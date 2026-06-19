using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace OUSystems.Cheats.Commands
{
	public class DeveloperConsoleManager : MonoBehaviour
	{
		public static List<string> Logs;

		public static List<string> InputHistory;

		public DevCommandManager Commands;

		public static DeveloperConsoleManager Instance { get; private set; }

		public static event Action<string> AnnounceNewLog
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Initiate(DevCommandManager commands)
		{
		}

		public void Clear()
		{
		}

		public static void Log(string log = "")
		{
		}

		public static void Input(string input)
		{
		}
	}
}
