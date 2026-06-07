using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Scenes.Events;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.State
{
	public static class ApplicationState
	{
		private static XAttribute _appSuspended;

		private static XAttribute _currentActivity;

		private static string _filePath;

		private static XAttribute _gameStateType;

		private static List<string> _tasks;

		private static XAttribute _taskStack;

		private static XDocument _xml;

		public static bool AppSuspended
		{
			get
			{
				return (bool?)_appSuspended == true;
			}
			set
			{
				_appSuspended.SetValue(value);
				_xml.Save(_filePath);
			}
		}

		public static bool CrashDetectedOnPreviousRun { get; private set; }

		public static string CurrentActivity
		{
			get
			{
				return (string)_currentActivity;
			}
			set
			{
				_currentActivity.SetValue(value);
				_xml.Save(_filePath);
			}
		}

		public static bool DesignInProgress
		{
			get
			{
				return (string)_currentActivity == "Design";
			}
			set
			{
				CurrentActivity = (value ? "Design" : string.Empty);
			}
		}

		public static bool FlightInProgress
		{
			get
			{
				return (string)_currentActivity == "Flight";
			}
			set
			{
				CurrentActivity = (value ? "Flight" : string.Empty);
			}
		}

		public static GameStateType GameStateType
		{
			get
			{
				return _gameStateType.GetEnumAttribute(GameStateType.Default);
			}
			set
			{
				_gameStateType.SetValue(value);
				_xml.Save(_filePath);
			}
		}

		public static void ClearState()
		{
			CrashDetectedOnPreviousRun = false;
			_currentActivity.SetValue(string.Empty);
			_appSuspended.SetValue(false);
			_taskStack.SetValue(string.Empty);
			_gameStateType.SetValue(GameStateType.Default);
			_xml.Save(_filePath);
		}

		public static void ClearTasks()
		{
			_tasks.Clear();
		}

		public static void Initialize()
		{
			_filePath = Path.Combine(GameData.PersistentDataPath, "ApplicationState.xml");
			if (File.Exists(_filePath))
			{
				try
				{
					_xml = XDocument.Load(_filePath);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			if (_xml == null)
			{
				_xml = new XDocument(new XElement("ApplicationState"));
			}
			_currentActivity = _xml.Root.Attribute("currentActivity");
			if (_currentActivity == null)
			{
				_xml.Root.SetAttributeValue("currentActivity", string.Empty);
				_currentActivity = _xml.Root.Attribute("currentActivity");
			}
			_appSuspended = _xml.Root.Attribute("appSuspended");
			if (_appSuspended == null)
			{
				_xml.Root.SetAttributeValue("appSuspended", false);
				_appSuspended = _xml.Root.Attribute("appSuspended");
			}
			_gameStateType = _xml.Root.Attribute("gameStateType");
			if (_gameStateType == null)
			{
				_xml.Root.SetAttributeValue("gameStateType", GameStateType.Default);
				_gameStateType = _xml.Root.Attribute("gameStateType");
			}
			_tasks = new List<string>();
			_taskStack = _xml.Root.Attribute("taskStack");
			if (_taskStack == null)
			{
				_xml.Root.SetAttributeValue("taskStack", string.Empty);
				_taskStack = _xml.Root.Attribute("taskStack");
			}
			else
			{
				string text = (string)_taskStack;
				if (!string.IsNullOrWhiteSpace(text))
				{
					Debug.LogError("A crash was detected on the previous run. Task stack: " + text);
					CrashDetectedOnPreviousRun = true;
				}
				_taskStack.SetValue(string.Empty);
			}
			Game.Instance.SceneManager.SceneUnloading += OnSceneUnloading;
		}

		public static void PopTask(string task)
		{
			for (int num = _tasks.Count - 1; num >= 0; num--)
			{
				if (_tasks[num] == task)
				{
					_tasks.RemoveAt(num);
					SaveTasks();
					return;
				}
			}
			Debug.LogError("Unable to pop task '" + task + "' because it could not be found anywhere in the stack.");
		}

		public static void PushTask(string task)
		{
			_tasks.Add(task);
			SaveTasks();
		}

		private static void OnSceneUnloading(object sender, SceneEventArgs e)
		{
			string scene = e.Scene;
			if (!(scene == "Flight"))
			{
				if (scene == "Design")
				{
					DesignInProgress = false;
				}
			}
			else
			{
				FlightInProgress = false;
			}
		}

		private static void SaveTasks()
		{
			string value = string.Join(" -> ", _tasks);
			_taskStack.SetValue(value);
			_xml.Save(_filePath);
		}
	}
}
