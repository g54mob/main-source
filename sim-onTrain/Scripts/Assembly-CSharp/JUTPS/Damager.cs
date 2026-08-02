using System.Collections.Generic;
using JUTPS.ArmorSystem;
using JUTPS.CharacterBrain;
using JUTPS.FX;
using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS
{
	[AddComponentMenu("JU TPS/Armor System/JU Damager")]
	public class Damager : MonoBehaviour
	{
		[JUHeader("Damager Settings")]
		public float Damage = 20f;

		public bool DisableOnStart = true;

		public float HitMinTime = 0.5f;

		private float CurrentHitTime;

		[JUHeader("Damage Detection Settings")]
		public bool RaycastingMode = true;

		public LayerMask RaycastCollideWith;

		public float RaycastDistance;

		[JUHeader("Collision Detection Mode Settings")]
		public bool IgnoreAllCollidersOfRootGameobject = true;

		public Collider[] AllRootGameobjectColliders;

		public bool LockStartPosition;

		[JUHeader("FX Settings")]
		public string[] TagsToDamage = new string[4] { "Untagged", "Skin", "Player", "Enemy" };

		public List<SurfaceAudiosWithFX> HitParticlesList = new List<SurfaceAudiosWithFX>();

		public AudioSource HitSoundsAudioSource;

		[HideInInspector]
		public bool Collided;

		private Vector3 startedLocalPosition;

		private Rigidbody rb;

		private bool CanHit = true;

		public GameObject Owner;

		private GameObject oldHitedCollider;

		private RaycastHit hit;

		private void Awake()
		{
			startedLocalPosition = base.transform.localPosition;
			JUCharacterBrain componentInParent = GetComponentInParent<JUCharacterBrain>();
			Owner = ((componentInParent == null) ? null : componentInParent.gameObject);
		}

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
			if (IgnoreAllCollidersOfRootGameobject)
			{
				AllRootGameobjectColliders = base.transform.root.GetComponentsInChildren<Collider>();
				if (GetComponent<Collider>() == null)
				{
					return;
				}
				Collider component = GetComponent<Collider>();
				Collider[] allRootGameobjectColliders = AllRootGameobjectColliders;
				foreach (Collider collider in allRootGameobjectColliders)
				{
					if (collider != component)
					{
						Physics.IgnoreCollision(collider, component, ignore: true);
					}
				}
			}
			if (DisableOnStart)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void Update()
		{
			if (LockStartPosition)
			{
				base.transform.localPosition = startedLocalPosition;
				if (rb != null)
				{
					rb.velocity = Vector3.zero;
					rb.isKinematic = false;
				}
			}
			if (!RaycastingMode || RaycastDistance == 0f)
			{
				return;
			}
			if (Physics.Raycast(base.transform.position, base.transform.forward, out var hitInfo, RaycastDistance, RaycastCollideWith))
			{
				if (!(hitInfo.collider.gameObject != oldHitedCollider))
				{
					return;
				}
				for (int i = 0; i < TagsToDamage.Length; i++)
				{
					if (hitInfo.collider.transform.tag == TagsToDamage[i] && CanHit)
					{
						DoDamage(hitInfo, null, Damage, HitParticlesList, HitSoundsAudioSource, AllRootGameobjectColliders);
						Collided = true;
						Invoke("DisableCollidedState", 0.1f);
						DisableDamagingForSeconds(HitMinTime);
					}
				}
				oldHitedCollider = hitInfo.collider.gameObject;
			}
			else
			{
				oldHitedCollider = null;
			}
		}

		private void OnDisable()
		{
			oldHitedCollider = null;
		}

		private void DisableCollidedState()
		{
			Collided = false;
		}

		public void DisableDamagingForSeconds(float DisabledSeconds)
		{
			CanHit = false;
			if (!IsInvoking("EnableDamaging"))
			{
				Invoke("EnableDamaging", DisabledSeconds);
			}
		}

		public void EnableDamaging()
		{
			CanHit = true;
		}

		private void OnCollisionEnter(Collision collision)
		{
			for (int i = 0; i < TagsToDamage.Length; i++)
			{
				if (collision.transform.tag == TagsToDamage[i] && CanHit)
				{
					if (collision.gameObject.layer == 9 && collision.gameObject.GetComponentInChildren<DamageableBodyPart>() != null)
					{
						break;
					}
					DoDamage(collision, Damage, HitParticlesList, HitSoundsAudioSource);
					Collided = true;
					Invoke("DisableCollidedState", 0.1f);
					DisableDamagingForSeconds(HitMinTime);
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			for (int i = 0; i < TagsToDamage.Length; i++)
			{
				if (other.transform.tag == TagsToDamage[i] && CanHit)
				{
					if (other.gameObject.layer == 9 && other.gameObject.GetComponentInChildren<DamageableBodyPart>() != null)
					{
						break;
					}
					DoDamage(other, Damage, HitParticlesList, HitSoundsAudioSource);
					Collided = true;
					Invoke("DisableCollidedState", 0.1f);
					DisableDamagingForSeconds(HitMinTime);
				}
			}
		}

		private void OnDrawGizmos()
		{
			if (RaycastingMode)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * RaycastDistance);
				return;
			}
			Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.lossyScale);
			Gizmos.color = new Color(1f, 0f, 0f, 0.2f);
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
			Gizmos.color = new Color(1f, 1f, 1f, 0.25f);
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		}

		public void DoDamage(Collider trigger, float damage, List<SurfaceAudiosWithFX> hitParticles, AudioSource hitAudioSource)
		{
			DamageableBodyPart componentInChildren = trigger.gameObject.GetComponentInChildren<DamageableBodyPart>();
			Vector3 hitPosition = trigger.ClosestPoint(base.transform.position);
			float damage2 = damage;
			if (componentInChildren == null)
			{
				JUHealth componentInParent = trigger.gameObject.GetComponentInParent<JUHealth>();
				if (componentInParent != null)
				{
					componentInParent.DoDamage(damage);
					if (Owner != null && !componentInParent.IsDead)
					{
						HitMarkerEffect.HitCheck(componentInParent.transform.tag, Owner.tag, hitPosition, damage2);
					}
				}
			}
			else
			{
				damage2 = componentInChildren.DoDamage(damage);
				if (Owner != null && componentInChildren != null && damage2 > 0f && !componentInChildren.Health.IsDead)
				{
					HitMarkerEffect.HitCheck(componentInChildren.transform.tag, Owner.tag, hitPosition, damage2);
				}
			}
			Vector3 fXPosition = trigger.ClosestPoint(base.transform.position);
			Quaternion fXRotation = Quaternion.LookRotation((base.transform.position - trigger.ClosestPoint(base.transform.position)).normalized);
			SurfaceAudiosWithFX.Play(hitAudioSource, hitParticles, fXPosition, fXRotation, null, (componentInChildren != null) ? componentInChildren.tag : trigger.transform.tag).transform.parent = trigger.transform;
		}

		public void DoDamage(Collision collision, float damage, List<SurfaceAudiosWithFX> hitParticles, AudioSource hitAudioSource)
		{
			DamageableBodyPart componentInChildren = collision.gameObject.GetComponentInChildren<DamageableBodyPart>();
			Vector3 point = collision.contacts[0].point;
			float damage2 = damage;
			if (componentInChildren == null)
			{
				JUHealth componentInParent = collision.gameObject.GetComponentInParent<JUHealth>();
				if (componentInParent != null)
				{
					componentInParent.DoDamage(damage);
					if (Owner != null && !componentInParent.IsDead)
					{
						HitMarkerEffect.HitCheck(componentInParent.transform.tag, Owner.tag, point, damage2);
					}
				}
			}
			else
			{
				damage2 = componentInChildren.DoDamage(damage);
				if (Owner != null && componentInChildren != null && damage2 > 0f && !componentInChildren.Health.IsDead)
				{
					HitMarkerEffect.HitCheck(componentInChildren.transform.tag, Owner.tag, point, damage2);
				}
			}
			Vector3 point2 = collision.contacts[0].point;
			Quaternion fXRotation = Quaternion.LookRotation(collision.contacts[0].normal);
			SurfaceAudiosWithFX.Play(hitAudioSource, hitParticles, point2, fXRotation, null, (componentInChildren != null) ? componentInChildren.tag : collision.collider.transform.tag).transform.parent = collision.transform;
		}

		public void DoDamage(RaycastHit hit, Collision collision, float damage, List<SurfaceAudiosWithFX> hitParticles, AudioSource hitAudioSource, Collider[] CollidersToIgnore = null)
		{
			if (CollidersToIgnore != null)
			{
				foreach (Collider collider in CollidersToIgnore)
				{
					if (hit.collider.gameObject == collider.gameObject)
					{
						return;
					}
				}
			}
			DamageableBodyPart damageableBodyPart = ((hit.point != Vector3.zero) ? hit.collider.gameObject.GetComponentInChildren<DamageableBodyPart>() : collision.gameObject.GetComponentInChildren<DamageableBodyPart>());
			Vector3 hitPosition = ((hit.point != Vector3.zero) ? hit.point : collision.contacts[0].point);
			float num = damage;
			if (damageableBodyPart == null)
			{
				JUHealth jUHealth = ((hit.point != Vector3.zero) ? hit.collider.gameObject.GetComponentInParent<JUHealth>() : collision.gameObject.GetComponentInParent<JUHealth>());
				if (jUHealth != null)
				{
					jUHealth.DoDamage(damage);
					if (Owner != null && !jUHealth.IsDead && num > 0f)
					{
						HitMarkerEffect.HitCheck(jUHealth.transform.tag, Owner.tag, hitPosition, num);
					}
				}
			}
			else
			{
				num = damageableBodyPart.DoDamage(damage);
				if (Owner != null && !damageableBodyPart.Health.IsDead && num > 0f)
				{
					HitMarkerEffect.HitCheck(damageableBodyPart.transform.tag, Owner.tag, hitPosition, num);
				}
			}
			Vector3 fXPosition = ((hit.point != Vector3.zero) ? hit.point : collision.GetContact(0).point);
			Quaternion fXRotation = Quaternion.LookRotation((hit.point != Vector3.zero) ? hit.normal : collision.GetContact(0).normal);
			string surfaceTag = ((hit.point != Vector3.zero) ? hit.transform.tag : collision.gameObject.tag);
			SurfaceAudiosWithFX.Play(hitAudioSource, hitParticles, fXPosition, fXRotation, null, surfaceTag).transform.parent = ((hit.point != Vector3.zero) ? hit.collider.transform : collision.collider.transform);
		}
	}
}
