namespace Sentry
{
	internal static class TransactionNameSourceExtensions
	{
		public static bool IsHighQuality(this TransactionNameSource transactionNameSource)
		{
			return transactionNameSource != TransactionNameSource.Url;
		}
	}
}
