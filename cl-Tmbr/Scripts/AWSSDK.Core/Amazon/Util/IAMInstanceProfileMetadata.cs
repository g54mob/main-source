using System;

namespace Amazon.Util
{
	public class IAMInstanceProfileMetadata
	{
		public string Code { get; set; }

		public string Message { get; set; }

		public DateTime LastUpdated { get; set; }

		public string InstanceProfileArn { get; set; }

		public string InstanceProfileId { get; set; }
	}
}
