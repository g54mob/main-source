using System;
using HQFPSTemplate.Equipment;
using UnityEngine;

namespace HQFPSTemplate.Examples
{
	public class EquipmentInstance : ScriptableObject
	{
		[Serializable]
		public class EquipmentInfo
		{
			public bool useCustomCategory;

			public string equipmentName;

			[DatabaseCategory]
			public string itemCategory;

			public Player player;

			public EquipmentItem baseEquipmentItem;

			public string equipmentHandlerName;

			[Range(10f, 120f)]
			public int itemFOV = 50;

			public UseConditions useConditions;
		}

		[Serializable]
		public struct UseConditions
		{
			[BHeader("Use Settings", order = 2)]
			public bool UseWhileAirborne;

			public bool UseWhileRunning;

			public bool CanStopReloading;
		}

		[HideInInspector]
		public EquipmentInfo m_EquipmentInfo;

		public void ClearInfo()
		{
			m_EquipmentInfo.equipmentName = "";
			m_EquipmentInfo.itemCategory = "";
			m_EquipmentInfo.player = null;
			m_EquipmentInfo.baseEquipmentItem = null;
			m_EquipmentInfo.itemFOV = 50;
		}

		public int GetNumberOfDefinedFields()
		{
			int num = 0;
			if (!string.IsNullOrEmpty(m_EquipmentInfo.equipmentName))
			{
				num++;
			}
			if (!string.IsNullOrEmpty(m_EquipmentInfo.itemCategory))
			{
				num++;
			}
			if (m_EquipmentInfo.player != null)
			{
				num++;
			}
			if (m_EquipmentInfo.baseEquipmentItem != null)
			{
				num++;
			}
			if (m_EquipmentInfo.itemFOV >= 10)
			{
				num++;
			}
			return num;
		}
	}
}
