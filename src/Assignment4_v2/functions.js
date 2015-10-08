var webURL = "http://localhost:52526/api/StarWars";


function forceGetFunc() {
    $.ajax(webURL, {
        method: "GET",
        success: simpleResponse
    });
}


function forcePatchFunc() {
    $.ajax(webURL + "/" + document.getElementById("index").value, {
        method: "PATCH",
        processData: false,
        contentType: "application/json",
        success: simpleResponse,
        data: JSON.stringify({
            FirstName: document.getElementById("first-name").value,
            NumberOfTimes: document.getElementById("num-times").value
        })
    });
}


function forcePushFunc() {
    $.ajax(webURL, {
        method: "POST",
        processData: false,
        contentType: "application/json",
        success: simpleResponse,        
        data: JSON.stringify({
            FirstName: document.getElementById("first-name").value,
            Character: document.getElementById("character").value
        })
        
    });
}


function simpleResponse(data) {
    document.getElementById("result").innerHTML = JSON.stringify(data);   
}