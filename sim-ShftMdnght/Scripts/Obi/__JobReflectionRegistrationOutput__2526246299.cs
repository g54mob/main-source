using System;
using Obi;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__2526246299
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForExtensions.EarlyJobInit<GenerateBoxContactsJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(GenerateBoxContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<GenerateCapsuleContactsJob>();
		}
		catch (Exception ex2)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex2, typeof(GenerateCapsuleContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstColliderWorld.IdentifyMovingColliders>();
		}
		catch (Exception ex3)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex3, typeof(BurstColliderWorld.IdentifyMovingColliders));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstColliderWorld.UpdateMovingColliders>();
		}
		catch (Exception ex4)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex4, typeof(BurstColliderWorld.UpdateMovingColliders));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstColliderWorld.GenerateContactsJob>();
		}
		catch (Exception ex5)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex5, typeof(BurstColliderWorld.GenerateContactsJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstColliderWorld.PrefixSumJob>();
		}
		catch (Exception ex6)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex6, typeof(BurstColliderWorld.PrefixSumJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstColliderWorld.SortContactPairsByShape>();
		}
		catch (Exception ex7)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex7, typeof(BurstColliderWorld.SortContactPairsByShape));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstColliderWorld.ApplyForceZonesJob>();
		}
		catch (Exception ex8)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex8, typeof(BurstColliderWorld.ApplyForceZonesJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<GenerateDistanceFieldContactsJob>();
		}
		catch (Exception ex9)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex9, typeof(GenerateDistanceFieldContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<GenerateEdgeMeshContactsJob>();
		}
		catch (Exception ex10)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex10, typeof(GenerateEdgeMeshContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<GenerateHeightFieldContactsJob>();
		}
		catch (Exception ex11)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex11, typeof(GenerateHeightFieldContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<GenerateSphereContactsJob>();
		}
		catch (Exception ex12)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex12, typeof(GenerateSphereContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<GenerateTriangleMeshContactsJob>();
		}
		catch (Exception ex13)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex13, typeof(GenerateTriangleMeshContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstAerodynamicConstraintsBatch.AerodynamicConstraintsBatchJob>();
		}
		catch (Exception ex14)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex14, typeof(BurstAerodynamicConstraintsBatch.AerodynamicConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstBendConstraintsBatch.BendConstraintsBatchJob>();
		}
		catch (Exception ex15)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex15, typeof(BurstBendConstraintsBatch.BendConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstBendConstraintsBatch.ApplyBendConstraintsBatchJob>();
		}
		catch (Exception ex16)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex16, typeof(BurstBendConstraintsBatch.ApplyBendConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstBendTwistConstraintsBatch.BendTwistConstraintsBatchJob>();
		}
		catch (Exception ex17)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex17, typeof(BurstBendTwistConstraintsBatch.BendTwistConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstBendTwistConstraintsBatch.ApplyBendTwistConstraintsBatchJob>();
		}
		catch (Exception ex18)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex18, typeof(BurstBendTwistConstraintsBatch.ApplyBendTwistConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstConstraintsBatchImpl.ClearLambdasJob>();
		}
		catch (Exception ex19)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex19, typeof(BurstConstraintsBatchImpl.ClearLambdasJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstChainConstraintsBatch.ChainConstraintsBatchJob>();
		}
		catch (Exception ex20)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex20, typeof(BurstChainConstraintsBatch.ChainConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstChainConstraintsBatch.ApplyChainConstraintsBatchJob>();
		}
		catch (Exception ex21)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex21, typeof(BurstChainConstraintsBatch.ApplyChainConstraintsBatchJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<ApplyCollisionConstraintsBatchJob>();
		}
		catch (Exception ex22)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex22, typeof(ApplyCollisionConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstColliderCollisionConstraintsBatch.UpdateContactsJob>();
		}
		catch (Exception ex23)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex23, typeof(BurstColliderCollisionConstraintsBatch.UpdateContactsJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstColliderCollisionConstraintsBatch.CollisionConstraintsBatchJob>();
		}
		catch (Exception ex24)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex24, typeof(BurstColliderCollisionConstraintsBatch.CollisionConstraintsBatchJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstColliderFrictionConstraintsBatch.FrictionConstraintsBatchJob>();
		}
		catch (Exception ex25)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex25, typeof(BurstColliderFrictionConstraintsBatch.FrictionConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraints.ClearFluidDataJob>();
		}
		catch (Exception ex26)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex26, typeof(BurstDensityConstraints.ClearFluidDataJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraints.UpdateInteractionsJob>();
		}
		catch (Exception ex27)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex27, typeof(BurstDensityConstraints.UpdateInteractionsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraints.CalculateLambdasJob>();
		}
		catch (Exception ex28)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex28, typeof(BurstDensityConstraints.CalculateLambdasJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraints.ApplyPositionDeltasJob>();
		}
		catch (Exception ex29)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex29, typeof(BurstDensityConstraints.ApplyPositionDeltasJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraints.ApplyAtmosphereJob>();
		}
		catch (Exception ex30)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex30, typeof(BurstDensityConstraints.ApplyAtmosphereJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraints.AverageSmoothPositionsJob>();
		}
		catch (Exception ex31)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex31, typeof(BurstDensityConstraints.AverageSmoothPositionsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraints.AverageAnisotropyJob>();
		}
		catch (Exception ex32)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex32, typeof(BurstDensityConstraints.AverageAnisotropyJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraintsBatch.UpdateDensitiesJob>();
		}
		catch (Exception ex33)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex33, typeof(BurstDensityConstraintsBatch.UpdateDensitiesJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraintsBatch.ApplyDensityConstraintsJob>();
		}
		catch (Exception ex34)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex34, typeof(BurstDensityConstraintsBatch.ApplyDensityConstraintsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraintsBatch.ViscosityVorticityJob>();
		}
		catch (Exception ex35)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex35, typeof(BurstDensityConstraintsBatch.ViscosityVorticityJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraintsBatch.NormalsJob>();
		}
		catch (Exception ex36)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex36, typeof(BurstDensityConstraintsBatch.NormalsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraintsBatch.AccumulateSmoothPositionsJob>();
		}
		catch (Exception ex37)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex37, typeof(BurstDensityConstraintsBatch.AccumulateSmoothPositionsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDensityConstraintsBatch.AccumulateAnisotropyJob>();
		}
		catch (Exception ex38)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex38, typeof(BurstDensityConstraintsBatch.AccumulateAnisotropyJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDistanceConstraintsBatch.DistanceConstraintsBatchJob>();
		}
		catch (Exception ex39)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex39, typeof(BurstDistanceConstraintsBatch.DistanceConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstDistanceConstraintsBatch.ApplyDistanceConstraintsBatchJob>();
		}
		catch (Exception ex40)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex40, typeof(BurstDistanceConstraintsBatch.ApplyDistanceConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<ApplyBatchedCollisionConstraintsBatchJob>();
		}
		catch (Exception ex41)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex41, typeof(ApplyBatchedCollisionConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstParticleCollisionConstraintsBatch.UpdateParticleContactsJob>();
		}
		catch (Exception ex42)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex42, typeof(BurstParticleCollisionConstraintsBatch.UpdateParticleContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstParticleCollisionConstraintsBatch.ParticleCollisionConstraintsBatchJob>();
		}
		catch (Exception ex43)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex43, typeof(BurstParticleCollisionConstraintsBatch.ParticleCollisionConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstParticleFrictionConstraintsBatch.ParticleFrictionConstraintsBatchJob>();
		}
		catch (Exception ex44)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex44, typeof(BurstParticleFrictionConstraintsBatch.ParticleFrictionConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstPinConstraintsBatch.ClearPinsJob>();
		}
		catch (Exception ex45)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex45, typeof(BurstPinConstraintsBatch.ClearPinsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstPinConstraintsBatch.UpdatePinsJob>();
		}
		catch (Exception ex46)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex46, typeof(BurstPinConstraintsBatch.UpdatePinsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstPinConstraintsBatch.PinConstraintsBatchJob>();
		}
		catch (Exception ex47)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex47, typeof(BurstPinConstraintsBatch.PinConstraintsBatchJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstPinConstraintsBatch.ApplyPinConstraintsBatchJob>();
		}
		catch (Exception ex48)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex48, typeof(BurstPinConstraintsBatch.ApplyPinConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstShapeMatchingConstraintsBatch.ShapeMatchingCalculateRestJob>();
		}
		catch (Exception ex49)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex49, typeof(BurstShapeMatchingConstraintsBatch.ShapeMatchingCalculateRestJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstShapeMatchingConstraintsBatch.ShapeMatchingConstraintsBatchJob>();
		}
		catch (Exception ex50)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex50, typeof(BurstShapeMatchingConstraintsBatch.ShapeMatchingConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstShapeMatchingConstraintsBatch.ApplyShapeMatchingConstraintsBatchJob>();
		}
		catch (Exception ex51)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex51, typeof(BurstShapeMatchingConstraintsBatch.ApplyShapeMatchingConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstSkinConstraintsBatch.SkinConstraintsBatchJob>();
		}
		catch (Exception ex52)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex52, typeof(BurstSkinConstraintsBatch.SkinConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstSkinConstraintsBatch.ApplySkinConstraintsBatchJob>();
		}
		catch (Exception ex53)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex53, typeof(BurstSkinConstraintsBatch.ApplySkinConstraintsBatchJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstStitchConstraintsBatch.StitchConstraintsBatchJob>();
		}
		catch (Exception ex54)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex54, typeof(BurstStitchConstraintsBatch.StitchConstraintsBatchJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstStitchConstraintsBatch.ApplyStitchConstraintsBatchJob>();
		}
		catch (Exception ex55)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex55, typeof(BurstStitchConstraintsBatch.ApplyStitchConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstStretchShearConstraintsBatch.StretchShearConstraintsBatchJob>();
		}
		catch (Exception ex56)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex56, typeof(BurstStretchShearConstraintsBatch.StretchShearConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstStretchShearConstraintsBatch.ApplyStretchShearConstraintsBatchJob>();
		}
		catch (Exception ex57)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex57, typeof(BurstStretchShearConstraintsBatch.ApplyStretchShearConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstTetherConstraintsBatch.TetherConstraintsBatchJob>();
		}
		catch (Exception ex58)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex58, typeof(BurstTetherConstraintsBatch.TetherConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstTetherConstraintsBatch.ApplyTetherConstraintsBatchJob>();
		}
		catch (Exception ex59)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex59, typeof(BurstTetherConstraintsBatch.ApplyTetherConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstVolumeConstraintsBatch.VolumeConstraintsBatchJob>();
		}
		catch (Exception ex60)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex60, typeof(BurstVolumeConstraintsBatch.VolumeConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstVolumeConstraintsBatch.ApplyVolumeConstraintsBatchJob>();
		}
		catch (Exception ex61)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex61, typeof(BurstVolumeConstraintsBatch.ApplyVolumeConstraintsBatchJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstPrefixSum.BlockSumJob>();
		}
		catch (Exception ex62)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex62, typeof(BurstPrefixSum.BlockSumJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<BurstPrefixSum.BlockSum>();
		}
		catch (Exception ex63)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex63, typeof(BurstPrefixSum.BlockSum));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstPrefixSum.PrefixSumJob>();
		}
		catch (Exception ex64)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex64, typeof(BurstPrefixSum.PrefixSumJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<ParticleGrid.UpdateGrid>();
		}
		catch (Exception ex65)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex65, typeof(ParticleGrid.UpdateGrid));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<ParticleGrid.GenerateParticleParticleContactsJob>();
		}
		catch (Exception ex66)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex66, typeof(ParticleGrid.GenerateParticleParticleContactsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<SpatialQueryJob>();
		}
		catch (Exception ex67)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex67, typeof(SpatialQueryJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BuildParticleMeshDataJob>();
		}
		catch (Exception ex68)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex68, typeof(BuildParticleMeshDataJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstFoamRenderSystem.ProjectOnSortAxisJob>();
		}
		catch (Exception ex69)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex69, typeof(BurstFoamRenderSystem.ProjectOnSortAxisJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstFoamRenderSystem.SortParticles>();
		}
		catch (Exception ex70)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex70, typeof(BurstFoamRenderSystem.SortParticles));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstFoamRenderSystem.BuildFoamMeshDataJob>();
		}
		catch (Exception ex71)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex71, typeof(BurstFoamRenderSystem.BuildFoamMeshDataJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstInstancedParticleRenderSystem.InstancedParticleTransforms>();
		}
		catch (Exception ex72)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex72, typeof(BurstInstancedParticleRenderSystem.InstancedParticleTransforms));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstChainRopeRenderSystem.InstanceTransforms>();
		}
		catch (Exception ex73)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex73, typeof(BurstChainRopeRenderSystem.InstanceTransforms));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstExtrudedRopeRenderSystem.BuildExtrudedMesh>();
		}
		catch (Exception ex74)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex74, typeof(BurstExtrudedRopeRenderSystem.BuildExtrudedMesh));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstLineRopeRenderSystem.BuildLineMesh>();
		}
		catch (Exception ex75)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex75, typeof(BurstLineRopeRenderSystem.BuildLineMesh));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BurstMeshRopeRenderSystem.BuildRopeMeshJob>();
		}
		catch (Exception ex76)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex76, typeof(BurstMeshRopeRenderSystem.BuildRopeMeshJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<ChaikinSmoothChunksJob>();
		}
		catch (Exception ex77)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex77, typeof(ChaikinSmoothChunksJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<DecimateChunksJob>();
		}
		catch (Exception ex78)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex78, typeof(DecimateChunksJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<ParallelTransportJob>();
		}
		catch (Exception ex79)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex79, typeof(ParallelTransportJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<ApplyInertialForcesJob>();
		}
		catch (Exception ex80)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex80, typeof(ApplyInertialForcesJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<CalculateSimplexBoundsJob>();
		}
		catch (Exception ex81)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex81, typeof(CalculateSimplexBoundsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BoundsReductionJob>();
		}
		catch (Exception ex82)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex82, typeof(BoundsReductionJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<FindFluidParticlesJob>();
		}
		catch (Exception ex83)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex83, typeof(FindFluidParticlesJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<EmitParticlesJob>();
		}
		catch (Exception ex84)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex84, typeof(EmitParticlesJob));
		}
		try
		{
			IJobParallelForDeferExtensions.EarlyJobInit<UpdateParticlesJob>();
		}
		catch (Exception ex85)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex85, typeof(UpdateParticlesJob));
		}
		try
		{
			IJobParallelForDeferExtensions.EarlyJobInit<CopyJob>();
		}
		catch (Exception ex86)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex86, typeof(CopyJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<InterpolationJob>();
		}
		catch (Exception ex87)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex87, typeof(InterpolationJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<PredictPositionsJob>();
		}
		catch (Exception ex88)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex88, typeof(PredictPositionsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<ResetNormals>();
		}
		catch (Exception ex89)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex89, typeof(ResetNormals));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<UpdateTriangleNormalsJob>();
		}
		catch (Exception ex90)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex90, typeof(UpdateTriangleNormalsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<UpdateEdgeNormalsJob>();
		}
		catch (Exception ex91)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex91, typeof(UpdateEdgeNormalsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<RenderableOrientationFromNormals>();
		}
		catch (Exception ex92)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex92, typeof(RenderableOrientationFromNormals));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<UpdatePositionsJob>();
		}
		catch (Exception ex93)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex93, typeof(UpdatePositionsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<UpdateVelocitiesJob>();
		}
		catch (Exception ex94)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex94, typeof(UpdateVelocitiesJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<DequeueIntoArrayJob<BurstContact>>();
		}
		catch (Exception ex95)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex95, typeof(DequeueIntoArrayJob<BurstContact>));
		}
		try
		{
			IJobExtensions.EarlyJobInit<DequeueIntoArrayJob<FluidInteraction>>();
		}
		catch (Exception ex96)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex96, typeof(DequeueIntoArrayJob<FluidInteraction>));
		}
		try
		{
			IJobExtensions.EarlyJobInit<DequeueIntoArrayJob<BurstQueryResult>>();
		}
		catch (Exception ex97)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex97, typeof(DequeueIntoArrayJob<BurstQueryResult>));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
