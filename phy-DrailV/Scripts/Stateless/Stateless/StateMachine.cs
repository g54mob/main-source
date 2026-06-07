using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Stateless.Reflection;

namespace Stateless
{
	public class StateMachine<TState, TTrigger>
	{
		internal abstract class ActivateActionBehaviour
		{
			public class Sync : ActivateActionBehaviour
			{
				private readonly Action _action;

				public Sync(TState state, Action action, InvocationInfo actionDescription)
					: base(state, actionDescription)
				{
					_action = action;
				}

				public override void Execute()
				{
					_action();
				}

				public override Task ExecuteAsync()
				{
					Execute();
					return TaskResult.Done;
				}
			}

			public class Async : ActivateActionBehaviour
			{
				private readonly Func<Task> _action;

				public Async(TState state, Func<Task> action, InvocationInfo actionDescription)
					: base(state, actionDescription)
				{
					_action = action;
				}

				public override void Execute()
				{
					throw new InvalidOperationException($"Cannot execute asynchronous action specified in OnActivateAsync for '{_state}' state. " + "Use asynchronous version of Activate [ActivateAsync]");
				}

				public override Task ExecuteAsync()
				{
					return _action();
				}
			}

			private readonly TState _state;

			internal InvocationInfo Description { get; }

			protected ActivateActionBehaviour(TState state, InvocationInfo actionDescription)
			{
				_state = state;
				Description = actionDescription;
			}

			public abstract void Execute();

			public abstract Task ExecuteAsync();
		}

		internal abstract class DeactivateActionBehaviour
		{
			public class Sync : DeactivateActionBehaviour
			{
				private readonly Action _action;

				public Sync(TState state, Action action, InvocationInfo actionDescription)
					: base(state, actionDescription)
				{
					_action = action;
				}

				public override void Execute()
				{
					_action();
				}

				public override Task ExecuteAsync()
				{
					Execute();
					return TaskResult.Done;
				}
			}

			public class Async : DeactivateActionBehaviour
			{
				private readonly Func<Task> _action;

				public Async(TState state, Func<Task> action, InvocationInfo actionDescription)
					: base(state, actionDescription)
				{
					_action = action;
				}

				public override void Execute()
				{
					throw new InvalidOperationException($"Cannot execute asynchronous action specified in OnDeactivateAsync for '{_state}' state. " + "Use asynchronous version of Deactivate [DeactivateAsync]");
				}

				public override Task ExecuteAsync()
				{
					return _action();
				}
			}

			private readonly TState _state;

			internal InvocationInfo Description { get; }

			protected DeactivateActionBehaviour(TState state, InvocationInfo actionDescription)
			{
				_state = state;
				Description = actionDescription;
			}

			public abstract void Execute();

			public abstract Task ExecuteAsync();
		}

		internal class DynamicTriggerBehaviour : TriggerBehaviour
		{
			private readonly Func<object[], TState> _destination;

			internal DynamicTransitionInfo TransitionInfo { get; private set; }

			public DynamicTriggerBehaviour(TTrigger trigger, Func<object[], TState> destination, TransitionGuard transitionGuard, DynamicTransitionInfo info)
				: base(trigger, transitionGuard)
			{
				_destination = destination ?? throw new ArgumentNullException("destination");
				TransitionInfo = info ?? throw new ArgumentNullException("info");
			}

			public void GetDestinationState(TState source, object[] args, out TState destination)
			{
				destination = _destination(args);
			}
		}

		internal abstract class EntryActionBehavior
		{
			public class Sync : EntryActionBehavior
			{
				private readonly Action<Transition, object[]> _action;

				public Sync(Action<Transition, object[]> action, InvocationInfo description)
					: base(description)
				{
					_action = action;
				}

				public override void Execute(Transition transition, object[] args)
				{
					_action(transition, args);
				}

				public override Task ExecuteAsync(Transition transition, object[] args)
				{
					Execute(transition, args);
					return TaskResult.Done;
				}
			}

			public class SyncFrom<TTriggerType> : Sync
			{
				internal TTriggerType Trigger { get; }

				public SyncFrom(TTriggerType trigger, Action<Transition, object[]> action, InvocationInfo description)
					: base(action, description)
				{
					Trigger = trigger;
				}

				public override void Execute(Transition transition, object[] args)
				{
					if (transition.Trigger.Equals(Trigger))
					{
						base.Execute(transition, args);
					}
				}

				public override Task ExecuteAsync(Transition transition, object[] args)
				{
					Execute(transition, args);
					return TaskResult.Done;
				}
			}

			public class Async : EntryActionBehavior
			{
				private readonly Func<Transition, object[], Task> _action;

				public Async(Func<Transition, object[], Task> action, InvocationInfo description)
					: base(description)
				{
					_action = action;
				}

				public override void Execute(Transition transition, object[] args)
				{
					throw new InvalidOperationException($"Cannot execute asynchronous action specified in OnEntry event for '{transition.Destination}' state. " + "Use asynchronous version of Fire [FireAsync]");
				}

				public override Task ExecuteAsync(Transition transition, object[] args)
				{
					return _action(transition, args);
				}
			}

			public class AsyncFrom<TTriggerType> : Async
			{
				internal TTriggerType Trigger { get; }

				public AsyncFrom(TTriggerType trigger, Func<Transition, object[], Task> action, InvocationInfo description)
					: base(action, description)
				{
					Trigger = trigger;
				}

				public override void Execute(Transition transition, object[] args)
				{
					if (transition.Trigger.Equals(Trigger))
					{
						base.Execute(transition, args);
					}
				}

				public override Task ExecuteAsync(Transition transition, object[] args)
				{
					if (transition.Trigger.Equals(Trigger))
					{
						return base.ExecuteAsync(transition, args);
					}
					return TaskResult.Done;
				}
			}

			public InvocationInfo Description { get; }

			protected EntryActionBehavior(InvocationInfo description)
			{
				Description = description;
			}

			public abstract void Execute(Transition transition, object[] args);

			public abstract Task ExecuteAsync(Transition transition, object[] args);
		}

		internal abstract class ExitActionBehavior
		{
			public class Sync : ExitActionBehavior
			{
				private readonly Action<Transition> _action;

				public Sync(Action<Transition> action, InvocationInfo actionDescription)
					: base(actionDescription)
				{
					_action = action;
				}

				public override void Execute(Transition transition)
				{
					_action(transition);
				}

				public override Task ExecuteAsync(Transition transition)
				{
					Execute(transition);
					return TaskResult.Done;
				}
			}

			public class Async : ExitActionBehavior
			{
				private readonly Func<Transition, Task> _action;

				public Async(Func<Transition, Task> action, InvocationInfo actionDescription)
					: base(actionDescription)
				{
					_action = action;
				}

				public override void Execute(Transition transition)
				{
					throw new InvalidOperationException($"Cannot execute asynchronous action specified in OnExit event for '{transition.Source}' state. " + "Use asynchronous version of Fire [FireAsync]");
				}

				public override Task ExecuteAsync(Transition transition)
				{
					return _action(transition);
				}
			}

			internal InvocationInfo Description { get; }

			public abstract void Execute(Transition transition);

			public abstract Task ExecuteAsync(Transition transition);

			protected ExitActionBehavior(InvocationInfo actionDescription)
			{
				Description = actionDescription;
			}
		}

		internal class GuardCondition
		{
			private InvocationInfo _methodDescription;

			internal Func<object[], bool> Guard { get; }

			internal string Description => _methodDescription.Description;

			internal InvocationInfo MethodDescription => _methodDescription;

			internal GuardCondition(Func<bool> guard, InvocationInfo description)
				: this((Func<object[], bool>)((object[] args) => guard()), description)
			{
			}

			internal GuardCondition(Func<object[], bool> guard, InvocationInfo description)
			{
				Guard = guard ?? throw new ArgumentNullException("guard");
				_methodDescription = description;
			}
		}

		internal class IgnoredTriggerBehaviour : TriggerBehaviour
		{
			public IgnoredTriggerBehaviour(TTrigger trigger, TransitionGuard transitionGuard)
				: base(trigger, transitionGuard)
			{
			}
		}

		internal abstract class InternalActionBehaviour
		{
			public class Sync : InternalActionBehaviour
			{
				private readonly Action<Transition, object[]> _action;

				public Sync(Action<Transition, object[]> action)
				{
					_action = action;
				}

				public override void Execute(Transition transition, object[] args)
				{
					_action(transition, args);
				}

				public override Task ExecuteAsync(Transition transition, object[] args)
				{
					Execute(transition, args);
					return TaskResult.Done;
				}
			}

			public class Async : InternalActionBehaviour
			{
				private readonly Func<Transition, object[], Task> _action;

				public Async(Func<Transition, object[], Task> action)
				{
					_action = action;
				}

				public override void Execute(Transition transition, object[] args)
				{
					throw new InvalidOperationException($"Cannot execute asynchronous action specified in OnEntry event for '{transition.Destination}' state. " + "Use asynchronous version of Fire [FireAsync]");
				}

				public override Task ExecuteAsync(Transition transition, object[] args)
				{
					return _action(transition, args);
				}
			}

			public abstract void Execute(Transition transition, object[] args);

			public abstract Task ExecuteAsync(Transition transition, object[] args);
		}

		internal abstract class InternalTriggerBehaviour : TriggerBehaviour
		{
			public class Sync : InternalTriggerBehaviour
			{
				public Action<Transition, object[]> InternalAction { get; }

				public Sync(TTrigger trigger, Func<object[], bool> guard, Action<Transition, object[]> internalAction, string guardDescription = null)
					: base(trigger, new TransitionGuard(guard, guardDescription))
				{
					InternalAction = internalAction;
				}

				public override void Execute(Transition transition, object[] args)
				{
					InternalAction(transition, args);
				}

				public override Task ExecuteAsync(Transition transition, object[] args)
				{
					Execute(transition, args);
					return TaskResult.Done;
				}
			}

			public class Async : InternalTriggerBehaviour
			{
				private readonly Func<Transition, object[], Task> InternalAction;

				public Async(TTrigger trigger, Func<object[], bool> guard, Func<Transition, object[], Task> internalAction, string guardDescription = null)
					: base(trigger, new TransitionGuard(guard, guardDescription))
				{
					InternalAction = internalAction;
				}

				[Obsolete]
				public Async(TTrigger trigger, Func<bool> guard, Func<Transition, object[], Task> internalAction, string guardDescription = null)
					: base(trigger, new TransitionGuard(guard, guardDescription))
				{
					InternalAction = internalAction;
				}

				public override void Execute(Transition transition, object[] args)
				{
					throw new InvalidOperationException($"Cannot execute asynchronous action specified in OnEntry event for '{transition.Destination}' state. " + "Use asynchronous version of Fire [FireAsync]");
				}

				public override Task ExecuteAsync(Transition transition, object[] args)
				{
					return InternalAction(transition, args);
				}
			}

			protected InternalTriggerBehaviour(TTrigger trigger, TransitionGuard guard)
				: base(trigger, guard)
			{
			}

			public abstract void Execute(Transition transition, object[] args);

			public abstract Task ExecuteAsync(Transition transition, object[] args);
		}

		private class OnTransitionedEvent
		{
			private readonly List<Func<Transition, Task>> _onTransitionedAsync = new List<Func<Transition, Task>>();

			private event Action<Transition> _onTransitioned;

			public void Invoke(Transition transition)
			{
				if (_onTransitionedAsync.Count != 0)
				{
					throw new InvalidOperationException("Cannot execute asynchronous action specified as OnTransitioned callback. Use asynchronous version of Fire [FireAsync]");
				}
				this._onTransitioned?.Invoke(transition);
			}

			public void Register(Action<Transition> action)
			{
				_onTransitioned += action;
			}

			public void Register(Func<Transition, Task> action)
			{
				_onTransitionedAsync.Add(action);
			}
		}

		internal class ReentryTriggerBehaviour : TriggerBehaviour
		{
			private readonly TState _destination;

			internal TState Destination => _destination;

			public ReentryTriggerBehaviour(TTrigger trigger, TState destination, TransitionGuard transitionGuard)
				: base(trigger, transitionGuard)
			{
				_destination = destination;
			}
		}

		public class StateConfiguration
		{
			private readonly StateMachine<TState, TTrigger> _machine;

			private readonly StateRepresentation _representation;

			private readonly Func<TState, StateRepresentation> _lookup;

			public TState State => _representation.UnderlyingState;

			public StateMachine<TState, TTrigger> Machine => _machine;

			internal StateConfiguration(StateMachine<TState, TTrigger> machine, StateRepresentation representation, Func<TState, StateRepresentation> lookup)
			{
				_machine = machine;
				_representation = representation;
				_lookup = lookup;
			}

			public StateConfiguration Permit(TTrigger trigger, TState destinationState)
			{
				EnforceNotIdentityTransition(destinationState);
				return InternalPermit(trigger, destinationState);
			}

			public StateConfiguration InternalTransition(TTrigger trigger, Action<Transition> entryAction)
			{
				return InternalTransitionIf(trigger, (object[] t) => true, entryAction);
			}

			public StateConfiguration InternalTransitionIf(TTrigger trigger, Func<object[], bool> guard, Action<Transition> entryAction, string guardDescription = null)
			{
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddTriggerBehaviour(new InternalTriggerBehaviour.Sync(trigger, guard, delegate(Transition t, object[] args)
				{
					entryAction(t);
				}, guardDescription));
				return this;
			}

			public StateConfiguration InternalTransition(TTrigger trigger, Action internalAction)
			{
				return InternalTransitionIf(trigger, (object[] t) => true, internalAction);
			}

			public StateConfiguration InternalTransitionIf(TTrigger trigger, Func<object[], bool> guard, Action internalAction, string guardDescription = null)
			{
				if (internalAction == null)
				{
					throw new ArgumentNullException("internalAction");
				}
				_representation.AddTriggerBehaviour(new InternalTriggerBehaviour.Sync(trigger, guard, delegate
				{
					internalAction();
				}, guardDescription));
				return this;
			}

			public StateConfiguration InternalTransitionIf<TArg0>(TTrigger trigger, Func<object[], bool> guard, Action<Transition> internalAction, string guardDescription = null)
			{
				if (internalAction == null)
				{
					throw new ArgumentNullException("internalAction");
				}
				_representation.AddTriggerBehaviour(new InternalTriggerBehaviour.Sync(trigger, guard, delegate(Transition t, object[] args)
				{
					internalAction(t);
				}, guardDescription));
				return this;
			}

			public StateConfiguration InternalTransition<TArg0>(TTrigger trigger, Action<Transition> internalAction)
			{
				return InternalTransitionIf(trigger, (object[] t) => true, internalAction);
			}

			public StateConfiguration InternalTransition<TArg0>(TriggerWithParameters<TArg0> trigger, Action<TArg0, Transition> internalAction)
			{
				return InternalTransitionIf(trigger, (TArg0 t) => true, internalAction);
			}

			public StateConfiguration InternalTransitionIf<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, bool> guard, Action<TArg0, Transition> internalAction, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (internalAction == null)
				{
					throw new ArgumentNullException("internalAction");
				}
				_representation.AddTriggerBehaviour(new InternalTriggerBehaviour.Sync(trigger.Trigger, TransitionGuard.ToPackedGuard(guard), delegate(Transition t, object[] args)
				{
					internalAction(ParameterConversion.Unpack<TArg0>(args, 0), t);
				}, guardDescription));
				return this;
			}

			public StateConfiguration InternalTransition<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Action<TArg0, TArg1, Transition> internalAction)
			{
				return InternalTransitionIf(trigger, (object[] t) => true, internalAction);
			}

			public StateConfiguration InternalTransitionIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Func<object[], bool> guard, Action<TArg0, TArg1, Transition> internalAction, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (internalAction == null)
				{
					throw new ArgumentNullException("internalAction");
				}
				_representation.AddTriggerBehaviour(new InternalTriggerBehaviour.Sync(trigger.Trigger, guard, delegate(Transition t, object[] args)
				{
					internalAction(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), t);
				}, guardDescription));
				return this;
			}

			public StateConfiguration InternalTransitionIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Func<TArg0, TArg1, bool> guard, Action<TArg0, TArg1, Transition> internalAction, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (internalAction == null)
				{
					throw new ArgumentNullException("internalAction");
				}
				_representation.AddTriggerBehaviour(new InternalTriggerBehaviour.Sync(trigger.Trigger, TransitionGuard.ToPackedGuard(guard), delegate(Transition t, object[] args)
				{
					internalAction(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), t);
				}, guardDescription));
				return this;
			}

			public StateConfiguration InternalTransitionIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<object[], bool> guard, Action<TArg0, TArg1, TArg2, Transition> internalAction, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (internalAction == null)
				{
					throw new ArgumentNullException("internalAction");
				}
				_representation.AddTriggerBehaviour(new InternalTriggerBehaviour.Sync(trigger.Trigger, guard, delegate(Transition t, object[] args)
				{
					internalAction(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2), t);
				}, guardDescription));
				return this;
			}

			public StateConfiguration InternalTransitionIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<TArg0, TArg1, TArg2, bool> guard, Action<TArg0, TArg1, TArg2, Transition> internalAction, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (internalAction == null)
				{
					throw new ArgumentNullException("internalAction");
				}
				_representation.AddTriggerBehaviour(new InternalTriggerBehaviour.Sync(trigger.Trigger, TransitionGuard.ToPackedGuard(guard), delegate(Transition t, object[] args)
				{
					internalAction(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2), t);
				}, guardDescription));
				return this;
			}

			public StateConfiguration InternalTransition<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Action<TArg0, TArg1, TArg2, Transition> internalAction)
			{
				return InternalTransitionIf(trigger, (object[] t) => true, internalAction);
			}

			public StateConfiguration PermitIf(TTrigger trigger, TState destinationState, Func<bool> guard, string guardDescription = null)
			{
				EnforceNotIdentityTransition(destinationState);
				return InternalPermitIf(trigger, destinationState, new TransitionGuard(guard, guardDescription));
			}

			public StateConfiguration PermitIf(TTrigger trigger, TState destinationState, params Tuple<Func<bool>, string>[] guards)
			{
				EnforceNotIdentityTransition(destinationState);
				return InternalPermitIf(trigger, destinationState, new TransitionGuard(guards));
			}

			public StateConfiguration PermitIf<TArg0>(TriggerWithParameters<TArg0> trigger, TState destinationState, Func<TArg0, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				EnforceNotIdentityTransition(destinationState);
				return InternalPermitIf(trigger.Trigger, destinationState, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription));
			}

			public StateConfiguration PermitIf<TArg0>(TriggerWithParameters<TArg0> trigger, TState destinationState, params Tuple<Func<TArg0, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				EnforceNotIdentityTransition(destinationState);
				return InternalPermitIf(trigger.Trigger, destinationState, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)));
			}

			public StateConfiguration PermitIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, TState destinationState, Func<TArg0, TArg1, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				EnforceNotIdentityTransition(destinationState);
				return InternalPermitIf(trigger.Trigger, destinationState, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription));
			}

			public StateConfiguration PermitIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, TState destinationState, params Tuple<Func<TArg0, TArg1, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				EnforceNotIdentityTransition(destinationState);
				return InternalPermitIf(trigger.Trigger, destinationState, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)));
			}

			public StateConfiguration PermitIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, TState destinationState, Func<TArg0, TArg1, TArg2, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				EnforceNotIdentityTransition(destinationState);
				return InternalPermitIf(trigger.Trigger, destinationState, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription));
			}

			public StateConfiguration PermitIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, TState destinationState, params Tuple<Func<TArg0, TArg1, TArg2, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				EnforceNotIdentityTransition(destinationState);
				return InternalPermitIf(trigger.Trigger, destinationState, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)));
			}

			public StateConfiguration PermitReentry(TTrigger trigger)
			{
				return InternalPermitReentryIf(trigger, _representation.UnderlyingState, null);
			}

			public StateConfiguration PermitReentryIf(TTrigger trigger, Func<bool> guard, string guardDescription = null)
			{
				return InternalPermitReentryIf(trigger, _representation.UnderlyingState, new TransitionGuard(guard, guardDescription));
			}

			public StateConfiguration PermitReentryIf(TTrigger trigger, params Tuple<Func<bool>, string>[] guards)
			{
				return InternalPermitReentryIf(trigger, _representation.UnderlyingState, new TransitionGuard(guards));
			}

			public StateConfiguration PermitReentryIf<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				return InternalPermitReentryIf(trigger.Trigger, _representation.UnderlyingState, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription));
			}

			public StateConfiguration PermitReentryIf<TArg0>(TriggerWithParameters<TArg0> trigger, params Tuple<Func<TArg0, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				return InternalPermitReentryIf(trigger.Trigger, _representation.UnderlyingState, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)));
			}

			public StateConfiguration PermitReentryIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Func<TArg0, TArg1, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				return InternalPermitReentryIf(trigger.Trigger, _representation.UnderlyingState, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription));
			}

			public StateConfiguration PermitReentryIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, params Tuple<Func<TArg0, TArg1, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				return InternalPermitReentryIf(trigger.Trigger, _representation.UnderlyingState, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)));
			}

			public StateConfiguration PermitReentryIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<TArg0, TArg1, TArg2, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				return InternalPermitReentryIf(trigger.Trigger, _representation.UnderlyingState, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription));
			}

			public StateConfiguration PermitReentryIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, params Tuple<Func<TArg0, TArg1, TArg2, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				return InternalPermitReentryIf(trigger.Trigger, _representation.UnderlyingState, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)));
			}

			public StateConfiguration Ignore(TTrigger trigger)
			{
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger, null));
				return this;
			}

			public StateConfiguration IgnoreIf(TTrigger trigger, Func<bool> guard, string guardDescription = null)
			{
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger, new TransitionGuard(guard, guardDescription)));
				return this;
			}

			public StateConfiguration IgnoreIf(TTrigger trigger, params Tuple<Func<bool>, string>[] guards)
			{
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger, new TransitionGuard(guards)));
				return this;
			}

			public StateConfiguration IgnoreIf<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger.Trigger, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription)));
				return this;
			}

			public StateConfiguration IgnoreIf<TArg0>(TriggerWithParameters<TArg0> trigger, params Tuple<Func<TArg0, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger.Trigger, new TransitionGuard(TransitionGuard.ToPackedGuards(guards))));
				return this;
			}

			public StateConfiguration IgnoreIf<TArg0, TArgo1>(TriggerWithParameters<TArg0, TArgo1> trigger, Func<TArg0, TArgo1, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger.Trigger, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription)));
				return this;
			}

			public StateConfiguration IgnoreIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, params Tuple<Func<TArg0, TArg1, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger.Trigger, new TransitionGuard(TransitionGuard.ToPackedGuards(guards))));
				return this;
			}

			public StateConfiguration IgnoreIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<TArg0, TArg1, TArg2, bool> guard, string guardDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger.Trigger, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription)));
				return this;
			}

			public StateConfiguration IgnoreIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, params Tuple<Func<TArg0, TArg1, TArg2, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				_representation.AddTriggerBehaviour(new IgnoredTriggerBehaviour(trigger.Trigger, new TransitionGuard(TransitionGuard.ToPackedGuards(guards))));
				return this;
			}

			public StateConfiguration OnActivate(Action activateAction, string activateActionDescription = null)
			{
				_representation.AddActivateAction(activateAction, InvocationInfo.Create(activateAction, activateActionDescription));
				return this;
			}

			public StateConfiguration OnDeactivate(Action deactivateAction, string deactivateActionDescription = null)
			{
				_representation.AddDeactivateAction(deactivateAction, InvocationInfo.Create(deactivateAction, deactivateActionDescription));
				return this;
			}

			public StateConfiguration OnEntry(Action entryAction, string entryActionDescription = null)
			{
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(delegate
				{
					entryAction();
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntry(Action<Transition> entryAction, string entryActionDescription = null)
			{
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(delegate(Transition t, object[] args)
				{
					entryAction(t);
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom(TTrigger trigger, Action entryAction, string entryActionDescription = null)
			{
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger, delegate
				{
					entryAction();
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom(TTrigger trigger, Action<Transition> entryAction, string entryActionDescription = null)
			{
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger, delegate(Transition t, object[] args)
				{
					entryAction(t);
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom(TriggerWithParameters trigger, Action<Transition> entryAction, string entryActionDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger.Trigger, delegate(Transition t, object[] args)
				{
					entryAction(t);
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom<TArg0>(TriggerWithParameters<TArg0> trigger, Action<TArg0> entryAction, string entryActionDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger.Trigger, delegate(Transition t, object[] args)
				{
					entryAction(ParameterConversion.Unpack<TArg0>(args, 0));
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom<TArg0>(TriggerWithParameters<TArg0> trigger, Action<TArg0, Transition> entryAction, string entryActionDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger.Trigger, delegate(Transition t, object[] args)
				{
					entryAction(ParameterConversion.Unpack<TArg0>(args, 0), t);
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Action<TArg0, TArg1> entryAction, string entryActionDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger.Trigger, delegate(Transition t, object[] args)
				{
					entryAction(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1));
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Action<TArg0, TArg1, Transition> entryAction, string entryActionDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger.Trigger, delegate(Transition t, object[] args)
				{
					entryAction(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), t);
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Action<TArg0, TArg1, TArg2> entryAction, string entryActionDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger.Trigger, delegate(Transition t, object[] args)
				{
					entryAction(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2));
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnEntryFrom<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Action<TArg0, TArg1, TArg2, Transition> entryAction, string entryActionDescription = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (entryAction == null)
				{
					throw new ArgumentNullException("entryAction");
				}
				_representation.AddEntryAction(trigger.Trigger, delegate(Transition t, object[] args)
				{
					entryAction(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2), t);
				}, InvocationInfo.Create(entryAction, entryActionDescription));
				return this;
			}

			public StateConfiguration OnExit(Action exitAction, string exitActionDescription = null)
			{
				if (exitAction == null)
				{
					throw new ArgumentNullException("exitAction");
				}
				_representation.AddExitAction(delegate
				{
					exitAction();
				}, InvocationInfo.Create(exitAction, exitActionDescription));
				return this;
			}

			public StateConfiguration OnExit(Action<Transition> exitAction, string exitActionDescription = null)
			{
				_representation.AddExitAction(exitAction, InvocationInfo.Create(exitAction, exitActionDescription));
				return this;
			}

			public StateConfiguration SubstateOf(TState superstate)
			{
				TState underlyingState = _representation.UnderlyingState;
				if (StateMachine<TState, TTrigger>.Eq(underlyingState, superstate))
				{
					throw new ArgumentException($"Configuring {underlyingState} as a substate of {superstate} creates an illegal cyclic configuration.");
				}
				HashSet<TState> hashSet = new HashSet<TState> { underlyingState };
				StateRepresentation stateRepresentation = _lookup(superstate);
				while (stateRepresentation.Superstate != null)
				{
					if (hashSet.Contains(stateRepresentation.Superstate.UnderlyingState))
					{
						throw new ArgumentException($"Configuring {underlyingState} as a substate of {superstate} creates an illegal nested cyclic configuration.");
					}
					hashSet.Add(stateRepresentation.Superstate.UnderlyingState);
					stateRepresentation = _lookup(stateRepresentation.Superstate.UnderlyingState);
				}
				StateRepresentation stateRepresentation2 = _lookup(superstate);
				_representation.Superstate = stateRepresentation2;
				stateRepresentation2.AddSubstate(_representation);
				return this;
			}

			public StateConfiguration PermitDynamic(TTrigger trigger, Func<TState> destinationStateSelector, string destinationStateSelectorDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				_representation.AddTriggerBehaviour(new DynamicTriggerBehaviour(trigger, (object[] args) => destinationStateSelector(), null, DynamicTransitionInfo.Create(trigger, null, InvocationInfo.Create(destinationStateSelector, destinationStateSelectorDescription), possibleDestinationStates)));
				return this;
			}

			public StateConfiguration PermitDynamic<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, TState> destinationStateSelector, string destinationStateSelectorDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				_representation.AddTriggerBehaviour(new DynamicTriggerBehaviour(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0)), null, DynamicTransitionInfo.Create(trigger.Trigger, null, InvocationInfo.Create(destinationStateSelector, destinationStateSelectorDescription), possibleDestinationStates)));
				return this;
			}

			public StateConfiguration PermitDynamic<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Func<TArg0, TArg1, TState> destinationStateSelector, string destinationStateSelectorDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				_representation.AddTriggerBehaviour(new DynamicTriggerBehaviour(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1)), null, DynamicTransitionInfo.Create(trigger.Trigger, null, InvocationInfo.Create(destinationStateSelector, destinationStateSelectorDescription), possibleDestinationStates)));
				return this;
			}

			public StateConfiguration PermitDynamic<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<TArg0, TArg1, TArg2, TState> destinationStateSelector, string destinationStateSelectorDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				_representation.AddTriggerBehaviour(new DynamicTriggerBehaviour(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2)), null, DynamicTransitionInfo.Create(trigger.Trigger, null, InvocationInfo.Create(destinationStateSelector, destinationStateSelectorDescription), possibleDestinationStates)));
				return this;
			}

			public StateConfiguration PermitDynamicIf(TTrigger trigger, Func<TState> destinationStateSelector, Func<bool> guard, string guardDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				return PermitDynamicIf(trigger, destinationStateSelector, null, guard, guardDescription, possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf(TTrigger trigger, Func<TState> destinationStateSelector, string destinationStateSelectorDescription, Func<bool> guard, string guardDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger, (object[] args) => destinationStateSelector(), destinationStateSelectorDescription, new TransitionGuard(guard, guardDescription), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf(TTrigger trigger, Func<TState> destinationStateSelector, DynamicStateInfos possibleDestinationStates = null, params Tuple<Func<bool>, string>[] guards)
			{
				return PermitDynamicIf(trigger, destinationStateSelector, null, possibleDestinationStates, guards);
			}

			public StateConfiguration PermitDynamicIf(TTrigger trigger, Func<TState> destinationStateSelector, string destinationStateSelectorDescription, DynamicStateInfos possibleDestinationStates = null, params Tuple<Func<bool>, string>[] guards)
			{
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger, (object[] args) => destinationStateSelector(), destinationStateSelectorDescription, new TransitionGuard(guards), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, TState> destinationStateSelector, Func<bool> guard, string guardDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0)), null, new TransitionGuard(guard, guardDescription), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, TState> destinationStateSelector)
			{
				return PermitDynamicIf(trigger, destinationStateSelector, null, Array.Empty<Tuple<Func<bool>, string>>());
			}

			public StateConfiguration PermitDynamicIf<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, TState> destinationStateSelector, DynamicStateInfos possibleDestinationStates = null, params Tuple<Func<bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0)), null, new TransitionGuard(guards), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Func<TArg0, TArg1, TState> destinationStateSelector, Func<bool> guard, string guardDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1)), null, new TransitionGuard(guard, guardDescription), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Func<TArg0, TArg1, TState> destinationStateSelector, DynamicStateInfos possibleDestinationStates = null, params Tuple<Func<bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1)), null, new TransitionGuard(guards), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<TArg0, TArg1, TArg2, TState> destinationStateSelector, Func<bool> guard, string guardDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2)), null, new TransitionGuard(guard, guardDescription), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<TArg0, TArg1, TArg2, TState> destinationStateSelector, DynamicStateInfos possibleDestinationStates = null, params Tuple<Func<bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2)), null, new TransitionGuard(guards), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, TState> destinationStateSelector, Func<TArg0, bool> guard, string guardDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0)), null, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0>(TriggerWithParameters<TArg0> trigger, Func<TArg0, TState> destinationStateSelector, DynamicStateInfos possibleDestinationStates = null, params Tuple<Func<TArg0, bool>, string>[] guards)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0)), null, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Func<TArg0, TArg1, TState> destinationStateSelector, Func<TArg0, TArg1, bool> guard, string guardDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1)), null, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, Func<TArg0, TArg1, TState> destinationStateSelector, Tuple<Func<TArg0, TArg1, bool>, string>[] guards, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1)), null, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<TArg0, TArg1, TArg2, TState> destinationStateSelector, Func<TArg0, TArg1, TArg2, bool> guard, string guardDescription = null, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2)), null, new TransitionGuard(TransitionGuard.ToPackedGuard(guard), guardDescription), possibleDestinationStates);
			}

			public StateConfiguration PermitDynamicIf<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, Func<TArg0, TArg1, TArg2, TState> destinationStateSelector, Tuple<Func<TArg0, TArg1, TArg2, bool>, string>[] guards, DynamicStateInfos possibleDestinationStates = null)
			{
				if (trigger == null)
				{
					throw new ArgumentNullException("trigger");
				}
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				return InternalPermitDynamicIf(trigger.Trigger, (object[] args) => destinationStateSelector(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2)), null, new TransitionGuard(TransitionGuard.ToPackedGuards(guards)), possibleDestinationStates);
			}

			private void EnforceNotIdentityTransition(TState destination)
			{
				if (StateMachine<TState, TTrigger>.Eq(destination, _representation.UnderlyingState))
				{
					throw new ArgumentException(StateConfigurationResources.SelfTransitionsEitherIgnoredOrReentrant);
				}
			}

			private StateConfiguration InternalPermit(TTrigger trigger, TState destinationState)
			{
				_representation.AddTriggerBehaviour(new TransitioningTriggerBehaviour(trigger, destinationState, null));
				return this;
			}

			private StateConfiguration InternalPermitIf(TTrigger trigger, TState destinationState, TransitionGuard transitionGuard)
			{
				_representation.AddTriggerBehaviour(new TransitioningTriggerBehaviour(trigger, destinationState, transitionGuard));
				return this;
			}

			private StateConfiguration InternalPermitReentryIf(TTrigger trigger, TState destinationState, TransitionGuard transitionGuard)
			{
				_representation.AddTriggerBehaviour(new ReentryTriggerBehaviour(trigger, destinationState, transitionGuard));
				return this;
			}

			private StateConfiguration InternalPermitDynamicIf(TTrigger trigger, Func<object[], TState> destinationStateSelector, string destinationStateSelectorDescription, TransitionGuard transitionGuard, DynamicStateInfos possibleDestinationStates)
			{
				if (destinationStateSelector == null)
				{
					throw new ArgumentNullException("destinationStateSelector");
				}
				if (transitionGuard == null)
				{
					throw new ArgumentNullException("transitionGuard");
				}
				_representation.AddTriggerBehaviour(new DynamicTriggerBehaviour(trigger, destinationStateSelector, transitionGuard, DynamicTransitionInfo.Create(trigger, transitionGuard.Conditions.Select((GuardCondition x) => x.MethodDescription), InvocationInfo.Create(destinationStateSelector, destinationStateSelectorDescription), possibleDestinationStates)));
				return this;
			}

			public StateConfiguration InitialTransition(TState targetState)
			{
				if (_representation.HasInitialTransition)
				{
					throw new InvalidOperationException($"This state has already been configured with an initial transition ({_representation.InitialTransitionTarget}).");
				}
				if (StateMachine<TState, TTrigger>.Eq(targetState, State))
				{
					throw new ArgumentException("Setting the current state as the target destination state is not allowed.", "targetState");
				}
				_representation.SetInitialTransition(targetState);
				return this;
			}
		}

		private readonly struct QueuedTrigger
		{
			public readonly TTrigger Trigger;

			public readonly object[] Args;

			public QueuedTrigger(TTrigger trigger, object[] args)
			{
				Trigger = trigger;
				Args = args;
			}
		}

		internal class StateReference
		{
			public TState State { get; set; }
		}

		internal class StateRepresentation
		{
			private readonly TState _state;

			private readonly bool _retainSynchronizationContext;

			private StateRepresentation _superstate;

			private readonly List<StateRepresentation> _substates = new List<StateRepresentation>();

			private readonly List<TriggerBehaviourResult> reusableResults = new List<TriggerBehaviourResult>();

			internal IDictionary<TTrigger, List<TriggerBehaviour>> TriggerBehaviours { get; } = new Dictionary<TTrigger, List<TriggerBehaviour>>();

			internal ICollection<EntryActionBehavior> EntryActions { get; } = new List<EntryActionBehavior>();

			internal ICollection<ExitActionBehavior> ExitActions { get; } = new List<ExitActionBehavior>();

			internal ICollection<ActivateActionBehaviour> ActivateActions { get; } = new List<ActivateActionBehaviour>();

			internal ICollection<DeactivateActionBehaviour> DeactivateActions { get; } = new List<DeactivateActionBehaviour>();

			public TState InitialTransitionTarget { get; private set; }

			public StateRepresentation Superstate
			{
				get
				{
					return _superstate;
				}
				set
				{
					_superstate = value;
				}
			}

			public TState UnderlyingState => _state;

			public IEnumerable<TTrigger> PermittedTriggers => GetPermittedTriggers();

			public bool HasInitialTransition { get; private set; }

			public StateRepresentation(TState state, bool retainSynchronizationContext = false)
			{
				_state = state;
				_retainSynchronizationContext = retainSynchronizationContext;
			}

			internal List<StateRepresentation> GetSubstates()
			{
				return _substates;
			}

			public bool CanHandle(TTrigger trigger, params object[] args)
			{
				TriggerBehaviourResult? handler;
				return TryFindHandler(trigger, args, out handler);
			}

			public bool CanHandle(TTrigger trigger, object[] args, out ICollection<string> unmetGuards)
			{
				TriggerBehaviourResult? handler;
				bool result = TryFindHandler(trigger, args, out handler);
				unmetGuards = handler?.UnmetGuardConditions;
				return result;
			}

			public bool TryFindHandler(TTrigger trigger, object[] args, out TriggerBehaviourResult? handler)
			{
				TriggerBehaviourResult? handler2 = null;
				TriggerBehaviourResult? handlerResult;
				bool result = TryFindLocalHandler(trigger, args, out handlerResult) || (Superstate != null && Superstate.TryFindHandler(trigger, args, out handler2));
				handler = handler2 ?? handlerResult;
				return result;
			}

			private bool TryFindLocalHandler(TTrigger trigger, object[] args, out TriggerBehaviourResult? handlerResult)
			{
				if (!TriggerBehaviours.TryGetValue(trigger, out var value))
				{
					handlerResult = null;
					return false;
				}
				lock (reusableResults)
				{
					try
					{
						foreach (TriggerBehaviour item in value)
						{
							reusableResults.Add(new TriggerBehaviourResult(item, item.UnmetGuardConditions(args)));
						}
						handlerResult = TryFindLocalHandlerResult(trigger, reusableResults) ?? TryFindLocalHandlerResultWithUnmetGuardConditions(reusableResults);
					}
					finally
					{
						reusableResults.Clear();
					}
				}
				if (!handlerResult.HasValue)
				{
					return false;
				}
				return handlerResult.GetValueOrDefault().UnmetGuardConditions.Count == 0;
			}

			private TriggerBehaviourResult? TryFindLocalHandlerResult(TTrigger trigger, List<TriggerBehaviourResult> results)
			{
				int num = 0;
				TriggerBehaviourResult? result = null;
				foreach (TriggerBehaviourResult result2 in results)
				{
					if (result2.UnmetGuardConditions.Count == 0 && num++ < 1)
					{
						result = result2;
					}
				}
				if (num <= 1)
				{
					return result;
				}
				throw new InvalidOperationException(string.Format(StateRepresentationResources.MultipleTransitionsPermitted, trigger, _state));
			}

			private static TriggerBehaviourResult TryFindLocalHandlerResultWithUnmetGuardConditions(List<TriggerBehaviourResult> results)
			{
				bool flag = false;
				TriggerBehaviourResult result = default(TriggerBehaviourResult);
				foreach (TriggerBehaviourResult result2 in results)
				{
					if (result2.UnmetGuardConditions.Count == 0)
					{
						continue;
					}
					if (!flag)
					{
						result = result2;
						flag = true;
					}
					foreach (string unmetGuardCondition in result2.UnmetGuardConditions)
					{
						if (!result.UnmetGuardConditions.Contains(unmetGuardCondition))
						{
							if (result.UnmetGuardConditions.IsReadOnly)
							{
								result = new TriggerBehaviourResult(result.Handler, new List<string>(result.UnmetGuardConditions));
							}
							result.UnmetGuardConditions.Add(unmetGuardCondition);
						}
					}
				}
				return result;
			}

			public void AddActivateAction(Action action, InvocationInfo activateActionDescription)
			{
				ActivateActions.Add(new ActivateActionBehaviour.Sync(_state, action, activateActionDescription));
			}

			public void AddDeactivateAction(Action action, InvocationInfo deactivateActionDescription)
			{
				DeactivateActions.Add(new DeactivateActionBehaviour.Sync(_state, action, deactivateActionDescription));
			}

			public void AddEntryAction(TTrigger trigger, Action<Transition, object[]> action, InvocationInfo entryActionDescription)
			{
				EntryActions.Add(new EntryActionBehavior.SyncFrom<TTrigger>(trigger, action, entryActionDescription));
			}

			public void AddEntryAction(Action<Transition, object[]> action, InvocationInfo entryActionDescription)
			{
				EntryActions.Add(new EntryActionBehavior.Sync(action, entryActionDescription));
			}

			public void AddExitAction(Action<Transition> action, InvocationInfo exitActionDescription)
			{
				ExitActions.Add(new ExitActionBehavior.Sync(action, exitActionDescription));
			}

			public void Activate()
			{
				if (_superstate != null)
				{
					_superstate.Activate();
				}
				ExecuteActivationActions();
			}

			public void Deactivate()
			{
				ExecuteDeactivationActions();
				if (_superstate != null)
				{
					_superstate.Deactivate();
				}
			}

			private void ExecuteActivationActions()
			{
				foreach (ActivateActionBehaviour activateAction in ActivateActions)
				{
					activateAction.Execute();
				}
			}

			private void ExecuteDeactivationActions()
			{
				foreach (DeactivateActionBehaviour deactivateAction in DeactivateActions)
				{
					deactivateAction.Execute();
				}
			}

			public void Enter(Transition transition, params object[] entryArgs)
			{
				if (transition.IsReentry)
				{
					ExecuteEntryActions(transition, entryArgs);
				}
				else if (!Includes(transition.Source))
				{
					if (_superstate != null && !transition.IsInitial)
					{
						_superstate.Enter(transition, entryArgs);
					}
					ExecuteEntryActions(transition, entryArgs);
				}
			}

			public Transition Exit(Transition transition)
			{
				if (transition.IsReentry)
				{
					ExecuteExitActions(transition);
				}
				else if (!Includes(transition.Destination))
				{
					ExecuteExitActions(transition);
					if (_superstate != null)
					{
						if (!IsIncludedIn(transition.Destination))
						{
							return _superstate.Exit(transition);
						}
						if (!StateMachine<TState, TTrigger>.Eq(_superstate.UnderlyingState, transition.Destination))
						{
							return _superstate.Exit(transition);
						}
					}
				}
				return transition;
			}

			private void ExecuteEntryActions(Transition transition, object[] entryArgs)
			{
				foreach (EntryActionBehavior entryAction in EntryActions)
				{
					entryAction.Execute(transition, entryArgs);
				}
			}

			private void ExecuteExitActions(Transition transition)
			{
				foreach (ExitActionBehavior exitAction in ExitActions)
				{
					exitAction.Execute(transition);
				}
			}

			internal void InternalAction(Transition transition, object[] args)
			{
				InternalTriggerBehaviour.Sync sync = null;
				for (StateRepresentation stateRepresentation = this; stateRepresentation != null; stateRepresentation = stateRepresentation._superstate)
				{
					if (stateRepresentation.TryFindLocalHandler(transition.Trigger, args, out var handlerResult))
					{
						if (handlerResult?.Handler is InternalTriggerBehaviour.Async)
						{
							throw new InvalidOperationException("Running Async internal actions in synchronous mode is not allowed");
						}
						sync = handlerResult?.Handler as InternalTriggerBehaviour.Sync;
						break;
					}
				}
				if (sync == null)
				{
					throw new ArgumentNullException("The configuration is incorrect, no action assigned to this internal transition.");
				}
				sync.InternalAction(transition, args);
			}

			public void AddTriggerBehaviour(TriggerBehaviour triggerBehaviour)
			{
				if (!TriggerBehaviours.TryGetValue(triggerBehaviour.Trigger, out var value))
				{
					value = new List<TriggerBehaviour>(1);
					TriggerBehaviours.Add(triggerBehaviour.Trigger, value);
				}
				value.Add(triggerBehaviour);
			}

			public void AddSubstate(StateRepresentation substate)
			{
				_substates.Add(substate);
			}

			public bool Includes(TState state)
			{
				if (!StateMachine<TState, TTrigger>.Eq(_state, state))
				{
					return !_substates.TrueForAll((StateRepresentation s) => !s.Includes(state));
				}
				return true;
			}

			public bool IsIncludedIn(TState state)
			{
				if (!StateMachine<TState, TTrigger>.Eq(_state, state))
				{
					if (_superstate != null)
					{
						return _superstate.IsIncludedIn(state);
					}
					return false;
				}
				return true;
			}

			public IEnumerable<TTrigger> GetPermittedTriggers(params object[] args)
			{
				IEnumerable<TTrigger> enumerable = from t in TriggerBehaviours
					where t.Value.Any((TriggerBehaviour a) => a.UnmetGuardConditions(args).Count == 0)
					select t.Key;
				if (Superstate != null)
				{
					enumerable = enumerable.Union(Superstate.GetPermittedTriggers(args));
				}
				return enumerable;
			}

			internal void SetInitialTransition(TState state)
			{
				InitialTransitionTarget = state;
				HasInitialTransition = true;
			}
		}

		public readonly struct Transition
		{
			public readonly TState Source;

			public readonly TState Destination;

			public readonly TTrigger Trigger;

			public readonly bool IsInitial;

			public readonly object[] Parameters;

			public bool IsReentry => StateMachine<TState, TTrigger>.Eq(Source, Destination);

			public Transition(TState source, TState destination, TTrigger trigger, object[] parameters = null, bool isInitial = false)
			{
				Source = source;
				Destination = destination;
				Trigger = trigger;
				IsInitial = isInitial;
				Parameters = parameters ?? Array.Empty<object>();
			}
		}

		internal class TransitionGuard
		{
			public static readonly TransitionGuard Empty = new TransitionGuard(Array.Empty<Tuple<Func<object[], bool>, string>>());

			internal GuardCondition[] Conditions { get; }

			internal ICollection<Func<object[], bool>> Guards
			{
				get
				{
					Func<object[], bool>[] array = new Func<object[], bool>[Conditions.Length];
					for (int i = 0; i < Conditions.Length; i++)
					{
						array[i] = Conditions[i].Guard;
					}
					return array;
				}
			}

			public static Func<object[], bool> ToPackedGuard<TArg0>(Func<TArg0, bool> guard)
			{
				return (object[] args) => guard(ParameterConversion.Unpack<TArg0>(args, 0));
			}

			public static Func<object[], bool> ToPackedGuard<TArg0, TArg1>(Func<TArg0, TArg1, bool> guard)
			{
				return (object[] args) => guard(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1));
			}

			public static Func<object[], bool> ToPackedGuard<TArg0, TArg1, TArg2>(Func<TArg0, TArg1, TArg2, bool> guard)
			{
				return (object[] args) => guard(ParameterConversion.Unpack<TArg0>(args, 0), ParameterConversion.Unpack<TArg1>(args, 1), ParameterConversion.Unpack<TArg2>(args, 2));
			}

			public static Tuple<Func<object[], bool>, string>[] ToPackedGuards<TArg0>(Tuple<Func<TArg0, bool>, string>[] guards)
			{
				Tuple<Func<object[], bool>, string>[] array = new Tuple<Func<object[], bool>, string>[guards.Length];
				for (int i = 0; i < guards.Length; i++)
				{
					Tuple<Func<TArg0, bool>, string> tuple = guards[i];
					array[i] = new Tuple<Func<object[], bool>, string>(ToPackedGuard(tuple.Item1), tuple.Item2);
				}
				return array;
			}

			public static Tuple<Func<object[], bool>, string>[] ToPackedGuards<TArg0, TArg1>(Tuple<Func<TArg0, TArg1, bool>, string>[] guards)
			{
				Tuple<Func<object[], bool>, string>[] array = new Tuple<Func<object[], bool>, string>[guards.Length];
				for (int i = 0; i < guards.Length; i++)
				{
					Tuple<Func<TArg0, TArg1, bool>, string> tuple = guards[i];
					array[i] = new Tuple<Func<object[], bool>, string>(ToPackedGuard(tuple.Item1), tuple.Item2);
				}
				return array;
			}

			public static Tuple<Func<object[], bool>, string>[] ToPackedGuards<TArg0, TArg1, TArg2>(Tuple<Func<TArg0, TArg1, TArg2, bool>, string>[] guards)
			{
				Tuple<Func<object[], bool>, string>[] array = new Tuple<Func<object[], bool>, string>[guards.Length];
				for (int i = 0; i < guards.Length; i++)
				{
					Tuple<Func<TArg0, TArg1, TArg2, bool>, string> tuple = guards[i];
					array[i] = new Tuple<Func<object[], bool>, string>(ToPackedGuard(tuple.Item1), tuple.Item2);
				}
				return array;
			}

			internal TransitionGuard(Tuple<Func<bool>, string>[] guards)
			{
				GuardCondition[] array = new GuardCondition[guards.Length];
				for (int i = 0; i < guards.Length; i++)
				{
					Tuple<Func<bool>, string> tuple = guards[i];
					array[i] = new GuardCondition(tuple.Item1, InvocationInfo.Create(tuple.Item1, tuple.Item2));
				}
				Conditions = array;
			}

			internal TransitionGuard(Func<bool> guard, string description = null)
			{
				Conditions = new GuardCondition[1]
				{
					new GuardCondition(guard, InvocationInfo.Create(guard, description))
				};
			}

			internal TransitionGuard(Tuple<Func<object[], bool>, string>[] guards)
			{
				GuardCondition[] array = new GuardCondition[guards.Length];
				for (int i = 0; i < guards.Length; i++)
				{
					Tuple<Func<object[], bool>, string> tuple = guards[i];
					array[i] = new GuardCondition(tuple.Item1, InvocationInfo.Create(tuple.Item1, tuple.Item2));
				}
				Conditions = array;
			}

			internal TransitionGuard(Func<object[], bool> guard, string description = null)
			{
				Conditions = new GuardCondition[1]
				{
					new GuardCondition(guard, InvocationInfo.Create(guard, description))
				};
			}

			public bool GuardConditionsMet(object[] args)
			{
				for (int i = 0; i < Conditions.Length; i++)
				{
					Func<object[], bool> guard = Conditions[i].Guard;
					if (guard == null || !guard(args))
					{
						return false;
					}
				}
				return true;
			}

			public ICollection<string> UnmetGuardConditions(object[] args)
			{
				List<string> list = null;
				GuardCondition[] conditions = Conditions;
				foreach (GuardCondition guardCondition in conditions)
				{
					if (!guardCondition.Guard(args))
					{
						if (list == null)
						{
							list = new List<string>(1);
						}
						list.Add(guardCondition.Description);
					}
				}
				if (list != null)
				{
					return list;
				}
				return Array.Empty<string>();
			}
		}

		internal class TransitioningTriggerBehaviour : TriggerBehaviour
		{
			internal TState Destination { get; }

			public TransitioningTriggerBehaviour(TTrigger trigger, TState destination, TransitionGuard transitionGuard)
				: base(trigger, transitionGuard)
			{
				Destination = destination;
			}
		}

		internal abstract class TriggerBehaviour
		{
			private readonly TransitionGuard _guard;

			public TTrigger Trigger { get; }

			internal TransitionGuard Guard => _guard;

			internal ICollection<Func<object[], bool>> Guards => _guard.Guards;

			protected TriggerBehaviour(TTrigger trigger, TransitionGuard guard)
			{
				_guard = guard ?? TransitionGuard.Empty;
				Trigger = trigger;
			}

			public bool GuardConditionsMet(params object[] args)
			{
				return _guard.GuardConditionsMet(args);
			}

			public ICollection<string> UnmetGuardConditions(object[] args)
			{
				return _guard.UnmetGuardConditions(args);
			}
		}

		internal readonly struct TriggerBehaviourResult
		{
			public readonly TriggerBehaviour Handler;

			public readonly ICollection<string> UnmetGuardConditions;

			public TriggerBehaviourResult(TriggerBehaviour handler, ICollection<string> unmetGuardConditions)
			{
				Handler = handler;
				UnmetGuardConditions = unmetGuardConditions;
			}
		}

		public class TriggerWithParameters
		{
			private readonly TTrigger _underlyingTrigger;

			private readonly Type[] _argumentTypes;

			public IEnumerable<Type> ArgumentTypes => _argumentTypes;

			public TTrigger Trigger => _underlyingTrigger;

			public TriggerWithParameters(TTrigger underlyingTrigger, params Type[] argumentTypes)
			{
				_underlyingTrigger = underlyingTrigger;
				_argumentTypes = argumentTypes ?? throw new ArgumentNullException("argumentTypes");
			}

			public void ValidateParameters(object[] args)
			{
				if (args == null)
				{
					throw new ArgumentNullException("args");
				}
				ParameterConversion.Validate(args, _argumentTypes);
			}
		}

		public class TriggerWithParameters<TArg0> : TriggerWithParameters
		{
			public TriggerWithParameters(TTrigger underlyingTrigger)
				: base(underlyingTrigger, new Type[1] { typeof(TArg0) })
			{
			}
		}

		public class TriggerWithParameters<TArg0, TArg1> : TriggerWithParameters
		{
			public TriggerWithParameters(TTrigger underlyingTrigger)
				: base(underlyingTrigger, new Type[2]
				{
					typeof(TArg0),
					typeof(TArg1)
				})
			{
			}
		}

		public class TriggerWithParameters<TArg0, TArg1, TArg2> : TriggerWithParameters
		{
			public TriggerWithParameters(TTrigger underlyingTrigger)
				: base(underlyingTrigger, new Type[3]
				{
					typeof(TArg0),
					typeof(TArg1),
					typeof(TArg2)
				})
			{
			}
		}

		private abstract class UnhandledTriggerAction
		{
			internal class Sync : UnhandledTriggerAction
			{
				private readonly Action<TState, TTrigger, ICollection<string>> _action;

				internal Sync(Action<TState, TTrigger, ICollection<string>> action = null)
				{
					_action = action;
				}

				public override void Execute(TState state, TTrigger trigger, ICollection<string> unmetGuards)
				{
					_action(state, trigger, unmetGuards);
				}

				public override Task ExecuteAsync(TState state, TTrigger trigger, ICollection<string> unmetGuards)
				{
					Execute(state, trigger, unmetGuards);
					return TaskResult.Done;
				}
			}

			internal class Async : UnhandledTriggerAction
			{
				private readonly Func<TState, TTrigger, ICollection<string>, Task> _action;

				internal Async(Func<TState, TTrigger, ICollection<string>, Task> action)
				{
					_action = action;
				}

				public override void Execute(TState state, TTrigger trigger, ICollection<string> unmetGuards)
				{
					throw new InvalidOperationException("Cannot execute asynchronous action specified in OnUnhandledTrigger. Use asynchronous version of Fire [FireAsync]");
				}

				public override Task ExecuteAsync(TState state, TTrigger trigger, ICollection<string> unmetGuards)
				{
					return _action(state, trigger, unmetGuards);
				}
			}

			public abstract void Execute(TState state, TTrigger trigger, ICollection<string> unmetGuards);

			public abstract Task ExecuteAsync(TState state, TTrigger trigger, ICollection<string> unmetGuards);
		}

		private readonly IDictionary<TState, StateRepresentation> _stateConfiguration = new Dictionary<TState, StateRepresentation>();

		private readonly IDictionary<TTrigger, TriggerWithParameters> _triggerConfiguration = new Dictionary<TTrigger, TriggerWithParameters>();

		private readonly Func<TState> _stateAccessor;

		private readonly Action<TState> _stateMutator;

		private UnhandledTriggerAction _unhandledTriggerAction;

		private readonly OnTransitionedEvent _onTransitionedEvent;

		private readonly OnTransitionedEvent _onTransitionCompletedEvent;

		private readonly TState _initialState;

		private readonly FiringMode _firingMode;

		private readonly Queue<QueuedTrigger> _eventQueue = new Queue<QueuedTrigger>();

		private bool _firing;

		public bool RetainSynchronizationContext { get; set; }

		public TState State
		{
			get
			{
				return _stateAccessor();
			}
			private set
			{
				_stateMutator(value);
			}
		}

		public IEnumerable<TTrigger> PermittedTriggers => GetPermittedTriggers();

		private StateRepresentation CurrentRepresentation => GetRepresentation(State);

		public StateMachine(Func<TState> stateAccessor, Action<TState> stateMutator)
			: this(stateAccessor, stateMutator, FiringMode.Queued)
		{
		}

		public StateMachine(TState initialState)
			: this(initialState, FiringMode.Queued)
		{
		}

		public StateMachine(Func<TState> stateAccessor, Action<TState> stateMutator, FiringMode firingMode)
			: this()
		{
			_stateAccessor = stateAccessor ?? throw new ArgumentNullException("stateAccessor");
			_stateMutator = stateMutator ?? throw new ArgumentNullException("stateMutator");
			_initialState = stateAccessor();
			_firingMode = firingMode;
		}

		public StateMachine(TState initialState, FiringMode firingMode)
			: this()
		{
			StateReference reference = new StateReference
			{
				State = initialState
			};
			_stateAccessor = () => reference.State;
			_stateMutator = delegate(TState s)
			{
				reference.State = s;
			};
			_initialState = initialState;
			_firingMode = firingMode;
		}

		private StateMachine()
		{
			_unhandledTriggerAction = new UnhandledTriggerAction.Sync(DefaultUnhandledTriggerAction);
			_onTransitionedEvent = new OnTransitionedEvent();
			_onTransitionCompletedEvent = new OnTransitionedEvent();
		}

		public IEnumerable<TTrigger> GetPermittedTriggers(params object[] args)
		{
			return CurrentRepresentation.GetPermittedTriggers(args);
		}

		public IEnumerable<TriggerDetails<TState, TTrigger>> GetDetailedPermittedTriggers(params object[] args)
		{
			return from trigger in CurrentRepresentation.GetPermittedTriggers(args)
				select new TriggerDetails<TState, TTrigger>(trigger, _triggerConfiguration);
		}

		public StateMachineInfo GetInfo()
		{
			StateInfo initialState = StateInfo.CreateStateInfo(new StateRepresentation(_initialState, RetainSynchronizationContext));
			Dictionary<TState, StateRepresentation> dictionary = new Dictionary<TState, StateRepresentation>(_stateConfiguration);
			List<TState> list = _stateConfiguration.SelectMany((KeyValuePair<TState, StateRepresentation> kvp) => kvp.Value.TriggerBehaviours.SelectMany((KeyValuePair<TTrigger, List<TriggerBehaviour>> b) => from tb in b.Value.OfType<TransitioningTriggerBehaviour>()
				select tb.Destination)).ToList();
			list.AddRange(_stateConfiguration.SelectMany((KeyValuePair<TState, StateRepresentation> kvp) => kvp.Value.TriggerBehaviours.SelectMany((KeyValuePair<TTrigger, List<TriggerBehaviour>> b) => from tb in b.Value.OfType<ReentryTriggerBehaviour>()
				select tb.Destination)).ToList());
			StateRepresentation[] array = (from underlying in list.Distinct().Except(dictionary.Keys)
				select new StateRepresentation(underlying, RetainSynchronizationContext)).ToArray();
			foreach (StateRepresentation stateRepresentation in array)
			{
				dictionary.Add(stateRepresentation.UnderlyingState, stateRepresentation);
			}
			Dictionary<TState, StateInfo> info = dictionary.ToDictionary((KeyValuePair<TState, StateRepresentation> kvp) => kvp.Key, (KeyValuePair<TState, StateRepresentation> kvp) => StateInfo.CreateStateInfo(kvp.Value));
			foreach (KeyValuePair<TState, StateInfo> item in info)
			{
				StateInfo.AddRelationships(item.Value, dictionary[item.Key], (TState k) => info[k]);
			}
			return new StateMachineInfo(info.Values, typeof(TState), typeof(TTrigger), initialState);
		}

		private StateRepresentation GetRepresentation(TState state)
		{
			if (!_stateConfiguration.TryGetValue(state, out var value))
			{
				value = new StateRepresentation(state, RetainSynchronizationContext);
				_stateConfiguration.Add(state, value);
			}
			return value;
		}

		public StateConfiguration Configure(TState state)
		{
			return new StateConfiguration(this, GetRepresentation(state), GetRepresentation);
		}

		public void Fire(TTrigger trigger)
		{
			InternalFire(trigger);
		}

		public void Fire(TriggerWithParameters trigger, params object[] args)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			InternalFire(trigger.Trigger, args);
		}

		public TriggerWithParameters SetTriggerParameters(TTrigger trigger, params Type[] argumentTypes)
		{
			TriggerWithParameters triggerWithParameters = new TriggerWithParameters(trigger, argumentTypes);
			SaveTriggerConfiguration(triggerWithParameters);
			return triggerWithParameters;
		}

		public void Fire<TArg0>(TriggerWithParameters<TArg0> trigger, TArg0 arg0)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			InternalFire(trigger.Trigger, arg0);
		}

		public void Fire<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, TArg0 arg0, TArg1 arg1)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			InternalFire(trigger.Trigger, arg0, arg1);
		}

		public void Fire<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, TArg0 arg0, TArg1 arg1, TArg2 arg2)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			InternalFire(trigger.Trigger, arg0, arg1, arg2);
		}

		public void Activate()
		{
			GetRepresentation(State).Activate();
		}

		public void Deactivate()
		{
			GetRepresentation(State).Deactivate();
		}

		private void InternalFire(TTrigger trigger, params object[] args)
		{
			switch (_firingMode)
			{
			case FiringMode.Immediate:
				InternalFireOne(trigger, args);
				break;
			case FiringMode.Queued:
				InternalFireQueued(trigger, args);
				break;
			default:
				throw new InvalidOperationException("The firing mode has not been configured!");
			}
		}

		private void InternalFireQueued(TTrigger trigger, params object[] args)
		{
			_eventQueue.Enqueue(new QueuedTrigger(trigger, args));
			if (_firing)
			{
				return;
			}
			try
			{
				_firing = true;
				while (_eventQueue.Count != 0)
				{
					QueuedTrigger queuedTrigger = _eventQueue.Dequeue();
					InternalFireOne(queuedTrigger.Trigger, queuedTrigger.Args);
				}
			}
			finally
			{
				_firing = false;
			}
		}

		private void InternalFireOne(TTrigger trigger, params object[] args)
		{
			if (_triggerConfiguration.TryGetValue(trigger, out var value))
			{
				value.ValidateParameters(args);
			}
			TState state = State;
			StateRepresentation representation = GetRepresentation(state);
			if (!representation.TryFindHandler(trigger, args, out var handler))
			{
				_unhandledTriggerAction.Execute(representation.UnderlyingState, trigger, handler?.UnmetGuardConditions);
				return;
			}
			TriggerBehaviour triggerBehaviour = handler?.Handler;
			if (triggerBehaviour != null)
			{
				if (triggerBehaviour is IgnoredTriggerBehaviour)
				{
					return;
				}
				if (triggerBehaviour is ReentryTriggerBehaviour reentryTriggerBehaviour)
				{
					ReentryTriggerBehaviour reentryTriggerBehaviour2 = reentryTriggerBehaviour;
					Transition transition = new Transition(state, reentryTriggerBehaviour2.Destination, trigger, args);
					HandleReentryTrigger(args, representation, transition);
					return;
				}
				if (triggerBehaviour is DynamicTriggerBehaviour dynamicTriggerBehaviour)
				{
					dynamicTriggerBehaviour.GetDestinationState(state, args, out var destination);
					Transition transition2 = new Transition(state, destination, trigger, args);
					HandleTransitioningTrigger(args, representation, transition2);
					return;
				}
				if (triggerBehaviour is TransitioningTriggerBehaviour transitioningTriggerBehaviour)
				{
					TransitioningTriggerBehaviour transitioningTriggerBehaviour2 = transitioningTriggerBehaviour;
					if (!Eq(state, transitioningTriggerBehaviour2.Destination))
					{
						Transition transition3 = new Transition(state, transitioningTriggerBehaviour2.Destination, trigger, args);
						HandleTransitioningTrigger(args, representation, transition3);
					}
					return;
				}
				if (triggerBehaviour is InternalTriggerBehaviour)
				{
					Transition transition4 = new Transition(state, state, trigger, args);
					CurrentRepresentation.InternalAction(transition4, args);
					return;
				}
			}
			throw new InvalidOperationException("State machine configuration incorrect, no handler for trigger.");
		}

		private void HandleReentryTrigger(object[] args, StateRepresentation representativeState, Transition transition)
		{
			transition = representativeState.Exit(transition);
			StateRepresentation representation = GetRepresentation(transition.Destination);
			StateRepresentation stateRepresentation;
			if (!Eq(transition.Source, transition.Destination))
			{
				transition = new Transition(transition.Destination, transition.Destination, transition.Trigger, args);
				representation.Exit(transition);
				_onTransitionedEvent.Invoke(transition);
				stateRepresentation = EnterState(representation, transition, args);
				_onTransitionCompletedEvent.Invoke(transition);
			}
			else
			{
				_onTransitionedEvent.Invoke(transition);
				stateRepresentation = EnterState(representation, transition, args);
				_onTransitionCompletedEvent.Invoke(transition);
			}
			State = stateRepresentation.UnderlyingState;
		}

		private void HandleTransitioningTrigger(object[] args, StateRepresentation representativeState, Transition transition)
		{
			transition = representativeState.Exit(transition);
			State = transition.Destination;
			StateRepresentation representation = GetRepresentation(transition.Destination);
			_onTransitionedEvent.Invoke(transition);
			StateRepresentation stateRepresentation = EnterState(representation, transition, args);
			if (!Eq(stateRepresentation.UnderlyingState, State))
			{
				State = stateRepresentation.UnderlyingState;
			}
			_onTransitionCompletedEvent.Invoke(new Transition(transition.Source, State, transition.Trigger, transition.Parameters));
		}

		private StateRepresentation EnterState(StateRepresentation representation, Transition transition, object[] args)
		{
			representation.Enter(transition, args);
			if (_firingMode == FiringMode.Immediate && !Eq(State, transition.Destination))
			{
				representation = GetRepresentation(State);
				transition = new Transition(transition.Source, State, transition.Trigger, args);
			}
			if (representation.HasInitialTransition)
			{
				bool flag = true;
				foreach (StateRepresentation substate in representation.GetSubstates())
				{
					if (Eq(substate.UnderlyingState, representation.InitialTransitionTarget))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					throw new InvalidOperationException($"The target ({representation.InitialTransitionTarget}) for the initial transition is not a substate.");
				}
				Transition transition2 = new Transition(transition.Source, representation.InitialTransitionTarget, transition.Trigger, args, isInitial: true);
				representation = GetRepresentation(representation.InitialTransitionTarget);
				_onTransitionedEvent.Invoke(new Transition(transition.Destination, transition2.Destination, transition.Trigger, transition.Parameters));
				representation = EnterState(representation, transition2, args);
			}
			return representation;
		}

		public void OnUnhandledTrigger(Action<TState, TTrigger> unhandledTriggerAction)
		{
			if (unhandledTriggerAction == null)
			{
				throw new ArgumentNullException("unhandledTriggerAction");
			}
			_unhandledTriggerAction = new UnhandledTriggerAction.Sync(delegate(TState s, TTrigger t, ICollection<string> c)
			{
				unhandledTriggerAction(s, t);
			});
		}

		public void OnUnhandledTrigger(Action<TState, TTrigger, ICollection<string>> unhandledTriggerAction)
		{
			if (unhandledTriggerAction == null)
			{
				throw new ArgumentNullException("unhandledTriggerAction");
			}
			_unhandledTriggerAction = new UnhandledTriggerAction.Sync(unhandledTriggerAction);
		}

		public bool IsInState(TState state)
		{
			return CurrentRepresentation.IsIncludedIn(state);
		}

		public bool CanFire(TTrigger trigger)
		{
			return CurrentRepresentation.CanHandle(trigger);
		}

		public bool CanFire<TArg0>(TriggerWithParameters<TArg0> trigger, TArg0 arg0)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			return CurrentRepresentation.CanHandle(trigger.Trigger, arg0);
		}

		public bool CanFire<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, TArg0 arg0, TArg1 arg1)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			return CurrentRepresentation.CanHandle(trigger.Trigger, arg0, arg1);
		}

		public bool CanFire<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, TArg0 arg0, TArg1 arg1, TArg2 arg2)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			return CurrentRepresentation.CanHandle(trigger.Trigger, arg0, arg1, arg2);
		}

		public bool CanFire(TTrigger trigger, out ICollection<string> unmetGuards)
		{
			return CurrentRepresentation.CanHandle(trigger, new object[0], out unmetGuards);
		}

		public bool CanFire<TArg0>(TriggerWithParameters<TArg0> trigger, TArg0 arg0, out ICollection<string> unmetGuards)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			return CurrentRepresentation.CanHandle(trigger.Trigger, new object[1] { arg0 }, out unmetGuards);
		}

		public bool CanFire<TArg0, TArg1>(TriggerWithParameters<TArg0, TArg1> trigger, TArg0 arg0, TArg1 arg1, out ICollection<string> unmetGuards)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			return CurrentRepresentation.CanHandle(trigger.Trigger, new object[2] { arg0, arg1 }, out unmetGuards);
		}

		public bool CanFire<TArg0, TArg1, TArg2>(TriggerWithParameters<TArg0, TArg1, TArg2> trigger, TArg0 arg0, TArg1 arg1, TArg2 arg2, out ICollection<string> unmetGuards)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			return CurrentRepresentation.CanHandle(trigger.Trigger, new object[3] { arg0, arg1, arg2 }, out unmetGuards);
		}

		public override string ToString()
		{
			return string.Format("StateMachine {{ State = {0}, PermittedTriggers = {{ {1} }}}}", State, string.Join(", ", from t in GetPermittedTriggers()
				select t.ToString()));
		}

		public TriggerWithParameters<TArg0> SetTriggerParameters<TArg0>(TTrigger trigger)
		{
			TriggerWithParameters<TArg0> triggerWithParameters = new TriggerWithParameters<TArg0>(trigger);
			SaveTriggerConfiguration(triggerWithParameters);
			return triggerWithParameters;
		}

		public TriggerWithParameters<TArg0, TArg1> SetTriggerParameters<TArg0, TArg1>(TTrigger trigger)
		{
			TriggerWithParameters<TArg0, TArg1> triggerWithParameters = new TriggerWithParameters<TArg0, TArg1>(trigger);
			SaveTriggerConfiguration(triggerWithParameters);
			return triggerWithParameters;
		}

		public TriggerWithParameters<TArg0, TArg1, TArg2> SetTriggerParameters<TArg0, TArg1, TArg2>(TTrigger trigger)
		{
			TriggerWithParameters<TArg0, TArg1, TArg2> triggerWithParameters = new TriggerWithParameters<TArg0, TArg1, TArg2>(trigger);
			SaveTriggerConfiguration(triggerWithParameters);
			return triggerWithParameters;
		}

		private void SaveTriggerConfiguration(TriggerWithParameters trigger)
		{
			if (_triggerConfiguration.ContainsKey(trigger.Trigger))
			{
				throw new InvalidOperationException(string.Format(StateMachineResources.CannotReconfigureParameters, trigger));
			}
			_triggerConfiguration.Add(trigger.Trigger, trigger);
		}

		private void DefaultUnhandledTriggerAction(TState state, TTrigger trigger, ICollection<string> unmetGuardConditions)
		{
			if (unmetGuardConditions != null && unmetGuardConditions.Count > 0)
			{
				throw new InvalidOperationException(string.Format(StateMachineResources.NoTransitionsUnmetGuardConditions, trigger, state, string.Join(", ", unmetGuardConditions)));
			}
			throw new InvalidOperationException(string.Format(StateMachineResources.NoTransitionsPermitted, trigger, state));
		}

		public void OnTransitioned(Action<Transition> onTransitionAction)
		{
			if (onTransitionAction == null)
			{
				throw new ArgumentNullException("onTransitionAction");
			}
			_onTransitionedEvent.Register(onTransitionAction);
		}

		public void OnTransitionCompleted(Action<Transition> onTransitionAction)
		{
			if (onTransitionAction == null)
			{
				throw new ArgumentNullException("onTransitionAction");
			}
			_onTransitionCompletedEvent.Register(onTransitionAction);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool Eq<T>(T a, T b)
		{
			return EqualityComparer<T>.Default.Equals(a, b);
		}
	}
}
