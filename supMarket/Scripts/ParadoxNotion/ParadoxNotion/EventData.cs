using UnityEngine;

namespace ParadoxNotion
{
	public struct EventData : IEventData
	{
		public GameObject receiver { get; private set; }

		public object sender { get; private set; }

		public object value { get; private set; }

		public object valueBoxed => null;

		public EventData(object value, GameObject receiver, object sender)
		{
			this.receiver = null;
			this.sender = null;
			this.value = null;
		}

		public EventData(GameObject receiver, object sender)
		{
			this.receiver = null;
			this.sender = null;
			value = null;
		}
	}
	public struct EventData<T> : IEventData
	{
		public GameObject receiver { get; private set; }

		public object sender { get; private set; }

		public T value { get; private set; }

		public object valueBoxed => null;

		public EventData(T value, GameObject receiver, object sender)
		{
			this.receiver = null;
			this.sender = null;
			this.value = default(T);
		}
	}
}
