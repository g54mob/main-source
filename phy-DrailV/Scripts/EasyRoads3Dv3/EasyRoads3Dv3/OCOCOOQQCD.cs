using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OCOCOOQQCD : MonoBehaviour
	{
		public static void OCDQDCCOCQ(ERModularBase baseScript, ERCrossingPrefabs scr, int connectionSegment, ERModularRoad road, int startend)
		{
			ERCrossings component = scr.gameObject.GetComponent<ERCrossings>();
			if (component == null && scr.gameObject.GetComponent<ERRoundabouts>() == null)
			{
				return;
			}
			if (startend == 0)
			{
				if (road.endPrefabScript != null && !road.endPrefabScript.isCustomPrefab && !road.endPrefabScript.isIConnector && (scr.crossingElements[connectionSegment].includeLeftSidewalk != road.endPrefabScript.crossingElements[road.endConnectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeRightSidewalk != road.endPrefabScript.crossingElements[road.endConnectionSegment].includeLeftSidewalk))
				{
					ODODCDCCCD(baseScript, scr, connectionSegment, road, road.endPrefabScript, road.endConnectionSegment);
				}
			}
			else if (road.startPrefabScript != null && !road.startPrefabScript.isCustomPrefab && !road.startPrefabScript.isIConnector && (scr.crossingElements[connectionSegment].includeLeftSidewalk != road.startPrefabScript.crossingElements[road.startConnectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeRightSidewalk != road.startPrefabScript.crossingElements[road.startConnectionSegment].includeLeftSidewalk))
			{
				ODODCDCCCD(baseScript, scr, connectionSegment, road, road.startPrefabScript, road.startConnectionSegment);
			}
		}

		public static void OQCDOQOCDC(ERModularBase baseScript, ERCrossingPrefabs scr, int connectionSegment, ERModularRoad road, int startend)
		{
			ERCrossings component = scr.gameObject.GetComponent<ERCrossings>();
			if (component == null && scr.gameObject.GetComponent<ERRoundabouts>() == null)
			{
				return;
			}
			if (startend == 0)
			{
				if (road.endPrefabScript != null)
				{
					if (road.endPrefabScript.isIConnector)
					{
						road.endPrefabScript.gameObject.GetComponent<ERIConnector>().OCCCCCCDCC(road);
					}
					else if (scr.crossingElements[connectionSegment].includeLeftSidewalk != road.endPrefabScript.crossingElements[road.endConnectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeRightSidewalk != road.endPrefabScript.crossingElements[road.endConnectionSegment].includeLeftSidewalk)
					{
						ODODCDCCCD(baseScript, road.endPrefabScript, road.endConnectionSegment, road, scr, connectionSegment);
					}
				}
			}
			else if (road.startPrefabScript != null)
			{
				if (road.startPrefabScript.isIConnector)
				{
					road.startPrefabScript.gameObject.GetComponent<ERIConnector>().OCCCCCCDCC(road);
				}
				else if (scr.crossingElements[connectionSegment].includeLeftSidewalk != road.startPrefabScript.crossingElements[road.startConnectionSegment].includeRightSidewalk || scr.crossingElements[connectionSegment].includeRightSidewalk != road.startPrefabScript.crossingElements[road.startConnectionSegment].includeLeftSidewalk)
				{
					ODODCDCCCD(baseScript, road.startPrefabScript, road.startConnectionSegment, road, scr, connectionSegment);
				}
			}
		}

		public static void ODODCDCCCD(ERModularBase baseScript, ERCrossingPrefabs scr, int connectionSegment, ERModularRoad road, ERCrossingPrefabs otherPrefabScript, int otherConnection)
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
				OCCDQCDODC(scr, connectionSegment, ref roadOnNeighbour, ref cornerElement, ref centerStatus);
				OQCQQOCQOQ(otherPrefabScript, otherConnection, ref roadOnNeighbour2, ref cornerElement2, ref centerStatus2);
				if (!roadOnNeighbour)
				{
					OQCQQOCQOQ(otherPrefabScript, otherConnection, ref roadOnNeighbour2, ref cornerElement2, ref centerStatus2);
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
				OQCQQOCQOQ(scr, connectionSegment, ref roadOnNeighbour, ref cornerElement, ref centerStatus);
				OCCDQCDODC(otherPrefabScript, otherConnection, ref roadOnNeighbour2, ref cornerElement2, ref centerStatus2);
				if (!roadOnNeighbour)
				{
					OCCDQCDODC(otherPrefabScript, otherConnection, ref roadOnNeighbour2, ref cornerElement2, ref centerStatus2);
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
				scr.gameObject.GetComponent<ERCrossings>().OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
			}
			else if ((bool)scr.gameObject.GetComponent<ERRoundabouts>())
			{
				ERRoundabouts component = scr.gameObject.GetComponent<ERRoundabouts>();
				component.OCCQCOQODO();
				component.OOCDCDDOQQ();
				component.OODOQQQCDD();
				if (component.connections.Count > 0)
				{
					component.OQCDOOOQDQ();
				}
			}
		}

		public static void OCCDQCDODC(ERCrossingPrefabs scr, int lookUpElement, ref bool roadOnNeighbour, ref int cornerElement, ref bool centerStatus)
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

		public static void OQCQQOCQOQ(ERCrossingPrefabs scr, int lookUpElement, ref bool roadOnNeighbour, ref int cornerElement, ref bool centerStatus)
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
					connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
					}
				}
				else if (prefabScript.crossingElements[list[i]].connectedMarker == 0)
				{
					connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
					}
				}
				else
				{
					connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
					}
				}
				connectedRoad.OCCCCCCDCC(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}
	}
}
