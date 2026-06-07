using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the Audio Clip value of a Local Name Variable")]
	public class GetAudioClipLocalName : PropertyTypeGetAudio
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueAudioClip.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override AudioClip Get(Args args)
		{
			return m_Variable.Get<AudioClip>(args);
		}
	}
}
