using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the Audio Clip value of a Global List Variable")]
	public class GetAudioClipGlobalList : PropertyTypeGetAudio
	{
		[SerializeField]
		protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueAudioClip.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override AudioClip Get(Args args)
		{
			return m_Variable.Get<AudioClip>(args);
		}
	}
}
