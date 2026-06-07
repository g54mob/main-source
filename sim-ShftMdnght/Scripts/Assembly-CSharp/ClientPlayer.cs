using Mirror;
using UnityEngine;

public class ClientPlayer : NetworkBehaviour
{
	public PlayerManager playerMan;

	public InventoryManager inventoryMan;

	public FPSController fpsScript;

	public TeleportPlayer teleportPlayer;

	public GameObject camHolder;

	public GameObject canvas;

	public WeaponSway weaponSway;

	public CameraShake camShake;

	public static ClientPlayer Instance { get; private set; }

	private void Start()
	{
		if (!base.isLocalPlayer)
		{
			Object.Destroy(weaponSway);
			Object.Destroy(canvas);
			Object.Destroy(camHolder);
		}
		else
		{
			Instance = this;
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
