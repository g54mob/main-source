using UnityEngine;

namespace TH20
{
	public class CutsceneLogicMoveToLocation : CutsceneLogic
	{
		public struct Parameters
		{
			public Transform CameraTransform;

			public MetagameCutsceneLocation TargetLocation;

			public float MaxSpeed;
		}

		private const float MinCameraSpeed = 20f;

		private const float CameraMaxAcceleration = 1f;

		private const float DampeningThreshold = 0.16f;

		private const float DampeningMultiplier = 0.935f;

		private readonly Transform _cameraTransform;

		private readonly Vector3 _startFocalPoint;

		private readonly Vector3 _startOffset;

		private readonly Vector3 _finalFocalPoint;

		private readonly Vector3 _finalPosition;

		private readonly Vector3 _finalOffset;

		private readonly float _cutsceneDistance;

		private readonly float _maxCameraSpeed;

		private float _progress;

		private float _cameraSpeed;

		public CutsceneLogicMoveToLocation(Parameters parameters)
			: base(parameters.CameraTransform)
		{
			_cameraTransform = parameters.CameraTransform;
			_maxCameraSpeed = parameters.MaxSpeed;
			base.LogicType = Type.FocalPointPosition;
			CameraUtils.GetCameraFocalPoint(parameters.CameraTransform, out _startFocalPoint);
			_finalPosition = parameters.TargetLocation.CameraLocationTarget;
			_finalFocalPoint = parameters.TargetLocation.CameraFocalPointTarget;
			_startOffset = _cameraTransform.position - _startFocalPoint;
			_finalOffset = _finalPosition - _finalFocalPoint;
			_cutsceneDistance = Vector3.Distance(parameters.CameraTransform.position, _finalPosition);
			_progress = 0f;
			_cameraSpeed = 0f;
		}

		public override Result CalculateCameraVariables()
		{
			Result result = default(Result);
			Vector3 vector = _finalPosition - _cameraTransform.position;
			float num = Vector3.Magnitude(vector);
			if (num < _maxCameraSpeed * 0.16f)
			{
				_cameraSpeed = Mathf.Max(20f, _cameraSpeed * 0.935f);
			}
			else
			{
				_cameraSpeed = Mathf.Min(_maxCameraSpeed, _cameraSpeed + 1f);
			}
			float num2 = _cameraSpeed * Time.unscaledDeltaTime;
			if (num > num2)
			{
				Vector3 vector2 = Vector3.Normalize(vector) * num2 + _cameraTransform.position;
				float num3 = Vector3.Magnitude(_finalPosition - vector2);
				float num4 = 1f - num3 / _cutsceneDistance;
				result.TargetFocalPoint = Vector3.Lerp(_startFocalPoint, _finalFocalPoint, num4);
				result.TargetPosition = result.TargetFocalPoint + Vector3.Lerp(_startOffset, _finalOffset, num4);
				_progress = num4;
			}
			else
			{
				result.TargetFocalPoint = _finalFocalPoint;
				result.TargetPosition = _finalPosition;
				_progress = 1f;
			}
			return result;
		}

		public override bool IsFinished()
		{
			return _progress >= 1f;
		}

		public override bool ContinueSmoothingAfterFinish()
		{
			return true;
		}

		public override string PrintStatus()
		{
			return $"Progress={_progress}, Speed={_cameraSpeed}";
		}
	}
}
