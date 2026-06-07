using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("0.1")]
	[Category("Constant/Point One")]
	[Image(typeof(IconPointOne), ColorTheme.Type.TextNormal)]
	[Description("The unit 0.1 value")]
	public class GetDecimalConstantPointOne : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalConstantPointOne());

		public override string String => "0.1";

		public override double EditorValue => 0.1;

		public override double Get(Args args)
		{
			return 0.1;
		}

		public override double Get(GameObject gameObject)
		{
			return 0.1;
		}
	}
}
