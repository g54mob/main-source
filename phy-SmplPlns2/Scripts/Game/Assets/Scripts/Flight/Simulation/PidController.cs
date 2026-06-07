using UnityEngine;

namespace Assets.Scripts.Flight.Simulation
{
	public class PidController
	{
		public delegate void PidHandler(PidController source);

		private PidController _autoTunePid;

		private float _lastError;

		public float ErrorAccum { get; private set; }

		public float? ErrorMaxAccum { get; set; }

		public bool IsAutoTuning { get; private set; }

		public Vector3 PidGains { get; set; }

		public float Value { get; private set; }

		public Vector3 ValueComponents { get; private set; }

		public event PidHandler AutoTuneComplete;

		public PidController()
		{
			ErrorMaxAccum = null;
		}

		public void Reset()
		{
			_lastError = 0f;
			ErrorAccum = 0f;
		}

		public void StartAutoTune(float integralGain = 1000f)
		{
			_autoTunePid = new PidController();
			_autoTunePid.PidGains = new Vector3(0f, integralGain, 0.5f);
			_autoTunePid.ErrorMaxAccum = null;
			Reset();
			PidGains = Vector3.zero;
			IsAutoTuning = true;
		}

		public float Update(float value, float target, float deltaTime)
		{
			if (IsAutoTuning)
			{
				return UpdateAutoTune(value, deltaTime);
			}
			return UpdatePID(value, target, deltaTime);
		}

		public float UpdateAutoTune(float value, float deltaTime)
		{
			float result = UpdatePID(value, 0f, deltaTime);
			float num = _autoTunePid.Update(_lastError, 0f - Mathf.Sign(_lastError), deltaTime);
			if (Mathf.Sign(_lastError) != Mathf.Sign(ErrorAccum))
			{
				float num2 = num * 0.25f;
				PidGains = new Vector3(num2, num2, num2 / 40f);
				IsAutoTuning = false;
				Reset();
				if (this.AutoTuneComplete != null)
				{
					this.AutoTuneComplete(this);
					return result;
				}
			}
			else
			{
				PidGains = new Vector3(num, 0f, 0f);
			}
			return result;
		}

		private static Vector3 CalculatePID(Vector3 pidGains, float error, float lastError, float deltaTime, float errorAccum)
		{
			Vector3 result = default(Vector3);
			result.x = pidGains.x * error;
			result.y = pidGains.y * errorAccum;
			float num = (error - lastError) / deltaTime;
			result.z = pidGains.z * num;
			return result;
		}

		private float UpdatePID(float value, float target, float deltaTime)
		{
			float num = target - value;
			ErrorAccum += deltaTime * num;
			if (ErrorMaxAccum.HasValue)
			{
				ErrorAccum = Mathf.Clamp(ErrorAccum, 0f - ErrorMaxAccum.Value, ErrorMaxAccum.Value);
			}
			ValueComponents = CalculatePID(PidGains, num, _lastError, deltaTime, ErrorAccum);
			Value = ValueComponents.x + ValueComponents.y + ValueComponents.z;
			_lastError = num;
			return Value;
		}
	}
}
