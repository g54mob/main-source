using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERRoundaboutsFunctions : MonoBehaviour
	{
		public static void OOODCQOQOQ(ERRoundabouts scr, int currentIndex)
		{
			float num = scr.prefabScript.sidewalkControlElements[currentIndex].sidewalkWidth1;
			float sidewalkWidth = scr.prefabScript.sidewalkControlElements[currentIndex].sidewalkWidth1;
			sidewalkWidth = ((currentIndex >= scr.connections.Count - 1) ? scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1 : scr.prefabScript.sidewalkControlElements[currentIndex + 1].sidewalkWidth1);
			if (num < sidewalkWidth)
			{
				num = sidewalkWidth;
			}
			float num2 = Vector3.Distance(Vector3.zero, scr.connections[currentIndex].leftOuterSegments[scr.connections[currentIndex].leftOuterSegments.Count - 1]);
			float num3 = scr.roundAboutRadius + 0.5f * scr.roundaboutWidth;
			num2 -= num3;
			Vector3 normalized = (scr.connections[currentIndex].leftOuterSegments[scr.connections[currentIndex].leftOuterSegments.Count - 1] - scr.connections[currentIndex].leftOuterSegments[scr.connections[currentIndex].leftOuterSegments.Count - 2]).normalized;
			while (num > num2)
			{
				scr.connections[currentIndex].leftOuterSegments.Add(scr.connections[currentIndex].leftOuterSegments[scr.connections[currentIndex].leftOuterSegments.Count - 1] + normalized * scr.roundAboutResolution);
				scr.connections[currentIndex].rightOuterSegments.Add(scr.connections[currentIndex].rightOuterSegments[scr.connections[currentIndex].rightOuterSegments.Count - 1] + normalized * scr.roundAboutResolution);
				scr.connections[currentIndex].leftInnerSegments.Add(scr.connections[currentIndex].leftInnerSegments[scr.connections[currentIndex].leftInnerSegments.Count - 1] + normalized * scr.roundAboutResolution);
				scr.connections[currentIndex].rightInnerSegments.Add(scr.connections[currentIndex].rightInnerSegments[scr.connections[currentIndex].rightInnerSegments.Count - 1] + normalized * scr.roundAboutResolution);
				num2 = Vector3.Distance(Vector3.zero, scr.connections[currentIndex].leftOuterSegments[scr.connections[currentIndex].leftOuterSegments.Count - 1]);
				num2 -= num3;
			}
		}

		public static void OCCDCCDCOO(ERRoundabouts scr, int currentIndex)
		{
			OOOOOOOCDO(scr, currentIndex);
			OOQODDCCCC(scr, scr.connections[currentIndex].rightSidewalkV3, null, scr.prefabScript.sidewalkControlElements[currentIndex], 0, 1, -1);
			scr.prefabScript.sidewalkControlElements[currentIndex].rightHandleV3 = scr.connections[currentIndex].rightSidewalkV3[scr.connections[currentIndex].rightSidewalkV3.Count - 1][0];
			scr.prefabScript.sidewalkControlElements[currentIndex].centerHandleV3 = scr.connections[currentIndex].rightSidewalkV3[0][0];
			OQQCODQQCO(scr, scr.connections[currentIndex].rightSidewalkV3, ref scr.connections[currentIndex].rightSidewalkUV, scr.prefabScript.sidewalkControlElements[currentIndex], reverse: false);
			int index = 0;
			if (scr.connections.Count > currentIndex + 1)
			{
				index = currentIndex + 1;
			}
			OOQODDCCCC(scr, scr.connections[currentIndex].leftSidewalkV3, null, scr.prefabScript.sidewalkControlElements[index], 0, 0, -1);
			scr.prefabScript.sidewalkControlElements[index].leftHandleV3 = scr.connections[currentIndex].leftSidewalkV3[scr.connections[currentIndex].leftSidewalkV3.Count - 1][0];
			scr.prefabScript.sidewalkControlElements[index].centerHandleV3_2 = scr.connections[currentIndex].leftSidewalkV3[0][0];
			OQQCODQQCO(scr, scr.connections[currentIndex].leftSidewalkV3, ref scr.connections[currentIndex].leftSidewalkUV, scr.prefabScript.sidewalkControlElements[index], reverse: true);
		}

		public static void OOOOOOOCDO(ERRoundabouts scr, int currentIndex)
		{
			int num = 0;
			if (currentIndex == 0)
			{
				num = 0;
			}
			else
			{
				int rightOuterInt = scr.connections[currentIndex - 1].rightOuterInt;
				num = rightOuterInt + Mathf.RoundToInt((float)(scr.connections[currentIndex].leftOuterInt - rightOuterInt) * 1f * 0.5f);
			}
			for (int i = num; i <= scr.connections[currentIndex].leftOuterInt; i++)
			{
				scr.connections[currentIndex].leftSidewalkSourceVecs.Add(scr.mainLeftPoints[i]);
			}
			scr.connections[currentIndex].leftSidewalkSourceVecs.AddRange(scr.connections[currentIndex].leftOuterSegments);
			int num2 = 0;
			if (currentIndex == scr.connections.Count - 1)
			{
				num2 = scr.mainLeftPoints.Count - 1;
			}
			else
			{
				int leftOuterInt = scr.connections[currentIndex + 1].leftOuterInt;
				num2 = scr.connections[currentIndex].rightOuterInt + Mathf.RoundToInt((float)(leftOuterInt - scr.connections[currentIndex].rightOuterInt) * 0.5f);
			}
			scr.connections[currentIndex].rightSidewalkSourceVecs.AddRange(scr.connections[currentIndex].rightOuterSegments);
			scr.connections[currentIndex].rightSidewalkSourceVecs.Reverse();
			num = scr.connections[currentIndex].rightOuterInt;
			for (int i = num; i <= num2; i++)
			{
				scr.connections[currentIndex].rightSidewalkSourceVecs.Add(scr.mainLeftPoints[i]);
			}
			scr.connections[currentIndex].leftSidewalkSourceVecs.Reverse();
			scr.connections[currentIndex].leftSidewalkV3.Add(new List<Vector3>());
			scr.connections[currentIndex].leftSidewalkV3[0].AddRange(scr.connections[currentIndex].rightSidewalkSourceVecs);
			scr.connections[currentIndex].rightSidewalkV3.Add(new List<Vector3>());
			scr.connections[currentIndex].rightSidewalkV3[0].AddRange(scr.connections[currentIndex].leftSidewalkSourceVecs);
			scr.connections[currentIndex].leftSidewalkSourceVecs.Reverse();
			scr.connections[currentIndex].rightSidewalkSourceVecs.Reverse();
		}

		public static void OOQODDCCCC(ERRoundabouts scr, List<List<Vector3>> vecArray, List<List<Vector3>> vecArrayOther, QDOQDSQOOQDDD corner, int startEnd, int mainOrConnected, int outerCornerInt)
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
					vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
				if (corner.beveledDepth != corner.curbDepth)
				{
					num = corner.curbDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
			}
			else
			{
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODCQODDDQD(vecArray[0], num2));
				num = corner.curbDepth;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
			}
			num = corner.sidewalkWidth1 - corner.curbDepth;
			vecArray.Add(new List<Vector3>());
			vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
			if (corner.beveledCurb && corner.outerCurb)
			{
				if (corner.beveledDepth != corner.curbDepth && corner.beveledDepth > 0f)
				{
					num = corner.sidewalkWidth1 - corner.beveledDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
				if (corner.beveledHeight > 0f && corner.beveledHeight != corner.curbHeight && corner.outerCurb)
				{
					num2 = corner.beveledHeight;
					num = corner.sidewalkWidth1;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
				num2 = 0f;
				num = corner.sidewalkWidth1;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
			}
			else
			{
				num = corner.sidewalkWidth1;
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				if (corner.outerCurb)
				{
					num2 = 0f;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OQQQDODQDO(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
			}
		}

		public static List<Vector3> OQQQDODQDO(List<Vector3> outer, List<Vector3> outerOther, float dist, float height, int startend, int leftright, int outerCornerInt)
		{
			List<Vector3> list = new List<Vector3>();
			Vector3 vector = Vector3.zero;
			int num = outer.Count;
			if (outerCornerInt != -1)
			{
				num = outerCornerInt;
			}
			for (int i = 0; i < num; i++)
			{
				Vector3 vector2 = ((i == 0) ? (outer[1] - outer[0]).normalized : ((i >= outer.Count - 1) ? (outer[i] - outer[i - 1]).normalized : (outer[i + 1] - outer[i - 1]).normalized));
				vector2 = ((leftright != 0) ? new Vector3(vector2.z, 0f, 0f - vector2.x) : new Vector3(0f - vector2.z, 0f, vector2.x));
				Vector3 vector3 = outer[i] + vector2 * dist;
				if (i > 0)
				{
					if (leftright == 0)
					{
						if (!OCQCDQCQOQ.OOOOCDQQOC(vector, outer[i - 1], vector3))
						{
							vector3 = vector;
						}
					}
					else if (OCQCDQCQOQ.OOOOCDQQOC(vector, outer[i - 1], vector3))
					{
						vector3 = vector;
					}
				}
				vector3.y = height;
				list.Add(vector3);
				vector = vector3;
			}
			return list;
		}

		public static List<Vector3> ODCOQOOOCO(ERRoundabouts scr, List<Vector3> innerArray, List<Vector3> outerOther, float dist, float height, float sidewalkWidth, int startend, int leftright, int outerCornerInt)
		{
			List<Vector3> list = new List<Vector3>();
			Vector3 normalized = (innerArray[1] - innerArray[0]).normalized;
			normalized = ((leftright != 0) ? new Vector3(normalized.z, 0f, 0f - normalized.x) : new Vector3(0f - normalized.z, 0f, normalized.x));
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

		public static void OQQCODQQCO(ERRoundabouts scr, List<List<Vector3>> vecArray, ref List<List<Vector2>> uvArray, QDOQDSQOOQDDD corner, bool reverse)
		{
			if (corner.sidewalkUVs.Count == 0 || !corner.lockUVs)
			{
				ODQCQCDQQQ(vecArray, ref corner.sidewalkUVs);
			}
			List<float> list = new List<float>();
			list.AddRange(corner.sidewalkUVs);
			uvArray.Clear();
			float num = 0f;
			List<float> list2 = new List<float>();
			for (int i = 0; i < vecArray.Count; i++)
			{
				uvArray.Add(new List<Vector2>());
				list2.Add(0f);
				uvArray[i].Add(new Vector2(list[i], 0f));
				num = 0f;
				for (int j = 1; j < vecArray[i].Count; j++)
				{
					num += Vector3.Distance(vecArray[i][j - 1], vecArray[i][j]);
					if (i == 0)
					{
						list2.Add(num / 2.5f);
					}
					uvArray[i].Add(new Vector2(list[i], list2[j]));
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

		public static void OCQCDODODO(ERRoundabouts scr)
		{
			int num = 0;
			for (int i = 0; i < scr.connections.Count; i++)
			{
				num = ((i != 0) ? (i - 1) : (scr.connections.Count - 1));
				for (int j = 0; j < scr.connections[i].rightSidewalkV3.Count; j++)
				{
					Vector3 a = scr.connections[i].rightSidewalkV3[j][scr.connections[i].rightSidewalkV3[j].Count - 1];
					Vector3 b = scr.connections[num].leftSidewalkV3[j][scr.connections[num].leftSidewalkV3[j].Count - 1];
					Vector3 value = Vector3.Lerp(a, b, 0.5f);
					scr.connections[i].rightSidewalkV3[j][scr.connections[i].rightSidewalkV3[j].Count - 1] = value;
					scr.connections[num].leftSidewalkV3[j][scr.connections[num].leftSidewalkV3[j].Count - 1] = value;
				}
			}
		}

		public static void SetInnerSidewalkVars(ERRoundabouts scr, int preset)
		{
			scr.innerSidewalkWidth1 = scr.baseScript.sidewalkPresets[preset - 1].sidewalkWidth1;
			scr.innerSidewalkWidth2 = scr.baseScript.sidewalkPresets[preset - 1].sidewalkWidth2;
			scr.innerCurbHeight = scr.baseScript.sidewalkPresets[preset - 1].curbHeight;
			scr.innerCurbDepth = scr.baseScript.sidewalkPresets[preset - 1].curbDepth;
			scr.innerBeveledCurb = scr.baseScript.sidewalkPresets[preset - 1].beveledCurb;
			scr.innerBeveledHeight = scr.baseScript.sidewalkPresets[preset - 1].beveledHeight;
			scr.innerBeveledDepth = scr.baseScript.sidewalkPresets[preset - 1].beveledDepth;
			scr.innerOuterCurb = scr.baseScript.sidewalkPresets[preset - 1].outerCurb;
			scr.innerRoadSideCurbUVControl = scr.baseScript.sidewalkPresets[preset - 1].roadSideCurbUVControl;
			scr.innerOuterSideCurbUVControl = scr.baseScript.sidewalkPresets[preset - 1].outerSideCurbUVControl;
			scr.innerSidewalkMaterial = scr.baseScript.sidewalkPresets[preset - 1].sidewalkMaterial;
			scr.innerSidewalkUVs = new List<float>(scr.baseScript.sidewalkPresets[preset - 1].sidewalkUVs);
		}

		public static void BuildInnerRoundaboutSidewalkData(ERRoundabouts scr, ERModularBase baseScr, List<Vector3> mainRightPoints, ref List<Vector3> innerRoundaboutSidewalkV3, ref List<Vector2> innerRoundaboutSidewalUV, ref List<int> innerRoundaboutSidewalTris, ref int innerSidewalkSegments)
		{
			if (baseScr.sidewalkPresets.Count <= scr.innerRoundaboutPreset - 1)
			{
				Debug.Log("No sidewalk presets available in the scene data, inner sidewalk cannot be generated > Fix!");
			}
			float innerSidewalkWidth = scr.innerSidewalkWidth1;
			float innerSidewalkWidth2 = scr.innerSidewalkWidth2;
			float innerCurbHeight = scr.innerCurbHeight;
			float innerCurbDepth = scr.innerCurbDepth;
			bool innerBeveledCurb = scr.innerBeveledCurb;
			float innerBeveledHeight = scr.innerBeveledHeight;
			float innerBeveledDepth = scr.innerBeveledDepth;
			bool innerOuterCurb = scr.innerOuterCurb;
			bool innerRoadSideCurbUVControl = scr.innerRoadSideCurbUVControl;
			bool innerOuterSideCurbUVControl = scr.innerOuterSideCurbUVControl;
			scr.innerRoundaboutSidewalkMaterial = scr.innerSidewalkMaterial;
			List<float> innerSidewalkUVs = scr.innerSidewalkUVs;
			int num = 1;
			int num2 = 0;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < mainRightPoints.Count - 1; i++)
			{
				Vector3 vector = ((i != 0 && i != mainRightPoints.Count - 1) ? (mainRightPoints[i + 1] - mainRightPoints[i - 1]).normalized : (mainRightPoints[1] - mainRightPoints[mainRightPoints.Count - 2]).normalized);
				vector = new Vector3(vector.z, 0f, 0f - vector.x);
				if (i > 0)
				{
					num3 += Vector3.Distance(mainRightPoints[i - 1], mainRightPoints[i]);
				}
				num4 = num3 / 2.5f;
				for (int j = 0; j < innerSidewalkUVs.Count; j++)
				{
					innerRoundaboutSidewalUV.Add(new Vector2(innerSidewalkUVs[j], num4));
				}
				Vector3 item = mainRightPoints[i];
				innerRoundaboutSidewalkV3.Add(item);
				if (innerBeveledCurb)
				{
					if (innerBeveledHeight > 0f)
					{
						item.y += innerBeveledHeight;
						innerRoundaboutSidewalkV3.Add(item);
						if (i == 0)
						{
							num++;
						}
						item.y += innerCurbHeight - innerBeveledHeight;
					}
					else
					{
						item.y += innerCurbHeight;
					}
					if (innerBeveledDepth > 0f)
					{
						item += vector * innerBeveledDepth;
						innerRoundaboutSidewalkV3.Add(item);
						if (i == 0)
						{
							num++;
						}
						item += vector * (innerCurbDepth - innerBeveledDepth);
					}
					else
					{
						item += vector * innerCurbDepth;
					}
				}
				else
				{
					item.y += innerCurbHeight;
					innerRoundaboutSidewalkV3.Add(item);
					if (i == 0)
					{
						num++;
					}
					item += vector * innerCurbDepth;
				}
				innerRoundaboutSidewalkV3.Add(item);
				if (i == 0)
				{
					num++;
				}
				item += vector * (innerSidewalkWidth - 2f * innerCurbDepth);
				innerRoundaboutSidewalkV3.Add(item);
				if (i == 0)
				{
					num++;
				}
				if (innerOuterCurb)
				{
					if (innerBeveledCurb)
					{
						if (innerBeveledDepth > 0f)
						{
							item += vector * (innerCurbDepth - innerBeveledDepth);
							innerRoundaboutSidewalkV3.Add(item);
							if (i == 0)
							{
								num++;
							}
							item += vector * innerBeveledDepth;
						}
						else
						{
							item += vector * innerCurbDepth;
						}
						if (innerBeveledHeight > 0f)
						{
							item.y -= innerCurbHeight - innerBeveledHeight;
							innerRoundaboutSidewalkV3.Add(item);
							if (i == 0)
							{
								num++;
							}
							item.y -= innerBeveledHeight;
						}
						else
						{
							item.y -= innerCurbHeight;
						}
						innerRoundaboutSidewalkV3.Add(item);
						if (i == 0)
						{
							num++;
						}
					}
					else
					{
						item += vector * innerCurbDepth;
						innerRoundaboutSidewalkV3.Add(item);
						if (i == 0)
						{
							num++;
						}
						item.y -= innerCurbHeight;
						innerRoundaboutSidewalkV3.Add(item);
						if (i == 0)
						{
							num++;
						}
					}
				}
				else
				{
					item += vector * innerCurbDepth;
					innerRoundaboutSidewalkV3.Add(item);
					if (i == 0)
					{
						num++;
					}
				}
				num2++;
			}
			int num5 = num;
			for (int i = 0; i < num2 - 1; i++)
			{
				for (int j = 0; j < num5 - 1; j++)
				{
					innerRoundaboutSidewalTris.Add(i * num5 + j);
					innerRoundaboutSidewalTris.Add((i + 1) * num5 + j + 1);
					innerRoundaboutSidewalTris.Add(i * num5 + j + 1);
					innerRoundaboutSidewalTris.Add((i + 1) * num5 + j);
					innerRoundaboutSidewalTris.Add((i + 1) * num5 + j + 1);
					innerRoundaboutSidewalTris.Add(i * num5 + j);
				}
			}
			for (int i = 0; i < num; i++)
			{
				List<Vector3> obj = innerRoundaboutSidewalkV3;
				int index = i;
				Vector3 value = (innerRoundaboutSidewalkV3[innerRoundaboutSidewalkV3.Count - num + i] = Vector3.Lerp(innerRoundaboutSidewalkV3[i], innerRoundaboutSidewalkV3[innerRoundaboutSidewalkV3.Count - num + i], 0.5f));
				obj[index] = value;
			}
			innerSidewalkSegments = num;
		}
	}
}
