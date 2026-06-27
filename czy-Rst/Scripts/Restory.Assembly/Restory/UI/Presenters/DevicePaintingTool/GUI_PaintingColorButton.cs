using System;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_PaintingColorButton : UIBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private Image baseColor;

		[SerializeField]
		private GUI_PresetSwitcher selectionPresetSwitcher;

		public event Action<GUI_PaintingColorButton> OnButtonClicked;

		protected override void OnEnable()
		{
			base.OnEnable();
			button.onClick.AddListener(ResolveClick);
		}

		protected override void OnDisable()
		{
			button.onClick.RemoveListener(ResolveClick);
			base.OnDisable();
		}

		public void AssignColor(Color newColor)
		{
			baseColor.color = newColor;
		}

		public void SwitchSelection(bool shouldBeSelected)
		{
			selectionPresetSwitcher.ActivatePreset((!shouldBeSelected) ? PresetName.Normal : PresetName.Selected);
		}

		private void ResolveClick()
		{
			this.OnButtonClicked?.Invoke(this);
		}
	}
}
