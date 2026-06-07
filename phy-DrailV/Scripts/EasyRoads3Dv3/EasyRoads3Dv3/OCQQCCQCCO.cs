using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OCQQCCQCCO : MonoBehaviour
	{
		public static List<Vector3> debugvecs = new List<Vector3>();

		public static bool sidewaysFlag = false;

		public static bool useLastFowardFlag = false;

		public static bool lastvecPositionsArray = false;

		public static int currentSplineInt = 0;

		private static float _4AAAA = 0f;

		private static float _5AAA1 = 0f;

		private static float _6AAAA = 0f;

		private static float _7AAA1 = 0f;

		private static Vector3 _8AAAA = Vector3.zero;

		private static Vector3 _9AAA1 = Vector3.zero;

		private static float BAAAA = 0.25f;

		private static float CAAA1 = 0f;

		private static float _00AAA = 0f;

		private static float _10AA1 = 0f;

		private static float _20AAA = 0f;

		private static Vector3 _30AA1 = Vector3.zero;

		private static Vector3 _40AAA = Vector3.zero;

		private static float _50AA1 = 0.25f;

		private static float _60AAA = 0f;

		private static float _70AA1 = 0f;

		private static float _80AAA = 0f;

		private static float _90AA1 = 0f;

		private static Vector3 B0AAA = Vector3.zero;

		private static Vector3 C0AA1 = Vector3.zero;

		private static float _01AAA = 0.25f;

		private static float _11AA1 = 0f;

		private static float _21AAA = 0f;

		private static float _31AA1 = 0f;

		private static float _41AAA = 0f;

		private static Vector3 _51AA1 = Vector3.zero;

		private static Vector3 _61AAA = Vector3.zero;

		private static float _71AA1 = 0.25f;

		private static Bounds _81AAA;

		private static bool _91AA1 = false;

		public static void OOQDDODQCQ(List<SideObject> QOQDQOOQDDQOOQ, ref List<ERSORoadExt> soDataExt)
		{
			for (int i = 0; i < soDataExt.Count; i++)
			{
				if (soDataExt[i] == null)
				{
					soDataExt.RemoveAt(i);
					i--;
					continue;
				}
				bool flag = false;
				for (int j = 0; j < QOQDQOOQDDQOOQ.Count; j++)
				{
					if (QOQDQOOQDDQOOQ[j] != null && soDataExt[i].id == QOQDQOOQDDQOOQ[j].id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					soDataExt.RemoveAt(i);
					i--;
				}
			}
			for (int i = 0; i < QOQDQOOQDDQOOQ.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < soDataExt.Count; j++)
				{
					if (QOQDQOOQDDQOOQ[i] != null && soDataExt[j].id == QOQDQOOQDDQOOQ[i].id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					soDataExt.Add(ERSORoadExt.CreateInstance(QOQDQOOQDDQOOQ[i]));
				}
			}
		}

		public static void OQCDQQQDQD(ERModularBase scr, SideObject so)
		{
			for (int i = 0; i < scr.roadTypes.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < scr.roadTypes[i].soDataExt.Count; j++)
				{
					if (scr.roadTypes[i].soDataExt[j] != null && scr.roadTypes[i].soDataExt[j].id == so.id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					scr.roadTypes[i].soDataExt.Add(ERSORoadExt.CreateInstance(so));
				}
			}
			ERModularRoad[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			ERModularRoad[] array2 = array;
			foreach (ERModularRoad eRModularRoad in array2)
			{
				bool flag = false;
				foreach (ERSORoadExt item in eRModularRoad.soDataExt)
				{
					if (item.id == so.id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					eRModularRoad.soDataExt.Add(ERSORoadExt.CreateInstance(so));
				}
				foreach (ERMarkerExt item2 in eRModularRoad.markersExt)
				{
				}
				eRModularRoad.sideObjectNames = OODQOODCOD(eRModularRoad);
			}
		}

		public static void OOOCQOCDDO(ERModularBase scr, SideObject so)
		{
			if (so == null)
			{
				return;
			}
			for (int i = 0; i < scr.roadTypes.Count; i++)
			{
				for (int j = 0; j < scr.roadTypes[i].soDataExt.Count; j++)
				{
					try
					{
						if (scr.roadTypes[i].soDataExt[j].sideObject.id == so.id)
						{
							scr.roadTypes[i].soDataExt.RemoveAt(j);
							break;
						}
					}
					catch
					{
						if (scr.roadTypes[i] != null && scr.roadTypes[i].soDataExt[j] != null)
						{
							Debug.Log("Removing side object " + so.name + " from road type " + scr.roadTypes[i].roadTypeName + " failed! " + i + " " + j + " " + scr.roadTypes[i].soDataExt[j].sideObject);
						}
						else if (scr.roadTypes[i] != null)
						{
						}
					}
				}
			}
			ERModularRoad[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			bool terrainSurfaceFlag = false;
			ERModularRoad[] array2 = array;
			foreach (ERModularRoad eRModularRoad in array2)
			{
				for (int j = 0; j < eRModularRoad.soDataExt.Count; j++)
				{
					try
					{
						if (eRModularRoad.soDataExt[j].sideObject.id == so.id)
						{
							eRModularRoad.soDataExt.RemoveAt(j);
							break;
						}
						OQOQCQDQQQ(eRModularRoad, so, ref terrainSurfaceFlag);
						scr.sideObjectNames = OODQOODCOD(eRModularRoad);
					}
					catch
					{
						Debug.Log(string.Concat("Removing side object ", so.name, " from road ", eRModularRoad.gameObject.name, " failed! ", j, " ", eRModularRoad.soDataExt[j].sideObject, " ", so.name));
					}
				}
			}
		}

		public static bool OQOOQQCOQO(ERModularRoad scr, SideObject so)
		{
			if (scr.markersExt.Count == 0)
			{
				return false;
			}
			int num = 0;
			int num2 = scr.markersExt.Count - 2;
			bool result = false;
			foreach (ERMarkerExt item in scr.markersExt)
			{
				bool flag = true;
				for (int i = 0; i < item.soData.Count; i++)
				{
					if (item.soData[i] != null)
					{
						if (item.soData[i].sideObject == so)
						{
							flag = false;
							break;
						}
					}
					else
					{
						item.soData.RemoveAt(i);
					}
				}
				if (flag)
				{
					item.soData.Add(ERSOMarkerExt.CreateInstance(so, flag: true));
					if (scr.isSideObject)
					{
						item.soData[item.soData.Count - 1].active = true;
					}
					item.soData[item.soData.Count - 1].startOffset = so.defaultStartOffset;
					item.soData[item.soData.Count - 1].endOffset = so.defaultEndOffset;
					OOQODQDODC(scr, num);
					if (so.markerActive && so.indentController)
					{
						OQOOOODDDO.SetMarkerIndentAlignment(item, scr);
						result = true;
					}
				}
				num++;
			}
			scr.sideObjectNames = OODQOODCOD(scr);
			OQOCCQOQQO(scr.baseScript, scr, so);
			scr.sosCleared = false;
			return result;
		}

		public static ERSOMarkerExt[] OQOQCQDQQQ(ERModularRoad scr, SideObject so, ref bool terrainSurfaceFlag)
		{
			List<ERSOMarkerExt> list = new List<ERSOMarkerExt>();
			if (so == null)
			{
				return list.ToArray();
			}
			int num = 0;
			foreach (ERMarkerExt item in scr.markersExt)
			{
				for (int i = 0; i < item.soData.Count; i++)
				{
					try
					{
						if (item.soData[i].sideObject.id == so.id)
						{
							if (so.markerActive && so.indentController)
							{
								item.leftIndentAlignment = 0;
								item.rightIndentAlignment = 0;
								terrainSurfaceFlag = true;
							}
							list.Add(item.soData[i]);
							item.soData.RemoveAt(i);
							i--;
						}
					}
					catch
					{
						if (item.soData[i] != null)
						{
							Debug.Log(string.Concat("Removing side object ", so.name, " from road ", scr.gameObject.name, " [markers] failed! ", i, " ", item.soData[i].sideObject, " ", so.name));
						}
					}
				}
				num++;
			}
			scr.sideObjectNames = OODQOODCOD(scr);
			ERSideObjectInstance[] componentsInChildren = scr.gameObject.GetComponentsInChildren<ERSideObjectInstance>();
			ERSideObjectInstance[] array = componentsInChildren;
			foreach (ERSideObjectInstance eRSideObjectInstance in array)
			{
				if (eRSideObjectInstance.so != null)
				{
					if (eRSideObjectInstance.so.id == so.id)
					{
						UnityEngine.Object.DestroyImmediate(eRSideObjectInstance.gameObject);
					}
					continue;
				}
				string text = "";
				if (eRSideObjectInstance.transform.parent != null)
				{
					text = ", parent object: " + eRSideObjectInstance.transform.parent.gameObject.name;
				}
				Debug.LogWarning("Side Object detected with empty Side Object Instance: " + eRSideObjectInstance.gameObject.name + text);
			}
			return list.ToArray();
		}

		public static void SynchSideObjects(ERModularRoad scr1, ERModularRoad scr2)
		{
			if (scr1.soDataExt.Count != scr2.soDataExt.Count)
			{
				return;
			}
			for (int i = 0; i < scr1.soDataExt.Count; i++)
			{
				if (!scr2.soDataExt[i].active || scr1.soDataExt[i].active)
				{
					continue;
				}
				scr1.soDataExt[i].active = true;
				int num = 0;
				foreach (ERMarkerExt item in scr1.markersExt)
				{
					item.soData.Add(ERSOMarkerExt.CreateInstance(scr1.soDataExt[i].sideObject, flag: false));
					OOQODQDODC(scr1, num);
					num++;
				}
				scr1.sideObjectNames = OODQOODCOD(scr1);
			}
			for (int i = 0; i < scr1.soDataExt.Count; i++)
			{
				if (!scr1.soDataExt[i].active || scr2.soDataExt[i].active)
				{
					continue;
				}
				scr2.soDataExt[i].active = true;
				int num = 0;
				foreach (ERMarkerExt item2 in scr2.markersExt)
				{
					item2.soData.Add(ERSOMarkerExt.CreateInstance(scr2.soDataExt[i].sideObject, flag: false));
					OOQODQDODC(scr2, num);
					num++;
				}
				scr2.sideObjectNames = OODQOODCOD(scr2);
			}
		}

		public static void OOQODQDODC(ERModularRoad scr, int marker)
		{
			List<ERSOMarkerExt> list = new List<ERSOMarkerExt>();
			for (int i = 0; i < scr.soDataExt.Count; i++)
			{
				for (int j = 0; j < scr.markersExt[marker].soData.Count; j++)
				{
					if (scr.markersExt[marker].soData[j].sideObject != null)
					{
						if (scr.soDataExt[i].sideObject.id == scr.markersExt[marker].soData[j].sideObject.id)
						{
							list.Add(scr.markersExt[marker].soData[j]);
						}
					}
					else
					{
						scr.markersExt[marker].soData.RemoveAt(j);
						j--;
					}
				}
			}
			scr.markersExt[marker].soData = new List<ERSOMarkerExt>(list);
		}

		public static string[] OODQOODCOD(ERModularRoad scr)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < scr.soDataExt.Count; i++)
			{
				if (scr.soDataExt[i] != null)
				{
					if (scr.soDataExt[i].sideObject != null)
					{
						if (scr.soDataExt[i].active)
						{
							list.Add(scr.soDataExt[i].sideObject.name);
						}
					}
					else
					{
						scr.soDataExt.RemoveAt(i);
						i--;
					}
				}
				else
				{
					scr.soDataExt.RemoveAt(i);
					i--;
				}
			}
			return list.ToArray();
		}

		public static bool OQODDOODDQ(ERModularRoad scr, SideObject so, int marker)
		{
			if (so == null)
			{
				return false;
			}
			foreach (ERSOMarkerExt soDatum in scr.markersExt[marker].soData)
			{
				if (soDatum.id == so.id)
				{
					return soDatum.active;
				}
			}
			return false;
		}

		public static bool OQODDOODDQ(ERModularRoad scr, SideObject so, int marker, ref float startOffset, ref float endOffset, ref ERSOMarkerExt soMarker)
		{
			if (so == null || marker >= scr.markersExt.Count)
			{
				return false;
			}
			bool flag = false;
			if (!scr.closedTrack && marker == scr.markersExt.Count - 1)
			{
				flag = true;
			}
			bool flag2 = true;
			if (marker == 0)
			{
				flag2 = false;
			}
			bool flag3 = true;
			if (marker >= scr.markersExt.Count - 1)
			{
				flag3 = false;
			}
			int num = 0;
			foreach (ERSOMarkerExt soDatum in scr.markersExt[marker].soData)
			{
				if (soDatum == null)
				{
					return false;
				}
				if (soDatum.id == so.id)
				{
					if (flag2)
					{
						if (scr.markersExt[marker - 1].soData[num].active || !soDatum.active)
						{
							startOffset = 0f;
						}
						else
						{
							startOffset = soDatum.startOffset;
						}
					}
					else
					{
						startOffset = soDatum.startOffset;
					}
					if ((flag3 && scr.markersExt[marker + 1].soData[num].active && marker + 1 != scr.markersExt.Count - 1) || !soDatum.active)
					{
						endOffset = 0f;
					}
					else
					{
						endOffset = soDatum.endOffset;
					}
					soMarker = soDatum;
					if (marker == scr.markersExt.Count - 2 && soDatum.endOffset == 0f && soDatum.active)
					{
						useLastFowardFlag = true;
					}
					if (flag)
					{
						return false;
					}
					return soDatum.active;
				}
				num++;
			}
			return false;
		}

		public static bool GetSidewaysPosition(ERModularRoad scr, SideObject so, ref List<float> sidewaysList, ref bool customNodelistFlag, ref List<List<Vector2>> nodeListValues, ref List<int> shapeTransitionTypes)
		{
			if (so == null)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < scr.markersExt.Count; i++)
			{
				int num = 0;
				foreach (ERSOMarkerExt soDatum in scr.markersExt[i].soData)
				{
					if (soDatum == null)
					{
						return false;
					}
					if (soDatum.id == so.id)
					{
						if (soDatum.splineActive)
						{
							sidewaysList.Add(soDatum.sidewaysDistance);
						}
						else
						{
							sidewaysList.Add(-1E+10f);
						}
						if (soDatum.sidewaysDistance != 0f)
						{
							result = true;
						}
						if (so.objectType == 1)
						{
							if (soDatum.nodeList.Count != so.nodeList.Count)
							{
								soDatum.nodeList = new List<Vector2>(so.nodeList);
							}
							if (OCQCDQCQOQ.CompareVector2List(soDatum.nodeList, so.nodeList))
							{
								customNodelistFlag = true;
							}
							nodeListValues.Add(soDatum.nodeList);
							shapeTransitionTypes.Add(soDatum.shapeTransitionType);
							customNodelistFlag = true;
						}
					}
					num++;
				}
			}
			if (scr.closedTrack && nodeListValues.Count > 0)
			{
				nodeListValues.Add(nodeListValues[0]);
				shapeTransitionTypes.Add(shapeTransitionTypes[0]);
			}
			return result;
		}

		public static bool ODDCCQDCOC(ERModularBase scr, ERModularRoad roadScr)
		{
			ERSideObjectInstance[] componentsInChildren = roadScr.gameObject.GetComponentsInChildren<ERSideObjectInstance>();
			ERSideObjectInstance[] array = componentsInChildren;
			foreach (ERSideObjectInstance eRSideObjectInstance in array)
			{
				if ((bool)eRSideObjectInstance.gameObject.GetComponent<MeshFilter>() && eRSideObjectInstance.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
				{
					eRSideObjectInstance.gameObject.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
				if ((bool)eRSideObjectInstance.gameObject.GetComponent<MeshCollider>() && eRSideObjectInstance.gameObject.GetComponent<MeshCollider>().sharedMesh != null)
				{
					eRSideObjectInstance.gameObject.GetComponent<MeshCollider>().sharedMesh.Clear();
				}
				List<GameObject> list;
				if (eRSideObjectInstance.so != null)
				{
					if (eRSideObjectInstance.so.objectType == 0)
					{
						list = new List<GameObject>();
						foreach (Transform item in eRSideObjectInstance.transform)
						{
							list.Add(item.gameObject);
						}
						foreach (GameObject item2 in list)
						{
							UnityEngine.Object.DestroyImmediate(item2);
						}
						continue;
					}
					list = new List<GameObject>();
					for (int j = 0; j < eRSideObjectInstance.transform.childCount; j++)
					{
						Transform transform = eRSideObjectInstance.transform.GetChild(j);
						list.Add(transform.gameObject);
						if ((bool)transform.GetComponent<MeshFilter>() && transform.GetComponent<MeshFilter>().sharedMesh != null)
						{
							transform.GetComponent<MeshFilter>().sharedMesh = null;
						}
						if ((bool)transform.GetComponent<MeshCollider>() && transform.GetComponent<MeshCollider>().sharedMesh != null)
						{
							transform.GetComponent<MeshCollider>().sharedMesh = null;
						}
						if ((bool)transform.GetComponent<BoxCollider>())
						{
							UnityEngine.Object.DestroyImmediate(transform.gameObject);
							j--;
						}
					}
					foreach (GameObject item3 in list)
					{
						UnityEngine.Object.DestroyImmediate(item3);
					}
					continue;
				}
				list = new List<GameObject>();
				foreach (Transform item4 in eRSideObjectInstance.transform)
				{
					list.Add(item4.gameObject);
				}
				foreach (GameObject item5 in list)
				{
					UnityEngine.Object.DestroyImmediate(item5);
				}
			}
			for (int j = 0; j < roadScr.soDataExt.Count; j++)
			{
				if (roadScr.soDataExt[j].active)
				{
					return true;
				}
			}
			return false;
		}

		public static void OQCQDCDODO(ERModularRoad rScr, SideObject so)
		{
			if (so == null)
			{
				return;
			}
			foreach (ERMarkerExt item in rScr.markersExt)
			{
				for (int i = 0; i < item.soData.Count; i++)
				{
					if (item.soData[i].id == so.id)
					{
						if (so.sidewaysDistanceUpdate == 1 || item.soData[i].sidewaysDistance == so.oldSidwaysDistance)
						{
							item.soData[i].sidewaysDistance = so.splinePosition;
						}
						break;
					}
				}
			}
		}

		public static bool OCODDQQOCC(ERModularRoad road, int marker, int soIndex)
		{
			if (marker == road.markersExt.Count - 1 || !road.markersExt[marker].soData[soIndex].active)
			{
				return false;
			}
			if (marker == 0)
			{
				if (!road.closedTrack)
				{
					return true;
				}
				if (road.markersExt[road.markersExt.Count - 1].soData[soIndex].active)
				{
					return false;
				}
				return true;
			}
			if (road.markersExt[marker - 1].soData[soIndex].active)
			{
				return false;
			}
			return true;
		}

		public static bool OQQOCQDQDQ(ERModularRoad road, int marker, int soIndex)
		{
			if (marker == road.markersExt.Count - 1 || !road.markersExt[marker].soData[soIndex].active)
			{
				return false;
			}
			if (marker == road.markersExt.Count - 2)
			{
				if (!road.closedTrack)
				{
					return true;
				}
				if (road.markersExt[0].soData[soIndex].active)
				{
					return false;
				}
				return true;
			}
			if (road.markersExt[marker + 1].soData[soIndex].active)
			{
				return false;
			}
			return true;
		}

		public static void ODDQCOQQDD(ERModularBase scr, ERModularRoad roadScr, SideObject so)
		{
			ERSideObjectInstance[] componentsInChildren = roadScr.gameObject.GetComponentsInChildren<ERSideObjectInstance>();
			ERSideObjectInstance[] array = componentsInChildren;
			foreach (ERSideObjectInstance eRSideObjectInstance in array)
			{
				if (so != null)
				{
					if (eRSideObjectInstance.id != so.id)
					{
						continue;
					}
					if ((bool)eRSideObjectInstance.gameObject.GetComponent<MeshFilter>() && eRSideObjectInstance.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
					{
						eRSideObjectInstance.gameObject.GetComponent<MeshFilter>().sharedMesh.Clear();
					}
					if ((bool)eRSideObjectInstance.gameObject.GetComponent<MeshCollider>() && eRSideObjectInstance.gameObject.GetComponent<MeshCollider>().sharedMesh != null)
					{
						eRSideObjectInstance.gameObject.GetComponent<MeshCollider>().sharedMesh.Clear();
					}
					List<GameObject> list = new List<GameObject>();
					foreach (Transform item in eRSideObjectInstance.transform)
					{
						list.Add(item.gameObject);
					}
					foreach (GameObject item2 in list)
					{
						UnityEngine.Object.DestroyImmediate(item2);
					}
				}
				else
				{
					string text = "";
					if (eRSideObjectInstance.transform.parent != null)
					{
						text = ", parent object: " + eRSideObjectInstance.transform.parent.gameObject.name;
					}
					Debug.LogWarning("Side Object detected with empty Side Object Instance: " + eRSideObjectInstance.gameObject.name + text);
				}
			}
		}

		public static void OQOCCODQOC(ERModularBase scr, ERModularRoad roadScr, bool isSideObjectFlag)
		{
			for (int i = 0; i < roadScr.soDataExt.Count; i++)
			{
				if (roadScr.soDataExt[i] != null && roadScr.soDataExt[i].active && (!roadScr.isSideObject || isSideObjectFlag))
				{
					OQOCCQOQQO(scr, roadScr, roadScr.soDataExt[i].sideObject);
				}
			}
			roadScr.sosCleared = false;
		}

		public static void OQOCCQOQQO(ERModularBase scr, ERModularRoad roadScr, SideObject so)
		{
			GameObject gameObject = null;
			if (so == null)
			{
				return;
			}
			ERSideObjectInstance[] componentsInChildren = roadScr.gameObject.GetComponentsInChildren<ERSideObjectInstance>();
			ERSideObjectInstance[] array = componentsInChildren;
			foreach (ERSideObjectInstance eRSideObjectInstance in array)
			{
				if (eRSideObjectInstance.so != null)
				{
					if (eRSideObjectInstance.so == so)
					{
						gameObject = eRSideObjectInstance.gameObject;
						break;
					}
					continue;
				}
				string text = "";
				if (eRSideObjectInstance.transform.parent != null)
				{
					text = ", parent object: " + eRSideObjectInstance.transform.parent.gameObject.name;
				}
				Debug.LogWarning("Side Object detected with empty Side Object Instance: " + eRSideObjectInstance.gameObject.name + text);
			}
			if (gameObject == null || (bool)so.targetObject)
			{
				if ((bool)so.targetObject)
				{
					if ((bool)gameObject)
					{
						UnityEngine.Object.DestroyImmediate(gameObject);
					}
					gameObject = UnityEngine.Object.Instantiate(so.targetObject);
					if ((bool)gameObject.GetComponent<MeshFilter>())
					{
						if ((bool)gameObject.GetComponent<MeshFilter>().sharedMesh)
						{
							Mesh sharedMesh = UnityEngine.Object.Instantiate(gameObject.GetComponent<MeshFilter>().sharedMesh);
							gameObject.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
							if ((bool)gameObject.GetComponent<MeshCollider>() && (bool)gameObject.GetComponent<MeshCollider>().sharedMesh)
							{
								gameObject.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
							}
						}
					}
					else
					{
						foreach (Transform item in gameObject.transform)
						{
							if ((bool)item.GetComponent<MeshFilter>().sharedMesh)
							{
								Mesh sharedMesh = UnityEngine.Object.Instantiate(item.GetComponent<MeshFilter>().sharedMesh);
								item.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
								if ((bool)item.GetComponent<MeshCollider>() && (bool)item.GetComponent<MeshCollider>().sharedMesh)
								{
									item.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
								}
							}
						}
					}
					gameObject.transform.position = Vector3.zero;
					gameObject.transform.eulerAngles = Vector3.zero;
					gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				}
				else
				{
					gameObject = new GameObject(so.name);
				}
				gameObject.transform.parent = roadScr.transform;
				gameObject.AddComponent<ERSideObjectInstance>();
				gameObject.GetComponent<ERSideObjectInstance>().so = so;
				gameObject.GetComponent<ERSideObjectInstance>().id = so.id;
				gameObject.GetComponent<ERSideObjectInstance>().roadScript = roadScr;
			}
			else
			{
				gameObject.transform.position = Vector3.zero;
				if ((bool)gameObject.GetComponent<MeshRenderer>() && so.material != null && so.material != gameObject.GetComponent<MeshRenderer>().sharedMaterial)
				{
					gameObject.GetComponent<MeshRenderer>().sharedMaterial = so.material;
				}
			}
			gameObject.layer = so.layer;
			gameObject.isStatic = so.isStatic;
			ERSORoadExt soData = null;
			foreach (ERSORoadExt item2 in roadScr.soDataExt)
			{
				if (item2.sideObject == so)
				{
					soData = item2;
					break;
				}
			}
			if (so.objectType == 0)
			{
				if (so.sourceObject == null)
				{
					Debug.Log("EasyRoads3Dv3: No Source Object has been assigned to this side object (" + so.name + "), side object creation aborted");
				}
				else
				{
					OQCDQQOOOD(gameObject, so, roadScr, soData);
				}
			}
			else if (so.objectType == 1)
			{
				if (so.meshObjects.Count == 0)
				{
					Debug.Log("EasyRoads3Dv3: no shape is defined for this side object (" + so.name + "), side object creation aborted");
					return;
				}
				if (so.snapList.Count < so.nodeList.Count)
				{
					for (int j = so.snapList.Count; j < so.nodeList.Count; j++)
					{
						so.snapList.Add(item: false);
					}
					so.UpdateTimeStamp();
				}
				if (so.colorList.Count < so.nodeList.Count)
				{
					for (int j = so.colorList.Count; j < so.nodeList.Count; j++)
					{
						so.colorList.Add(Color.white);
					}
					so.UpdateTimeStamp();
				}
				if (so.snapWeightList.Count < so.nodeList.Count)
				{
					for (int j = 0; j < so.nodeList.Count; j++)
					{
						if (so.snapList[j])
						{
							so.snapWeightList.Add(1f);
						}
						else
						{
							so.snapWeightList.Add(0f);
						}
					}
					so.UpdateTimeStamp();
				}
				OQCDQQOOOD(gameObject, so, roadScr, soData);
			}
			else
			{
				if (so.objectType != 2)
				{
					return;
				}
				if (so.meshObjects.Count == 0)
				{
					Debug.Log("EasyRoads3Dv3: no source mesh is defined for this side object (" + so.name + "), side object creation aborted");
					return;
				}
				int childCount = gameObject.transform.childCount;
				int j;
				for (j = 0; j < gameObject.transform.childCount; j++)
				{
					UnityEngine.Object.DestroyImmediate(gameObject.transform.GetChild(j).gameObject);
					j--;
				}
				OQCDQQOOOD(gameObject, so, roadScr, soData);
			}
		}

		public static void OQCDQQOOOD(GameObject go, SideObject so, ERModularRoad roadScr, ERSORoadExt soData)
		{
			bool flag = false;
			foreach (ERSOMarkerExt soDatum in roadScr.markersExt[0].soData)
			{
				if (soDatum == null)
				{
					OQQOOODQDQ.ResetMarkerSOData(roadScr);
				}
			}
			debugvecs.Clear();
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Color> list4 = new List<Color>();
			List<Vector4> list5 = new List<Vector4>();
			List<float> list6 = new List<float>();
			List<float> list7 = new List<float>();
			List<Vector3> list8 = null;
			List<Vector3> list9 = null;
			List<Vector3> list10 = null;
			List<Vector3> list11 = null;
			List<float> list12 = null;
			_9AAA1 = Vector2.zero;
			_51AA1 = Vector2.zero;
			_61AAA = Vector2.zero;
			_51AA1 = Vector2.zero;
			useLastFowardFlag = false;
			lastvecPositionsArray = false;
			if (soData != null)
			{
				OQQOOODQDQ.SynchSoData(soData, flag: false);
				list8 = ((so.relativeTo != 1 && so.position != 1) ? ((so.relativeTo != 2 && so.position != 2) ? new List<Vector3>(roadScr.soSplinePoints) : new List<Vector3>(roadScr.soSplinePointsRight)) : new List<Vector3>(roadScr.soSplinePointsLeft));
				list11 = new List<Vector3>(roadScr.soSplinePoints);
				if (roadScr.OOQDQQOQCD.Count == 0)
				{
					if (list11.Count == 0)
					{
						return;
					}
					roadScr.OQCODCDCDC = new List<float>();
					roadScr.OOQDQQOQCD = roadScr.OQCDDDCOOD(roadScr.tValues, roadScr.markerDistances, roadScr.markersExt, 0, roadScr.tmpMarkersExt.Count, ref roadScr.OQCODCDCDC, roadScr.randomRotations);
				}
				list12 = new List<float>(roadScr.OOQDQQOQCD);
				list9 = new List<Vector3>(roadScr.soSplinePointsLeft);
				list10 = new List<Vector3>(roadScr.soSplinePointsRight);
				List<int> markerInts = new List<int>(roadScr.markerInts);
				List<float> sidewaysList = new List<float>();
				sidewaysFlag = false;
				bool customNodelistFlag = false;
				List<List<Vector2>> nodeListValues = new List<List<Vector2>>();
				List<int> shapeTransitionTypes = new List<int>();
				List<float> tValues = new List<float>();
				List<Vector3> tmpMarkers = new List<Vector3>();
				List<float> markerDistances = new List<float>();
				List<List<Vector2>> nodeList = new List<List<Vector2>>();
				if (GetSidewaysPosition(roadScr, so, ref sidewaysList, ref customNodelistFlag, ref nodeListValues, ref shapeTransitionTypes))
				{
					sidewaysFlag = true;
					markerInts.Clear();
					list8 = OCQCDQCQOQ.GetSoSplinePoints(roadScr, sidewaysList, ref markerInts, ref tValues, ref markerDistances, ref tmpMarkers);
					list9.Clear();
					list10.Clear();
					for (int i = 0; i < list8.Count; i++)
					{
						Vector3 vector = ((i != 0) ? ((i != list8.Count - 1) ? (list8[i + 1] - list8[i - 1]) : (list8[list8.Count - 1] - list8[list8.Count - 2])) : (list8[i + 1] - list8[i]));
						vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
						list9.Add(list8[i] - vector);
						list10.Add(list8[i] + vector);
					}
					list11 = new List<Vector3>(list8);
				}
				else
				{
					sidewaysList.Clear();
					tValues = roadScr.tValues;
					markerDistances = roadScr.markerDistances;
				}
				if (so.objectType == 1)
				{
					if (so.nodeList.Count == 0)
					{
						return;
					}
					if (so.clampUVs && so.nodeList.Count != so.uvs.Count)
					{
						so.ODDDODDCQC();
					}
					if (!customNodelistFlag)
					{
						for (int j = 0; j < so.nodeList.Count; j++)
						{
							nodeList.Add(new List<Vector2>());
							for (int i = 0; i < list11.Count; i++)
							{
								nodeList[j].Add(so.nodeList[j]);
							}
						}
					}
					else if (markerDistances.Count != 0)
					{
						nodeList = OCQCDQCQOQ.GetRoadShapeValues(tValues, markerDistances, nodeListValues, 0, roadScr.tmpMarkersExt.Count, so.nodeList, shapeTransitionTypes, roadScr.closedTrack);
					}
					else
					{
						Debug.LogError("EasyRoads3Dv3: Please Refresh the Road Network: General Settings > Scene Settings");
					}
					List<Vector3> list13 = new List<Vector3>();
					int index = 0;
					for (int i = 0; i < roadScr.markersExt[0].soData.Count; i++)
					{
						if (roadScr.markersExt[0].soData[i].sideObject == so)
						{
							index = i;
							break;
						}
					}
					for (int i = 0; i < roadScr.markersExt.Count; i++)
					{
						int num = roadScr.markersExt[i].startSplinePoint - 1;
						if (num >= list8.Count)
						{
							num = list8.Count - 1;
						}
						if (i == 0)
						{
							num = 0;
						}
						Vector3 v = Vector3.zero;
						Vector3 v2 = list8[num];
						Vector3 dir = ((list8.Count <= num + 1) ? (list8[num] - list8[num - 1]).normalized : (list8[num + 1] - list8[num]).normalized);
						list13.Clear();
						for (int k = 0; k < so.nodeList.Count; k++)
						{
							List<Vector2> nodeList2 = roadScr.markersExt[i].soData[index].nodeList;
							if (so.align == 1 || (sidewaysFlag && so.align != 0))
							{
								OCQCDQCQOQ.OQOCCODDQQ(ref v, v2, dir, nodeList2[k], roadScr, _9AAA1);
							}
							else if (so.align == 2 || so.align == 0)
							{
								OCQCDQCQOQ.OQQCCQCQQC(ref v, v2, dir, nodeList2[k], 0f, _9AAA1);
							}
							else if (so.align == 3)
							{
								OCQCDQCQOQ.OQQCCQCQQC(ref v, v2, dir, nodeList2[k], list12[num], _9AAA1);
							}
							list13.Add(v);
						}
						roadScr.markersExt[i].soData[index].nodeShapeVecsGlobal = new List<Vector3>(list13);
					}
				}
				List<Vector3> vecPositions = new List<Vector3>(list8);
				List<Vector3> list14 = new List<Vector3>();
				List<Vector3> list15 = new List<Vector3>();
				List<Vector3> list16 = new List<Vector3>(list11);
				List<float> list17 = new List<float>(list12);
				List<float> list18 = new List<float>();
				List<float> list19 = new List<float>();
				List<float> list20 = new List<float>();
				List<List<Vector3>> list21 = new List<List<Vector3>>();
				List<List<Vector3>> list22 = new List<List<Vector3>>();
				List<List<Vector3>> list23 = new List<List<Vector3>>();
				List<List<Vector3>> list24 = new List<List<Vector3>>();
				List<List<float>> list25 = new List<List<float>>();
				List<List<List<Vector2>>> list26 = new List<List<List<Vector2>>>();
				List<List<float>> list27 = new List<List<float>>();
				List<List<float>> list28 = new List<List<float>>();
				List<List<float>> list29 = new List<List<float>>();
				if (vecPositions.Count != list16.Count || (list16.Count != list17.Count && !sidewaysFlag))
				{
					Debug.LogWarning("EasyRoads3Dv3 Warning: incomplete spline data, generating " + so.name + " aborted. Please try to refresh the road network (General Settings > Scene Settings)");
					return;
				}
				Vector3 pTarget = Vector3.zero;
				if (roadScr.markerInts.Count == 0)
				{
					return;
				}
				if (soData.xPosition != 0f && so.position == 0 && sidewaysList.Count == 0)
				{
					vecPositions.Clear();
					markerInts.Clear();
					for (int i = 0; i < list8.Count; i++)
					{
						Vector3 vector;
						if (!roadScr.isSideObject)
						{
							vector = (list10[i] - list9[i]).normalized;
						}
						else
						{
							vector = ((i == 0) ? (list8[1] - list8[0]) : ((i != list8.Count - 1) ? (list8[i + 1] - list8[i - 1]) : (list8[list8.Count - 1] - list8[list8.Count - 2])));
							vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
						}
						Vector3 v2 = list8[i] + soData.xPosition * vector;
						if (i == 0)
						{
							vecPositions.Add(v2);
							markerInts.Add(roadScr.markerInts[0]);
							pTarget = v2;
						}
						else if (soData.xPosition > 0f)
						{
							if (!OCQCDQCQOQ.OOOOCDQQOC(pTarget, list8[i - 1], v2))
							{
								vecPositions.Add(v2);
								markerInts.Add(roadScr.markerInts[i]);
								pTarget = v2;
							}
						}
						else if (OCQCDQCQOQ.OOOOCDQQOC(pTarget, list8[i - 1], v2))
						{
							vecPositions.Add(v2);
							markerInts.Add(roadScr.markerInts[i]);
							pTarget = v2;
						}
					}
					if (vecPositions.Count <= 1 && list8.Count > 1)
					{
						Debug.LogError("EasyRoads3Dv3 Error: could not extract side object spline points. Please report with full details");
						return;
					}
				}
				else if (so.sidewaysOffset == 0f)
				{
				}
				int num2 = 0;
				float startOffset = 0f;
				float endOffset = 0f;
				int startInt = 0;
				ERSOMarkerExt soMarker = null;
				bool flag2 = OQODDOODDQ(roadScr, so, 0, ref startOffset, ref endOffset, ref soMarker);
				if (flag2 && (startOffset != 0f || roadScr.startOffsetActiveMarker != -1))
				{
					OQQOOODQDQ.OCDQODDQOC(ref startInt, startOffset, ref markerInts, ref vecPositions, ref list9, list10, ref soMarker, roadScr, ref nodeList);
				}
				else if (flag2)
				{
					OQQOOODQDQ.OOODQDDDOQ(0, vecPositions, markerInts, ref soMarker, startFlag: true, roadScr);
				}
				if (flag2 && endOffset != 0f)
				{
					OQQOOODQDQ.OOOCQOCCQQ(startInt, endOffset, ref markerInts, ref vecPositions, ref list9, list10, ref soMarker, roadScr, ref nodeList);
				}
				else if (flag2)
				{
					OQQOOODQDQ.OOODQDDDOQ(0, vecPositions, markerInts, ref soMarker, startFlag: false, roadScr);
				}
				bool flag3 = flag2;
				bool flag4 = flag2;
				bool flag5 = false;
				list21.Add(new List<Vector3>());
				list22.Add(new List<Vector3>());
				list23.Add(new List<Vector3>());
				list24.Add(new List<Vector3>());
				list25.Add(new List<float>());
				list27.Add(new List<float>());
				list28.Add(new List<float>());
				list29.Add(new List<float>());
				list26.Add(new List<List<Vector2>>());
				for (int l = 0; l < nodeList.Count; l++)
				{
					list26[0].Add(new List<Vector2>());
				}
				float num3 = 0f;
				int num4 = 0;
				if (soMarker == null)
				{
					return;
				}
				if (soMarker.rotationAngle != 0f)
				{
					float num5 = soMarker.rotationDistance;
					if (num5 < 3f * so.middleZDistance)
					{
						num5 = 3f * so.middleZDistance;
					}
					list27[0].Add(num3 + soMarker.rotationCenter - num5 * 0.5f);
					list28[0].Add(num5);
					list29[0].Add(soMarker.rotationAngle);
				}
				int num6 = 0;
				for (int i = startInt; i < vecPositions.Count; i++)
				{
					if (flag2)
					{
						list21[num6].Add(vecPositions[i]);
						list22[num6].Add(list9[i]);
						list23[num6].Add(list10[i]);
						if (!sidewaysFlag)
						{
							if (list16.Count > i)
							{
								list24[num6].Add(list16[i]);
							}
							else if (list24[num6].Count - 1 < list16.Count)
							{
								list24[num6].Add(list16[list24[num6].Count - 1]);
							}
							if (list17.Count > i)
							{
								list25[num6].Add(list17[i]);
							}
							else
							{
								list25[num6].Add(0f);
							}
						}
						for (int l = 0; l < nodeList.Count; l++)
						{
							list26[num6][l].Add(nodeList[l][i]);
						}
					}
					if (i >= vecPositions.Count - 1)
					{
						continue;
					}
					if (num2 != markerInts[i])
					{
						flag2 = OQODDOODDQ(roadScr, so, markerInts[i], ref startOffset, ref endOffset, ref soMarker);
						if (flag2 && startOffset != 0f)
						{
							OQQOOODQDQ.OCDQODDQOC(ref i, startOffset, ref markerInts, ref vecPositions, ref list9, list10, ref soMarker, roadScr, ref nodeList);
						}
						else if (flag2)
						{
							OQQOOODQDQ.OOODQDDDOQ(i, vecPositions, markerInts, ref soMarker, startFlag: true, roadScr);
						}
						if (flag2 && endOffset != 0f)
						{
							OQQOOODQDQ.OOOCQOCCQQ(i, endOffset, ref markerInts, ref vecPositions, ref list9, list10, ref soMarker, roadScr, ref nodeList);
						}
						else if (flag2)
						{
							OQQOOODQDQ.OOODQDDDOQ(i, vecPositions, markerInts, ref soMarker, startFlag: false, roadScr);
						}
						if (!flag4 && flag2 && list21[num6].Count > 0)
						{
							list21.Add(new List<Vector3>());
							list22.Add(new List<Vector3>());
							list23.Add(new List<Vector3>());
							list24.Add(new List<Vector3>());
							list25.Add(new List<float>());
							list26.Add(new List<List<Vector2>>());
							for (int l = 0; l < nodeList.Count; l++)
							{
								list26[num6 + 1].Add(new List<Vector2>());
							}
							list27.Add(new List<float>());
							list28.Add(new List<float>());
							list29.Add(new List<float>());
							num6++;
							num3 = 0f;
							num4 = 0;
							list21[num6].Add(vecPositions[i]);
							list22[num6].Add(list9[i]);
							list23[num6].Add(list10[i]);
							list24[num6].Add(list16[i]);
							if (list17.Count > i)
							{
								list25[num6].Add(list17[i]);
							}
							else
							{
								list25[num6].Add(0f);
							}
							for (int l = 0; l < nodeList.Count; l++)
							{
								list26[num6][l].Add(nodeList[l][i]);
							}
						}
						else if (!flag4 && flag2)
						{
							list21[num6].Add(vecPositions[i]);
							list22[num6].Add(list9[i]);
							list23[num6].Add(list10[i]);
							list24[num6].Add(list16[i]);
							if (list17.Count > i)
							{
								list25[num6].Add(list17[i]);
							}
							else
							{
								list25[num6].Add(0f);
							}
							for (int l = 0; l < nodeList.Count; l++)
							{
								list26[num6][l].Add(nodeList[l][i]);
							}
						}
						if (flag2 && i > 0 && num4 > 0 && soMarker.rotationAngle != 0f)
						{
							float num5 = soMarker.rotationDistance;
							if (num5 < 3f * so.middleZDistance)
							{
								num5 = 3f * so.middleZDistance;
							}
							list27[num6].Add(num3 + soMarker.rotationCenter - num5 * 0.5f);
							list28[num6].Add(num5);
							list29[num6].Add(soMarker.rotationAngle);
						}
						flag4 = flag2;
						num2 = markerInts[i];
					}
					else
					{
						if (flag2 && i > 0 && num4 > 0)
						{
							num3 += Vector3.Distance(vecPositions[i - 1], vecPositions[i]);
						}
						num4++;
					}
				}
				if (so.snapToTerrain)
				{
					for (int i = 0; i < vecPositions.Count; i++)
					{
						Vector3 v2 = vecPositions[i];
						v2.y = OCQCDQCQOQ.OOOQQOODDD(v2, roadScr.baseScript);
						vecPositions[i] = v2;
					}
				}
				for (int i = 0; i < roadScr.soDataExt.Count; i++)
				{
					if (roadScr.soDataExt[i].id == so.id)
					{
						roadScr.soDataExt[i].vecPositions = new List<Vector3>(vecPositions);
					}
				}
				bool flag6 = true;
				bool flag7 = true;
				if (roadScr.closedTrack && flag3 && flag4)
				{
					flag6 = false;
					flag7 = false;
				}
				if (so.objectType == 0 && so.bridgeObject)
				{
					flag7 = false;
				}
				if (soData.yPosition != 0f)
				{
					for (int j = 0; j < list21.Count; j++)
					{
						for (int i = 0; i < list21[j].Count; i++)
						{
							Vector3 v2 = list21[j][i];
							v2.y += soData.yPosition;
							list21[j][i] = v2;
						}
					}
				}
				List<float> list30 = new List<float>();
				List<List<float>> list31 = new List<List<float>>();
				List<float> list32 = new List<float>();
				float num7 = 0f;
				for (int j = 0; j < list21.Count; j++)
				{
					list6.Add(0f);
					list7.Add(0f);
					float num8 = 0f;
					num7 = 0f;
					float num9 = 0f;
					Vector3 position = roadScr.markersExt[0].position;
					Vector3 zero = Vector3.zero;
					Vector3 vector2 = new Vector3(-1000000f, 0f, -1000000f);
					list31.Add(new List<float>());
					list31[j].Add(0f);
					for (int i = 1; i < list21[j].Count; i++)
					{
						num7 += Vector3.Distance(list21[j][i - 1], list21[j][i]);
						list31[j].Add(num7);
					}
					if (list21[j].Count < 2)
					{
						break;
					}
					Vector3 normalized = (list21[j][list21[j].Count - 1] - list21[j][list21[j].Count - 2]).normalized;
					if (normalized == Vector3.zero)
					{
						normalized = (list21[j][list21[j].Count - 1] - list21[j][list21[j].Count - 3]).normalized;
					}
					zero = list21[j][list21[j].Count - 1] + 100f * normalized;
					list21[j].Add(zero);
					zero = list22[j][list22[j].Count - 1] + 100f * normalized;
					list22[j].Add(zero);
					zero = list23[j][list23[j].Count - 1] + 100f * normalized;
					list23[num6].Add(zero);
					list31[j].Add(num7 + Vector3.Distance(list21[j][list21[j].Count - 2], list21[j][list21[j].Count - 1]));
					list32.Add(num7);
				}
				if (go == null)
				{
					return;
				}
				for (int m = 0; m < so.meshObjects.Count; m++)
				{
					so.meshObjects[m].Clear();
				}
				so.instantiatedObjects.Clear();
				so.SetMaxVertices();
				float halfRoadWidth = 0.5f * roadScr.roadWidth;
				bool flag8 = true;
				Vector3 forward = Vector3.zero;
				Vector3 startPos = Vector3.zero;
				float clampUVYPerc = 1f;
				for (int j = 0; j < list21.Count; j++)
				{
					if (list32.Count == 0)
					{
						break;
					}
					bool flag9 = false;
					bool flag10 = false;
					if (j == 0 && flag3 && flag4 && roadScr.closedTrack)
					{
						flag9 = true;
					}
					if (j == list21.Count - 1 && flag3 && flag4 && roadScr.closedTrack)
					{
						flag10 = true;
					}
					num7 = list32[j];
					vecPositions = list21[j];
					list14 = list22[j];
					list15 = list23[j];
					list16 = list24[j];
					list17 = list25[j];
					nodeList = list26[j];
					list30 = list31[j];
					float num10 = 0f;
					float num9 = 0f;
					for (int l = 0; l < so.nodeList.Count - 1; l++)
					{
						num9 += Vector2.Distance(so.nodeList[l], so.nodeList[l + 1]);
					}
					num10 = 1f / num9;
					if (so.clampUVY && so.objectType == 1 && roadScr.baseScript.clampUVs)
					{
						float num11 = list30[list30.Count - 2] * so.uvy * num10;
						clampUVYPerc = (Mathf.Round(num11) - (1f - so.clampUVYValue)) / num11;
					}
					if (so.objectType < 2)
					{
						so.middleZDistance = so.m_distance;
					}
					if (so.middleZDistance == 0f)
					{
						so.middleZDistance = 1f;
					}
					float num12 = num7;
					if (j == 0 && flag6 && so.includeStartSegment && so.startZDistance != 2000f)
					{
						num12 -= so.startZDistance;
					}
					else if (j != 0 && so.includeStartSegment && so.startZDistance != 2000f)
					{
						num12 -= so.startZDistance;
					}
					if (j == list21.Count - 1 && flag7 && so.includeEndSegment && so.endZDistance != -2000f)
					{
						num12 -= so.endZDistance;
					}
					else if (j != list21.Count - 1 && so.includeEndSegment && so.endZDistance != -2000f)
					{
						num12 -= so.endZDistance;
					}
					float num13 = Mathf.Round(num12 / so.middleZDistance);
					if (num13 == 0f)
					{
						num13 = 1f;
					}
					float num14 = num12 / (num13 * so.middleZDistance / so.scale.z);
					if (so.objectType == 0 && so.bridgeObject)
					{
						num14 = 1f;
					}
					if (so.objectType == 1)
					{
						Terrain[] array = UnityEngine.Object.FindObjectsOfType(typeof(Terrain)) as Terrain[];
						Terrain terrain = OQOQCOQOOQ(vecPositions[0]);
						Vector3 vector3 = (_81AAA.min = new Vector3(terrain.transform.position.x, 0f, terrain.transform.position.z));
						vector3.x += terrain.terrainData.size.x;
						vector3.z += terrain.terrainData.size.z;
						_81AAA.max = vector3;
						vector3.x = terrain.terrainData.size.x;
						vector3.z = terrain.terrainData.size.z;
						_81AAA.size = vector3;
					}
					float num15 = 0f;
					float num16 = 0f;
					float num17 = 0f;
					int num18 = 1;
					int num19 = 0;
					int num20 = 0;
					bool flag11 = false;
					int currentVecArrayInt = 0;
					int num21 = 0;
					int num22 = 0;
					bool skipStartBlend = false;
					bool skipEndBlend = false;
					if (j == 0 && !flag6)
					{
						skipStartBlend = true;
					}
					if (j == list21.Count - 1 && !flag7)
					{
						skipEndBlend = true;
					}
					if (j == list21.Count - 1)
					{
						lastvecPositionsArray = true;
						if (!flag7)
						{
							skipEndBlend = true;
						}
					}
					flag8 = true;
					_4AAAA = 0f;
					_5AAA1 = 0f;
					_6AAAA = 0f;
					_7AAA1 = 0f;
					_8AAAA = Vector3.zero;
					BAAAA = 0.25f;
					CAAA1 = 0f;
					_00AAA = 0f;
					_10AA1 = 0f;
					_20AAA = 0f;
					_30AA1 = Vector3.zero;
					_40AAA = Vector3.zero;
					_50AA1 = 0.25f;
					_60AAA = 0f;
					_70AA1 = 0f;
					_80AAA = 0f;
					_90AA1 = 0f;
					B0AAA = Vector3.zero;
					C0AA1 = Vector3.zero;
					_01AAA = 0.25f;
					_11AA1 = 0f;
					_21AAA = 0f;
					_31AA1 = 0f;
					_41AAA = 0f;
					_51AA1 = Vector3.zero;
					_61AAA = Vector3.zero;
					_91AA1 = false;
					while (num15 + 0.1f < num7)
					{
						if (num15 < 0f)
						{
							Debug.LogError("EasyRoads3Dv3: " + so.name + " - unable to generate side object, please check the side objects setting in the Side Object Manager");
							return;
						}
						num21++;
						if (num15 >= _10AA1)
						{
							_00AAA = (_10AA1 = num15);
							float num23 = UnityEngine.Random.Range(soData.minRandomXPositionDistance, soData.maxRandomXPositionDistance);
							if (num23 < 3f * so.middleZDistance)
							{
								num23 = 3f * so.middleZDistance;
							}
							CAAA1 = 0.5f * num23;
							_10AA1 += num23;
							_20AAA = Mathf.Lerp(_00AAA, _10AA1, 0.5f);
							_30AA1.x = UnityEngine.Random.Range(soData.randomMinXPosition, soData.randomMaxXPosition);
							if (_10AA1 > num7)
							{
								_10AA1 = num7;
								if (_10AA1 - _00AAA < 3f * so.middleZDistance)
								{
									_30AA1.x = 0f;
								}
							}
							if (_20AAA > num7)
							{
								_20AAA = num7;
								if (_20AAA - _00AAA < 2f * so.middleZDistance)
								{
									_30AA1.x = 0f;
								}
							}
						}
						if (_30AA1.x != 0f)
						{
							if (num15 < _20AAA)
							{
								float t = (num15 - _20AAA) / (_20AAA - _00AAA);
								_40AAA.x = Mathf.Lerp(0f, _30AA1.x, Mathf.SmoothStep(0f, 1f, t));
							}
							else
							{
								float t = (num15 - _20AAA) / (_10AA1 - _20AAA);
								_40AAA.x = Mathf.Lerp(_30AA1.x, 0f, Mathf.SmoothStep(0f, 1f, t));
							}
						}
						if (num15 >= _80AAA)
						{
							_70AA1 = (_80AAA = num15);
							float num23 = UnityEngine.Random.Range(soData.minRandomYPositionDistance, soData.maxRandomYPositionDistance);
							if (num23 < 3f * so.middleZDistance)
							{
								num23 = 3f * so.middleZDistance;
							}
							_60AAA = 0.5f * num23;
							_80AAA += num23;
							_90AA1 = Mathf.Lerp(_70AA1, _80AAA, 0.5f);
							B0AAA.x = UnityEngine.Random.Range(soData.randomMinYPosition, soData.randomMaxYPosition);
							if (_80AAA > num7)
							{
								_80AAA = num7;
								if (_80AAA - _70AA1 < 3f * so.middleZDistance)
								{
									B0AAA.x = 0f;
								}
							}
							if (_90AA1 > num7)
							{
								_90AA1 = num7;
								if (_90AA1 - _70AA1 < 2f * so.middleZDistance)
								{
									B0AAA.x = 0f;
								}
							}
						}
						if (B0AAA.x != 0f)
						{
							if (num15 < _90AA1)
							{
								float t = (num15 - _90AA1) / (_90AA1 - _70AA1);
								C0AA1.x = Mathf.Lerp(0f, B0AAA.x, Mathf.SmoothStep(0f, 1f, t));
							}
							else
							{
								float t = (num15 - _90AA1) / (_80AAA - _90AA1);
								C0AA1.x = Mathf.Lerp(B0AAA.x, 0f, Mathf.SmoothStep(0f, 1f, t));
							}
						}
						if (num15 >= _6AAAA)
						{
							_5AAA1 = (_6AAAA = num15);
							float num23 = UnityEngine.Random.Range(soData.minRandomRotationDistance, soData.maxRandomRotationDistance);
							if (num23 < 3f * so.middleZDistance)
							{
								num23 = 3f * so.middleZDistance;
							}
							_4AAAA = 0.5f * num23;
							_6AAAA += num23;
							_7AAA1 = Mathf.Lerp(_5AAA1, _6AAAA, 0.5f);
							_8AAAA.x = UnityEngine.Random.Range(soData.randomMinRotation, soData.randomMaxRotation);
							if (_6AAAA > num7)
							{
								_6AAAA = num7;
								if (_6AAAA - _5AAA1 < 3f * so.middleZDistance)
								{
									_8AAAA.x = 0f;
								}
							}
							if (_7AAA1 > num7)
							{
								_7AAA1 = num7;
								if (_7AAA1 - _5AAA1 < 2f * so.middleZDistance)
								{
									_8AAAA.x = 0f;
								}
							}
							if (_8AAAA.x != 0f && list27[j].Count > 0 && _6AAAA > list27[j][0])
							{
								_6AAAA = _31AA1 + so.middleZDistance;
								_7AAA1 = Mathf.Lerp(_5AAA1, _6AAAA, 0.5f);
								_8AAAA.x = 0f;
							}
						}
						if (list27[j].Count > 0 && num15 > list27[j][0])
						{
							_21AAA = (_31AA1 = num15);
							_31AA1 += list28[j][0];
							_41AAA = Mathf.Lerp(_21AAA, _31AA1, 0.5f);
							_51AA1.x = list29[j][0];
							_11AA1 = 0.5f * list28[j][0];
							list27[j].RemoveAt(0);
							list28[j].RemoveAt(0);
							list29[j].RemoveAt(0);
						}
						if (_8AAAA.x != 0f)
						{
							if (num15 < _7AAA1)
							{
								float t = (num15 - _5AAA1) / (_7AAA1 - _5AAA1);
								_9AAA1.x = Mathf.Lerp(0f, _8AAAA.x, Mathf.SmoothStep(0f, 1f, t));
							}
							else
							{
								float t = (num15 - _7AAA1) / (_6AAAA - _7AAA1);
								_9AAA1.x = Mathf.Lerp(_8AAAA.x, 0f, Mathf.SmoothStep(0f, 1f, t));
							}
						}
						if (so.objectType == 0)
						{
							OCQQDCCQCO(go, num15, num14, so, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, num21, roadScr, -1, soData);
							if (!(num15 + so.m_distance * num14 + 1f >= num7) || !roadScr.closedTrack || j < list21.Count - 1 || !OQODDOODDQ(roadScr, so, 0) || !flag4)
							{
							}
							if (so.density == 0f)
							{
								num15 += so.m_distance * num14;
							}
							else
							{
								num15 += (so.m_distance + UnityEngine.Random.value * so.density) * num14;
								if (num15 + 0.1f > num7)
								{
									num15 = num7 + 0.01f;
								}
							}
							OOQCOOOOQC(num15, list30, ref currentVecArrayInt);
						}
						else if (so.objectType == 1)
						{
							ODQODQCODO(num15, so.meshObjects[0], 1, roadScr.markersExt, list6, list7, num18, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, debugFlag: false, num20, flag11, num14, so, roadScr, nodeList, clampUVYPerc, num10, soData);
							if (so.startObject != null && num21 == 1)
							{
								OCQQDCCQCO(go, num15, num14, so, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, num21, roadScr, 0, soData);
							}
							else if (so.connectionObject != null && num21 > 1 && !flag11)
							{
								OCQQDCCQCO(go, num15, num14, so, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, num21, roadScr, 1, soData);
							}
							else if (flag11 && so.endObject != null && flag7)
							{
								OCQQDCCQCO(go, num15, num14, so, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, num21, roadScr, 2, soData);
							}
							if (so.position == 0)
							{
								int num24 = currentVecArrayInt;
								OOQCOOOOQC(num15, list30, ref currentVecArrayInt);
								if (so.scaleToRoad)
								{
									num22 = ((num24 >= currentVecArrayInt) ? (num22 + 1) : 0);
									if (num22 >= 3)
									{
										num15 = 0.2f + num7;
									}
									num15 += Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1]);
								}
								else
								{
									num15 += so.middleZDistance * num14;
								}
							}
							else
							{
								currentVecArrayInt++;
								num15 = list30[currentVecArrayInt];
							}
							if (num15 + 0.1f > num7 && num15 - 0.25f < num7)
							{
								num15 = num7 - 0.11f;
								flag11 = true;
							}
							if (!flag11 || j < list21.Count - 1)
							{
								CheckVertexLimit(so, 0);
							}
						}
						else
						{
							for (int m = 0; m < so.meshObjects.Count; m++)
							{
								so.meshObjects[m].vecCount = so.meshObjects[m].sVecs.Count;
								if (num15 == 0f && so.includeStartSegment && (flag6 || j != 0))
								{
									if (so.meshObjects[m].zValuesStart.Count > 0)
									{
										ODQDOQDQOC(num15, so.meshObjects[m], 0, roadScr.markersExt, list6, list7, num18, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, debugFlag: false, num20, lastSegment: false, 1f, so, halfRoadWidth, roadScr, flag8, skipStartBlend, skipEndBlend, ref forward, ref startPos, soData);
										if (so.boxcollider)
										{
											AddBoxCollider(go, so, so.startZDistance, num15, vecPositions, list30, currentVecArrayInt, roadScr, list16, soData);
										}
									}
								}
								else if (!flag11 || !so.includeEndSegment || (!flag7 && j == list21.Count - 1))
								{
									ODQDOQDQOC(num15, so.meshObjects[m], 1, roadScr.markersExt, list6, list7, num18, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, debugFlag: false, num20, lastSegment: false, num14, so, halfRoadWidth, roadScr, flag8, skipStartBlend, skipEndBlend, ref forward, ref startPos, soData);
									if (so.boxcollider)
									{
										AddBoxCollider(go, so, so.middleZDistance, num15, vecPositions, list30, currentVecArrayInt, roadScr, list16, soData);
									}
								}
								else if (so.meshObjects[m].zValuesEnd.Count > 0)
								{
									ODQDOQDQOC(num15, so.meshObjects[m], 2, roadScr.markersExt, list6, list7, num18, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, debugFlag: true, num20, lastSegment: true, 1f, so, halfRoadWidth, roadScr, flag8, skipStartBlend, skipEndBlend, ref forward, ref startPos, soData);
									if (so.boxcollider)
									{
										AddBoxCollider(go, so, so.endZDistance, num15, vecPositions, list30, currentVecArrayInt, roadScr, list16, soData);
									}
								}
							}
							if (so.startObject != null && num21 == 1)
							{
								OCQQDCCQCO(go, num15, num14, so, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, num21, roadScr, 0, soData);
							}
							else if (so.connectionObject != null && num21 > 1)
							{
								OCQQDCCQCO(go, num15, num14, so, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, num21, roadScr, 1, soData);
							}
							bool flag12 = flag11;
							if (num15 == 0f && so.includeStartSegment && !flag9)
							{
								num15 = (so.scaleToRoad ? (num15 + Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1])) : (num15 + so.startZDistance));
								OOQCOOOOQC(num15, list30, ref currentVecArrayInt);
							}
							else if (flag11 && so.includeEndSegment)
							{
								num15 = (so.scaleToRoad ? (num15 + Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1])) : (num15 + so.endZDistance));
							}
							else
							{
								num15 = (so.scaleToRoad ? (num15 + Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1])) : (num15 + so.middleZDistance * num14));
								int num24 = currentVecArrayInt;
								OOQCOOOOQC(num15, list30, ref currentVecArrayInt);
								if (!so.scaleToRoad)
								{
								}
							}
							if (num15 + so.endZDistance + 0.1f >= num7)
							{
								flag11 = true;
							}
							if (so.scaleToRoad && currentVecArrayInt >= vecPositions.Count - 3)
							{
								flag11 = true;
							}
							if (flag11)
							{
								if (so.includeEndSegment)
								{
									CheckVertexLimit(so, 2);
								}
								else
								{
									CheckVertexLimit(so, 1);
								}
							}
							else if (flag12)
							{
								if (j < list21.Count - 1)
								{
									if (so.includeStartSegment)
									{
										CheckVertexLimit(so, 0);
									}
									else
									{
										CheckVertexLimit(so, 1);
									}
								}
							}
							else
							{
								CheckVertexLimit(so, 1);
							}
						}
						if (list7.Count > num18 && num15 > list7[num18])
						{
							num18++;
						}
						num20++;
						flag8 = false;
					}
					if ((so.objectType == 0 || so.connectionObject != null || so.endObject != null) && flag7 && so.objectType != 1)
					{
						_91AA1 = true;
						OCQQDCCQCO(go, num15, num14, so, vecPositions, list14, list15, list16, list17, list30, currentVecArrayInt, num21, roadScr, 2, soData);
					}
					if (so.objectType != 1 || so.clampUVY)
					{
					}
				}
				if (!flag7)
				{
					for (int m = 0; m < so.meshObjects.Count; m++)
					{
						for (int i = 0; i < so.meshObjects[m].middleStartInts.Count; i++)
						{
							List<Vector3> sVecs = so.meshObjects[m].sVecs;
							int index2 = so.meshObjects[m].middleStartInts[i];
							Vector3 value = (so.meshObjects[m].sVecs[so.meshObjects[m].sVecs.Count - so.meshObjects[m].vecs.Count + so.meshObjects[m].middleEndInts[i]] = Vector3.Lerp(so.meshObjects[m].sVecs[so.meshObjects[m].middleStartInts[i]], so.meshObjects[m].sVecs[so.meshObjects[m].sVecs.Count - so.meshObjects[m].vecs.Count + so.meshObjects[m].middleEndInts[i]], 0.5f));
							sVecs[index2] = value;
							if (so.smoothMiddle)
							{
								so.meshObjects[m].normalArray1.Add(so.meshObjects[m].middleStartInts[i]);
								so.meshObjects[m].normalArray2.Add(so.meshObjects[m].sVecs.Count - so.meshObjects[m].vecs.Count + so.meshObjects[m].middleEndInts[i]);
							}
						}
					}
				}
				if (so.objectType != 0)
				{
					if (so.objectType == 1 && roadScr.closedTrack && flag3 && flag4)
					{
						for (int i = 0; i < so.nodeList.Count; i++)
						{
							List<Vector3> sVecs2 = so.meshObjects[0].sVecs;
							int index3 = i;
							Vector3 value = (so.meshObjects[0].sVecs[so.meshObjects[0].sVecs.Count - so.nodeList.Count + i] = Vector3.Lerp(so.meshObjects[0].sVecs[i], so.meshObjects[0].sVecs[so.meshObjects[0].sVecs.Count - so.nodeList.Count + i], 0.5f));
							sVecs2[index3] = value;
							so.meshObjects[0].normalArray1.Add(i);
							so.meshObjects[0].normalArray2.Add(so.meshObjects[0].sVecs.Count - so.nodeList.Count + i);
						}
					}
					so.meshObjects[0].OODOQQQCDD(go, so, roadScr.baseScript);
					go.GetComponent<ERSideObjectInstance>().vecs = debugvecs;
					return;
				}
				Transform transform = go.transform.Find("container");
				if (so.combine)
				{
					int num25 = 65000;
					if (so.instantiatedObjects.Count * so.maxVertices > num25)
					{
						List<GameObject> list33 = new List<GameObject>();
						float num26 = Mathf.Ceil(so.instantiatedObjects.Count * so.maxVertices / num25);
						int num21 = 1;
						int num27 = 0;
						GameObject gameObject = new GameObject("Batch 1");
						list33.Add(gameObject);
						gameObject.transform.parent = go.transform;
						while (so.instantiatedObjects.Count > 0)
						{
							if ((num27 + 1) * so.maxVertices > num25)
							{
								ERMeshCombineUtility.CombineMesh(gameObject, null, transform, roadScr.isSideObject);
								num21++;
								num27 = 0;
								gameObject = new GameObject("Batch " + num21);
								list33.Add(gameObject);
								gameObject.transform.parent = go.transform;
							}
							so.instantiatedObjects[0].transform.parent = gameObject.transform;
							num27++;
							so.instantiatedObjects.RemoveAt(0);
						}
						if (num27 > 0)
						{
							ERMeshCombineUtility.CombineMesh(gameObject, null, transform, roadScr.isSideObject);
						}
						go.GetComponent<ERSideObjectInstance>().batchedObjects = new List<GameObject>(list33);
						go.GetComponent<ERSideObjectInstance>().batches = true;
					}
					else
					{
						ERMeshCombineUtility.CombineMesh(go, null, transform, roadScr.isSideObject);
						go.GetComponent<ERSideObjectInstance>().batchedObjects.Clear();
						go.GetComponent<ERSideObjectInstance>().batches = false;
					}
					go.GetComponent<ERSideObjectInstance>().combined = true;
				}
				else
				{
					if (transform != null)
					{
						UnityEngine.Object.DestroyImmediate(transform.gameObject);
					}
					if ((bool)go.GetComponent<MeshFilter>())
					{
						UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshFilter>());
					}
					if ((bool)go.GetComponent<MeshRenderer>())
					{
						UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshRenderer>());
					}
				}
			}
			else
			{
				Debug.LogError("Missing side object data: " + go.name + " for road: " + roadScr.gameObject.name);
				UnityEngine.Object.DestroyImmediate(go);
			}
		}

		public static void AddBoxCollider(GameObject go, SideObject so, float zDist, float curDist, List<Vector3> vecPositions, List<float> vecDistances, int currentVecArrayInt, ERModularRoad roadScr, List<Vector3> vecPositionsCenter, ERSORoadExt soData)
		{
			Vector3 v2;
			Vector3 zero;
			Vector3 v = (v2 = (zero = Vector3.zero));
			if (!so.scaleToRoad)
			{
				OOQCQOQDCC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: false, debugFlag: false);
				OOQCQOQDCC(curDist + zDist, vecPositions, vecDistances, currentVecArrayInt, ref v2, ref v2, doSecond: false, debugFlag: false);
			}
			else
			{
				v = vecPositions[currentVecArrayInt];
				v2 = vecPositions[currentVecArrayInt + 1];
				zDist = Vector3.Distance(v, v2);
			}
			if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
			{
				if (so.snapToTerrain)
				{
					v.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition;
				}
				if (so.snapToTerrain)
				{
					v2.y = OCQCDQCQOQ.OOOQQOODDD(v2, roadScr.baseScript) + soData.yPosition;
				}
			}
			else if (roadScr.snapToTerrain || !roadScr.isSideObject)
			{
				if (so.snapToTerrain)
				{
					v.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition;
				}
				if (so.snapToTerrain)
				{
					v2.y = OCQCDQCQOQ.OOOQQOODDD(v2, roadScr.baseScript) + soData.yPosition;
				}
			}
			zero = (v2 - v).normalized;
			if ((double)so.boxSize.x < 0.01)
			{
				so.boxSize.x = 0.01f;
			}
			GameObject gameObject = new GameObject("BoxCollider");
			gameObject.transform.position = Vector3.Lerp(v, v2, 0.5f);
			gameObject.transform.forward = zero;
			BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
			boxCollider.size = new Vector3(so.boxSize.x * so.scale.x * so.boxColliderScale.x, so.boxSize.y * so.scale.y * so.boxColliderScale.y, zDist * so.scale.z * so.boxColliderScale.z);
			boxCollider.center = new Vector3(so.boxOffset.x * so.scale.x, so.boxOffset.y * so.scale.y, 0f);
			Vector3 _1AAAA = Vector3.zero;
			Vector3 _1AAAA2 = Vector3.zero;
			Vector3 _1AAAA3 = Vector3.zero;
			if (_30AA1.x != 0f)
			{
				ᙄ(curDist, ref _1AAAA, ref _40AAA, _00AAA, _20AAA, _10AA1, CAAA1, _30AA1);
			}
			if (B0AAA.x != 0f)
			{
				ᙄ(curDist, ref _1AAAA2, ref C0AA1, _70AA1, _90AA1, _80AAA, _60AAA, B0AAA);
			}
			if (_8AAAA.x != 0f)
			{
				ᙄ(curDist, ref _1AAAA3, ref _9AAA1, _5AAA1, _7AAA1, _6AAAA, _4AAAA, _8AAAA);
			}
			if (_51AA1.x != 0f)
			{
				ᙅ(curDist, ref _1AAAA3);
			}
			if (so.align == 1 || (sidewaysFlag && so.align != 0))
			{
				OCQCDQCQOQ.OQOCDQCDCQ(gameObject, v, roadScr, _1AAAA3);
			}
			else if (so.align == 2)
			{
				OCQCDQCQOQ.OODCQODDQQ(gameObject, v2, v, zero, _1AAAA3);
			}
			else if (so.align == 3)
			{
				if (currentSplineInt >= vecPositionsCenter.Count)
				{
					currentSplineInt = vecPositionsCenter.Count - 1;
				}
				OCQCDQCQOQ.ODQOQDCQDC(gameObject, vecPositionsCenter[currentSplineInt], roadScr, _1AAAA3);
			}
			else if (_1AAAA3 != Vector3.zero)
			{
				OCQCDQCQOQ.OODCQODDQQ(gameObject, v2, v, zero, _1AAAA3);
			}
			gameObject.transform.parent = go.transform;
		}

		public static void CheckVertexLimit(SideObject so, int segment)
		{
			float num = 65000f;
			bool flag = false;
			if (so.objectType == 1)
			{
				if ((float)(so.meshObjects[0].sVecs.Count + so.nodeList.Count) >= num)
				{
					flag = true;
				}
			}
			else
			{
				foreach (ERMesh meshObject in so.meshObjects)
				{
					int num2 = 0;
					switch (segment)
					{
					case 0:
						num2 = meshObject.sStartVecs.Count;
						break;
					case 1:
						num2 = meshObject.vecsInt.Count;
						break;
					case 2:
						num2 = meshObject.endVecsInt.Count;
						break;
					}
					if ((float)(meshObject.sVecs.Count + num2) > num)
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				return;
			}
			foreach (ERMesh meshObject2 in so.meshObjects)
			{
				meshObject2.sVecsGroups.Add(new List<Vector3>(meshObject2.sVecs));
				meshObject2.sUvGroups.Add(new List<Vector2>(meshObject2.sUv));
				meshObject2.sUv2Groups.Add(new List<Vector2>(meshObject2.sUv2));
				meshObject2.sColorsGroups.Add(new List<Color>(meshObject2.sColors));
				meshObject2.sNormalsGroups.Add(new List<Vector3>(meshObject2.sNormals));
				meshObject2.sTangentsGroups.Add(new List<Vector4>(meshObject2.sTangents));
				meshObject2.sTrianglesGroups.Add(new List<int>(meshObject2.sTriangles));
				meshObject2.normalArray1Group.Add(new List<int>(meshObject2.normalArray1));
				meshObject2.normalArray2Group.Add(new List<int>(meshObject2.normalArray2));
				meshObject2.sTerrainNormalsGroups.Add(new List<Vector3>(meshObject2.sTerrainNormals));
				if (so.objectType == 1)
				{
					int count = Math.Max(0, meshObject2.sVecs.Count - so.nodeList.Count);
					if (meshObject2.sVecs.Count > 0)
					{
						meshObject2.sVecs.RemoveRange(0, count);
					}
					if (meshObject2.sUv.Count > 0)
					{
						meshObject2.sUv.RemoveRange(0, count);
					}
					if (meshObject2.sUv2.Count > 0)
					{
						meshObject2.sUv2.RemoveRange(0, count);
					}
					if (meshObject2.sColors.Count > 0)
					{
						meshObject2.sColors.RemoveRange(0, count);
					}
					if (meshObject2.sNormals.Count > 0)
					{
						meshObject2.sNormals.RemoveRange(0, count);
					}
					if (meshObject2.sTangents.Count > 0)
					{
						meshObject2.sTangents.RemoveRange(0, count);
					}
					meshObject2.sTriangles.Clear();
					if (meshObject2.normalArray1.Count > 0)
					{
						meshObject2.normalArray1.RemoveRange(0, count);
					}
					if (meshObject2.normalArray2.Count > 0)
					{
						meshObject2.normalArray2.RemoveRange(0, count);
					}
					if (meshObject2.sTerrainNormals.Count > 0)
					{
						meshObject2.sTerrainNormals.RemoveRange(0, count);
					}
				}
				else
				{
					meshObject2.sVecs.Clear();
					meshObject2.sUv.Clear();
					meshObject2.sUv2.Clear();
					meshObject2.sColors.Clear();
					meshObject2.sNormals.Clear();
					meshObject2.sTangents.Clear();
					meshObject2.sTriangles.Clear();
					meshObject2.normalArray1.Clear();
					meshObject2.normalArray2.Clear();
					meshObject2.sTerrainNormals.Clear();
				}
			}
		}

		public static void ODQDOQDQOC(float curDist, ERMesh mobject, int meshSegment, List<ERMarkerExt> markers, List<float> segmentDistances, List<float> segmentAccDistances, int markerIndex, List<Vector3> vecPositions, List<Vector3> vecPositionsLeft, List<Vector3> vecPositionsRight, List<Vector3> vecPositionsCenter, List<float> vecAngles, List<float> vecDistances, int currentVecArrayInt, bool debugFlag, int segmentCount, bool lastSegment, float scaleFactor, SideObject so, float halfRoadWidth, ERModularRoad roadScr, bool newSegment, bool skipStartBlend, bool skipEndBlend, ref Vector3 forward, ref Vector3 startPos, ERSORoadExt soData)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Color> list4 = new List<Color>();
			List<Vector3> list5 = new List<Vector3>();
			List<Vector4> list6 = new List<Vector4>();
			List<int> list7 = new List<int>();
			List<Vector3> list8 = new List<Vector3>();
			List<Vector2> collection = new List<Vector2>();
			List<Vector2> collection2 = new List<Vector2>();
			List<Color> collection3 = new List<Color>();
			List<Vector3> collection4 = new List<Vector3>();
			List<Vector4> collection5 = new List<Vector4>();
			List<int> list9 = new List<int>();
			List<float> list10 = new List<float>();
			List<ZIndexArray> list11 = new List<ZIndexArray>();
			List<Vector3> list12 = new List<Vector3>();
			switch (meshSegment)
			{
			case 0:
				list12 = new List<Vector3>(mobject.startVecs);
				list = mobject.sVecs;
				list2 = mobject.sUv;
				list3 = mobject.sUv2;
				list4 = mobject.sColors;
				list5 = mobject.sNormals;
				list6 = mobject.sTangents;
				list7 = mobject.sTriangles;
				list10 = mobject.zValuesStart;
				list11 = mobject.zValueVecIndexesStart;
				list8 = mobject.startVecs;
				collection = mobject.startUv;
				collection2 = mobject.startUv2;
				collection3 = mobject.startColors;
				collection4 = mobject.startNormals;
				collection5 = mobject.startTangents;
				list9 = mobject.startTriangles;
				break;
			case 1:
				list12 = new List<Vector3>(mobject.vecs);
				list = mobject.sVecs;
				list2 = mobject.sUv;
				list3 = mobject.sUv2;
				list4 = mobject.sColors;
				list5 = mobject.sNormals;
				list6 = mobject.sTangents;
				list7 = mobject.sTriangles;
				list10 = mobject.zValues;
				list11 = mobject.zValueVecIndexes;
				list8 = mobject.vecs;
				collection = mobject.uv;
				collection2 = mobject.uv2;
				collection3 = mobject.colors;
				collection4 = mobject.normals;
				collection5 = mobject.tangents;
				list9 = mobject.triangles;
				break;
			case 2:
				list12 = new List<Vector3>(mobject.endVecs);
				list = mobject.sVecs;
				list2 = mobject.sUv;
				list3 = mobject.sUv2;
				list4 = mobject.sColors;
				list5 = mobject.sNormals;
				list6 = mobject.sTangents;
				list7 = mobject.sTriangles;
				list10 = mobject.zValuesEnd;
				list11 = mobject.zValueVecIndexesEnd;
				list8 = mobject.endVecs;
				collection = mobject.endUv;
				collection2 = mobject.endUv2;
				collection3 = mobject.endColors;
				collection4 = mobject.endNormals;
				collection5 = mobject.endTangents;
				list9 = mobject.endTriangles;
				break;
			}
			try
			{
				float num = 0f;
				if (so.scaleToRoad)
				{
					num = Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1]);
					switch (meshSegment)
					{
					case 0:
						scaleFactor = num / so.startZDistance;
						break;
					case 1:
						scaleFactor = num / so.middleZDistance;
						break;
					case 2:
						scaleFactor = num / so.endZDistance;
						break;
					}
					curDist = vecDistances[currentVecArrayInt];
				}
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				Vector3 zero3 = Vector3.zero;
				Vector3 v2;
				Vector3 v = (v2 = Vector3.zero);
				for (int i = 0; i < list10.Count; i++)
				{
					float num2 = curDist + list10[i] * scaleFactor;
					OOQCQOQDCC(num2, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag);
					if (currentSplineInt >= vecAngles.Count)
					{
						currentSplineInt = vecAngles.Count - 1;
					}
					if (currentSplineInt >= vecPositionsRight.Count)
					{
						currentSplineInt = vecPositionsRight.Count - 1;
					}
					Vector3 vector = (lastSegment ? forward : (forward = v2 - v));
					vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
					if (useLastFowardFlag && lastvecPositionsArray && currentSplineInt >= vecPositions.Count - 2)
					{
						forward = roadScr.lastForward;
					}
					if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
					{
						if (so.snapToTerrain)
						{
							v.y = (v2.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition);
						}
						vector = (vecPositionsRight[currentSplineInt] - vecPositionsLeft[currentSplineInt]).normalized;
					}
					else if ((roadScr.snapToTerrain || !roadScr.isSideObject) && so.snapToTerrain)
					{
						v.y = (v2.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition);
					}
					startPos = v;
					Vector3 zero4 = Vector3.zero;
					zero = Vector3.zero;
					zero2 = Vector3.zero;
					zero3 = Vector3.zero;
					if (_30AA1.x != 0f)
					{
						ᙃ(num2, ref zero, ref _40AAA, _00AAA, _20AAA, _10AA1, CAAA1, _30AA1);
						v += vector * zero.x;
						v2 += vector * zero.x;
					}
					if (B0AAA.x != 0f)
					{
						ᙃ(num2, ref zero2, ref C0AA1, _70AA1, _90AA1, _80AAA, _60AAA, B0AAA);
					}
					if (_8AAAA.x != 0f)
					{
						ᙄ(num2, ref zero3, ref _9AAA1, _5AAA1, _7AAA1, _6AAAA, _4AAAA, _8AAAA);
					}
					if (_51AA1.x != 0f)
					{
						ᙅ(num2, ref zero3);
					}
					for (int j = 0; j < list11[i].index.Count; j++)
					{
						Vector2 vec = list8[list11[i].index[j]];
						Vector3 v3;
						if (!so.adjustToRoadWidth || Mathf.Abs(list8[list11[i].index[j]].x) < so.xOffset)
						{
							v3 = v + vector * (list8[list11[i].index[j]].x * so.scale.x);
						}
						else if (list8[list11[i].index[j]].x < 0f)
						{
							vec.x = list8[list11[i].index[j]].x + so.xOffset - halfRoadWidth;
							v3 = v + vector * vec.x * so.scale.x;
						}
						else
						{
							vec.x = list8[list11[i].index[j]].x - so.xOffset + halfRoadWidth;
							v3 = v + vector * vec.x * so.scale.x;
						}
						v3.y += list8[list11[i].index[j]].y * so.scale.y;
						if (so.align == 1 || (sidewaysFlag && so.align != 0))
						{
							OCQCDQCQOQ.OQOCCODDQQ(ref v3, v, forward, vec, roadScr, zero3);
						}
						else if (so.align == 2)
						{
							OCQCDQCQOQ.OQQCCQCQQC(ref v3, v, forward, vec, 0f, zero3);
						}
						else if (so.align == 3)
						{
							OCQCDQCQOQ.OQQCCQCQQC(ref v3, v, forward, vec, vecAngles[currentSplineInt], zero3);
						}
						else if (zero3.x != 0f)
						{
							OCQCDQCQOQ.RandomAlignment(ref v3, v, forward, vec, zero3);
						}
						if (B0AAA.x != 0f)
						{
							v3.y += zero2.x;
						}
						list12[list11[i].index[j]] = v3;
					}
				}
				if (debugFlag)
				{
				}
				list.AddRange(list12);
				list2.AddRange(collection);
				list3.AddRange(collection2);
				list4.AddRange(collection3);
				list5.AddRange(collection4);
				list6.AddRange(collection5);
				int count = list.Count;
				switch (OCQCDQCQOQ.ODOQDCOOOQ(segmentCount, so, newSegment, mobject, lastSegment, skipStartBlend, skipEndBlend))
				{
				case 0:
				{
					if (count - mobject.vecs.Count - mobject.startVecs.Count < 0)
					{
						break;
					}
					for (int i = 0; i < mobject.startEndInts.Count; i++)
					{
						List<Vector3> list15 = list;
						int index3 = count - mobject.vecs.Count + mobject.middleStartStartInts[i];
						Vector3 value = (list[count - mobject.vecs.Count - mobject.startVecs.Count + mobject.startEndInts[i]] = Vector3.Lerp(list[count - mobject.vecs.Count + mobject.middleStartStartInts[i]], list[count - mobject.vecs.Count - mobject.startVecs.Count + mobject.startEndInts[i]], 0.5f));
						list15[index3] = value;
						if (so.smoothStart)
						{
							mobject.normalArray1.Add(count - mobject.vecs.Count + mobject.middleStartStartInts[i]);
							mobject.normalArray2.Add(count - mobject.vecs.Count - mobject.startVecs.Count + mobject.startEndInts[i]);
						}
					}
					break;
				}
				case 1:
				{
					if (count - 2 * mobject.vecs.Count < 0)
					{
						break;
					}
					for (int i = 0; i < mobject.middleStartInts.Count; i++)
					{
						if (segmentCount == 2)
						{
						}
						List<Vector3> list14 = list;
						int index2 = count - mobject.vecs.Count + mobject.middleStartInts[i];
						Vector3 value = (list[count - 2 * mobject.vecs.Count + mobject.middleEndInts[i]] = Vector3.Lerp(list[count - mobject.vecs.Count + mobject.middleStartInts[i]], list[count - 2 * mobject.vecs.Count + mobject.middleEndInts[i]], 0.5f));
						list14[index2] = value;
						if (so.smoothMiddle)
						{
							mobject.normalArray1.Add(count - mobject.vecs.Count + mobject.middleStartInts[i]);
							mobject.normalArray2.Add(count - 2 * mobject.vecs.Count + mobject.middleEndInts[i]);
						}
					}
					break;
				}
				case 2:
				{
					if (count - mobject.endVecs.Count - mobject.vecs.Count < 0)
					{
						break;
					}
					for (int i = 0; i < mobject.middleEndEndInts.Count; i++)
					{
						List<Vector3> list13 = list;
						int index = count - mobject.endVecs.Count + mobject.endStartInts[i];
						Vector3 value = (list[count - mobject.endVecs.Count - mobject.vecs.Count + mobject.middleEndEndInts[i]] = Vector3.Lerp(list[count - mobject.endVecs.Count + mobject.endStartInts[i]], list[count - mobject.endVecs.Count - mobject.vecs.Count + mobject.middleEndEndInts[i]], 0.5f));
						list13[index] = value;
						if (so.smoothEnd)
						{
							mobject.normalArray1.Add(count - mobject.endVecs.Count + mobject.endStartInts[i]);
							mobject.normalArray2.Add(count - mobject.endVecs.Count - mobject.vecs.Count + mobject.middleEndEndInts[i]);
						}
					}
					break;
				}
				}
				for (int i = 0; i < list9.Count; i++)
				{
					list7.Add(mobject.vecCount + list9[i]);
				}
			}
			catch
			{
				Debug.LogError("EasyRoads3Dv3 Error: Road: " + roadScr.name + " - Side Object: " + so.name);
			}
		}

		public static void ODQODQCODO(float curDist, ERMesh mobject, int meshSegment, List<ERMarkerExt> markers, List<float> segmentDistances, List<float> segmentAccDistances, int markerIndex, List<Vector3> vecPositions, List<Vector3> vecPositionsLeft, List<Vector3> vecPositionsRight, List<Vector3> vecPositionsCenter, List<float> vecAngles, List<float> vecDistances, int currentVecArrayInt, bool debugFlag, int segmentCount, bool lastSegment, float scaleFactor, SideObject so, ERModularRoad roadScr, List<List<Vector2>> fullNodeList, float clampUVYPerc, float uvyShapeRatio, ERSORoadExt soData)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Color> list4 = new List<Color>();
			List<Vector3> list5 = new List<Vector3>();
			List<Vector4> list6 = new List<Vector4>();
			List<int> list7 = new List<int>();
			List<Vector3> list8 = new List<Vector3>();
			List<Vector3> list9 = new List<Vector3>();
			List<Vector2> list10 = new List<Vector2>();
			List<Vector2> list11 = new List<Vector2>();
			List<Color> list12 = new List<Color>();
			List<Vector3> list13 = new List<Vector3>();
			List<Vector4> list14 = new List<Vector4>();
			List<int> list15 = new List<int>();
			List<float> list16 = new List<float>();
			List<ZIndexArray> list17 = new List<ZIndexArray>();
			List<Vector3> list18 = new List<Vector3>();
			List<Vector2> list19 = new List<Vector2>();
			List<Vector2> list20 = new List<Vector2>();
			list = mobject.sVecs;
			list2 = mobject.sUv;
			list3 = mobject.sUv2;
			list4 = mobject.sColors;
			list5 = mobject.sNormals;
			list6 = mobject.sTangents;
			list7 = mobject.sTriangles;
			list8 = mobject.sTerrainNormals;
			list9 = mobject.vecs;
			list10 = mobject.uv;
			list11 = mobject.uv2;
			list12 = mobject.colors;
			list13 = mobject.normals;
			list14 = mobject.tangents;
			list15 = mobject.triangles;
			list18.Clear();
			Vector2 item = Vector2.zero;
			Vector2 zero = Vector2.zero;
			Vector3 v2;
			Vector3 v = (v2 = Vector3.zero);
			if (so.position == 0)
			{
				OOQCQOQDCC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag);
			}
			else
			{
				v = vecPositions[currentVecArrayInt];
				v2 = vecPositions[currentVecArrayInt + 1];
			}
			Vector3 vector;
			Vector3 dir = (vector = v2 - v);
			vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
			int num = 0;
			if (so.scaleToRoad)
			{
				if (v == vecPositions[currentVecArrayInt])
				{
					vector = (vecPositionsRight[currentVecArrayInt] - vecPositionsLeft[currentVecArrayInt]).normalized;
				}
				else
				{
					num = 1;
					vector = (vecPositionsRight[currentVecArrayInt + 1] - vecPositionsLeft[currentVecArrayInt + 1]).normalized;
				}
				vector = new Vector3(vector.x, 0f, vector.z).normalized;
				dir = new Vector3(0f - vector.z, 0f, vector.x).normalized;
			}
			debugvecs.Add(vecPositionsRight[currentVecArrayInt]);
			debugvecs.Add(vecPositionsLeft[currentVecArrayInt]);
			if (_40AAA.x != 0f)
			{
				v += _40AAA.x * vector;
				v2 += _40AAA.x * vector;
			}
			if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
			{
				if (!so.scaleToRoad)
				{
					vector = new Vector3(vector.x, 0f, vector.z).normalized;
				}
			}
			else if (roadScr.snapToTerrain)
			{
				roadScr.baseScript.OCCDCQCOQC(ref v);
				v.y += soData.yPosition;
			}
			else if ((roadScr.snapToTerrain || !roadScr.isSideObject) && so.snapToTerrain)
			{
				v.y = (v2.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition);
			}
			if (currentSplineInt >= vecAngles.Count)
			{
				currentSplineInt = vecAngles.Count - 1;
			}
			if (vecPositions.Count <= currentVecArrayInt + 2)
			{
				lastSegment = true;
			}
			List<float> list21 = new List<float>(so.uvs);
			if (so.reverseUVs)
			{
				float num2 = 1f;
				float num3 = 0f;
				for (int i = 0; i < list21.Count; i++)
				{
					if (list21[i] < num2)
					{
						num2 = list21[i];
					}
					if (list21[i] > num3)
					{
						num3 = list21[i];
					}
				}
				for (int i = 0; i < list21.Count; i++)
				{
					list21[i] = Mathf.Lerp(num3, num2, (list21[i] - num2) / (num3 - num2));
				}
			}
			List<float> list22 = new List<float>();
			list22.Add(0f);
			float num4 = 0f;
			for (int i = 0; i < so.nodeList.Count; i++)
			{
				Vector3 v3 = v + vector * fullNodeList[i][currentVecArrayInt].x;
				v3.y += fullNodeList[i][currentVecArrayInt].y;
				if (so.align == 1 || (sidewaysFlag && so.align != 0))
				{
					OCQCDQCQOQ.OQOCCODDQQ(ref v3, v, dir, fullNodeList[i][currentVecArrayInt], roadScr, _9AAA1);
				}
				else if (so.align == 2)
				{
					OCQCDQCQOQ.OQQCCQCQQC(ref v3, v, dir, fullNodeList[i][currentVecArrayInt], 0f, _9AAA1);
				}
				else if (so.align == 3)
				{
					OCQCDQCQOQ.OQQCCQCQQC(ref v3, v, dir, fullNodeList[i][currentVecArrayInt], vecAngles[currentSplineInt], _9AAA1);
				}
				if (so.snapWeightList[i] > 0f)
				{
					Vector3 pos = v3;
					roadScr.baseScript.OCCDCQCOQC(ref pos);
					v3.y = Mathf.Lerp(v3.y, pos.y, so.snapWeightList[i]);
					if ((double)so.snapWeightList[i] > 0.95)
					{
						list8.Add(roadScr.baseScript.ODQQCDQCQO(pos));
					}
					else
					{
						list8.Add(Vector3.zero);
					}
				}
				else
				{
					list8.Add(Vector3.zero);
				}
				list18.Add(v3);
				list4.Add(so.colorList[i]);
				if (i > 0)
				{
					num4 += Vector3.Distance(v3, list18[list18.Count - 2]);
					list22.Add(num4);
				}
				if (so.clampUVs && !so.terrainUVs)
				{
					item = new Vector2(list21[i], curDist * so.uvy * clampUVYPerc * uvyShapeRatio);
					if (lastSegment && so.clampUVY)
					{
						item.y = Mathf.Ceil(item.y) - (1f - so.clampUVYValue);
					}
				}
				zero.x = (v3.x - _81AAA.min.x) / _81AAA.size.x;
				zero.y = (v3.z - _81AAA.min.z) / _81AAA.size.z;
				list20.Add(zero);
				if (so.clampUVs && !so.terrainUVs)
				{
					list19.Add(item);
				}
				else if (so.terrainUVs)
				{
					list19.Add(zero);
				}
			}
			if (!so.clampUVs && !so.terrainUVs)
			{
				float num5 = list22[list22.Count - 1];
				for (int i = 0; i < so.nodeList.Count; i++)
				{
					item = (so.reverseUVs ? new Vector2((num5 - list22[i]) / so.totalDistance, curDist * so.uvy * clampUVYPerc * uvyShapeRatio) : new Vector2(list22[i] / so.totalDistance, curDist * so.uvy * clampUVYPerc * uvyShapeRatio));
					list19.Add(item);
				}
			}
			if (debugFlag)
			{
			}
			int count = list.Count;
			list.AddRange(list18);
			list2.AddRange(list19);
			list3.AddRange(list20);
			int count2 = so.nodeList.Count;
			if (segmentCount > 0)
			{
				for (int i = 0; i < count2 - 1; i++)
				{
					list7.Add(count - count2 + i);
					list7.Add(count + i);
					list7.Add(count + i + 1);
					list7.Add(count - count2 + i);
					list7.Add(count + i + 1);
					list7.Add(count - count2 + i + 1);
				}
			}
		}

		public static void OCQQDCCQCO(GameObject parentGo, float curDist, float scaleFactor, SideObject so, List<Vector3> vecPositions, List<Vector3> vecPositionsLeft, List<Vector3> vecPositionsRight, List<Vector3> vecPositionsCenter, List<float> vecAngles, List<float> vecDistances, int currentVecArrayInt, int num, ERModularRoad roadScr, int startConnectionEnd, ERSORoadExt soData)
		{
			int num2 = num;
			GameObject gameObject = null;
			string text = "";
			if (so.objectType == 0)
			{
				if (startConnectionEnd != 2 || so.endObject == null || !so.meshBoundsAlignment)
				{
					if (so.childOrder == 0)
					{
						gameObject = UnityEngine.Object.Instantiate(so.sourceObject);
					}
					else if (so.childOrder == 1)
					{
						int childCount = so.sourceObject.transform.childCount;
						if (childCount > 1)
						{
							num--;
							num -= Mathf.RoundToInt(Mathf.Floor(num / childCount) * (float)childCount);
							if (_91AA1)
							{
								num++;
								if (num >= childCount)
								{
									num = 0;
								}
							}
							gameObject = UnityEngine.Object.Instantiate(so.sourceObject.transform.GetChild(num).gameObject);
						}
						else
						{
							gameObject = UnityEngine.Object.Instantiate(so.sourceObject);
						}
					}
					else
					{
						int childCount = so.sourceObject.transform.childCount;
						gameObject = ((childCount <= 1) ? UnityEngine.Object.Instantiate(so.sourceObject) : UnityEngine.Object.Instantiate(so.sourceObject.transform.GetChild(Mathf.RoundToInt(UnityEngine.Random.Range(0, childCount))).gameObject));
					}
				}
				else
				{
					gameObject = UnityEngine.Object.Instantiate(so.endObject);
				}
				ERPrefabInstance eRPrefabInstance = gameObject.AddComponent<ERPrefabInstance>();
				eRPrefabInstance.roadScript = roadScr;
				eRPrefabInstance.so = so;
				eRPrefabInstance.soData = soData;
			}
			else
			{
				switch (startConnectionEnd)
				{
				case 0:
					if (so.startObject != null)
					{
						gameObject = so.startObject;
						text = " Start Object";
					}
					break;
				case 1:
					if (so.connectionObject != null)
					{
						gameObject = so.connectionObject;
						text = " Connection Object";
					}
					break;
				case 2:
					if (so.endObject != null)
					{
						gameObject = so.endObject;
						text = " End Object";
					}
					break;
				}
				if (gameObject != null)
				{
					if (so.childOrder == 0)
					{
						gameObject = UnityEngine.Object.Instantiate(gameObject);
					}
					else if (so.childOrder == 1)
					{
						int childCount = gameObject.transform.childCount;
						if (childCount > 1)
						{
							num--;
							num -= Mathf.RoundToInt(Mathf.Floor(num / childCount) * (float)childCount);
							gameObject = UnityEngine.Object.Instantiate(gameObject.transform.GetChild(num).gameObject);
						}
						else
						{
							gameObject = UnityEngine.Object.Instantiate(gameObject);
						}
					}
					else
					{
						int childCount = gameObject.transform.childCount;
						gameObject = ((childCount <= 1) ? UnityEngine.Object.Instantiate(gameObject) : UnityEngine.Object.Instantiate(gameObject.transform.GetChild(Mathf.RoundToInt(UnityEngine.Random.Range(0, childCount))).gameObject));
					}
				}
			}
			if (gameObject == null)
			{
				return;
			}
			so.instantiatedObjects.Add(gameObject);
			gameObject.name = so.name + text;
			gameObject.transform.parent = parentGo.transform;
			gameObject.isStatic = so.isStatic;
			gameObject.layer = so.layer;
			Vector3 v2;
			Vector3 v = (v2 = Vector3.zero);
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			Vector3 vector;
			if (!so.meshBoundsAlignment)
			{
				OOQCQOQDCC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag: false);
				zero2 = (zero = (zero3 = (v2 - v).normalized));
				vector = v;
				if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
				{
					if (so.snapToTerrain)
					{
						v.y = (v2.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition);
					}
					zero = (vecPositionsRight[currentVecArrayInt] - vecPositionsLeft[currentVecArrayInt]).normalized;
				}
				else if ((roadScr.snapToTerrain || !roadScr.isSideObject) && so.snapToTerrain)
				{
					v.y = (v2.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition);
				}
			}
			else
			{
				Bounds bounds = default(Bounds);
				if (OCQCDQCQOQ.OQCOCOCOQO(gameObject, ref bounds))
				{
					OOQCQOQDCC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: false, debugFlag: false);
					OOQCQOQDCC(curDist + bounds.size.z, vecPositions, vecDistances, currentVecArrayInt, ref v2, ref v2, doSecond: false, debugFlag: false);
					zero2 = (zero = (zero3 = (v2 - v).normalized));
					vector = v;
					if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
					{
						zero = (vecPositionsRight[currentVecArrayInt] - vecPositionsLeft[currentVecArrayInt]).normalized;
					}
					else if ((roadScr.snapToTerrain || !roadScr.isSideObject) && roadScr.terrainDeformation && so.snapToTerrain)
					{
						v.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition;
						v2.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition;
					}
				}
				else
				{
					OOQCQOQDCC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag: false);
					zero2 = (zero = (zero3 = (v2 - v).normalized));
					vector = v;
					if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
					{
						zero = (vecPositionsRight[currentVecArrayInt] - vecPositionsLeft[currentVecArrayInt]).normalized;
					}
					else if ((roadScr.snapToTerrain || !roadScr.isSideObject) && roadScr.terrainDeformation && so.snapToTerrain)
					{
						v.y = (v2.y = OCQCDQCQOQ.OOOQQOODDD(v, roadScr.baseScript) + soData.yPosition);
					}
				}
			}
			if (so.objectType != 0)
			{
				if (_40AAA.x != 0f)
				{
					v += _40AAA.x * zero;
					v2 += _40AAA.x * zero;
				}
			}
			else if (soData.randomMinXPosition != 0f || soData.randomMaxXPosition != 0f)
			{
				float num3 = Mathf.Lerp(soData.randomMinXPosition, soData.randomMaxXPosition, UnityEngine.Random.value);
				v += zero * num3;
				v2 += zero * num3;
			}
			if (so.selectedRotation == 0)
			{
				zero = new Vector3(zero3.x, 0f, zero3.z).normalized;
				float num4 = Vector3.Angle(Vector3.forward, zero);
				if (OCQCDQCQOQ.OCQDCQCOQQ(Vector3.forward, zero, Vector3.up) == -1f)
				{
					num4 = 360f - num4;
				}
				gameObject.transform.eulerAngles = new Vector3(0f, num4 + so.yRotation, 0f);
			}
			else if (so.selectedRotation == 1)
			{
				gameObject.transform.eulerAngles = new Vector3(0f, so.yRotation, 0f);
			}
			else if (so.selectedRotation == 2)
			{
				gameObject.transform.eulerAngles = new Vector3(0f, UnityEngine.Random.value * 360f, 0f);
			}
			gameObject.transform.position = v;
			Vector3 _1AAAA = Vector3.zero;
			if (_8AAAA.x != 0f)
			{
				ᙄ(curDist, ref _1AAAA, ref _9AAA1, _5AAA1, _7AAA1, _6AAAA, _4AAAA, _8AAAA);
			}
			if (_51AA1.x != 0f)
			{
				ᙅ(curDist, ref _1AAAA);
			}
			if (so.align == 1 || (sidewaysFlag && so.align != 0))
			{
				OCQCDQCQOQ.OQOCDQCDCQ(gameObject, v, roadScr, _1AAAA);
			}
			else if (so.align == 2)
			{
				OCQCDQCQOQ.OODCQODDQQ(gameObject, v2, vector, zero2, _1AAAA);
			}
			else if (so.align == 3)
			{
				if (!roadScr.isSideObject)
				{
					if (currentSplineInt < vecPositionsCenter.Count)
					{
						OCQCDQCQOQ.ODQOQDCQDC(gameObject, vecPositionsCenter[currentSplineInt], roadScr, _1AAAA);
					}
					else
					{
						OCQCDQCQOQ.ODQOQDCQDC(gameObject, vecPositionsCenter[vecPositionsCenter.Count - 1], roadScr, _1AAAA);
					}
				}
				else if (currentSplineInt < vecPositionsCenter.Count)
				{
					OCQCDQCQOQ.ODQOQDCQDC(gameObject, vecPositionsCenter[currentSplineInt], roadScr, new Vector3(0f - vecAngles[currentSplineInt] + _1AAAA.x, _1AAAA.y, _1AAAA.z));
				}
				else
				{
					OCQCDQCQOQ.ODQOQDCQDC(gameObject, vecPositionsCenter[vecPositionsCenter.Count - 1], roadScr, new Vector3(0f - vecAngles[vecAngles.Count - 1] + _1AAAA.x, _1AAAA.y, _1AAAA.z));
				}
			}
			else if (so.meshBoundsAlignment)
			{
				float minY = 20000f;
				float maxY = -20000f;
				OCQCDQCQOQ.ODOCDDQCQQ(roadScr.baseScript, v2, vector, ref minY, ref maxY);
				if (so.alignPoint == 0)
				{
					v.y = minY;
				}
				else if (so.alignPoint == 1)
				{
					v.y = maxY;
				}
				else if (so.alignPoint == 2)
				{
					v.y = (minY + maxY) * 0.5f;
				}
				if (_1AAAA.x != 0f)
				{
					OCQCDQCQOQ.InstantiatedRandomRotation(gameObject, Vector3.zero, roadScr, _1AAAA);
				}
				v.y += soData.yPosition;
				gameObject.transform.position = v;
			}
			else if (_1AAAA.x != 0f)
			{
				OCQCDQCQOQ.InstantiatedRandomRotation(gameObject, Vector3.zero, roadScr, -_1AAAA);
			}
			if (C0AA1.x != 0f)
			{
				v = gameObject.transform.position;
				v.y += C0AA1.x;
				gameObject.transform.position = v;
			}
			if (so.minScale != 1f || so.maxScale != 1f)
			{
				float num5 = so.minScale + (so.maxScale - so.minScale) * UnityEngine.Random.value;
				gameObject.transform.localScale = new Vector3(num5, num5, num5);
			}
		}

		public static void OOQCQOQDCC(float tmpDist, List<Vector3> vecPositions, List<float> vecDistances, int currentVecArrayInt, ref Vector3 v, ref Vector3 v1, bool doSecond, bool debugFlag)
		{
			if (currentVecArrayInt == 0)
			{
				currentVecArrayInt = 1;
			}
			if (currentVecArrayInt + 1 >= vecDistances.Count)
			{
				return;
			}
			for (int i = currentVecArrayInt; i < vecDistances.Count; i++)
			{
				if (!(vecDistances[i] > tmpDist))
				{
					continue;
				}
				float num = (tmpDist - vecDistances[i - 1]) / (vecDistances[i] - vecDistances[i - 1]);
				v = Vector3.Lerp(vecPositions[i - 1], vecPositions[i], num);
				if (doSecond)
				{
					if ((double)num < 0.99)
					{
						v1 = Vector3.Lerp(vecPositions[i - 1], vecPositions[i], num + 0.01f);
					}
					else
					{
						v1 = Vector3.Lerp(vecPositions[i], vecPositions[i + 1], 0.01f);
					}
				}
				currentSplineInt = i;
				break;
			}
		}

		public static void GetSplinePositionsMin(float tmpDist, List<Vector3> vecPositions, List<float> vecDistances, int currentVecArrayInt, ref Vector3 v, ref Vector3 v1, bool doSecond, bool debugFlag)
		{
			Vector3 vector = vecPositions[currentVecArrayInt];
			int num = 0;
			bool flag = false;
			if (currentVecArrayInt + 1 < vecDistances.Count)
			{
				for (int num2 = currentVecArrayInt; num2 >= 0; num2--)
				{
					if (vecDistances[num2] <= tmpDist)
					{
						float t = (tmpDist - vecDistances[num2]) / (vecDistances[num2 + 1] - vecDistances[num2]);
						v = (v1 = Vector3.Lerp(vecPositions[num2], vecPositions[num2 + 1], t));
						currentSplineInt = num2;
						flag = true;
						break;
					}
					num++;
				}
			}
			if (!flag)
			{
				Vector3 zero = Vector3.zero;
				if (num > 0 && currentVecArrayInt - num >= 0)
				{
					Debug.Log(num + " " + currentVecArrayInt + " " + vecPositions.Count);
					zero = (vecPositions[currentVecArrayInt - num] - vector).normalized;
				}
				else
				{
					zero = (vecPositions[currentVecArrayInt] - vecPositions[currentVecArrayInt + 1]).normalized;
				}
				v = (v1 = vector + zero * (vecDistances[currentVecArrayInt] - tmpDist));
			}
		}

		public static void OOQCOOOOQC(float curDist, List<float> vecDistances, ref int currentVecArrayInt)
		{
			if (currentVecArrayInt < vecDistances.Count)
			{
				for (int i = currentVecArrayInt; i < vecDistances.Count; i++)
				{
					if (vecDistances[i] > curDist)
					{
						currentVecArrayInt = i - 1;
						break;
					}
				}
			}
			else
			{
				currentVecArrayInt = vecDistances.Count - 1;
			}
		}

		private static void ᙃ(float ᙂ, ref Vector3 _1AAAA, ref Vector3 ᙄ, float _3AAAA, float _4AAAA, float _5AAAA, float _6AAAA, Vector3 _7AAAA)
		{
			if (ᙂ <= _4AAAA)
			{
				float num = (ᙂ - _3AAAA) / (_4AAAA - _3AAAA);
				float num2 = num * _6AAAA;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(_6AAAA - num2) < 0.25)
				{
					num = 1f;
				}
				ᙄ.x = Mathf.Lerp(0f, _7AAAA.x, Mathf.SmoothStep(0f, 1f, num));
			}
			else
			{
				float num = (ᙂ - _4AAAA) / (_5AAAA - _4AAAA);
				float num2 = num * _6AAAA;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(_6AAAA - num2) < 0.25)
				{
					num = 1f;
				}
				ᙄ.x = Mathf.Lerp(_7AAAA.x, 0f, Mathf.SmoothStep(0f, 1f, num));
			}
			_1AAAA = ᙄ;
		}

		private static void ᙄ(float ᙂ, ref Vector3 _1AAAA, ref Vector3 ᙄ, float _3AAAA, float _4AAAA, float _5AAAA, float _6AAAA, Vector3 _7AAAA)
		{
			if (ᙂ <= _4AAAA)
			{
				float num = (ᙂ - _3AAAA) / (_4AAAA - _3AAAA);
				float num2 = num * _6AAAA;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(_6AAAA - num2) < 0.25)
				{
					num = 1f;
				}
				ᙄ.x = Mathf.Lerp(0f, _7AAAA.x, Mathf.SmoothStep(0f, 1f, num));
			}
			else
			{
				float num = (ᙂ - _4AAAA) / (_5AAAA - _4AAAA);
				float num2 = num * _6AAAA;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(_6AAAA - num2) < 0.25)
				{
					num = 1f;
				}
				ᙄ.x = Mathf.Lerp(_7AAAA.x, 0f, Mathf.SmoothStep(0f, 1f, num));
			}
			_1AAAA = ᙄ;
		}

		private static void ᙅ(float ᙂ, ref Vector3 _1AAAA)
		{
			if (ᙂ <= _41AAA)
			{
				float num = (ᙂ - _21AAA) / (_41AAA - _21AAA);
				float num2 = num * _11AA1;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(_11AA1 - num2) < 0.25)
				{
					num = 1f;
				}
				_61AAA.x = Mathf.Lerp(0f, _51AA1.x, Mathf.SmoothStep(0f, 1f, num));
				if (_1AAAA == Vector3.zero)
				{
					_1AAAA = _61AAA;
				}
				else
				{
					_1AAAA = Vector3.Lerp(_1AAAA, _61AAA, num);
				}
			}
			else
			{
				float num = (ᙂ - _41AAA) / (_31AA1 - _41AAA);
				float num2 = num * _11AA1;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(_11AA1 - num2) < 0.25)
				{
					num = 1f;
				}
				_61AAA.x = Mathf.Lerp(_51AA1.x, 0f, Mathf.SmoothStep(0f, 1f, num));
				if (_1AAAA == Vector3.zero)
				{
					_1AAAA = _61AAA;
				}
				else
				{
					_1AAAA = Vector3.Lerp(_61AAA, _1AAAA, num);
				}
			}
		}

		public static Terrain OQOQCOQOOQ(Vector3 pos)
		{
			Terrain[] array = UnityEngine.Object.FindObjectsOfType(typeof(Terrain)) as Terrain[];
			Terrain[] array2 = array;
			foreach (Terrain terrain in array2)
			{
				if (terrain != null && pos.x > terrain.transform.position.x && pos.x < terrain.transform.position.x + terrain.terrainData.size.x && pos.z > terrain.transform.position.z && pos.z < terrain.transform.position.z + terrain.terrainData.size.z)
				{
					return terrain;
				}
			}
			return array[0];
		}
	}
}
