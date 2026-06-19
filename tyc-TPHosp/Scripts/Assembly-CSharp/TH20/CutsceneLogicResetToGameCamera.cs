using UnityEngine;

namespace TH20
{
	public class CutsceneLogicResetToGameCamera : CutsceneLogic
	{
		private readonly Vector3 _startPosition;

		private readonly Vector3 _startFocalPoint;

		private readonly Vector3 _finalPosition;

		private readonly Vector3 _finalFocalPoint;

		private readonly float _cutsceneTime;

		private float _elapsedTime;

		public CutsceneLogicResetToGameCamera(Transform cameraTransform, Vector3 finalPosition, Vector3 finalFocalPoint, float maxSpeed)
			: base(cameraTransform)
		{
			base.LogicType = Type.FocalPointPosition;
			_startPosition = cameraTransform.position;
			CameraUtils.GetCameraFocalPoint(cameraTransform, out _startFocalPoint);
			_finalPosition = finalPosition;
			_finalFocalPoint = finalFocalPoint;
			float num = Vector3.Distance(_startFocalPoint, _finalFocalPoint);
			_cutsceneTime = ((maxSpeed > 0f) ? (num / maxSpeed) : 1f);
		}

		public override Result CalculateCameraVariables()
		{
			Result result = default(Result);
			_elapsedTime += Time.unscaledDeltaTime;
			float num = _elapsedTime / _cutsceneTime;
			if (num < 1f)
			{
				result.TargetFocalPoint = Vector3.Lerp(_startFocalPoint, _finalFocalPoint, EasingsUtils.CubicEaseInOut(num));
				result.TargetPosition = Vector3.Lerp(_startPosition, _finalPosition, EasingsUtils.CubicEaseInOut(num));
			}
			else
			{
				result.TargetFocalPoint = _finalFocalPoint;
				result.TargetPosition = _finalPosition;
			}
			return result;
		}

		public override bool IsFinished()
		{
			return _elapsedTime / _cutsceneTime >= 1f;
		}

		public override string PrintStatus()
		{
			return $"t={_elapsedTime / _cutsceneTime}, elapsed={_elapsedTime}, cutsceneTime={_cutsceneTime}";
		}
	}
}
