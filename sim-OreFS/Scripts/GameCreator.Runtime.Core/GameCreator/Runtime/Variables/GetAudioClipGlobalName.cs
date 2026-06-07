using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the Audio Clip value of a Global Name Variable")]
	public class GetAudioClipGlobalName : PropertyTypeGetAudio
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueAudioClip.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override AudioClip Get(Args args)
		{
			return m_Variable.Get<AudioClip>(args);
		}
	}
}
