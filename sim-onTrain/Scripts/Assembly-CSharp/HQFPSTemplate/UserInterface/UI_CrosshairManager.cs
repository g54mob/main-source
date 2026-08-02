using HQFPSTemplate.Equipment;
using UnityEngine;

namespace HQFPSTemplate.UserInterface
{
	public class UI_CrosshairManager : UserInterfaceBehaviour
	{
		[BHeader("GENERAL", true)]
		[SerializeField]
		private UI_Crosshair m_Crosshair;

		[SerializeField]
		private UI_CrosshairInfo[] m_CrosshairsInfo;

		[Space]
		[SerializeField]
		private UI_Crosshair m_Hitmarker;

		[SerializeField]
		private UI_CrosshairInfo m_HitmarkerInfo;

		private UI_CrosshairInfo m_CurrentCrosshairInfo;

		public override void OnPostAttachment()
		{
			if (!base.gameObject.activeSelf)
			{
				return;
			}
			m_Hitmarker.EnableCrosshair(enable: false);
			base.Player.UseItem.AddListener(ApplyUsePunch);
			base.Player.Aim.AddStartListener(delegate
			{
				if (!m_CurrentCrosshairInfo.GraphicsInfo.ShowWhenAiming)
				{
					EnableCanvas(enable: false);
				}
			});
			base.Player.Aim.AddStopListener(delegate
			{
				EnableCanvas(enable: true);
			});
			base.Player.Pause.AddStartListener(delegate
			{
				EnableCanvas(enable: false);
			});
			base.Player.Pause.AddStopListener(delegate
			{
				EnableCanvas(enable: true);
			});
			base.Player.ActiveEquipmentItem.AddChangeListener(OnChanged_HeldItem);
		}

		private void FixedUpdate()
		{
			if (m_CurrentCrosshairInfo != null)
			{
				Vector2 stateScale = GetStateScale();
				m_Crosshair.AddSpringForce(stateScale);
				if (m_Hitmarker != null && (bool)m_Hitmarker)
				{
					m_Hitmarker.AddSpringForce(stateScale);
				}
				UpdateCrosshairColor(base.Player.RaycastInfo.Get());
			}
		}

		private Vector2 GetStateScale()
		{
			Vector2 one = Vector2.one;
			if (base.Player.Run.Active && base.Player.Velocity.Val.sqrMagnitude > 0.2f)
			{
				one *= m_CurrentCrosshairInfo.ScaleInfo.RunScale;
			}
			else if (base.Player.Crouch.Active)
			{
				one *= m_CurrentCrosshairInfo.ScaleInfo.CrouchScale;
			}
			else if (base.Player.Prone.Active)
			{
				one *= m_CurrentCrosshairInfo.ScaleInfo.ProneScale;
			}
			else if (base.Player.Walk.Active && base.Player.Velocity.Val.sqrMagnitude > 0.2f)
			{
				one *= m_CurrentCrosshairInfo.ScaleInfo.WalkScale;
			}
			else
			{
				one *= m_CurrentCrosshairInfo.ScaleInfo.IdleScale;
			}
			if (!base.Player.IsGrounded.Get())
			{
				one *= m_CurrentCrosshairInfo.ScaleInfo.AirborneMultiplier;
			}
			if (base.Player.Aim.Active)
			{
				one *= m_CurrentCrosshairInfo.ScaleInfo.AimScaleMultiplier;
			}
			return one * m_CurrentCrosshairInfo.ScaleInfo.ScaleMultiplier;
		}

		private void UpdateCrosshairColor(RaycastInfo raycastInfo)
		{
			EquipmentItem equipmentItem = base.Player.ActiveEquipmentItem.Get();
			if (equipmentItem != null)
			{
				Color color = ((!equipmentItem.CanBeUsed()) ? m_CurrentCrosshairInfo.GraphicsInfo.UnusableColor : ((raycastInfo == null || !(raycastInfo.Collider != null) || !raycastInfo.Collider.GetComponent<Hitbox>()) ? m_CurrentCrosshairInfo.GraphicsInfo.NormalColor : m_CurrentCrosshairInfo.GraphicsInfo.OnEntityColor));
				m_Crosshair.ChangeColor(color);
			}
		}

		private void ApplyUsePunch(bool continuosly, int useType)
		{
			m_Crosshair.AddSpringForce(m_CurrentCrosshairInfo.ScaleInfo.ItemUseScaleForce);
		}

		private void EnableCanvas(bool enable)
		{
			m_Crosshair.EnableCrosshair(enable);
		}

		private void OnChanged_HeldItem(EquipmentItem eItem)
		{
			int num = Mathf.Min(eItem.EInfo.General.CrosshairID, m_CrosshairsInfo.Length - 1);
			if (num != m_Crosshair.CrosshairID)
			{
				m_CurrentCrosshairInfo = m_CrosshairsInfo[num];
				m_Crosshair.UpdateInfo(m_CurrentCrosshairInfo, num);
			}
		}
	}
}
