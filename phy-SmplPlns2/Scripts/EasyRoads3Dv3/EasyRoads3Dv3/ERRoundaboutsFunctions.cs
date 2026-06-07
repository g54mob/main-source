using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERRoundaboutsFunctions : MonoBehaviour
	{
		public static void OCDODOQQDO(ERRoundabouts scr, int currentIndex)
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

		public static void OCOCQQDOQD(ERRoundabouts scr, int currentIndex)
		{
			OCDDCCDQDO(scr, currentIndex);
			OCQDDOCDCQ(scr, scr.connections[currentIndex].rightSidewalkV3, null, scr.prefabScript.sidewalkControlElements[currentIndex], 0, 1, -1);
			scr.prefabScript.sidewalkControlElements[currentIndex].rightHandleV3 = scr.connections[currentIndex].rightSidewalkV3[scr.connections[currentIndex].rightSidewalkV3.Count - 1][0];
			scr.prefabScript.sidewalkControlElements[currentIndex].centerHandleV3 = scr.connections[currentIndex].rightSidewalkV3[0][0];
			OCODDDCDQQ(scr, scr.connections[currentIndex].rightSidewalkV3, ref scr.connections[currentIndex].rightSidewalkUV, scr.prefabScript.sidewalkControlElements[currentIndex], reverse: false);
			int index = 0;
			if (scr.connections.Count > currentIndex + 1)
			{
				index = currentIndex + 1;
			}
			OCQDDOCDCQ(scr, scr.connections[currentIndex].leftSidewalkV3, null, scr.prefabScript.sidewalkControlElements[index], 0, 0, -1);
			scr.prefabScript.sidewalkControlElements[index].leftHandleV3 = scr.connections[currentIndex].leftSidewalkV3[scr.connections[currentIndex].leftSidewalkV3.Count - 1][0];
			scr.prefabScript.sidewalkControlElements[index].centerHandleV3_2 = scr.connections[currentIndex].leftSidewalkV3[0][0];
			OCODDDCDQQ(scr, scr.connections[currentIndex].leftSidewalkV3, ref scr.connections[currentIndex].leftSidewalkUV, scr.prefabScript.sidewalkControlElements[index], reverse: true);
		}

		public static void OCDDCCDQDO(ERRoundabouts scr, int currentIndex)
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
			if (num2 >= scr.mainLeftPoints.Count)
			{
				Debug.LogWarning("EasyRoads3Dv3 Warning: Side object data could not be set, please report with Roundabout settings");
				num2 = scr.mainLeftPoints.Count - 1;
			}
			num = scr.connections[currentIndex].rightOuterInt;
			for (int j = num; j <= num2; j++)
			{
				scr.connections[currentIndex].rightSidewalkSourceVecs.Add(scr.mainLeftPoints[j]);
			}
			scr.connections[currentIndex].leftSidewalkSourceVecs.Reverse();
			scr.connections[currentIndex].leftSidewalkV3.Add(new List<Vector3>());
			scr.connections[currentIndex].leftSidewalkV3[0].AddRange(scr.connections[currentIndex].rightSidewalkSourceVecs);
			scr.connections[currentIndex].rightSidewalkV3.Add(new List<Vector3>());
			scr.connections[currentIndex].rightSidewalkV3[0].AddRange(scr.connections[currentIndex].leftSidewalkSourceVecs);
			scr.connections[currentIndex].leftSidewalkSourceVecs.Reverse();
			scr.connections[currentIndex].rightSidewalkSourceVecs.Reverse();
		}

		public static void OCQDDOCDCQ(ERRoundabouts scr, List<List<Vector3>> vecArray, List<List<Vector3>> vecArrayOther, QDOQDSQOOQDDD corner, int startEnd, int mainOrConnected, int outerCornerInt)
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
					vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
				if (corner.beveledDepth != corner.curbDepth)
				{
					num = corner.curbDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
			}
			else
			{
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(ODDCOCQDOQ(vecArray[0], num2));
				num = corner.curbDepth;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
			}
			num = corner.sidewalkWidth1 - corner.curbDepth;
			vecArray.Add(new List<Vector3>());
			vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
			if (corner.beveledCurb && corner.outerCurb)
			{
				if (corner.beveledDepth != corner.curbDepth && corner.beveledDepth > 0f)
				{
					num = corner.sidewalkWidth1 - corner.beveledDepth;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
				if (corner.beveledHeight > 0f && corner.beveledHeight != corner.curbHeight && corner.outerCurb)
				{
					num2 = corner.beveledHeight;
					num = corner.sidewalkWidth1;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
				num2 = 0f;
				num = corner.sidewalkWidth1;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
			}
			else
			{
				num = corner.sidewalkWidth1;
				num2 = corner.curbHeight;
				vecArray.Add(new List<Vector3>());
				vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				if (corner.outerCurb)
				{
					num2 = 0f;
					vecArray.Add(new List<Vector3>());
					vecArray[vecArray.Count - 1].AddRange(OOODQOQDDC(vecArray[0], null, num, num2, startEnd, mainOrConnected, -1));
				}
			}
		}

		public static List<Vector3> OOODQOQDDC(List<Vector3> outer, List<Vector3> outerOther, float dist, float height, int startend, int leftright, int outerCornerInt)
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
						if (!OQQOCDQCQD.OOCQODQDQD(vector, outer[i - 1], vector3))
						{
							vector3 = vector;
						}
					}
					else if (OQQOCDQCQD.OOCQODQDQD(vector, outer[i - 1], vector3))
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

		public static List<Vector3> OCQCDQCQDD(ERRoundabouts scr, List<Vector3> innerArray, List<Vector3> outerOther, float dist, float height, float sidewalkWidth, int startend, int leftright, int outerCornerInt)
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
				Vector3 vector3 = OQQOCDQCQD.OCDCQCDDCC(vector, p, innerArray[i], vector2, flag: false);
				normalized = (innerArray[i] - vector3).normalized;
				vector3 += normalized * dist;
				vector3.y = height;
				list.Add(vector3);
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

		public static void OCODDDCDQQ(ERRoundabouts scr, List<List<Vector3>> vecArray, ref List<List<Vector2>> uvArray, QDOQDSQOOQDDD corner, bool reverse)
		{
			if (corner.sidewalkUVs.Count == 0 || !corner.lockUVs)
			{
				OQDQCOOQCO(vecArray, ref corner.sidewalkUVs);
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

		public static void OCQCDOQCCO(ERRoundabouts scr)
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
			for (int k = 0; k < num2 - 1; k++)
			{
				for (int l = 0; l < num5 - 1; l++)
				{
					innerRoundaboutSidewalTris.Add(k * num5 + l);
					innerRoundaboutSidewalTris.Add((k + 1) * num5 + l + 1);
					innerRoundaboutSidewalTris.Add(k * num5 + l + 1);
					innerRoundaboutSidewalTris.Add((k + 1) * num5 + l);
					innerRoundaboutSidewalTris.Add((k + 1) * num5 + l + 1);
					innerRoundaboutSidewalTris.Add(k * num5 + l);
				}
			}
			for (int m = 0; m < num; m++)
			{
				List<Vector3> obj = innerRoundaboutSidewalkV3;
				int index = m;
				Vector3 value = (innerRoundaboutSidewalkV3[innerRoundaboutSidewalkV3.Count - num + m] = Vector3.Lerp(innerRoundaboutSidewalkV3[m], innerRoundaboutSidewalkV3[innerRoundaboutSidewalkV3.Count - num + m], 0.5f));
				obj[index] = value;
			}
			innerSidewalkSegments = num;
		}

		public static void ODCCCCOQCD(GameObject go)
		{
			Mesh sharedMesh = go.GetComponent<MeshFilter>().sharedMesh;
			if (sharedMesh == null)
			{
				return;
			}
			float num = 1f;
			float num2 = 7.25f;
			Vector2[] array = new Vector2[9]
			{
				new Vector2(0f, 0.51f),
				new Vector2(3.25f, 0.51f),
				new Vector2(5.75f, 0.41f),
				new Vector2(6.625f, 0.38f),
				new Vector2(6.705f, 0.35f),
				new Vector2(6.75f, 0.145f),
				new Vector2(7.14f, 0.145f),
				new Vector2(7.24f, 0.08f),
				new Vector2(7.25f, 0f)
			};
			bool[] array2 = new bool[9] { false, false, false, false, true, true, true, true, false };
			bool[] array3 = new bool[9] { false, false, false, true, true, false, false, false, false };
			bool[] array4 = new bool[9] { false, false, false, false, false, true, false, false, false };
			float num3 = 0.06f;
			float num4 = 0.02f;
			List<float> list = new List<float>();
			float num5 = 0f;
			list.Add(0f);
			for (int i = 1; i < array.Length; i++)
			{
				num5 += Vector2.Distance(array[i], array[i - 1]);
				list.Add(num5);
			}
			for (int j = 0; j < list.Count; j++)
			{
				list[j] /= list[list.Count - 1];
			}
			list[0] = 0f;
			list[1] = 0f;
			list[2] = 0.05f;
			list[3] = 0.05f;
			list[4] = 0.08f;
			list[5] = 0.15f;
			list[6] = 0.254f;
			list[7] = 0.297f;
			list[8] = 0.336f;
			List<float> list2 = new List<float>(list);
			list2[3] = 0.05f;
			list2[4] = 0.084f;
			list2[5] = 0.155f;
			list2[6] = 0.257f;
			list2[7] = 0.305f;
			int num6 = Mathf.RoundToInt(2f * num2 * MathF.PI);
			float num7 = 2f * num2;
			float num8 = 360f / ((float)num6 * 1f) * num;
			float num9 = 0f;
			float num10 = 0f;
			Vector3 zero = Vector3.zero;
			int num11 = 0;
			float num12 = 0f;
			Vector3 zero2;
			Vector3 vector = (zero2 = Vector3.zero);
			float num13 = num2 * 0.5f;
			List<Vector3> list3 = new List<Vector3>();
			while (num10 < 360f + num12)
			{
				zero.x = num2 * Mathf.Cos((0f - num10 + num12) * (MathF.PI / 180f));
				zero.z = num2 * Mathf.Sin((0f - num10 + num12) * (MathF.PI / 180f));
				Vector3 normalized = (zero - Vector3.zero).normalized;
				list3.Add(zero + normalized * num13);
				num10 += num8;
				num11++;
			}
			List<Vector3> list4 = new List<Vector3>();
			List<Vector3> list5 = new List<Vector3>();
			List<Vector2> list6 = new List<Vector2>();
			List<Vector2> list7 = new List<Vector2>();
			List<Color> list8 = new List<Color>();
			Color item = new Color(1f, 1f, 1f, 0f);
			Color item2 = new Color(1f, 1f, 1f, 1f);
			int num14 = 4;
			float num15 = 0.15f;
			float num16 = 3f;
			list4.Add(new Vector3(0f, array[0].y, 0f));
			list6.Add(Vector2.zero);
			list7.Add(new Vector2((0f - num2) / num7 * num16, (0f - num2) / num7 * num16));
			list8.Add(item);
			List<List<int>> list9 = new List<List<int>>();
			for (int k = 0; k < array.Length; k++)
			{
				list9.Add(new List<int>());
			}
			list9[0].Add(0);
			num5 = 0f;
			float num17 = 0f;
			float num18 = 0f;
			float num19 = 0f;
			float num20 = 0f;
			for (int l = 0; l < list3.Count; l++)
			{
				if (l > 0)
				{
					num5 += Vector3.Distance(list3[l], list3[l - 1]);
				}
				float y = num5 * num15;
				Vector3 normalized = list3[l].normalized;
				num17 = UnityEngine.Random.value * num3;
				num18 = UnityEngine.Random.value * num4;
				if (l == 0)
				{
					num19 = num17;
					num20 = num18;
				}
				else if (l == list3.Count - 1)
				{
					num17 = num19;
					num18 = num20;
				}
				for (int m = 1; m < array.Length; m++)
				{
					if ((m != 1 || Mathf.Round((float)l * 0.25f) == (float)l * 0.25f) && (m != 2 || Mathf.Round((float)l * 0.5f) == (float)l * 0.5f))
					{
						Vector3 item3 = normalized * array[m].x;
						item3.y = array[m].y;
						if (array3[m])
						{
							item3.y -= num17;
						}
						if (array4[m])
						{
							item3.y += num18;
						}
						list4.Add(item3);
						list6.Add(new Vector2(list[m], y));
						list7.Add(new Vector2((item3.x - num2) / num7 * num16, (item3.z - num2) / num7 * num16));
						if (m == array.Length - 1)
						{
							list5.Add(item3);
						}
						if (m < num14)
						{
							list8.Add(item);
						}
						else
						{
							list8.Add(item2);
						}
						list9[m].Add(list4.Count - 1);
					}
				}
			}
			Debug.Log(list6[list6.Count - 1]);
			if (true)
			{
				float num21 = Mathf.Round(list6[list6.Count - 1].y) / list6[list6.Count - 1].y;
				for (int n = 0; n < list6.Count; n++)
				{
					Vector2 value = list6[n];
					value.y *= num21;
					list6[n] = value;
				}
			}
			List<ERCell> cEdges = new List<ERCell>();
			list5.Add(list5[0]);
			List<int> list10 = OQQOCDQCQDExt.OOQOQOCODD(list4, list5, cEdges);
			float num22 = 0f;
			float num23 = 0f;
			float num24 = 0f;
			float num25 = 0f;
			float num26 = 0f;
			float num27 = 0f;
			int num28 = 0;
			int num29 = 0;
			for (int num30 = 0; num30 < array2.Length - 1; num30++)
			{
				if (!array2[num30])
				{
					continue;
				}
				float num31 = Mathf.Round(array[num30].x * 1000f);
				for (int num32 = 0; num32 < list10.Count; num32 += 3)
				{
					num22 = Vector3.Distance(new Vector3(list4[list10[num32]].x, 0f, list4[list10[num32]].z), Vector3.zero);
					num23 = Vector3.Distance(new Vector3(list4[list10[num32 + 1]].x, 0f, list4[list10[num32 + 1]].z), Vector3.zero);
					num24 = Vector3.Distance(new Vector3(list4[list10[num32 + 2]].x, 0f, list4[list10[num32 + 2]].z), Vector3.zero);
					Vector2 value;
					if (list9[num30].Contains(list10[num32]))
					{
						num28 = GetMatchingVertex(list10[num32], list4[list10[num32]], list4);
						num29 = list10[num32];
						if (num28 == -1)
						{
							list4.Add(list4[list10[num32]]);
							num28 = list4.Count - 1;
							value = list6[list10[num32]];
							value.x = list2[num30];
							list6.Add(value);
							list7.Add(list7[list10[num32]]);
							list8.Add(list8[list10[num32]]);
							for (int num33 = 0; num33 < list10.Count; num33 += 3)
							{
								num25 = Vector3.Distance(new Vector3(list4[list10[num33]].x, 0f, list4[list10[num33]].z), Vector3.zero);
								num26 = Vector3.Distance(new Vector3(list4[list10[num33 + 1]].x, 0f, list4[list10[num33 + 1]].z), Vector3.zero);
								num27 = Vector3.Distance(new Vector3(list4[list10[num33 + 2]].x, 0f, list4[list10[num33 + 2]].z), Vector3.zero);
								if (list10[num33] == num29 && (num26 > num31 || num27 > num31))
								{
									list10[num33] = num28;
								}
								if (list10[num33 + 1] == num29 && (num25 > num31 || num27 > num31))
								{
									list10[num33 + 1] = num28;
								}
								if (list10[num33 + 2] == num29 && (num25 > num31 || num26 > num31))
								{
									list10[num33 + 2] = num28;
								}
							}
						}
					}
					if (list9[num30].Contains(list10[num32 + 1]))
					{
						num28 = GetMatchingVertex(list10[num32 + 1], list4[list10[num32 + 1]], list4);
						num29 = list10[num32 + 1];
						if (num28 == -1)
						{
							list4.Add(list4[list10[num32 + 1]]);
							num28 = list4.Count - 1;
							value = list6[list10[num32 + 1]];
							value.x = list2[num30];
							list6.Add(value);
							list7.Add(list7[list10[num32 + 1]]);
							list8.Add(list8[list10[num32 + 1]]);
							for (int num34 = 0; num34 < list10.Count; num34 += 3)
							{
								num25 = Mathf.Round(Vector3.Distance(new Vector3(list4[list10[num34]].x, 0f, list4[list10[num34]].z), Vector3.zero) * 1000f);
								num26 = Mathf.Round(Vector3.Distance(new Vector3(list4[list10[num34 + 1]].x, 0f, list4[list10[num34 + 1]].z), Vector3.zero) * 1000f);
								num27 = Mathf.Round(Vector3.Distance(new Vector3(list4[list10[num34 + 2]].x, 0f, list4[list10[num34 + 2]].z), Vector3.zero) * 1000f);
								if (list10[num34] == num29 && (num26 > num31 || num27 > num31))
								{
									list10[num34] = num28;
								}
								if (list10[num34 + 1] == num29 && (num25 > num31 || num27 > num31))
								{
									list10[num34 + 1] = num28;
								}
								if (list10[num34 + 2] == num29 && (num25 > num31 || num26 > num31))
								{
									list10[num34 + 2] = num28;
								}
							}
						}
					}
					if (!list9[num30].Contains(list10[num32 + 2]))
					{
						continue;
					}
					num28 = GetMatchingVertex(list10[num32 + 2], list4[list10[num32 + 2]], list4);
					num29 = list10[num32 + 2];
					if (num28 != -1)
					{
						continue;
					}
					list4.Add(list4[list10[num32 + 2]]);
					num28 = list4.Count - 1;
					value = list6[list10[num32 + 2]];
					value.x = list2[num30];
					list6.Add(value);
					list7.Add(list7[list10[num32 + 2]]);
					list8.Add(list8[list10[num32 + 2]]);
					for (int num35 = 0; num35 < list10.Count; num35 += 3)
					{
						num25 = Mathf.Round(Vector3.Distance(new Vector3(list4[list10[num35]].x, 0f, list4[list10[num35]].z), Vector3.zero) * 1000f);
						num26 = Mathf.Round(Vector3.Distance(new Vector3(list4[list10[num35 + 1]].x, 0f, list4[list10[num35 + 1]].z), Vector3.zero) * 1000f);
						num27 = Mathf.Round(Vector3.Distance(new Vector3(list4[list10[num35 + 2]].x, 0f, list4[list10[num35 + 2]].z), Vector3.zero) * 1000f);
						if (list10[num35] == num29 && (num26 > num31 || num27 > num31))
						{
							list10[num35] = num28;
						}
						if (list10[num35 + 1] == num29 && (num25 > num31 || num27 > num31))
						{
							list10[num35 + 1] = num28;
						}
						if (list10[num35 + 2] == num29 && (num25 > num31 || num26 > num31))
						{
							list10[num35 + 2] = num28;
						}
					}
				}
			}
			sharedMesh = new Mesh();
			go.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
			sharedMesh.Clear();
			sharedMesh.vertices = list4.ToArray();
			sharedMesh.uv = list7.ToArray();
			sharedMesh.uv4 = list6.ToArray();
			sharedMesh.colors = list8.ToArray();
			sharedMesh.triangles = list10.ToArray();
			sharedMesh.RecalculateBounds();
			sharedMesh.RecalculateNormals();
			sharedMesh.RecalculateTangents();
		}

		public static int GetMatchingVertex(int _index, Vector3 v, List<Vector3> vecs)
		{
			int result = -1;
			for (int i = 0; i < vecs.Count; i++)
			{
				if (vecs[i] == v && i != _index)
				{
					return i;
				}
			}
			return result;
		}
	}
}
