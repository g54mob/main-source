using System;
using System.Collections.Generic;
using Restory.Infrastructure.StateMachine.States;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Zenject;

namespace Restory.Infrastructure.StateMachine
{
	public class GlobalStateObserver : IInitializable, IDisposable
	{
		private readonly Dictionary<object, Action> subscriberEventHandlerDictionary = new Dictionary<object, Action>();

		private readonly GlobalStateMachine globalStateMachine;

		private readonly List<Action> cachedEventHandlers = new List<Action>();

		public IExitableState ActiveState => globalStateMachine?.ActiveState;

		public bool IsInGameLoop => ActiveState is GameLoopState;

		public bool IsInInitializationState => globalStateMachine?.IsInInitializationState ?? false;

		public bool IsLoading
		{
			get
			{
				if (!IsInInitializationState)
				{
					return ActiveState is LoadProgressState;
				}
				return true;
			}
		}

		public GlobalStateObserver(GlobalStateMachine globalStateMachine)
		{
			this.globalStateMachine = globalStateMachine;
		}

		public void Initialize()
		{
			globalStateMachine.OnActiveStateChanged += ResolveOnGlobalStateMachineActiveStateChanged;
			ResolveOnGlobalStateMachineActiveStateChanged();
		}

		public void Dispose()
		{
			globalStateMachine.OnActiveStateChanged -= ResolveOnGlobalStateMachineActiveStateChanged;
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

		private void ResolveOnGlobalStateMachineActiveStateChanged()
		{
			NotifyAll();
		}
	}
}
