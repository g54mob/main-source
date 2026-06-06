using System.IO;

public static class PathHelper
{
	public static string ConstructPath(params string[] pathParts)
	{
		if (pathParts.Length == 0)
		{
			return string.Empty;
		}
		string text = pathParts[0];
		for (int i = 1; i < pathParts.Length; i++)
		{
			text = text + Path.DirectorySeparatorChar + pathParts[i];
		}
		return text;
	}
}
