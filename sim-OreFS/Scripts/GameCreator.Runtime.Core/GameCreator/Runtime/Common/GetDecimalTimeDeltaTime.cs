using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Delta Time")]
	[Category("Time/Delta Time")]
	[Image(typeof(IconTimer), ColorTheme.Type.Blue)]
	[Description("The amount of seconds elapsed since the completion of the last frame")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Frame", "Increment" })]
	public class GetDecimalTimeDeltaTime : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalTimeDeltaTime());

		public override string String => "Delta Time";

		public override double Get(Args args)
		{
			return Time.deltaTime;
		}

		public override double Get(GameObject gameObject)
		{
			return Time.deltaTime;
		}
	}
}
