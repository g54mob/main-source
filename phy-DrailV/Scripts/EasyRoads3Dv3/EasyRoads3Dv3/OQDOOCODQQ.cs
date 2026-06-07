using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OQDOOCODQQ : MonoBehaviour
	{
		public static void OCDOOODQCD(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[1], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[1], num2));
			list.Add(sourceVecs[2][0]);
			float y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			vector = sourceVecs[3][0] + normalized * corner.curbDepth;
			list.Add(sourceVecs[3][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[4], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			vector.y = 0f;
			list.Add(vector);
			list.Add(vector);
			if (corner.outerCurb)
			{
				list2.Add(new Vector2(corner.sidewalkUVs[5], num2));
			}
			else
			{
				list2.Add(new Vector2(0f, num2));
			}
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				if (corner.outerCurb)
				{
					triList[triArrayElement].Add(sourceTris[5][0]);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 6);
					triList[triArrayElement].Add(count + 8);
				}
				triList[triArrayElement].Add(sourceTris[4][0]);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 4);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				if (corner.outerCurb)
				{
					triList[triArrayElement].Add(sourceTris[5][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(count + 6);
				}
				triList[triArrayElement].Add(sourceTris[4][0]);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
			}
		}

		public static void OCOCQDCQDQ(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 1], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 1], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 2], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 2], num2));
			normalized = (sourceVecs[2][0] - sourceVecs[2][1]).normalized;
			vector = sourceVecs[2][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			float y = OQOQCDQDOO(sourceVecs[2][0], vector, num, sourceUVs[2][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 3], y));
			y = num2 - corner.beveledDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 3], y));
			list.Add(sourceVecs[3][0]);
			y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 4], y));
			list.Add(sourceVecs[4][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 4], y));
			normalized = (sourceVecs[5][0] - sourceVecs[5][1]).normalized;
			vector = sourceVecs[5][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			y = OQOQCDQDOO(sourceVecs[5][0], vector, num, sourceUVs[5][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			y = num2 - (corner.sidewalkWidth1 - corner.beveledDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 3], y));
			normalized = (sourceVecs[6][0] - sourceVecs[6][1]).normalized;
			vector = sourceVecs[6][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			y = OQOQCDQDOO(sourceVecs[6][0], vector, num, sourceUVs[6][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 2], y));
			normalized = (sourceVecs[7][0] - sourceVecs[7][1]).normalized;
			vector = sourceVecs[7][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			y = OQOQCDQDOO(sourceVecs[7][0], vector, num, sourceUVs[7][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 1], y));
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(sourceTris[7][0]);
				triList[triArrayElement].Add(sourceTris[6][0]);
				triList[triArrayElement].Add(count + 12);
				triList[triArrayElement].Add(count + 12);
				triList[triArrayElement].Add(sourceTris[6][0]);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(sourceTris[6][0]);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(sourceTris[6][0]);
				triList[triArrayElement].Add(sourceTris[5][0]);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(sourceTris[5][0]);
				triList[triArrayElement].Add(sourceTris[4][0]);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 13);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 13);
				triList[triArrayElement].Add(count + 11);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 11);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 11);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 6);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[7][0]);
				triList[triArrayElement].Add(count + 12);
				triList[triArrayElement].Add(sourceTris[6][0]);
				triList[triArrayElement].Add(count + 12);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(sourceTris[6][0]);
				triList[triArrayElement].Add(sourceTris[6][0]);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(sourceTris[6][0]);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(sourceTris[5][0]);
				triList[triArrayElement].Add(sourceTris[5][0]);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(sourceTris[4][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 13);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 11);
				triList[triArrayElement].Add(count + 13);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 11);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 11);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 7);
			}
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
		}

		public static void OOQDOCDQOD(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[1], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[1], num2));
			list.Add(sourceVecs[2][0]);
			float y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			vector = sourceVecs[3][0] + normalized * corner.curbDepth;
			list.Add(sourceVecs[3][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[4], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			vector.y = 0f;
			list.Add(vector);
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[5], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				if (corner.outerCurb)
				{
					triList[triArrayElement].Add(sourceTris[5][0]);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 6);
					triList[triArrayElement].Add(count + 8);
				}
				triList[triArrayElement].Add(sourceTris[4][0]);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 4);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				if (corner.outerCurb)
				{
					triList[triArrayElement].Add(sourceTris[5][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(count + 6);
				}
				triList[triArrayElement].Add(sourceTris[4][0]);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
			}
		}

		public static void OQOCOODDQC(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			float y = OQOQCDQDOO(sourceVecs[1][0], vector, num, sourceUVs[1][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			y = num2 - corner.beveledDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			list.Add(sourceVecs[2][0]);
			y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			vector = sourceVecs[3][0] + normalized * corner.curbDepth;
			list.Add(sourceVecs[3][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			y = OQOQCDQDOO(sourceVecs[4][0], vector, num, sourceUVs[4][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[4], y));
			y = num2 - (corner.sidewalkWidth1 - corner.beveledDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			normalized = (sourceVecs[5][0] - sourceVecs[5][1]).normalized;
			vector = sourceVecs[5][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[5], num2));
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				if (corner.outerCurb)
				{
					triList[triArrayElement].Add(sourceTris[5][0]);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 6);
					triList[triArrayElement].Add(count + 8);
				}
				triList[triArrayElement].Add(sourceTris[4][0]);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 4);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				if (corner.outerCurb)
				{
					triList[triArrayElement].Add(sourceTris[5][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(sourceTris[4][0]);
					triList[triArrayElement].Add(count + 8);
					triList[triArrayElement].Add(count + 6);
				}
				triList[triArrayElement].Add(sourceTris[4][0]);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
			}
		}

		public static void ODDDCDOOCO(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			Vector3 vector2 = sourceVecs[sourceVecs.Count - 1][0];
			vector2.y = 0f;
			normalized = (vector2 - sourceVecs[0][0]).normalized;
			Vector3 item = vector + normalized * corner.sidewalkWidth1;
			list.Add(item);
			list.Add(item);
			list2.Add(new Vector2(corner.sidewalkUVs[3], num2));
			float y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			list.Add(sourceVecs[1][0]);
			y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			list.Add(sourceVecs[2][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 4);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
			}
		}

		public static void OOQCOOOCQO(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[1], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[1], num2));
			list.Add(sourceVecs[2][0]);
			float y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			vector = sourceVecs[3][0] + normalized * corner.curbDepth;
			list.Add(sourceVecs[3][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0];
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			vector.y = 0f;
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 6);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 7);
			}
		}

		public static void OQQOCDDDDO(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[1], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[1], num2));
			normalized = (sourceVecs[2][0] - sourceVecs[2][1]).normalized;
			vector = sourceVecs[2][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			float y = OQOQCDQDOO(sourceVecs[2][0], vector, num, sourceUVs[2][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			y = num2 - corner.beveledDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			list.Add(sourceVecs[3][0]);
			y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[3], y));
			list.Add(sourceVecs[4][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[3], y));
			list.Add(sourceVecs[5][0]);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[3], y));
			normalized = (sourceVecs[5][0] - sourceVecs[5][1]).normalized;
			vector = sourceVecs[5][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			normalized = (sourceVecs[5][0] - sourceVecs[5][1]).normalized;
			vector = sourceVecs[5][0] + normalized * corner.curbDepth;
			vector.y = corner.beveledHeight;
			list.Add(vector);
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			vector.y = 0f;
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 11);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 8);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[3][0]);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(count + 11);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 10);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 9);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(count + 9);
			}
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
		}

		public static void OCQOCOQDOQ(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			float y = OQOQCDQDOO(sourceVecs[1][0], vector, num, sourceUVs[1][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			y = num2 - corner.beveledDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			list.Add(sourceVecs[2][0]);
			y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			vector = sourceVecs[3][0] + normalized * corner.curbDepth;
			list.Add(sourceVecs[3][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0] + normalized * corner.curbDepth;
			vector.y = corner.beveledHeight;
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0] + normalized * corner.curbDepth;
			vector.y = 0f;
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			vector = sourceVecs[4][0];
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 8);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(count + 6);
			}
		}

		public static void OCQDCDOQCC(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			float y = OQOQCDQDOO(sourceVecs[1][0], vector, num, sourceUVs[1][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			y = num2 - corner.beveledDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			list.Add(sourceVecs[2][0]);
			y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			vector = sourceVecs[3][0] + normalized * corner.curbDepth;
			list.Add(sourceVecs[3][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			normalized = (sourceVecs[4][0] - sourceVecs[4][1]).normalized;
			vector = sourceVecs[4][0] + normalized * corner.curbDepth;
			vector.y = 0f;
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			vector = sourceVecs[4][0];
			list.Add(vector);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 8);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(sourceTris[2][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 7);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 6);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 8);
				triList[triArrayElement].Add(count + 6);
			}
		}

		public static void OODCQOCCCC(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = OQOQCDQDOO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			Vector3 vector2 = sourceVecs[sourceVecs.Count - 1][0];
			vector2.y = 0f;
			normalized = (vector2 - sourceVecs[0][0]).normalized;
			Vector3 item = vector + normalized * corner.sidewalkWidth1;
			list.Add(item);
			float y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			list.Add(sourceVecs[1][0]);
			y = num2 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			list.Add(sourceVecs[2][0]);
			y = num2 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			list.Add(sourceVecs[3][0]);
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if (leftrightroad == 0)
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 5);
				triList[triArrayElement].Add(count + 4);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][0]);
				triList[triArrayElement].Add(sourceTris[1][0]);
				triList[triArrayElement].Add(count);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 1);
				triList[triArrayElement].Add(count + 3);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 2);
				triList[triArrayElement].Add(count + 4);
				triList[triArrayElement].Add(count + 5);
			}
		}

		public static float OQOQCDQDOO(Vector3 v1, Vector3 v2, float uvRatio, float startUV, float dir)
		{
			float num = Vector3.Distance(v1, v2);
			return startUV + dir * num / uvRatio;
		}
	}
}
