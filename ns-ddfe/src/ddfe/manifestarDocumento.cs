using Newtonsoft.Json;
using ns_ddfe.src.commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ns_ddfe.src.ddfe.eventos
{
    public class ManifestarDocumento
    {
        public class Body
        {
            public string CNPJInteressado { get; set; }
            public string nsu { get; set; }
            public string chave { get; set; }

            public Manifestacao manifestacao { get; set; }

            public class Manifestacao
            {
                public string tpEvento { get; set; }
                public string xJust { get; set; }
            }
        }

        public class Response
        {
            public string status { get; set; }
            public string motivo { get; set; }
            public dynamic retEvento { get; set; }
            public string erro { get; set; }

        }

        public static async Task<Response> sendPostRequest(Body requestBody)
        {
            string url = "https://ddfe.ns.eti.br/events/manif";

            var responseAPI = JsonConvert.DeserializeObject<Response>(await nsAPI.postRequest(url, JsonConvert.SerializeObject(requestBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })));

            return responseAPI;
        }
    }
}
