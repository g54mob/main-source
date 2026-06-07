using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random Euler X")]
	[Category("Random/Random Euler X")]
	[Image(typeof(IconDice), ColorTheme.Type.Yellow, typeof(OverlayX))]
	[Description("Creates a rotation with a random euler X axis")]
	public class GetRotationRandomEulerX : PropertyTypeGetRotation
	{
		public override string String => "Random X";

		public override Quaternion Get(Args args)
		{
			return Quaternion.Euler(Vector3.right * UnityEngine.Random.Range(-360f, 360f));
		}

		public override Quaternion Get(GameObject gameObject)
		{
			return Quaternion.Euler(Vector3.right * UnityEngine.Random.Range(-360f, 360f));
		}
	}
}
