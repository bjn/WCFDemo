using System;
using WCFDemo.Contracts;

namespace WCFDemo.Service
{
    public class Demo : IDemo
    {
        [RequestCountBehavior]
        public DateTime GetUtcDate()
        {           
            return DateTime.UtcNow;
        }

        public int GetTotalNumberOfRequests()
        {
            return CountOperation.GetCount();
        }
    }
}
