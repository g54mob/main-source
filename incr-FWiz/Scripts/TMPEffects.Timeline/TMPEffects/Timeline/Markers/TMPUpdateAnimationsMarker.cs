using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPUpdateAnimationsMarkerStyle")]
	[TrackBindingType(typeof(TMPAnimatorTrack))]
	[DisplayName("TMPEffects Marker/TMPAnimator/UpdateAnimations")]
	public class TMPUpdateAnimationsMarker : TMPEffectsMarker
	{
		[Space]
		[Tooltip("The delta time value to update the animations with. Set to -1 to use Time.deltaTime, -2 to use Time.fixedDeltaTime")]
		[SerializeField]
		private float deltaTime;

		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);

		public float DeltaTime => 0f;
	}
}
