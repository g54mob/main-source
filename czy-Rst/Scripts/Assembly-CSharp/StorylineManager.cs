using System;
using System.Collections.Generic;
using System.Linq;

public class StorylineManager
{
	public static StoryLineType ChooseNewStoryline(IReadOnlyList<StoryLineType> completedStorylineTypes)
	{
		int num = new Random().Next(0, 101);
		if (completedStorylineTypes.Count == 0)
		{
			if (num <= 50)
			{
				return StoryLineType.IFPW;
			}
			return StoryLineType.MDPM;
		}
		if (completedStorylineTypes.Count == 1)
		{
			if (num < 70)
			{
				return StoryLineType.USNME;
			}
			if (num < 95)
			{
				return StoryLineType.DCAS;
			}
			return StoryLineType.TCAC;
		}
		if (completedStorylineTypes.Count == 2 || completedStorylineTypes.Count == 3)
		{
			if (!completedStorylineTypes.Contains(StoryLineType.USNME))
			{
				if (completedStorylineTypes.Contains(StoryLineType.DCAS))
				{
					if (!completedStorylineTypes.Contains(StoryLineType.TCAC))
					{
						if (num < 95)
						{
							return StoryLineType.USNME;
						}
						return StoryLineType.TCAC;
					}
					return StoryLineType.USNME;
				}
				if (num < 75)
				{
					return StoryLineType.USNME;
				}
				return StoryLineType.DCAS;
			}
			if (!completedStorylineTypes.Contains(StoryLineType.DCAS))
			{
				if (completedStorylineTypes.Contains(StoryLineType.USNME))
				{
					if (!completedStorylineTypes.Contains(StoryLineType.TCAC))
					{
						if (num < 95)
						{
							return StoryLineType.DCAS;
						}
						return StoryLineType.TCAC;
					}
					return StoryLineType.DCAS;
				}
				if (num < 30)
				{
					return StoryLineType.DCAS;
				}
				return StoryLineType.USNME;
			}
			return StoryLineType.TCAC;
		}
		if (completedStorylineTypes.Count == 4)
		{
			if (!completedStorylineTypes.Contains(StoryLineType.IFPW))
			{
				return StoryLineType.IFPW;
			}
			return StoryLineType.MDPM;
		}
		return StoryLineType.NULL;
	}
}
