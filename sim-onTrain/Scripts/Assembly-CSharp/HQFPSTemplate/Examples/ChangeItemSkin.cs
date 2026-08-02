using HQFPSTemplate.Equipment;
using UnityEngine;

namespace HQFPSTemplate.Examples
{
	public class ChangeItemSkin : MonoBehaviour
	{
		[BHeader("Demo", true)]
		[SerializeField]
		private bool m_EnableChangeItemSkins = true;

		[SerializeField]
		[ShowIf("m_EnableChangeItemSkins", true, 10f)]
		private KeyCode m_ChangeItemSkinKey = KeyCode.U;

		private EquipmentHandler m_EquipmentHandler;

		private void Start()
		{
			m_EquipmentHandler = GetComponentInParent<EquipmentHandler>();
		}

		private void Update()
		{
			if (m_EnableChangeItemSkins && Input.GetKeyDown(m_ChangeItemSkinKey))
			{
				m_EquipmentHandler.EquipmentItem.EModel.UpdateSkin();
			}
		}
	}
}
