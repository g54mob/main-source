using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class ThirdPersonManager : NetworkBehaviour
{
	public Animator bodyAnim;

	public Animator legsAnim;

	public Animator armsAnim;

	public SkinnedMeshRenderer[] models;

	public MeshRenderer[] models_;

	public GameObject[] objsToTurnOffLocally;

	public GameObject[] objs;

	public Transform[] spineRots;

	public Transform camRot;

	public Animator[] gunshotAnims;

	public GameObject flashlightLight;

	public ClientPlayer clientPlayer;

	public Animator mopAnim;

	public PlayerManager playerMan;

	public SkinnedMeshRenderer shirt;

	public Material[] shirtColors;

	public DialogueInteractable moodReading;

	public GameObject stuckObj;

	public GameObject unstuckParticles;

	public AudioSource duckSqueak;

	public Transform thirdPersonGasPump;

	public ParticleSystem gasPumpParticles;

	public bool gasPumpParticlesOn;

	public GameObject[] hatObjs;

	public Material[] headMaterials;

	public SkinnedMeshRenderer headRenderer;

	public void ChangeGasPumpParticles(bool on)
	{
		if (gasPumpParticlesOn != on)
		{
			if (ClientPlayer.Instance.isServer)
			{
				ChangeGasPumpParticlesRpc(on);
			}
			else
			{
				ChangeGasPumpParticlesCmd(on);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void ChangeGasPumpParticlesCmd(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendCommandInternal("System.Void ThirdPersonManager::ChangeGasPumpParticlesCmd(System.Boolean)", -1909322759, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChangeGasPumpParticlesRpc(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendRPCInternal("System.Void ThirdPersonManager::ChangeGasPumpParticlesRpc(System.Boolean)", -629733778, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void GetStuck()
	{
		if (ClientPlayer.Instance.isServer)
		{
			GetStuckRpc();
		}
		else
		{
			GetStuckCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void GetStuckCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::GetStuckCmd()", -1972096090, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void GetStuckRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::GetStuckRpc()", 668239705, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void GetUnstuck()
	{
		if (ClientPlayer.Instance.isServer)
		{
			GetUnstuckRpc();
		}
		else
		{
			GetUnstuckCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void GetUnstuckCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::GetUnstuckCmd()", -135525343, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void GetUnstuckRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::GetUnstuckRpc()", -1797311230, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void GetStunned()
	{
		if (ClientPlayer.Instance.isServer)
		{
			GetStunnedRpc();
		}
		else
		{
			GetStunnedCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void GetStunnedCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::GetStunnedCmd()", 114719703, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void GetStunnedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::GetStunnedRpc()", 574330164, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void GetUnstunned()
	{
		if (ClientPlayer.Instance.isServer)
		{
			GetUnstunnedRpc();
		}
		else
		{
			GetUnstunnedCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void GetUnstunnedCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::GetUnstunnedCmd()", 1821999904, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void GetUnstunnedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::GetUnstunnedRpc()", -2099443689, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SqueakDuck()
	{
		if (ClientPlayer.Instance.isServer)
		{
			SqueakDuckRpc();
		}
		else
		{
			SqueakDuckCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void SqueakDuckCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::SqueakDuckCmd()", 1121170507, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SqueakDuckRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::SqueakDuckRpc()", -1955098936, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Start()
	{
		if (!base.isLocalPlayer)
		{
			playerMan.inventoryMan.thirdPersonGasPump = thirdPersonGasPump;
			base.enabled = false;
		}
		else
		{
			Invoke("SetColor", 1f);
			Invoke("SetMood", 1f);
		}
	}

	private void SetMood()
	{
		if (ClientPlayer.Instance.isServer)
		{
			SetMoodRpc(Random.Range(1, 8));
		}
		else
		{
			SetMoodCmd(Random.Range(1, 8));
		}
	}

	[Command(requiresAuthority = false)]
	public void SetMoodCmd(int x)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(x);
		SendCommandInternal("System.Void ThirdPersonManager::SetMoodCmd(System.Int32)", 1940476580, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SetMoodRpc(int x)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(x);
		SendRPCInternal("System.Void ThirdPersonManager::SetMoodRpc(System.Int32)", 976463515, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SetColor()
	{
		if (ClientPlayer.Instance.isServer)
		{
			SetColorRpc(PlayerPrefs.GetInt("ShirtColor", 1));
		}
		else
		{
			SetColorCmd(PlayerPrefs.GetInt("ShirtColor", 1));
		}
	}

	[Command(requiresAuthority = false)]
	public void SetColorCmd(int colorIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(colorIndex);
		SendCommandInternal("System.Void ThirdPersonManager::SetColorCmd(System.Int32)", -151349282, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SetColorRpc(int colorIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(colorIndex);
		SendRPCInternal("System.Void ThirdPersonManager::SetColorRpc(System.Int32)", -1502593679, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ResetAnims()
	{
		if (base.isServer)
		{
			ResetAnimsRpc();
		}
		else
		{
			ResetAnimsCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void ResetAnimsCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::ResetAnimsCmd()", -1300986677, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ResetAnimsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::ResetAnimsRpc()", -82288824, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void TurnOffModels()
	{
		GameObject[] array = objsToTurnOffLocally;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		SkinnedMeshRenderer[] array2 = models;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].enabled = false;
		}
		MeshRenderer[] array3 = models_;
		for (int i = 0; i < array3.Length; i++)
		{
			array3[i].enabled = false;
		}
	}

	private void FixedUpdate()
	{
		if (playerMan.downed)
		{
			spineRots[0].localEulerAngles = new Vector3(NormalizeAngle(camRot.localEulerAngles.x) - 80f, 0f, 0f);
			spineRots[1].localEulerAngles = Vector3.zero;
			spineRots[2].localEulerAngles = Vector3.zero;
			return;
		}
		Transform[] array = spineRots;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].localEulerAngles = new Vector3(NormalizeAngle(camRot.localEulerAngles.x) / 3f, 0f, 0f);
		}
	}

	private float NormalizeAngle(float angle)
	{
		if (angle > 180f)
		{
			angle -= 360f;
		}
		return angle;
	}

	public void EquipObj(int item)
	{
		if (base.isServer)
		{
			EquipObjRpc(item);
		}
		else
		{
			EquipObjCmd(item);
		}
	}

	[Command(requiresAuthority = false)]
	public void EquipObjCmd(int item)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(item);
		SendCommandInternal("System.Void ThirdPersonManager::EquipObjCmd(System.Int32)", -512014476, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void EquipObjRpc(int item)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(item);
		SendRPCInternal("System.Void ThirdPersonManager::EquipObjRpc(System.Int32)", 1444713131, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void DropObj()
	{
		armsAnim.SetBool("HoldingSingle", value: false);
		armsAnim.SetBool("HoldingDouble", value: false);
		if (base.isServer)
		{
			DropObjRpc();
		}
		else
		{
			DropObjCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void DropObjCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::DropObjCmd()", -1522661822, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void DropObjRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::DropObjRpc()", -1532640763, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ShootGun()
	{
		if (base.isServer)
		{
			ShootGunRpc();
		}
		else
		{
			ShootGunCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void ShootGunCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::ShootGunCmd()", 52063879, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ShootGunRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::ShootGunRpc()", -784025948, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void MeleeAttack()
	{
		if (base.isServer)
		{
			MeleeAttackRpc();
		}
		else
		{
			MeleeAttackCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void MeleeAttackCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::MeleeAttackCmd()", 1202890128, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void MeleeAttackRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::MeleeAttackRpc()", -1649127801, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void TurnOffArmsAnim()
	{
		armsAnim.SetBool("Melee", value: false);
	}

	public void ToggleFlashlight(bool on)
	{
		if (base.isServer)
		{
			ToggleFlashlightRpc(on);
		}
		else
		{
			ToggleFlashlightCmd(on);
		}
	}

	[Command(requiresAuthority = false)]
	public void ToggleFlashlightCmd(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendCommandInternal("System.Void ThirdPersonManager::ToggleFlashlightCmd(System.Boolean)", 215521485, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ToggleFlashlightRpc(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendRPCInternal("System.Void ThirdPersonManager::ToggleFlashlightRpc(System.Boolean)", 1926400914, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ToggleMop(bool on)
	{
		if (base.isServer)
		{
			ToggleMopRpc(on);
		}
		else
		{
			ToggleMopCmd(on);
		}
	}

	[Command(requiresAuthority = false)]
	public void ToggleMopCmd(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendCommandInternal("System.Void ThirdPersonManager::ToggleMopCmd(System.Boolean)", -232963515, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ToggleMopRpc(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendRPCInternal("System.Void ThirdPersonManager::ToggleMopRpc(System.Boolean)", 171893178, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void UpdateHat()
	{
		if (base.isServer)
		{
			UpdateHatRpc();
		}
		else
		{
			UpdateHatCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void UpdateHatCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThirdPersonManager::UpdateHatCmd()", 1984560030, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void UpdateHatRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThirdPersonManager::UpdateHatRpc()", -1084860639, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void UpdateHatForOthersCmd(int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(index);
		SendCommandInternal("System.Void ThirdPersonManager::UpdateHatForOthersCmd(System.Int32)", -1962354107, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void UpdateHatForOthersRpc(int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(index);
		SendRPCInternal("System.Void ThirdPersonManager::UpdateHatForOthersRpc(System.Int32)", 1835799734, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeGasPumpParticlesCmd__Boolean(bool on)
	{
		ChangeGasPumpParticlesRpc(on);
	}

	protected static void InvokeUserCode_ChangeGasPumpParticlesCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeGasPumpParticlesCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ChangeGasPumpParticlesCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ChangeGasPumpParticlesRpc__Boolean(bool on)
	{
		gasPumpParticlesOn = on;
		if (on)
		{
			ParticleSystem.EmissionModule emission = gasPumpParticles.emission;
			ParticleSystem.MinMaxCurve rateOverTime = emission.rateOverTime;
			rateOverTime.constant = 35f;
			emission.rateOverTime = rateOverTime;
		}
		else
		{
			ParticleSystem.EmissionModule emission2 = gasPumpParticles.emission;
			ParticleSystem.MinMaxCurve rateOverTime2 = emission2.rateOverTime;
			rateOverTime2.constant = 0f;
			emission2.rateOverTime = rateOverTime2;
		}
	}

	protected static void InvokeUserCode_ChangeGasPumpParticlesRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeGasPumpParticlesRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ChangeGasPumpParticlesRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_GetStuckCmd()
	{
		GetStuckRpc();
	}

	protected static void InvokeUserCode_GetStuckCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command GetStuckCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_GetStuckCmd();
		}
	}

	protected void UserCode_GetStuckRpc()
	{
		stuckObj.SetActive(value: true);
	}

	protected static void InvokeUserCode_GetStuckRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC GetStuckRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_GetStuckRpc();
		}
	}

	protected void UserCode_GetUnstuckCmd()
	{
		GetUnstuckRpc();
	}

	protected static void InvokeUserCode_GetUnstuckCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command GetUnstuckCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_GetUnstuckCmd();
		}
	}

	protected void UserCode_GetUnstuckRpc()
	{
		stuckObj.SetActive(value: false);
		unstuckParticles.SetActive(value: false);
		unstuckParticles.SetActive(value: true);
	}

	protected static void InvokeUserCode_GetUnstuckRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC GetUnstuckRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_GetUnstuckRpc();
		}
	}

	protected void UserCode_GetStunnedCmd()
	{
		GetStunnedRpc();
	}

	protected static void InvokeUserCode_GetStunnedCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command GetStunnedCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_GetStunnedCmd();
		}
	}

	protected void UserCode_GetStunnedRpc()
	{
	}

	protected static void InvokeUserCode_GetStunnedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC GetStunnedRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_GetStunnedRpc();
		}
	}

	protected void UserCode_GetUnstunnedCmd()
	{
		GetUnstunnedRpc();
	}

	protected static void InvokeUserCode_GetUnstunnedCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command GetUnstunnedCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_GetUnstunnedCmd();
		}
	}

	protected void UserCode_GetUnstunnedRpc()
	{
	}

	protected static void InvokeUserCode_GetUnstunnedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC GetUnstunnedRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_GetUnstunnedRpc();
		}
	}

	protected void UserCode_SqueakDuckCmd()
	{
		SqueakDuckRpc();
	}

	protected static void InvokeUserCode_SqueakDuckCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SqueakDuckCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_SqueakDuckCmd();
		}
	}

	protected void UserCode_SqueakDuckRpc()
	{
		duckSqueak.Play();
	}

	protected static void InvokeUserCode_SqueakDuckRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SqueakDuckRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_SqueakDuckRpc();
		}
	}

	protected void UserCode_SetMoodCmd__Int32(int x)
	{
		SetMoodRpc(x);
	}

	protected static void InvokeUserCode_SetMoodCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetMoodCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_SetMoodCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetMoodRpc__Int32(int x)
	{
		moodReading.dialogueId = "Player" + x;
	}

	protected static void InvokeUserCode_SetMoodRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetMoodRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_SetMoodRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetColorCmd__Int32(int colorIndex)
	{
		SetColorRpc(colorIndex);
	}

	protected static void InvokeUserCode_SetColorCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetColorCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_SetColorCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetColorRpc__Int32(int colorIndex)
	{
		Material[] materials = shirt.materials;
		materials[0] = shirtColors[colorIndex];
		shirt.materials = materials;
	}

	protected static void InvokeUserCode_SetColorRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetColorRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_SetColorRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_ResetAnimsCmd()
	{
		ResetAnimsRpc();
	}

	protected static void InvokeUserCode_ResetAnimsCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ResetAnimsCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ResetAnimsCmd();
		}
	}

	protected void UserCode_ResetAnimsRpc()
	{
		bodyAnim.SetBool("Walking", value: false);
		bodyAnim.SetBool("Running", value: false);
		armsAnim.SetBool("Walking", value: false);
		armsAnim.SetBool("Running", value: false);
		armsAnim.SetBool("MidAir", value: false);
		legsAnim.SetBool("Walking", value: false);
		legsAnim.SetBool("Running", value: false);
		legsAnim.SetBool("MidAir", value: false);
	}

	protected static void InvokeUserCode_ResetAnimsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ResetAnimsRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ResetAnimsRpc();
		}
	}

	protected void UserCode_EquipObjCmd__Int32(int item)
	{
		EquipObjRpc(item);
	}

	protected static void InvokeUserCode_EquipObjCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command EquipObjCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_EquipObjCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_EquipObjRpc__Int32(int item)
	{
		ToggleFlashlight(on: false);
		GameObject[] array = objs;
		foreach (GameObject gameObject in array)
		{
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: false);
			}
		}
		armsAnim.SetBool("HoldingSingle", value: false);
		armsAnim.SetBool("HoldingDouble", value: false);
		switch (item)
		{
		case 0:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 1:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 2:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 3:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 4:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 5:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 6:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 7:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 8:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 9:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 10:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 11:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 12:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 13:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 14:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 15:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 16:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 17:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 18:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 19:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 20:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 21:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 22:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 23:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 24:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 25:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 26:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 27:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 28:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 29:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 30:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 31:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 32:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 33:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 34:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 35:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 36:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 37:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 38:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 39:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 40:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 41:
			armsAnim.SetBool("HoldingDouble", value: true);
			break;
		case 42:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 43:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 44:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 45:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		case 46:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		default:
			armsAnim.SetBool("HoldingSingle", value: true);
			break;
		}
		objs[item].SetActive(value: true);
	}

	protected static void InvokeUserCode_EquipObjRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EquipObjRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_EquipObjRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_DropObjCmd()
	{
		DropObjRpc();
	}

	protected static void InvokeUserCode_DropObjCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DropObjCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_DropObjCmd();
		}
	}

	protected void UserCode_DropObjRpc()
	{
		GameObject[] array = objs;
		foreach (GameObject gameObject in array)
		{
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: false);
			}
		}
		armsAnim.SetBool("HoldingSingle", value: false);
		armsAnim.SetBool("HoldingDouble", value: false);
	}

	protected static void InvokeUserCode_DropObjRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC DropObjRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_DropObjRpc();
		}
	}

	protected void UserCode_ShootGunCmd()
	{
		ShootGunRpc();
	}

	protected static void InvokeUserCode_ShootGunCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ShootGunCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ShootGunCmd();
		}
	}

	protected void UserCode_ShootGunRpc()
	{
		if (!(ClientPlayer.Instance == clientPlayer))
		{
			Animator[] array = gunshotAnims;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetTrigger("Shoot");
			}
		}
	}

	protected static void InvokeUserCode_ShootGunRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ShootGunRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ShootGunRpc();
		}
	}

	protected void UserCode_MeleeAttackCmd()
	{
		MeleeAttackRpc();
	}

	protected static void InvokeUserCode_MeleeAttackCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command MeleeAttackCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_MeleeAttackCmd();
		}
	}

	protected void UserCode_MeleeAttackRpc()
	{
		if (!(ClientPlayer.Instance == clientPlayer))
		{
			CancelInvoke("TurnOffArmsAnim");
			Invoke("TurnOffArmsAnim", 0.5f);
			armsAnim.SetTrigger("MeleeAction");
			armsAnim.SetBool("Melee", value: true);
		}
	}

	protected static void InvokeUserCode_MeleeAttackRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC MeleeAttackRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_MeleeAttackRpc();
		}
	}

	protected void UserCode_ToggleFlashlightCmd__Boolean(bool on)
	{
		ToggleFlashlightRpc(on);
	}

	protected static void InvokeUserCode_ToggleFlashlightCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ToggleFlashlightCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ToggleFlashlightCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ToggleFlashlightRpc__Boolean(bool on)
	{
		if (!(ClientPlayer.Instance == clientPlayer))
		{
			flashlightLight.SetActive(on);
		}
	}

	protected static void InvokeUserCode_ToggleFlashlightRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ToggleFlashlightRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ToggleFlashlightRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ToggleMopCmd__Boolean(bool on)
	{
		ToggleMopRpc(on);
	}

	protected static void InvokeUserCode_ToggleMopCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ToggleMopCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ToggleMopCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ToggleMopRpc__Boolean(bool on)
	{
		if (!(ClientPlayer.Instance == clientPlayer))
		{
			mopAnim.SetBool("Use", on);
		}
	}

	protected static void InvokeUserCode_ToggleMopRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ToggleMopRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_ToggleMopRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_UpdateHatCmd()
	{
		UpdateHatRpc();
	}

	protected static void InvokeUserCode_UpdateHatCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command UpdateHatCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_UpdateHatCmd();
		}
	}

	protected void UserCode_UpdateHatRpc()
	{
		if (!(ClientPlayer.Instance.playerMan != playerMan))
		{
			int num = PlayerPrefs.GetInt("CurrentHatSelection", 0);
			if (!SaveManager.Instance.customizablesUnlocked.Contains(num))
			{
				num = 0;
			}
			if (base.isServer)
			{
				UpdateHatForOthersRpc(num);
			}
			else
			{
				UpdateHatForOthersCmd(num);
			}
		}
	}

	protected static void InvokeUserCode_UpdateHatRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateHatRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_UpdateHatRpc();
		}
	}

	protected void UserCode_UpdateHatForOthersCmd__Int32(int index)
	{
		UpdateHatForOthersRpc(index);
	}

	protected static void InvokeUserCode_UpdateHatForOthersCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command UpdateHatForOthersCmd called on client.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_UpdateHatForOthersCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_UpdateHatForOthersRpc__Int32(int index)
	{
		GameObject[] array = hatObjs;
		foreach (GameObject gameObject in array)
		{
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: false);
			}
		}
		if ((bool)hatObjs[index])
		{
			hatObjs[index].SetActive(value: true);
		}
		if (headRenderer != null && headMaterials != null && index < headMaterials.Length)
		{
			Material[] materials = headRenderer.materials;
			materials[0] = headMaterials[index];
			headRenderer.materials = materials;
		}
	}

	protected static void InvokeUserCode_UpdateHatForOthersRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateHatForOthersRpc called on server.");
		}
		else
		{
			((ThirdPersonManager)obj).UserCode_UpdateHatForOthersRpc__Int32(reader.ReadVarInt());
		}
	}

	static ThirdPersonManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ChangeGasPumpParticlesCmd(System.Boolean)", InvokeUserCode_ChangeGasPumpParticlesCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::GetStuckCmd()", InvokeUserCode_GetStuckCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::GetUnstuckCmd()", InvokeUserCode_GetUnstuckCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::GetStunnedCmd()", InvokeUserCode_GetStunnedCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::GetUnstunnedCmd()", InvokeUserCode_GetUnstunnedCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::SqueakDuckCmd()", InvokeUserCode_SqueakDuckCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::SetMoodCmd(System.Int32)", InvokeUserCode_SetMoodCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::SetColorCmd(System.Int32)", InvokeUserCode_SetColorCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ResetAnimsCmd()", InvokeUserCode_ResetAnimsCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::EquipObjCmd(System.Int32)", InvokeUserCode_EquipObjCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::DropObjCmd()", InvokeUserCode_DropObjCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ShootGunCmd()", InvokeUserCode_ShootGunCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::MeleeAttackCmd()", InvokeUserCode_MeleeAttackCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ToggleFlashlightCmd(System.Boolean)", InvokeUserCode_ToggleFlashlightCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ToggleMopCmd(System.Boolean)", InvokeUserCode_ToggleMopCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::UpdateHatCmd()", InvokeUserCode_UpdateHatCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::UpdateHatForOthersCmd(System.Int32)", InvokeUserCode_UpdateHatForOthersCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ChangeGasPumpParticlesRpc(System.Boolean)", InvokeUserCode_ChangeGasPumpParticlesRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::GetStuckRpc()", InvokeUserCode_GetStuckRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::GetUnstuckRpc()", InvokeUserCode_GetUnstuckRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::GetStunnedRpc()", InvokeUserCode_GetStunnedRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::GetUnstunnedRpc()", InvokeUserCode_GetUnstunnedRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::SqueakDuckRpc()", InvokeUserCode_SqueakDuckRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::SetMoodRpc(System.Int32)", InvokeUserCode_SetMoodRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::SetColorRpc(System.Int32)", InvokeUserCode_SetColorRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ResetAnimsRpc()", InvokeUserCode_ResetAnimsRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::EquipObjRpc(System.Int32)", InvokeUserCode_EquipObjRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::DropObjRpc()", InvokeUserCode_DropObjRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ShootGunRpc()", InvokeUserCode_ShootGunRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::MeleeAttackRpc()", InvokeUserCode_MeleeAttackRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ToggleFlashlightRpc(System.Boolean)", InvokeUserCode_ToggleFlashlightRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::ToggleMopRpc(System.Boolean)", InvokeUserCode_ToggleMopRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::UpdateHatRpc()", InvokeUserCode_UpdateHatRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThirdPersonManager), "System.Void ThirdPersonManager::UpdateHatForOthersRpc(System.Int32)", InvokeUserCode_UpdateHatForOthersRpc__Int32);
	}
}
