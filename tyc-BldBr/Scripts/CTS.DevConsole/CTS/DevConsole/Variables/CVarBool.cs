using System;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public sealed class CVarBool : ConsoleVarValue<bool>
	{
		internal CVarBool()
		{
		}

		public override string ToString()
		{
			return _currentValue.ToString();
		}

		internal override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport inputReport, string arg, int selfArgIndex, int realArgIndex)
		{
			if (selfArgIndex == 1)
			{
				EValidity correctTypeValidity = ConsoleCommand.CheckBasicTypeArgument(ref inputReport, null, arg, realArgIndex, ConsoleCommand.EArgType.Bool, isLastArg: true);
				return ConsoleVarValue.CheckArgumentForDefault(ref inputReport, arg, realArgIndex, correctTypeValidity);
			}
			return EValidity.Invalid;
		}

		internal override bool TryParse(string arg, out bool outValue)
		{
			arg = arg.ToLowerInvariant();
			switch (arg)
			{
			case "1":
			case "true":
				outValue = true;
				return true;
			case "0":
			case "false":
				outValue = false;
				return true;
			default:
				outValue = false;
				return false;
			}
		}
	}
}
