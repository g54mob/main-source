using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[BurstCompile]
	public struct UnpackTreeInstanceJob : IJob
	{
		public NativeArray<int> count;

		[WriteOnly]
		public NativeArray<TreeInstance> trees;

		[ReadOnly]
		public NativeArray<half4> placementData;

		[ReadOnly]
		public NativeArray<half4> randomData;

		[ReadOnly]
		public NativeArray<int> treeIndexes;

		public void Execute()
		{
			for (int i = 0; i < placementData.Length; i++)
			{
				half4 half5 = placementData[i];
				if ((float)half5.w > 0f)
				{
					TreeInstance value = default(TreeInstance);
					half4 half6 = randomData[i];
					value.position = new Vector3(half5.x, (float)half5.y * 2f, half5.z);
					value.color = Color.white;
					value.lightmapColor = Color.white;
					value.prototypeIndex = treeIndexes[(int)(float)half6.x % treeIndexes.Length];
					value.heightScale = half6.y;
					value.widthScale = half6.z;
					value.rotation = half6.w;
					trees[count[0]] = value;
					count[0] = count[0] + 1;
				}
			}
		}
	}
}
