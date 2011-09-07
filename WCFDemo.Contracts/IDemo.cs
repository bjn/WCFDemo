using System;
using System.ServiceModel;

namespace WCFDemo.Contracts
{
    [ServiceContract]
    public interface IDemo
    {
        [OperationContract]
        DateTime GetUtcDate();
        
        [OperationContract]
        int GetTotalNumberOfRequests();
    }
}
