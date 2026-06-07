using System;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
	public enum PrefabId
	{
		MarkerRangeHighlighter = 0
	}

	[Serializable]
	private class ManagedPrefab
	{
		[SerializeField]
		private PrefabId _id;

		[SerializeField]
		private GameObject _prefab;

		[NonSerialized]
		private GameObject _instance;

		[NonSerialized]
		private Component _component;

		public PrefabId Id => _id;

		public void Initialize()
		{
			_instance = UnityEngine.Object.Instantiate(_prefab);
			_instance.gameObject.SetActive(value: false);
		}

		public T GetInstance<T>() where T : Component
		{
			T val;
			if (!(_component == null))
			{
				val = _component as T;
				if ((object)val != null)
				{
					goto IL_003f;
				}
			}
			val = (T)(_component = _instance.GetComponent<T>());
			goto IL_003f;
			IL_003f:
			return val;
		}

		public bool TryGetInstance<T>(out T instance) where T : Component
		{
			instance = GetInstance<T>();
			return instance != null;
		}
	}

	[SerializeField]
	private ManagedPrefab[] _prefabs;

	public void Initialize()
	{
		ManagedPrefab[] prefabs = _prefabs;
		for (int i = 0; i < prefabs.Length; i++)
		{
			prefabs[i].Initialize();
		}
	}

	public bool TryGetInstance<T>(PrefabId id, out T instance) where T : Component
	{
		ManagedPrefab[] prefabs = _prefabs;
		foreach (ManagedPrefab managedPrefab in prefabs)
		{
			if (managedPrefab.Id == id && managedPrefab.TryGetInstance<T>(out instance))
			{
				return true;
			}
		}
		instance = null;
		return false;
	}
}
