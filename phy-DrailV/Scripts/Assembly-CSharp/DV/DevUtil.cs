using System;

namespace DV
{
	public class DevUtil
	{
		public const string DEV_ENVIRONMENT_VAR = "DERAIL_VALLEY_DEV";

		public static bool IsDevMachine()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("DERAIL_VALLEY_DEV");
			if (environmentVariable != null)
			{
				return environmentVariable != "";
			}
			return false;
		}
	}
}
