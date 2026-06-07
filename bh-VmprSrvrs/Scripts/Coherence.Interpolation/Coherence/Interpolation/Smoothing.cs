using Coherence.Common;
using UnityEngine;

namespace Coherence.Interpolation
{
	public class Smoothing : ISmoothing<double>, ISmoothing<float>, ISmoothing<Vector2>, ISmoothing<Vector3>, ISmoothing<Quaternion>
	{
		private double lastTime;

		private double doubleVelocity;

		private Vector4d velocity;

		double ISmoothing<double>.CurrentVelocity
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		float ISmoothing<float>.CurrentVelocity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		Vector2 ISmoothing<Vector2>.CurrentVelocity
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		Vector3 ISmoothing<Vector3>.CurrentVelocity
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		Quaternion ISmoothing<Quaternion>.CurrentVelocity
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		private float GetDeltaTime(double time)
		{
			return 0f;
		}

		public double SmoothDouble(SmoothingSettings settings, double currentValue, double targetValue, double time)
		{
			return 0.0;
		}

		public float SmoothFloat(SmoothingSettings settings, float currentValue, float targetValue, double time)
		{
			return 0f;
		}

		public Vector2 SmoothVector2(SmoothingSettings settings, Vector2 currentValue, Vector2 targetValue, double time)
		{
			return default(Vector2);
		}

		public Vector3 SmoothVector3(SmoothingSettings settings, Vector3 currentValue, Vector3 targetValue, double time)
		{
			return default(Vector3);
		}

		public Quaternion SmoothQuaternion(SmoothingSettings settings, Quaternion currentValue, Quaternion targetValue, double time)
		{
			return default(Quaternion);
		}

		public double Smooth(SmoothingSettings settings, double currentValue, double targetValue, double time)
		{
			return 0.0;
		}

		public float Smooth(SmoothingSettings settings, float currentValue, float targetValue, double time)
		{
			return 0f;
		}

		public Vector2 Smooth(SmoothingSettings settings, Vector2 currentValue, Vector2 targetValue, double time)
		{
			return default(Vector2);
		}

		public Vector3 Smooth(SmoothingSettings settings, Vector3 currentValue, Vector3 targetValue, double time)
		{
			return default(Vector3);
		}

		public Quaternion Smooth(SmoothingSettings settings, Quaternion currentValue, Quaternion targetValue, double time)
		{
			return default(Quaternion);
		}
	}
}
