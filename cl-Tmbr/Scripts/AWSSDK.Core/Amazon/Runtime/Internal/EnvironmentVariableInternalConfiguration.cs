using System;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class EnvironmentVariableInternalConfiguration : InternalConfiguration
	{
		private Logger _logger = Logger.GetLogger(typeof(EnvironmentVariableInternalConfiguration));

		public const string ENVIRONMENT_VARIABLE_AWS_ENABLE_ENDPOINT_DISCOVERY = "AWS_ENABLE_ENDPOINT_DISCOVERY";

		public const string ENVIRONMENT_VARIABLE_AWS_MAX_ATTEMPTS = "AWS_MAX_ATTEMPTS";

		public const string ENVIRONMENT_VARIABLE_AWS_RETRY_MODE = "AWS_RETRY_MODE";

		public const string ENVIRONMENT_VARIABLE_AWS_EC2_METADATA_SERVICE_ENDPOINT = "AWS_EC2_METADATA_SERVICE_ENDPOINT";

		public const string ENVIRONMENT_VARIABLE_AWS_EC2_METADATA_SERVICE_ENDPOINT_MODE = "AWS_EC2_METADATA_SERVICE_ENDPOINT_MODE";

		public const string ENVIRONMENT_VARIABLE_AWS_USE_DUALSTACK_ENDPOINT = "AWS_USE_DUALSTACK_ENDPOINT";

		public const string ENVIRONMENT_VARIABLE_AWS_USE_FIPS_ENDPOINT = "AWS_USE_FIPS_ENDPOINT";

		public const string ENVIRONMENT_VARIABLE_AWS_IGNORE_CONFIGURED_ENDPOINT_URLS = "AWS_IGNORE_CONFIGURED_ENDPOINT_URLS";

		public const string ENVIRONMENT_VARIABLE_AWS_DISABLE_REQUEST_COMPRESSION = "AWS_DISABLE_REQUEST_COMPRESSION";

		public const string ENVIRONMENT_VARIABLE_AWS_REQUEST_MIN_COMPRESSION_SIZE_BYTES = "AWS_REQUEST_MIN_COMPRESSION_SIZE_BYTES";

		public const string ENVIRONMENT_VARIABLE_AWS_SDK_UA_APP_ID = "AWS_SDK_UA_APP_ID";

		public const string ENVIRONMENT_VARAIBLE_AWS_ACCOUNT_ID_ENDPOINT_MODE = "AWS_ACCOUNT_ID_ENDPOINT_MODE";

		public const string ENVIRONMENT_VARIABLE_AWS_REQUEST_CHECKSUM_CALCULATION = "AWS_REQUEST_CHECKSUM_CALCULATION";

		public const string ENVIRONMENT_VARIABLE_AWS_RESPONSE_CHECKSUM_VALIDATION = "AWS_RESPONSE_CHECKSUM_VALIDATION";

		public const int AWS_SDK_UA_APP_ID_MAX_LENGTH = 50;

		public EnvironmentVariableInternalConfiguration()
		{
			base.EndpointDiscoveryEnabled = GetEnvironmentVariable<bool>("AWS_ENABLE_ENDPOINT_DISCOVERY");
			base.MaxAttempts = GetEnvironmentVariable<int>("AWS_MAX_ATTEMPTS");
			base.RetryMode = GetEnvironmentVariable<RequestRetryMode>("AWS_RETRY_MODE");
			base.EC2MetadataServiceEndpoint = GetEC2MetadataEndpointEnvironmentVariable();
			base.EC2MetadataServiceEndpointMode = GetEnvironmentVariable<EC2MetadataServiceEndpointMode>("AWS_EC2_METADATA_SERVICE_ENDPOINT_MODE");
			base.UseDualstackEndpoint = GetEnvironmentVariable<bool>("AWS_USE_DUALSTACK_ENDPOINT");
			base.UseFIPSEndpoint = GetEnvironmentVariable<bool>("AWS_USE_FIPS_ENDPOINT");
			base.IgnoreConfiguredEndpointUrls = GetEnvironmentVariable("AWS_IGNORE_CONFIGURED_ENDPOINT_URLS", defaultValue: false);
			base.DisableRequestCompression = GetEnvironmentVariable<bool>("AWS_DISABLE_REQUEST_COMPRESSION");
			base.RequestMinCompressionSizeBytes = GetEnvironmentVariable<long>("AWS_REQUEST_MIN_COMPRESSION_SIZE_BYTES");
			base.AccountIdEndpointMode = GetEnvironmentVariable<AccountIdEndpointMode>("AWS_ACCOUNT_ID_ENDPOINT_MODE");
			base.RequestChecksumCalculation = GetEnvironmentVariable<RequestChecksumCalculation>("AWS_REQUEST_CHECKSUM_CALCULATION");
			base.ResponseChecksumValidation = GetEnvironmentVariable<ResponseChecksumValidation>("AWS_RESPONSE_CHECKSUM_VALIDATION");
			base.ClientAppId = GetClientAppIdEnvironmentVariable();
		}

		private bool GetEnvironmentVariable(string name, bool defaultValue)
		{
			if (!TryGetEnvironmentVariable(name, out var value))
			{
				return defaultValue;
			}
			try
			{
				return bool.Parse(value);
			}
			catch (Exception ex)
			{
				_logger.Error(ex, ex.Message);
				throw new FormatException(ex.Message, ex.InnerException);
			}
		}

		private bool TryGetEnvironmentVariable(string environmentVariableName, out string value)
		{
			value = Environment.GetEnvironmentVariable(environmentVariableName);
			if (string.IsNullOrEmpty(value))
			{
				_logger.DebugFormat("The environment variable " + environmentVariableName + " was not set with a value.");
				value = null;
				return false;
			}
			return true;
		}

		private T? GetEnvironmentVariable<T>(string name) where T : struct
		{
			if (!TryGetEnvironmentVariable(name, out var value))
			{
				return null;
			}
			try
			{
				object obj;
				if (typeof(T) == typeof(bool))
				{
					obj = bool.Parse(value);
				}
				else if (typeof(T) == typeof(int))
				{
					obj = int.Parse(value);
				}
				else if (typeof(T) == typeof(long))
				{
					obj = long.Parse(value);
				}
				else if (typeof(T).IsEnum)
				{
					obj = Enum.Parse(typeof(T), value, ignoreCase: true);
				}
				else
				{
					if (!(typeof(T) == typeof(string)))
					{
						throw new InvalidOperationException($"Unable to convert type {typeof(T?)} for environment variable {name}.");
					}
					obj = value.ToString();
				}
				return (T?)obj;
			}
			catch (InvalidOperationException)
			{
				throw;
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "The environment variable " + name + " was set with value " + value + ", but it could not be parsed as a valid value.");
			}
			return null;
		}

		private string GetEC2MetadataEndpointEnvironmentVariable()
		{
			if (!TryGetEnvironmentVariable("AWS_EC2_METADATA_SERVICE_ENDPOINT", out var value))
			{
				return null;
			}
			if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
			{
				throw new AmazonClientException("The environment variable AWS_EC2_METADATA_SERVICE_ENDPOINT was set with value " + value + ", but it could not be parsed as a well-formed Uri.");
			}
			return value;
		}

		private string GetClientAppIdEnvironmentVariable()
		{
			if (!TryGetEnvironmentVariable("AWS_SDK_UA_APP_ID", out var value))
			{
				return null;
			}
			if (value != null && value.Length > 50)
			{
				Logger.GetLogger(typeof(InternalConfiguration)).InfoFormat("Warning: Client app id exceeds recommended maximum length of {0} characters: \"{1}\"", 50, value);
			}
			return value;
		}
	}
}
