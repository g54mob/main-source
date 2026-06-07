using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Scene/Unload Scene")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you unload a scene by name or build index")]
	public class MMF_UnloadScene : MMF_Feedback
	{
		public enum ColorModes
		{
			Instant = 0,
			Gradient = 1,
			Interpolate = 2
		}

		public enum Methods
		{
			BuildIndex = 0,
			SceneName = 1
		}

		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("Unload Scene", true, 43, false, false)]
		[Tooltip("whether to unload a scene by build index or by name")]
		public Methods Method;

		[MMFEnumCondition("Method", new int[] { 0 })]
		[Tooltip("the build ID of the scene to unload, find it in your Build Settings")]
		public int BuildIndex;

		[Tooltip("the name of the scene to unload")]
		[MMFEnumCondition("Method", new int[] { 1 })]
		public string SceneName;

		[Tooltip("whether or not to output warnings if the scene doesn't exist or can't be loaded")]
		public bool OutputWarningsIfNeeded;

		protected Scene _sceneToUnload;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
