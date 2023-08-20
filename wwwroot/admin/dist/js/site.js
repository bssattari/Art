$(function () {
    $('.custom-control-input').click(function () {
        var btn = $(this)
        var id = btn.data("id")
        var type = btn.data("type")
        var url = "/admin/" + type + "/isview/" + id        

        $.ajax({
            type: 'GET',
            url: url,
            dataType: "html",
            success: function (data) {
               console.log(data)
            },
        });
    })
})