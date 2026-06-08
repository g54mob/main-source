using System;
using System.Collections.Generic;
using Kitchen.Modules;
using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	[CreateAssetMenu(fileName = "ModuleDirectory", menuName = "Kitchen/Module Directory", order = 1)]
	public class ModuleDirectory : KitchenObject
	{
		public static ModuleDirectory Main;

		[SerializeField]
		private Dictionary<Type, Element> DefaultModule = new Dictionary<Type, Element>();

		[SerializeField]
		private Dictionary<Font, TMP_FontAsset> Fonts = new Dictionary<Font, TMP_FontAsset>();

		public T GetPrefab<T>() where T : Element
		{
			if (DefaultModule.TryGetValue(typeof(T), out var value))
			{
				return (T)value;
			}
			return null;
		}

		public TMP_FontAsset Get(Font f)
		{
			return Fonts[f];
		}

		public static T Add<T>(Transform container, Vector2 position = default(Vector2)) where T : Element
		{
			T prefab = Main.GetPrefab<T>();
			Element element = null;
			if (prefab == null)
			{
				GameObject gameObject = new GameObject(typeof(T).Name);
				gameObject.transform.parent = container;
				element = gameObject.AddComponent<T>();
			}
			else
			{
				element = UnityEngine.Object.Instantiate(prefab, container, worldPositionStays: true);
			}
			Transform transform = element.transform;
			transform.Reset();
			transform.localPosition = position;
			element.Initialise();
			return (T)element;
		}

		private void AddModules(List<GameObject> prefabs)
		{
			foreach (GameObject prefab in prefabs)
			{
				Component componentInChildren = prefab.GetComponentInChildren(typeof(Element), includeInactive: true);
				if (componentInChildren != null && componentInChildren is Element element)
				{
					DefaultModule[element.GetType()] = element;
				}
			}
		}
	}
}
