using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct CameraZoomStruct
	{
		public bool IsNeedZoom;

		public float _zoomUpdateSpeed;

		public float _zoomIncrementMultiplier;

		[MinMaxSlider(0f, 50f)]
		public Vector2 _distanceMinMax;

		public AnimationCurve _distanceCurve;

		[MinMaxSlider(0f, 90f)]
		public Vector2 _orientationMinMax;

		public AnimationCurve _orientationCurve;

		[Range(0f, 1f)]
		public float _startZoomLerp;
	}
}
