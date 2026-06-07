using UnityEngine;

[CreateAssetMenu(fileName = "GE_unlockBuildingData_default", menuName = "Tower Factory/GameplayEffect/Player/UnlockBuilding")]
public class GE_UnlockBuildingData : GameplayEffectData
{
	[Header("Unlock building")]
	[SerializeField]
	private GameplayObjectData[] buildingsToUnlock;

	public GameplayObjectData[] BuildingsToUnlock => buildingsToUnlock;

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_UnlockBuilding();
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}
}
