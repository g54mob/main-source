using System;
using System.Collections;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class WeaponCorrector : MonoBehaviour, IEquipmentComponent
	{
		[Serializable]
		private class MovingPartsCorrector
		{
			[Serializable]
			public struct MovingPart
			{
				public Transform MovingPartTransform;

				public Vector3 EmptyPosition;

				public Vector3 EmptyRotation;
			}

			public float MoveDelay = 0.1f;

			[Group]
			public MovingPart[] MovingParts = new MovingPart[0];
		}

		[Serializable]
		private class CartridgeCorrector
		{
			[HideInInspector]
			public CartridgeObject[] Cartridges;

			public CartridgeObject CartridgePrefab;

			public Transform[] CartridgeTransforms;

			[Space(5f)]
			public bool ReloadReverseOrderUpdate;

			public float ReloadUpdateDelay = 0.5f;
		}

		[SerializeField]
		[Group]
		private MovingPartsCorrector m_MovingPartsCorrector;

		[SerializeField]
		[Group]
		private CartridgeCorrector m_CartridgeCorrector;

		protected ProjectileWeapon m_Weapon;

		private float m_CanUpdateMovingPartsTime;

		private bool m_UpdateMovingParts;

		public virtual void Initialize(EquipmentItem equipmentItem)
		{
			m_Weapon = equipmentItem as ProjectileWeapon;
			if (m_CartridgeCorrector.CartridgePrefab != null)
			{
				m_CartridgeCorrector.Cartridges = new CartridgeObject[m_CartridgeCorrector.CartridgeTransforms.Length];
				for (int i = 0; i < m_CartridgeCorrector.Cartridges.Length; i++)
				{
					m_CartridgeCorrector.Cartridges[i] = UnityEngine.Object.Instantiate(m_CartridgeCorrector.CartridgePrefab, m_CartridgeCorrector.CartridgeTransforms[i]);
				}
			}
		}

		public void OnSelected()
		{
			m_Weapon.CurrentAmmoInfo.AddChangeListener(OnAmmoChanged);
			m_Weapon.Player.Reload.AddStartListener(OnReload);
			if (m_CartridgeCorrector.CartridgePrefab != null)
			{
				m_CartridgeCorrector.CartridgePrefab.SetFOV(m_Weapon.EModel.TargetFOV);
			}
		}

		protected virtual void OnAmmoChanged(ProjectileWeapon.AmmoInfo ammoInfo)
		{
			if (ammoInfo.CurrentInMagazine < m_Weapon.CurrentAmmoInfo.PrevVal.CurrentInMagazine && !m_Weapon.Player.Reload.Active)
			{
				int currentInMagazine = ammoInfo.CurrentInMagazine;
				int magazineSize = m_Weapon.MagazineSize;
				if (magazineSize - (magazineSize - currentInMagazine) < m_CartridgeCorrector.Cartridges.Length)
				{
					m_CartridgeCorrector.Cartridges[magazineSize - (magazineSize - currentInMagazine)].ChangeState(enable: false);
				}
				if (currentInMagazine == 0)
				{
					m_CanUpdateMovingPartsTime = Time.time + m_MovingPartsCorrector.MoveDelay;
					m_UpdateMovingParts = true;
				}
			}
		}

		protected virtual void LateUpdate()
		{
			if (m_UpdateMovingParts && m_CanUpdateMovingPartsTime < Time.time)
			{
				UpdateMovingParts();
			}
		}

		protected virtual void OnReload()
		{
			m_UpdateMovingParts = false;
			int currentInMagazine = m_Weapon.CurrentAmmoInfo.Get().CurrentInMagazine;
			int magazineSize = m_Weapon.MagazineSize;
			int reloadingAmount = Mathf.Clamp(m_Weapon.CurrentAmmoInfo.Get().CurrentInStorage, 1, magazineSize);
			StartCoroutine(C_ReloadUpdateCartridges(currentInMagazine, reloadingAmount));
		}

		private void OnDisable()
		{
			m_Weapon.Player.Reload.RemoveStartListener(OnReload);
			m_Weapon.CurrentAmmoInfo.RemoveChangeListener(OnAmmoChanged);
		}

		private void UpdateMovingParts()
		{
			for (int i = 0; i < m_MovingPartsCorrector.MovingParts.Length; i++)
			{
				if (m_MovingPartsCorrector.MovingParts[i].EmptyPosition != Vector3.zero)
				{
					Vector3 localPosition = new Vector3(m_MovingPartsCorrector.MovingParts[i].MovingPartTransform.localPosition.x + m_MovingPartsCorrector.MovingParts[i].EmptyPosition.x, m_MovingPartsCorrector.MovingParts[i].MovingPartTransform.localPosition.y + m_MovingPartsCorrector.MovingParts[i].EmptyPosition.y, m_MovingPartsCorrector.MovingParts[i].MovingPartTransform.localPosition.z + m_MovingPartsCorrector.MovingParts[i].EmptyPosition.z);
					m_MovingPartsCorrector.MovingParts[i].MovingPartTransform.localPosition = localPosition;
				}
				if (m_MovingPartsCorrector.MovingParts[i].EmptyRotation != Vector3.zero)
				{
					Vector3 localEulerAngles = m_MovingPartsCorrector.MovingParts[i].MovingPartTransform.localEulerAngles;
					Vector3 localEulerAngles2 = new Vector3(localEulerAngles.x + m_MovingPartsCorrector.MovingParts[i].EmptyRotation.x, localEulerAngles.y + m_MovingPartsCorrector.MovingParts[i].EmptyRotation.y, localEulerAngles.z + m_MovingPartsCorrector.MovingParts[i].EmptyRotation.z);
					m_MovingPartsCorrector.MovingParts[i].MovingPartTransform.localEulerAngles = localEulerAngles2;
				}
			}
		}

		private IEnumerator C_ReloadUpdateCartridges(int currentInMag, int reloadingAmount)
		{
			yield return new WaitForSeconds(m_CartridgeCorrector.ReloadUpdateDelay);
			int num = Mathf.Clamp(reloadingAmount - currentInMag + 1, 0, m_CartridgeCorrector.Cartridges.Length);
			for (int i = 0; i < num; i++)
			{
				m_CartridgeCorrector.Cartridges[i].ChangeState(enable: true);
			}
		}
	}
}
