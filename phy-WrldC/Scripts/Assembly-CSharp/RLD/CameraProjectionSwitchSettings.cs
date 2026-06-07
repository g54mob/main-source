using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraProjectionSwitchSettings : Settings
	{
		[SerializeField]
		private CameraProjectionSwitchMode _switchMode;

		[SerializeField]
		private float _transitionDurationInSeconds = 0.23f;

		public CameraProjectionSwitchMode SwitchMode
		{
			get
			{
				return _switchMode;
			}
			set
			{
				_switchMode = value;
			}
		}

		public float TransitionDurationInSeconds
		{
			get
			{
				return _transitionDurationInSeconds;
			}
			set
			{
				_transitionDurationInSeconds = Mathf.Max(value, 0.01f);
			}
		}
	}
}
