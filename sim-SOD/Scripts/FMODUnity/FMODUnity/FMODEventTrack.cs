using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace FMODUnity
{
	[TrackColor(0.066f, 0.134f, 0.244f)]
	[DisplayName("FMOD/Event Track")]
	[TrackBindingType(typeof(GameObject))]
	[TrackClipType(typeof(FMODEventPlayable))]
	public class FMODEventTrack : TrackAsset
	{
		public FMODEventMixerBehaviour template;

		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return default(Playable);
		}
	}
}
