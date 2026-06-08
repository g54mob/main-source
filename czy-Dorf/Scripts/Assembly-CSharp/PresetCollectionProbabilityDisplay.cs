using TMPro;
using UnityEngine;

public class PresetCollectionProbabilityDisplay : MonoBehaviour
{
	[SerializeField]
	private TilePreset[] tilePresets;

	[SerializeField]
	private TextMeshPro label;

	public void UpdateProbability(TileGenConfiguration configuration)
	{
		float num = 0f;
		TilePreset[] array = tilePresets;
		foreach (TilePreset referencePreset in array)
		{
			TilePresetConfiguration tilePresetConfiguration = configuration.GetTilePresetConfiguration(referencePreset);
			num += tilePresetConfiguration.tilePresetProbability * 100f;
		}
		label.text = num.ToString("0.00") + "%";
	}
}
