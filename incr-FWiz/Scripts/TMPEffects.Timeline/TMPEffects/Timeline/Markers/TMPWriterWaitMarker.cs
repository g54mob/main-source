using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	[CustomStyle("TMPWriterWaitMarkerStyle")]
	[DisplayName("TMPEffects Marker/TMPWriter/Wait")]
	public class TMPWriterWaitMarker : TMPEffectsMarker
	{
		[Space]
		[Tooltip("The amount of time the TMPWriter should wait before continuing to write.")]
		[SerializeField]
		private float waitTime;

		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => default(NotificationFlags);

		public float WaitTime => 0f;

		private void OnValidate()
		{
		}
	}
}
