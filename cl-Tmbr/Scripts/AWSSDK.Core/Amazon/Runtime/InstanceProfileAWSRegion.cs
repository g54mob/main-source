using System;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime
{
	public class InstanceProfileAWSRegion : AWSRegion
	{
		public InstanceProfileAWSRegion()
		{
			RegionEndpoint region = EC2InstanceMetadata.Region;
			if (region == null)
			{
				throw new InvalidOperationException("EC2 instance metadata was not available or did not contain region information.");
			}
			base.Region = region;
			Logger.GetLogger(typeof(InstanceProfileAWSRegion)).InfoFormat("Region found using EC2 instance metadata.");
		}
	}
}
