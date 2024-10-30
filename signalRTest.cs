using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Eplan.EplApi.Base;

public class Script
{
    private const string ApiUrl = "http://localhost:5210/api/messages";

    [Start]
    public void TestHttpMessaging()
    {
        try
        {
            using (var client = new HttpClient())
            {
                // Enviar mensajes a través de solicitudes HTTP POST
                SendMessage(client, "Starting HTTP messaging test...");
                System.Threading.Thread.Sleep(1000);

                SendMessage(client, "Test message from EPLAN");
                System.Threading.Thread.Sleep(1000);

                SendMessage(client, "HTTP messaging test completed!");
            }

            LogMessage("Messages sent successfully");
        }
        catch (Exception ex)
        {
            LogError("Test failed: " + ex.Message);
        }
    }

    private void SendMessage(HttpClient client, string message)
    {
        var json = "{\"message\":\"" + message + "\"}";
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = client.PostAsync(ApiUrl, content).Result;
        response.EnsureSuccessStatusCode();
    }

    private void LogMessage(string message)
    {
        new BaseException(message, MessageLevel.Message).FixMessage();
    }

    private void LogError(string message)
    {
        new BaseException(message, MessageLevel.Error).FixMessage();
    }
}