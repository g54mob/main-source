using System;
using NSEipix.Base;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class CameraSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private float screenEdgeBorderUp;

		[SerializeField]
		private float screenEdgeBorderDown;

		[SerializeField]
		private float screenEdgeBorderRight;

		[SerializeField]
		private float screenEdgeBorderLeft;

		[SerializeField]
		private float cameraSensitivityMin;

		[SerializeField]
		private float cameraSensitivityMax;

		[SerializeField]
		private float mouseMoveSpeed;

		[SerializeField]
		private float mousePanSpeed;

		[SerializeField]
		private float mouseRotateSpeed;

		[SerializeField]
		private float mouseTiltSpeed;

		[SerializeField]
		private float mouseZoomSpeed;

		[SerializeField]
		private float keyboardMoveSpeed;

		[SerializeField]
		private float keyboardFastMoveSpeed;

		[SerializeField]
		private float keyboardRotateSpeed;

		[SerializeField]
		private float keyboardZoomSpeed;

		[SerializeField]
		private float keyboardTiltSpeed;

		[SerializeField]
		private float defaultHeight;

		[SerializeField]
		private float defaultRotation;

		[SerializeField]
		private float defaultTilt;

		[SerializeField]
		private float lookAtHeightOffset;

		[SerializeField]
		private bool smoothing;

		[SerializeField]
		private bool moveSmoothing;

		[SerializeField]
		private float moveDampening;

		[SerializeField]
		private float zoomDampening;

		[SerializeField]
		private float rotationDampening;

		[SerializeField]
		private float tiltDampening;

		[SerializeField]
		private float maxTilt;

		[SerializeField]
		private FloatRange minTiltRange;

		[SerializeField]
		private FloatRange heightRange;

		[SerializeField]
		private float defaultMinTilt;

		public float ScreenEdgeBorderUp => screenEdgeBorderUp;

		public float ScreenEdgeBorderDown => screenEdgeBorderDown;

		public float ScreenEdgeBorderRight => screenEdgeBorderRight;

		public float ScreenEdgeBorderLeft => screenEdgeBorderLeft;

		public float MouseMoveSpeed => mouseMoveSpeed;

		public float MousePanSpeed => mousePanSpeed;

		public float MouseRotateSpeed => mouseRotateSpeed;

		public float MouseTiltSpeed => mouseTiltSpeed;

		public float MouseZoomSpeed => mouseZoomSpeed;

		public float KeyboardMoveSpeed => keyboardMoveSpeed;

		public float KeyboardFastMoveSpeed => keyboardFastMoveSpeed;

		public float KeyboardRotateSpeed => keyboardRotateSpeed;

		public float KeyboardZoomSpeed => keyboardZoomSpeed;

		public float KeyboardTiltSpeed => keyboardTiltSpeed;

		public bool Smoothing => smoothing;

		public float MoveDampening => moveDampening;

		public float ZoomDampening => zoomDampening;

		public float RotationDampening => rotationDampening;

		public float TiltDampening => tiltDampening;

		public FloatRange HeightRange => heightRange;

		public FloatRange MinTiltRange => minTiltRange;

		public float MaxTilt => maxTilt;

		public float DefaultHeight => defaultHeight;

		public float DefaultRotation => defaultRotation;

		public float DefaultTilt => defaultTilt;

		public bool MoveSmoothing => moveSmoothing;

		public float LookAtHeightOffset => lookAtHeightOffset;

		public float CameraSensitivityMin => cameraSensitivityMin;

		public float CameraSensitivityMax => cameraSensitivityMax;

		public float DefaultMinTilt => defaultMinTilt;

		public override string GetID()
		{
			return "CameraSettings";
		}
	}
}
