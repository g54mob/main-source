using System;
using System.Collections;
using Assets.Scripts.Craft;
using Jundroo.Common.Extensions;
using Jundroo.Common.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class RocketExplosionScript : MonoBehaviour, IExplosionScript
	{
		[Serializable]
		private class DebrisComponent
		{
			[SerializeField]
			private DebrisConfiguration _config;

			[SerializeField]
			private GameObject _prefab;

			public DebrisConfiguration Config => _config;

			public GameObject Prefab => _prefab;

			public void Awake()
			{
				if (Prefab == null)
				{
					Debug.LogError("Rocket explosion debris prefab not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Rocket explosion debris configuration not found");
				}
			}
		}

		[Serializable]
		private class DebrisConfiguration
		{
			public float BlastDelay = 0.05f;

			public int CountMax = 5;

			public int CountMin = 3;

			public float ForceMax = 15f;

			public float ForceMin = 10f;

			public float Lifetime = 5f;

			public float ParticleEmitDuration = 1f;

			public float ScaleMax = 0.3f;

			public float ScaleMin = 0.1f;

			public float TorqueForce = 20f;
		}

		[Serializable]
		private class ExplosionCoreComponent
		{
			[SerializeField]
			private ExplosionCoreConfiguration _config;

			[SerializeField]
			private GameObject _object;

			public ExplosionCoreConfiguration Config => _config;

			public GameObject Object => _object;

			public ParticleSystem ParticleSystem { get; private set; }

			public void Awake()
			{
				if (Object == null)
				{
					Debug.LogError("Rocket explosion core component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Rocket explosion core component configuration not found");
				}
				ParticleSystem = Object.GetComponent<ParticleSystem>();
			}

			public void UpdateScale(float scale)
			{
				ParticleSystem.MainModule main = ParticleSystem.main;
				main.Scale((ParticleSystem.MainModule x) => x.startLifetime, scale);
				main.Scale((ParticleSystem.MainModule x) => x.startSize, scale);
				main.Scale((ParticleSystem.MainModule x) => x.startSpeed, scale);
			}
		}

		[Serializable]
		private class ExplosionCoreConfiguration
		{
		}

		[Serializable]
		private class ExplosionSoundComponent
		{
			[SerializeField]
			private ExplosionSoundComponentConfiguration _config;

			[SerializeField]
			private GameObject _object;

			public AudioSource AudioSource { get; private set; }

			public ExplosionSoundComponentConfiguration Config => _config;

			public GameObject Object => _object;

			public void Awake()
			{
				if (Object == null)
				{
					Debug.LogError("Rocket explosion sound component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Rocket explosion sound component configuration not found");
				}
				AudioSource = Object.GetComponent<AudioSource>();
			}
		}

		[Serializable]
		private class ExplosionSoundComponentConfiguration
		{
		}

		[Serializable]
		private class ExplosiveForceComponent
		{
			[SerializeField]
			private ExplosiveForceComponentConfiguration _config;

			[SerializeField]
			private GameObject _object;

			public ExplosiveForceComponentConfiguration Config => _config;

			public GameObject Object => _object;

			public ExplosiveForceScript Script { get; private set; }

			public void Awake()
			{
				if (Object == null)
				{
					Debug.LogError("Rocket explosive force compontent object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Rocket explosive force compontent configuration not found");
				}
				Script = Object.GetComponent<ExplosiveForceScript>();
			}

			public void UpdateConfiguration(float scale)
			{
				Script.BlastForce = Config.BlastForce;
				Script.BlastRadius = Config.BlastRadius;
				Script.CriticalBlastRadius = Config.CriticalBlastRadius;
			}
		}

		[Serializable]
		private class ExplosiveForceComponentConfiguration
		{
			public float BlastForce = 60f;

			public float BlastRadius = 4f;

			public float CriticalBlastRadius = 1.5f;
		}

		[SerializeField]
		[InspectorFieldOrder(103)]
		private DebrisComponent _debris;

		[SerializeField]
		private bool _drawGizmos;

		[SerializeField]
		[InspectorFieldOrder(101)]
		private ExplosionCoreComponent _explosionCore;

		[SerializeField]
		[InspectorFieldOrder(104)]
		private ExplosionSoundComponent _explosionSound;

		[SerializeField]
		[InspectorFieldOrder(105)]
		private ExplosiveForceComponent _explosiveForce;

		[SerializeField]
		[Range(0.5f, 2f)]
		private float _scale = 1f;

		[SerializeField]
		private float _totalLifetime = 6f;

		public ExplosiveForceScript ExplosiveForce => _explosiveForce.Script;

		public void Explode(float scale, Vector3? blastDirection, AircraftScript owner, Rigidbody ownerBody, Vector3? impactDirection, ExplosiveWeaponImpactType impactType)
		{
			Explode(scale, disableChunks: true, owner, ownerBody, impactDirection);
		}

		protected virtual void Awake()
		{
			_explosionCore.Awake();
			_debris.Awake();
			_explosionSound.Awake();
			_explosiveForce.Awake();
		}

		protected virtual void OnDrawGizmos()
		{
			if (_drawGizmos)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(_explosiveForce.Object.transform.position, _explosiveForce.Config.CriticalBlastRadius * _scale);
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireSphere(_explosiveForce.Object.transform.position, _explosiveForce.Config.BlastRadius * _scale);
			}
		}

		private IEnumerator DebrisBlast()
		{
			yield return new WaitForSeconds(_debris.Config.BlastDelay);
			Transform transform = new GameObject("Debris").transform;
			transform.SetParent(base.transform);
			transform.localScale = Vector3.one;
			transform.localRotation = Quaternion.identity;
			transform.localPosition = Vector3.zero;
			StartCoroutine(DebrisDestroy(transform.gameObject));
			int num = (int)((float)UnityEngine.Random.Range(_debris.Config.CountMin, _debris.Config.CountMax) * _scale);
			for (int i = 0; i < num; i++)
			{
				ExplosionDebrisScript component = UnityEngine.Object.Instantiate(_debris.Prefab).GetComponent<ExplosionDebrisScript>();
				component.transform.SetParent(transform);
				component.transform.localPosition = Vector3.zero;
				component.MeshRenderer.transform.localScale = Vector3.one * (UnityEngine.Random.Range(_debris.Config.ScaleMin, _debris.Config.ScaleMax) * _scale);
				Vector3 force = UnityEngine.Random.onUnitSphere * (UnityEngine.Random.Range(_debris.Config.ForceMin, _debris.Config.ForceMax) * _scale);
				Rigidbody rigidbody = component.Rigidbody;
				rigidbody.mass *= _scale;
				rigidbody.AddForce(force, ForceMode.Impulse);
				rigidbody.AddTorque(UnityEngine.Random.insideUnitSphere * (_debris.Config.TorqueForce * _scale));
				ParticleSystem.MainModule main = component.ParticleSystem.main;
				main.Scale((ParticleSystem.MainModule x) => x.startSize, _scale);
				main.Scale((ParticleSystem.MainModule x) => x.startLifetime, _scale);
				StartCoroutine(DebrisStopEmission(component));
				StartCoroutine(DebrisDestroy(component.gameObject));
			}
		}

		private IEnumerator DebrisDestroy(GameObject debris)
		{
			yield return new WaitForSeconds(_debris.Config.Lifetime * _scale);
			UnityEngine.Object.Destroy(debris);
		}

		private IEnumerator DebrisStopEmission(ExplosionDebrisScript debris)
		{
			yield return new WaitForSeconds(_debris.Config.ParticleEmitDuration * _scale);
			ParticleSystem.EmissionModule emission = debris.ParticleSystem.emission;
			emission.rateOverDistance = new ParticleSystem.MinMaxCurve(0f);
			_drawGizmos = false;
		}

		private void Explode(float scale, bool disableChunks, AircraftScript owner, Rigidbody rocketBody, Vector3? impactDirection)
		{
			_scale = scale;
			_explosionCore.UpdateScale(_scale);
			_explosionCore.ParticleSystem.Play(withChildren: true);
			_explosionSound.AudioSource.pitch = 1f;
			_explosionSound.AudioSource.PlayDelayed(Vector3.Distance(FlightSceneScript.Instance.LocalPlayer?.FramePosition ?? Vector3.zero, base.transform.position) / 340.29f);
			_explosiveForce.UpdateConfiguration(1f);
			_explosiveForce.Script.Detonate(owner, rocketBody, impactDirection);
			if (!disableChunks)
			{
				StartCoroutine(DebrisBlast());
			}
			UnityEngine.Object.Destroy(base.gameObject, _totalLifetime);
		}
	}
}
