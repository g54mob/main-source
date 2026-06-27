using System;
using System.Collections.Generic;
using Rewired;
using Zenject;

namespace Restory.Gameplay.PlayerInput.Observers
{
	public sealed class RewiredInitializedObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action> subscriberEventHandlerDictionary = new Dictionary<object, Action>();

		private readonly List<Action> cachedEventHandlers = new List<Action>();

		public bool IsReady => ReInput.isReady;

		public RewiredInitializedObserver()
		{
			ReInput.InitializedEvent += ResolveOnChanged;
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
			ReInput.InitializedEvent -= ResolveOnChanged;
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
