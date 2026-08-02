using System.Collections.Generic;
using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.ArmorSystem
{
	[AddComponentMenu("JU TPS/Armor System/Damageable Body")]
	public class DamageableBody : MonoBehaviour
	{
		[JUHeader("Damageable Body Parts Intensity")]
		[Range(0f, 10f)]
		public float HeadDamageIntensity = 5f;

		[Range(0f, 10f)]
		public float TorsoDamageIntensity = 1f;

		[Range(0f, 10f)]
		public float LegsDamageIntensity = 0.8f;

		[Range(0f, 10f)]
		public float ArmsDamageIntensity = 0.5f;

		public DamageableBodyPart[] AllParts;

		private void Start()
		{
			Animator component = GetComponent<Animator>();
			if (component == null)
			{
				Debug.LogError("Damageable Body: Could not find the Animator, without it it is not possible to distribute the bones normally");
			}
			else
			{
				DistributeDamageableComponentsInTheBody(component, HeadDamageIntensity, TorsoDamageIntensity, LegsDamageIntensity, ArmsDamageIntensity);
			}
			AllParts = GetComponentsInChildren<DamageableBodyPart>();
		}

		public static DamageableBodyPart[] DistributeDamageableComponentsInTheBody(Animator animator, float HeadValue = 5f, float TorsoValue = 1f, float LegValue = 0.8f, float ArmValue = 0.5f)
		{
			List<DamageableBodyPart> list = new List<DamageableBodyPart>();
			Collider[] componentsInChildren = animator.GetBoneTransform(HumanBodyBones.Hips).GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				if (collider.gameObject.layer == 15 && collider.GetComponent<DamageableBodyPart>() == null)
				{
					list.Add(collider.gameObject.AddComponent<DamageableBodyPart>());
					if (collider.gameObject.TryGetComponent<Rigidbody>(out var component))
					{
						component.isKinematic = true;
						component.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
					}
					else
					{
						Rigidbody rigidbody = collider.gameObject.AddComponent<Rigidbody>();
						rigidbody.isKinematic = true;
						rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
					}
				}
				if (collider.gameObject.layer == 15 && collider.GetComponent<DamageableBodyPart>() != null)
				{
					list.Add(collider.gameObject.GetComponent<DamageableBodyPart>());
					if (collider.gameObject.TryGetComponent<Rigidbody>(out var component2))
					{
						component2.isKinematic = true;
						component2.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
					}
					else
					{
						Rigidbody rigidbody2 = collider.gameObject.AddComponent<Rigidbody>();
						rigidbody2.isKinematic = true;
						rigidbody2.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
					}
				}
			}
			DamageableBodyPart[] array = list.ToArray();
			foreach (DamageableBodyPart damageableBodyPart in array)
			{
				if (damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.Hips) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.Spine) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.Chest) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.UpperChest))
				{
					damageableBodyPart.DamageMultiplier = TorsoValue;
				}
				if (damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.Head))
				{
					damageableBodyPart.DamageMultiplier = HeadValue;
				}
				if (damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.LeftFoot) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.RightLowerLeg) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.RightUpperLeg) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.RightFoot))
				{
					damageableBodyPart.DamageMultiplier = LegValue;
				}
				if (damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.LeftLowerArm) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.LeftUpperArm) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.LeftHand) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.RightLowerArm) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.RightUpperArm) || damageableBodyPart.transform == animator.GetBoneTransform(HumanBodyBones.RightHand))
				{
					damageableBodyPart.DamageMultiplier = ArmValue;
				}
			}
			return list.ToArray();
		}
	}
}
