using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Combat
{
	public class ParticleGravitySnow : MonoBehaviour
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
			}
		}

		public void Update()
		{
			if (_particleSystem == null)
			{
				return;
			}
			ParticleSystem.Particle[] array = new ParticleSystem.Particle[_particleSystem.particleCount];
			_particleSystem.GetParticles(array);
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 position = array[i].position;
				Vector3 vector = GetGravityDirection(position).normalized;
				Vector3 vector2 = Vector3.Cross(vector, Vector3.forward) * 1.8f;
				array[i].velocity = array[i].GetCurrentSize(_particleSystem) * _particleSystem.main.gravityModifier.constant * 9.81f * Time.smoothDeltaTime * (vector + vector2);
				Bounds bounds = new Bounds(_particleSystem.transform.position, new Vector3(300f, 300f, 1f));
				float num = 150f;
				float num2 = (float)WorldController.TerrainSettings.PlanetSize * 1.4f;
				float value = Vector3.Distance(-1f * GetGravityDirection(position).normalized * num2, position) / num;
				value = 1f - Mathf.Clamp01(value);
				Vector2 vector3 = position - _particleSystem.transform.position;
				float b = 1f - Mathf.Abs(vector3.x) / bounds.extents.x;
				float b2 = 1f - Mathf.Abs(vector3.y) / bounds.extents.y;
				b = Mathf.Min(0.4f, b) * 2.5f;
				b2 = Mathf.Min(0.4f, b2) * 2.5f;
				float t = Mathf.Min(b, b2, value);
				array[i].startColor = Color.Lerp(new Color(1f, 1f, 1f, 0f), Color.white, t);
				if (!bounds.Contains(position))
				{
					array[i].remainingLifetime = -1f;
				}
			}
			_particleSystem.SetParticles(array, array.Length);
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
