using System.Collections.Generic;

public class RoomComparer : IComparer<KeyValuePair<Room, int>>
{
	public int Compare(KeyValuePair<Room, int> x, KeyValuePair<Room, int> y)
	{
		return x.Value.CompareTo(y.Value);
	}
}
