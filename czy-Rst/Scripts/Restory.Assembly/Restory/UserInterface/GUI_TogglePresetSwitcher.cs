using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface
{
	public sealed class GUI_TogglePresetSwitcher : GUI_SelectablePresetSwitcherBase
	{
		[SerializeField]
		private PresetSwitcherBlock switcherBlock = PresetSwitcherBlock.DefaultBlock;

		[SerializeField]
		private PresetSwitcherBlock switcherBlockIsOn = PresetSwitcherBlock.DefaultBlock;

		[SerializeField]
		private Toggle toggle;

		private bool isOn;

		protected override void OnEnable()
		{
			base.OnEnable();
			toggle.onValueChanged.AddListener(ToggleOnValueChangedResolve);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			toggle.onValueChanged.RemoveListener(ToggleOnValueChangedResolve);
		}

		protected override void Update()
		{
			base.Update();
			CheckIsOn();
		}

		protected override void CheckInteractable()
		{
			SetInteractableState(toggle.interactable);
		}

		private void CheckIsOn()
		{
			if (isOn != toggle.isOn)
			{
				isOn = toggle.isOn;
				UpdateVisuals();
			}
		}

		public override void UpdateVisuals(bool instantly = false)
		{
			if (isOn)
			{
				UpdateVisuals(ref switcherBlockIsOn);
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
