using System;
using Assets.Scripts.Flight.Events;
using Jundroo.Common.Extensions;
using UnityEngine;
using WaveHarmonic.Crest;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Sea
{
	public class AircraftCarrierScript : MonoBehaviour
	{
		private bool _isSinking;

		[SerializeField]
		private float _speed = 8f;

		[SerializeField]
		private float[] _wakeParticleEmissionRates;

		[SerializeField]
		private ParticleSystem[] _wakeParticleSystems;

		[SerializeField]
		private AnimatedWavesLodInput _wakeWave;

		public bool IsSinkable => SinkableShip != null;

		protected virtual Rigidbody RigidBody { get; private set; }

		protected virtual SinkableShipScript SinkableShip { get; private set; }

		protected virtual void Awake()
		{
			RigidBody = GetComponent<Rigidbody>();
			SinkableShip = GetComponent<SinkableShipScript>();
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded -= OnPlayerLoaded;
			}
			if (SinkableShip != null)
			{
				SinkableShip.StartedSinking -= StartedSinking;
			}
			ParticleSystem[] wakeParticleSystems = _wakeParticleSystems;
			foreach (ParticleSystem particleSystem in wakeParticleSystems)
			{
				if (particleSystem != null)
				{
					UnityEngine.Object.Destroy(particleSystem.gameObject);
				}
			}
			if (_wakeWave != null)
			{
				UnityEngine.Object.Destroy(_wakeWave.gameObject);
			}
		}

		protected virtual void Start()
		{
			RigidBody.centerOfMass = Vector3.zero;
			RigidBody.inertiaTensorRotation = Quaternion.identity;
			RigidBody.inertiaTensor = Vector3.zero;
			RigidBody.linearVelocity = base.transform.forward * _speed;
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded += OnPlayerLoaded;
				instance.RaiseLocalPlayerLoaded(OnPlayerLoaded);
			}
			if (SinkableShip != null)
			{
				SinkableShip.StartedSinking += StartedSinking;
			}
		}

		protected virtual void Update()
		{
			Vector3 linearVelocity = RigidBody.linearVelocity;
			Vector3 v = linearVelocity;
			float? y = 0f;
			float magnitude = v.Copy(null, y).magnitude;
			if (!IsSinkable || !SinkableShip.Sinking)
			{
				Rigidbody rigidBody = RigidBody;
				Vector3 v2 = base.transform.forward * magnitude;
				y = linearVelocity.y;
				rigidBody.linearVelocity = v2.Copy(null, y);
			}
			float num = Mathf.Min(_speed, magnitude);
			float num2 = num / _speed;
			bool flag = num <= 1f || _isSinking;
			if (_wakeWave != null)
			{
				_wakeWave.Weight = (flag ? 0f : num2);
			}
			for (int i = 0; i < _wakeParticleSystems.Length; i++)
			{
				if (!(_wakeParticleSystems[i] != null))
				{
					continue;
				}
				ParticleSystem.MainModule main = _wakeParticleSystems[i].main;
				main.startSpeed = 0f - num;
				ParticleSystem.EmissionModule emission = _wakeParticleSystems[i].emission;
				emission.rateOverTime = num2 * _wakeParticleEmissionRates[i];
				if (flag)
				{
					emission.rateOverTime = 0f;
					if (emission.enabled && _wakeParticleSystems[i].particleCount == 0)
					{
						emission.enabled = false;
					}
				}
				else if (!emission.enabled)
				{
					emission.enabled = true;
				}
			}
		}

		private void OnPlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			ReinitializeWaterTrail();
		}

		private void ReinitializeWaterTrail()
		{
			ParticleSystem[] wakeParticleSystems;
			if (_isSinking)
			{
				wakeParticleSystems = _wakeParticleSystems;
				foreach (ParticleSystem particleSystem in wakeParticleSystems)
				{
					if (particleSystem != null)
					{
						particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
					}
				}
				_wakeWave.Weight = 0f;
				return;
			}
			float num = ((_speed <= 0f) ? 0f : _speed);
			_wakeWave.Weight = ((num > 0f) ? 1 : 0);
			wakeParticleSystems = _wakeParticleSystems;
			foreach (ParticleSystem particleSystem2 in wakeParticleSystems)
			{
				if (particleSystem2 != null)
				{
					ParticleSystem.MainModule main = particleSystem2.main;
					main.startSpeed = 0f - num;
					if (num < 0f)
					{
						particleSystem2.Simulate(90f, withChildren: true, restart: true);
						particleSystem2.Play(withChildren: true);
					}
				}
			}
		}

		private void StartedSinking(object sender, EventArgs e)
		{
			_isSinking = true;
			ParticleSystem[] wakeParticleSystems = _wakeParticleSystems;
			foreach (ParticleSystem particleSystem in wakeParticleSystems)
			{
				if (particleSystem != null)
				{
					particleSystem.transform.parent = base.transform.parent;
				}
			}
		}
	}
}
