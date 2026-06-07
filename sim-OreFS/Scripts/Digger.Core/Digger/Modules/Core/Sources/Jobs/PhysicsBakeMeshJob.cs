using Unity.Burst;
using Unity.Jobs;
using UnityEngine;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct PhysicsBakeMeshJob : IJob
	{
		public int MeshInstanceId;

		public void Execute()
		{
			Physics.BakeMesh(MeshInstanceId, convex: false);
		}
	}
}
