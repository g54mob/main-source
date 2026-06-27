using Restory.UserInterface;
using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UI.Views
{
	public sealed class GUI_ToggleButtonPresetSwitcher : GUI_SelectablePresetSwitcherBase
	{
		[SerializeField]
		private PresetSwitcherBlock switcherBlock = PresetSwitcherBlock.DefaultBlock;

		[SerializeField]
		private PresetSwitcherBlock switcherBlockIsSelected = PresetSwitcherBlock.DefaultBlock;

		[SerializeField]
		private ToggleButton toggleButton;

		protected override void OnEnable()
		{
			base.OnEnable();
			toggleButton.IsSelectedChanged += ToggleOnValueChangedResolve;
			UpdateVisuals(instantly: true);
		}

		protected override void OnDisable()
		{
			toggleButton.IsSelectedChanged -= ToggleOnValueChangedResolve;
			base.OnDisable();
		}

		protected override void CheckInteractable()
		{
			SetInteractableState(toggleButton.interactable);
		}

		public override void UpdateVisuals(bool instantly = false)
		{
			if (toggleButton.IsSelected)
			{
				UpdateVisuals(ref switcherBlockIsSelected);
			}
			else
			{
				UpdateVisuals(ref switcherBlock);
			}
		}

		private void UpdateVisuals(ref PresetSwitcherBlock switcherBlock, bool instantly = false)
		{
			if (!isInteractable)
			{
				switcherBlock.ActivatePreset(switcherBlock.DisabledPresetName, instantly);
			}
			else if (isPointerDown)
			{
				switcherBlock.ActivatePreset(switcherBlock.PressedPresetName, instantly);
			}
			else if (HasSelection)
			{
				switcherBlock.ActivatePreset(switcherBlock.SelectedPresetName, instantly);
			}
			else if (IsPointerInside)
			{
				switcherBlock.ActivatePreset(switcherBlock.HighlightedPresetName, instantly);
			}
			else
			{
				switcherBlock.ActivatePreset(switcherBlock.NormalPresetName, instantly);
			}
		}

		private void ToggleOnValueChangedResolve(bool isOn)
		{
			UpdateVisuals();
		}
	}
}
