using System;
using System.Collections.Generic;
using Zenject;

namespace Restory.Gameplay.GameSettings.Observers
{
	public class GameSettingsTextSizeChangeObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action<TextSize?>> subscriberEventHandlerDictionary = new Dictionary<object, Action<TextSize?>>();

		private readonly List<Action<TextSize?>> cachedEventHandlers = new List<Action<TextSize?>>();

		private readonly GameSettingsManager gameSettingsManager;

		public TextSize? TextSize
		{
			get
			{
				if (!(gameSettingsManager != null) || !gameSettingsManager.IsInitialized)
				{
					return null;
				}
				return gameSettingsManager.TextSize;
			}
		}

		public GameSettingsTextSizeChangeObserver(GameSettingsManager globalStateMachine)
		{
			gameSettingsManager = globalStateMachine;
		}

		public void Initialize()
		{
			gameSettingsManager.TextSizeChanged += ResolveOnLocalizationChanged;
		}

		public void Dispose()
		{
			gameSettingsManager.TextSizeChanged -= ResolveOnLocalizationChanged;
			subscriberEventHandlerDictionary.Clear();
		}

		public void AddSubscriber(object subscriber, Action<TextSize?> eventHandler)
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
			foreach (Action<TextSize?> cachedEventHandler in cachedEventHandlers)
			{
				cachedEventHandler?.Invoke(gameSettingsManager.TextSize);
			}
			cachedEventHandlers.Clear();
		}

		private void ResolveOnLocalizationChanged(TextSize? textSize)
		{
			NotifyAll();
		}
	}
}
