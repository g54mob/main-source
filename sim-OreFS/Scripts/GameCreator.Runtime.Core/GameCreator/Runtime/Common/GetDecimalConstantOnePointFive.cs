using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("1.5")]
	[Category("Constant/One point Five")]
	[Image(typeof(IconOnePointFive), ColorTheme.Type.TextNormal)]
	[Description("The unit 1.5 value")]
	public class GetDecimalConstantOnePointFive : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalConstantOnePointFive());

		public override string String => "1.5";

		public override double EditorValue => 1.5;

		public override double Get(Args args)
		{
			return 1.5;
		}

		public override double Get(GameObject gameObject)
		{
			return 1.5;
		}
	}
}
