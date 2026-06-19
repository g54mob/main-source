using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPSkipWriterMarkerStyle")]
	[DisplayName("TMPEffects Marker/TMPWriter/Skip writer")]
	public class TMPSkipWriterMarker : TMPEffectsMarker
	{
		[Space]
		[Tooltip("Whether to skip the show animations (if any) when skipping the current text.")]
		[SerializeField]
		private bool skipShowAnimation;

		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);

		public bool SkipShowAnimation => false;
	}
}
