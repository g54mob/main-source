using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class MVerseAirSac : MVerseNetworkBehaviour
{
	[NonSerialized]
	public AirSac airSac;

	[NonSerialized]
	[SyncVar]
	public string trueGUID;

	[SyncVar]
	private AirSac.TARGET_BEHAVIOR targetBehavior;

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

	public AirSac.TARGET_BEHAVIOR NetworktargetBehavior
	{
		get
		{
			return default(AirSac.TARGET_BEHAVIOR);
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

	public void Init(AirSac.TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload)
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

	static MVerseAirSac()
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
