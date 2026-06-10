using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class GridTools : Singleton<GridTools>
	{
		private GridTools()
		{
		}

		public HashSet<Vec3Int> GetSurroundingPositions(Vec3Int startPosition, Vec3Int size, float originalAngle)
		{
			HashSet<Vec3Int> hashSet = HashSetPool<Vec3Int>.Get();
			List<Vec3Int> positions = GetPositions(startPosition, size, originalAngle, usePool: true);
			foreach (Vec3Int item in positions)
			{
				hashSet.Add(new Vec3Int(item.x + 1, item.y, item.z));
				hashSet.Add(new Vec3Int(item.x - 1, item.y, item.z));
				hashSet.Add(new Vec3Int(item.x, item.y, item.z + 1));
				hashSet.Add(new Vec3Int(item.x, item.y, item.z - 1));
				hashSet.Add(new Vec3Int(item.x + 1, item.y, item.z + 1));
				hashSet.Add(new Vec3Int(item.x + 1, item.y, item.z - 1));
				hashSet.Add(new Vec3Int(item.x - 1, item.y, item.z + 1));
				hashSet.Add(new Vec3Int(item.x - 1, item.y, item.z - 1));
			}
			foreach (Vec3Int item2 in positions)
			{
				hashSet.Remove(item2);
			}
			ListPool<Vec3Int>.Return(positions);
			return hashSet;
		}

		public List<Vec3Int> GetSurroundingPositionsRange(Vec3Int startPosition, Vec3Int size, float originalAngle, int range, bool removeCorners = false)
		{
			HashSet<Vec3Int> hashSet = new HashSet<Vec3Int>();
			List<Vec3Int> list = GetPositionsJanitor(startPosition, size, originalAngle).ToList();
			foreach (Vec3Int item in list)
			{
				for (int i = 1; i <= range; i++)
				{
					hashSet.Add(new Vec3Int(item.x + i, item.y, item.z));
					hashSet.Add(new Vec3Int(item.x - i, item.y, item.z));
					hashSet.Add(new Vec3Int(item.x, item.y, item.z + i));
					hashSet.Add(new Vec3Int(item.x, item.y, item.z - i));
					hashSet.Add(new Vec3Int(item.x + i, item.y, item.z + i));
					hashSet.Add(new Vec3Int(item.x + i, item.y, item.z - i));
					hashSet.Add(new Vec3Int(item.x - i, item.y, item.z + i));
					hashSet.Add(new Vec3Int(item.x - i, item.y, item.z - i));
				}
			}
			foreach (Vec3Int item2 in list)
			{
				hashSet.Remove(item2);
			}
			if (removeCorners)
			{
				return RemoveCornerPositions(hashSet.ToList());
			}
			return hashSet.Distinct().ToList();
		}

		[MustDisposeResource]
		public PooledList<Vec3Int> GetForbiddenPositions(BaseBuildingBlueprint blueprint, PooledList<Vec3Int> buildingPositions, Vec3Int startPosition, float originalAngle)
		{
			PooledList<Vec3Int> janitor = ListPool<Vec3Int>.GetJanitor();
			if (buildingPositions.Count == 0)
			{
				return janitor;
			}
			int num;
			for (num = Mathf.Abs((int)originalAngle); num >= 360; num -= 360)
			{
			}
			int num2 = buildingPositions.Min((Vec3Int pos) => pos.x);
			int num3 = buildingPositions.Max((Vec3Int pos) => pos.x);
			int num4 = buildingPositions.Min((Vec3Int pos) => pos.z);
			int num5 = buildingPositions.Max((Vec3Int pos) => pos.z);
			int y = startPosition.y;
			ForbiddenAreaInfo forbiddenAreaInfo = blueprint.ForbiddenAreaInfo;
			int forbiddenAreaFrontOffset = forbiddenAreaInfo.ForbiddenAreaFrontOffset;
			if (forbiddenAreaFrontOffset > 0)
			{
				if (num == 0)
				{
					Vec3Int start = new Vec3Int(num2, y, num5 + 1);
					Vec3Int size = new Vec3Int(blueprint.Size.x, blueprint.Size.y, forbiddenAreaFrontOffset);
					janitor.AddRange(GetPositions(start, size));
				}
				if (num == 90)
				{
					Vec3Int start2 = new Vec3Int(num3 + 1, y, num4);
					Vec3Int size2 = new Vec3Int(forbiddenAreaFrontOffset, blueprint.Size.y, blueprint.Size.x);
					janitor.AddRange(GetPositions(start2, size2));
				}
				if (num == 180)
				{
					Vec3Int start3 = new Vec3Int(num2, y, num4 - forbiddenAreaFrontOffset);
					Vec3Int size3 = new Vec3Int(blueprint.Size.x, blueprint.Size.y, forbiddenAreaFrontOffset);
					janitor.AddRange(GetPositions(start3, size3));
				}
				if (num == 270)
				{
					Vec3Int start4 = new Vec3Int(num2 - forbiddenAreaFrontOffset, y, num4);
					Vec3Int size4 = new Vec3Int(forbiddenAreaFrontOffset, blueprint.Size.y, blueprint.Size.x);
					janitor.AddRange(GetPositions(start4, size4));
				}
			}
			int forbiddenAreaBackOffset = forbiddenAreaInfo.ForbiddenAreaBackOffset;
			if (forbiddenAreaBackOffset > 0)
			{
				if (num == 0)
				{
					Vec3Int start5 = new Vec3Int(num2, y, num4 - forbiddenAreaBackOffset);
					Vec3Int size5 = new Vec3Int(blueprint.Size.x, blueprint.Size.y, forbiddenAreaBackOffset);
					janitor.AddRange(GetPositions(start5, size5));
				}
				if (num == 90)
				{
					Vec3Int start6 = new Vec3Int(num2 - forbiddenAreaBackOffset, y, num4);
					Vec3Int size6 = new Vec3Int(forbiddenAreaBackOffset, blueprint.Size.y, blueprint.Size.x);
					janitor.AddRange(GetPositions(start6, size6));
				}
				if (num == 180)
				{
					Vec3Int start7 = new Vec3Int(num2, y, num5 + 1);
					Vec3Int size7 = new Vec3Int(blueprint.Size.x, blueprint.Size.y, forbiddenAreaBackOffset);
					janitor.AddRange(GetPositions(start7, size7));
				}
				if (num == 270)
				{
					Vec3Int start8 = new Vec3Int(num3 + 1, y, num4);
					Vec3Int size8 = new Vec3Int(forbiddenAreaBackOffset, blueprint.Size.y, blueprint.Size.x);
					janitor.AddRange(GetPositions(start8, size8));
				}
			}
			int forbiddenAreaRightOffset = forbiddenAreaInfo.ForbiddenAreaRightOffset;
			if (forbiddenAreaRightOffset > 0)
			{
				if (num == 0)
				{
					Vec3Int start9 = new Vec3Int(num3 + 1, y, num4);
					Vec3Int size9 = new Vec3Int(forbiddenAreaRightOffset, blueprint.Size.y, blueprint.Size.z);
					janitor.AddRange(GetPositions(start9, size9));
				}
				if (num == 90)
				{
					Vec3Int start10 = new Vec3Int(num2, y, num4 - forbiddenAreaRightOffset);
					Vec3Int size10 = new Vec3Int(blueprint.Size.z, blueprint.Size.y, forbiddenAreaRightOffset);
					janitor.AddRange(GetPositions(start10, size10));
				}
				if (num == 180)
				{
					Vec3Int start11 = new Vec3Int(num2 - forbiddenAreaRightOffset, y, num4);
					Vec3Int size11 = new Vec3Int(forbiddenAreaRightOffset, blueprint.Size.y, blueprint.Size.z);
					janitor.AddRange(GetPositions(start11, size11));
				}
				if (num == 270)
				{
					Vec3Int start12 = new Vec3Int(num2, y, num5 + 1);
					Vec3Int size12 = new Vec3Int(blueprint.Size.z, blueprint.Size.y, forbiddenAreaRightOffset);
					janitor.AddRange(GetPositions(start12, size12));
				}
			}
			int forbiddenAreaLeftOffset = forbiddenAreaInfo.ForbiddenAreaLeftOffset;
			if (forbiddenAreaLeftOffset > 0)
			{
				if (num == 0)
				{
					Vec3Int start13 = new Vec3Int(num2 - forbiddenAreaLeftOffset, y, num4);
					Vec3Int size13 = new Vec3Int(forbiddenAreaLeftOffset, blueprint.Size.y, blueprint.Size.z);
					janitor.AddRange(GetPositions(start13, size13));
				}
				if (num == 90)
				{
					Vec3Int start14 = new Vec3Int(num2, y, num5 + 1);
					Vec3Int size14 = new Vec3Int(blueprint.Size.z, blueprint.Size.y, forbiddenAreaLeftOffset);
					janitor.AddRange(GetPositions(start14, size14));
				}
				if (num == 180)
				{
					Vec3Int start15 = new Vec3Int(num3 + 1, y, num4);
					Vec3Int size15 = new Vec3Int(forbiddenAreaLeftOffset, blueprint.Size.y, blueprint.Size.z);
					janitor.AddRange(GetPositions(start15, size15));
				}
				if (num == 270)
				{
					Vec3Int start16 = new Vec3Int(num2, y, num4 - forbiddenAreaLeftOffset);
					Vec3Int size16 = new Vec3Int(blueprint.Size.z, blueprint.Size.y, forbiddenAreaLeftOffset);
					janitor.AddRange(GetPositions(start16, size16));
				}
			}
			return janitor;
		}

		public List<Vec3Int> GetPositions(Vec3Int start, Vec3Int size)
		{
			List<Vec3Int> list = new List<Vec3Int>();
			for (int i = start.x; i < start.x + size.x; i++)
			{
				for (int j = start.y; j < start.y + size.y; j++)
				{
					for (int k = start.z; k < start.z + size.z; k++)
					{
						list.Add(new Vec3Int(i, j, k));
					}
				}
			}
			return list;
		}

		public List<Vec3Int> GetForbiddenPositionsOLD(List<Vec3Int> buildingPositions, Vec3Int startPosition, Vec3Int forbiddenAmount, float originalAngle, bool usePool = false)
		{
			if (forbiddenAmount == Vec3Int.zero)
			{
				return new List<Vec3Int>();
			}
			List<Vec3Int> list = ((!usePool) ? new List<Vec3Int>() : ListPool<Vec3Int>.Get());
			int num;
			for (num = Mathf.Abs((int)originalAngle); num >= 360; num -= 360)
			{
			}
			int num2 = buildingPositions.Min((Vec3Int pos) => pos.x);
			int num3 = buildingPositions.Max((Vec3Int pos) => pos.x);
			int num4 = buildingPositions.Min((Vec3Int pos) => pos.z);
			int num5 = buildingPositions.Max((Vec3Int pos) => pos.z);
			switch (num)
			{
			case 0:
			case 180:
			{
				for (int num9 = num2 - forbiddenAmount.x; num9 <= num3 + forbiddenAmount.x; num9++)
				{
					for (int num10 = num4 - forbiddenAmount.z; num10 <= num5 + forbiddenAmount.z; num10++)
					{
						for (int num11 = startPosition.y; num11 <= startPosition.y + forbiddenAmount.y; num11++)
						{
							Vec3Int item2 = new Vec3Int(num9, num11, num10);
							if (!buildingPositions.Contains(item2))
							{
								list.Add(item2);
							}
						}
					}
				}
				return list;
			}
			case 90:
			case 270:
			{
				for (int num6 = num2 - forbiddenAmount.z; num6 <= num3 + forbiddenAmount.z; num6++)
				{
					for (int num7 = num4 - forbiddenAmount.x; num7 <= num5 + forbiddenAmount.x; num7++)
					{
						for (int num8 = startPosition.y; num8 <= startPosition.y + forbiddenAmount.y; num8++)
						{
							Vec3Int item = new Vec3Int(num6, num8, num7);
							if (!buildingPositions.Contains(item))
							{
								list.Add(item);
							}
						}
					}
				}
				return list;
			}
			default:
				return list;
			}
		}

		public List<Vec3Int> GetPositions(Vec3Int startPosition, Vec3Int size, float originalAngle, bool usePool = false)
		{
			List<Vec3Int> list = ((!usePool) ? new List<Vec3Int>() : ListPool<Vec3Int>.Get());
			int num;
			for (num = Mathf.Abs((int)originalAngle); num >= 360; num -= 360)
			{
			}
			int x = startPosition.x;
			int z = startPosition.z;
			int y = startPosition.y;
			int num2 = y + size.y;
			if (num == 0)
			{
				for (int i = x; i < x + size.x; i++)
				{
					for (int j = z; j < z + size.z; j++)
					{
						for (int k = y; k < num2; k++)
						{
							list.Add(new Vec3Int(i, k, j));
						}
					}
				}
			}
			if (num == 90)
			{
				for (int l = x; l < x + size.z; l++)
				{
					for (int num3 = z; num3 > z - size.x; num3--)
					{
						for (int m = y; m < num2; m++)
						{
							list.Add(new Vec3Int(l, m, num3));
						}
					}
				}
			}
			if (num == 180)
			{
				for (int num4 = x; num4 > x - size.x; num4--)
				{
					for (int num5 = z; num5 > z - size.z; num5--)
					{
						for (int n = y; n < num2; n++)
						{
							list.Add(new Vec3Int(num4, n, num5));
						}
					}
				}
			}
			if (num == 270)
			{
				for (int num6 = x; num6 > x - size.z; num6--)
				{
					for (int num7 = z; num7 < z + size.x; num7++)
					{
						for (int num8 = y; num8 < num2; num8++)
						{
							list.Add(new Vec3Int(num6, num8, num7));
						}
					}
				}
			}
			return list;
		}

		[MustDisposeResource]
		public PooledList<Vec3Int> GetPositionsJanitor(Vec3Int startPosition, Vec3Int size, float originalAngle)
		{
			PooledList<Vec3Int> janitor = ListPool<Vec3Int>.GetJanitor();
			int num;
			for (num = Mathf.Abs((int)originalAngle); num >= 360; num -= 360)
			{
			}
			int x = startPosition.x;
			int z = startPosition.z;
			int y = startPosition.y;
			int num2 = y + size.y;
			if (num == 0)
			{
				for (int i = x; i < x + size.x; i++)
				{
					for (int j = z; j < z + size.z; j++)
					{
						for (int k = y; k < num2; k++)
						{
							janitor.Add(new Vec3Int(i, k, j));
						}
					}
				}
			}
			if (num == 90)
			{
				for (int l = x; l < x + size.z; l++)
				{
					for (int num3 = z; num3 > z - size.x; num3--)
					{
						for (int m = y; m < num2; m++)
						{
							janitor.Add(new Vec3Int(l, m, num3));
						}
					}
				}
			}
			if (num == 180)
			{
				for (int num4 = x; num4 > x - size.x; num4--)
				{
					for (int num5 = z; num5 > z - size.z; num5--)
					{
						for (int n = y; n < num2; n++)
						{
							janitor.Add(new Vec3Int(num4, n, num5));
						}
					}
				}
			}
			if (num == 270)
			{
				for (int num6 = x; num6 > x - size.z; num6--)
				{
					for (int num7 = z; num7 < z + size.x; num7++)
					{
						for (int num8 = y; num8 < num2; num8++)
						{
							janitor.Add(new Vec3Int(num6, num8, num7));
						}
					}
				}
			}
			return janitor;
		}

		public List<Vec3Int> GetPositions(Vec3Int startPosition, Vec3Int size, float originalAngle)
		{
			List<Vec3Int> list = new List<Vec3Int>();
			int num;
			for (num = Mathf.Abs((int)originalAngle); num >= 360; num -= 360)
			{
			}
			int x = startPosition.x;
			int z = startPosition.z;
			int y = startPosition.y;
			int num2 = y + size.y;
			if (num == 0)
			{
				for (int i = x; i < x + size.x; i++)
				{
					for (int j = z; j < z + size.z; j++)
					{
						for (int k = y; k < num2; k++)
						{
							list.Add(new Vec3Int(i, k, j));
						}
					}
				}
			}
			if (num == 90)
			{
				for (int l = x; l < x + size.z; l++)
				{
					for (int num3 = z; num3 > z - size.x; num3--)
					{
						for (int m = y; m < num2; m++)
						{
							list.Add(new Vec3Int(l, m, num3));
						}
					}
				}
			}
			if (num == 180)
			{
				for (int num4 = x; num4 > x - size.x; num4--)
				{
					for (int num5 = z; num5 > z - size.z; num5--)
					{
						for (int n = y; n < num2; n++)
						{
							list.Add(new Vec3Int(num4, n, num5));
						}
					}
				}
			}
			if (num == 270)
			{
				for (int num6 = x; num6 > x - size.z; num6--)
				{
					for (int num7 = z; num7 < z + size.x; num7++)
					{
						for (int num8 = y; num8 < num2; num8++)
						{
							list.Add(new Vec3Int(num6, num8, num7));
						}
					}
				}
			}
			return list;
		}

		public Bounds GetBoundsCornerStart(Vector3 cornerPosition, Vec3Int size, float originalAngle, int height)
		{
			return (int)originalAngle switch
			{
				0 => new Bounds(new Vector3(cornerPosition.x + (float)(size.x - 1) / 2f, cornerPosition.y + (float)height / 2f, cornerPosition.z + (float)(size.z - 1) / 2f), (Vector3)size), 
				90 => new Bounds(new Vector3(cornerPosition.x + (float)(size.z - 1) / 2f, cornerPosition.y + (float)height / 2f, cornerPosition.z - (float)(size.x - 1) / 2f), new Vector3(size.z, size.y, size.x)), 
				180 => new Bounds(new Vector3(cornerPosition.x - (float)(size.x - 1) / 2f, cornerPosition.y + (float)height / 2f, cornerPosition.z - (float)(size.z - 1) / 2f), (Vector3)size), 
				_ => new Bounds(new Vector3(cornerPosition.x - (float)(size.z - 1) / 2f, cornerPosition.y + (float)height / 2f, cornerPosition.z + (float)(size.x - 1) / 2f), new Vector3(size.z, size.y, size.x)), 
			};
		}

		public void ForEachPositionInRange(Vector3 center, float range, Action<Vec3Int> callback)
		{
			center.x += 0.5f;
			center.z += 0.5f;
			Vector3 vector = center;
			vector.x = Mathf.Floor(vector.x + range / 2f);
			vector.z = Mathf.Floor(vector.z - range / 2f);
			Vector3 vector2 = center;
			vector2.x = Mathf.Floor(vector2.x - range / 2f);
			vector2.z = Mathf.Floor(vector2.z + range / 2f);
			if (vector.x > vector2.x)
			{
				float x = vector.x;
				vector.x = vector2.x;
				vector2.x = x;
			}
			if (vector.z > vector2.z)
			{
				float z = vector.z;
				vector.z = vector2.z;
				vector2.z = z;
			}
			for (int i = (int)vector.x; (float)i <= vector2.x; i++)
			{
				for (int j = (int)vector.z; (float)j <= vector2.z; j++)
				{
					callback(new Vec3Int(i, Mathf.FloorToInt(vector.y), j));
				}
			}
		}

		private List<Vec3Int> RemoveCornerPositions(List<Vec3Int> list)
		{
			Vec3Int vec3Int = list.First((Vec3Int v1) => v1.x == list.Min((Vec3Int vec3Int5) => vec3Int5.x) && v1.z == list.Min((Vec3Int vec3Int5) => vec3Int5.z));
			Vec3Int vec3Int2 = list.First((Vec3Int v1) => v1.x == list.Max((Vec3Int vec3Int5) => vec3Int5.x) && v1.z == list.Min((Vec3Int vec3Int5) => vec3Int5.z));
			Vec3Int vec3Int3 = list.First((Vec3Int v1) => v1.x == list.Min((Vec3Int vec3Int5) => vec3Int5.x) && v1.z == list.Max((Vec3Int vec3Int5) => vec3Int5.z));
			Vec3Int vec3Int4 = list.First((Vec3Int v1) => v1.x == list.Max((Vec3Int vec3Int5) => vec3Int5.x) && v1.z == list.Max((Vec3Int vec3Int5) => vec3Int5.z));
			list.RemoveMultiple(vec3Int, vec3Int2, vec3Int3, vec3Int4);
			return list;
		}
	}
}
