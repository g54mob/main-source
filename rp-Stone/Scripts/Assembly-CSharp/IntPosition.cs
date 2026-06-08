using System;

[Serializable]
public class IntPosition
{
	public int x;

	public int y;

	public int z;

	public IntPosition()
	{
	}

	public IntPosition(int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}
}
