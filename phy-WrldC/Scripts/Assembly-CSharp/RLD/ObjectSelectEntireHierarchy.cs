using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ObjectSelectEntireHierarchy : Singleton<ObjectSelectEntireHierarchy>
	{
		private bool _isActive;

		private bool _ignoreObjectGroups;

		public bool IgnoreObjectGroups
		{
			get
			{
				return _ignoreObjectGroups;
			}
			set
			{
				_ignoreObjectGroups = value;
			}
		}

		public void SetActive(bool isActive)
		{
			if (_isActive != isActive)
			{
				if (isActive)
				{
					_isActive = true;
					MonoSingleton<RTObjectSelection>.Get.PreSelectCustomize += OnPreSelectCustomize;
					MonoSingleton<RTObjectSelection>.Get.PreDeselectCustomize += OnPreDeselectCustomize;
				}
				else
				{
					_isActive = false;
					MonoSingleton<RTObjectSelection>.Get.PreSelectCustomize -= OnPreSelectCustomize;
					MonoSingleton<RTObjectSelection>.Get.PreDeselectCustomize -= OnPreDeselectCustomize;
				}
			}
		}

		private void OnPreSelectCustomize(ObjectPreSelectCustomizeInfo customizeInfo, List<GameObject> toBeSelected)
		{
			if (IgnoreObjectGroups)
			{
				List<GameObject> roots = GameObjectEx.GetRoots(toBeSelected);
				if (roots.Count == 0)
				{
					return;
				}
				List<GameObject> list = new List<GameObject>(roots.Count * 10);
				foreach (GameObject item in roots)
				{
					list.AddRange(item.GetAllChildrenAndSelf());
				}
				customizeInfo.SelectThese(list);
				return;
			}
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (GameObject item2 in toBeSelected)
			{
				if (MonoSingleton<RTObjectGroupDb>.Get.IsGroup(item2))
				{
					continue;
				}
				foreach (GameObject item3 in GetFurthestParentNotGroup(item2).gameObject.GetAllChildrenAndSelf())
				{
					hashSet.Add(item3);
				}
			}
			customizeInfo.SelectThese(hashSet);
		}

		private void OnPreDeselectCustomize(ObjectPreDeselectCustomizeInfo customizeInfo, List<GameObject> toBeDeselected)
		{
			if (IgnoreObjectGroups)
			{
				List<GameObject> roots = GameObjectEx.GetRoots(toBeDeselected);
				if (roots.Count == 0)
				{
					return;
				}
				List<GameObject> list = new List<GameObject>(roots.Count * 10);
				foreach (GameObject item in roots)
				{
					list.AddRange(item.GetAllChildrenAndSelf());
				}
				customizeInfo.DeselectThese(list);
				return;
			}
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (GameObject item2 in toBeDeselected)
			{
				if (MonoSingleton<RTObjectGroupDb>.Get.IsGroup(item2))
				{
					continue;
				}
				foreach (GameObject item3 in GetFurthestParentNotGroup(item2).gameObject.GetAllChildrenAndSelf())
				{
					hashSet.Add(item3);
				}
			}
			customizeInfo.DeselectThese(hashSet);
		}

		private Transform GetFurthestParentNotGroup(GameObject gameObj)
		{
			Transform transform = gameObj.transform;
			while (true)
			{
				Transform parent = transform.parent;
				if (parent == null || MonoSingleton<RTObjectGroupDb>.Get.IsGroup(parent.gameObject))
				{
					break;
				}
				transform = parent;
			}
			return transform;
		}
	}
}
