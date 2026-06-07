using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UMA.Timeline
{
	[TrackColor(0.2f, 0.4f, 0.2f)]
	[TrackClipType(typeof(UmaColorClip))]
	[TrackBindingType(typeof(DynamicCharacterAvatar))]
	public class UmaColorTrack : TrackAsset
	{
		[Tooltip("Time between rebuilding the UMA texture so we aren't rebuilding it every frame")]
		public float timeStep;

		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return default(Playable);
		}
	}
}
