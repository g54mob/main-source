using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class MVerseSpore : MVerseNetworkBehaviour
{
	[NonSerialized]
	public Spore spore;

	[NonSerialized]
	[SyncVar]
	public string trueGUID;

	[SyncVar]
	public Vector3 startPosition;

	[SyncVar]
	private Spore.TARGET_BEHAVIOR targetBehavior;

	[SyncVar]
	private Vector2 targetBehaviorLocation;

	[SyncVar]
	private Vector2 targetLocation;

	[SyncVar]
	private int payload;

	[SyncVar]
	public bool suppressEffects;

	[SyncVar]
	public int updateCount;

	[SyncVar]
	public int startUpdateCount;

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

	public Vector3 NetworkstartPosition
	{
		get
		{
			return default(Vector3);
		}
		[param: In]
		set
		{
		}
	}

	public Spore.TARGET_BEHAVIOR NetworktargetBehavior
	{
		get
		{
			return default(Spore.TARGET_BEHAVIOR);
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

	public Vector2 NetworktargetLocation
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

	public int NetworkupdateCount
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

	public int NetworkstartUpdateCount
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

	public override void Awake()
	{
	}

	public void Init(Spore.TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload, Vector2 targetLocation, Vector3 startPosition, int updateCount, int startUpdateCount)
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

	static MVerseSpore()
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
