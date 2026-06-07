using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OOCOCCQDOD : MonoBehaviour
	{
		public static void ODQDOCOCQD(ERCrossings scr, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, List<Material> materialList, List<Material> connectionMaterialList)
		{
			int centerPointIndex = 0;
			int centerPointIndex2 = 0;
			int centerPointIndex3 = 0;
			int centerPointIndex4 = 0;
			meshVecs.Add(Vector3.zero);
			meshUVs.Add(new Vector2(0.5f, GetCenterUVY(scr, scr.frontRoadUVTiling, scr.startConnectionV3, 0)));
			if (scr.frontRoadUVTiling == scr.backRoadUVTiling && scr.frontRoadUVTiling != scr.leftRoadUVTiling)
			{
				centerPointIndex3 = (centerPointIndex4 = 1);
				meshVecs.Add(Vector3.zero);
				meshUVs.Add(new Vector2(0.5f, GetCenterUVY(scr, scr.leftRoadUVTiling, scr.leftConnectionV3, 2)));
				if (scr.leftRoadUVTiling != scr.rightRoadUVTiling)
				{
					centerPointIndex4 = 2;
					meshVecs.Add(Vector3.zero);
					meshUVs.Add(new Vector2(0.5f, GetCenterUVY(scr, scr.rightRoadUVTiling, scr.rightConnectionV3, 3)));
				}
			}
			else if (scr.frontRoadUVTiling != scr.backRoadUVTiling)
			{
				centerPointIndex2 = (centerPointIndex3 = (centerPointIndex4 = 1));
				meshVecs.Add(Vector3.zero);
				meshUVs.Add(new Vector2(0.5f, GetCenterUVY(scr, scr.backRoadUVTiling, scr.endConnectionV3, 1)));
				if (scr.leftRoadUVTiling != scr.backRoadUVTiling)
				{
					centerPointIndex3 = (centerPointIndex4 = 2);
					meshVecs.Add(Vector3.zero);
					meshUVs.Add(new Vector2(0.5f, GetCenterUVY(scr, scr.leftRoadUVTiling, scr.leftConnectionV3, 2)));
					if (scr.leftRoadUVTiling != scr.rightRoadUVTiling)
					{
						centerPointIndex4 = 3;
						meshVecs.Add(Vector3.zero);
						meshUVs.Add(new Vector2(0.5f, GetCenterUVY(scr, scr.rightRoadUVTiling, scr.rightConnectionV3, 3)));
					}
				}
			}
			OCDDCCCCOC(scr, scr.startConnectionV3, scr.startConnectionUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.startConnectionTris, 1, OQQOCDQCQD.OCQQDQCDOD(materialList, connectionMaterialList[0]), centerPointIndex);
			OCDDCCCCOC(scr, scr.endConnectionV3, scr.endConnectionUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.endConnectionTris, 1, OQQOCDQCQD.OCQQDQCDOD(materialList, connectionMaterialList[1]), centerPointIndex2);
			OCDDCCCCOC(scr, scr.leftConnectionV3, scr.leftConnectionUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftConnectionTris, 1, OQQOCDQCQD.OCQQDQCDOD(materialList, connectionMaterialList[2]), centerPointIndex3);
			OCDDCCCCOC(scr, scr.rightConnectionV3, scr.rightConnectionUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightConnectionTris, 1, OQQOCDQCQD.OCQQDQCDOD(materialList, connectionMaterialList[3]), centerPointIndex4);
		}

		public static float GetCenterUVY(ERCrossings scr, float uvTiling, List<List<Vector3>> vecArray, int connection)
		{
			return 0f;
		}

		public static void OCDDCCCCOC(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector2>> uvArray, int frontLeft, int topBottom, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<List<int>> intArray, int startRow, int triArrayIndex, int centerPointIndex)
		{
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
			if (startRow == 1)
			{
				triList[triArrayIndex].AddRange(OODQCCODOO(intArray));
			}
			triList[triArrayIndex].AddRange(OODQCOCCQQ(intArray[0], intArray[1], startRow));
			triList[triArrayIndex].AddRange(OODQCOCCQQ(intArray[3], intArray[4], startRow));
			if (intArray[1].Count == intArray[2].Count)
			{
				triList[triArrayIndex].AddRange(OODQCOCCQQ(intArray[1], intArray[2], startRow));
			}
			else
			{
				triList[triArrayIndex].AddRange(OOCDCOOCDD(intArray[1], intArray[2], vecArray[1], vecArray[2], frontLeft, topBottom, startRow));
			}
			if (intArray[2].Count == intArray[3].Count)
			{
				triList[triArrayIndex].AddRange(OODQCOCCQQ(intArray[2], intArray[3], startRow));
			}
			else
			{
				triList[triArrayIndex].AddRange(OOCDCOOCDD(intArray[2], intArray[3], vecArray[2], vecArray[3], frontLeft, topBottom, startRow));
			}
			triList[triArrayIndex].Add(intArray[1][intArray[1].Count - 1]);
			triList[triArrayIndex].Add(centerPointIndex);
			triList[triArrayIndex].Add(intArray[2][intArray[2].Count - 1]);
			triList[triArrayIndex].Add(intArray[2][intArray[2].Count - 1]);
			triList[triArrayIndex].Add(centerPointIndex);
			triList[triArrayIndex].Add(intArray[3][intArray[3].Count - 1]);
		}

		public static List<int> OODQCCODOO(List<List<int>> intArray)
		{
			List<int> list = new List<int>();
			list.Add(intArray[0][0]);
			list.Add(intArray[0][1]);
			list.Add(intArray[1][1]);
			list.Add(intArray[0][0]);
			list.Add(intArray[1][1]);
			list.Add(intArray[2][1]);
			list.Add(intArray[0][0]);
			list.Add(intArray[2][1]);
			list.Add(intArray[4][0]);
			list.Add(intArray[4][0]);
			list.Add(intArray[2][1]);
			list.Add(intArray[3][1]);
			list.Add(intArray[4][0]);
			list.Add(intArray[3][1]);
			list.Add(intArray[4][1]);
			return list;
		}

		public static List<int> OODQCOCCQQ(List<int> col1, List<int> col2, int startRow)
		{
			List<int> list = new List<int>();
			for (int i = startRow; i < col1.Count - 1; i++)
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

		public static List<int> OOCDCOOCDD(List<int> col1, List<int> col2, List<Vector3> vecs1, List<Vector3> vecs2, int frontLeft, int topBottom, int startRow)
		{
			List<int> list = new List<int>();
			int num = startRow;
			int num2 = startRow;
			int num3 = 0;
			bool flag = false;
			bool flag2 = false;
			int num4 = 0;
			while ((!flag || !flag2) && num3 < 100)
			{
				if (num < col1.Count - 1 && num2 < col2.Count - 1)
				{
					float num5 = Vector3.Distance(vecs1[num], vecs2[num2 + 1]);
					float num6 = Vector3.Distance(vecs1[num + 1], vecs2[num2]);
					num4 = ((num5 < num6) ? 1 : 0);
				}
				else if (num >= col1.Count - 1)
				{
					num4 = 1;
				}
				else if (num2 >= col2.Count - 1)
				{
					num4 = 0;
				}
				if (num4 == 0)
				{
					list.Add(col1[num]);
					list.Add(col1[num + 1]);
					list.Add(col2[num2]);
					num++;
				}
				else
				{
					list.Add(col1[num]);
					list.Add(col2[num2 + 1]);
					list.Add(col2[num2]);
					num2++;
				}
				if (num >= col1.Count - 1)
				{
					flag = true;
				}
				if (num2 >= col2.Count - 1)
				{
					flag2 = true;
				}
				num3++;
			}
			return list;
		}

		public static void InitOQQDOOOCOQ(ERCrossings scr)
		{
			OQQDOOOCOQ(scr, scr.startConnectionV3, ref scr.startConnectionUV, ref scr.uvArrayFront, 0, scr.frontRoadUVTiling);
			OQQDOOOCOQ(scr, scr.endConnectionV3, ref scr.endConnectionUV, ref scr.uvArrayBack, 0, scr.backRoadUVTiling);
			OQQDOOOCOQ(scr, scr.leftConnectionV3, ref scr.leftConnectionUV, ref scr.uvArrayLeft, 1, scr.leftRoadUVTiling);
			OQQDOOOCOQ(scr, scr.rightConnectionV3, ref scr.rightConnectionUV, ref scr.uvArrayRight, 1, scr.rightRoadUVTiling);
		}

		public static void OQQDOOOCOQ(ERCrossings scr, List<List<Vector3>> vecArray, ref List<List<Vector2>> uvs, ref List<float> uvArray, int verthorz, float uvTiling)
		{
			ERSideWalkVecs.OQDQCOOQCO(vecArray, ref uvArray);
			Vector3 vA = new Vector3(50f, 0f, 0f);
			Vector3 vB = new Vector3(-50f, 0f, 0f);
			float num = Mathf.Abs(vecArray[0][0].z);
			if (verthorz == 1)
			{
				vA = new Vector3(0f, 0f, 50f);
				vB = new Vector3(0f, 0f, -50f);
				num = Mathf.Abs(vecArray[0][0].x);
			}
			float num2 = 5f * uvTiling;
			float num3 = 0f;
			for (int i = 0; i < vecArray.Count; i++)
			{
				uvs.Add(new List<Vector2>());
				for (int j = 0; j < vecArray[i].Count; j++)
				{
					Vector3 a = OQOQOOCDCC.OCOOQOQCDC(vA, vB, vecArray[i][j]);
					num3 = Vector3.Distance(a, vecArray[i][j]);
					float num4 = num3 / num;
					uvs[i].Add(new Vector2(uvArray[i], num3 / num2));
				}
			}
		}

		public static Vector3[] OCDCDOQCOC(ERCrossings scr, Vector3[] vecs)
		{
			if (!scr.tCrossing)
			{
				vecs[scr.frontLeftRoadInts[0]] = (vecs[scr.leftRightRoadInts[0]] = (vecs[scr.frontLeftRoadInts[0]] + vecs[scr.leftRightRoadInts[0]]) * 0.5f);
				vecs[scr.frontLeftRoadInts[1]] = (vecs[scr.leftRightRoadInts[1]] = (vecs[scr.frontLeftRoadInts[1]] + vecs[scr.leftRightRoadInts[1]]) * 0.5f);
				vecs[scr.frontRightRoadInts[0]] = (vecs[scr.rightLeftRoadInts[0]] = (vecs[scr.frontRightRoadInts[0]] + vecs[scr.rightLeftRoadInts[0]]) * 0.5f);
				vecs[scr.frontRightRoadInts[1]] = (vecs[scr.rightLeftRoadInts[1]] = (vecs[scr.frontRightRoadInts[1]] + vecs[scr.rightLeftRoadInts[1]]) * 0.5f);
				vecs[scr.rightRightRoadInts[0]] = (vecs[scr.backLeftRoadInts[0]] = (vecs[scr.rightRightRoadInts[0]] + vecs[scr.backLeftRoadInts[0]]) * 0.5f);
				vecs[scr.rightRightRoadInts[1]] = (vecs[scr.backLeftRoadInts[1]] = (vecs[scr.rightRightRoadInts[1]] + vecs[scr.backLeftRoadInts[1]]) * 0.5f);
				vecs[scr.leftLeftRoadInts[0]] = (vecs[scr.backRightRoadInts[0]] = (vecs[scr.leftLeftRoadInts[0]] + vecs[scr.backRightRoadInts[0]]) * 0.5f);
				vecs[scr.leftLeftRoadInts[1]] = (vecs[scr.backRightRoadInts[1]] = (vecs[scr.leftLeftRoadInts[1]] + vecs[scr.backRightRoadInts[1]]) * 0.5f);
			}
			else if (scr.tCrossingLeftRight == 0)
			{
				vecs[scr.frontLeftRoadInts[0]] = (vecs[scr.leftRightRoadInts[0]] = (vecs[scr.frontLeftRoadInts[0]] + vecs[scr.leftRightRoadInts[0]]) * 0.5f);
				vecs[scr.frontLeftRoadInts[1]] = (vecs[scr.leftRightRoadInts[1]] = (vecs[scr.frontLeftRoadInts[1]] + vecs[scr.leftRightRoadInts[1]]) * 0.5f);
				vecs[scr.frontRightRoadInts[0]] = (vecs[scr.backLeftRoadInts[0]] = (vecs[scr.frontRightRoadInts[0]] + vecs[scr.backLeftRoadInts[0]]) * 0.5f);
				vecs[scr.frontRightRoadInts[1]] = (vecs[scr.backLeftRoadInts[1]] = (vecs[scr.frontRightRoadInts[1]] + vecs[scr.backLeftRoadInts[1]]) * 0.5f);
				vecs[scr.leftLeftRoadInts[0]] = (vecs[scr.backRightRoadInts[0]] = (vecs[scr.leftLeftRoadInts[0]] + vecs[scr.backRightRoadInts[0]]) * 0.5f);
				vecs[scr.leftLeftRoadInts[1]] = (vecs[scr.backRightRoadInts[1]] = (vecs[scr.leftLeftRoadInts[1]] + vecs[scr.backRightRoadInts[1]]) * 0.5f);
			}
			else if (scr.tCrossingLeftRight == 1)
			{
				vecs[scr.frontLeftRoadInts[0]] = (vecs[scr.backRightRoadInts[0]] = (vecs[scr.frontLeftRoadInts[0]] + vecs[scr.backRightRoadInts[0]]) * 0.5f);
				vecs[scr.frontLeftRoadInts[1]] = (vecs[scr.backRightRoadInts[1]] = (vecs[scr.frontLeftRoadInts[1]] + vecs[scr.backRightRoadInts[1]]) * 0.5f);
				vecs[scr.frontRightRoadInts[0]] = (vecs[scr.rightLeftRoadInts[0]] = (vecs[scr.frontRightRoadInts[0]] + vecs[scr.rightLeftRoadInts[0]]) * 0.5f);
				vecs[scr.frontRightRoadInts[1]] = (vecs[scr.rightLeftRoadInts[1]] = (vecs[scr.frontRightRoadInts[1]] + vecs[scr.rightLeftRoadInts[1]]) * 0.5f);
				vecs[scr.rightRightRoadInts[0]] = (vecs[scr.backLeftRoadInts[0]] = (vecs[scr.rightRightRoadInts[0]] + vecs[scr.backLeftRoadInts[0]]) * 0.5f);
				vecs[scr.rightRightRoadInts[1]] = (vecs[scr.backLeftRoadInts[1]] = (vecs[scr.rightRightRoadInts[1]] + vecs[scr.backLeftRoadInts[1]]) * 0.5f);
			}
			return vecs;
		}
	}
}
