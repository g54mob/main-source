using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface
{
	public class GUI_SelectablePresetSwitcher : GUI_SelectablePresetSwitcherBase
	{
		[SerializeField]
		private PresetSwitcherBlock switcherBlock = PresetSwitcherBlock.DefaultBlock;

		[SerializeField]
		private Selectable selectable;

		protected override void CheckInteractable()
		{
			SetInteractableState(selectable.interactable);
		}

		public override void UpdateVisuals(bool instantly = false)
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
	}
}
