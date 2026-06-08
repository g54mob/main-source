using System;
using System.Linq;
using Amazon.Runtime;

namespace Amazon.S3
{
	public static class ArnExtensions
	{
		internal const string ResourceTypeAccessPoint = "accesspoint";

		internal const string ResourceTypeBucketName = "bucket_name";

		internal const string ResourceTypeOutpostAccessPoint = "outpost";

		public static bool TryParseAccessPoint(this Arn arn, out string accessPoint)
		{
			accessPoint = null;
			if (string.IsNullOrEmpty(arn.Resource))
			{
				return false;
			}
			if (arn.Resource.StartsWith("accesspoint:", StringComparison.Ordinal) || arn.Resource.StartsWith("accesspoint/", StringComparison.Ordinal))
			{
				accessPoint = arn.Resource.Substring("accesspoint".Length + 1);
				return true;
			}
			return false;
		}

		public static bool TryParseBucket(this Arn arn, out string bucketName)
		{
			bucketName = null;
			if (string.IsNullOrEmpty(arn.Resource))
			{
				return false;
			}
			if (arn.Resource.StartsWith("bucket_name:", StringComparison.Ordinal) || arn.Resource.StartsWith("bucket_name/", StringComparison.Ordinal))
			{
				bucketName = arn.Resource.Substring("bucket_name".Length + 1);
				return true;
			}
			return false;
		}

		public static bool IsOutpostArn(this Arn arn)
		{
			if (string.IsNullOrEmpty(arn.Resource))
			{
				return false;
			}
			return arn.Resource.StartsWith("outpost", StringComparison.Ordinal);
		}

		public static bool IsService(this Arn arn, string serviceName)
		{
			return arn.Service.Equals(serviceName, StringComparison.Ordinal);
		}

		public static bool IsMRAPArn(this Arn arn)
		{
			if (string.IsNullOrEmpty(arn.Resource))
			{
				return false;
			}
			if (!arn.Resource.StartsWith("accesspoint:", StringComparison.Ordinal) && !arn.Resource.StartsWith("accesspoint/", StringComparison.Ordinal))
			{
				return false;
			}
			return string.IsNullOrEmpty(arn.Region);
		}

		public static S3OutpostResource ParseOutpost(this Arn arn)
		{
			if (string.IsNullOrEmpty(arn.Resource))
			{
				throw new AmazonClientException("Arn Resource can not be null");
			}
			if (!arn.IsOutpostArn())
			{
				throw new AmazonClientException("Arn Resource: " + arn.Resource + " does not resemble an outpost access point");
			}
			string resource = arn.Resource;
			char[] separator = new char[2] { '/', ':' };
			string[] array = resource.Split(separator, 5);
			if (array.Length < 4 || !string.Equals(array[2], "accesspoint"))
			{
				throw new AmazonClientException("Invalid ARN: " + arn.ToString() + ", outpost resource format is incorrect");
			}
			S3OutpostResource s3OutpostResource = new S3OutpostResource(arn);
			s3OutpostResource.OutpostId = array[1];
			s3OutpostResource.AccessPointName = array[3];
			if (array.Length > 4)
			{
				s3OutpostResource.Key = array[4];
			}
			return new S3OutpostResource(arn)
			{
				OutpostId = array[1],
				AccessPointName = array[3],
				Key = ((array.Length > 4) ? array[4] : null)
			};
		}

		public static bool HasValidAccountId(this Arn arn)
		{
			if (!string.IsNullOrEmpty(arn.AccountId))
			{
				if (arn.AccountId.Length == 12)
				{
					return arn.AccountId.ToCharArray().All((char x) => char.IsDigit(x));
				}
				return false;
			}
			return true;
		}
	}
}
