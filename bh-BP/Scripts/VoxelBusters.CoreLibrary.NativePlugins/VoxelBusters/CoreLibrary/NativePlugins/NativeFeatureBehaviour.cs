using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public abstract class NativeFeatureBehaviour : MonoBehaviour
	{
		private bool m_isInitialised;

		public abstract bool IsAvailable();

		protected abstract string GetFeatureName();

		public static T CreateInstance<T>(string name = "GameObject") where T : NativeFeatureBehaviour
		{
			return null;
		}

		protected static T CreateInstanceInternal<T>(string name, params object[] args) where T : NativeFeatureBehaviour
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		protected void OnDestroy()
		{
		}

		protected virtual void AwakeInternal(object[] args)
		{
		}

		protected virtual void StartInternal()
		{
		}

		protected virtual void DestroyInternal()
		{
		}
	}
}
