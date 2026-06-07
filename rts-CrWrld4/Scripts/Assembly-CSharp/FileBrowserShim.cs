using Crosstales.FB;
using UnityEngine;

public class FileBrowserShim : MonoBehaviour
{
	public static string SaveFile(string cat, string title, string defaultDirectory, string defaultName, params string[] extensions)
	{
		return null;
	}

	public static string LoadFile(string cat, string title, string defaultDirectory, params string[] extensions)
	{
		return null;
	}

	private static ExtensionFilter[] GetEFA(string[] extensions)
	{
		return null;
	}

	public static string LoadFileE(string cat, string title, string defaultDirectory, params ExtensionFilter[] extensions)
	{
		return null;
	}
}
