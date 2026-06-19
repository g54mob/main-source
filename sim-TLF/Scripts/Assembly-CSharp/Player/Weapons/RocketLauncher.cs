using JSAM;
using UnityEngine;

namespace Player.Weapons
{
	public class RocketLauncher : MonoBehaviour
	{
		[Header("Снаряд")]
		[Tooltip("Префаб снаряда. Має мати компонент Rigidbody.")]
		public GameObject projectilePrefab;

		[Tooltip("Точка вильоту снаряда (дочірній об'єкт зброї).")]
		public Transform muzzlePoint;

		[Header("Параметри пострілу")]
		[Tooltip("Початкова швидкість снаряда (м/с).")]
		[Range(10f, 500f)]
		public float initialSpeed = 80f;

		[Tooltip("Маса снаряда (кг).")]
		[Range(0.1f, 50f)]
		public float projectileMass = 1f;

		[Tooltip("Множник гравітації для снаряда (1 = стандартна ~9.81).")]
		[Range(0f, 5f)]
		public float gravityScale = 1f;

		[Tooltip("Опір повітря (drag). Чим більше — тим швидше гальмує.")]
		[Range(0f, 5f)]
		public float airDrag = 0.05f;

		[Tooltip("Кутовий опір снаряда.")]
		[Range(0f, 5f)]
		public float angularDrag = 0.5f;

		[Header("Вибух")]
		[Tooltip("Радіус вибуху (м).")]
		[Range(1f, 50f)]
		public float explosionRadius = 8f;

		[Tooltip("Сила вибуху.")]
		[Range(100f, 10000f)]
		public float explosionForce = 1500f;

		[Tooltip("Префаб ефекту вибуху (необов'язково).")]
		public GameObject explosionEffectPrefab;

		[Header("Перезарядка")]
		[Tooltip("Затримка між пострілами (секунди).")]
		[Range(0f, 5f)]
		public float fireRate = 0.8f;

		private float _nextFireTime;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				TryFire();
			}
		}

		public void TryFire()
		{
			if (Time.time < _nextFireTime)
			{
				Debug.Log("[RocketLauncher] Перезарядка... залишилось: " + (_nextFireTime - Time.time).ToString("F2") + " с");
				return;
			}
			if (projectilePrefab == null)
			{
				Debug.LogError("[RocketLauncher] projectilePrefab не призначено!");
				return;
			}
			Fire();
			_nextFireTime = Time.time + fireRate;
		}

		private void Fire()
		{
			Transform transform = ((muzzlePoint != null) ? muzzlePoint : base.transform);
			GameObject gameObject = Object.Instantiate(projectilePrefab, transform.position, transform.rotation);
			AudioManager.PlaySound(WeaponsLibrarySounds.FlareGunShot);
			AudioManager.PlaySound(WeaponsLibrarySounds.FlareGunShotAdd);
			Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				Debug.LogWarning("[RocketLauncher] Rigidbody не знайдено на снаряді — додаю автоматично.");
				rigidbody = gameObject.AddComponent<Rigidbody>();
			}
			rigidbody.mass = projectileMass;
			rigidbody.linearDamping = airDrag;
			rigidbody.angularDamping = angularDrag;
			rigidbody.useGravity = false;
			rigidbody.linearVelocity = transform.forward * initialSpeed;
			(gameObject.GetComponent<ProjectileGravity>() ?? gameObject.AddComponent<ProjectileGravity>()).gravityScale = gravityScale;
			Debug.Log($"[RocketLauncher] ПОСТРІЛ! Швидкість={initialSpeed} м/с | " + $"Гравітація×{gravityScale} | Drag={airDrag}");
		}
	}
}
