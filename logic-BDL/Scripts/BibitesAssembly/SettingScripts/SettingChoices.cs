using System;
using System.Collections.Generic;
using System.Linq;

namespace SettingScripts
{
	public class SettingChoices<TEnum> where TEnum : struct, Enum
	{
		public List<SettingChoice<TEnum>> choices;

		public SettingChoice<TEnum> this[int index] => choices[index];

		public SettingChoices(List<SettingChoice<TEnum>> initChoices)
		{
			choices = initChoices;
		}

		public SettingChoices()
		{
		}

		public SettingChoice<TEnum> ChoiceOfVal(TEnum val)
		{
			if (choices == null || choices.Count < 1)
			{
				return null;
			}
			return choices.FirstOrDefault((SettingChoice<TEnum> c) => c.val.Equals(val));
		}

		public int IndexOfValue(TEnum val)
		{
			if (choices == null || choices.Count < 1)
			{
				return -1;
			}
			return choices.FindIndex((SettingChoice<TEnum> c) => c.val.Equals(val));
		}
	}
}
