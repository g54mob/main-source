using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("Don't save on anything")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class SetAudioNone : PropertyTypeSetAudio
	{
		public static PropertySetAudio Create => new PropertySetAudio(new SetAudioNone());

		public override string String => "(none)";

		public override void Set(AudioClip value, Args args)
		{
		}

		public override void Set(AudioClip value, GameObject gameObject)
		{
		}
	}
}
