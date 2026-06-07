using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random Unit")]
	[Category("Random/Random Unit")]
	[Image(typeof(IconDice), ColorTheme.Type.TextNormal)]
	[Description("A random decimal number between zero and one (range is inclusive)")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalRandomUnit : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalRandomUnit());

		public override string String => "Random Unit";

		public override double Get(Args args)
		{
			return UnityEngine.Random.value;
		}
	}
}
