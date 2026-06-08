namespace Kitchen
{
	public static class MergeConditionHelpers
	{
		public static bool CanComp(this MergeCondition condition)
		{
			if (condition != MergeCondition.All && condition != MergeCondition.OnlyAsComponents && condition != MergeCondition.MaintainWrapper && condition != MergeCondition.OnlyWithPlate)
			{
				return condition == MergeCondition.OnlyAsFirstSplitElement;
			}
			return true;
		}

		public static bool CanWrap(this MergeCondition condition)
		{
			if (condition != MergeCondition.All && condition != MergeCondition.OnlyAsWrapped && condition != MergeCondition.OnlyWithPlate)
			{
				return condition == MergeCondition.OnlyAsFirstSplitElement;
			}
			return true;
		}

		public static bool CanSide(this MergeCondition condition)
		{
			return condition == MergeCondition.AsSide;
		}

		public static bool CanChangeWrapper(this MergeCondition condition)
		{
			return condition != MergeCondition.MaintainWrapper;
		}
	}
}
