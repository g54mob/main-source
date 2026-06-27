using System;
using System.Collections.Generic;
using Zenject;

namespace Restory.Utils.Observers
{
	public class ApplicationGetFocusObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action> subscriberEventHandlerDictionary = new Dictionary<object, Action>();

		private readonly ApplicationFocusDetectionService applicationFocusDetectionService;

		private readonly List<Action> cachedEventHandlers = new List<Action>();

		public ApplicationGetFocusObserver(ApplicationFocusDetectionService applicationFocusDetectionService)
		{
			this.applicationFocusDetectionService = applicationFocusDetectionService;
		}

		public void Initialize()
		{
			applicationFocusDetectionService.OnApplicationGotFocus.AddListener(ResolveOnChanged);
		}

		public void Dispose()
		{
			applicationFocusDetectionService.OnApplicationGotFocus.RemoveListener(ResolveOnChanged);
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
