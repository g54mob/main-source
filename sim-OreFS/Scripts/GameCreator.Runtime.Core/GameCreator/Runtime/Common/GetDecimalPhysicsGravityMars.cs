using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mars Gravity")]
	[Category("Physics/Mars Gravity")]
	[Image(typeof(IconApple), ColorTheme.Type.Red)]
	[Description("The gravity on Mars in units per second square")]
	public class GetDecimalPhysicsGravityMars : PropertyTypeGetDecimal
	{
		private const float GRAVITY = 3.71f;

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalPhysicsGravityMars());

		public override double EditorValue => 3.7100000381469727;

		public override string String => "Mars Gravity";

		public override double Get(Args args)
		{
			return 3.7100000381469727;
		}

		public override double Get(GameObject gameObject)
		{
			return 3.7100000381469727;
		}
	}
}
