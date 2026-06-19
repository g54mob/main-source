using UnityEngine;

namespace JSAM
{
	public class AudioLibraryLoader : MonoBehaviour
	{
		public enum LoadBehaviour
		{
			OnStartAndDestroy = 0,
			OnEnableAndDisable = 1
		}

		[SerializeField]
		private AudioLibrary library;

		public LoadBehaviour loadTiming;

		private void Load()
		{
			AudioManagerInternal.Instance.LoadAudioLibrary(library);
		}

		private void Unload()
		{
			AudioManagerInternal.Instance.UnloadAudioLibrary(library);
		}

		private void OnEnable()
		{
			if (loadTiming == LoadBehaviour.OnEnableAndDisable)
			{
				Load();
			}
		}

		private void OnDisable()
		{
			if (loadTiming == LoadBehaviour.OnEnableAndDisable)
			{
				Unload();
			}
		}

		private void Start()
		{
			if (loadTiming == LoadBehaviour.OnStartAndDestroy)
			{
				Load();
			}
		}

		private void OnDestroy()
		{
			if (loadTiming == LoadBehaviour.OnStartAndDestroy)
			{
				Unload();
			}
		}
	}
}
