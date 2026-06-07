using System;
using UnityEngine;

namespace MSP_Input
{
	public class GyroAccel : MonoBehaviour
	{
		public bool forceAccelerometer;

		public float smoothingTime = 0.1f;

		public float headingOffset;

		public float pitchOffset;

		public float pitchOffsetMinimum = -70f;

		public float pitchOffsetMaximum = 70f;

		public float gyroHeadingAmplifier = 1f;

		public float gyroPitchAmplifier = 1f;

		private Quaternion rotation = Quaternion.identity;

		private float heading;

		private float pitch;

		private float roll;

		private static bool _forceAccelerometer;

		private static float _smoothingTime;

		private static float _headingOffset;

		private static float _pitchOffset = 30f;

		private static float _pitchOffsetMinimum;

		private static float _pitchOffsetMaximum;

		private static float _gyroHeadingAmplifier;

		private static float _gyroPitchAmplifier;

		private static Quaternion _rotation = Quaternion.identity;

		private static float _heading;

		private static float _pitch;

		private static float _roll;

		private void Awake()
		{
			Input.compensateSensors = true;
			if (!SystemInfo.supportsGyroscope)
			{
				forceAccelerometer = true;
				Debug.Log("No gyroscope available: forcing accelerometer");
			}
			if (SystemInfo.supportsGyroscope && !forceAccelerometer)
			{
				Debug.Log("Enabling gyro");
				Input.gyro.enabled = true;
			}
			_forceAccelerometer = forceAccelerometer;
			_smoothingTime = smoothingTime;
			_headingOffset = headingOffset;
			pitchOffset = _pitchOffset;
			_pitchOffsetMinimum = pitchOffsetMinimum;
			_pitchOffsetMaximum = pitchOffsetMaximum;
			_gyroHeadingAmplifier = gyroHeadingAmplifier;
			_gyroPitchAmplifier = gyroPitchAmplifier;
		}

		private void OnDestroy()
		{
			Debug.Log("Disabling gyro");
			Input.gyro.enabled = false;
		}

		private void Update()
		{
			forceAccelerometer = _forceAccelerometer;
			smoothingTime = _smoothingTime;
			headingOffset = _headingOffset;
			pitchOffset = _pitchOffset;
			pitchOffsetMinimum = _pitchOffsetMinimum;
			pitchOffsetMaximum = _pitchOffsetMaximum;
			gyroHeadingAmplifier = _gyroHeadingAmplifier;
			gyroPitchAmplifier = _gyroPitchAmplifier;
			CheckHeadingAndPitchBoundaries();
			if (!forceAccelerometer)
			{
				UpdateGyroscopeOrientation();
			}
			else
			{
				UpdateAccelerometerOrientation();
			}
			_rotation = rotation;
			_heading = heading;
			_pitch = pitch;
			_roll = roll;
			_headingOffset = headingOffset;
			_pitchOffset = pitchOffset;
			base.transform.rotation = GetRotation();
		}

		private void UpdateGyroscopeOrientation()
		{
			Quaternion attitude = Input.gyro.attitude;
			Quaternion quaternion = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f);
			Quaternion quaternion2 = new Quaternion(0f, 0f, 1f, 0f);
			attitude = quaternion * attitude * quaternion2;
			GetDevicePitchAndRollFromGravityVector(out var devicePitch, out var deviceRoll);
			float num = Mathf.Cos(MathF.PI / 180f * deviceRoll);
			float num2 = Mathf.Sin(MathF.PI / 180f * deviceRoll);
			float num3 = (0f - Input.gyro.rotationRateUnbiased.x) * num2 - Input.gyro.rotationRateUnbiased.y * num;
			gyroHeadingAmplifier = Mathf.Clamp(gyroHeadingAmplifier, 0.1f, 4f);
			num3 *= gyroHeadingAmplifier - 1f;
			headingOffset += num3;
			float num4 = (0f - Input.gyro.rotationRateUnbiased.y) * num2 + Input.gyro.rotationRateUnbiased.x * num;
			gyroPitchAmplifier = Mathf.Clamp(gyroPitchAmplifier, 0.1f, 4f);
			num4 *= gyroPitchAmplifier - 1f;
			if (devicePitch > pitchOffsetMinimum && devicePitch < pitchOffsetMaximum)
			{
				pitchOffset += num4;
			}
			if (devicePitch <= pitchOffsetMinimum)
			{
				pitchOffset -= Mathf.Abs(num4);
			}
			if (devicePitch >= pitchOffsetMaximum)
			{
				pitchOffset += Mathf.Abs(num4);
			}
			CheckHeadingAndPitchBoundaries();
			Vector3 rhs = attitude * Vector3.forward;
			Vector3 axis = Vector3.Cross(Vector3.up, rhs);
			AnimationCurve animationCurve = new AnimationCurve(new Keyframe(-90f, 0f), new Keyframe(pitchOffset, 0f - pitchOffset), new Keyframe(90f, 0f));
			attitude = Quaternion.AngleAxis(animationCurve.Evaluate(devicePitch), axis) * attitude;
			attitude = Quaternion.AngleAxis(headingOffset, Vector3.up) * attitude;
			float num5 = ((smoothingTime > Time.unscaledDeltaTime) ? (Time.unscaledDeltaTime / smoothingTime) : 1f);
			rotation = Quaternion.Slerp(rotation, attitude, num5);
			Vector3 lhs = rotation * Vector3.forward;
			Vector3 to = Vector3.Cross(Vector3.up, Vector3.Cross(lhs, Vector3.up));
			float b = Vector3.Angle(Vector3.forward, to) * Mathf.Sign(lhs.x);
			AnimationCurve animationCurve2 = new AnimationCurve(new Keyframe(-90f, 0f, 0f, 0f), new Keyframe(-85f, num5, 0f, 0f), new Keyframe(85f, num5, 0f, 0f), new Keyframe(90f, 0f, 0f, 0f));
			heading = Mathf.LerpAngle(heading, b, animationCurve2.Evaluate(pitch));
			pitch = Mathf.LerpAngle(pitch, devicePitch + animationCurve.Evaluate(devicePitch), num5);
			roll = Mathf.LerpAngle(roll, deviceRoll, num5);
		}

		private void UpdateAccelerometerOrientation()
		{
			GetDevicePitchAndRollFromGravityVector(out var devicePitch, out var deviceRoll);
			AnimationCurve animationCurve = new AnimationCurve(new Keyframe(-90f, 0f), new Keyframe(pitchOffset, 0f - pitchOffset), new Keyframe(90f, 0f));
			Quaternion identity = Quaternion.identity;
			identity = GetQuaternionFromHeadingPitchRoll(headingOffset, devicePitch + animationCurve.Evaluate(devicePitch), deviceRoll);
			float t = ((smoothingTime > Time.unscaledDeltaTime) ? (Time.unscaledDeltaTime / smoothingTime) : 1f);
			rotation = Quaternion.Slerp(rotation, identity, t);
			heading = Mathf.LerpAngle(heading, headingOffset, t);
			pitch = Mathf.LerpAngle(pitch, devicePitch + animationCurve.Evaluate(devicePitch), t);
			roll = Mathf.LerpAngle(roll, deviceRoll, t);
		}

		public static void GetDevicePitchAndRollFromGravityVector(out float devicePitch, out float deviceRoll)
		{
			Vector3 vector = (SystemInfo.supportsGyroscope ? Input.gyro.gravity : Input.acceleration);
			Vector3 vector2 = Vector3.Cross(Vector3.forward, Vector3.Cross(vector, Vector3.forward));
			devicePitch = Vector3.Angle(vector, Vector3.forward) - 90f;
			deviceRoll = Vector3.Angle(vector2, -Vector3.up) * Mathf.Sign(Vector3.Cross(vector2, Vector3.down).z);
			AnimationCurve animationCurve = new AnimationCurve(new Keyframe(-90f, 0f), new Keyframe(-80f, 1f), new Keyframe(80f, 1f), new Keyframe(90f, 0f));
			deviceRoll *= animationCurve.Evaluate(devicePitch);
		}

		private void CheckHeadingAndPitchBoundaries()
		{
			if (heading > 360f)
			{
				heading -= 360f;
			}
			if (heading < 0f)
			{
				heading += 360f;
			}
			if (pitchOffset < pitchOffsetMinimum)
			{
				pitchOffset = pitchOffsetMinimum;
			}
			if (pitchOffset > pitchOffsetMaximum)
			{
				pitchOffset = pitchOffsetMaximum;
			}
		}

		public static Quaternion GetQuaternionFromHeadingPitchRoll(float inputHeading, float inputPitch, float inputRoll)
		{
			return Quaternion.Euler(0f, inputHeading, 0f) * Quaternion.Euler(inputPitch, 0f, 0f) * Quaternion.Euler(0f, 0f, inputRoll);
		}

		public static Quaternion GetRotation()
		{
			return _rotation;
		}

		public static float GetHeading()
		{
			return _heading;
		}

		public static float GetPitch()
		{
			return _pitch;
		}

		public static float GetRoll()
		{
			return _roll;
		}

		public static void GetHeadingPitchRoll(out float h, out float p, out float r)
		{
			h = _heading;
			p = _pitch;
			r = _roll;
		}

		public static void SetSmoothingTime(float smoothTime)
		{
			_smoothingTime = smoothTime;
		}

		public static float GetSmoothingTime()
		{
			return _smoothingTime;
		}

		public static void AddFloatToHeadingOffset(float extraHeadingOffset)
		{
			_headingOffset += extraHeadingOffset;
		}

		public static float GetHeadingOffset()
		{
			return _headingOffset;
		}

		public static void SetHeadingOffset(float newHeadingOffset)
		{
			_headingOffset = newHeadingOffset;
		}

		public static void AddFloatToPitchOffset(float extraPitchOffset)
		{
			_pitchOffset += extraPitchOffset;
		}

		public static float GetPitchOffset()
		{
			return _pitchOffset;
		}

		public static void SetPitchOffset(float newPitchOffset)
		{
			_pitchOffset = newPitchOffset;
		}

		public static void SetPitchOffsetMinumumMaximum(float newPitchOffsetMinimum, float newPitchOffsetMaximum)
		{
			_pitchOffsetMinimum = newPitchOffsetMinimum;
			_pitchOffsetMaximum = newPitchOffsetMaximum;
		}

		public static void SetGyroHeadingAmplifier(float newValue)
		{
			_gyroHeadingAmplifier = newValue;
		}

		public static float GetGyroHeadingAmplifier()
		{
			return _gyroHeadingAmplifier;
		}

		public static void SetGyroPitchAmplifier(float newValue)
		{
			_gyroPitchAmplifier = newValue;
		}

		public static float GetGyroPitchAmplifier()
		{
			return _gyroPitchAmplifier;
		}

		public static void SetForceAccelerometer(bool newValue)
		{
			_forceAccelerometer = newValue;
		}

		public static bool GetForceAccelerometer()
		{
			return _forceAccelerometer;
		}
	}
}
