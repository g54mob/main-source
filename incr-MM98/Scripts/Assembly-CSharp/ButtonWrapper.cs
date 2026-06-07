using UnityEngine.UI;

public class ButtonWrapper : Button
{
	private SelectionState? _forceState;

	public void ForceNormal()
	{
		SetForcedState(SelectionState.Normal);
	}

	public void ForceHighlighted()
	{
		SetForcedState(SelectionState.Highlighted);
	}

	public void ForceSelected()
	{
		SetForcedState(SelectionState.Selected);
	}

	public void ForcePressed()
	{
		SetForcedState(SelectionState.Pressed);
	}

	public void ForceDisabled()
	{
		SetForcedState(SelectionState.Disabled);
	}

	public void Clear()
	{
		SetForcedState(null);
	}

	private void SetForcedState(SelectionState? state)
	{
		_forceState = state;
		DoStateTransition(base.currentSelectionState, instant: true);
	}

	protected override void DoStateTransition(SelectionState state, bool instant)
	{
		base.DoStateTransition(_forceState ?? state, instant);
	}
}
