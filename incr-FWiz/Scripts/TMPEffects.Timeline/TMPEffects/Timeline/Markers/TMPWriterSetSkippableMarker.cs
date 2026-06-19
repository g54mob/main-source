using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPSetSkippableMarkerStyle")]
	[DisplayName("TMPEffects Marker/TMPWriter/SetSkippable")]
	public class TMPWriterSetSkippableMarker : TMPEffectsMarker
	{
		[Space]
		[Tooltip("Whether the current text should be skippable.")]
		[SerializeField]
		private bool skippable;

		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);

		public bool Skippable => false;
	}
}
