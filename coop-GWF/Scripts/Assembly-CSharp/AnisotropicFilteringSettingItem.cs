using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Setting Item/Anisotropic Filtering", fileName = "AnisotropicFilteringSetting")]
public class AnisotropicFilteringSettingItem : DropdownSettingItem
{
	private static readonly List<string> DefaultOptions = new List<string> { "Off", "2x", "4x", "8x", "16x" };

	private void OnEnable()
	{
		if (string.IsNullOrWhiteSpace(key))
		{
			key = "anisotropicfiltering";
		}
		if (string.IsNullOrWhiteSpace(label))
		{
			label = "Anisotropic Filtering";
		}
		if (options == null || options.Count == 0)
		{
			options = new List<string>(DefaultOptions);
		}
		index = Mathf.Clamp(index, 0, Mathf.Max(0, options.Count - 1));
	}
}
