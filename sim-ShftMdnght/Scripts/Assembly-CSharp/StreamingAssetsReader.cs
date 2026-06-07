using System;
using System.Collections;
using System.IO;

public static class StreamingAssetsReader
{
	public static bool TryReadTextSync(string path, out string text)
	{
		text = string.Empty;
		if (!File.Exists(path))
		{
			return false;
		}
		text = File.ReadAllText(path);
		return true;
	}

	public static IEnumerator ReadTextAsync(string path, Action<bool, string> onDone)
	{
		if (!File.Exists(path))
		{
			onDone?.Invoke(arg1: false, string.Empty);
		}
		else
		{
			onDone?.Invoke(arg1: true, File.ReadAllText(path));
		}
		yield break;
	}
}
