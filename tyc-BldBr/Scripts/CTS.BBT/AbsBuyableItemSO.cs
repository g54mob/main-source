using CTS.BBT.TechTree;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Serialization;

public abstract class AbsBuyableItemSO : AbsLockableItemSO
{
	[FormerlySerializedAs("LocalizationFurnitureNameKey")]
	[SerializeField]
	[BoxGroup("Common")]
	public LocalizedString LocalizationItemSONameKey;

	[FormerlySerializedAs("LocalizationFurnitureDescKey")]
	[SerializeField]
	[BoxGroup("Common")]
	public LocalizedString LocalizationItemSODescKey;

	[SerializeField]
	[BoxGroup("Common")]
	public TechTreeTechnologySO TechTreeTechnologyRequiered;

	[field: SerializeField]
	[field: BoxGroup("Common")]
	[field: ShowAssetPreview(64, 64)]
	public Sprite Icon { get; protected set; }

	[field: SerializeField]
	[field: BoxGroup("Common")]
	[field: MinValue(0)]
	public int PurchasePrice { get; protected set; }

	[field: SerializeField]
	public string Name { get; set; } = "Name";

	[field: SerializeField]
	public string Description { get; set; } = "Description";
}
