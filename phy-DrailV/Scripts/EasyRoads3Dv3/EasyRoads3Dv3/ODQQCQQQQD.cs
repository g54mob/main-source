using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ODQQCQQQQD : MonoBehaviour
	{
		public static void OQDCOOOOCO(ERCrossings scr, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<Material> materialList)
		{
			List<int> normalInts = new List<int>();
			List<int> normalIntsStart = new List<int>();
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag)
			{
				ODQCCCOCDD(scr, scr.leftSidewalkStartV3, scr.leftSidewalkStartUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkStartTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[0], scr.leftStartSidewalkCornerInt, ref normalInts, ref normalIntsStart);
				OQDDODCOQQ.OOCQCQDQDO(scr, 0, scr.leftSidewalkStartV3, 0);
				scr.OQOCCQDCCOStart.AddRange(normalIntsStart);
				scr.OQOCCQDCCO.AddRange(normalInts);
				if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
				{
					ODQCCCOCDD(scr, scr.rightSidewalkLeftV3, scr.rightSidewalkLeftUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkLeftTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[0], scr.rightLeftSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OQDDODCOQQ.OOCQCQDQDO(scr, 2, scr.rightSidewalkLeftV3, 0);
					scr.OOOCCCCODQStart.AddRange(normalIntsStart);
					scr.OOOCCCCODQ.AddRange(normalInts);
				}
				else if (scr.tCrossing)
				{
					ODQCCCOCDD(scr, scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkEndTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[0], scr.rightEndSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OQDDODCOQQ.OOCQCQDQDO(scr, 1, scr.rightSidewalkEndV3, 1);
					scr.OOOCCCCODQStart.AddRange(normalIntsStart);
					scr.OOOCCCCODQ.AddRange(normalInts);
				}
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag)
			{
				ODQCCCOCDD(scr, scr.rightSidewalkStartV3, scr.rightSidewalkStartUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkStartTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[1], scr.rightStartSidewalkCornerInt, ref normalInts, ref normalIntsStart);
				OQDDODCOQQ.OOCQCQDQDO(scr, 0, scr.rightSidewalkStartV3, 1);
				scr.ODCDCOODCQStart.AddRange(normalIntsStart);
				scr.ODCDCOODCQ.AddRange(normalInts);
				if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
				{
					ODQCCCOCDD(scr, scr.leftSidewalkRightV3, scr.leftSidewalkRightUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkRightTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[1], scr.leftRightSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OQDDODCOQQ.OOCQCQDQDO(scr, 3, scr.leftSidewalkRightV3, 0);
					scr.OCDDDQCCOOStart.AddRange(normalIntsStart);
					scr.OCDDDQCCOO.AddRange(normalInts);
				}
				else if (scr.tCrossing)
				{
					ODQCCCOCDD(scr, scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkEndTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[1], scr.leftEndSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OQDDODCOQQ.OOCQCQDQDO(scr, 1, scr.leftSidewalkEndV3, 0);
					scr.OCDDDQCCOOStart.AddRange(normalIntsStart);
					scr.OCDDDQCCOO.AddRange(normalInts);
				}
			}
			if ((!scr.tCrossing || scr.tCrossingLeftRight == 1) && scr.prefabScript.sidewalkControlElements[3].renderFlag)
			{
				ODQCCCOCDD(scr, scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkEndTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[3], scr.leftEndSidewalkCornerInt, ref normalInts, ref normalIntsStart);
				OQDDODCOQQ.OOCQCQDQDO(scr, 1, scr.leftSidewalkEndV3, 0);
				scr.OCCDCQDDDDStart.AddRange(normalIntsStart);
				scr.OCCDCQDDDD.AddRange(normalInts);
				if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
				{
					ODQCCCOCDD(scr, scr.rightSidewalkRightV3, scr.rightSidewalkRightUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkRightTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[3], scr.rightRightSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OQDDODCOQQ.OOCQCQDQDO(scr, 3, scr.rightSidewalkRightV3, 1);
					scr.ODQQCQDOQCStart.AddRange(normalIntsStart);
					scr.ODQQCQDOQC.AddRange(normalInts);
				}
			}
			if ((!scr.tCrossing || scr.tCrossingLeftRight == 0) && scr.prefabScript.sidewalkControlElements[2].renderFlag)
			{
				ODQCCCOCDD(scr, scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkEndTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[2], scr.rightEndSidewalkCornerInt, ref normalInts, ref normalIntsStart);
				OQDDODCOQQ.OOCQCQDQDO(scr, 1, scr.rightSidewalkEndV3, 1);
				scr.OCDCDQQCDDStart.AddRange(normalIntsStart);
				scr.OCDCDQQCDD.AddRange(normalInts);
				if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
				{
					ODQCCCOCDD(scr, scr.leftSidewalkLeftV3, scr.leftSidewalkLeftUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkLeftTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[2], scr.leftLeftSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OQDDODCOQQ.OOCQCQDQDO(scr, 2, scr.leftSidewalkLeftV3, 0);
					scr.OQCQCCCQQCStart.AddRange(normalIntsStart);
					scr.OQCQCCCQQC.AddRange(normalInts);
				}
			}
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag && !scr.prefabScript.crossingElements[0].includeLeftSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[0], scr.leftSidewalkStartV3, scr.leftSidewalkStartUV, scr.leftSidewalkStartTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag && !scr.prefabScript.crossingElements[0].includeRightSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[1], scr.rightSidewalkStartV3, scr.rightSidewalkStartUV, scr.rightSidewalkStartTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				if (scr.prefabScript.sidewalkControlElements[2].renderFlag && !scr.prefabScript.crossingElements[1].includeRightSidewalk)
				{
					OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[2], scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, scr.rightSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
				}
			}
			else if (scr.prefabScript.sidewalkControlElements[1].renderFlag && !scr.prefabScript.crossingElements[1].includeRightSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[1], scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, scr.rightSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				if (scr.prefabScript.sidewalkControlElements[3].renderFlag && !scr.prefabScript.crossingElements[1].includeLeftSidewalk)
				{
					OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[3], scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, scr.leftSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
				}
			}
			else if (scr.prefabScript.sidewalkControlElements[0].renderFlag && !scr.prefabScript.crossingElements[1].includeLeftSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[3], scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, scr.leftSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (scr.prefabScript.sidewalkControlElements[2].renderFlag && (!scr.tCrossing || scr.tCrossingLeftRight == 0) && !scr.prefabScript.crossingElements[2].includeLeftSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[2], scr.leftSidewalkLeftV3, scr.leftSidewalkLeftUV, scr.leftSidewalkLeftTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag && (!scr.tCrossing || scr.tCrossingLeftRight == 0) && !scr.prefabScript.crossingElements[2].includeRightSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[0], scr.rightSidewalkLeftV3, scr.rightSidewalkLeftUV, scr.rightSidewalkLeftTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag && (!scr.tCrossing || scr.tCrossingLeftRight == 1) && !scr.prefabScript.crossingElements[3].includeLeftSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[1], scr.leftSidewalkRightV3, scr.leftSidewalkRightUV, scr.leftSidewalkRightTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (scr.prefabScript.sidewalkControlElements[3].renderFlag && (!scr.tCrossing || scr.tCrossingLeftRight == 1) && !scr.prefabScript.crossingElements[3].includeRightSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[3], scr.rightSidewalkRightV3, scr.rightSidewalkRightUV, scr.rightSidewalkRightTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
		}

		public static void OQOQOCQOCD(ERRoundabouts scr, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<Material> materialList)
		{
			for (int i = 0; i < scr.connections.Count; i++)
			{
				int num = i;
				num = ((scr.connections.Count > i + 1) ? (num + 1) : 0);
				if (scr.prefabScript.sidewalkControlElements[num].renderFlag)
				{
					ODQQCDCODQ(scr, scr.connections[i].leftSidewalkV3, scr.connections[i].leftSidewalkUV, 0, 0, ref meshVecs, ref scr.connections[i].leftSidewalkNormalsStart, ref scr.connections[i].leftSidewalkNormalsEnd, ref meshUVs, ref triList, ref scr.connections[i].leftSidewalkTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[num], -1);
					if (!scr.prefabScript.crossingElements[i].includeLeftSidewalk)
					{
						OQCODQCOOO(null, scr.prefabScript.sidewalkControlElements[num], scr.connections[i].leftSidewalkV3, scr.connections[i].leftSidewalkUV, scr.connections[i].leftSidewalkTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
					}
				}
				num = i;
				if (scr.prefabScript.sidewalkControlElements[i].renderFlag)
				{
					ODQQCDCODQ(scr, scr.connections[i].rightSidewalkV3, scr.connections[i].rightSidewalkUV, 0, 0, ref meshVecs, ref scr.connections[i].rightSidewalkNormalsStart, ref scr.connections[i].rightSidewalkNormalsEnd, ref meshUVs, ref triList, ref scr.connections[i].rightSidewalkTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[num], -1);
					if (!scr.prefabScript.crossingElements[i].includeRightSidewalk)
					{
						OQCODQCOOO(null, scr.prefabScript.sidewalkControlElements[i], scr.connections[i].rightSidewalkV3, scr.connections[i].rightSidewalkUV, scr.connections[i].rightSidewalkTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
					}
				}
			}
		}

		public static void ODOCQDDQDQ(ERRoundabouts scr, List<Vector3> vecs, List<Vector2> uvs, List<int> tris, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<Material> materialList)
		{
			int index = 0;
			for (int i = 0; i < materialList.Count; i++)
			{
				if (materialList[i] == scr.innerRoundaboutSidewalkMaterial)
				{
					index = i;
				}
			}
			int count = meshVecs.Count;
			for (int i = 0; i < vecs.Count; i++)
			{
				meshVecs.Add(vecs[i]);
				meshUVs.Add(uvs[i]);
				if (i < scr.innerSidewalkSegments)
				{
					scr.innerRoundaboutSidewalkIntsStart.Add(meshVecs.Count - 1);
				}
			}
			for (int i = 0; i < scr.innerSidewalkSegments; i++)
			{
				scr.innerRoundaboutSidewalkIntsEnd.Add(meshVecs.Count - scr.innerSidewalkSegments + i);
			}
			List<int> list = new List<int>();
			for (int i = 0; i < tris.Count; i++)
			{
				list.Add(count + tris[i]);
				if (tris[i] > vecs.Count - 1)
				{
					Debug.Log(tris[i] + " > " + (vecs.Count - 1));
				}
			}
			triList[index].AddRange(list);
		}

		public static void ODQCCCOCDD(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector2>> uvArray, int frontLeft, int topBottom, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<List<int>> intArray, ref List<Material> materialList, bool reverse, QDOQDSQOOQDDD corner, int outerCornerInt, ref List<int> normalInts, ref List<int> normalIntsStart)
		{
			normalInts.Clear();
			normalIntsStart.Clear();
			int triArrayElement = 0;
			ODCQDQOCDD(ref materialList, ref triList, corner.sidewalkMaterial, ref triArrayElement);
			int num = meshVecs.Count;
			for (int i = 0; i < vecArray.Count; i++)
			{
				intArray.Add(new List<int>());
				for (int j = 0; j < vecArray[i].Count; j++)
				{
					meshVecs.Add(vecArray[i][j]);
					meshUVs.Add(uvArray[i][j]);
					if (j == 0)
					{
						normalIntsStart.Add(num);
					}
					if (j == vecArray[i].Count - 1)
					{
						normalInts.Add(num);
					}
					intArray[i].Add(num);
					num++;
				}
			}
			for (int i = 0; i < intArray.Count - 1; i++)
			{
				if (!reverse)
				{
					triList[triArrayElement].AddRange(OQDCDQQDQO(intArray[i], intArray[i + 1]));
				}
				else
				{
					triList[triArrayElement].AddRange(OQDCDQQDQO(intArray[i + 1], intArray[i]));
				}
			}
			if (corner.beveledCurb)
			{
				if (corner.beveledHeight == 0f && corner.beveledDepth == 0f)
				{
					triList[triArrayElement].AddRange(OQDQCDQDOD(intArray[2][outerCornerInt - 1], intArray[1], outerCornerInt - 1, !reverse));
				}
				else if (corner.beveledHeight == 0f || corner.beveledDepth == 0f)
				{
					triList[triArrayElement].AddRange(OQDQCDQDOD(intArray[3][outerCornerInt - 1], intArray[2], outerCornerInt - 1, !reverse));
				}
				else
				{
					triList[triArrayElement].AddRange(OQDQCDQDOD(intArray[4][outerCornerInt - 1], intArray[3], outerCornerInt - 1, !reverse));
				}
			}
			else
			{
				triList[triArrayElement].AddRange(OQDQCDQDOD(intArray[3][outerCornerInt - 1], intArray[2], outerCornerInt - 1, !reverse));
			}
		}

		public static void ODQQCDCODQ(ERRoundabouts scr, List<List<Vector3>> vecArray, List<List<Vector2>> uvArray, int frontLeft, int topBottom, ref List<Vector3> meshVecs, ref List<int> startNormalInts, ref List<int> endNormalInts, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<List<int>> intArray, ref List<Material> materialList, bool reverse, QDOQDSQOOQDDD corner, int outerCornerInt)
		{
			int triArrayElement = 0;
			ODCQDQOCDD(ref materialList, ref triList, corner.sidewalkMaterial, ref triArrayElement);
			startNormalInts.Clear();
			endNormalInts.Clear();
			int num = meshVecs.Count;
			for (int i = 0; i < vecArray.Count; i++)
			{
				intArray.Add(new List<int>());
				for (int j = 0; j < vecArray[i].Count; j++)
				{
					meshVecs.Add(vecArray[i][j]);
					meshUVs.Add(uvArray[i][j]);
					if (j == 0)
					{
						startNormalInts.Add(num);
					}
					if (j == vecArray[i].Count - 1)
					{
						endNormalInts.Add(num);
					}
					intArray[i].Add(num);
					num++;
				}
			}
			for (int i = 0; i < intArray.Count - 1; i++)
			{
				if (!reverse)
				{
					triList[triArrayElement].AddRange(OQDCDQQDQO(intArray[i], intArray[i + 1]));
				}
				else
				{
					triList[triArrayElement].AddRange(OQDCDQQDQO(intArray[i + 1], intArray[i]));
				}
			}
		}

		public static List<int> OQDCDQQDQO(List<int> col1, List<int> col2)
		{
			List<int> list = new List<int>();
			int count = col1.Count;
			if (col2.Count < col1.Count)
			{
				count = col2.Count;
			}
			for (int i = 0; i < count - 1; i++)
			{
				list.Add(col1[i]);
				list.Add(col2[i + 1]);
				list.Add(col2[i]);
				list.Add(col1[i + 1]);
				list.Add(col2[i + 1]);
				list.Add(col1[i]);
			}
			return list;
		}

		public static List<int> OQDQCDQDOD(int outerPoint, List<int> innerCol, int startPoint, bool reverse)
		{
			List<int> list = new List<int>();
			for (int i = startPoint; i < innerCol.Count - 1; i++)
			{
				if (!reverse)
				{
					list.Add(outerPoint);
					list.Add(innerCol[i + 1]);
					list.Add(innerCol[i]);
				}
				else
				{
					list.Add(outerPoint);
					list.Add(innerCol[i]);
					list.Add(innerCol[i + 1]);
				}
			}
			return list;
		}

		public static void OQCODQCOOO(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, List<Material> materialList, int leftrightroad)
		{
			int triArrayElement = 0;
			ODCQDQOCDD(ref materialList, ref triList, corner.sidewalkMaterial, ref triArrayElement);
			if (corner.outerCurb)
			{
				if (!corner.beveledCurb)
				{
					OQDOOCODQQ.OCDOOODQCD(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
				else if (corner.beveledHeight > 0f && corner.beveledDepth > 0f)
				{
					OQDOOCODQQ.OCOCQDCQDQ(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
				else if (corner.beveledHeight > 0f)
				{
					OQDOOCODQQ.OOQDOCDQOD(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
				else if (corner.beveledDepth > 0f)
				{
					OQDOOCODQQ.OQOCOODDQC(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
				else
				{
					OQDOOCODQQ.ODDDCDOOCO(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
				}
			}
			else if (!corner.beveledCurb)
			{
				OQDOOCODQQ.OOQCOOOCQO(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
			else if (corner.beveledHeight > 0f && corner.beveledDepth > 0f)
			{
				OQDOOCODQQ.OQQOCDDDDO(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
			else if (corner.beveledHeight > 0f)
			{
				OQDOOCODQQ.OCQOCOQDOQ(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
			else if (corner.beveledDepth > 0f)
			{
				OQDOOCODQQ.OCQDCDOQCC(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
			else
			{
				OQDOOCODQQ.OODCQOCCCC(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad);
			}
		}

		public static void OQOOCOCDDD()
		{
		}

		public static void ODCQDQOCDD(ref List<Material> materialList, ref List<List<int>> triList, Material sidewalkMaterial, ref int triArrayElement)
		{
			for (int i = 0; i < materialList.Count; i++)
			{
				if (materialList[i] == sidewalkMaterial)
				{
					triArrayElement = i;
					return;
				}
			}
			materialList.Add(sidewalkMaterial);
			triList.Add(new List<int>());
			triArrayElement = materialList.Count - 1;
		}
	}
}
