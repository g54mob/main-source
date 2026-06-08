using System;

namespace Amazon.Util.Internal
{
	public sealed class EnvironmentVariableRetriever : IEnvironmentVariableRetriever
	{
		public string GetEnvironmentVariable(string key)
		{
			return Environment.GetEnvironmentVariable(key);
		}
	}
}
