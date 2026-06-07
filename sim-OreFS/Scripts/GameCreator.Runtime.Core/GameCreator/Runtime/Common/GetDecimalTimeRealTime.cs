using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Real Time")]
	[Category("Time/Real Time")]
	[Image(typeof(IconTimer), ColorTheme.Type.Yellow, typeof(OverlayDot))]
	[Description("The unscaled amount of seconds since the application started running")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Elapsed", "Unscaled" })]
	public class GetDecimalTimeRealTime : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalTimeRealTime());

		public override string String => "Real Time";

		public override double Get(Args args)
		{
			return Time.unscaledTime;
		}

		public override double Get(GameObject gameObject)
		{
			return Time.unscaledTime;
		}
	}
}
