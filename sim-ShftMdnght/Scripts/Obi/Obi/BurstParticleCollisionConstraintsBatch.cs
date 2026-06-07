using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace Obi
{
	public class BurstParticleCollisionConstraintsBatch : BurstConstraintsBatchImpl, IParticleCollisionConstraintsBatchImpl, IConstraintsBatchImpl
	{
		[BurstCompile]
		public struct UpdateParticleContactsJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<float4> prevPositions;

			[ReadOnly]
			public NativeArray<quaternion> prevOrientations;

			[ReadOnly]
			public NativeArray<float4> velocities;

			[ReadOnly]
			public NativeArray<float4> radii;

			[ReadOnly]
			public NativeArray<float> invMasses;

			[ReadOnly]
			public NativeArray<float> invRotationalMasses;

			[ReadOnly]
			public NativeArray<int> particleMaterialIndices;

			[ReadOnly]
			public NativeArray<BurstCollisionMaterial> collisionMaterials;

			[ReadOnly]
			public NativeArray<int> simplices;

			[ReadOnly]
			public SimplexCounts simplexCounts;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<ContactEffectiveMasses> effectiveMasses;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<BurstContact> contacts;

			[ReadOnly]
			public BatchData batchData;

			public void Execute(int workItemIndex)
			{
				batchData.GetConstraintRange(workItemIndex, out var start, out var end);
				for (int i = start; i < end; i++)
				{
					BurstContact value = contacts[i];
					ContactEffectiveMasses value2 = effectiveMasses[i];
					int size;
					int simplexStartAndSize = simplexCounts.GetSimplexStartAndSize(value.bodyA, out size);
					int size2;
					int simplexStartAndSize2 = simplexCounts.GetSimplexStartAndSize(value.bodyB, out size2);
					float4 zero = float4.zero;
					float4 zero2 = float4.zero;
					quaternion orientation = new quaternion(0f, 0f, 0f, 0f);
					float num = 0f;
					float num2 = 0f;
					float num3 = 0f;
					float4 zero3 = float4.zero;
					float4 zero4 = float4.zero;
					quaternion orientation2 = new quaternion(0f, 0f, 0f, 0f);
					float num4 = 0f;
					float num5 = 0f;
					float num6 = 0f;
					for (int j = 0; j < size; j++)
					{
						int index = simplices[simplexStartAndSize + j];
						zero += velocities[index] * value.pointA[j];
						zero2 += prevPositions[index] * value.pointA[j];
						orientation.value += prevOrientations[index].value * value.pointA[j];
						num2 += invMasses[index] * value.pointA[j];
						num3 += invRotationalMasses[index] * value.pointA[j];
						num += BurstMath.EllipsoidRadius(value.normal, prevOrientations[index], radii[index].xyz) * value.pointA[j];
					}
					for (int k = 0; k < size2; k++)
					{
						int index2 = simplices[simplexStartAndSize2 + k];
						zero3 += velocities[index2] * value.pointB[k];
						zero4 += prevPositions[index2] * value.pointB[k];
						orientation2.value += prevOrientations[index2].value * value.pointB[k];
						num5 += invMasses[index2] * value.pointB[k];
						num6 += invRotationalMasses[index2] * value.pointB[k];
						num4 += BurstMath.EllipsoidRadius(value.normal, prevOrientations[index2], radii[index2].xyz) * value.pointB[k];
					}
					float num7 = math.dot(zero2 - zero4, value.normal);
					value.distance = num7 - (num + num4);
					float4 contactPoint = zero4 + value.normal * (value.distance + num4);
					float4 contactPoint2 = zero2 - value.normal * (value.distance + num);
					value.CalculateTangent(zero - zero3);
					int num8 = particleMaterialIndices[simplices[simplexStartAndSize]];
					int num9 = particleMaterialIndices[simplices[simplexStartAndSize2]];
					bool rollingContacts = (num8 >= 0 && collisionMaterials[num8].rollingContacts > 0) | (num9 >= 0 && collisionMaterials[num9].rollingContacts > 0);
					float4 inverseInertiaTensor = math.rcp(BurstMath.GetParticleInertiaTensor(num, num3) + new float4(1E-07f));
					float4 inverseInertiaTensor2 = math.rcp(BurstMath.GetParticleInertiaTensor(num4, num6) + new float4(1E-07f));
					value2.CalculateContactMassesA(num2, inverseInertiaTensor, zero2, orientation, contactPoint, value.normal, value.tangent, value.bitangent, rollingContacts);
					value2.CalculateContactMassesB(num5, inverseInertiaTensor2, zero4, orientation2, contactPoint2, value.normal, value.tangent, value.bitangent, rollingContacts);
					contacts[i] = value;
					effectiveMasses[i] = value2;
				}
			}
		}

		[BurstCompile]
		public struct ParticleCollisionConstraintsBatchJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<quaternion> orientations;

			[ReadOnly]
			public NativeArray<float> invMasses;

			[ReadOnly]
			public NativeArray<float4> radii;

			[ReadOnly]
			public NativeArray<int> particleMaterialIndices;

			[ReadOnly]
			public NativeArray<BurstCollisionMaterial> collisionMaterials;

			[ReadOnly]
			public NativeArray<int> simplices;

			[ReadOnly]
			public SimplexCounts simplexCounts;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<float4> positions;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<float4> deltas;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<int> counts;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<BurstContact> contacts;

			[ReadOnly]
			public NativeArray<ContactEffectiveMasses> effectiveMasses;

			[ReadOnly]
			public Oni.ConstraintParameters constraintParameters;

			[ReadOnly]
			public Oni.SolverParameters solverParameters;

			[ReadOnly]
			public float4 gravity;

			[ReadOnly]
			public float substepTime;

			[ReadOnly]
			public BatchData batchData;

			public void Execute(int workItemIndex)
			{
				batchData.GetConstraintRange(workItemIndex, out var start, out var end);
				for (int i = start; i < end; i++)
				{
					BurstContact value = contacts[i];
					int size;
					int simplexStartAndSize = simplexCounts.GetSimplexStartAndSize(value.bodyA, out size);
					int size2;
					int simplexStartAndSize2 = simplexCounts.GetSimplexStartAndSize(value.bodyB, out size2);
					BurstCollisionMaterial burstCollisionMaterial = CombineCollisionMaterials(simplices[simplexStartAndSize], simplices[simplexStartAndSize2]);
					float4 zero = float4.zero;
					float4 zero2 = float4.zero;
					float num = 0f;
					float num2 = 0f;
					for (int j = 0; j < size; j++)
					{
						int index = simplices[simplexStartAndSize + j];
						zero += positions[index] * value.pointA[j];
						num += BurstMath.EllipsoidRadius(value.normal, orientations[index], radii[index].xyz) * value.pointA[j];
					}
					for (int k = 0; k < size2; k++)
					{
						int index2 = simplices[simplexStartAndSize2 + k];
						zero2 += positions[index2] * value.pointB[k];
						num2 += BurstMath.EllipsoidRadius(value.normal, orientations[index2], radii[index2].xyz) * value.pointA[k];
					}
					float4 posA = zero - value.normal * num;
					float4 posB = zero2 + value.normal * num2;
					float num3 = value.SolveAdhesion(effectiveMasses[i].TotalNormalInvMass, posA, posB, burstCollisionMaterial.stickDistance, burstCollisionMaterial.stickiness, substepTime);
					num3 += value.SolvePenetration(effectiveMasses[i].TotalNormalInvMass, posA, posB, solverParameters.maxDepenetration * substepTime);
					if (math.abs(num3) > 1E-07f)
					{
						float num4 = solverParameters.shockPropagation * math.dot(value.normal, math.normalizesafe(gravity));
						float4 float5 = num3 * value.normal;
						float num5 = BurstMath.BaryScale(value.pointA);
						for (int l = 0; l < size; l++)
						{
							int index3 = simplices[simplexStartAndSize + l];
							deltas[index3] += float5 * invMasses[index3] * value.pointA[l] * num5 * (1f - num4);
							counts[index3]++;
						}
						num5 = BurstMath.BaryScale(value.pointB);
						for (int m = 0; m < size2; m++)
						{
							int index4 = simplices[simplexStartAndSize2 + m];
							deltas[index4] -= float5 * invMasses[index4] * value.pointB[m] * num5 * (1f + num4);
							counts[index4]++;
						}
					}
					if (constraintParameters.evaluationOrder == Oni.ConstraintParameters.EvaluationOrder.Sequential)
					{
						for (int n = 0; n < size; n++)
						{
							BurstConstraintsBatchImpl.ApplyPositionDelta(simplices[simplexStartAndSize + n], constraintParameters.SORFactor, ref positions, ref deltas, ref counts);
						}
						for (int num6 = 0; num6 < size2; num6++)
						{
							BurstConstraintsBatchImpl.ApplyPositionDelta(simplices[simplexStartAndSize2 + num6], constraintParameters.SORFactor, ref positions, ref deltas, ref counts);
						}
					}
					contacts[i] = value;
				}
			}

			private BurstCollisionMaterial CombineCollisionMaterials(int entityA, int entityB)
			{
				int num = particleMaterialIndices[entityA];
				int num2 = particleMaterialIndices[entityB];
				if (num >= 0 && num2 >= 0)
				{
					return BurstCollisionMaterial.CombineWith(collisionMaterials[num], collisionMaterials[num2]);
				}
				if (num >= 0)
				{
					return collisionMaterials[num];
				}
				if (num2 >= 0)
				{
					return collisionMaterials[num2];
				}
				return default(BurstCollisionMaterial);
			}
		}

		public BatchData batchData;

		public BurstParticleCollisionConstraintsBatch(BurstParticleCollisionConstraints constraints)
		{
			m_Constraints = constraints;
			m_ConstraintType = Oni.ConstraintType.ParticleCollision;
		}

		public BurstParticleCollisionConstraintsBatch(BatchData batchData)
		{
			this.batchData = batchData;
		}

		public override JobHandle Initialize(JobHandle inputDeps, float substepTime)
		{
			return IJobParallelForExtensions.Schedule(new UpdateParticleContactsJob
			{
				prevPositions = base.solverImplementation.prevPositions,
				prevOrientations = base.solverImplementation.prevOrientations,
				velocities = base.solverImplementation.velocities,
				radii = base.solverImplementation.principalRadii,
				invMasses = base.solverImplementation.invMasses,
				invRotationalMasses = base.solverImplementation.invRotationalMasses,
				simplices = base.solverImplementation.simplices,
				simplexCounts = base.solverImplementation.simplexCounts,
				particleMaterialIndices = base.solverImplementation.collisionMaterials,
				collisionMaterials = ObiColliderWorld.GetInstance().collisionMaterials.AsNativeArray<BurstCollisionMaterial>(),
				contacts = ((BurstSolverImpl)base.constraints.solver).abstraction.particleContacts.AsNativeArray<BurstContact>(),
				effectiveMasses = ((BurstSolverImpl)base.constraints.solver).abstraction.particleContactEffectiveMasses.AsNativeArray<ContactEffectiveMasses>(),
				batchData = batchData
			}, innerloopBatchCount: (!batchData.isLast) ? 1 : batchData.workItemCount, arrayLength: batchData.workItemCount, dependsOn: inputDeps);
		}

		public override JobHandle Evaluate(JobHandle inputDeps, float stepTime, float substepTime, int steps, float timeLeft)
		{
			Oni.ConstraintParameters constraintParameters = base.solverAbstraction.GetConstraintParameters(m_ConstraintType);
			return IJobParallelForExtensions.Schedule(new ParticleCollisionConstraintsBatchJob
			{
				positions = base.solverImplementation.positions,
				orientations = base.solverImplementation.orientations,
				invMasses = base.solverImplementation.invMasses,
				radii = base.solverImplementation.principalRadii,
				particleMaterialIndices = base.solverImplementation.collisionMaterials,
				collisionMaterials = ObiColliderWorld.GetInstance().collisionMaterials.AsNativeArray<BurstCollisionMaterial>(),
				simplices = base.solverImplementation.simplices,
				simplexCounts = base.solverImplementation.simplexCounts,
				deltas = base.solverImplementation.positionDeltas,
				counts = base.solverImplementation.positionConstraintCounts,
				contacts = base.solverAbstraction.particleContacts.AsNativeArray<BurstContact>(),
				effectiveMasses = ((BurstSolverImpl)base.constraints.solver).abstraction.particleContactEffectiveMasses.AsNativeArray<ContactEffectiveMasses>(),
				batchData = batchData,
				constraintParameters = constraintParameters,
				solverParameters = base.solverImplementation.abstraction.parameters,
				gravity = new float4(base.solverImplementation.abstraction.parameters.gravity, 0f),
				substepTime = substepTime
			}, innerloopBatchCount: (!batchData.isLast) ? 1 : batchData.workItemCount, arrayLength: batchData.workItemCount, dependsOn: inputDeps);
		}

		public override JobHandle Apply(JobHandle inputDeps, float substepTime)
		{
			Oni.ConstraintParameters constraintParameters = base.solverAbstraction.GetConstraintParameters(m_ConstraintType);
			return IJobParallelForExtensions.Schedule(new ApplyBatchedCollisionConstraintsBatchJob
			{
				contacts = base.solverAbstraction.particleContacts.AsNativeArray<BurstContact>(),
				simplices = base.solverImplementation.simplices,
				simplexCounts = base.solverImplementation.simplexCounts,
				positions = base.solverImplementation.positions,
				deltas = base.solverImplementation.positionDeltas,
				counts = base.solverImplementation.positionConstraintCounts,
				orientations = base.solverImplementation.orientations,
				orientationDeltas = base.solverImplementation.orientationDeltas,
				orientationCounts = base.solverImplementation.orientationConstraintCounts,
				batchData = batchData,
				constraintParameters = constraintParameters
			}, innerloopBatchCount: (!batchData.isLast) ? 1 : batchData.workItemCount, arrayLength: batchData.workItemCount, dependsOn: inputDeps);
		}
	}
}
