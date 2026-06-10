namespace NSEipix
{
	public static class NumberExtensions
	{
		public static uint Multiply(this uint number, float multiplier)
		{
			return (uint)((float)number * multiplier);
		}
	}
}
