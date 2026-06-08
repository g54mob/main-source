namespace Amazon.Runtime.Internal
{
	public class MonitoringAPICallAttempt : MonitoringAPICall
	{
		public string Fqdn { get; internal set; }

		public string SessionToken { get; internal set; }

		public string AccessKey { get; internal set; }

		public int? HttpStatusCode { get; internal set; }

		public string SdkExceptionMessage { get; internal set; }

		public string SdkException { get; internal set; }

		public string AWSException { get; internal set; }

		public string AWSExceptionMessage { get; internal set; }

		public string XAmznRequestId { get; internal set; }

		public string XAmzRequestId { get; internal set; }

		public string XAmzId2 { get; internal set; }

		public long AttemptLatency { get; internal set; }

		public MonitoringAPICallAttempt(IRequestContext requestContext)
			: base(requestContext)
		{
			base.Type = CSMType.ApiCallAttempt.ToString();
		}
	}
}
