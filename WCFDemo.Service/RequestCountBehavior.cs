using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WCFDemo.Service
{
    public class RequestCountBehavior : Attribute,IOperationBehavior
    {
        public void Validate(OperationDescription operationDescription)
        {
            
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            IOperationInvoker invoker = dispatchOperation.Invoker;
            dispatchOperation.Invoker = new CountOperation(invoker);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
           
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
         
        }
    }
}