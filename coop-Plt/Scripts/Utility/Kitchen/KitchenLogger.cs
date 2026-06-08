using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Kitchen
{
	public static class KitchenLogger
	{
		public static List<LogMessage> Messages = new List<LogMessage>();

		public static IEnumerable<LogMessage> LastMessages(int max = 10)
		{
			for (int i = 0; i < max; i++)
			{
				int num = Messages.Count - 1 - i;
				if (num >= 0)
				{
					yield return Messages[num];
					continue;
				}
				break;
			}
		}

		public static void Log(string message, [CallerMemberName] string member_name = "")
		{
			string callerType = GetCallerType();
			LogMessage logMessage = new LogMessage
			{
				Source = callerType + "." + member_name,
				Message = message
			};
			Messages.Add(logMessage);
			UnityEngine.Debug.LogWarning(logMessage);
		}

		private static string GetCallerType()
		{
			MethodBase method = new StackTrace().GetFrame(2).GetMethod();
			if (method.DeclaringType == null)
			{
				return "Unknown";
			}
			return method.DeclaringType.Name.Split('`')[0];
		}
	}
}
