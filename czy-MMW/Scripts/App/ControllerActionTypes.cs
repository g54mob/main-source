public static class ControllerActionTypes
{
	public enum MotorwaysControllerActions
	{
		NavigateUp = 0,
		NavigateRight = 1,
		NavigateDown = 2,
		NavigateLeft = 3,
		NavigateInDirection = 4,
		AccumulateNavigateInDirection = 5,
		ResetAccumulatedNavigation = 6,
		ActivateSelected = 7,
		ActivateBack = 8,
		ActivateMenu = 9,
		BeginMoveInGameFocus = 10,
		MoveInGameFocus = 11,
		EndMoveInGameFocus = 12,
		DrawRoad = 13,
		CancelDrawRoad = 14,
		FocusUpgradeBar = 15,
		SelectUpgrade = 16,
		PlaceUpgrade = 17,
		MoveMotorway = 18,
		MoveMotorwayHandle = 19,
		ToggleDrawMode = 20,
		ToggleGameSpeed = 21,
		DecreaseGameSpeed = 22,
		IncreaseGameSpeed = 23,
		ActivateControllerSelect = 24,
		Zoom = 25
	}
}
