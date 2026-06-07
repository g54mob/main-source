using System;
using System.Collections.Generic;
using System.Linq;

namespace SettingScripts
{
	public abstract class EnumSetting<TEnum> : Setting<TEnum> where TEnum : struct, Enum
	{
		public SettingChoices<TEnum> choices;

		public bool hasChoices
		{
			get
			{
				if (choices != null && choices.choices != null)
				{
					return choices.choices.Count > 0;
				}
				return false;
			}
		}

		public string valLabel
		{
			get
			{
				if (!hasChoices)
				{
					return val.ToString();
				}
				return choices.choices.FirstOrDefault((SettingChoice<TEnum> c) => EqualityComparer<TEnum>.Default.Equals(c.val, val))?.label ?? val.ToString();
			}
		}

		protected EnumSetting(SettingChoices<TEnum> baseChoices)
		{
			choices = baseChoices;
		}

		public EnumSetting()
		{
		}
	}
}
