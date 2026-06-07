using UnityEngine;

namespace Gh
{
	[DisallowMultipleComponent]
	public class CameraFrameLimiter : MonoBehaviour
	{
		private Camera _camera;

		public float renderFPS;

		private float _currentFrameDelayRemaining;

		public float FPSDelay => 0f;

		public bool PauseRender { get; set; }

		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{
		}
	}
}
