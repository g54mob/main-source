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
		private float waitTime = 0.5f;

		public override PropertyName id => default(PropertyName);

		public override NotificationFlags flags => (NotificationFlags)((retroactive ? 2 : 0) | (triggerOnce ? 4 : 0) | (triggerInEditMode ? 1 : 0));

		public float WaitTime => waitTime;

		private void OnValidate()
		{
			if (waitTime < 0f)
			{
				waitTime = 0f;
			}
		}
	}
}
