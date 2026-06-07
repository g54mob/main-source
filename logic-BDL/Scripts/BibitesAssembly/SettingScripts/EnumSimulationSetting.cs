using System;
using UnityEngine;

namespace SettingScripts
{
	public abstract class EnumSimulationSetting<TEnum> : EnumSetting<TEnum> where TEnum : struct, Enum
	{
		[SerializeField]
		private TEnum Value;

		public override TEnum val
		{
			get
			{
				return Value;
			}
			set
			{
				Value = value;
			}
		}

		protected EnumSimulationSetting(SettingChoices<TEnum> baseChoices)
			: base(baseChoices)
		{
		}

		protected EnumSimulationSetting()
		{
		}
	}
}
