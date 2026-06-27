using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameSettings.Observers
{
	public class GameSettingsLanguageChangeObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action<SystemLanguage>> subscriberEventHandlerDictionary = new Dictionary<object, Action<SystemLanguage>>();

		private readonly List<Action<SystemLanguage>> cachedEventHandlers = new List<Action<SystemLanguage>>();

		private readonly GameSettingsManager gameSettingsManager;

		public SystemLanguage Localization
		{
			get
			{
				if (!(gameSettingsManager != null))
				{
					return SystemLanguage.English;
				}
				return gameSettingsManager.Localization;
			}
		}

		public GameSettingsLanguageChangeObserver(GameSettingsManager globalStateMachine)
		{
			gameSettingsManager = globalStateMachine;
		}

		public void Initialize()
		{
			gameSettingsManager.OnLocalisationChanged.AddListener(ResolveOnLocalizationChanged);
		}

		public void Dispose()
		{
			gameSettingsManager.OnLocalisationChanged.RemoveListener(ResolveOnLocalizationChanged);
			subscriberEventHandlerDictionary.Clear();
		}

		public void AddSubscriber(object subscriber, Action<SystemLanguage> eventHandler)
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
			foreach (Action<SystemLanguage> cachedEventHandler in cachedEventHandlers)
			{
				cachedEventHandler?.Invoke(gameSettingsManager.Localization);
			}
			cachedEventHandlers.Clear();
		}

		private void ResolveOnLocalizationChanged(SystemLanguage newLanguage)
		{
			NotifyAll();
		}
	}
}
