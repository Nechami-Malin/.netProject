using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.model.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public BaseResponse()
        {
            Success = true;
        }
    }
}
