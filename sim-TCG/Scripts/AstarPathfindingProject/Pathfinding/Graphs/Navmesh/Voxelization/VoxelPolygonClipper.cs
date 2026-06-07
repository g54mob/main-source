using Unity.Burst;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization
{
	internal struct VoxelPolygonClipper
	{
		public unsafe fixed float x[8];

		public unsafe fixed float y[8];

		public unsafe fixed float z[8];

		public int n;

		public unsafe Vector3 this[int i]
		{
			set
			{
				x[i] = value.x;
				y[i] = value.y;
				z[i] = value.z;
			}
		}

		public unsafe void ClipPolygonAlongX([NoAlias] ref VoxelPolygonClipper result, float multi, float offset)
		{
			int num = 0;
			float num2 = multi * x[n - 1] + offset;
			int i = 0;
			int num3 = n - 1;
			for (; i < n; i++)
			{
				float num4 = multi * x[i] + offset;
				bool num5 = num2 >= 0f;
				bool flag = num4 >= 0f;
				if (num5 != flag)
				{
					float num6 = num2 / (num2 - num4);
					result.x[num] = x[num3] + (x[i] - x[num3]) * num6;
					result.y[num] = y[num3] + (y[i] - y[num3]) * num6;
					result.z[num] = z[num3] + (z[i] - z[num3]) * num6;
					num++;
				}
				if (flag)
				{
					result.x[num] = x[i];
					result.y[num] = y[i];
					result.z[num] = z[i];
					num++;
				}
				num2 = num4;
				num3 = i;
			}
			result.n = num;
		}

		public unsafe void ClipPolygonAlongZWithYZ([NoAlias] ref VoxelPolygonClipper result, float multi, float offset)
		{
			int num = 0;
			Hint.Assume(n >= 0);
			Hint.Assume(n <= 8);
			float num2 = multi * z[n - 1] + offset;
			int i = 0;
			int num3 = n - 1;
			for (; i < n; i++)
			{
				float num4 = multi * z[i] + offset;
				bool num5 = num2 >= 0f;
				bool flag = num4 >= 0f;
				if (num5 != flag)
				{
					float num6 = num2 / (num2 - num4);
					result.y[num] = y[num3] + (y[i] - y[num3]) * num6;
					result.z[num] = z[num3] + (z[i] - z[num3]) * num6;
					num++;
				}
				if (flag)
				{
					result.y[num] = y[i];
					result.z[num] = z[i];
					num++;
				}
				num2 = num4;
				num3 = i;
			}
			result.n = num;
		}

		public unsafe void ClipPolygonAlongZWithY([NoAlias] ref VoxelPolygonClipper result, float multi, float offset)
		{
			int num = 0;
			Hint.Assume(n >= 3);
			Hint.Assume(n <= 8);
			float num2 = multi * z[n - 1] + offset;
			int i = 0;
			int num3 = n - 1;
			for (; i < n; i++)
			{
				float num4 = multi * z[i] + offset;
				bool num5 = num2 >= 0f;
				bool flag = num4 >= 0f;
				if (num5 != flag)
				{
					float num6 = num2 / (num2 - num4);
					result.y[num] = y[num3] + (y[i] - y[num3]) * num6;
					num++;
				}
				if (flag)
				{
					result.y[num] = y[i];
					num++;
				}
				num2 = num4;
				num3 = i;
			}
			result.n = num;
		}
	}
}
