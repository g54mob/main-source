namespace Amazon.Runtime.Internal.UserAgent
{
	[ConstantClassComparer(ConstantClassComparerKind.Ordinal)]
	public class UserAgentFeatureId : ConstantClass
	{
		public static readonly UserAgentFeatureId PAGINATOR = new UserAgentFeatureId("C");

		public static readonly UserAgentFeatureId RETRY_MODE_STANDARD = new UserAgentFeatureId("E");

		public static readonly UserAgentFeatureId RETRY_MODE_ADAPTIVE = new UserAgentFeatureId("F");

		public static readonly UserAgentFeatureId S3_TRANSFER = new UserAgentFeatureId("G");

		public static readonly UserAgentFeatureId S3_EXPRESS_BUCKET = new UserAgentFeatureId("J");

		public static readonly UserAgentFeatureId GZIP_REQUEST_COMPRESSION = new UserAgentFeatureId("L");

		public static readonly UserAgentFeatureId ENDPOINT_OVERRIDE = new UserAgentFeatureId("N");

		public static readonly UserAgentFeatureId ACCOUNT_ID_MODE_PREFERRED = new UserAgentFeatureId("P");

		public static readonly UserAgentFeatureId ACCOUNT_ID_MODE_DISABLED = new UserAgentFeatureId("Q");

		public static readonly UserAgentFeatureId ACCOUNT_ID_MODE_REQUIRED = new UserAgentFeatureId("R");

		public static readonly UserAgentFeatureId SIGV4A_SIGNING = new UserAgentFeatureId("S");

		public static readonly UserAgentFeatureId RESOLVED_ACCOUNT_ID = new UserAgentFeatureId("T");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_REQ_CRC32 = new UserAgentFeatureId("U");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_REQ_CRC32C = new UserAgentFeatureId("V");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_REQ_CRC64 = new UserAgentFeatureId("W");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_REQ_SHA1 = new UserAgentFeatureId("X");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_REQ_SHA256 = new UserAgentFeatureId("Y");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_REQ_WHEN_SUPPORTED = new UserAgentFeatureId("Z");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_REQ_WHEN_REQUIRED = new UserAgentFeatureId("a");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_RES_WHEN_SUPPORTED = new UserAgentFeatureId("b");

		public static readonly UserAgentFeatureId FLEXIBLE_CHECKSUMS_RES_WHEN_REQUIRED = new UserAgentFeatureId("c");

		public static readonly UserAgentFeatureId DDB_MAPPER = new UserAgentFeatureId("d");

		public static readonly UserAgentFeatureId CREDENTIALS_CODE = new UserAgentFeatureId("e");

		public static readonly UserAgentFeatureId CREDENTIALS_ENV_VARS = new UserAgentFeatureId("g");

		public static readonly UserAgentFeatureId CREDENTIALS_ENV_VARS_STS_WEB_ID_TOKEN = new UserAgentFeatureId("h");

		public static readonly UserAgentFeatureId CREDENTIALS_STS_ASSUME_ROLE = new UserAgentFeatureId("i");

		public static readonly UserAgentFeatureId CREDENTIALS_STS_ASSUME_ROLE_WEB_ID = new UserAgentFeatureId("k");

		public static readonly UserAgentFeatureId CREDENTIALS_STS_ASSUME_ROLE_SAML = new UserAgentFeatureId("j");

		public static readonly UserAgentFeatureId CREDENTIALS_STS_SESSION_TOKEN = new UserAgentFeatureId("m");

		public static readonly UserAgentFeatureId CREDENTIALS_PROFILE = new UserAgentFeatureId("n");

		public static readonly UserAgentFeatureId CREDENTIALS_PROFILE_SOURCE_PROFILE = new UserAgentFeatureId("o");

		public static readonly UserAgentFeatureId CREDENTIALS_PROFILE_NAMED_PROVIDER = new UserAgentFeatureId("p");

		public static readonly UserAgentFeatureId CREDENTIALS_PROFILE_STS_WEB_ID_TOKEN = new UserAgentFeatureId("q");

		public static readonly UserAgentFeatureId CREDENTIALS_PROFILE_SSO = new UserAgentFeatureId("r");

		public static readonly UserAgentFeatureId CREDENTIALS_SSO = new UserAgentFeatureId("s");

		public static readonly UserAgentFeatureId CREDENTIALS_PROFILE_SSO_LEGACY = new UserAgentFeatureId("t");

		public static readonly UserAgentFeatureId CREDENTIALS_SSO_LEGACY = new UserAgentFeatureId("u");

		public static readonly UserAgentFeatureId CREDENTIALS_PROFILE_PROCESS = new UserAgentFeatureId("v");

		public static readonly UserAgentFeatureId CREDENTIALS_PROCESS = new UserAgentFeatureId("w");

		public static readonly UserAgentFeatureId CREDENTIALS_AWS_SDK_STORE = new UserAgentFeatureId("y");

		public static readonly UserAgentFeatureId CREDENTIALS_HTTP = new UserAgentFeatureId("z");

		public static readonly UserAgentFeatureId CREDENTIALS_IMDS = new UserAgentFeatureId("0");

		public static readonly UserAgentFeatureId SSO_LOGIN_DEVICE = new UserAgentFeatureId("1");

		public static readonly UserAgentFeatureId SSO_LOGIN_AUTH = new UserAgentFeatureId("2");

		public static readonly UserAgentFeatureId OBSERVABILITY_TRACING = new UserAgentFeatureId("4");

		public static readonly UserAgentFeatureId OBSERVABILITY_METRICS = new UserAgentFeatureId("5");

		public static readonly UserAgentFeatureId OBSERVABILITY_OTEL_TRACING = new UserAgentFeatureId("6");

		public static readonly UserAgentFeatureId OBSERVABILITY_OTEL_METRICS = new UserAgentFeatureId("7");

		public UserAgentFeatureId(string value)
			: base(value)
		{
		}

		public static UserAgentFeatureId FindValue(string value)
		{
			return ConstantClass.FindValue<UserAgentFeatureId>(value);
		}

		public static implicit operator UserAgentFeatureId(string value)
		{
			return FindValue(value);
		}
	}
}
