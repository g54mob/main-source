using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.Core
{
	public class TriangulationHelper
	{
		public static int PolygonizeOutline(SquareCell cell, Outline[] outlines, float isoLevel)
		{
			int result = 0;
			bool num = cell.Data1 >= isoLevel;
			bool flag = cell.Data2 >= isoLevel;
			bool flag2 = cell.Data3 >= isoLevel;
			bool flag3 = cell.Data4 >= isoLevel;
			bool flag4 = num && !flag && !flag2 && !flag3;
			bool flag5 = !num && flag && !flag2 && !flag3;
			bool flag6 = num && flag && !flag2 && !flag3;
			bool flag7 = !num && !flag && !flag2 && flag3;
			bool flag8 = num && !flag && !flag2 && flag3;
			bool flag9 = !num && flag && !flag2 && flag3;
			bool flag10 = num && flag && !flag2 && flag3;
			bool flag11 = !num && !flag && flag2 && !flag3;
			bool flag12 = num && !flag && flag2 && !flag3;
			bool flag13 = !num && flag && flag2 && !flag3;
			bool flag14 = num && flag && flag2 && !flag3;
			bool flag15 = !num && !flag && flag2 && flag3;
			bool flag16 = num && !flag && flag2 && flag3;
			bool num2 = !num && flag && flag2 && flag3;
			if (flag4)
			{
				Vector2 a = VertexInterp(isoLevel, cell.Position3, cell.Position1, cell.Data3, cell.Data1);
				Vector2 b = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				outlines[0].A = a;
				outlines[0].B = b;
				result = 1;
			}
			if (flag5)
			{
				Vector2 a2 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 b2 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				outlines[0].A = a2;
				outlines[0].B = b2;
				result = 1;
			}
			if (flag6)
			{
				Vector2 a3 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				Vector2 b3 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				outlines[0].A = a3;
				outlines[0].B = b3;
				result = 1;
			}
			if (flag7)
			{
				Vector2 a4 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				Vector2 b4 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				outlines[0].A = a4;
				outlines[0].B = b4;
				result = 1;
			}
			if (flag8)
			{
				Vector2 a5 = VertexInterp(isoLevel, cell.Position4, cell.Position2, cell.Data4, cell.Data2);
				Vector2 b5 = VertexInterp(isoLevel, cell.Position4, cell.Position3, cell.Data4, cell.Data3);
				outlines[0].A = a5;
				outlines[0].B = b5;
				Vector2 a6 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				Vector2 b6 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				outlines[1].A = a6;
				outlines[1].B = b6;
				result = 2;
			}
			if (flag9)
			{
				Vector2 a7 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 b7 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				outlines[0].A = a7;
				outlines[0].B = b7;
				result = 1;
			}
			if (flag10)
			{
				Vector2 a8 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				Vector2 b8 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				outlines[0].A = a8;
				outlines[0].B = b8;
				result = 1;
			}
			if (flag11)
			{
				Vector2 a9 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				Vector2 b9 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				outlines[0].A = a9;
				outlines[0].B = b9;
				result = 1;
			}
			if (flag12)
			{
				Vector2 a10 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				Vector2 b10 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				outlines[0].A = a10;
				outlines[0].B = b10;
				result = 1;
			}
			if (flag13)
			{
				Vector2 a11 = VertexInterp(isoLevel, cell.Position2, cell.Position1, cell.Data2, cell.Data1);
				Vector2 b11 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				outlines[0].A = a11;
				outlines[0].B = b11;
				Vector2 a12 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				Vector2 b12 = VertexInterp(isoLevel, cell.Position3, cell.Position1, cell.Data3, cell.Data1);
				outlines[1].A = a12;
				outlines[1].B = b12;
				result = 2;
			}
			if (flag14)
			{
				Vector2 a13 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				Vector2 b13 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				outlines[0].A = a13;
				outlines[0].B = b13;
				result = 1;
			}
			if (flag15)
			{
				Vector2 a14 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				Vector2 b14 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				outlines[0].A = a14;
				outlines[0].B = b14;
				result = 1;
			}
			if (flag16)
			{
				Vector2 a15 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				Vector2 b15 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				outlines[0].A = a15;
				outlines[0].B = b15;
				result = 1;
			}
			if (num2)
			{
				Vector2 a16 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 b16 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				outlines[0].A = a16;
				outlines[0].B = b16;
				result = 1;
			}
			return result;
		}

		public static int Polygonize(SquareCell cell, Triangle[] triangles, float isoLevel, int materialType)
		{
			int result = 0;
			bool flag = cell.Data1 >= isoLevel;
			bool flag2 = cell.Data2 >= isoLevel;
			bool flag3 = cell.Data3 >= isoLevel;
			bool flag4 = cell.Data4 >= isoLevel;
			float num = 0.99f;
			if (cell.Type1 != materialType)
			{
				if (cell.Data1 >= isoLevel)
				{
					cell.Data1 = isoLevel * num;
				}
				flag = false;
			}
			if (cell.Type2 != materialType)
			{
				if (cell.Data2 >= isoLevel)
				{
					cell.Data2 = isoLevel * num;
				}
				flag2 = false;
			}
			if (cell.Type3 != materialType)
			{
				if (cell.Data3 >= isoLevel)
				{
					cell.Data3 = isoLevel * num;
				}
				flag3 = false;
			}
			if (cell.Type4 != materialType)
			{
				if (cell.Data4 >= isoLevel)
				{
					cell.Data4 = isoLevel * num;
				}
				flag4 = false;
			}
			bool flag5 = flag && !flag2 && !flag3 && !flag4;
			bool flag6 = !flag && flag2 && !flag3 && !flag4;
			bool flag7 = flag && flag2 && !flag3 && !flag4;
			bool flag8 = !flag && !flag2 && !flag3 && flag4;
			bool flag9 = flag && !flag2 && !flag3 && flag4;
			bool flag10 = !flag && flag2 && !flag3 && flag4;
			bool flag11 = flag && flag2 && !flag3 && flag4;
			bool flag12 = !flag && !flag2 && flag3 && !flag4;
			bool flag13 = flag && !flag2 && flag3 && !flag4;
			bool flag14 = !flag && flag2 && flag3 && !flag4;
			bool flag15 = flag && flag2 && flag3 && !flag4;
			bool flag16 = !flag && !flag2 && flag3 && flag4;
			bool flag17 = flag && !flag2 && flag3 && flag4;
			bool flag18 = !flag && flag2 && flag3 && flag4;
			bool num2 = flag && flag2 && flag3 && flag4;
			if (flag5)
			{
				Vector2 position = VertexInterp(isoLevel, cell.Position3, cell.Position1, cell.Data3, cell.Data1);
				Vector2 position2 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 position3 = cell.Position1;
				triangles[0].Position1 = position;
				triangles[0].Position2 = position2;
				triangles[0].Position3 = position3;
				result = 1;
			}
			if (flag6)
			{
				Vector2 position4 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 position5 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				Vector2 position6 = cell.Position2;
				triangles[0].Position1 = position4;
				triangles[0].Position2 = position5;
				triangles[0].Position3 = position6;
				result = 1;
			}
			if (flag7)
			{
				Vector2 position7 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				Vector2 position8 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				Vector2 position9 = cell.Position1;
				Vector2 position10 = cell.Position2;
				triangles[0].Position1 = position7;
				triangles[0].Position2 = position10;
				triangles[0].Position3 = position9;
				triangles[1].Position1 = position7;
				triangles[1].Position2 = position8;
				triangles[1].Position3 = position10;
				result = 2;
			}
			if (flag8)
			{
				Vector2 position11 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				Vector2 position12 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				Vector2 position13 = cell.Position4;
				triangles[0].Position1 = position11;
				triangles[0].Position2 = position12;
				triangles[0].Position3 = position13;
				result = 1;
			}
			if (flag9)
			{
				Vector2 position14 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 position15 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				Vector2 position16 = VertexInterp(isoLevel, cell.Position4, cell.Position2, cell.Data4, cell.Data2);
				Vector2 position17 = VertexInterp(isoLevel, cell.Position4, cell.Position3, cell.Data4, cell.Data3);
				Vector2 position18 = cell.Position4;
				Vector2 position19 = cell.Position1;
				triangles[0].Position1 = position18;
				triangles[0].Position2 = position16;
				triangles[0].Position3 = position17;
				triangles[1].Position1 = position15;
				triangles[1].Position2 = position14;
				triangles[1].Position3 = position19;
				result = 2;
			}
			if (flag10)
			{
				Vector2 vector = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				Vector2 position20 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				triangles[0].Position1 = vector;
				triangles[0].Position2 = cell.Position4;
				triangles[0].Position3 = cell.Position2;
				triangles[1].Position1 = position20;
				triangles[1].Position2 = vector;
				triangles[1].Position3 = cell.Position2;
				result = 2;
			}
			if (flag11)
			{
				Vector2 vector2 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				Vector2 vector3 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				triangles[0].Position1 = vector3;
				triangles[0].Position2 = cell.Position4;
				triangles[0].Position3 = cell.Position2;
				triangles[1].Position1 = vector2;
				triangles[1].Position2 = vector3;
				triangles[1].Position3 = cell.Position2;
				triangles[2].Position1 = cell.Position1;
				triangles[2].Position2 = vector2;
				triangles[2].Position3 = cell.Position2;
				result = 3;
			}
			if (flag12)
			{
				Vector2 position21 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				Vector2 position22 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				triangles[0].Position1 = position22;
				triangles[0].Position2 = position21;
				triangles[0].Position3 = cell.Position3;
				result = 1;
			}
			if (flag13)
			{
				Vector2 position23 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 position24 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				triangles[0].Position1 = cell.Position1;
				triangles[0].Position2 = cell.Position3;
				triangles[0].Position3 = position23;
				triangles[1].Position1 = cell.Position3;
				triangles[1].Position2 = position24;
				triangles[1].Position3 = position23;
				result = 2;
			}
			if (flag14)
			{
				Vector2 position25 = VertexInterp(isoLevel, cell.Position2, cell.Position1, cell.Data2, cell.Data1);
				Vector2 position26 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				Vector2 position27 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				Vector2 position28 = VertexInterp(isoLevel, cell.Position3, cell.Position1, cell.Data3, cell.Data1);
				triangles[0].Position1 = position25;
				triangles[0].Position2 = position27;
				triangles[0].Position3 = cell.Position2;
				triangles[1].Position1 = cell.Position3;
				triangles[1].Position2 = position26;
				triangles[1].Position3 = position28;
				result = 2;
			}
			if (flag15)
			{
				Vector2 vector4 = VertexInterp(isoLevel, cell.Position3, cell.Position4, cell.Data3, cell.Data4);
				Vector2 position29 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				triangles[0].Position1 = cell.Position1;
				triangles[0].Position2 = position29;
				triangles[0].Position3 = cell.Position2;
				triangles[1].Position1 = vector4;
				triangles[1].Position2 = position29;
				triangles[1].Position3 = cell.Position1;
				triangles[2].Position1 = cell.Position3;
				triangles[2].Position2 = vector4;
				triangles[2].Position3 = cell.Position1;
				result = 3;
			}
			if (flag16)
			{
				Vector2 position30 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				Vector2 position31 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				triangles[0].Position1 = cell.Position3;
				triangles[0].Position2 = cell.Position4;
				triangles[0].Position3 = position30;
				triangles[1].Position1 = cell.Position4;
				triangles[1].Position2 = position31;
				triangles[1].Position3 = position30;
				result = 2;
			}
			if (flag17)
			{
				Vector2 vector5 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 position32 = VertexInterp(isoLevel, cell.Position2, cell.Position4, cell.Data2, cell.Data4);
				triangles[0].Position1 = vector5;
				triangles[0].Position2 = cell.Position1;
				triangles[0].Position3 = cell.Position3;
				triangles[1].Position1 = position32;
				triangles[1].Position2 = vector5;
				triangles[1].Position3 = cell.Position3;
				triangles[2].Position1 = position32;
				triangles[2].Position2 = cell.Position3;
				triangles[2].Position3 = cell.Position4;
				result = 3;
			}
			if (flag18)
			{
				Vector2 position33 = VertexInterp(isoLevel, cell.Position1, cell.Position2, cell.Data1, cell.Data2);
				Vector2 vector6 = VertexInterp(isoLevel, cell.Position1, cell.Position3, cell.Data1, cell.Data3);
				triangles[0].Position1 = cell.Position2;
				triangles[0].Position2 = position33;
				triangles[0].Position3 = cell.Position4;
				triangles[1].Position1 = cell.Position4;
				triangles[1].Position2 = position33;
				triangles[1].Position3 = vector6;
				triangles[2].Position1 = vector6;
				triangles[2].Position2 = cell.Position3;
				triangles[2].Position3 = cell.Position4;
				result = 3;
			}
			if (num2)
			{
				triangles[0].Position1 = cell.Position3;
				triangles[0].Position2 = cell.Position2;
				triangles[0].Position3 = cell.Position1;
				triangles[1].Position1 = cell.Position2;
				triangles[1].Position2 = cell.Position3;
				triangles[1].Position3 = cell.Position4;
				result = 2;
			}
			return result;
		}

		public static Vector2 VertexInterp(float isolevel, Vector2 p1, Vector2 p2, float valp1, float valp2)
		{
			Vector2 zero = Vector2.zero;
			if ((double)Math.Abs(isolevel - valp1) < 1E-05)
			{
				return p1;
			}
			if ((double)Math.Abs(isolevel - valp2) < 1E-05)
			{
				return p2;
			}
			if ((double)Math.Abs(valp1 - valp2) < 1E-05)
			{
				return p1;
			}
			float num = (isolevel - valp1) / (valp2 - valp1);
			zero.x = p1.x + num * (p2.x - p1.x);
			zero.y = p1.y + num * (p2.y - p1.y);
			return zero;
		}

		public static float GetVoxelVolumeForSphere(Vector3 voxelPosition, Vector3 sphereOrigin, float sphereRadius)
		{
			float t = (voxelPosition - sphereOrigin).sqrMagnitude / (sphereRadius * sphereRadius);
			return Mathf.Clamp01(Mathf.Lerp(1f, 0f, t));
		}
	}
}
