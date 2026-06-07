using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you set a property on a target VisualEffect")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.VisualEffectGraph", null)]
	public class MMF_VisualEffectSetProperty : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Visual Effect Property", true, 41, false, false)]
		[Tooltip("the duration for the player to consider. This won't impact your visual effect, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual particle system, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(DeclaredDuration);
			}
			set
			{
				DeclaredDuration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		protected override void CustomPlayFeedback(Vector3 position, float attenuation = 1f)
		{
		}
	}
}
