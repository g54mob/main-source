using System;
using System.Collections.Generic;
using UnityEngine;

namespace SE.EvilLib.AudioManager
{
	[Serializable]
	public class AudioClassVoice : AudioClass
	{
		public int type;

		public List<ClipClassVoice> clipClasses;

		public List<AudioClip> GetClipsByLang(string lang)
		{
			return null;
		}
	}
}
