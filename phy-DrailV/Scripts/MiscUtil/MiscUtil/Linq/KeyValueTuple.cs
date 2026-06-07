namespace MiscUtil.Linq
{
	public struct KeyValueTuple<TKey, T>
	{
		private readonly TKey key;

		private readonly T value;

		public TKey Key => key;

		public T Value => value;

		public KeyValueTuple(TKey key, T value)
		{
			this.key = key;
			this.value = value;
		}
	}
	public struct KeyValueTuple<TKey, T1, T2>
	{
		private readonly TKey key;

		private readonly T1 value1;

		private readonly T2 value2;

		public TKey Key => key;

		public T1 Value1 => value1;

		public T2 Value2 => value2;

		public KeyValueTuple(TKey key, T1 value1, T2 value2)
		{
			this.key = key;
			this.value1 = value1;
			this.value2 = value2;
		}
	}
	public struct KeyValueTuple<TKey, T1, T2, T3>
	{
		private readonly TKey key;

		private readonly T1 value1;

		private readonly T2 value2;

		private readonly T3 value3;

		public TKey Key => key;

		public T1 Value1 => value1;

		public T2 Value2 => value2;

		public T3 Value3 => value3;

		public KeyValueTuple(TKey key, T1 value1, T2 value2, T3 value3)
		{
			this.key = key;
			this.value1 = value1;
			this.value2 = value2;
			this.value3 = value3;
		}
	}
	public struct KeyValueTuple<TKey, T1, T2, T3, T4>
	{
		private readonly TKey key;

		private readonly T1 value1;

		private readonly T2 value2;

		private readonly T3 value3;

		private readonly T4 value4;

		public TKey Key => key;

		public T1 Value1 => value1;

		public T2 Value2 => value2;

		public T3 Value3 => value3;

		public T4 Value4 => value4;

		public KeyValueTuple(TKey key, T1 value1, T2 value2, T3 value3, T4 value4)
		{
			this.key = key;
			this.value1 = value1;
			this.value2 = value2;
			this.value3 = value3;
			this.value4 = value4;
		}
	}
}
