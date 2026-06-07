using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("0")]
	[Category("Constant/Zero")]
	[Image(typeof(IconZero), ColorTheme.Type.TextNormal)]
	[Description("The zero value")]
	public class GetDecimalConstantZero : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalConstantZero());

		public override string String => "0";

		public override double EditorValue => 0.0;

		public override double Get(Args args)
		{
			return 0.0;
		}

		public override double Get(GameObject gameObject)
		{
			return 0.0;
		}
	}
}
