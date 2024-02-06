using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyEventWebAPI.Models
{
    public class ResponseMCls
    {
        public string ResponseCode { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
    }
}