using UnityEngine;

[CreateAssetMenu(fileName = "GE_giveResources_default", menuName = "Tower Factory/GameplayEffect/Player/GiveResources")]
public class GE_GiveResourcesData : GameplayEffectData
{
	[Header("Give resource")]
	[SerializeField]
	private Cost[] resourcesToGive;

	public Cost[] ResourcesToGive => resourcesToGive;

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_GiveResources();
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowMaxStacksInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}
}
