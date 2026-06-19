using UnityEngine;

namespace TH20
{
	public class MetagameCutsceneLocation : MonoBehaviour
	{
		[SerializeField]
		public string LocationId;

		[SerializeField]
		protected Transform CameraTransform;

		[SerializeField]
		protected Transform CameraFocalPointTransform;

		private Coroutine _coroutine;

		public Vector3 CameraLocationTarget => CameraTransform.position;

		public Vector3 CameraFocalPointTarget => GetCameraFocalPoint();

		public bool IsAnimating => _coroutine != null;

		public void StartAnimation()
		{
			_coroutine = StartAnimationCoroutine();
		}

		public virtual void SkipToAnimationEnd()
		{
			OnAnimationFinished();
		}

		protected virtual Coroutine StartAnimationCoroutine()
		{
			return null;
		}

		protected void OnAnimationFinished()
		{
			_coroutine = null;
		}

		private Vector3 GetCameraFocalPoint()
		{
			if (CameraFocalPointTransform != null)
			{
				return CameraFocalPointTransform.position;
			}
			return CameraLocationTarget + CameraTransform.forward * 300f;
		}
	}
}
