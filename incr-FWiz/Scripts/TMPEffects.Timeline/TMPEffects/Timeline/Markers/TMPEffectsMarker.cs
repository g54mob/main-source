using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline.Markers
{
	public abstract class TMPEffectsMarker : Marker, INotification, INotificationOptionProvider
	{
		[Header("Marker Settings")]
		[SerializeField]
		protected bool retroactive;

		[SerializeField]
		protected bool triggerOnce;

		[SerializeField]
		protected bool triggerInEditMode;

		public abstract PropertyName id { get; }

		public abstract NotificationFlags flags { get; }
	}
}
