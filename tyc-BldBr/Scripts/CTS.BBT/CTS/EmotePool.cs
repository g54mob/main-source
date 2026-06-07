using System.Collections.Generic;
using CTS.Emotes;
using UnityEngine;

namespace CTS
{
	public static class EmotePool
	{
		private static readonly HashSet<EmoteBBT> _bbtEmotes = new HashSet<EmoteBBT>();

		[RuntimeInitializeOnLoadMethod]
		private static void Clear()
		{
			_bbtEmotes.Clear();
		}

		public static EmoteBBT GetEmoteBBT()
		{
			foreach (EmoteBBT bbtEmote in _bbtEmotes)
			{
				if (!bbtEmote.IsPlaying)
				{
					_bbtEmotes.Remove(bbtEmote);
					return bbtEmote;
				}
			}
			return new EmoteBBT();
		}

		public static void PushEmote(EmoteBBT emote)
		{
			_bbtEmotes.Add(emote);
		}
	}
}
