using JUTPS.FX;
using JUTPSEditor.JUHeader;
using UnityEngine;
using UnityEngine.Events;

namespace JUTPS
{
	[AddComponentMenu("JU TPS/Third Person System/Additionals/JU Health")]
	public class JUHealth : MonoBehaviour
	{
		[JUHeader("Settings")]
		public float Health = 100f;

		public float MaxHealth = 100f;

		[JUHeader("Effects")]
		public bool BloodScreenEffect;

		public GameObject BloodHitParticle;

		[JUHeader("On Death Event")]
		public UnityEvent OnDeath;

		[JUHeader("Stats")]
		public bool IsDead;

		private void Start()
		{
			LimitHealth();
			InvokeRepeating("CheckHealthState", 0f, 0.5f);
		}

		private void LimitHealth()
		{
			Health = Mathf.Clamp(Health, 0f, MaxHealth);
		}

		public static void DoDamage(JUHealth health, float damage, Vector3 hitPosition = default(Vector3))
		{
			health.DoDamage(damage, hitPosition);
		}

		public void DoDamage(float damage, Vector3 hitPosition = default(Vector3))
		{
			Health -= damage;
			LimitHealth();
			Invoke("CheckHealthState", 0.016f);
			if (BloodScreenEffect)
			{
				BloodScreen.PlayerTakingDamaged();
			}
			if (hitPosition != Vector3.zero && BloodHitParticle != null)
			{
				GameObject obj = Object.Instantiate(BloodHitParticle, hitPosition, Quaternion.identity);
				obj.hideFlags = HideFlags.HideInHierarchy;
				Object.Destroy(obj, 3f);
			}
		}

		public void CheckHealthState()
		{
			LimitHealth();
			if (Health <= 0f && !IsDead)
			{
				Health = 0f;
				IsDead = true;
				Damager[] componentsInChildren = GetComponentsInChildren<Damager>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.SetActive(value: false);
				}
				OnDeath.Invoke();
			}
			if (Health > 0f)
			{
				IsDead = false;
			}
		}
	}
}
