namespace Amazon.Util.Internal
{
	public interface IEnvironmentVariableRetriever
	{
		string GetEnvironmentVariable(string key);
	}
}
