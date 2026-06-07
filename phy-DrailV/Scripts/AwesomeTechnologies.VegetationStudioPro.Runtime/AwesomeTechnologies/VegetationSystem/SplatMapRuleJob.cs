using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct SplatMapRuleJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<byte> TerrainTextureData;

		public NativeArray<float3> Position;

		[ReadOnly]
		public NativeArray<ARGBBytes> SplatMapArray;

		public float MinValue;

		public float MaxValue;

		public int SplatmapIndex;

		public int Width;

		public int Height;

		public float3 TerrainPosition;

		public float2 SplatCellSize;

		public bool Include;

		public void Execute(int index)
		{
			if (Excluded[index] == 1)
			{
				return;
			}
			int num = Mathf.RoundToInt(MinValue * 256f);
			int num2 = Mathf.RoundToInt(MaxValue * 256f);
			float3 obj = Position[index] - TerrainPosition;
			int num3 = Mathf.RoundToInt(obj.x / SplatCellSize.x);
			int num4 = Mathf.RoundToInt(obj.z / SplatCellSize.y);
			if (num3 < 0 || num4 < 0 || num3 > Width - 1 || num4 > Height - 1)
			{
				if (Include)
				{
					TerrainTextureData[index] = 1;
				}
				return;
			}
			int num5 = 0;
			switch (SplatmapIndex)
			{
			case 0:
				num5 = SplatMapArray[num3 + num4 * Width].R;
				break;
			case 1:
				num5 = SplatMapArray[num3 + num4 * Width].G;
				break;
			case 2:
				num5 = SplatMapArray[num3 + num4 * Width].B;
				break;
			case 3:
				num5 = SplatMapArray[num3 + num4 * Width].A;
				break;
			}
			if (num5 >= num && num5 <= num2)
			{
				TerrainTextureData[index] = 1;
			}
		}
	}
}
