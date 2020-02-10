using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OracleDotNetProjectwithWebService.Models
{
    public class Model
    {
        public WebService ModelWebService { get; set; }

        // Constructor
        public Model()
        {
            ModelWebService = new WebService();
        }
    }
}