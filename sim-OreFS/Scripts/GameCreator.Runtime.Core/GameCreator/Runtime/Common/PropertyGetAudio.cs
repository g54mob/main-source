using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetAudio : TPropertyGet<PropertyTypeGetAudio, AudioClip>
	{
		public PropertyGetAudio()
			: base((PropertyTypeGetAudio)new GetAudioClip())
		{
		}

		public PropertyGetAudio(PropertyTypeGetAudio defaultType)
			: base(defaultType)
		{
		}

		public PropertyGetAudio(AudioClip clip)
			: base((PropertyTypeGetAudio)new GetAudioClip(clip))
		{
		}
	}
}
