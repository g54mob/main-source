using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random Euler Y")]
	[Category("Random/Random Euler Y")]
	[Image(typeof(IconDice), ColorTheme.Type.Yellow, typeof(OverlayY))]
	[Description("Creates a rotation with a random euler Y axis")]
	public class GetRotationRandomEulerY : PropertyTypeGetRotation
	{
		public override string String => "Random Y";

		public override Quaternion Get(Args args)
		{
			return Quaternion.Euler(Vector3.up * UnityEngine.Random.Range(-360f, 360f));
		}

		public override Quaternion Get(GameObject gameObject)
		{
			return Quaternion.Euler(Vector3.up * UnityEngine.Random.Range(-360f, 360f));
		}
	}
}
