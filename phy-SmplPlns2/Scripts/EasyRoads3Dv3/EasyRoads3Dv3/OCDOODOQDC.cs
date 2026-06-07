using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OCDOODOQDC : MonoBehaviour
	{
		public static void OQCQOCQCDC(ref int startInt, float startOffset, ref List<int> markerInts, ref List<Vector3> vecPositions, ref List<Vector3> soSplinePointCenter, ref List<Vector3> soSplinePointLeft, List<Vector3> soSplinePointRight, ref ERSOMarkerExt soMarker, ERModularRoad roadScr, ref List<List<Vector2>> nodeList)
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
						Vector3 item3 = Vector3.Lerp(soSplinePointCenter[i - 1], soSplinePointCenter[i], t);
						for (int j = 0; j < nodeList.Count; j++)
						{
							Vector2 item4 = Vector2.Lerp(nodeList[j][i - 1], nodeList[j][i], t);
							nodeList[j].Insert(i, item4);
						}
						vecPositions.Insert(i, vector);
						soSplinePointLeft.Insert(i, item);
						soSplinePointRight.Insert(i, item2);
						soSplinePointCenter.Insert(i, item3);
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
							soMarker.startOffsetV3.y = OQQOCDQCQD.OQDODCCCCQ(soMarker.startOffsetV3, roadScr.baseScript);
							vector2.y = OQQOCDQCQD.OQDODCCCCQ(vector2, roadScr.baseScript);
							vector3.y = OQQOCDQCQD.OQDODCCCCQ(vector3, roadScr.baseScript);
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
			for (int num4 = startInt; num4 > 0; num4--)
			{
				num = Vector3.Distance(vecPositions[num4 - 1], vecPositions[num4]);
				if (num2 + num > startOffset)
				{
					float t = (startOffset - num2) / num;
					Vector3 vector = Vector3.Lerp(vecPositions[num4], vecPositions[num4 - 1], t);
					Vector3 item = Vector3.Lerp(soSplinePointLeft[num4], soSplinePointLeft[num4 - 1], t);
					Vector3 item2 = Vector3.Lerp(soSplinePointRight[num4], soSplinePointRight[num4 - 1], t);
					Vector3 item3 = Vector3.Lerp(soSplinePointCenter[num4], soSplinePointCenter[num4 - 1], t);
					for (int k = 0; k < nodeList.Count; k++)
					{
						Vector2 item4 = Vector2.Lerp(nodeList[k][num4], nodeList[k][num4 - 1], t);
						nodeList[k].Insert(num4, item4);
					}
					vecPositions.Insert(num4, vector);
					soSplinePointLeft.Insert(num4, item);
					soSplinePointRight.Insert(num4, item2);
					soSplinePointCenter.Insert(num4, item3);
					markerInts[num4] = num3;
					markerInts.Insert(num4, num3);
					soMarker.startOffsetV3 = vector;
					Vector3 vector2 = vector;
					Vector3 vector3 = vecPositions[num4 + 1];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						soMarker.startOffsetV3.y = OQQOCDQCQD.OQDODCCCCQ(soMarker.startOffsetV3, roadScr.baseScript);
						vector2.y = OQQOCDQCQD.OQDODCCCCQ(vector2, roadScr.baseScript);
						vector3.y = OQQOCDQCQD.OQDODCCCCQ(vector3, roadScr.baseScript);
					}
					soMarker.startOffsetDir = (vector2 - vector3).normalized;
					soMarker.startOffsetDir = new Vector3(soMarker.startOffsetDir.x, 0f, soMarker.startOffsetDir.z).normalized;
					soMarker.startOffsetV3nb = soSplinePointLeft[num4];
					soMarker.curStartInt++;
					startInt = num4;
					break;
				}
				num2 += num;
				markerInts[num4] = num3;
			}
		}

		public static void ODCCCCOOCQ(int startInt, float endOffset, ref List<int> markerInts, ref List<Vector3> vecPositions, ref List<Vector3> soSplinePointCenter, ref List<Vector3> soSplinePointLeft, List<Vector3> soSplinePointRight, ref ERSOMarkerExt soMarker, ERModularRoad roadScr, ref List<List<Vector2>> nodeList)
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
				for (int num5 = num2; num5 > 0; num5--)
				{
					num3 = Vector3.Distance(vecPositions[num5 - 1], vecPositions[num5]);
					if (num4 + num3 > endOffset)
					{
						float t = (endOffset - num4) / num3;
						Vector3 vector = Vector3.Lerp(vecPositions[num5], vecPositions[num5 - 1], t);
						Vector3 item = Vector3.Lerp(soSplinePointLeft[num5], soSplinePointLeft[num5 - 1], t);
						Vector3 item2 = Vector3.Lerp(soSplinePointRight[num5], soSplinePointRight[num5 - 1], t);
						Vector3 item3 = Vector3.Lerp(soSplinePointCenter[num5], soSplinePointCenter[num5 - 1], t);
						for (int j = 0; j < nodeList.Count; j++)
						{
							Vector2 item4 = Vector2.Lerp(nodeList[j][num5], nodeList[j][num5 - 1], t);
							nodeList[j].Insert(num5, item4);
						}
						vecPositions.Insert(num5, vector);
						soSplinePointLeft.Insert(num5, item);
						soSplinePointRight.Insert(num5, item2);
						soSplinePointCenter.Insert(num5, item3);
						markerInts[num5] = num + 1;
						markerInts.Insert(num5, num + 1);
						Vector3 vector2 = vector;
						Vector3 vector3 = vecPositions[num5 - 1];
						soMarker.endOffsetV3 = vector;
						if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
						{
							soMarker.endOffsetV3.y = OQQOCDQCQD.OQDODCCCCQ(soMarker.endOffsetV3, roadScr.baseScript);
							vector2.y = OQQOCDQCQD.OQDODCCCCQ(vector2, roadScr.baseScript);
							vector3.y = OQQOCDQCQD.OQDODCCCCQ(vector3, roadScr.baseScript);
						}
						soMarker.endOffsetDir = (vector2 - vector3).normalized;
						soMarker.endOffsetV3nb = vecPositions[num5];
						soMarker.curEndInt++;
						break;
					}
					num4 += num3;
					markerInts[num5] = num + 1;
				}
				return;
			}
			for (int k = num2; k < vecPositions.Count - 1; k++)
			{
				num3 = Vector3.Distance(vecPositions[k], vecPositions[k + 1]);
				if (num4 + num3 > endOffset)
				{
					float t = (endOffset - num4) / num3;
					Vector3 vector = Vector3.Lerp(vecPositions[k], vecPositions[k + 1], t);
					Vector3 item = Vector3.Lerp(soSplinePointLeft[k], soSplinePointLeft[k + 1], t);
					Vector3 item2 = Vector3.Lerp(soSplinePointRight[k], soSplinePointRight[k + 1], t);
					Vector3 item3 = Vector3.Lerp(soSplinePointCenter[k], soSplinePointCenter[k + 1], t);
					for (int l = 0; l < nodeList.Count; l++)
					{
						Vector2 item4 = Vector2.Lerp(nodeList[l][k], nodeList[l][k + 1], t);
						nodeList[l].Insert(k, item4);
					}
					vecPositions.Insert(k + 1, vector);
					soSplinePointLeft.Insert(k + 1, item);
					soSplinePointRight.Insert(k + 1, item2);
					soSplinePointCenter.Insert(k + 1, item3);
					markerInts[k] = num;
					markerInts.Insert(k + 1, num + 1);
					soMarker.endOffsetV3 = vector;
					Vector3 vector2 = vector;
					Vector3 vector3 = vecPositions[k];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						soMarker.endOffsetV3.y = OQQOCDQCQD.OQDODCCCCQ(soMarker.endOffsetV3, roadScr.baseScript);
						vector2.y = OQQOCDQCQD.OQDODCCCCQ(vector2, roadScr.baseScript);
						vector3.y = OQQOCDQCQD.OQDODCCCCQ(vector3, roadScr.baseScript);
					}
					soMarker.endOffsetDir = (vector2 - vector3).normalized;
					soMarker.startOffsetV3nb = vecPositions[k];
					break;
				}
				markerInts[k] = num;
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

		public static void OOCOOOQOOD(ERModularRoad road, ERSOMarkerExt markerSO, Vector3 v, Camera cam, ref int xDir, ref int yDir)
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
				for (int j = 0; j < list.Count - 1; j++)
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

		public static void OOOODDODCO(ERModularRoad road, ERSOMarkerExt markerSO, Vector3 v, Vector3 vOld, float movement)
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
						for (int j = markerSO.curStartInt; j < list.Count - 1; j++)
						{
							float num5 = Vector3.Distance(list[j], v);
							float num6 = Vector3.Distance(list[j], list[j + 1]);
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
					for (int num7 = markerSO.curStartInt; num7 > 0; num7--)
					{
						float num5 = Vector3.Distance(list[num7], v);
						float num6 = Vector3.Distance(list[num7], list[num7 - 1]);
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

		public static void OOOCQDOOCC(ERModularRoad road, ERSOMarkerExt markerSO, Vector3 v)
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
						for (int j = markerSO.curEndInt; j < list.Count - 1; j++)
						{
							float num5 = Vector3.Distance(list[j], v);
							float num6 = Vector3.Distance(list[j], list[j + 1]);
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
					for (int num7 = markerSO.curEndInt; num7 > 0; num7--)
					{
						float num5 = Vector3.Distance(list[num7], v);
						float num6 = Vector3.Distance(list[num7], list[num7 - 1]);
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

		public static void ODCQQCOQOC(int startInt, List<Vector3> vecPositions, List<int> markersInts, ref ERSOMarkerExt soMarker, bool startFlag, ERModularRoad roadScr)
		{
			if (startFlag)
			{
				soMarker.startOffsetV3 = vecPositions[startInt];
				if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
				{
					soMarker.startOffsetV3.y = OQQOCDQCQD.OQDODCCCCQ(soMarker.startOffsetV3, roadScr.baseScript);
				}
				Vector3 vector;
				Vector3 vector2;
				if (startInt == 0)
				{
					vector = vecPositions[startInt + 1];
					vector2 = vecPositions[startInt];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						vector.y = OQQOCDQCQD.OQDODCCCCQ(vector, roadScr.baseScript);
						vector2.y = OQQOCDQCQD.OQDODCCCCQ(vector2, roadScr.baseScript);
					}
				}
				else
				{
					vector = vecPositions[startInt];
					vector2 = vecPositions[startInt - 1];
					if (soMarker.sideObject.snapToTerrain || roadScr.snapToTerrain)
					{
						vector.y = OQQOCDQCQD.OQDODCCCCQ(vector, roadScr.baseScript);
						vector2.y = OQQOCDQCQD.OQDODCCCCQ(vector2, roadScr.baseScript);
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
						soMarker.endOffsetV3.y = OQQOCDQCQD.OQDODCCCCQ(soMarker.endOffsetV3, roadScr.baseScript);
						vector.y = OQQOCDQCQD.OQDODCCCCQ(vector, roadScr.baseScript);
						vector2.y = OQQOCDQCQD.OQDODCCCCQ(vector2, roadScr.baseScript);
					}
					soMarker.endOffsetDir = (vector - vector2).normalized;
					break;
				}
			}
		}

		public static void SynchSoData(ERSORoadExt soData, bool flag)
		{
			if (!soData.distanceChange || flag)
			{
				soData.m_distance = soData.sideObject.m_distance;
			}
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
			if (flag)
			{
				soData.distanceChange = false;
				soData.xPosChange = false;
				soData.randomXPositionChange = false;
				soData.xPositionDistanceChange = false;
				soData.randomYPositionChange = false;
				soData.yPositionDistanceChange = false;
				soData.yPosChange = false;
				soData.rotationAngleChange = false;
				soData.rotationDistanceChange = false;
				soData.autoGenerate = soData.sideObject.autoGenerate;
				soData.markerActive = soData.sideObject.markerActive;
			}
		}

		public static void OQDCDQDCCQ(ERSORoadExt soData, ERSORoadExt source)
		{
			soData.autoGenerate = source.autoGenerate;
			soData.markerActive = source.markerActive;
			soData.clampToMarkers = source.clampToMarkers;
			soData.m_distance = source.m_distance;
			soData.xPosition = source.xPosition;
			soData.yPosition = source.yPosition;
			soData.randomMinRotation = source.randomMinRotation;
			soData.randomMaxRotation = source.randomMaxRotation;
			soData.minRandomRotationDistance = source.minRandomRotationDistance;
			soData.maxRandomRotationDistance = source.maxRandomRotationDistance;
			soData.distanceChange = source.distanceChange;
			soData.xPosChange = source.xPosChange;
			soData.randomXPositionChange = source.randomXPositionChange;
			soData.yPosChange = source.yPosChange;
			soData.randomYPositionChange = source.randomYPositionChange;
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
			soData.sourceObject = source.sourceObject;
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
					if (item.sideObject.relativeTo != 0 && num2 != -1 && item2.soData.Count >= num2 && item2.soData[num2] != null && item2.soData[num2].otherSide == null)
					{
						item2.soData[num2].otherSide = ERSOMarkerExt.CreateInstance(item.sideObject, flag: true);
						item2.soData[num2].otherSide.Copy(item2.soData[num2], reverse: true);
					}
					num++;
				}
			}
		}

		public static void ODCCCDDOCO(ERModularRoad road, SideObject so)
		{
			foreach (ERMarkerExt item in road.markersExt)
			{
				foreach (ERSOMarkerExt soDatum in item.soData)
				{
					if (soDatum.id == so.id)
					{
						if (soDatum.otherSide == null)
						{
							soDatum.otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
							soDatum.otherSide.xPosition = soDatum.xPosition * -1f;
						}
						break;
					}
				}
			}
		}

		public static void OODQOODQOD(ERModularBase scr, ERSideObjectInstance instance)
		{
			SideObject so = instance.so;
			GameObject gameObject = instance.gameObject;
			int num = 0;
			for (int i = 0; i < so.hardEdge.Count; i++)
			{
				if (so.hardEdge[i])
				{
					num++;
				}
			}
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
				list.Add(so.snapWeightList.Count - 1 + num);
			}
			else if ((double)so.snapWeightList[so.snapWeightList.Count - 1] >= 0.95)
			{
				list2.Add(so.snapWeightList.Count - 1 + num);
			}
			if (list.Count == 0 && list2.Count == 0)
			{
				return;
			}
			List<GameObject> list3 = new List<GameObject>();
			List<bool> list4 = new List<bool>();
			list3.Add(gameObject);
			list4.Add(item: false);
			foreach (Transform item in gameObject.transform)
			{
				if (item.name.IndexOf(" Batch ") != -1)
				{
					list3.Add(item.gameObject);
					if (item.GetComponent<ERSideObjectSection>() != null)
					{
						list4.Add(item.GetComponent<ERSideObjectSection>().mirrored);
					}
					else
					{
						list4.Add(item: false);
					}
				}
			}
			int num2 = 0;
			foreach (GameObject item2 in list3)
			{
				if (item2.GetComponent<MeshFilter>() != null)
				{
					Mesh sharedMesh = item2.GetComponent<MeshFilter>().sharedMesh;
					int num3 = so.nodeList.Count + num;
					list.Clear();
					list2.Clear();
				}
				num2++;
			}
		}

		public static bool IsActiveAsChild(ERModularBase scr, double soid, double targetSOId)
		{
			if (scr != null)
			{
				for (int i = 0; i < scr.QOQDQOOQDDQOOQ.Count; i++)
				{
					if (scr.QOQDQOOQDDQOOQ[i].id != soid)
					{
						continue;
					}
					if (scr.QOQDQOOQDDQOOQ[i].buildOtherSideObjectChilds.Count == 0 && scr.QOQDQOOQDDQOOQ[i].buildOtherSideObjects.Count != 0)
					{
						scr.QOQDQOOQDDQOOQ[i].OODQQCODOO();
					}
					for (int j = 0; j < scr.QOQDQOOQDDQOOQ[i].buildOtherSideObjectChilds.Count; j++)
					{
						if (scr.QOQDQOOQDDQOOQ[i].buildOtherSideObjectChilds[j].soid == targetSOId)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static void OQCQCQOOCO(ERCrossingPrefabs prefabScript, int connectionIndex, ref List<Vector3> vecs, float offset, float startEnd, float side)
		{
			List<Vector3> list = new List<Vector3>(vecs);
			int num = list.Count - 1;
			int num2 = 0;
			int num3 = num;
			for (int i = num2; i <= num3; i++)
			{
				Vector3 normalized;
				if (i == 0 && startEnd == 1f)
				{
					normalized = (list[i + 1] - list[i]).normalized;
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				}
				else if (i == num || (i == 0 && startEnd == -1f))
				{
					if (startEnd == -1f)
					{
						if (side == -1f)
						{
							if (prefabScript.crossingElements[connectionIndex].centerCornerDirectionRight == Vector3.zero)
							{
								QDOODOQQDQODD.SetCornerDirectionRight(connectionIndex, prefabScript);
							}
							normalized = prefabScript.crossingElements[connectionIndex].centerCornerDirectionRight * side;
						}
						else
						{
							if (prefabScript.crossingElements[connectionIndex].centerCornerDirectionLeft == Vector3.zero)
							{
								QDOODOQQDQODD.SetCornerDirectionLeft(connectionIndex, prefabScript);
							}
							normalized = prefabScript.crossingElements[connectionIndex].centerCornerDirectionLeft * side;
						}
					}
					else if (side == -1f)
					{
						if (prefabScript.crossingElements[connectionIndex].centerCornerDirectionLeft == Vector3.zero)
						{
							QDOODOQQDQODD.SetCornerDirectionLeft(connectionIndex, prefabScript);
						}
						normalized = prefabScript.crossingElements[connectionIndex].centerCornerDirectionLeft * side;
					}
					else
					{
						if (prefabScript.crossingElements[connectionIndex].centerCornerDirectionRight == Vector3.zero)
						{
							QDOODOQQDQODD.SetCornerDirectionRight(connectionIndex, prefabScript);
						}
						normalized = prefabScript.crossingElements[connectionIndex].centerCornerDirectionRight * side;
					}
				}
				else if (i < num)
				{
					normalized = (list[i + 1] - list[i - 1]).normalized;
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				}
				else
				{
					normalized = (list[i] - list[i - 1]).normalized;
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				}
				vecs[i] = list[i] + normalized * offset;
			}
		}

		public static void OCQCDODDQC(ref List<int> tris, int index)
		{
			for (int i = 0; i < tris.Count; i += 3)
			{
				if (tris[i] == index || tris[i + 1] == index || tris[i + 2] == index)
				{
					tris.RemoveRange(i, 3);
					i -= 3;
				}
			}
		}

		public static bool OCDODCCOCC(int startEnd, ERModularRoad road, SideObject so, int mainOrOtherSide, ERSOMarkerExt soMarkerData)
		{
			soMarkerData.active = false;
			ERSORoadExt eRSORoadExt = null;
			for (int i = 0; i < road.soDataExt.Count; i++)
			{
				if (road.soDataExt[i].sideObject == so)
				{
					eRSORoadExt = road.soDataExt[i];
				}
			}
			if (startEnd == 0)
			{
				if ((mainOrOtherSide == 0 && so.relativeTo == 1) || (mainOrOtherSide == 1 && so.relativeTo == 2))
				{
					if (eRSORoadExt.otherRoadStartLeft != null)
					{
						OCQODDCQDD.OODOQDDOCQ(eRSORoadExt.otherRoadStartLeft.baseScript, eRSORoadExt.otherRoadStartLeft, so);
						OCQODDCQDD.OOOQQQOOQC(eRSORoadExt.otherRoadStartLeft.baseScript, eRSORoadExt.otherRoadStartLeft, so, updateSideObjectsOnOtherRoadObjects: false);
						return true;
					}
				}
				else if (eRSORoadExt.otherRoadStartRight != null)
				{
					OCQODDCQDD.OODOQDDOCQ(eRSORoadExt.otherRoadStartRight.baseScript, eRSORoadExt.otherRoadStartRight, so);
					OCQODDCQDD.OOOQQQOOQC(eRSORoadExt.otherRoadStartRight.baseScript, eRSORoadExt.otherRoadStartRight, so, updateSideObjectsOnOtherRoadObjects: false);
					return true;
				}
			}
			else if ((mainOrOtherSide == 0 && so.relativeTo == 1) || (mainOrOtherSide == 1 && so.relativeTo == 2))
			{
				if (eRSORoadExt.otherRoadEndLeft != null)
				{
					OCQODDCQDD.OODOQDDOCQ(eRSORoadExt.otherRoadEndLeft.baseScript, eRSORoadExt.otherRoadEndLeft, so);
					OCQODDCQDD.OOOQQQOOQC(eRSORoadExt.otherRoadEndLeft.baseScript, eRSORoadExt.otherRoadEndLeft, so, updateSideObjectsOnOtherRoadObjects: false);
					return true;
				}
			}
			else if (eRSORoadExt.otherRoadEndRight != null)
			{
				OCQODDCQDD.OODOQDDOCQ(eRSORoadExt.otherRoadEndRight.baseScript, eRSORoadExt.otherRoadEndRight, so);
				OCQODDCQDD.OOOQQQOOQC(eRSORoadExt.otherRoadEndRight.baseScript, eRSORoadExt.otherRoadEndRight, so, updateSideObjectsOnOtherRoadObjects: false);
				return true;
			}
			return false;
		}

		public static bool OQCOOQOCDO(ERCrossingPrefabs prefab, ERModularRoad road, int index, ref List<ERModularRoad> rds, ref List<ERSORoadExt> sodatas)
		{
			bool result = false;
			foreach (ERSORoadExt item in road.soDataExt)
			{
				if (!(item != null) || !(item.sideObject != null))
				{
					continue;
				}
				if (prefab.crossingElements[index].connectedMarker == 0)
				{
					if ((item.snapIntsStartSide1 != null && item.snapIntsStartSide1.Count > 0) || (item.snapIntsStartSide2 != null && item.snapIntsStartSide2.Count > 0))
					{
						result = true;
						rds.Add(road);
						sodatas.Add(item);
					}
				}
				else if ((item.snapIntsEndSide1 != null && item.snapIntsEndSide1.Count > 0) || (item.snapIntsEndSide2 != null && item.snapIntsEndSide2.Count > 0))
				{
					result = true;
					rds.Add(road);
					sodatas.Add(item);
				}
			}
			return result;
		}

		public static void OCODQOQCQO(ERModularBase scr, bool roadNetworkRefresh)
		{
			for (int i = 0; i < ERRoadNetwork.soRoadUpdate.Count; i++)
			{
				OCQODDCQDD.OODOQDDOCQ(scr, ERRoadNetwork.soRoadUpdate[i].road, ERRoadNetwork.soRoadUpdate[i].soData.sideObject);
				OCQODDCQDD.OOOQQQOOQC(scr, ERRoadNetwork.soRoadUpdate[i].road, ERRoadNetwork.soRoadUpdate[i].soData.sideObject, updateSideObjectsOnOtherRoadObjects: false);
			}
			try
			{
				int count = ERRoadNetwork.snapObjects.Count;
				for (int j = 0; j < ERRoadNetwork.snapObjects.Count; j++)
				{
					if (ERRoadNetwork.snapObjects[j].ints1 == null || ERRoadNetwork.snapObjects[j].ints2 == null || ERRoadNetwork.snapObjects[j].ints1.Count <= 0 || ERRoadNetwork.snapObjects[j].ints1.Count != ERRoadNetwork.snapObjects[j].ints2.Count)
					{
						continue;
					}
					Vector3[] vertices = ERRoadNetwork.snapObjects[j].mesh1.vertices;
					Vector3[] vertices2 = ERRoadNetwork.snapObjects[j].mesh2.vertices;
					Vector3[] normals = ERRoadNetwork.snapObjects[j].mesh1.normals;
					Vector3[] normals2 = ERRoadNetwork.snapObjects[j].mesh2.normals;
					if (vertices.Length == 0 || vertices2.Length == 0 || ERRoadNetwork.snapObjects[j].road1 == null || ERRoadNetwork.snapObjects[j].road2 == null)
					{
						if (ERRoadNetwork.snapObjects[j].road1 != null && ERRoadNetwork.snapObjects[j].road2 != null)
						{
							Debug.Log("EasyRoads3Dv3v3 Warning: The side object " + ERRoadNetwork.snapObjects[j].soData1.sideObject.name + " could not be fully updated between the road objects: '" + ERRoadNetwork.snapObjects[j].road1.name + "' and '" + ERRoadNetwork.snapObjects[j].road2.name + "'");
						}
						else
						{
							Debug.Log("EasyRoads3Dv3v3 Warning: The side object could not fully update on connector");
						}
						continue;
					}
					int num = 0;
					if (ERRoadNetwork.snapObjects[j].instance.crossingElements[ERRoadNetwork.snapObjects[j].el1].connectedMarker != 0)
					{
						num = 1;
					}
					int num2 = 0;
					if (ERRoadNetwork.snapObjects[j].instance.crossingElements[ERRoadNetwork.snapObjects[j].el2].connectedMarker != 0)
					{
						num2 = 1;
					}
					if (num == 0)
					{
						if (ERRoadNetwork.snapObjects[j].side1 == 1)
						{
							ERRoadNetwork.snapObjects[j].soData1.snapIntsStartSide1 = ERRoadNetwork.snapObjects[j].ints1;
							ERRoadNetwork.snapObjects[j].soData1.snapMeshSide1 = ERRoadNetwork.snapObjects[j].mesh1;
							ERRoadNetwork.snapObjects[j].soData1.otherRoadStartLeft = ERRoadNetwork.snapObjects[j].road2.GetComponent<ERModularRoad>();
						}
						else
						{
							ERRoadNetwork.snapObjects[j].soData1.snapIntsStartSide2 = ERRoadNetwork.snapObjects[j].ints1;
							ERRoadNetwork.snapObjects[j].soData1.snapMeshSide2 = ERRoadNetwork.snapObjects[j].mesh1;
							ERRoadNetwork.snapObjects[j].soData1.otherRoadStartRight = ERRoadNetwork.snapObjects[j].road2.GetComponent<ERModularRoad>();
						}
					}
					else if (ERRoadNetwork.snapObjects[j].side1 == 0)
					{
						ERRoadNetwork.snapObjects[j].soData1.snapIntsEndSide1 = ERRoadNetwork.snapObjects[j].ints1;
						ERRoadNetwork.snapObjects[j].soData1.snapMeshSide1 = ERRoadNetwork.snapObjects[j].mesh1;
						ERRoadNetwork.snapObjects[j].soData1.otherRoadEndLeft = ERRoadNetwork.snapObjects[j].road2.GetComponent<ERModularRoad>();
					}
					else
					{
						ERRoadNetwork.snapObjects[j].soData1.snapIntsEndSide2 = ERRoadNetwork.snapObjects[j].ints1;
						ERRoadNetwork.snapObjects[j].soData1.snapMeshSide2 = ERRoadNetwork.snapObjects[j].mesh1;
						ERRoadNetwork.snapObjects[j].soData1.otherRoadEndRight = ERRoadNetwork.snapObjects[j].road2.GetComponent<ERModularRoad>();
					}
					if (num2 == 0)
					{
						if (ERRoadNetwork.snapObjects[j].side2 == 1)
						{
							ERRoadNetwork.snapObjects[j].soData2.snapIntsStartSide1 = ERRoadNetwork.snapObjects[j].ints2;
							ERRoadNetwork.snapObjects[j].soData2.snapMeshSide1 = ERRoadNetwork.snapObjects[j].mesh2;
							ERRoadNetwork.snapObjects[j].soData2.otherRoadStartLeft = ERRoadNetwork.snapObjects[j].road1.GetComponent<ERModularRoad>();
						}
						else
						{
							ERRoadNetwork.snapObjects[j].soData2.snapIntsStartSide2 = ERRoadNetwork.snapObjects[j].ints2;
							ERRoadNetwork.snapObjects[j].soData2.snapMeshSide2 = ERRoadNetwork.snapObjects[j].mesh2;
							ERRoadNetwork.snapObjects[j].soData2.otherRoadStartRight = ERRoadNetwork.snapObjects[j].road1.GetComponent<ERModularRoad>();
						}
					}
					else if (ERRoadNetwork.snapObjects[j].side1 == 0)
					{
						ERRoadNetwork.snapObjects[j].soData2.snapIntsEndSide2 = ERRoadNetwork.snapObjects[j].ints2;
						ERRoadNetwork.snapObjects[j].soData2.snapMeshSide2 = ERRoadNetwork.snapObjects[j].mesh2;
						ERRoadNetwork.snapObjects[j].soData2.otherRoadEndLeft = ERRoadNetwork.snapObjects[j].road1.GetComponent<ERModularRoad>();
					}
					else
					{
						ERRoadNetwork.snapObjects[j].soData2.snapIntsEndSide1 = ERRoadNetwork.snapObjects[j].ints2;
						ERRoadNetwork.snapObjects[j].soData2.snapMeshSide1 = ERRoadNetwork.snapObjects[j].mesh2;
						ERRoadNetwork.snapObjects[j].soData2.otherRoadEndRight = ERRoadNetwork.snapObjects[j].road1.GetComponent<ERModularRoad>();
					}
					float num3 = Vector3.Distance(vertices[ERRoadNetwork.snapObjects[j].ints1[0]], vertices2[ERRoadNetwork.snapObjects[j].ints2[0]]);
					float num4 = Vector3.Distance(vertices[ERRoadNetwork.snapObjects[j].ints1[0]], vertices2[ERRoadNetwork.snapObjects[j].ints2[ERRoadNetwork.snapObjects[j].ints2.Count - 1]]);
					if (num4 < num3)
					{
						ERRoadNetwork.snapObjects[j].ints2.Reverse();
					}
					if (ERRoadNetwork.snapObjects[j].road1 != ERRoadNetwork.snapObjects[j].road2)
					{
						for (int k = 0; k < ERRoadNetwork.snapObjects[j].ints1.Count; k++)
						{
							vertices[ERRoadNetwork.snapObjects[j].ints1[k]] = (vertices2[ERRoadNetwork.snapObjects[j].ints2[k]] = Vector3.Lerp(vertices[ERRoadNetwork.snapObjects[j].ints1[k]], vertices2[ERRoadNetwork.snapObjects[j].ints2[k]], 0.5f));
							normals[ERRoadNetwork.snapObjects[j].ints1[k]] = (normals2[ERRoadNetwork.snapObjects[j].ints2[k]] = Vector3.Lerp(normals[ERRoadNetwork.snapObjects[j].ints1[k]], normals2[ERRoadNetwork.snapObjects[j].ints2[k]], 0.5f));
						}
						ERRoadNetwork.snapObjects[j].mesh1.vertices = vertices;
						ERRoadNetwork.snapObjects[j].mesh2.vertices = vertices2;
						ERRoadNetwork.snapObjects[j].mesh1.normals = normals;
						ERRoadNetwork.snapObjects[j].mesh2.normals = normals2;
					}
					else
					{
						for (int l = 0; l < ERRoadNetwork.snapObjects[j].ints1.Count; l++)
						{
							vertices[ERRoadNetwork.snapObjects[j].ints1[l]] = (vertices[ERRoadNetwork.snapObjects[j].ints2[l]] = Vector3.Lerp(vertices[ERRoadNetwork.snapObjects[j].ints1[l]], vertices[ERRoadNetwork.snapObjects[j].ints2[l]], 0.5f));
							normals[ERRoadNetwork.snapObjects[j].ints1[l]] = (normals[ERRoadNetwork.snapObjects[j].ints2[l]] = Vector3.Lerp(normals[ERRoadNetwork.snapObjects[j].ints1[l]], normals[ERRoadNetwork.snapObjects[j].ints2[l]], 0.5f));
						}
						ERRoadNetwork.snapObjects[j].mesh1.vertices = vertices;
						ERRoadNetwork.snapObjects[j].mesh1.normals = normals;
					}
				}
				for (int m = 0; m < scr.connectionObjects.Count; m++)
				{
					scr.connectionObjects[m].UpdateSurfacesTriangulation();
				}
			}
			catch
			{
			}
			scr.surfaceChangeFlag = false;
			scr.connectionObjects.Clear();
			ERRoadNetwork.soRoadUpdate.Clear();
			ERRoadNetwork.snapObjects.Clear();
		}

		public static void AssignSideObjects(ERModularBase scr, ERModularRoad OOOCDDCQCD)
		{
			for (int i = 0; i < scr.QOQDQOOQDDQOOQ.Count; i++)
			{
				bool flag = true;
				bool flag2 = false;
				foreach (ERSORoadExt item in OOOCDDCQCD.soDataExt)
				{
					if (item.sideObject.id == scr.QOQDQOOQDDQOOQ[i].id)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					OOOCDDCQCD.soDataExt.Add(ERSORoadExt.CreateInstance(scr.QOQDQOOQDDQOOQ[i]));
				}
			}
			OOOCDDCQCD.sideObjectNames = OCQODDCQDD.OQCCQCDQQO(OOOCDDCQCD);
		}
	}
}
