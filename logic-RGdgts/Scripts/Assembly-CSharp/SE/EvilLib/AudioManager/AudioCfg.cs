using System.Collections.Generic;
using SE.EvilLib.Core;
using UnityEngine;

namespace SE.EvilLib.AudioManager
{
	[CreateAssetMenu]
	public class AudioCfg : ScriptableObject
	{
		[Separator]
		public List<IntString> musicTypeList;

		public List<IntString> sfxTypeList;

		public List<IntString> voiceTypeList;

		public List<IntString> customTemplates;

		[Separator]
		public List<AudioClassMusic> musics;

		[Separator]
		public List<AudioClassSfx> sfxs;

		[Separator]
		public List<AudioClassVoice> voices;

		public AudioClassMusic GetAudioClassMusic(int type)
		{
			return null;
		}

		public AudioClassSfx GetAudioClassSfx(int type)
		{
			return null;
		}

		public AudioClassVoice GetAudioClassVoice(int type)
		{
			return null;
		}

		public string GetAudioName(int type, AudioCategory category)
		{
			return null;
		}

		public List<IntString> GetTypeList(AudioCategory category)
		{
			return null;
		}

		public List<string> GetNameList(AudioCategory category)
		{
			return null;
		}
	}
}
