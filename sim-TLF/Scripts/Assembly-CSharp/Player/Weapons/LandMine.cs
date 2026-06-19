using Entities;
using UnityEngine;

namespace Player.Weapons
{
	public class LandMine : MonoBehaviour
	{
		[Header("Trigger Settings")]
		[Tooltip("Шари об'єктів, які можуть активувати міну.")]
		public LayerMask triggerLayers;

		[Header("Explosion Settings")]
		[Tooltip("Радіус вибуху (м).")]
		[Range(1f, 50f)]
		public float explosionRadius = 8f;

		[Tooltip("Максимальний урон вибуху (в центрі).")]
		[Range(0f, 10000f)]
		public float maxDamage = 100f;

		[Tooltip("Сила вибухового імпульсу для Rigidbody.")]
		[Range(0f, 10000f)]
		public float explosionForce = 1500f;

		[Tooltip("Вертикальний зсув вибухової хвилі.")]
		[Range(0f, 5f)]
		public float upwardsModifier = 0.5f;

		[Tooltip("Шари об'єктів, які отримують урон/силу від вибуху.")]
		public LayerMask explosionCheckMask;

		[Header("Audio")]
		[Tooltip("AudioSource для звуку вибуху.")]
		[SerializeField]
		private AudioSource _explosionAudioSource;

		[Tooltip("Аудіокліп вибуху (якщо AudioSource не має кліпу за замовчуванням).")]
		[SerializeField]
		private AudioClip _explosionClip;

		[Header("Particles")]
		[Tooltip("Партікл-система вибуху.")]
		[SerializeField]
		private ParticleSystem _explosionParticles;

		[Tooltip("Затримка перед зупинкою партіклів (сек).")]
		[SerializeField]
		private float _particlesStopDelay = 3f;

		[Tooltip("Затримка перед знищенням об'єкта після вибуху (сек).")]
		[SerializeField]
		private float _destroyDelay = 5f;

		private bool _exploded;

		private void OnTriggerEnter(Collider other)
		{
			if (!_exploded && (triggerLayers.value & (1 << other.gameObject.layer)) != 0)
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
			Collider[] components = GetComponents<Collider>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].enabled = false;
			}
			if (_explosionParticles != null)
			{
				_explosionParticles.transform.parent = null;
				_explosionParticles.Play();
				Invoke("StopParticles", _particlesStopDelay);
			}
			if (_explosionAudioSource != null)
			{
				if (_explosionClip != null)
				{
					_explosionAudioSource.PlayOneShot(_explosionClip);
				}
				else
				{
					_explosionAudioSource.Play();
				}
				_explosionAudioSource.transform.parent = null;
				Object.Destroy(_explosionAudioSource.gameObject, (_explosionClip != null) ? (_explosionClip.length + 0.5f) : _destroyDelay);
			}
			Collider[] array = Physics.OverlapSphere(center, explosionRadius, explosionCheckMask);
			int num = 0;
			components = array;
			foreach (Collider obj in components)
			{
				if (obj.TryGetComponent<IHealthHandler>(out var component))
				{
					float num2 = Vector3.Distance((component as MonoBehaviour).transform.position, center);
					float num3 = Mathf.Clamp01((explosionRadius - num2) / explosionRadius);
					component.HealthService.Damage(maxDamage * num3);
				}
				Rigidbody attachedRigidbody = obj.attachedRigidbody;
				if (attachedRigidbody != null)
				{
					attachedRigidbody.AddExplosionForce(explosionForce, center, explosionRadius, upwardsModifier, ForceMode.Impulse);
					num++;
				}
			}
			Debug.Log($"[LandMine] ВИБУХ у {center} | Радіус={explosionRadius}м | " + $"Урон={maxDamage} | Об'єктів={num}");
			Object.Destroy(base.gameObject, _destroyDelay);
		}

		private void StopParticles()
		{
			if (_explosionParticles != null)
			{
				_explosionParticles.Stop();
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = new Color(1f, 0.3f, 0f, 0.15f);
			Gizmos.DrawSphere(base.transform.position, explosionRadius);
			Gizmos.color = new Color(1f, 0.3f, 0f, 0.85f);
			Gizmos.DrawWireSphere(base.transform.position, explosionRadius);
		}
	}
}
