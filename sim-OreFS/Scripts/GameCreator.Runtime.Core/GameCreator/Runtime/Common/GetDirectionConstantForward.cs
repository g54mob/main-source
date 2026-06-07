using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Forward")]
	[Category("Constants/Forward")]
	[Image(typeof(IconVector3), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Description("A vector with the constant (0, 0, 1)")]
	public class GetDirectionConstantForward : PropertyTypeGetDirection
	{
		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionConstantForward());

		public override string String => "Forward";

		public override Vector3 EditorValue => Vector3.forward;

		public override Vector3 Get(Args args)
		{
			return Vector3.forward;
		}
	}
}
