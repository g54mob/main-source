using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlexibleColorPicker))]
public class FCP_Persistence : MonoBehaviour
{
	public enum SaveStrategy
	{
		SessionOnly = 0,
		File = 1,
		PlayerPrefs = 2
	}

	public string saveName;

	public SaveStrategy saveStrategy;

	private FlexibleColorPicker fcp;

	private static Dictionary<string, Color> savedColors;

	private static string saveFilePath;

	private static bool saveFileLoaded;

	private static bool saveFileOutdated;

	private void Awake()
	{
	}

	private void InitStatic()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void LoadDataFile()
	{
	}

	private void SaveDataFile()
	{
	}

	public void SaveColor(Color c)
	{
	}

	public bool LoadColor(out Color c)
	{
		c = default(Color);
		return false;
	}

	private static string GenerateID()
	{
		return null;
	}
}
