using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPResetWriterMarkerStyle")]
	[DisplayName("TMPEffects Marker/TMPWriter/Reset writer")]
	public class TMPResetWriterMarker : TMPEffectsMarker
	{
		[Space]
		[Tooltip("What text index to reset the TMPWriter to.")]
		[SerializeField]
		private int textIndex;

		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);

		public int TextIndex => 0;

		private void OnValidate()
		{
		}
	}
}
