using System.Collections.Generic;
using UnityEngine;

public class Folders : MonoBehaviour
{
	public static Dictionary<string, string> folder = new Dictionary<string, string>();

	private void Awake()
	{
		SetFolders();
	}

	private void SetFolders()
	{
		folder["cache"] = Application.persistentDataPath + "/cache";
	}

	public static string GetFolder(string _id)
	{
		return folder[_id];
	}
}
