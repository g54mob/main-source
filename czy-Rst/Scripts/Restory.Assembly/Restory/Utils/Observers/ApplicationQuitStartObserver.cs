using System;
using System.Collections.Generic;
using Zenject;

namespace Restory.Utils.Observers
{
	public class ApplicationQuitStartObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action> subscriberEventHandlerDictionary = new Dictionary<object, Action>();

		private readonly ApplicationQuitDetectionService applicationQuitDetectionService;

		private readonly List<Action> cachedEventHandlers = new List<Action>();

		public bool IsInQuit => applicationQuitDetectionService.IsInQuit;

		public ApplicationQuitStartObserver(ApplicationQuitDetectionService applicationQuitDetectionService)
		{
			this.applicationQuitDetectionService = applicationQuitDetectionService;
		}

		public void Initialize()
		{
			applicationQuitDetectionService.OnStartQuit += ResolveOnChanged;
		}

		public void Dispose()
		{
			applicationQuitDetectionService.OnStartQuit -= ResolveOnChanged;
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
