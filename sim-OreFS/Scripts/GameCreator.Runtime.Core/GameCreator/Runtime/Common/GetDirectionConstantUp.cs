using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Up")]
	[Category("Constants/Up")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green, typeof(OverlayArrowUp))]
	[Description("A vector with the constant (0, 1, 0)")]
	public class GetDirectionConstantUp : PropertyTypeGetDirection
	{
		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionConstantUp());

		public override string String => "Up";

		public override Vector3 EditorValue => Vector3.up;

		public override Vector3 Get(Args args)
		{
			return Vector3.up;
		}
	}
}
