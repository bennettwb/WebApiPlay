$(document).ready(function () {
    var assetPush = $.connection('assetPush');

    assetPush.received(function (data) {
        // $('#top').append("<span>" + data + "</span>");
        var asset = $.parseJSON(data);
        var img = new Image();
        img.src = asset.AssetThumbnails[0].URL;
        var current = window.rx.image(asset.AssetThumbnails[0].URL, lon2x(asset.long), lat2y(asset.lat), img.width / 2, img.height / 2).attr({ opacity: 0 });

        var after = current.animate({ opacity: 1 }, 1000, "easeIn").glow();

        var remove = Raphael.animation({ params: { opacity: 0 }, ms: 2000, easing: "easeIn", callback: function () {
            this.remove();
        }
        });
        after.animate(remove.delay(4000));
        current.animate(remove.delay(4000));

    });

    assetPush.start();

    $('#xxx').click(function () {
        assetPush.send("widget");
    });

});