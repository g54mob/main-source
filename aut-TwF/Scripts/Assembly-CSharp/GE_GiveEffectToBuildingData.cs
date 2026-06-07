using UnityEngine;

[CreateAssetMenu(fileName = "GE_giveEffectToBuildingData_default", menuName = "Tower Factory/GameplayEffect/Player/GiveEffectToBuilding")]
public class GE_GiveEffectToBuildingData : GameplayEffectData
{
	[Header("Give effect to building")]
	[SerializeField]
	private bool affectAllTowers;

	[SerializeField]
	private bool affectAllBuildings;

	[SerializeField]
	private bool affectAllExtractors;

	[SerializeField]
	private bool affectAllProcessors;

	[SerializeField]
	private GameplayObjectData[] affectedBuildings;

	[SerializeField]
	private GameplayEffectData[] effectsToApply;

	[SerializeField]
	private GameplayEffectData[] effectsToRemove;

	public bool AffectAllTowers => affectAllTowers;

	public bool AffectAllBuildings => affectAllBuildings;

	public bool AffectAllExtractors => affectAllExtractors;

	public bool AffectAllProcessors => affectAllProcessors;

	public GameplayObjectData[] AffectedBuildings => affectedBuildings;

	public GameplayEffectData[] EffectsToApply => effectsToApply;

	public GameplayEffectData[] EffectsToRemove => effectsToRemove;

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_GiveEffectToBuilding();
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}

	public bool IsAffected(GameplayObjectData playerStructure)
	{
		if ((!AffectAllTowers || playerStructure.Type != EGameplayObjectType.Tower) && (!AffectAllBuildings || (playerStructure.Type != EGameplayObjectType.Building && playerStructure.Type != EGameplayObjectType.Extractor && playerStructure.Type != EGameplayObjectType.Processor)) && (!AffectAllExtractors || playerStructure.Type != EGameplayObjectType.Extractor) && (!AffectAllProcessors || playerStructure.Type != EGameplayObjectType.Processor))
		{
			return AffectedBuildings.Contains(playerStructure);
		}
		return true;
	}
}
