using System.Collections.Generic;
using UnityEngine;

namespace Radio
{
	public static class RadioTrackQueue
	{
		public static RadioTrack PickNext(RadioChannel channel, int tracksSinceLastAd, RadioConditionProcessor conditions, out bool wasAd)
		{
			wasAd = false;
			RadioTrack radioTrack = TryPickSpecial(channel, conditions);
			if (radioTrack != null)
			{
				return radioTrack;
			}
			bool num = channel.adTracks != null && channel.adTracks.Length != 0;
			bool flag = channel.playAdFirst && tracksSinceLastAd == -1;
			bool flag2 = tracksSinceLastAd > 0 && tracksSinceLastAd >= channel.adEveryNTracks;
			if (num && (flag2 || flag))
			{
				wasAd = true;
				return PickWeighted(channel.adTracks);
			}
			if (channel.musicTracks == null || channel.musicTracks.Length == 0)
			{
				return null;
			}
			return PickWeighted(channel.musicTracks);
		}

		private static RadioTrack TryPickSpecial(RadioChannel channel, RadioConditionProcessor conditions)
		{
			if (channel.specialTracks == null || channel.specialTracks.Length == 0)
			{
				return null;
			}
			List<RadioTrack> list = new List<RadioTrack>();
			RadioTrack[] specialTracks = channel.specialTracks;
			foreach (RadioTrack radioTrack in specialTracks)
			{
				if (radioTrack.requiredConditions != RadioCondition.None && conditions.IsAnyActive(radioTrack.requiredConditions))
				{
					list.Add(radioTrack);
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return PickWeighted(list);
		}

		private static RadioTrack PickWeighted(IList<RadioTrack> tracks)
		{
			float num = 0f;
			foreach (RadioTrack track in tracks)
			{
				num += track.weight;
			}
			float num2 = Random.Range(0f, num);
			float num3 = 0f;
			foreach (RadioTrack track2 in tracks)
			{
				num3 += track2.weight;
				if (num2 <= num3)
				{
					return track2;
				}
			}
			return tracks[tracks.Count - 1];
		}
	}
}
