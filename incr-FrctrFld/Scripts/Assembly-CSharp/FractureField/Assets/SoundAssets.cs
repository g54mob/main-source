using System;
using UnityEngine;

namespace FractureField.Assets
{
	[Serializable]
	public class SoundAssets
	{
		[SerializeField]
		private AudioClip _gameSoundtrack;

		public static AudioClip GameSoundtrack => null;
	}
}
