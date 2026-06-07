using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Moon Gravity")]
	[Category("Physics/Moon Gravity")]
	[Image(typeof(IconApple), ColorTheme.Type.Blue)]
	[Description("The gravity on the Moon in units per second square")]
	public class GetDecimalPhysicsGravityMoon : PropertyTypeGetDecimal
	{
		private const float GRAVITY = 1.62f;

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalPhysicsGravityMoon());

		public override double EditorValue => 1.6200000047683716;

		public override string String => "Moon Gravity";

		public override double Get(Args args)
		{
			return 1.6200000047683716;
		}

		public override double Get(GameObject gameObject)
		{
			return 1.6200000047683716;
		}
	}
}
