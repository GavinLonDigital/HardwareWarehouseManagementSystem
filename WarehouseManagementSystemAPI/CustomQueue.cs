using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystemAPI
{
    public delegate void QueueEventHandler<T, U>(T sender, U eventArgs);
    public class CustomQueue<T> where T:IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        Queue<T> _queue = null;

        public event QueueEventHandler<CustomQueue<T>, QueueEventArgs> CustomQueueEvent;

        public CustomQueue()
        {
            _queue = new Queue<T>();
        }

        public int QueueLength
        {
            get {
                return _queue.Count;
            }
        }
        public void AddItem(T item)
        {
            _queue.Enqueue(item);

            QueueEventArgs queueEventArgs = new QueueEventArgs { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id ({item.Id}), Name ({item.Name}), Type ({item.Type}), Quantity ({item.Quantity}), has been added to the queue." };

            OnQueueChanged(queueEventArgs);


        }
        public T GetItem()
        {
            T item = _queue.Dequeue();
            
            QueueEventArgs queueEventArgs = new QueueEventArgs { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id ({item.Id}), Name ({item.Name}), Type ({item.Type}), Quantity ({item.Quantity}), has been processed." };

            OnQueueChanged(queueEventArgs);

            return item;

        }
        protected virtual void OnQueueChanged(QueueEventArgs a)
        {
            CustomQueueEvent(this, a);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }

    public class QueueEventArgs:System.EventArgs
    { 
        public string Message { get; set; }
    
    }
    
}
