using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutpostPerk : MonoBehaviour
{
	[SerializeField]
	private BuildSlot buildSlot;

	[SerializeField]
	private int numberOfTowersToActivate = 2;

	private void OnEnable()
	{
		if (!(PerkManager.instance == null) && PerkManager.instance.OutpostEquipped)
		{
			StartCoroutine(BuildFreeTowers());
		}
	}

	private IEnumerator BuildFreeTowers()
	{
		yield return null;
		yield return null;
		yield return null;
		List<BuildSlot> builtSlotsThatRelyOnThisBuilding = buildSlot.BuiltSlotsThatRelyOnThisBuilding;
		List<BuildSlot> towerSlots = new List<BuildSlot>();
		foreach (BuildSlot item in builtSlotsThatRelyOnThisBuilding)
		{
			if ((bool)item && item.name.Contains("Tower"))
			{
				towerSlots.Add(item);
			}
		}
		towerSlots = towerSlots.OrderByDescending((BuildSlot slot) => Vector3.Distance(base.transform.position, slot.transform.position)).ToList();
		for (int i = 0; i < Mathf.Min(numberOfTowersToActivate, towerSlots.Count); i++)
		{
			if (towerSlots[i].Level == 0)
			{
				towerSlots[i].ActivateIgrnoringActivatorLevel();
				yield return null;
				towerSlots[i].TryToBuildOrUpgradeAndPay(null, _presentChoice: false);
				yield return null;
			}
		}
	}
}
