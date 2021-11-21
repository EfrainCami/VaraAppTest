using System;
using System.Collections.Generic;
using System.Text;

namespace VarAPI.Exceptions
{
    public class Detail
    {
        public string campo { get; set; }
        public string valor { get; set; }
        public string problema { get; set; }
        public string localizacion { get; set; }
    }
    public class NetworkException
    {
        /**
         *
  "detail": [
    {
      "campo": "string",
      "valor": "string",
      "problema": "string",
      "localizacion": "string"
    }
  ],  
         */
        public string name { get; set; }
        public string debugId { get; set; }
        public string message { get; set; }
        public Detail[] detail { get; set; }
    }
}
