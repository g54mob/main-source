using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	[ExecuteInEditMode]
	[AddComponentMenu("Dreamteck/Splines/Users/Particle Controller")]
	public class ParticleController : SplineUser
	{
		public enum EmitPoint
		{
			Beginning = 0,
			Ending = 1,
			Random = 2,
			Ordered = 3
		}

		public enum MotionType
		{
			None = 0,
			UseParticleSystem = 1,
			FollowForward = 2,
			FollowBackward = 3,
			ByNormal = 4,
			ByNormalRandomized = 5
		}

		public enum Wrap
		{
			Default = 0,
			Loop = 1
		}

		public class Particle
		{
			internal Vector2 startOffset;

			internal Vector2 endOffset;

			internal float cycleSpeed;

			internal Color startColor;

			internal double startPercent;

			internal double GetSplinePercent(Wrap wrap, ParticleSystem.Particle particle, MotionType motionType)
			{
				return 0.0;
			}
		}

		[SerializeField]
		[HideInInspector]
		private ParticleSystem _particleSystem;

		private ParticleSystemRenderer _renderer;

		[HideInInspector]
		public bool pauseWhenNotVisible;

		[HideInInspector]
		public Vector2 offset;

		[HideInInspector]
		public bool volumetric;

		[HideInInspector]
		public bool emitFromShell;

		[HideInInspector]
		public bool apply3DRotation;

		[HideInInspector]
		public Vector2 scale;

		[HideInInspector]
		public EmitPoint emitPoint;

		[HideInInspector]
		public MotionType motionType;

		[HideInInspector]
		public Wrap wrapMode;

		[HideInInspector]
		public float minCycles;

		[HideInInspector]
		public float maxCycles;

		private ParticleSystem.Particle[] _particles;

		private Particle[] _controllers;

		private int _particleCount;

		private int _birthIndex;

		private List<Vector4> _customParticleData;

		public ParticleSystem particleSystemComponent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void LateRun()
		{
		}

		private void TransformParticle(ref ParticleSystem.Particle particle, Transform trs)
		{
		}

		private void InverseTransformParticle(ref ParticleSystem.Particle particle, Transform trs)
		{
		}

		protected override void Reset()
		{
		}

		private void HandleParticle(int index)
		{
		}

		private void OnParticleBorn(int index)
		{
		}
	}
}
