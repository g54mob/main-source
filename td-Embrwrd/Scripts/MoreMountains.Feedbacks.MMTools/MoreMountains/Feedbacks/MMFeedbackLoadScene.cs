using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will request the load of a new scene, using the method of your choice")]
	[FeedbackPath("Scene/Load Scene")]
	[AddComponentMenu(null)]
	public class MMFeedbackLoadScene : MMFeedback
	{
		public enum LoadingModes
		{
			Direct = 0,
			MMSceneLoadingManager = 1,
			MMAdditiveSceneLoadingManager = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Scene Names")]
		[Tooltip("the name of the loading screen scene to use - HAS TO BE ADDED TO YOUR BUILD SETTINGS")]
		public string LoadingSceneName;

		[Tooltip("the name of the destination scene - HAS TO BE ADDED TO YOUR BUILD SETTINGS")]
		public string DestinationSceneName;

		[Tooltip("the loading mode to use to load the destination scene : - direct : uses Unity's SceneManager API- MMSceneLoadingManager : the simple, original MM way of loading scenes- MMAdditiveSceneLoadingManager : a more advanced way of loading scenes, with (way) more options")]
		[Header("Mode")]
		public LoadingModes LoadingMode;

		[Tooltip("the priority to use when loading the new scenes")]
		[Header("Loading Scene Manager")]
		public ThreadPriority Priority;

		[Tooltip("whether or not to interpolate progress (slower, but usually looks better and smoother)")]
		public bool InterpolateProgress;

		[Tooltip("whether or not to perform extra checks to make sure the loading screen and destination scene are in the build settings")]
		public bool SecureLoad;

		[Tooltip("a delay (in seconds) to apply before the first fade plays")]
		[Header("Loading Scene Delays")]
		public float BeforeEntryFadeDelay;

		[Tooltip("the duration (in seconds) of the entry fade")]
		public float EntryFadeDuration;

		[Tooltip("a delay (in seconds) to apply after the first fade plays")]
		public float AfterEntryFadeDelay;

		[Tooltip("a delay (in seconds) to apply before the exit fade plays")]
		public float BeforeExitFadeDelay;

		[Tooltip("the duration (in seconds) of the exit fade")]
		public float ExitFadeDuration;

		[Header("Transitions")]
		[Tooltip("the speed at which the progress bar should move if interpolated")]
		public float ProgressInterpolationSpeed;

		[Tooltip("the order in which to play fades (really depends on the type of fader you have in your loading screen")]
		public MMAdditiveSceneLoadingManager.FadeModes FadeMode;

		[Tooltip("the tween to use on the entry fade")]
		public MMTweenType EntryFadeTween;

		[Tooltip("the tween to use on the exit fade")]
		public MMTweenType ExitFadeTween;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
