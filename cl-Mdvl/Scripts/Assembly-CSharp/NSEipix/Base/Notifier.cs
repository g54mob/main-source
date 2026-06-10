using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NSEipix.Base
{
	public sealed class Notifier
	{
		private HashSet<IObserver> observers;

		public Notifier()
		{
			observers = new HashSet<IObserver>();
		}

		public void Attach(IObserver observer)
		{
			if (!observers.Contains(observer))
			{
				observers.Add(observer);
			}
		}

		public void Detach(IObserver observer)
		{
			observers.Remove(observer);
		}

		public void RemoveAllObservers()
		{
			observers.Clear();
		}

		public void NotifyAll(string notification, params object[] parameters)
		{
			Notify(notification, delegate(MethodInfo method, IObserver observer)
			{
				method.Invoke(observer, parameters);
				return false;
			});
		}

		public void NotifyOne(string notification, params object[] parameters)
		{
			Notify(notification, delegate(MethodInfo method, IObserver observer)
			{
				object obj = method.Invoke(observer, parameters);
				return (obj is ConsumeFlag && (ConsumeFlag)obj == ConsumeFlag.CONSUME) ? true : false;
			});
		}

		public void NotifyCount(string notification, int count, params object[] parameters)
		{
			Notify(notification, delegate(MethodInfo method, IObserver observer)
			{
				object obj = method.Invoke(observer, parameters);
				count = ((obj is ConsumeFlag && (ConsumeFlag)obj == ConsumeFlag.CONSUME) ? (count - 1) : count);
				return count <= 0;
			});
		}

		private void Notify(string notification, Func<MethodInfo, IObserver, bool> action)
		{
			IObserver[] array = observers.ToArray();
			foreach (IObserver observer in array)
			{
				if (observer.Equals(null))
				{
					observers.Remove(observer);
					continue;
				}
				MethodInfo method = observer.GetType().GetMethod(notification, BindingFlags.Instance | BindingFlags.NonPublic);
				if (method != null && action(method, observer))
				{
					break;
				}
			}
		}
	}
}
