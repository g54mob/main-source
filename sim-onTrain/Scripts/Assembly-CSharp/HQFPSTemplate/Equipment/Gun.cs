using System;
using System.Linq;
using HQFPSTemplate.Items;
using HQFPSTemplate.Surfaces;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class Gun : ProjectileWeapon
	{
		private float m_NextTimeCanChangeMode = -1f;

		private GunSettings.Shooting m_P;

		protected ItemProperty m_FireModes;

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_P = (base.EInfo as GunInfo).Projectile;
		}

		public override void Equip(Item item)
		{
			base.Equip(item);
			if (item.HasProperty(base.EHandler.ItemProperties.FireModeProperty))
			{
				m_FireModes = item.GetProperty(base.EHandler.ItemProperties.FireModeProperty);
				base.SelectedFireMode = m_FireModes.Integer;
				SelectFireMode(base.SelectedFireMode);
			}
		}

		public override bool TryChangeUseMode()
		{
			if (m_FireModes != null && Time.time > m_NextTimeCanChangeMode)
			{
				m_NextTimeCanChangeMode = Time.time + 0.3f;
				m_NextTimeCanUse = Time.time + 0.3f;
				int nextFireModeIndex = GetNextFireModeIndex(base.SelectedFireMode);
				if (nextFireModeIndex == base.SelectedFireMode)
				{
					return false;
				}
				base.SelectedFireMode = nextFireModeIndex;
				SelectFireMode(base.SelectedFireMode);
				base.EHandler.PlayDelayedSound(m_PW.Shooting.FireModeChangeAudio);
				return true;
			}
			return false;
		}

		public override void Shoot(Ray[] itemUseRays)
		{
			base.Shoot(itemUseRays);
			Vector3[] array = new Vector3[m_P.RayCount];
			if (m_P.RayCount > 1)
			{
				for (int i = 0; i < m_P.RayCount; i++)
				{
					array[i] = DoHitscan(itemUseRays[i]);
				}
			}
			else
			{
				array[0] = DoHitscan(itemUseRays[0]);
			}
			FireHitPoints.Send(array);
		}

		public override float GetUseRaySpreadMod()
		{
			return m_P.RaySpread * m_P.SpreadOverTime.Evaluate((float)base.EHandler.ContinuouslyUsedTimes / (float)base.MagazineSize);
		}

		public override int GetUseRaysAmount()
		{
			return m_P.RayCount;
		}

		protected Vector3 DoHitscan(Ray itemUseRay)
		{
			if (Physics.Raycast(itemUseRay, out var hitInfo, m_P.RayImpact.MaxDistance, m_P.RayMask, QueryTriggerInteraction.Collide))
			{
				float impulseAtDistance = m_P.RayImpact.GetImpulseAtDistance(hitInfo.distance);
				bool flag = hitInfo.collider.GetComponentInParent<ZombieController>() != null;
				if (hitInfo.rigidbody != null && !flag)
				{
					hitInfo.rigidbody.AddForceAtPosition(itemUseRay.direction * impulseAtDistance, hitInfo.point, ForceMode.Impulse);
				}
				float damageAtDistance = m_P.RayImpact.GetDamageAtDistance(hitInfo.distance);
				DamageInfo arg = new DamageInfo(0f - damageAtDistance, DamageType.Bullet, hitInfo.point, itemUseRay.direction, impulseAtDistance * (float)m_P.RayCount, hitInfo.normal, base.Player, hitInfo.transform);
				base.Player.DealDamage.Try(arg, null);
				if (!flag)
				{
					SurfaceManager.SpawnEffect(hitInfo, SurfaceEffects.BulletHit, 1f);
				}
			}
			else
			{
				hitInfo.point = itemUseRay.GetPoint(10f);
			}
			Debug.DrawLine(itemUseRay.origin, hitInfo.point, Color.yellow, 3f);
			return hitInfo.point;
		}

		private void SelectFireMode(int selectedMode)
		{
			UpdateFireModeSettings(selectedMode);
			m_FireModes.Integer = selectedMode;
		}

		private int GetNextFireModeIndex(int currentIndex)
		{
			int num = (int)Enum.GetValues(typeof(ProjectileWeaponInfo.FireMode)).Cast<ProjectileWeaponInfo.FireMode>().Max();
			int num2 = 0;
			int num3 = currentIndex;
			int num4 = ((num3 == num) ? 1 : (num3 * 2));
			while (num4 <= num && num2 <= 20)
			{
				if (m_PW.Shooting.Modes.HasFlag((ProjectileWeaponInfo.FireMode)num4))
				{
					num3 = num4;
					break;
				}
				num4 = ((num4 == num) ? 1 : (num4 * 2));
				num2++;
			}
			return num3;
		}
	}
}
