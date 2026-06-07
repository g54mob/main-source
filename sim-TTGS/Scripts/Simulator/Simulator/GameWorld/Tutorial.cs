using System;
using System.Collections.Generic;
using Dhs5.Utility.Debuggers;

namespace Simulator.GameWorld
{
	public static class Tutorial
	{
		private static List<int> _seenTutorials = new List<int>();

		private static Tutorial_HUDPopupModule _module;

		private static Action _callback;

		public static TutorialData CurrentData { get; private set; }

		private static Tutorial_HUDPopupModule Module
		{
			get
			{
				if (_module == null)
				{
					World.HUDPopup.GetModule<Tutorial_HUDPopupModule>(EHUDPopupModuleType.TUTORIAL, out _module);
				}
				return _module;
			}
		}

		public static bool TryShow(TutorialData data, Action callback = null)
		{
			if (!CanShow(data))
			{
				callback?.Invoke();
				return false;
			}
			_callback = callback;
			Show(data);
			return true;
		}

		private static bool CanShow(TutorialData data)
		{
			if (data == null)
			{
				Debugger<EDebugCategory>.LogError(EDebugCategory.TUTORIAL, "Data is null");
				return false;
			}
			if (!GameplayApplicationOptions.Tutorial)
			{
				return false;
			}
			if (_seenTutorials.Contains(data.UID))
			{
				return false;
			}
			if (Module == null)
			{
				Debugger<EDebugCategory>.LogError(EDebugCategory.TUTORIAL, "Can't find Tutorial_HUDPopupModule");
				return false;
			}
			return true;
		}

		private static void Show(TutorialData data)
		{
			Module.Closing += OnModuleClosing;
			CurrentData = data;
			World.HUDPopup.Open(EHUDPopupModuleType.TUTORIAL);
			_seenTutorials.Add(data.UID);
			Debugger<EDebugCategory>.Log(EDebugCategory.TUTORIAL, $"Showing: {data.UID} - {data.TitleTerm}");
		}

		private static void OnModuleClosing()
		{
			Module.Closing -= OnModuleClosing;
			_callback?.Invoke();
			_callback = null;
			CurrentData = null;
		}

		public static void Save()
		{
			SaveManager.CurrentSave.tutorial.seenTutorials = new List<int>(_seenTutorials);
			_seenTutorials.Log(EDebugCategory.TUTORIAL, "Save", (int i) => i.ToString());
		}

		public static void Load()
		{
			_seenTutorials = new List<int>(SaveManager.CurrentSave.tutorial.seenTutorials);
			if (_seenTutorials.Count != 0)
			{
				_seenTutorials.Log(EDebugCategory.TUTORIAL, "Load", (int i) => i.ToString());
			}
		}

		public static void Clear()
		{
			_seenTutorials.Clear();
		}
	}
}
