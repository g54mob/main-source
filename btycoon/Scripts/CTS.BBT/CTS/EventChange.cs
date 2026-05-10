namespace CTS
{
	public readonly struct EventChange<T>
	{
		public readonly T Previous;

		public readonly T Current;

		public EventChange(T previous, T current)
		{
			Previous = previous;
			Current = current;
		}
	}
}
