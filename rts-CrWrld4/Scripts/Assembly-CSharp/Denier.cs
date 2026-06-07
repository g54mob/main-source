using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class Denier : UnitManager
{
	private class ClonePack : IClonePack
	{
		private int fogWidth;

		private int fogHeight;

		private bool fogIsSquare;

		public ClonePack(int fogWidth, int fogHeight, bool fogIsSquare)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	public GameObject rangeIndicator;

	private int _FOGWIDTH;

	private int _FOGHEIGHT;

	private bool _FOGISSQUARE;

	private int hideCounter;

	private int lcx;

	private int lcy;

	public int FOGWIDTH
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int FOGHEIGHT
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool FOGISSQUARE
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override string officialName => null;

	public override void OnMouseOver()
	{
	}

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override void Awake()
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

	private void HandleFog()
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
