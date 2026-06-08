using System;
using System.Globalization;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public class EnvironmentVariableAWSRegion : AWSRegion
	{
		public const string ENVIRONMENT_VARIABLE_REGION = "AWS_REGION";

		public const string ENVIRONMENT_VARIABLE_DEFAULT_REGION = "AWS_DEFAULT_REGION";

		public EnvironmentVariableAWSRegion()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("AWS_REGION");
			if (string.IsNullOrEmpty(environmentVariable))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The environment variable {0} was not set with AWS region data.", "AWS_REGION"));
			}
			SetRegionFromName(environmentVariable);
			Logger.GetLogger(typeof(EnvironmentVariableAWSRegion)).InfoFormat("Region found using environment variable.");
		}
	}
}
