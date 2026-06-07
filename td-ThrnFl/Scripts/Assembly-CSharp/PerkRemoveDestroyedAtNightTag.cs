using UnityEngine;

public class PerkRemoveDestroyedAtNightTag : MonoBehaviour
{
	[SerializeField]
	private Equippable perkRequirement;

	[SerializeField]
	private BuildingInteractor buildingInteractor;

	private void Start()
	{
		if (PerkManager.IsEquipped(perkRequirement))
		{
			buildingInteractor.SetNeverDenyHarvest(_neverDenyHarvest: true);
		}
		Object.Destroy(this);
	}
}
