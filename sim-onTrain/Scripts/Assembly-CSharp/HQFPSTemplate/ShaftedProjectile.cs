using System;
using System.Collections;
using HQFPSTemplate.Surfaces;
using UnityEngine;
using UnityEngine.Events;

namespace HQFPSTemplate
{
	[RequireComponent(typeof(Collider))]
	[RequireComponent(typeof(Rigidbody))]
	public class ShaftedProjectile : Projectile
	{
		[Serializable]
		public class TwangSettings
		{
			public Vector3 MovementPivot;

			public float Duration = 1f;

			public float Range = 18f;

			public SoundPlayer Audio;
		}

		public struct ImpactInfo
		{
			public Hitbox Hitbox;
		}

		public Message<ImpactInfo> Impact = new Message<ImpactInfo>();

		public Message Launched = new Message();

		[BHeader("General", true)]
		[SerializeField]
		private LayerMask m_Mask;

		[SerializeField]
		private float m_MaxDistance = 2f;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("0 = no gravity, 1 = full gravity")]
		private float m_GravityMultiplier = 1f;

		[SerializeField]
		private TrailRenderer m_Trail;

		[SerializeField]
		private bool m_AllowSticking;

		[BHeader("Damage")]
		[SerializeField]
		[Range(0f, 200f)]
		private float m_MaxDamageSpeed = 50f;

		[SerializeField]
		[Range(0f, 200f)]
		private float m_MaxDamage = 100f;

		[SerializeField]
		private AnimationCurve m_DamageCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.8f, 0.5f), new Keyframe(1f, 0f));

		[SerializeField]
		private float m_ImpactForce = 15f;

		[BHeader("Penetration")]
		[SerializeField]
		private float m_PenetrationOffset = 0.2f;

		[SerializeField]
		private Vector2 m_RandomRotation = Vector2.zero;

		[SerializeField]
		private bool m_PlayTwangAnimation;

		[SerializeField]
		private UnityEvent m_OnImpact;

		[SerializeField]
		[ShowIf("m_PlayTwangAnimation", true, 10f)]
		private TwangSettings m_TwangSettings;

		[BHeader("Audio")]
		[SerializeField]
		private AudioSource m_AudioSource;

		[SerializeField]
		private SurfaceEffects m_PenetrationEffect;

		private Entity m_Launcher;

		private Collider m_Collider;

		private Rigidbody m_Rigidbody;

		private bool m_Done;

		private bool m_Launched;

		private Transform m_Pivot;

		private ArrowNetworkSync networkSync;

		public float GravityMultiplier => m_GravityMultiplier;

		public override void Launch(Entity launcher)
		{
			if (m_Launcher != null)
			{
				Debug.LogWarningFormat(this, "Already launched this projectile!", base.name);
				return;
			}
			m_Launcher = launcher;
			m_Launched = true;
			base.gameObject.layer = LayerMask.NameToLayer("Bullet");
			OnLaunched();
			Launched.Send();
		}

		public void NetworkLaunch(Entity launcher)
		{
			m_Launcher = launcher;
			m_Launched = true;
			OnLaunched();
		}

		public void CheckForSurfaces(Ray ray)
		{
			CheckForSurfaces(ray.origin, ray.direction);
		}

		public void CheckForSurfaces(Vector3 position, Vector3 direction, float overrideMaxDistance = -1f)
		{
			if (networkSync != null && !networkSync.isServer)
			{
				return;
			}
			float maxDistance = ((overrideMaxDistance > 0f) ? overrideMaxDistance : m_MaxDistance);
			Ray ray = new Ray(position, direction);
			if (!Physics.Raycast(ray, out var hitInfo, maxDistance, m_Mask, QueryTriggerInteraction.Collide))
			{
				return;
			}
			Debug.Log("Arrow hit: " + hitInfo.collider.gameObject.name + " on layer: " + LayerMask.LayerToName(hitInfo.collider.gameObject.layer));
			Vector3 impactPoint = hitInfo.point + base.transform.forward * m_PenetrationOffset;
			bool flag = hitInfo.collider.GetComponentInParent<ZombieController>() != null;
			float magnitude = m_Rigidbody.velocity.magnitude;
			float impactForce = m_ImpactForce;
			float num = m_DamageCurve.Evaluate(1f - magnitude / m_MaxDamageSpeed);
			float num2 = m_MaxDamage * num;
			Debug.Log($"Damage calculated: {num2}, Launcher: {m_Launcher != null}");
			if (m_Launcher != null)
			{
				DamageInfo arg = new DamageInfo(0f - num2, DamageType.Stab, hitInfo.point, ray.direction, impactForce, hitInfo.normal, m_Launcher, hitInfo.transform);
				IDamageable damageable = hitInfo.collider.GetComponentInParent<IDamageable>();
				if (damageable == null)
				{
					damageable = hitInfo.collider.GetComponentInChildren<IDamageable>();
				}
				bool flag2 = m_Launcher.DealDamage.Try(arg, damageable);
				Debug.Log(string.Format("[ARROW_DMG] dealt={0} damageable={1} collider={2} launcher={3}", flag2, (damageable != null) ? damageable.GetType().Name : "YOK", hitInfo.collider.name, m_Launcher != null));
			}
			if (hitInfo.rigidbody != null && !flag)
			{
				hitInfo.rigidbody.AddForceAtPosition(base.transform.forward * impactForce, hitInfo.point, ForceMode.Impulse);
			}
			Hitbox component = hitInfo.collider.GetComponent<Hitbox>();
			m_OnImpact.Invoke();
			Impact.Send(new ImpactInfo
			{
				Hitbox = component
			});
			m_Collider.enabled = false;
			if (m_Trail != null)
			{
				m_Trail.enabled = false;
			}
			m_Done = true;
			if (networkSync != null && networkSync.isServer)
			{
				networkSync.ServerStopArrow(impactPoint, m_AllowSticking ? hitInfo.collider.gameObject : null);
			}
		}

		public void TryCloseRangeHit(Vector3 muzzlePosition, Vector3 direction, float backDistance, float pointBlankRange)
		{
			if (!(networkSync != null) || networkSync.isServer)
			{
				direction = direction.normalized;
				Vector3 vector = muzzlePosition - direction * backDistance;
				float num = backDistance + pointBlankRange;
				if (Physics.Raycast(vector, direction, out var hitInfo, num, m_Mask, QueryTriggerInteraction.Collide) && !(Vector3.Dot(hitInfo.point - muzzlePosition, direction) > pointBlankRange))
				{
					CheckForSurfaces(vector, direction, num);
				}
			}
		}

		public void OnNetworkImpact()
		{
			m_Done = true;
			m_Collider.enabled = false;
			if (m_Trail != null)
			{
				m_Trail.enabled = false;
			}
			if (m_AllowSticking)
			{
				OnSurfacePenetrated();
			}
		}

		public void OnLaunched()
		{
			m_Collider.enabled = false;
			if (m_Trail != null)
			{
				m_Trail.enabled = true;
			}
		}

		public void OnSurfacePenetrated()
		{
			m_Rigidbody.isKinematic = true;
			if (m_PlayTwangAnimation)
			{
				StartCoroutine(C_DoTwang());
			}
		}

		private void Awake()
		{
			m_Collider = GetComponent<Collider>();
			m_Rigidbody = GetComponent<Rigidbody>();
			networkSync = GetComponent<ArrowNetworkSync>();
			if (m_Trail != null)
			{
				m_Trail.enabled = false;
			}
		}

		private void FixedUpdate()
		{
			bool flag = !(networkSync != null) || networkSync.isServer;
			if (m_Launched && !m_Done)
			{
				if (m_GravityMultiplier < 1f && m_Rigidbody.useGravity)
				{
					float num = 1f - m_GravityMultiplier;
					m_Rigidbody.AddForce(-Physics.gravity * num, ForceMode.Acceleration);
				}
				if (m_Rigidbody.velocity.sqrMagnitude > 0.1f)
				{
					base.transform.rotation = Quaternion.LookRotation(m_Rigidbody.velocity);
				}
				if (flag)
				{
					float num2 = m_Rigidbody.velocity.magnitude * Time.fixedDeltaTime;
					float overrideMaxDistance = Mathf.Max(m_MaxDistance, num2 + 0.5f);
					CheckForSurfaces(base.transform.position, base.transform.forward, overrideMaxDistance);
				}
			}
		}

		private void OnDestroy()
		{
			if (m_Pivot != null)
			{
				UnityEngine.Object.Destroy(m_Pivot.gameObject);
			}
		}

		private IEnumerator C_DoTwang()
		{
			m_Pivot = new GameObject("Shafted Projectile Pivot").transform;
			m_Pivot.position = base.transform.position + Vector3Utils.LocalToWorld(m_TwangSettings.MovementPivot, base.transform);
			m_Pivot.rotation = base.transform.rotation;
			float stopTime = Time.time + m_TwangSettings.Duration;
			float range = m_TwangSettings.Range;
			float currentVelocity = 0f;
			m_TwangSettings.Audio.Play(ItemSelection.Method.RandomExcludeLast, m_AudioSource);
			Quaternion localRotation = m_Pivot.localRotation;
			Quaternion randomRotation = Quaternion.Euler(new Vector2(UnityEngine.Random.Range(0f - m_RandomRotation.x, m_RandomRotation.x), UnityEngine.Random.Range(0f - m_RandomRotation.y, m_RandomRotation.y)));
			while (Time.time < stopTime)
			{
				m_Pivot.localRotation = localRotation * randomRotation * Quaternion.Euler(UnityEngine.Random.Range(0f - range, range), UnityEngine.Random.Range(0f - range, range), 0f);
				range = Mathf.SmoothDamp(range, 0f, ref currentVelocity, stopTime - Time.time);
				yield return null;
			}
		}
	}
}
