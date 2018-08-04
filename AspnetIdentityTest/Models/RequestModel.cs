using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetIdentityTest.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public string Operator { get; set; }
        
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public string ClientName { get; set; }
        public string Executor { get; set; }
        public string SolutionComment { get; set; }
        public string State { get; set; }
    }
}