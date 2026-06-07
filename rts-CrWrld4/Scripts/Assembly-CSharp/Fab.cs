using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class Fab : UnitManager
{
	public enum FabType
	{
		BLUE = 0,
		RED = 1,
		GRAY = 2
	}

	public Mesh padMeshBlue;

	public Mesh padMeshRed;

	public Mesh padMeshGray;

	public GameObject shaft;

	public GameObject piston0;

	public GameObject piston1;

	public GameObject rod0;

	public GameObject rod1;

	public GameObject typeQuad;

	private int MAX_ROTATE_SPEED;

	private int MAX_WORK_SPEED;

	private int workSpeed;

	private List<FabricatorWare> producedWares;

	private FabType _fabType;

	private WaresManager.WareDef wareToMakeDef;

	private int neededWare;

	private int neededWareCost;

	private int _wareToMake;

	private float _shaftRotation;

	public FabType TypeOfFab;

	private Vector3 producedWareStartPos;

	private float producedWareDist;

	private const int PILE_WIDTH = 6;

	private const int PILE_LENGTH = 4;

	private const int PILE_HEIGHT = 5;

	public FabType fabType
	{
		get
		{
			return default(FabType);
		}
		set
		{
		}
	}

	public int wareToMake
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private float shaftRotation
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public override void Awake()
	{
	}

	private void SetFabType(FabType fabType)
	{
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	public List<FabricatorWare> GetProducedWares()
	{
		return null;
	}

	private void SetNeededWares()
	{
	}

	private void Fabricate()
	{
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	public void DestroyProducedWares(int wareType, int amt)
	{
	}

	private int GetNewPadPos()
	{
		return 0;
	}

	private void PositionProducedWares()
	{
	}

	public override void ApplyPacket(Packet pm)
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
