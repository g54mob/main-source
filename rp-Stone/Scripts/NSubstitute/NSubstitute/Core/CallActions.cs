using System;
using System.Collections.Concurrent;

namespace NSubstitute.Core
{
	public class CallActions : ICallActions
	{
		private class CallAction
		{
			private ICallSpecification _callSpecification;

			private readonly Action<CallInfo> _action;

			public CallAction(ICallSpecification callSpecification, Action<CallInfo> action)
			{
				_callSpecification = callSpecification;
				_action = action;
			}

			public bool IsSatisfiedBy(ICall call)
			{
				return _callSpecification.IsSatisfiedBy(call);
			}

			public void Invoke(CallInfo callInfo)
			{
				_action(callInfo);
				_callSpecification.InvokePerArgumentActions(callInfo);
			}

			public bool IsFor(ICallSpecification spec)
			{
				return _callSpecification == spec;
			}

			public void UpdateCallSpecification(ICallSpecification spec)
			{
				_callSpecification = spec;
			}
		}

		private static readonly Action<CallInfo> EmptyAction = delegate
		{
		};

		private readonly ICallInfoFactory _callInfoFactory;

		private ConcurrentQueue<CallAction> _actions = new ConcurrentQueue<CallAction>();

		public CallActions(ICallInfoFactory callInfoFactory)
		{
			_callInfoFactory = callInfoFactory;
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
						callInfo = _callInfoFactory.Create(call);
					}
					action.Invoke(callInfo);
				}
			}
		}
	}
}
