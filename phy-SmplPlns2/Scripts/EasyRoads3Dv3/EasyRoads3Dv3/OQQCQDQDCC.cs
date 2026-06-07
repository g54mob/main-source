using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OQQCQDQDCC : MonoBehaviour
	{
		public static void OQDDDDDQCD(ERModularBase baseScript, ERCrossingPrefabs scr, int connectionSegment, ERModularRoad road, int startend)
		{
			if (scr == null || road == null)
			{
				return;
			}
			ERCrossings component = scr.gameObject.GetComponent<ERCrossings>();
			if (component == null && scr.gameObject.GetComponent<ERRoundabouts>() == null)
			{
				return;
			}
			if (startend == 0)
			{
				if (road.endPrefabScript != null && !road.endPrefabScript.isCustomPrefab && !road.endPrefabScript.isIConnector && !road.endPrefabScript.isFlexConnector && (scr.crossingElements[connectionSegment].includeLeftSidewalk != road.endPrefabScript.crossingElements[road.endConnectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeRightSidewalk != road.endPrefabScript.crossingElements[road.endConnectionSegment].includeLeftSidewalk))
				{
					OQCDCCOOCC(baseScript, scr, connectionSegment, road, road.endPrefabScript, road.endConnectionSegment);
				}
			}
			else if (road.startPrefabScript != null && !road.startPrefabScript.isCustomPrefab && !road.startPrefabScript.isIConnector && !road.startPrefabScript.isFlexConnector && (scr.crossingElements[connectionSegment].includeLeftSidewalk != road.startPrefabScript.crossingElements[road.startConnectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeRightSidewalk != road.startPrefabScript.crossingElements[road.startConnectionSegment].includeLeftSidewalk))
			{
				OQCDCCOOCC(baseScript, scr, connectionSegment, road, road.startPrefabScript, road.startConnectionSegment);
			}
		}

		public static void OOQQCCCCOO(ERModularBase baseScript, ERCrossingPrefabs scr, int connectionSegment, ERModularRoad road, int startend)
		{
			if (scr == null || road == null)
			{
				return;
			}
			ERCrossings component = scr.gameObject.GetComponent<ERCrossings>();
			if (component == null && scr.gameObject.GetComponent<ERRoundabouts>() == null)
			{
				return;
			}
			if (startend == 0)
			{
				if (road.endPrefabScript != null && !road.endPrefabScript.isFlexConnector)
				{
					if (road.endPrefabScript.isIConnector)
					{
						road.endPrefabScript.gameObject.GetComponent<ERIConnector>().ODDDQDQOOD(road);
					}
					else if (scr.crossingElements[connectionSegment].includeLeftSidewalk != road.endPrefabScript.crossingElements[road.endConnectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeRightSidewalk != road.endPrefabScript.crossingElements[road.endConnectionSegment].includeLeftSidewalk)
					{
						OQCDCCOOCC(baseScript, road.endPrefabScript, road.endConnectionSegment, road, scr, connectionSegment);
					}
				}
			}
			else if (road.startPrefabScript != null && !road.startPrefabScript.isFlexConnector)
			{
				if (road.startPrefabScript.isIConnector)
				{
					road.startPrefabScript.gameObject.GetComponent<ERIConnector>().ODDDQDQOOD(road);
				}
				else if (scr.crossingElements[connectionSegment].includeLeftSidewalk != road.startPrefabScript.crossingElements[road.startConnectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeRightSidewalk != road.startPrefabScript.crossingElements[road.startConnectionSegment].includeLeftSidewalk)
				{
					OQCDCCOOCC(baseScript, road.startPrefabScript, road.startConnectionSegment, road, scr, connectionSegment);
				}
			}
		}

		public static void OQCDCCOOCC(ERModularBase baseScript, ERCrossingPrefabs scr, int connectionSegment, ERModularRoad road, ERCrossingPrefabs otherPrefabScript, int otherConnection)
		{
			if (scr.isIConnector)
			{
				return;
			}
			scr.crossingElements[connectionSegment].includeRightSidewalk = otherPrefabScript.crossingElements[otherConnection].includeLeftSidewalk;
			scr.crossingElements[connectionSegment].includeLeftSidewalk = otherPrefabScript.crossingElements[otherConnection].includeRightSidewalk;
			if (scr.crossingElements[connectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeLeftSidewalk)
			{
			}
			if (baseScript.mirrorCrossings)
			{
				bool roadOnNeighbour = false;
				int cornerElement = -1;
				bool centerStatus = true;
				bool roadOnNeighbour2 = false;
				int cornerElement2 = -1;
				bool centerStatus2 = true;
				OCDQCQOQCQ(scr, connectionSegment, ref roadOnNeighbour, ref cornerElement, ref centerStatus);
				OOQQQOOOOC(otherPrefabScript, otherConnection, ref roadOnNeighbour2, ref cornerElement2, ref centerStatus2);
				if (!roadOnNeighbour)
				{
					OOQQQOOOOC(otherPrefabScript, otherConnection, ref roadOnNeighbour2, ref cornerElement2, ref centerStatus2);
					if (!otherPrefabScript.isCustomPrefab)
					{
						scr.sidewalkControlElements[cornerElement].renderFlag = otherPrefabScript.sidewalkControlElements[cornerElement2].renderFlag;
						scr.crossingElements[scr.sidewalkControlElements[cornerElement].crossingElementRightIndex].includeRightSidewalk = otherPrefabScript.crossingElements[otherPrefabScript.sidewalkControlElements[cornerElement2].crossingElementLeftIndex].includeLeftSidewalk;
					}
				}
				else if (!otherPrefabScript.isCustomPrefab && otherPrefabScript.sidewalkControlElements[cornerElement2].renderFlag)
				{
					scr.sidewalkControlElements[cornerElement].renderFlag = true;
				}
				roadOnNeighbour = false;
				cornerElement = -1;
				centerStatus = true;
				roadOnNeighbour2 = false;
				cornerElement2 = -1;
				centerStatus2 = true;
				OOQQQOOOOC(scr, connectionSegment, ref roadOnNeighbour, ref cornerElement, ref centerStatus);
				OCDQCQOQCQ(otherPrefabScript, otherConnection, ref roadOnNeighbour2, ref cornerElement2, ref centerStatus2);
				if (!roadOnNeighbour)
				{
					OCDQCQOQCQ(otherPrefabScript, otherConnection, ref roadOnNeighbour2, ref cornerElement2, ref centerStatus2);
					if (cornerElement >= 0 && cornerElement2 >= 0)
					{
						scr.sidewalkControlElements[cornerElement].renderFlag = otherPrefabScript.sidewalkControlElements[cornerElement2].renderFlag;
						scr.crossingElements[scr.sidewalkControlElements[cornerElement].crossingElementLeftIndex].includeLeftSidewalk = otherPrefabScript.crossingElements[otherPrefabScript.sidewalkControlElements[cornerElement2].crossingElementRightIndex].includeRightSidewalk;
					}
				}
				else if (otherPrefabScript.sidewalkControlElements[cornerElement2].renderFlag)
				{
					scr.sidewalkControlElements[cornerElement].renderFlag = true;
				}
			}
			if ((bool)scr.gameObject.GetComponent<ERCrossings>())
			{
				scr.gameObject.GetComponent<ERCrossings>().OQDCCQOCCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
			}
			else if ((bool)scr.gameObject.GetComponent<ERRoundabouts>())
			{
				ERRoundabouts component = scr.gameObject.GetComponent<ERRoundabouts>();
				component.OOODQQDOOD();
				component.OCODQOOOCQ();
				component.OCOCDCDDOD();
				if (component.connections.Count > 0)
				{
					component.OCCCDCOOOC();
				}
			}
		}

		public static void OCDQCQOQCQ(ERCrossingPrefabs scr, int lookUpElement, ref bool roadOnNeighbour, ref int cornerElement, ref bool centerStatus)
		{
			for (int i = 0; i < scr.sidewalkControlElements.Count; i++)
			{
				if (scr.sidewalkControlElements[i].crossingElementLeftIndex == lookUpElement)
				{
					if (scr.crossingElements[scr.sidewalkControlElements[i].crossingElementRightIndex].connectedRoad != null)
					{
						roadOnNeighbour = true;
					}
					cornerElement = i;
					centerStatus = scr.sidewalkControlElements[i].renderFlag;
					break;
				}
			}
		}

		public static void OOQQQOOOOC(ERCrossingPrefabs scr, int lookUpElement, ref bool roadOnNeighbour, ref int cornerElement, ref bool centerStatus)
		{
			for (int i = 0; i < scr.sidewalkControlElements.Count; i++)
			{
				if (scr.sidewalkControlElements[i].crossingElementRightIndex == lookUpElement)
				{
					if (scr.crossingElements[scr.sidewalkControlElements[i].crossingElementLeftIndex].connectedRoad != null)
					{
						roadOnNeighbour = true;
					}
					cornerElement = i;
					centerStatus = scr.sidewalkControlElements[i].renderFlag;
					break;
				}
			}
		}

		public static bool CheckRoadTypeChanges(ERModularBase baseScript, ERCrossingPrefabs prefabScript, bool ercrossing, bool erroundabout)
		{
			if (prefabScript == null)
			{
				return false;
			}
			if (prefabScript.isCustomPrefab)
			{
				return false;
			}
			List<ERModularRoad> updatedRoads = new List<ERModularRoad>();
			if (prefabScript.crossingsScript == null && (bool)prefabScript.gameObject.GetComponent<ERCrossings>())
			{
				prefabScript.crossingsScript = prefabScript.gameObject.GetComponent<ERCrossings>();
			}
			if (prefabScript.roundaboutScript == null && (bool)prefabScript.gameObject.GetComponent<ERRoundabouts>())
			{
				prefabScript.roundaboutScript = prefabScript.gameObject.GetComponent<ERRoundabouts>();
			}
			bool result = false;
			bool flag = false;
			foreach (QDOODOQQDQODD crossingElement in prefabScript.crossingElements)
			{
				foreach (QDQDOOQQDQODD roadType in baseScript.roadTypes)
				{
					if (roadType.id == crossingElement.roadType)
					{
						if (prefabScript.crossingsScript != null && ercrossing)
						{
							flag = prefabScript.crossingsScript.UpdateToRoadType(roadType, ref updatedRoads);
						}
						else if (prefabScript.roundaboutScript != null && erroundabout)
						{
							flag = prefabScript.roundaboutScript.UpdateToRoadType(roadType);
						}
						result = true;
					}
				}
			}
			return result;
		}

		public static void UpdateToRoadType(ERCrossingPrefabs prefabScript, QDQDOOQQDQODD sourcePreset, ref List<ERModularRoad> updatedRoads)
		{
			List<int> list = new List<int>();
			if (0 == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				ERModularRoad connectedRoad = prefabScript.crossingElements[list[i]].connectedRoad;
				if ((bool)connectedRoad.startPrefabScript && (bool)connectedRoad.endPrefabScript)
				{
					connectedRoad.OODCDQQQDD(prefabScript, list[i], reverse: true, uvReverse: true, UpdateResolutionFlag: false);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OODCDQQQDD(prefabScript, list[i], reverse: false, uvReverse: false, UpdateResolutionFlag: false);
					}
				}
				else if (prefabScript.crossingElements[list[i]].connectedMarker == 0)
				{
					connectedRoad.OODCDQQQDD(prefabScript, list[i], reverse: true, uvReverse: true, UpdateResolutionFlag: false);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OODCDQQQDD(prefabScript, list[i], reverse: false, uvReverse: false, UpdateResolutionFlag: false);
					}
				}
				else
				{
					connectedRoad.OODCDQQQDD(prefabScript, list[i], reverse: false, uvReverse: false, UpdateResolutionFlag: false);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OODCDQQQDD(prefabScript, list[i], reverse: true, uvReverse: true, UpdateResolutionFlag: false);
					}
				}
				connectedRoad.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public static void SwapConnectionInit(ERModularBase scr, ERCrossingPrefabs prefab, ref int newIndex, ref int oldIndex, ref int index1, ref int index2, ref ERModularRoad road1, ref ERModularRoad road2)
		{
			int num = 0;
			foreach (QDOODOQQDQODD crossingElement in prefab.crossingElements)
			{
				if (crossingElement.connectedRoad != null)
				{
					if (index1 == -1)
					{
						index1 = num;
						road1 = crossingElement.connectedRoad;
					}
					else
					{
						index2 = num;
						road2 = crossingElement.connectedRoad;
					}
				}
				num++;
			}
			oldIndex = index1;
			if (index2 == -1)
			{
				OODDQCQCOC(prefab, index1, ref newIndex);
			}
			else
			{
				newIndex = index2;
			}
		}

		public static void OOOQOCQCQD(ERModularBase scr, ERCrossingPrefabs prefab, int newIndex, int oldIndex, int index1, int index2, ERModularRoad road1, ERModularRoad road2)
		{
			int num = -1;
			if (road2 != null)
			{
				if (prefab.crossingElements[index2].connectedRoad.startPrefabScript == prefab)
				{
					prefab.crossingElements[index2].connectedRoad.startPrefabScript = null;
					prefab.crossingElements[index2].connectedRoad = null;
					num = 0;
				}
				else
				{
					prefab.crossingElements[index2].connectedRoad.endPrefabScript = null;
					prefab.crossingElements[index2].connectedRoad = null;
					num = road2.markersExt.Count - 1;
				}
			}
			int num2 = 0;
			Vector3 position;
			Vector3 vector;
			Vector3 oCCQQOCQDQ;
			if (prefab.crossingElements[oldIndex].connectedRoad.startPrefabScript == prefab)
			{
				prefab.crossingElements[oldIndex].connectedRoad.startPrefabScript = null;
				prefab.crossingElements[oldIndex].connectedRoad.startConnectionSegment = -1;
				num2 = 0;
				road1.nodeWithinRange = 0;
				oCCQQOCQDQ = (position = prefab.crossingElements[oldIndex].connectedRoad.markersExt[0].position);
				vector = prefab.crossingElements[oldIndex].connectedRoad.soSplinePoints[1];
				if (position == vector && prefab.crossingElements[oldIndex].connectedRoad.soSplinePoints.Count > 2)
				{
					vector = prefab.crossingElements[oldIndex].connectedRoad.soSplinePoints[2];
				}
			}
			else
			{
				prefab.crossingElements[oldIndex].connectedRoad.endPrefabScript = null;
				prefab.crossingElements[oldIndex].connectedRoad.endConnectionSegment = -1;
				num2 = 1;
				road1.nodeWithinRange = road1.markersExt.Count - 1;
				oCCQQOCQDQ = (position = prefab.crossingElements[oldIndex].connectedRoad.markersExt[prefab.crossingElements[oldIndex].connectedRoad.markersExt.Count - 1].position);
				vector = prefab.crossingElements[oldIndex].connectedRoad.soSplinePoints[prefab.crossingElements[oldIndex].connectedRoad.soSplinePoints.Count - 2];
				if (position == vector && prefab.crossingElements[oldIndex].connectedRoad.soSplinePoints.Count > 2)
				{
					vector = prefab.crossingElements[oldIndex].connectedRoad.soSplinePoints[prefab.crossingElements[oldIndex].connectedRoad.soSplinePoints.Count - 3];
				}
			}
			prefab.crossingElements[oldIndex].connectedRoad = null;
			prefab.crossingElements[oldIndex].connectedMarker = -1;
			prefab.crossingElements[oldIndex].connectedRoadGO = null;
			if (road2 != null)
			{
				Vector3 vector2 = position - road2.markersExt[num].position;
				vector = position + vector2;
			}
			prefab.OCODOODQQQ(position, vector, newIndex, road1);
			OQQOCDQCQDExt.OOCQOCCCDQ(prefab, road1, road1.nodeWithinRange, newIndex);
			if (num2 == 0)
			{
				OQOCQDQODD.ODCQDDOQOQ(road1, oCCQQOCQDQ, prefab, newIndex, reverse: true, uvReverse: false, forceAutoRotate: false);
			}
			else
			{
				OQOCQDQODD.ODCQDDOQOQ(road1, oCCQQOCQDQ, prefab, newIndex, reverse: false, uvReverse: false, forceAutoRotate: false);
			}
			if (road2 != null)
			{
				oCCQQOCQDQ = prefab.transform.TransformPoint(prefab.crossingElements[index1].tmpCenterPoint);
				OQQOCDQCQDExt.OOCQOCCCDQ(prefab, road2, road2.nodeWithinRange, index1);
				if (num == 0)
				{
					road2.nodeWithinRange = 0;
					OQOCQDQODD.ODCQDDOQOQ(road2, oCCQQOCQDQ, prefab, index1, reverse: true, uvReverse: false, forceAutoRotate: false);
				}
				else
				{
					road2.nodeWithinRange = num;
					OQOCQDQODD.ODCQDDOQOQ(road2, oCCQQOCQDQ, prefab, index1, reverse: false, uvReverse: false, forceAutoRotate: false);
				}
			}
		}

		public static void OODDQCQCOC(ERCrossingPrefabs prefab, int index, ref int newIndex)
		{
			int roadShapeMatchCount = prefab.crossingElements[index].roadShapeMatchCount;
			index++;
			if (index >= prefab.crossingElements.Count)
			{
				index = 0;
			}
			for (int i = index; i < prefab.crossingElements.Count; i++)
			{
				if (prefab.crossingElements[i].roadShapeMatchCount == roadShapeMatchCount)
				{
					newIndex = i;
					break;
				}
			}
			if (newIndex != -1)
			{
				return;
			}
			for (int j = 0; j < index; j++)
			{
				if (prefab.crossingElements[j].roadShapeMatchCount == roadShapeMatchCount)
				{
					newIndex = j;
					break;
				}
			}
		}
	}
}
