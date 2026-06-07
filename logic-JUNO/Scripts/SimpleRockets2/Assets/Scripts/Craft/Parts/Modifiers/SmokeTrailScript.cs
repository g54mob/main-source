using Assets.Scripts.Flight;
using ModApi.Flight;
using ModApi.Flight.GameView;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class SmokeTrailScript : MonoBehaviour
	{
		private struct EmissionFrame
		{
			public Vector3 Position;

			public float Time;

			public Vector3 Velocity;
		}

		private const int MaxParticlesPerFrame = 10;

		private Color _color = Color.white;

		private float _currentLight = 1f;

		private float _emissionRate;

		private ParticleSystem.EmitParams _emitParams;

		private float _lastEmissionTime;

		private EmissionFrame? _lastFrame;

		private float _maxLifetime;

		private float _maxParticleSize;

		private float _maxParticleSpeed;

		private ParticleSystem.ForceOverLifetimeModule _moduleForce;

		private ParticleSystem.MainModule _moduleMain;

		private PartScript _partScript;

		private ParticleSystem _ps;

		private float _timeBetweenParticles;

		private ITimeManager _timeManager;

		private float _totalTime;

		private Transform _transform;

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public bool EmissionEnabled { get; set; }

		public float EmissionOpacity { get; set; }

		public float ExpansionSize { get; set; } = 1f;

		public float Intensity { get; set; }

		public float Light { get; set; } = 1f;

		public float SpeedOverride { get; set; } = 1f;

		private Rigidbody RigidBody => _partScript.BodyScript.RigidBody;

		public void FlightUpdate(Vector3 surfaceVelocity)
		{
			float num = (float)_timeManager.DeltaTime;
			_totalTime += num;
			_moduleMain.simulationSpeed = num / Time.deltaTime;
			Vector3 vector = -surfaceVelocity * Mathf.Min(1f, 0.75f * _partScript.CraftScript.AtmosphereSample.AirDensity);
			_moduleForce.x = vector.x;
			_moduleForce.y = vector.y;
			_moduleForce.z = vector.z;
		}

		protected virtual void Awake()
		{
			if (Game.InFlightScene)
			{
				_transform = base.transform;
				_ps = GetComponent<ParticleSystem>();
				_emitParams = default(ParticleSystem.EmitParams);
				_moduleMain = _ps.main;
				_moduleForce = _ps.forceOverLifetime;
				_moduleForce.enabled = true;
				_moduleForce.space = ParticleSystemSimulationSpace.World;
				_maxLifetime = _moduleMain.startLifetime.constant;
				_maxParticleSize = _moduleMain.startSize.constant;
				_maxParticleSpeed = _moduleMain.startSpeed.constant;
				_color = _moduleMain.startColor.color;
				ParticleSystem.EmissionModule emission = _ps.emission;
				emission.enabled = false;
				_emissionRate = emission.rateOverTime.constant;
				if (_emissionRate > 0f)
				{
					_timeBetweenParticles = 1f / _emissionRate;
				}
				else
				{
					_timeBetweenParticles = 1f;
				}
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}

		protected virtual void LateUpdate()
		{
			_currentLight = Mathf.Lerp(_currentLight, Light, 0.5f * Time.deltaTime);
			if (!EmissionEnabled || EmissionOpacity == 0f || Time.timeScale == 0f)
			{
				_lastFrame = null;
				return;
			}
			float num = ((Time.timeScale < 1f) ? 1f : Time.timeScale);
			EmissionFrame value = new EmissionFrame
			{
				Velocity = RigidBody.velocity + _transform.forward * (_maxParticleSpeed * Intensity * SpeedOverride),
				Position = _transform.position,
				Time = _totalTime
			};
			if (_lastFrame.HasValue)
			{
				EmissionFrame value2 = _lastFrame.Value;
				float num2 = value.Time - value2.Time;
				if (num2 > 0f)
				{
					if (_lastEmissionTime < value2.Time)
					{
						_lastEmissionTime = value2.Time;
					}
					int num3 = 0;
					while (_lastEmissionTime <= _totalTime && num3++ < 10)
					{
						float t = (_lastEmissionTime - value2.Time) / num2;
						float num4 = _totalTime - _lastEmissionTime;
						_emitParams.startLifetime = _maxLifetime * Random.Range(0.9f, 1f);
						_emitParams.startSize = _maxParticleSize * Intensity * ExpansionSize * Random.Range(0.9f, 1f);
						_emitParams.velocity = Vector3.Lerp(value2.Velocity, value.Velocity, t);
						_emitParams.position = Vector3.Lerp(value2.Position, value.Position, t) + _emitParams.velocity * num4;
						float num5 = Random.Range(0.5f, 1f);
						_emitParams.startColor = new Color(_color.r * num5 * _currentLight, _color.g * num5 * _currentLight, _color.b * num5 * _currentLight, _color.a * EmissionOpacity);
						_ps.Emit(_emitParams, 1);
						_lastEmissionTime += _timeBetweenParticles * num;
					}
				}
			}
			_lastFrame = value;
		}

		protected virtual void OnDestroy()
		{
			UpdateEventSubscriptions(subscribe: false);
		}

		protected virtual void Start()
		{
			UpdateEventSubscriptions(subscribe: true);
			_timeManager = FlightSceneScript.Instance.TimeManager;
			_partScript = GetComponentInParent<PartScript>();
			base.gameObject.layer = 0;
		}

		private void OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
		{
			if (_lastFrame.HasValue)
			{
				_lastFrame = null;
			}
		}

		private void UpdateEventSubscriptions(bool subscribe)
		{
			IGameView gameView = Game.Instance?.FlightScene?.ViewManager?.GameView;
			if (gameView != null)
			{
				if (subscribe)
				{
					gameView.ReferenceFrameRecentered += OnReferenceFrameRecentered;
				}
				else
				{
					gameView.ReferenceFrameRecentered -= OnReferenceFrameRecentered;
				}
			}
		}
	}
}
