using System;
using System.Collections;
using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public abstract class ProjectileWeapon : EquipmentItem
	{
		public struct AmmoInfo
		{
			public int CurrentInMagazine;

			public int CurrentInStorage;

			public override string ToString()
			{
				return $"Ammo In Mag: {CurrentInMagazine}. Total Ammo: {CurrentInStorage}";
			}
		}

		private readonly int animHash_Fire = Animator.StringToHash("Fire");

		private readonly int animHash_FireSpeed = Animator.StringToHash("Fire Speed");

		private readonly int animHash_FireIndex = Animator.StringToHash("Fire Index");

		private readonly int animHash_Reload = Animator.StringToHash("Reload");

		private readonly int animHash_EmptyReload = Animator.StringToHash("Empty Reload");

		private readonly int animHash_StartReload = Animator.StringToHash("Start Reload");

		private readonly int animHash_EndReload = Animator.StringToHash("End Reload");

		private readonly int animHash_ReloadSpeed = Animator.StringToHash("Reload Speed");

		private readonly int animHash_EmptyReloadSpeed = Animator.StringToHash("Empty Reload Speed");

		public Message<Vector3[]> FireHitPoints = new Message<Vector3[]>();

		public Message DryFire = new Message();

		public Value<AmmoInfo> CurrentAmmoInfo = new Value<AmmoInfo>();

		public PlayerWeaponController tpsWeapon;

		protected ProjectileWeaponInfo m_PW;

		protected int m_CurrentFireAnimIndex;

		private int m_AmmoToAdd;

		private bool m_ReloadLoopStarted;

		private float m_ReloadLoopEndTime;

		private float m_ReloadStartTime;

		private bool m_EndReload;

		protected ItemProperty m_AmmoTypeProperty;

		protected ItemProperty m_AmmoProperty;

		private WaitForSeconds m_BurstWait;

		public int lastAmmoChargedSize;

		public int currentMagazine;

		public int SelectedFireMode { get; protected set; } = 2;

		public int MagazineSize => m_PW.Shooting.MagazineSize;

		public bool AmmoEnabled => m_PW.Shooting.EnableAmmo;

		public void UpdateAmmoInfo()
		{
			if (m_PW.Shooting.EnableAmmo)
			{
				CurrentAmmoInfo.Set(new AmmoInfo
				{
					CurrentInMagazine = GetAmmoInMagazine(),
					CurrentInStorage = GetAmmoCount()
				});
			}
		}

		public void CheckAmmoStatus()
		{
			UpdateAmmoInfo();
			if (GetAmmoCount() < m_PW.Shooting.MagazineSize)
			{
				currentMagazine = GetAmmoCount();
				UpdateAmmoInfo();
			}
		}

		public override float GetTimeBetweenUses()
		{
			return m_UseThreshold * Mathf.Clamp(1f / m_PW.Shooting.FireRateOverTime.Evaluate((float)base.EHandler.ContinuouslyUsedTimes / (float)MagazineSize), 0.1f, 10f);
		}

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_PW = base.EInfo as ProjectileWeaponInfo;
			m_BurstWait = new WaitForSeconds(m_PW.Shooting.BurstDuration / (float)m_PW.Shooting.BurstLength);
			UpdateFireModeSettings(SelectedFireMode);
			UpdateAmmoInfo();
			m_GeneralInfo.connectedInventory.OnCollectableCollected.AddListener(delegate(CollectableItemData x, int y, float z)
			{
				if (x == m_GeneralInfo.bulletData)
				{
					UpdateAmmoInfo();
				}
			});
			m_GeneralInfo.connectedInventory.OnInventoryUpdated.AddListener(CheckAmmoStatus);
		}

		public override void Equip(Item item)
		{
			base.Equip(item);
			currentMagazine = m_Chooser.lastSelectedSlot.InventoryItem.inventoryData.currentMagazineCount;
			m_AmmoProperty = item.GetProperty(base.EHandler.ItemProperties.AmmoProperty);
			m_AmmoTypeProperty = item.GetProperty(base.EHandler.ItemProperties.AmmoTypeProperty);
			if (m_PW.Shooting.EnableAmmo)
			{
				if (m_AmmoProperty != null)
				{
					int num = m_AmmoProperty.Integer - m_PW.Shooting.MagazineSize;
					if (num > 0)
					{
						AddAmmoToInventory(num);
					}
					m_AmmoProperty.Integer = Mathf.Clamp(m_AmmoProperty.Integer, 0, m_PW.Shooting.MagazineSize);
				}
				else
				{
					Debug.LogError("Equipment item with name '" + base.name + "' has ammo enabled but no ammo property found on the item.");
				}
				UpdateAmmoInfo();
			}
			base.EHandler.Animator_SetFloat(animHash_FireSpeed, m_PW.Shooting.FireAnimationSpeed);
			base.EHandler.Animator_SetFloat(animHash_EmptyReloadSpeed, m_PW.Reloading.EmptyReloadAnimationSpeed);
			base.EHandler.Animator_SetFloat(animHash_ReloadSpeed, m_PW.Reloading.ReloadAnimationSpeed);
		}

		public override bool TryUseOnce(Ray[] itemUseRays, int useType)
		{
			bool flag = false;
			if (Time.time > m_NextTimeCanUse)
			{
				flag = (CurrentAmmoInfo.Val.CurrentInMagazine > 0 || !m_PW.Shooting.EnableAmmo) && SelectedFireMode != 1;
				if (flag && m_Chooser != null && m_Chooser.lastSelectedSlot != null && m_Chooser.lastSelectedSlot.InventoryItem != null && !m_Chooser.lastSelectedSlot.InventoryItem.CanUse())
				{
					flag = false;
					Debug.Log("[ProjectileWeapon] Cannot use - durability is 0");
				}
				if (flag)
				{
					if (SelectedFireMode == 4)
					{
						StartCoroutine(C_DoBurst());
					}
					else
					{
						Shoot(itemUseRays);
						tpsWeapon.Shoot();
					}
					m_NextTimeCanUse = Time.time + m_UseThreshold * Mathf.Clamp(1f / m_PW.Shooting.FireRateOverTime.Evaluate((float)base.EHandler.ContinuouslyUsedTimes / (float)m_PW.Shooting.MagazineSize), 0.1f, 10f);
					m_GeneralEvents.OnUse.Invoke();
				}
				else if (!base.Player.Reload.Active)
				{
					base.EHandler.PlaySound(m_PW.Shooting.DryShootAudio, 1f);
					if (m_PW.Shooting.HasDryFireAnim)
					{
						base.EHandler.Animator_SetFloat(animHash_FireIndex, 4f);
						base.EHandler.Animator_SetTrigger(animHash_Fire);
					}
					DryFire.Send();
					m_NextTimeCanUse = Time.time + 0.1f;
				}
			}
			return flag;
		}

		public override bool TryUseContinuously(Ray[] itemUseRays, int useType)
		{
			if ((CurrentAmmoInfo.Val.CurrentInMagazine == 0 && m_PW.Shooting.EnableAmmo) || SelectedFireMode == 1)
			{
				return false;
			}
			if (SelectedFireMode == 8)
			{
				return TryUseOnce(itemUseRays, useType);
			}
			return false;
		}

		public override void OnAimStart()
		{
			base.OnAimStart();
			base.EHandler.PlaySound(m_PW.Aiming.AimSounds, 1f);
		}

		public virtual void Shoot(Ray[] itemUseRays)
		{
			if (m_GeneralInfo?.connectedInventory != null && m_GeneralInfo.bulletData != null)
			{
				m_GeneralInfo.connectedInventory.AddItemInventory(m_GeneralInfo.bulletData, -1);
			}
			try
			{
				if (m_Chooser != null && m_Chooser.lastSelectedSlot != null && m_Chooser.lastSelectedSlot.InventoryItem != null)
				{
					m_Chooser.lastSelectedSlot.InventoryItem.DecreaseDurability();
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("[ProjectileWeapon] Could not decrease durability: " + ex.Message);
			}
			NetworkSoundPlayer.Instance.PlaySound(m_PW.Shooting.networkShootSound, base.transform.position);
			base.EHandler.PlayDelayedSounds(m_PW.Shooting.HandlingAudio);
			if (base.Player.IsGrounded.Get() && m_PW.Shooting.CasingDropAudio.Length != 0)
			{
				base.EHandler.PlayDelayedSounds(m_PW.Shooting.CasingDropAudio);
			}
			int num;
			if (!base.Player.Aim.Active)
			{
				num = ((m_CurrentFireAnimIndex != 0) ? 2 : 0);
				if (m_PW.Shooting.HasAlternativeFireAnim)
				{
					m_CurrentFireAnimIndex = ((m_CurrentFireAnimIndex == 0) ? 1 : 0);
				}
			}
			else
			{
				num = ((m_CurrentFireAnimIndex == 0) ? 1 : 3);
				if (m_PW.Shooting.HasAlternativeFireAnim)
				{
					m_CurrentFireAnimIndex = ((m_CurrentFireAnimIndex == 0) ? 1 : 0);
				}
			}
			base.EHandler.Animator_SetFloat(animHash_FireIndex, num);
			base.EHandler.Animator_SetTrigger(animHash_Fire);
			base.Player.Camera.Physics.PlayDelayedCameraForces(m_PW.Shooting.HandlingCamForces);
			if (m_PW.Shooting.EnableAmmo)
			{
				m_AmmoProperty.Integer--;
				currentMagazine--;
				m_Chooser.lastSelectedSlot.InventoryItem.inventoryData.currentMagazineCount = currentMagazine;
				UpdateAmmoInfo();
			}
		}

		public override bool TryStartReload()
		{
			if (m_ReloadLoopEndTime < Time.time && m_PW.Shooting.EnableAmmo && CurrentAmmoInfo.Val.CurrentInMagazine < m_PW.Shooting.MagazineSize)
			{
				m_AmmoToAdd = m_PW.Shooting.MagazineSize - CurrentAmmoInfo.Val.CurrentInMagazine;
				if (CurrentAmmoInfo.Val.CurrentInStorage < m_AmmoToAdd)
				{
					m_AmmoToAdd = CurrentAmmoInfo.Val.CurrentInStorage;
				}
				if (m_AmmoToAdd > 0)
				{
					base.EHandler.ClearDelayedSounds();
					if (CurrentAmmoInfo.Val.CurrentInMagazine == 0 && m_PW.Reloading.HasEmptyReload)
					{
						if (m_PW.Reloading.ReloadType == ProjectileWeaponInfo.ReloadType.Once)
						{
							m_ReloadLoopEndTime = Time.time + m_PW.Reloading.EmptyReloadDuration;
						}
						else if (m_PW.Reloading.ReloadType == ProjectileWeaponInfo.ReloadType.Progressive)
						{
							m_ReloadStartTime = Time.time + m_PW.Reloading.EmptyReloadDuration;
						}
						base.EHandler.Animator_SetTrigger(animHash_EmptyReload);
						base.Player.Camera.Physics.PlayDelayedCameraForces(m_PW.Reloading.EmptyReloadLoopCamForces);
						base.EHandler.PlayDelayedSounds(m_PW.Reloading.EmptyReloadSounds);
					}
					else if (m_PW.Reloading.ReloadType == ProjectileWeaponInfo.ReloadType.Once)
					{
						m_ReloadLoopEndTime = Time.time + m_PW.Reloading.ReloadDuration;
						base.EHandler.Animator_SetTrigger(animHash_Reload);
						base.Player.Camera.Physics.PlayDelayedCameraForces(m_PW.Reloading.ReloadLoopCamForces);
						base.EHandler.PlayDelayedSounds(m_PW.Reloading.ReloadSounds);
					}
					else if (m_PW.Reloading.ReloadType == ProjectileWeaponInfo.ReloadType.Progressive)
					{
						m_ReloadStartTime = Time.time + m_PW.Reloading.ReloadStartDuration;
						base.EHandler.Animator_SetTrigger(animHash_StartReload);
						base.Player.Camera.Physics.PlayDelayedCameraForces(m_PW.Reloading.ReloadStartCamForces);
						base.EHandler.PlayDelayedSounds(m_PW.Reloading.ReloadStartSounds);
					}
					if (m_PW.Reloading.ReloadType == ProjectileWeaponInfo.ReloadType.Once)
					{
						UpdateAmmoInfo();
					}
					tpsWeapon.Reload();
					m_GeneralEvents.OnReload.Invoke(arg0: true);
					return true;
				}
			}
			return false;
		}

		public override bool IsDoneReloading()
		{
			if (!m_ReloadLoopStarted)
			{
				if (Time.time > m_ReloadStartTime)
				{
					if (CurrentAmmoInfo.Val.CurrentInMagazine == 0 && m_PW.Reloading.HasEmptyReload)
					{
						m_ReloadLoopStarted = true;
						if (m_PW.Reloading.ProgressiveEmptyReload && m_PW.Reloading.ReloadType == ProjectileWeaponInfo.ReloadType.Progressive)
						{
							if (m_AmmoToAdd <= 1)
							{
								GetAmmoFromInventory(1);
								m_AmmoProperty.Integer++;
								currentMagazine++;
								m_Chooser.lastSelectedSlot.InventoryItem.inventoryData.currentMagazineCount = currentMagazine;
								m_AmmoToAdd--;
								return true;
							}
							base.Player.Camera.Physics.PlayDelayedCameraForces(m_PW.Reloading.ReloadStartCamForces);
							base.EHandler.PlayDelayedSounds(m_PW.Reloading.ReloadStartSounds);
							m_ReloadLoopEndTime = Time.time + m_PW.Reloading.ReloadStartDuration;
							base.EHandler.Animator_SetTrigger(animHash_StartReload);
						}
					}
					else
					{
						m_ReloadLoopStarted = true;
						m_ReloadLoopEndTime = Time.time + m_PW.Reloading.ReloadDuration;
						base.Player.Camera.Physics.PlayDelayedCameraForces(m_PW.Reloading.ReloadLoopCamForces);
						base.EHandler.PlayDelayedSounds(m_PW.Reloading.ReloadSounds);
						base.EHandler.Animator_SetTrigger(animHash_Reload);
					}
				}
				return false;
			}
			if (m_ReloadLoopStarted && Time.time >= m_ReloadLoopEndTime)
			{
				if (m_PW.Reloading.ReloadType == ProjectileWeaponInfo.ReloadType.Once || (CurrentAmmoInfo.Val.CurrentInMagazine == 0 && !m_PW.Reloading.ProgressiveEmptyReload))
				{
					m_AmmoProperty.Integer += m_AmmoToAdd;
					GetAmmoFromInventory(m_AmmoToAdd);
					currentMagazine += m_AmmoToAdd;
					m_Chooser.lastSelectedSlot.InventoryItem.inventoryData.currentMagazineCount = currentMagazine;
					m_AmmoToAdd = 0;
					lastAmmoChargedSize = m_AmmoToAdd;
				}
				else if (m_PW.Reloading.ReloadType == ProjectileWeaponInfo.ReloadType.Progressive)
				{
					if (m_AmmoToAdd > 0)
					{
						GetAmmoFromInventory(1);
						m_AmmoProperty.Integer++;
						currentMagazine++;
						m_Chooser.lastSelectedSlot.InventoryItem.inventoryData.currentMagazineCount = currentMagazine;
						m_AmmoToAdd--;
					}
					if (m_AmmoToAdd > 0)
					{
						base.Player.Camera.Physics.PlayDelayedCameraForces(m_PW.Reloading.ReloadLoopCamForces);
						base.EHandler.PlayDelayedSounds(m_PW.Reloading.ReloadSounds);
						base.EHandler.Animator_SetTrigger(animHash_Reload);
						m_ReloadLoopEndTime = Time.time + m_PW.Reloading.ReloadDuration;
					}
					else if (!m_EndReload)
					{
						base.EHandler.Animator_SetTrigger(animHash_EndReload);
						m_EndReload = true;
						m_ReloadLoopEndTime = Time.time + m_PW.Reloading.ReloadEndDuration;
						base.Player.Camera.Physics.PlayDelayedCameraForces(m_PW.Reloading.ReloadEndCamForces);
						base.EHandler.PlayDelayedSounds(m_PW.Reloading.ReloadEndSounds);
					}
					else
					{
						m_EndReload = false;
					}
				}
				UpdateAmmoInfo();
				if (!m_EndReload)
				{
					return m_AmmoToAdd == 0;
				}
				return false;
			}
			return false;
		}

		public override void OnReloadStop()
		{
			m_ReloadLoopEndTime = Time.time;
			m_EndReload = false;
			m_ReloadLoopStarted = false;
			base.EHandler.ClearDelayedSounds();
			m_GeneralEvents.OnReload.Invoke(arg0: false);
		}

		public override void OnUseEnd()
		{
			NetworkSoundPlayer.Instance.PlaySound(m_PW.Shooting.networkShootTailAudio, base.transform.position);
		}

		public override bool CanBeUsed()
		{
			if (CurrentAmmoInfo.Get().CurrentInMagazine <= 0)
			{
				return !m_PW.Shooting.EnableAmmo;
			}
			return true;
		}

		protected virtual void OnEnable()
		{
			base.Player.Inventory.ContainerChanged.AddListener(OnInventoryChanged);
		}

		protected virtual void OnDisable()
		{
			base.Player.Inventory.ContainerChanged.RemoveListener(OnInventoryChanged);
		}

		protected int AddAmmoToInventory(int amount)
		{
			return base.Player.Inventory.AddItem(m_AmmoTypeProperty.ItemId, amount, ItemContainerFlags.Storage);
		}

		public int GetAmmoCount()
		{
			return m_GeneralInfo.connectedInventory.GetTotalItemCount(m_GeneralInfo.bulletData);
		}

		public int GetAmmoInMagazine()
		{
			return currentMagazine;
		}

		protected int GetAmmoFromInventory(int amount)
		{
			return amount;
		}

		protected virtual void UpdateFireModeSettings(int selectedMode)
		{
			if (4 == selectedMode)
			{
				m_UseThreshold = m_PW.Shooting.BurstDuration + m_PW.Shooting.BurstPause;
			}
			else if (8 == selectedMode)
			{
				m_UseThreshold = 60f / (float)m_PW.Shooting.RoundsPerMinute;
			}
			else if (2 == selectedMode)
			{
				m_UseThreshold = m_PW.Shooting.FireDuration;
			}
			else if (1 == selectedMode)
			{
				m_UseThreshold = m_PW.Shooting.FireDuration;
			}
		}

		private void OnInventoryChanged()
		{
			if (m_PW.Shooting.EnableAmmo)
			{
				UpdateAmmoInfo();
			}
		}

		private IEnumerator C_DoBurst()
		{
			for (int i = 0; i < m_PW.Shooting.BurstLength; i++)
			{
				if (!CanBeUsed())
				{
					break;
				}
				Shoot(base.EHandler.GenerateItemUseRays(base.Player, base.EHandler.ItemUseTransform, GetUseRaysAmount(), GetUseRaySpreadMod()));
				yield return m_BurstWait;
			}
		}
	}
}
