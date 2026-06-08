namespace Amazon.Runtime
{
	public class RetryableDetails
	{
		public bool Throttling { get; private set; }

		public RetryableDetails(bool throttling)
		{
			Throttling = throttling;
		}
	}
}
