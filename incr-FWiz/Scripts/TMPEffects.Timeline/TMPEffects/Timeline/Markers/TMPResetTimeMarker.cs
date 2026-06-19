using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPResetTimeMarkerStyle")]
	[TrackBindingType(typeof(TMPAnimatorTrack))]
	[DisplayName("TMPEffects Marker/TMPAnimator/ResetTime")]
	public class TMPResetTimeMarker : TMPEffectsMarker
	{
		[Space]
		[Tooltip("The time value to reset the TMPAnimator to.")]
		[SerializeField]
		private new float time;

		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);

		public float Time => 0f;

		private void OnValidate()
		{
		}
	}
}
