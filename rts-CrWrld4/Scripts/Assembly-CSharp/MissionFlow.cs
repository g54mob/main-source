using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class MissionFlow
{
	public class MissionFlowRecord
	{
		public long creeperTotal;

		public int creeperCoverage;

		public long anticreeperTotal;

		public int anticreeperCoverage;

		public float energyProduction;

		public short ecoCount;

		public short[] unitCounts;

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public int completionTime;

	public List<MissionFlowRecord> records;

	private int arraySize;

	private int rowHeight;

	public void AddRecord(long creeperTotal, int creeperCoverage, long anticreeperTotal, int anticreeperCoverage, float energyProduction, short ecoCount)
	{
	}

	public Texture2D GetImage(int width)
	{
		return null;
	}

	private void DrawRect(Color32[] pixels, int pixelsWidth, int sx, int sy, int w, int h, Color32 color)
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
