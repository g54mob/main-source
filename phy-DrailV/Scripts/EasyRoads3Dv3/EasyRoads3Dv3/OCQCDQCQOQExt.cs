using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OCQCDQCQOQExt : MonoBehaviour
	{
		public static void ODDDQODDQQ(ERModularBase scr)
		{
			ERCrossings[] array = Object.FindObjectsOfType(typeof(ERCrossings)) as ERCrossings[];
			int num = 0;
			ERCrossings[] array2 = array;
			foreach (ERCrossings eRCrossings in array2)
			{
				num++;
				try
				{
					if (!OCOCOOQQCD.CheckRoadTypeChanges(scr, eRCrossings.prefabScript, ercrossing: true, erroundabout: false))
					{
						eRCrossings.OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
					}
				}
				catch
				{
					Debug.Log("Refresh failed: " + eRCrossings.gameObject.name);
				}
			}
			ERRoundabouts[] array3 = Object.FindObjectsOfType(typeof(ERRoundabouts)) as ERRoundabouts[];
			num = 0;
			ERRoundabouts[] array4 = array3;
			foreach (ERRoundabouts eRRoundabouts in array4)
			{
				num++;
				try
				{
					if (OCOCOOQQCD.CheckRoadTypeChanges(scr, eRRoundabouts.prefabScript, ercrossing: false, erroundabout: true))
					{
						continue;
					}
					eRRoundabouts.OCCQCOQODO();
					eRRoundabouts.OOCDCDDOQQ();
					if (eRRoundabouts.leftFlag && eRRoundabouts.rightFlag)
					{
						eRRoundabouts.OODOQQQCDD();
						if (eRRoundabouts.connections.Count > 0)
						{
							eRRoundabouts.OQCDOOOQDQ();
						}
					}
				}
				catch
				{
					Debug.Log("Refresh failed: " + eRRoundabouts.gameObject.name);
				}
			}
			ERCrossingPrefabs[] array5 = Object.FindObjectsOfType(typeof(ERCrossingPrefabs)) as ERCrossingPrefabs[];
			num = 0;
			ERCrossingPrefabs[] array6 = array5;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array6)
			{
				num++;
				try
				{
					eRCrossingPrefabs.OCCQOOCCCQ(forceFlag: true);
				}
				catch
				{
				}
			}
			ERModularRoad[] array7 = Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			num = 0;
			ERModularRoad[] array8 = array7;
			foreach (ERModularRoad eRModularRoad in array8)
			{
				num++;
				try
				{
					if (eRModularRoad.markersExt.Count <= 1)
					{
						Object.DestroyImmediate(eRModularRoad.gameObject);
						continue;
					}
					eRModularRoad.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
					Transform transform = eRModularRoad.transform.Find("treesERMesh");
					while (transform != null)
					{
						Object.DestroyImmediate(transform.gameObject);
						transform = eRModularRoad.transform.Find("treesERMesh");
					}
					transform = eRModularRoad.transform.Find("detailERMesh");
					while (transform != null)
					{
						Object.DestroyImmediate(transform.gameObject);
						transform = eRModularRoad.transform.Find("detailERMesh");
					}
				}
				catch
				{
					Debug.Log("Refresh failed: " + eRModularRoad.gameObject.name);
				}
			}
			ERSideObjectInstance[] array9 = Object.FindObjectsOfType(typeof(ERSideObjectInstance)) as ERSideObjectInstance[];
			num = 0;
			ERSideObjectInstance[] array10 = array9;
			foreach (ERSideObjectInstance eRSideObjectInstance in array10)
			{
				num++;
				if (!(eRSideObjectInstance.so != null))
				{
					continue;
				}
				ERModularRoad component = eRSideObjectInstance.transform.parent.GetComponent<ERModularRoad>();
				bool flag = false;
				try
				{
					for (int j = 0; j < component.soDataExt.Count; j++)
					{
						if (component.soDataExt[j].sideObject.id == eRSideObjectInstance.so.id && component.soDataExt[j].active)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						OCQQCCQCCO.OQOCCQOQQO(scr, component, eRSideObjectInstance.so);
					}
					else
					{
						Debug.LogWarning("EasyRoads3Dv3 warning: the side object " + eRSideObjectInstance.so.name + " (game object ) exists while this side object is currently not active for this road: road name: " + component.gameObject.name);
					}
				}
				catch
				{
					Debug.LogWarning("EasyRoads3Dv3 warning: the side object " + eRSideObjectInstance.so.name + " (game object ) exists while this side object currently does not exist in road object: " + component.gameObject.name);
				}
			}
		}

		public static string[] GetMatchingPrefabs(ERModularRoad scr, string[] prefabs, ref ERCrossingPrefabs[] prefs, int type)
		{
			GameObject gameObject = null;
			List<string> list = new List<string>();
			List<ERCrossingPrefabs> list2 = new List<ERCrossingPrefabs>();
			bool flag = true;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (scr.startPrefabScript != null || scr.endPrefabScript != null)
			{
				flag = false;
				if (scr.startPrefabScript != null)
				{
					num = scr.startPrefabScript.crossingElements[scr.startConnectionSegment].roadShapeMatchCount;
					num2 = scr.startPrefabScript.prefabId;
				}
				if (scr.endPrefabScript != null)
				{
					num = scr.endPrefabScript.crossingElements[scr.endConnectionSegment].roadShapeMatchCount;
					num3 = scr.endPrefabScript.prefabId;
				}
			}
			for (int i = 0; i < prefabs.Length; i++)
			{
				if (type == 1)
				{
					gameObject = Resources.Load("custom prefabs/" + prefabs[i]) as GameObject;
					string text = "custom prefabs/";
				}
				else
				{
					gameObject = Resources.Load("dynamic prefabs/" + prefabs[i]) as GameObject;
					string text = "dynamic prefabs/";
				}
				if (!(gameObject != null))
				{
					continue;
				}
				ERCrossingPrefabs component = gameObject.GetComponent<ERCrossingPrefabs>();
				if (!(component != null) || !(gameObject.GetComponent<ERRoundabouts>() == null))
				{
					continue;
				}
				for (int j = 0; j < component.crossingElements.Count; j++)
				{
					bool flag2 = false;
					if (component.crossingElements[j].roadType == scr.roadType)
					{
						flag2 = true;
						if (num != 0 && num2 != component.prefabId && num3 != component.prefabId && num != component.crossingElements[j].roadShapeMatchCount)
						{
							flag2 = false;
						}
					}
					if (flag2 || scr.roadShapeMatchCount == component.crossingElements[j].roadShapeMatchCount || scr.roadShapeMatchCount == 0 || (component.crossingElements[j].roadShapeMatchCount == 0 && flag))
					{
						list.Add(prefabs[i]);
						list2.Add(component);
						break;
					}
				}
			}
			if (list.Count == 0)
			{
				list.Add("No matches Found");
			}
			prefs = list2.ToArray();
			return list.ToArray();
		}

		public static bool OQCDDODDDC(ERModularRoad road, ref bool left, ref bool right)
		{
			QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(road.baseScript.roadTypes, road.roadType);
			if (roadTypeElByID != null)
			{
				if (road.roadShape.Count <= 1 || roadTypeElByID.roadShape.Count <= 1)
				{
					return false;
				}
				if (roadTypeElByID.roadWidth != road.roadWidth)
				{
					if (-1f * road.roadShape[0].x < roadTypeElByID.roadShape[0].x && -1f * road.roadShape[1].x < roadTypeElByID.roadShape[0].x)
					{
						left = true;
					}
					if (-1f * road.roadShape[road.roadShape.Count - 1].x > roadTypeElByID.roadShape[roadTypeElByID.roadShape.Count - 1].x && -1f * road.roadShape[road.roadShape.Count - 2].x > roadTypeElByID.roadShape[roadTypeElByID.roadShape.Count - 1].x)
					{
						right = true;
					}
				}
				return true;
			}
			return false;
		}

		public static bool OCDQQOQOQO(ERCrossingPrefabs prefab, ERModularRoad road, int marker, int connection)
		{
			if (prefab.isCustomPrefab || prefab.isIConnector)
			{
				return false;
			}
			if (prefab.sidewalkControlElements.Count != prefab.crossingElements.Count)
			{
				Debug.LogError("EasyRoads3Dv3: Sidewalk data is not valid for the following connection prefab: " + prefab.gameObject.name);
				return false;
			}
			if (marker == 0)
			{
				if (road.endPrefabScript != null && road.endPrefabScript.isCustomPrefab)
				{
					return false;
				}
			}
			else if (road.startPrefabScript != null && road.startPrefabScript.isCustomPrefab)
			{
				return false;
			}
			prefab.OCQQQCDODC(flag: false);
			bool left = false;
			bool right = false;
			if (!OQCDDODDDC(road, ref left, ref right))
			{
				return false;
			}
			if (marker == 0)
			{
				bool flag = left;
				left = right;
				right = flag;
			}
			bool flag2 = false;
			if (left || right)
			{
				flag2 = true;
			}
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			switch (connection)
			{
			case 0:
				num = 1;
				num2 = 2;
				num3 = 3;
				break;
			case 1:
				num = 0;
				num2 = 3;
				num3 = 2;
				break;
			case 2:
				num = 3;
				num2 = 1;
				num3 = 0;
				break;
			case 3:
				num = 2;
				num2 = 0;
				num3 = 1;
				break;
			}
			bool flag6 = left;
			bool flag7 = right;
			for (int i = 0; i < prefab.sidewalkControlElements.Count; i++)
			{
				int crossingElementLeftIndex = prefab.sidewalkControlElements[i].crossingElementLeftIndex;
				int crossingElementRightIndex = prefab.sidewalkControlElements[i].crossingElementRightIndex;
				bool flag8 = false;
				flag8 = ((left == right) ? (flag6 = (flag7 = left)) : ((crossingElementLeftIndex != connection) ? ((crossingElementLeftIndex != num) ? ((crossingElementLeftIndex != num2) ? right : left) : right) : left));
				prefab.sidewalkControlElements[i].renderFlag = flag8;
				prefab.sidewalkControlElements[i].leftConnectionHandle = flag8;
				prefab.crossingElements[prefab.sidewalkControlElements[i].crossingElementLeftIndex].includeLeftSidewalk = flag8;
				prefab.sidewalkControlElements[i].rightConnectionHandle = flag8;
				prefab.crossingElements[prefab.sidewalkControlElements[i].crossingElementRightIndex].includeRightSidewalk = flag8;
			}
			if ((bool)prefab.gameObject.GetComponent<ERCrossings>())
			{
				prefab.gameObject.GetComponent<ERCrossings>().OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
			}
			return true;
		}

		public static bool OODCDQQDDC(ERCrossingPrefabs prefab, ERModularRoad road, int marker, int connection)
		{
			return true;
		}
	}
}
