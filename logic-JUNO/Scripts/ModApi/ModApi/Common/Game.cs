using System;
using System.Reflection;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace ModApi.Common
{
	public static class Game
	{
		private static Func<Version> _getVersionField;

		private static IGame _instance;

		private static IGameLoopRegistrar _loop;

		public static bool InDesignerScene => Instance.SceneManager.InDesignerScene;

		public static bool InFlightScene => Instance.SceneManager.InFlightScene;

		public static bool InMenuScene => Instance.SceneManager.InMenuScene;

		public static bool InPlanetStudioScene => Instance.SceneManager.InPlanetStudioScene;

		public static IGame Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = LoadInstance();
				}
				return _instance;
			}
		}

		public static IGameLoopRegistrar Loop => _loop;

		public static string PersistentDataPath => Application.persistentDataPath;

		public static Version Version
		{
			get
			{
				if (_getVersionField == null)
				{
					Type type = Project.MainAssembly.GetType("Assets.Scripts.Game", throwOnError: true, ignoreCase: false);
					if (type == null)
					{
						Debug.LogError("The type 'Assets.Scripts.Game' could not be found.");
						return null;
					}
					FieldInfo versionField = type.GetField("Version", BindingFlags.Static | BindingFlags.Public);
					if (versionField == null)
					{
						Debug.LogError("The field 'Version' on type 'Assets.Scripts.Game' could not be found.");
						return null;
					}
					_getVersionField = () => (Version)versionField.GetValue(null);
				}
				return _getVersionField();
			}
		}

		private static void LoadGameLoopRegistrar(Type gameType)
		{
			PropertyInfo property = gameType.GetProperty("Loop", BindingFlags.Static | BindingFlags.Public);
			if (property == null)
			{
				Debug.LogError("The 'Loop' property on type 'Assets.Scripts.Game' could not be found");
				return;
			}
			object value = property.GetValue(null, null);
			if (value == null)
			{
				Debug.LogError("The game loop property could not be retrieved.");
			}
			else
			{
				_loop = (IGameLoopRegistrar)value;
			}
		}

		private static IGame LoadInstance()
		{
			Type type = Project.MainAssembly.GetType("Assets.Scripts.Game", throwOnError: true, ignoreCase: false);
			if (type == null)
			{
				Debug.LogError("The type 'Assets.Scripts.Game' could not be found.");
				return null;
			}
			PropertyInfo property = type.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public);
			if (property == null)
			{
				Debug.LogError("The 'Instance' property on type 'Assets.Scripts.Game' could not be found");
				return null;
			}
			object value = property.GetValue(null, null);
			if (value == null)
			{
				Debug.LogError("The game instance could not be retrieved.");
				return null;
			}
			LoadGameLoopRegistrar(type);
			return (IGame)value;
		}
	}
}
