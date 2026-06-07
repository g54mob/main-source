using System;

namespace SettingScripts
{
	public class SettingChoice<TEnum> where TEnum : struct, Enum
	{
		public TEnum val;

		public string label;

		public string tooltipText;

		public SettingChoice(TEnum enumVal, string title, string tooltip)
		{
			val = enumVal;
			label = title;
			tooltipText = tooltip;
		}
	}
}
