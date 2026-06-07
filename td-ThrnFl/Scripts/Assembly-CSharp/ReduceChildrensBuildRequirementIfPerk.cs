using UnityEngine;

public class ReduceChildrensBuildRequirementIfPerk : MonoBehaviour
{
	[SerializeField]
	private Equippable perk;

	private void Update()
	{
		if (PerkManager.instance.CurrentlyEquipped.Contains(perk))
		{
			BuildSlot component = GetComponent<BuildSlot>();
			foreach (BuildSlot item in component.IsRootOf)
			{
				if (item.ActivatorBuilding == component)
				{
					item.ActivatorLevel = Mathf.Max(0, item.ActivatorLevel - 1);
				}
			}
		}
		Object.Destroy(this);
	}
}
