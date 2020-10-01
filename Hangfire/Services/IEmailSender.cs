using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Services
{
    interface IEmailSender
    {
        Task Sender(string userId, string message);
    }
}
