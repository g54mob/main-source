using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Down")]
	[Category("Constants/Down")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green, typeof(OverlayArrowDown))]
	[Description("A vector with the constant (0, -1, 0)")]
	public class GetDirectionConstantDown : PropertyTypeGetDirection
	{
		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionConstantDown());

		public override string String => "Down";

		public override Vector3 EditorValue => Vector3.down;

		public override Vector3 Get(Args args)
		{
			return Vector3.down;
		}
	}
}
