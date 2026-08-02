using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
	private PlayerWeaponVisuals visualController;

	private PlayerWeaponController weaponController;

	private void Start()
	{
		visualController = GetComponentInParent<PlayerWeaponVisuals>();
		weaponController = GetComponentInParent<PlayerWeaponController>();
	}

	public void ReloadIsOver()
	{
		visualController.MaximizeRigWeight();
	}

	public void ReturnRig()
	{
		visualController?.MaximizeRigWeight();
		visualController.MaximizeLeftWeight();
	}

	public void WeaponGrabIsOver()
	{
		visualController.OnEquipAnimationFinished();
	}

	public void StationaryActionEnded()
	{
		visualController.OnStationaryActionEnded();
	}
}
