using ModApi;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Flight.Effects
{
	public class LaunchParticleController : MonoBehaviour
	{
		private Vector3[] _additionalVectors;

		[SerializeField]
		[FormerlySerializedAs("_speedToEmissionRate")]
		private AnimationCurve _distanceToEmissionRate;

		[SerializeField]
		private float _emissionDistanceDivisor = 150f;

		[SerializeField]
		private float _emissionDistanceMultiplier = 30f;

		private Vector3[] _lastEmittedPositions;

		private int _lastParticleCount;

		[SerializeField]
		private Vector3 _maxVelocityDirection = Vector3.one;

		[SerializeField]
		private Vector3 _minVelocityDirection = -Vector3.one;

		private ParticleSystem.Particle[] _particles;

		private ParticleSystem _particleSystem;

		private ParticleSystem[] _subSystems;

		public float EmissionDistanceDivisor
		{
			get
			{
				return _emissionDistanceDivisor;
			}
			set
			{
				_emissionDistanceDivisor = value;
			}
		}

		public float EmissionDistanceMultiplier
		{
			get
			{
				return _emissionDistanceMultiplier;
			}
			set
			{
				_emissionDistanceMultiplier = value;
			}
		}

		public void TriggerSteamParticles()
		{
			_particleSystem.Play();
		}

		private void Awake()
		{
			_particleSystem = GetComponent<ParticleSystem>();
			InitializeArrays();
			_subSystems = new ParticleSystem[_particleSystem.subEmitters.subEmittersCount];
			for (int i = 0; i < _particleSystem.subEmitters.subEmittersCount; i++)
			{
				_subSystems[i] = _particleSystem.subEmitters.GetSubEmitterSystem(i);
			}
		}

		private Vector3 GetNewRandomDirection()
		{
			return new Vector3(Random.Range(_minVelocityDirection.x, _maxVelocityDirection.x), Random.Range(_minVelocityDirection.y, _maxVelocityDirection.y), Random.Range(_minVelocityDirection.z, _maxVelocityDirection.z));
		}

		private void InitializeArrays()
		{
			_particles = new ParticleSystem.Particle[_particleSystem.particleCount];
			if (_lastEmittedPositions != null && _lastEmittedPositions.Length != 0)
			{
				Vector3[] lastEmittedPositions = _lastEmittedPositions;
				_lastEmittedPositions = new Vector3[_particles.Length];
				for (int i = 0; i < lastEmittedPositions.Length; i++)
				{
					if (_lastEmittedPositions.Length > i)
					{
						_lastEmittedPositions[i] = lastEmittedPositions[i];
					}
				}
			}
			else
			{
				_lastEmittedPositions = new Vector3[_particles.Length];
			}
			_additionalVectors = new Vector3[_particles.Length];
			for (int j = 0; j < _additionalVectors.Length; j++)
			{
				_additionalVectors[j] = GetNewRandomDirection();
			}
		}

		private void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
			{
				TriggerSteamParticles();
			}
			if (!_particleSystem.isPlaying)
			{
				return;
			}
			if (_particleSystem.particleCount != _lastParticleCount)
			{
				InitializeArrays();
				_lastParticleCount = _particleSystem.particleCount;
			}
			_particleSystem.GetParticles(_particles);
			for (int i = 0; i < _particles.Length; i++)
			{
				Vector3 target = _additionalVectors[i] * _particles[i].velocity.magnitude;
				_particles[i].velocity = Vector3.RotateTowards(_particles[i].velocity, target, Time.deltaTime, Time.deltaTime);
				if (Utilities.CompareVector3s(_particles[i].velocity.normalized, target.normalized))
				{
					_additionalVectors[i] = GetNewRandomDirection();
				}
			}
			_particleSystem.SetParticles(_particles, _particles.Length);
			for (int j = 0; j < _particles.Length; j++)
			{
				float num = _distanceToEmissionRate.Evaluate(Mathf.Clamp01(_particles[j].position.magnitude / _emissionDistanceDivisor)) * _emissionDistanceMultiplier;
				if (Vector3.Distance(_lastEmittedPositions[j], _particles[j].position) > num)
				{
					ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
					{
						applyShapeToPosition = true,
						position = _particles[j].position,
						startSize = _particles[j].GetCurrentSize(_particleSystem)
					};
					for (int k = 0; k < _subSystems.Length; k++)
					{
						_subSystems[k].Emit(emitParams, 1);
						_lastEmittedPositions[j] = emitParams.position;
					}
				}
			}
		}
	}
}
