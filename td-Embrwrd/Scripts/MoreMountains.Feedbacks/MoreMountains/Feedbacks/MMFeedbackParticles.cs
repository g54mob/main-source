using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will simply play the specified ParticleSystem (from your scene) when played.")]
	[FeedbackPath("Particles/Particles Play")]
	public class MMFeedbackParticles : MMFeedback
	{
		public enum Modes
		{
			Play = 0,
			Stop = 1,
			Pause = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("whether to Play, Stop or Pause the target particle system when that feedback is played")]
		[Header("Bound Particles")]
		public Modes Mode;

		[Tooltip("the particle system to play with this feedback")]
		public ParticleSystem BoundParticleSystem;

		[Tooltip("a list of (optional) particle systems")]
		public List<ParticleSystem> RandomParticleSystems;

		[Tooltip("if this is true, the particles will be moved to the position passed in parameters")]
		public bool MoveToPosition;

		[Tooltip("if this is true, the particle system's object will be set active on play")]
		public bool ActivateOnPlay;

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomReset()
		{
		}

		protected virtual void PlayParticles(Vector3 position)
		{
		}

		protected virtual void StopParticles()
		{
		}
	}
}
