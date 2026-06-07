public static class eStageTypeExtension
{
	public static bool CanReEnter(this eStageType stageType)
	{
		return false;
	}

	public static bool IsStartupNode(this eStageType stageType)
	{
		return false;
	}

	public static bool IsBattleNode(this eStageType stageType)
	{
		return false;
	}

	public static bool IsBattleNodeExceptBoss(this eStageType stageType)
	{
		return false;
	}
}
