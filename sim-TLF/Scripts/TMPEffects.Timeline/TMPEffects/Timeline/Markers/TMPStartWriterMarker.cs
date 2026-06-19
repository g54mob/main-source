using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPStartWriterMarkerStyle")]
	[DisplayName("TMPEffects Marker/TMPWriter/Start writer")]
	public class TMPStartWriterMarker : TMPEffectsMarker
	{
		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => (NotificationFlags)((retroactive ? 2 : 0) | (triggerOnce ? 4 : 0) | (triggerInEditMode ? 1 : 0));
	}
}
