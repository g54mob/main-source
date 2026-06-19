using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPRestartWriterMarkerStyle")]
	[DisplayName("TMPEffects Marker/TMPWriter/Restart writer")]
	public class TMPRestartWriterMarker : TMPEffectsMarker
	{
		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);
	}
}
