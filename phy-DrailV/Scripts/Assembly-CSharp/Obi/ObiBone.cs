using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[AddComponentMenu("Physics/Obi/Obi Bone")]
	[RequireComponent(typeof(ObiDistanceConstraints))]
	[RequireComponent(typeof(ObiBendingConstraints))]
	[RequireComponent(typeof(ObiSkinConstraints))]
	public class ObiBone : ObiActor
	{
		public const float DEFAULT_PARTICLE_MASS = 0.1f;

		public const float MAX_YOUNG_MODULUS = 20f;

		public const float MIN_YOUNG_MODULUS = 0.0001f;

		[Tooltip("Initial particle radius.")]
		public float particleRadius = 0.05f;

		[HideInInspector]
		[SerializeField]
		private List<Transform> bones;

		[SerializeField]
		[HideInInspector]
		private int[] parentIndices;

		[HideInInspector]
		public bool[] frozen;

		protected ObiAnimatorController animatorController;

		private readonly Vector4[] simulationPosition = new Vector4[1];

		public ObiSkinConstraints SkinConstraints => constraints[Oni.ConstraintType.Skin] as ObiSkinConstraints;

		public ObiDistanceConstraints DistanceConstraints => constraints[Oni.ConstraintType.Distance] as ObiDistanceConstraints;

		public ObiBendingConstraints BendingConstraints => constraints[Oni.ConstraintType.Bending] as ObiBendingConstraints;

		public override void Awake()
		{
			base.Awake();
			SetupAnimatorController();
		}

		public void OnValidate()
		{
			particleRadius = Mathf.Max(0f, particleRadius);
		}

		public override void OnSolverFrameEnd()
		{
			base.OnSolverFrameEnd();
			UpdateBones();
		}

		public override bool AddToSolver(object info)
		{
			if (base.Initialized && base.AddToSolver(info))
			{
				solver.RequireRenderablePositions();
				return true;
			}
			return false;
		}

		public override bool RemoveFromSolver(object info)
		{
			if (solver != null)
			{
				solver.RelinquishRenderablePositions();
			}
			return base.RemoveFromSolver(info);
		}

		private void SetupAnimatorController()
		{
			Animator componentInParent = GetComponentInParent<Animator>();
			if (componentInParent != null)
			{
				animatorController = componentInParent.GetComponent<ObiAnimatorController>();
				if (animatorController == null)
				{
					animatorController = componentInParent.gameObject.AddComponent<ObiAnimatorController>();
				}
			}
		}

		private IEnumerable EnumerateBonesBreadthFirst()
		{
			int count = 0;
			Queue<Transform> queue = new Queue<Transform>();
			queue.Enqueue(base.transform);
			while (queue.Count > 0)
			{
				Transform current = queue.Dequeue();
				if (!(current != null))
				{
					continue;
				}
				count++;
				yield return current;
				foreach (Transform item in current.transform)
				{
					queue.Enqueue(item);
				}
				if (current == base.transform && count > 1)
				{
					yield return null;
				}
			}
		}

		public IEnumerator GeneratePhysicRepresentationForBones()
		{
			initialized = false;
			initializing = true;
			RemoveFromSolver(null);
			bones = new List<Transform>();
			foreach (Transform item in EnumerateBonesBreadthFirst())
			{
				bones.Add(item);
			}
			parentIndices = new int[bones.Count];
			active = new bool[bones.Count];
			positions = new Vector3[bones.Count];
			velocities = new Vector3[bones.Count];
			invMasses = new float[bones.Count];
			solidRadii = new float[bones.Count];
			phases = new int[bones.Count];
			restPositions = new Vector4[bones.Count];
			frozen = new bool[bones.Count];
			DistanceConstraints.Clear();
			ObiDistanceConstraintBatch distanceBatch = new ObiDistanceConstraintBatch(cooked: false, sharesParticles: false, 0.0001f, 20f);
			DistanceConstraints.AddBatch(distanceBatch);
			BendingConstraints.Clear();
			ObiBendConstraintBatch bendingBatch = new ObiBendConstraintBatch(cooked: false, sharesParticles: false, 0.0001f, 20f);
			BendingConstraints.AddBatch(bendingBatch);
			SkinConstraints.Clear();
			ObiSkinConstraintBatch skinBatch = new ObiSkinConstraintBatch(cooked: true, sharesParticles: false, 0.0001f, 20f);
			SkinConstraints.AddBatch(skinBatch);
			int i = 0;
			while (i < bones.Count)
			{
				active[i] = true;
				invMasses[i] = 10f;
				positions[i] = base.transform.InverseTransformPoint(bones[i].position);
				restPositions[i] = positions[i];
				restPositions[i][3] = 0f;
				solidRadii[i] = particleRadius;
				frozen[i] = false;
				phases[i] = Oni.MakePhase(1, selfCollisions ? Oni.ParticlePhase.SelfCollide : ((Oni.ParticlePhase)0));
				parentIndices[i] = -1;
				if (bones[i].parent != null)
				{
					parentIndices[i] = bones.IndexOf(bones[i].parent);
				}
				skinBatch.AddConstraint(i, positions[i], Vector3.up, 0.05f, 0f, 0f, 1f);
				foreach (Transform item2 in bones[i])
				{
					int num = bones.IndexOf(item2);
					if (num >= 0)
					{
						distanceBatch.AddConstraint(i, num, Vector3.Distance(bones[i].position, item2.position), 1f, 1f);
						if (parentIndices[i] >= 0)
						{
							Transform transform2 = bones[parentIndices[i]];
							float restBend = Oni.BendingConstraintRest(new float[9]
							{
								transform2.position[0],
								transform2.position[1],
								transform2.position[2],
								item2.position[0],
								item2.position[1],
								item2.position[2],
								bones[i].position[0],
								bones[i].position[1],
								bones[i].position[2]
							});
							bendingBatch.AddConstraint(parentIndices[i], num, i, restBend, 0f, 0f);
						}
					}
				}
				if (i % 10 == 0)
				{
					yield return new CoroutineJob.ProgressInfo("ObiBone: generating particles...", (float)i / (float)bones.Count);
				}
				int num2 = i + 1;
				i = num2;
			}
			skinBatch.Cook();
			initializing = false;
			initialized = true;
		}

		public override void OnSolverStepBegin()
		{
			bool flag = base.enabled;
			if (animatorController != null)
			{
				animatorController.UpdateAnimation();
			}
			simulationPosition[0] = Vector4.zero;
			Transform transform = base.Solver.transform;
			Matrix4x4 matrix4x = ((!base.Solver.simulateInLocalSpace) ? ActorLocalToWorldMatrix : (transform.worldToLocalMatrix * ActorLocalToWorldMatrix));
			Matrix4x4 matrix4x2 = transform.worldToLocalMatrix * base.Solver.LastTransform;
			ObiSkinConstraintBatch obiSkinConstraintBatch = (ObiSkinConstraintBatch)SkinConstraints.GetBatches()[0];
			for (int i = 0; i < particleIndices.Length; i++)
			{
				Vector3 vector = matrix4x.MultiplyPoint3x4(base.transform.InverseTransformPoint(bones[i].position));
				if (!flag || invMasses[i] == 0f)
				{
					simulationPosition[0] = vector;
					Oni.SetParticlePositions(solver.OniSolver, simulationPosition, 1, particleIndices[i]);
				}
				else if (base.Solver.simulateInLocalSpace)
				{
					Oni.GetParticlePositions(solver.OniSolver, simulationPosition, 1, particleIndices[i]);
					simulationPosition[0] = Vector3.Lerp(simulationPosition[0], matrix4x2.MultiplyPoint3x4(simulationPosition[0]), worldVelocityScale);
					Oni.SetParticlePositions(solver.OniSolver, simulationPosition, 1, particleIndices[i]);
				}
				obiSkinConstraintBatch.skinPoints[i] = vector;
			}
			obiSkinConstraintBatch.PushDataToSolver(SkinConstraints);
		}

		public override void OnSolverStepEnd()
		{
			base.OnSolverStepEnd();
			if (animatorController != null)
			{
				animatorController.ResetUpdateFlag();
			}
		}

		public void UpdateBones()
		{
			for (int i = 0; i < bones.Count; i++)
			{
				if (frozen[i])
				{
					continue;
				}
				Vector3 particlePosition = GetParticlePosition(i);
				if (parentIndices[i] >= 0 && !frozen[parentIndices[i]])
				{
					Transform transform = bones[parentIndices[i]];
					if (transform.childCount <= 1)
					{
						Vector3 fromDirection = transform.TransformDirection(bones[i].localPosition);
						Vector3 toDirection = particlePosition - GetParticlePosition(parentIndices[i]);
						transform.rotation = Quaternion.FromToRotation(fromDirection, toDirection) * transform.rotation;
					}
				}
				bones[i].position = particlePosition;
			}
		}

		public override void ResetActor()
		{
			PushDataToSolver(ParticleData.POSITIONS | ParticleData.VELOCITIES);
			if (particleIndices != null)
			{
				for (int i = 0; i < particleIndices.Length; i++)
				{
					solver.renderablePositions[particleIndices[i]] = positions[i];
					bones[i].position = base.transform.TransformPoint(positions[i]);
				}
			}
		}
	}
}
