using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public static class AudioLoaderOptimizer
	{
		private static readonly Dictionary<string, List<GameObject>> PlayingGameObjectsByClipName;

		public static void AddNonPreloadedPlayingClip(AudioClip clip, GameObject maHolderGameObject)
		{
		}

		public static void RemoveNonPreloadedPlayingClip(AudioClip clip, GameObject maHolderGameObject)
		{
		}

		public static bool IsAnyOfNonPreloadedClipPlaying(AudioClip clip)
		{
			return false;
		}
	}
}
