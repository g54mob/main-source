using System;
using UnityEngine;

namespace LaundryBear
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		public static Func<T> SingletonInstanceMissingEvent;

		protected bool m_isPersistent = true;

		private static bool sm_instanceSet;

		protected static T sm_instance;

		public static bool HasInstance => sm_instanceSet;

		public static T Instance => CurrentInstanceGetter();

		private static Func<T> CurrentInstanceGetter { get; set; }

		private static void SetInstance(T component)
		{
			sm_instance = component;
			if (null == sm_instance)
			{
				CurrentInstanceGetter = GetMissingInstance;
				sm_instanceSet = false;
			}
			else
			{
				CurrentInstanceGetter = GetLiveInstance;
				sm_instanceSet = true;
			}
		}

		protected virtual void Awake()
		{
			if (HasInstance && Instance != this)
			{
				Debug.Log("Preventing creation of a second Singleton of type " + typeof(T).ToString() + ". Destroying game object.");
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			Debug.Log("Singleton of type " + typeof(T).ToString() + " is being created");
			SetInstance(GetComponent<T>());
			if (m_isPersistent)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDestroy()
		{
			SetInstance(null);
			sm_instanceSet = false;
		}

		private static T GetLiveInstance()
		{
			return sm_instance;
		}

		private static T GetMissingInstance()
		{
			SetInstance(UnityEngine.Object.FindObjectOfType<T>());
			if (sm_instance != null)
			{
				return sm_instance;
			}
			return null;
		}
	}
}
