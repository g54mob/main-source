using System;
using System.Collections.Generic;
using System.Linq;

namespace Stateless.Reflection
{
	public class StateInfo
	{
		public object UnderlyingState { get; }

		public ICollection<StateInfo> Substates { get; private set; }

		public StateInfo Superstate { get; private set; }

		public IEnumerable<ActionInfo> EntryActions { get; private set; }

		public IEnumerable<InvocationInfo> ActivateActions { get; private set; }

		public IEnumerable<InvocationInfo> DeactivateActions { get; private set; }

		public IEnumerable<InvocationInfo> ExitActions { get; private set; }

		public IEnumerable<TransitionInfo> Transitions
		{
			get
			{
				if (FixedTransitions != null)
				{
					return ((IEnumerable<TransitionInfo>)FixedTransitions).Concat((IEnumerable<TransitionInfo>)DynamicTransitions);
				}
				return null;
			}
		}

		public IEnumerable<FixedTransitionInfo> FixedTransitions { get; private set; }

		public IEnumerable<DynamicTransitionInfo> DynamicTransitions { get; private set; }

		public IEnumerable<IgnoredTransitionInfo> IgnoredTriggers { get; private set; }

		internal static StateInfo CreateStateInfo<TState, TTrigger>(StateMachine<TState, TTrigger>.StateRepresentation stateRepresentation)
		{
			if (stateRepresentation == null)
			{
				throw new ArgumentException("stateRepresentation");
			}
			List<IgnoredTransitionInfo> list = new List<IgnoredTransitionInfo>();
			foreach (KeyValuePair<TTrigger, List<StateMachine<TState, TTrigger>.TriggerBehaviour>> triggerBehaviour in stateRepresentation.TriggerBehaviours)
			{
				foreach (StateMachine<TState, TTrigger>.TriggerBehaviour item in triggerBehaviour.Value)
				{
					if (item is StateMachine<TState, TTrigger>.IgnoredTriggerBehaviour behaviour)
					{
						list.Add(IgnoredTransitionInfo.Create(behaviour));
					}
				}
			}
			return new StateInfo(stateRepresentation.UnderlyingState, list, stateRepresentation.EntryActions.Select((StateMachine<TState, TTrigger>.EntryActionBehavior e) => ActionInfo.Create(e)).ToList(), stateRepresentation.ActivateActions.Select((StateMachine<TState, TTrigger>.ActivateActionBehaviour e) => e.Description).ToList(), stateRepresentation.DeactivateActions.Select((StateMachine<TState, TTrigger>.DeactivateActionBehaviour e) => e.Description).ToList(), stateRepresentation.ExitActions.Select((StateMachine<TState, TTrigger>.ExitActionBehavior e) => e.Description).ToList());
		}

		internal static void AddRelationships<TState, TTrigger>(StateInfo info, StateMachine<TState, TTrigger>.StateRepresentation stateRepresentation, Func<TState, StateInfo> lookupState)
		{
			if (lookupState == null)
			{
				throw new ArgumentNullException("lookupState");
			}
			List<StateInfo> substates = (from s in stateRepresentation.GetSubstates()
				select lookupState(s.UnderlyingState)).ToList();
			StateInfo superstate = null;
			if (stateRepresentation.Superstate != null)
			{
				superstate = lookupState(stateRepresentation.Superstate.UnderlyingState);
			}
			List<FixedTransitionInfo> list = new List<FixedTransitionInfo>();
			List<DynamicTransitionInfo> list2 = new List<DynamicTransitionInfo>();
			foreach (KeyValuePair<TTrigger, List<StateMachine<TState, TTrigger>.TriggerBehaviour>> triggerBehaviour in stateRepresentation.TriggerBehaviours)
			{
				foreach (StateMachine<TState, TTrigger>.TriggerBehaviour item in triggerBehaviour.Value.Where((StateMachine<TState, TTrigger>.TriggerBehaviour behaviour) => behaviour is StateMachine<TState, TTrigger>.TransitioningTriggerBehaviour))
				{
					StateInfo destinationStateInfo = lookupState(((StateMachine<TState, TTrigger>.TransitioningTriggerBehaviour)item).Destination);
					list.Add(FixedTransitionInfo.Create(item, destinationStateInfo));
				}
				foreach (StateMachine<TState, TTrigger>.TriggerBehaviour item2 in triggerBehaviour.Value.Where((StateMachine<TState, TTrigger>.TriggerBehaviour behaviour) => behaviour is StateMachine<TState, TTrigger>.ReentryTriggerBehaviour))
				{
					StateInfo destinationStateInfo2 = lookupState(((StateMachine<TState, TTrigger>.ReentryTriggerBehaviour)item2).Destination);
					list.Add(FixedTransitionInfo.Create(item2, destinationStateInfo2));
				}
				foreach (StateMachine<TState, TTrigger>.TriggerBehaviour item3 in triggerBehaviour.Value.Where((StateMachine<TState, TTrigger>.TriggerBehaviour behaviour) => behaviour is StateMachine<TState, TTrigger>.InternalTriggerBehaviour))
				{
					StateInfo destinationStateInfo3 = lookupState(stateRepresentation.UnderlyingState);
					list.Add(FixedTransitionInfo.Create(item3, destinationStateInfo3));
				}
				foreach (StateMachine<TState, TTrigger>.TriggerBehaviour item4 in triggerBehaviour.Value.Where((StateMachine<TState, TTrigger>.TriggerBehaviour behaviour) => behaviour is StateMachine<TState, TTrigger>.DynamicTriggerBehaviour))
				{
					list2.Add(((StateMachine<TState, TTrigger>.DynamicTriggerBehaviour)item4).TransitionInfo);
				}
			}
			info.AddRelationships(superstate, substates, list, list2);
		}

		private StateInfo(object underlyingState, IEnumerable<IgnoredTransitionInfo> ignoredTriggers, IEnumerable<ActionInfo> entryActions, IEnumerable<InvocationInfo> activateActions, IEnumerable<InvocationInfo> deactivateActions, IEnumerable<InvocationInfo> exitActions)
		{
			UnderlyingState = underlyingState;
			IgnoredTriggers = ignoredTriggers ?? throw new ArgumentNullException("ignoredTriggers");
			EntryActions = entryActions;
			ActivateActions = activateActions;
			DeactivateActions = deactivateActions;
			ExitActions = exitActions;
		}

		private void AddRelationships(StateInfo superstate, ICollection<StateInfo> substates, IEnumerable<FixedTransitionInfo> transitions, IEnumerable<DynamicTransitionInfo> dynamicTransitions)
		{
			Superstate = superstate;
			Substates = substates ?? throw new ArgumentNullException("substates");
			FixedTransitions = transitions ?? throw new ArgumentNullException("transitions");
			DynamicTransitions = dynamicTransitions ?? throw new ArgumentNullException("dynamicTransitions");
		}

		public override string ToString()
		{
			return UnderlyingState?.ToString() ?? "<null>";
		}
	}
}
