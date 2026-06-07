using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Tantawowa.TimelineEvents
{
	[TrackColor(0.4448276f, 0f, 1f)]
	[TrackClipType(typeof(TimelineEventClip))]
	[TrackBindingType(typeof(GameObject))]
	public class TimelineEventTrack : TrackAsset
	{
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return default(Playable);
		}
	}
}
