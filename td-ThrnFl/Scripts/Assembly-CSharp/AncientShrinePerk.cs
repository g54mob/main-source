using UnityEngine;

public class AncientShrinePerk : MonoBehaviour
{
	[SerializeField]
	private Equippable requiredPerk;

	[SerializeField]
	private BuildSlot buildSlot;

	[SerializeField]
	private Shrine shrine;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float xpRequirementMulti = 2f;

	private void Start()
	{
		if (PerkManager.IsEquipped(requiredPerk))
		{
			if (buildSlot.Level == 0)
			{
				buildSlot.ExecuteBuildOrUpgrade(PlayerInteraction.instance, _presentChoice: false);
			}
			shrine.AdjustRequiredXp(xpRequirementMulti);
		}
	}
}
