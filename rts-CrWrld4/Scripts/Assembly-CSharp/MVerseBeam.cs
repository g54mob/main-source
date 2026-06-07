using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class MVerseBeam : NetworkBehaviour
{
	[NonSerialized]
	public MVerseUnit mvu;

	private BeamMVB beamMVB;

	[NonSerialized]
	public Vector3 startLocation;

	[NonSerialized]
	public Vector3 endLocation;

	[NonSerialized]
	public Color color;

	[NonSerialized]
	public bool visible;

	[NonSerialized]
	public float width;

	[SyncVar]
	public int unitUID;

	[SyncVar]
	public int beamUID;

	private Beam beam;

	private float deltaT;

	private float MIN_DELTAT;

	private Vector3 lastMVUPos;

	private Vector3 lastStartPos;

	private Vector3 lastEndPos;

	private float lastWidth;

	private string lastColorMat;

	private bool lastVisible;

	private float lastHDR;

	public int NetworkunitUID
	{
		get
		{
			return 0;
		}
		[param: In]
		set
		{
		}
	}

	public int NetworkbeamUID
	{
		get
		{
			return 0;
		}
		[param: In]
		set
		{
		}
	}

	public void Awake()
	{
	}

	public override void OnStartServer()
	{
	}

	public override void OnStartClient()
	{
	}

	public void SyncBeam()
	{
	}

	[Command]
	public void CmdSetMVUPos(Vector3 pos)
	{
	}

	[ClientRpc]
	public void RpcSetMVUPos(Vector3 pos)
	{
	}

	[Command]
	public void CmdSetStartPos(Vector3 pos)
	{
	}

	[ClientRpc]
	public void RpcSetStartPos(Vector3 pos)
	{
	}

	[Command]
	public void CmdSetEndPos(Vector3 pos)
	{
	}

	[ClientRpc]
	public void RpcSetEndPos(Vector3 pos)
	{
	}

	[Command]
	public void CmdSetWidth(float val)
	{
	}

	[ClientRpc]
	public void RpcSetWidth(float val)
	{
	}

	[Command]
	public void CmdSetColorMat(string val)
	{
	}

	[ClientRpc]
	public void RpcSetColorMat(string val)
	{
	}

	[Command]
	public void CmdSetVisible(bool val)
	{
	}

	[ClientRpc]
	public void RpcSetVisible(bool val)
	{
	}

	[Command]
	public void CmdSetHDR(float val)
	{
	}

	[ClientRpc]
	public void RpcSetHDR(float val)
	{
	}

	[ClientCallback]
	private void OnDestroy()
	{
	}

	private void MirrorProcessed()
	{
	}

	public void UserCode_CmdSetMVUPos(Vector3 pos)
	{
	}

	protected static void InvokeUserCode_CmdSetMVUPos(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetMVUPos(Vector3 pos)
	{
	}

	protected static void InvokeUserCode_RpcSetMVUPos(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetStartPos(Vector3 pos)
	{
	}

	protected static void InvokeUserCode_CmdSetStartPos(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetStartPos(Vector3 pos)
	{
	}

	protected static void InvokeUserCode_RpcSetStartPos(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetEndPos(Vector3 pos)
	{
	}

	protected static void InvokeUserCode_CmdSetEndPos(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetEndPos(Vector3 pos)
	{
	}

	protected static void InvokeUserCode_RpcSetEndPos(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetWidth(float val)
	{
	}

	protected static void InvokeUserCode_CmdSetWidth(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetWidth(float val)
	{
	}

	protected static void InvokeUserCode_RpcSetWidth(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetColorMat(string val)
	{
	}

	protected static void InvokeUserCode_CmdSetColorMat(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetColorMat(string val)
	{
	}

	protected static void InvokeUserCode_RpcSetColorMat(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetVisible(bool val)
	{
	}

	protected static void InvokeUserCode_CmdSetVisible(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetVisible(bool val)
	{
	}

	protected static void InvokeUserCode_RpcSetVisible(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetHDR(float val)
	{
	}

	protected static void InvokeUserCode_CmdSetHDR(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetHDR(float val)
	{
	}

	protected static void InvokeUserCode_RpcSetHDR(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	static MVerseBeam()
	{
	}

	public override bool SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		return false;
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
	}
}
