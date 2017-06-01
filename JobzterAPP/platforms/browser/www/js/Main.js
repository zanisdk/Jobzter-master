

function navigate(loca, id) {
    //alert(loca + id);
    if (id > 0) {
        window.localStorage.setItem("id", id);
    }
    window.location.assign(loca + ".html");
}

function SoegSpot() {

    window.localStorage.setItem("key", $("#soeg").val());
    window.location.assign("Soeg.html");
}

function navigateMap(id) {
    window.localStorage.setItem("id", id);
    window.location.assign("VisSpot.html");
}

function goBack() {
    window.history.back();
}

function toDec(pos) {
    var arrpos = pos.split('.');
    var newpos = arrpos[0] + arrpos[1] + "." + arrpos[2];

    var PosDb = newpos; //Replace . with , (Used in danish doubles);
    var Deg = Math.floor(PosDb / 100);
    var DecPos = Deg + ((PosDb - (Deg * 100)) / 60);

    return DecPos; //=56.0172
}

$(function () {

    if (window.localStorage.getItem("level") === null) {
        $("#adminMenu").hide();
    } else {
        if (parseInt(window.localStorage.getItem("level")) < 2) {
            $("#adminMenu").hide();
        } else {
            $("#adminMenu").show();
        }
    }

});
