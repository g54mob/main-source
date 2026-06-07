using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	internal struct ActiveRegionMergeJob : IJob
	{
		[ReadOnly]
		public NativeList<ActiveRegion> activeRegions;

		[ReadOnly]
		public NativeList<Matrix4x4> vpMatrices;

		public Vector2 scale;

		public NativeArray<Rect> merged;

		public unsafe void Execute()
		{
			float num = 1f;
			float num2 = 1f;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < activeRegions.Length; i++)
			{
				ActiveRegion activeRegion = activeRegions[i];
				Rect rect = activeRegion.rect;
				Vector2* ptr = stackalloc Vector2[4]
				{
					new Vector2(rect.x, rect.y),
					new Vector2(rect.x, rect.yMax),
					new Vector2(rect.xMax, rect.yMax),
					new Vector2(rect.xMax, rect.y)
				};
				for (int j = 0; j < 4; j++)
				{
					Vector3 vector = activeRegion.localToWorld.MultiplyPoint3x4(ptr[j]);
					Vector2 vector4;
					if (activeRegion.IsWorldSpace)
					{
						Vector4 vector2 = vector;
						vector2.w = 1f;
						Vector4 vector3 = vpMatrices[activeRegion.vpMatrixCacheIndex.index] * vector2;
						vector4 = new Vector2(vector3.x, vector3.y) / vector3.w * 0.5f + new Vector2(0.5f, 0.5f);
					}
					else
					{
						vector4 = vector * scale;
					}
					num = Mathf.Min(num, vector4.x);
					num2 = Mathf.Min(num2, vector4.y);
					num3 = Mathf.Max(num3, vector4.x);
					num4 = Mathf.Max(num4, vector4.y);
				}
			}
			merged[0] = new Rect(num, num2, num3 - num, num4 - num2);
		}
	}
}
