using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OOODQCODCC : MonoBehaviour
	{
		public static void OODOODDDOD(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, int startEnd, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			int num2 = 0;
			Vector3 vector;
			Vector3 vector2;
			Vector3 normalized;
			Vector3 vector3;
			float y;
			if (!hardEdge)
			{
				float num3 = 0f;
				if (startEnd == 0)
				{
					vector = sourceVecs[0][0];
					vector2 = sourceVecs[0][1];
					num2 = 0;
				}
				else
				{
					vector = sourceVecs[0][sourceVecs[0].Count - 1];
					vector2 = sourceVecs[0][sourceVecs[0].Count - 2];
					num2 = 1;
				}
				normalized = (vector - vector2).normalized;
				vector3 = vector + normalized * corner.curbDepth;
				list.Add(vector3);
				list.Add(vector3);
				num3 = ((startEnd != 0) ? ODDOCQQDQO(vector, vector3, num, sourceUVs[0][sourceVecs[0].Count - 1].y, 1f) : ODDOCQQDQO(vector, vector3, num, sourceUVs[0][0].y, -1f));
				list2.Add(new Vector2(corner.sidewalkUVs[0], num3));
				list2.Add(new Vector2(corner.sidewalkUVs[0], num3));
				if (startEnd == 0)
				{
					vector = sourceVecs[1][0];
					vector2 = sourceVecs[1][1];
				}
				else
				{
					vector = sourceVecs[1][sourceVecs[1].Count - 1];
					vector2 = sourceVecs[1][sourceVecs[1].Count - 2];
				}
				normalized = (vector - vector2).normalized;
				vector3 = vector + normalized * corner.curbDepth;
				list.Add(vector3);
				list.Add(vector3);
				list2.Add(new Vector2(corner.sidewalkUVs[1], num3));
				list2.Add(new Vector2(corner.sidewalkUVs[1], num3));
				vector = ((startEnd != 0) ? sourceVecs[2][sourceVecs[2].Count - 1] : sourceVecs[2][0]);
				list.Add(vector);
				y = num3 - corner.curbDepth / num;
				list2.Add(new Vector2(corner.sidewalkUVs[2], y));
				vector = ((startEnd != 0) ? sourceVecs[3][sourceVecs[3].Count - 1] : sourceVecs[3][0]);
				vector3 = vector + normalized * corner.curbDepth;
				list.Add(vector);
				y = num3 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
				list2.Add(new Vector2(corner.sidewalkUVs[2], y));
				if (startEnd == 0)
				{
					vector = sourceVecs[4][0];
					vector2 = sourceVecs[4][1];
				}
				else
				{
					vector = sourceVecs[4][sourceVecs[4].Count - 1];
					vector2 = sourceVecs[4][sourceVecs[4].Count - 2];
				}
				normalized = (vector - vector2).normalized;
				vector3 = vector + normalized * corner.curbDepth;
				list.Add(vector3);
				list.Add(vector3);
				y = num3 - corner.sidewalkWidth1 / num;
				list2.Add(new Vector2(corner.sidewalkUVs[4], num3));
				list2.Add(new Vector2(corner.sidewalkUVs[1], y));
				vector3.y -= corner.curbHeight;
				list.Add(vector3);
				list.Add(vector3);
				if (corner.outerCurb)
				{
					list2.Add(new Vector2(corner.sidewalkUVs[5], num3));
				}
				else
				{
					list2.Add(new Vector2(0f, num3));
				}
				list2.Add(new Vector2(corner.sidewalkUVs[0], y));
				if (scr != null)
				{
					scr.debugVecs.AddRange(list);
				}
				int count = vecs.Count;
				vecs.AddRange(list);
				uvs.AddRange(list2);
				if ((leftrightroad == 0 && startEnd == 0) || (leftrightroad == 1 && startEnd == 1))
				{
					triList[triArrayElement].Add(sourceTris[0][num2]);
					triList[triArrayElement].Add(count);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(count);
					triList[triArrayElement].Add(count + 2);
					triList[triArrayElement].Add(count + 2);
					triList[triArrayElement].Add(sourceTris[2][num2]);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					if (corner.outerCurb)
					{
						triList[triArrayElement].Add(sourceTris[5][num2]);
						triList[triArrayElement].Add(sourceTris[4][num2]);
						triList[triArrayElement].Add(count + 8);
						triList[triArrayElement].Add(sourceTris[4][num2]);
						triList[triArrayElement].Add(count + 6);
						triList[triArrayElement].Add(count + 8);
					}
					triList[triArrayElement].Add(sourceTris[4][num2]);
					triList[triArrayElement].Add(sourceTris[3][num2]);
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
					triList[triArrayElement].Add(sourceTris[0][num2]);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(count);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(count + 2);
					triList[triArrayElement].Add(count);
					triList[triArrayElement].Add(count + 2);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(sourceTris[2][num2]);
					if (corner.outerCurb)
					{
						triList[triArrayElement].Add(sourceTris[5][num2]);
						triList[triArrayElement].Add(count + 8);
						triList[triArrayElement].Add(sourceTris[4][num2]);
						triList[triArrayElement].Add(sourceTris[4][num2]);
						triList[triArrayElement].Add(count + 8);
						triList[triArrayElement].Add(count + 6);
					}
					triList[triArrayElement].Add(sourceTris[4][num2]);
					triList[triArrayElement].Add(count + 6);
					triList[triArrayElement].Add(sourceTris[3][num2]);
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
				return;
			}
			if (startEnd == 0)
			{
				vector = sourceVecs[0][0];
				vector2 = sourceVecs[0][1];
				num2 = 0;
			}
			else
			{
				vector = sourceVecs[0][sourceVecs[0].Count - 1];
				vector2 = sourceVecs[0][sourceVecs[0].Count - 2];
				num2 = 1;
			}
			float num4 = 0f;
			normalized = (vector - vector2).normalized;
			vector3 = vector + normalized * corner.curbDepth;
			list.Add(vector3);
			list.Add(vector3);
			num4 = ((startEnd != 0) ? ODDOCQQDQO(vector, vector3, num, sourceUVs[0][sourceVecs[0].Count - 1].y, 1f) : ODDOCQQDQO(vector, vector3, num, sourceUVs[0][0].y, -1f));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num4));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num4));
			if (startEnd == 0)
			{
				vector = sourceVecs[1][0];
				vector2 = sourceVecs[1][1];
			}
			else
			{
				vector = sourceVecs[1][sourceVecs[1].Count - 1];
				vector2 = sourceVecs[1][sourceVecs[1].Count - 2];
			}
			normalized = (vector - vector2).normalized;
			vector3 = vector + normalized * corner.curbDepth;
			list.Add(vector3);
			list.Add(vector3);
			list2.Add(new Vector2(corner.sidewalkUVs[1], num4));
			list2.Add(new Vector2(corner.sidewalkUVs[1], num4));
			list.Add(vector3);
			list.Add(vector3);
			list2.Add(new Vector2(corner.sidewalkUVs[1], num4));
			list2.Add(new Vector2(corner.sidewalkUVs[1], num4));
			vector = ((startEnd != 0) ? sourceVecs[2][sourceVecs[2].Count - 1] : sourceVecs[2][0]);
			list.Add(vector);
			y = num4 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			vector = ((startEnd != 0) ? sourceVecs[3][sourceVecs[3].Count - 1] : sourceVecs[3][0]);
			vector3 = sourceVecs[3][0] + normalized * corner.curbDepth;
			list.Add(vector);
			y = num4 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			if (startEnd == 0)
			{
				vector = sourceVecs[4][0];
				vector2 = sourceVecs[4][1];
			}
			else
			{
				vector = sourceVecs[4][sourceVecs[4].Count - 1];
				vector2 = sourceVecs[4][sourceVecs[4].Count - 2];
			}
			normalized = (vector - vector2).normalized;
			vector3 = vector + normalized * corner.curbDepth;
			list.Add(vector3);
			list.Add(vector3);
			y = num4 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[4], num4));
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			list.Add(vector3);
			list.Add(vector3);
			list2.Add(new Vector2(corner.sidewalkUVs[4], num4));
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			vector3.y -= corner.curbHeight;
			list.Add(vector3);
			list.Add(vector3);
			if (corner.outerCurb)
			{
				list2.Add(new Vector2(corner.sidewalkUVs[5], num4));
			}
			else
			{
				list2.Add(new Vector2(0f, num4));
			}
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count2 = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if ((leftrightroad == 0 && startEnd == 0) || (leftrightroad == 1 && startEnd == 1))
			{
				triList[triArrayElement].Add(sourceTris[0][num2]);
				triList[triArrayElement].Add(count2);
				triList[triArrayElement].Add(sourceTris[1][num2]);
				triList[triArrayElement].Add(sourceTris[1][num2]);
				triList[triArrayElement].Add(count2);
				triList[triArrayElement].Add(count2 + 2);
				triList[triArrayElement].Add(count2 + 4);
				triList[triArrayElement].Add(sourceTris[3][num2]);
				triList[triArrayElement].Add(sourceTris[2][num2]);
				triList[triArrayElement].Add(sourceTris[7][num2]);
				triList[triArrayElement].Add(sourceTris[6][num2]);
				triList[triArrayElement].Add(count2 + 12);
				triList[triArrayElement].Add(sourceTris[6][num2]);
				triList[triArrayElement].Add(count2 + 10);
				triList[triArrayElement].Add(count2 + 12);
				triList[triArrayElement].Add(sourceTris[5][num2]);
				triList[triArrayElement].Add(sourceTris[4][num2]);
				triList[triArrayElement].Add(count2 + 8);
				triList[triArrayElement].Add(count2 + 1);
				triList[triArrayElement].Add(count2 + 13);
				triList[triArrayElement].Add(count2 + 11);
				triList[triArrayElement].Add(count2 + 1);
				triList[triArrayElement].Add(count2 + 11);
				triList[triArrayElement].Add(count2 + 3);
				triList[triArrayElement].Add(count2 + 6);
				triList[triArrayElement].Add(count2 + 4);
				triList[triArrayElement].Add(count2 + 9);
				triList[triArrayElement].Add(count2 + 6);
				triList[triArrayElement].Add(count2 + 9);
				triList[triArrayElement].Add(count2 + 7);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][num2]);
				triList[triArrayElement].Add(sourceTris[1][num2]);
				triList[triArrayElement].Add(count2);
				triList[triArrayElement].Add(sourceTris[1][num2]);
				triList[triArrayElement].Add(count2 + 2);
				triList[triArrayElement].Add(count2);
				triList[triArrayElement].Add(count2 + 4);
				triList[triArrayElement].Add(sourceTris[2][num2]);
				triList[triArrayElement].Add(sourceTris[3][num2]);
				triList[triArrayElement].Add(sourceTris[7][num2]);
				triList[triArrayElement].Add(count2 + 12);
				triList[triArrayElement].Add(sourceTris[6][num2]);
				triList[triArrayElement].Add(sourceTris[6][num2]);
				triList[triArrayElement].Add(count2 + 12);
				triList[triArrayElement].Add(count2 + 10);
				triList[triArrayElement].Add(sourceTris[5][num2]);
				triList[triArrayElement].Add(count2 + 8);
				triList[triArrayElement].Add(sourceTris[4][num2]);
				triList[triArrayElement].Add(count2 + 1);
				triList[triArrayElement].Add(count2 + 11);
				triList[triArrayElement].Add(count2 + 13);
				triList[triArrayElement].Add(count2 + 1);
				triList[triArrayElement].Add(count2 + 3);
				triList[triArrayElement].Add(count2 + 11);
				triList[triArrayElement].Add(count2 + 6);
				triList[triArrayElement].Add(count2 + 9);
				triList[triArrayElement].Add(count2 + 4);
				triList[triArrayElement].Add(count2 + 6);
				triList[triArrayElement].Add(count2 + 7);
				triList[triArrayElement].Add(count2 + 9);
			}
		}

		public static void OCQDQODOQQ(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = ODDOCQQDQO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
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
			float y = ODDOCQQDQO(sourceVecs[2][0], vector, num, sourceUVs[2][0].y, -1f);
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
			y = ODDOCQQDQO(sourceVecs[5][0], vector, num, sourceUVs[5][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			y = num2 - (corner.sidewalkWidth1 - corner.beveledDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 3], y));
			normalized = (sourceVecs[6][0] - sourceVecs[6][1]).normalized;
			vector = sourceVecs[6][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			y = ODDOCQQDQO(sourceVecs[6][0], vector, num, sourceUVs[6][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			y = num2 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[corner.sidewalkUVs.Count - 2], y));
			normalized = (sourceVecs[7][0] - sourceVecs[7][1]).normalized;
			vector = sourceVecs[7][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			y = ODDOCQQDQO(sourceVecs[7][0], vector, num, sourceUVs[7][0].y, -1f);
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

		public static void OQDDDCDCDO(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = ODDOCQQDQO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
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
			vector.y -= 0f;
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

		public static void OQCDCQQOQO(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = ODDOCQQDQO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			float y = ODDOCQQDQO(sourceVecs[1][0], vector, num, sourceUVs[1][0].y, -1f);
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
			y = ODDOCQQDQO(sourceVecs[4][0], vector, num, sourceUVs[4][0].y, -1f);
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

		public static void OCODODDDOC(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = ODDOCQQDQO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
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

		public static void OQQQDCQCOC(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, int startEnd, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			int num2 = 0;
			Vector3 vector;
			Vector3 vector2;
			Vector3 normalized;
			Vector3 vector3;
			float y;
			if (!hardEdge)
			{
				if (startEnd == 0)
				{
					vector = sourceVecs[0][0];
					vector2 = sourceVecs[0][1];
					num2 = 0;
				}
				else
				{
					vector = sourceVecs[0][sourceVecs[0].Count - 1];
					vector2 = sourceVecs[0][sourceVecs[0].Count - 2];
					num2 = 1;
				}
				normalized = (vector - vector2).normalized;
				vector3 = vector + normalized * corner.curbDepth;
				list.Add(vector3);
				list.Add(vector3);
				float num3 = ODDOCQQDQO(vector, vector3, num, vector.y, -1f);
				list2.Add(new Vector2(corner.sidewalkUVs[0], num3));
				list2.Add(new Vector2(corner.sidewalkUVs[0], num3));
				if (startEnd == 0)
				{
					vector = sourceVecs[1][0];
					vector2 = sourceVecs[1][1];
				}
				else
				{
					vector = sourceVecs[1][sourceVecs[1].Count - 1];
					vector2 = sourceVecs[1][sourceVecs[1].Count - 2];
				}
				normalized = (vector - vector2).normalized;
				vector3 = vector + normalized * corner.curbDepth;
				list.Add(vector3);
				list.Add(vector3);
				list2.Add(new Vector2(corner.sidewalkUVs[1], num3));
				list2.Add(new Vector2(corner.sidewalkUVs[1], num3));
				vector = ((startEnd != 0) ? sourceVecs[2][sourceVecs[2].Count - 1] : sourceVecs[2][0]);
				list.Add(vector);
				y = num3 - corner.curbDepth / num;
				list2.Add(new Vector2(corner.sidewalkUVs[2], y));
				vector = ((startEnd != 0) ? sourceVecs[3][sourceVecs[3].Count - 1] : sourceVecs[3][0]);
				vector3 = vector + normalized * corner.curbDepth;
				list.Add(vector);
				y = num3 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
				list2.Add(new Vector2(corner.sidewalkUVs[2], y));
				if (startEnd == 0)
				{
					vector = sourceVecs[4][0];
					vector2 = sourceVecs[4][1];
				}
				else
				{
					vector = sourceVecs[4][sourceVecs[4].Count - 1];
					vector2 = sourceVecs[4][sourceVecs[4].Count - 2];
				}
				normalized = (vector - vector2).normalized;
				vector3 = vector;
				list.Add(vector3);
				y = num3 - corner.sidewalkWidth1 / num;
				list2.Add(new Vector2(corner.sidewalkUVs[2], y));
				normalized = (vector - vector2).normalized;
				vector3 = vector + normalized * corner.curbDepth;
				list.Add(vector3);
				list2.Add(new Vector2(corner.sidewalkUVs[1], y));
				vector3.y -= corner.curbHeight;
				list.Add(vector3);
				list2.Add(new Vector2(corner.sidewalkUVs[0], y));
				if (scr != null)
				{
					scr.debugVecs.AddRange(list);
				}
				int count = vecs.Count;
				vecs.AddRange(list);
				uvs.AddRange(list2);
				if ((leftrightroad == 0 && startEnd == 0) || (leftrightroad == 1 && startEnd == 1))
				{
					triList[triArrayElement].Add(sourceTris[0][num2]);
					triList[triArrayElement].Add(count);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(count);
					triList[triArrayElement].Add(count + 2);
					triList[triArrayElement].Add(count + 2);
					triList[triArrayElement].Add(sourceTris[2][num2]);
					triList[triArrayElement].Add(sourceTris[1][num2]);
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
					triList[triArrayElement].Add(sourceTris[0][num2]);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(count);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(count + 2);
					triList[triArrayElement].Add(count);
					triList[triArrayElement].Add(count + 2);
					triList[triArrayElement].Add(sourceTris[1][num2]);
					triList[triArrayElement].Add(sourceTris[2][num2]);
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
				return;
			}
			if (startEnd == 0)
			{
				vector = sourceVecs[0][0];
				vector2 = sourceVecs[0][1];
				num2 = 0;
			}
			else
			{
				vector = sourceVecs[0][sourceVecs[0].Count - 1];
				vector2 = sourceVecs[0][sourceVecs[0].Count - 2];
				num2 = 1;
			}
			float y2 = vector.y;
			float num4 = ((startEnd != 0) ? (sourceVecs[1][sourceVecs[1].Count - 1].y - sourceVecs[0][sourceVecs[0].Count - 1].y) : (sourceVecs[1][0].y - sourceVecs[0][0].y));
			float num5 = 0f;
			normalized = (vector - vector2).normalized;
			vector3 = vector + normalized * corner.curbDepth;
			list.Add(vector3);
			list.Add(vector3);
			num5 = ((startEnd != 0) ? ODDOCQQDQO(vector, vector3, num, sourceUVs[0][sourceVecs[0].Count - 1].y, 1f) : ODDOCQQDQO(vector, vector3, num, sourceUVs[0][0].y, -1f));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num5));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num5));
			if (startEnd == 0)
			{
				vector = sourceVecs[1][0];
				vector2 = sourceVecs[1][1];
			}
			else
			{
				vector = sourceVecs[1][sourceVecs[1].Count - 1];
				vector2 = sourceVecs[1][sourceVecs[1].Count - 2];
			}
			normalized = (vector - vector2).normalized;
			vector3 = vector + normalized * corner.curbDepth;
			list.Add(vector3);
			list.Add(vector3);
			list2.Add(new Vector2(corner.sidewalkUVs[1], num5));
			list2.Add(new Vector2(corner.sidewalkUVs[1], num5));
			list.Add(vector3);
			list.Add(vector3);
			list2.Add(new Vector2(corner.sidewalkUVs[1], num5));
			list2.Add(new Vector2(corner.sidewalkUVs[1], num5));
			vector = ((startEnd != 0) ? sourceVecs[2][sourceVecs[2].Count - 1] : sourceVecs[2][0]);
			list.Add(vector);
			y = num5 - corner.curbDepth / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			if (startEnd == 0)
			{
				vector = sourceVecs[3][0];
			}
			else
			{
				vector = sourceVecs[3][sourceVecs[3].Count - 1];
			}
			vector3 = sourceVecs[3][0] + normalized * corner.curbDepth;
			if (startEnd == 0)
			{
				list.Add(sourceVecs[3][0]);
			}
			else
			{
				list.Add(sourceVecs[3][sourceVecs[3].Count - 1]);
			}
			y = num5 - (corner.sidewalkWidth1 - corner.curbDepth) / num;
			list2.Add(new Vector2(corner.sidewalkUVs[2], y));
			if (startEnd == 0)
			{
				vector = sourceVecs[4][0];
				vector2 = sourceVecs[4][1];
			}
			else
			{
				vector = sourceVecs[4][sourceVecs[4].Count - 1];
				vector2 = sourceVecs[4][sourceVecs[4].Count - 2];
			}
			normalized = (vector - vector2).normalized;
			vector3 = vector + normalized * corner.curbDepth;
			list.Add(vector3);
			list.Add(vector3);
			y = num5 - corner.sidewalkWidth1 / num;
			list2.Add(new Vector2(corner.sidewalkUVs[4], num5));
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			list.Add(vector3);
			list.Add(vector3);
			list2.Add(new Vector2(corner.sidewalkUVs[4], num5));
			list2.Add(new Vector2(corner.sidewalkUVs[1], y));
			vector3.y -= num4;
			list.Add(vector3);
			list.Add(vector3);
			if (corner.outerCurb)
			{
				list2.Add(new Vector2(corner.sidewalkUVs[4], num5));
			}
			else
			{
				list2.Add(new Vector2(0f, num5));
			}
			list2.Add(new Vector2(corner.sidewalkUVs[0], y));
			if (scr != null)
			{
				scr.debugVecs.AddRange(list);
			}
			int count2 = vecs.Count;
			vecs.AddRange(list);
			uvs.AddRange(list2);
			if ((leftrightroad == 0 && startEnd == 0) || (leftrightroad == 1 && startEnd == 1))
			{
				triList[triArrayElement].Add(sourceTris[0][num2]);
				triList[triArrayElement].Add(count2);
				triList[triArrayElement].Add(sourceTris[1][num2]);
				triList[triArrayElement].Add(sourceTris[1][num2]);
				triList[triArrayElement].Add(count2);
				triList[triArrayElement].Add(count2 + 2);
				triList[triArrayElement].Add(count2 + 4);
				triList[triArrayElement].Add(sourceTris[3][num2]);
				triList[triArrayElement].Add(sourceTris[2][num2]);
				triList[triArrayElement].Add(sourceTris[5][num2]);
				triList[triArrayElement].Add(sourceTris[4][num2]);
				triList[triArrayElement].Add(count2 + 8);
				triList[triArrayElement].Add(count2 + 1);
				triList[triArrayElement].Add(count2 + 13);
				triList[triArrayElement].Add(count2 + 11);
				triList[triArrayElement].Add(count2 + 1);
				triList[triArrayElement].Add(count2 + 11);
				triList[triArrayElement].Add(count2 + 3);
				triList[triArrayElement].Add(count2 + 6);
				triList[triArrayElement].Add(count2 + 4);
				triList[triArrayElement].Add(count2 + 9);
				triList[triArrayElement].Add(count2 + 6);
				triList[triArrayElement].Add(count2 + 9);
				triList[triArrayElement].Add(count2 + 7);
			}
			else
			{
				triList[triArrayElement].Add(sourceTris[0][num2]);
				triList[triArrayElement].Add(sourceTris[1][num2]);
				triList[triArrayElement].Add(count2);
				triList[triArrayElement].Add(sourceTris[1][num2]);
				triList[triArrayElement].Add(count2 + 2);
				triList[triArrayElement].Add(count2);
				triList[triArrayElement].Add(count2 + 4);
				triList[triArrayElement].Add(sourceTris[2][num2]);
				triList[triArrayElement].Add(sourceTris[3][num2]);
				triList[triArrayElement].Add(sourceTris[5][num2]);
				triList[triArrayElement].Add(count2 + 8);
				triList[triArrayElement].Add(sourceTris[4][num2]);
				triList[triArrayElement].Add(count2 + 1);
				triList[triArrayElement].Add(count2 + 11);
				triList[triArrayElement].Add(count2 + 13);
				triList[triArrayElement].Add(count2 + 1);
				triList[triArrayElement].Add(count2 + 3);
				triList[triArrayElement].Add(count2 + 11);
				triList[triArrayElement].Add(count2 + 6);
				triList[triArrayElement].Add(count2 + 9);
				triList[triArrayElement].Add(count2 + 4);
				triList[triArrayElement].Add(count2 + 6);
				triList[triArrayElement].Add(count2 + 7);
				triList[triArrayElement].Add(count2 + 9);
			}
		}

		public static void OCQCDODQDC(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = ODDOCQQDQO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
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
			float y = ODDOCQQDQO(sourceVecs[2][0], vector, num, sourceUVs[2][0].y, -1f);
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

		public static void OCCQCCQDOO(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = ODDOCQQDQO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			float y = ODDOCQQDQO(sourceVecs[1][0], vector, num, sourceUVs[1][0].y, -1f);
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

		public static void OCDOQCOQDQ(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = ODDOCQQDQO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			list2.Add(new Vector2(corner.sidewalkUVs[0], num2));
			normalized = (sourceVecs[1][0] - sourceVecs[1][1]).normalized;
			vector = sourceVecs[1][0] + normalized * (corner.curbDepth - corner.beveledDepth);
			list.Add(vector);
			list.Add(vector);
			float y = ODDOCQQDQO(sourceVecs[1][0], vector, num, sourceUVs[1][0].y, -1f);
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

		public static void OOCDDDQQDD(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, int triArrayElement, int leftrightroad, bool hardEdge)
		{
			float num = 2.5f;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			Vector3 normalized = (sourceVecs[0][0] - sourceVecs[0][1]).normalized;
			Vector3 vector = sourceVecs[0][0] + normalized * corner.curbDepth;
			list.Add(vector);
			list.Add(vector);
			float num2 = ODDOCQQDQO(sourceVecs[0][0], vector, num, sourceUVs[0][0].y, -1f);
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

		public static Vector3 CloseGapOODOODDDOD(ERCrossingPrefabs prefabScript, Vector3 cornerPoint, Vector3 lastPoint, Vector3 pavementPoint, Vector3 forward, float dist, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<int> tris, ERSideWalk sw, float offsetX)
		{
			int num = vecs.Count - 5;
			if (sw.hardEdges)
			{
				num--;
			}
			if (sw.hardEdges && sw.outerCurb)
			{
				num--;
			}
			if (sw.outerCurb)
			{
				num--;
			}
			int count = vecs.Count;
			Vector3 a = vecs[count - 1];
			a.y = 0f;
			float y = uvs[count - 1].y;
			y += Vector3.Distance(a, cornerPoint) / sw.uvRatio * sw.tiling;
			Vector3 vector = cornerPoint + offsetX * -forward;
			vecs.Add(vector);
			Vector3 vector2 = vector;
			dist += Vector3.Distance(lastPoint, vector);
			float y2 = dist / sw.uvRatio * sw.tiling;
			uvs.Add(new Vector2(sw.sidewalkUVs[0], y2));
			vector.y += sw.shape[1].y;
			vecs.Add(vector);
			uvs.Add(new Vector2(sw.sidewalkUVs[1], y2));
			if (sw.hardEdges)
			{
				vecs.Add(vector);
				uvs.Add(new Vector2(sw.sidewalkUVs[1], y2));
			}
			tris.Add(num);
			tris.Add(count);
			tris.Add(count + 1);
			tris.Add(num);
			tris.Add(count + 1);
			tris.Add(num + 1);
			if (!sw.hardEdges)
			{
				tris.Add(num + 1);
				tris.Add(count + 1);
				tris.Add(num + 2);
			}
			else
			{
				tris.Add(num + 2);
				tris.Add(count + 2);
				tris.Add(num + 3);
			}
			int count2 = vecs.Count;
			y2 = y;
			if (sw.outerCurb)
			{
				vecs.Add(vector2);
				uvs.Add(new Vector2(sw.sidewalkUVs[5], y2));
				int num2 = vecs.Count - 1;
				tris.Add(count2);
				tris.Add(count - 1);
				tris.Add(count - 2);
				tris.Add(count2);
				tris.Add(count - 2);
				tris.Add(count2 + 1);
			}
			vecs.Add(vector);
			uvs.Add(new Vector2(sw.sidewalkUVs[4], y2));
			if (sw.hardEdges)
			{
				vecs.Add(vector);
				uvs.Add(new Vector2(sw.sidewalkUVs[4], y2));
			}
			if (!sw.outerCurb)
			{
				tris.Add(count - 2);
				tris.Add(vecs.Count - 1);
				tris.Add(count - 1);
			}
			else if (sw.outerCurb && !sw.hardEdges)
			{
				tris.Add(count - 3);
				tris.Add(vecs.Count - 1);
				tris.Add(count - 2);
			}
			else if (sw.outerCurb && sw.hardEdges)
			{
				tris.Add(count - 4);
				tris.Add(vecs.Count - 1);
				tris.Add(count - 3);
			}
			return vector2;
		}

		public static float ODDOCQQDQO(Vector3 v1, Vector3 v2, float uvRatio, float startUV, float dir)
		{
			float num = Vector3.Distance(v1, v2);
			return startUV + dir * num / uvRatio;
		}
	}
}
