using System;
using Restory.UserInterface.ElementPresets;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	[Serializable]
	public struct PresetSwitcherBlock
	{
		public static PresetSwitcherBlock DefaultBlock = new PresetSwitcherBlock
		{
			normalPresetName = PresetName.Normal,
			highlightedPresetName = PresetName.Highlighted,
			pressedPresetName = PresetName.Pressed,
			selectedPresetName = PresetName.Selected,
			disabledPresetName = PresetName.Disabled
		};

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPresetName;

		[SerializeField]
		private PresetName highlightedPresetName;

		[SerializeField]
		private PresetName pressedPresetName;

		[SerializeField]
		private PresetName selectedPresetName;

		[SerializeField]
		private PresetName disabledPresetName;

		public GUI_PresetSwitcher PresetSwitcher
		{
			get
			{
				return presetSwitcher;
			}
			set
			{
				presetSwitcher = value;
			}
		}

		public PresetName NormalPresetName
		{
			get
			{
				return normalPresetName;
			}
			set
			{
				normalPresetName = value;
			}
		}

		public PresetName HighlightedPresetName
		{
			get
			{
				return highlightedPresetName;
			}
			set
			{
				highlightedPresetName = value;
			}
		}

		public PresetName PressedPresetName
		{
			get
			{
				return pressedPresetName;
			}
			set
			{
				pressedPresetName = value;
			}
		}

		public PresetName SelectedPresetName
		{
			get
			{
				return selectedPresetName;
			}
			set
			{
				selectedPresetName = value;
			}
		}

		public PresetName DisabledPresetName
		{
			get
			{
				return disabledPresetName;
			}
			set
			{
				disabledPresetName = value;
			}
		}

		public void ActivatePreset(PresetName presetName, bool forceActivate = false)
		{
			PresetSwitcher.ActivatePreset(presetName, forceActivate);
		}
	}
}
