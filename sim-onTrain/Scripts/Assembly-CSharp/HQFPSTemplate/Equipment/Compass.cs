using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class Compass : EquipmentItem
	{
		[Serializable]
		private class CompassSettings
		{
			public Transform CompassRose;
		}

		[SerializeField]
		[Group]
		private CompassSettings m_CompassSettings;

		private CompassInfo m_CompassInfo;

		private Vector3 m_CurrentRoseRotation;

		private Vector3 m_NorthDirection;

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_CompassInfo = base.EInfo as CompassInfo;
			if (Singleton<WorldManager>.Instance != null)
			{
				m_NorthDirection = Singleton<WorldManager>.Instance.NorthDirection;
			}
			else
			{
				m_NorthDirection = Vector3.forward;
			}
		}

		private void LateUpdate()
		{
			float num = 0f - Vector3.SignedAngle(base.Player.transform.forward, m_NorthDirection, Vector3.up);
			m_CurrentRoseRotation = Vector3.Scale(new Vector3(num, num, num), m_CompassInfo.CompassSettings.CompassRoseRotationAxis.normalized);
			m_CompassSettings.CompassRose.localRotation = Quaternion.Euler(m_CompassSettings.CompassRose.localEulerAngles + m_CurrentRoseRotation);
		}
	}
}
