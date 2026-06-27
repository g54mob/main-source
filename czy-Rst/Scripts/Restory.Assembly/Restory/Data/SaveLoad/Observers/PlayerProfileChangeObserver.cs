using System;
using System.Collections.Generic;
using Zenject;

namespace Restory.Data.SaveLoad.Observers
{
	public class PlayerProfileChangeObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action> subscriberEventHandlerDictionary = new Dictionary<object, Action>();

		private readonly PlayerProfileService playerProfileService;

		private readonly List<Action> cachedEventHandlers = new List<Action>();

		public PlayerProfileChangeObserver(PlayerProfileService playerProfileService)
		{
			this.playerProfileService = playerProfileService;
			playerProfileService.OnProfileChanged += NotifyAll;
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
			playerProfileService.OnProfileChanged -= NotifyAll;
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

		public void NotifyAll()
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
