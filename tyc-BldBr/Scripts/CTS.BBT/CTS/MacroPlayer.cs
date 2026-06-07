using System;
using CTS.DevConsole;
using UnityEngine;

namespace CTS
{
	public class MacroPlayer : MonoBehaviour
	{
		private static readonly Action<KeyCode, string> _updateMethod = EnumerateMacros;

		private void Update()
		{
			if (!UIUtility.InInputField())
			{
				CommandMacro.Macros.Enumerate(_updateMethod);
			}
		}

		private static void EnumerateMacros(KeyCode code, string command)
		{
			if (Input.GetKeyDown(code))
			{
				DeveloperConsole.ExecuteCommand(command);
			}
		}
	}
}
