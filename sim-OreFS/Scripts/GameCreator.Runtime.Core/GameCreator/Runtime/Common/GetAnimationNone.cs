using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("Returns a null Animation Clip ")]
	public class GetAnimationNone : PropertyTypeGetAnimation
	{
		public static PropertyGetAnimation Create => new PropertyGetAnimation(new GetAnimationNone());

		public override string String => "None";

		public override AnimationClip Get(Args args)
		{
			return null;
		}

		public override AnimationClip Get(GameObject gameObject)
		{
			return null;
		}
	}
}
