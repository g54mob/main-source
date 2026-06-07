using System;
using System.Collections;
using Assets.Scripts.Craft;
using Jundroo.Common.Extensions;
using Jundroo.Common.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class MissileExplosionScript : ExplosionBaseScript
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
					Debug.LogError("Missile explosion debris prefab not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Missile explosion debris configuration not found");
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

			public VolumetricExplosionScript VolumetricExplosion { get; private set; }

			public void Awake()
			{
				if (Object == null)
				{
					Debug.LogError("Missile explosion core component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Missile explosion core component configuration not found");
				}
				ParticleSystem = Object.GetComponent<ParticleSystem>();
				VolumetricExplosion = Object.GetComponent<VolumetricExplosionScript>();
			}

			public void UpdateProperties(float scale, ExplosiveWeaponImpactType impactType, Vector3? direction = null)
			{
				if (ParticleSystem != null)
				{
					ParticleSystem.MainModule main = ParticleSystem.main;
					main.Scale((ParticleSystem.MainModule x) => x.startLifetime, scale);
					main.Scale((ParticleSystem.MainModule x) => x.startSize, scale);
					main.Scale((ParticleSystem.MainModule x) => x.startSpeed, scale);
				}
				if (VolumetricExplosion != null)
				{
					VolumetricExplosion.transform.localScale = 0.75f * scale * Vector3.one;
					VolumetricExplosion.Duration = Mathf.Clamp(4f * scale, 0f, 25f);
					VolumetricExplosion.Stem = impactType != ExplosiveWeaponImpactType.Air && impactType != ExplosiveWeaponImpactType.Structure;
					VolumetricExplosion.Stem = scale > 9f && VolumetricExplosion.Stem;
					if (direction.HasValue && impactType == ExplosiveWeaponImpactType.Air)
					{
						VolumetricExplosion.transform.up = direction.Value;
						VolumetricExplosion.RaiseAmount = 2f;
						VolumetricExplosion.Shroom = 0f;
					}
					else
					{
						VolumetricExplosion.RaiseAmount = (VolumetricExplosion.Stem ? 0.9f : 0.2f);
						VolumetricExplosion.Shroom = UnityEngine.Random.Range(0f, 0.2f);
					}
				}
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
					Debug.LogError("Missile explosion sound component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Missile explosion sound component configuration not found");
				}
				AudioSource = Object.GetComponent<AudioSource>();
			}
		}

		[Serializable]
		private class ExplosionSoundComponentConfiguration
		{
		}

		[Serializable]
		private class ExplosionSparksComponent
		{
			[SerializeField]
			private ExplosionSparksConfiguration _config;

			[SerializeField]
			private GameObject _object;

			public ExplosionSparksConfiguration Config => _config;

			public GameObject Object => _object;

			public ParticleSystem ParticleSystem { get; private set; }

			public void Awake()
			{
				if (Object == null)
				{
					Debug.LogError("Missile explosion sparks component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Missile explosion sparks component configuration not found");
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
		private class ExplosionSparksConfiguration
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
					Debug.LogError("Missile explosive force component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Missile explosive force component configuration not found");
				}
				Script = Object.GetComponent<ExplosiveForceScript>();
			}

			public void UpdateConfiguration(float scale)
			{
				Script.BlastForce = Config.BlastForce * scale;
				Script.BlastRadius = Config.BlastRadius * scale;
				Script.CriticalBlastRadius = Config.CriticalBlastRadius * scale;
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
		[InspectorFieldOrder(102)]
		private ExplosionSparksComponent _explosionSparks;

		[SerializeField]
		[InspectorFieldOrder(105)]
		private ExplosiveForceComponent _explosiveForce;

		[SerializeField]
		[Range(0.5f, 2f)]
		private float _scale = 1f;

		[SerializeField]
		private float _totalLifetime = 6f;

		public override ExplosiveForceScript ExplosiveForce => _explosiveForce.Script;

		public override void Explode(float scale, Vector3? blastDirection, AircraftScript owner, Rigidbody ownerBody, Vector3? impactDirection, ExplosiveWeaponImpactType impactType)
		{
			_scale = Mathf.Clamp(scale, 0f, 15f);
			_explosionCore.UpdateProperties(_scale, impactType, impactDirection);
			if (_explosionCore.ParticleSystem != null)
			{
				_explosionCore.ParticleSystem.Play();
			}
			_explosionSparks.UpdateScale(_scale);
			_explosionSparks.ParticleSystem.Play();
			_explosionSound.AudioSource.pitch = 1f / _scale;
			_explosionSound.AudioSource.PlayDelayed(Vector3.Distance(FlightSceneScript.Instance.LocalPlayer?.FramePosition ?? Vector3.zero, base.transform.position) / 340.29f);
			_explosiveForce.UpdateConfiguration(_scale);
			_explosiveForce.Script.Detonate(owner, ownerBody, impactDirection);
			StartCoroutine(DebrisBlast());
			UnityEngine.Object.Destroy(base.gameObject, _totalLifetime);
		}

		protected virtual void Awake()
		{
			_explosionCore.Awake();
			_explosionSparks.Awake();
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
			float num = ((_scale > 1f) ? Mathf.Sqrt(_scale) : _scale);
			int num2 = (int)((float)UnityEngine.Random.Range(_debris.Config.CountMin, _debris.Config.CountMax) * num);
			for (int i = 0; i < num2; i++)
			{
				ExplosionDebrisScript component = UnityEngine.Object.Instantiate(_debris.Prefab).GetComponent<ExplosionDebrisScript>();
				component.transform.SetParent(transform);
				component.transform.localPosition = Vector3.zero;
				component.MeshRenderer.transform.localScale = Vector3.one * (UnityEngine.Random.Range(_debris.Config.ScaleMin, _debris.Config.ScaleMax) * num);
				Vector3 force = UnityEngine.Random.onUnitSphere * (UnityEngine.Random.Range(_debris.Config.ForceMin, _debris.Config.ForceMax) * num);
				Rigidbody rigidbody = component.Rigidbody;
				rigidbody.mass *= num;
				rigidbody.AddForce(force, ForceMode.Impulse);
				rigidbody.AddTorque(UnityEngine.Random.insideUnitSphere * (_debris.Config.TorqueForce * num));
				ParticleSystem.MainModule main = component.ParticleSystem.main;
				main.Scale((ParticleSystem.MainModule x) => x.startSize, num);
				main.Scale((ParticleSystem.MainModule x) => x.startLifetime, num);
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
	}
}
