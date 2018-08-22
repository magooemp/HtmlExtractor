$(document).ready(function(){
    console.log('tela carregada, vamos carregar a grid...');
   carregarGrid('US');
});

//Executar pesquisa com base no pais selecionado
function pesquisar()
{
    var pais = $("#ddlPais").val();
    carregarGrid(pais);
}

///Carregar grid com os valores da api
function carregarGrid(pais)
{
    console.log('funcao para carregar a grid chamada...');

    GetPais(pais).then(paises =>
    {
        console.log('paises retornadas da api -> ', paises);

        //Limpar grid
        $('#tablecontent').html('');

        //Carregar tabela
        paises.forEach(item => {
            $('#tablecontent').append(
                '<tr><td>' + item.Country + '</td><td>' + item.Category + '</td><td>' + item.Title + '</td><td>' + item.Value +'</td></tr>'
            );
        });
    });
}
