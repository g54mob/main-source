using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the Animation Clip value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetAnimationLocalName : PropertyTypeSetAnimation
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueAnimClip.TYPE_ID);

		public static PropertySetAnimation Create => new PropertySetAnimation(new SetAnimationLocalName());

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
