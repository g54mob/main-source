public static class GnormanActionExtensions
{
	public static bool IsFluff(this GnormanAction action)
	{
		if (action != GnormanAction.None)
		{
			return action.Data() is GnormanFluffActionData;
		}
		return false;
	}

	public static bool FluffData(this GnormanAction action, out GnormanFluffActionData data)
	{
		data = null;
		if (action == GnormanAction.None)
		{
			return false;
		}
		data = action.Data() as GnormanFluffActionData;
		return data;
	}

	public static bool IsTutorial(this GnormanAction action)
	{
		if (action != GnormanAction.None)
		{
			return action.Data() is GnormanTutorialActionData;
		}
		return false;
	}

	public static bool TutorialData(this GnormanAction action, out GnormanTutorialActionData data)
	{
		data = null;
		if (action == GnormanAction.None)
		{
			return false;
		}
		data = action.Data() as GnormanTutorialActionData;
		return data;
	}
}
