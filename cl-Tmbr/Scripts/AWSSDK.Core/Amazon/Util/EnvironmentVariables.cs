namespace Amazon.Util
{
	public abstract class EnvironmentVariables
	{
		public const string AWS_LAMBDA_FUNCTION_NAME = "AWS_LAMBDA_FUNCTION_NAME";

		public const string _X_AMZN_TRACE_ID = "_X_AMZN_TRACE_ID";

		public const string SERVICE_SPECIFIC_ENDPOINT_ENVIRONMENT_VARIABLE_PREFIX = "AWS_ENDPOINT_URL_";

		public const string GLOBAL_ENDPOINT_ENVIRONMENT_VARIABLE = "AWS_ENDPOINT_URL";
	}
}
