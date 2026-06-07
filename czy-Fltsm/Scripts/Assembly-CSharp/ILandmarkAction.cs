using I2.Loc;

public interface ILandmarkAction
{
	ILandmarkActionStates State { get; }

	Project Project { get; }

	bool UseBoat { get; set; }

	int MooringPointCount { get; }

	int AssignmentLimitMinimum { get; }

	int AssignmentLimitMaximum { get; }

	int AssignmentLimit { get; }

	bool IsCompleted { get; }

	bool WasCompleted { get; }

	ILandmarkActionEvent UpdatedEvent { get; }

	LocalizedString Title { get; }

	LocalizedString ActivateText { get; }

	void SetAssignmentLimit(int limit);

	void UpdateState();

	void Activate();

	void Deactivate();

	bool ReturnIsInteractable();

	bool TryReturnInteractableTooltip(out LocalizedString tooltip);

	float ReturnProgress();
}
