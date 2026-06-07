using UnityEngine.UI;

public class MenuToggle : MenuElement
{
	public delegate void OnToggleValueChanged(bool nextState);

	private bool state;

	public Image iconImage;

	public OnToggleValueChanged onToggleValueChanged;

	public void OnToggleClick()
	{
		state = !state;
		UpdateDisplayForState();
		onToggleValueChanged?.Invoke(state);
	}

	public void SetState(bool nextState)
	{
		state = nextState;
		UpdateDisplayForState();
	}

	private void UpdateDisplayForState()
	{
		iconImage.enabled = state;
	}
}
