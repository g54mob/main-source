using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Zero")]
	[Category("Constants/Zero")]
	[Image(typeof(IconZero), ColorTheme.Type.TextNormal)]
	[Description("A Vector3 with a 0 value on all three axis")]
	public class GetDirectionVector3Zero : PropertyTypeGetDirection
	{
		public override string String => "(0,0,0)";

		public override Vector3 EditorValue => Vector3.zero;

		public override Vector3 Get(Args args)
		{
			return Vector3.zero;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return Vector3.zero;
		}

		public static PropertyGetDirection Create()
		{
			return new PropertyGetDirection(new GetDirectionVector3Zero());
		}
	}
}
