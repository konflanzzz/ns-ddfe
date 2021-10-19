using System;
using System.Threading.Tasks;
using ns_ddfe.src.ddfe.unique;
using ns_ddfe.src.ddfe.bunch;
using ns_ddfe.src.ddfe.eventos;

namespace ns_ddfe_core
{
    class Program
    {
        static async Task Main()
        {
            configParceiro.token = "";
            await manifestarDocumento();
        }

        static async Task downloadUnico()
        {
            var requisicaoDownloadUnico = new DownloadUnico.Body
            {
                CNPJInteressado = "",
                chave = "",
                apenasComXml = true,
                comEventos = false,
                incluirPDF = true,
            };

            var retornoDownload = await DownloadUnico.sendPostRequest(requisicaoDownloadUnico, @"DDFe/");
            Console.WriteLine();
        }

        static async Task downlaodLote()
        {
            var requisicaoDownloadLote = new DownloadLote.Body
            {
                CNPJInteressado = "",
                tpAmb = 2,
                incluirPDF = false,
                modelo = 55,
                apenasComXml = true,
            };

            var retornoDownload = await DownloadLote.sendPostRequest(requisicaoDownloadLote, @"DDFe/", true);
            Console.WriteLine(retornoDownload);
        }

        static async Task manifestarDocumento() 
        {
            var requisicaoManifestarDocumento = new ManifestarDocumento.Body
            {
                chave = "",
                CNPJInteressado = "",
                manifestacao = new ManifestarDocumento.Body.Manifestacao
                {
                    tpEvento = "",
                    xJust = "TESTE FAVOR DESCONSIDERAR"
                }

            };

            var retornoManifestarDocumento = await ManifestarDocumento.sendPostRequest(requisicaoManifestarDocumento);
            Console.WriteLine(retornoManifestarDocumento);
        }
    }
}
