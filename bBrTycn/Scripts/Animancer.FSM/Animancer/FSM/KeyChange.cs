using System;

namespace Animancer.FSM
{
	public struct KeyChange<TKey> : IDisposable
	{
		[ThreadStatic]
		private static KeyChange<TKey> _Current;

		private IKeyedStateMachine<TKey> _StateMachine;

		private TKey _PreviousKey;

		private TKey _NextKey;

		public static bool IsActive => _Current._StateMachine != null;

		public static IKeyedStateMachine<TKey> StateMachine => _Current._StateMachine;

		public static TKey PreviousKey => _Current._PreviousKey;

		public static TKey NextKey => _Current._NextKey;

		internal KeyChange(IKeyedStateMachine<TKey> stateMachine, TKey previousKey, TKey nextKey)
		{
			this = _Current;
			_Current._StateMachine = stateMachine;
			_Current._PreviousKey = previousKey;
			_Current._NextKey = nextKey;
		}

		public void Dispose()
		{
			_Current = this;
		}

		public override string ToString()
		{
			if (!IsActive)
			{
				return "KeyChange<" + typeof(TKey).FullName + "(Not Currently Active)";
			}
			return "KeyChange<" + typeof(TKey).FullName + string.Format(">({0}={1}", "PreviousKey", PreviousKey) + string.Format(", {0}={1})", "NextKey", NextKey);
		}

		public static string CurrentToString()
		{
			return _Current.ToString();
		}
	}
}
