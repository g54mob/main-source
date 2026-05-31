using System;
using UnityEngine;

public class PersistentFilePath : MonoBehaviour
{
	public static PersistentFilePath ins;

	public string currentFilePath;

	public bool closeMainMenuOnReload;

	private void Awake()
	{
		if (ins != null && ins != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		ins = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	public void SetCurrentFilePathToNowUTC(bool vertical, int farmType, int crossoverFarm)
	{
		DateTime utcNow = DateTime.UtcNow;
		string text = ((crossoverFarm == 0) ? ((!vertical) ? ("H" + farmType) : ("V" + farmType)) : ((!vertical) ? ("HS" + crossoverFarm) : ("VS" + crossoverFarm)));
		string text2 = text + $"-{utcNow.Year}-{utcNow.Month}-{utcNow.Day}-{utcNow.Hour}-{utcNow.Minute}-{utcNow.Second}.txt";
		currentFilePath = text2;
	}
}
