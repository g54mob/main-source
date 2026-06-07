using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/External/Toggle")]
	public class ExternalOptionToggle : ToggleOption
	{
		public Toggle.ToggleEvent onValueChange;

		protected override void ApplySetting(bool _value)
		{
		}
	}
}
