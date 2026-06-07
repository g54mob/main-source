using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERSideWalkVecs : MonoBehaviour
	{
		public static GameObject sidewalk;

		public static void OCOOCOCCQC(ERCrossings scr)
		{
			OQCODQDDDD(scr);
			OOCCQCQQOD(scr);
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag)
			{
				OCQDDOCDCQ(scr, scr.leftSidewalkStartV3, scr.rightSidewalkLeftV3, scr.prefabScript.sidewalkControlElements[0], 0, 0, scr.leftStartSidewalkCornerInt);
				OCQDDOCDCQ(scr, scr.rightSidewalkLeftV3, scr.leftSidewalkStartV3, scr.prefabScript.sidewalkControlElements[0], 1, 1, scr.rightLeftSidewalkCornerInt);
				OOQDDOOCQO(ref scr.leftSidewalkStartV3, ref scr.rightSidewalkLeftV3);
				OCODDDCDQQ(scr, scr.leftSidewalkStartV3, ref scr.leftSidewalkStartUV, scr.prefabScript.sidewalkControlElements[0], reverse: true, scr.frontRoadUVTiling);
				OCODDDCDQQ(scr, scr.rightSidewalkLeftV3, ref scr.rightSidewalkLeftUV, scr.prefabScript.sidewalkControlElements[0], reverse: false, scr.rightRoadUVTiling);
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag)
			{
				OCQDDOCDCQ(scr, scr.rightSidewalkStartV3, scr.leftSidewalkRightV3, scr.prefabScript.sidewalkControlElements[1], 1, 0, scr.rightStartSidewalkCornerInt);
				OCQDDOCDCQ(scr, scr.leftSidewalkRightV3, scr.rightSidewalkStartV3, scr.prefabScript.sidewalkControlElements[1], 0, 1, scr.leftRightSidewalkCornerInt);
				OOQDDOOCQO(ref scr.rightSidewalkStartV3, ref scr.leftSidewalkRightV3);
				OCODDDCDQQ(scr, scr.rightSidewalkStartV3, ref scr.rightSidewalkStartUV, scr.prefabScript.sidewalkControlElements[1], reverse: false, scr.frontRoadUVTiling);
				OCODDDCDQQ(scr, scr.leftSidewalkRightV3, ref scr.leftSidewalkRightUV, scr.prefabScript.sidewalkControlElements[1], reverse: true, scr.leftRoadUVTiling);
			}
			if (scr.prefabScript.sidewalkControlElements[3].renderFlag)
			{
				OCQDDOCDCQ(scr, scr.leftSidewalkEndV3, scr.rightSidewalkRightV3, scr.prefabScript.sidewalkControlElements[3], 0, 0, scr.leftEndSidewalkCornerInt);
				OCQDDOCDCQ(scr, scr.rightSidewalkRightV3, scr.leftSidewalkEndV3, scr.prefabScript.sidewalkControlElements[3], 1, 1, scr.rightRightSidewalkCornerInt);
				OOQDDOOCQO(ref scr.leftSidewalkEndV3, ref scr.rightSidewalkRightV3);
				OCODDDCDQQ(scr, scr.leftSidewalkEndV3, ref scr.leftSidewalkEndUV, scr.prefabScript.sidewalkControlElements[3], reverse: true, scr.backRoadUVTiling);
				OCODDDCDQQ(scr, scr.rightSidewalkRightV3, ref scr.rightSidewalkRightUV, scr.prefabScript.sidewalkControlElements[3], reverse: false, scr.rightRoadUVTiling);
			}
			if (scr.prefabScript.sidewalkControlElements[2].renderFlag)
			{
				OCQDDOCDCQ(scr, scr.rightSidewalkEndV3, scr.leftSidewalkLeftV3, scr.prefabScript.sidewalkControlElements[2], 1, 0, scr.rightEndSidewalkCornerInt);
				OCQDDOCDCQ(scr, scr.leftSidewalkLeftV3, scr.rightSidewalkEndV3, scr.prefabScript.sidewalkControlElements[2], 0, 1, scr.leftLeftSidewalkCornerInt);
				OOQDDOOCQO(ref scr.rightSidewalkEndV3, ref scr.leftSidewalkLeftV3);
				OCODDDCDQQ(scr, scr.rightSidewalkEndV3, ref scr.rightSidewalkEndUV, scr.prefabScript.sidewalkControlElements[2], reverse: false, scr.backRoadUVTiling);
				OCODDDCDQQ(scr, scr.leftSidewalkLeftV3, ref scr.leftSidewalkLeftUV, scr.prefabScript.sidewalkControlElements[2], reverse: true, scr.leftRoadUVTiling);
			}
		}

		public static void OQCODQDDDD(ERCrossings scr)
		{
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag)
			{
				OCDDOCQDDO(scr, scr.startConnectionV3[0], scr.leftConnectionV3[scr.leftConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 1, ref scr.leftStartSidewalkCornerInt);
				OCDDOCQDDO(scr, scr.leftConnectionV3[scr.leftConnectionV3.Count - 1], scr.startConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 0, ref scr.rightLeftSidewalkCornerInt);
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag)
			{
				OCDDOCQDDO(scr, scr.startConnectionV3[scr.startConnectionV3.Count - 1], scr.rightConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 1, ref scr.rightStartSidewalkCornerInt);
				OCDDOCQDDO(scr, scr.rightConnectionV3[0], scr.startConnectionV3[scr.startConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 0, ref scr.leftRightSidewalkCornerInt);
			}
			if (scr.prefabScript.sidewalkControlElements[3].renderFlag)
			{
				OCDDOCQDDO(scr, scr.endConnectionV3[0], scr.rightConnectionV3[scr.rightConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 1, ref scr.leftEndSidewalkCornerInt);
				OCDDOCQDDO(scr, scr.rightConnectionV3[scr.rightConnectionV3.Count - 1], scr.endConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 0, ref scr.rightRightSidewalkCornerInt);
			}
			if (scr.prefabScript.sidewalkControlElements[2].renderFlag)
			{
				OCDDOCQDDO(scr, scr.endConnectionV3[scr.endConnectionV3.Count - 1], scr.leftConnectionV3[0][0], scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 1, ref scr.rightEndSidewalkCornerInt);
				OCDDOCQDDO(scr, scr.leftConnectionV3[0], scr.endConnectionV3[scr.endConnectionV3.Count - 1][0], scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 0, ref scr.leftLeftSidewalkCornerInt);
			}
		}

		public static void OCDDOCQDDO(ERCrossings scr, List<Vector3> vecArray, Vector3 firstOther, float sidewalkWidth, int xorz, ref int cornerInt)
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

		public static void OCQDDOCDCQ(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector3>> vecArrayOther, QDOQDSQOOQDDD corner, int startEnd, int mainOrConnected, int outerCornerInt)
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
					vecArray[vecArray.Count - 1].AddRange(ODDCOCQDOQ(vecArray[0], num2));
				}
				num2 = corner.curbHeight;
				if (corner.beveledDepth > 0f && corner.beveledDepth != corner.curbDepth)
				{
					num = corner.beveledDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
				}
				if (corner.beveledDepth != corner.curbDepth)
				{
					num = corner.curbDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
				}
			}
			else
			{
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODDCOCQDOQ(vecArray[0], num2));
				num = corner.curbDepth;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], vecArrayOther[0], num, num2, startEnd, mainOrConnected, -1));
			}
			num = corner.curbDepth;
			vecArray.Add(new List<Vector3>());
			vecArray[vecArray.Count - 1].AddRange(OCQCDQCQDD(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
			if (corner.beveledCurb && corner.outerCurb)
			{
				if (corner.beveledDepth != corner.curbDepth && corner.beveledDepth > 0f)
				{
					num = corner.beveledDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OCQCDQCQDD(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				}
				if (corner.beveledHeight > 0f && corner.beveledHeight != corner.curbHeight && corner.outerCurb)
				{
					num2 = corner.beveledHeight;
					num = 0f;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OCQCDQCQDD(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				}
				num2 = 0f;
				num = 0f;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OCQCDQCQDD(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
			}
			else
			{
				num = 0f;
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OCQCDQCQDD(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				if (corner.outerCurb)
				{
					num2 = 0f;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OCQCDQCQDD(scr, vecArray[0], vecArrayOther[0], num, num2, corner.sidewalkWidth1, startEnd, mainOrConnected, outerCornerInt));
				}
			}
		}

		public static void OOCCQCQQOD(ERCrossings scr)
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

		public static List<Vector3> OOODQOQDDC(List<Vector3> outer, List<Vector3> outerOther, float dist, float height, int startend, int leftright, int outerCornerInt)
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

		public static List<Vector3> OCQCDQCQDD(ERCrossings scr, List<Vector3> innerArray, List<Vector3> outerOther, float dist, float height, float sidewalkWidth, int startend, int leftright, int outerCornerInt)
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
					Vector3 vector3 = OQQOCDQCQD.OCDCQCDDCC(vector, p, innerArray[i], vector2, flag: false);
					normalized = (innerArray[i] - vector3).normalized;
					vector3 += normalized * dist;
					vector3.y = height;
					list.Add(vector3);
				}
			}
			else
			{
				for (int j = 0; j < innerArray.Count; j++)
				{
					Vector3 normalized = ((j != 0) ? ((j >= innerArray.Count - 1) ? (innerArray[innerArray.Count - 1] - innerArray[innerArray.Count - 2]) : (innerArray[j + 1] - innerArray[j - 1])) : (innerArray[1] - innerArray[0]));
					normalized = (((leftright != 0 || startend != 0) && (leftright != 1 || startend != 0)) ? new Vector3(normalized.z, 0f, 0f - normalized.x).normalized : new Vector3(0f - normalized.z, 0f, normalized.x).normalized);
					Vector3 vector3 = innerArray[j] + normalized * sidewalkWidth;
					vector3.y = height;
					list.Add(vector3);
				}
			}
			return list;
		}

		public static List<Vector3> ODDCOCQDOQ(List<Vector3> outer, float height)
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

		public static void OCODDDCDQQ(ERCrossings scr, List<List<Vector3>> vecArray, ref List<List<Vector2>> uvArray, QDOQDSQOOQDDD corner, bool reverse, float uvTiling)
		{
			if (corner.sidewalkUVs.Count == 0 || !corner.lockUVs)
			{
				OQDQCOOQCO(vecArray, ref corner.sidewalkUVs);
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

		public static void OQDQCOOQCO(List<List<Vector3>> vecArray, ref List<float> sidewalkUVs)
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
			for (int j = 0; j < list.Count; j++)
			{
				sidewalkUVs.Add(list[j] / num);
			}
		}

		public static void OOQDDOOCQO(ref List<List<Vector3>> outer1, ref List<List<Vector3>> outer2)
		{
			for (int i = 0; i < outer1.Count; i++)
			{
				if (outer1[i][outer1[i].Count - 1] != outer2[i][outer2[i].Count - 1])
				{
					Vector3 vector = OQQOCDQCQD.OCDCQCDDCC(outer1[i][outer1[i].Count - 1], outer1[i][outer1[i].Count - 2], outer2[i][outer2[i].Count - 1], outer2[i][outer2[i].Count - 2], flag: false);
					List<Vector3> list = outer1[i];
					int index = outer1[i].Count - 1;
					Vector3 value = (outer2[i][outer2[i].Count - 1] = vector);
					list[index] = value;
				}
			}
		}

		public static Vector3[] OQQDDCOQDD(ERCrossings scr, Vector3[] normals)
		{
			for (int i = 0; i < scr.ODDDDDODQC.Count; i++)
			{
				normals[scr.ODDDDDODQC[i]] = (normals[scr.OQOQQQQQCO[i]] = (normals[scr.ODDDDDODQC[i]] + normals[scr.OQOQQQQQCO[i]]) * 0.5f);
				normals[scr.ODDDDDODQCStart[i]] = normals[scr.ODDDDDODQCStart[i] + 1];
				normals[scr.OQOQQQQQCOStart[i]] = normals[scr.OQOQQQQQCOStart[i] + 1];
			}
			for (int j = 0; j < scr.OOODDDQQDD.Count; j++)
			{
				normals[scr.OOODDDQQDD[j]] = (normals[scr.OCCCOQDDCC[j]] = (normals[scr.OOODDDQQDD[j]] + normals[scr.OCCCOQDDCC[j]]) * 0.5f);
				normals[scr.OOODDDQQDDStart[j]] = normals[scr.OOODDDQQDDStart[j] + 1];
				normals[scr.OCCCOQDDCCStart[j]] = normals[scr.OCCCOQDDCCStart[j] + 1];
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				for (int k = 0; k < scr.ODOCCCOCOO.Count; k++)
				{
					normals[scr.ODOCCCOCOO[k]] = (normals[scr.OQDCOODOCD[k]] = (normals[scr.ODOCCCOCOO[k]] + normals[scr.OQDCOODOCD[k]]) * 0.5f);
					normals[scr.ODOCCCOCOOStart[k]] = normals[scr.ODOCCCOCOOStart[k] + 1];
					normals[scr.OQDCOODOCDStart[k]] = normals[scr.OQDCOODOCDStart[k] + 1];
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				for (int l = 0; l < scr.ODQDQQOOQQ.Count; l++)
				{
					normals[scr.ODQDQQOOQQ[l]] = (normals[scr.OCQOCDCQOD[l]] = (normals[scr.ODQDQQOOQQ[l]] + normals[scr.OCQOCDCQOD[l]]) * 0.5f);
				}
			}
			return normals;
		}

		public static Vector4[] AdjustSidewalkTangents1(ERCrossings scr, Vector4[] tangents)
		{
			for (int i = 0; i < scr.ODDDDDODQC.Count; i++)
			{
				tangents[scr.ODDDDDODQC[i]] = (tangents[scr.OQOQQQQQCO[i]] = (tangents[scr.ODDDDDODQC[i]] + tangents[scr.OQOQQQQQCO[i]]) * 0.5f);
				tangents[scr.ODDDDDODQCStart[i]] = tangents[scr.ODDDDDODQCStart[i] + 1];
				tangents[scr.OQOQQQQQCOStart[i]] = tangents[scr.OQOQQQQQCOStart[i] + 1];
			}
			for (int j = 0; j < scr.OOODDDQQDD.Count; j++)
			{
				tangents[scr.OOODDDQQDD[j]] = (tangents[scr.OCCCOQDDCC[j]] = (tangents[scr.OOODDDQQDD[j]] + tangents[scr.OCCCOQDDCC[j]]) * 0.5f);
				tangents[scr.OOODDDQQDDStart[j]] = tangents[scr.OOODDDQQDDStart[j] + 1];
				tangents[scr.OCCCOQDDCCStart[j]] = tangents[scr.OCCCOQDDCCStart[j] + 1];
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				for (int k = 0; k < scr.ODOCCCOCOO.Count; k++)
				{
					tangents[scr.ODOCCCOCOO[k]] = (tangents[scr.OQDCOODOCD[k]] = (tangents[scr.ODOCCCOCOO[k]] + tangents[scr.OQDCOODOCD[k]]) * 0.5f);
					tangents[scr.ODOCCCOCOOStart[k]] = tangents[scr.ODOCCCOCOOStart[k] + 1];
					tangents[scr.OQDCOODOCDStart[k]] = tangents[scr.OQDCOODOCDStart[k] + 1];
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				for (int l = 0; l < scr.ODQDQQOOQQ.Count; l++)
				{
					tangents[scr.ODQDQQOOQQ[l]] = (tangents[scr.OCQOCDCQOD[l]] = (tangents[scr.ODQDQQOOQQ[l]] + tangents[scr.OCQOCDCQOD[l]]) * 0.5f);
				}
			}
			return tangents;
		}

		public static Vector4[] AdjustSidewalkTangents(ERCrossings scr, Vector4[] tangents)
		{
			for (int i = 0; i < tangents.Length; i++)
			{
				tangents[i] = new Vector4(-1f, 0f, 0f, -1f);
			}
			return tangents;
		}

		public static Vector3[] OCQDQCODCD(ERRoundabouts scr, Vector3[] normals)
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
						normals[rightSidewalkNormalsEnd[j]] = (normals[leftSidewalkNormalsEnd[j]] = (normals[rightSidewalkNormalsEnd[j]] + normals[leftSidewalkNormalsEnd[j]]) * 0.5f);
					}
					if (rightSidewalkNormalsStart[j] + 1 < normals.Length)
					{
						normals[rightSidewalkNormalsStart[j]] = normals[rightSidewalkNormalsStart[j] + 1];
					}
					if (leftSidewalkNormalsStart[j] + 1 < normals.Length)
					{
						normals[leftSidewalkNormalsStart[j]] = normals[leftSidewalkNormalsStart[j] + 1];
					}
				}
			}
			for (int k = 0; k < scr.innerRoundaboutSidewalkIntsStart.Count; k++)
			{
				normals[scr.innerRoundaboutSidewalkIntsStart[k]] = (normals[scr.innerRoundaboutSidewalkIntsEnd[k]] = (normals[scr.innerRoundaboutSidewalkIntsStart[k]] + normals[scr.innerRoundaboutSidewalkIntsEnd[k]]) * 0.5f);
			}
			return normals;
		}

		public static Vector3[] SnapSidewalkCornersVecs(ERCrossings scr, Vector3[] vecs)
		{
			for (int i = 0; i < scr.ODDDDDODQC.Count; i++)
			{
				vecs[scr.ODDDDDODQC[i]] = (vecs[scr.OQOQQQQQCO[i]] = (vecs[scr.ODDDDDODQC[i]] + vecs[scr.OQOQQQQQCO[i]]) * 0.5f);
			}
			for (int j = 0; j < scr.OOODDDQQDD.Count; j++)
			{
				vecs[scr.OOODDDQQDD[j]] = (vecs[scr.OCCCOQDDCC[j]] = (vecs[scr.OOODDDQQDD[j]] + vecs[scr.OCCCOQDDCC[j]]) * 0.5f);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				for (int k = 0; k < scr.ODOCCCOCOO.Count; k++)
				{
					vecs[scr.ODOCCCOCOO[k]] = (vecs[scr.OQDCOODOCD[k]] = (vecs[scr.ODOCCCOCOO[k]] + vecs[scr.OQDCOODOCD[k]]) * 0.5f);
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				for (int l = 0; l < scr.ODQDQQOOQQ.Count; l++)
				{
					vecs[scr.ODQDQQOOQQ[l]] = (vecs[scr.OCQOCDCQOD[l]] = (vecs[scr.ODQDQQOOQQ[l]] + vecs[scr.OCQOCDCQOD[l]]) * 0.5f);
				}
			}
			return vecs;
		}

		public static void OQQQCQCDOQ(ERModularBase baseScript, ERSideWalk sw, Vector3 pos)
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

		public static void OCCDCDODDO(ERSideWalk sw, GameObject sidewalkGO, List<Vector3> vecs, int leftRight, float offsetX, bool updateMesh)
		{
			int innerIndex = 0;
			List<bool> trisFlag = new List<bool>();
			List<Vector2> list = OCCQODQQCQ(sw, ref innerIndex, ref trisFlag);
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
				for (int j = 0; j < list.Count; j++)
				{
					sidewalkUVs.Add(list2[j] / num);
				}
			}
			if (vecs == null)
			{
				vecs = new List<Vector3>();
				num = 0f;
				for (int k = 0; k < 10; k++)
				{
					vecs.Add(Vector3.forward * num);
					num += 1f;
				}
			}
			sw.shape = list;
			sw.doConnectionTri = trisFlag;
			sw.sidewalkUVs = sidewalkUVs;
			List<Vector3> positions = new List<Vector3>();
			List<Vector3> perpPositions = new List<Vector3>();
			List<int> middleIndexes = new List<int>();
			List<Vector3> list3 = new List<Vector3>();
			List<Vector3> list4 = new List<Vector3>();
			List<int> list5 = new List<int>();
			List<float> sidewalksDistances = new List<float>();
			if (updateMesh)
			{
				OCOCDCDDOD(null, sw, list, trisFlag, sidewalkUVs, vecs, new List<Vector3>(), leftRight, sidewalkGO, offsetX, closedStart: true, closedEnd: true, ref positions, ref perpPositions, ref middleIndexes, ref sidewalksDistances);
			}
		}

		private static List<Vector2> OCCQODQQCQ(ERSideWalk sw, ref int innerIndex, ref List<bool> trisFlag)
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
			innerIndex = (sw.pavementIndex = list.Count);
			sw.pavementIndex = innerIndex - 1;
			zero.x = sw.sidewalkWidth - sw.curbDepth;
			list.Add(zero);
			trisFlag.Add(item: false);
			if (!sw.outerCurb)
			{
				zero.x = sw.sidewalkWidth;
				list.Add(zero);
				trisFlag.Add(item: false);
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

		public static List<Vector3> OCOCDCDDOD(ERModularRoad road, ERSideWalk sw, List<Vector2> shape, List<bool> trisFlag, List<float> uv, List<Vector3> splineTmp, List<Vector3> spline2Tmp, int leftright, GameObject sidewalkGO, float offsetX, bool closedStart, bool closedEnd, ref List<Vector3> positions, ref List<Vector3> perpPositions, ref List<int> middleIndexes, ref List<float> sidewalksDistances)
		{
			List<Vector3> list = new List<Vector3>(splineTmp);
			List<Vector3> list2 = new List<Vector3>(spline2Tmp);
			List<float> list3 = new List<float>();
			if (road != null)
			{
				list3 = new List<float>(road.distances);
			}
			List<List<Vector3>> list4 = new List<List<Vector3>>();
			List<List<Vector2>> list5 = new List<List<Vector2>>();
			for (int i = 0; i < shape.Count; i++)
			{
				list4.Add(new List<Vector3>());
				list5.Add(new List<Vector2>());
			}
			float num = sw.tiling / sw.uvRatio;
			if (road != null)
			{
				float num2 = Mathf.Round(road.totalDistance * num);
				num = num2 / road.totalDistance;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			int num7 = 0;
			float num8 = 0f;
			List<float> list6 = new List<float>();
			List<int> list7 = new List<int>();
			int num9 = 0;
			List<ERCrosswalkInstance> list8 = new List<ERCrosswalkInstance>();
			if (road != null)
			{
				if (road.rt == null && road.roadType != 0.0)
				{
					road.rt = QDQDOOQQDQODD.GetRoadTypeElByID(road.baseScript.roadTypes, road.roadType);
				}
				if (road.rt == null)
				{
					return null;
				}
				if (sw.crosswalkPavement && sw.crosswalkSize > 0f && road.rt != null && road.rt.crosswalks)
				{
					flag = true;
					num3 = road.rt.crosswalkIntervals;
					if (num3 < sw.crosswalkSize)
					{
						num3 = sw.crosswalkSize + 10f;
					}
					num4 = sw.crosswalkSize;
					num5 = sw.crosswalkWidth;
				}
			}
			float num10 = num4;
			float num11 = num4 * 0.5f;
			int num12 = 5;
			int num13 = 3;
			if (sw.includeOuterStrip)
			{
				num12 = 7;
				num13 = 4;
			}
			int num14 = 0;
			int num15 = 0;
			int num16 = 0;
			int count = sw.yPositions.Count;
			List<Vector3> vecs = new List<Vector3>();
			List<Vector2> uvs = new List<Vector2>();
			List<int> tris = new List<int>();
			int count2 = list4.Count;
			int num17 = 0;
			int num18 = 0;
			List<int> list9 = new List<int>();
			for (int j = 0; j < trisFlag.Count; j++)
			{
				if (trisFlag[j])
				{
					num18++;
				}
				list9.Add(num18);
			}
			float num19 = 0f;
			float num20 = 0f;
			Vector3 a = list[0];
			int num21 = list.Count;
			for (int k = 0; k < num21; k++)
			{
				Vector3 normalized;
				if (list2.Count == 0)
				{
					Vector3 vector = ((k > 0 && k < list.Count - 1) ? (list[k + 1] - list[k - 1]) : ((k != 0) ? (list[k] - list[k - 1]) : (list[k + 1] - list[0])));
					normalized = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
					normalized *= (float)leftright;
				}
				else
				{
					normalized = (list[k] - list2[k]).normalized;
				}
				Vector3 vector2 = list[k];
				if (flag && !flag2 && list3[k] - num6 > num3 && list3[k] + num4 + 10f < road.totalDistance)
				{
					flag2 = true;
					num7 = k;
					sidewalksDistances.Add(list3[k]);
					float t = (num3 - list3[k - 1]) / (list3[k] - list3[k - 1]);
					Vector3 normalized2 = (list2[k] - list[k]).normalized;
					float num22 = Vector3.Distance(list2[k], list[k]);
					vector2 = (list[k] = Vector3.Lerp(list[k - 1], list[k], t));
					list2[k] = list[k] + normalized2 * num22;
					if (Vector3.Distance(vector2, list[k - 1]) < 0.5f)
					{
						list.RemoveAt(k - 1);
						list2.RemoveAt(k - 1);
						list3.RemoveAt(k - 1);
						for (int l = 0; l < count2; l++)
						{
							list4[l].RemoveAt(k - 1);
							list5[l].RemoveAt(k - 1);
						}
						num21--;
						k--;
						num17 = k * (count2 + num18);
						vecs.RemoveRange(vecs.Count - sw.realColCount, sw.realColCount);
						uvs.RemoveRange(uvs.Count - sw.realColCount, sw.realColCount);
						tris.RemoveRange(tris.Count - (sw.shape.Count - 1) * 6 + sw.pavementIndex * 6, 6);
					}
					float num23 = 0f;
					int num24 = 1;
					Vector3 vector4 = vector2;
					while (num24 < num12 && k + num24 < num21)
					{
						num23 += Vector3.Distance(vector4, list[k + num24]);
						if (num23 > num4)
						{
							normalized2 = ((num24 > num13) ? (list[k + num24] - vector4).normalized : (list[k + num24 - 1] - list[k + num24 - 2]).normalized);
							Vector3 normalized3 = (list[k + num24 - 1] - list2[k + num24 - 1]).normalized;
							Vector3 normalized4 = (list[k + num24] - list2[k + num24]).normalized;
							float num25 = Vector3.Distance(list[k + num24 - 1], list[k + num24]);
							Vector3 a2 = list[k + num24 - 1];
							while (num24 < num12 && num24 < count)
							{
								Vector3 vector5 = vector4 + normalized2 * (sw.yPositions[num24] - sw.yPositions[num24 - 1]);
								list.Insert(k + num24, vector5);
								float num26 = Vector3.Distance(a2, vector5);
								Vector3 vector6 = Vector3.Lerp(normalized3, normalized4, num26 / num25);
								list2.Insert(k + num24, vector5 - vector6 * num22);
								list3.Insert(k + num24, list3[k + num24 - 1]);
								num21++;
								vector4 = list[k + num24];
								if (num24 == num13 - 1)
								{
									positions.Add(vector5);
									perpPositions.Add(vector5 - vector6 * num22);
									middleIndexes.Add(k + num24);
								}
								num24++;
								if (num24 >= num13)
								{
									normalized2 = (list[k + num24] - vector4).normalized;
								}
							}
						}
						else
						{
							if (num23 < sw.yPositions[num24])
							{
								vector4 = list[k + num24];
								list.RemoveAt(k + num24);
								list2.RemoveAt(k + num24);
								list3.RemoveAt(k + num24);
								num21--;
								continue;
							}
							Vector3 normalized5 = (list[k + num24 - 1] - list2[k + num24 - 1]).normalized;
							Vector3 normalized6 = (list[k + num24 + 1] - list2[k + num24 + 1]).normalized;
							float num27 = Vector3.Distance(list[k + num24 - 1], list[k + num24 + 1]);
							normalized2 = (list[k + num24] - vector4).normalized;
							list[k + num24] = vector4 + normalized2 * (sw.yPositions[num24] - sw.yPositions[num24 - 1]);
							float num28 = Vector3.Distance(list[k + num24 - 1], list[k + num24]);
							Vector3 vector6 = Vector3.Lerp(normalized5, normalized6, num28 / num27);
							list2[k + num24] = list[k + num24] - vector6;
						}
						vector4 = list[k + num24];
						if (num24 == num13 - 1)
						{
							positions.Add(vector4);
							perpPositions.Add(list2[k + num24]);
							middleIndexes.Add(k + num24);
						}
						if (num24 < sw.yPositions.Count)
						{
							num23 = sw.yPositions[num24];
						}
						num24++;
					}
					if (Vector3.Distance(vector4, list[k + num24 - 2]) < 0.5f)
					{
						list.RemoveAt(k + num24 - 1);
						list2.RemoveAt(k + num24 - 1);
						list3.RemoveAt(k + num24 - 1);
						num21--;
					}
					num8 = 0f - Mathf.Lerp(sw.crosswalkMinHeight, sw.crosswalkMaxHeight, UnityEngine.Random.value) + sw.curbHeight;
					num10 = num6 + num3 + num4;
					num14 = k + num12;
					num15 = ((num12 != 5) ? (k + 2) : (k + 1));
					num16 = num15 + 2;
					list7.Clear();
					list6.Clear();
					list7.Add(vecs.Count + sw.realPavementIndex - sw.realColCount);
				}
				if (k > 0)
				{
					num19 += Vector3.Distance(a, vector2);
				}
				a = vector2;
				num20 = num19 * num;
				if (flag2)
				{
					if (k > num14)
					{
						flag2 = false;
						num6 = num10;
						list8.Add(new ERCrosswalkInstance(new List<int>(list7), sw, new List<float>(list6), num8, 0));
						list7.Clear();
						list6.Clear();
					}
					else
					{
						list6.Add(num20);
					}
				}
				for (int m = 0; m < count2; m++)
				{
					Vector3 vector4 = vector2 + (shape[m].x + offsetX) * normalized;
					vector4.y += shape[m].y;
					if (flag2 && k >= num15 && k <= num16 && m <= sw.pavementIndex)
					{
						vector4.y -= num8;
					}
					Vector2 item = new Vector2(uv[m], num20);
					list4[m].Add(vector4);
					list5[m].Add(item);
					vecs.Add(vector4);
					uvs.Add(item);
					if (trisFlag[m])
					{
						vecs.Add(list4[m][k]);
						Vector2 item2 = list5[m][k];
						item2.x += sw.hardEdgePadding;
						uvs.Add(item2);
					}
					if (m < count2 - 1 && k < list4[0].Count && (!flag2 || m < sw.pavementIndex || m >= sw.pavementIndex + 1))
					{
						if (leftright == -1)
						{
							tris.Add(num17 + m + list9[m]);
							tris.Add(num17 + m + count2 + num18 + 1 + list9[m]);
							tris.Add(num17 + m + count2 + num18 + list9[m]);
							tris.Add(num17 + m + list9[m]);
							tris.Add(num17 + m + list9[m] + 1);
							tris.Add(num17 + m + count2 + num18 + 1 + list9[m]);
						}
						else
						{
							tris.Add(num17 + m + list9[m]);
							tris.Add(num17 + m + count2 + num18 + list9[m]);
							tris.Add(num17 + m + count2 + num18 + 1 + list9[m]);
							tris.Add(num17 + m + list9[m]);
							tris.Add(num17 + m + count2 + num18 + 1 + list9[m]);
							tris.Add(num17 + m + list9[m] + 1);
						}
					}
				}
				flag3 = flag2;
				num17 = k * (count2 + num18);
			}
			int count3 = vecs.Count;
			if (closedStart)
			{
				OCQQCDDDQO(sw, list4, list5, ref vecs, ref uvs, ref tris, list.Count, leftright, 0);
			}
			if (closedEnd)
			{
				OCQQCDDDQO(sw, list4, list5, ref vecs, ref uvs, ref tris, list.Count, leftright, 1);
			}
			int count4 = vecs.Count;
			OCCCDCDQDC.OCODODDOQO(sw, ref vecs, Vector3.zero, shape.Count + num18, count3, count4, 0);
			int lastPavementCount = 0;
			foreach (ERCrosswalkInstance item3 in list8)
			{
				item3.CreateCrosswalk(ref vecs, ref uvs, ref tris, ref lastPavementCount, leftright, triangulateSidewalk: true, isConnector: false, road, null);
			}
			Mesh sharedMesh = sidewalkGO.GetComponent<MeshFilter>().sharedMesh;
			sharedMesh.Clear();
			sharedMesh.vertices = vecs.ToArray();
			sharedMesh.uv = uvs.ToArray();
			sharedMesh.triangles = tris.ToArray();
			sharedMesh.RecalculateNormals();
			sharedMesh.RecalculateTangents();
			sharedMesh.RecalculateBounds();
			sidewalkGO.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
			sidewalkGO.layer = sw.layer;
			sidewalkGO.isStatic = sw.isStatic;
			if (sw.castShadow)
			{
				sidewalkGO.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				sidewalkGO.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			return list;
		}

		public static void OQQCDQCODD(ERModularBase baseScript, ERCrossingPrefabs prefabScript, ERConnectionSibling conn1, ERConnectionSibling conn2, int index, int index2, bool conn1Priority, float turnSWAroundCornerThreshold)
		{
			bool flag = false;
			bool flag2 = false;
			bool isStatic = true;
			if (conn1.leftSidewalkActive && conn1.leftSidewalk == null)
			{
				conn1.leftSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn1.leftSidewalkid);
			}
			if (conn1.leftSidewalk == null)
			{
				conn1.leftSidewalkid = 0.0;
			}
			if (conn2.rightSidewalkActive && conn2.rightSidewalk == null)
			{
				conn2.rightSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn2.rightSidewalkid);
			}
			if (conn2.rightSidewalk == null)
			{
				conn2.rightSidewalkid = 0.0;
			}
			if (conn1.leftSidewalkid == 0.0 && conn2.rightSidewalkid == 0.0)
			{
				if (conn1.leftSidewalkGO != null)
				{
					UnityEngine.Object.DestroyImmediate(conn1.leftSidewalkGO);
				}
				if (conn2.rightSidewalkGO != null)
				{
					UnityEngine.Object.DestroyImmediate(conn2.rightSidewalkGO);
				}
				return;
			}
			List<Vector3> verts = new List<Vector3>();
			List<Vector2> uv = new List<Vector2>();
			List<Vector2> uv2 = new List<Vector2>();
			List<Color> colors = new List<Color>();
			List<Material> mats = new List<Material>();
			List<List<int>> tris = new List<List<int>>();
			tris.Add(new List<int>());
			bool flag3 = false;
			if (conn1.leftSidewalkActive && conn2.rightSidewalkActive)
			{
				if (conn1.leftSidewalkid == conn2.rightSidewalkid && conn1.leftSidewalkid != 0.0)
				{
					flag3 = OCQCCDCODC(baseScript, prefabScript, conn1, conn2, index, index2, conn1Priority, ref verts, ref uv, ref uv2, ref tris, ref colors);
					mats.Add(conn1.leftSidewalk.material);
				}
				else
				{
					flag3 = BuildFlexSingle(baseScript, prefabScript, conn1, conn2, index, conn1Priority, ref verts, ref uv, ref uv2, ref tris, turnSWAroundCornerThreshold, ref mats, ref colors);
				}
			}
			else
			{
				flag3 = BuildFlexSingle(baseScript, prefabScript, conn1, conn2, index, conn1Priority, ref verts, ref uv, ref uv2, ref tris, turnSWAroundCornerThreshold, ref mats, ref colors);
			}
			if (!flag3)
			{
				return;
			}
			int layer = 0;
			if (conn1.leftSidewalkGO == null)
			{
				Material material = null;
				if (conn1.leftSidewalk != null)
				{
					material = conn1.leftSidewalk.material;
					layer = conn1.leftSidewalk.layer;
					isStatic = conn1.leftSidewalk.isStatic;
				}
				if (material == null && conn2.rightSidewalk != null)
				{
					material = conn2.rightSidewalk.material;
					layer = conn2.rightSidewalk.layer;
					isStatic = conn2.rightSidewalk.isStatic;
				}
				conn1.leftSidewalkGO = prefabScript.ODDDOCCQCO(index, " [Left]", material);
			}
			MeshRenderer component = conn1.leftSidewalkGO.GetComponent<MeshRenderer>();
			if (mats.Count == 1)
			{
				component.sharedMaterial = mats[0];
			}
			else
			{
				component.sharedMaterials = mats.ToArray();
			}
			if (conn1.leftSidewalk != null)
			{
				if (conn1.leftSidewalk.castShadow)
				{
					conn1.leftSidewalkGO.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
				}
				else
				{
					conn1.leftSidewalkGO.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
				}
			}
			if (conn2.rightSidewalk != null)
			{
				if (conn2.rightSidewalk.castShadow)
				{
					conn1.leftSidewalkGO.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
				}
				if (conn1.leftSidewalk == null && !conn2.rightSidewalk.castShadow)
				{
					conn1.leftSidewalkGO.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
				}
			}
			Mesh sharedMesh = conn1.leftSidewalkGO.GetComponent<MeshFilter>().sharedMesh;
			sharedMesh.Clear();
			sharedMesh.vertices = verts.ToArray();
			sharedMesh.uv = uv.ToArray();
			if (uv2.Count > 0)
			{
				sharedMesh.uv4 = uv2.ToArray();
			}
			if (colors.Count > 0)
			{
				sharedMesh.colors = colors.ToArray();
			}
			sharedMesh.subMeshCount = 1;
			if (tris.Count == 1)
			{
				sharedMesh.triangles = tris[0].ToArray();
			}
			else
			{
				sharedMesh.subMeshCount = tris.Count;
				for (int i = 0; i < tris.Count; i++)
				{
					if (tris[i].Count > 0)
					{
						sharedMesh.SetTriangles(tris[i].ToArray(), i);
						continue;
					}
					sharedMesh.subMeshCount--;
					if (mats.Count > i)
					{
						mats.RemoveAt(i);
						component.sharedMaterials = mats.ToArray();
					}
				}
			}
			sharedMesh.RecalculateNormals();
			sharedMesh.RecalculateTangents();
			sharedMesh.RecalculateBounds();
			conn1.leftSidewalkGO.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
			conn1.leftSidewalkVecs.Clear();
			conn1.leftSidewalkUVs.Clear();
			conn1.rightSidewalkVecs.Clear();
			conn1.rightSidewalkUVs.Clear();
			conn1.leftSidewalkGO.layer = layer;
			conn1.leftSidewalkGO.isStatic = isStatic;
		}

		private static bool ussst(ERCrossingPrefabs tssss, ERConnectionSibling ussss, int vssss, bool wssss)
		{
			for (int i = 0; i < tssss.siblings.Count; i++)
			{
				if (tssss.siblings[i] == ussss)
				{
					vssss = i;
				}
			}
			bool result = true;
			if (ussss.road != null)
			{
				if ((ussss.road.startPrefabScript == tssss && ussss.road.startConnectionSegment == vssss && wssss) || (ussss.road.endPrefabScript == tssss && ussss.road.endConnectionSegment == vssss && !wssss))
				{
					result = !ussss.road.rightSidewalkActive;
				}
				else if ((ussss.road.endPrefabScript == tssss && ussss.road.endConnectionSegment == vssss && wssss) || (ussss.road.startPrefabScript == tssss && ussss.road.startConnectionSegment == vssss && !wssss))
				{
					result = !ussss.road.leftSidewalkActive;
				}
			}
			return result;
		}

		public static bool OCQCCDCODC(ERModularBase baseScript, ERCrossingPrefabs prefabScript, ERConnectionSibling conn1, ERConnectionSibling conn2, int index, int index2, bool conn1Priority, ref List<Vector3> verts, ref List<Vector2> uv1, ref List<Vector2> uv4, ref List<List<int>> tris, ref List<Color> colors)
		{
			ERSideWalk eRSideWalk = (conn1.leftSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn1.leftSidewalkid));
			float num = 0f - conn1.roadType.roadShapeData.leftSidewalkOffset;
			float num2 = 0f - conn2.roadType.roadShapeData.rightSidewalkOffset;
			float num3 = num;
			if (eRSideWalk == null)
			{
				Debug.Log("EasyRoads3Dv3 NullReferenceException:  sidewalk of connection " + index + " - connection object  " + prefabScript.gameObject.name + " is not set");
				if (conn1.leftSidewalkGO != null)
				{
					UnityEngine.Object.DestroyImmediate(conn1.leftSidewalkGO);
				}
				return false;
			}
			List<Vector3> list = new List<Vector3>(conn1.leftRoundingPoints);
			List<Vector3> list2 = new List<Vector3>(conn2.rightRoundingPoints);
			List<Vector3> list3 = new List<Vector3>();
			ERConnectionSibling eRConnectionSibling = null;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			bool flag = false;
			bool flag2 = false;
			Vector3 zero3 = Vector3.zero;
			float num4 = -1f;
			bool _0ssss = true;
			int leftright = -1;
			bool flag3 = eRSideWalk.planarUVs;
			if (!flag3 && (conn1.buildPriority == 1 || conn2.buildPriority == 1))
			{
				flag3 = true;
			}
			int num5 = -1;
			if (conn1.roadTypeID == conn2.roadTypeID && conn1.manuallyPrioritized == conn2.manuallyPrioritized)
			{
				if (!conn1.manuallyPrioritized && !conn2.manuallyPrioritized)
				{
					list2.Reverse();
					list2.RemoveAt(0);
					list.AddRange(list2);
				}
				zero = conn1.rightRoundingPoints[0];
				zero2 = conn2.leftRoundingPoints[0];
				num4 = -1f;
				zero3 = conn1.forward;
				eRConnectionSibling = conn2;
				if (flag3)
				{
					float num6 = Mathf.Abs(conn1.angle - conn2.angle);
					float num7 = 0f;
					int num8 = 0;
					num8 = ((conn2.orderedIndex != prefabScript.siblings.Count - 1) ? (conn2.orderedIndex + 1) : 0);
					for (int i = 0; i < prefabScript.siblings.Count; i++)
					{
						if (prefabScript.siblings[i].orderedIndex == num8)
						{
							num7 = ((!(prefabScript.siblings[i].angle > conn2.angle)) ? Mathf.Abs(prefabScript.siblings[i].angle + 360f - conn2.angle) : Mathf.Abs(prefabScript.siblings[i].angle - conn2.angle));
							break;
						}
					}
					if (num7 > 135f)
					{
						list.Reverse();
						zero = conn2.leftRoundingPoints[0];
						zero2 = conn1.rightRoundingPoints[0];
						num4 = 1f;
						leftright = 1;
						zero3 = conn2.forward;
						_0ssss = false;
						eRConnectionSibling = conn1;
					}
				}
			}
			else if (conn1Priority || (conn1.manuallyPrioritized && !conn2.manuallyPrioritized))
			{
				int num9 = conn1.leftRoundingPoints.Count - 1;
				float num10 = Vector3.Distance(conn2.rightRoundingPoints[conn2.rightRoundingPoints.Count - 1], conn1.leftRoundingPoints[num9]);
				list.Clear();
				for (int j = 0; j <= num9 && Vector3.Distance(conn1.leftRoundingPoints[j], conn1.leftRoundingPoints[num9]) > num10; j++)
				{
					list.Add(conn1.leftRoundingPoints[j]);
				}
				List<Vector3> list4 = new List<Vector3>(conn2.rightRoundingPoints);
				list4.Reverse();
				if (list.Count > 1 && list4.Count > 0 && (double)Vector3.Distance(list[list.Count - 1], list4[0]) < 0.2)
				{
					list.RemoveAt(list.Count - 1);
				}
				num5 = list.Count;
				list.AddRange(list4);
				zero = conn1.rightRoundingPoints[0];
				zero2 = conn2.leftRoundingPoints[0];
				num4 = -1f;
				zero3 = conn1.forward;
				eRConnectionSibling = conn2;
				leftright = -1;
			}
			else
			{
				List<Vector3> list5 = new List<Vector3>(conn1.leftRoundingPoints);
				int num11 = conn2.rightRoundingPoints.Count - 1;
				float num12 = Vector3.Distance(conn1.leftRoundingPoints[conn1.leftRoundingPoints.Count - 1], conn2.rightRoundingPoints[num11]);
				list.Clear();
				for (int k = 0; k <= num11 && Vector3.Distance(conn2.rightRoundingPoints[k], conn2.rightRoundingPoints[num11]) > num12; k++)
				{
					list.Add(conn2.rightRoundingPoints[k]);
				}
				list5.Reverse();
				if (list5.Count > 0 && list.Count > 0 && (double)Vector3.Distance(list[list.Count - 1], list5[0]) < 0.2)
				{
					list.RemoveAt(list.Count - 1);
				}
				num5 = list.Count;
				list.AddRange(list5);
				zero = conn2.leftRoundingPoints[0];
				zero2 = conn1.rightRoundingPoints[0];
				num4 = 1f;
				zero3 = conn2.forward;
				eRConnectionSibling = conn1;
				leftright = 1;
				_0ssss = false;
				num2 = 0f - conn1.roadType.roadShapeData.leftSidewalkOffset;
				num = 0f - conn2.roadType.roadShapeData.rightSidewalkOffset;
				num3 = num;
			}
			List<Vector2> list6 = new List<Vector2>(eRSideWalk.shape);
			List<float> list7 = new List<float>(eRSideWalk.sidewalkUVs);
			List<bool> list8 = new List<bool>(eRSideWalk.doConnectionTri);
			List<Vector3> list9 = new List<Vector3>();
			List<Vector3> ussss = new List<Vector3>();
			Vector3 zero4 = Vector3.zero;
			Vector3 zero5 = Vector3.zero;
			if (!flag3 && eRSideWalk.sidewalkWidth > conn1.radius)
			{
				flag3 = true;
			}
			int num13 = -1;
			int num14 = -1;
			int num15 = -1;
			int num16 = -1;
			int num17 = -1;
			int num18 = -1;
			int num19 = -1;
			int num20 = -1;
			int num21 = 0;
			int num22 = 0;
			float num23 = 0f;
			float num24 = 0f;
			bool flag4 = false;
			List<float> list10 = new List<float>();
			List<int> list11 = new List<int>();
			int num25 = 0;
			List<ERCrosswalkInstance> list12 = new List<ERCrosswalkInstance>();
			int num26 = -1;
			int num27 = -1;
			bool flag5 = false;
			if (num4 == -1f)
			{
				if (conn1.leftSidewalkActive && conn1.leftCrosswalkActive)
				{
					if (Vector3.Distance(list[0], list[1]) + 0.01f < conn1.crosswalkAddedDistance)
					{
						list.RemoveAt(1);
						if (num5 != -1)
						{
							num5--;
						}
					}
					float num28 = 0.5f;
					bool flag6 = true;
					if (conn1.leftSidewalk.crosswalkSize + 0.5f < conn1.crosswalkAddedDistance)
					{
						num28 = 0.5f + (conn1.crosswalkAddedDistance - 0.5f - conn1.leftSidewalk.crosswalkSize) * 0.5f;
						flag6 = false;
					}
					else if (Vector3.Distance(list[0], list[1]) > conn1.crosswalkAddedDistance)
					{
						flag6 = false;
					}
					else
					{
						float num29 = Vector3.Distance(list[0], list[1]);
						if (num29 + 0.01f < conn1.crosswalkAddedDistance)
						{
							flag6 = false;
						}
					}
					Vector3 normalized = (list[1] - list[0]).normalized;
					Vector3 vector = list[0] + normalized * num28;
					list.Insert(1, vector);
					int num30 = conn1.leftSidewalk.yPositions.Count;
					if (flag6)
					{
						num30--;
					}
					int num31 = Mathf.RoundToInt(Mathf.Floor((float)num30 * 0.5f));
					for (int l = 1; l < num30; l++)
					{
						Vector3 vector2 = vector + normalized * conn1.leftSidewalk.yPositions[l];
						list.Insert(l + 1, vector2);
						if (l == num31)
						{
							conn1.crosswalkLeftPosition = vector2;
						}
					}
					if (num5 != -1)
					{
						num5 += num30;
					}
					num13 = 0;
					num14 = 6;
					num17 = 2;
					if (conn1.leftSidewalk.yPositions.Count == 7)
					{
						num17++;
						num14 += 2;
					}
					num18 = num17 + 2;
					num23 = 0f - Mathf.Lerp(conn1.leftSidewalk.crosswalkMinHeight, conn1.leftSidewalk.crosswalkMaxHeight, UnityEngine.Random.value) + conn1.leftSidewalk.curbHeight;
					num21 = conn1.leftSidewalk.pavementIndex;
				}
				if (conn2.rightSidewalkActive && conn2.rightCrosswalkActive)
				{
					if (Vector3.Distance(list[list.Count - 1], list[list.Count - 2]) + 0.01f < conn2.crosswalkAddedDistance)
					{
						list.RemoveAt(list.Count - 2);
					}
					float num32 = 0.5f;
					bool flag7 = true;
					if (conn2.rightSidewalk.crosswalkSize + 0.5f != conn2.crosswalkAddedDistance)
					{
						num32 = 0.5f + (conn2.crosswalkAddedDistance - 0.5f - conn2.rightSidewalk.crosswalkSize) * 0.5f;
						flag7 = false;
					}
					else if (Vector3.Distance(list[list.Count - 1], list[list.Count - 2]) > conn2.crosswalkAddedDistance)
					{
						flag7 = false;
					}
					else
					{
						float num33 = Vector3.Distance(list[list.Count - 1], list[list.Count - 2]);
						if (num33 + 0.01f < conn2.crosswalkAddedDistance)
						{
							flag7 = false;
						}
					}
					Vector3 normalized2 = (list[list.Count - 2] - list[list.Count - 1]).normalized;
					Vector3 vector3 = list[list.Count - 1] + normalized2 * num32;
					list.Insert(list.Count - 1, vector3);
					int num34 = conn2.rightSidewalk.yPositions.Count;
					if (flag7)
					{
						num34--;
					}
					int num35 = Mathf.RoundToInt(Mathf.Floor((float)num34 * 0.5f));
					int index3 = list.Count - 2;
					for (int m = 1; m < num34; m++)
					{
						Vector3 vector4 = vector3 + normalized2 * conn2.rightSidewalk.yPositions[m];
						list.Insert(index3, vector4);
						if (m == num35)
						{
							conn2.crosswalkRightPosition = vector4;
						}
					}
					num16 = list.Count - 1;
					num15 = list.Count - 6;
					num20 = list.Count - 3;
					if (conn2.rightSidewalk.yPositions.Count == 7)
					{
						num20--;
						num15 -= 2;
					}
					num19 = num20 - 2;
					num24 = 0f - Mathf.Lerp(conn2.rightSidewalk.crosswalkMinHeight, conn2.rightSidewalk.crosswalkMaxHeight, UnityEngine.Random.value) + conn2.rightSidewalk.curbHeight;
					num22 = conn2.rightSidewalk.pavementIndex;
					flag5 = true;
				}
				num26 = num14 - 1;
				num27 = num15;
			}
			else
			{
				if (conn2.rightSidewalkActive && conn2.rightCrosswalkActive)
				{
					if (Vector3.Distance(list[0], list[1]) + 0.01f < conn2.crosswalkAddedDistance)
					{
						list.RemoveAt(1);
						if (num5 != -1)
						{
							num5--;
						}
					}
					float num36 = 0.5f;
					bool flag8 = true;
					if (conn2.rightSidewalk.crosswalkSize + 0.5f != conn2.crosswalkAddedDistance)
					{
						num36 = 0.5f + (conn2.crosswalkAddedDistance - 0.5f - conn2.rightSidewalk.crosswalkSize) * 0.5f;
						flag8 = false;
					}
					else if (Vector3.Distance(list[0], list[1]) > conn2.crosswalkAddedDistance)
					{
						flag8 = false;
					}
					else
					{
						float num37 = Vector3.Distance(list[0], list[1]);
						if (num37 + 0.01f < conn2.crosswalkAddedDistance)
						{
							flag8 = false;
						}
					}
					Vector3 normalized3 = (list[1] - list[0]).normalized;
					Vector3 vector5 = list[0] + normalized3 * num36;
					list.Insert(1, vector5);
					int num38 = conn2.rightSidewalk.yPositions.Count;
					if (flag8)
					{
						num38--;
					}
					int num39 = Mathf.RoundToInt(Mathf.Floor((float)num38 * 0.5f));
					for (int n = 1; n < num38; n++)
					{
						Vector3 vector6 = vector5 + normalized3 * conn2.rightSidewalk.yPositions[n];
						list.Insert(n + 1, vector6);
						if (n == num39)
						{
							conn2.crosswalkRightPosition = vector6;
						}
					}
					if (num5 != -1)
					{
						num5 += num38;
					}
					num15 = 1;
					num16 = 4;
					num19 = 2;
					if (conn2.rightSidewalk.yPositions.Count == 7)
					{
						num19++;
						num16 += 2;
					}
					num20 = num19 + 2;
					num24 = 0f - Mathf.Lerp(conn2.rightSidewalk.crosswalkMinHeight, conn2.rightSidewalk.crosswalkMaxHeight, UnityEngine.Random.value) + conn2.rightSidewalk.curbHeight;
					num22 = conn2.rightSidewalk.pavementIndex;
				}
				if (conn1.leftSidewalkActive && conn1.leftCrosswalkActive)
				{
					if (Vector3.Distance(list[list.Count - 1], list[list.Count - 2]) + 0.01f < conn1.crosswalkAddedDistance)
					{
						list.RemoveAt(list.Count - 2);
					}
					float num40 = 0.5f;
					bool flag9 = true;
					if (conn1.leftSidewalk.crosswalkSize + 0.5f != conn1.crosswalkAddedDistance)
					{
						num40 = 0.5f + (conn1.crosswalkAddedDistance - 0.5f - conn1.leftSidewalk.crosswalkSize) * 0.5f;
						flag9 = false;
					}
					else if (Vector3.Distance(list[list.Count - 1], list[list.Count - 2]) > conn1.crosswalkAddedDistance)
					{
						flag9 = false;
					}
					else
					{
						float num41 = Vector3.Distance(list[list.Count - 1], list[list.Count - 2]);
						if (num41 + 0.01f < conn1.crosswalkAddedDistance)
						{
							flag9 = false;
						}
					}
					Vector3 normalized4 = (list[list.Count - 2] - list[list.Count - 1]).normalized;
					Vector3 vector7 = list[list.Count - 1] + normalized4 * num40;
					list.Insert(list.Count - 1, vector7);
					int num42 = conn1.leftSidewalk.yPositions.Count;
					if (flag9)
					{
						num42--;
					}
					int num43 = Mathf.RoundToInt(Mathf.Floor((float)num42 * 0.5f));
					int index4 = list.Count - 2;
					for (int num44 = 1; num44 < num42; num44++)
					{
						Vector3 crosswalkLeftPosition = vector7 + normalized4 * conn1.leftSidewalk.yPositions[num44];
						list.Insert(index4, vector7 + normalized4 * conn1.leftSidewalk.yPositions[num44]);
						if (num44 == num43)
						{
							conn1.crosswalkLeftPosition = crosswalkLeftPosition;
						}
					}
					num14 = list.Count - 1;
					num13 = list.Count - 6;
					num18 = list.Count - 3;
					if (conn1.leftSidewalk.yPositions.Count == 7)
					{
						num18--;
						num13 -= 2;
					}
					num17 = num18 - 2;
					num23 = 0f - Mathf.Lerp(conn1.leftSidewalk.crosswalkMinHeight, conn1.leftSidewalk.crosswalkMaxHeight, UnityEngine.Random.value) + conn1.leftSidewalk.curbHeight;
					num21 = conn1.leftSidewalk.pavementIndex;
					flag5 = true;
				}
				num26 = num14 - 1;
				num27 = num15;
			}
			if (flag3 && num15 != -1 && conn1.angleWithNextRoad > 110f)
			{
				flag3 = false;
			}
			if (flag3)
			{
				float num45 = 0f;
				num45 = ((!(conn2.angle > conn1.angle)) ? Mathf.Abs(conn2.angle + 360f - conn1.angle) : Mathf.Abs(conn2.angle - conn1.angle));
				if (num45 > 135f && conn1.radius >= 6f)
				{
					flag3 = false;
				}
				else if (num45 > 145f && conn1.radius >= 4f)
				{
					flag3 = false;
				}
				else if (num45 > 155f && conn1.radius >= 3f)
				{
					flag3 = false;
				}
				else if (num45 > 165f && conn1.radius >= 1f)
				{
					flag3 = false;
				}
				else if (num45 > 175f && conn1.radius >= 1f)
				{
					flag3 = false;
				}
			}
			int num46 = 0;
			if (!flag3 && eRSideWalk.subdivision > 0)
			{
				for (int num47 = 0; num47 < eRSideWalk.subdivision; num47++)
				{
					float t = ((float)num47 + 1f) / ((float)eRSideWalk.subdivision + 1f);
					list6.Insert(eRSideWalk.pavementIndex + 1 + num47, Vector2.Lerp(eRSideWalk.shape[eRSideWalk.pavementIndex], eRSideWalk.shape[eRSideWalk.pavementIndex + 1], t));
					list7.Insert(eRSideWalk.pavementIndex + 1 + num47, Mathf.Lerp(eRSideWalk.sidewalkUVs[eRSideWalk.pavementIndex], eRSideWalk.sidewalkUVs[eRSideWalk.pavementIndex + 1], t));
					list8.Insert(eRSideWalk.pavementIndex + 1 + num47, item: false);
				}
				num46 = eRSideWalk.subdivision;
			}
			List<List<Vector2>> list13 = new List<List<Vector2>>();
			for (int num48 = 0; num48 < list6.Count; num48++)
			{
				conn1.leftSidewalkVecs.Add(new List<Vector3>());
				conn1.leftSidewalkUVs.Add(new List<Vector2>());
				if (flag3)
				{
					list13.Add(new List<Vector2>());
				}
			}
			float num49 = 0f;
			float num50 = 0f;
			float num51 = 0f;
			float num52 = 0f;
			float num53 = 0f;
			float num54 = 0f;
			Vector2 zero6 = Vector2.zero;
			int index5 = 1000;
			int index6 = -1;
			Vector3 cp = Vector3.zero;
			Vector3 vector8 = Vector3.zero;
			List<Vector3> list14 = new List<Vector3>();
			for (int num55 = 0; num55 < list.Count; num55++)
			{
				Vector3 vector9;
				if (num55 <= 0 || num55 >= list.Count - 1)
				{
					vector9 = ((num55 != 0) ? ((num4 != 1f) ? (zero2 - list[num55]).normalized : (list[num55] - zero2).normalized) : ((num4 != 1f) ? (zero - list[0]).normalized : (list[0] - zero).normalized));
				}
				else
				{
					Vector3 vector10 = list[num55 + 1] - list[num55 - 1];
					vector9 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
				}
				vector9 *= num4;
				Vector3 vector11 = list[num55];
				Vector3 item = vector11 + (list6[list6.Count - 1].x + num3) * vector9;
				list14.Add(item);
			}
			for (int num56 = 1; num56 < list14.Count; num56++)
			{
				if (Vector3.Distance(list14[num56], list14[num56 - 1]) < 0.1f)
				{
					list14.RemoveAt(num56);
					list.RemoveAt(num56);
				}
			}
			OQQOCDQCQD.ListPointsOCDCQCDDCC(prefabScript, list14, ref index5, ref index6, ref cp);
			if (index5 != 1000)
			{
				if (index5 > 0)
				{
					float num57 = Vector3.Distance(cp, list14[index5]);
					float num58 = Vector3.Distance(cp, list14[index5 - 1]);
					if (num57 / num58 < 0.25f)
					{
						index5--;
					}
				}
				if (index6 < list14.Count - 2)
				{
					float num59 = Vector3.Distance(cp, list14[index6]);
					float num60 = Vector3.Distance(cp, list14[index6 + 1]);
					if (num59 / num60 < 0.25f)
					{
						index6++;
					}
				}
				bool flag10 = false;
				if (index6 == num15)
				{
					index6--;
					flag10 = true;
				}
				Vector3 normalized5 = (list[index5 + 1] - list[index5]).normalized;
				Vector3 p = list14[index5] + normalized5 * 10f;
				Vector3 vector12 = OQQOCDQCQD.OCDCQCDDCC(list14[index5], p, cp, list14[index6], flag: true);
				if (vector12 != Vector3.zero)
				{
					cp = vector12;
				}
				normalized5 = (cp - list14[index5]).normalized;
				Vector3 normalized6 = (list[index5] - list14[index5]).normalized;
				Vector3 vector13 = list14[index5] + normalized6 * (eRSideWalk.sidewalkWidth - list6[eRSideWalk.pavementIndex + 1].x);
				Vector3 p2 = vector13 + normalized5 * 1500f;
				Vector3 vector14 = normalized5;
				normalized5 = (cp - list14[index6 + 1]).normalized;
				normalized6 = (list[index6 + 1] - list14[index6 + 1]).normalized;
				Vector3 p3 = list14[index6 + 1] + normalized6 * (eRSideWalk.sidewalkWidth - list6[eRSideWalk.pavementIndex + 1].x);
				Vector3 p4 = vector13 + normalized5 * 1500f;
				vector8 = OQQOCDQCQD.OCDCQCDDCC(vector13, p2, p3, p4, flag: true);
			}
			Vector3 a = Vector3.zero;
			Vector3 a2 = Vector3.zero;
			float num61 = 0f;
			int num62 = 0;
			int num63 = 0;
			int num64 = 0;
			int num65 = 0;
			bool flag11 = false;
			if (eRSideWalk.pavementIndex + 1 < list6.Count - 1)
			{
				flag11 = true;
			}
			for (int num66 = 0; num66 < list.Count; num66++)
			{
				Vector3 vector15 = prefabScript.transform.TransformPoint(list[num66]);
				if (num66 == num5 + 1)
				{
					num3 = num2;
				}
				Vector3 vector9;
				if (num66 == num26)
				{
					Vector3 vector10 = list[num66] - list[num66 - 1];
					vector9 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
				}
				else if (num66 == num27)
				{
					Vector3 vector10 = list[num66 + 1] - list[num66];
					vector9 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
				}
				else if (num66 <= 0 || num66 >= list.Count - 1)
				{
					vector9 = ((num66 == 0) ? ((num4 != 1f) ? (zero - list[0]).normalized : (list[0] - zero).normalized) : ((num4 != 1f) ? (zero2 - list[num66]).normalized : (list[num66] - zero2).normalized));
				}
				else
				{
					Vector3 vector10 = list[num66 + 1] - list[num66 - 1];
					vector9 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
					if (num66 == num5 && cp != Vector3.zero)
					{
						vector9 = (list[num5] - cp).normalized * (0f - num4);
					}
				}
				vector9 *= num4;
				num50 = num49;
				if (num66 > 0)
				{
					num49 += Vector3.Distance(list[num66 - 1], list[num66]);
				}
				num53 = num49 / eRSideWalk.uvRatio * eRSideWalk.tiling;
				Vector3 vector16 = list[num66];
				for (int num67 = 0; num67 < list6.Count; num67++)
				{
					Vector3 item = vector16;
					item.y += list6[num67].y;
					if (num66 >= num17 && num66 <= num18 && num67 <= num21)
					{
						item.y -= num23;
					}
					else if (num66 >= num19 && num66 <= num20 && num67 <= num22)
					{
						item.y -= num24;
					}
					item += (list6[num67].x + num3) * vector9;
					if (num66 > 0 && num66 == num5 && num67 == eRSideWalk.pavementIndex)
					{
						Vector3 normalized7 = (list[num66 - 1] - list[num66]).normalized;
						float num68 = Vector3.Angle(vector9, normalized7);
						float num69 = list6[num67].x / Mathf.Sin(num68 * (MathF.PI / 180f));
						item = vector16;
						item.y += list6[num67].y;
						item += (num69 + num3) * vector9;
					}
					if (index5 != 1000)
					{
						if (num66 == index5 + 1 && num67 == list6.Count - 1)
						{
							item = cp;
							float num70 = num61 + Vector3.Distance(a2, item);
							item.y += list6[num67].y;
							num54 = num70 / eRSideWalk.uvRatio * eRSideWalk.tiling;
							conn1.leftSidewalkUVs[num67].Add(new Vector2(list7[num67], num54));
						}
						else if (num66 == index5 + 1 && num67 == eRSideWalk.pavementIndex + 1)
						{
							item = vector8;
							float num71 = num61 + Vector3.Distance(a, item);
							item.y += list6[num67].y;
							num54 = num71 / eRSideWalk.uvRatio * eRSideWalk.tiling;
							conn1.leftSidewalkUVs[num67].Add(new Vector2(list7[num67], num54));
						}
						else if (num66 == index6 && num67 == list6.Count - 1)
						{
							if (index6 < list.Count - 1)
							{
								float num72 = Vector3.Distance(cp, item);
								float num73 = num49 - num72;
								num54 = num73 / eRSideWalk.uvRatio * eRSideWalk.tiling;
								conn1.leftSidewalkUVs[num67].Add(new Vector2(list7[num67], num54));
							}
							else
							{
								float num74 = num49 + Vector3.Distance(list[num66], list[num66 + 1]);
								Vector3 a3 = OQQOCDQCQD.OCOOQOQCDC(list[num66], list[num66 + 1], cp);
								float num75 = Vector3.Distance(a3, list[num66 + 1]);
								float num76 = num74 - num75;
								num54 = num76 / eRSideWalk.uvRatio * eRSideWalk.tiling;
								conn1.leftSidewalkUVs[num67].Add(new Vector2(list7[num67], num54));
							}
							item = cp;
							item.y += list6[num67].y;
						}
						else if (num66 == index6 && num67 == eRSideWalk.pavementIndex + 1)
						{
							if (index6 < list.Count - 1)
							{
								float num77 = Vector3.Distance(vector8, item);
								float num78 = num49 - num77;
								num54 = num78 / eRSideWalk.uvRatio * eRSideWalk.tiling;
								conn1.leftSidewalkUVs[num67].Add(new Vector2(list7[num67], num54));
							}
							else
							{
								float num79 = num49 + Vector3.Distance(list[num66], list[num66 + 1]);
								Vector3 a4 = OQQOCDQCQD.OCOOQOQCDC(list[num66], list[num66 + 1], vector8);
								float num80 = Vector3.Distance(a4, list[num66 + 1]);
								float num81 = num79 - num80;
								num54 = num81 / eRSideWalk.uvRatio * eRSideWalk.tiling;
								conn1.leftSidewalkUVs[num67].Add(new Vector2(list7[num67], num54));
							}
							item = vector8;
							item.y += list6[num67].y;
						}
						else
						{
							conn1.leftSidewalkUVs[num67].Add(new Vector2(list7[num67], num53));
						}
					}
					else
					{
						conn1.leftSidewalkUVs[num67].Add(new Vector2(list7[num67], num53));
					}
					conn1.leftSidewalkVecs[num67].Add(item);
					if (index5 != 1000 && num66 == index5)
					{
						if (num67 == eRSideWalk.pavementIndex + 1)
						{
							a = item;
							a.y -= list6[num67].y;
							num61 = num49;
						}
						else if (num67 == list6.Count - 1)
						{
							a2 = item;
							a2.y -= list6[num67].y;
						}
					}
					if (flag3)
					{
						if (num67 == eRSideWalk.pavementIndex)
						{
							list9.Add(item);
						}
						else if (num67 == eRSideWalk.pavementIndex + 1 && (index5 == 1000 || num66 <= index5 + 1 || num66 > index6))
						{
							ussss.Add(item);
						}
					}
				}
				if (index5 != 1000 && flag11 && (num66 == index5 + 1 || num66 == index6))
				{
					Vector3 a5 = conn1.leftSidewalkVecs[eRSideWalk.pavementIndex + 1][num66];
					a5.y = 0f;
					Vector3 b = conn1.leftSidewalkVecs[eRSideWalk.shape.Count - 1][num66];
					b.y = 0f;
					for (int num82 = eRSideWalk.pavementIndex + 2; num82 < eRSideWalk.shape.Count - 1; num82++)
					{
						Vector3 value = Vector3.Lerp(a5, b, eRSideWalk.shapePercentages[num82]);
						value.y = eRSideWalk.shape[num82].y;
						conn1.leftSidewalkVecs[num82][num66] = value;
						Vector2 value2 = conn1.leftSidewalkUVs[num82][num66];
						value2.y = Mathf.Lerp(conn1.leftSidewalkUVs[eRSideWalk.pavementIndex + 1][num66].y, conn1.leftSidewalkUVs[eRSideWalk.shape.Count - 1][num66].y, eRSideWalk.shapePercentages[num82]);
						conn1.leftSidewalkUVs[num82][num66] = value2;
					}
				}
			}
			int num83 = 0;
			List<int> list15 = new List<int>();
			for (int num84 = 0; num84 < list8.Count; num84++)
			{
				if (list8[num84] || (flag3 && (num84 == eRSideWalk.pavementIndex || num84 == eRSideWalk.pavementIndex + 1)))
				{
					num83++;
					if (flag3 && (num84 == eRSideWalk.pavementIndex || num84 == eRSideWalk.pavementIndex + 1))
					{
						list8[num84] = true;
					}
				}
				list15.Add(num83);
			}
			int num85 = 0;
			if (flag3)
			{
				num85 = 2;
			}
			int count = conn1.leftSidewalkVecs.Count;
			int count2 = conn1.leftSidewalkVecs[0].Count;
			int num86 = 0;
			Color white = Color.white;
			Color black = Color.black;
			int num87 = 0;
			int num88 = 0;
			int num89 = 0;
			int num90 = 0;
			int num91 = 0;
			int num92 = 0;
			for (int num93 = 0; num93 < conn1.leftSidewalkVecs[0].Count; num93++)
			{
				if (index5 == 1000 || num93 == index5)
				{
				}
				if ((num93 >= num13 && num93 <= num14 - 1) || (num93 >= num15 && num93 <= num16 - 1))
				{
					if (!flag4)
					{
						flag4 = true;
						if (num93 > 0)
						{
							list11.Add(verts.Count + eRSideWalk.realPavementIndex - eRSideWalk.realColCount - conn2.rightSidewalk.subdivision - num85);
							list10.Add(conn1.leftSidewalkUVs[0][num93].y);
						}
						else
						{
							list11.Add(eRSideWalk.realPavementIndex);
						}
					}
					else
					{
						list10.Add(conn1.leftSidewalkUVs[0][num93].y);
					}
				}
				else if (flag4)
				{
					float curbHeight = num23;
					int subdivision = conn1.leftSidewalk.subdivision;
					if (num93 >= num15 && num93 <= num16)
					{
						curbHeight = num24;
					}
					list12.Add(new ERCrosswalkInstance(new List<int>(list11), eRSideWalk, new List<float>(list10), curbHeight, subdivision + num85));
					list11.Clear();
					list10.Clear();
					flag4 = false;
				}
				for (int num94 = 0; num94 < count; num94++)
				{
					verts.Add(conn1.leftSidewalkVecs[num94][num93]);
					uv1.Add(conn1.leftSidewalkUVs[num94][num93]);
					if (list8[num94])
					{
						verts.Add(conn1.leftSidewalkVecs[num94][num93]);
						Vector2 item2 = conn1.leftSidewalkUVs[num94][num93];
						item2.x += eRSideWalk.hardEdgePadding;
						uv1.Add(item2);
					}
					if (index5 != 1000 && num94 == eRSideWalk.pavementIndex + 1 && num93 == index5)
					{
						num87 = num86 + num94 + list15[num94];
						if (num87 == num90)
						{
							index5++;
						}
					}
					if (index5 != 1000 && num94 == eRSideWalk.pavementIndex + 1 && num93 == index5 - 1)
					{
						num90 = num86 + num94 + list15[num94];
					}
					if (num94 < count - 1 && num93 < count2 - 1 && (!flag3 || num94 != eRSideWalk.pavementIndex) && (num94 <= eRSideWalk.pavementIndex || index5 == 1000 || num93 <= index5 || num93 >= index6) && (!flag4 || num94 < eRSideWalk.pavementIndex || num94 >= eRSideWalk.pavementIndex + 1 + num46))
					{
						if (num4 == -1f)
						{
							tris[0].Add(num86 + num94 + list15[num94]);
							tris[0].Add(num86 + num94 + count + num83 + 1 + list15[num94]);
							tris[0].Add(num86 + num94 + count + num83 + list15[num94]);
							tris[0].Add(num86 + num94 + list15[num94]);
							tris[0].Add(num86 + num94 + list15[num94] + 1);
							tris[0].Add(num86 + num94 + count + num83 + 1 + list15[num94]);
						}
						else
						{
							tris[0].Add(num86 + num94 + list15[num94]);
							tris[0].Add(num86 + num94 + count + num83 + list15[num94]);
							tris[0].Add(num86 + num94 + count + num83 + 1 + list15[num94]);
							tris[0].Add(num86 + num94 + list15[num94]);
							tris[0].Add(num86 + num94 + count + num83 + 1 + list15[num94]);
							tris[0].Add(num86 + num94 + list15[num94] + 1);
						}
					}
				}
				num86 = ((num93 <= 0) ? verts.Count : ((num93 + 1) * (count + num83)));
			}
			if (flag4)
			{
				float curbHeight2 = num24;
				list12.Add(new ERCrosswalkInstance(new List<int>(list11), eRSideWalk, new List<float>(list10), curbHeight2, conn1.leftSidewalk.subdivision + num85));
				list11.Clear();
				list10.Clear();
				flag4 = false;
			}
			bool utsss = false;
			int ttsss = 0;
			List<Vector3> list16 = new List<Vector3>();
			int num95 = 0;
			int lastPavementCount = 0;
			foreach (ERCrosswalkInstance item3 in list12)
			{
				List<int> tris2 = new List<int>(tris[0]);
				list16 = item3.CreateCrosswalk(ref verts, ref uv1, ref tris2, ref lastPavementCount, leftright, !flag3, isConnector: true, null, prefabScript);
				tris[0] = tris2;
				utsss = true;
				if (!flag3)
				{
					continue;
				}
				if (num95 == 0 && ((num13 != -1 && (list12.Count != 1 || eRConnectionSibling == conn2)) || (num13 == -1 && list12.Count == 1)))
				{
					if (!eRSideWalk.includeOuterStrip)
					{
						list9.RemoveRange(2, 3);
						list9.InsertRange(2, list16);
					}
					else
					{
						list9.RemoveRange(2, 5);
						list9.InsertRange(2, list16);
					}
				}
				else if (!eRSideWalk.includeOuterStrip)
				{
					list9.RemoveRange(list9.Count - 5, 3);
					list9.InsertRange(list9.Count - 2, list16);
				}
				else
				{
					list9.RemoveRange(list9.Count - 7, 5);
					list9.InsertRange(list9.Count - 2, list16);
				}
				num95++;
			}
			if (flag3)
			{
				yssst(prefabScript, ref ussss, ref list9, list6, eRSideWalk, zero3, list7, _0ssss, num4, ref verts, ref uv1, ref tris, ttsss, utsss, vtsss: false, 0);
				if (flag3 && ussss.Count > 0 && list9.Count > 0)
				{
					Vector3 zero7 = Vector3.zero;
					Vector3 zero8 = Vector3.zero;
					Vector3 zero9 = Vector3.zero;
					Vector3 zero10 = Vector3.zero;
					Vector3 zero11 = Vector3.zero;
					Vector3 zero12 = Vector3.zero;
					int num96 = 0;
					for (int num97 = 0; num97 < ussss.Count; num97++)
					{
						zero9 = ussss[num97];
						zero9.y = vector8.y;
						if (zero9 == vector8 && num97 != 0)
						{
							ussss.RemoveRange(0, num97);
							break;
						}
					}
					ussss.Reverse();
					list9.Reverse();
					float num98 = 0f;
					float num99 = 0f;
					Vector3 vector17 = list9[0];
					Vector3 vector18 = ussss[0];
					int num100 = 0;
					int count3 = verts.Count;
					int num101 = count3 + 1;
					if (!flag5)
					{
						List<int> tris3 = tris[0];
						SecondaryPavement(ref verts, ref uv1, ref tris3, list9, ussss, eRSideWalk, (int)num4, prefabScript);
						tris[0] = tris3;
					}
					else
					{
						eRSideWalk = list12[list12.Count - 1].sidewalk;
						List<int> tris4 = tris[0];
						CrosswalkByInnerPavementVecs(eRSideWalk, list9, ussss, ref verts, ref uv1, ref tris4, prefabScript, leftright);
						tris[0] = tris4;
					}
				}
			}
			int count4 = verts.Count;
			int count5 = verts.Count;
			OCCCDCDQDC.OCODODDOQO(eRSideWalk, ref verts, Vector3.zero, eRSideWalk.shape.Count + num83, count4, count5, 0);
			return true;
		}

		public static void CrosswalkByInnerPavementVecs(ERSideWalk sw, List<Vector3> innerPavementVecs, List<Vector3> outerPavementVecs, ref List<Vector3> verts, ref List<Vector2> uv1, ref List<int> tris, ERCrossingPrefabs prefabScript, int leftright)
		{
			float num = Vector3.Distance(innerPavementVecs[0], innerPavementVecs[1]);
			Vector3 vector = innerPavementVecs[0];
			Vector3 vector2 = outerPavementVecs[0];
			int count = outerPavementVecs.Count;
			int count2 = verts.Count;
			verts.Add(innerPavementVecs[0]);
			uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex], 0f));
			verts.Add(outerPavementVecs[0]);
			uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex + 1], 0f));
			verts.Add(innerPavementVecs[1]);
			float y = num / sw.uvRatio * sw.tiling;
			uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex], y));
			int num2 = 3;
			int num3 = 0;
			int num4 = 4;
			if (sw.includeOuterStrip)
			{
				verts.Add(innerPavementVecs[2]);
				uv1.Add(new Vector2(sw.crosswalkStripUVX, y));
				verts.Add(innerPavementVecs[3]);
				uv1.Add(new Vector2(sw.crosswalkOuterUVX, y));
				verts.Add(outerPavementVecs[1]);
				uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex + 1], y));
				num2++;
				num4 += 2;
				if (leftright == -1)
				{
					tris.Add(count2);
					tris.Add(count2 + 2);
					tris.Add(count2 + 3);
					tris.Add(count2);
					tris.Add(count2 + 3);
					tris.Add(count2 + 4);
					tris.Add(count2);
					tris.Add(count2 + 4);
					tris.Add(count2 + 1);
					tris.Add(count2 + 1);
					tris.Add(count2 + 4);
					tris.Add(count2 + 5);
				}
				else
				{
					tris.Add(count2);
					tris.Add(count2 + 3);
					tris.Add(count2 + 2);
					tris.Add(count2);
					tris.Add(count2 + 4);
					tris.Add(count2 + 3);
					tris.Add(count2);
					tris.Add(count2 + 1);
					tris.Add(count2 + 4);
					tris.Add(count2 + 1);
					tris.Add(count2 + 5);
					tris.Add(count2 + 4);
				}
			}
			else
			{
				verts.Add(innerPavementVecs[2]);
				uv1.Add(new Vector2(sw.crosswalkOuterUVX, y));
				verts.Add(outerPavementVecs[1]);
				uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex + 1], y));
				if (leftright == -1)
				{
					tris.Add(count2);
					tris.Add(count2 + 2);
					tris.Add(count2 + 3);
					tris.Add(count2);
					tris.Add(count2 + 3);
					tris.Add(count2 + 1);
					tris.Add(count2 + 1);
					tris.Add(count2 + 3);
					tris.Add(count2 + 4);
				}
				else
				{
					tris.Add(count2);
					tris.Add(count2 + 3);
					tris.Add(count2 + 2);
					tris.Add(count2);
					tris.Add(count2 + 1);
					tris.Add(count2 + 3);
					tris.Add(count2 + 1);
					tris.Add(count2 + 4);
					tris.Add(count2 + 3);
				}
			}
			count2 = verts.Count;
			if (count <= 2 + num4)
			{
				return;
			}
			for (int i = 0; i < num4; i++)
			{
				num += Vector3.Distance(innerPavementVecs[num2 + i - 1], innerPavementVecs[num2 + i]);
				y = num / sw.uvRatio * sw.tiling;
				verts.Add(innerPavementVecs[num2 + i]);
				uv1.Add(new Vector2(sw.crosswalkOuterUVX, y));
				verts.Add(outerPavementVecs[2 + i]);
				uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex + 1], y));
				if (leftright == -1)
				{
					tris.Add(count2 - 2);
					tris.Add(count2);
					tris.Add(count2 - 1);
					tris.Add(count2 - 1);
					tris.Add(count2);
					tris.Add(count2 + 1);
				}
				else
				{
					tris.Add(count2 - 2);
					tris.Add(count2 - 1);
					tris.Add(count2);
					tris.Add(count2 - 1);
					tris.Add(count2 + 1);
					tris.Add(count2);
				}
				count2 += 2;
			}
			num2 += num4;
			num3 = 2 + num4;
			if (sw.includeOuterStrip)
			{
				verts.Add(innerPavementVecs[num2]);
				uv1.Add(new Vector2(sw.crosswalkStripUVX, y));
				verts.Add(innerPavementVecs[num2 + 1]);
				uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex], y));
				verts.Add(innerPavementVecs[num2 + 2]);
				float num5 = num + Vector3.Distance(outerPavementVecs[num3 - 1], outerPavementVecs[num3]);
				num += Vector3.Distance(innerPavementVecs[num2 + 1], innerPavementVecs[num2 + 2]);
				y = num / sw.uvRatio * sw.tiling;
				uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex], y));
				verts.Add(outerPavementVecs[num3]);
				uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex + 1], num5 / sw.uvRatio * sw.tiling));
				if (leftright == -1)
				{
					tris.Add(count2);
					tris.Add(count2 + 1);
					tris.Add(count2 + 2);
					tris.Add(count2);
					tris.Add(count2 + 2);
					tris.Add(count2 - 2);
					tris.Add(count2 - 2);
					tris.Add(count2 + 2);
					tris.Add(count2 + 3);
					tris.Add(count2 - 2);
					tris.Add(count2 + 3);
					tris.Add(count2 - 1);
				}
				else
				{
					tris.Add(count2);
					tris.Add(count2 + 2);
					tris.Add(count2 + 1);
					tris.Add(count2);
					tris.Add(count2 - 2);
					tris.Add(count2 + 2);
					tris.Add(count2 - 2);
					tris.Add(count2 + 3);
					tris.Add(count2 + 2);
					tris.Add(count2 - 2);
					tris.Add(count2 - 1);
					tris.Add(count2 + 3);
				}
				num2 += 2;
				if (num2 + 1 != innerPavementVecs.Count || num3 + 1 != outerPavementVecs.Count)
				{
					innerPavementVecs.RemoveRange(0, num2);
					outerPavementVecs.RemoveRange(0, num3);
					SecondaryPavement(ref verts, ref uv1, ref tris, innerPavementVecs, outerPavementVecs, sw, -1, prefabScript);
				}
			}
			else
			{
				verts.Add(innerPavementVecs[num2]);
				uv1.Add(new Vector2(sw.crosswalkStripUVX, y));
				verts.Add(innerPavementVecs[num2 + 1]);
				float num6 = num + Vector3.Distance(outerPavementVecs[num3 - 1], outerPavementVecs[num3]);
				num += Vector3.Distance(innerPavementVecs[num2], innerPavementVecs[num2 + 1]);
				y = num / sw.uvRatio * sw.tiling;
				uv1.Add(new Vector2(sw.crosswalkStripUVX, y));
				verts.Add(outerPavementVecs[num3]);
				uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex + 1], num6 / sw.uvRatio * sw.tiling));
				if (leftright == -1)
				{
					tris.Add(count2);
					tris.Add(count2 + 1);
					tris.Add(count2 - 2);
					tris.Add(count2 - 2);
					tris.Add(count2 + 1);
					tris.Add(count2 + 2);
					tris.Add(count2 - 2);
					tris.Add(count2 + 2);
					tris.Add(count2 - 1);
				}
				else
				{
					tris.Add(count2);
					tris.Add(count2 - 2);
					tris.Add(count2 + 1);
					tris.Add(count2 - 2);
					tris.Add(count2 + 2);
					tris.Add(count2 + 1);
					tris.Add(count2 - 2);
					tris.Add(count2 - 1);
					tris.Add(count2 + 2);
				}
				num2++;
				if (num2 + 1 != innerPavementVecs.Count || num3 + 1 != outerPavementVecs.Count)
				{
					innerPavementVecs.RemoveRange(0, num2);
					outerPavementVecs.RemoveRange(0, num3);
					SecondaryPavement(ref verts, ref uv1, ref tris, innerPavementVecs, outerPavementVecs, sw, leftright, prefabScript);
				}
			}
		}

		private static void SecondaryPavement(ref List<Vector3> verts, ref List<Vector2> uv1, ref List<int> tris, List<Vector3> innerPavementVecs, List<Vector3> outerPavementVecs, ERSideWalk sw, int leftright, ERCrossingPrefabs prefabScript)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			int num4 = verts.Count;
			int item = num4 + 1;
			Vector3 a = innerPavementVecs[0];
			Vector3 a2 = outerPavementVecs[0];
			verts.Add(innerPavementVecs[0]);
			verts.Add(outerPavementVecs[0]);
			innerPavementVecs.RemoveAt(0);
			outerPavementVecs.RemoveAt(0);
			uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex], 0f));
			uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex + 1], 0f));
			int num5 = verts.Count - 1;
			int num6 = innerPavementVecs.Count;
			int num7 = outerPavementVecs.Count;
			while ((num7 > 0 || num6 > 0) && num3 < 100)
			{
				if ((num6 > 0 && num <= num2) || num7 == 0)
				{
					num += Vector3.Distance(a, innerPavementVecs[0]);
					verts.Add(innerPavementVecs[0]);
					uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex], num / sw.uvRatio * sw.tiling));
					a = innerPavementVecs[0];
					innerPavementVecs.RemoveAt(0);
					num6--;
					if (leftright == -1)
					{
						tris.Add(num4);
						tris.Add(num5 + 1);
						tris.Add(item);
					}
					else
					{
						tris.Add(num4);
						tris.Add(item);
						tris.Add(num5 + 1);
					}
					num5++;
					num4 = num5;
				}
				else if (num7 > 0)
				{
					num2 += Vector3.Distance(a2, outerPavementVecs[0]);
					verts.Add(outerPavementVecs[0]);
					uv1.Add(new Vector2(sw.sidewalkUVs[sw.pavementIndex + 1], num2 / sw.uvRatio * sw.tiling));
					a2 = outerPavementVecs[0];
					outerPavementVecs.RemoveAt(0);
					num7--;
					if (leftright == -1)
					{
						tris.Add(item);
						tris.Add(num4);
						tris.Add(num5 + 1);
					}
					else
					{
						tris.Add(item);
						tris.Add(num5 + 1);
						tris.Add(num4);
					}
					num5++;
					item = num5;
				}
				num3++;
			}
		}

		private static Vector2 vssss(Vector3 tssss, Vector3 ussss, Vector3 vssss, int wssss, float xssss, ERSideWalk yssss)
		{
			Vector3 b = OQQOCDQCQD.OCOOQOQCDC(tssss, ussss, vssss);
			float num = Vector3.Distance(tssss, b);
			float x = Mathf.Lerp(yssss.sidewalkUVs[yssss.pavementIndex], yssss.sidewalkUVs[yssss.pavementIndex + 1], num / yssss.pavementSize);
			num = Vector3.Distance(vssss, b);
			if (wssss == 0)
			{
				num = 0f;
			}
			float y = xssss + num / yssss.uvRatio * yssss.tiling;
			return new Vector2(x, y);
		}

		private static void DelaunayConstructor(List<Vector3> delaunayVecs1, List<Vector2> delaunayUVs1, List<Vector3> delaunayVecs2, List<Vector2> delaunayUVs2, ref List<Vector3> verts, ref List<Vector2> uvs, ref List<int> tris)
		{
			delaunayVecs1.Reverse();
			delaunayUVs1.Reverse();
			if (delaunayVecs2 != null)
			{
				delaunayVecs2.AddRange(delaunayVecs1);
				delaunayUVs2.AddRange(delaunayUVs1);
			}
			List<int> list = OQQOCDQCQDExt.OOQOQOCODD(delaunayVecs2, delaunayVecs2, null);
			int count = verts.Count;
			verts.AddRange(delaunayVecs2);
			uvs.AddRange(delaunayUVs2);
			for (int i = 0; i < list.Count; i++)
			{
				tris.Add(count + list[i]);
			}
		}

		public static bool BuildFlexSingle(ERModularBase baseScript, ERCrossingPrefabs prefabScript, ERConnectionSibling conn1, ERConnectionSibling conn2, int index, bool conn1Priority, ref List<Vector3> verts, ref List<Vector2> uv1, ref List<Vector2> uv4, ref List<List<int>> tris, float turnSWAroundCornerThreshold, ref List<Material> mats, ref List<Color> colors)
		{
			if (conn1.leftSidewalkid == 0.0 && conn2.rightSidewalkid == 0.0)
			{
				return false;
			}
			bool flag = true;
			List<Vector3> list = new List<Vector3>(conn1.leftRoundingPoints);
			List<Vector3> list2 = new List<Vector3>(conn2.rightRoundingPoints);
			List<Vector3> list3 = new List<Vector3>(conn2.rightRoundingPoints);
			float num = -1f;
			float num2 = 1f;
			ERSideWalk eRSideWalk = null;
			float num3 = 0f;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			Vector3 zero = Vector3.zero;
			Vector3 vector4 = Vector3.zero;
			Vector3 vector5 = Vector3.zero;
			int num4 = 0;
			bool flag2 = false;
			bool flag3 = false;
			ERConnectionSibling eRConnectionSibling = null;
			if (conn1.rightRoundingPoints.Count == 0 || conn1.leftRoundingPoints.Count == 0)
			{
				Debug.Log("EasyRoads3Dv3 Warning: Unable to Create Flex Connector sidewalks");
				return false;
			}
			if (conn2.rightRoundingPoints.Count == 0 || conn2.leftRoundingPoints.Count == 0)
			{
				Debug.Log("EasyRoads3Dv3 Warning: Unable to Create Flex Connector sidewalks");
				return false;
			}
			if (conn1.roadTypeID == conn2.roadTypeID && conn1.manuallyPrioritized == conn2.manuallyPrioritized)
			{
				bool flag4 = false;
				if (conn1.leftSidewalkActive && conn2.rightSidewalkActive)
				{
					float num5 = Mathf.Abs(conn1.angle - conn2.angle);
					float num6 = 0f;
					int num7 = 0;
					num7 = ((conn2.orderedIndex != prefabScript.siblings.Count - 1) ? (conn2.orderedIndex + 1) : 0);
					for (int i = 0; i < prefabScript.siblings.Count; i++)
					{
						if (prefabScript.siblings[i].orderedIndex == num7)
						{
							num6 = ((!(prefabScript.siblings[i].angle > conn2.angle)) ? Mathf.Abs(prefabScript.siblings[i].angle + 360f - conn2.angle) : Mathf.Abs(prefabScript.siblings[i].angle - conn2.angle));
							break;
						}
					}
					if (num6 > 135f)
					{
						flag4 = true;
					}
				}
				if (conn1.leftSidewalkActive && (!conn2.rightSidewalkActive || conn1.buildPriority == 0) && !flag4)
				{
					if (conn2.rightSidewalkActive && conn2.rightSidewalkid != 0.0)
					{
						eRConnectionSibling = conn2;
					}
					flag2 = false;
					eRSideWalk = (conn1.leftSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn1.leftSidewalkid));
					if (eRSideWalk != null)
					{
						num3 = conn1.roadType.roadShapeData.leftSidewalkOffset * num;
						vector4 = list[0] + conn1.sideways * (eRSideWalk.sidewalkWidth + num3);
						vector5 = vector4 + conn1.forward * 150f;
						vector = conn1.forward;
						vector2 = (conn1.leftRoundingPoints[0] - conn1.rightRoundingPoints[0]).normalized;
						vector3 = conn1.rightRoundingPoints[0];
						zero = conn2.leftRoundingPoints[0];
						num2 = 1f;
						flag3 = conn1.leftCrosswalkActive;
						if (conn1.roadTypeID == conn2.roadTypeID && !conn1.manuallyPrioritized && !conn2.manuallyPrioritized)
						{
							list2.Reverse();
							list2.RemoveAt(0);
							list.AddRange(list2);
							num = -1f;
						}
					}
				}
				else
				{
					if (conn1.leftSidewalkActive && conn1.leftSidewalkid != 0.0)
					{
						eRConnectionSibling = conn1;
					}
					flag = false;
					flag2 = true;
					list3 = new List<Vector3>(conn1.leftRoundingPoints);
					num = 1f;
					eRSideWalk = (conn2.rightSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn2.rightSidewalkid));
					if (eRSideWalk != null)
					{
						num3 = conn1.roadType.roadShapeData.leftSidewalkOffset * num * -1f;
						vector4 = list2[0] + -conn2.sideways * (eRSideWalk.sidewalkWidth + num3);
						vector5 = vector4 + conn2.forward * 150f;
						vector = conn2.forward;
						vector2 = (conn2.leftRoundingPoints[0] - conn2.rightRoundingPoints[0]).normalized;
						vector3 = conn2.leftRoundingPoints[0];
						zero = conn1.rightRoundingPoints[0];
						num2 = -1f;
						flag3 = conn2.rightCrosswalkActive;
						if (conn1.roadTypeID == conn2.roadTypeID && !conn1.manuallyPrioritized && !conn2.manuallyPrioritized)
						{
							list.Reverse();
							list.RemoveAt(0);
							list2.AddRange(list);
							list = list2;
						}
						else if (conn1.roadTypeID == conn2.roadTypeID && conn2.primaryPriorityConnection)
						{
							list = list2;
						}
						else if (conn1.roadTypeID == conn2.roadTypeID && conn1.manuallyPrioritized && conn2.manuallyPrioritized)
						{
							list.Reverse();
						}
					}
				}
			}
			else if (conn1.leftSidewalkActive && (!conn2.rightSidewalkActive || conn2.buildPriority == 1))
			{
				if (conn2.rightSidewalkActive && conn2.rightSidewalkid != 0.0)
				{
					eRConnectionSibling = conn2;
				}
				flag2 = false;
				eRSideWalk = (conn1.leftSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn1.leftSidewalkid));
				num3 = conn1.roadType.roadShapeData.leftSidewalkOffset * num;
				if (eRSideWalk != null)
				{
					vector4 = list[0] + conn1.sideways * (eRSideWalk.sidewalkWidth + num3);
				}
				vector5 = vector4 + conn1.forward * 150f;
				vector = conn1.forward;
				vector2 = (conn1.leftRoundingPoints[0] - conn1.rightRoundingPoints[0]).normalized;
				vector3 = conn1.rightRoundingPoints[0];
				zero = conn2.leftRoundingPoints[0];
				flag3 = conn1.leftCrosswalkActive;
				if (conn1.buildPriority == 0)
				{
					int num8 = conn1.leftRoundingPoints.Count - 1;
					float num9 = Vector3.Distance(conn2.rightRoundingPoints[conn2.rightRoundingPoints.Count - 1], conn1.leftRoundingPoints[num8]);
					list.Clear();
					for (int j = 0; j <= num8 && Vector3.Distance(conn1.leftRoundingPoints[j], conn1.leftRoundingPoints[num8]) > num9; j++)
					{
						list.Add(conn1.leftRoundingPoints[j]);
					}
					List<Vector3> list4 = new List<Vector3>(conn2.rightRoundingPoints);
					list4.Reverse();
					if (list.Count > 1 && list4.Count > 0 && (double)Vector3.Distance(list[list.Count - 1], list4[0]) < 0.2)
					{
						list.RemoveAt(list.Count - 1);
					}
					list.AddRange(list4);
				}
				else
				{
					int num10 = conn2.rightRoundingPoints.Count - 1;
					float num11 = Vector3.Distance(conn1.leftRoundingPoints[conn1.leftRoundingPoints.Count - 1], conn2.rightRoundingPoints[num10]);
					List<Vector3> list5 = new List<Vector3>();
					for (int k = 0; k <= num10 && Vector3.Distance(conn2.rightRoundingPoints[k], conn2.rightRoundingPoints[num10]) > num11; k++)
					{
						list5.Add(conn2.rightRoundingPoints[k]);
					}
					list5.Reverse();
					if (list.Count > 1 && list5.Count > 0 && (double)Vector3.Distance(list[list.Count - 1], list5[0]) < 0.2)
					{
						list5.RemoveAt(0);
					}
					list.AddRange(list5);
				}
			}
			else
			{
				if (conn1.leftSidewalkActive && conn1.leftSidewalkid != 0.0)
				{
					eRConnectionSibling = conn1;
				}
				flag2 = true;
				num = 1f;
				eRSideWalk = (conn2.rightSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn2.rightSidewalkid));
				num3 = conn2.roadType.roadShapeData.rightSidewalkOffset * num * -1f;
				if (eRSideWalk != null)
				{
					vector4 = list2[0] + -conn2.sideways * (eRSideWalk.sidewalkWidth + num3);
				}
				vector5 = vector4 + conn2.forward * 150f;
				vector = conn2.forward;
				vector2 = (conn2.leftRoundingPoints[0] - conn2.rightRoundingPoints[0]).normalized;
				vector3 = conn2.leftRoundingPoints[0];
				zero = conn1.rightRoundingPoints[0];
				num2 = -1f;
				flag3 = conn2.rightCrosswalkActive;
				if (conn2.buildPriority == 0)
				{
					int num12 = conn2.rightRoundingPoints.Count - 1;
					float num13 = Vector3.Distance(conn1.leftRoundingPoints[conn1.leftRoundingPoints.Count - 1], conn2.rightRoundingPoints[num12]);
					list.Clear();
					for (int l = 0; l <= num12 && Vector3.Distance(conn2.rightRoundingPoints[l], conn2.rightRoundingPoints[num12]) > num13; l++)
					{
						list.Add(conn2.rightRoundingPoints[l]);
					}
					List<Vector3> list6 = new List<Vector3>(conn1.leftRoundingPoints);
					list6.Reverse();
					if (list.Count > 1 && list6.Count > 0 && (double)Vector3.Distance(list[list.Count - 1], list6[0]) < 0.2)
					{
						list.RemoveAt(list.Count - 1);
					}
					list.AddRange(list6);
				}
				else
				{
					int num14 = conn1.leftRoundingPoints.Count - 1;
					float num15 = Vector3.Distance(conn2.rightRoundingPoints[conn2.rightRoundingPoints.Count - 1], conn1.leftRoundingPoints[num14]);
					List<Vector3> list7 = new List<Vector3>();
					for (int m = 0; m <= num14 && Vector3.Distance(conn1.leftRoundingPoints[m], conn1.leftRoundingPoints[num14]) > num15; m++)
					{
						list7.Add(conn1.leftRoundingPoints[m]);
					}
					list.Clear();
					list.AddRange(conn2.rightRoundingPoints);
					list7.Reverse();
					if (list.Count > 1 && list7.Count > 0 && (double)Vector3.Distance(list[list.Count - 1], list7[0]) < 0.2)
					{
						list7.RemoveAt(0);
					}
					list.AddRange(list7);
				}
			}
			if (eRSideWalk == null)
			{
				Debug.Log("EasyRoads3Dv3: " + prefabScript.gameObject.name + " > sidewalk of connection " + index + " is not set");
				if (conn1.leftSidewalkGO != null)
				{
					UnityEngine.Object.DestroyImmediate(conn1.leftSidewalkGO);
				}
				return false;
			}
			for (int n = 0; n < eRSideWalk.shape.Count; n++)
			{
				conn1.leftSidewalkVecs.Add(new List<Vector3>());
				conn1.leftSidewalkUVs.Add(new List<Vector2>());
			}
			mats.Add(eRSideWalk.material);
			float y = 0f;
			Vector3 vector6;
			Vector2 item = (vector6 = Vector2.zero);
			float num16 = 0f;
			float num17 = 0f;
			int count = eRSideWalk.shape.Count;
			int num18 = count;
			int num19 = 0;
			int num20 = 0;
			List<int> list8 = new List<int>();
			List<bool> list9 = new List<bool>();
			bool flag5 = false;
			int pavementIndex = eRSideWalk.pavementIndex;
			bool flag6 = true;
			Vector3 vB = list[0] + vector * 150f;
			if (num3 != 0f)
			{
				vB += vector2 * (0f - num3) * num;
			}
			float num21 = 0f;
			float num22 = 0f;
			Vector3 vB2;
			Vector3 vector8;
			Vector3 zero2;
			Vector3 vector7 = (vector8 = (vB2 = (zero2 = Vector3.zero)));
			float num23 = 0f;
			if ((eRConnectionSibling != null && conn1.roadTypeID != conn2.roadTypeID) || conn1.buildPriority != conn2.buildPriority || eRSideWalk.sidewalkWidth > conn1.radius || Vector3.Angle(conn1.forward, conn2.forward) < turnSWAroundCornerThreshold)
			{
				flag6 = false;
			}
			List<Vector3> list10 = new List<Vector3>();
			Vector3 vector9 = Vector3.zero;
			Vector3 vector10 = Vector3.zero;
			List<float> list11 = new List<float>();
			int num24 = -1;
			int num25 = -1;
			int num26 = -1;
			int num27 = -1;
			int num28 = -1;
			int num29 = -1;
			int num30 = -1;
			int num31 = -1;
			int num32 = -1;
			int num33 = -1;
			int num34 = -1;
			int num35 = -1;
			int num36 = -1;
			int num37 = -1;
			int num38 = -1;
			int num39 = -1;
			int num40 = 0;
			int num41 = 0;
			float num42 = 0f;
			float num43 = 0f;
			int num44 = 0;
			int num45 = 0;
			float num46 = 0f;
			float num47 = 0f;
			bool flag7 = false;
			List<float> list12 = new List<float>();
			List<int> list13 = new List<int>();
			int num48 = 0;
			List<ERCrosswalkInstance> list14 = new List<ERCrosswalkInstance>();
			int num49 = -1;
			int num50 = -1;
			int num51 = 0;
			if (num == -1f)
			{
				if (conn1.leftSidewalkActive && conn1.leftCrosswalkActive)
				{
					float num52 = 0.5f;
					for (int num53 = 0; num53 < list.Count; num53++)
					{
						if (list[num53] == conn1.firstLeftRoundingVec)
						{
							if (num53 > 1)
							{
								list.RemoveRange(1, num53 - 1);
							}
							break;
						}
					}
					Vector3 normalized = (list[1] - list[0]).normalized;
					Vector3 vector11 = list[0] + normalized * num52;
					list.Insert(1, vector11);
					int count2 = conn1.leftSidewalk.yPositions.Count;
					int num54 = Mathf.RoundToInt(Mathf.Floor((float)count2 * 0.5f));
					for (int num55 = 1; num55 < count2; num55++)
					{
						Vector3 vector12 = vector11 + normalized * conn1.leftSidewalk.yPositions[num55];
						list.Insert(num55 + 1, vector12);
						if (num55 == num54)
						{
							conn1.crosswalkLeftPosition = vector12;
						}
					}
					num24 = 0;
					num25 = 6;
					num26 = 2;
					if (conn1.leftSidewalk.yPositions.Count == 7)
					{
						num26++;
						num25 += 2;
					}
					num27 = num26 + 2;
					num42 = 0f - Mathf.Lerp(conn1.leftSidewalk.crosswalkMinHeight, conn1.leftSidewalk.crosswalkMaxHeight, UnityEngine.Random.value) + conn1.leftSidewalk.curbHeight;
					num40 = conn1.leftSidewalk.pavementIndex;
					flag6 = false;
				}
				if (conn2.rightSidewalkActive && conn2.rightCrosswalkActive)
				{
					vector10 = conn2.firstRightRoundingVec;
					list11 = conn2.rightSidewalk.yPositions;
					num28 = 0;
					num29 = 6;
					num30 = 2;
					if (conn2.rightSidewalk.yPositions.Count == 7)
					{
						num30++;
						num29 += 2;
					}
					num31 = num30 + 2;
					num43 = 0f - Mathf.Lerp(conn2.rightSidewalk.crosswalkMinHeight, conn2.rightSidewalk.crosswalkMaxHeight, UnityEngine.Random.value) + conn2.rightSidewalk.curbHeight;
					num41 = conn2.rightSidewalk.pavementIndex;
					flag6 = false;
				}
				num49 = num33 - 1;
				num50 = num34;
			}
			else
			{
				if (conn2.rightSidewalkActive && conn2.rightCrosswalkActive)
				{
					float num56 = 0.5f;
					for (int num57 = 0; num57 < list.Count; num57++)
					{
						if (list[num57] == conn2.firstRightRoundingVec)
						{
							if (num57 > 1)
							{
								list.RemoveRange(1, num57 - 1);
							}
							break;
						}
					}
					Vector3 normalized2 = (list[1] - list[0]).normalized;
					Vector3 vector13 = list[0] + normalized2 * num56;
					list.Insert(1, vector13);
					int count3 = conn2.rightSidewalk.yPositions.Count;
					int num58 = Mathf.RoundToInt(Mathf.Floor((float)count3 * 0.5f));
					for (int num59 = 1; num59 < count3; num59++)
					{
						Vector3 vector14 = vector13 + normalized2 * conn2.rightSidewalk.yPositions[num59];
						list.Insert(num59 + 1, vector14);
						if (num59 == num58)
						{
							conn2.crosswalkRightPosition = vector14;
						}
					}
					num24 = 0;
					num25 = 6;
					num26 = 2;
					if (conn2.rightSidewalk.yPositions.Count == 7)
					{
						num26++;
						num25 += 2;
					}
					num27 = num26 + 2;
					num42 = 0f - Mathf.Lerp(conn2.rightSidewalk.crosswalkMinHeight, conn2.rightSidewalk.crosswalkMaxHeight, UnityEngine.Random.value) + conn2.rightSidewalk.curbHeight;
					num40 = conn2.rightSidewalk.pavementIndex;
					flag6 = false;
				}
				if (conn1.leftSidewalkActive && conn1.leftCrosswalkActive)
				{
					vector10 = conn1.firstLeftRoundingVec;
					list11 = conn1.leftSidewalk.yPositions;
					num28 = 0;
					num29 = 6;
					num30 = 2;
					if (conn1.leftSidewalk.yPositions.Count == 7)
					{
						num30++;
						num29 += 2;
					}
					num31 = num30 + 2;
					num43 = 0f - Mathf.Lerp(conn1.leftSidewalk.crosswalkMinHeight, conn1.leftSidewalk.crosswalkMaxHeight, UnityEngine.Random.value) + conn1.leftSidewalk.curbHeight;
					num41 = conn1.leftSidewalk.pavementIndex;
					flag6 = false;
				}
				num49 = num33 - 1;
				num50 = num34;
			}
			if (!flag6)
			{
				for (int num60 = 1; num60 < list.Count; num60++)
				{
					if (OQQOCDQCQD.OOCQODQDQD(vector5, vector4, list[num60]) != flag2)
					{
						continue;
					}
					Vector3 vector15 = list[num60];
					list[num60] = OQQOCDQCQD.OCDCQCDDCC(vector5, vector4, list[num60 - 1], list[num60], flag: false);
					if (eRConnectionSibling != null)
					{
						vector9 = (list[num60 - 1] - vector15).normalized;
						if (num60 - 2 >= 1)
						{
							vector9 = (list[num60 - 2] - list[num60 - 1]).normalized;
						}
						list10 = new List<Vector3>(list);
						list10[num60 - 1] = list[num60];
						list10[num60] = vector15;
						list10.RemoveRange(0, num60 - 1);
						list10.Reverse();
						if (vector10 != Vector3.zero)
						{
							float num61 = 0.5f;
							for (int num62 = 0; num62 < list10.Count; num62++)
							{
								if (list10[num62] == vector10)
								{
									if (num62 > 1)
									{
										list10.RemoveRange(1, num62 - 1);
									}
									break;
								}
							}
							Vector3 normalized3 = (list10[1] - list10[0]).normalized;
							Vector3 vector16 = list10[0] + normalized3 * num61;
							list10.Insert(1, vector16);
							int count4 = list11.Count;
							int num63 = Mathf.RoundToInt(Mathf.Floor((float)count4 * 0.5f));
							int num64 = list10.Count - 2;
							for (int num65 = 1; num65 < count4; num65++)
							{
								Vector3 vector17 = vector16 + normalized3 * list11[num65];
								list10.Insert(num65 + 1, vector17);
								if (num65 == num63)
								{
									if (flag2)
									{
										conn1.crosswalkLeftPosition = vector17;
									}
									else
									{
										conn2.crosswalkRightPosition = vector17;
									}
								}
							}
						}
					}
					list.RemoveRange(num60 + 1, list.Count - num60 - 1);
				}
			}
			for (int num66 = 0; num66 < eRSideWalk.doConnectionTri.Count; num66++)
			{
				flag5 = false;
				if (flag6)
				{
					if (eRSideWalk.doConnectionTri[num66] || num66 == pavementIndex || num66 == pavementIndex + 1)
					{
						flag5 = true;
						num20++;
					}
				}
				else if (eRSideWalk.doConnectionTri[num66] && num66 != pavementIndex && num66 != pavementIndex + 1)
				{
					flag5 = true;
					num20++;
				}
				list8.Add(num20);
				list9.Add(flag5);
				vB2 = list[0] + vector2 * 50f * num2;
			}
			List<Vector3> wssss = new List<Vector3>();
			List<Vector3> ussss = new List<Vector3>();
			List<Vector2> list15 = new List<Vector2>();
			List<Vector2> list16 = new List<Vector2>();
			Vector3 vector18 = Vector3.zero;
			Vector3 p = Vector3.zero;
			Vector3 vector19 = Vector3.zero;
			Vector3 vector20 = Vector3.zero;
			bool flag8 = false;
			int num67 = 0;
			int count5 = list.Count;
			float num68 = 0f;
			Vector3 vector21 = Vector3.zero;
			Vector3 vA = list[0];
			if (num3 != 0f)
			{
				vA += vector2 * (0f - num3) * num;
			}
			Vector3 pCheck = Vector3.zero;
			Vector3 vector22 = Vector3.zero;
			bool flag9 = false;
			bool flag10 = true;
			if (conn1.buildPriority == 0 && conn2.buildPriority == 0 && conn1.leftSidewalk == conn2.rightSidewalk)
			{
				flag10 = false;
			}
			bool flag11 = false;
			int num69 = -1;
			int num70 = 0;
			int num71 = 0;
			int num72 = 0;
			int ussss2 = 0;
			for (int num73 = 0; num73 < count5; num73++)
			{
				Vector3 vector24;
				if (num73 > 0 && num73 < count5 - 1)
				{
					Vector3 vector23 = list[num73 + 1] - list[num73 - 1];
					vector24 = new Vector3(vector23.z, 0f, 0f - vector23.x).normalized;
				}
				else if (num73 == 0)
				{
					vector24 = num2 * (vector3 - list[0]).normalized;
				}
				else
				{
					Vector3 vector23 = list[num73] - list[num73 - 1];
					vector24 = new Vector3(vector23.z, 0f, 0f - vector23.x).normalized;
				}
				vector24 *= num;
				Vector3 vector25 = list[num73];
				Vector3 vector26 = vector25 + vector2 * (0f - num3) * num;
				if (num73 > 0)
				{
					num16 += Vector3.Distance(list[num73 - 1], list[num73]);
				}
				num68 = num16 / eRSideWalk.uvRatio * eRSideWalk.tiling;
				if (num73 >= num24 && num73 <= num25)
				{
					if (!flag7)
					{
						flag7 = true;
						if (num73 > 0)
						{
							list13.Add(verts.Count + eRSideWalk.realPavementIndex - eRSideWalk.realColCount - num51 - num71);
							list12.Add(num68);
						}
						else
						{
							list13.Add(eRSideWalk.realPavementIndex);
							list12.Add(num68);
						}
					}
					else
					{
						list12.Add(num68);
					}
				}
				else if (flag7)
				{
					float curbHeight = num42;
					list12.Add(num68);
					list14.Add(new ERCrosswalkInstance(new List<int>(list13), eRSideWalk, new List<float>(list12), curbHeight, num51 + num71));
					list13.Clear();
					list12.Clear();
					flag7 = false;
				}
				if (!flag6)
				{
					if (num73 == count5 - 1)
					{
						vector24 = -vector;
					}
					vector7 = OQQOCDQCQD.OCOOQOQCDC(vA, vB, vector26);
					num21 = Vector3.Distance(vector26, vector7);
					flag11 = false;
					if (num73 < count5 - 1)
					{
						if (count - 1 < eRSideWalk.shape.Count && count > 0)
						{
							pCheck = vector25 + (eRSideWalk.shape[count - 1].x + num3 - num21) * (-vector2 * num);
						}
						else
						{
							Debug.LogError("EasyRoads3D: Sidewalk '" + eRSideWalk.name + "' IndexOutOfRangeException, please report.");
						}
					}
				}
				num70 = tris.Count;
				for (int num74 = 0; num74 < count; num74++)
				{
					Vector3 vector27 = vector25;
					Vector2 vector28 = new Vector2(eRSideWalk.sidewalkUVs[num74], num68);
					Vector3 vector29;
					if (num74 <= pavementIndex || flag6)
					{
						vector29 = vector27 + (eRSideWalk.shape[num74].x + num3) * vector24;
						Vector3 vector30 = vector25;
						if (num74 == pavementIndex)
						{
							vector8 = OQQOCDQCQD.OCOOQOQCDC(vA, vB, vector29);
							num23 = Vector3.Distance(vector7, vector8);
							float num75 = eRSideWalk.shape[num74 + 1].x - eRSideWalk.shape[num74].x;
							num22 = Vector3.Distance(vector29, vector8);
							float num76 = eRSideWalk.shape[num74 + 1].x - num22;
							float t = num76 / num75;
							item = vector28;
							item.x = Mathf.Lerp(eRSideWalk.sidewalkUVs[num74 + 1], eRSideWalk.sidewalkUVs[num74], t);
							zero2 = OQQOCDQCQD.OCOOQOQCDC(vA, vB2, vector29);
							y = (item.y = Vector3.Distance(vector29, zero2) / eRSideWalk.uvRatio * eRSideWalk.tiling);
							if (num74 != 2)
							{
							}
						}
					}
					else
					{
						if (flag10 && OQQOCDQCQD.OOCQODQDQD(list[count5 - 1], list[count5 - 2], pCheck) != flag2)
						{
							if (!flag9)
							{
								flag11 = true;
								num69 = verts.Count;
							}
							flag9 = true;
						}
						if (vector20 != Vector3.zero && (num73 == count5 - 1 || flag11))
						{
							vector29 = vector21;
						}
						else
						{
							vector29 = vector27 + (eRSideWalk.shape[num74].x + num3 - num21) * (-vector2 * num);
							vector29 -= vector * num23;
							zero2 = OQQOCDQCQD.OCOOQOQCDC(vA, vB2, vector29);
						}
						item = vector28;
						item.y = y;
					}
					vector29.y += eRSideWalk.shape[num74].y;
					if (num73 >= num26 && num73 <= num27 && num74 <= num40)
					{
						vector29.y -= num42;
					}
					conn1.leftSidewalkVecs[num74].Add(vector29);
					conn1.leftSidewalkUVs[num74].Add(vector28);
					verts.Add(vector29);
					uv1.Add(vector28);
					if (num74 == pavementIndex && num73 == num25)
					{
						ussss2 = verts.Count - 1;
					}
					if (num73 == count5 - 1 && num74 == 0)
					{
						vector22 = vector29;
					}
					if (num74 == pavementIndex + 1 && vector20 == Vector3.zero)
					{
						Vector3 vector31 = OQQOCDQCQD.OCDCQCDDCC(p, vector29, vector18, vector19, flag: true);
						if (vector31 != Vector3.zero)
						{
							vector20 = vector31;
							ussss.Add(vector20);
							zero2 = OQQOCDQCQD.OCOOQOQCDC(vA, vB2, vector20);
							y = (item.y = Vector3.Distance(vector20, zero2) / eRSideWalk.uvRatio * eRSideWalk.tiling);
							list16.Add(new Vector2(vector28.x, item.y));
							float num77 = Vector3.Distance(verts[verts.Count - 1 - num18], vector20);
							float num78 = Vector3.Distance(verts[verts.Count - 1 - num18], verts[verts.Count - 1]);
							float t2 = num77 / num78;
							verts[verts.Count - 1] = vector20;
							Vector2 value = uv1[uv1.Count - 1];
							value.y = Mathf.Lerp(uv1[uv1.Count - 1 - num18].y, value.y, t2);
							uv1[uv1.Count - 1] = value;
							num77 = Vector3.Distance(vector18, vector20);
							num78 = Vector3.Distance(vector18, vector19);
							t2 = num77 / num78;
							int num79 = num67 - num18;
							int num80 = 0;
							for (int num81 = 0; num81 <= pavementIndex; num81++)
							{
								if (num81 == 0)
								{
									vector21 = verts[num79 + num18 + num80];
								}
								if (num81 == pavementIndex)
								{
									verts[num79 + num18 + num80] = Vector3.Lerp(verts[num79 + num80], verts[num79 + num80 + num18], t2);
									value = uv1[num79 + num18 + num80];
									value.y = Mathf.Lerp(uv1[num79 + num80].y, uv1[num79 + num80 + num18].y, t2);
									uv1[num79 + num18 + num80] = value;
								}
								if (list9[num81])
								{
									num80++;
								}
								num80++;
							}
							if (num73 < count5 - 1)
							{
								flag8 = true;
								tris.RemoveRange(num70, tris.Count - num70);
							}
						}
						else
						{
							ussss.Add(vector29);
							list16.Add(new Vector2(vector28.x, item.y));
						}
						p = vector29;
						vector18 = vector19;
					}
					if (list9[num74])
					{
						verts.Add(vector29);
						vector28.x += eRSideWalk.hardEdgePadding;
						uv1.Add(vector28);
						if (num73 == 0)
						{
							num18++;
						}
					}
					if (num74 == pavementIndex && vector20 == Vector3.zero)
					{
						wssss.Add(vector29);
						list15.Add(item);
						vector19 = vector29;
					}
					if (!flag8 && num74 < count - 1 && num73 < list.Count - 1 && ((num74 != pavementIndex && (!flag9 || num74 < pavementIndex)) || flag6) && (!flag7 || num74 < eRSideWalk.pavementIndex || num74 >= eRSideWalk.pavementIndex + 1 + num72))
					{
						if (num == -1f)
						{
							tris[0].Add(num19 + num74 + list8[num74]);
							tris[0].Add(num19 + num74 + count + num20 + 1 + list8[num74]);
							tris[0].Add(num19 + num74 + count + num20 + list8[num74]);
							tris[0].Add(num19 + num74 + list8[num74]);
							tris[0].Add(num19 + num74 + list8[num74] + 1);
							tris[0].Add(num19 + num74 + count + num20 + 1 + list8[num74]);
						}
						else
						{
							tris[0].Add(num19 + num74 + list8[num74]);
							tris[0].Add(num19 + num74 + count + num20 + list8[num74]);
							tris[0].Add(num19 + num74 + count + num20 + 1 + list8[num74]);
							tris[0].Add(num19 + num74 + list8[num74]);
							tris[0].Add(num19 + num74 + count + num20 + 1 + list8[num74]);
							tris[0].Add(num19 + num74 + list8[num74] + 1);
						}
					}
					if (num74 == 0)
					{
						vector21 = vector29;
					}
				}
				num67 = verts.Count;
				if (flag8)
				{
					break;
				}
				num19 = (num73 + 1) * (count + num20);
				Vector3 vector32 = vector7;
			}
			if (flag8)
			{
				zero2 = OQQOCDQCQD.OCOOQOQCDC(vA, vB2, list[count5 - 1]);
				float num82 = Vector3.Distance(list[count5 - 1], zero2);
				List<int> _1ssss = tris[0];
				vector22 = Assss(prefabScript, list[count5 - 1], vector21, vector20, vector, num16, ref verts, ref uv1, ref _1ssss, eRSideWalk, num3);
				tris[0] = _1ssss;
			}
			if (!flag6)
			{
				if (num69 != -1)
				{
					wssst(prefabScript, eRSideWalk, ref verts, ref uv1, vector22, vector20, num69, 1);
				}
				if (num24 != -1)
				{
					bool flag12 = false;
					int utsss = 0;
					List<Vector3> list17 = new List<Vector3>();
					int num83 = 0;
					int lastPavementCount = 0;
					bool flag13 = false;
					List<int> tris2 = new List<int>(tris[0]);
					list17 = list14[0].CreateCrosswalk(ref verts, ref uv1, ref tris2, ref lastPavementCount, (int)num, triangulateSidewalk: true, isConnector: true, null, prefabScript);
					tris[0] = tris2;
					flag12 = true;
					if (!eRSideWalk.includeOuterStrip)
					{
						wssss.RemoveRange(0, 6);
						ussss.RemoveRange(0, 6);
					}
					else
					{
						wssss.RemoveRange(0, 8);
						ussss.RemoveRange(0, 8);
					}
					xssss(prefabScript, ussss2, ref ussss, ref wssss, eRSideWalk.shape, eRSideWalk, vector, eRSideWalk.sidewalkUVs, flag2, num, ref verts, ref uv1, ref tris, utsss, flag12, vector20, xtsss: false);
				}
				else
				{
					wssss.Reverse();
					list15.Reverse();
					ussss.AddRange(wssss);
					list16.AddRange(list15);
					List<int> list18 = OQQOCDQCQDExt.OOQOQOCODD(ussss, ussss, null);
					num19 = verts.Count;
					verts.AddRange(ussss);
					uv1.AddRange(list16);
					for (int num84 = 0; num84 < list18.Count; num84++)
					{
						tris[0].Add(num19 + list18[num84]);
					}
				}
			}
			else
			{
				if (num24 != -1)
				{
					bool flag14 = false;
					int num85 = 0;
					List<Vector3> list19 = new List<Vector3>();
					int num86 = 0;
					int lastPavementCount2 = 0;
					bool flag15 = false;
					List<int> tris3 = new List<int>(tris[0]);
					list19 = list14[0].CreateCrosswalk(ref verts, ref uv1, ref tris3, ref lastPavementCount2, (int)num, triangulateSidewalk: true, isConnector: true, null, prefabScript);
					tris[0] = tris3;
					flag14 = true;
				}
				List<int> tris4 = tris[0];
				OCQQCDDDQO(eRSideWalk, conn1.leftSidewalkVecs, conn1.leftSidewalkUVs, ref verts, ref uv1, ref tris4, list.Count, (int)num, 1);
				tris[0] = tris4;
				vector4 = prefabScript.transform.TransformPoint(conn1.leftSidewalkVecs[4][conn1.leftSidewalkVecs[0].Count - 1]);
				vector5 = prefabScript.transform.TransformPoint(conn1.leftSidewalkVecs[4][conn1.leftSidewalkVecs[0].Count - 2]);
			}
			if (!flag2)
			{
				if (conn1.road != null && conn1.road.endPrefabScript == prefabScript && !conn1.road.leftSidewalkActive)
				{
					List<int> tris5 = tris[0];
					OCQQCDDDQO(eRSideWalk, conn1.leftSidewalkVecs, conn1.leftSidewalkUVs, ref verts, ref uv1, ref tris5, list.Count, (int)num, 0);
					tris[0] = tris5;
				}
				else if (conn1.road != null && conn1.road.startPrefabScript == prefabScript && !conn1.road.rightSidewalkActive)
				{
					List<int> tris6 = tris[0];
					OCQQCDDDQO(eRSideWalk, conn1.leftSidewalkVecs, conn1.leftSidewalkUVs, ref verts, ref uv1, ref tris6, list.Count, (int)(0f - num), 0);
					tris[0] = tris6;
				}
			}
			else if (conn2.road != null && conn2.road.endPrefabScript == prefabScript && !conn2.road.rightSidewalkActive)
			{
				List<int> tris7 = tris[0];
				OCQQCDDDQO(eRSideWalk, conn1.leftSidewalkVecs, conn1.leftSidewalkUVs, ref verts, ref uv1, ref tris7, list.Count, (int)(0f - num), 0);
				tris[0] = tris7;
			}
			else if (conn2.road != null && conn2.road.startPrefabScript == prefabScript && !conn2.road.leftSidewalkActive)
			{
				List<int> tris8 = tris[0];
				OCQQCDDDQO(eRSideWalk, conn1.leftSidewalkVecs, conn1.leftSidewalkUVs, ref verts, ref uv1, ref tris8, list.Count, (int)num, 0);
				tris[0] = tris8;
			}
			int count6 = verts.Count;
			int count7 = verts.Count;
			OCCCDCDQDC.OCODODDOQO(eRSideWalk, ref verts, Vector3.zero, eRSideWalk.shape.Count + num20, count6, count7, 0);
			if (list10 != null && list10.Count > 0)
			{
				num19 = verts.Count;
				num *= -1f;
				Material material = eRSideWalk.material;
				vector2 = eRConnectionSibling.sideways;
				bool flag16 = false;
				Vector3 vector33 = vector22 + -vector * 150f;
				if (eRConnectionSibling == conn1)
				{
					eRSideWalk = (conn1.leftSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn1.leftSidewalkid));
					num3 = conn1.roadType.roadShapeData.leftSidewalkOffset * num;
					vector = conn1.forward;
					vector2 = (conn1.rightRoundingPoints[0] - conn1.leftRoundingPoints[0]).normalized;
					flag16 = true;
				}
				else
				{
					eRSideWalk = (conn2.rightSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, conn2.rightSidewalkid));
					num3 = conn2.roadType.roadShapeData.rightSidewalkOffset * num;
					vector33 = vector22 + -vector * 150f;
					vector4 = list2[0] + -conn2.sideways * (eRSideWalk.sidewalkWidth + num3);
					vector5 = vector4 + conn2.forward * 150f;
					vector = conn2.forward;
					vector2 = (conn2.leftRoundingPoints[0] - conn2.rightRoundingPoints[0]).normalized;
					flag16 = false;
				}
				if (eRSideWalk == null)
				{
					Debug.Log("Second sidewalk object is null: " + prefabScript.gameObject.name);
					return false;
				}
				list14.Clear();
				list13.Clear();
				list12.Clear();
				wssss.Clear();
				ussss.Clear();
				num71 = 0;
				int num87 = 0;
				if (material != eRSideWalk.material)
				{
					mats.Add(eRSideWalk.material);
					num87 = 1;
				}
				count = eRSideWalk.shape.Count;
				list9 = eRSideWalk.doConnectionTri;
				num16 = 0f;
				Vector3 vector23;
				Vector3 vector29;
				Vector3 a = (vector29 = (vector23 = Vector3.zero));
				num20 = 0;
				list8.Clear();
				tris.Add(new List<int>());
				int num88 = 0;
				List<float> list20 = new List<float>();
				for (int num89 = 0; num89 < list9.Count; num89++)
				{
					if (list9[num89])
					{
						num20++;
						if (num89 <= eRSideWalk.pavementIndex)
						{
							num88++;
						}
						if (num89 >= eRSideWalk.pavementIndex + 1)
						{
							list20.Add(eRSideWalk.shape[num89].y);
						}
					}
					list8.Add(num20);
					if (num89 <= eRSideWalk.pavementIndex)
					{
						num88++;
					}
					if (num89 >= eRSideWalk.pavementIndex + 1)
					{
						list20.Add(eRSideWalk.shape[num89].y);
					}
				}
				int num90 = count + num20;
				count5 = list10.Count;
				for (int num91 = 0; num91 < count5; num91++)
				{
					Vector3 vector24;
					if (num91 > 0 && num91 < count5 - 1)
					{
						vector23 = list10[num91 + 1] - list10[num91 - 1];
						vector24 = new Vector3(vector23.z, 0f, 0f - vector23.x).normalized;
					}
					else if (num91 == 0)
					{
						vector24 = -vector2 * num;
					}
					else
					{
						vector23 = list10[num91] - list10[num91 - 1];
						vector24 = new Vector3(vector23.z, 0f, 0f - vector23.x).normalized;
						if (num28 != -1)
						{
							vector9 = vector23;
						}
					}
					vector24 *= num;
					if (num91 >= num28 && num91 <= num29)
					{
						if (!flag7)
						{
							flag7 = true;
							if (num91 > 0)
							{
								list13.Add(verts.Count + eRSideWalk.realPavementIndex - eRSideWalk.realColCount - num51 - num71);
								list12.Add(0f);
							}
							else
							{
								list13.Add(verts.Count + eRSideWalk.realPavementIndex);
							}
						}
						else
						{
							list12.Add(0f);
						}
					}
					else if (flag7)
					{
						float curbHeight2 = num43;
						if (num91 >= num28 && num91 <= num29)
						{
							curbHeight2 = num43;
						}
						list14.Add(new ERCrosswalkInstance(new List<int>(list13), eRSideWalk, new List<float>(list12), curbHeight2, num51 + num71));
						list13.Clear();
						list12.Clear();
						flag7 = false;
					}
					Vector3 vector25 = list10[num91];
					Vector3 vector26 = (vector25 += vector2 * num3 * num);
					if (num91 == count5 - 1)
					{
						vector25 = vector22;
					}
					if (num91 > 0)
					{
						num16 += Vector3.Distance(a, vector26);
					}
					num68 = num16 / eRSideWalk.uvRatio * eRSideWalk.tiling;
					num70 = tris.Count;
					for (int num92 = 0; num92 < count; num92++)
					{
						Vector3 vector27 = vector25;
						vector29 = vector27 + eRSideWalk.shape[num92].x * vector24;
						vector29.y += eRSideWalk.shape[num92].y;
						if (num91 >= num30 && num91 <= num31 && num92 <= num41)
						{
							vector29.y -= num43;
						}
						verts.Add(vector29);
						Vector2 vector28 = new Vector2(eRSideWalk.sidewalkUVs[num92], num68);
						uv1.Add(vector28);
						if (num92 == eRSideWalk.pavementIndex)
						{
							wssss.Add(vector29);
						}
						else if (num92 == eRSideWalk.pavementIndex + 1)
						{
							ussss.Add(vector29);
						}
						if (list9[num92])
						{
							verts.Add(vector29);
							vector28.x += eRSideWalk.hardEdgePadding;
							uv1.Add(vector28);
						}
						if (num92 < count - 1 && num91 < count5 - 1 && (!flag7 || num92 < eRSideWalk.pavementIndex || num92 >= eRSideWalk.pavementIndex + 1))
						{
							if (num == -1f)
							{
								tris[num87].Add(num19 + num92 + list8[num92]);
								tris[num87].Add(num19 + num92 + count + num20 + 1 + list8[num92]);
								tris[num87].Add(num19 + num92 + count + num20 + list8[num92]);
								tris[num87].Add(num19 + num92 + list8[num92]);
								tris[num87].Add(num19 + num92 + list8[num92] + 1);
								tris[num87].Add(num19 + num92 + count + num20 + 1 + list8[num92]);
							}
							else
							{
								tris[num87].Add(num19 + num92 + list8[num92]);
								tris[num87].Add(num19 + num92 + count + num20 + list8[num92]);
								tris[num87].Add(num19 + num92 + count + num20 + 1 + list8[num92]);
								tris[num87].Add(num19 + num92 + list8[num92]);
								tris[num87].Add(num19 + num92 + count + num20 + 1 + list8[num92]);
								tris[num87].Add(num19 + num92 + list8[num92] + 1);
							}
						}
					}
					a = vector26;
					num19 += count + num20;
				}
				if (flag7)
				{
					float curbHeight3 = num43;
					list14.Add(new ERCrosswalkInstance(new List<int>(list13), eRSideWalk, new List<float>(list12), curbHeight3, num51 + num71));
					list13.Clear();
					list12.Clear();
					flag7 = false;
				}
				int num93 = verts.Count - count - num20;
				if (OQQOCDQCQD.OOCQODQDQD(vector22, vector33, vector29) == flag16)
				{
					num19 = num93;
					for (int num94 = 0; num94 < count; num94++)
					{
						Vector3 vector34 = verts[num93 + num94 + list8[num94]];
						Vector3 p2 = vector34 + vector9 * 2f;
						vector29 = OQQOCDQCQD.OCDCQCDDCC(vector22, vector33, vector34, p2, flag: false);
						num16 = Vector3.Distance(vector29, vector34);
						vector29.y += eRSideWalk.shape[num94].y;
						num68 = uv1[num93 + num94 + list8[num94]].y + num16 / eRSideWalk.uvRatio * eRSideWalk.tiling;
						verts.Add(vector29);
						Vector2 vector28 = new Vector2(eRSideWalk.sidewalkUVs[num94], num68);
						uv1.Add(vector28);
						if (list9[num94])
						{
							verts.Add(vector29);
							vector28.x += eRSideWalk.hardEdgePadding;
							uv1.Add(vector28);
						}
						if (num94 < count - 1)
						{
							if (num == -1f)
							{
								tris[num87].Add(num19 + num94 + list8[num94]);
								tris[num87].Add(num19 + num94 + count + num20 + 1 + list8[num94]);
								tris[num87].Add(num19 + num94 + count + num20 + list8[num94]);
								tris[num87].Add(num19 + num94 + list8[num94]);
								tris[num87].Add(num19 + num94 + list8[num94] + 1);
								tris[num87].Add(num19 + num94 + count + num20 + 1 + list8[num94]);
							}
							else
							{
								tris[num87].Add(num19 + num94 + list8[num94]);
								tris[num87].Add(num19 + num94 + count + num20 + list8[num94]);
								tris[num87].Add(num19 + num94 + count + num20 + 1 + list8[num94]);
								tris[num87].Add(num19 + num94 + list8[num94]);
								tris[num87].Add(num19 + num94 + count + num20 + 1 + list8[num94]);
								tris[num87].Add(num19 + num94 + list8[num94] + 1);
							}
						}
					}
				}
				else
				{
					int num95 = num90 - num88;
					num93 = verts.Count - num95;
					for (int num96 = 0; num96 < num95; num96++)
					{
						Vector3 vector35 = OQQOCDQCQD.OCDCQCDDCC(vector22, vector33, verts[num93 + num96], verts[num93 + num96 - num90], flag: true);
						if (vector35 != Vector3.zero)
						{
							vector35.y += list20[num96];
							float num97 = Vector3.Distance(vector35, verts[num93 + num96]);
							verts[num93 + num96] = vector35;
							Vector2 value2 = uv1[num93 + num96];
							value2.y -= num97 / eRSideWalk.uvRatio * eRSideWalk.tiling;
							uv1[num93 + num96] = value2;
							if (num96 == 0)
							{
								ussss[ussss.Count - 1] = vector35;
							}
						}
					}
				}
				if (num28 != -1 && list14.Count > 0)
				{
					bool flag17 = false;
					int ttsss = 0;
					List<Vector3> list21 = new List<Vector3>();
					int num98 = 0;
					int lastPavementCount3 = 0;
					bool flag18 = false;
					List<int> tris9 = new List<int>(tris[num87]);
					list21 = list14[0].CreateCrosswalk(ref verts, ref uv1, ref tris9, ref lastPavementCount3, (int)num, triangulateSidewalk: false, isConnector: true, null, prefabScript);
					tris[num87] = tris9;
					flag17 = true;
					if (!eRSideWalk.includeOuterStrip)
					{
						wssss.RemoveRange(2, 3);
						wssss.InsertRange(2, list21);
					}
					else
					{
						wssss.RemoveRange(2, 5);
						wssss.InsertRange(2, list21);
					}
					yssst(prefabScript, ref ussss, ref wssss, eRSideWalk.shape, eRSideWalk, vector, eRSideWalk.sidewalkUVs, flag2, num, ref verts, ref uv1, ref tris, ttsss, flag17, vtsss: true, num87);
				}
			}
			return true;
		}

		private static void wssst(ERCrossingPrefabs tssss, ERSideWalk ussss, ref List<Vector3> vssss, ref List<Vector2> wssss, Vector3 xssss, Vector3 yssss, int Assss, int _0ssss)
		{
			if (ussss.curbVecCount == 0)
			{
				ussss.OCOODDDQCC();
			}
			int curbVecCount = ussss.curbVecCount;
			Vector3 b = vssss[Assss + ussss.curbVecCount];
			b.y -= ussss.shape[ussss.shape.Count - 1].y;
			float num = Vector3.Distance(xssss, b);
			float num2 = num / ussss.uvRatio * ussss.tiling;
			vssss[Assss] = yssss;
			Vector2 value;
			if (curbVecCount > 2)
			{
				value = wssss[Assss];
				value.y -= num2;
				wssss[Assss] = value;
				b = Vector3.Lerp(yssss, xssss, ussss.shapePercentages[ussss.pavementIndex + 2]);
				b.y += ussss.shape[ussss.pavementIndex + 2].y;
				vssss[Assss + 1] = b;
				value = wssss[Assss + 1];
				value.y -= num2;
				wssss[Assss + 1] = value;
				if (ussss.hardEdges)
				{
					vssss[Assss + 2] = b;
					wssss[Assss + 2] = value;
				}
			}
			b = xssss;
			b.y = ussss.shape[ussss.shape.Count - 1].y;
			vssss[Assss + ussss.curbVecCount] = b;
			value = wssss[Assss + ussss.curbVecCount];
			value.y -= num2;
			wssss[Assss + ussss.curbVecCount] = value;
		}

		private static void xssss(ERCrossingPrefabs tssss, int ussss, ref List<Vector3> vssss, ref List<Vector3> wssss, List<Vector2> xssss, ERSideWalk yssss, Vector3 Assss, List<float> _0ssss, bool _1ssss, float _2ssss, ref List<Vector3> _3ssss, ref List<Vector2> _4ssss, ref List<List<int>> ttsss, int utsss, bool vtsss, Vector3 wtsss, bool xtsss)
		{
			int num = ussss + 1;
			int index = wssss.Count - 1;
			int num2 = vssss.Count - 1;
			if (num2 > 1)
			{
				vssss.RemoveRange(1, num2 - 1);
			}
			num2 = 1;
			if (wtsss != Vector3.zero)
			{
				wssss.RemoveAt(index);
				wssss.Add(wtsss);
			}
			Vector3 vector = _3ssss[ussss];
			Vector3 vector2 = _3ssss[num];
			float y = _4ssss[num].y;
			if (_4ssss[ussss].y != _4ssss[num].y)
			{
				Vector3 vA = vector - Assss * 100f;
				vector = OQQOCDQCQD.OCOOQOQCDC(vA, vector, vector2);
				float num3 = Vector3.Distance(vector, _3ssss[ussss]);
				Vector2 value = _4ssss[ussss];
				value.y = _4ssss[num].y + num3 / yssss.uvRatio * yssss.tiling;
				_4ssss[ussss] = value;
			}
			wssss.RemoveAt(0);
			Vector3 vector3 = vssss[0];
			Vector3 vB = vector3 + Assss * 50f;
			index = wssss.Count - 1;
			int item = ussss;
			int count = _3ssss.Count;
			float num4 = yssss.sidewalkUVs[yssss.pavementIndex];
			float num5 = yssss.sidewalkUVs[yssss.pavementIndex + 1];
			float num6 = yssss.shape[yssss.pavementIndex + 1].x - yssss.shape[yssss.pavementIndex].x;
			num4 = yssss.sidewalkUVs[yssss.pavementIndex + 1];
			num5 = yssss.sidewalkUVs[yssss.pavementIndex];
			for (int i = 0; i <= index; i++)
			{
				Vector3 vector4 = wssss[i];
				_3ssss.Add(wssss[i]);
				Vector3 b = OQQOCDQCQD.OCOOQOQCDC(vector3, vB, vector4);
				float num7 = Vector3.Distance(vector4, b);
				float x = Mathf.Lerp(num4, num5, num7 / num6);
				b = OQQOCDQCQD.OCOOQOQCDC(vector, vector2, vector4);
				num7 = Vector3.Distance(vector4, b);
				float y2 = y + num7 / yssss.uvRatio * yssss.tiling;
				_4ssss.Add(new Vector2(x, y2));
				if (_2ssss == -1f)
				{
					ttsss[0].Add(count + i);
					ttsss[0].Add(item);
					ttsss[0].Add(num);
				}
				else
				{
					ttsss[0].Add(item);
					ttsss[0].Add(count + i);
					ttsss[0].Add(num);
				}
				item = count + i;
			}
		}

		private static void yssst(ERCrossingPrefabs tssss, ref List<Vector3> ussss, ref List<Vector3> vssss, List<Vector2> wssss, ERSideWalk xssss, Vector3 yssss, List<float> Assss, bool _0ssss, float _1ssss, ref List<Vector3> _2ssss, ref List<Vector2> _3ssss, ref List<List<int>> _4ssss, int ttsss, bool utsss, bool vtsss, int wtsss)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector3> list3 = new List<Vector3>();
			List<Vector2> list4 = new List<Vector2>();
			Vector3 vector = vssss[0];
			Vector3 vector2 = ussss[0];
			if (ttsss > 0)
			{
				vector = vssss[ttsss - 1];
				vector2 = ussss[ttsss - 1];
				ussss.RemoveRange(0, ttsss);
				vssss.RemoveRange(0, ttsss);
			}
			int num = ussss.Count - 1;
			int num2 = 0;
			List<float> list5 = new List<float>();
			float num3 = 0f;
			list5.Add(0f);
			if (!utsss)
			{
				for (int i = 0; i < num - 2 && OQQOCDQCQD.OOCQODQDQD(ussss[i + 1], ussss[i], ussss[i + 2]) == _0ssss; i++)
				{
					num2 = i + 1;
					num3 += Vector3.Distance(vssss[i], vssss[i + 1]);
					list5.Add(num3);
				}
			}
			int num4 = 0;
			for (int j = 0; j < vssss.Count - 2 && OQQOCDQCQD.OOCQODQDQD(vssss[j + 1], vssss[j], vssss[j + 2]) == _0ssss; j++)
			{
				Vector3 vA = vssss[j] + (vssss[j + 1] - vssss[j]).normalized * 50f;
				Vector3 b = OQQOCDQCQD.OCOOQOQCDC(vA, vssss[j], vssss[j + 2]);
				float num5 = Vector3.Distance(vssss[j + 2], b);
				if (num5 < 0.01f)
				{
					if (j < vssss.Count - 2 && OQQOCDQCQD.OOCQODQDQD(vssss[j + 1], vssss[j], vssss[j + 3]) == _0ssss)
					{
						num4 = j + 1;
					}
				}
				else
				{
					num4 = j + 1;
				}
			}
			float num6 = num3;
			float num7 = 0f;
			Vector3 normalized = (ussss[num2] - vssss[num2]).normalized;
			if (num2 != 0)
			{
				num7 = num6 / xssss.uvRatio * xssss.tiling;
				yssss = (ussss[num2 + 1] - ussss[num2]).normalized;
				vector2 = ussss[num2];
				vector = ((!_0ssss) ? (vector2 - new Vector3(yssss.z, 0f, 0f - yssss.x) * xssss.pavementSize) : (vector2 + new Vector3(yssss.z, 0f, 0f - yssss.x) * xssss.pavementSize));
				normalized = (vector2 - vector).normalized;
			}
			bool flag = true;
			Vector3 vector3;
			Vector3 p;
			if (num4 > num2)
			{
				flag = false;
				vector3 = vssss[num2];
				p = vector3 + yssss * 150f;
				Vector3 vector4 = vssss[num2];
				Vector3 vector5 = vssss[num2];
				vector4 = ((!_0ssss) ? (vector5 - new Vector3(yssss.z, 0f, 0f - yssss.x) * xssss.pavementSize) : (vector5 + new Vector3(yssss.z, 0f, 0f - yssss.x) * xssss.pavementSize));
				list.Add(vector3);
				list2.Add(ERSideWalkVecs.vssss(vector4, vector5, vector3, -1, num7, xssss));
				for (int k = num2 + 1; k < vssss.Count; k++)
				{
					Vector3 vector6 = OQQOCDQCQD.OCDCQCDDCC(vector3, p, vssss[k - 1], vssss[k], flag: true);
					if (vector6 != Vector3.zero && k > num2 + 1)
					{
						list.Add(vector6);
						list2.Add(ERSideWalkVecs.vssss(vector4, vector5, vector6, -1, num7, xssss));
						vssss.RemoveRange(num2 + 1, k - num2 - 1);
						vssss.Insert(num2 + 1, vector6);
						break;
					}
					list.Add(vssss[k]);
					list2.Add(ERSideWalkVecs.vssss(vector4, vector5, vssss[k], k - num2, num7, xssss));
				}
				if (list.Count >= 3)
				{
					List<int> tris = _4ssss[wtsss];
					DelaunayConstructor(list, list2, new List<Vector3>(), new List<Vector2>(), ref _2ssss, ref _3ssss, ref tris);
					_4ssss[wtsss] = tris;
				}
			}
			list.Clear();
			list2.Clear();
			vector3 = ussss[num2];
			p = vector3 + yssss * 150f;
			Vector3 vector7 = vssss[vssss.Count - 1];
			Vector3 vector8 = ussss[ussss.Count - 1];
			if (xssss.pavementSize == 0f)
			{
				xssss.pavementSize = wssss[xssss.pavementIndex + 1].x - wssss[xssss.pavementIndex].x;
			}
			list.Add(vssss[0]);
			list.Add(vssss[1]);
			if (num2 == 0)
			{
				list2.Add(new Vector2(Assss[xssss.pavementIndex], 0f));
			}
			else
			{
				list2.Add(new Vector2(Assss[xssss.pavementIndex], 0f));
			}
			if (num2 <= 1)
			{
				list2.Add(ERSideWalkVecs.vssss(vector, vector2, vssss[1], -1, num7, xssss));
			}
			else
			{
				list2.Add(new Vector2(Assss[xssss.pavementIndex], list5[1] / xssss.uvRatio * xssss.tiling));
			}
			bool flag2 = false;
			for (int l = 2; l < vssss.Count; l++)
			{
				Vector3 vector6 = OQQOCDQCQD.OCDCQCDDCC(vector3, p, vssss[l - 1], vssss[l], flag: true);
				if (vector6 != Vector3.zero)
				{
					list.Add(vector6);
					list2.Add(ERSideWalkVecs.vssss(vector, vector2, vector6, -1, num7, xssss));
					vssss.RemoveRange(0, l);
					vssss.Insert(0, vector6);
					flag2 = true;
					break;
				}
				list.Add(vssss[l]);
				if (l >= num2)
				{
					list2.Add(ERSideWalkVecs.vssss(vector, vector2, vssss[l], l - num2, num7, xssss));
				}
				else
				{
					list2.Add(new Vector2(Assss[xssss.pavementIndex], list5[l] / xssss.uvRatio * xssss.tiling));
				}
			}
			if (!flag2)
			{
				vssss.Clear();
			}
			list3.Add(ussss[0]);
			if (num2 == 0)
			{
				list4.Add(new Vector2(Assss[xssss.pavementIndex + 1], 0f));
			}
			else
			{
				list4.Add(new Vector2(Assss[xssss.pavementIndex + 1], 0f));
			}
			bool flag3 = false;
			int num8 = 0;
			if (vtsss)
			{
				num = ussss.Count;
			}
			bool flag4 = true;
			for (int m = 1; m <= num; m++)
			{
				if (m != num && (vtsss || OQQOCDQCQD.OOCQODQDQD(p, vector3, ussss[m]) == _0ssss))
				{
					flag4 = true;
				}
				else if (m != num || m < ussss.Count)
				{
					Vector3 vector6 = OQQOCDQCQD.OCOOQOQCDC(p, vector3, ussss[m]);
					flag4 = !((double)Vector3.Distance(vector6, ussss[m]) > 0.005);
				}
				else
				{
					flag4 = false;
				}
				if (flag4)
				{
					list3.Add(ussss[m]);
					if (m >= num2)
					{
						list4.Add(ERSideWalkVecs.vssss(vector, vector2, ussss[m], m - num2, num7, xssss));
					}
					else
					{
						list4.Add(new Vector2(Assss[xssss.pavementIndex + 1], list5[m] / xssss.uvRatio * xssss.tiling));
					}
					Vector3 a = OQQOCDQCQD.OCOOQOQCDC(p, vector3, ussss[m]);
					if (m < num - 1 && Vector3.Distance(a, ussss[m]) > 0.01f)
					{
						Vector3 vector6 = OQQOCDQCQD.OCDCQCDDCC(vector3, p, ussss[m], ussss[m + 1], flag: true);
						if (vector6 != Vector3.zero)
						{
							list3.Add(vector6);
							list4.Add(ERSideWalkVecs.vssss(vector, vector2, vector6, -1, num7, xssss));
							ussss.RemoveRange(0, m + 1);
							ussss.Insert(0, vector6);
							flag3 = true;
							break;
						}
					}
					num8++;
					continue;
				}
				if (num8 > 0)
				{
					if (m - 2 < 1)
					{
						m = 3;
					}
					ussss.RemoveRange(0, m - 2);
				}
				flag3 = true;
				break;
			}
			if (!flag3)
			{
				ussss.Clear();
			}
			if (list3.Count + list.Count >= 3)
			{
				List<int> tris2 = _4ssss[wtsss];
				DelaunayConstructor(list, list2, list3, list4, ref _2ssss, ref _3ssss, ref tris2);
				_4ssss[wtsss] = tris2;
			}
			float num9 = xssss.pavementSize - 0.0025f;
			flag = false;
			num8 = 0;
		}

		private static Vector3 Assss(ERCrossingPrefabs tssss, Vector3 ussss, Vector3 vssss, Vector3 wssss, Vector3 xssss, float yssss, ref List<Vector3> Assss, ref List<Vector2> _0ssss, ref List<int> _1ssss, ERSideWalk _2ssss, float _3ssss)
		{
			if (!_2ssss.beveledCurb)
			{
				return OOODQCODCC.CloseGapOODOODDDOD(tssss, ussss, vssss, wssss, xssss, yssss, ref Assss, ref _0ssss, ref _1ssss, _2ssss, _3ssss);
			}
			if ((_2ssss.beveledHeight > 0f && _2ssss.beveledDepth > 0f) || _2ssss.beveledHeight > 0f || _2ssss.beveledDepth > 0f)
			{
			}
			return Vector3.zero;
		}

		public static void OCQQCDDDQO(ERSideWalk sw, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<int> tris, int pointsCount, int leftrightroad, int startEnd)
		{
			QDOQDSQOOQDDD qDOQDSQOOQDDD = new QDOQDSQOOQDDD(null);
			qDOQDSQOOQDDD.CopyFromSidewalk(sw);
			int triArrayElement = 0;
			List<List<int>> triList = new List<List<int>>();
			triList.Add(tris);
			List<List<int>> list = new List<List<int>>();
			int num = 0;
			for (int i = 0; i < sourceVecs.Count; i++)
			{
				list.Add(new List<int>());
				list[num].Add(num);
				if (sw.doConnectionTri[i])
				{
					num++;
					list.Add(new List<int>());
					list[num].Add(num);
				}
				num++;
			}
			num = list.Count;
			pointsCount--;
			for (int j = 0; j < list.Count; j++)
			{
				list[j].Add(pointsCount * num + j);
			}
			if (leftrightroad == -1)
			{
				leftrightroad = 0;
			}
			if (qDOQDSQOOQDDD.outerCurb)
			{
				if (!qDOQDSQOOQDDD.beveledCurb)
				{
					OOODQCODCC.OODOODDDOD(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, startEnd, sw.hardEdges);
				}
				else if (qDOQDSQOOQDDD.beveledHeight > 0f && qDOQDSQOOQDDD.beveledDepth > 0f)
				{
					OOODQCODCC.OCQDQODOQQ(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, sw.hardEdges);
				}
				else if (qDOQDSQOOQDDD.beveledHeight > 0f)
				{
					OOODQCODCC.OQDDDCDCDO(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, sw.hardEdges);
				}
				else if (qDOQDSQOOQDDD.beveledDepth > 0f)
				{
					OOODQCODCC.OQCDCQQOQO(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, sw.hardEdges);
				}
				else
				{
					OOODQCODCC.OCODODDDOC(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, sw.hardEdges);
				}
			}
			else if (!qDOQDSQOOQDDD.beveledCurb)
			{
				OOODQCODCC.OQQQDCQCOC(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, startEnd, sw.hardEdges);
			}
			else if (qDOQDSQOOQDDD.beveledHeight > 0f && qDOQDSQOOQDDD.beveledDepth > 0f)
			{
				OOODQCODCC.OCQCDODQDC(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, sw.hardEdges);
			}
			else if (qDOQDSQOOQDDD.beveledHeight > 0f)
			{
				OOODQCODCC.OCCQCCQDOO(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, sw.hardEdges);
			}
			else if (qDOQDSQOOQDDD.beveledDepth > 0f)
			{
				OOODQCODCC.OCDOQCOQDQ(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, sw.hardEdges);
			}
			else
			{
				OOODQCODCC.OOCDDDQQDD(null, qDOQDSQOOQDDD, sourceVecs, sourceUVs, list, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, sw.hardEdges);
			}
		}

		public static void OQQDQDDQOC(ERModularRoad road, List<GameObject> crosswalkObjects, List<Vector3> leftPositions, List<Vector3> leftPerpPositions, List<Vector3> rightPositions, List<Vector3> rightPerpPositions, List<int> leftIndexes, List<int> rightIndexes, List<Vector3> leftPoints, List<Vector3> rightPoints)
		{
			List<Vector3> list = leftPositions;
			List<Vector3> list2 = rightPositions;
			if (road.rt == null && road.roadType != 0.0)
			{
				road.rt = QDQDOOQQDQODD.GetRoadTypeElByID(road.baseScript.roadTypes, road.roadType);
			}
			if (road.rt == null || (road.rt.crosswalkPrefab == null && road.rt.crosswalkType == ERCrossWalkType.Prefab) || (road.rt.crosswalkDecal == null && road.rt.crosswalkType == ERCrossWalkType.DecalProjector))
			{
				return;
			}
			float num = 1f;
			if (list.Count == 0)
			{
				list = rightPositions;
				list2 = rightPerpPositions;
				num = -1f;
			}
			else if (rightPositions.Count == 0)
			{
				list2 = leftPerpPositions;
			}
			float num2 = 0f;
			float num3 = 1f;
			Vector2 zero = Vector2.zero;
			float num4 = 0f;
			for (int i = 0; i < list.Count; i++)
			{
				Vector3 vector = Vector3.Lerp(list[i], list2[i], 0.5f);
				if (road.rt.crosswalkType == ERCrossWalkType.Prefab)
				{
					vector.y += road.rt.crosswalkHeightOffset;
				}
				else
				{
					vector.y += 0.25f;
				}
				num2 = Vector3.Distance(list[i], list2[i]);
				Vector3 normalized = (list[i] - list2[i]).normalized;
				num3 = 1f;
				Vector3 vector2;
				if (leftPoints != null && leftPoints.Count != 0)
				{
					if (rightPoints != null && rightPoints.Count != 0)
					{
						vector2 = Vector3.Lerp((leftPoints[leftIndexes[i] + 1] - leftPoints[leftIndexes[i] - 1]).normalized, (rightPoints[rightIndexes[i] + 1] - rightPoints[rightIndexes[i] - 1]).normalized, 0.5f);
						if (leftPoints[leftIndexes[i] + 1].y < leftPoints[leftIndexes[i] - 1].y)
						{
							num3 = -1f;
						}
					}
					else
					{
						vector2 = (leftPoints[leftIndexes[i] + 1] - leftPoints[leftIndexes[i] - 1]).normalized;
						if (leftPoints[leftIndexes[i] + 1].y < leftPoints[leftIndexes[i] - 1].y)
						{
							num3 = -1f;
						}
					}
				}
				else if (rightPoints != null && rightPoints.Count != 0)
				{
					vector2 = (rightPoints[rightIndexes[i] + 1] - rightPoints[rightIndexes[i] - 1]).normalized;
					if (rightPoints[rightIndexes[i] + 1].y < rightPoints[rightIndexes[i] - 1].y)
					{
						num3 = -1f;
					}
				}
				else
				{
					vector2 = (list[i] - list2[i]).normalized;
				}
				if (road.rt.crosswalkType == ERCrossWalkType.DecalProjector && road.rt.crosswalkDecal != null)
				{
					num2 -= road.rt.crosswalkDecal.startOffset * 2f;
					Vector3 size = new Vector3(road.rt.crosswalkDecal.width, num2, 1f);
					float y = CrosswalkYTiling(road.rt.crosswalkDecal, num2);
					GameObject gameObject = OQQOCDQCQD.OOOQODQOQD(tiling: new Vector2(road.rt.crosswalkDecal.uvRightBottom.x - road.rt.crosswalkDecal.uvLeftTop.x, y), offset: new Vector2(road.rt.crosswalkDecal.uvLeftTop.x, 0f), name: road.rt.crosswalkDecal.name, size: size, drawDistance: road.rt.crosswalkDecal.drawDistance, mat: road.rt.crosswalkDecal.material, rendermask: road.rt.crosswalkDecal.renderingLayerMask, transparentTextureResolution: 2);
					gameObject.transform.position = vector;
					gameObject.transform.parent = road.transform;
					gameObject.transform.forward = normalized;
					Vector3 normalized2 = new Vector3(vector2.x, 0f, vector2.z).normalized;
					float num5 = Vector3.Angle(vector2, normalized2);
					if (num5 > 1f)
					{
						if (num != 1f || list[i].y < list2[i].y)
						{
						}
						num5 *= num3;
						gameObject.transform.Rotate(0f, 0f, num5, Space.Self);
					}
					gameObject.transform.Rotate(90f, 0f, 0f, Space.Self);
					crosswalkObjects.Add(gameObject);
				}
				else
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(road.rt.crosswalkPrefab);
					gameObject2.name = road.rt.crosswalkPrefab.name + "_ERCrosswalk";
					gameObject2.transform.position = vector;
					gameObject2.transform.forward = vector2 * num;
					OQQOCDQCQD.OQOCQQOCOC(gameObject2, vector, null, Vector3.zero, vector + vector2 * num, list[i], -1f);
					gameObject2.transform.parent = road.transform;
					crosswalkObjects.Add(gameObject2);
				}
			}
		}

		public static float CrosswalkYTiling(ERDecal decal, float crosswalkLength)
		{
			float num = 0f;
			float num2 = 0f;
			if (decal.uvBreakPoints.Count > 0)
			{
				float num3 = crosswalkLength / decal.length;
				float num4 = Mathf.Floor(num3);
				float num5 = num3 - num4;
				for (int i = 0; i < decal.uvBreakPoints.Count; i++)
				{
					if (decal.uvBreakPoints[i].y > num5)
					{
						num = ((i == 0) ? ((!(decal.uvBreakPoints[i].y - num5 < num5 - 0f)) ? 0f : decal.uvBreakPoints[i].y) : ((i == decal.uvBreakPoints.Count - 1) ? ((!(1f - num5 < num5 - decal.uvBreakPoints[i].y)) ? decal.uvBreakPoints[i].y : 1f) : ((!(decal.uvBreakPoints[i].y - num5 < num5 - decal.uvBreakPoints[i - 1].y)) ? decal.uvBreakPoints[i - 1].y : decal.uvBreakPoints[i].y)));
						num2 = num4 + num;
						break;
					}
				}
			}
			else
			{
				num2 = crosswalkLength / decal.length;
			}
			if (num2 == 0f)
			{
				num2 = crosswalkLength / decal.length;
			}
			return num2;
		}

		public static void OCQDCQDOOO(Transform connection, ERConnectionSibling sibling)
		{
			Debug.Log(sibling.roadType.crosswalkType.ToString() + ":  " + sibling.roadType.crosswalkPrefab?.ToString() + " > " + sibling.roadType.crosswalkDecal);
			if (sibling.roadType == null || (sibling.roadType.crosswalkType == ERCrossWalkType.Prefab && sibling.roadType.crosswalkPrefab == null) || (sibling.roadType.crosswalkType == ERCrossWalkType.DecalProjector && sibling.roadType.crosswalkDecal == null))
			{
				return;
			}
			if (sibling.crosswalkLeftPosition == Vector3.zero)
			{
				Vector3 vA = sibling.leftRoundingPoints[0] + (sibling.leftRoundingPoints[0] - sibling.lEnd).normalized * 50f;
				sibling.crosswalkLeftPosition = OQQOCDQCQD.OCOOQOQCDC(vA, sibling.lEnd, sibling.crosswalkRightPosition);
			}
			else if (sibling.crosswalkRightPosition == Vector3.zero)
			{
				Vector3 vA2 = sibling.rightRoundingPoints[0] + (sibling.rightRoundingPoints[0] - sibling.rEnd).normalized * 50f;
				sibling.crosswalkRightPosition = OQQOCDQCQD.OCOOQOQCDC(vA2, sibling.rEnd, sibling.crosswalkLeftPosition);
			}
			Vector3 position = Vector3.Lerp(sibling.crosswalkLeftPosition, sibling.crosswalkRightPosition, 0.5f);
			Vector3 vector = connection.TransformPoint(sibling.firstLeftRoundingVec);
			Vector3 vector2 = connection.TransformPoint(sibling.firstRightRoundingVec);
			Vector3 vector3 = connection.TransformPoint(sibling.cp);
			Vector3 lhs = vector - vector3;
			Vector3 rhs = vector2 - vector3;
			Vector3 upwards = Vector3.Cross(lhs, rhs);
			GameObject gameObject = null;
			if (sibling.roadType.crosswalkType == ERCrossWalkType.Prefab)
			{
				position.y += sibling.roadType.crosswalkHeightOffset;
				gameObject = UnityEngine.Object.Instantiate(sibling.roadType.crosswalkPrefab);
				gameObject.transform.parent = connection;
				gameObject.transform.position = connection.TransformPoint(position);
				gameObject.transform.forward = (gameObject.transform.position - connection.TransformPoint(Vector3.zero)).normalized;
				gameObject.transform.rotation = Quaternion.LookRotation(gameObject.transform.forward, upwards);
			}
			else if (sibling.roadType.crosswalkType == ERCrossWalkType.DecalProjector)
			{
				ERDecal crosswalkDecal = sibling.roadType.crosswalkDecal;
				float num = Vector3.Distance(sibling.leftRoundingPoints[0], sibling.rightRoundingPoints[0]) - crosswalkDecal.startOffset;
				Vector3 size = new Vector3(crosswalkDecal.width, num, 1f);
				float y = CrosswalkYTiling(crosswalkDecal, num);
				gameObject = OQQOCDQCQD.OOOQODQOQD(tiling: new Vector2(crosswalkDecal.uvLeftTop.x - crosswalkDecal.uvRightBottom.x, y), offset: new Vector2(crosswalkDecal.uvLeftTop.x, crosswalkDecal.uvRightBottom.y), name: crosswalkDecal.name, size: size, drawDistance: crosswalkDecal.drawDistance, mat: crosswalkDecal.material, rendermask: crosswalkDecal.renderingLayerMask, transparentTextureResolution: 2);
				if (gameObject != null)
				{
					gameObject.transform.position = connection.TransformPoint(position);
					gameObject.transform.parent = connection;
					vector2 = connection.TransformPoint(sibling.leftRoundingPoints[0]);
					vector = connection.TransformPoint(sibling.rightRoundingPoints[0]);
					Vector3 forward = vector2 - vector;
					vector2 = gameObject.transform.position;
					vector = connection.transform.position;
					Vector3 normalized = (vector2 - vector).normalized;
					Vector3 normalized2 = new Vector3(normalized.x, 0f, normalized.z).normalized;
					float num2 = Vector3.Angle(normalized, normalized2);
					gameObject.transform.forward = forward;
					if (num2 > 1f)
					{
						if (vector2.y > vector.y)
						{
							num2 *= -1f;
						}
						gameObject.transform.Rotate(0f, 0f, num2, Space.Self);
					}
					gameObject.transform.Rotate(90f, 0f, 0f, Space.Self);
				}
			}
			sibling.crosswalkObject = gameObject;
		}

		public static void OCQCQODCOO(ERModularRoad OOOCDDCQCD, ERModularRoad road2, ERModularRoad attachTargetRoad, ERCrossingPrefabs prefabScript, Vector3 selectedRoadV3, Vector3 newRoadV3)
		{
			int num = 0;
			double num2 = 0.0;
			bool flag = false;
			bool flag2 = false;
			if (attachTargetRoad.startPrefabScript == prefabScript)
			{
				selectedRoadV3 = attachTargetRoad.markersExt[0].position;
				flag2 = true;
			}
			else
			{
				selectedRoadV3 = attachTargetRoad.markersExt[attachTargetRoad.markersExt.Count - 1].position;
			}
			bool flag3 = false;
			if (road2 != null && road2.startPrefabScript == prefabScript)
			{
				newRoadV3 = road2.markersExt[0].position;
				flag3 = true;
			}
			else
			{
				newRoadV3 = road2.markersExt[road2.markersExt.Count - 1].position;
			}
			Vector3 position = OOOCDDCQCD.markersExt[1].position;
			bool flag4 = OQQOCDQCQD.OOCQODQDQD(newRoadV3, selectedRoadV3, position);
			if ((flag2 && flag4) || (!flag2 && !flag4))
			{
				num = (OOOCDDCQCD.defaultLeftSidewalk = (OOOCDDCQCD.defaultRightSidewalk = attachTargetRoad.defaultLeftSidewalk));
				num2 = (OOOCDDCQCD.defaultLeftSidewalkid = (OOOCDDCQCD.defaultRightSidewalkid = attachTargetRoad.defaultLeftSidewalkid));
				flag = (OOOCDDCQCD.leftSidewalkActive = (OOOCDDCQCD.rightSidewalkActive = attachTargetRoad.leftSidewalkActive));
			}
			else
			{
				num = (OOOCDDCQCD.defaultLeftSidewalk = (OOOCDDCQCD.defaultRightSidewalk = attachTargetRoad.defaultRightSidewalk));
				num2 = (OOOCDDCQCD.defaultLeftSidewalkid = (OOOCDDCQCD.defaultRightSidewalkid = attachTargetRoad.defaultRightSidewalkid));
				flag = (OOOCDDCQCD.leftSidewalkActive = (OOOCDDCQCD.rightSidewalkActive = attachTargetRoad.rightSidewalkActive));
			}
		}
	}
}
