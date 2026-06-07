using Assets.Nimbatus.Scripts.Animations;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelScene
{
	public class NimbatusSpeedAnimation : MonoBehaviour
	{
		public AnimationCurve LerpCurve;

		public ParticleSystem StarParticleSystem;

		public ParticleSystem DebrisParticleSystem;

		public PositionWiggler Wiggler;

		public SpriteSinusColorFader ThrusterGlow;

		public ParticleSystem SparksTop;

		public ParticleSystem SparksBottom;

		public ParticleSystem ThrustersBlueTop;

		public ParticleSystem ThrustersBlueBottom;

		public ParticleSystem ThrustersWhiteTop;

		public ParticleSystem ThrustersWhiteBottom;

		private float _targetSpeed;

		private float _currentSpeed;

		private float _lerpSpeed;

		private float _targetParticleSpeed;

		private float _currentParticleSpeed;

		private float _lerpParticleSpeed;

		public static bool IsOverwritten;

		public static bool IsParticleOverwritten;

		private void Start()
		{
			if (IsOverwritten)
			{
				_lerpSpeed = 1f;
				IsOverwritten = false;
			}
			else
			{
				_lerpSpeed = 1f;
				_targetSpeed = 1f;
				_currentSpeed = _targetSpeed;
			}
			if (IsParticleOverwritten)
			{
				_lerpParticleSpeed = 1f;
				IsParticleOverwritten = false;
			}
			else
			{
				_lerpParticleSpeed = 1f;
				_targetParticleSpeed = 1f;
				_currentParticleSpeed = _targetParticleSpeed;
			}
		}

		private void Update()
		{
			UpdateSpeed();
		}

		public void SetLerpSpeed(int speed)
		{
			_lerpSpeed = (float)speed / 100f;
		}

		public void SetTargetSpeed(float inSpeed)
		{
			_targetSpeed = Mathf.Clamp01(inSpeed);
		}

		public void SetParticleLerpSpeed(int speed)
		{
			_lerpParticleSpeed = (float)speed / 100f;
		}

		public void SetParticleTargetSpeed(float inSpeed)
		{
			_targetParticleSpeed = Mathf.Clamp01(inSpeed);
		}

		private void UpdateSpeed()
		{
			_currentSpeed = Mathf.Lerp(_currentSpeed, _targetSpeed, Time.deltaTime * _lerpSpeed);
			float t = LerpCurve.Evaluate(_currentSpeed);
			Wiggler.Speed = Mathf.Lerp(0f, 6f, t);
			Wiggler.Size = Mathf.Lerp(0f, 0.005f, t);
			ThrusterGlow.colorA = Color.Lerp(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 15), t);
			ThrusterGlow.colorB = Color.Lerp(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 20), t);
			ParticleSystem.EmissionModule emission = SparksTop.emission;
			ParticleSystem.EmissionModule emission2 = SparksBottom.emission;
			if (_currentSpeed > 0.6f)
			{
				emission.rateOverTime = 15f;
				emission2.rateOverTime = 15f;
			}
			else
			{
				emission.rateOverTime = 0f;
				emission2.rateOverTime = 0f;
			}
			ParticleSystem.MainModule main = ThrustersBlueTop.main;
			main.startLifetime = Mathf.Lerp(0f, 1f, _currentSpeed);
			main.startSpeed = Mathf.Lerp(0f, 1f, _currentSpeed);
			ParticleSystem.EmissionModule emission3 = ThrustersBlueTop.emission;
			if (_currentSpeed < 0.4f)
			{
				emission3.rateOverTime = 0f;
			}
			else
			{
				emission3.rateOverTime = Mathf.Lerp(0f, 500f, _currentSpeed);
			}
			ParticleSystem.MainModule main2 = ThrustersBlueBottom.main;
			main2.startLifetime = Mathf.Lerp(0f, 1f, _currentSpeed);
			main2.startSpeed = Mathf.Lerp(0f, 1f, _currentSpeed);
			ParticleSystem.EmissionModule emission4 = ThrustersBlueBottom.emission;
			if (_currentSpeed < 0.4f)
			{
				emission4.rateOverTime = 0f;
			}
			else
			{
				emission4.rateOverTime = Mathf.Lerp(0f, 500f, _currentSpeed);
			}
			ParticleSystem.MainModule main3 = ThrustersWhiteTop.main;
			main3.startLifetime = Mathf.Lerp(0f, 1.5f, _currentSpeed);
			main3.startSpeed = Mathf.Lerp(0f, 1f, _currentSpeed);
			ParticleSystem.EmissionModule emission5 = ThrustersWhiteTop.emission;
			if (_currentSpeed < 0.4f)
			{
				emission5.rateOverTime = 0f;
			}
			else
			{
				emission5.rateOverTime = Mathf.Lerp(0f, 500f, _currentSpeed);
			}
			ParticleSystem.MainModule main4 = ThrustersWhiteBottom.main;
			main4.startLifetime = Mathf.Lerp(0f, 1.5f, _currentSpeed);
			main4.startSpeed = Mathf.Lerp(0f, 1f, _currentSpeed);
			ParticleSystem.EmissionModule emission6 = ThrustersWhiteBottom.emission;
			if (_currentSpeed < 0.4f)
			{
				emission6.rateOverTime = 0f;
			}
			else
			{
				emission6.rateOverTime = Mathf.Lerp(0f, 500f, _currentSpeed);
			}
			_currentParticleSpeed = Mathf.Lerp(_currentParticleSpeed, _targetParticleSpeed, Time.deltaTime * _lerpParticleSpeed);
			float t2 = LerpCurve.Evaluate(_currentParticleSpeed);
			ParticleSystem.MainModule main5 = StarParticleSystem.main;
			main5.simulationSpeed = Mathf.Lerp(0.001f, 1f, t2);
			ParticleSystem.SizeBySpeedModule sizeBySpeed = StarParticleSystem.sizeBySpeed;
			sizeBySpeed.x = new ParticleSystem.MinMaxCurve(Mathf.Lerp(1f, 100f, t2), new AnimationCurve(new Keyframe(0f, Mathf.Lerp(1f, 0.1f, t2)), new Keyframe(1f, 1f, Mathf.Lerp(0f, 2f, t2), 0f)));
			ParticleSystem.MainModule main6 = DebrisParticleSystem.main;
			main6.simulationSpeed = Mathf.Lerp(0f, 1f, t2);
		}

		public void OverrideSpeed(float overrideEndAnimationNimbatusSpeed)
		{
			_targetSpeed = overrideEndAnimationNimbatusSpeed;
			_currentSpeed = _targetSpeed;
			UpdateSpeed();
		}

		public void OverrideParticleSpeed(float overrideEndAnimationParticleSpeed)
		{
			_targetParticleSpeed = overrideEndAnimationParticleSpeed;
			_currentParticleSpeed = _targetParticleSpeed;
			UpdateSpeed();
		}

		public void StopNimbatusImmediately()
		{
			_targetSpeed = 0f;
			_currentSpeed = _targetSpeed;
			UpdateSpeed();
			SparksTop.Clear();
			SparksBottom.Clear();
			ThrustersBlueTop.Clear();
			ThrustersBlueBottom.Clear();
			ThrustersWhiteTop.Clear();
			ThrustersWhiteBottom.Clear();
		}

		public void StopParticleImmediately()
		{
			_targetParticleSpeed = 0f;
			_currentParticleSpeed = _targetParticleSpeed;
			UpdateSpeed();
		}
	}
}
