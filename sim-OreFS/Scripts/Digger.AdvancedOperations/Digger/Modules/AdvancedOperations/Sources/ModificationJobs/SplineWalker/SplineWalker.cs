using Digger.Modules.AdvancedOperations.Splines;
using Digger.Modules.Core.Sources;
using Unity.Jobs;
using UnityEngine;

namespace Digger.Modules.AdvancedOperations.Sources.ModificationJobs.SplineWalker
{
	public class SplineWalker
	{
		public delegate IOperation<T> OperationAt<T>(Vector3 position) where T : struct, IJobParallelFor;

		private readonly DiggerSystem[] diggerSystems;

		public SplineWalker(DiggerSystem[] diggerSystems)
		{
			this.diggerSystems = diggerSystems;
		}

		public async Awaitable WalkAlongSpline<T>(BezierSpline spline, float step, OperationAt<T> getOperationAt, bool useBackgroundThreads = false) where T : struct, IJobParallelFor
		{
			float approxLength = spline.GetApproxLength();
			step /= approxLength;
			for (float t = 0f; t < 1f; t += step)
			{
				IOperation<T> operation = getOperationAt(spline.GetPoint(t));
				await DoOperation(operation, useBackgroundThreads);
			}
			DiggerSystem[] array = diggerSystems;
			for (int i = 0; i < array.Length; i++)
			{
				await array[i].BuildPendingMeshesAsync(useBackgroundThreads);
			}
		}

		private async Awaitable DoOperation<T>(IOperation<T> operation, bool useBackgroundThreads) where T : struct, IJobParallelFor
		{
			DiggerSystem[] array = diggerSystems;
			foreach (DiggerSystem diggerSystem in array)
			{
				if (operation.GetAreaToModify(diggerSystem).NeedsModification)
				{
					await diggerSystem.ModifyWithoutMeshes(operation, useBackgroundThreads);
				}
			}
		}
	}
}
