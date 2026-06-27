using System;
using System.Collections.Generic;
using Rewired;
using Zenject;

namespace Restory.Gameplay.PlayerInput.Observers
{
	public sealed class RewiredControllerConnectedObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action<int, ControllerType>> subscriberEventHandlerDictionary = new Dictionary<object, Action<int, ControllerType>>();

		private readonly List<Action<int, ControllerType>> cachedEventHandlers = new List<Action<int, ControllerType>>();

		public void Initialize()
		{
			ReInput.ControllerConnectedEvent += ResolveOnChanged;
		}

		public void Dispose()
		{
			ReInput.ControllerConnectedEvent -= ResolveOnChanged;
			subscriberEventHandlerDictionary.Clear();
		}

		public void AddSubscriber(object subscriber, Action<int, ControllerType> eventHandler)
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

		private void ResolveOnChanged(ControllerStatusChangedEventArgs controllerStatusChangedEventArgs)
		{
			cachedEventHandlers.AddRange(subscriberEventHandlerDictionary.Values);
			foreach (Action<int, ControllerType> cachedEventHandler in cachedEventHandlers)
			{
				cachedEventHandler?.Invoke(controllerStatusChangedEventArgs.controllerId, controllerStatusChangedEventArgs.controllerType);
			}
			cachedEventHandlers.Clear();
		}
	}
}
