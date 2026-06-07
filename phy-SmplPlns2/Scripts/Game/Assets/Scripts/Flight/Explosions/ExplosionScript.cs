using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class ExplosionScript : MonoBehaviour
	{
		private class CascadeExplosion
		{
			public int NumCascades { get; set; }

			public PartScript Part { get; set; }

			public float Power { get; set; }
		}

		private List<CascadeExplosion> _cascades = new List<CascadeExplosion>();

		private float _cascadeTimer;

		private ParticleSystem _particleSystem;

		public AircraftScript Aircraft { get; private set; }

		public float Magnitude { get; private set; }

		public int NumCascades { get; private set; }

		public bool UpdateTransform { get; private set; }

		public Vector3 Velocity { get; private set; }

		public static ExplosionScript CreateExplosion(AircraftScript aircraft, Vector3 position, Vector3 velocity, float magnitude, int explosionCascadeCount = 0)
		{
			bool updateTransform = false;
			GameObject gameObject = Object.Instantiate(Resources.Load("Flight/Explosions/Explosion")) as GameObject;
			ExplosionScript explosionScript = gameObject.AddComponent<ExplosionScript>();
			explosionScript.Aircraft = aircraft;
			explosionScript.Magnitude = magnitude;
			explosionScript.NumCascades = explosionCascadeCount;
			explosionScript.UpdateTransform = updateTransform;
			explosionScript.Velocity = velocity;
			gameObject.transform.position = position;
			gameObject.transform.localScale = new Vector3(5f, 5f, 5f);
			return explosionScript;
		}

		protected virtual void FixedUpdate()
		{
			base.transform.position += Velocity * Time.deltaTime;
			Velocity -= Velocity * 0.5f * Time.deltaTime;
		}

		protected virtual void Start()
		{
			AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.loop = false;
			audioSource.playOnAwake = true;
			audioSource.clip = AudioStore.ExplosionAudio.Resource;
			audioSource.outputAudioMixerGroup = AudioStore.ExplosionAudio.MixerGroup;
			audioSource.volume = 1f;
			audioSource.dopplerLevel = 0f;
			audioSource.minDistance = 25f;
			audioSource.maxDistance = 1500f;
			audioSource.spatialBlend = 1f;
			audioSource.Play();
			_particleSystem = base.transform.GetComponentInChildren<ParticleSystem>();
			Vector3 position = base.transform.position;
			if (!(Aircraft != null))
			{
				return;
			}
			foreach (PartData part in Aircraft.Parts)
			{
				if (!part.PartScript.gameObject.activeInHierarchy || !part.PartType.CanExplode)
				{
					continue;
				}
				float magnitude = (part.PartScript.transform.position - position).magnitude;
				if (magnitude < 10f)
				{
					float num = Magnitude * 25f;
					if (magnitude > 1f)
					{
						num /= magnitude;
					}
					float num2 = part.PartType.ExplodeForce * 35f;
					if (num > num2 && NumCascades < 5)
					{
						NumCascades++;
						CascadeExplosion item = new CascadeExplosion
						{
							Part = part.PartScript,
							Power = Magnitude * 0.95f,
							NumCascades = NumCascades
						};
						_cascades.Add(item);
					}
				}
			}
		}

		protected virtual void Update()
		{
			if (_particleSystem != null)
			{
				if (_particleSystem.isPaused && !PauseManager.Paused)
				{
					_particleSystem.Play();
				}
				else if (!_particleSystem.isPaused)
				{
					_particleSystem.Pause();
				}
			}
			_cascadeTimer += Time.deltaTime;
			if (_cascadeTimer > 0.1f)
			{
				_cascadeTimer = 0f;
				if (_cascades.Count > 0)
				{
					CascadeExplosion cascadeExplosion = _cascades[0];
					PartScript part = cascadeExplosion.Part;
					if (part != null && part.gameObject.activeInHierarchy && part.Part.PartType.CanExplode)
					{
						part.Body.ExplodePart(part, cascadeExplosion.Power, cascadeExplosion.NumCascades);
					}
					_cascades.RemoveAt(0);
				}
			}
			if (UpdateTransform)
			{
				base.transform.rotation = Camera.main.transform.rotation;
			}
			if (base.transform.position.y < GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault())
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
