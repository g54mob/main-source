using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class PlayerEquipmentController : PlayerComponent
	{
		[SerializeField]
		private Camera m_FPCamera;

		[SerializeField]
		private bool m_AimWhileReloading;

		[SerializeField]
		private bool m_ReloadWhileProne;

		[SerializeField]
		private bool m_AutoReloadOnEmpty = true;

		[Space]
		[SerializeField]
		private EquipmentHandler[] m_EquipmentHandlers;

		private float m_NextTimeCanAutoReload;

		private float m_NextTimeToEquip;

		private bool m_WaitingToEquip;

		public EquipmentHandler ActiveEHandler { get; private set; }

		public Camera FPCamera => m_FPCamera;

		private void Awake()
		{
			base.Player.EquipItem.SetTryer(TryChangeItem);
			base.Player.SwapItem.SetTryer(TrySwapItems);
			base.Player.DestroyEquippedItem.SetTryer(TryDestroyHeldItem);
			base.Player.Death.AddListener(OnDeath);
			base.Player.UseItem.SetTryer(TryUse);
			base.Player.Aim.SetStartTryer(TryStartAim);
			base.Player.Aim.AddStopListener(OnAimStop);
			base.Player.Reload.SetStartTryer(OnReloadStart);
			base.Player.Reload.AddStopListener(OnReloadStop);
			base.Player.ChangeUseMode.SetTryer(TryChangeUseMode);
			base.Player.ObjectInProximity.AddChangeListener(OnChanged_ObjectInProximity);
			base.Player.IsGrounded.AddChangeListener(OnGroundedChange);
			ActiveEHandler = m_EquipmentHandlers[0];
		}

		private void OnDeath()
		{
			m_NextTimeCanAutoReload = 0f;
			m_NextTimeToEquip = 0f;
			m_WaitingToEquip = false;
			ActiveEHandler.Reset();
		}

		private void Update()
		{
			if (base.Player.Reload.Active && ActiveEHandler.IsDoneReloading())
			{
				base.Player.Reload.ForceStop();
			}
			if (m_WaitingToEquip && Time.time > m_NextTimeToEquip)
			{
				Equip(base.Player.EquippedItem.Get());
				m_WaitingToEquip = false;
			}
		}

		private bool TryChangeUseMode()
		{
			if (base.Player.Reload.Active || base.Player.Run.Active || ActiveEHandler.EquipmentItem == null)
			{
				return false;
			}
			return base.Player.ActiveEquipmentItem.Get().TryChangeUseMode();
		}

		private bool TryChangeItem(Item item, bool instantly)
		{
			if (base.Player.EquippedItem.Get() == item && item != null)
			{
				return false;
			}
			ChangeItem(item, instantly);
			return true;
		}

		private void ChangeItem(Item item, bool instantly)
		{
			m_WaitingToEquip = true;
			if (ActiveEHandler.EquipmentItem != null)
			{
				if (ActiveEHandler.UsingItem.Active)
				{
					ActiveEHandler.UsingItem.ForceStop();
					ActiveEHandler.EquipmentItem.OnUseEnd();
				}
				if (base.Player.Aim.Active)
				{
					base.Player.Aim.ForceStop();
				}
				if (base.Player.Reload.Active)
				{
					base.Player.Reload.ForceStop();
				}
				ActiveEHandler.UnequipItem();
				if (!instantly)
				{
					m_NextTimeToEquip = Time.time + ActiveEHandler.EquipmentItem.EInfo.Unequipping.Duration;
				}
			}
			base.Player.EquippedItem.Set(item);
		}

		private bool TryDestroyHeldItem()
		{
			if (base.Player.EquippedItem.Get() == null)
			{
				return false;
			}
			base.Player.Inventory.RemoveItem(base.Player.EquippedItem.Get());
			base.Player.EquipItem.Try(null, arg2: true);
			return true;
		}

		private bool TrySwapItems(Item item)
		{
			Item item2 = base.Player.EquippedItem.Get();
			if (item2 != null && ContainsEquipmentItem(item))
			{
				ItemSlot itemSlot = base.Player.Inventory.GetItemSlot(item2);
				if (base.Player.DropItem.Try(item2))
				{
					base.Player.DestroyEquippedItem.Try();
					base.Player.EquipItem.Try(item, arg2: true);
					itemSlot.SetItem(item);
					return true;
				}
			}
			return false;
		}

		public void Equip(Item item)
		{
			for (int i = 0; i < m_EquipmentHandlers.Length; i++)
			{
				if (item != null && m_EquipmentHandlers[i].ContainsEquipmentItem(item.Id))
				{
					ActiveEHandler = m_EquipmentHandlers[i];
					break;
				}
			}
			if (base.Player.Aim.Active)
			{
				base.Player.Aim.ForceStop();
			}
			if (base.Player.Reload.Active)
			{
				base.Player.Reload.ForceStop();
			}
			ActiveEHandler.EquipItem(item);
			base.Player.ActiveEquipmentItem.Set(ActiveEHandler.EquipmentItem);
			m_FPCamera.fieldOfView = ActiveEHandler.EquipmentItem.EModel.TargetFOV;
		}

		private bool TryUse(bool continuously, int useIndex)
		{
			EquipmentItem equipmentItem = ActiveEHandler.EquipmentItem;
			float staminaTakePerUse = equipmentItem.EInfo.General.StaminaTakePerUse;
			bool flag = equipmentItem.CanBeUsed();
			if (!continuously && base.Player.Reload.Active && equipmentItem.EInfo.General.CanStopReloading && flag)
			{
				base.Player.Reload.ForceStop();
			}
			if (CanUseItem(equipmentItem))
			{
				bool num = ActiveEHandler.TryUse(continuously, useIndex);
				if (num)
				{
					if (staminaTakePerUse > 0f)
					{
						base.Player.Stamina.Set(Mathf.Max(base.Player.Stamina.Get() - staminaTakePerUse, 0f));
					}
					m_NextTimeCanAutoReload = Time.time + 0.35f;
				}
				if (!flag && m_AutoReloadOnEmpty && !continuously && m_NextTimeCanAutoReload < Time.time)
				{
					base.Player.Reload.TryStart();
				}
				return num;
			}
			return false;
		}

		private void OnGroundedChange(bool grounded)
		{
			ActiveEHandler.OnGroundedChange(grounded);
		}

		private bool TryStartAim()
		{
			if (base.Player.Run.Active || base.Player.Reload.Active || (!m_AimWhileReloading && base.Player.Aim.Active))
			{
				return false;
			}
			return ActiveEHandler.TryStartAim();
		}

		private void OnAimStop()
		{
			ActiveEHandler.OnAimStop();
		}

		private bool CanUseItem(EquipmentItem eItem)
		{
			if (eItem != null)
			{
				float staminaTakePerUse = eItem.EInfo.General.StaminaTakePerUse;
				bool num = base.Player.IsGrounded.Get() || eItem.EInfo.General.UseWhileAirborne;
				bool flag = !base.Player.Run.Active || eItem.EInfo.General.UseWhileRunning;
				bool flag2 = staminaTakePerUse == 0f || base.Player.Stamina.Get() > staminaTakePerUse;
				if (num && flag2 && flag)
				{
					return !base.Player.Reload.Active;
				}
				return false;
			}
			return false;
		}

		private bool OnReloadStart()
		{
			if (base.Player.Prone.Active && !m_ReloadWhileProne)
			{
				return false;
			}
			bool num = ActiveEHandler.TryStartReload();
			if (num && base.Player.Aim.Active && !m_AimWhileReloading)
			{
				base.Player.Aim.ForceStop();
			}
			return num;
		}

		private void OnReloadStop()
		{
			ActiveEHandler.OnReloadStop();
		}

		private bool ContainsEquipmentItem(Item item)
		{
			EquipmentHandler[] equipmentHandlers = m_EquipmentHandlers;
			for (int i = 0; i < equipmentHandlers.Length; i++)
			{
				if (equipmentHandlers[i].ContainsEquipmentItem(item.Id))
				{
					return true;
				}
			}
			return false;
		}

		private void OnChanged_ObjectInProximity(Collider col)
		{
			if (ActiveEHandler.EquipmentItem != null && (bool)base.Player.ObjectInProximity.Get() && base.Player.Aim.Active)
			{
				base.Player.Aim.ForceStop();
			}
		}
	}
}
