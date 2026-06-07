using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Time Scale")]
	[Category("Time/Time Scale")]
	[Image(typeof(IconTimer), ColorTheme.Type.Green)]
	[Description("The scale at which time passes")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Slow", "Fast", "Pause", "Freeze" })]
	public class GetDecimalTimeScale : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalTimeScale());

		public override string String => "Time Scale";

		public override double Get(Args args)
		{
			return Time.timeScale;
		}

		public override double Get(GameObject gameObject)
		{
			return Time.timeScale;
		}
	}
}
