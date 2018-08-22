// Exclusive file (JS) for Ajax call

var urlApi = "http://casos.info/htmlextractor/api/"; // Published on this domain for example 

//Ajax Function to get all information about {CountryCode}
function GetPais(CountryCode){
    //Send Api POST
	//This GET will returns all information about selected country
    return $.ajax({
        type: "GET",
        url: urlApi + "cia/" + CountryCode,
        contentType: "application/json; charset=utf-8"
    });
}

function GetCountryList() {
	//Send Api POST
	//This GET returns a list of all countries avaliable
	return $.ajax({
		type: "GET",
		url: urlApi + "cia/countries",
		contentType: "application/json; charset=utf-8"
	});
}