using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Errors
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        string IServiceException.Message => "Email Already Exist";
    }
}
