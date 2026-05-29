using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public abstract class ConsoleVarValue : ConsoleVar
	{
		public override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();
			SetDefaultValues();
		}

		public virtual void CopyFrom(ConsoleVarValue other)
		{
		}

		protected static EValidity CheckArgumentForDefault(ref DeveloperConsole.InputReport inputReport, string arg, int argIndex, EValidity correctTypeValidity)
		{
			arg = arg.ToLowerInvariant();
			if (!DeveloperConsole.ArgIsContainedIn(arg, "default", caseSensitive: false))
			{
				return correctTypeValidity;
			}
			inputReport.CommandMatches.Add("Default");
			EValidity val;
			if (arg == "default")
			{
				inputReport.CastedArguments.Insert(argIndex, "default");
				val = EValidity.Valid;
			}
			else
			{
				val = EValidity.Incomplete;
			}
			return (EValidity)Math.Max((int)val, (int)correctTypeValidity);
		}

		internal override bool IsArgumentIndexOutOfBounds(int argIndex)
		{
			if (argIndex >= 0)
			{
				return argIndex > 1;
			}
			return true;
		}
	}
	[Serializable]
	public abstract class ConsoleVarValue<T> : ConsoleVarValue where T : unmanaged
	{
		[SerializeField]
		protected T _defaultValue;

		protected T _currentValue;

		public static implicit operator T(ConsoleVarValue<T> cvar)
		{
			return cvar._currentValue;
		}

		public virtual void SetCurrentValue(T newValue)
		{
			if (!object.Equals(_currentValue, newValue))
			{
				_currentValue = newValue;
				TriggerValueChange();
			}
		}

		public override void SetDefaultValues()
		{
			SetCurrentValue(_defaultValue);
		}

		internal abstract bool TryParse(string arg, out T outValue);

		internal virtual string CurrentValueToString()
		{
			return _currentValue.ToString();
		}

		public override void Execute(string[] args)
		{
			if (args.Length == 0)
			{
				DeveloperConsole.Log("'" + base.ConsoleKey + "': " + CurrentValueToString());
				return;
			}
			if (args.Length != 1)
			{
				DeveloperConsole.LogError("'" + base.ConsoleKey + "' only accepts 1 enum argument");
				return;
			}
			string text = args[0];
			T outValue;
			if (text == "default" || text == "reset")
			{
				SetDefaultValues();
			}
			else if (TryParse(text, out outValue))
			{
				SetCurrentValue(outValue);
				DeveloperConsole.Log("Variable set to " + CurrentValueToString());
			}
			else
			{
				DeveloperConsole.LogError("Argument '" + text + "' isn't of type " + GetType().BaseType.GenericTypeArguments[0].Name);
			}
		}
	}
}
