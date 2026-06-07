using System;
using System.Collections;
using UnityEngine;

namespace Jundroo.Common.Coroutines
{
	public class YieldAction : CustomYieldInstruction
	{
		private Action _action;

		private bool _autocomplete;

		private Func<IEnumerator> _yieldableAction;

		public bool IsComplete { get; private set; }

		public bool IsRunning { get; private set; }

		public override bool keepWaiting => !IsComplete;

		public YieldAction(Action action)
		{
			_action = action;
			_yieldableAction = null;
			_autocomplete = false;
		}

		public YieldAction(Func<IEnumerator> yieldableAction, bool autocomplete = false)
		{
			_action = null;
			_yieldableAction = yieldableAction;
			_autocomplete = autocomplete;
		}

		public void Complete()
		{
			if (!IsRunning)
			{
				throw new InvalidOperationException("Unable to complete " + typeof(YieldAction).Name + " because it is not currently running.");
			}
			IsRunning = false;
			IsComplete = true;
		}

		public IEnumerator Start()
		{
			if (IsRunning)
			{
				throw new InvalidOperationException("Unable to start " + typeof(YieldAction).Name + " because it is already running.");
			}
			if (IsComplete)
			{
				throw new InvalidOperationException("Unable to start " + typeof(YieldAction).Name + " because it has already completed.");
			}
			IsRunning = true;
			if (_yieldableAction != null)
			{
				yield return _yieldableAction();
				if (_autocomplete)
				{
					Complete();
				}
			}
			else
			{
				_action();
			}
			yield return this;
		}
	}
}
