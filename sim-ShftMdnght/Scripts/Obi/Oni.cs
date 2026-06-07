using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class Oni
{
	public enum ConstraintType
	{
		Tether = 0,
		Volume = 1,
		Chain = 2,
		Bending = 3,
		Distance = 4,
		ShapeMatching = 5,
		BendTwist = 6,
		StretchShear = 7,
		Pin = 8,
		ParticleCollision = 9,
		Density = 10,
		Collision = 11,
		Skin = 12,
		Aerodynamics = 13,
		Stitch = 14,
		ParticleFriction = 15,
		Friction = 16
	}

	[Flags]
	public enum RenderingSystemType
	{
		None = 0,
		PathSmoother = 1,
		ExtrudedRope = 2,
		ChainRope = 4,
		LineRope = 8,
		MeshRope = 0x10,
		Cloth = 0x20,
		SkinnedCloth = 0x40,
		TearableCloth = 0x80,
		Softbody = 0x100,
		Fluid = 0x200,
		Particles = 0x400,
		InstancedParticles = 0x800,
		FoamParticles = 0x1000,
		AllSmoothedRopes = 0x1B,
		AllRopes = 0xC1F,
		AllClothes = 0xCE0,
		AllParticles = 0x1E00
	}

	[Flags]
	public enum SimplexType
	{
		None = 0,
		Point = 1,
		Edge = 2,
		Triangle = 4,
		All = -1
	}

	public enum ShapeType
	{
		Sphere = 0,
		Box = 1,
		Capsule = 2,
		Heightmap = 3,
		TriangleMesh = 4,
		EdgeMesh = 5,
		SignedDistanceField = 6
	}

	public enum MaterialCombineMode
	{
		Average = 0,
		Minimum = 1,
		Multiply = 2,
		Maximum = 3
	}

	[Serializable]
	public struct SolverParameters
	{
		public enum Interpolation
		{
			None = 0,
			Interpolate = 1,
			Extrapolate = 2
		}

		public enum Mode
		{
			Mode3D = 0,
			Mode2D = 1
		}

		[Tooltip("In 2D mode, particles are simulated on the XY plane only. For use in conjunction with Unity's 2D mode.")]
		public Mode mode;

		[Tooltip("Same as Rigidbody.interpolation. Set to INTERPOLATE for cloth that is applied on a main character or closely followed by a camera. NONE for everything else.")]
		public Interpolation interpolation;

		[Tooltip("Simulation gravity expressed in local space.")]
		public Vector3 gravity;

		[Tooltip("Simulation wind expressed in local space.")]
		public Vector3 ambientWind;

		[Tooltip("Foam gravity scale.")]
		[Range(-1f, 3f)]
		public float foamGravityScale;

		[Tooltip("Percentage of velocity lost per second, between 0% (0) and 100% (1).")]
		[Range(0f, 1f)]
		public float damping;

		[Tooltip("Max ratio between a particle's longest and shortest axis. Use 1 for isotropic (completely round) particles.")]
		[Range(1f, 5f)]
		public float maxAnisotropy;

		[Tooltip("Mass-normalized kinetic energy threshold below which particle positions aren't updated.")]
		public float sleepThreshold;

		[Tooltip("Maximum particle linear velocity.")]
		public float maxVelocity;

		[Tooltip("Maximum particle angular velocity.")]
		public float maxAngularVelocity;

		[Tooltip("Maximum distance between elements (simplices/colliders) for a contact to be generated.")]
		public float collisionMargin;

		[Tooltip("Maximum depenetration velocity applied to particles that start a frame inside an object. Low values ensure no 'explosive' collision resolution. Should be > 0 unless looking for non-physical effects.")]
		public float maxDepenetration;

		[Tooltip("Percentage of collider velocities used for continuous collision detection. Set to 0 for purely static collisions, set to 1 for pure continuous collisions.")]
		[Range(0f, 1f)]
		public float colliderCCD;

		[Tooltip("Percentage of particle velocities used for continuous collision detection. Set to 0 for purely static collisions, set to 1 for pure continuous collisions.")]
		[Range(0f, 1f)]
		public float particleCCD;

		[Tooltip("Percentage of shock propagation applied to particle-particle collisions. Useful for particle stacking.")]
		[Range(0f, 1f)]
		public float shockPropagation;

		[Tooltip("Amount of iterations spent on convex optimization for surface collisions.")]
		[Range(1f, 32f)]
		public int surfaceCollisionIterations;

		[Tooltip("Error threshold at which to stop convex optimization for surface collisions.")]
		public float surfaceCollisionTolerance;

		public SolverParameters(Interpolation interpolation, Vector4 gravity)
		{
			mode = Mode.Mode3D;
			this.gravity = gravity;
			ambientWind = Vector3.zero;
			this.interpolation = interpolation;
			foamGravityScale = 1f;
			damping = 0f;
			shockPropagation = 0f;
			surfaceCollisionIterations = 8;
			surfaceCollisionTolerance = 0.005f;
			maxAnisotropy = 3f;
			maxDepenetration = 10f;
			sleepThreshold = 0.0005f;
			maxVelocity = 50f;
			maxAngularVelocity = 20f;
			collisionMargin = 0.02f;
			colliderCCD = 1f;
			particleCCD = 0f;
		}
	}

	[Serializable]
	public struct ConstraintParameters
	{
		public enum EvaluationOrder
		{
			Sequential = 0,
			Parallel = 1
		}

		[Tooltip("Order in which constraints are evaluated. SEQUENTIAL converges faster but is not very stable. PARALLEL is very stable but converges slowly, requiring more iterations to achieve the same result.")]
		public EvaluationOrder evaluationOrder;

		[Tooltip("Number of relaxation iterations performed by the constraint solver. A low number of iterations will perform better, but be less accurate.")]
		public int iterations;

		[Tooltip("Over (or under if < 1) relaxation factor used. At 1, no overrelaxation is performed. At 2, constraints double their relaxation rate. High values reduce stability but improve convergence.")]
		[Range(0.1f, 2f)]
		public float SORFactor;

		[MarshalAs(UnmanagedType.I1)]
		[Tooltip("Whether this constraint group is solved or not.")]
		public bool enabled;

		public ConstraintParameters(bool enabled, EvaluationOrder order, int iterations)
		{
			this.enabled = enabled;
			this.iterations = iterations;
			evaluationOrder = order;
			SORFactor = 1f;
		}
	}

	public struct ContactPair
	{
		public int bodyA;

		public int bodyB;
	}

	public struct Contact
	{
		public Vector4 pointA;

		public Vector4 pointB;

		public Vector4 normal;

		public Vector4 tangent;

		public float distance;

		public float normalImpulse;

		public float tangentImpulse;

		public float bitangentImpulse;

		public float stickImpulse;

		public float rollingFrictionImpulse;

		public int bodyA;

		public int bodyB;
	}

	public const int ConstraintTypeCount = 17;

	public const int ColliderShapeTypeCount = 7;

	public const int QueryTypeCount = 3;
}
