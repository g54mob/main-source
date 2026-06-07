using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Combat
{
	public class ParticleGravity : MonoBehaviour
	{
		private ParticleSystem _particleSystem;

		private bool _hasPlanetaryGravity;

		private float _gravityMod;

		public void Start()
		{
			Init(GetComponent<ParticleSystem>());
		}

		public void Init(ParticleSystem system)
		{
			if (!(system == null))
			{
				_particleSystem = system;
				_gravityMod = WorldController.TerrainSettings.GetGravityModifier();
				_hasPlanetaryGravity = RunningModeSpecifics.Has(ERunningModeSpecific.CentralGravity);
				_gravityMod *= _particleSystem.main.gravityModifier.constant;
			}
		}

		public void Update()
		{
			if (!(_particleSystem == null))
			{
				ParticleSystem.Particle[] array = new ParticleSystem.Particle[_particleSystem.particleCount];
				_particleSystem.GetParticles(array);
				for (int i = 0; i < array.Length; i++)
				{
					Vector3 position = array[i].position;
					array[i].velocity += _gravityMod * 9.81f * Time.smoothDeltaTime * (Vector3)GetGravityDirection(position).normalized;
				}
				_particleSystem.SetParticles(array, array.Length);
			}
		}

		public Vector2 GetGravityDirection(Vector2 position)
		{
			if (_hasPlanetaryGravity)
			{
				return Vector2.zero - position;
			}
			return -Vector2.up;
		}
	}
}
