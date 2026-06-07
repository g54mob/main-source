using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Earth Gravity")]
	[Category("Physics/Earth Gravity")]
	[Image(typeof(IconApple), ColorTheme.Type.Green)]
	[Description("The gravity in planet Earth in units per second square")]
	public class GetDecimalPhysicsGravityEarth : PropertyTypeGetDecimal
	{
		private const float GRAVITY = 9.81f;

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalPhysicsGravityEarth());

		public override double EditorValue => 9.8100004196167;

		public override string String => "Gravity";

		public override double Get(Args args)
		{
			return 9.8100004196167;
		}

		public override double Get(GameObject gameObject)
		{
			return 9.8100004196167;
		}
	}
}
