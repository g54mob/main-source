using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("Don't save on anything")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class SetAnimationNone : PropertyTypeSetAnimation
	{
		public static PropertySetAnimation Create => new PropertySetAnimation(new SetAnimationNone());

		public override string String => "(none)";

		public override void Set(AnimationClip value, Args args)
		{
		}

		public override void Set(AnimationClip value, GameObject gameObject)
		{
		}
	}
}
