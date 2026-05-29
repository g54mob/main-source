using System;

[Serializable]
public class Magic
{
	public long capMagic;

	public long curMagic;

	public long idleMagic;

	public float magicBarSpeed;

	public long magicPerBar;

	public long magicGained;

	public float magicPower;

	public float magicBarProgress;

	public Magic()
	{
		capMagic = 0L;
		curMagic = 0L;
		idleMagic = 0L;
		magicBarSpeed = 0f;
		magicPerBar = 0L;
		magicGained = 0L;
		magicPower = 1f;
		magicBarProgress = 0f;
	}

	public void unlockMagic()
	{
		if (capMagic < 10000)
		{
			capMagic = 10000L;
		}
		if (magicBarSpeed < 3f)
		{
			magicBarSpeed = 3f;
		}
		if (magicPerBar < 1)
		{
			magicPerBar = 1L;
		}
	}

	public void reset()
	{
		idleMagic = 0L;
		curMagic = 0L;
		magicBarProgress = 0f;
	}
}
