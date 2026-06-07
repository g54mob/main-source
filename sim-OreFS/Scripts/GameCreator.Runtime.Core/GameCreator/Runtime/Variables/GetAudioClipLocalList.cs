using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the Audio Clip value of a Local List Variable")]
	public class GetAudioClipLocalList : PropertyTypeGetAudio
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueAudioClip.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override AudioClip Get(Args args)
		{
			return m_Variable.Get<AudioClip>(args);
		}
	}
}
