$(document).ready(function () {
    var assetPush = $.connection('assetPush');

    assetPush.received(function (data) {
        $('#top').append("<span>" + data + "</span>");
    });

    assetPush.start();

    $('#xxx').click(function () {
        assetPush.send("widget");
    });
    
});