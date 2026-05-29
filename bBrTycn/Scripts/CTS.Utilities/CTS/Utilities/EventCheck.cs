using System;

namespace CTS.Utilities
{
	public abstract class EventCheck : EventCheckBase
	{
		private readonly Func<bool> _checkFunction;

		public virtual bool Value => Check();

		public static implicit operator bool(EventCheck check)
		{
			return check.Check();
		}

		protected EventCheck(Func<bool> func)
		{
			_checkFunction = func;
		}

		private bool Check()
		{
			if (LastValue.HasValue)
			{
				return LastValue.Value;
			}
			LastValue = _checkFunction();
			UnregisterTick();
			RegisterTick();
			return LastValue.Value;
		}
	}
	public abstract class EventCheck<TArg> : EventCheckBase
	{
		private readonly Func<TArg, bool> _checkFunction;

		protected EventCheck(Func<TArg, bool> func)
		{
			_checkFunction = func;
		}

		public bool Check(TArg arg)
		{
			if (LastValue.HasValue)
			{
				return LastValue.Value;
			}
			LastValue = _checkFunction(arg);
			UnregisterTick();
			RegisterTick();
			return LastValue.Value;
		}
	}
	public abstract class EventCheck<TArg1, TArg2> : EventCheckBase
	{
		private readonly Func<TArg1, TArg2, bool> _checkFunction;

		protected EventCheck(Func<TArg1, TArg2, bool> func)
		{
			_checkFunction = func;
		}

		public bool Check(TArg1 arg1, TArg2 arg2)
		{
			if (LastValue.HasValue)
			{
				return LastValue.Value;
			}
			LastValue = _checkFunction(arg1, arg2);
			UnregisterTick();
			RegisterTick();
			return LastValue.Value;
		}
	}
}
