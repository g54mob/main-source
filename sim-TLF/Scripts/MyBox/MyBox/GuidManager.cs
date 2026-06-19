using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyBox
{
	public class GuidManager
	{
		private struct GuidInfo
		{
			public GameObject GameObject;

			public event Action<GameObject> OnAdd;

			public event Action OnRemove;

			public GuidInfo(GuidComponent comp)
			{
				GameObject = comp.gameObject;
				this.OnRemove = null;
				this.OnAdd = null;
			}

			public void HandleAddCallback()
			{
				this.OnAdd?.Invoke(GameObject);
			}

			public void HandleRemoveCallback()
			{
				this.OnRemove?.Invoke();
			}
		}

		private static GuidManager _instance;

		private readonly Dictionary<Guid, GuidInfo> _guidToObjectMap = new Dictionary<Guid, GuidInfo>();

		private static GuidManager Instance => _instance ?? (_instance = new GuidManager());

		public static bool Add(GuidComponent guidComponent)
		{
			return Instance.InternalAdd(guidComponent);
		}

		public static void Remove(Guid guid)
		{
			Instance.InternalRemove(guid);
		}

		public static GameObject ResolveGuid(Guid guid, Action<GameObject> onAddCallback, Action onRemoveCallback)
		{
			return Instance.ResolveGuidInternal(guid, onAddCallback, onRemoveCallback);
		}

		public static GameObject ResolveGuid(Guid guid, Action onDestroyCallback)
		{
			return Instance.ResolveGuidInternal(guid, null, onDestroyCallback);
		}

		public static GameObject ResolveGuid(Guid guid)
		{
			return Instance.ResolveGuidInternal(guid, null, null);
		}

		private bool InternalAdd(GuidComponent guidComponent)
		{
			Guid guid = guidComponent.GetGuid();
			GuidInfo value = new GuidInfo(guidComponent);
			if (!_guidToObjectMap.ContainsKey(guid))
			{
				_guidToObjectMap.Add(guid, value);
				return true;
			}
			GuidInfo value2 = _guidToObjectMap[guid];
			if (value2.GameObject != null && value2.GameObject != guidComponent.gameObject)
			{
				if (!Application.isPlaying)
				{
					Debug.LogWarningFormat(guidComponent, "Guid Collision Detected while creating {0}.\nAssigning new Guid.", (guidComponent != null) ? guidComponent.name : "NULL");
				}
				return false;
			}
			value2.GameObject = value.GameObject;
			value2.HandleAddCallback();
			_guidToObjectMap[guid] = value2;
			return true;
		}

		private void InternalRemove(Guid guid)
		{
			if (_guidToObjectMap.TryGetValue(guid, out var value))
			{
				value.HandleRemoveCallback();
			}
			_guidToObjectMap.Remove(guid);
		}

		private GameObject ResolveGuidInternal(Guid guid, Action<GameObject> onAddCallback, Action onRemoveCallback)
		{
			if (_guidToObjectMap.TryGetValue(guid, out var value))
			{
				if (onAddCallback != null)
				{
					value.OnAdd += onAddCallback;
				}
				if (onRemoveCallback != null)
				{
					value.OnRemove += onRemoveCallback;
				}
				_guidToObjectMap[guid] = value;
				return value.GameObject;
			}
			if (onAddCallback != null)
			{
				value.OnAdd += onAddCallback;
			}
			if (onRemoveCallback != null)
			{
				value.OnRemove += onRemoveCallback;
			}
			_guidToObjectMap.Add(guid, value);
			return null;
		}
	}
}
