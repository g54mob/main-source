using NBT.Tags;
using UnityEngine;

public class AircraftMoveTarget
{
	public AircraftPadUnitManager aircraftPad;

	private AircraftMoveTargetIndicator primaryIndicator;

	private AircraftMoveTargetIndicator secondaryIndicator;

	private GameObject line;

	public int primaryCellX;

	public int primaryCellY;

	public int secondaryCellX;

	public int secondaryCellY;

	private int primaryHeight;

	private int secondaryHeight;

	private bool dirty;

	public bool temp;

	private bool _secondaryMode;

	private bool _hilightMode;

	public bool secondaryMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hilightMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public AircraftMoveTarget(bool temp)
	{
	}

	public void ShowIndicators()
	{
	}

	public void Update()
	{
	}

	public void SetLocation(int cellX, int cellY)
	{
	}

	public void SetPrimaryLocation(int cellX, int cellY)
	{
	}

	public void SetSecondaryLocation(int cellX, int cellY)
	{
	}

	public void SetIndicatorsVisible(bool vis)
	{
	}

	public void DestroyMoveTarget()
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
