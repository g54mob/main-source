using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Button/Restore Defaults")]
	[RequireComponent(typeof(Button))]
	public class RestoreDefaultsButton : MonoBehaviour
	{
		public SliderOption[] sliders;

		public List<DropdownOption> dropdowns;

		public ToggleOption[] toggles;

		private List<OptionPreset> presets;

		private void Awake()
		{
		}

		public void RestoreDefaults()
		{
		}
	}
}
