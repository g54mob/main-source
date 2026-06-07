using AwesomeTechnologies.Utility.Quadtree;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct UnityTerranCellSampleJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<float> InputHeights;

		public NativeArray<Bounds> VegetationCellBoundsList;

		public int HeightmapWidth;

		public int HeightmapHeight;

		public Vector3 HeightMapScale;

		public Rect TerrainRect;

		public Vector3 TerrainPosition;

		public float WorldspaceHeightCutoff;

		public void Execute(int index)
		{
			Bounds bounds = VegetationCellBoundsList[index];
			Rect other = RectExtension.CreateRectFromBounds(bounds);
			if (!TerrainRect.Overlaps(other))
			{
				return;
			}
			float2 float5 = new float2(bounds.center.x - bounds.extents.x, bounds.center.z - bounds.extents.z);
			float2 float6 = new float2(float5.x - TerrainPosition.x, float5.y - TerrainPosition.z);
			float2 obj = new float2(float6.x / HeightMapScale.x, float6.y / HeightMapScale.z);
			int num = Mathf.CeilToInt(other.width / HeightMapScale.x);
			int num2 = Mathf.CeilToInt(other.height / HeightMapScale.z);
			int num3 = Mathf.FloorToInt(obj.x);
			int num4 = Mathf.FloorToInt(obj.y);
			float num5 = float.MaxValue;
			float num6 = float.MinValue;
			for (int i = num3; i <= num3 + num; i++)
			{
				for (int j = num4; j <= num4 + num2; j++)
				{
					float height = GetHeight(i, j);
					if (height < num5)
					{
						num5 = height;
					}
					if (height > num6)
					{
						num6 = height;
					}
				}
			}
			if (!(num6 + TerrainPosition.y < WorldspaceHeightCutoff))
			{
				float num7 = (num6 + num5) / 2f;
				float y = num6 - num5;
				bounds = new Bounds(new Vector3(bounds.center.x, num7 + TerrainPosition.y, bounds.center.z), new Vector3(bounds.size.x, y, bounds.size.z));
				VegetationCellBoundsList[index] = bounds;
			}
		}

		private float GetHeight(int x, int y)
		{
			x = math.clamp(x, 0, HeightmapWidth - 1);
			y = math.clamp(y, 0, HeightmapHeight - 1);
			return InputHeights[y * HeightmapWidth + x] * HeightMapScale.y;
		}
	}
}
