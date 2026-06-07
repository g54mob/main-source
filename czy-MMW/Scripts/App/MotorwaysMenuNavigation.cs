using Factory;
using Motorways.UI;
using Popups;
using Screens;
using UnityEngine;
using UnityEngine.UI;

public class MotorwaysMenuNavigation : MenuNavigation
{
	[Dependency]
	protected ScreenStack _screenStack;

	[Dependency]
	protected PopupStack _popupStack;

	public override bool ActivateSelected()
	{
		if (_activeFocus != null)
		{
			if (typeof(TouchButton).IsAssignableFrom(_activeFocus.GetType()))
			{
				((TouchButton)_activeFocus).OnSubmit(null);
				return true;
			}
			if (typeof(TouchToggle).IsAssignableFrom(_activeFocus.GetType()))
			{
				((TouchToggle)_activeFocus).OnSubmit(null);
				return true;
			}
		}
		return false;
	}

	public override void BackActivated()
	{
		IScreen topVisibleScreen = _screenStack.GetTopVisibleScreen();
		if (_popupStack.HasActivePopups && _popupStack.GetTopPopup().CanBeDismissed())
		{
			_popupStack.PopPopup();
		}
		else if (topVisibleScreen is BaseScalingScreen baseScalingScreen)
		{
			baseScalingScreen.BackActivated();
		}
	}

	public override void PageSelected(Vector2 direction)
	{
		if (_screenStack.GetTopVisibleScreen() is BaseScalingScreen baseScalingScreen)
		{
			baseScalingScreen.PageSelected(direction);
		}
	}
}
