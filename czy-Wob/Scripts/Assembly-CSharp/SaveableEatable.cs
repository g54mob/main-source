using System;

[Serializable]
public class SaveableEatable
{
	public int bitesLeft;

	public SaveableEatable()
	{
	}

	public SaveableEatable(Eatable e)
	{
		bitesLeft = e.GetBitesLeft();
	}

	public void Load(Eatable e)
	{
		e.SetBitesLeft(bitesLeft);
	}

	public SaveableEatable GetCopy()
	{
		return new SaveableEatable
		{
			bitesLeft = bitesLeft
		};
	}
}
