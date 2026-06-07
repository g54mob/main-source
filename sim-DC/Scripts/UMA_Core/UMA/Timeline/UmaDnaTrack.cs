using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UMA.Timeline
{
	[TrackColor(0.2f, 0.8f, 0.2f)]
	[TrackClipType(typeof(UmaDnaClip))]
	[TrackBindingType(typeof(DynamicCharacterAvatar))]
	public class UmaDnaTrack : TrackAsset
	{
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return default(Playable);
		}
	}
}
