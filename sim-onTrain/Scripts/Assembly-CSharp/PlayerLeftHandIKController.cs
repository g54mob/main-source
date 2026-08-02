using UnityEngine;

public class PlayerLeftHandIKController : MonoBehaviour
{
	public PlayerWeaponController weapon { get; private set; }

	public PlayerWeaponVisuals weaponVisuals { get; private set; }

	private void Awake()
	{
		weapon = GetComponent<PlayerWeaponController>();
		weaponVisuals = GetComponent<PlayerWeaponVisuals>();
	}
}
