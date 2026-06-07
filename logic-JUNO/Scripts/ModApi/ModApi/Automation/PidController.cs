using UnityEngine;

namespace ModApi.Automation
{
	public class PidController
	{
		public delegate void PidHandler(PidController source);

		private PidController _autoTunePid;

		private float _lastError;

		private PidControllerOscillationMonitor _oscillationMonitor;

		public bool AutoResetWhenErrorSignChanges { get; set; }

		public float ErrorAccum { get; private set; }

		public float? ErrorMaxAccum { get; set; }

		public Vector3 PidGains { get; set; }

		public float Value { get; private set; }

		public Vector3 ValueComponents { get; private set; }

		public PidController()
		{
			ErrorMaxAccum = null;
			Reset();
		}

		public PidController MakeCopy()
		{
			return (PidController)MemberwiseClone();
		}

		public void Reset()
		{
			_lastError = 0f;
			ErrorAccum = 0f;
			_oscillationMonitor?.Reset();
		}

		public float Update(float value, float target, float deltaTime, float? valueRate = null)
		{
			return UpdatePID(value, target, deltaTime, valueRate);
		}

		private static Vector3 CalculatePID(Vector3 pidGains, float error, float lastError, float deltaTime, float errorAccum, float? valueRate = null)
		{
			Vector3 result = default(Vector3);
			result.x = pidGains.x * error;
			result.y = pidGains.y * errorAccum;
			float num = valueRate ?? ((error - lastError) / deltaTime);
			result.z = pidGains.z * num;
			return result;
		}

		private float UpdatePID(float value, float target, float deltaTime, float? valueRate = null)
		{
			float num = target - value;
			ErrorAccum += deltaTime * num;
			if (ErrorMaxAccum.HasValue)
			{
				ErrorAccum = Mathf.Clamp(ErrorAccum, 0f - ErrorMaxAccum.Value, ErrorMaxAccum.Value);
			}
			Vector3 pidGains;
			if (_oscillationMonitor != null)
			{
				_oscillationMonitor.Update(num, deltaTime);
				pidGains = PidGains * _oscillationMonitor.RecommendedPidAdjustment;
			}
			else
			{
				pidGains = PidGains;
			}
			ValueComponents = CalculatePID(pidGains, num, _lastError, deltaTime, ErrorAccum, valueRate);
			Value = ValueComponents.x + ValueComponents.y + ValueComponents.z;
			if (AutoResetWhenErrorSignChanges && Mathf.Sign(_lastError) != Mathf.Sign(num) && _lastError != 0f)
			{
				Reset();
			}
			_lastError = num;
			return Value;
		}
	}
}
