// Exclusive file (JS) for Ajax call

var urlApi = "http://casos.info/htmlextractor/api/"; 

function GetPais(pais){
    //Send Api POST
    return $.ajax({
        type: "GET",
        url: urlApi + "cia/" + pais,
        contentType: "application/json; charset=utf-8"
    });
}