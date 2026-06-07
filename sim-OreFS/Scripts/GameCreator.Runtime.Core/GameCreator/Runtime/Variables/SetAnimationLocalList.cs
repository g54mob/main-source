using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the Animation Clip value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetAnimationLocalList : PropertyTypeSetAnimation
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueAnimClip.TYPE_ID);

		public static PropertySetAnimation Create => new PropertySetAnimation(new SetAnimationLocalList());

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
