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

		public override NotificationFlags flags => (NotificationFlags)((retroactive ? 2 : 0) | (triggerOnce ? 4 : 0) | (triggerInEditMode ? 1 : 0));

		public int TextIndex => textIndex;

		private void OnValidate()
		{
			if (textIndex < 0)
			{
				textIndex = 0;
			}
		}
	}
}
