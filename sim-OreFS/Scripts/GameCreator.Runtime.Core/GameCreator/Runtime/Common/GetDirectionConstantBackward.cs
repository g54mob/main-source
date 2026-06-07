using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Backward")]
	[Category("Constants/Backward")]
	[Image(typeof(IconVector3), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Description("A vector with the constant (0, 0, -1)")]
	public class GetDirectionConstantBackward : PropertyTypeGetDirection
	{
		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionConstantBackward());

		public override string String => "Backward";

		public override Vector3 EditorValue => Vector3.back;

		public override Vector3 Get(Args args)
		{
			return Vector3.back;
		}
	}
}
