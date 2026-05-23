using System.IO;
using UnityEngine;

public class Version
{
	public int major;

	public int minor;

	public int build;

	private const string kRuntimeFilename = "Version";

	private const string kEditorFilename = "Assets/Resources/Version.txt";

	private string fileContents
	{
		get
		{
			try
			{
				if (Application.isEditor)
				{
					return File.ReadAllText("Assets/Resources/Version.txt");
				}
				return Resources.Load<TextAsset>("Version").text;
			}
			catch
			{
				return "0.0.0";
			}
		}
	}

	public Version()
	{
		string[] array = fileContents.Split('.');
		major = int.Parse(array[0]);
		minor = int.Parse(array[1]);
		build = int.Parse(array[2]);
	}

	public override string ToString()
	{
		return major + "." + minor + "." + build;
	}
}
