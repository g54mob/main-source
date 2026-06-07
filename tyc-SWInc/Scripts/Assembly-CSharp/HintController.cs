public static class HintController
{
	public enum Hints
	{
		HintEmployeeAssign = 0,
		HintStaffAssign = 1,
		HintMultipleBuild = 2,
		HintQuickSelect = 3,
		HintSelectFurnitureType = 4,
		HintCopyColor = 5,
		HintProductRelease = 6,
		HintFurnitureCopyMultiple = 7,
		HintEmployeeEducation = 8,
		HintEmployeeSelection = 9,
		HintAutoScaleSegment = 10,
		HintElevatorBeam = 11,
		HintGridSnapToWall = 12,
		HintWorkItemActions = 13,
		HintTeamSizeEffectiveness = 14,
		DeleteKeyHintHint = 15,
		LampTestHint = 16,
		FurnPlaceHintRotateKey = 17,
		FurnPlaceHintRotateMouse = 18,
		FurnPlaceHintAlign = 19,
		FurnPlaceHintMultiple = 20,
		FurnPlaceHintRotateMouseSnap = 21,
		GermHint = 22,
		SkipTimeHint = 23,
		OldComputerHint = 24,
		HintStretchPanel = 25,
		HintMultiSelectList = 26,
		HintAutoBuyTemp = 27,
		HintJumpToSelection = 28,
		HintManufacturingSpace = 29,
		HintResizeWindow = 30,
		HintDismissNotification = 31,
		HintDuplicateStuff = 32,
		HintMoveFurniture = 33,
		HintCloseWindows = 34,
		HintNightOwl = 35,
		HintSendHome = 36,
		HintGlobalSearch = 37,
		FurnitureShortCutHint = 38
	}

	public static bool IsHintPossible(Hints hint)
	{
		if (Options.HintsEnabled)
		{
			return Options.HintEnabled((int)hint);
		}
		return false;
	}

	public static void Show(Hints hint)
	{
		if (Options.HintsEnabled && Options.HintEnabled((int)hint))
		{
			NotificationManager.AddHint(hint);
		}
	}
}
