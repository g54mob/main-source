using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;

public class MVerseForb : MVerseNetworkBehaviour
{
	[NonSerialized]
	public Forb forb;

	[NonSerialized]
	[SyncVar]
	public string trueGUID;

	[SyncVar]
	public bool suppressEffects;

	[NonSerialized]
	public bool initialized;

	public string NetworktrueGUID
	{
		get
		{
			return null;
		}
		[param: In]
		set
		{
		}
	}

	public bool NetworksuppressEffects
	{
		get
		{
			return false;
		}
		[param: In]
		set
		{
		}
	}

	public override void Awake()
	{
	}

	public void Init()
	{
	}

	public override void OnStartClient()
	{
	}

	public IEnumerator DestroyNextFrame()
	{
		return null;
	}

	[Command]
	public void CmdDamage(float amt)
	{
	}

	private void MirrorProcessed()
	{
	}

	public void UserCode_CmdDamage(float amt)
	{
	}

	protected static void InvokeUserCode_CmdDamage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	static MVerseForb()
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
