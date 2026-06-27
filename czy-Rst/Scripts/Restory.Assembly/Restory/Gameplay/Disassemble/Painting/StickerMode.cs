using Restory.Gameplay.GameCursor;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.UserInterface.DeviceCustomizations;
using Restory.UI.Presenters.DevicePaintingTool;
using UnityEngine;

namespace Restory.Gameplay.Disassemble.Painting
{
	public class StickerMode : IPaintingMode
	{
		private readonly IPlayerInput playerInput;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly CursorSelectionService cursorSelectionService;

		private GUI_DeviceSticker selectedSticker;

		private bool IsExecuteButtonPressed => playerInput.GetButton(71);

		public StickerMode(IPlayerInput playerInput, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, GUI_DeviceCustomizationPanel deviceCustomizationPanel)
		{
			this.playerInput = playerInput;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
		}

		public void Enter()
		{
		}

		public void OnUpdate(float deltaTime)
		{
			Vector2 mousePosition = playerInput.GetMousePosition();
			GameObject hitObject;
			if (IsExecuteButtonPressed)
			{
				if ((bool)selectedSticker)
				{
					selectedSticker.Drag(mousePosition, deltaTime);
				}
			}
			else if (!cursorDetectorService.UIDetector.TryToDetect(mousePosition, out hitObject))
			{
				if ((bool)selectedSticker)
				{
					selectedSticker = null;
				}
			}
			else if (!(cursorSelectionService.DetectedGameObject == hitObject))
			{
				cursorSelectionService.SetDetection(hitObject);
				hitObject.TryGetComponent<GUI_DeviceSticker>(out selectedSticker);
			}
		}

		public void PressExecuteButton()
		{
			StartDragSelectedSticker();
		}

		public void ReleaseExecuteButton()
		{
			ResetSelectedSticker();
		}

		public void Redo()
		{
		}

		public void Undo()
		{
		}

		public void Exit()
		{
			ResetSelectedSticker();
		}

		private void StartDragSelectedSticker()
		{
			if ((bool)selectedSticker)
			{
				selectedSticker.StartDrag();
			}
		}

		private void ResetSelectedSticker()
		{
			if ((bool)selectedSticker)
			{
				selectedSticker.StopDrag();
				selectedSticker = null;
				cursorSelectionService.ClearDetection();
			}
		}
	}
}
