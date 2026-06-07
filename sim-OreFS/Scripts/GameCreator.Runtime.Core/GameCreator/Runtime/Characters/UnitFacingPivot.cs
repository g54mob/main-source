using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Pivot")]
	[Image(typeof(IconRotationYaw), ColorTheme.Type.Green)]
	[Category("Pivot/Pivot")]
	[Description("Rotates the Character towards the direction it moves")]
	public class UnitFacingPivot : TUnitFacing
	{
		private enum DirectionFrom
		{
			MotionDirection = 0,
			DriverDirection = 1
		}

		[SerializeField]
		private DirectionFrom m_DirectionFrom;

		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

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
			Vector3 driverDirection = Vector3.Scale(m_DirectionFrom switch
			{
				DirectionFrom.MotionDirection => base.Character.Motion.MoveDirection, 
				DirectionFrom.DriverDirection => base.Character.Driver.WorldMoveDirection, 
				_ => throw new ArgumentOutOfRangeException(), 
			}, Vector3Plane.NormalUp);
			Vector3 vector = DecideDirection(driverDirection);
			return m_Axonometry?.ProcessRotation(this, vector) ?? vector;
		}

		public override string ToString()
		{
			return "Pivot";
		}
	}
}
