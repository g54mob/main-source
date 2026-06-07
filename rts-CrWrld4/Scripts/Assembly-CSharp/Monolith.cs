using NBT.Tags;
using UnityEngine;

public class Monolith : UnitManager
{
	private class ClonePack : IClonePack
	{
		private bool absorb;

		public ClonePack(bool absorb)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	public GameObject playerControlledIndicator;

	public GameObject directionIndicator;

	private int controlTransitionCounter;

	private long stashedCreeper;

	private long stashedAnticreeper;

	private int MAX_EMIT_PER_CELL;

	private int CONTROL_TRANSITION_TIME;

	private bool _absorb;

	private bool _playerControlled;

	public bool absorb
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool playerControlled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

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

	private void CheckDisconnect()
	{
	}

	public override void GameUpdate()
	{
	}

	public long AbsorbCreeper()
	{
		return 0L;
	}

	public void AddForEmission(long creeper, long anticreeper)
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
