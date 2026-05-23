using UnityEngine;

public class Mill_Improvement_Scarecrows : MonoBehaviour
{
	[SerializeField]
	private BuildSlot buildSlot;

	public Mesh lvl2Mesh;

	public Mesh lvl3Mesh;

	private void OnEnable()
	{
		buildSlot.upgrades[1].upgradeBranches[0].replacementMesh = lvl2Mesh;
		buildSlot.upgrades[2].upgradeBranches[0].replacementMesh = lvl3Mesh;
		foreach (BuildSlot item in buildSlot.BuiltSlotsThatRelyOnThisBuilding)
		{
			Scarecrow[] components = item.GetComponents<Scarecrow>();
			foreach (Scarecrow scarecrow in components)
			{
				scarecrow.scareCrow.SetActive(value: true);
				item.Upgrades[0].upgradeBranches[0].objectsToActivate.Add(scarecrow.scareCrow);
			}
		}
	}
}
