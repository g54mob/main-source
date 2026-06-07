using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class PriorityEvent
	{
		protected struct EventSubscription
		{
			public Action Method;

			public int Priority;
		}

		private readonly List<EventSubscription> _subscribedMethods = new List<EventSubscription>();

		private int _index;

		public void Invoke()
		{
			for (_index = 0; _index < _subscribedMethods.Count; _index++)
			{
				_subscribedMethods[_index].Method();
			}
		}

		public void Subscribe(Action method, int priority)
		{
			int num = _subscribedMethods.Count;
			for (int i = 0; i < _subscribedMethods.Count; i++)
			{
				if (_subscribedMethods[i].Priority > priority)
				{
					num = i;
					break;
				}
			}
			EventSubscription item = new EventSubscription
			{
				Method = method,
				Priority = priority
			};
			_subscribedMethods.Insert(num, item);
			if (num <= _index)
			{
				_index++;
			}
		}

		public void Unsubscribe(Action method)
		{
			int num = -1;
			for (int i = 0; i < _subscribedMethods.Count; i++)
			{
				if (_subscribedMethods[i].Method == method)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				_subscribedMethods.RemoveAt(num);
				if (num <= _index)
				{
					_index--;
				}
			}
		}
	}
}
