using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class EquipmentFixer : MonoBehaviour
	{
		[HideInInspector]
		public List<EquipmentItem> m_EquipmentItems = new List<EquipmentItem>();
	}
}
