using System;

[Serializable]
public class ItemStackData
{
	public string itemId;

	public int count;

	public ItemStackData(string id, int c)
	{
		itemId = id;
		count = c;
	}
}
