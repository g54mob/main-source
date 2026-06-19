using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TH20.Timeline
{
	[TrackColor(0.353f, 0.932f, 0.325f)]
	[TrackClipType(typeof(EventClip))]
	[TrackBindingType(typeof(EventBehaviour))]
	public class EventTrack : TrackAsset
	{
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			foreach (TimelineClip clip in GetClips())
			{
				EventClip eventClip = (EventClip)clip.asset;
				clip.displayName = eventClip.EventName;
			}
			return ScriptPlayable<EventMixer>.Create(graph, inputCount);
		}
	}
}
