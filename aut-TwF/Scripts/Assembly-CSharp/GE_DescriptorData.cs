using UnityEngine;

[CreateAssetMenu(fileName = "GE_descriptorData_default", menuName = "Tower Factory/GameplayEffect/Descriptor")]
public class GE_DescriptorData : GameplayEffectData
{
	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_Descriptor();
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
