using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Vector Zero")]
	[Category("Constants/Vector Zero")]
	[Image(typeof(IconZero), ColorTheme.Type.Yellow)]
	[Description("Returns zeroed Vector3 position")]
	public class GetPositionVectorZero : PropertyTypeGetPosition
	{
		public override string String => "Zero";

		public override Vector3 EditorValue => Vector3.zero;

		public override Vector3 Get(Args args)
		{
			return Vector3.zero;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return Vector3.zero;
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionVectorZero());
		}
	}
}
