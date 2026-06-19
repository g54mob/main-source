using System.ComponentModel;
using TMPEffects.Components.Animator;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPSettingsMarkerStyle")]
	[TrackBindingType(typeof(TMPAnimatorTrack))]
	[DisplayName("TMPEffects Marker/TMPAnimator/SetUpdateFrom")]
	public class TMPSetUpdateFromMarker : TMPEffectsMarker
	{
		[Space]
		[Tooltip("Where the TMPAnimator should be updated from.")]
		[SerializeField]
		private UpdateFrom updateFrom;

		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);

		public UpdateFrom UpdateFrom => default(UpdateFrom);
	}
}
