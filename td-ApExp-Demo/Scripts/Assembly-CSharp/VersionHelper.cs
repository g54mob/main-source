using UnityEngine;

public static class VersionHelper
{
	public static bool CompareVersions(string currentVersion, string requiredVersion)
	{
		int[] array = StringToVersion(currentVersion);
		int[] array2 = StringToVersion(requiredVersion);
		int num = Mathf.Min(array.Length, array2.Length);
		for (int i = 0; i < num; i++)
		{
			if (array[i] != array2[i])
			{
				return array[i] > array2[i];
			}
		}
		if (array.Length == array2.Length)
		{
			return true;
		}
		return array.Length > array2.Length;
	}

	public static int[] StringToVersion(string versionString)
	{
		string[] array = versionString.Split('.');
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = int.Parse(array[i]);
		}
		return array2;
	}
}
