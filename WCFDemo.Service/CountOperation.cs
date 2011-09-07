using System;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace WCFDemo.Service
{ 
    public class CountOperation : IOperationInvoker
    {
        private static int _counter;
        private readonly IOperationInvoker _invoker;

        public static int GetCount()
        {
            return _counter;
        }

        public CountOperation(IOperationInvoker invoker)
        {
            _invoker = invoker;
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            Interlocked.Increment(ref _counter);

            return _invoker.Invoke(instance, inputs, out outputs);
        }

        public object[] AllocateInputs()
        {
            return _invoker.AllocateInputs();
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return _invoker.InvokeBegin(instance, inputs, callback, state);
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return _invoker.InvokeEnd(instance, out outputs, result);
        }

        public bool IsSynchronous
        {
            get { return _invoker.IsSynchronous; }
        }
    }
}