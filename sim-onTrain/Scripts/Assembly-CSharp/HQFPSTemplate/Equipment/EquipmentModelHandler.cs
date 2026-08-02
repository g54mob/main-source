using System;
using System.Collections.Generic;
using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[Serializable]
	public class EquipmentModelHandler
	{
		[SerializeField]
		private Renderer m_EquipmentModel;

		[SerializeField]
		private EquipmentModelInfo m_FPModelSettings;

		private ItemProperty m_AttachedSkinProperty;

		private int m_CurrentSkinIndex;

		public float TargetFOV => m_FPModelSettings.TargetFOV;

		private bool HasSkins
		{
			get
			{
				if ((bool)m_FPModelSettings && (bool)m_EquipmentModel)
				{
					return m_FPModelSettings.HasSkins;
				}
				return false;
			}
		}

		public void UpdateSkinIDProperty(Item item)
		{
			if (HasSkins && item.TryGetProperty(m_FPModelSettings.SkinIDProperty, out var itemProperty))
			{
				if (m_AttachedSkinProperty != itemProperty)
				{
					m_AttachedSkinProperty = itemProperty;
				}
				m_CurrentSkinIndex = Mathf.Clamp(m_AttachedSkinProperty.Integer, 0, m_FPModelSettings.Skins.Count - 1);
				UpdateItemRenderer(m_FPModelSettings.Skins[m_CurrentSkinIndex]);
			}
		}

		public void UpdateMaterialsFov()
		{
			if (m_FPModelSettings != null && m_EquipmentModel != null)
			{
				UpdateMaterialsFOV(m_FPModelSettings.TargetFOV);
			}
		}

		public void UpdateMaterialsFOV(float fov)
		{
			if (!(m_FPModelSettings != null) || !(m_EquipmentModel != null))
			{
				return;
			}
			Material[] sharedMaterials;
			if (m_FPModelSettings.HasSkins)
			{
				List<Material> list = new List<Material>();
				foreach (EquipmentSkin skin in m_FPModelSettings.Skins)
				{
					sharedMaterials = skin.SharedMaterials;
					foreach (Material item in sharedMaterials)
					{
						if (!list.Contains(item))
						{
							list.Add(item);
						}
					}
				}
				{
					foreach (Material item2 in list)
					{
						item2.SetFloat(m_FPModelSettings.FovProperty, fov);
					}
					return;
				}
			}
			sharedMaterials = m_EquipmentModel.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				sharedMaterials[i].SetFloat(m_FPModelSettings.FovProperty, fov);
			}
		}

		public float GetMaterialFOV()
		{
			if (m_FPModelSettings != null && m_EquipmentModel != null)
			{
				return m_EquipmentModel.sharedMaterial.GetFloat(m_FPModelSettings.FovProperty);
			}
			return 0f;
		}

		public void UpdateSkin()
		{
			if (HasSkins)
			{
				EquipmentSkin equipmentSkin = m_FPModelSettings.Skins.ToArray().Select(ref m_CurrentSkinIndex, ItemSelection.Method.Sequence);
				if (m_AttachedSkinProperty != null)
				{
					m_AttachedSkinProperty.Integer = m_FPModelSettings.Skins.IndexOf(equipmentSkin);
				}
				UpdateItemRenderer(equipmentSkin);
			}
		}

		private void UpdateItemRenderer(EquipmentSkin skin)
		{
			MeshFilter component = m_EquipmentModel.GetComponent<MeshFilter>();
			if (component != null)
			{
				component.sharedMesh = skin.SharedMesh;
				m_EquipmentModel.sharedMaterials = skin.SharedMaterials;
			}
		}
	}
}
