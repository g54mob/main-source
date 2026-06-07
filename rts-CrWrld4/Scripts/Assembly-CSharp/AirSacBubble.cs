using System;
using NBT.Tags;
using UnityEngine;

public class AirSacBubble : UnitManager
{
	[NonSerialized]
	public MVerseAirSacBubble mverseController;

	[NonSerialized]
	public int payload;

	[NonSerialized]
	public Transform attachedTo;

	[NonSerialized]
	public AirSacBubble attachedFrom;

	[NonSerialized]
	public bool dontMoveAttachedTo;

	[NonSerialized]
	public bool dumpPayloadOnDestroy;

	[NonSerialized]
	public bool dumpPayloadInsideShields;

	[NonSerialized]
	public Vector3 lastPosition;

	private static Vector3 GRAVITY;

	[NonSerialized]
	public float MAX_SPEED;

	[NonSerialized]
	public float BOND_DISTANCE;

	[NonSerialized]
	public float STIFFNESS;

	[NonSerialized]
	public bool disableLine;

	[NonSerialized]
	public bool disableCreeperDamp;

	[NonSerialized]
	public float minScale;

	[NonSerialized]
	public float maxScale;

	[NonSerialized]
	public float scaleInterval;

	[NonSerialized]
	public bool BOUNCE_TERRAIN;

	[NonSerialized]
	public bool BOUNCE_PSEUDOTERRAIN;

	[NonSerialized]
	public bool BOUNCE_SHIELD;

	[NonSerialized]
	public bool DESTROY_WHEN_STILL;

	[NonSerialized]
	public int DESTROY_WHEN_DRY_TIME;

	[NonSerialized]
	public float DESTROY_WHEN_DRY_MAX_HEIGHT;

	[NonSerialized]
	private float MOVE_TO_SPEED;

	[NonSerialized]
	public bool SNIPER_IGNORE;

	[NonSerialized]
	public Vector3 moveToPos;

	[NonSerialized]
	public bool brave;

	[NonSerialized]
	public int braveInteractions;

	[NonSerialized]
	public int braveMaxInteractions;

	private bool _showPathLine;

	private bool _attachedToBlob;

	public LineRenderer line;

	public LineRenderer pathLine;

	private int dryCounter;

	private bool _useWrathMaterial;

	private int lastASBArrayPos;

	private int popupQuellCount;

	private float INTERACT_DIST2;

	private float MAXDIFF;

	[NonSerialized]
	public bool dontChainDestroy;

	public bool showPathLine
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool attachedToBlob
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool useWrathMaterial
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool IsEgg => false;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void Init()
	{
	}

	private void UpdateASBArray()
	{
	}

	public void SetScale()
	{
	}

	public override void GameUpdate()
	{
	}

	public void UpdatePathLine()
	{
	}

	public void HandleCollisions()
	{
	}

	private void HandleCollisions(int cx, int cz)
	{
	}

	public void Constrain()
	{
	}

	private void DumpPayload()
	{
	}

	private void AddCreeper(int cx, int cy, int payload)
	{
	}

	public static Vector3 RandomV3(float min, float max)
	{
		return default(Vector3);
	}

	private void Boom()
	{
	}

	public void ShowPathLine(bool show, Color color, bool ignoreMVerse = false)
	{
	}

	public bool GetPathLine()
	{
		return false;
	}

	public void BecomeBrave()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	private void OnDestroy()
	{
	}

	public override void Damage(float damage)
	{
	}

	private float Clamp(float val, float min, float max)
	{
		return 0f;
	}

	public override void ReadData(Tag data)
	{
	}

	public override void ReadDataLate()
	{
	}

	private bool CheckRange(Vector3 val)
	{
		return false;
	}

	private bool CheckRange(float val)
	{
		return false;
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
