using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Right")]
	[Category("Constants/Right")]
	[Image(typeof(IconVector3), ColorTheme.Type.Red, typeof(OverlayArrowRight))]
	[Description("A vector with the constant (1, 0, 0)")]
	public class GetDirectionConstantRight : PropertyTypeGetDirection
	{
		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionConstantRight());

		public override string String => "Right";

		public override Vector3 EditorValue => Vector3.right;

		public override Vector3 Get(Args args)
		{
			return Vector3.right;
		}
	}
}
