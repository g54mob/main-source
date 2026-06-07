using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_disableTowerData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/Disable Tower")]
public class GE_DisableTowerData : GameplayEffectData
{
	[SerializeField]
	private GameObject disabledVFXPrefab;

	[SerializeField]
	private Material disabledVFXMaterial;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_disableTower_name").Entry.GetLocalizedString();

	public override string Description => new LocalizedString("GameplayEffects", "GE_disableTower_description").GetLocalizedString();

	public GameObject DisabledVFXPrefab => disabledVFXPrefab;

	public Material DisabledVFXMaterial => disabledVFXMaterial;

	private void Reset()
	{
		base.HasDuration = true;
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_DisableTower();
	}

	protected override bool ShowNameInInspector()
	{
		return false;
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}

	protected override bool ShowMaxStacksInInspector()
	{
		return false;
	}
}
