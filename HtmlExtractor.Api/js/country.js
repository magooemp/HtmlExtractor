$(document).ready(function(){
    console.log('[debug] Html loaded');
	LoadCountries();    // Load the list of couutries from http://casos.info/htmlextractor/api/cia/countries
	LoadCountry('xx'); // xx = World, us=UnitedStates, br=Brazil
	});

//Executar pesquisa com base no pais selecionado
function GetData()
{
	var CountryCode = $("#ddlCountry").val();
	LoadCountry(CountryCode);
}
 
//function Download_CSV(CountryCode) {
//	console.log('DownloadCSV...');
////Chamar URL download CSV
//}

//function Download_XML(CountryCode) {
//	console.log('DownloadXML...');
//	//Chamar URL download CSV
//}


///Carregar grid com os valores da api
function LoadCountry(CountryCode)
{
    console.log('funcao para carregar a grid chamada...');

	GetPais(CountryCode).then(countriesInfo =>
    {
		console.log('paises retornadas da api -> ', countriesInfo);

        //Limpar grid
        $('#tablecontent').html('');

        //Carregar tabela
		countriesInfo.forEach(item => {
            $('#tablecontent').append(
                '<tr><td>' + item.Country + '</td><td>' + item.Category + '</td><td>' + item.Title + ' '+item.Subtitle + '</td><td>' + item.Value +'</td></tr>'
            );
        });
	});
	
}

//Load list of countries from CiaFactBook
function LoadCountries() {
	console.log('LoadCountries()...');

	GetCountryList().then(countries => {
		console.log('paises retornadas da api para combo -> ', countries);

		//Limpar grid
		$('#ddlCountry').html('');

		//Carregar tabela
		countries.forEach(item => {
			console.log(item);
			$('#ddlCountry').append( 
				'<option value = "' + item.CountryCode + '">' + item.CountryName+'</option >'
			);
		});
	});
}

