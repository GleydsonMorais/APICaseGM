# APICaseGM
Criação de uma API para teste de Backend.

WEB API criada em C# com DB em Sql Server.

A API foi desenvolvida em Asp.Net Entity Framework C#, onde primeiro foi modelado os obijetos do DB na pasta Model tem os objetos Caminhoneiro e Caminhao.
Depois foi mapeado os objetos criado com o DB na pasta Data/Mapping.
E foi criado o arquivo de conexão com o DB Data/DataContext.cs

Metodos:

APIController api = new APIControllerM();

api.PostCaminhoneiro(caminhoneiro); <br/>
api.GetCaminhoneiro(id);
api.EditCaminhoneiro(caminhoneito);
api.GetListCaminhoneiroCarga(id);
api.GetListCaminhoneiroPeriodo(dataInicio, dataFinal);
api.GetListCaminhoneiroComVeiculos();
api.GetListCaminhoneiroPorCaminhao();

O primeiro metodo recebe um objeto do tipo Caminhoneiro e grava no DB, e retorno uma mensagem de sucesso.
O segundo metodo recebe o ID do Caminhoneiro e retorna um objeto Caminhoneiro.
O terceiro metodo recebe um objeto do tipo Caminhoneiro e edita no DB, e retorno uma mensagem de sucesso.
O quarto metodo recbe um ID ("S" ou "N") e retorna a lista de caminhoneiros que esta carregado ou não.
O quinto metodo recebe duas datas (dataInicio e dataFinal), se data fical for nula, retornara a lista de caminhoneiros que passou pelo terminao na dataInicio e a dataFinal não for nula, retonarar uma lista de caminhoneiros que passaram pelo terminal naquele periodo de tempo, que pose ser uma semana, mes, ano. vai do periodo que queira pesquisar.
O sexto metodo não recebe nenhum parametro e retonar uma lista de caminhoneiro que possuem Caminhão proprio.
o setimo metdo não recebe nenhum parametro e retorna uma lista de origem e destino agrupada por tipo de caminhao.
