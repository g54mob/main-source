using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Combat
{
	[ExecuteInEditMode]
	public class NimbatusParticleEffect : SerializedMonoBehaviour
	{
		public ParticleSystem ParticleEffect;

		public string SoundName;

		public bool AffectedByGravity;

		private ParticleSystem _particleSystem;

		public float PlayEffect(Transform trans)
		{
			return PlayEffect(trans.position, trans.rotation);
		}

		public float PlayEffect(Vector3 position, Quaternion rotation)
		{
			if (!string.IsNullOrEmpty(SoundName))
			{
				AudioController.Play(SoundName, position);
			}
			if (ParticleEffect != null)
			{
				Vector3 position2 = position;
				position2.z = -5f;
				ParticleSystem particleSystem = Object.Instantiate(ParticleEffect, position2, rotation);
				if (AffectedByGravity)
				{
					particleSystem.gameObject.AddComponent<ParticleGravity>().Init(particleSystem);
				}
				particleSystem.Play(true);
				Object.Destroy(particleSystem.gameObject, particleSystem.main.duration);
				return particleSystem.main.duration;
			}
			return 0f;
		}

		public void Start()
		{
			_particleSystem = GetComponent<ParticleSystem>();
		}

		public void Update()
		{
		}
	}
}
