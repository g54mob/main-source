namespace NekoLib.ReactiveProps
{
	public struct ReadonlyProp<T> : IReadOnlyProp<T>
	{
		public T Value { get; }

		public ReadonlyProp(T value)
		{
			Value = value;
		}
	}
}
