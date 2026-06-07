using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Left")]
	[Category("Constants/Left")]
	[Image(typeof(IconVector3), ColorTheme.Type.Red, typeof(OverlayArrowLeft))]
	[Description("A vector with the constant (-1, 0, 0)")]
	public class GetDirectionConstantLeft : PropertyTypeGetDirection
	{
		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionConstantLeft());

		public override string String => "Left";

		public override Vector3 EditorValue => Vector3.left;

		public override Vector3 Get(Args args)
		{
			return Vector3.left;
		}
	}
}
