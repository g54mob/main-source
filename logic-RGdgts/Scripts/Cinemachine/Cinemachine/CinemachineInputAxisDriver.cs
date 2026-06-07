using System;

namespace Cinemachine
{
	[Serializable]
	public struct CinemachineInputAxisDriver
	{
		public float multiplier;

		public float accelTime;

		public float decelTime;

		public string name;

		[NoSaveDuringPlay]
		public float inputValue;

		private float mCurrentSpeed;

		private const float Epsilon = 0.0001f;

		public void Validate()
		{
		}

		public bool Update(float deltaTime, ref AxisBase axis)
		{
			return false;
		}

		public bool Update(float deltaTime, ref AxisState axis)
		{
			return false;
		}

		private float ClampValue(ref AxisBase axis, float v)
		{
			return 0f;
		}
	}
}
