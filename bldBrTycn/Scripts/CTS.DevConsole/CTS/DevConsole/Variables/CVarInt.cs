using System;
using System.Globalization;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public class CVarInt : ConsoleVarValue<int>
	{
		internal CVarInt()
		{
		}

		internal override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport report, string arg, int selfArgIndex, int realArgIndex)
		{
			if (selfArgIndex == 1)
			{
				EValidity correctTypeValidity = ConsoleCommand.CheckBasicTypeArgument(ref report, null, arg, realArgIndex, ConsoleCommand.EArgType.Int, isLastArg: true);
				return ConsoleVarValue.CheckArgumentForDefault(ref report, arg, realArgIndex, correctTypeValidity);
			}
			return EValidity.Invalid;
		}

		internal override bool TryParse(string arg, out int outValue)
		{
			return int.TryParse(arg, NumberStyles.Integer, CultureInfo.InvariantCulture, out outValue);
		}
	}
}
