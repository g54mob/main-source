using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class CounterMeasureScript : MonoBehaviour
	{
		private static AnimationCurve _sharedEvadeCurve;

		private AircraftScript _aircraft;

		private AudioSource _audio;

		private float _audioDispersionRate;

		private bool _audioLoops;

		private float _breakDispersionRate = 0.25f;

		private float _breakEffectToDisperse;

		private float _breakLockChance;

		private AnimationCurve _evadeCurve;

		private float _evadeEffectToDisperse;

		private float _evadeLockChance;

		private float _evasionDispersionRate = 0.25f;

		private float _gravityMultiplier;

		private bool _hasBegun;

		private List<ParticleSystem> _particleSystems;

		private Rigidbody _rigidbody;

		private PlayerTarget _target;

		public SignatureType SignatureType { get; private set; }

		public void SetupAndBegin(SignatureType signatureType, AircraftScript aircraft, float breakLockChance, float evadeLockChance, Vector3 startVelocity, float drag = 1f, Vector3? angularVelocity = null, float gravityMultiplier = 0f, bool audioLoops = false, float dispersionRate = 0.25f)
		{
			SignatureType = signatureType;
			_aircraft = aircraft;
			_target = aircraft.Target as PlayerTarget;
			_breakLockChance = breakLockChance;
			_evadeLockChance = evadeLockChance;
			_evasionDispersionRate = dispersionRate;
			_breakDispersionRate = dispersionRate;
			_audio = GetComponent<AudioSource>();
			_audioDispersionRate = _audio.volume * dispersionRate;
			_audioLoops = audioLoops;
			if (_sharedEvadeCurve == null)
			{
				_sharedEvadeCurve = Resources.Load<CurveObject>("Data/Weapons/CountermeasureEvadeCurve").Curve;
			}
			_evadeCurve = _sharedEvadeCurve;
			_gravityMultiplier = gravityMultiplier;
			_particleSystems = new List<ParticleSystem>(GetComponentsInChildren<ParticleSystem>());
			for (int i = 0; i < _particleSystems.Count; i++)
			{
				ParticleSystem.MainModule main = _particleSystems[i].main;
				main.playOnAwake = false;
				_particleSystems[i].Stop();
			}
			_rigidbody = base.gameObject.AddMissingComponent<Rigidbody>();
			_rigidbody.linearDamping = drag;
			_rigidbody.linearVelocity = startVelocity;
			if (angularVelocity.HasValue)
			{
				_rigidbody.angularVelocity = angularVelocity.Value;
			}
			StartCoroutine(BeginEffect(0.1f));
		}

		protected virtual void FixedUpdate()
		{
			_rigidbody.AddForce(Physics.gravity * (_rigidbody.mass * _gravityMultiplier));
		}

		protected virtual void OnDestroy()
		{
			if (_aircraft != null && _evadeEffectToDisperse > 0f)
			{
				_target.AddEvadeLockProbability(SignatureType, 0f - _evadeEffectToDisperse);
			}
			if (_aircraft != null && _breakEffectToDisperse > 0f)
			{
				_target.AddBreakLockProbability(SignatureType, 0f - _breakEffectToDisperse);
			}
		}

		protected virtual void Update()
		{
			if (PauseManager.Paused || !_hasBegun)
			{
				return;
			}
			if (_evadeEffectToDisperse > 0f)
			{
				float num = Time.deltaTime * _evasionDispersionRate;
				_target.AddEvadeLockProbability(SignatureType, 0f - num);
				_evadeEffectToDisperse -= num;
				if (_evadeEffectToDisperse < 0f && _target.GetEvadeLockProbability(SignatureType) > 0f)
				{
					_target.AddEvadeLockProbability(SignatureType, 0f - _evadeEffectToDisperse);
					_evadeEffectToDisperse = 0f;
				}
			}
			if (_breakEffectToDisperse > 0f)
			{
				float num2 = Time.deltaTime * _breakDispersionRate;
				_target.AddBreakLockProbability(SignatureType, 0f - num2);
				_breakEffectToDisperse -= num2;
				if (_breakEffectToDisperse < 0f && _target.GetBreakLockProbability(SignatureType) > 0f)
				{
					_target.AddEvadeLockProbability(SignatureType, 0f - _breakEffectToDisperse);
					_breakEffectToDisperse = 0f;
				}
			}
			if (_audioLoops)
			{
				_audio.volume = Mathf.Clamp01(_audio.volume - _audioDispersionRate * Time.deltaTime);
			}
			if (base.transform.position.y < GameWorld.Instance.FloatingOriginSeaLevel)
			{
				StartCoroutine(RemovePhysicalEvidenceAfter(0f));
			}
		}

		private IEnumerator BeginEffect(float startDelay)
		{
			yield return new WaitForSeconds(startDelay / 2f);
			if (_aircraft == null)
			{
				yield break;
			}
			for (int i = 0; i < _particleSystems.Count; i++)
			{
				_particleSystems[i].Play();
			}
			if (!_audio.isPlaying)
			{
				_audio.Play();
				if (_audioLoops)
				{
					_audio.timeSamples = (int)(Random.value * (float)_audio.clip.samples);
				}
			}
			ParticleSystem.MainModule main = _particleSystems[0].main;
			Object.Destroy(base.gameObject, main.startLifetime.constantMax + main.duration);
			StartCoroutine(RemovePhysicalEvidenceAfter(main.duration));
			_hasBegun = true;
			yield return new WaitForSeconds(startDelay / 2f);
			float signature = _target.GetSignature(SignatureType);
			float num = _breakLockChance * (1f - _target.GetBreakLockProbability(SignatureType)) * _evadeCurve.Evaluate(signature);
			_target.AddBreakLockProbability(SignatureType, num);
			_breakEffectToDisperse = num;
			float num2 = _evadeLockChance * (1f - _target.GetEvadeLockProbability(SignatureType)) * _evadeCurve.Evaluate(signature);
			_target.AddEvadeLockProbability(SignatureType, num2);
			_evadeEffectToDisperse = num2;
		}

		private IEnumerator RemovePhysicalEvidenceAfter(float delay)
		{
			yield return new WaitForSeconds(delay);
			Transform transform = base.transform.Find("Mesh");
			if (transform != null)
			{
				Object.Destroy(transform.gameObject);
			}
			if (TryGetComponent<Rigidbody>(out var component))
			{
				component.useGravity = false;
				component.isKinematic = true;
			}
			if (TryGetComponent<Collider>(out var component2))
			{
				component2.enabled = false;
			}
			if (_audio != null && _audio.isPlaying)
			{
				_audio.Stop();
			}
			for (int i = 0; i < _particleSystems.Count; i++)
			{
				_particleSystems[i].Stop();
			}
		}
	}
}
