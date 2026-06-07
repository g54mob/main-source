using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Tank")]
	[Image(typeof(IconTank), ColorTheme.Type.Green)]
	[Category("Tank")]
	[Description("Moves the Player using a directional input from the Player's perspective")]
	public class UnitPlayerTank : UnitPlayerDirectional
	{
		public override Type ForceFacing => typeof(UnitFacingTank);

		protected override Vector3 GetMoveDirection(Vector3 input)
		{
			Vector3 direction = new Vector3(0f, 0f, input.y);
			Vector3 vector = base.Transform.TransformDirection(direction);
			vector.Scale(Vector3Plane.NormalUp);
			vector.Normalize();
			return vector * direction.magnitude;
		}

		public override string ToString()
		{
			return "Tank";
		}
	}
}
