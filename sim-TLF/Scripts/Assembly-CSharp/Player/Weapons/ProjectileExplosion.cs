using Entities;
using UnityEngine;

namespace Player.Weapons
{
	public class ProjectileExplosion : MonoBehaviour
	{
		[Tooltip("Радіус вибуху (м).")]
		[Range(1f, 50f)]
		public float explosionRadius = 8f;

		[Tooltip("Сила вибуху (Impulse).")]
		[Range(0f, 10000f)]
		public float explosionForce = 1500f;

		[Tooltip("Вертикальний зсув вибухової хвилі (upwardsModifier).")]
		[Range(0f, 5f)]
		public float upwardsModifier = 0.5f;

		[Tooltip("Префаб ефекту вибуху (VFX/Particles). Необов'язково.")]
		public GameObject explosionEffectPrefab;

		[SerializeField]
		private float _maxDamage;

		[SerializeField]
		private LayerMask _explosionCheckMask;

		[Header("Audio")]
		[SerializeField]
		private GameObject _explosionGO;

		[SerializeField]
		private AudioSource _flySource;

		[Header("Particles")]
		[SerializeField]
		private ParticleSystem _particles;

		[SerializeField]
		private float _particlesStopDelay;

		private bool _exploded;

		private void OnCollisionEnter(Collision collision)
		{
			if (!_exploded)
			{
				Explode(base.transform.position);
			}
		}

		public void Explode(Vector3 center)
		{
			if (_exploded)
			{
				return;
			}
			_exploded = true;
			if (explosionEffectPrefab != null)
			{
				Object.Instantiate(explosionEffectPrefab, center, Quaternion.identity).transform.parent = null;
			}
			Collider[] array = Physics.OverlapSphere(center, explosionRadius, _explosionCheckMask);
			int num = 0;
			Collider[] array2 = array;
			foreach (Collider obj in array2)
			{
				if (obj.TryGetComponent<IHealthHandler>(out var component))
				{
					Vector3 position = (component as MonoBehaviour).transform.position;
					float num2 = (explosionRadius - Vector3.Distance(position, center)) / explosionRadius;
					component.HealthService.Damage(_maxDamage * num2);
				}
				_explosionGO.SetActive(value: true);
				_flySource.Stop();
				Rigidbody attachedRigidbody = obj.attachedRigidbody;
				if (attachedRigidbody != null)
				{
					attachedRigidbody.AddExplosionForce(explosionForce, center, explosionRadius, upwardsModifier, ForceMode.Impulse);
					num++;
				}
			}
			Debug.Log($"[ProjectileExplosion] ВИБУХ у {center} | " + $"Радіус={explosionRadius}м | Сила={explosionForce} | Об'єктів={num}");
			Invoke("DisableParticles", _particlesStopDelay);
		}

		private void DisableParticles()
		{
			if (_particles != null)
			{
				_particles.Stop();
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = new Color(1f, 0.3f, 0f, 0.25f);
			Gizmos.DrawSphere(base.transform.position, explosionRadius);
			Gizmos.color = new Color(1f, 0.3f, 0f, 0.85f);
			Gizmos.DrawWireSphere(base.transform.position, explosionRadius);
		}
	}
}
