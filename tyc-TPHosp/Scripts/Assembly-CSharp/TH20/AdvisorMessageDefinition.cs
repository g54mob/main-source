using UnityEngine;

namespace TH20
{
	public struct AdvisorMessageDefinition
	{
		public PlatformFeatureSupport.FeatureType FeatureRequired;

		public LocalisedString LocalisedMessage;

		public string Message;

		[DontSave]
		public Sprite Icon;

		public float Duration;

		public bool ShowIndefinitely;

		public bool UserCanDismiss;

		public Vector3? CameraFocus;

		[DontSave]
		public GameObject CameraTrackObject;

		public bool StartCollaborativeMenuOnClick;

		public RuntimeAnimatorController OverrideAnimationGraph;

		public AdvisorDisplayType DisplayType;
	}
}
