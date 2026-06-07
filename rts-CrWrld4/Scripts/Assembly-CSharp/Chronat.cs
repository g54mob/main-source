using NBT.Tags;
using UnityEngine;

public class Chronat : UnitManager
{
	private const float SPINNER_SPEED = 5f;

	private const float AMMO_USE = 1f / 60f;

	public GameObject spinner;

	public GameObject feet;

	public GameObject body;

	public GameObject rangeIndicator;

	private int hideCounter;

	private int lastRange;

	private int MYRANGE => 0;

	public override string officialName => null;

	public override void Update()
	{
	}

	public override void OnMouseOver()
	{
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void GameUpdate()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override void ReadDataLate()
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
