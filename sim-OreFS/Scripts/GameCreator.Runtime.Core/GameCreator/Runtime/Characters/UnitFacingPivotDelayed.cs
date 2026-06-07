using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Pivot Delayed")]
	[Image(typeof(IconRotationYaw), ColorTheme.Type.Green, typeof(OverlayDot))]
	[Category("Pivot/Pivot Delayed")]
	[Description("Rotates the Character towards the direction it's moving after a delay")]
	public class UnitFacingPivotDelayed : TUnitFacing
	{
		private enum DirectionFrom
		{
			MotionDirection = 0,
			DriverDirection = 1
		}

		[SerializeField]
		private DirectionFrom m_DirectionFrom;

		[SerializeField]
		[Min(0f)]
		private float m_Delay = 1.75f;

		[SerializeField]
		[Range(0f, 180f)]
		private float m_DelayAngle = 30f;

		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

		[NonSerialized]
		private float m_DirectionChangeTime;

		[NonSerialized]
		private bool m_WasDirectionChanged;

		public override Axonometry Axonometry
		{
			get
			{
				return m_Axonometry;
			}
			set
			{
				m_Axonometry = value;
			}
		}

		protected override Vector3 GetDefaultDirection()
		{
			Vector3 vector = base.Transform.TransformDirection(Vector3.forward);
			Vector3 vector2 = Vector3.Scale(m_DirectionFrom switch
			{
				DirectionFrom.MotionDirection => base.Character.Motion.MoveDirection, 
				DirectionFrom.DriverDirection => base.Character.Driver.WorldMoveDirection, 
				_ => throw new ArgumentOutOfRangeException(), 
			}, Vector3Plane.NormalUp);
			if (vector2.magnitude > base.Character.Motion.LinearSpeed * 0.25f)
			{
				if (!m_WasDirectionChanged)
				{
					m_DirectionChangeTime = base.Character.Time.Time;
				}
				m_WasDirectionChanged = true;
				if (Vector3.Angle(vector, vector2) > m_DelayAngle)
				{
					Vector3 vector3 = DecideDirection((base.Character.Time.Time - m_DirectionChangeTime < m_Delay) ? vector : vector2);
					return m_Axonometry?.ProcessRotation(this, vector3) ?? vector3;
				}
				return m_Axonometry?.ProcessRotation(this, vector2) ?? vector2;
			}
			m_WasDirectionChanged = false;
			return m_Axonometry?.ProcessRotation(this, vector) ?? vector;
		}

		public override string ToString()
		{
			return "Pivot Delayed";
		}
	}
}
