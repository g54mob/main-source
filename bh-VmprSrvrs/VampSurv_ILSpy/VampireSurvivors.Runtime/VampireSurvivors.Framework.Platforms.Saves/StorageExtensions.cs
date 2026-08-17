namespace VampireSurvivors.Framework.Platforms.Saves;

public static class StorageExtensions
{
	public static bool Succeed(StorageResult result)
	{
		return result == StorageResult.Successful;
	}
}
