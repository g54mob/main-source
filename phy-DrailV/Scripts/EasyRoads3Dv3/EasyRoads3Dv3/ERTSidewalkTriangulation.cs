using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERTSidewalkTriangulation : MonoBehaviour
	{
		public static void OQDCOOOOCO(ERCrossings scr, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<Material> materialList)
		{
			ODQCCCOCDD(scr, scr.leftSidewalkStartV3, scr.leftSidewalkStartUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkStartTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[0], scr.leftStartSidewalkCornerInt);
			ODQCCCOCDD(scr, scr.rightSidewalkLeftV3, scr.rightSidewalkLeftUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkLeftTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[0], scr.rightLeftSidewalkCornerInt);
			ODQCCCOCDD(scr, scr.rightSidewalkStartV3, scr.rightSidewalkStartUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkStartTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[1], scr.rightStartSidewalkCornerInt);
			ODQCCCOCDD(scr, scr.leftSidewalkRightV3, scr.leftSidewalkRightUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkRightTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[1], scr.leftRightSidewalkCornerInt);
			ODQCCCOCDD(scr, scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkEndTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[3], scr.leftEndSidewalkCornerInt);
			ODQCCCOCDD(scr, scr.rightSidewalkRightV3, scr.rightSidewalkRightUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkRightTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[3], scr.rightRightSidewalkCornerInt);
			ODQCCCOCDD(scr, scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkEndTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[2], scr.rightEndSidewalkCornerInt);
			ODQCCCOCDD(scr, scr.leftSidewalkLeftV3, scr.leftSidewalkLeftUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkLeftTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[2], scr.leftLeftSidewalkCornerInt);
			if (!scr.prefabScript.crossingElements[0].includeLeftSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[0], scr.leftSidewalkStartV3, scr.leftSidewalkStartUV, scr.leftSidewalkStartTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (!scr.prefabScript.crossingElements[0].includeRightSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[1], scr.rightSidewalkStartV3, scr.rightSidewalkStartUV, scr.rightSidewalkStartTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.prefabScript.crossingElements[1].includeRightSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[2], scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, scr.rightSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.prefabScript.crossingElements[1].includeLeftSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[3], scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, scr.leftSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (!scr.prefabScript.crossingElements[2].includeLeftSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[2], scr.leftSidewalkLeftV3, scr.leftSidewalkLeftUV, scr.leftSidewalkLeftTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (!scr.prefabScript.crossingElements[2].includeRightSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[0], scr.rightSidewalkLeftV3, scr.rightSidewalkLeftUV, scr.rightSidewalkLeftTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.prefabScript.crossingElements[3].includeLeftSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[1], scr.leftSidewalkRightV3, scr.leftSidewalkRightUV, scr.leftSidewalkRightTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (!scr.prefabScript.crossingElements[3].includeRightSidewalk)
			{
				OQCODQCOOO(scr, scr.prefabScript.sidewalkControlElements[3], scr.rightSidewalkRightV3, scr.rightSidewalkRightUV, scr.rightSidewalkRightTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
		}

		public static void ODQCCCOCDD(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector2>> uvArray, int frontLeft, int topBottom, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<List<int>> intArray, ref List<Material> materialList, bool reverse, QDOQDSQOOQDDD corner, int outerCornerInt)
		{
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
