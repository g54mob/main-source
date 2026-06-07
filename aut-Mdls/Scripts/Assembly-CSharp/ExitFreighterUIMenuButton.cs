using Data.Variables;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using Utils.Enums;

public class ExitFreighterUIMenuButton : ExitUIMenuButton
{
	[SerializeField]
	private BoolVariableSO _unsavedFreighterChanges;

	[SerializeField]
	private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

	protected override void Exit()
	{
		if (_unsavedFreighterChanges.Value)
		{
			UnsavedChangesPrompt();
		}
		else
		{
			base.Exit();
		}
	}

	private void UnsavedChangesPrompt()
	{
		MenuModalDialogDto dto = new MenuModalDialogDto("FreightersUI.UnsavedChanges", Sizes.S, base.Exit, showCancelButton: true)
		{
			OverrideSuccessButtonTextKey = "ModalGeneric.AcceptButton"
		};
		_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
	}
}
