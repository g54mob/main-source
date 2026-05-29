using UnityEngine;

namespace Crosstales.Common.Util
{
	[DisallowMultipleComponent]
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
	{
		[SerializeField]
		private bool dontDestroy;

		public static string PrefabPath;

		public static string GameObjectName;

		protected static T instance;

		private static readonly object lockObj;

		public static T Instance
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public bool DontDestroy
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnApplicationQuit()
		{
		}

		public static void CreateInstance(bool searchExistingGameObject = true, bool deleteExistingInstance = false)
		{
		}

		public static void DeleteInstance()
		{
		}
	}
}
