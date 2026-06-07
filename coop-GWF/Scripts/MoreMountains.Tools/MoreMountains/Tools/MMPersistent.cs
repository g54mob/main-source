using System;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMPersistent : MMPersistentBase
	{
		[Serializable]
		public struct Data
		{
			public Vector3 Position;

			public Quaternion LocalRotation;

			public Vector3 LocalScale;

			public bool ActiveState;

			public List<ComponentData> ComponentEnabledStates;
		}

		[Serializable]
		public struct ComponentData
		{
			public string Name;

			public bool EnabledState;
		}

		[Header("Properties")]
		[Tooltip("whether or not to save this object's position")]
		public bool SavePosition = true;

		[Tooltip("whether or not to save this object's rotation")]
		public bool SaveLocalRotation = true;

		[Tooltip("whether or not to save this object's scale")]
		public bool SaveLocalScale = true;

		[Tooltip("whether or not to save this object's active state")]
		public bool SaveActiveState = true;

		[Tooltip("whether or not to save this object's components' enabled states")]
		public bool SaveEnabledStates;

		public override string OnSave()
		{
			List<ComponentData> componentEnabledStates = null;
			if (SaveEnabledStates)
			{
				componentEnabledStates = GetCurrentComponents();
			}
			return JsonUtility.ToJson(new Data
			{
				Position = base.transform.position,
				LocalRotation = base.transform.localRotation,
				LocalScale = base.transform.localScale,
				ActiveState = base.gameObject.activeSelf,
				ComponentEnabledStates = componentEnabledStates
			});
		}

		public override void OnLoad(string data)
		{
			if (SavePosition)
			{
				base.transform.position = JsonUtility.FromJson<Data>(data).Position;
			}
			if (SaveLocalRotation)
			{
				base.transform.localRotation = JsonUtility.FromJson<Data>(data).LocalRotation;
			}
			if (SaveLocalScale)
			{
				base.transform.localScale = JsonUtility.FromJson<Data>(data).LocalScale;
			}
			if (SaveActiveState)
			{
				base.gameObject.SetActive(JsonUtility.FromJson<Data>(data).ActiveState);
			}
			if (!SaveEnabledStates)
			{
				return;
			}
			List<ComponentData> componentEnabledStates = JsonUtility.FromJson<Data>(data).ComponentEnabledStates;
			Behaviour[] components = base.gameObject.GetComponents<Behaviour>();
			Renderer[] components2 = base.gameObject.GetComponents<Renderer>();
			if (componentEnabledStates.Count != components.Length + components2.Length)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < components.Length; i++)
			{
				if (componentEnabledStates[i].Name == components[i].name)
				{
					components[i].enabled = componentEnabledStates[i].EnabledState;
				}
				num++;
			}
			for (int j = 0; j < components2.Length; j++)
			{
				if (componentEnabledStates[num + j].Name == components2[j].name)
				{
					components2[j].enabled = componentEnabledStates[num + j].EnabledState;
				}
			}
		}

		protected virtual List<ComponentData> GetCurrentComponents()
		{
			List<ComponentData> list = new List<ComponentData>();
			Behaviour[] components = base.gameObject.GetComponents<Behaviour>();
			Renderer[] components2 = base.gameObject.GetComponents<Renderer>();
			Behaviour[] array = components;
			foreach (Behaviour behaviour in array)
			{
				list.Add(new ComponentData
				{
					Name = behaviour.name,
					EnabledState = behaviour.enabled
				});
			}
			Renderer[] array2 = components2;
			foreach (Renderer renderer in array2)
			{
				list.Add(new ComponentData
				{
					Name = renderer.name,
					EnabledState = renderer.enabled
				});
			}
			return list;
		}
	}
}
