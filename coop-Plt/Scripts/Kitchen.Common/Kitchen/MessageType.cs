namespace Kitchen
{
	public enum MessageType
	{
		ViewUpdate = 0,
		ViewReparent = 1,
		SpecificViewUpdate = 2,
		CreateView = 3,
		DestroyView = 4,
		Command = 5,
		ViewPositionUpdate = 6,
		MaintainInBounds = 7
	}
}
