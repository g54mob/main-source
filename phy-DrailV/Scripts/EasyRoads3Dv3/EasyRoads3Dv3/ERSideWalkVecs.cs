using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERSideWalkVecs : MonoBehaviour
	{
		public static GameObject sidewalk;

		public static void OCDDQODQDQ(ERCrossings scr)
		{
			OCQQQQOQCO(scr);
			OQDCDDODOO(scr);
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag)
			{
				OOQODDCCCC(scr, scr.leftSidewalkStartV3, scr.rightSidewalkLeftV3, scr.prefabScript.sidewalkControlElements[0], 0, 0, scr.leftStartSidewalkCornerInt);
				OOQODDCCCC(scr, scr.rightSidewalkLeftV3, scr.leftSidewalkStartV3, scr.prefabScript.sidewalkControlElements[0], 1, 1, scr.rightLeftSidewalkCornerInt);
				OODDCQQDCD(ref scr.leftSidewalkStartV3, ref scr.rightSidewalkLeftV3);
				OQQCODQQCO(scr, scr.leftSidewalkStartV3, ref scr.leftSidewalkStartUV, scr.prefabScript.sidewalkControlElements[0], reverse: true, scr.frontRoadUVTiling);
				OQQCODQQCO(scr, scr.rightSidewalkLeftV3, ref scr.rightSidewalkLeftUV, scr.prefabScript.sidewalkControlElements[0], reverse: false, scr.rightRoadUVTiling);
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag)
			{
				OOQODDCCCC(scr, scr.rightSidewalkStartV3, scr.leftSidewalkRightV3, scr.prefabScript.sidewalkControlElements[1], 1, 0, scr.rightStartSidewalkCornerInt);
				OOQODDCCCC(scr, scr.leftSidewalkRightV3, scr.rightSidewalkStartV3, scr.prefabScript.sidewalkControlElements[1], 0, 1, scr.leftRightSidewalkCornerInt);
				OODDCQQDCD(ref scr.rightSidewalkStartV3, ref scr.leftSidewalkRightV3);
				OQQCODQQCO(scr, scr.rightSidewalkStartV3, ref scr.rightSidewalkStartUV, scr.prefabScript.sidewalkControlElements[1], reverse: false, scr.frontRoadUVTiling);
				OQQCODQQCO(scr, scr.leftSidewalkRightV3, ref scr.leftSidewalkRightUV, scr.prefabScript.sidewalkControlElements[1], reverse: true, scr.leftRoadUVTiling);
			}
			if (scr.prefabScript.sidewalkControlElements[3].renderFlag)
			{
				OOQODDCCCC(scr, scr.leftSidewalkEndV3, scr.rightSidewalkRightV3, scr.prefabScript.sidewalkControlElements[3], 0, 0, scr.leftEndSidewalkCornerInt);
				OOQODDCCCC(scr, scr.rightSidewalkRightV3, scr.leftSidewalkEndV3, scr.prefabScript.sidewalkControlElements[3], 1, 1, scr.rightRightSidewalkCornerInt);
				OODDCQQDCD(ref scr.leftSidewalkEndV3, ref scr.rightSidewalkRightV3);
				OQQCODQQCO(scr, scr.leftSidewalkEndV3, ref scr.leftSidewalkEndUV, scr.prefabScript.sidewalkControlElements[3], reverse: true, scr.backRoadUVTiling);
				OQQCODQQCO(scr, scr.rightSidewalkRightV3, ref scr.rightSidewalkRightUV, scr.prefabScript.sidewalkControlElements[3], reverse: false, scr.rightRoadUVTiling);
			}
			if (scr.prefabScript.sidewalkControlElements[2].renderFlag)
			{
				OOQODDCCCC(scr, scr.rightSidewalkEndV3, scr.leftSidewalkLeftV3, scr.prefabScript.sidewalkControlElements[2], 1, 0, scr.rightEndSidewalkCornerInt);
				OOQODDCCCC(scr, scr.leftSidewalkLeftV3, scr.rightSidewalkEndV3, scr.prefabScript.sidewalkControlElements[2], 0, 1, scr.leftLeftSidewalkCornerInt);
				OODDCQQDCD(ref scr.rightSidewalkEndV3, ref scr.leftSidewalkLeftV3);
				OQQCODQQCO(scr, scr.rightSidewalkEndV3, ref scr.rightSidewalkEndUV, scr.prefabScript.sidewalkControlElements[2], reverse: false, scr.backRoadUVTiling);
				OQQCODQQCO(scr, scr.leftSidewalkLeftV3, ref scr.leftSidewalkLeftUV, scr.prefabScript.sidewalkControlElements[2], reverse: true, scr.leftRoadUVTiling);
			}
		}

		public static void OCQQQQOQCO(ERCrossings scr)
		{
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag)
			{
				OQQOQOQODQ(scr, scr.startConnectionV3[0], scr.leftConnectionV3[scr.leftConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 1, ref scr.leftStartSidewalkCornerInt);
				OQQOQOQODQ(scr, scr.leftConnectionV3[scr.leftConnectionV3.Count - 1], scr.startConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 0, ref scr.rightLeftSidewalkCornerInt);
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag)
			{
				OQQOQOQODQ(scr, scr.startConnectionV3[scr.startConnectionV3.Count - 1], scr.rightConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 1, ref scr.rightStartSidewalkCornerInt);
				OQQOQOQODQ(scr, scr.rightConnectionV3[0], scr.startConnectionV3[scr.startConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 0, ref scr.leftRightSidewalkCornerInt);
			}
			if (scr.prefabScript.sidewalkControlElements[3].renderFlag)
			{
				OQQOQOQODQ(scr, scr.endConnectionV3[0], scr.rightConnectionV3[scr.rightConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 1, ref scr.leftEndSidewalkCornerInt);
				OQQOQOQODQ(scr, scr.rightConnectionV3[scr.rightConnectionV3.Count - 1], scr.endConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 0, ref scr.rightRightSidewalkCornerInt);
			}
			if (scr.prefabScript.sidewalkControlElements[2].renderFlag)
			{
				OQQOQOQODQ(scr, scr.endConnectionV3[scr.endConnectionV3.Count - 1], scr.leftConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 1, ref scr.rightEndSidewalkCornerInt);
				OQQOQOQODQ(scr, scr.leftConnectionV3[0], scr.endConnectionV3[scr.endConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 0, ref scr.leftLeftSidewalkCornerInt);
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

		public static void OOQODDCCCC(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector3>> vecArrayOther, QDOQDSQOOQDDD corner, int startEnd, int mainOrConnected, int outerCornerInt)
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
					vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
				}
				if (corner.beveledDepth != corner.curbDepth)
				{
					num = corner.curbDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
				}
			}
			else
			{
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODCQODDDQD(vecArray[0], num2));
				num = corner.curbDepth;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
			}
			num = corner.curbDepth;
			vecArray.Add(new List<Vector3>());
			vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
			if (corner.beveledCurb && corner.outerCurb)
			{
				if (corner.beveledDepth != corner.curbDepth && corner.beveledDepth > 0f)
				{
					num = corner.beveledDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				}
				if (corner.beveledHeight > 0f && corner.beveledHeight != corner.curbHeight && corner.outerCurb)
				{
					num2 = corner.beveledHeight;
					num = 0f;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				}
				num2 = 0f;
				num = 0f;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
			}
			else
			{
				num = 0f;
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				if (corner.outerCurb)
				{
					num2 = 0f;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(ODCOQOOOCO(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
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
			scr.leftSidewalkLeftV3.Add(new List<Vector3>());
			scr.leftSidewalkLeftV3[0].AddRange(scr.leftConnectionV3[0]);
			scr.rightSidewalkLeftV3.Add(new List<Vector3>());
			scr.rightSidewalkLeftV3[0].AddRange(scr.leftConnectionV3[scr.leftConnectionV3.Count - 1]);
			scr.leftSidewalkRightV3.Add(new List<Vector3>());
			scr.leftSidewalkRightV3[0].AddRange(scr.rightConnectionV3[0]);
			scr.rightSidewalkRightV3.Add(new List<Vector3>());
			scr.rightSidewalkRightV3[0].AddRange(scr.rightConnectionV3[scr.rightConnectionV3.Count - 1]);
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
				vector = ((startend != 0) ? new Vector3(vector.z, 0f, 0f - vector.x) : new Vector3(0f - vector.z, 0f, vector.x));
				Vector3 item = outer[i] + vector * dist;
				item.y = height;
				list.Add(item);
			}
			return list;
		}

		public static List<Vector3> ODCOQOOOCO(ERCrossings scr, List<Vector3> innerArray, List<Vector3> outerOther, float dist, float height, float sidewalkWidth, int startend, int leftright, int outerCornerInt)
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

		public static Vector3[] OODOCDCQDC(ERCrossings scr, Vector3[] normals)
		{
			for (int i = 0; i < scr.OQOCCQDCCO.Count; i++)
			{
				ref Vector3 reference = ref normals[scr.OQOCCQDCCO[i]];
				ref Vector3 reference2 = ref normals[scr.OOOCCCCODQ[i]];
				reference = (reference2 = (normals[scr.OQOCCQDCCO[i]] + normals[scr.OOOCCCCODQ[i]]) * 0.5f);
				ref Vector3 reference3 = ref normals[scr.OQOCCQDCCOStart[i]];
				reference3 = normals[scr.OQOCCQDCCOStart[i] + 1];
				ref Vector3 reference4 = ref normals[scr.OOOCCCCODQStart[i]];
				reference4 = normals[scr.OOOCCCCODQStart[i] + 1];
			}
			for (int i = 0; i < scr.ODCDCOODCQ.Count; i++)
			{
				ref Vector3 reference5 = ref normals[scr.ODCDCOODCQ[i]];
				ref Vector3 reference6 = ref normals[scr.OCDDDQCCOO[i]];
				reference5 = (reference6 = (normals[scr.ODCDCOODCQ[i]] + normals[scr.OCDDDQCCOO[i]]) * 0.5f);
				ref Vector3 reference7 = ref normals[scr.ODCDCOODCQStart[i]];
				reference7 = normals[scr.ODCDCOODCQStart[i] + 1];
				ref Vector3 reference8 = ref normals[scr.OCDDDQCCOOStart[i]];
				reference8 = normals[scr.OCDDDQCCOOStart[i] + 1];
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				for (int i = 0; i < scr.OCDCDQQCDD.Count; i++)
				{
					ref Vector3 reference9 = ref normals[scr.OCDCDQQCDD[i]];
					ref Vector3 reference10 = ref normals[scr.OQCQCCCQQC[i]];
					reference9 = (reference10 = (normals[scr.OCDCDQQCDD[i]] + normals[scr.OQCQCCCQQC[i]]) * 0.5f);
					ref Vector3 reference11 = ref normals[scr.OCDCDQQCDDStart[i]];
					reference11 = normals[scr.OCDCDQQCDDStart[i] + 1];
					ref Vector3 reference12 = ref normals[scr.OQCQCCCQQCStart[i]];
					reference12 = normals[scr.OQCQCCCQQCStart[i] + 1];
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				for (int i = 0; i < scr.OCCDCQDDDD.Count; i++)
				{
					ref Vector3 reference13 = ref normals[scr.OCCDCQDDDD[i]];
					ref Vector3 reference14 = ref normals[scr.ODQQCQDOQC[i]];
					reference13 = (reference14 = (normals[scr.OCCDCQDDDD[i]] + normals[scr.ODQQCQDOQC[i]]) * 0.5f);
				}
			}
			return normals;
		}

		public static Vector4[] AdjustSidewalkTangents1(ERCrossings scr, Vector4[] tangents)
		{
			for (int i = 0; i < scr.OQOCCQDCCO.Count; i++)
			{
				ref Vector4 reference = ref tangents[scr.OQOCCQDCCO[i]];
				ref Vector4 reference2 = ref tangents[scr.OOOCCCCODQ[i]];
				reference = (reference2 = (tangents[scr.OQOCCQDCCO[i]] + tangents[scr.OOOCCCCODQ[i]]) * 0.5f);
				ref Vector4 reference3 = ref tangents[scr.OQOCCQDCCOStart[i]];
				reference3 = tangents[scr.OQOCCQDCCOStart[i] + 1];
				ref Vector4 reference4 = ref tangents[scr.OOOCCCCODQStart[i]];
				reference4 = tangents[scr.OOOCCCCODQStart[i] + 1];
			}
			for (int i = 0; i < scr.ODCDCOODCQ.Count; i++)
			{
				ref Vector4 reference5 = ref tangents[scr.ODCDCOODCQ[i]];
				ref Vector4 reference6 = ref tangents[scr.OCDDDQCCOO[i]];
				reference5 = (reference6 = (tangents[scr.ODCDCOODCQ[i]] + tangents[scr.OCDDDQCCOO[i]]) * 0.5f);
				ref Vector4 reference7 = ref tangents[scr.ODCDCOODCQStart[i]];
				reference7 = tangents[scr.ODCDCOODCQStart[i] + 1];
				ref Vector4 reference8 = ref tangents[scr.OCDDDQCCOOStart[i]];
				reference8 = tangents[scr.OCDDDQCCOOStart[i] + 1];
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				for (int i = 0; i < scr.OCDCDQQCDD.Count; i++)
				{
					ref Vector4 reference9 = ref tangents[scr.OCDCDQQCDD[i]];
					ref Vector4 reference10 = ref tangents[scr.OQCQCCCQQC[i]];
					reference9 = (reference10 = (tangents[scr.OCDCDQQCDD[i]] + tangents[scr.OQCQCCCQQC[i]]) * 0.5f);
					ref Vector4 reference11 = ref tangents[scr.OCDCDQQCDDStart[i]];
					reference11 = tangents[scr.OCDCDQQCDDStart[i] + 1];
					ref Vector4 reference12 = ref tangents[scr.OQCQCCCQQCStart[i]];
					reference12 = tangents[scr.OQCQCCCQQCStart[i] + 1];
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				for (int i = 0; i < scr.OCCDCQDDDD.Count; i++)
				{
					ref Vector4 reference13 = ref tangents[scr.OCCDCQDDDD[i]];
					ref Vector4 reference14 = ref tangents[scr.ODQQCQDOQC[i]];
					reference13 = (reference14 = (tangents[scr.OCCDCQDDDD[i]] + tangents[scr.ODQQCQDOQC[i]]) * 0.5f);
				}
			}
			return tangents;
		}

		public static Vector4[] AdjustSidewalkTangents(ERCrossings scr, Vector4[] tangents)
		{
			for (int i = 0; i < tangents.Length; i++)
			{
				ref Vector4 reference = ref tangents[i];
				reference = new Vector4(-1f, 0f, 0f, -1f);
			}
			return tangents;
		}

		public static Vector3[] ODDODCQQCC(ERRoundabouts scr, Vector3[] normals)
		{
			for (int i = 0; i < scr.connections.Count; i++)
			{
				List<int> rightSidewalkNormalsStart = scr.connections[i].rightSidewalkNormalsStart;
				List<int> rightSidewalkNormalsEnd = scr.connections[i].rightSidewalkNormalsEnd;
				List<int> leftSidewalkNormalsStart;
				List<int> leftSidewalkNormalsEnd;
				if (scr.connections.Count == 1)
				{
					leftSidewalkNormalsStart = scr.connections[0].leftSidewalkNormalsStart;
					leftSidewalkNormalsEnd = scr.connections[0].leftSidewalkNormalsEnd;
				}
				else if (i == 0)
				{
					leftSidewalkNormalsStart = scr.connections[scr.connections.Count - 1].leftSidewalkNormalsStart;
					leftSidewalkNormalsEnd = scr.connections[scr.connections.Count - 1].leftSidewalkNormalsEnd;
				}
				else
				{
					leftSidewalkNormalsStart = scr.connections[i - 1].leftSidewalkNormalsStart;
					leftSidewalkNormalsEnd = scr.connections[i - 1].leftSidewalkNormalsEnd;
				}
				for (int j = 0; j < rightSidewalkNormalsStart.Count; j++)
				{
					if (rightSidewalkNormalsEnd[j] < normals.Length && leftSidewalkNormalsEnd[j] < normals.Length)
					{
						ref Vector3 reference = ref normals[rightSidewalkNormalsEnd[j]];
						ref Vector3 reference2 = ref normals[leftSidewalkNormalsEnd[j]];
						reference = (reference2 = (normals[rightSidewalkNormalsEnd[j]] + normals[leftSidewalkNormalsEnd[j]]) * 0.5f);
					}
					if (rightSidewalkNormalsStart[j] + 1 < normals.Length)
					{
						ref Vector3 reference3 = ref normals[rightSidewalkNormalsStart[j]];
						reference3 = normals[rightSidewalkNormalsStart[j] + 1];
					}
					if (leftSidewalkNormalsStart[j] + 1 < normals.Length)
					{
						ref Vector3 reference4 = ref normals[leftSidewalkNormalsStart[j]];
						reference4 = normals[leftSidewalkNormalsStart[j] + 1];
					}
				}
			}
			for (int i = 0; i < scr.innerRoundaboutSidewalkIntsStart.Count; i++)
			{
				ref Vector3 reference5 = ref normals[scr.innerRoundaboutSidewalkIntsStart[i]];
				ref Vector3 reference6 = ref normals[scr.innerRoundaboutSidewalkIntsEnd[i]];
				reference5 = (reference6 = (normals[scr.innerRoundaboutSidewalkIntsStart[i]] + normals[scr.innerRoundaboutSidewalkIntsEnd[i]]) * 0.5f);
			}
			return normals;
		}

		public static Vector3[] SnapSidewalkCornersVecs(ERCrossings scr, Vector3[] vecs)
		{
			for (int i = 0; i < scr.OQOCCQDCCO.Count; i++)
			{
				ref Vector3 reference = ref vecs[scr.OQOCCQDCCO[i]];
				ref Vector3 reference2 = ref vecs[scr.OOOCCCCODQ[i]];
				reference = (reference2 = (vecs[scr.OQOCCQDCCO[i]] + vecs[scr.OOOCCCCODQ[i]]) * 0.5f);
			}
			for (int i = 0; i < scr.ODCDCOODCQ.Count; i++)
			{
				ref Vector3 reference3 = ref vecs[scr.ODCDCOODCQ[i]];
				ref Vector3 reference4 = ref vecs[scr.OCDDDQCCOO[i]];
				reference3 = (reference4 = (vecs[scr.ODCDCOODCQ[i]] + vecs[scr.OCDDDQCCOO[i]]) * 0.5f);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				for (int i = 0; i < scr.OCDCDQQCDD.Count; i++)
				{
					ref Vector3 reference5 = ref vecs[scr.OCDCDQQCDD[i]];
					ref Vector3 reference6 = ref vecs[scr.OQCQCCCQQC[i]];
					reference5 = (reference6 = (vecs[scr.OCDCDQQCDD[i]] + vecs[scr.OQCQCCCQQC[i]]) * 0.5f);
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				for (int i = 0; i < scr.OCCDCQDDDD.Count; i++)
				{
					ref Vector3 reference7 = ref vecs[scr.OCCDCQDDDD[i]];
					ref Vector3 reference8 = ref vecs[scr.ODQQCQDOQC[i]];
					reference7 = (reference8 = (vecs[scr.OCCDCQDDDD[i]] + vecs[scr.ODQQCQDOQC[i]]) * 0.5f);
				}
			}
			return vecs;
		}

		public static void ODDQQCDDQD(ERModularBase baseScript, ERSideWalk sw, Vector3 pos)
		{
			Transform transform = null;
			if (baseScript != null)
			{
				transform = baseScript.transform.Find("Temp Sidewalk");
			}
			if (transform == null)
			{
				GameObject gameObject = new GameObject("Temp Sidewalk");
				transform = gameObject.transform;
				transform.parent = baseScript.transform;
			}
			else
			{
				sidewalk = GameObject.Find(sw.name);
			}
			if (sidewalk == null)
			{
				sidewalk = new GameObject(sw.name);
			}
			sidewalk.transform.parent = transform;
			sidewalk.transform.position = pos;
			if (sidewalk.GetComponent<MeshRenderer>() == null)
			{
				sidewalk.AddComponent<MeshRenderer>();
				if (sw.material != null)
				{
					sidewalk.GetComponent<MeshRenderer>().sharedMaterial = sw.material;
				}
			}
			if (sidewalk.GetComponent<MeshFilter>() == null)
			{
				sidewalk.AddComponent<MeshFilter>().sharedMesh = new Mesh();
			}
		}

		public static void OCOCOQCDOQ(ERModularBase baseScript, ERSideWalk sw, GameObject sidewalkGO, List<Vector3> vecs, int leftRight, float offsetX)
		{
			int innerIndex = 0;
			List<bool> trisFlag = new List<bool>();
			List<Vector2> list = OCCDOOOOOQ(sw, ref innerIndex, ref trisFlag);
			List<float> sidewalkUVs = sw.sidewalkUVs;
			float num = 0f;
			if (sidewalkUVs.Count != list.Count)
			{
				sidewalkUVs.Clear();
				num = 0f;
				List<float> list2 = new List<float>();
				list2.Add(0f);
				for (int i = 1; i < list.Count; i++)
				{
					num += Vector2.Distance(list[i - 1], list[i]);
					list2.Add(num);
				}
				for (int i = 0; i < list.Count; i++)
				{
					sidewalkUVs.Add(list2[i] / num);
				}
			}
			if (vecs == null)
			{
				vecs = new List<Vector3>();
				num = 0f;
				for (int i = 0; i < 10; i++)
				{
					vecs.Add(Vector3.forward * num);
					num += 1f;
				}
			}
			OODOQQQCDD(sw, list, trisFlag, sidewalkUVs, vecs, leftRight, sidewalkGO, offsetX);
		}

		private static List<Vector2> OCCDOOOOOQ(ERSideWalk sw, ref int innerIndex, ref List<bool> trisFlag)
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 zero = Vector2.zero;
			list.Add(zero);
			trisFlag.Add(item: false);
			if (sw.beveledCurb)
			{
				if (sw.beveledHeight != 0f || sw.beveledDepth != 0f)
				{
					if (sw.beveledHeight > 0f)
					{
						zero.y = sw.beveledHeight;
						list.Add(zero);
						if (sw.hardEdges)
						{
							trisFlag.Add(item: true);
						}
						else
						{
							trisFlag.Add(item: false);
						}
					}
					if (sw.beveledDepth > 0f)
					{
						zero.y = sw.curbHeight;
						zero.x = sw.beveledDepth;
						list.Add(zero);
						if (sw.hardEdges)
						{
							trisFlag.Add(item: true);
						}
						else
						{
							trisFlag.Add(item: false);
						}
					}
				}
			}
			else
			{
				zero.y = sw.curbHeight;
				list.Add(zero);
				if (sw.hardEdges)
				{
					trisFlag.Add(item: true);
				}
				else
				{
					trisFlag.Add(item: false);
				}
			}
			zero.x = sw.curbDepth;
			zero.y = sw.curbHeight;
			list.Add(zero);
			trisFlag.Add(item: false);
			innerIndex = list.Count;
			zero.x = sw.sidewalkWidth - sw.curbDepth;
			list.Add(zero);
			trisFlag.Add(item: false);
			if (!sw.outerCurb)
			{
				zero.x = sw.sidewalkWidth;
				list.Add(zero);
				if (sw.hardEdges)
				{
					trisFlag.Add(item: true);
				}
				else
				{
					trisFlag.Add(item: false);
				}
			}
			else if (sw.outerCurb)
			{
				if (sw.beveledCurb)
				{
					if (sw.beveledDepth > 0f)
					{
						zero.x = sw.sidewalkWidth - sw.beveledDepth;
						list.Add(zero);
						if (sw.hardEdges)
						{
							trisFlag.Add(item: true);
						}
						else
						{
							trisFlag.Add(item: false);
						}
					}
					if (sw.beveledHeight > 0f)
					{
						zero.x = sw.sidewalkWidth;
						zero.y = sw.beveledHeight;
						list.Add(zero);
						if (sw.hardEdges)
						{
							trisFlag.Add(item: true);
						}
						else
						{
							trisFlag.Add(item: false);
						}
					}
				}
				else
				{
					zero.x = sw.sidewalkWidth;
					list.Add(zero);
					if (sw.hardEdges)
					{
						trisFlag.Add(item: true);
					}
					else
					{
						trisFlag.Add(item: false);
					}
				}
				zero.x = sw.sidewalkWidth;
				zero.y = 0f;
				list.Add(zero);
				trisFlag.Add(item: false);
			}
			return list;
		}

		public static void OODOQQQCDD(ERSideWalk sw, List<Vector2> shape, List<bool> trisFlag, List<float> uv, List<Vector3> spline, int leftright, GameObject sidewalkGO, float offsetX)
		{
			List<List<Vector3>> list = new List<List<Vector3>>();
			List<List<Vector2>> list2 = new List<List<Vector2>>();
			for (int i = 0; i < shape.Count; i++)
			{
				list.Add(new List<Vector3>());
				list2.Add(new List<Vector2>());
			}
			float num = 0f;
			for (int i = 0; i < spline.Count; i++)
			{
				Vector3 vector = ((i > 0 && i < spline.Count - 1) ? (spline[i + 1] - spline[i - 1]) : ((i != 0) ? (spline[i] - spline[i - 1]) : (spline[i + 1] - spline[0])));
				Vector3 normalized = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				normalized *= (float)leftright;
				if (i > 0)
				{
					num += Vector3.Distance(spline[i - 1], spline[i]);
				}
				float y = num / 2f;
				Vector3 vector2 = spline[i];
				for (int j = 0; j < shape.Count; j++)
				{
					Vector3 vector3 = vector2;
					vector3.y += shape[j].y;
					list[j].Add(vector3 + (shape[j].x + offsetX) * normalized);
					list2[j].Add(new Vector2(uv[j], y));
				}
			}
			int num2 = 0;
			List<int> list3 = new List<int>();
			for (int i = 0; i < trisFlag.Count; i++)
			{
				if (trisFlag[i])
				{
					num2++;
				}
				list3.Add(num2);
			}
			List<Vector3> vecs = new List<Vector3>();
			List<Vector2> uvs = new List<Vector2>();
			List<int> tris = new List<int>();
			int count = list.Count;
			int num3 = 0;
			for (int i = 0; i < list[0].Count; i++)
			{
				for (int j = 0; j < count; j++)
				{
					vecs.Add(list[j][i]);
					uvs.Add(list2[j][i]);
					if (trisFlag[j])
					{
						vecs.Add(list[j][i]);
						uvs.Add(list2[j][i]);
					}
					if (j < count - 1 && i < list[0].Count - 1)
					{
						if (leftright == -1)
						{
							tris.Add(num3 + j + list3[j]);
							tris.Add(num3 + j + count + num2 + 1 + list3[j]);
							tris.Add(num3 + j + count + num2 + list3[j]);
							tris.Add(num3 + j + list3[j]);
							tris.Add(num3 + j + list3[j] + 1);
							tris.Add(num3 + j + count + num2 + 1 + list3[j]);
						}
						else
						{
							tris.Add(num3 + j + list3[j]);
							tris.Add(num3 + j + count + num2 + list3[j]);
							tris.Add(num3 + j + count + num2 + 1 + list3[j]);
							tris.Add(num3 + j + list3[j]);
							tris.Add(num3 + j + count + num2 + 1 + list3[j]);
							tris.Add(num3 + j + list3[j] + 1);
						}
					}
				}
				num3 = i * (count + num2);
			}
			int count2 = vecs.Count;
			OQCODQCOOO(sw, list, list2, ref vecs, ref uvs, ref tris, leftright);
			int count3 = vecs.Count;
			OCDCQDCDOD.ODODQQQOOQ(sw, ref vecs, Vector3.zero, shape.Count + num2, count2, count3, 0);
			Mesh sharedMesh = sidewalkGO.GetComponent<MeshFilter>().sharedMesh;
			sharedMesh.Clear();
			sharedMesh.vertices = vecs.ToArray();
			sharedMesh.uv = uvs.ToArray();
			sharedMesh.triangles = tris.ToArray();
			sharedMesh.RecalculateNormals();
			sharedMesh.RecalculateBounds();
			sidewalkGO.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
		}

		public static void OQCODQCOOO(ERSideWalk sw, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<int> tris, int leftrightroad)
		{
			QDOQDSQOOQDDD qDOQDSQOOQDDD = new QDOQDSQOOQDDD(null);
			qDOQDSQOOQDDD.CopyFromSidewalk(sw);
			int triArrayElement = 0;
			List<List<int>> triList = new List<List<int>>();
			triList.Add(tris);
			List<List<int>> list = new List<List<int>>();
			for (int i = 0; i < vecs.Count; i++)
			{
				list.Add(new List<int>());
				list[i].Add(i);
			}
			if (leftrightroad == -1)
			{
				leftrightroad = 0;
			}
			if (qDOQDSQOOQDDD.outerCurb)
			{
				if (!qDOQDSQOOQDDD.beveledCurb)
				{
					OQDOOCODQQ.OCDOOODQCD(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
				else if (qDOQDSQOOQDDD.beveledHeight > 0f && qDOQDSQOOQDDD.beveledDepth > 0f)
				{
					OQDOOCODQQ.OCOCQDCQDQ(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
				else if (qDOQDSQOOQDDD.beveledHeight > 0f)
				{
					OQDOOCODQQ.OOQDOCDQOD(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
				else if (qDOQDSQOOQDDD.beveledDepth > 0f)
				{
					OQDOOCODQQ.OQOCOODDQC(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
				else
				{
					OQDOOCODQQ.ODDDCDOOCO(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
			}
			else if (!qDOQDSQOOQDDD.beveledCurb)
			{
				OQDOOCODQQ.OOQCOOOCQO(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
			else if (qDOQDSQOOQDDD.beveledHeight > 0f && qDOQDSQOOQDDD.beveledDepth > 0f)
			{
				OQDOOCODQQ.OQQOCDDDDO(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
			else if (qDOQDSQOOQDDD.beveledHeight > 0f)
			{
				OQDOOCODQQ.OCQOCOQDOQ(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
			else if (qDOQDSQOOQDDD.beveledDepth > 0f)
			{
				OQDOOCODQQ.OCQDCDOQCC(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
			else
			{
				OQDOOCODQQ.OODCQOCCCC(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
		}
	}
}
