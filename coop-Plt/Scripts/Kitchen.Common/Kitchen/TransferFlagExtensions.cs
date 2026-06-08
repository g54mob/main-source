namespace Kitchen
{
	public static class TransferFlagExtensions
	{
		public static bool Has(this TransferFlags flags, TransferFlags flag)
		{
			return (flags & flag) != 0;
		}
	}
}
