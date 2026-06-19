using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPStartAnimatingMarkerStyle")]
	[TrackBindingType(typeof(TMPAnimatorTrack))]
	[DisplayName("TMPEffects Marker/TMPAnimator/StartAnimating")]
	public class TMPStartAnimatingMarker : TMPEffectsMarker
	{
		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => (NotificationFlags)((retroactive ? 2 : 0) | (triggerOnce ? 4 : 0) | (triggerInEditMode ? 1 : 0));
	}
}
