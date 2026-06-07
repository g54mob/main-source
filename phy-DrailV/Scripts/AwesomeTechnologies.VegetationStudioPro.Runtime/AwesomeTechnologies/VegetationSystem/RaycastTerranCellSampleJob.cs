using AwesomeTechnologies.Utility.Quadtree;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct RaycastTerranCellSampleJob : IJobParallelFor
	{
		public NativeArray<Bounds> VegetationCellBoundsList;

		public Rect TerrainRect;

		public float TerrainMinHeight;

		public float TerrainMaxHeight;

		public void Execute(int index)
		{
			Bounds bounds = VegetationCellBoundsList[index];
			Rect other = RectExtension.CreateRectFromBounds(bounds);
			if (TerrainRect.Overlaps(other))
			{
				float num = bounds.center.y + bounds.extents.y;
				float num2 = ((!(bounds.center.y < 99999f)) ? (bounds.center.y - bounds.extents.y) : TerrainMinHeight);
				if (TerrainMinHeight < num2)
				{
					num2 = TerrainMinHeight;
				}
				if (TerrainMaxHeight > num)
				{
					num = TerrainMaxHeight;
				}
				float y = (num + num2) / 2f;
				float y2 = num - num2;
				bounds = new Bounds(new Vector3(bounds.center.x, y, bounds.center.z), new Vector3(bounds.size.x, y2, bounds.size.z));
				VegetationCellBoundsList[index] = bounds;
			}
		}
	}
}
