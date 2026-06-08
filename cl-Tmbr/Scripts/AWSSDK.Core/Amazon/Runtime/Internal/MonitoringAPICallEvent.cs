namespace Amazon.Runtime.Internal
{
	public class MonitoringAPICallEvent : MonitoringAPICall
	{
		public int AttemptCount { get; internal set; }

		public long Latency { get; internal set; }

		public bool IsLastExceptionRetryable { get; internal set; }

		public string FinalSdkExceptionMessage { get; internal set; }

		public string FinalSdkException { get; internal set; }

		public string FinalAWSException { get; internal set; }

		public string FinalAWSExceptionMessage { get; internal set; }

		public int? FinalHttpStatusCode { get; internal set; }

		public MonitoringAPICallEvent(IRequestContext requestContext)
			: base(requestContext)
		{
			base.Type = CSMType.ApiCall.ToString();
		}
	}
}
