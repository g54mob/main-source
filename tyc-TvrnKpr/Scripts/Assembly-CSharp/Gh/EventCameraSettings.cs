using Gh.Tk;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh
{
	public class EventCameraSettings : IPersistable
	{
		public string visual;

		public Vector3 cameraPivotRotation;

		public Vector3 cameraCradlePosition;

		public float swaySpeed;

		public float swayAmountModifier;

		public bool showCountdown;

		public bool useEventTimeAsCountdown;

		public float countdownPercentage;

		public bool disableCloseButton;

		public string displayTextKey;

		[FormerlySerializedAs("voText")]
		public string voTextKey;

		public bool VOPlayed;

		public int gameEventParentId;

		public bool shouldFollowTarget;

		public bool followPelvisBone;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool destroyOnGoxDestroyed;

		public string Id { get; set; }

		public EventCameraSettings(string displayTextKey)
		{
		}

		public EventCameraSettings(string displayTextKey, string visual)
		{
		}

		public EventCameraSettings()
		{
		}
	}
}
