namespace Amazon.Runtime.Internal.Util
{
	public static class TransformServiceId
	{
		public static string TransformServiceIdToConfigVariable(string serviceId)
		{
			return serviceId.ToLower().Replace(' ', '_');
		}

		public static string TransformServiceIdToEnvVariable(string serviceId)
		{
			string text = serviceId.ToUpper().Replace(' ', '_');
			return "AWS_ENDPOINT_URL_" + text;
		}
	}
}
