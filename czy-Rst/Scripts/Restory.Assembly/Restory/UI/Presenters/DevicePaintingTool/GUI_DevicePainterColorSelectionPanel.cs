using System;
using System.Collections.Generic;
using ModestTree;
using Restory.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_DevicePainterColorSelectionPanel : MonoBehaviour, IKeyDownHandler, IEventSystemHandler
	{
		private static readonly int[] ColorSelectionInputData = new int[9] { 57, 58, 59, 60, 61, 62, 63, 64, 65 };

		[SerializeField]
		private GUI_PaintingColorButton[] colorButtons = new GUI_PaintingColorButton[0];

		private GUI_RewiredPanelInputModule inputModule;

		private int currentlySelectedColorIndex;

		public int CurrentlySelectedColorIndex => currentlySelectedColorIndex;

		public event Action<int> OnColorSelectionChangeRequested;

		[Inject]
		private void Construct(GUI_RewiredPanelInputModule inputModule)
		{
			this.inputModule = inputModule;
		}

		protected void OnDisable()
		{
			UnsubscribeButtons();
			if (inputModule.MonoShellExists())
			{
				inputModule.RemoveSelectedPanel(base.gameObject);
			}
		}

		public void Show()
		{
			SubscribeButtons();
			inputModule.AddSelectedPanel(base.gameObject);
		}

		public void Hide()
		{
			UnsubscribeButtons();
			inputModule.RemoveSelectedPanel(base.gameObject);
		}

		public void OnKeyDown(KeyEventData eventData)
		{
			int num = ColorSelectionInputData.IndexOf(eventData.ActionId);
			if (num >= 0 && num < ColorSelectionInputData.Length)
			{
				ResolveColorButtonClicked(colorButtons[num]);
			}
		}

		public void ChangeColorsOfButtons(IReadOnlyList<Color> newColors)
		{
			for (int i = 0; i < colorButtons.Length; i++)
			{
				if (i < newColors.Count)
				{
					colorButtons[i].gameObject.SetActive(value: true);
					colorButtons[i].AssignColor(newColors[i]);
				}
				else
				{
					colorButtons[i].gameObject.SetActive(value: false);
				}
			}
		}

		public void SelectDefaultColor()
		{
			bool flag = false;
			GUI_PaintingColorButton[] array = colorButtons;
			foreach (GUI_PaintingColorButton gUI_PaintingColorButton in array)
			{
				if ((bool)gUI_PaintingColorButton)
				{
					gUI_PaintingColorButton.SwitchSelection(!flag);
					flag = true;
				}
			}
		}

		private void RequestSelectingDefaultColor()
		{
			for (int i = 0; i < colorButtons.Length; i++)
			{
				if ((bool)colorButtons[i])
				{
					this.OnColorSelectionChangeRequested?.Invoke(i);
				}
			}
			Debug.LogError("[GUI_DevicePainterColorSelectionPanel] tried to request default button to be selected, but there are no valid buttons set!");
		}

		public void SetColorSelection(int colorButtonIndex)
		{
			if (colorButtonIndex < 0 || colorButtonIndex >= colorButtons.Length || !colorButtons[colorButtonIndex])
			{
				Debug.LogError(string.Format("[{0}] tried to set button with index {1} ", "GUI_DevicePainterColorSelectionPanel", colorButtonIndex) + "as selected, but there is no button with that index! Falling back to selecting default button.");
				RequestSelectingDefaultColor();
				return;
			}
			for (int i = 0; i < colorButtons.Length; i++)
			{
				colorButtons[i].SwitchSelection(i == colorButtonIndex);
			}
			currentlySelectedColorIndex = colorButtonIndex;
		}

		private void SubscribeButtons()
		{
			GUI_PaintingColorButton[] array = colorButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnButtonClicked += ResolveColorButtonClicked;
			}
		}

		private void UnsubscribeButtons()
		{
			GUI_PaintingColorButton[] array = colorButtons;
			foreach (GUI_PaintingColorButton gUI_PaintingColorButton in array)
			{
				if ((bool)gUI_PaintingColorButton)
				{
					gUI_PaintingColorButton.OnButtonClicked -= ResolveColorButtonClicked;
				}
			}
		}

		private void ResolveColorButtonClicked(GUI_PaintingColorButton clickedButton)
		{
			for (int i = 0; i < colorButtons.Length; i++)
			{
				if ((bool)colorButtons[i] && !(colorButtons[i] != clickedButton))
				{
					this.OnColorSelectionChangeRequested?.Invoke(i);
				}
			}
		}
	}
}
