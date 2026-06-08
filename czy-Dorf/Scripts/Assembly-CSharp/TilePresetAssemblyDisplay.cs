using TMPro;
using UnityEngine;

public class TilePresetAssemblyDisplay : MonoBehaviour
{
	[SerializeField]
	private TileGenConfiguration configuration;

	private void CalculateTilePresetProbabilities()
	{
		if (configuration != null)
		{
			SetPresetTexts();
		}
		else
		{
			SetPresetTexts("");
		}
	}

	private void SetPresetTexts(string targetLabel)
	{
		TilePreset[] array = Object.FindObjectsOfType<TilePreset>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponentInChildren<TextMeshPro>().text = targetLabel;
		}
	}

	private void SetPresetTexts()
	{
		TilePreset[] array = Object.FindObjectsOfType<TilePreset>();
		foreach (TilePreset tilePreset in array)
		{
			TilePresetConfiguration tilePresetConfiguration = configuration.GetTilePresetConfiguration(tilePreset);
			if (tilePresetConfiguration == null)
			{
				Debug.Log($"no preset configuration found for {tilePreset}");
			}
			TextMeshPro componentInChildren = tilePreset.GetComponentInChildren<TextMeshPro>();
			if (componentInChildren == null)
			{
				Debug.LogError($"{tilePreset} has no textMesh");
			}
			else
			{
				componentInChildren.text = (tilePresetConfiguration.tilePresetProbability * 100f).ToString("0.00") + "%";
			}
		}
		PresetCollectionProbabilityDisplay[] array2 = Object.FindObjectsOfType<PresetCollectionProbabilityDisplay>();
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].UpdateProbability(configuration);
		}
	}
}
