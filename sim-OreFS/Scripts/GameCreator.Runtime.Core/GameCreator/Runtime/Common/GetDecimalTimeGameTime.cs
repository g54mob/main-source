using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Time")]
	[Category("Time/Game Time")]
	[Image(typeof(IconTimer), ColorTheme.Type.Yellow)]
	[Description("The internal amount of seconds since the application started running")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Elapsed" })]
	public class GetDecimalTimeGameTime : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalTimeGameTime());

		public override string String => "Game Time";

		public override double Get(Args args)
		{
			return Time.time;
		}

		public override double Get(GameObject gameObject)
		{
			return Time.time;
		}
	}
}
