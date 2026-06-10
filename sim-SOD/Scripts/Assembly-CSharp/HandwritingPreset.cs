using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "handwriting_data", menuName = "Database/Handwriting Preset")]
public class HandwritingPreset : SoCustomComparison
{
	[Header("Font")]
	public TMP_FontAsset fontAsset;

	[Header("Suitability")]
	public float baseChance;

	[InfoBox("If enabled: The below traits will be used to calculate the likihood of this being chosen vs others.", EInfoBoxType.Normal)]
	[ReorderableList]
	public List<CharacterTrait.TraitPickRule> characterTraits;
}
