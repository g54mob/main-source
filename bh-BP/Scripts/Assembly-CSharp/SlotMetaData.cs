using System;

[Serializable]
public class SlotMetaData
{
	public int NumLvlsCompleted;

	public float PlayTime;

	public int SecsSince2040;

	public int Seed;

	public SlotMetaData()
	{
	}

	public SlotMetaData(MetaSaveData savData)
	{
	}
}
