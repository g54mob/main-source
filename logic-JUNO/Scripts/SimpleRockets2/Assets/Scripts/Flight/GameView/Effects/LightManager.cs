using System.Collections.Generic;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Flight.GameView.Effects
{
	public static class LightManager
	{
		private static bool _initialized;

		private static LinkedList<(int Id, Light Light)> _list;

		private static int _maxLights;

		static LightManager()
		{
			_list = new LinkedList<(int, Light)>();
			_maxLights = int.MaxValue;
			SceneManager.sceneUnloaded += delegate
			{
				_list.Clear();
			};
		}

		public static void RegisterActiveLight(Light light)
		{
			if (!_initialized)
			{
				Initialize();
			}
			_list.AddFirst((light.GetInstanceID(), light));
			UpdateLights();
		}

		public static void UnregisterActiveLight(Light light)
		{
			if (!_initialized)
			{
				return;
			}
			int instanceID = light.GetInstanceID();
			for (LinkedListNode<(int, Light)> linkedListNode = _list.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (linkedListNode.Value.Item1 == instanceID)
				{
					linkedListNode.Value.Item2.enabled = false;
					_list.Remove(linkedListNode);
					UpdateLights();
					break;
				}
			}
		}

		private static void Initialize()
		{
			_initialized = true;
			EnumSetting<CraftQualitySettings.MaxCraftLights> craftLightsLimit = Game.Instance.Settings.Quality.Crafts.CraftLightsLimit;
			craftLightsLimit.Changed += OnCraftLightsLimitChanged;
			OnCraftLightsLimitChanged(null, new SettingChangedEventArgs<CraftQualitySettings.MaxCraftLights>(craftLightsLimit));
		}

		private static void OnCraftLightsLimitChanged(object sender, SettingChangedEventArgs<CraftQualitySettings.MaxCraftLights> e)
		{
			_maxLights = (int)e.Setting.Value;
			UpdateLights();
		}

		private static void UpdateLights()
		{
			int num = 0;
			LinkedListNode<(int, Light)> linkedListNode = _list.First;
			while (linkedListNode != null)
			{
				linkedListNode.Value.Item2.enabled = num < _maxLights;
				linkedListNode = linkedListNode.Next;
				num++;
			}
		}
	}
}
