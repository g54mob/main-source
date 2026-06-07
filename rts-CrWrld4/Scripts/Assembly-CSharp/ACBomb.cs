using System;
using ClockStone;
using NBT.Tags;
using UnityEngine;

public class ACBomb : UnitManager
{
	private Vector2 targetCellCoords;

	private float ACCELERATION;

	private float MAX_SPEED;

	[NonSerialized]
	public int PAYLOAD;

	private Vector3 lastPosition;

	private float currentSpeed;

	private ParticleTrailManager trail;

	private AudioObject droppingSound;

	public static ACBomb GetBomb(Vector3 startPos, Vector2 targetCellCoords, bool enemy, int PAYLOAD)
	{
		return null;
	}

	public float Remap(float value, float from1, float to1, float from2, float to2)
	{
		return 0f;
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void Update()
	{
	}

	public void Init(Vector2 targetCellCoords)
	{
	}

	public override void GameUpdate()
	{
	}

	private void HandleSound()
	{
	}

	private void HitTarget()
	{
	}

	private void SetPosition(Vector3 pos)
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override string GetDataName()
	{
		return null;
	}

	public override void ReadData(Tag data)
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
