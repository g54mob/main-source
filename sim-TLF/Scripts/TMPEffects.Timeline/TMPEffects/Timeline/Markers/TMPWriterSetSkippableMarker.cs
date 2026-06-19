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

		public override NotificationFlags flags => (NotificationFlags)((retroactive ? 2 : 0) | (triggerOnce ? 4 : 0) | (triggerInEditMode ? 1 : 0));

		public bool Skippable => skippable;
	}
}
