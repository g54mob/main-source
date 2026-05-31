using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct CameraMouseControlsStruct
	{
		public bool IsNeedMouseClick;

		[Range(0f, 0.4f)]
		public float _mousePadding;

		public bool _onlyMoveIfInsideScreen;

		public bool _screenBorderMove;

		public float _deltaPanningModifier;

		public float _deltaRotationModifier;

		public float _deltaZoomModifier;

		public float _rotationBuffer;
	}
}
