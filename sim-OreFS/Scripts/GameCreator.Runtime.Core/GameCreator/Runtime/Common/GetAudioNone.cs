using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("Returns a null Audio Clip ")]
	[HideLabelsInEditor(true)]
	public class GetAudioNone : PropertyTypeGetAudio
	{
		public static PropertyGetAudio Create => new PropertyGetAudio(new GetAudioNone());

		public override string String => "None";

		public override AudioClip Get(Args args)
		{
			return null;
		}

		public override AudioClip Get(GameObject gameObject)
		{
			return null;
		}
	}
}
