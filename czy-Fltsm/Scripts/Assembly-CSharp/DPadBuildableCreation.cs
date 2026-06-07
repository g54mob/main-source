using UnityEngine;
using UnityEngine.EventSystems;

public class DPadBuildableCreation : DPadMenuBase
{
	[SerializeField]
	private PanelID _panelId = PanelID.BuildableCreation;

	public override void Enable(int triggerAction, bool handleInput)
	{
		base.Enable(triggerAction, handleInput);
		GameManager.UIManager.DisplayPanel(_panelId);
	}

	public override void Trigger()
	{
		if ((bool)EventSystem.current.currentSelectedGameObject && EventSystem.current.currentSelectedGameObject.TryGetComponent<BuildableToggle>(out var component) && component.isActiveAndEnabled)
		{
			component.Trigger();
		}
		Disable();
	}

	public override void Disable()
	{
		base.Disable();
		GameManager.UIManager.ClosePanel(_panelId);
	}
}
