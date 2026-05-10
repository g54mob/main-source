namespace CTS.BBT.AI
{
	public struct RangeValue<T> where T : unmanaged
	{
		public T MinimumValue;

		public T MaximumValue;

		public T CurrentValue;
	}
}
