using System;
using System.Collections.Concurrent;

namespace NSubstitute.Core
{
	public class CallActions : ICallActions
	{
		private class CallAction
		{
			public CallAction(ICallSpecification callSpecification, Action<CallInfo> action)
			{
				_003CcallSpecification_003EP = callSpecification;
				_003Caction_003EP = action;
				base._002Ector();
			}

			public bool IsSatisfiedBy(ICall call)
			{
				return _003CcallSpecification_003EP.IsSatisfiedBy(call);
			}

			public void Invoke(CallInfo callInfo)
			{
				_003Caction_003EP(callInfo);
				_003CcallSpecification_003EP.InvokePerArgumentActions(callInfo);
			}

			public bool IsFor(ICallSpecification spec)
			{
				return _003CcallSpecification_003EP == spec;
			}

			public void UpdateCallSpecification(ICallSpecification spec)
			{
				_003CcallSpecification_003EP = spec;
			}
		}

		private static readonly Action<CallInfo> EmptyAction = delegate
		{
		};

		private ConcurrentQueue<CallAction> _actions;

		public CallActions(ICallInfoFactory callInfoFactory)
		{
			_003CcallInfoFactory_003EP = callInfoFactory;
			_actions = new ConcurrentQueue<CallAction>();
			base._002Ector();
		}

		public void Add(ICallSpecification callSpecification, Action<CallInfo> action)
		{
			_actions.Enqueue(new CallAction(callSpecification, action));
		}

		public void Add(ICallSpecification callSpecification)
		{
			Add(callSpecification, EmptyAction);
		}

		public void MoveActionsForSpecToNewSpec(ICallSpecification oldCallSpecification, ICallSpecification newCallSpecification)
		{
			foreach (CallAction action in _actions)
			{
				if (action.IsFor(oldCallSpecification))
				{
					action.UpdateCallSpecification(newCallSpecification);
				}
			}
		}

		public void Clear()
		{
			_actions = new ConcurrentQueue<CallAction>();
		}

		public void InvokeMatchingActions(ICall call)
		{
			if (_actions.IsEmpty)
			{
				return;
			}
			CallInfo callInfo = null;
			foreach (CallAction action in _actions)
			{
				if (action.IsSatisfiedBy(call))
				{
					if (callInfo == null)
					{
						callInfo = _003CcallInfoFactory_003EP.Create(call);
					}
					action.Invoke(callInfo);
				}
			}
		}
	}
}
