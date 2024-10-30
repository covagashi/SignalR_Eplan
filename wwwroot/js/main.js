$(document).ready(function () {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/testHub")
        .build();

    connection.on("ReceiveMessage", function (message) {
        $("#messages").append(`<div>${message}</div>`);
    });

    connection.start()
        .then(() => {
            $("#connectionStatus").text("Connected");
        })
        .catch(err => {
            $("#connectionStatus").text("Connection failed");
            console.error(err);
        });
});