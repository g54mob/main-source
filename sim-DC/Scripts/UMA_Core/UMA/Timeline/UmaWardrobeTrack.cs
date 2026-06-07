using UMA.CharacterSystem;
using UnityEngine.Timeline;

namespace UMA.Timeline
{
	[TrackColor(0.2f, 0f, 0.2f)]
	[TrackClipType(typeof(UmaWardrobeClip))]
	[TrackBindingType(typeof(DynamicCharacterAvatar))]
	public class UmaWardrobeTrack : TrackAsset
	{
	}
}
