namespace Amazon.S3.Internal
{
	internal static class S3ArnUtils
	{
		internal static bool IsS3AccessPointsArn(string bucket)
		{
			string accessPoint;
			if (Arn.TryParse(bucket, out var arn))
			{
				return arn.TryParseAccessPoint(out accessPoint);
			}
			return false;
		}

		internal static bool IsS3OutpostsArn(string bucket)
		{
			if (Arn.TryParse(bucket, out var arn))
			{
				return arn.IsOutpostArn();
			}
			return false;
		}
	}
}
