using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("-1")]
	[Category("Constant/Minus One")]
	[Image(typeof(IconOne), ColorTheme.Type.TextNormal, typeof(OverlayMinus))]
	[Description("The unit -1 value")]
	public class GetDecimalConstantMinusOne : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalConstantMinusOne());

		public override string String => "-1";

		public override double EditorValue => -1.0;

		public override double Get(Args args)
		{
			return -1.0;
		}

		public override double Get(GameObject gameObject)
		{
			return -1.0;
		}
	}
}
