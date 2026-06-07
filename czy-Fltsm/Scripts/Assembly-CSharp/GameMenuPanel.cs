using Rewired;
using Rewired.UI.ControlMapper;
using RewiredConsts;
using UnityEngine;

public class GameMenuPanel : Panel
{
	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	public int _closeAction;

	[Tooltip("The panel with the control mapper inside the settings panel.")]
	[SerializeField]
	private ControlMapper _controlMapper;

	private PauseMenuWindow _activePauseMenuWindow;

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (ID == id && !GameManager.CursorManager.TryDisplayExitPanel())
		{
			if (_controlMapper.IsPendingInputWindowOpened)
			{
				_controlMapper.ClosePendingInputWindow();
			}
			else if (base.Open(id, context))
			{
				GameManager.UIManager.PauseGame();
				return true;
			}
		}
		return false;
	}

	public override void Close()
	{
		if ((bool)_activePauseMenuWindow)
		{
			_activePauseMenuWindow.Disable();
		}
		GameManager.UIManager.UnpauseGame();
		PanelEvent.DispatchPanelClosedEvent(this);
	}

	public void OnPauseMenuWindowEnabled(PauseMenuWindow window)
	{
		if (_activePauseMenuWindow != null && _activePauseMenuWindow != window)
		{
			_activePauseMenuWindow.Disable();
		}
		_activePauseMenuWindow = window;
	}

	public void OnPauseMenuWindowDisabled(PauseMenuWindow panel)
	{
		if (_activePauseMenuWindow == panel)
		{
			_activePauseMenuWindow = null;
		}
	}
}
