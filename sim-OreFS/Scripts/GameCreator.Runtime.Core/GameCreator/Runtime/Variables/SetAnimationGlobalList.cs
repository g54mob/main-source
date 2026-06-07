using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the Animation Clip value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetAnimationGlobalList : PropertyTypeSetAnimation
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueAnimClip.TYPE_ID);

		public static PropertySetAnimation Create => new PropertySetAnimation(new SetAnimationGlobalList());

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
