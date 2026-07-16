using System;

[Serializable]
public class ShopWagon
{
	public int Index;

	public int Size;

	public ShopWagon(int index, int size)
	{
		Index = index;
		Size = size;
	}
}
