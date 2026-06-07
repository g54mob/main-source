using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Identity")]
	[Category("Math/Identity")]
	[Image(typeof(IconRotation), ColorTheme.Type.TextNormal)]
	[Description("A rotation that represents no rotation at all")]
	public class GetRotationIdentity : PropertyTypeGetRotation
	{
		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationIdentity());

		public override string String => "Identity";

		public override Quaternion Get(Args args)
		{
			return Quaternion.identity;
		}

		public override Quaternion Get(GameObject gameObject)
		{
			return Quaternion.identity;
		}
	}
}
