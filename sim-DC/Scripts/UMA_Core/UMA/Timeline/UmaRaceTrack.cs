using UMA.CharacterSystem;
using UnityEngine.Timeline;

namespace UMA.Timeline
{
	[TrackColor(0.2f, 0.2f, 0.2f)]
	[TrackClipType(typeof(UmaRaceClip))]
	[TrackBindingType(typeof(DynamicCharacterAvatar))]
	public class UmaRaceTrack : TrackAsset
	{
	}
}
