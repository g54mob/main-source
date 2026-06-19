using System.Threading;
using System.Threading.Tasks;
using Loxodon.Framework.Messaging;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class MessengerExample : MonoBehaviour
	{
		private IMessenger messenger;

		private ISubscription<TestMessage> subscription;

		private ISubscription<TestMessage> subscriptionInUIsThread;

		public IMessenger Messenger => messenger;

		private void Start()
		{
			messenger = new Messenger();
			subscription = messenger.Subscribe<TestMessage>(OnMessage);
			subscriptionInUIsThread = messenger.Subscribe<TestMessage>(OnMessageInUIThread).ObserveOn(SynchronizationContext.Current);
			Task.Run(delegate
			{
				messenger.Publish(new TestMessage(this, "This is a test."));
			});
		}

		protected void OnMessage(TestMessage message)
		{
			Debug.LogFormat("ThreadID:{0} Received:{1}", Thread.CurrentThread.ManagedThreadId, message.Content);
		}

		protected void OnMessageInUIThread(TestMessage message)
		{
			Debug.LogFormat("ThreadID:{0} Received:{1}", Thread.CurrentThread.ManagedThreadId, message.Content);
		}

		private void OnDestroy()
		{
			if (subscription != null)
			{
				subscription.Dispose();
				subscription = null;
			}
			if (subscriptionInUIsThread != null)
			{
				subscriptionInUIsThread.Dispose();
				subscriptionInUIsThread = null;
			}
		}
	}
}
