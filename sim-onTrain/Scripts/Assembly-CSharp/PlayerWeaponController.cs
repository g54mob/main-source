using System.Collections.Generic;
using System.Runtime.InteropServices;
using HQFPSTemplate;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlayerWeaponController : NetworkBehaviour
{
	private PlayerLeftHandIKController player;

	private PlayerWeaponVisuals visuals;

	[SyncVar(hook = "OnCurrentWeaponChanged")]
	private int currentWeaponIndex;

	private EastupWeapon currentWeapon;

	[SerializeField]
	private Transform gunPoint;

	[SerializeField]
	private Transform weaponHolder;

	[Header("Inventory")]
	[SerializeField]
	private int maxSlots = 2;

	public List<EastupWeapon> weaponSlots;

	private Animator animator;

	private NetworkAnimator networkAnim;

	public NetworkAnimator NetworkAnim
	{
		get
		{
			if (!(networkAnim == null))
			{
				return networkAnim;
			}
			return GetComponent<NetworkAnimator>();
		}
	}

	public int NetworkcurrentWeaponIndex
	{
		get
		{
			return currentWeaponIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentWeaponIndex, 1uL, OnCurrentWeaponChanged);
		}
	}

	private void Start()
	{
		animator = GetComponentInChildren<Animator>();
		player = GetComponent<PlayerLeftHandIKController>();
		visuals = GetComponent<PlayerWeaponVisuals>();
		if (currentWeaponIndex >= 0 && currentWeaponIndex < weaponSlots.Count)
		{
			currentWeapon = weaponSlots[currentWeaponIndex];
		}
		else
		{
			UnEquip();
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!base.isLocalPlayer && currentWeaponIndex >= 0 && currentWeaponIndex < weaponSlots.Count)
		{
			currentWeapon = weaponSlots[currentWeaponIndex];
			Debug.Log($"OnStartClient: Set current weapon to index {currentWeaponIndex}, type: {currentWeapon?.weaponType}");
		}
	}

	private void OnCurrentWeaponChanged(int oldIndex, int newIndex)
	{
		if (base.isLocalPlayer || newIndex < 0 || newIndex >= weaponSlots.Count)
		{
			return;
		}
		currentWeapon = weaponSlots[newIndex];
		if (!(visuals != null))
		{
			return;
		}
		visuals.SwitchOffWeaponModels();
		if (newIndex > 0 && currentWeapon.weaponData != null)
		{
			WeaponModel weaponModelByType = visuals.GetWeaponModelByType(currentWeapon.weaponType);
			if (weaponModelByType != null)
			{
				weaponModelByType.gameObject.SetActive(value: true);
			}
		}
		if (!HasOnlyOneWeapon())
		{
			visuals.SwitchOnBackupWeaponModel();
		}
	}

	private void Update()
	{
	}

	public void EquipWeapon(CollectableItemData data)
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		int num = 0;
		foreach (EastupWeapon weaponSlot in weaponSlots)
		{
			if (weaponSlot.weaponData == data)
			{
				CmdEquipWeapon(num);
				break;
			}
			num++;
		}
	}

	[Command]
	private void CmdEquipWeapon(int weaponIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(weaponIndex);
		SendCommandInternal("System.Void PlayerWeaponController::CmdEquipWeapon(System.Int32)", -1084611615, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcEquipWeapon(int weaponIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(weaponIndex);
		SendRPCInternal("System.Void PlayerWeaponController::RpcEquipWeapon(System.Int32)", -2051837546, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PickupWeapon(EastupWeapon newWeapon)
	{
		if (weaponSlots.Count < maxSlots)
		{
			weaponSlots.Add(newWeapon);
			player.weaponVisuals.SwitchOnBackupWeaponModel();
		}
	}

	private void DropWeapon()
	{
	}

	public void UnEquip()
	{
		if (base.isLocalPlayer)
		{
			CmdEquipWeapon(0);
		}
		else
		{
			currentWeapon = weaponSlots[0];
		}
	}

	public void Shoot()
	{
		NetworkAnim.SetTrigger("Fire");
	}

	public void Reload()
	{
		player.weaponVisuals.PlayerReloadAnimation();
	}

	public bool HasOnlyOneWeapon()
	{
		return weaponSlots.Count <= 1;
	}

	public EastupWeapon CurrentWeapon()
	{
		return currentWeapon;
	}

	public EastupWeapon BackupWeapon()
	{
		foreach (EastupWeapon weaponSlot in weaponSlots)
		{
			if (weaponSlot != currentWeapon)
			{
				return weaponSlot;
			}
		}
		return null;
	}

	[Command]
	public void CmdFireArrow(Vector3 spawnPosition, Vector3 direction, string bulletItemName, float launchSpeed)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(spawnPosition);
		writer.WriteVector3(direction);
		writer.WriteString(bulletItemName);
		writer.WriteFloat(launchSpeed);
		SendCommandInternal("System.Void PlayerWeaponController::CmdFireArrow(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Single)", 367751446, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public Transform GunPoint()
	{
		return gunPoint;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdEquipWeapon__Int32(int weaponIndex)
	{
		if (weaponIndex >= 0 && weaponIndex < weaponSlots.Count)
		{
			NetworkcurrentWeaponIndex = weaponIndex;
			currentWeapon = weaponSlots[weaponIndex];
			RpcEquipWeapon(weaponIndex);
		}
	}

	protected static void InvokeUserCode_CmdEquipWeapon__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdEquipWeapon called on client.");
		}
		else
		{
			((PlayerWeaponController)obj).UserCode_CmdEquipWeapon__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_RpcEquipWeapon__Int32(int weaponIndex)
	{
		if (weaponIndex >= 0 && weaponIndex < weaponSlots.Count)
		{
			currentWeapon = weaponSlots[weaponIndex];
			visuals.PlayWeaponEquipAnimation(weaponIndex);
		}
	}

	protected static void InvokeUserCode_RpcEquipWeapon__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcEquipWeapon called on server.");
		}
		else
		{
			((PlayerWeaponController)obj).UserCode_RpcEquipWeapon__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdFireArrow__Vector3__Vector3__String__Single(Vector3 spawnPosition, Vector3 direction, string bulletItemName, float launchSpeed)
	{
		CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(bulletItemName);
		if (itemFromName == null || itemFromName.itemPrefab == null)
		{
			Debug.LogError("Arrow item veya prefab bulunamadı: " + bulletItemName);
			return;
		}
		Quaternion rotation = Quaternion.LookRotation(direction);
		GameObject obj = Object.Instantiate(itemFromName.itemPrefab, spawnPosition, rotation);
		obj.layer = LayerMask.NameToLayer("Bullet");
		NetworkServer.Spawn(obj);
		Entity entity = GetComponentInParent<Entity>();
		if (entity == null)
		{
			entity = GetComponent<Entity>();
		}
		ShaftedProjectile component = obj.GetComponent<ShaftedProjectile>();
		if (component != null)
		{
			component.Launch(entity);
		}
		Rigidbody component2 = obj.GetComponent<Rigidbody>();
		if (component2 != null)
		{
			component2.isKinematic = false;
			component2.velocity = direction * launchSpeed;
		}
		if (component != null)
		{
			component.TryCloseRangeHit(spawnPosition, direction.normalized, 1f, 1.5f);
		}
		ArrowNetworkSync component3 = obj.GetComponent<ArrowNetworkSync>();
		if (component3 != null && !component3.IsStopped)
		{
			float gravityMult = ((component != null) ? component.GravityMultiplier : 1f);
			component3.RpcLaunchArrow(spawnPosition, direction, launchSpeed, gravityMult, NetworkTime.time);
		}
	}

	protected static void InvokeUserCode_CmdFireArrow__Vector3__Vector3__String__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdFireArrow called on client.");
		}
		else
		{
			((PlayerWeaponController)obj).UserCode_CmdFireArrow__Vector3__Vector3__String__Single(reader.ReadVector3(), reader.ReadVector3(), reader.ReadString(), reader.ReadFloat());
		}
	}

	static PlayerWeaponController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponController), "System.Void PlayerWeaponController::CmdEquipWeapon(System.Int32)", InvokeUserCode_CmdEquipWeapon__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponController), "System.Void PlayerWeaponController::CmdFireArrow(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Single)", InvokeUserCode_CmdFireArrow__Vector3__Vector3__String__Single, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerWeaponController), "System.Void PlayerWeaponController::RpcEquipWeapon(System.Int32)", InvokeUserCode_RpcEquipWeapon__Int32);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(currentWeaponIndex);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteInt(currentWeaponIndex);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref currentWeaponIndex, OnCurrentWeaponChanged, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentWeaponIndex, OnCurrentWeaponChanged, reader.ReadInt());
		}
	}
}
