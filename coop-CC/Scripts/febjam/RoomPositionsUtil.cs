using System.Collections.Generic;
using Aggro.Core;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public static class RoomPositionsUtil
{
	public static Vector3[] GeneratePositions(float shrinkGridSpaceDistance, float positionNoise, float exclusionCheckRadius, int seed)
	{
		List<Vector3> list = new List<Vector3>();
		ObjectQuery<WarehouseInclusionZone> objectQuery = GameUtil.entityManager.CreateObjectQuery<WarehouseInclusionZone>();
		ObjectQuery<WarehouseExclusionZone> objectQuery2 = GameUtil.entityManager.CreateObjectQuery<WarehouseExclusionZone>();
		objectQuery.Run();
		objectQuery2.Run();
		Bounds bounds = default(Bounds);
		for (int i = 0; i < objectQuery.count; i++)
		{
			if (i == 0)
			{
				bounds = objectQuery[i].GetBounds();
			}
			else
			{
				bounds.Encapsulate(objectQuery[i].GetBounds());
			}
		}
		Unity.Mathematics.Random random = MathUtil.GetRandom(seed);
		for (float num = bounds.min.x + random.NextFloat(0f, shrinkGridSpaceDistance); num <= bounds.max.x; num += shrinkGridSpaceDistance)
		{
			for (float num2 = bounds.min.z + random.NextFloat(0f, shrinkGridSpaceDistance); num2 <= bounds.max.z; num2 += shrinkGridSpaceDistance)
			{
				list.Add(new Vector3(num, 0f, num2) + new Vector3(random.NextFloat(0f - positionNoise, positionNoise), 0f, random.NextFloat(0f - positionNoise, positionNoise)));
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			Vector3 worldPos = list[j];
			bool flag = false;
			for (int k = 0; k < objectQuery.count; k++)
			{
				if (objectQuery[k].IsInBounds(worldPos))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.RemoveAtSwapBack(j);
				j--;
			}
		}
		for (int l = 0; l < objectQuery2.count; l++)
		{
			objectQuery2[l].RemoveOverlapping(list, exclusionCheckRadius);
		}
		for (int m = 0; m < list.Count; m++)
		{
			if (!Physics.Raycast(new Ray(list[m] + Vector3.up, Vector3.down), 2f, 65536))
			{
				list.RemoveAtSwapBack(m);
				m--;
			}
		}
		list.Randomize(random.NextInt());
		return list.ToArray();
	}
}
