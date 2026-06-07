using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the Animation Clip value of a Global Name Variable")]
	public class GetAnimationGlobalName : PropertyTypeGetAnimation
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueAnimClip.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override AnimationClip Get(Args args)
		{
			return m_Variable.Get<AnimationClip>(args);
		}
	}
}
