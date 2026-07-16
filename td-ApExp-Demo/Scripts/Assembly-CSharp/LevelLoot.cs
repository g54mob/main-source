using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "LevelLoot")]
public class LevelLoot : ScriptableObject
{
	[field: SerializeField]
	public LootType LootType { get; private set; }

	[field: SerializeField]
	public Sprite MapNodeIcon { get; private set; }

	[field: SerializeField]
	public LocalizedString TooltipKey { get; private set; }

	[field: SerializeField]
	public AnimationCurve WeightCurve { get; private set; }

	public string TooltipString => TooltipKey.GetLocalizedString();
}
