using Gh.Tk;
using UnityEngine;

namespace Gh
{
	[PersistenceIgnoreParent]
	[PersistenceOptIn]
	public class EventCamera : MonoBehaviour, IPersistable
	{
		[PersistenceOptIn]
		public EventCameraSettings CameraSettings;

		protected Transform _pivot;

		protected Transform _cameraCradle;

		protected Vector3 _baseCradlePosition;

		protected Camera _camera;

		protected Transform _followTarget;

		private float _cameraVsScreenSizeFactor;

		private CameraFrameLimiter _cameraFrameLimiter;

		private float _swayTime;

		public string Id => null;

		public RenderTexture CameraRenderTexture { get; set; }

		public virtual float RenderFPS
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdateCameraSway()
		{
		}

		public virtual void SetFollowTarget(Transform target)
		{
		}

		public Transform GetFollowTarget()
		{
			return null;
		}

		public virtual void EnableCamera()
		{
		}

		protected void PlayVo()
		{
		}

		public virtual void DisableCamera()
		{
		}

		protected void StopVo()
		{
		}

		public virtual bool IsCameraUpdating()
		{
			return false;
		}

		public void KillEventCamera()
		{
		}
	}
}
