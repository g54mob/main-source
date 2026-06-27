using System;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.PlayerInput;
using Restory.UI.Presenters.Notepad;
using Restory.UI.Presenters.PauseMenu;
using Rewired;
using Zenject;

namespace Restory.Gameplay.OverlayActivators
{
	public class NotepadActivator : WindowActivatorBase, IInitializable, IDisposable
	{
		private IPlayerInput playerInput;

		private GUI_NotepadWindow notepadWindow;

		private NotepadInteractiveWorkplaceItem notepadInteractiveWorkplaceItem;

		private GUI_PauseMenu pauseMenu;

		public override bool IsActivated => notepadWindow.IsVisible;

		[Inject]
		private void Construct(IPlayerInput playerInput, NotepadInteractiveWorkplaceItem notepadInteractiveWorkplaceItem, GUI_NotepadWindow notepadWindow, GUI_PauseMenu pauseMenu)
		{
			this.playerInput = playerInput;
			this.notepadInteractiveWorkplaceItem = notepadInteractiveWorkplaceItem;
			this.notepadWindow = notepadWindow;
			this.pauseMenu = pauseMenu;
		}

		public void Initialize()
		{
			playerInput.AddInputEventDelegate(ResolveInventoryButtonJustPressed, InputActionEventType.ButtonJustReleased, 90);
			notepadInteractiveWorkplaceItem.Trigger.OnClick += ResolveNotepadTriggerClick;
		}

		public void Dispose()
		{
			playerInput?.RemoveInputEventDelegate(ResolveInventoryButtonJustPressed, InputActionEventType.ButtonJustReleased, 90);
			notepadInteractiveWorkplaceItem.Trigger.OnClick -= ResolveNotepadTriggerClick;
		}

		public void HideWindow()
		{
			notepadWindow.Hide();
		}

		protected override void ResolveOnIsBlockedChanged(bool isBlocked)
		{
			notepadInteractiveWorkplaceItem.Trigger.Toggle(!isBlocked);
		}

		private void SwitchNotepad()
		{
			if (!base.IsBlocked && notepadInteractiveWorkplaceItem.IsActive)
			{
				if (notepadWindow.IsVisible)
				{
					notepadWindow.Hide();
				}
				else if (!pauseMenu.IsShown)
				{
					notepadWindow.Show();
				}
			}
		}

		private void ResolveNotepadTriggerClick()
		{
			SwitchNotepad();
		}

		private void ResolveInventoryButtonJustPressed(InputActionEventData eventData)
		{
			SwitchNotepad();
		}
	}
}
