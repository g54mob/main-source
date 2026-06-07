using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public abstract class PrivateSingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		[ClearOnReload]
		private static T s_sharedInstance;

		[ClearOnReload(/*Could not decode attribute arguments.*/)]
		private static readonly object s_objectLock;

		[ClearOnReload(/*Could not decode attribute arguments.*/)]
		private static bool s_isDestroyed;

		[SerializeField]
		private bool m_isPersistent;

		private bool m_isInitialised;

		private bool m_forcedDestroy;

		public static bool IsSingletonActive => false;

		public bool IsPersistent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected static T GetSingleton()
		{
			return null;
		}

		protected static bool TryGetSingleton(out T singleton)
		{
			singleton = null;
			return false;
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		protected virtual void OnSingletonAwake()
		{
		}

		protected virtual void OnSingletonStart()
		{
		}

		protected virtual void OnSingletonDestroy()
		{
		}

		private void Init()
		{
		}

		public void DestorySingleton(bool immediate = true)
		{
		}
	}
}
