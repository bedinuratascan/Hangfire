using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob", () => EmailReport(),Cron.Minutely);
        }

        public static void EmailReport()
        {
            Debug.WriteLine("Rapor, email olarak gönderildi.");
        }

    }
}
