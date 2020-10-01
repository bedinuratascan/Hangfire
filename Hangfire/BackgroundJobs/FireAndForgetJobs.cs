using Hangfire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.BackgroundJobs
{
    public class FireAndForgetJobs
    {
        public static void SendEmailToUserJob(string userId,string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.Sender(userId, message));
        }
    }
}
