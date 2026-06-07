using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERConnection
	{
		public string name;

		public ERCrossingPrefabs prefabScript;

		public GameObject gameObject;

		public ERConnectionData[] connectionData;

		public static string str = "EasyRoads3Dv3v3 Warning: The free version does not support API calls";

		public ERConnection(GameObject go, string g_name)
		{
			name = g_name;
			gameObject = go;
			prefabScript = go.GetComponent<ERCrossingPrefabs>();
		}

		public static ERConnection Create(GameObject go)
		{
			if (go.GetComponent<ERCrossingPrefabs>() != null)
			{
				return new ERConnection(go, go.name);
			}
			return null;
		}

		public void SetPosition(Vector3 pos)
		{
			if (gameObject != null)
			{
				gameObject.transform.position = pos;
			}
			if (prefabScript != null)
			{
				prefabScript.OCOOQCCDQO(ignorePriority: true, null);
			}
		}

		public string GetName()
		{
			if (gameObject != null)
			{
				return gameObject.name;
			}
			return "";
		}

		public void SetName(string name)
		{
			if (gameObject != null)
			{
				gameObject.name = name;
			}
		}

		public void SetRotation(Vector3 euler)
		{
			if (gameObject != null)
			{
				gameObject.transform.eulerAngles = euler;
			}
			if (prefabScript != null)
			{
				prefabScript.OCOOQCCDQO(ignorePriority: true, null);
			}
		}

		public void Destroy()
		{
			if (gameObject != null)
			{
				Object.DestroyImmediate(gameObject);
			}
			if (prefabScript != null)
			{
				prefabScript.OCOOQCCDQO(ignorePriority: true, null);
			}
		}

		public void UnConnect(int connectionIndex)
		{
			if (prefabScript.crossingElements.Count <= connectionIndex)
			{
				return;
			}
			ERModularRoad eRModularRoad = null;
			int num = 0;
			if (prefabScript.crossingElements[connectionIndex].connectedRoad != null)
			{
				eRModularRoad = prefabScript.crossingElements[connectionIndex].connectedRoad;
				if (prefabScript.crossingElements[connectionIndex].connectedMarker == 0)
				{
					ODQCQOODDO.ODCOOQCQQD(eRModularRoad.baseScript, eRModularRoad, 1, 0, 0);
				}
				else
				{
					ODQCQOODDO.OQDOCOCDDO(eRModularRoad.baseScript, eRModularRoad, eRModularRoad.markersExt.Count - 2, eRModularRoad.markersExt.Count - 1, eRModularRoad.markersExt.Count - 1);
				}
			}
		}

		public ERConnectionData[] GetConnectionData()
		{
			if (prefabScript != null)
			{
				List<ERConnectionData> list = new List<ERConnectionData>();
				int num = 0;
				foreach (QDOODOQQDQODD crossingElement in prefabScript.crossingElements)
				{
					if (crossingElement.connectedRoad != null)
					{
						if (crossingElement.connectedRoad.road == null)
						{
							crossingElement.connectedRoad.road = new ERRoad(crossingElement.connectedRoad);
						}
						list.Add(new ERConnectionData(crossingElement.connectedRoad.road, crossingElement.connectedMarker, num));
					}
					num++;
				}
				if (list.Count > 0)
				{
					return list.ToArray();
				}
				return null;
			}
			return null;
		}

		public Vector3 GetLocalConnectionPosition(int connectionIndex)
		{
			if (prefabScript.crossingElements.Count > connectionIndex)
			{
				if (prefabScript.crossingElements[connectionIndex] != null)
				{
					if (prefabScript.crossingElements[connectionIndex].tmpCenterPoint != Vector3.zero)
					{
						return prefabScript.crossingElements[connectionIndex].tmpCenterPoint;
					}
					return prefabScript.crossingElements[connectionIndex].centerPoint;
				}
				return Vector3.zero;
			}
			return Vector3.zero;
		}

		public Vector3[] GetLocalConnectionPositions()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < prefabScript.crossingElements.Count; i++)
			{
				if (prefabScript.crossingElements[i] != null)
				{
					if (prefabScript.crossingElements[i].tmpCenterPoint != Vector3.zero)
					{
						list.Add(prefabScript.crossingElements[i].tmpCenterPoint);
					}
					else
					{
						list.Add(prefabScript.crossingElements[i].centerPoint);
					}
				}
			}
			return list.ToArray();
		}
	}
}
