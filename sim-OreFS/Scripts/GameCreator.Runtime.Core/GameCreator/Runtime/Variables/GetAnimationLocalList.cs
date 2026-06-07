using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the Animation Clip value of a Local List Variable")]
	public class GetAnimationLocalList : PropertyTypeGetAnimation
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueAnimClip.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override AnimationClip Get(Args args)
		{
			return m_Variable.Get<AnimationClip>(args);
		}
	}
}
