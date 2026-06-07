using UnityEngine;

namespace RLD
{
	public class GizmoSglAxisRotationDrag3D : GizmoScreenDrag
	{
		public struct WorkData
		{
			public Vector3 RotationPlanePos;

			public Vector3 Axis;

			public GizmoSnapMode SnapMode;

			public float SnapStep;
		}

		private float _accumSnapDrag;

		private Plane _rotationPlane;

		private Vector3 _screenDragCircleTangent;

		private WorkData _workData;

		private bool _adjustRotationForAbsSnap;

		private float _relativeRotation;

		private float _totalRotation;

		public override GizmoDragChannel DragChannel => GizmoDragChannel.Rotation;

		public float RelativeRotation => _relativeRotation;

		public float TotalRotation => _totalRotation;

		public Plane RotationPlane => _rotationPlane;

		public void SetWorkData(WorkData workData)
		{
			if (!IsActive)
			{
				_workData = workData;
				_rotationPlane = new Plane(_workData.Axis, _workData.RotationPlanePos);
			}
		}

		protected override void CalculateDragValues()
		{
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			_relativeRotation = Vector2.Dot(_screenDragCircleTangent, device.GetFrameDelta()) * base.Sensitivity;
			if (_relativeRotation == 0f)
			{
				_relativeDragRotation = Quaternion.identity;
				return;
			}
			if (CanSnap())
			{
				_accumSnapDrag += _relativeRotation;
				_accumSnapDrag %= 360f;
				if (_workData.SnapMode == GizmoSnapMode.Absolute && _adjustRotationForAbsSnap)
				{
					NumSnapSteps numSnapSteps = SnapMath.CalculateNumSnapSteps(_workData.SnapStep, _totalRotation);
					float totalRotation = _totalRotation;
					if (numSnapSteps.AbsFracSteps < 0.5f)
					{
						_totalRotation = (float)numSnapSteps.AbsIntNumSteps * _workData.SnapStep * Mathf.Sign(_totalRotation);
					}
					else
					{
						_totalRotation = (float)(numSnapSteps.AbsIntNumSteps + 1) * _workData.SnapStep * Mathf.Sign(_totalRotation);
					}
					_relativeRotation = _totalRotation - totalRotation;
					_accumSnapDrag = 0f;
					_relativeDragRotation = Quaternion.AngleAxis(_relativeRotation, _workData.Axis);
					_adjustRotationForAbsSnap = false;
				}
				else if (SnapMath.CanExtractSnap(_workData.SnapStep, _accumSnapDrag))
				{
					_relativeRotation = SnapMath.ExtractSnap(_workData.SnapStep, ref _accumSnapDrag);
					_totalRotation += _relativeRotation;
					_totalRotation %= 360f;
					_relativeDragRotation = Quaternion.AngleAxis(_relativeRotation, _workData.Axis);
				}
				else
				{
					_relativeDragRotation = Quaternion.identity;
				}
			}
			else
			{
				_accumSnapDrag = 0f;
				_adjustRotationForAbsSnap = true;
				_totalRotation += _relativeRotation;
				_totalRotation %= 360f;
				_relativeDragRotation = Quaternion.AngleAxis(_relativeRotation, _workData.Axis);
			}
			_totalDragRotation = Quaternion.AngleAxis(_totalRotation, _workData.Axis);
		}

		protected override void OnSessionBegin()
		{
			Camera targetCamera = MonoSingleton<RTFocusCamera>.Get.TargetCamera;
			_adjustRotationForAbsSnap = false;
			if (MonoSingleton<RTGizmosEngine>.Get.HoveredGizmo.HoverInfo.HandleDimension == GizmoDimension.Dim3D)
			{
				Ray ray = MonoSingleton<RTInputDevice>.Get.Device.GetRay(targetCamera);
				if (_rotationPlane.Raycast(ray, out var enter))
				{
					Vector3 point = ray.GetPoint(enter);
					Vector3 rhs = point - _workData.RotationPlanePos;
					Vector3 vector = Vector3.Cross(_workData.Axis, rhs);
					Vector2 vector2 = targetCamera.WorldToScreenPoint(point);
					Vector2 vector3 = targetCamera.WorldToScreenPoint(point + vector);
					_screenDragCircleTangent = (vector3 - vector2).normalized;
				}
			}
			else
			{
				Vector2 vector4 = MonoSingleton<RTInputDevice>.Get.Device.GetPositionYAxisUp();
				Vector2 vector5 = targetCamera.WorldToScreenPoint(_workData.RotationPlanePos);
				_screenDragCircleTangent = (vector4 - vector5).GetNormal();
			}
		}

		protected override void OnSessionEnd()
		{
			_accumSnapDrag = 0f;
			_screenDragCircleTangent = Vector2.zero;
			_adjustRotationForAbsSnap = false;
			_totalRotation = 0f;
			_relativeRotation = 0f;
		}
	}
}
