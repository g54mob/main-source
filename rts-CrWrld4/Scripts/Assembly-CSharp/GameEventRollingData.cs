using System.Collections.Generic;
using NBT.Tags;

public class GameEventRollingData
{
	public struct DataPoint
	{
		public bool liveData;

		public int updateCount;

		public double totalCreeper;

		public double totalAnticreeper;

		public double coverCreeper;

		public double coverAnticreeper;

		public double energyProduction;

		public double energyUse;

		public double energyDeficit;

		public double anticreeperProduction;

		public double anticreeperUse;

		public double anticreeperDeficit;

		public double argProduction;

		public double argUse;

		public double argDeficit;

		public double lifticProduction;

		public double lifticUse;

		public double lifticDeficit;

		public void AddData(long totalCreeper, long totalAnticreeper, int coverCreeper, int coverAnticreeper, float energyProduction, float energyUse, float energyDeficit, float anticreeperProduction, float anticreeperUse, float anticreeperDeficit, float argProduction, float argUse, float argDeficit, float lifticProduction, float lifticUse, float lifticDeficit)
		{
		}

		public void Average()
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

	public const int SAMPLE_SIZE = 30;

	public const int DATA_SIZE = 60;

	public LinkedList<DataPoint> data;

	private DataPoint currentSample;

	private int currentSampleCount;

	public int hasNewDataCount;

	public void AddData(long creeperLevel, long anticreeperLevel, int coverCreeper, int coverAnticreeper, float energyProduction, float energyUse, float energyDeficit, float anticreeperProduction, float anticreeperUse, float anticreeperDeficit, float argProduction, float argUse, float argDeficit, float lifticProduction, float lifticUse, float lifticDeficit)
	{
	}

	public DataPoint GetLastData()
	{
		return default(DataPoint);
	}

	public void ReadData(Tag tdata)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
