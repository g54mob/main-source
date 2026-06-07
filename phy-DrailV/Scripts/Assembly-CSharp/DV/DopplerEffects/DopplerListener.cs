using DV.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace DV.DopplerEffects
{
	public class DopplerListener : ADopplerListener
	{
		private Transform oldTarget;

		private Doppler.UpdateMode updateMode;

		private bool isVR;

		public override Doppler.UpdateMode UpdateMode => updateMode;

		protected override void Awake()
		{
			base.Awake();
			isVR = VRManager.IsVREnabled();
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.WorldMoved += WorldMoved;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.WorldMoved -= WorldMoved;
			}
		}

		private void WorldMoved(WorldMover _, Vector3 __)
		{
			SingletonBehaviour<DopplerStopRequests>.Instance.SkipFrames = 1;
		}

		public override float3 GetPosition()
		{
			Transform transform = null;
			updateMode = Doppler.UpdateMode.LateUpdate;
			if (PlayerManager.PlayerCamera == null)
			{
				SingletonBehaviour<DopplerStopRequests>.Instance.SkipFrames = 1;
				return float3.zero;
			}
			if (PlayerManager.PlayerCamera.enabled || isVR || ((bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance && (bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.CurrentCar))
			{
				transform = PlayerManager.PlayerCamera.transform;
			}
			else if ((bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance)
			{
				transform = SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.transform;
			}
			if (transform == null)
			{
				SingletonBehaviour<DopplerStopRequests>.Instance.SkipFrames = 1;
				return float3.zero;
			}
			if (transform != oldTarget)
			{
				oldTarget = transform;
				SingletonBehaviour<DopplerStopRequests>.Instance.SkipFrames = 2;
			}
			return transform.position;
		}
	}
}
