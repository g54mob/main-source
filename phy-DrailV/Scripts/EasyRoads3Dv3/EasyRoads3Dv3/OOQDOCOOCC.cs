using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OOQDOCOOCC : MonoBehaviour
	{
		public static void OCDDQODQDQ(ERCrossings scr)
		{
			OCQQQQOQCO(scr);
			OQDCDDODOO(scr);
			if (scr.tCrossingLeftRight == 0)
			{
				OOQODDCCCC(scr, scr.leftSidewalkStartV3, scr.rightSidewalkLeftV3, scr.prefabScript.sidewalkControlElements[0], 0, 0, scr.leftStartSidewalkCornerInt, crossingSide: true);
				OOQODDCCCC(scr, scr.rightSidewalkLeftV3, scr.leftSidewalkStartV3, scr.prefabScript.sidewalkControlElements[0], 1, 1, scr.rightLeftSidewalkCornerInt, crossingSide: true);
				OODDCQQDCD(ref scr.leftSidewalkStartV3, ref scr.rightSidewalkLeftV3);
			}
			else
			{
				OOQODDCCCC(scr, scr.leftSidewalkStartV3, scr.rightSidewalkLeftV3, scr.prefabScript.sidewalkControlElements[0], 0, 0, scr.leftStartSidewalkCornerInt, crossingSide: false);
			}
			if (scr.tCrossingLeftRight == 1)
			{
				OOQODDCCCC(scr, scr.rightSidewalkStartV3, scr.leftSidewalkRightV3, scr.prefabScript.sidewalkControlElements[1], 1, 0, scr.rightStartSidewalkCornerInt, crossingSide: true);
				OOQODDCCCC(scr, scr.leftSidewalkRightV3, scr.rightSidewalkStartV3, scr.prefabScript.sidewalkControlElements[1], 0, 1, scr.leftRightSidewalkCornerInt, crossingSide: true);
				OODDCQQDCD(ref scr.rightSidewalkStartV3, ref scr.leftSidewalkRightV3);
			}
			else
			{
				OOQODDCCCC(scr, scr.rightSidewalkStartV3, scr.leftSidewalkRightV3, scr.prefabScript.sidewalkControlElements[1], 1, 0, scr.rightStartSidewalkCornerInt, crossingSide: false);
			}
			if (scr.tCrossingLeftRight == 1)
			{
				OOQODDCCCC(scr, scr.leftSidewalkEndV3, scr.rightSidewalkRightV3, scr.prefabScript.sidewalkControlElements[3], 0, 0, scr.leftEndSidewalkCornerInt, crossingSide: true);
				OOQODDCCCC(scr, scr.rightSidewalkRightV3, scr.leftSidewalkEndV3, scr.prefabScript.sidewalkControlElements[3], 1, 1, scr.rightRightSidewalkCornerInt, crossingSide: true);
				OODDCQQDCD(ref scr.leftSidewalkEndV3, ref scr.rightSidewalkRightV3);
			}
			else
			{
				OOQODDCCCC(scr, scr.leftSidewalkEndV3, scr.rightSidewalkRightV3, scr.prefabScript.sidewalkControlElements[1], 0, 0, scr.leftEndSidewalkCornerInt, crossingSide: false);
			}
			if (scr.tCrossingLeftRight == 0)
			{
				OOQODDCCCC(scr, scr.rightSidewalkEndV3, scr.leftSidewalkLeftV3, scr.prefabScript.sidewalkControlElements[2], 1, 0, scr.rightEndSidewalkCornerInt, crossingSide: true);
				OOQODDCCCC(scr, scr.leftSidewalkLeftV3, scr.rightSidewalkEndV3, scr.prefabScript.sidewalkControlElements[2], 0, 1, scr.leftLeftSidewalkCornerInt, crossingSide: true);
				OODDCQQDCD(ref scr.rightSidewalkEndV3, ref scr.leftSidewalkLeftV3);
			}
			else
			{
				OOQODDCCCC(scr, scr.rightSidewalkEndV3, scr.leftSidewalkLeftV3, scr.prefabScript.sidewalkControlElements[0], 1, 0, scr.rightEndSidewalkCornerInt, crossingSide: false);
			}
			OQQCODQQCO(scr, scr.leftSidewalkStartV3, ref scr.leftSidewalkStartUV, scr.prefabScript.sidewalkControlElements[0], reverse: true, scr.frontRoadUVTiling);
			if (scr.tCrossingLeftRight == 0)
			{
				OQQCODQQCO(scr, scr.rightSidewalkLeftV3, ref scr.rightSidewalkLeftUV, scr.prefabScript.sidewalkControlElements[0], reverse: false, scr.rightRoadUVTiling);
			}
			OQQCODQQCO(scr, scr.rightSidewalkStartV3, ref scr.rightSidewalkStartUV, scr.prefabScript.sidewalkControlElements[1], reverse: false, scr.frontRoadUVTiling);
			if (scr.tCrossingLeftRight == 1)
			{
				OQQCODQQCO(scr, scr.leftSidewalkRightV3, ref scr.leftSidewalkRightUV, scr.prefabScript.sidewalkControlElements[1], reverse: true, scr.leftRoadUVTiling);
			}
			OQQCODQQCO(scr, scr.leftSidewalkEndV3, ref scr.leftSidewalkEndUV, scr.prefabScript.sidewalkControlElements[3], reverse: true, scr.backRoadUVTiling);
			if (scr.tCrossingLeftRight == 1)
			{
				OQQCODQQCO(scr, scr.rightSidewalkRightV3, ref scr.rightSidewalkRightUV, scr.prefabScript.sidewalkControlElements[3], reverse: false, scr.rightRoadUVTiling);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				OQQCODQQCO(scr, scr.rightSidewalkEndV3, ref scr.rightSidewalkEndUV, scr.prefabScript.sidewalkControlElements[2], reverse: false, scr.backRoadUVTiling);
			}
			else
			{
				OQQCODQQCO(scr, scr.rightSidewalkEndV3, ref scr.rightSidewalkEndUV, scr.prefabScript.sidewalkControlElements[0], reverse: false, scr.backRoadUVTiling);
			}
			if (scr.tCrossingLeftRight == 0)
			{
				OQQCODQQCO(scr, scr.leftSidewalkLeftV3, ref scr.leftSidewalkLeftUV, scr.prefabScript.sidewalkControlElements[2], reverse: true, scr.leftRoadUVTiling);
			}
		}

		public static void OCQQQQOQCO(ERCrossings scr)
		{
			if (scr.tCrossingLeftRight == 0)
			{
				OQQOQOQODQ(scr, scr.startConnectionV3[0], scr.leftConnectionV3[scr.leftConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 1, ref scr.leftStartSidewalkCornerInt);
				OQQOQOQODQ(scr, scr.leftConnectionV3[scr.leftConnectionV3.Count - 1], scr.startConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 0, ref scr.rightLeftSidewalkCornerInt);
			}
			else
			{
				scr.leftStartSidewalkCornerInt = scr.startConnectionV3[0].Count;
			}
			if (scr.tCrossingLeftRight == 1)
			{
				OQQOQOQODQ(scr, scr.startConnectionV3[scr.startConnectionV3.Count - 1], scr.rightConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 1, ref scr.rightStartSidewalkCornerInt);
				OQQOQOQODQ(scr, scr.rightConnectionV3[0], scr.startConnectionV3[scr.startConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 0, ref scr.leftRightSidewalkCornerInt);
			}
			else
			{
				scr.rightStartSidewalkCornerInt = scr.startConnectionV3[scr.startConnectionV3.Count - 1].Count;
			}
			if (scr.tCrossingLeftRight == 1)
			{
				OQQOQOQODQ(scr, scr.endConnectionV3[0], scr.rightConnectionV3[scr.rightConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 1, ref scr.leftEndSidewalkCornerInt);
				OQQOQOQODQ(scr, scr.rightConnectionV3[scr.rightConnectionV3.Count - 1], scr.endConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 0, ref scr.rightRightSidewalkCornerInt);
			}
			else
			{
				scr.leftEndSidewalkCornerInt = scr.endConnectionV3[0].Count;
			}
			if (scr.tCrossingLeftRight == 0)
			{
				OQQOQOQODQ(scr, scr.endConnectionV3[scr.endConnectionV3.Count - 1], scr.leftConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 1, ref scr.rightEndSidewalkCornerInt);
				OQQOQOQODQ(scr, scr.leftConnectionV3[0], scr.endConnectionV3[scr.endConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 0, ref scr.leftLeftSidewalkCornerInt);
			}
			else
			{
				scr.rightEndSidewalkCornerInt = scr.endConnectionV3[scr.endConnectionV3.Count - 1].Count;
			}
		}

		public static void OQQOQOQODQ(ERCrossings scr, List<Vector3> vecArray, Vector3 firstOther, float sidewalkWidth, int xorz, ref int cornerInt)
		{
			if (xorz == 0)
			{
				firstOther.z = vecArray[0].z;
			}
			else
			{
				firstOther.x = vecArray[0].x;
			}
			cornerInt = vecArray.Count - 1;
			for (int i = 0; i < vecArray.Count; i++)
			{
				if (Vector3.Distance(vecArray[i], firstOther) <= sidewalkWidth)
				{
					cornerInt = i + 1;
					break;
				}
			}
		}

		public static void OOQODDCCCC(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector3>> vecArrayOther, QDOQDSQOOQDDD corner, int startEnd, int mainOrConnected, int outerCornerInt, bool crossingSide)
		{
			float num = 0f;
			float num2 = 0f;
			List<Vector3> list = new List<Vector3>();
			if (corner.beveledCurb)
			{
				if (corner.beveledHeight > 0f && corner.beveledHeight != corner.curbHeight)
				{
					num2 = corner.beveledHeight;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(ODCQODDDQD(vecArray[0], num2));
				}
				num2 = corner.curbHeight;
				if (corner.beveledDepth > 0f && corner.beveledDepth != corner.curbDepth)
				{
					num = corner.beveledDepth;
					vecArray.Add(new List<Vector3>());
					if (crossingSide)
					{
						vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
					}
					else
					{
						vecArray[vecArray.Count - 1].AddRange(OQCDCQOOOD(vecArray[0], num, num2, startEnd, mainOrConnected, -1));
					}
				}
				if (corner.beveledDepth != corner.curbDepth)
				{
					num = corner.curbDepth;
					vecArray.Add(new List<Vector3>());
					if (crossingSide)
					{
						vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
					}
					else
					{
						vecArray[vecArray.Count - 1].AddRange(OQCDCQOOOD(vecArray[0], num, num2, startEnd, mainOrConnected, -1));
					}
				}
			}
			else
			{
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODCQODDDQD(vecArray[0], num2));
				num = corner.curbDepth;
				vecArray.Add(new List<Vector3>());
				if (crossingSide)
				{
					vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
				}
				else
				{
					vecArray[vecArray.Count - 1].AddRange(OQCDCQOOOD(vecArray[0], num, num2, startEnd, mainOrConnected, -1));
				}
			}
			num = corner.curbDepth;
			vecArray.Add(new List<Vector3>());
			vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
			if (corner.beveledCurb && corner.outerCurb)
			{
				if (corner.beveledDepth != corner.curbDepth && corner.beveledDepth > 0f)
				{
					num = corner.beveledDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				}
				if (corner.beveledHeight > 0f && corner.beveledHeight != corner.curbHeight && corner.outerCurb)
				{
					num2 = corner.beveledHeight;
					num = 0f;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				}
				num2 = 0f;
				num = 0f;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
			}
			else
			{
				num = 0f;
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				if (corner.outerCurb)
				{
					num2 = 0f;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				}
			}
		}

		public static void OQDCDDODOO(ERCrossings scr)
		{
			scr.leftSidewalkStartV3.Add(new List<Vector3>());
			scr.leftSidewalkStartV3[0].AddRange(scr.startConnectionV3[0]);
			scr.rightSidewalkStartV3.Add(new List<Vector3>());
			scr.rightSidewalkStartV3[0].AddRange(scr.startConnectionV3[scr.startConnectionV3.Count - 1]);
			scr.leftSidewalkEndV3.Add(new List<Vector3>());
			scr.leftSidewalkEndV3[0].AddRange(scr.endConnectionV3[0]);
			scr.rightSidewalkEndV3.Add(new List<Vector3>());
			scr.rightSidewalkEndV3[0].AddRange(scr.endConnectionV3[scr.endConnectionV3.Count - 1]);
			if (scr.tCrossingLeftRight == 0)
			{
				scr.leftSidewalkLeftV3.Add(new List<Vector3>());
				scr.leftSidewalkLeftV3[0].AddRange(scr.leftConnectionV3[0]);
				scr.rightSidewalkLeftV3.Add(new List<Vector3>());
				scr.rightSidewalkLeftV3[0].AddRange(scr.leftConnectionV3[scr.leftConnectionV3.Count - 1]);
			}
			if (scr.tCrossingLeftRight == 1)
			{
				scr.leftSidewalkRightV3.Add(new List<Vector3>());
				scr.leftSidewalkRightV3[0].AddRange(scr.rightConnectionV3[0]);
				scr.rightSidewalkRightV3.Add(new List<Vector3>());
				scr.rightSidewalkRightV3[0].AddRange(scr.rightConnectionV3[scr.rightConnectionV3.Count - 1]);
			}
		}

		public static List<Vector3> OQQQDODQDO(List<Vector3> outer, List<Vector3> outerOther, float dist, float height, int startend, int leftright, int outerCornerInt)
		{
			List<Vector3> list = new List<Vector3>();
			int num = outer.Count;
			if (outerCornerInt != -1)
			{
				num = outerCornerInt;
			}
			for (int i = 0; i < num; i++)
			{
				Vector3 vector = ((i != 0) ? ((i >= outer.Count - 1) ? (outerOther[outerOther.Count - 2] - outer[i - 1]).normalized : (outer[i + 1] - outer[i - 1]).normalized) : (outer[1] - outer[0]).normalized);
				vector = ((startend != 0) ? new Vector3(vector.z, 0f, 0f - vector.x).normalized : new Vector3(0f - vector.z, 0f, vector.x).normalized);
				Vector3 item = outer[i] + vector * dist;
				item.y = height;
				list.Add(item);
			}
			return list;
		}

		public static List<Vector3> OQCDCQOOOD(List<Vector3> outer, float dist, float height, int startend, int leftright, int outerCornerInt)
		{
			List<Vector3> list = new List<Vector3>();
			int num = outer.Count;
			if (outerCornerInt != -1)
			{
				num = outerCornerInt;
			}
			for (int i = 0; i < num; i++)
			{
				Vector3 vector = ((i != 0) ? ((i >= outer.Count - 1) ? (outer[i] - outer[i - 1]).normalized : (outer[i + 1] - outer[i - 1]).normalized) : (outer[1] - outer[0]).normalized);
				vector = ((startend != 0) ? new Vector3(vector.z, 0f, 0f - vector.x) : new Vector3(0f - vector.z, 0f, vector.x));
				Vector3 item = outer[i] + vector * dist;
				item.y = height;
				list.Add(item);
			}
			return list;
		}

		public static List<Vector3> ODCOQOOOCO(ERCrossings scr, List<Vector3> innerArray, float dist, float height, float sidewalkWidth, int startend, int leftright, int outerCornerInt)
		{
			List<Vector3> list = new List<Vector3>();
			if (sidewalkWidth >= 0.5f)
			{
				Vector3 normalized = (innerArray[1] - innerArray[0]).normalized;
				normalized = ((startend != 0) ? new Vector3(normalized.z, 0f, 0f - normalized.x) : new Vector3(0f - normalized.z, 0f, normalized.x));
				Vector3 vector = innerArray[0] + normalized * sidewalkWidth;
				Vector3 vector2 = innerArray[0];
				Vector3 p = vector;
				if (leftright == 0)
				{
					p.z += 1f;
				}
				else
				{
					p.x += 1f;
				}
				int num = innerArray.Count;
				if (outerCornerInt != -1)
				{
					num = outerCornerInt;
				}
				for (int i = 0; i < num; i++)
				{
					vector2 = innerArray[i];
					if (leftright == 0)
					{
						vector2.x += 1f;
					}
					else
					{
						vector2.z += 1f;
					}
					Vector3 vector3 = OCQCDQCQOQ.OCDCDCDCQD(vector, p, innerArray[i], vector2);
					normalized = (innerArray[i] - vector3).normalized;
					vector3 += normalized * dist;
					vector3.y = height;
					list.Add(vector3);
				}
			}
			else
			{
				for (int i = 0; i < innerArray.Count; i++)
				{
					Vector3 normalized = ((i != 0) ? ((i >= innerArray.Count - 1) ? (innerArray[innerArray.Count - 1] - innerArray[innerArray.Count - 2]) : (innerArray[i + 1] - innerArray[i - 1])) : (innerArray[1] - innerArray[0]));
					normalized = (((leftright != 0 || startend != 0) && (leftright != 1 || startend != 0)) ? new Vector3(normalized.z, 0f, 0f - normalized.x).normalized : new Vector3(0f - normalized.z, 0f, normalized.x).normalized);
					Vector3 vector3 = innerArray[i] + normalized * sidewalkWidth;
					vector3.y = height;
					list.Add(vector3);
				}
			}
			return list;
		}

		public static List<Vector3> ODCQODDDQD(List<Vector3> outer, float height)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < outer.Count; i++)
			{
				Vector3 item = outer[i];
				item.y = height;
				list.Add(item);
			}
			return list;
		}

		public static void OQQCODQQCO(ERCrossings scr, List<List<Vector3>> vecArray, ref List<List<Vector2>> uvArray, QDOQDSQOOQDDD corner, bool reverse, float uvTiling)
		{
			if (corner.sidewalkUVs.Count == 0 || !corner.lockUVs)
			{
				ODQCQCDQQQ(vecArray, ref corner.sidewalkUVs);
			}
			List<float> list = new List<float>();
			list.AddRange(corner.sidewalkUVs);
			uvArray.Clear();
			float num = 0f;
			float num2 = 5f * uvTiling;
			for (int i = 0; i < vecArray.Count; i++)
			{
				uvArray.Add(new List<Vector2>());
				uvArray[i].Add(new Vector2(list[i], 0f));
				num = 0f;
				for (int j = 1; j < vecArray[i].Count; j++)
				{
					num += Vector3.Distance(vecArray[i][j - 1], vecArray[i][j]);
					uvArray[i].Add(new Vector2(list[i], num / num2));
				}
			}
		}

		public static void ODQCQCDQQQ(List<List<Vector3>> vecArray, ref List<float> sidewalkUVs)
		{
			sidewalkUVs.Clear();
			List<float> list = new List<float>();
			list.Add(0f);
			float num = 0f;
			for (int i = 1; i < vecArray.Count; i++)
			{
				num += Vector3.Distance(vecArray[i - 1][0], vecArray[i][0]);
				list.Add(num);
			}
			for (int i = 0; i < list.Count; i++)
			{
				sidewalkUVs.Add(list[i] / num);
			}
		}

		public static void OODDCQQDCD(ref List<List<Vector3>> outer1, ref List<List<Vector3>> outer2)
		{
			for (int i = 0; i < outer1.Count; i++)
			{
				if (outer1[i][outer1[i].Count - 1] != outer2[i][outer2[i].Count - 1])
				{
					Vector3 vector = OCQCDQCQOQ.OCDCDCDCQD(outer1[i][outer1[i].Count - 1], outer1[i][outer1[i].Count - 2], outer2[i][outer2[i].Count - 1], outer2[i][outer2[i].Count - 2]);
					List<Vector3> list = outer1[i];
					int index = outer1[i].Count - 1;
					Vector3 value = (outer2[i][outer2[i].Count - 1] = vector);
					list[index] = value;
				}
			}
		}
	}
}
