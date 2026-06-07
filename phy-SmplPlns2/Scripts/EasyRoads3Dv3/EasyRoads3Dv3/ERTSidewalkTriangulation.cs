using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERTSidewalkTriangulation : MonoBehaviour
	{
		public static void ODQDOCOCQD(ERCrossings scr, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<Material> materialList)
		{
			OOQODOCOCD(scr, scr.leftSidewalkStartV3, scr.leftSidewalkStartUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkStartTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[0], scr.leftStartSidewalkCornerInt);
			OOQODOCOCD(scr, scr.rightSidewalkLeftV3, scr.rightSidewalkLeftUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkLeftTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[0], scr.rightLeftSidewalkCornerInt);
			OOQODOCOCD(scr, scr.rightSidewalkStartV3, scr.rightSidewalkStartUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkStartTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[1], scr.rightStartSidewalkCornerInt);
			OOQODOCOCD(scr, scr.leftSidewalkRightV3, scr.leftSidewalkRightUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkRightTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[1], scr.leftRightSidewalkCornerInt);
			OOQODOCOCD(scr, scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkEndTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[3], scr.leftEndSidewalkCornerInt);
			OOQODOCOCD(scr, scr.rightSidewalkRightV3, scr.rightSidewalkRightUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkRightTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[3], scr.rightRightSidewalkCornerInt);
			OOQODOCOCD(scr, scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkEndTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[2], scr.rightEndSidewalkCornerInt);
			OOQODOCOCD(scr, scr.leftSidewalkLeftV3, scr.leftSidewalkLeftUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkLeftTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[2], scr.leftLeftSidewalkCornerInt);
			if (!scr.prefabScript.crossingElements[0].includeLeftSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[0], scr.leftSidewalkStartV3, scr.leftSidewalkStartUV, scr.leftSidewalkStartTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (!scr.prefabScript.crossingElements[0].includeRightSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[1], scr.rightSidewalkStartV3, scr.rightSidewalkStartUV, scr.rightSidewalkStartTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.prefabScript.crossingElements[1].includeRightSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[2], scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, scr.rightSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.prefabScript.crossingElements[1].includeLeftSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[3], scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, scr.leftSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (!scr.prefabScript.crossingElements[2].includeLeftSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[2], scr.leftSidewalkLeftV3, scr.leftSidewalkLeftUV, scr.leftSidewalkLeftTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (!scr.prefabScript.crossingElements[2].includeRightSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[0], scr.rightSidewalkLeftV3, scr.rightSidewalkLeftUV, scr.rightSidewalkLeftTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.prefabScript.crossingElements[3].includeLeftSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[1], scr.leftSidewalkRightV3, scr.leftSidewalkRightUV, scr.leftSidewalkRightTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (!scr.prefabScript.crossingElements[3].includeRightSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[3], scr.rightSidewalkRightV3, scr.rightSidewalkRightUV, scr.rightSidewalkRightTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
		}

		public static void OOQODOCOCD(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector2>> uvArray, int frontLeft, int topBottom, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<List<int>> intArray, ref List<Material> materialList, bool reverse, QDOQDSQOOQDDD corner, int outerCornerInt)
		{
			int triArrayElement = 0;
			OOQDDDDCOC(ref materialList, ref triList, corner.sidewalkMaterial, ref triArrayElement);
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
			for (int k = 0; k < intArray.Count - 1; k++)
			{
				if (!reverse)
				{
					triList[triArrayElement].AddRange(OODQCOCCQQ(intArray[k], intArray[k + 1]));
				}
				else
				{
					triList[triArrayElement].AddRange(OODQCOCCQQ(intArray[k + 1], intArray[k]));
				}
			}
			if (corner.beveledCurb)
			{
				if (corner.beveledHeight == 0f && corner.beveledDepth == 0f)
				{
					triList[triArrayElement].AddRange(OCOCDQOCCC(intArray[2][outerCornerInt - 1], intArray[1], outerCornerInt - 1, !reverse));
				}
				else if (corner.beveledHeight == 0f || corner.beveledDepth == 0f)
				{
					triList[triArrayElement].AddRange(OCOCDQOCCC(intArray[3][outerCornerInt - 1], intArray[2], outerCornerInt - 1, !reverse));
				}
				else
				{
					triList[triArrayElement].AddRange(OCOCDQOCCC(intArray[4][outerCornerInt - 1], intArray[3], outerCornerInt - 1, !reverse));
				}
			}
			else
			{
				triList[triArrayElement].AddRange(OCOCDQOCCC(intArray[3][outerCornerInt - 1], intArray[2], outerCornerInt - 1, !reverse));
			}
		}

		public static List<int> OODQCOCCQQ(List<int> col1, List<int> col2)
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

		public static List<int> OCOCDQOCCC(int outerPoint, List<int> innerCol, int startPoint, bool reverse)
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

		public static void OCQQCDDDQO(ERCrossings scr, QDOQDSQOOQDDD corner, List<List<Vector3>> sourceVecs, List<List<Vector2>> sourceUVs, List<List<int>> sourceTris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> triList, List<Material> materialList, int leftrightroad)
		{
			int triArrayElement = 0;
			OOQDDDDCOC(ref materialList, ref triList, corner.sidewalkMaterial, ref triArrayElement);
			if (corner.outerCurb)
			{
				if (!corner.beveledCurb)
				{
					OOODQCODCC.OODOODDDOD(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, 0, hardEdge: false);
				}
				else if (corner.beveledHeight > 0f && corner.beveledDepth > 0f)
				{
					OOODQCODCC.OCQDQODOQQ(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, hardEdge: false);
				}
				else if (corner.beveledHeight > 0f)
				{
					OOODQCODCC.OQDDDCDCDO(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, hardEdge: false);
				}
				else if (corner.beveledDepth > 0f)
				{
					OOODQCODCC.OQCDCQQOQO(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, hardEdge: false);
				}
				else
				{
					OOODQCODCC.OCODODDDOC(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, hardEdge: false);
				}
			}
			else if (!corner.beveledCurb)
			{
				OOODQCODCC.OQQQDCQCOC(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, 0, hardEdge: false);
			}
			else if (corner.beveledHeight > 0f && corner.beveledDepth > 0f)
			{
				OOODQCODCC.OCQCDODQDC(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, hardEdge: false);
			}
			else if (corner.beveledHeight > 0f)
			{
				OOODQCODCC.OCCQCCQDOO(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, hardEdge: false);
			}
			else if (corner.beveledDepth > 0f)
			{
				OOODQCODCC.OCDOQCOQDQ(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, hardEdge: false);
			}
			else
			{
				OOODQCODCC.OOCDDDQQDD(scr, corner, sourceVecs, sourceUVs, sourceTris, ref vecs, ref uvs, ref triList, triArrayElement, leftrightroad, hardEdge: false);
			}
		}

		public static void OQQCDQDDOQ()
		{
		}

		public static void OOQDDDDCOC(ref List<Material> materialList, ref List<List<int>> triList, Material sidewalkMaterial, ref int triArrayElement)
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
