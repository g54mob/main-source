using UnityEngine;

public class PerkUnrestrictedUpgrading : MonoBehaviour
{
	[SerializeField]
	private Equippable requiredEquippable;

	[SerializeField]
	private BuildSlot buildSlot;

	private void Start()
	{
		if (PerkManager.IsEquipped(requiredEquippable))
		{
			buildSlot.SetRequiredRootLevelDifference(-100);
		}
		Object.Destroy(this);
	}
}
