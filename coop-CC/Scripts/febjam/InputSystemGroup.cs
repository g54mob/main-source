using Aggro.Core;

[UpdateInGroup(typeof(PresentationSystemGroup), UpdatePriority.Normal)]
public class InputSystemGroup : EntitySystemGroupBase, IInputController
{
	protected override bool ShouldUpdateGroup()
	{
		return AggroInputManager.HasControl(this);
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.Game.Enable();
		AggroInputManager.DisableUIModule();
		AggroInputManager.HideMouseCursor();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.Game.Disable();
		AggroInputManager.EnableUIModule();
		AggroInputManager.ResetMouseCursor();
	}
}
