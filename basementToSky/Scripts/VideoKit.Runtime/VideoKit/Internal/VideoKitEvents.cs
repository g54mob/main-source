using System;
using System.Collections;
using UnityEngine;

namespace VideoKit.Internal
{
	[DefaultExecutionOrder(-9000)]
	public sealed class VideoKitEvents : MonoBehaviour
	{
		public static VideoKitEvents Instance => OptionalInstance = (((object)OptionalInstance != null) ? OptionalInstance : new GameObject("VideoKitEvents").AddComponent<VideoKitEvents>());

		public static VideoKitEvents? OptionalInstance { get; private set; }

		public event Action? onFrame;

		public event Action? onUpdate;

		public event Action? onLateUpdate;

		public event Action? onPause;

		public event Action? onResume;

		public event Action? onQuit;

		private void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		private IEnumerator Start()
		{
			WaitForEndOfFrame yielder = new WaitForEndOfFrame();
			while (true)
			{
				yield return yielder;
				this.onFrame?.Invoke();
			}
		}

		private void Update()
		{
			this.onUpdate?.Invoke();
		}

		private void LateUpdate()
		{
			this.onLateUpdate?.Invoke();
		}

		private void OnApplicationPause(bool paused)
		{
			(paused ? this.onPause : this.onResume)?.Invoke();
		}

		private void OnApplicationQuit()
		{
			this.onQuit?.Invoke();
			UnityEngine.Object.Destroy(base.gameObject);
			OptionalInstance = null;
		}
	}
}
