using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OOQCCQOCDO : MonoBehaviour
	{
		public static void OQDCOOOOCO(ERCrossings scr, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, List<Material> materialList, List<Material> connectionMaterialList)
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
			OCCODCCOOC(scr, scr.startConnectionV3, scr.startConnectionUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.startConnectionTris, 1, OCQCDQCQOQ.OQOQDQCODD(materialList, connectionMaterialList[0]), centerPointIndex);
			OCCODCCOOC(scr, scr.endConnectionV3, scr.endConnectionUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.endConnectionTris, 1, OCQCDQCQOQ.OQOQDQCODD(materialList, connectionMaterialList[1]), centerPointIndex2);
			OCCODCCOOC(scr, scr.leftConnectionV3, scr.leftConnectionUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftConnectionTris, 1, OCQCDQCQOQ.OQOQDQCODD(materialList, connectionMaterialList[2]), centerPointIndex3);
			OCCODCCOOC(scr, scr.rightConnectionV3, scr.rightConnectionUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightConnectionTris, 1, OCQCDQCQOQ.OQOQDQCODD(materialList, connectionMaterialList[3]), centerPointIndex4);
		}

		public static float GetCenterUVY(ERCrossings scr, float uvTiling, List<List<Vector3>> vecArray, int connection)
		{
			float num = 1f;
			float num2 = 5f * uvTiling;
			switch (connection)
			{
			case 0:
				return (0f - vecArray[0][0].z) / num2;
			case 1:
				return vecArray[0][0].z / num2;
			case 2:
				return (0f - vecArray[0][0].x) / num2;
			default:
				return vecArray[0][0].x / num2;
			}
		}

		public static void OCCODCCOOC(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector2>> uvArray, int frontLeft, int topBottom, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<List<int>> intArray, int startRow, int triArrayIndex, int centerPointIndex)
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
				triList[triArrayIndex].AddRange(OQDQQQCCQD(intArray));
			}
			triList[triArrayIndex].AddRange(OQDCDQQDQO(intArray[0], intArray[1], startRow));
			triList[triArrayIndex].AddRange(OQDCDQQDQO(intArray[3], intArray[4], startRow));
			if (intArray[1].Count == intArray[2].Count)
			{
				triList[triArrayIndex].AddRange(OQDCDQQDQO(intArray[1], intArray[2], startRow));
			}
			else
			{
				triList[triArrayIndex].AddRange(OQOOCDOOOQ(intArray[1], intArray[2], vecArray[1], vecArray[2], frontLeft, topBottom, startRow));
			}
			if (intArray[2].Count == intArray[3].Count)
			{
				triList[triArrayIndex].AddRange(OQDCDQQDQO(intArray[2], intArray[3], startRow));
			}
			else
			{
				triList[triArrayIndex].AddRange(OQOOCDOOOQ(intArray[2], intArray[3], vecArray[2], vecArray[3], frontLeft, topBottom, startRow));
			}
			triList[triArrayIndex].Add(intArray[1][intArray[1].Count - 1]);
			triList[triArrayIndex].Add(centerPointIndex);
			triList[triArrayIndex].Add(intArray[2][intArray[2].Count - 1]);
			triList[triArrayIndex].Add(intArray[2][intArray[2].Count - 1]);
			triList[triArrayIndex].Add(centerPointIndex);
			triList[triArrayIndex].Add(intArray[3][intArray[3].Count - 1]);
		}

		public static List<int> OQDQQQCCQD(List<List<int>> intArray)
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

		public static List<int> OQDCDQQDQO(List<int> col1, List<int> col2, int startRow)
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

		public static List<int> OQOOCDOOOQ(List<int> col1, List<int> col2, List<Vector3> vecs1, List<Vector3> vecs2, int frontLeft, int topBottom, int startRow)
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

		public static void InitODOCDQCCCD(ERCrossings scr)
		{
			ODOCDQCCCD(scr, scr.startConnectionV3, ref scr.startConnectionUV, ref scr.uvArrayFront, 0, scr.frontRoadUVTiling);
			ODOCDQCCCD(scr, scr.endConnectionV3, ref scr.endConnectionUV, ref scr.uvArrayBack, 0, scr.backRoadUVTiling);
			ODOCDQCCCD(scr, scr.leftConnectionV3, ref scr.leftConnectionUV, ref scr.uvArrayLeft, 1, scr.leftRoadUVTiling);
			ODOCDQCCCD(scr, scr.rightConnectionV3, ref scr.rightConnectionUV, ref scr.uvArrayRight, 1, scr.rightRoadUVTiling);
		}

		public static void ODOCDQCCCD(ERCrossings scr, List<List<Vector3>> vecArray, ref List<List<Vector2>> uvs, ref List<float> uvArray, int verthorz, float uvTiling)
		{
			ERSideWalkVecs.ODQCQCDQQQ(vecArray, ref uvArray);
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
					Vector3 a = OOCDOQCOCD.OQQQDCODQD(vA, vB, vecArray[i][j]);
					num3 = Vector3.Distance(a, vecArray[i][j]);
					float num4 = num3 / num;
					uvs[i].Add(new Vector2(uvArray[i], num3 / num2));
				}
			}
		}

		public static Vector3[] OQOQCDODCO(ERCrossings scr, Vector3[] vecs)
		{
			if (!scr.tCrossing)
			{
				ref Vector3 reference = ref vecs[scr.frontLeftRoadInts[0]];
				ref Vector3 reference2 = ref vecs[scr.leftRightRoadInts[0]];
				reference = (reference2 = (vecs[scr.frontLeftRoadInts[0]] + vecs[scr.leftRightRoadInts[0]]) * 0.5f);
				ref Vector3 reference3 = ref vecs[scr.frontLeftRoadInts[1]];
				ref Vector3 reference4 = ref vecs[scr.leftRightRoadInts[1]];
				reference3 = (reference4 = (vecs[scr.frontLeftRoadInts[1]] + vecs[scr.leftRightRoadInts[1]]) * 0.5f);
				ref Vector3 reference5 = ref vecs[scr.frontRightRoadInts[0]];
				ref Vector3 reference6 = ref vecs[scr.rightLeftRoadInts[0]];
				reference5 = (reference6 = (vecs[scr.frontRightRoadInts[0]] + vecs[scr.rightLeftRoadInts[0]]) * 0.5f);
				ref Vector3 reference7 = ref vecs[scr.frontRightRoadInts[1]];
				ref Vector3 reference8 = ref vecs[scr.rightLeftRoadInts[1]];
				reference7 = (reference8 = (vecs[scr.frontRightRoadInts[1]] + vecs[scr.rightLeftRoadInts[1]]) * 0.5f);
				ref Vector3 reference9 = ref vecs[scr.rightRightRoadInts[0]];
				ref Vector3 reference10 = ref vecs[scr.backLeftRoadInts[0]];
				reference9 = (reference10 = (vecs[scr.rightRightRoadInts[0]] + vecs[scr.backLeftRoadInts[0]]) * 0.5f);
				ref Vector3 reference11 = ref vecs[scr.rightRightRoadInts[1]];
				ref Vector3 reference12 = ref vecs[scr.backLeftRoadInts[1]];
				reference11 = (reference12 = (vecs[scr.rightRightRoadInts[1]] + vecs[scr.backLeftRoadInts[1]]) * 0.5f);
				ref Vector3 reference13 = ref vecs[scr.leftLeftRoadInts[0]];
				ref Vector3 reference14 = ref vecs[scr.backRightRoadInts[0]];
				reference13 = (reference14 = (vecs[scr.leftLeftRoadInts[0]] + vecs[scr.backRightRoadInts[0]]) * 0.5f);
				ref Vector3 reference15 = ref vecs[scr.leftLeftRoadInts[1]];
				ref Vector3 reference16 = ref vecs[scr.backRightRoadInts[1]];
				reference15 = (reference16 = (vecs[scr.leftLeftRoadInts[1]] + vecs[scr.backRightRoadInts[1]]) * 0.5f);
			}
			else if (scr.tCrossingLeftRight == 0)
			{
				ref Vector3 reference17 = ref vecs[scr.frontLeftRoadInts[0]];
				ref Vector3 reference18 = ref vecs[scr.leftRightRoadInts[0]];
				reference17 = (reference18 = (vecs[scr.frontLeftRoadInts[0]] + vecs[scr.leftRightRoadInts[0]]) * 0.5f);
				ref Vector3 reference19 = ref vecs[scr.frontLeftRoadInts[1]];
				ref Vector3 reference20 = ref vecs[scr.leftRightRoadInts[1]];
				reference19 = (reference20 = (vecs[scr.frontLeftRoadInts[1]] + vecs[scr.leftRightRoadInts[1]]) * 0.5f);
				ref Vector3 reference21 = ref vecs[scr.frontRightRoadInts[0]];
				ref Vector3 reference22 = ref vecs[scr.backLeftRoadInts[0]];
				reference21 = (reference22 = (vecs[scr.frontRightRoadInts[0]] + vecs[scr.backLeftRoadInts[0]]) * 0.5f);
				ref Vector3 reference23 = ref vecs[scr.frontRightRoadInts[1]];
				ref Vector3 reference24 = ref vecs[scr.backLeftRoadInts[1]];
				reference23 = (reference24 = (vecs[scr.frontRightRoadInts[1]] + vecs[scr.backLeftRoadInts[1]]) * 0.5f);
				ref Vector3 reference25 = ref vecs[scr.leftLeftRoadInts[0]];
				ref Vector3 reference26 = ref vecs[scr.backRightRoadInts[0]];
				reference25 = (reference26 = (vecs[scr.leftLeftRoadInts[0]] + vecs[scr.backRightRoadInts[0]]) * 0.5f);
				ref Vector3 reference27 = ref vecs[scr.leftLeftRoadInts[1]];
				ref Vector3 reference28 = ref vecs[scr.backRightRoadInts[1]];
				reference27 = (reference28 = (vecs[scr.leftLeftRoadInts[1]] + vecs[scr.backRightRoadInts[1]]) * 0.5f);
			}
			else if (scr.tCrossingLeftRight == 1)
			{
				ref Vector3 reference29 = ref vecs[scr.frontLeftRoadInts[0]];
				ref Vector3 reference30 = ref vecs[scr.backRightRoadInts[0]];
				reference29 = (reference30 = (vecs[scr.frontLeftRoadInts[0]] + vecs[scr.backRightRoadInts[0]]) * 0.5f);
				ref Vector3 reference31 = ref vecs[scr.frontLeftRoadInts[1]];
				ref Vector3 reference32 = ref vecs[scr.backRightRoadInts[1]];
				reference31 = (reference32 = (vecs[scr.frontLeftRoadInts[1]] + vecs[scr.backRightRoadInts[1]]) * 0.5f);
				ref Vector3 reference33 = ref vecs[scr.frontRightRoadInts[0]];
				ref Vector3 reference34 = ref vecs[scr.rightLeftRoadInts[0]];
				reference33 = (reference34 = (vecs[scr.frontRightRoadInts[0]] + vecs[scr.rightLeftRoadInts[0]]) * 0.5f);
				ref Vector3 reference35 = ref vecs[scr.frontRightRoadInts[1]];
				ref Vector3 reference36 = ref vecs[scr.rightLeftRoadInts[1]];
				reference35 = (reference36 = (vecs[scr.frontRightRoadInts[1]] + vecs[scr.rightLeftRoadInts[1]]) * 0.5f);
				ref Vector3 reference37 = ref vecs[scr.rightRightRoadInts[0]];
				ref Vector3 reference38 = ref vecs[scr.backLeftRoadInts[0]];
				reference37 = (reference38 = (vecs[scr.rightRightRoadInts[0]] + vecs[scr.backLeftRoadInts[0]]) * 0.5f);
				ref Vector3 reference39 = ref vecs[scr.rightRightRoadInts[1]];
				ref Vector3 reference40 = ref vecs[scr.backLeftRoadInts[1]];
				reference39 = (reference40 = (vecs[scr.rightRightRoadInts[1]] + vecs[scr.backLeftRoadInts[1]]) * 0.5f);
			}
			return vecs;
		}
	}
}
