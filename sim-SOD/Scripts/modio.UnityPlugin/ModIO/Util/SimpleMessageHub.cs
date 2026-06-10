using System;
using System.Collections.Generic;

namespace ModIO.Util
{
	public class SimpleMessageHub : SelfInstancingMonoSingleton<SimpleMessageHub>
	{
		private readonly Dictionary<Type, List<Action<ISimpleMessage>>> dictionary;

		private List<ISimpleMessage> threadSafeMessages;

		public SimpleMessageUnsubscribeToken Subscribe<T>(Action<T> subscription) where T : class, ISimpleMessage
		{
			return null;
		}

		public void Publish<T>(T message) where T : class, ISimpleMessage
		{
		}

		public void PublishThreadSafe<T>(T message) where T : class, ISimpleMessage
		{
		}

		private void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void ClearTypeSubscriptions<T>()
		{
		}
	}
}
