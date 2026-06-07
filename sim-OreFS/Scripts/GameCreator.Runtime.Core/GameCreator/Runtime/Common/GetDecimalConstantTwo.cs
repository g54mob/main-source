using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("2")]
	[Category("Constant/Two")]
	[Image(typeof(IconTwo), ColorTheme.Type.TextNormal)]
	[Description("The unit 2 value")]
	public class GetDecimalConstantTwo : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalConstantTwo());

		public override string String => "2";

		public override double EditorValue => 2.0;

		public override double Get(Args args)
		{
			return 2.0;
		}

		public override double Get(GameObject gameObject)
		{
			return 2.0;
		}
	}
}
