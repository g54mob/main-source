using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class RoomManager : Singleton<RoomManager>
	{
		private class Events : Dictionary<int, List<Action>>
		{
		}

		[NonSerialized]
		private readonly Events m_Events = new Events();

		protected override void OnCreate()
		{
			base.OnCreate();
			SceneManager.sceneLoaded += OnLoadScene;
		}

		private void OnLoadScene(Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
		{
			int buildIndex = scene.buildIndex;
			if (!m_Events.TryGetValue(buildIndex, out var value))
			{
				return;
			}
			foreach (Action item in value)
			{
				item();
			}
			m_Events.Remove(buildIndex);
		}

		public void Subscribe(int scene, Action action)
		{
			if (!m_Events.TryGetValue(scene, out var value))
			{
				value = new List<Action>();
				m_Events.Add(scene, value);
			}
			value.Add(action);
		}
	}
}
