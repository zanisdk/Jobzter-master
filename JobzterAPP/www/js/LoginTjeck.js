if (localStorage.getItem("user") != null) {
    var id = localStorage.getItem("user");

    $.ajax({
        type: 'GET',
        url: 'http://www.dykkerspots.dk/api/LoginTjek/' + id,
        success: function (data) {
            if (data === false) {
                localStorage.removeItem("user");
                localStorage.removeItem("level");
                window.location.assign("index.html");
            }
        }
    });
}