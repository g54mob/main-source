using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class MVerseAirSacBubble : MVerseNetworkBehaviour
{
	[NonSerialized]
	public AirSacBubble asb;

	[NonSerialized]
	[SyncVar]
	public string trueGUID;

	[SyncVar]
	private bool enemy;

	[SyncVar]
	public bool showPathLine;

	[SyncVar]
	private Vector3 moveToPos;

	[SyncVar]
	private int payload;

	[SyncVar]
	private bool useWrathMaterial;

	[SyncVar]
	private bool SNIPER_IGNORE;

	[SyncVar]
	private float minScale;

	[SyncVar]
	private float scaleInterval;

	[SyncVar]
	private Color pathLineColor;

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

	public bool Networkenemy
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

	public bool NetworkshowPathLine
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

	public Vector3 NetworkmoveToPos
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

	public bool NetworkuseWrathMaterial
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

	public bool NetworkSNIPER_IGNORE
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

	public float NetworkminScale
	{
		get
		{
			return 0f;
		}
		[param: In]
		set
		{
		}
	}

	public float NetworkscaleInterval
	{
		get
		{
			return 0f;
		}
		[param: In]
		set
		{
		}
	}

	public Color NetworkpathLineColor
	{
		get
		{
			return default(Color);
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

	public void Init(bool enemy, bool showPathLine, Vector3 moveToPos, int payload, bool useWrathMaterial, bool SNIPER_IGNORE, float minScale, float scaleInterval, Color pathLineColor)
	{
	}

	public override void OnStartClient()
	{
	}

	public IEnumerator DestroyNextFrame()
	{
		return null;
	}

	private void OnShowPathLineChanged(bool oldVal, bool newVal)
	{
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

	static MVerseAirSacBubble()
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
