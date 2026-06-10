using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public class PS4ControllerExtension : Controller.Extension, IControllerVibrator
	{
		internal class sOiVfRZDNaCmLOcrivCmWnUXgyF : IControllerExtensionSource
		{
			public readonly IPS4ControllerExtensionSource ottLIBaLKUdMBBqnPedZdrrIelx;

			public sOiVfRZDNaCmLOcrivCmWnUXgyF(IPS4ControllerExtensionSource source)
			{
			}
		}

		private readonly TimerAbs[] PycTVpjFjwfCGsowmeMWFpbIOXU;

		private IPS4ControllerExtensionSource Source => null;

		internal Joystick joystick => null;

		public int deviceHandle => 0;

		public int userStatusCode => 0;

		public bool userIsPrimary => false;

		public int userId => 0;

		public Color userColor => default(Color);

		public int userColorId => 0;

		public string userName => null;

		public int vibrationMotorCount => 0;

		internal PS4ControllerExtension(IPS4ControllerExtensionSource source)
			: base((IControllerExtensionSource)null)
		{
		}

		protected PS4ControllerExtension(PS4ControllerExtension source)
			: base((IControllerExtensionSource)null)
		{
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

		public Vector3 GetAccelerometerValueRaw()
		{
			return default(Vector3);
		}

		public Vector3 GetAccelerometerValue()
		{
			return default(Vector3);
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			return default(Vector3);
		}

		public Vector3 GetLastGyroscopeValue()
		{
			return default(Vector3);
		}

		public Quaternion GetOrientationRaw()
		{
			return default(Quaternion);
		}

		public Quaternion GetOrientation()
		{
			return default(Quaternion);
		}

		public void ResetOrientation()
		{
		}

		public void SetMotionSensorState(bool enabled)
		{
		}

		public void SetTiltCorrectionState(bool enabled)
		{
		}

		public void SetAngularVelocityDeadbandState(bool enabled)
		{
		}

		public void SetLightColor(Color color)
		{
		}

		public void SetLightColor(float red, float green, float blue)
		{
		}

		public void SetLightColor(float red, float green, float blue, float intensity)
		{
		}

		public void ResetLight()
		{
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}

		private void QWIjVqDTqkbRucBdBwaMftUrGTU()
		{
		}

		private void byElLAxPlbLAnuFUvRVYXfGZFF(int P_0, float P_1, float P_2)
		{
		}
	}
}
