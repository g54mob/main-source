using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OQQOOODQDQ : MonoBehaviour
	{
		public static void OCDQODDQOC(ref int startInt, float startOffset, ref List<int> markerInts, ref List<Vector3> vecPositions, ref List<Vector3> soSplinePointLeft, List<Vector3> soSplinePointRight, ref ERSOMarkerExt soMarker, ERModularRoad roadScr, ref List<List<Vector2>> nodeList)
		{
			soMarker.curStartInt = startInt;
			float num = 0f;
			float num2 = 0f;
			if (startOffset >= 0f)
			{
				for (int i = startInt + 1; i < vecPositions.Count; i++)
				{
					num = Vector3.Distance(vecPositions[i - 1], vecPositions[i]);
					if (num2 + num > startOffset)
					{
						float t = (startOffset - num2) / num;
						Vector3 vector = Vector3.Lerp(vecPositions[i - 1], vecPositions[i], t);
						Vector3 item = Vector3.Lerp(soSplinePointLeft[i - 1], soSplinePointLeft[i], t);
						Vector3 item2 = Vector3.Lerp(soSplinePointRight[i - 1], soSplinePointRight[i], t);
						for (int j = 0; j < nodeList.Count; j++)
						{
							Vector2 item3 = Vector2.Lerp(nodeList[j][i - 1], nodeList[j][i], t);
							nodeList[j].Insert(i, item3);
						}
						vecPositions.Insert(i, vector);
						soSplinePointLeft.Insert(i, item);
						soSplinePointRight.Insert(i, item2);
						markerInts.Insert(i, markerInts[i]);
						startInt = i;
						soMarker.startOffsetV3 = vector;
						Vector3 vector2 = vector;
						Vector3 vector3 = vecPositions[i - 1];
						if (vector2 == vector3)
						{
							vector2 = vecPositions[i];
						}
						if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
						{
							soMarker.startOffsetV3.y = OCQCDQCQOQ.OOOQQOODDD(soMarker.startOffsetV3, roadScr.baseScript);
							vector2.y = OCQCDQCQOQ.OOOQQOODDD(vector2, roadScr.baseScript);
							vector3.y = OCQCDQCQOQ.OOOQQOODDD(vector3, roadScr.baseScript);
						}
						Vector3 startOffsetDir = soMarker.startOffsetDir;
						soMarker.startOffsetDir = (vector2 - vector3).normalized;
						soMarker.startOffsetDir = new Vector3(soMarker.startOffsetDir.x, 0f, soMarker.startOffsetDir.z).normalized;
						if (soMarker.startOffsetDir == Vector3.zero)
						{
							soMarker.startOffsetDir = startOffsetDir;
						}
						soMarker.startOffsetV3nb = soSplinePointLeft[i];
						break;
					}
					num2 += num;
				}
				return;
			}
			startOffset *= -1f;
			int num3 = markerInts[startInt];
			for (int i = startInt; i > 0; i--)
			{
				num = Vector3.Distance(vecPositions[i - 1], vecPositions[i]);
				if (num2 + num > startOffset)
				{
					float t = (startOffset - num2) / num;
					Vector3 vector = Vector3.Lerp(vecPositions[i], vecPositions[i - 1], t);
					Vector3 item = Vector3.Lerp(soSplinePointLeft[i], soSplinePointLeft[i - 1], t);
					Vector3 item2 = Vector3.Lerp(soSplinePointRight[i], soSplinePointRight[i - 1], t);
					for (int j = 0; j < nodeList.Count; j++)
					{
						Vector2 item3 = Vector2.Lerp(nodeList[j][i], nodeList[j][i - 1], t);
						nodeList[j].Insert(i, item3);
					}
					vecPositions.Insert(i, vector);
					soSplinePointLeft.Insert(i, item);
					soSplinePointRight.Insert(i, item2);
					markerInts[i] = num3;
					markerInts.Insert(i, num3);
					soMarker.startOffsetV3 = vector;
					Vector3 vector2 = vector;
					Vector3 vector3 = vecPositions[i + 1];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						soMarker.startOffsetV3.y = OCQCDQCQOQ.OOOQQOODDD(soMarker.startOffsetV3, roadScr.baseScript);
						vector2.y = OCQCDQCQOQ.OOOQQOODDD(vector2, roadScr.baseScript);
						vector3.y = OCQCDQCQOQ.OOOQQOODDD(vector3, roadScr.baseScript);
					}
					soMarker.startOffsetDir = (vector2 - vector3).normalized;
					soMarker.startOffsetDir = new Vector3(soMarker.startOffsetDir.x, 0f, soMarker.startOffsetDir.z).normalized;
					soMarker.startOffsetV3nb = soSplinePointLeft[i];
					soMarker.curStartInt++;
					startInt = i;
					break;
				}
				num2 += num;
				markerInts[i] = num3;
			}
		}

		public static void OOOCQOCCQQ(int startInt, float endOffset, ref List<int> markerInts, ref List<Vector3> vecPositions, ref List<Vector3> soSplinePointLeft, List<Vector3> soSplinePointRight, ref ERSOMarkerExt soMarker, ERModularRoad roadScr, ref List<List<Vector2>> nodeList)
		{
			int num = markerInts[startInt];
			int num2 = 0;
			for (int i = startInt + 1; i < vecPositions.Count; i++)
			{
				if (num != markerInts[i])
				{
					num2 = i;
					break;
				}
			}
			if (num2 == 0)
			{
				num2 = vecPositions.Count - 1;
			}
			soMarker.curEndInt = num2;
			float num3 = 0f;
			float num4 = 0f;
			if (endOffset < 0f)
			{
				endOffset *= -1f;
				for (int i = num2; i > 0; i--)
				{
					num3 = Vector3.Distance(vecPositions[i - 1], vecPositions[i]);
					if (num4 + num3 > endOffset)
					{
						float t = (endOffset - num4) / num3;
						Vector3 vector = Vector3.Lerp(vecPositions[i], vecPositions[i - 1], t);
						Vector3 item = Vector3.Lerp(soSplinePointLeft[i], soSplinePointLeft[i - 1], t);
						Vector3 item2 = Vector3.Lerp(soSplinePointRight[i], soSplinePointRight[i - 1], t);
						for (int j = 0; j < nodeList.Count; j++)
						{
							Vector2 item3 = Vector2.Lerp(nodeList[j][i], nodeList[j][i - 1], t);
							nodeList[j].Insert(i, item3);
						}
						vecPositions.Insert(i, vector);
						soSplinePointLeft.Insert(i, item);
						soSplinePointRight.Insert(i, item2);
						markerInts[i] = num + 1;
						markerInts.Insert(i, num + 1);
						Vector3 vector2 = vector;
						Vector3 vector3 = vecPositions[i - 1];
						soMarker.endOffsetV3 = vector;
						if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
						{
							soMarker.endOffsetV3.y = OCQCDQCQOQ.OOOQQOODDD(soMarker.endOffsetV3, roadScr.baseScript);
							vector2.y = OCQCDQCQOQ.OOOQQOODDD(vector2, roadScr.baseScript);
							vector3.y = OCQCDQCQOQ.OOOQQOODDD(vector3, roadScr.baseScript);
						}
						soMarker.endOffsetDir = (vector2 - vector3).normalized;
						soMarker.endOffsetV3nb = vecPositions[i];
						soMarker.curEndInt++;
						break;
					}
					num4 += num3;
					markerInts[i] = num + 1;
				}
				return;
			}
			for (int i = num2; i < vecPositions.Count - 1; i++)
			{
				num3 = Vector3.Distance(vecPositions[i], vecPositions[i + 1]);
				if (num4 + num3 > endOffset)
				{
					float t = (endOffset - num4) / num3;
					Vector3 vector = Vector3.Lerp(vecPositions[i], vecPositions[i + 1], t);
					Vector3 item = Vector3.Lerp(soSplinePointLeft[i], soSplinePointLeft[i + 1], t);
					Vector3 item2 = Vector3.Lerp(soSplinePointRight[i], soSplinePointRight[i + 1], t);
					for (int j = 0; j < nodeList.Count; j++)
					{
						Vector2 item3 = Vector2.Lerp(nodeList[j][i], nodeList[j][i + 1], t);
						nodeList[j].Insert(i, item3);
					}
					vecPositions.Insert(i + 1, vector);
					soSplinePointLeft.Insert(i + 1, item);
					soSplinePointRight.Insert(i + 1, item2);
					markerInts[i] = num;
					markerInts.Insert(i + 1, num + 1);
					soMarker.endOffsetV3 = vector;
					Vector3 vector2 = vector;
					Vector3 vector3 = vecPositions[i];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						soMarker.endOffsetV3.y = OCQCDQCQOQ.OOOQQOODDD(soMarker.endOffsetV3, roadScr.baseScript);
						vector2.y = OCQCDQCQOQ.OOOQQOODDD(vector2, roadScr.baseScript);
						vector3.y = OCQCDQCQOQ.OOOQQOODDD(vector3, roadScr.baseScript);
					}
					soMarker.endOffsetDir = (vector2 - vector3).normalized;
					soMarker.startOffsetV3nb = vecPositions[i];
					break;
				}
				markerInts[i] = num;
				num4 += num3;
			}
		}

		public static bool MoveDirection(ERModularRoad road, ERSOMarkerExt markerSO, Vector3 v)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < road.soDataExt.Count; i++)
			{
				if (road.soDataExt[i].id == markerSO.id)
				{
					list = road.soDataExt[i].vecPositions;
				}
			}
			bool result = false;
			if (list.Count > 0 && markerSO.curStartInt != -1)
			{
				float num2;
				float num = (num2 = 0f);
				float num3 = Vector3.Distance(list[markerSO.curStartInt], v);
				if (markerSO.curStartInt > 0)
				{
					num = Vector3.Distance(list[markerSO.curStartInt - 1], v);
					if (num3 < num)
					{
						result = true;
					}
				}
				else if (markerSO.curStartInt < list.Count - 1)
				{
					num2 = Vector3.Distance(list[markerSO.curStartInt + 1], v);
					if (num3 >= num2)
					{
						result = true;
					}
				}
			}
			return result;
		}

		public static void OCCODQOODQ(ERModularRoad road, ERSOMarkerExt markerSO, Vector3 v, Camera cam, ref int xDir, ref int yDir)
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0f;
			float num2 = 0f;
			float num3 = 10000f;
			int num4 = -1;
			float num5 = 10000f;
			for (int i = 0; i < road.soDataExt.Count; i++)
			{
				if (road.soDataExt[i].id != markerSO.id)
				{
					continue;
				}
				list = road.soDataExt[i].vecPositions;
				if (list.Count <= 1)
				{
					continue;
				}
				for (int j = 0; j < list.Count; j++)
				{
					float num6 = Vector3.Distance(list[j], v);
					if (num5 > num6)
					{
						num5 = num6;
						num4 = j;
					}
				}
				Vector3 vector = cam.WorldToScreenPoint(list[num4]);
				Vector3 vector2 = cam.WorldToScreenPoint(list[num4 + 1]);
				if (vector.x > vector2.x)
				{
					xDir = 1;
				}
				else
				{
					xDir = -1;
				}
				if (vector.y > vector2.y)
				{
					yDir = -1;
				}
				else
				{
					yDir = 1;
				}
			}
		}

		public static void OOCQDODDDQ(ERModularRoad road, ERSOMarkerExt markerSO, Vector3 v, Vector3 vOld, float movement)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < road.soDataExt.Count; i++)
			{
				if (road.soDataExt[i].id == markerSO.id)
				{
					list = road.soDataExt[i].vecPositions;
				}
			}
			if (list.Count > 0 && markerSO.curStartInt != -1)
			{
				float num2;
				float num = (num2 = 0f);
				float num3 = Vector3.Distance(list[markerSO.curStartInt], v);
				bool flag = false;
				if (markerSO.curStartInt > 0)
				{
					num = Vector3.Distance(list[markerSO.curStartInt - 1], v);
					if (num3 < num)
					{
						flag = true;
					}
				}
				else if (markerSO.curStartInt < list.Count - 1)
				{
					num2 = Vector3.Distance(list[markerSO.curStartInt + 1], v);
					if (num3 >= num2)
					{
						flag = true;
					}
				}
				float num4 = 0f;
				if (flag)
				{
					if (markerSO.curStartInt < list.Count - 1)
					{
						for (int i = markerSO.curStartInt; i < list.Count - 1; i++)
						{
							float num5 = Vector3.Distance(list[i], v);
							float num6 = Vector3.Distance(list[i], list[i + 1]);
							if (num5 < num6)
							{
								markerSO.startOffset = num4 + num5;
								break;
							}
							num4 += num6;
						}
					}
					else
					{
						markerSO.startOffset = 0f;
					}
				}
				else if (markerSO.curStartInt > 0)
				{
					for (int i = markerSO.curStartInt; i > 0; i--)
					{
						float num5 = Vector3.Distance(list[i], v);
						float num6 = Vector3.Distance(list[i], list[i - 1]);
						if (num5 < num6)
						{
							markerSO.startOffset = (num4 + num5) * -1f;
							break;
						}
						num4 += num6;
					}
				}
				else
				{
					markerSO.startOffset = 0f;
				}
			}
			else
			{
				markerSO.startOffset = -0.01f;
			}
		}

		public static void ODQCCCQCDC(ERModularRoad road, ERSOMarkerExt markerSO, Vector3 v)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < road.soDataExt.Count; i++)
			{
				if (road.soDataExt[i].id == markerSO.id)
				{
					list = road.soDataExt[i].vecPositions;
				}
			}
			if (markerSO.curEndInt >= list.Count)
			{
				markerSO.curEndInt = list.Count - 1;
			}
			if (list.Count > 0 && markerSO.curEndInt != -1)
			{
				float num2;
				float num = (num2 = 0f);
				float num3 = Vector3.Distance(list[markerSO.curEndInt], v);
				bool flag = false;
				if (markerSO.curEndInt > 0)
				{
					num = Vector3.Distance(list[markerSO.curEndInt - 1], v);
					if (num3 < num)
					{
						flag = true;
					}
				}
				else if (markerSO.curEndInt < list.Count - 1)
				{
					num2 = Vector3.Distance(list[markerSO.curEndInt + 1], v);
					if (num3 > num2)
					{
						flag = true;
					}
				}
				float num4 = 0f;
				if (flag)
				{
					if (markerSO.curEndInt < list.Count - 1)
					{
						for (int i = markerSO.curEndInt; i < list.Count - 1; i++)
						{
							float num5 = Vector3.Distance(list[i], v);
							float num6 = Vector3.Distance(list[i], list[i + 1]);
							if (num5 < num6)
							{
								markerSO.endOffset = num4 + num5;
								break;
							}
							num4 += num6;
						}
					}
					else
					{
						markerSO.endOffset = 0f;
					}
				}
				else if (markerSO.curEndInt < list.Count)
				{
					for (int i = markerSO.curEndInt; i > 0; i--)
					{
						float num5 = Vector3.Distance(list[i], v);
						float num6 = Vector3.Distance(list[i], list[i - 1]);
						if (num5 < num6)
						{
							markerSO.endOffset = (num4 + num5) * -1f;
							break;
						}
						num4 += num6;
					}
				}
				else
				{
					markerSO.endOffset = 0f;
				}
			}
			else
			{
				markerSO.endOffset = -0.01f;
			}
		}

		public static void OOODQDDDOQ(int startInt, List<Vector3> vecPositions, List<int> markersInts, ref ERSOMarkerExt soMarker, bool startFlag, ERModularRoad roadScr)
		{
			if (startFlag)
			{
				soMarker.startOffsetV3 = vecPositions[startInt];
				if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
				{
					soMarker.startOffsetV3.y = OCQCDQCQOQ.OOOQQOODDD(soMarker.startOffsetV3, roadScr.baseScript);
				}
				Vector3 vector;
				Vector3 vector2;
				if (startInt == 0)
				{
					vector = vecPositions[startInt + 1];
					vector2 = vecPositions[startInt];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						vector.y = OCQCDQCQOQ.OOOQQOODDD(vector, roadScr.baseScript);
						vector2.y = OCQCDQCQOQ.OOOQQOODDD(vector2, roadScr.baseScript);
					}
				}
				else
				{
					vector = vecPositions[startInt];
					vector2 = vecPositions[startInt - 1];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						vector.y = OCQCDQCQOQ.OOOQQOODDD(vector, roadScr.baseScript);
						vector2.y = OCQCDQCQOQ.OOOQQOODDD(vector2, roadScr.baseScript);
					}
				}
				soMarker.startOffsetDir = (vector - vector2).normalized;
				return;
			}
			int num = markersInts[startInt];
			for (int i = startInt + 1; i < vecPositions.Count; i++)
			{
				if (num != markersInts[i] || i == vecPositions.Count - 1)
				{
					soMarker.endOffsetV3 = vecPositions[i];
					Vector3 vector = vecPositions[i];
					Vector3 vector2 = vecPositions[i - 1];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						soMarker.endOffsetV3.y = OCQCDQCQOQ.OOOQQOODDD(soMarker.endOffsetV3, roadScr.baseScript);
						vector.y = OCQCDQCQOQ.OOOQQOODDD(vector, roadScr.baseScript);
						vector2.y = OCQCDQCQOQ.OOOQQOODDD(vector2, roadScr.baseScript);
					}
					soMarker.endOffsetDir = (vector - vector2).normalized;
					break;
				}
			}
		}

		public static void SynchSoData(ERSORoadExt soData, bool flag)
		{
			if (!soData.xPosChange || flag)
			{
				soData.xPosition = soData.sideObject.xPosition;
			}
			if (!soData.randomXPositionChange || flag)
			{
				soData.randomMinXPosition = soData.sideObject.randomMinXPosition;
				soData.randomMaxXPosition = soData.sideObject.randomMaxXPosition;
			}
			if (!soData.xPositionDistanceChange || flag)
			{
				soData.minRandomXPositionDistance = soData.sideObject.minRandomXPositionDistance;
				soData.maxRandomXPositionDistance = soData.sideObject.maxRandomXPositionDistance;
			}
			if (!soData.randomYPositionChange || flag)
			{
				soData.randomMinYPosition = soData.sideObject.randomMinYPosition;
				soData.randomMaxYPosition = soData.sideObject.randomMaxYPosition;
			}
			if (!soData.yPositionDistanceChange || flag)
			{
				soData.minRandomYPositionDistance = soData.sideObject.minRandomYPositionDistance;
				soData.maxRandomYPositionDistance = soData.sideObject.maxRandomYPositionDistance;
			}
			if (!soData.yPosChange || flag)
			{
				soData.yPosition = soData.sideObject.yPosition;
			}
			if (!soData.rotationAngleChange || flag)
			{
				soData.randomMinRotation = soData.sideObject.randomMinRotation;
				soData.randomMaxRotation = soData.sideObject.randomMaxRotation;
			}
			if (!soData.rotationDistanceChange || flag)
			{
				soData.minRandomRotationDistance = soData.sideObject.minRandomRotationDistance;
				soData.maxRandomRotationDistance = soData.sideObject.maxRandomRotationDistance;
			}
		}

		public static void CopySoData(ERSORoadExt soData, ERSORoadExt source)
		{
			soData.xPosition = source.xPosition;
			soData.yPosition = source.yPosition;
			soData.randomMinRotation = source.randomMinRotation;
			soData.randomMaxRotation = source.randomMaxRotation;
			soData.minRandomRotationDistance = source.minRandomRotationDistance;
			soData.maxRandomRotationDistance = source.maxRandomRotationDistance;
			soData.xPosChange = source.xPosChange;
			soData.yPosChange = source.yPosChange;
			soData.rotationAngleChange = source.rotationAngleChange;
			soData.rotationDistanceChange = source.rotationDistanceChange;
			soData.xPositionDistanceChange = source.xPositionDistanceChange;
			soData.randomXPosition = source.randomXPosition;
			soData.randomMinXPosition = source.randomMinXPosition;
			soData.randomMaxXPosition = source.randomMaxXPosition;
			soData.minRandomXPositionDistance = source.minRandomXPositionDistance;
			soData.maxRandomXPositionDistance = source.maxRandomXPositionDistance;
			soData.yPositionDistanceChange = source.yPositionDistanceChange;
			soData.randomYPosition = source.randomYPosition;
			soData.randomMinYPosition = source.randomMinYPosition;
			soData.randomMaxYPosition = source.randomMaxYPosition;
			soData.minRandomYPositionDistance = source.minRandomYPositionDistance;
			soData.maxRandomYPositionDistance = source.maxRandomYPositionDistance;
		}

		public static void UnlockSORotation(List<ERSORoadExt> soDataList)
		{
			foreach (ERSORoadExt soData in soDataList)
			{
				soData.lockRandomRotations = false;
			}
		}

		public static void CheckMarkerSOData(SideObject so, ERModularRoad road)
		{
		}

		public static void ResetMarkerSOData(ERModularRoad road)
		{
			foreach (ERSORoadExt item in road.soDataExt)
			{
				if (!item.active)
				{
					continue;
				}
				int num = 0;
				foreach (ERMarkerExt item2 in road.markersExt)
				{
					int num2 = -1;
					int num3 = 0;
					bool flag = false;
					foreach (ERSOMarkerExt soDatum in item2.soData)
					{
						if (soDatum == null)
						{
							num2 = num3;
						}
						else if (soDatum.id == item.id)
						{
							flag = true;
							break;
						}
						num3++;
					}
					if (!flag && num2 != -1)
					{
						item2.soData[num2] = ERSOMarkerExt.CreateInstance(item.sideObject, flag: true);
					}
					num++;
				}
			}
		}

		public static void OQCCQDQDQQ(ERModularBase scr, SideObject so, GameObject go)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			if ((double)so.snapWeightList[0] > 0.99)
			{
				list.Add(0);
			}
			else if ((double)so.snapWeightList[0] >= 0.95)
			{
				list2.Add(0);
			}
			if ((double)so.snapWeightList[so.snapWeightList.Count - 1] > 0.99)
			{
				list.Add(so.snapWeightList.Count - 1);
			}
			else if ((double)so.snapWeightList[so.snapWeightList.Count - 1] >= 0.95)
			{
				list2.Add(so.snapWeightList.Count - 1);
			}
			if (list.Count == 0 && list2.Count == 0)
			{
				return;
			}
			List<GameObject> list3 = new List<GameObject>();
			list3.Add(go);
			foreach (Transform item in go.transform)
			{
				if (item.name.IndexOf(" Batch ") != -1)
				{
					list3.Add(item.gameObject);
				}
			}
			foreach (GameObject item2 in list3)
			{
				if (!(item2.GetComponent<MeshFilter>() != null))
				{
					continue;
				}
				Mesh sharedMesh = item2.GetComponent<MeshFilter>().sharedMesh;
				int count = so.nodeList.Count;
				Vector3[] vertices = sharedMesh.vertices;
				Vector3[] normals = sharedMesh.normals;
				if ((float)vertices.Length * 1f / ((float)count * 1f) != (float)(vertices.Length / count))
				{
					continue;
				}
				for (int i = 0; i < vertices.Length; i += count)
				{
					for (int j = 0; j < list.Count; j++)
					{
						Vector3 pos = vertices[i + list[j]];
						scr.OCCDCQCOQC(ref pos);
						vertices[i + list[j]] = pos;
						ref Vector3 reference = ref normals[i + list[j]];
						reference = scr.ODQQCDQCQO(pos);
					}
					for (int j = 0; j < list2.Count; j++)
					{
						Vector3 pos = vertices[i + list2[j]];
						ref Vector3 reference2 = ref normals[i + list2[j]];
						reference2 = scr.ODQQCDQCQO(pos);
					}
				}
				sharedMesh.vertices = vertices;
				sharedMesh.normals = normals;
				if (item2.GetComponent<MeshCollider>() != null)
				{
					item2.GetComponent<MeshCollider>().sharedMesh = null;
					item2.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
				}
			}
		}
	}
}
