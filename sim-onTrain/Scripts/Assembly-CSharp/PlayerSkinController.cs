using System.Collections.Generic;
using System.Runtime.InteropServices;
using JUTPS;
using JUTPS.FX;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-200)]
public class PlayerSkinController : NetworkBehaviour
{
	public List<GameObject> skins = new List<GameObject>();

	[SyncVar(hook = "OnChangeSkin")]
	[SerializeField]
	public int selectedSkin;

	public UnityEvent OnSkinSelected = new UnityEvent();

	public int NetworkselectedSkin
	{
		get
		{
			return selectedSkin;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref selectedSkin, 1uL, OnChangeSkin);
		}
	}

	private void Start()
	{
		if (base.isLocalPlayer)
		{
			CmdChangeSkin(Random.Range(0, skins.Count));
		}
	}

	[Command]
	public void CmdChangeSkin(int newSkinIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(newSkinIndex);
		SendCommandInternal("System.Void PlayerSkinController::CmdChangeSkin(System.Int32)", -1985680997, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void OnChangeSkin(int oldSkinIndex, int newSkinIndex)
	{
		GameObject gameObject = Object.Instantiate(skins[selectedSkin], base.transform);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = Vector3.zero;
		TsSkinObject component = gameObject.GetComponent<TsSkinObject>();
		GetComponent<Animator>().avatar = gameObject.GetComponent<Animator>().avatar;
		GetComponent<BodyLeanInert>().RootBone = component.skinInfo.rootBone.transform;
		JUFootstep component2 = GetComponent<JUFootstep>();
		component2.LeftFoot = component.skinInfo.leftFoot;
		component2.RightFoot = component.skinInfo.rightFoot;
		GetComponent<JUCharacterController>().HumanoidSpine = component.skinInfo.spine.transform;
		OnSkinSelected.Invoke();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdChangeSkin__Int32(int newSkinIndex)
	{
		NetworkselectedSkin = newSkinIndex;
	}

	protected static void InvokeUserCode_CmdChangeSkin__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdChangeSkin called on client.");
		}
		else
		{
			((PlayerSkinController)obj).UserCode_CmdChangeSkin__Int32(reader.ReadInt());
		}
	}

	static PlayerSkinController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerSkinController), "System.Void PlayerSkinController::CmdChangeSkin(System.Int32)", InvokeUserCode_CmdChangeSkin__Int32, requiresAuthority: true);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(selectedSkin);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteInt(selectedSkin);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref selectedSkin, OnChangeSkin, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref selectedSkin, OnChangeSkin, reader.ReadInt());
		}
	}
}
