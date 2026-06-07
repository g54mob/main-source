using System;

namespace SettingScripts
{
	[Serializable]
	public class ChoiceSetting<TEnum> : EnumSimulationSetting<TEnum> where TEnum : struct, Enum
	{
		public ChoiceSetting(SettingChoices<TEnum> baseChoices)
			: base(baseChoices)
		{
		}

		public ChoiceSetting()
		{
		}
	}
}
