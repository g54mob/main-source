using System.Collections.Generic;
using UnityEngine;

namespace RoslynCSharp.Modding
{
	public sealed class ModScriptReplacerReport
	{
		private List<string> replaceMessages = new List<string>();

		private List<string> replaceWarnings = new List<string>();

		private List<string> replaceErrors = new List<string>();

		public bool HasMessages => replaceMessages.Count > 0;

		public bool HasWarnings => replaceWarnings.Count > 0;

		public bool HasErrors => replaceErrors.Count > 0;

		public IReadOnlyList<string> Messages => replaceMessages;

		public IReadOnlyList<string> Warnings => replaceWarnings;

		public IReadOnlyList<string> Errors => replaceErrors;

		public void AddMessage(string message)
		{
			replaceMessages.Add(message);
		}

		public void AddMessageFormat(string messageFormat, params object[] args)
		{
			replaceMessages.Add(string.Format(messageFormat, args));
		}

		public void AddWarning(string warningMessage)
		{
			replaceWarnings.Add(warningMessage);
		}

		public void AddWarningFormat(string warningFormat, params object[] args)
		{
			replaceWarnings.Add(string.Format(warningFormat, args));
		}

		public void AddError(string errorMessage)
		{
			replaceErrors.Add(errorMessage);
		}

		public void AddErrorFormat(string errorFormat, params object[] args)
		{
			replaceErrors.Add(string.Format(errorFormat, args));
		}

		public void LogToConsole()
		{
			if (!HasWarnings && !HasErrors)
			{
				return;
			}
			Debug.Log("__Mod Script Replacer Report__");
			foreach (string replaceMessage in replaceMessages)
			{
				Debug.Log(replaceMessage);
			}
			foreach (string replaceWarning in replaceWarnings)
			{
				Debug.LogWarning(replaceWarning);
			}
			foreach (string replaceError in replaceErrors)
			{
				Debug.LogError(replaceError);
			}
		}
	}
}
