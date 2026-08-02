using HQFPSTemplate.Equipment;
using UnityEngine;

public class BuildingHammerController : MonoBehaviour
{
	public MeleeWeapon meleeWeapon;

	public float placeCastDelay = 0.15f;

	public bool itCanBuild;

	public bool canPlaceItem;

	private void OnEnable()
	{
		if (meleeWeapon != null)
		{
			meleeWeapon.isBlockedToUse = true;
			meleeWeapon.skipHitSound = true;
		}
	}

	private void OnDisable()
	{
		if (meleeWeapon != null)
		{
			meleeWeapon.skipHitSound = false;
		}
	}

	public void ChangeBuildState(bool canBuild)
	{
		itCanBuild = canBuild;
		UpdateHammerBlockState();
	}

	public void SetCanPlaceItem(bool canPlace)
	{
		canPlaceItem = canPlace;
		UpdateHammerBlockState();
	}

	private void UpdateHammerBlockState()
	{
		if (meleeWeapon != null)
		{
			bool isBlockedToUse = !itCanBuild || !canPlaceItem;
			meleeWeapon.isBlockedToUse = isBlockedToUse;
		}
	}
}
