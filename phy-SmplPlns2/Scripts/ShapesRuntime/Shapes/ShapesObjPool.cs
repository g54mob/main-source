using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	public abstract class ShapesObjPool<T, P> : MonoBehaviour where T : Component where P : ShapesObjPool<T, P>
	{
		private const int ALLOCATION_COUNT_WARNING = 500;

		private const int ALLOCATION_COUNT_CAP = 1000;

		private Stack<T> elementsPassive = new Stack<T>();

		private Dictionary<int, T> elementsActive = new Dictionary<int, T>();

		private static P instance;

		private int ElementCount => elementsPassive.Count + elementsActive.Count;

		public T ImmediateModeElement => GetElement(-1);

		public static int InstanceElementCount
		{
			get
			{
				if (!InstanceExists)
				{
					return 0;
				}
				return Instance.ElementCount;
			}
		}

		public static int InstanceElementCountActive
		{
			get
			{
				if (!InstanceExists)
				{
					return 0;
				}
				return Instance.elementsActive.Count;
			}
		}

		public static bool InstanceExists => instance != null;

		public abstract string PoolTypeName { get; }

		public static P Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindAnyObjectByType<P>();
					if (instance == null)
					{
						instance = CreatePool();
					}
				}
				return instance;
			}
		}

		private static P CreatePool()
		{
			GameObject gameObject = new GameObject();
			if (Application.isPlaying)
			{
				Object.DontDestroyOnLoad(gameObject);
			}
			P result = gameObject.AddComponent<P>();
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			return result;
		}

		private void ClearData()
		{
			for (int num = base.transform.childCount - 1; num >= 0; num--)
			{
				base.transform.GetChild(num).gameObject.DestroyBranched();
			}
			elementsPassive.Clear();
			elementsActive.Clear();
		}

		private void OnEnable()
		{
			base.gameObject.name = "Shapes " + PoolTypeName + " Pool";
			ClearData();
			instance = (P)this;
		}

		private void OnDisable()
		{
			ClearData();
		}

		public T GetElement(int id)
		{
			if (!elementsActive.TryGetValue(id, out var value))
			{
				return AllocateElement(id);
			}
			return value;
		}

		public T AllocateElement(int id)
		{
			T val = null;
			while (val == null && elementsPassive.Count > 0)
			{
				val = elementsPassive.Pop();
			}
			if (val == null)
			{
				val = CreateElement(id);
			}
			elementsActive.Add(id, val);
			return val;
		}

		public void ReleaseElement(int id)
		{
			if (elementsActive.TryGetValue(id, out var value))
			{
				elementsActive.Remove(id);
				elementsPassive.Push(value);
			}
		}

		private T CreateElement(int id)
		{
			int elementCount = ElementCount;
			if (elementCount > 1000)
			{
				Debug.LogError($"Text element allocation cap of {1000} reached. You are probably leaking and not properly disposing {PoolTypeName.ToLower()} elements");
				return null;
			}
			if (elementCount > 500)
			{
				Debug.LogWarning($"Allocating more than {500} {PoolTypeName.ToLower()} elements. You are probably leaking and not properly disposing text objects");
			}
			GameObject obj = new GameObject((id == -1) ? ("Immediate Mode " + PoolTypeName) : id.ToString());
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			obj.transform.localPosition = Vector3.zero;
			obj.hideFlags = HideFlags.HideAndDontSave;
			T val = obj.AddComponent<T>();
			OnCreatedNewComponent(val);
			return val;
		}

		public abstract void OnCreatedNewComponent(T comp);
	}
}
