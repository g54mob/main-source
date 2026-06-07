using System;
using System.Collections;
using Assets.Scripts.Craft;
using Jundroo.Common.Collections;
using Jundroo.Common.Extensions;
using Jundroo.Common.Inspector;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Flight.Explosions
{
	public class BombExplosionScript : ExplosionBaseScript
	{
		[Serializable]
		private class BurnMarkComponent
		{
			[SerializeField]
			private BurnMarkConfiguration _config;

			[SerializeField]
			private GameObject _object;

			public BurnMarkConfiguration Config => _config;

			public GameObject Object => _object;

			public DecalProjector Projector { get; private set; }

			public BombExplosionBurnMarkScript Script { get; private set; }

			public void Awake()
			{
				if (Object == null)
				{
					Debug.LogError("Bomb explosion burn mark component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Bomb explosion burn mark component configuration not found");
				}
				Script = Object.GetComponent<BombExplosionBurnMarkScript>();
				Projector = Object.GetComponent<DecalProjector>();
				Projector.enabled = false;
			}
		}

		[Serializable]
		private class BurnMarkConfiguration
		{
			public float AppearanceDelay = 0.1f;

			public float AppearanceLerpTime = 0.2f;

			public float Lifetime = 12f;

			public float Size = 20f;
		}

		[Serializable]
		private class DebrisComponent
		{
			[SerializeField]
			private DebrisConfiguration _config;

			[SerializeField]
			private ParticleSystem _smoke;

			[SerializeField]
			private ParticleSystem _system;

			public DebrisConfiguration Config => _config;

			public ParticleSystem ParticleSystem => _system;

			public ParticleSystem SubParticleSystem => _smoke;

			public void Awake()
			{
				if (ParticleSystem == null)
				{
					Debug.LogError("Bomb explosion debris particle system not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Bomb explosion debris configuration not found");
				}
			}

			public void UpdateScale(float scale)
			{
				ParticleSystem.MainModule main = ParticleSystem.main;
				main.Scale((ParticleSystem.MainModule mainModule) => mainModule.startSize, scale);
				main.Scale((ParticleSystem.MainModule mainModule) => mainModule.startSpeed, scale);
				main.Scale((ParticleSystem.MainModule mainModule) => mainModule.startLifetime, scale);
				ParticleSystem.transform.localPosition = Vector3.up * (scale * 4f);
				main = SubParticleSystem.main;
				main.Scale((ParticleSystem.MainModule mainModule) => mainModule.startSize, scale);
				main.Scale((ParticleSystem.MainModule mainModule) => mainModule.startSpeed, scale);
				SubParticleSystem.emission.Scale((ParticleSystem.EmissionModule e) => e.rateOverDistance, 1f / scale);
			}
		}

		[Serializable]
		private class DebrisConfiguration
		{
			public float AngleMax = 45f;

			public float BlastDelay = 0.2f;

			public int CountMax = 60;

			public int CountMin = 40;

			public float ForceMax = 30f;

			public float ForceMin = 20f;

			public float Lifetime = 10f;

			public float ParticleEmitDuration = 2f;

			public float ScaleMax = 0.8f;

			public float ScaleMin = 0.3f;

			public float TorqueForce = 50f;
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
					Debug.LogError("Bomb explosion core component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Bomb explosion core component configuration not found");
				}
				ParticleSystem = Object.GetComponent<ParticleSystem>();
				VolumetricExplosion = Object.GetComponent<VolumetricExplosionScript>();
			}

			public void UpdateProperties(float scale, ExplosiveWeaponImpactType impactType)
			{
				if (ParticleSystem != null)
				{
					ParticleSystem.transform.localScale *= scale;
					scale = Mathf.Clamp(scale, 0.01f, 15f);
					ParticleSystem.MainModule main = ParticleSystem.main;
					main.Scale((ParticleSystem.MainModule x) => x.startLifetime, scale);
					main.Scale((ParticleSystem.MainModule x) => x.startSpeed, 1f / scale);
				}
				if (VolumetricExplosion != null)
				{
					VolumetricExplosion.transform.localScale = 4f * scale * Vector3.one;
					VolumetricExplosion.Duration = Mathf.Clamp(12f * scale, 0f, 25f);
					VolumetricExplosion.Stem = impactType != ExplosiveWeaponImpactType.Air && impactType != ExplosiveWeaponImpactType.Structure;
					VolumetricExplosion.Stem = scale > 0.9f && VolumetricExplosion.Stem;
					VolumetricExplosion.RaiseAmount = (VolumetricExplosion.Stem ? 0.9f : 0.4f);
					VolumetricExplosion.Shroom = UnityEngine.Random.Range(0.6f, 1f);
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
					Debug.LogError("Bomb explosion sound compontent object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Bomb explosion sound compontent configuration not found");
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
					Debug.LogError("Bomb explosive force component object not found");
				}
				else if (Config == null)
				{
					Debug.LogError("Bomb explosive force component configuration not found");
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
			public float BlastForce = 100f;

			public float BlastRadius = 100f;

			public float CriticalBlastRadius = 50f;
		}

		[SerializeField]
		private Vector3 _blastDirection = Vector3.up;

		[SerializeField]
		[InspectorFieldOrder(102)]
		private BurnMarkComponent _burnMark;

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

		private AssetCollection<Texture2D> _explosionTextures;

		[SerializeField]
		[InspectorFieldOrder(105)]
		private ExplosiveForceComponent _explosiveForce;

		[SerializeField]
		[Range(0.5f, 2f)]
		private float _scale = 1f;

		private ExplosionCoreComponent _selectedExplosionCore;

		[SerializeField]
		private float _totalLifetime = 25f;

		public override ExplosiveForceScript ExplosiveForce => _explosiveForce.Script;

		public override void Explode(float scale, Vector3? blastDirection, AircraftScript owner, Rigidbody ownerBody, Vector3? impactDirection, ExplosiveWeaponImpactType impactType)
		{
			bool num = impactType == ExplosiveWeaponImpactType.Ground || impactType == ExplosiveWeaponImpactType.Structure || impactType == ExplosiveWeaponImpactType.Boat;
			_selectedExplosionCore = _explosionCore;
			if (_explosionTextures == null)
			{
				LoadExplosionTextures();
			}
			Texture2D asset = _explosionTextures.GetAsset((impactType == ExplosiveWeaponImpactType.Water) ? "Explosion1_White" : "Explosion1_Black");
			if (_selectedExplosionCore.Object.TryGetComponent<ParticleSystemRenderer>(out var component))
			{
				component.material.mainTexture = asset;
			}
			_selectedExplosionCore.Object.SetActive(value: true);
			_selectedExplosionCore.Awake();
			_scale = Mathf.Clamp(scale, 0f, 15f);
			_blastDirection = blastDirection ?? Vector3.up;
			_selectedExplosionCore.UpdateProperties(_scale, impactType);
			if (_selectedExplosionCore.ParticleSystem != null)
			{
				_selectedExplosionCore.ParticleSystem.Play();
			}
			_explosionSound.AudioSource.pitch = 1f / _scale;
			_explosionSound.AudioSource.PlayDelayed(Vector3.Distance(FlightSceneScript.Instance.LocalPlayer?.FramePosition ?? Vector3.zero, base.transform.position) / 340.29f);
			_explosiveForce.UpdateConfiguration(_scale);
			_explosiveForce.Script.Detonate(owner, ownerBody, impactDirection);
			if (num)
			{
				float scale2 = ((_scale > 1f) ? Mathf.Sqrt(_scale) : _scale);
				_debris.UpdateScale(scale2);
				_debris.ParticleSystem.Play();
				StartCoroutine(ShowBurnMark());
			}
			UnityEngine.Object.Destroy(base.gameObject, _totalLifetime);
		}

		public void ScaleBlastForce(float scale)
		{
			_explosiveForce.Config.BlastForce *= scale;
		}

		protected virtual void Awake()
		{
			_burnMark.Awake();
			_debris.Awake();
			_explosionSound.Awake();
			_explosiveForce.Awake();
			LoadExplosionTextures();
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

		private IEnumerator DebrisDestroy(GameObject debris)
		{
			yield return new WaitForSeconds(_debris.Config.Lifetime * _scale);
			UnityEngine.Object.Destroy(debris);
		}

		private IEnumerator DebrisStartStopEmission(BombExplosionDebrisScript debris)
		{
			ParticleSystem.EmissionModule emission = debris.ParticleSystem.emission;
			emission.enabled = false;
			yield return new WaitForSeconds(debris.ParticleSystem.main.startDelay.constant * _scale);
			emission.enabled = true;
			yield return new WaitForSeconds(_debris.Config.ParticleEmitDuration * _scale);
			emission.rateOverDistance = new ParticleSystem.MinMaxCurve(0f);
			debris.LerpDrag(debris.RigidBodyDrag, 0f, 1f);
			_drawGizmos = false;
		}

		private void LoadExplosionTextures()
		{
			_explosionTextures = Game.Instance.ResourceLoader.LoadScriptableObject<AssetCollection<Texture2D>>("Flight/Explosions/ExplosionTextures");
		}

		private IEnumerator ShowBurnMark()
		{
			yield return new WaitForSeconds(_burnMark.Config.AppearanceDelay);
			Transform obj = _burnMark.Object.transform;
			obj.forward = _blastDirection * -1f;
			obj.localPosition += new Vector3(0f, 2f, 0f);
			_burnMark.Projector.enabled = true;
			_burnMark.Script.LerpSize(0f, _burnMark.Config.Size * _scale, _burnMark.Config.AppearanceLerpTime);
		}
	}
}
