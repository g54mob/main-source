using System;
using System.Collections.Generic;
using Zenject;

namespace Restory.UniversalPlatform.Observers
{
	public class PlatformAchievementsManagerAchievementsReceivedObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action> subscriberEventHandlerDictionary = new Dictionary<object, Action>();

		private readonly PlatformAchievementsManager platformAchievementsManager;

		private readonly List<Action> cachedEventHandlers = new List<Action>();

		public PlatformAchievementsManagerAchievementsReceivedObserver(PlatformAchievementsManager platformAchievementsManager)
		{
			this.platformAchievementsManager = platformAchievementsManager;
		}

		public void Initialize()
		{
			platformAchievementsManager.AchievementsReceived += ResolveOnChanged;
		}

		public void Dispose()
		{
			platformAchievementsManager.AchievementsReceived -= ResolveOnChanged;
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
