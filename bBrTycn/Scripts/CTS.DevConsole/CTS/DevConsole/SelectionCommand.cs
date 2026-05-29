using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CTS.DevConsole
{
	public abstract class SelectionCommand<TSelectionType> : ConsoleCommand where TSelectionType : Component
	{
		private TSelectionType _currentSelected;

		protected virtual bool CanSearchObjectInSceneIfNothingSelected { get; } = true;

		protected sealed override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (ConsoleCommand.TryGetSelectedObject(typeof(TSelectionType), out var component, CanSearchObjectInSceneIfNothingSelected))
			{
				_currentSelected = (TSelectionType)component;
				RunCommandOnSelection(_currentSelected, args, rawArgs);
			}
			else
			{
				DeveloperConsole.LogError("Nothing is selected...");
			}
		}

		protected abstract void RunCommandOnSelection(TSelectionType selection, List<object> args, string[] rawArgs);

		protected void InvokeOnSelection(string methodName)
		{
			MethodInfo method = typeof(TSelectionType).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if ((object)method == null)
			{
				Debug.LogError("Method " + methodName + " not found");
			}
			else
			{
				method.Invoke(_currentSelected, new object[0]);
			}
		}
	}
}
