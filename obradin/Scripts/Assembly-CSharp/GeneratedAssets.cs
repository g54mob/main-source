using System.IO;
using UnityEngine;

public class GeneratedAssets
{
	public static string ToGenPath(string nonGeneratedPath)
	{
		return nonGeneratedPath.Replace("Assets/", "Assets/Generated/");
	}

	public static T LoadResource<T>(string assetPath) where T : Object
	{
		return Resources.Load<T>(Path.GetFileNameWithoutExtension(ToGenPath(assetPath)));
	}
}
