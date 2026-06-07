using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Towards Direction")]
	[Image(typeof(IconArrowCircleRight), ColorTheme.Type.Yellow)]
	[Category("Direction/Towards Direction")]
	[Description("Rotates the Character towards a specific world-space direction")]
	public class UnitFacingDirection : TUnitFacing
	{
		[SerializeField]
		private PropertyGetRotation m_Direction = GetRotationTowardsDirection.CreateForward;

		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

		[NonSerialized]
		private Args args;

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
			if (args == null)
			{
				args = new Args(base.Character);
			}
			Vector3 driverDirection = Vector3.Scale(m_Direction.Get(args) * Vector3.forward, Vector3Plane.NormalUp);
			Vector3 vector = DecideDirection(driverDirection);
			return m_Axonometry?.ProcessRotation(this, vector) ?? vector;
		}

		public override string ToString()
		{
			return "Towards Direction";
		}
	}
}
