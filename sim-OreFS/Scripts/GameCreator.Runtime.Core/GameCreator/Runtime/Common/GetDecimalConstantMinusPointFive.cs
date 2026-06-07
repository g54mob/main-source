using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("-0.5")]
	[Category("Constant/Minus Point Five")]
	[Image(typeof(IconPointFive), ColorTheme.Type.TextNormal, typeof(OverlayMinus))]
	[Description("The unit -0.5 value")]
	public class GetDecimalConstantMinusPointFive : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalConstantMinusPointFive());

		public override string String => "-0.5";

		public override double EditorValue => -0.5;

		public override double Get(Args args)
		{
			return -0.5;
		}

		public override double Get(GameObject gameObject)
		{
			return -0.5;
		}
	}
}
