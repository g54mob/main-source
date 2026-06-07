using System;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class GreenarMother : UnitManager
{
	private class ClonePack : IClonePack
	{
		private int spawnInterval;

		public ClonePack(int spawnInterval)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	[NonSerialized]
	public int SPAWN_INTERVAL;

	public GameObject rangeIndicator;

	public bool forceShowRange;

	private int hideCounter;

	private double randSeed;

	public override string officialName => null;

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public override void GameUpdate()
	{
	}

	public override void Update()
	{
	}

	public override void OnMouseOver()
	{
	}

	private void Spawn()
	{
	}

	private bool IsClear(int cx, int cy)
	{
		return false;
	}

	public double RandDouble()
	{
		return 0.0;
	}

	public float RandFloat()
	{
		return 0f;
	}

	public Vector2 RandCircle(float R)
	{
		return default(Vector2);
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
