using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will let you change the scene's skybox on play, replacing it with another one, either a specific one, or one picked at random among multiple skyboxes.")]
	[FeedbackPath("Renderer/Skybox")]
	[AddComponentMenu(null)]
	public class MMFeedbackSkybox : MMFeedback
	{
		public enum Modes
		{
			Single = 0,
			Random = 1
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Skybox")]
		public Modes Mode;

		public Material SingleSkybox;

		public Material[] RandomSkyboxes;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
