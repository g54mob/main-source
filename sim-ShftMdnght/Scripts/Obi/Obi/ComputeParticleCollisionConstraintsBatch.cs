using UnityEngine;

namespace Obi
{
	public class ComputeParticleCollisionConstraintsBatch : ComputeConstraintsBatchImpl, IParticleCollisionConstraintsBatchImpl, IConstraintsBatchImpl
	{
		public ComputeParticleCollisionConstraintsBatch(ComputeParticleCollisionConstraints constraints)
		{
			m_Constraints = constraints;
			m_ConstraintType = Oni.ConstraintType.ParticleCollision;
		}

		public override void Initialize(float substepTime)
		{
			ComputeShader constraintsShader = ((ComputeParticleCollisionConstraints)m_Constraints).constraintsShader;
			int initializeKernel = ((ComputeParticleCollisionConstraints)m_Constraints).initializeKernel;
			if (base.solverImplementation.simplexCounts.simplexCount > 0)
			{
				constraintsShader.SetInt("pointCount", base.solverAbstraction.simplexCounts.pointCount);
				constraintsShader.SetInt("edgeCount", base.solverAbstraction.simplexCounts.edgeCount);
				constraintsShader.SetInt("triangleCount", base.solverAbstraction.simplexCounts.triangleCount);
				constraintsShader.SetFloat("shockPropagation", base.solverAbstraction.parameters.shockPropagation);
				constraintsShader.SetVector("gravity", base.solverAbstraction.parameters.gravity);
				constraintsShader.SetBuffer(initializeKernel, "simplices", base.solverImplementation.simplices);
				constraintsShader.SetBuffer(initializeKernel, "particleContacts", base.solverAbstraction.particleContacts.computeBuffer);
				constraintsShader.SetBuffer(initializeKernel, "effectiveMasses", base.solverAbstraction.particleContactEffectiveMasses.computeBuffer);
				constraintsShader.SetBuffer(initializeKernel, "dispatchBuffer", base.solverImplementation.particleGrid.dispatchBuffer);
				constraintsShader.SetBuffer(initializeKernel, "collisionMaterials", base.solverImplementation.colliderGrid.materialsBuffer);
				constraintsShader.SetBuffer(initializeKernel, "positions", base.solverImplementation.positionsBuffer);
				constraintsShader.SetBuffer(initializeKernel, "prevPositions", base.solverImplementation.prevPositionsBuffer);
				constraintsShader.SetBuffer(initializeKernel, "orientations", base.solverImplementation.orientationsBuffer);
				constraintsShader.SetBuffer(initializeKernel, "prevOrientations", base.solverImplementation.prevOrientationsBuffer);
				constraintsShader.SetBuffer(initializeKernel, "principalRadii", base.solverImplementation.principalRadiiBuffer);
				constraintsShader.SetBuffer(initializeKernel, "velocities", base.solverImplementation.velocitiesBuffer);
				constraintsShader.SetBuffer(initializeKernel, "positionConstraintCounts", base.solverImplementation.positionConstraintCountBuffer);
				constraintsShader.SetBuffer(initializeKernel, "collisionMaterialIndices", base.solverImplementation.collisionMaterialIndexBuffer);
				constraintsShader.SetBuffer(initializeKernel, "deltasAsInt", base.solverImplementation.positionDeltasIntBuffer);
				constraintsShader.SetBuffer(initializeKernel, "invMasses", base.solverImplementation.invMassesBuffer);
				constraintsShader.SetBuffer(initializeKernel, "invRotationalMasses", base.solverImplementation.invMassesBuffer);
				constraintsShader.SetFloat("deltaTime", substepTime);
				constraintsShader.DispatchIndirect(initializeKernel, base.solverImplementation.particleGrid.dispatchBuffer);
			}
		}

		public override void Evaluate(float stepTime, float substepTime, int steps, float timeLeft)
		{
			if (base.solverImplementation.simplexCounts.simplexCount > 0)
			{
				ComputeShader constraintsShader = ((ComputeParticleCollisionConstraints)m_Constraints).constraintsShader;
				int projectKernel = ((ComputeParticleCollisionConstraints)m_Constraints).projectKernel;
				constraintsShader.SetBuffer(projectKernel, "particleContacts", base.solverAbstraction.particleContacts.computeBuffer);
				constraintsShader.SetBuffer(projectKernel, "effectiveMasses", base.solverAbstraction.particleContactEffectiveMasses.computeBuffer);
				constraintsShader.SetBuffer(projectKernel, "dispatchBuffer", base.solverImplementation.particleGrid.dispatchBuffer);
				constraintsShader.SetBuffer(projectKernel, "simplices", base.solverImplementation.simplices);
				constraintsShader.SetBuffer(projectKernel, "positions", base.solverImplementation.positionsBuffer);
				constraintsShader.SetBuffer(projectKernel, "prevPositions", base.solverImplementation.prevPositionsBuffer);
				constraintsShader.SetBuffer(projectKernel, "orientations", base.solverImplementation.orientationsBuffer);
				constraintsShader.SetBuffer(projectKernel, "prevOrientations", base.solverImplementation.prevOrientationsBuffer);
				constraintsShader.SetBuffer(projectKernel, "principalRadii", base.solverImplementation.principalRadiiBuffer);
				constraintsShader.SetBuffer(projectKernel, "positionConstraintCounts", base.solverImplementation.positionConstraintCountBuffer);
				constraintsShader.SetBuffer(projectKernel, "deltasAsInt", base.solverImplementation.positionDeltasIntBuffer);
				constraintsShader.SetBuffer(projectKernel, "invMasses", base.solverImplementation.invMassesBuffer);
				constraintsShader.SetFloat("deltaTime", substepTime);
				constraintsShader.DispatchIndirect(projectKernel, base.solverImplementation.particleGrid.dispatchBuffer);
			}
		}

		public override void Apply(float substepTime)
		{
			ComputeShader constraintsShader = ((ComputeParticleCollisionConstraints)m_Constraints).constraintsShader;
			int applyKernel = ((ComputeParticleCollisionConstraints)m_Constraints).applyKernel;
			if (base.solverImplementation.activeParticleCount > 0)
			{
				Oni.ConstraintParameters constraintParameters = base.solverAbstraction.GetConstraintParameters(m_ConstraintType);
				constraintsShader.SetBuffer(applyKernel, "particleIndices", base.solverImplementation.activeParticlesBuffer);
				constraintsShader.SetBuffer(applyKernel, "positions", base.solverImplementation.positionsBuffer);
				constraintsShader.SetBuffer(applyKernel, "positionConstraintCounts", base.solverImplementation.positionConstraintCountBuffer);
				constraintsShader.SetBuffer(applyKernel, "deltasAsInt", base.solverImplementation.positionDeltasIntBuffer);
				constraintsShader.SetInt("particleCount", base.solverAbstraction.activeParticleCount);
				constraintsShader.SetFloat("sorFactor", constraintParameters.SORFactor);
				int threadGroupsX = ComputeMath.ThreadGroupCount(base.solverAbstraction.activeParticleCount, 128);
				constraintsShader.Dispatch(applyKernel, threadGroupsX, 1, 1);
			}
		}
	}
}
