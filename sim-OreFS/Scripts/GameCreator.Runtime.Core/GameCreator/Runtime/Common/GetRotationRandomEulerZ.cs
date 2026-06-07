using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random Euler Z")]
	[Category("Random/Random Euler Z")]
	[Image(typeof(IconDice), ColorTheme.Type.Yellow, typeof(OverlayZ))]
	[Description("Creates a rotation with a random euler Z axis")]
	public class GetRotationRandomEulerZ : PropertyTypeGetRotation
	{
		public override string String => "Random Z";

		public override Quaternion Get(Args args)
		{
			return Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(-360f, 360f));
		}

		public override Quaternion Get(GameObject gameObject)
		{
			return Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(-360f, 360f));
		}
	}
}
