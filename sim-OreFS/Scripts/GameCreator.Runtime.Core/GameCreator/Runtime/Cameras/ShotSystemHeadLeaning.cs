using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemHeadLeaning : TShotSystem
	{
		public static readonly int ID = "ShotSystemHeadLeaning".GetHashCode();

		[SerializeField]
		private bool m_IsActive = true;

		[SerializeField]
		private float m_SmoothTime = 0.2f;

		[SerializeField]
		private PropertyGetDecimal m_AngleForward = GetDecimalDecimal.Create(5f);

		[SerializeField]
		private PropertyGetDecimal m_AngleSideways = GetDecimalDecimal.Create(2f);

		private Quaternion m_LeaningCurrent;

		private Quaternion m_LeaningVelocity;

		public override int Id => ID;

		public bool IsActive
		{
			get
			{
				return m_IsActive;
			}
			set
			{
				m_IsActive = value;
			}
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			Quaternion target = Quaternion.identity;
			if (m_IsActive)
			{
				if (!(shotType is ShotTypeFirstPerson { Character: var character }))
				{
					return;
				}
				if (character != null)
				{
					Vector3 vector = Vector3.ClampMagnitude((character.Motion.LinearSpeed > 0f) ? (character.Driver.LocalMoveDirection / character.Motion.LinearSpeed) : Vector3.zero, 1f);
					float num = (float)m_AngleForward.Get(shotType.Args);
					float num2 = (float)m_AngleSideways.Get(shotType.Args);
					target = Quaternion.Euler(vector.z * num, 0f, vector.x * num2 * -1f);
				}
			}
			m_LeaningCurrent = QuaternionUtils.SmoothDamp(m_LeaningCurrent, target, ref m_LeaningVelocity, m_SmoothTime, shotType.ShotCamera.TimeMode.DeltaTime);
			shotType.Rotation *= m_LeaningCurrent;
		}
	}
}
