public class Admin
{
	private static string data;

	public static bool hasInitialized { get; private set; }

	private static void Initialize()
	{
	}

	public static string GetProperty(string key, string defaultValue = null)
	{
		Initialize();
		if (data != null)
		{
			return SlimJson.Parse(data, key);
		}
		return defaultValue;
	}
}
