using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("1")]
	[Category("Constant/One")]
	[Image(typeof(IconOne), ColorTheme.Type.TextNormal)]
	[Description("The unit 1 value")]
	public class GetDecimalConstantOne : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalConstantOne());

		public override string String => "1";

		public override double EditorValue => 1.0;

		public override double Get(Args args)
		{
			return 1.0;
		}

		public override double Get(GameObject gameObject)
		{
			return 1.0;
		}
	}
}
