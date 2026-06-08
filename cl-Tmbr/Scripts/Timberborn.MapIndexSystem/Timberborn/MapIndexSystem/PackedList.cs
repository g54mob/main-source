namespace Timberborn.MapIndexSystem
{
	public readonly struct PackedList<T>
	{
		public T[] Array { get; }

		public PackedList(T[] array)
		{
			Array = array;
		}
	}
}
