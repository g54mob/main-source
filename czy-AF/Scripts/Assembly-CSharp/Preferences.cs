using System.IO;
using HorizonBasedAmbientOcclusion;
using Kengine;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Preferences : MonoBehaviour
{
	public static PreferenceData data = new PreferenceData();

	public static string preferencesPath;

	public static PostProcessLayer postProcessLayer;

	private void Start()
	{
		postProcessLayer = GameObject.Find("cameraHighlight").GetComponent<PostProcessLayer>();
		preferencesPath = Application.persistentDataPath + "/preferences.save";
		LoadPreferences();
	}

	public static void ApplyPreferences()
	{
		Project.instance.SetRecovery(data.generalRecovery);
		Workspaces.SetWorkspace(data.visualsWorkspace);
		switch (data.visualsAntiAlias)
		{
		case 0:
			QualitySettings.antiAliasing = 8;
			postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
			break;
		case 1:
			QualitySettings.antiAliasing = 4;
			postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
			break;
		case 2:
			QualitySettings.antiAliasing = 2;
			postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
			break;
		case 3:
			QualitySettings.antiAliasing = 0;
			postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
			break;
		}
		Camera.main.GetComponent<HBAO>().enabled = data.visualsAmbientOcclusion;
		QualitySettings.shadows = (data.visualsShadows ? ShadowQuality.All : ShadowQuality.Disable);
		QualitySettings.vSyncCount = (data.visualsVSync ? 1 : 0);
		Object.FindObjectOfType<CanvasScaler>().scaleFactor = data.visualsScale;
		Grid.instance.SetOpacity(data.gridOpacity);
	}

	public static void LoadPreferences()
	{
		if (File.Exists(preferencesPath))
		{
			data = Saving.LoadObjectUncompressed<PreferenceData>(preferencesPath);
		}
		else
		{
			Cache.Clear();
			SavePreferences();
		}
		ApplyPreferences();
	}

	public static void SavePreferences()
	{
		Saving.SaveObjectUncompressed(data, preferencesPath);
		ApplyPreferences();
	}

	public static void ResetPreferences()
	{
		data = new PreferenceData();
		SavePreferences();
	}

	public static void HighQuality()
	{
		QualitySettings.antiAliasing = 8;
		postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
	}
}
