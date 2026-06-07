using System.Collections.Generic;
using UnityEngine;

namespace SE.EvilLib.AudioManager
{
	public static class AudioPooler
	{
		private static AudioManager aManager;

		private static Dictionary<int, List<AudioSource>> dictPooled;

		private static Dictionary<int, AudioSource> dictActive;

		private static Dictionary<int, int> dictLookup;

		private static Transform trContainer;

		public static void Init(AudioManager manager)
		{
		}

		private static void CreateExpandPool(AudioSource source, int amount = -1)
		{
		}

		public static AudioSource GetSource(AudioSource templateSource)
		{
			return null;
		}

		public static void RemoveSource(AudioSource source)
		{
		}
	}
}
