using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPWriterWaitMarkerStyle")]
	[DisplayName("TMPEffects Marker/TMPWriter/ResetWait")]
	public class TMPWriterResetWaitMarker : TMPEffectsMarker
	{
		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);
	}
}
