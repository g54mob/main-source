using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;

namespace Rewired.Demos.CustomPlatform
{
	public class UnityInputJoystickSource
	{
		public class Joystick : IControllerVibrator
		{
			private const int maxJoysticks = 8;

			private const int maxAxes = 10;

			private const int maxButtons = 20;

			public readonly long systemId;

			public readonly string deviceName;

			public Guid deviceInstanceGuid;

			public readonly int axisCount;

			public readonly int buttonCount;

			public MyPlatformControllerIdentifier identifier;

			public readonly bool[] buttonValues;

			public readonly float[] axisValues;

			public int unityIndex;

			public int vibrationMotorCount { get; set; }

			public Joystick(long systemId, string deviceName, int axisCount, int buttonCount)
			{
			}

			public bool GetButtonValue(int index)
			{
				return false;
			}

			public float GetAxisValue(int index)
			{
				return 0f;
			}

			public void SetVibration(int motorIndex, float motorLevel)
			{
			}

			public void SetVibration(int motorIndex, float motorLevel, float duration)
			{
			}

			public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
			{
			}

			public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
			{
			}

			public float GetVibration(int motorIndex)
			{
				return 0f;
			}

			public void StopVibration()
			{
			}
		}

		private const float joystickCheckInterval = 1f;

		private static int systemIdCounter;

		private string[] _unityJoysticks;

		private double _nextJoystickCheckTime;

		private List<Joystick> _joysticks;

		private ReadOnlyCollection<Joystick> _joysticks_readOnly;

		public void Update()
		{
		}

		public IList<Joystick> GetJoysticks()
		{
			return null;
		}

		private void CheckForJoystickChanges()
		{
		}

		private bool DidJoysticksChange()
		{
			return false;
		}

		private void RefreshJoysticks()
		{
		}
	}
}
