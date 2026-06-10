using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will simply play the specified ParticleSystem (from your scene) when played.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Particles/Particles Play")]
	public class MMF_Particles : MMF_Feedback
	{
		public enum Modes
		{
			Play = 0,
			Stop = 1,
			Pause = 2,
			Emit = 3
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Bound Particles", true, 41, true, false)]
		[Tooltip("whether to Play, Stop or Pause the target particle system when that feedback is played")]
		public Modes Mode;

		[Tooltip("in Emit mode, the amount of particles per emit")]
		[MMFEnumCondition("Mode", new int[] { 3 })]
		public int EmitCount = 100;

		[Tooltip("the particle system to play with this feedback")]
		public ParticleSystem BoundParticleSystem;

		[Tooltip("a list of (optional) particle systems")]
		public List<ParticleSystem> RandomParticleSystems;

		[Tooltip("if this is true, the particles will be moved to the position passed in parameters")]
		public bool MoveToPosition;

		[Tooltip("if this is true, the particle system's object will be set active on play")]
		public bool ActivateOnPlay;

		[Tooltip("if this is true, the particle system will be stopped on initialization")]
		public bool StopSystemOnInit = true;

		[Tooltip("if this is true, the particle system will be stopped on reset")]
		public bool StopSystemOnReset = true;

		[Tooltip("if this is true, the particle system will be stopped on feedback stop")]
		public bool StopSystemOnStopFeedback = true;

		[Tooltip("the duration for the player to consider. This won't impact your particle system, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual particle system, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		[MMFInspectorGroup("Simulation Speed", true, 43, false, false)]
		[Tooltip("whether or not to force a specific simulation speed on the target particle system(s)")]
		public bool ForceSimulationSpeed;

		[Tooltip("The min and max values at which to randomize the simulation speed, if ForceSimulationSpeed is true. A new value will be randomized every time this feedback plays")]
		[MMFCondition("ForceSimulationSpeed", true)]
		public Vector2 ForcedSimulationSpeed = new Vector2(0.1f, 1f);

		protected ParticleSystem.EmitParams _emitParams;

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

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			BoundParticleSystem = FindAutomatedTarget<ParticleSystem>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (RandomParticleSystems == null)
			{
				RandomParticleSystems = new List<ParticleSystem>();
			}
			if (StopSystemOnInit)
			{
				StopParticles();
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				PlayParticles(position);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && StopSystemOnStopFeedback)
			{
				StopParticles();
			}
		}

		protected override void CustomReset()
		{
			base.CustomReset();
			if (!InCooldown && StopSystemOnReset)
			{
				StopParticles();
			}
		}

		protected virtual void PlayParticles(Vector3 position)
		{
			if (MoveToPosition)
			{
				if (Mode != Modes.Emit)
				{
					BoundParticleSystem.transform.position = position;
					foreach (ParticleSystem randomParticleSystem in RandomParticleSystems)
					{
						randomParticleSystem.transform.position = position;
					}
				}
				else
				{
					_emitParams.position = position;
				}
			}
			if (ActivateOnPlay)
			{
				BoundParticleSystem.gameObject.SetActive(value: true);
				foreach (ParticleSystem randomParticleSystem2 in RandomParticleSystems)
				{
					randomParticleSystem2.gameObject.SetActive(value: true);
				}
			}
			if (RandomParticleSystems.Count > 0)
			{
				int index = Random.Range(0, RandomParticleSystems.Count);
				HandleParticleSystemAction(RandomParticleSystems[index]);
			}
			else if (BoundParticleSystem != null)
			{
				HandleParticleSystemAction(BoundParticleSystem);
			}
		}

		protected virtual void HandleParticleSystemAction(ParticleSystem targetParticleSystem)
		{
			if (ForceSimulationSpeed)
			{
				ParticleSystem.MainModule main = targetParticleSystem.main;
				main.simulationSpeed = Random.Range(ForcedSimulationSpeed.x, ForcedSimulationSpeed.y);
			}
			switch (Mode)
			{
			case Modes.Play:
				targetParticleSystem?.Play();
				break;
			case Modes.Emit:
				_emitParams.applyShapeToPosition = true;
				targetParticleSystem.Emit(_emitParams, EmitCount);
				break;
			case Modes.Stop:
				targetParticleSystem?.Stop();
				break;
			case Modes.Pause:
				targetParticleSystem?.Pause();
				break;
			}
		}

		protected virtual void StopParticles()
		{
			foreach (ParticleSystem randomParticleSystem in RandomParticleSystems)
			{
				randomParticleSystem?.Stop();
			}
			if (BoundParticleSystem != null)
			{
				BoundParticleSystem.Stop();
			}
		}
	}
}
