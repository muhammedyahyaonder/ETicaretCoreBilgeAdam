// withtout session or local storage
//$(document).ready(function () {
//    $('#sidebarCollapse').on('click', function (event) {
//        event.preventDefault();
//        $('#sidebar').toggleClass('active');
//        var text = $('#s-collapse').text();
//        if (text === '<') {
//            $('#s-collapse').text('>');
//            $('#sidebarCollapse').attr('title', 'Open Menu');
//        } else {
//            $('#s-collapse').text('<');
//            $('#sidebarCollapse').attr('title', 'Close Menu');
//        }
//    });
//});

// with session or local storage
$(document).ready(function () {
    //var sideBar = localStorage.getItem("sidebar"); // tarayıcı kapandıktan sonra tarayıcı storage'ında tutulmaya devam eder
    var sideBar = sessionStorage.getItem("sidebar"); // tarayıcı kapandıktan sonra tarayıcı storage'ından siler
    if (sideBar == null) {
        sideBar = "1";
        sessionStorage.setItem("sidebar", "1");
    }
    if (sideBar === "1") {
        $('#s-collapse').text('<');
        $('#sidebarCollapse').attr('title', 'Soldaki Menüyü Kapat');
        $('#sidebar').removeAttr("style");
        $('#sidebar').removeClass("active");
    } else {
        $('#s-collapse').text('>');
        $('#sidebarCollapse').attr('title', 'Soldaki Menüyü Aç');
        $('#sidebar').css("display", "none");
        $('#sidebar').addClass("active");
    }
    $('#sidebarCollapse').on('click', function (event) {
        event.preventDefault();
        sideBar = sessionStorage.getItem("sidebar");
        if (sideBar === "1") {
            sideBar = "0";
        } else {
            sideBar = "1";
        }
        sessionStorage.setItem("sidebar", sideBar);
        window.location.reload(); // tarayıcıyı bulunduğu url'ye yönlendirir
    });
});