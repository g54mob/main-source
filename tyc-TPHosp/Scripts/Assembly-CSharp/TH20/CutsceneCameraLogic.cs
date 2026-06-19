#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine;

namespace TH20
{
	public class CutsceneCameraLogic : MustCallDestroy, IGameEventsBase
	{
		public Action<CutsceneLogic> OnCutsceneSectionFinished;

		private readonly Camera _camera;

		private readonly TopDownCameraLogic _topDownCamera;

		private Vector3 _cachedPosition;

		private Vector3 _cachedFocalPoint;

		private CutsceneLogic _logic;

		private CutsceneLogic.Result _result;

		public bool IsInCutscene { get; private set; }

		public bool HasActiveCutsceneLogic => _logic != null;

		public CutsceneCameraLogic(Camera camera, TopDownCameraLogic topDownCamera, TopDownCameraLogic.Config config)
		{
			GameEventsRegistry.RegisterGlobalEvent(this);
			_camera = camera;
			_topDownCamera = topDownCamera;
		}

		public void VerifyEvents()
		{
			OnCutsceneSectionFinished.VerifyIsNull();
		}

		public void EnableCutsceneCamera(bool enable)
		{
			IsInCutscene = enable;
		}

		public void Update()
		{
			if (_logic != null)
			{
				if (_logic.IsFinished())
				{
					OnCutsceneSectionFinished.InvokeSafe(_logic);
					_logic = null;
				}
				else
				{
					_result = _logic.CalculateCameraVariables();
				}
				_camera.transform.position = _result.TargetPosition;
				_camera.transform.rotation = Quaternion.LookRotation(_result.TargetFocalPoint - _camera.transform.position, Vector3.up);
			}
		}

		private void PushCutsceneMode(CutsceneLogic logic)
		{
			_logic = logic;
		}

		public CutsceneLogicMoveToLocation SetModeMoveToLocation(MetagameCutsceneLocation cutsceneLocation, float maxSpeed)
		{
			if (cutsceneLocation == null)
			{
				Logging.Error(LogChannels.Metagame, "RB: Trying to move to MetagameCutsceneLocation but the location was NULL");
				return null;
			}
			CutsceneLogicMoveToLocation cutsceneLogicMoveToLocation = new CutsceneLogicMoveToLocation(new CutsceneLogicMoveToLocation.Parameters
			{
				CameraTransform = _camera.transform,
				TargetLocation = cutsceneLocation,
				MaxSpeed = maxSpeed
			});
			PushCutsceneMode(cutsceneLogicMoveToLocation);
			return cutsceneLogicMoveToLocation;
		}

		public CutsceneLogicResetToGameCamera SetModeResetToCachedCamera(float maxSpeed, float blendTime = 2f)
		{
			CutsceneLogicResetToGameCamera cutsceneLogicResetToGameCamera = new CutsceneLogicResetToGameCamera(_camera.transform, _cachedPosition, _cachedFocalPoint, maxSpeed);
			PushCutsceneMode(cutsceneLogicResetToGameCamera);
			return cutsceneLogicResetToGameCamera;
		}

		public void CacheCurrentTransform()
		{
			_topDownCamera.Update();
			_cachedPosition = _camera.transform.position;
			CameraUtils.GetCameraFocalPoint(_camera.transform, out _cachedFocalPoint);
		}
	}
}
