using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Console
{
	public static class Console
	{
		private const string PATH_CONSOLE_UI = "GameCreator/Console/Console";

		private const string MENU_ITEM_OPEN = "Game Creator/Console #%c";

		[field: NonSerialized]
		private static ConsoleUI ConsoleUI { get; set; }

		public static bool IsOpen
		{
			get
			{
				if (ConsoleUI != null)
				{
					return ConsoleUI.IsOpen;
				}
				return false;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitializeOnLoad()
		{
			ConsoleUI = null;
		}

		public static void Submit(Input input)
		{
			IEnumerable<Output> enumerable = Commands.Run(input);
			ConsoleUI consoleUI = RequestConsoleUI();
			foreach (Output item in enumerable)
			{
				consoleUI.Print(item);
			}
		}

		public static void Print(string text)
		{
			RequestConsoleUI().Print(text);
		}

		public static void Clear()
		{
			RequestConsoleUI().Clear();
		}

		public static void Open()
		{
			RequestConsoleUI().Open();
		}

		public static void Close()
		{
			if (!(ConsoleUI == null))
			{
				RequestConsoleUI().Close();
			}
		}

		public static void Toggle()
		{
			if (IsOpen)
			{
				Close();
			}
			else
			{
				Open();
			}
		}

		private static ConsoleUI RequestConsoleUI()
		{
			if (ConsoleUI == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("GameCreator/Console/Console"));
				Resources.UnloadUnusedAssets();
				ConsoleUI = gameObject.GetComponent<ConsoleUI>();
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
			return ConsoleUI;
		}
	}
}
