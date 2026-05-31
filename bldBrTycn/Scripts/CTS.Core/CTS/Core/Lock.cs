namespace CTS.Core
{
	public readonly struct Lock
	{
		private readonly int _value;

		internal Lock(int value)
		{
			_value = value;
		}

		internal int GetValue()
		{
			return _value;
		}

		public bool IsLocked()
		{
			return GetValue() > 0;
		}

		public bool IsUnlocked()
		{
			return GetValue() <= 0;
		}

		public static implicit operator bool(Lock @lock)
		{
			return @lock.IsLocked();
		}
	}
}
