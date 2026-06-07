using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ODQCCDQOCO : MonoBehaviour
	{
		public static void ODQDOCOCQD(ERCrossings scr, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<Material> materialList)
		{
			List<int> normalInts = new List<int>();
			List<int> normalIntsStart = new List<int>();
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag)
			{
				OOQODOCOCD(scr, scr.leftSidewalkStartV3, scr.leftSidewalkStartUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkStartTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[0], scr.leftStartSidewalkCornerInt, ref normalInts, ref normalIntsStart);
				OCQDCOOCOO.OQDDDCOQQD(scr, 0, scr.leftSidewalkStartV3, 0);
				scr.ODDDDDODQCStart.AddRange(normalIntsStart);
				scr.ODDDDDODQC.AddRange(normalInts);
				if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
				{
					OOQODOCOCD(scr, scr.rightSidewalkLeftV3, scr.rightSidewalkLeftUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkLeftTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[0], scr.rightLeftSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OCQDCOOCOO.OQDDDCOQQD(scr, 2, scr.rightSidewalkLeftV3, 0);
					scr.OQOQQQQQCOStart.AddRange(normalIntsStart);
					scr.OQOQQQQQCO.AddRange(normalInts);
				}
				else if (scr.tCrossing)
				{
					OOQODOCOCD(scr, scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkEndTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[0], scr.rightEndSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OCQDCOOCOO.OQDDDCOQQD(scr, 1, scr.rightSidewalkEndV3, 1);
					scr.OQOQQQQQCOStart.AddRange(normalIntsStart);
					scr.OQOQQQQQCO.AddRange(normalInts);
				}
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag)
			{
				OOQODOCOCD(scr, scr.rightSidewalkStartV3, scr.rightSidewalkStartUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkStartTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[1], scr.rightStartSidewalkCornerInt, ref normalInts, ref normalIntsStart);
				OCQDCOOCOO.OQDDDCOQQD(scr, 0, scr.rightSidewalkStartV3, 1);
				scr.OOODDDQQDDStart.AddRange(normalIntsStart);
				scr.OOODDDQQDD.AddRange(normalInts);
				if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
				{
					OOQODOCOCD(scr, scr.leftSidewalkRightV3, scr.leftSidewalkRightUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkRightTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[1], scr.leftRightSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OCQDCOOCOO.OQDDDCOQQD(scr, 3, scr.leftSidewalkRightV3, 0);
					scr.OCCCOQDDCCStart.AddRange(normalIntsStart);
					scr.OCCCOQDDCC.AddRange(normalInts);
				}
				else if (scr.tCrossing)
				{
					OOQODOCOCD(scr, scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkEndTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[1], scr.leftEndSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OCQDCOOCOO.OQDDDCOQQD(scr, 1, scr.leftSidewalkEndV3, 0);
					scr.OCCCOQDDCCStart.AddRange(normalIntsStart);
					scr.OCCCOQDDCC.AddRange(normalInts);
				}
			}
			if ((!scr.tCrossing || scr.tCrossingLeftRight == 1) && scr.prefabScript.sidewalkControlElements[3].renderFlag)
			{
				OOQODOCOCD(scr, scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkEndTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[3], scr.leftEndSidewalkCornerInt, ref normalInts, ref normalIntsStart);
				OCQDCOOCOO.OQDDDCOQQD(scr, 1, scr.leftSidewalkEndV3, 0);
				scr.ODQDQQOOQQStart.AddRange(normalIntsStart);
				scr.ODQDQQOOQQ.AddRange(normalInts);
				if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
				{
					OOQODOCOCD(scr, scr.rightSidewalkRightV3, scr.rightSidewalkRightUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkRightTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[3], scr.rightRightSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OCQDCOOCOO.OQDDDCOQQD(scr, 3, scr.rightSidewalkRightV3, 1);
					scr.OCQOCDCQODStart.AddRange(normalIntsStart);
					scr.OCQOCDCQOD.AddRange(normalInts);
				}
			}
			if ((!scr.tCrossing || scr.tCrossingLeftRight == 0) && scr.prefabScript.sidewalkControlElements[2].renderFlag)
			{
				OOQODOCOCD(scr, scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.rightSidewalkEndTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[2], scr.rightEndSidewalkCornerInt, ref normalInts, ref normalIntsStart);
				OCQDCOOCOO.OQDDDCOQQD(scr, 1, scr.rightSidewalkEndV3, 1);
				scr.ODOCCCOCOOStart.AddRange(normalIntsStart);
				scr.ODOCCCOCOO.AddRange(normalInts);
				if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
				{
					OOQODOCOCD(scr, scr.leftSidewalkLeftV3, scr.leftSidewalkLeftUV, 0, 0, ref meshVecs, ref meshUVs, ref triList, ref scr.leftSidewalkLeftTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[2], scr.leftLeftSidewalkCornerInt, ref normalInts, ref normalIntsStart);
					OCQDCOOCOO.OQDDDCOQQD(scr, 2, scr.leftSidewalkLeftV3, 0);
					scr.OQDCOODOCDStart.AddRange(normalIntsStart);
					scr.OQDCOODOCD.AddRange(normalInts);
				}
			}
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag && !scr.prefabScript.crossingElements[0].includeLeftSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[0], scr.leftSidewalkStartV3, scr.leftSidewalkStartUV, scr.leftSidewalkStartTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag && !scr.prefabScript.crossingElements[0].includeRightSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[1], scr.rightSidewalkStartV3, scr.rightSidewalkStartUV, scr.rightSidewalkStartTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				if (scr.prefabScript.sidewalkControlElements[2].renderFlag && !scr.prefabScript.crossingElements[1].includeRightSidewalk)
				{
					OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[2], scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, scr.rightSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
				}
			}
			else if (scr.prefabScript.sidewalkControlElements[1].renderFlag && !scr.prefabScript.crossingElements[1].includeRightSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[1], scr.rightSidewalkEndV3, scr.rightSidewalkEndUV, scr.rightSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				if (scr.prefabScript.sidewalkControlElements[3].renderFlag && !scr.prefabScript.crossingElements[1].includeLeftSidewalk)
				{
					OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[3], scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, scr.leftSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
				}
			}
			else if (scr.prefabScript.sidewalkControlElements[0].renderFlag && !scr.prefabScript.crossingElements[1].includeLeftSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[3], scr.leftSidewalkEndV3, scr.leftSidewalkEndUV, scr.leftSidewalkEndTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (scr.prefabScript.sidewalkControlElements[2].renderFlag && (!scr.tCrossing || scr.tCrossingLeftRight == 0) && !scr.prefabScript.crossingElements[2].includeLeftSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[2], scr.leftSidewalkLeftV3, scr.leftSidewalkLeftUV, scr.leftSidewalkLeftTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (scr.prefabScript.sidewalkControlElements[1].renderFlag && (!scr.tCrossing || scr.tCrossingLeftRight == 0) && !scr.prefabScript.crossingElements[2].includeRightSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[0], scr.rightSidewalkLeftV3, scr.rightSidewalkLeftUV, scr.rightSidewalkLeftTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
			if (scr.prefabScript.sidewalkControlElements[0].renderFlag && (!scr.tCrossing || scr.tCrossingLeftRight == 1) && !scr.prefabScript.crossingElements[3].includeLeftSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[1], scr.leftSidewalkRightV3, scr.leftSidewalkRightUV, scr.leftSidewalkRightTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
			}
			if (scr.prefabScript.sidewalkControlElements[3].renderFlag && (!scr.tCrossing || scr.tCrossingLeftRight == 1) && !scr.prefabScript.crossingElements[3].includeRightSidewalk)
			{
				OCQQCDDDQO(scr, scr.prefabScript.sidewalkControlElements[3], scr.rightSidewalkRightV3, scr.rightSidewalkRightUV, scr.rightSidewalkRightTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
			}
		}

		public static void ODQODDODCC(ERRoundabouts scr, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<Material> materialList)
		{
			for (int i = 0; i < scr.connections.Count; i++)
			{
				int num = i;
				num = ((scr.connections.Count > i + 1) ? (num + 1) : 0);
				if (scr.prefabScript.sidewalkControlElements[num].renderFlag)
				{
					OOQQDDCQCC(scr, scr.connections[i].leftSidewalkV3, scr.connections[i].leftSidewalkUV, 0, 0, ref meshVecs, ref scr.connections[i].leftSidewalkNormalsStart, ref scr.connections[i].leftSidewalkNormalsEnd, ref meshUVs, ref triList, ref scr.connections[i].leftSidewalkTris, ref materialList, reverse: true, scr.prefabScript.sidewalkControlElements[num], -1);
					if (!scr.prefabScript.crossingElements[i].includeLeftSidewalk)
					{
						OCQQCDDDQO(null, scr.prefabScript.sidewalkControlElements[num], scr.connections[i].leftSidewalkV3, scr.connections[i].leftSidewalkUV, scr.connections[i].leftSidewalkTris, ref meshVecs, ref meshUVs, ref triList, materialList, 0);
					}
				}
				num = i;
				if (scr.prefabScript.sidewalkControlElements[i].renderFlag)
				{
					OOQQDDCQCC(scr, scr.connections[i].rightSidewalkV3, scr.connections[i].rightSidewalkUV, 0, 0, ref meshVecs, ref scr.connections[i].rightSidewalkNormalsStart, ref scr.connections[i].rightSidewalkNormalsEnd, ref meshUVs, ref triList, ref scr.connections[i].rightSidewalkTris, ref materialList, reverse: false, scr.prefabScript.sidewalkControlElements[num], -1);
					if (!scr.prefabScript.crossingElements[i].includeRightSidewalk)
					{
						OCQQCDDDQO(null, scr.prefabScript.sidewalkControlElements[i], scr.connections[i].rightSidewalkV3, scr.connections[i].rightSidewalkUV, scr.connections[i].rightSidewalkTris, ref meshVecs, ref meshUVs, ref triList, materialList, 1);
					}
				}
			}
		}

		public static void OQDQDOCODD(ERRoundabouts scr, List<Vector3> vecs, List<Vector2> uvs, List<int> tris, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<Material> materialList)
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
			for (int j = 0; j < vecs.Count; j++)
			{
				meshVecs.Add(vecs[j]);
				meshUVs.Add(uvs[j]);
				if (j < scr.innerSidewalkSegments)
				{
					scr.innerRoundaboutSidewalkIntsStart.Add(meshVecs.Count - 1);
				}
			}
			for (int k = 0; k < scr.innerSidewalkSegments; k++)
			{
				scr.innerRoundaboutSidewalkIntsEnd.Add(meshVecs.Count - scr.innerSidewalkSegments + k);
			}
			List<int> list = new List<int>();
			for (int l = 0; l < tris.Count; l++)
			{
				list.Add(count + tris[l]);
				if (tris[l] > vecs.Count - 1)
				{
					Debug.Log(tris[l] + " > " + (vecs.Count - 1));
				}
			}
			triList[index].AddRange(list);
		}

		public static void OOQODOCOCD(ERCrossings scr, List<List<Vector3>> vecArray, List<List<Vector2>> uvArray, int frontLeft, int topBottom, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<List<int>> intArray, ref List<Material> materialList, bool reverse, QDOQDSQOOQDDD corner, int outerCornerInt, ref List<int> normalInts, ref List<int> normalIntsStart)
		{
			normalInts.Clear();
			normalIntsStart.Clear();
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

		public static void OOQQDDCQCC(ERRoundabouts scr, List<List<Vector3>> vecArray, List<List<Vector2>> uvArray, int frontLeft, int topBottom, ref List<Vector3> meshVecs, ref List<int> startNormalInts, ref List<int> endNormalInts, ref List<Vector2> meshUVs, ref List<List<int>> triList, ref List<List<int>> intArray, ref List<Material> materialList, bool reverse, QDOQDSQOOQDDD corner, int outerCornerInt)
		{
			int triArrayElement = 0;
			OOQDDDDCOC(ref materialList, ref triList, corner.sidewalkMaterial, ref triArrayElement);
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
		}

		public static List<Vector3> OCOCDCDDOD(ERCrossingPrefabs prefabScript, ERRoundaboutElement conn, ERSideWalk sw, List<Vector2> shape, List<bool> trisFlag, List<float> uv, List<Vector3> splineTmp, List<Vector3> spline2Tmp, int leftright, GameObject sidewalkGO, float offsetX, bool closedStart, bool closedEnd)
		{
			List<Vector3> list = new List<Vector3>(splineTmp);
			if ((double)Vector3.Distance(list[0], list[1]) < 0.1)
			{
				list.RemoveAt(1);
			}
			list.Reverse();
			List<float> list2 = new List<float>();
			List<List<Vector3>> list3 = new List<List<Vector3>>();
			List<List<Vector2>> list4 = new List<List<Vector2>>();
			for (int i = 0; i < shape.Count; i++)
			{
				list3.Add(new List<Vector3>());
				list4.Add(new List<Vector2>());
			}
			float num = sw.tiling / sw.uvRatio;
			Vector3 zero = Vector3.zero;
			zero = ((leftright != -1) ? conn.rightOuterSegments[conn.rightOuterSegments.Count - 1] : conn.leftOuterSegments[conn.leftOuterSegments.Count - 1]);
			Vector3 zero2 = Vector3.zero;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			int num6 = 0;
			float num7 = 0f;
			List<float> list5 = new List<float>();
			List<int> list6 = new List<int>();
			int num8 = 0;
			List<ERCrosswalkInstance> list7 = new List<ERCrosswalkInstance>();
			if (conn != null)
			{
				if (conn.rt == null && conn.roadType != 0.0)
				{
					conn.rt = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, conn.roadType);
				}
				if (conn.rt == null)
				{
					return null;
				}
				if (sw.crosswalkPavement && sw.crosswalkSize > 0f && conn.rt != null && conn.rt.crosswalks)
				{
					flag = true;
					num3 = sw.crosswalkSize;
					num4 = sw.crosswalkWidth;
				}
			}
			float num9 = num3;
			float num10 = num3 * 0.5f;
			int num11 = 5;
			int num12 = 3;
			if (sw.includeOuterStrip)
			{
				num11 = 7;
				num12 = 4;
			}
			int num13 = 0;
			int num14 = 0;
			int num15 = 0;
			List<Vector3> vecs = new List<Vector3>();
			List<Vector2> list8 = new List<Vector2>();
			List<int> list9 = new List<int>();
			int count = list3.Count;
			int num16 = 0;
			int num17 = 0;
			List<int> list10 = new List<int>();
			for (int j = 0; j < trisFlag.Count; j++)
			{
				if (trisFlag[j])
				{
					num17++;
				}
				list10.Add(num17);
			}
			float num18 = 0f;
			float num19 = 0f;
			Vector3 a = list[0];
			int count2 = list.Count;
			for (int k = 0; k < count2; k++)
			{
				Vector3 vector;
				if (k <= 0 || k >= list.Count - 1)
				{
					vector = ((k != 0) ? (list[k] - zero2).normalized : (list[0] - zero).normalized);
				}
				else
				{
					Vector3 vector2 = list[k + 1] - list[k - 1];
					vector = new Vector3(vector2.z, 0f, 0f - vector2.x).normalized;
					vector *= (float)leftright;
				}
				Vector3 vector3 = list[k];
				if (!flag || flag2 || list2[k] - num5 > num2)
				{
				}
				if (k > 0)
				{
					num18 += Vector3.Distance(a, vector3);
				}
				a = vector3;
				num19 = num18 * num;
				if (flag2)
				{
					if (k > num13)
					{
						flag2 = false;
						num5 = num9;
						list7.Add(new ERCrosswalkInstance(new List<int>(list6), sw, new List<float>(list5), num7, 0));
						list6.Clear();
						list5.Clear();
					}
					else
					{
						list5.Add(num19);
					}
				}
				for (int l = 0; l < count; l++)
				{
					Vector3 item = vector3 + (shape[l].x + offsetX) * vector;
					item.y += shape[l].y;
					if (flag2 && k >= num14 && k <= num15 && l <= sw.pavementIndex)
					{
						item.y -= num7;
					}
					Vector2 item2 = new Vector2(uv[l], num19);
					list3[l].Add(item);
					list4[l].Add(item2);
					vecs.Add(item);
					list8.Add(item2);
					if (trisFlag[l])
					{
						vecs.Add(list3[l][k]);
						Vector2 item3 = list4[l][k];
						item3.x += sw.hardEdgePadding;
						list8.Add(item3);
					}
					if (l < count - 1 && k < list3[0].Count && (!flag2 || l < sw.pavementIndex || l >= sw.pavementIndex + 1))
					{
						if (leftright == -1)
						{
							list9.Add(num16 + l + list10[l]);
							list9.Add(num16 + l + count + num17 + 1 + list10[l]);
							list9.Add(num16 + l + count + num17 + list10[l]);
							list9.Add(num16 + l + list10[l]);
							list9.Add(num16 + l + list10[l] + 1);
							list9.Add(num16 + l + count + num17 + 1 + list10[l]);
						}
						else
						{
							list9.Add(num16 + l + list10[l]);
							list9.Add(num16 + l + count + num17 + list10[l]);
							list9.Add(num16 + l + count + num17 + 1 + list10[l]);
							list9.Add(num16 + l + list10[l]);
							list9.Add(num16 + l + count + num17 + 1 + list10[l]);
							list9.Add(num16 + l + list10[l] + 1);
						}
					}
				}
				flag3 = flag2;
				num16 = k * (count + num17);
			}
			int count3 = vecs.Count;
			int count4 = vecs.Count;
			OCCCDCDQDC.OCODODDOQO(sw, ref vecs, Vector3.zero, shape.Count + num17, count3, count4, 0);
			int num20 = 0;
			foreach (ERCrosswalkInstance item4 in list7)
			{
			}
			Mesh sharedMesh = sidewalkGO.GetComponent<MeshFilter>().sharedMesh;
			sharedMesh.Clear();
			sharedMesh.vertices = vecs.ToArray();
			sharedMesh.uv = list8.ToArray();
			sharedMesh.triangles = list9.ToArray();
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
