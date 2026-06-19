using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Building_", menuName = "Project/Building")]
public class BuildingAsset : ScriptableObject, ICheckpoint
{
	[SerializeField]
	public LocalizedString Title;

	[SerializeField]
	public LocalizedString Description;

	public bool OneOfAType;

	public bool IsPipelined;

	[field: SerializeField]
	public string ID { get; private set; }

	[field: SerializeField]
	public List<CostStack> BuildingCosts { get; private set; }

	[field: SerializeField]
	public List<CostStack> UnlockCosts { get; private set; }

	[field: SerializeField]
	public Sprite Icon { get; private set; }

	public bool AlreadyUnlocked => false;

	public string CheckpointID => null;
}
