using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the Animation Clip value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetAnimationGlobalName : PropertyTypeSetAnimation
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueAnimClip.TYPE_ID);

		public static PropertySetAnimation Create => new PropertySetAnimation(new SetAnimationGlobalName());

		public override string String => m_Variable.ToString();

		public override void Set(AnimationClip value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override AnimationClip Get(Args args)
		{
			return m_Variable.Get(args) as AnimationClip;
		}
	}
}
