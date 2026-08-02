using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class MeleeWeapon : EquipmentItem
	{
		public bool isBlockedToUse;

		public bool skipHitSound;

		public bool isUnarmed;

		private MeleeWeaponInfo m_MW;

		private int m_LastFreeSwing;

		private float m_NextResetSwingSelectionTime;

		public bool useContinusly;

		[ShowIf("useContinusly", true, 10f)]
		public float repeatTime;

		private EquipmentHandler m_EquipmentHandler;

		private Coroutine repeatIEnumerator;

		private bool useInCooldown;

		private float useTimer;

		public PlayerWeaponController tpsWeapon;

		public TsPlayerAnimationController tpsAnimationController;

		public List<TPSAnimationInfo> tpsAnimationKeys;

		public PlayerWeaponVisuals weaponVisuals;

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_EquipmentHandler = eHandler;
			m_MW = base.EInfo as MeleeWeaponInfo;
		}

		public override bool TryUseOnce(Ray[] itemUseRays, int useType)
		{
			if (isBlockedToUse)
			{
				return false;
			}
			if (Time.time < m_NextTimeCanUse)
			{
				return false;
			}
			if (!isUnarmed && m_EquipmentHandler != null)
			{
				EastUpPlayerItemManager componentInParent = m_EquipmentHandler.GetComponentInParent<EastUpPlayerItemManager>();
				if (componentInParent != null && componentInParent.lastSelectedSlot != null && componentInParent.lastSelectedSlot.InventoryItem != null && !componentInParent.lastSelectedSlot.InventoryItem.CanUse())
				{
					Debug.Log("[MeleeWeapon] Cannot use - durability is 0");
					return false;
				}
			}
			MeleeWeaponInfo.SwingData swingData = ((!(Time.time > m_NextResetSwingSelectionTime) || !m_MW.MeleeSettings.ResetSwingsIfNotUsed) ? m_MW.MeleeSettings.Swings.Select(ref m_LastFreeSwing, m_MW.MeleeSettings.SwingSelection) : m_MW.MeleeSettings.Swings[0]);
			m_UseThreshold = swingData.Cooldown;
			m_NextTimeCanUse = Time.time + m_UseThreshold;
			if (m_MW.MeleeSettings.ResetSwingsIfNotUsed)
			{
				m_NextResetSwingSelectionTime = Time.time + m_MW.MeleeSettings.ResetSwingsDelay;
			}
			base.EHandler.Animator_SetFloat(EASTUP_AnimationKeys.animHash_SwingIndex, swingData.AnimationIndex);
			base.EHandler.Animator_SetTrigger(EASTUP_AnimationKeys.animHash_Swing);
			if (TryGetComponent<FPSWeaponBase>(out var component))
			{
				component.Hit(0.15f);
			}
			if (tpsAnimationController != null && tpsAnimationKeys != null && tpsAnimationKeys.Count > 0)
			{
				int num = swingData.AnimationIndex;
				if (num >= tpsAnimationKeys.Count)
				{
					num = 0;
				}
				if (isUnarmed)
				{
					tpsAnimationController.SetNetworkTriggerWithUpperBody(tpsAnimationKeys[num].LayerIndex, tpsAnimationKeys[num].AnimName, tpsAnimationKeys[num].animTime);
				}
				else
				{
					tpsWeapon.Shoot();
				}
			}
			else
			{
				tpsWeapon.Shoot();
			}
			base.EHandler.Animator_SetFloat(EASTUP_AnimationKeys.animHash_SwingSpeed, swingData.AnimationSpeed);
			base.Player.Camera.Physics.AddPositionForce(swingData.SwingCamForces.PositionForce);
			base.Player.Camera.Physics.AddRotationForce(swingData.SwingCamForces.RotationForce);
			NetworkSoundPlayer.Instance.PlaySound(swingData.networkSwingSound, base.transform.position);
			StartCoroutine(C_SphereCastDelayed(swingData));
			return true;
		}

		public override bool TryUseContinuously(Ray[] itemUseRays, int useType)
		{
			if (!m_MW.MeleeSettings.CanContinuouslyAttack && !useContinusly)
			{
				return false;
			}
			return TryUseOnce(itemUseRays, useType);
		}

		protected virtual IDamageable SphereCast(Ray itemUseRays, MeleeWeaponInfo.SwingData swing)
		{
			IDamageable result = null;
			float maxHitDistance = m_MW.MeleeSettings.MaxHitDistance;
			Vector3 position = itemUseRays.origin + itemUseRays.direction * (maxHitDistance * 0.5f);
			float radius = maxHitDistance * 0.5f + swing.CastRadius;
			Collider[] array = Physics.OverlapSphere(position, radius, m_MW.MeleeSettings.HitMask, QueryTriggerInteraction.Collide);
			Collider collider = null;
			float num = float.MaxValue;
			Collider collider2 = null;
			float num2 = float.MaxValue;
			IDamageable damageable = null;
			Collider[] array2 = array;
			foreach (Collider collider3 in array2)
			{
				if (collider3.transform.IsChildOf(base.Player.transform) || collider3.transform == base.Player.transform)
				{
					continue;
				}
				float num3 = Vector3.Distance(itemUseRays.origin, collider3.ClosestPoint(itemUseRays.origin));
				if (!(num3 > maxHitDistance))
				{
					if (num3 < num)
					{
						num = num3;
						collider = collider3;
					}
					IDamageable componentInParent = collider3.GetComponentInParent<IDamageable>();
					if (componentInParent != null && num3 < num2)
					{
						num2 = num3;
						collider2 = collider3;
						damageable = componentInParent;
					}
				}
			}
			Collider collider4 = ((collider2 != null) ? collider2 : collider);
			if (collider4 != null)
			{
				Vector3 vector = collider4.ClosestPoint(itemUseRays.origin);
				if (collider4.attachedRigidbody != null)
				{
					collider4.attachedRigidbody.AddForceAtPosition(itemUseRays.direction * swing.HitImpact, vector, ForceMode.Impulse);
				}
				DamageInfo arg = new DamageInfo(0f - m_GeneralInfo.hitDamage, m_MW.MeleeSettings.DamageType, vector, itemUseRays.direction, swing.HitImpact, base.Player, collider4.transform);
				if (!skipHitSound)
				{
					Debug.Log(string.Format("[MELEE_HITSOUND] Hit sound oynatıldı -> collider={0}, damageable={1}, mesafe={2:F2}, hitPoint={3}", collider4.name, (damageable != null) ? damageable.GetType().Name : "YOK", (collider2 != null) ? num2 : num, vector));
					NetworkSoundPlayer.Instance.PlaySound(swing.networkHitSound, vector);
				}
				base.Player.Camera.Physics.AddPositionForce(swing.HitCamForces.PositionForce);
				base.Player.Camera.Physics.AddRotationForce(swing.HitCamForces.RotationForce);
				base.Player.DealDamage.Try(arg, damageable);
				if (!isUnarmed && m_EquipmentHandler != null)
				{
					EastUpPlayerItemManager componentInParent2 = m_EquipmentHandler.GetComponentInParent<EastUpPlayerItemManager>();
					if (componentInParent2 != null && componentInParent2.lastSelectedSlot != null && componentInParent2.lastSelectedSlot.InventoryItem != null)
					{
						componentInParent2.lastSelectedSlot.InventoryItem.DecreaseDurability();
					}
				}
			}
			return result;
		}

		private IEnumerator C_SphereCastDelayed(MeleeWeaponInfo.SwingData swing)
		{
			yield return new WaitForSeconds(swing.CastDelay);
			m_GeneralEvents.OnUse.Invoke();
			Ray[] array = base.EHandler.GenerateItemUseRays(base.Player, base.EHandler.ItemUseTransform, 1, 1f);
			SphereCast(array[0], swing);
		}
	}
}
