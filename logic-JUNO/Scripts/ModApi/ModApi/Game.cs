using System;
using System.Reflection;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace ModApi
{
	internal static class Game
	{
		private static IGame _instance;

		private static IGameLoopRegistrar _loop;

		public static bool InDesignerScene => Instance.SceneManager?.InDesignerScene ?? false;

		public static bool InFlightScene => Instance.SceneManager?.InFlightScene ?? false;

		public static bool InMenuScene => Instance.SceneManager?.InMenuScene ?? false;

		public static bool InPlanetStudioScene => Instance.SceneManager?.InPlanetStudioScene ?? false;

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
