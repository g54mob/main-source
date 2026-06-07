using System;
using Digger.Modules.Core.Sources.Jobs;
using Digger.Modules.Core.Sources.VoxelPhysics;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__9483568085447320680
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobExtensions.EarlyJobInit<ConnectedComponentLabelingJob>();
			IJobExtensions.EarlyJobInit<LinkLabelOfNeighborChunksXJob>();
			IJobExtensions.EarlyJobInit<LinkLabelOfNeighborChunksYJob>();
			IJobExtensions.EarlyJobInit<LinkLabelOfNeighborChunksZJob>();
			IJobParallelForExtensions.EarlyJobInit<RemoveFloatingVoxelsJob>();
			IJobParallelForExtensions.EarlyJobInit<AdvancedVoxelGenerationJob>();
			IJobParallelForExtensions.EarlyJobInit<GetSurfaceChunksJob>();
			IJobParallelForExtensions.EarlyJobInit<MarchingCubesJob>();
			IJobParallelForExtensions.EarlyJobInit<MeshToVoxelsJob>();
			IJobExtensions.EarlyJobInit<PhysicsBakeMeshJob>();
			IJobParallelForExtensions.EarlyJobInit<SimpleVoxelGenerationJob>();
			IJobParallelForExtensions.EarlyJobInit<VoxelFillSurfaceJob>();
			IJobParallelForExtensions.EarlyJobInit<VoxelKernelModificationJob>();
			IJobParallelForExtensions.EarlyJobInit<VoxelModificationJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
