using System;
using System.Collections;
using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class LauncherWeapon : ProjectileWeapon
	{
		[Serializable]
		public class LauncherSettings
		{
			[Tooltip("Object to disable after using this weapon (e.g. arrow)")]
			public GameObject FPProjectile;

			[EnableIf("FPProjectile", true, 0f)]
			public float EnableFPProjectileReloadDelay = 1f;
		}

		[SerializeField]
		[Group]
		private LauncherSettings m_LauncherSettings;

		private LauncherInfo.LaunchingInfo m_L;

		private WaitForSeconds m_WaitAfterLaunch;

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_L = (base.EInfo as LauncherInfo).Launching;
			m_WaitAfterLaunch = new WaitForSeconds(m_L.LaunchDelay);
		}

		public override void Equip(Item item)
		{
			base.Equip(item);
			if (m_LauncherSettings.FPProjectile != null)
			{
				m_LauncherSettings.FPProjectile.SetActive(CanBeUsed());
			}
			base.Player.Reload.AddStartListener(On_Reload);
		}

		public override void Unequip()
		{
			base.Unequip();
			base.Player.Reload.RemoveStartListener(On_Reload);
		}

		public override void Shoot(Ray[] itemUseRays)
		{
			base.Shoot(itemUseRays);
			if (tpsWeapon != null && tpsWeapon.isLocalPlayer && m_GeneralInfo.bulletData != null)
			{
				Vector3 spawnPosition = itemUseRays[0].origin + base.transform.TransformVector(m_L.SpawnOffset);
				Vector3 direction = itemUseRays[0].direction;
				string itemName = m_GeneralInfo.bulletData.itemName;
				tpsWeapon.CmdFireArrow(spawnPosition, direction, itemName, m_L.LaunchSpeed);
				StartCoroutine(C_LaunchWithDelay());
			}
		}

		private IEnumerator C_LaunchWithDelay()
		{
			yield return m_WaitAfterLaunch;
			if (m_LauncherSettings.FPProjectile != null)
			{
				m_LauncherSettings.FPProjectile.SetActive(value: false);
			}
		}

		public override float GetUseRaySpreadMod()
		{
			return m_L.LaunchSpread;
		}

		private void On_Reload()
		{
			if (m_LauncherSettings.FPProjectile != null)
			{
				StartCoroutine(C_OnReload());
			}
		}

		private IEnumerator C_OnReload()
		{
			yield return new WaitForSeconds(m_LauncherSettings.EnableFPProjectileReloadDelay);
			if (base.Player.Reload.Active)
			{
				m_LauncherSettings.FPProjectile.SetActive(value: true);
			}
		}

		private IEnumerator C_LaunchWithDelay(Ray[] itemUseRays)
		{
			yield return m_WaitAfterLaunch;
			if (m_LauncherSettings.FPProjectile != null)
			{
				m_LauncherSettings.FPProjectile.SetActive(value: false);
			}
			if (!m_L.Prefab)
			{
				Debug.LogErrorFormat("No Projectile prefab assigned in the inspector! Please assign one.");
				yield return null;
			}
			Vector3 position = itemUseRays[0].origin + base.transform.TransformVector(m_L.SpawnOffset);
			Quaternion rotation = Quaternion.LookRotation(itemUseRays[0].direction, base.transform.up);
			ShaftedProjectile shaftedProjectile = UnityEngine.Object.Instantiate(m_L.Prefab, position, rotation);
			shaftedProjectile.GetComponent<Rigidbody>().velocity = shaftedProjectile.transform.forward * m_L.LaunchSpeed;
			shaftedProjectile.GetComponent<ShaftedProjectile>().Launch(base.Player);
			shaftedProjectile.GetComponent<ShaftedProjectile>().CheckForSurfaces(itemUseRays[0]);
			RaycastHit raycastHit = default(RaycastHit);
			FireHitPoints.Send(new Vector3[1] { raycastHit.point });
		}
	}
}
