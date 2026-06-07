using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will instantiate the specified ParticleSystem at the specified position on Start or on Play, optionally nesting them.")]
	[FeedbackPath("Particles/Particles Instantiation")]
	public class MMFeedbackParticlesInstantiation : MMFeedback
	{
		public enum PositionModes
		{
			FeedbackPosition = 0,
			Transform = 1,
			WorldPosition = 2,
			Script = 3
		}

		public enum Modes
		{
			Cached = 0,
			OnDemand = 1
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("whether the particle system should be cached or created on demand the first time")]
		[Header("Particles Instantiation")]
		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("if this is false, a brand new particle system will be created every time")]
		public bool CachedRecycle;

		[Tooltip("the particle system to spawn")]
		public ParticleSystem ParticlesPrefab;

		[Tooltip("the possible random particle systems")]
		public List<ParticleSystem> RandomParticlePrefabs;

		[Tooltip("if this is true, the particle system game object will be activated on Play, useful if you've somehow disabled it in a past Play")]
		public bool ForceSetActiveOnPlay;

		[Header("Position")]
		[Tooltip("the selected position mode")]
		public PositionModes PositionMode;

		[Tooltip("the position at which to spawn this particle system")]
		[MMFEnumCondition("PositionMode", new int[] { 1 })]
		public Transform InstantiateParticlesPosition;

		[Tooltip("the world position to move to when in WorldPosition mode")]
		[MMFEnumCondition("PositionMode", new int[] { 2 })]
		public Vector3 TargetWorldPosition;

		[Tooltip("an offset to apply to the instantiation position")]
		public Vector3 Offset;

		[Tooltip("whether or not the particle system should be nested in hierarchy or floating on its own")]
		[MMFEnumCondition("PositionMode", new int[] { 1, 0 })]
		public bool NestParticles;

		[Tooltip("whether or not to also apply rotation")]
		public bool ApplyRotation;

		[Tooltip("whether or not to also apply scale")]
		public bool ApplyScale;

		protected ParticleSystem _instantiatedParticleSystem;

		protected List<ParticleSystem> _instantiatedRandomParticleSystems;

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected virtual void InstantiateParticleSystem()
		{
		}

		protected virtual void PositionParticleSystem(ParticleSystem system)
		{
		}

		protected virtual Quaternion GetRotation(Transform target)
		{
			return default(Quaternion);
		}

		protected virtual Vector3 GetScale(Transform target)
		{
			return default(Vector3);
		}

		protected virtual Vector3 GetPosition(Vector3 position)
		{
			return default(Vector3);
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
	}
}
