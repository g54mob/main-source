using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Restory.Gameplay.Dialogue.LuaWrappers
{
	public class LuaWrapperTemplate
	{
		private static class LuaNames
		{
			public static readonly string NoArgumentsReturnVoid = "TEST_NoArgumentsReturnVoid";

			public static readonly string SingleArgumentReturnVoid = "TEST_SingleArgumentReturnVoid";

			public static readonly string MultipleArgumentsReturnVoid = "TEST_MultipleArgumentsReturnVoid";

			public static readonly string NoArgumentsReturnBool = "TEST_NoArgumentsReturnBool";

			public static readonly string SingleArgumentReturnNumber = "TEST_SingleArgumentReturnNumber";

			public static readonly string MultipleArgumentsReturnBool = "TEST_MultipleArgumentsReturnBool";

			public static readonly string MultipleArgumentsReturnNumber = "TEST_MultipleArgumentsReturnNumber";
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.NoArgumentsReturnVoid, this, SymbolExtensions.GetMethodInfo(() => DoNoArgumentsMethod()));
			Lua.RegisterFunction(LuaNames.SingleArgumentReturnVoid, this, SymbolExtensions.GetMethodInfo(() => DoSingleArgumentMethod(string.Empty)));
			Lua.RegisterFunction(LuaNames.MultipleArgumentsReturnVoid, this, SymbolExtensions.GetMethodInfo(() => DoMultipleArgumentsMethod(string.Empty, 0f)));
			Lua.RegisterFunction(LuaNames.NoArgumentsReturnBool, this, SymbolExtensions.GetMethodInfo(() => GetBoolFromNoArgumentsMethod()));
			Lua.RegisterFunction(LuaNames.SingleArgumentReturnNumber, this, SymbolExtensions.GetMethodInfo(() => GetNumberFromSingleArgumentMethod(0f)));
			Lua.RegisterFunction(LuaNames.MultipleArgumentsReturnBool, this, SymbolExtensions.GetMethodInfo(() => GetBoolFromMultipleArgumentsMethod(string.Empty, 123f)));
			Lua.RegisterFunction(LuaNames.MultipleArgumentsReturnNumber, this, SymbolExtensions.GetMethodInfo((string name) => GetNumberFromMultipleArguments(name, argument2: false, argument3: false)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.NoArgumentsReturnVoid);
			Lua.UnregisterFunction(LuaNames.SingleArgumentReturnVoid);
			Lua.UnregisterFunction(LuaNames.MultipleArgumentsReturnVoid);
			Lua.UnregisterFunction(LuaNames.NoArgumentsReturnBool);
			Lua.UnregisterFunction(LuaNames.SingleArgumentReturnNumber);
			Lua.UnregisterFunction(LuaNames.MultipleArgumentsReturnBool);
			Lua.UnregisterFunction(LuaNames.MultipleArgumentsReturnNumber);
		}

		private void DoNoArgumentsMethod()
		{
			Debug.Log("[DoNoArgumentsMethod] successfully called from Dialogue System.");
		}

		private bool GetBoolFromNoArgumentsMethod()
		{
			Debug.Log("[GetBoolFromNoArgumentsMethod] successfully called from Dialogue System.");
			return true;
		}

		private int GetNumberFromSingleArgumentMethod(float argument)
		{
			Debug.Log(string.Format("[{0}] successfully called from Dialogue System. Argument value is '{1}'.", "GetNumberFromSingleArgumentMethod", argument));
			return (int)argument * 10;
		}

		private void DoSingleArgumentMethod(string argument)
		{
			Debug.Log("[DoSingleArgumentMethod] successfully called from Dialogue System. Argument value is '" + argument + "'.");
		}

		private void DoMultipleArgumentsMethod(string argument1, float argument2)
		{
			Debug.Log(string.Format("[{0}] successfully called from Dialogue System. Argument values are '{1}' and '{2}'.", "DoMultipleArgumentsMethod", argument1, argument2));
		}

		private bool GetBoolFromMultipleArgumentsMethod(string argument1, float argument2)
		{
			Debug.Log(string.Format("[{0}] successfully called from Dialogue System. Argument values are '{1}' and '{2}'.", "GetBoolFromMultipleArgumentsMethod", argument1, argument2));
			if (!string.IsNullOrEmpty(argument1))
			{
				return argument2 > 0f;
			}
			return false;
		}

		private float GetNumberFromMultipleArguments(string argument1, bool argument2, bool argument3)
		{
			Debug.Log(string.Format("[{0}] successfully called from Dialogue System. Argument values are '{1}', '{2}' and '{3}'.", "GetBoolFromMultipleArgumentsMethod", argument1, argument2, argument3));
			return 9000f;
		}
	}
}
