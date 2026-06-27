using System;
using System.Collections.Generic;
using Zenject;

namespace Restory.UniversalPlatform.Observers
{
	public class PlatformManagerMainInitializationObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action> subscriberEventHandlerDictionary = new Dictionary<object, Action>();

		private readonly PlatformManager platformManager;

		private readonly List<Action> cachedEventHandlers = new List<Action>();

		public PlatformManagerMainInitializationObserver(PlatformManager platformManager)
		{
			this.platformManager = platformManager;
		}

		public void Initialize()
		{
			platformManager.MainInitialized += ResolveOnChanged;
		}

		public void Dispose()
		{
			platformManager.MainInitialized -= ResolveOnChanged;
			subscriberEventHandlerDictionary.Clear();
		}

		public void AddSubscriber(object subscriber, Action eventHandler)
		{
			if (subscriber != null && eventHandler != null && !subscriberEventHandlerDictionary.ContainsKey(subscriber))
			{
				subscriberEventHandlerDictionary.Add(subscriber, eventHandler);
			}
		}

		public void RemoveSubscriber(object subscriber)
		{
			subscriberEventHandlerDictionary.Remove(subscriber);
		}

		private void ResolveOnChanged()
		{
			cachedEventHandlers.AddRange(subscriberEventHandlerDictionary.Values);
			foreach (Action cachedEventHandler in cachedEventHandlers)
			{
				cachedEventHandler?.Invoke();
			}
			cachedEventHandlers.Clear();
		}
	}
}
