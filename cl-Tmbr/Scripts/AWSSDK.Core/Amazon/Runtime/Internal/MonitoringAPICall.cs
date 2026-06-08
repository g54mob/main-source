using System;
using Amazon.Util;

namespace Amazon.Runtime.Internal
{
	public class MonitoringAPICall
	{
		protected enum CSMType
		{
			ApiCall = 0,
			ApiCallAttempt = 1
		}

		public string Api { get; internal set; }

		public string Service { get; internal set; }

		public string ClientId { get; internal set; }

		public long Timestamp { get; internal set; }

		public string Type { get; internal set; }

		public int Version { get; internal set; } = 1;

		public string Region { get; internal set; }

		public string UserAgent { get; internal set; }

		public MonitoringAPICall(IRequestContext requestContext)
			: this()
		{
			Service = requestContext.ServiceMetaData.ServiceId;
			Api = CSMUtilities.GetApiNameFromRequest(requestContext.RequestName, requestContext.ServiceMetaData.OperationNameMapping, Service);
		}

		public MonitoringAPICall()
		{
			Timestamp = AWSSDKUtils.ConvertToUnixEpochMilliseconds(DateTime.UtcNow);
			ClientId = DeterminedCSMConfiguration.Instance.CSMConfiguration.ClientId;
		}
	}
}
