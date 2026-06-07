using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[RequireComponent(typeof(Toggle))]
	public abstract class ToggleOption : OptionBase<bool, BoolToggle>
	{
		protected Toggle toggle;

		public override bool Value
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected void OnValueChange(bool _value)
		{
		}
	}
}
