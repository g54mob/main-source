using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random")]
	[Category("Random/Random")]
	[Image(typeof(IconDice), ColorTheme.Type.Red)]
	[Description("Randomly returns true or false with equal probability")]
	[Keywords(new string[] { "Dice", "Any" })]
	public class GetBoolRandom : PropertyTypeGetBool
	{
		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolRandom());

		public override string String => "Random";

		public override bool Get(Args args)
		{
			return UnityEngine.Random.Range(0, 2) == 0;
		}

		public override bool Get(GameObject gameObject)
		{
			return UnityEngine.Random.Range(0, 2) == 0;
		}
	}
}
