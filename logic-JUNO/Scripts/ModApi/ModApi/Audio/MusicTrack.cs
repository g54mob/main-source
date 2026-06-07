using System;
using UnityEngine;

namespace ModApi.Audio
{
	[Serializable]
	public class MusicTrack
	{
		[SerializeField]
		private string _primaryAudioClipName;

		[SerializeField]
		private string _secondaryAudioClipName;

		public string PrimaryAudioClipName => _primaryAudioClipName;

		public string SecondaryAudioClipName => _secondaryAudioClipName;

		public MusicTrack(string primaryAudioClipName, string secondaryAudioClipName)
		{
			_primaryAudioClipName = primaryAudioClipName;
			_secondaryAudioClipName = secondaryAudioClipName;
		}
	}
}
