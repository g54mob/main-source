using System;
using System.Globalization;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public class CVarFloat : ConsoleVarValue<float>
	{
		internal CVarFloat()
		{
		}

		internal override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport report, string arg, int selfArgIndex, int realArgIndex)
		{
			if (selfArgIndex == 1)
			{
				EValidity correctTypeValidity = ConsoleCommand.CheckBasicTypeArgument(ref report, null, arg, realArgIndex, ConsoleCommand.EArgType.Float, isLastArg: true);
				return ConsoleVarValue.CheckArgumentForDefault(ref report, arg, realArgIndex, correctTypeValidity);
			}
			return EValidity.Invalid;
		}

		internal override bool TryParse(string arg, out float outValue)
		{
			return float.TryParse(arg, NumberStyles.Float, CultureInfo.InvariantCulture, out outValue);
		}
	}
}
