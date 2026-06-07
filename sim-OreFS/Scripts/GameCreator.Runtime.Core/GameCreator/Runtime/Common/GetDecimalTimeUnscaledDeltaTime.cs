using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Real Delta Time")]
	[Category("Time/Real Delta Time")]
	[Image(typeof(IconTimer), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Description("The amount of seconds elapsed since the completion of the last frame without the time scale")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Frame", "Increment" })]
	public class GetDecimalTimeUnscaledDeltaTime : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalTimeUnscaledDeltaTime());

		public override string String => "Real Delta Time";

		public override double Get(Args args)
		{
			return Time.unscaledDeltaTime;
		}

		public override double Get(GameObject gameObject)
		{
			return Time.unscaledDeltaTime;
		}
	}
}
