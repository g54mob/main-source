using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraFocusSettings : Settings
	{
		[SerializeField]
		private CameraFocusMode _focusMode = CameraFocusMode.Smooth;

		[SerializeField]
		private float _constantSpeed = 10f;

		[SerializeField]
		private float _smoothTime = 1.5f;

		[SerializeField]
		private float _focusDistanceAdd = 1.2f;

		public CameraFocusMode FocusMode
		{
			get
			{
				return _focusMode;
			}
			set
			{
				_focusMode = value;
			}
		}

		public float ConstantSpeed
		{
			get
			{
				return _constantSpeed;
			}
			set
			{
				_constantSpeed = Mathf.Max(value, 0.0001f);
			}
		}

		public float SmoothTime
		{
			get
			{
				return _smoothTime;
			}
			set
			{
				_smoothTime = Mathf.Max(value, 0.0001f);
			}
		}

		public float FocusDistanceAdd
		{
			get
			{
				return _focusDistanceAdd;
			}
			set
			{
				_focusDistanceAdd = Mathf.Max(value, 0.0001f);
			}
		}
	}
}
