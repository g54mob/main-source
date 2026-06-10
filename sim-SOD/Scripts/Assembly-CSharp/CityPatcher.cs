using System.IO;
using NaughtyAttributes;
using UnityEngine;

public class CityPatcher : MonoBehaviour
{
	[Header("Input")]
	[InfoBox("This is written specifically to update the old city file included in the first version of the game 'charlotte heights'", EInfoBoxType.Normal)]
	public string inputCityPath;

	[Header("State")]
	private FileInfo loadCityFileInfo;

	private CitySaveData currentData;

	[Button(null, EButtonEnableMode.Always)]
	public void PatchCity()
	{
	}

	private void LoadFullCityData()
	{
	}

	private void SaveCityData()
	{
	}
}
