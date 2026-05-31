using System.Collections.Generic;

public static class ConstructionFeedback
{
	public static HashSet<ConstructionFeedBackResult> FeedbackList { get; } = new HashSet<ConstructionFeedBackResult>();

	public static void ClearList()
	{
		FeedbackList.Clear();
	}

	public static int Count()
	{
		return FeedbackList.Count;
	}

	public static void AddToList(ConstructionFeedBackResult feedback)
	{
		FeedbackList.Add(feedback);
	}
}
