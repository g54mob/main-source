using System;
using System.Collections.Generic;

namespace ModIO.Util
{
	public class SimpleMessageHub : SelfInstancingMonoSingleton<SimpleMessageHub>
	{
		private readonly Dictionary<Type, List<Action<ISimpleMessage>>> dictionary = new Dictionary<Type, List<Action<ISimpleMessage>>>();

		private List<ISimpleMessage> threadSafeMessages = new List<ISimpleMessage>();

		public SimpleMessageUnsubscribeToken Subscribe<T>(Action<T> subscription) where T : class, ISimpleMessage
		{
			Type t = typeof(T);
			if (!dictionary.ContainsKey(t))
			{
				dictionary.Add(t, new List<Action<ISimpleMessage>>());
			}
			Action<ISimpleMessage> actionWrapper = delegate(ISimpleMessage x)
			{
				subscription(x as T);
			};
			dictionary[t].Add(actionWrapper);
			return new SimpleMessageUnsubscribeToken(delegate
			{
				if (dictionary.ContainsKey(t))
				{
					dictionary[t].Remove(actionWrapper);
				}
			});
		}

		public void Publish<T>(T message) where T : class, ISimpleMessage
		{
			Type typeFromHandle = typeof(T);
			if (!dictionary.ContainsKey(typeFromHandle))
			{
				return;
			}
			foreach (Action<ISimpleMessage> item in dictionary[typeFromHandle])
			{
				item(message);
			}
		}

		public void PublishThreadSafe<T>(T message) where T : class, ISimpleMessage
		{
			lock (threadSafeMessages)
			{
				threadSafeMessages.Add(message);
			}
		}

		private void Update()
		{
			lock (threadSafeMessages)
			{
				foreach (ISimpleMessage threadSafeMessage in threadSafeMessages)
				{
					Publish(threadSafeMessage);
				}
				threadSafeMessages.Clear();
			}
		}

		protected override void OnDestroy()
		{
			dictionary.Clear();
		}

		public void ClearTypeSubscriptions<T>()
		{
			if (dictionary.ContainsKey(typeof(T)))
			{
				dictionary[typeof(T)].Clear();
			}
		}
	}
}
