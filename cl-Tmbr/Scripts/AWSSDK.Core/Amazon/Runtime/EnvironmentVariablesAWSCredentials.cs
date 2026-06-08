using System;
using System.Globalization;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public class EnvironmentVariablesAWSCredentials : AWSCredentials
	{
		public const string ENVIRONMENT_VARIABLE_ACCESSKEY = "AWS_ACCESS_KEY_ID";

		public const string ENVIRONMENT_VARIABLE_SECRETKEY = "AWS_SECRET_ACCESS_KEY";

		public const string ENVIRONMENT_VARIABLE_SESSION_TOKEN = "AWS_SESSION_TOKEN";

		public const string ENVIRONMENT_VARIABLE_ACCOUNT_ID = "AWS_ACCOUNT_ID";

		public const string LEGACY_ENVIRONMENT_VARIABLE_SECRETKEY = "AWS_SECRET_KEY";

		private Logger logger;

		public EnvironmentVariablesAWSCredentials()
		{
			logger = Logger.GetLogger(typeof(EnvironmentVariablesAWSCredentials));
			FetchCredentials();
			base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_ENV_VARS);
		}

		public ImmutableCredentials FetchCredentials()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
			string environmentVariable2 = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");
			if (string.IsNullOrEmpty(environmentVariable2))
			{
				environmentVariable2 = Environment.GetEnvironmentVariable("AWS_SECRET_KEY");
				if (!string.IsNullOrEmpty(environmentVariable2))
				{
					logger.InfoFormat("AWS secret key found using legacy and non-standard environment variable '{0}', consider updating to the cross-SDK standard variable '{1}'.", "AWS_SECRET_KEY", "AWS_SECRET_ACCESS_KEY");
				}
			}
			if (string.IsNullOrEmpty(environmentVariable) || string.IsNullOrEmpty(environmentVariable2))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The environment variables {0}/{1}/{2} were not set with AWS credentials.", "AWS_ACCESS_KEY_ID", "AWS_SECRET_ACCESS_KEY", "AWS_SESSION_TOKEN"));
			}
			string environmentVariable3 = Environment.GetEnvironmentVariable("AWS_SESSION_TOKEN");
			string environmentVariable4 = Environment.GetEnvironmentVariable("AWS_ACCOUNT_ID");
			logger.InfoFormat("Credentials found using environment variables.");
			return new ImmutableCredentials(environmentVariable, environmentVariable2, environmentVariable3, environmentVariable4);
		}

		public override ImmutableCredentials GetCredentials()
		{
			return FetchCredentials();
		}
	}
}
