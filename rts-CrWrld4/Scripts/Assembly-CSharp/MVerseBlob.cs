using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class MVerseBlob : MVerseNetworkBehaviour
{
	[NonSerialized]
	public Blob blob;

	[NonSerialized]
	[SyncVar]
	public string trueGUID;

	[SyncVar]
	private Blob.TARGET_BEHAVIOR targetBehavior;

	[SyncVar]
	private Vector2 targetBehaviorLocation;

	[SyncVar]
	private int payload;

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

	public Blob.TARGET_BEHAVIOR NetworktargetBehavior
	{
		get
		{
			return default(Blob.TARGET_BEHAVIOR);
		}
		[param: In]
		set
		{
		}
	}

	public Vector2 NetworktargetBehaviorLocation
	{
		get
		{
			return default(Vector2);
		}
		[param: In]
		set
		{
		}
	}

	public int Networkpayload
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

	public void Init(Blob.TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload)
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

	static MVerseBlob()
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
