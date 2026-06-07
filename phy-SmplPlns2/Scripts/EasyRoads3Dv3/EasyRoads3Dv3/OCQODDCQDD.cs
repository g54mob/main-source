using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OCQODDCQDD : MonoBehaviour
	{
		public static List<Vector3> debugvecs = new List<Vector3>();

		public static bool sidewaysFlag = false;

		public static bool useLastFowardFlag = false;

		public static bool lastvecPositionsArray = false;

		public static int currentSplineInt = 0;

		private static float xssss = 0f;

		private static float yssst = 0f;

		private static float Assss = 0f;

		private static float _0ssst = 0f;

		private static Vector3 _1ssss = Vector3.zero;

		private static Vector3 _2ssst = Vector3.zero;

		private static float _3ssss = 0.25f;

		private static float _4ssst = 0f;

		private static float ttsss = 0f;

		private static float utsst = 0f;

		private static float vtsss = 0f;

		private static Vector3 wtsst = Vector3.zero;

		private static Vector3 xtsss = Vector3.zero;

		private static float ytsst = 0.25f;

		private static float Atsss = 0f;

		private static float _0tsst = 0f;

		private static float _1tsss = 0f;

		private static float _2tsst = 0f;

		private static Vector3 _3tsss = Vector3.zero;

		private static Vector3 _4tsst = Vector3.zero;

		private static float tusss = 0.25f;

		private static float uusst;

		private static float vusss = 0f;

		private static float wusst = 0f;

		private static float xusss = 0f;

		private static float yusst = 0f;

		private static Vector3 Ausss = Vector3.zero;

		private static Vector3 _0usst = Vector3.zero;

		private static float _1usss = 0.25f;

		private static Bounds _2usst;

		private static float _3usss = 0f;

		private static float _4usst = 0f;

		private static int tvsss = 0;

		private static int uvsst = 1;

		private static int vvsss = 0;

		private static bool wvsst = true;

		private static bool xvsss = false;

		private static bool yvsst = false;

		private static Vector3 Avsss = Vector3.zero;

		private static Vector3 _0vsst = Vector3.zero;

		private static float _1vsss = 0f;

		private static float _2vsst = 0f;

		public static void OCODCOOQOC(List<SideObject> QOQDQOOQDDQOOQ, ref List<ERSORoadExt> soDataExt)
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
			for (int k = 0; k < QOQDQOOQDDQOOQ.Count; k++)
			{
				bool flag2 = false;
				for (int l = 0; l < soDataExt.Count; l++)
				{
					if (QOQDQOOQDDQOOQ[k] != null && soDataExt[l].id == QOQDQOOQDDQOOQ[k].id)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					soDataExt.Add(ERSORoadExt.CreateInstance(QOQDQOOQDDQOOQ[k]));
				}
			}
		}

		public static void ODCCCOCODC(ERModularBase scr, SideObject so)
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
				bool flag2 = false;
				foreach (ERSORoadExt item in eRModularRoad.soDataExt)
				{
					if (item.id == so.id)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					eRModularRoad.soDataExt.Add(ERSORoadExt.CreateInstance(so));
				}
				foreach (ERMarkerExt item2 in eRModularRoad.markersExt)
				{
				}
				eRModularRoad.sideObjectNames = OQCCQCDQQO(eRModularRoad);
			}
		}

		public static void OQQOCODQCD(ERModularBase scr, SideObject so)
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
						if ((scr.roadTypes[i] == null || !(scr.roadTypes[i].soDataExt[j] != null)) && scr.roadTypes[i] != null)
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
				for (int l = 0; l < eRModularRoad.soDataExt.Count; l++)
				{
					try
					{
						if (eRModularRoad.soDataExt[l].sideObject.id == so.id)
						{
							eRModularRoad.soDataExt.RemoveAt(l);
							break;
						}
						ODDODQOOCC(eRModularRoad, so, ref terrainSurfaceFlag);
						scr.sideObjectNames = OQCCQCDQQO(eRModularRoad);
					}
					catch
					{
						Debug.Log("Removing side object " + so.name + " from road " + eRModularRoad.gameObject.name + " failed! " + l + " " + eRModularRoad.soDataExt[l].sideObject?.ToString() + " " + so.name);
					}
				}
			}
		}

		public static bool OQDCQDCQDD(ERModularRoad scr, SideObject so, bool forceMarkerActive)
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
						if (item.soData[i].sideObject.id != so.id)
						{
							continue;
						}
						flag = false;
						if (forceMarkerActive)
						{
							item.soData[i].active = true;
							if (so.dualSided)
							{
								item.soData[i].otherSide.active = true;
							}
						}
						break;
					}
					item.soData.RemoveAt(i);
				}
				if (flag)
				{
					item.soData.Add(ERSOMarkerExt.CreateInstance(so, flag: true));
					if (scr.isSideObject || forceMarkerActive)
					{
						item.soData[item.soData.Count - 1].active = true;
					}
					item.soData[item.soData.Count - 1].startOffset = so.defaultStartOffset;
					item.soData[item.soData.Count - 1].endOffset = so.defaultEndOffset;
					item.soData[item.soData.Count - 1].xPosition = so.xPosition;
					OQODDODODC(scr, num);
					if (so.markerActive && so.indentController)
					{
						OODCDDQOQC.SetMarkerIndentAlignment(item, scr, "");
						result = true;
					}
					if (so.dualSided && item.soData[item.soData.Count - 1].sideObject.id == so.id)
					{
						item.soData[item.soData.Count - 1].otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
						InitOtherMarkerSO(scr, item.soData[item.soData.Count - 1], so, forceMarkerActive);
					}
				}
				num++;
			}
			scr.sideObjectNames = OQCCQCDQQO(scr);
			OOOQQQOOQC(scr.baseScript, scr, so, updateSideObjectsOnOtherRoadObjects: true);
			scr.sosCleared = false;
			return result;
		}

		public static void InitOtherMarkerSO(ERModularRoad scr, ERSOMarkerExt soData, SideObject so, bool forceMarkerActive)
		{
			if (scr.isSideObject || (soData.active && so.markerActive) || forceMarkerActive)
			{
				soData.otherSide.active = true;
			}
			soData.otherSide.startOffset = soData.startOffset;
			soData.otherSide.endOffset = soData.endOffset;
			soData.otherSide.xPosition = 0f - soData.xPosition;
		}

		public static ERSOMarkerExt[] ODDODQOOCC(ERModularRoad scr, SideObject so, ref bool terrainSurfaceFlag)
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
							Debug.Log("Removing side object " + so.name + " from road " + scr.gameObject.name + " [markers] failed! " + i + " " + item.soData[i].sideObject?.ToString() + " " + so.name);
						}
					}
				}
				num++;
			}
			scr.sideObjectNames = OQCCQCDQQO(scr);
			ERSideObjectInstance[] componentsInChildren = scr.gameObject.GetComponentsInChildren<ERSideObjectInstance>();
			ERSideObjectInstance[] array = componentsInChildren;
			foreach (ERSideObjectInstance eRSideObjectInstance in array)
			{
				if (eRSideObjectInstance.so != null)
				{
					if (eRSideObjectInstance.so.id == so.id)
					{
						if (Application.isEditor && !Application.isPlaying)
						{
							UnityEngine.Object.DestroyImmediate(eRSideObjectInstance.gameObject);
						}
						else
						{
							UnityEngine.Object.Destroy(eRSideObjectInstance.gameObject);
						}
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
					OQODDODODC(scr1, num);
					num++;
				}
				scr1.sideObjectNames = OQCCQCDQQO(scr1);
			}
			for (int j = 0; j < scr1.soDataExt.Count; j++)
			{
				if (!scr1.soDataExt[j].active || scr2.soDataExt[j].active)
				{
					continue;
				}
				scr2.soDataExt[j].active = true;
				int num2 = 0;
				foreach (ERMarkerExt item2 in scr2.markersExt)
				{
					item2.soData.Add(ERSOMarkerExt.CreateInstance(scr2.soDataExt[j].sideObject, flag: false));
					OQODDODODC(scr2, num2);
					num2++;
				}
				scr2.sideObjectNames = OQCCQCDQQO(scr2);
			}
		}

		public static void OQODDODODC(ERModularRoad scr, int marker)
		{
			List<ERSOMarkerExt> list = new List<ERSOMarkerExt>();
			for (int i = 0; i < scr.soDataExt.Count; i++)
			{
				if (!(scr.soDataExt[i] != null) || !(scr.soDataExt[i].sideObject != null))
				{
					continue;
				}
				for (int j = 0; j < scr.markersExt[marker].soData.Count; j++)
				{
					if (scr.markersExt[marker].soData[j] != null && scr.markersExt[marker].soData[j].sideObject != null)
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

		public static string[] OQCCQCDQQO(ERModularRoad scr)
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

		public static bool OOCODQOQOO(ERModularRoad scr, SideObject so, int marker, bool mirrored)
		{
			if (so == null)
			{
				return false;
			}
			foreach (ERSOMarkerExt soDatum in scr.markersExt[marker].soData)
			{
				if (soDatum.id != so.id)
				{
					continue;
				}
				if (!mirrored)
				{
					return soDatum.active;
				}
				if (mirrored && soDatum.otherSide == null)
				{
					OCDOODOQDC.ODCCCDDOCO(scr, so);
					if (soDatum.otherSide == null)
					{
						soDatum.otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
					}
					soDatum.otherSide.Copy(soDatum, reverse: true);
				}
				return soDatum.otherSide.active;
			}
			return false;
		}

		public static bool OOCODQOQOO(ERModularRoad scr, SideObject so, int marker, ref float startOffset, ref float endOffset, ref ERSOMarkerExt soMarker, bool mirrored)
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
					if (mirrored && soDatum.otherSide == null)
					{
						OCDOODOQDC.ODCCCDDOCO(scr, so);
						if (soDatum.otherSide == null)
						{
							soDatum.otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
						}
						soDatum.otherSide.Copy(soDatum, reverse: true);
					}
					if (flag2)
					{
						if (!mirrored)
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
							if (scr.markersExt[marker - 1].soData[num].otherSide == null)
							{
								OCDOODOQDC.ODCCCDDOCO(scr, so);
								if (scr.markersExt[marker - 1].soData[num].otherSide == null)
								{
									scr.markersExt[marker - 1].soData[num].otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
								}
								scr.markersExt[marker - 1].soData[num].otherSide.Copy(scr.markersExt[marker - 1].soData[num], reverse: true);
							}
							if (scr.markersExt[marker - 1].soData[num].otherSide.active || !soDatum.otherSide.active)
							{
								startOffset = 0f;
							}
							else
							{
								startOffset = soDatum.otherSide.startOffset;
							}
						}
					}
					else if (!mirrored)
					{
						startOffset = soDatum.startOffset;
					}
					else
					{
						startOffset = soDatum.otherSide.startOffset;
					}
					if (flag3 && marker + 1 < scr.markersExt.Count && scr.markersExt[marker + 1].soData.Count != scr.markersExt[marker].soData.Count)
					{
						ERMarkerExt.OQDCDQDCCQ(scr.markersExt[marker], scr.markersExt[marker + 1], scr.gameObject.name);
					}
					if (!mirrored)
					{
						if ((flag3 && marker + 1 < scr.markersExt.Count && scr.markersExt[marker + 1].soData[num].active) || !soDatum.active)
						{
							if (marker + 1 == scr.markersExt.Count - 1 && !scr.closedTrack)
							{
								endOffset = soDatum.endOffset;
							}
							else
							{
								endOffset = 0f;
							}
						}
						else
						{
							endOffset = soDatum.endOffset;
						}
					}
					else
					{
						if (mirrored && marker + 1 <= scr.markersExt.Count - 1 && scr.markersExt[marker + 1].soData[num].otherSide == null)
						{
							OCDOODOQDC.ODCCCDDOCO(scr, scr.markersExt[marker + 1].soData[num].sideObject);
							if (scr.markersExt[marker + 1].soData[num].otherSide == null)
							{
								scr.markersExt[marker + 1].soData[num].otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
							}
							scr.markersExt[marker + 1].soData[num].otherSide.Copy(scr.markersExt[marker + 1].soData[num], reverse: true);
						}
						if ((flag3 && marker + 1 < scr.markersExt.Count && scr.markersExt[marker + 1].soData[num].otherSide.active) || !soDatum.otherSide.active)
						{
							if (marker + 1 == scr.markersExt.Count - 1 && !scr.closedTrack)
							{
								endOffset = soDatum.otherSide.endOffset;
							}
							else
							{
								endOffset = 0f;
							}
						}
						else
						{
							endOffset = soDatum.otherSide.endOffset;
						}
					}
					if (!mirrored)
					{
						soMarker = soDatum;
					}
					else
					{
						soMarker = soDatum.otherSide;
					}
					if (marker == scr.markersExt.Count - 2 && soDatum.endOffset == 0f && soDatum.active)
					{
						useLastFowardFlag = true;
					}
					if (flag)
					{
						return false;
					}
					if (!mirrored)
					{
						return soDatum.active;
					}
					return soDatum.otherSide.active;
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
				if (i > 0 && scr.markersExt[i - 1].soData.Count != scr.markersExt[i].soData.Count)
				{
					ERMarkerExt.OQDCDQDCCQ(scr.markersExt[i - 1], scr.markersExt[i], scr.gameObject.name);
				}
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
							if (OQQOCDQCQD.CompareVector2List(soDatum.nodeList, so.nodeList))
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

		public static bool OCOCDCQQOQ(ERModularBase scr, ERModularRoad roadScr)
		{
			if (roadScr == null || roadScr.gameObject == null)
			{
				return false;
			}
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
				if (eRSideObjectInstance.so != null)
				{
					if (eRSideObjectInstance.so.objectType == 0)
					{
						List<GameObject> list = new List<GameObject>();
						foreach (Transform item in eRSideObjectInstance.transform)
						{
							list.Add(item.gameObject);
						}
						foreach (GameObject item2 in list)
						{
							if (Application.isEditor && !Application.isPlaying)
							{
								UnityEngine.Object.DestroyImmediate(item2);
							}
							else
							{
								UnityEngine.Object.Destroy(item2);
							}
						}
						continue;
					}
					List<GameObject> list2 = new List<GameObject>();
					for (int j = 0; j < eRSideObjectInstance.transform.childCount; j++)
					{
						Transform child = eRSideObjectInstance.transform.GetChild(j);
						list2.Add(child.gameObject);
						if ((bool)child.GetComponent<MeshFilter>() && child.GetComponent<MeshFilter>().sharedMesh != null)
						{
							child.GetComponent<MeshFilter>().sharedMesh = null;
						}
						if ((bool)child.GetComponent<MeshCollider>() && child.GetComponent<MeshCollider>().sharedMesh != null)
						{
							child.GetComponent<MeshCollider>().sharedMesh = null;
						}
						if ((bool)child.GetComponent<BoxCollider>())
						{
							if (Application.isEditor && !Application.isPlaying)
							{
								UnityEngine.Object.DestroyImmediate(child.gameObject);
							}
							else
							{
								UnityEngine.Object.Destroy(child.gameObject);
							}
							j--;
						}
					}
					if (Application.isEditor && !Application.isPlaying)
					{
						foreach (GameObject item3 in list2)
						{
							UnityEngine.Object.DestroyImmediate(item3);
						}
						continue;
					}
					foreach (GameObject item4 in list2)
					{
						UnityEngine.Object.Destroy(item4);
					}
					continue;
				}
				List<GameObject> list3 = new List<GameObject>();
				foreach (Transform item5 in eRSideObjectInstance.transform)
				{
					list3.Add(item5.gameObject);
				}
				if (Application.isEditor && !Application.isPlaying)
				{
					foreach (GameObject item6 in list3)
					{
						UnityEngine.Object.DestroyImmediate(item6);
					}
					continue;
				}
				foreach (GameObject item7 in list3)
				{
					UnityEngine.Object.Destroy(item7);
				}
			}
			bool result = false;
			for (int k = 0; k < roadScr.soDataExt.Count; k++)
			{
				if (roadScr.soDataExt[k] != null && roadScr.soDataExt[k].active)
				{
					result = true;
					roadScr.soDataExt[k].snapIntsStartSide1 = null;
					roadScr.soDataExt[k].snapIntsEndSide1 = null;
					roadScr.soDataExt[k].snapIntsStartSide2 = null;
					roadScr.soDataExt[k].snapIntsEndSide2 = null;
					roadScr.soDataExt[k].snapMeshSide1 = null;
					roadScr.soDataExt[k].snapMeshSide2 = null;
					roadScr.soDataExt[k].otherRoadStartLeft = null;
					roadScr.soDataExt[k].otherRoadStartRight = null;
					roadScr.soDataExt[k].otherRoadEndLeft = null;
					roadScr.soDataExt[k].otherRoadEndRight = null;
					roadScr.soDataExt[k].otherSoDataStartLeft = null;
					roadScr.soDataExt[k].otherSoDataStartRight = null;
					roadScr.soDataExt[k].otherSoDataEndLeft = null;
					roadScr.soDataExt[k].otherSoDataEndRight = null;
				}
				if (roadScr.soDataExt[k].runtimeObjects.Count > 0 && Application.isPlaying)
				{
					for (int l = 0; l < roadScr.soDataExt[k].runtimeObjects.Count; l++)
					{
						UnityEngine.Object.DestroyImmediate(roadScr.soDataExt[k].runtimeObjects[l]);
					}
					roadScr.soDataExt[k].runtimeObjects.Clear();
				}
			}
			ERDecal eRDecal = null;
			if (roadScr.rt != null)
			{
				eRDecal = ERDecal.OCDDCQOQOO(roadScr.rt.decalPresets, ERLaneDirectionOptions.Straight);
			}
			if (eRDecal != null)
			{
				result = true;
			}
			return result;
		}

		public static void ODCDCCDQDD(ERModularRoad rScr, SideObject so)
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

		public static bool OQQOODOODQ(ERModularRoad road, int marker, int soIndex)
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

		public static bool ODOOOOCDOQ(ERModularRoad road, int marker, int soIndex)
		{
			if (marker == road.markersExt.Count - 1 || (road.markersExt[marker].soData[soIndex].otherSide != null && !road.markersExt[marker].soData[soIndex].otherSide.active))
			{
				return false;
			}
			if (marker == 0)
			{
				if (!road.closedTrack)
				{
					return true;
				}
				if (road.markersExt[road.markersExt.Count - 1].soData[soIndex].otherSide != null && road.markersExt[road.markersExt.Count - 1].soData[soIndex].otherSide.active)
				{
					return false;
				}
				return true;
			}
			if (road.markersExt[marker - 1].soData[soIndex].otherSide != null && road.markersExt[marker - 1].soData[soIndex].otherSide.active)
			{
				return false;
			}
			return true;
		}

		public static bool OCQOODCQDO(ERModularRoad road, int marker, int soIndex)
		{
			if (marker == road.markersExt.Count - 1 || !road.markersExt[marker].soData[soIndex].active)
			{
				return false;
			}
			if (marker == road.markersExt.Count - 2)
			{
				if (!road.closedTrack || !road.markersExt[road.markersExt.Count - 1].soData[soIndex].active)
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

		public static bool OCCOCQQOCQ(ERModularRoad road, int marker, int soIndex)
		{
			if (marker == road.markersExt.Count - 1 || (road.markersExt[marker].soData[soIndex].otherSide != null && !road.markersExt[marker].soData[soIndex].otherSide.active))
			{
				return false;
			}
			if (marker == road.markersExt.Count - 2)
			{
				if (!road.closedTrack || (road.markersExt[road.markersExt.Count - 1].soData[soIndex].otherSide != null && !road.markersExt[road.markersExt.Count - 1].soData[soIndex].otherSide.active))
				{
					return true;
				}
				if (road.markersExt[0].soData[soIndex].otherSide != null && road.markersExt[0].soData[soIndex].otherSide.active)
				{
					return false;
				}
				return true;
			}
			if (road.markersExt[marker + 1].soData[soIndex].otherSide != null && road.markersExt[marker + 1].soData[soIndex].otherSide.active)
			{
				return false;
			}
			return true;
		}

		public static bool OQQDQDQCDO(List<SideObject> list, SideObject so)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == so)
				{
					return true;
				}
			}
			return false;
		}

		public static void OODOQDDOCQ(ERModularBase scr, ERModularRoad roadScr, SideObject so)
		{
			if (roadScr == null || roadScr.gameObject == null)
			{
				return;
			}
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
					if (Application.isEditor && !Application.isPlaying)
					{
						foreach (GameObject item2 in list)
						{
							UnityEngine.Object.DestroyImmediate(item2);
						}
						continue;
					}
					foreach (GameObject item3 in list)
					{
						UnityEngine.Object.Destroy(item3);
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
			for (int j = 0; j < roadScr.soDataExt.Count; j++)
			{
				if (!(roadScr.soDataExt[j] != null) || !(roadScr.soDataExt[j].sideObject == so))
				{
					continue;
				}
				roadScr.soDataExt[j].snapIntsStartSide1 = null;
				roadScr.soDataExt[j].snapIntsEndSide1 = null;
				roadScr.soDataExt[j].snapIntsStartSide2 = null;
				roadScr.soDataExt[j].snapIntsEndSide2 = null;
				roadScr.soDataExt[j].snapMeshSide1 = null;
				roadScr.soDataExt[j].snapMeshSide2 = null;
				roadScr.soDataExt[j].otherRoadStartLeft = null;
				roadScr.soDataExt[j].otherRoadStartRight = null;
				roadScr.soDataExt[j].otherRoadEndLeft = null;
				roadScr.soDataExt[j].otherRoadEndRight = null;
				roadScr.soDataExt[j].otherSoDataStartLeft = null;
				roadScr.soDataExt[j].otherSoDataStartRight = null;
				roadScr.soDataExt[j].otherSoDataEndLeft = null;
				roadScr.soDataExt[j].otherSoDataEndRight = null;
				if (Application.isPlaying && roadScr.soDataExt[j].runtimeObjects.Count > 0)
				{
					for (int k = 0; k < roadScr.soDataExt[j].runtimeObjects.Count; k++)
					{
						UnityEngine.Object.DestroyImmediate(roadScr.soDataExt[j].runtimeObjects[k]);
					}
					roadScr.soDataExt[j].runtimeObjects.Clear();
				}
			}
		}

		public static void OOODQOOOCO(ERModularBase scr, ERModularRoad roadScr, bool isSideObjectFlag)
		{
			for (int i = 0; i < roadScr.soDataExt.Count; i++)
			{
				if (roadScr.soDataExt[i] != null && roadScr.soDataExt[i].active && (!roadScr.isSideObject || isSideObjectFlag || roadScr.forceSORefresh))
				{
					OOOQQQOOQC(scr, roadScr, roadScr.soDataExt[i].sideObject, updateSideObjectsOnOtherRoadObjects: false);
				}
			}
			roadScr.sosCleared = false;
			if (!roadScr.isSideObject)
			{
				roadScr.forceSORefresh = false;
			}
		}

		public static void OOOQQQOOQC(ERModularBase scr, ERModularRoad roadScr, SideObject so, bool updateSideObjectsOnOtherRoadObjects, bool isParent = true)
		{
			GameObject gameObject = null;
			if (so == null || roadScr == null)
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
						if (Application.isEditor && !Application.isPlaying)
						{
							UnityEngine.Object.DestroyImmediate(gameObject);
						}
						else
						{
							UnityEngine.Object.Destroy(gameObject);
						}
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
								Mesh sharedMesh2 = UnityEngine.Object.Instantiate(item.GetComponent<MeshFilter>().sharedMesh);
								item.GetComponent<MeshFilter>().sharedMesh = sharedMesh2;
								if ((bool)item.GetComponent<MeshCollider>() && (bool)item.GetComponent<MeshCollider>().sharedMesh)
								{
									item.GetComponent<MeshCollider>().sharedMesh = sharedMesh2;
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
				if ((bool)gameObject.GetComponent<MeshFilter>() && gameObject.GetComponent<MeshFilter>().sharedMesh != null)
				{
					gameObject.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
			}
			gameObject.layer = so.layer;
			gameObject.tag = so.tag;
			gameObject.isStatic = so.isStatic;
			ERSORoadExt eRSORoadExt = null;
			foreach (ERSORoadExt item2 in roadScr.soDataExt)
			{
				if (item2.sideObject == so)
				{
					eRSORoadExt = item2;
					break;
				}
			}
			if (eRSORoadExt == null)
			{
				return;
			}
			if (so.objectType == 0)
			{
				if (so.sourceObject == null)
				{
					Debug.Log("EasyRoads3Dv3: No Source Object has been assigned to this side object (" + so.name + "), side object creation aborted");
					return;
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
					for (int k = so.colorList.Count; k < so.nodeList.Count; k++)
					{
						so.colorList.Add(Color.white);
					}
					so.UpdateTimeStamp();
				}
				if (so.snapWeightList.Count < so.nodeList.Count)
				{
					for (int l = 0; l < so.nodeList.Count; l++)
					{
						if (so.snapList[l])
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
			}
			else if (so.objectType == 2)
			{
				if (so.meshObjects.Count == 0)
				{
					Debug.Log("EasyRoads3Dv3: no source mesh is defined for this side object (" + so.name + "), side object creation aborted");
					return;
				}
				int childCount = gameObject.transform.childCount;
				if (Application.isEditor && !Application.isPlaying)
				{
					int num;
					for (num = 0; num < gameObject.transform.childCount; num++)
					{
						UnityEngine.Object.DestroyImmediate(gameObject.transform.GetChild(num).gameObject);
						num--;
					}
				}
				else
				{
					int childCount2 = gameObject.transform.childCount;
					int num2 = 0;
					int num3;
					for (num3 = 0; num3 < gameObject.transform.childCount; num3++)
					{
						UnityEngine.Object.Destroy(gameObject.transform.GetChild(num3).gameObject);
						num3--;
						num2++;
						if (num2 == childCount2)
						{
							break;
						}
					}
				}
			}
			if (eRSORoadExt.runtimeObjects.Count > 0 && Application.isPlaying)
			{
				int num4 = eRSORoadExt.runtimeObjects.Count - 1;
				int num5 = 0;
				for (int m = 0; m < eRSORoadExt.runtimeObjects.Count; m++)
				{
					UnityEngine.Object.DestroyImmediate(eRSORoadExt.runtimeObjects[m]);
					num5++;
					if (m == num4)
					{
						break;
					}
				}
				eRSORoadExt.runtimeObjects.Clear();
			}
			if (so.relativeTo != 0)
			{
				if (so.relativeTo == 1)
				{
					OQOCDQDCDQ(gameObject, so, roadScr, eRSORoadExt, mirrored: false, !isParent);
					if (eRSORoadExt.autoGenerate || so.dualSided)
					{
						OQOCDQDCDQ(gameObject, so, roadScr, eRSORoadExt, mirrored: true, !isParent);
					}
				}
				else
				{
					OQOCDQDCDQ(gameObject, so, roadScr, eRSORoadExt, mirrored: false, !isParent);
					if (eRSORoadExt.autoGenerate || so.dualSided)
					{
						OQOCDQDCDQ(gameObject, so, roadScr, eRSORoadExt, mirrored: true, !isParent);
					}
				}
			}
			else
			{
				OQOCDQDCDQ(gameObject, so, roadScr, eRSORoadExt, mirrored: false, !isParent);
			}
			if (so.buildOtherSideObjectChilds.Count == 0 && so.buildOtherSideObjects.Count != 0)
			{
				so.OODQQCODOO();
			}
			if (so.buildOtherSideObjectChilds.Count > 0)
			{
				for (int n = 0; n < so.buildOtherSideObjectChilds.Count; n++)
				{
					SideObject sideObject = null;
					for (int num6 = 0; num6 < scr.QOQDQOOQDDQOOQ.Count; num6++)
					{
						if (scr.QOQDQOOQDDQOOQ[num6] != null && scr.QOQDQOOQDDQOOQ[num6].id == so.buildOtherSideObjectChilds[n].soid)
						{
							sideObject = scr.QOQDQOOQDDQOOQ[num6];
							break;
						}
					}
					if (!(sideObject != null))
					{
						continue;
					}
					_2vsst = so.buildOtherSideObjectChilds[n].offset;
					bool flag = false;
					for (int num7 = 0; num7 < roadScr.soDataExt.Count; num7++)
					{
						if (roadScr.soDataExt[num7].id == sideObject.id)
						{
							flag = roadScr.soDataExt[num7].active;
							break;
						}
					}
					if (!flag)
					{
						OODOQDDOCQ(scr, roadScr, sideObject);
						OOOQQQOOQC(scr, roadScr, sideObject, updateSideObjectsOnOtherRoadObjects: false);
					}
				}
			}
			if (updateSideObjectsOnOtherRoadObjects)
			{
				OCDOODOQDC.OCODQOQCQO(scr, roadNetworkRefresh: false);
			}
		}

		public static void OQOCDQDCDQ(GameObject go, SideObject so, ERModularRoad roadScr, ERSORoadExt soData, bool mirrored, bool isChild)
		{
			if (roadScr.baseScript.debugMode)
			{
			}
			try
			{
				if ((mirrored && roadScr.isSideObject) || roadScr.markersExt.Count < 2)
				{
					return;
				}
				isChild = so.isUsedAsChild;
				if (so.objectType == 1 && so.triangulateDualSided)
				{
					if (!mirrored)
					{
						soData.mainTriangulateVecs.Clear();
						soData.startSplinePointIndexes.Clear();
						soData.endSplinePointIndexes.Clear();
					}
					else
					{
						soData.mirroredTriangulateVecs.Clear();
						soData.startSplinePointIndexesMirrored.Clear();
						soData.endSplinePointIndexesMirrored.Clear();
					}
				}
				bool flag = false;
				yvsst = false;
				bool flag2 = false;
				bool flag3 = false;
				Avsss = Vector3.zero;
				_0vsst = Vector3.zero;
				soData.lastEndPosition = Vector3.zero;
				foreach (ERSOMarkerExt soDatum in roadScr.markersExt[0].soData)
				{
					if (soDatum == null)
					{
						OCDOODOQDC.ResetMarkerSOData(roadScr);
						if (soDatum == null)
						{
							return;
						}
					}
					if (mirrored && soDatum.sideObject == so && soDatum.otherSide == null)
					{
						OCDOODOQDC.ODCCCDDOCO(roadScr, so);
						if (soDatum.otherSide == null)
						{
							soDatum.otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
						}
						soDatum.otherSide.Copy(soDatum, reverse: true);
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
				_2ssst = Vector2.zero;
				Ausss = Vector2.zero;
				_0usst = Vector2.zero;
				Ausss = Vector2.zero;
				useLastFowardFlag = false;
				lastvecPositionsArray = false;
				if (soData != null)
				{
					OCDOODOQDC.SynchSoData(soData, flag: false);
					list8 = (((so.relativeTo != 1 || mirrored) && !(so.relativeTo == 2 && mirrored) && so.position != 1) ? (((so.relativeTo != 2 || mirrored) && !(so.relativeTo == 1 && mirrored) && so.position != 2) ? new List<Vector3>(roadScr.soSplinePoints) : ((so.scaleToRoad && !roadScr.isSideObject) ? new List<Vector3>(roadScr.soSplinePointsRightClamped) : new List<Vector3>(roadScr.soSplinePointsRight))) : ((so.scaleToRoad && !roadScr.isSideObject) ? new List<Vector3>(roadScr.soSplinePointsLeftClamped) : new List<Vector3>(roadScr.soSplinePointsLeft)));
					list11 = new List<Vector3>(roadScr.soSplinePoints);
					if (roadScr.OODOCCDDCQ.Count == 0)
					{
						if (list11.Count == 0)
						{
							return;
						}
						roadScr.ODCODQCCDQ = new List<float>();
						roadScr.OODOCCDDCQ = roadScr.ODOCQDOCDD(roadScr.tValues, roadScr.markerDistances, roadScr.markersExt, 0, roadScr.tmpMarkersExt.Count, ref roadScr.ODCODQCCDQ, roadScr.randomRotations);
					}
					if (so.align == 3 && !roadScr.rotationsAdjustedFlag)
					{
						if (roadScr.lastRotationStartInt != 0)
						{
							for (int i = 0; i < roadScr.lastRotationStartInt; i++)
							{
								Vector3 vector = roadScr.soSplinePointsLeft[i];
								vector.y = roadScr.soSplinePointsRight[i].y;
								Vector3 vector2 = roadScr.soSplinePointsRight[i] - vector;
								Vector3 to = roadScr.soSplinePointsRight[i] - roadScr.soSplinePointsLeft[i];
								float num = Vector3.Angle(vector2, to);
								if (roadScr.soSplinePointsLeft[i].y < roadScr.soSplinePointsRight[i].y)
								{
									num *= -1f;
								}
								roadScr.OODOCCDDCQ[i] = num;
							}
						}
						if (roadScr.lastRotationEndInt != 0)
						{
							for (int j = roadScr.lastRotationEndInt; j < list8.Count; j++)
							{
								Vector3 vector3 = roadScr.soSplinePointsLeft[j];
								vector3.y = roadScr.soSplinePointsRight[j].y;
								Vector3 vector4 = roadScr.soSplinePointsRight[j] - vector3;
								Vector3 to2 = roadScr.soSplinePointsRight[j] - roadScr.soSplinePointsLeft[j];
								float num2 = Vector3.Angle(vector4, to2);
								if (roadScr.soSplinePointsLeft[j].y < roadScr.soSplinePointsRight[j].y)
								{
									num2 *= -1f;
								}
								roadScr.OODOCCDDCQ[j] = num2;
							}
						}
						roadScr.rotationsAdjustedFlag = true;
					}
					list12 = new List<float>(roadScr.OODOCCDDCQ);
					if (list8.Count > list12.Count)
					{
						int count = list12.Count;
						for (int k = count; k < list8.Count; k++)
						{
							list12.Add(0f);
						}
					}
					if (!so.scaleToRoad || roadScr.isSideObject)
					{
						list9 = new List<Vector3>(roadScr.soSplinePointsLeft);
						list10 = new List<Vector3>(roadScr.soSplinePointsRight);
					}
					else
					{
						list9 = new List<Vector3>(roadScr.soSplinePointsLeftClamped);
						list10 = new List<Vector3>(roadScr.soSplinePointsRightClamped);
					}
					List<int> markerInts = new List<int>(roadScr.markerInts);
					int count2 = markerInts.Count;
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
						list8 = OQQOCDQCQD.GetSoSplinePoints(roadScr, sidewaysList, ref markerInts, ref tValues, ref markerDistances, ref tmpMarkers);
						list9.Clear();
						list10.Clear();
						for (int l = 0; l < list8.Count; l++)
						{
							Vector3 vector5 = ((l != 0) ? ((l != list8.Count - 1) ? (list8[l + 1] - list8[l - 1]) : (list8[list8.Count - 1] - list8[list8.Count - 2])) : (list8[l + 1] - list8[l]));
							vector5 = new Vector3(vector5.z, 0f, 0f - vector5.x).normalized;
							list9.Add(list8[l] - vector5);
							list10.Add(list8[l] + vector5);
						}
						list11 = new List<Vector3>(list8);
					}
					else
					{
						sidewaysList.Clear();
						tValues = roadScr.tValues;
						markerDistances = roadScr.markerDistances;
					}
					int num3 = -1;
					for (int m = 0; m < roadScr.markersExt[0].soData.Count; m++)
					{
						if (!(roadScr.markersExt[0].soData[m] != null) || !(roadScr.markersExt[0].soData[m].sideObject == so))
						{
							continue;
						}
						num3 = m;
						if (!mirrored)
						{
							if (roadScr.markersExt[0].soData[m].active && roadScr.markersExt[0].soData[m].startOffset == 0f)
							{
								flag2 = true;
							}
							if (!roadScr.closedTrack && roadScr.markersExt[roadScr.markersExt.Count - 2].soData.Count > m && roadScr.markersExt[roadScr.markersExt.Count - 2].soData[m].active && roadScr.markersExt[roadScr.markersExt.Count - 2].soData[m].endOffset == 0f)
							{
								flag3 = true;
							}
						}
						else
						{
							if (roadScr.markersExt[0].soData[m].otherSide.active && roadScr.markersExt[0].soData[m].otherSide.startOffset == 0f)
							{
								flag2 = true;
							}
							if (!roadScr.closedTrack && roadScr.markersExt[roadScr.markersExt.Count - 2].soData.Count > m && roadScr.markersExt[roadScr.markersExt.Count - 2].soData[m].otherSide != null && roadScr.markersExt[roadScr.markersExt.Count - 2].soData[m].otherSide.active && roadScr.markersExt[roadScr.markersExt.Count - 2].soData[m].otherSide.endOffset == 0f)
							{
								flag3 = true;
							}
						}
						break;
					}
					if (num3 == -1 && !isChild)
					{
						return;
					}
					if (so.objectType == 1)
					{
						if (so.hardEdge.Count < so.nodeList.Count)
						{
							so.hardEdge = new List<bool>(new bool[so.nodeList.Count]);
						}
						if (mirrored && so.nodeListMirrored.Count == 0)
						{
							so.OCDDQQDCCD();
						}
						if (shapeTransitionTypes.Count < markerDistances.Count)
						{
							if (shapeTransitionTypes.Count == 0)
							{
								shapeTransitionTypes.Add(0);
							}
							for (int n = shapeTransitionTypes.Count; n < markerDistances.Count; n++)
							{
								shapeTransitionTypes.Add(shapeTransitionTypes[shapeTransitionTypes.Count - 1]);
							}
						}
						if (nodeListValues.Count < markerDistances.Count)
						{
							if (nodeListValues.Count == 0)
							{
								nodeListValues.Add(new List<Vector2>(so.nodeList));
							}
							for (int count3 = nodeListValues.Count; count3 < markerDistances.Count; count3++)
							{
								nodeListValues.Add(new List<Vector2>(nodeListValues[nodeListValues.Count - 1]));
							}
						}
						if (so.nodeList.Count == 0)
						{
							return;
						}
						if (so.clampUVs && so.nodeList.Count != so.uvs.Count)
						{
							so.OQCQODQQQQ();
						}
						if (!customNodelistFlag)
						{
							for (int num4 = 0; num4 < so.nodeList.Count; num4++)
							{
								nodeList.Add(new List<Vector2>());
								for (int num5 = 0; num5 < list11.Count; num5++)
								{
									nodeList[num4].Add(so.nodeList[num4]);
								}
							}
						}
						else if (markerDistances.Count != 0)
						{
							nodeList = OQQOCDQCQD.GetRoadShapeValues(tValues, markerDistances, nodeListValues, 0, roadScr.tmpMarkersExt.Count, so.nodeList, shapeTransitionTypes, roadScr.closedTrack);
							for (int num6 = 0; num6 < nodeList.Count; num6++)
							{
								if (nodeList[num6].Count != list11.Count)
								{
									nodeList[num6].Clear();
									for (int num7 = 0; num7 < list11.Count; num7++)
									{
										nodeList[num6].Add(so.nodeList[num6]);
									}
								}
							}
						}
						else
						{
							Debug.LogError("EasyRoads3Dv3: Please update the Road Network: General Settings > Scene Settings > Refresh Road network");
						}
						List<Vector3> list13 = new List<Vector3>();
						if (!isChild)
						{
							for (int num8 = 0; num8 < roadScr.markersExt.Count; num8++)
							{
								int num9 = roadScr.markersExt[num8].startSplinePoint - 1;
								if (num9 >= list8.Count)
								{
									num9 = list8.Count - 1;
								}
								if (num8 == 0)
								{
									num9 = 0;
								}
								Vector3 v = Vector3.zero;
								Vector3 n2 = Vector3.zero;
								Vector3 v2 = list8[num9];
								Vector3 dir = ((list8.Count <= num9 + 1) ? (list8[num9] - list8[num9 - 1]).normalized : (list8[num9 + 1] - list8[num9]).normalized);
								list13.Clear();
								for (int num10 = 0; num10 < so.nodeList.Count; num10++)
								{
									List<Vector2> list14 = null;
									if (roadScr.markersExt[num8].soData.Count <= num3)
									{
										list14 = so.nodeList;
									}
									else
									{
										if (!mirrored)
										{
											list14 = roadScr.markersExt[num8].soData[num3].nodeList;
										}
										else if (roadScr.markersExt[num8].soData[num3].otherSide != null)
										{
											list14 = roadScr.markersExt[num8].soData[num3].otherSide.nodeList;
										}
										if (list14 == null || list14.Count != so.nodeList.Count)
										{
											list14 = so.nodeList;
										}
									}
									if (so.align == 1 || (sidewaysFlag && so.align != 0))
									{
										OQQOCDQCQD.OOCQDCCDQO(ref v, ref n2, v2, dir, list14[num10], roadScr, _2ssst);
									}
									else if (so.align == 2 || so.align == 0)
									{
										OQQOCDQCQD.OQDQDOOOCC(ref v, ref n2, v2, dir, list14[num10], 0f, _2ssst);
									}
									else if (so.align == 3)
									{
										OQQOCDQCQD.OQDQDOOOCC(ref v, ref n2, v2, dir, list14[num10], list12[num9], _2ssst);
									}
									list13.Add(v);
								}
								if (roadScr.markersExt[num8].soData.Count > num3 && !mirrored)
								{
									roadScr.markersExt[num8].soData[num3].nodeShapeVecsGlobal = new List<Vector3>(list13);
								}
							}
						}
					}
					List<Vector3> vecPositions = new List<Vector3>(list8);
					List<Vector3> list15 = new List<Vector3>();
					List<Vector3> list16 = new List<Vector3>();
					List<Vector3> soSplinePointCenter = new List<Vector3>(list11);
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
					List<List<int>> list30 = new List<List<int>>();
					List<bool> list31 = new List<bool>();
					List<int> list32 = new List<int>();
					List<int> list33 = new List<int>();
					if (vecPositions.Count != soSplinePointCenter.Count || (soSplinePointCenter.Count > list17.Count && !sidewaysFlag))
					{
						Debug.LogWarning("EasyRoads3Dv3 Warning: incomplete spline data, generating " + so.name + " aborted. Please try to refresh the road network (General Settings > Scene Settings)");
						return;
					}
					Vector3 pTarget = Vector3.zero;
					if (roadScr.markerInts.Count == 0)
					{
						return;
					}
					bool flag4 = false;
					if (soData.xPosition == 0f && num3 >= 0)
					{
						for (int num11 = 0; num11 < roadScr.markersExt.Count; num11++)
						{
							if (roadScr.markersExt[num11].soData.Count <= num3 || roadScr.markersExt[num11].soData[num3] == null)
							{
								continue;
							}
							if (mirrored && roadScr.markersExt[num11].soData[num3].otherSide == null)
							{
								OCDOODOQDC.ODCCCDDOCO(roadScr, so);
								if (roadScr.markersExt[num11].soData[num3].otherSide == null)
								{
									roadScr.markersExt[num11].soData[num3].otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
								}
								roadScr.markersExt[num11].soData[num3].otherSide.Copy(roadScr.markersExt[num11].soData[num3], reverse: true);
							}
							if ((!mirrored && roadScr.markersExt[num11].soData[num3].xPosition != soData.xPosition) || (mirrored && roadScr.markersExt[num11].soData[num3].otherSide.xPosition != soData.xPosition))
							{
								flag4 = true;
								break;
							}
						}
					}
					if ((soData.xPosition != 0f && so.position == 0 && sidewaysList.Count == 0) || flag4)
					{
						float num12 = soData.xPosition;
						if (mirrored)
						{
							num12 *= -1f;
						}
						vecPositions.Clear();
						markerInts.Clear();
						int num13 = 1;
						int num14 = roadScr.markersExt.Count - 1;
						float num15 = 0f;
						List<ERSOMarkerExt> list34 = null;
						bool flag5 = false;
						int index = 0;
						float num16 = 0f;
						List<Vector3> list35 = new List<Vector3>(list10);
						List<Vector3> list36 = new List<Vector3>(list9);
						int num17 = 0;
						for (int num18 = 0; num18 < list8.Count; num18++)
						{
							if (num18 == roadScr.markersExt[num13].startSplinePoint)
							{
								if (num13 < num14)
								{
									num13++;
									index++;
								}
								else
								{
									flag5 = true;
									index++;
								}
								num16 = roadScr.markersExt[index].startDistance;
							}
							List<ERSOMarkerExt> soData2 = roadScr.markersExt[num13 - 1].soData;
							if (!flag5)
							{
								list34 = roadScr.markersExt[num13].soData;
							}
							else
							{
								soData2 = roadScr.markersExt[num13].soData;
								list34 = roadScr.markersExt[0].soData;
							}
							if (num3 >= 0 && num3 < soData2.Count && soData2[num3] != null)
							{
								if (!mirrored)
								{
									if (soData2[num3].xPosition == list34[num3].xPosition)
									{
										num12 = soData2[num3].xPosition;
									}
									else
									{
										num15 = (roadScr.distances[num18] - num16) / roadScr.markersExt[index].totalDistance;
										num12 = Mathf.SmoothStep(soData2[num3].xPosition, list34[num3].xPosition, num15);
									}
								}
								else
								{
									if (roadScr.markersExt[num13].soData[num3].otherSide == null)
									{
										OCDOODOQDC.ODCCCDDOCO(roadScr, so);
										if (roadScr.markersExt[num13].soData[num3].otherSide == null)
										{
											roadScr.markersExt[num13].soData[num3].otherSide = ERSOMarkerExt.CreateInstance(so, flag: true);
										}
										roadScr.markersExt[num13].soData[num3].otherSide.Copy(list34[num3], reverse: true);
									}
									if (soData2[num3].otherSide.xPosition == list34[num3].otherSide.xPosition)
									{
										num12 = soData2[num3].otherSide.xPosition;
									}
									else
									{
										num15 = (roadScr.distances[num18] - num16) / roadScr.markersExt[index].totalDistance;
										num12 = Mathf.SmoothStep(soData2[num3].otherSide.xPosition, list34[num3].otherSide.xPosition, num15);
									}
								}
							}
							Vector3 vector5;
							if (!roadScr.isSideObject)
							{
								vector5 = (list35[num18] - list36[num18]).normalized;
							}
							else
							{
								vector5 = ((num18 == 0) ? (list8[1] - list8[0]) : ((num18 != list8.Count - 1) ? (list8[num18 + 1] - list8[num18 - 1]) : (list8[list8.Count - 1] - list8[list8.Count - 2])));
								vector5 = new Vector3(vector5.z, 0f, 0f - vector5.x).normalized;
							}
							Vector3 v2 = list8[num18] + num12 * vector5;
							if (num18 == 0 || num12 == 0f)
							{
								vecPositions.Add(v2);
								markerInts.Add(roadScr.markerInts[0]);
								pTarget = v2;
							}
							else if (num12 >= 0f)
							{
								if (!OQQOCDQCQD.OOCQODQDQD(pTarget, list8[num18 - 1], v2))
								{
									vecPositions.Add(v2);
									if (num18 < count2)
									{
										markerInts.Add(roadScr.markerInts[num18]);
									}
									else
									{
										markerInts.Add(roadScr.markerInts[count2 - 1]);
									}
									pTarget = v2;
								}
								else
								{
									list9.RemoveAt(num18 - num17);
									list10.RemoveAt(num18 - num17);
									num17++;
								}
							}
							else if (OQQOCDQCQD.OOCQODQDQD(pTarget, list8[num18 - 1], v2))
							{
								vecPositions.Add(v2);
								if (num18 < count2)
								{
									markerInts.Add(roadScr.markerInts[num18]);
								}
								else
								{
									markerInts.Add(roadScr.markerInts[count2 - 1]);
								}
								pTarget = v2;
							}
							else
							{
								list9.RemoveAt(num18 - num17);
								list10.RemoveAt(num18 - num17);
								num17++;
							}
						}
						if (vecPositions.Count <= 1 && list8.Count > 1)
						{
							Debug.LogError("EasyRoads3Dv3 Error: side object: " + so.name + " on road object: " + roadScr.gameObject.name + " - could not extract side object spline points. Please report with full details");
							return;
						}
					}
					else if (so.sidewaysOffset == 0f)
					{
					}
					int num19 = 0;
					float startOffset = 0f;
					float endOffset = 0f;
					int startInt = 0;
					ERSOMarkerExt soMarker = null;
					if (markerInts.Count != vecPositions.Count)
					{
						Debug.Log("EasyRoads3Dv3 Warning: " + roadScr.name + " Side Object: " + so.name + " Please review the side object status for this road");
						return;
					}
					bool flag6 = OOCODQOQOO(roadScr, so, 0, ref startOffset, ref endOffset, ref soMarker, mirrored);
					if (flag6 && (startOffset != 0f || roadScr.startOffsetActiveMarker != -1))
					{
						OCDOODOQDC.OQCQOCQCDC(ref startInt, startOffset, ref markerInts, ref vecPositions, ref soSplinePointCenter, ref list9, list10, ref soMarker, roadScr, ref nodeList);
					}
					else if (flag6)
					{
						OCDOODOQDC.ODCQQCOQOC(0, vecPositions, markerInts, ref soMarker, startFlag: true, roadScr);
					}
					if (flag6 && endOffset != 0f)
					{
						OCDOODOQDC.ODCCCCOOCQ(startInt, endOffset, ref markerInts, ref vecPositions, ref soSplinePointCenter, ref list9, list10, ref soMarker, roadScr, ref nodeList);
					}
					else if (flag6)
					{
						OCDOODOQDC.ODCQQCOQOC(0, vecPositions, markerInts, ref soMarker, startFlag: false, roadScr);
					}
					bool flag7 = flag6;
					bool flag8 = flag6;
					bool flag9 = false;
					list21.Add(new List<Vector3>());
					list22.Add(new List<Vector3>());
					list23.Add(new List<Vector3>());
					list24.Add(new List<Vector3>());
					list25.Add(new List<float>());
					list27.Add(new List<float>());
					list28.Add(new List<float>());
					list29.Add(new List<float>());
					list30.Add(new List<int>());
					list26.Add(new List<List<Vector2>>());
					for (int num20 = 0; num20 < nodeList.Count; num20++)
					{
						list26[0].Add(new List<Vector2>());
					}
					if ((so.relativeTo == 1 && mirrored) || (so.relativeTo == 2 && mirrored))
					{
						list31.Add(item: true);
					}
					else
					{
						list31.Add(item: false);
					}
					float num21 = 0f;
					int num22 = 0;
					if (soMarker == null && !isChild)
					{
						return;
					}
					if (soMarker != null && soMarker.rotationAngle != 0f)
					{
						float num23 = soMarker.rotationDistance;
						if (num23 < 3f * so.middleZDistance)
						{
							num23 = 3f * so.middleZDistance;
						}
						list27[0].Add(num21 + soMarker.rotationCenter - num23 * 0.5f);
						list28[0].Add(num23);
						if (!mirrored)
						{
							list29[0].Add(soMarker.rotationAngle);
						}
						else
						{
							list29[0].Add(0f - soMarker.rotationAngle);
						}
					}
					bool flag10 = false;
					int num24 = -1;
					int num25 = -1;
					int num26 = roadScr.exitRoads.Count - 1;
					int num27 = 0;
					if (roadScr.exitRoads.Count > 0)
					{
						flag10 = true;
						num25 = roadScr.exitRoads[0].startSplineIndex;
						num24 = roadScr.exitRoads[0].endSplineIndex;
					}
					bool flag11 = false;
					int item = 0;
					int num28 = 0;
					for (int startInt2 = startInt; startInt2 < vecPositions.Count; startInt2++)
					{
						if (flag6)
						{
							if (startInt2 == num25 && so.relativeTo == 2)
							{
								int num29 = roadScr.exitRoads[num27].soPointsRightStart.Count - 1;
								for (int num30 = 0; num30 < roadScr.exitRoads[num27].soPointsRightStart.Count; num30++)
								{
									Vector3 v2 = roadScr.exitRoads[num27].soPointsRightStart[num30];
									if (so.xPosition != 0f)
									{
										Vector3 vector5 = ((num30 == 0) ? (roadScr.exitRoads[num27].soPointsRightStart[1] - roadScr.exitRoads[num27].soPointsRightStart[0]) : ((num30 != num29) ? (roadScr.exitRoads[num27].soPointsRightStart[startInt2 + 1] - roadScr.exitRoads[num27].soPointsRightStart[startInt2 - 1]) : (roadScr.exitRoads[num27].soPointsRightStart[num29] - roadScr.exitRoads[num27].soPointsRightStart[num29 - 1])));
										vector5 = new Vector3(vector5.z, 0f, 0f - vector5.x).normalized;
										v2 = roadScr.exitRoads[num27].soPointsRightStart[num30] + vector5 * so.xPosition;
									}
									list21[num28].Add(v2);
									list22[num28].Add(v2);
									list23[num28].Add(v2);
									list24[num28].Add(soSplinePointCenter[startInt2]);
									if (!flag11)
									{
										list32.Add(startInt2);
										flag11 = true;
									}
								}
								list21.Add(new List<Vector3>());
								list22.Add(new List<Vector3>());
								list23.Add(new List<Vector3>());
								list24.Add(new List<Vector3>());
								list25.Add(new List<float>());
								list26.Add(new List<List<Vector2>>());
								for (int num31 = 0; num31 < nodeList.Count; num31++)
								{
									list26[num28 + 1].Add(new List<Vector2>());
								}
								list27.Add(new List<float>());
								list28.Add(new List<float>());
								list29.Add(new List<float>());
								list30.Add(new List<int>());
								if ((so.relativeTo == 1 && mirrored) || (so.relativeTo == 2 && mirrored))
								{
									list31.Add(item: true);
								}
								else
								{
									list31.Add(item: false);
								}
								num28++;
								num21 = 0f;
								num22 = 0;
								startInt2 = num24 - 1;
								if (num27 < num26)
								{
									num27++;
									num24 = roadScr.exitRoads[num27].endSplineIndex;
								}
							}
							else
							{
								list21[num28].Add(vecPositions[startInt2]);
								list22[num28].Add(list9[startInt2]);
								list23[num28].Add(list10[startInt2]);
								list24[num28].Add(soSplinePointCenter[startInt2]);
								if (!flag11)
								{
									list32.Add(startInt2);
									flag11 = true;
								}
								item = startInt2;
							}
							if (!sidewaysFlag)
							{
								if (list17.Count > startInt2)
								{
									list25[num28].Add(list17[startInt2]);
								}
								else
								{
									list25[num28].Add(0f);
								}
							}
							for (int num32 = 0; num32 < nodeList.Count; num32++)
							{
								list26[num28][num32].Add(nodeList[num32][startInt2]);
							}
							if (startInt2 == num24 - 1 && so.relativeTo != 2)
							{
							}
						}
						if (startInt2 >= vecPositions.Count - 1)
						{
							continue;
						}
						if (num19 != markerInts[startInt2])
						{
							flag6 = OOCODQOQOO(roadScr, so, markerInts[startInt2], ref startOffset, ref endOffset, ref soMarker, mirrored);
							if (list30.Count <= num28)
							{
								list30.Add(new List<int>());
							}
							list30[num28].Add(startInt2 - 2);
							if (flag6 && startOffset != 0f)
							{
								OCDOODOQDC.OQCQOCQCDC(ref startInt2, startOffset, ref markerInts, ref vecPositions, ref soSplinePointCenter, ref list9, list10, ref soMarker, roadScr, ref nodeList);
							}
							else if (flag6)
							{
								OCDOODOQDC.ODCQQCOQOC(startInt2, vecPositions, markerInts, ref soMarker, startFlag: true, roadScr);
							}
							if (flag6 && endOffset != 0f)
							{
								OCDOODOQDC.ODCCCCOOCQ(startInt2, endOffset, ref markerInts, ref vecPositions, ref soSplinePointCenter, ref list9, list10, ref soMarker, roadScr, ref nodeList);
							}
							else if (flag6)
							{
								OCDOODOQDC.ODCQQCOQOC(startInt2, vecPositions, markerInts, ref soMarker, startFlag: false, roadScr);
							}
							if (!flag8 && flag6 && list21[num28].Count > 0)
							{
								list33.Add(item);
								list32.Add(startInt2);
								flag11 = true;
								item = startInt2;
								list21.Add(new List<Vector3>());
								list22.Add(new List<Vector3>());
								list23.Add(new List<Vector3>());
								list24.Add(new List<Vector3>());
								list25.Add(new List<float>());
								list26.Add(new List<List<Vector2>>());
								for (int num33 = 0; num33 < nodeList.Count; num33++)
								{
									list26[num28 + 1].Add(new List<Vector2>());
								}
								list27.Add(new List<float>());
								list28.Add(new List<float>());
								list29.Add(new List<float>());
								if ((so.relativeTo == 1 && mirrored) || (so.relativeTo == 2 && mirrored))
								{
									list31.Add(item: true);
								}
								else
								{
									list31.Add(item: false);
								}
								num28++;
								num21 = 0f;
								num22 = 0;
								list21[num28].Add(vecPositions[startInt2]);
								list22[num28].Add(list9[startInt2]);
								list23[num28].Add(list10[startInt2]);
								list24[num28].Add(soSplinePointCenter[startInt2]);
								if (list17.Count > startInt2)
								{
									list25[num28].Add(list17[startInt2]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num34 = 0; num34 < nodeList.Count; num34++)
								{
									list26[num28][num34].Add(nodeList[num34][startInt2]);
								}
							}
							else if (!flag8 && flag6)
							{
								list32.Add(startInt2);
								flag11 = true;
								item = startInt2;
								list21[num28].Add(vecPositions[startInt2]);
								list22[num28].Add(list9[startInt2]);
								list23[num28].Add(list10[startInt2]);
								list24[num28].Add(soSplinePointCenter[startInt2]);
								if (list17.Count > startInt2)
								{
									list25[num28].Add(list17[startInt2]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num35 = 0; num35 < nodeList.Count; num35++)
								{
									list26[num28][num35].Add(nodeList[num35][startInt2]);
								}
							}
							if (flag6 && startInt2 > 0 && num22 > 0 && soMarker.rotationAngle != 0f)
							{
								float num36 = soMarker.rotationDistance;
								if (num36 < 3f * so.middleZDistance)
								{
									num36 = 3f * so.middleZDistance;
								}
								list27[num28].Add(num21 + soMarker.rotationCenter - num36 * 0.5f);
								list28[num28].Add(num36);
								if (!mirrored)
								{
									list29[num28].Add(soMarker.rotationAngle);
								}
								else
								{
									list29[num28].Add(0f - soMarker.rotationAngle);
								}
							}
							flag8 = flag6;
							num19 = markerInts[startInt2];
						}
						else
						{
							if (flag6 && startInt2 > 0 && num22 > 0)
							{
								num21 += Vector3.Distance(vecPositions[startInt2 - 1], vecPositions[startInt2]);
							}
							num22++;
						}
					}
					if (flag11)
					{
						list33.Add(item);
					}
					List<int> list37 = new List<int>();
					int num37 = list21.Count;
					if (num37 == 1 && list21[0].Count == 0)
					{
						num37 = 0;
					}
					bool flag12 = false;
					bool flag13 = false;
					bool flag14 = false;
					bool flag15 = false;
					int num38 = -1;
					uvsst = -1;
					if (soData.autoGenerate || isChild)
					{
						bool flag16 = true;
						bool flag17 = false;
						bool flag18 = false;
						bool flag19 = false;
						flag18 = false;
						flag19 = false;
						float num39 = 0f;
						if (list21[0].Count == 0)
						{
							list31.Clear();
						}
						if (so.tunnelObject || isChild)
						{
							flag7 = (flag8 = false);
							num38 = (uvsst = 1);
							num28 = 0;
							int num40 = 0;
							for (int num41 = 0; num41 < roadScr.soSectionList1.Count; num41++)
							{
								if ((roadScr.soSectionList1[num41].soid != so.id && !OCDOODOQDC.IsActiveAsChild(roadScr.baseScript, roadScr.soSectionList1[num41].soid, so.id)) || (roadScr.baseScript.isInBuildMode && !roadScr.soSectionList1[num41].active))
								{
									continue;
								}
								if (isChild)
								{
									num39 = roadScr.soSectionList1[num41].so.ODDDCDDOCQ(so.id);
								}
								flag18 = true;
								if (num40 > 0 || list21[0].Count > 0)
								{
									list21.Add(new List<Vector3>());
									list22.Add(new List<Vector3>());
									list23.Add(new List<Vector3>());
									list24.Add(new List<Vector3>());
									list25.Add(new List<float>());
									list26.Add(new List<List<Vector2>>());
									for (int num42 = 0; num42 < nodeList.Count; num42++)
									{
										list26[num28 + 1].Add(new List<Vector2>());
									}
									list27.Add(new List<float>());
									list28.Add(new List<float>());
									list29.Add(new List<float>());
									num21 = 0f;
									num22 = 0;
									num28 = list21.Count - 1;
								}
								num40++;
								list37.Add(num41);
								int num43 = roadScr.soSectionList1[num41].startSplinePoint;
								int num44 = roadScr.soSectionList1[num41].endSplinePoint;
								if (num43 <= 0)
								{
									num43 = 1;
								}
								if (num43 >= vecPositions.Count - 1)
								{
									num43 = vecPositions.Count - 2;
								}
								if (num44 >= vecPositions.Count - 1 || num44 < 0)
								{
									num44 = vecPositions.Count - 2;
								}
								Vector3 vector6 = roadScr.soSectionList1[num41].startPosition;
								Vector3 vector7 = roadScr.soSectionList1[num41].endPosition;
								if (roadScr.baseScript.activeTerrain == null)
								{
									roadScr.baseScript.OQQOQQCOOQ(vecPositions[num43]);
								}
								float num45 = OQQOCDQCQD.OCCOCQQCCQ(roadScr.baseScript.activeTerrain, vecPositions[num43 - 1], vecPositions[num43]);
								if (roadScr.soSectionList1[num41].so == null)
								{
									roadScr.soSectionList1[num41].GetERSectionSO(roadScr.baseScript.QOQDQOOQDDQOOQ);
								}
								if (roadScr.soSectionList1[num41].so == null)
								{
									Debug.LogError("EasyRoads3Dv3 Error: the side object assigned to this section is null, please report with details of the processes prior to this error message");
								}
								if (roadScr.soSectionList1[num41].so.geoStartOffset + num45 - num39 != 0f)
								{
									float num46 = 0f;
									Vector3 vector8 = roadScr.soSectionList1[num41].startPosition;
									float num47 = roadScr.soSectionList1[num41].so.geoStartOffset - num39;
									if (num47 < num45 * 1.5f && !isChild)
									{
										num47 = num45 * 1.5f;
									}
									int num48 = num43 - 1;
									bool flag20 = true;
									if (num47 <= 0f || num48 <= 0)
									{
										flag20 = false;
									}
									List<Vector3> soSplinePoints = roadScr.soSplinePoints;
									while (num47 > 0f && num48 >= 0)
									{
										num46 = Vector3.Distance(soSplinePoints[num48], vector8);
										if (num46 > num47)
										{
											float t = num47 / num46;
											vector6 = Vector3.Lerp(vector8, soSplinePoints[num48], t);
											num43 = num48 + 1;
											flag20 = false;
											break;
										}
										num47 -= num46;
										vector8 = soSplinePoints[num48];
										num48--;
									}
									if (flag20 && !isChild)
									{
										Debug.Log("EasyRoads3Dv3 Warning: Side object '" + so.name + "' section " + (num41 + 1) + " Start Offset is too large, not enough room in front of the tunnel start");
									}
								}
								num45 = OQQOCDQCQD.OCCOCQQCCQ(roadScr.baseScript.activeTerrain, vecPositions[num44 - 1], vecPositions[num44]);
								if (roadScr.soSectionList1[num41].so.geoEndOffset + num45 - num39 != 0f)
								{
									float num49 = 0f;
									Vector3 vector9 = roadScr.soSectionList1[num41].endPosition;
									float num50 = roadScr.soSectionList1[num41].so.geoEndOffset - num39;
									if (num50 < num45 * 1.5f && !isChild)
									{
										num50 = num45 * 1.5f;
									}
									int num51 = num44 + 1;
									bool flag21 = true;
									List<Vector3> soSplinePoints2 = roadScr.soSplinePoints;
									while (num50 > 0f && num51 < vecPositions.Count)
									{
										num49 = Vector3.Distance(soSplinePoints2[num51], vector9);
										if (num49 > num50)
										{
											float t2 = num50 / num49;
											vector7 = Vector3.Lerp(vector9, soSplinePoints2[num51], t2);
											num44 = num51 - 1;
											flag21 = false;
											break;
										}
										num50 -= num49;
										vector9 = soSplinePoints2[num51];
										num51++;
									}
									if (flag21 && !isChild)
									{
										Debug.Log("EasyRoads3Dv3 Warning: Side object '" + so.name + "' section " + (num41 + 1) + " End Offset is too large, not enough room after the tunnel end");
									}
								}
								if ((isChild && so.relativeTo == 1 && !mirrored) || (so.relativeTo == 2 && mirrored))
								{
									int num52 = 0;
									if (num43 > 0)
									{
										num52 = 1;
									}
									vector6 = OQQOCDQCQD.OCOOQOQCDC(vecPositions[num43 - num52], vecPositions[num43 + 1], vector6);
								}
								else if ((isChild && so.relativeTo == 2 && !mirrored) || (so.relativeTo == 1 && mirrored))
								{
									int num53 = 0;
									if (num43 > 0)
									{
										num53 = 1;
									}
									vector6 = OQQOCDQCQD.OCOOQOQCDC(vecPositions[num43 - num53], vecPositions[num43 + 1], vector6);
								}
								float num54 = Vector3.Distance(vecPositions[num43], list9[num43]);
								Vector3 vector5 = (list9[num43] - list10[num43]).normalized;
								list21[num28].Add(vector6);
								list22[num28].Add(vector6 + vector5 * num54);
								num54 = Vector3.Distance(vecPositions[num43], list10[num43]);
								list23[num28].Add(vector6 + -vector5 * num54);
								list24[num28].Add(vector6);
								if (list17.Count > num43)
								{
									list25[num28].Add(list17[num43]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num55 = num43; num55 <= num44; num55++)
								{
									list21[num28].Add(vecPositions[num55]);
									list22[num28].Add(list9[num55]);
									list23[num28].Add(list10[num55]);
									list24[num28].Add(soSplinePointCenter[num55]);
									if (list17.Count > num43)
									{
										list25[num28].Add(list17[num55]);
									}
									else
									{
										list25[num28].Add(0f);
									}
								}
								if ((isChild && so.relativeTo == 1 && !mirrored) || (so.relativeTo == 2 && mirrored))
								{
									int num56 = 0;
									if (num44 < list9.Count - 1)
									{
										num56 = 1;
									}
									vector7 = OQQOCDQCQD.OCOOQOQCDC(list9[num44 - 3], list9[num44 + num56], vector7);
								}
								else if ((isChild && so.relativeTo == 2 && !mirrored) || (so.relativeTo == 1 && mirrored))
								{
									int num57 = 0;
									if (num44 < list9.Count - 1)
									{
										num57 = 1;
									}
									vector7 = OQQOCDQCQD.OCOOQOQCDC(list10[num44 - 3], list10[num44 + num57], vector7);
								}
								num54 = Vector3.Distance(vecPositions[num44], list9[num44]);
								vector5 = (list9[num44] - list10[num44]).normalized;
								list21[num28].Add(vector7);
								list22[num28].Add(vector7 + vector5 * num54);
								num54 = Vector3.Distance(vecPositions[num44], list10[num44]);
								list23[num28].Add(vector7 + -vector5 * num54);
								list24[num28].Add(vector7);
								if (list17.Count > num44 + 1)
								{
									list25[num28].Add(list17[num44 + 1]);
								}
								else if (list25[num28].Count > 0 && list17.Count > num43)
								{
									list25[num28].Add(list25[num28][list25[num28].Count - 1]);
								}
								else
								{
									list25[num28].Add(0f);
								}
							}
						}
						if (so.bridgeObject || isChild)
						{
							flag7 = (flag8 = false);
							flag11 = false;
							num28 = 0;
							int num58 = 0;
							for (int num59 = 0; num59 < roadScr.soSectionList2.Count; num59++)
							{
								if ((roadScr.soSectionList2[num59].soid != so.id && !OCDOODOQDC.IsActiveAsChild(roadScr.baseScript, roadScr.soSectionList2[num59].soid, so.id)) || (roadScr.baseScript.isInBuildMode && !roadScr.soSectionList2[num59].active))
								{
									continue;
								}
								num38 = (uvsst = 2);
								flag18 = true;
								if ((num58 > 0 || list21[0].Count > 0) && (flag17 || (flag16 && list21[0].Count > 0)))
								{
									list21.Add(new List<Vector3>());
									list22.Add(new List<Vector3>());
									list23.Add(new List<Vector3>());
									list24.Add(new List<Vector3>());
									list25.Add(new List<float>());
									list26.Add(new List<List<Vector2>>());
									for (int num60 = 0; num60 < nodeList.Count; num60++)
									{
										list26[num28 + 1].Add(new List<Vector2>());
									}
									list27.Add(new List<float>());
									list28.Add(new List<float>());
									list29.Add(new List<float>());
									num21 = 0f;
									num22 = 0;
									num28 = list21.Count - 1;
								}
								num58++;
								list37.Add(num59);
								int num61 = roadScr.soSectionList2[num59].startSplinePoint;
								int num62 = roadScr.soSectionList2[num59].endSplinePoint;
								if (num61 < 0)
								{
									num61 = 1;
								}
								if (num61 >= vecPositions.Count - 1)
								{
									num61 = vecPositions.Count - 2;
								}
								if (num62 >= vecPositions.Count || num62 < 0)
								{
									num62 = vecPositions.Count - 2;
								}
								Vector3 vector10 = vecPositions[num61];
								Vector3 vector11 = vecPositions[num62];
								if (roadScr.baseScript.activeTerrain == null)
								{
									roadScr.baseScript.OQQOQQCOOQ(vecPositions[num61]);
								}
								float num63 = 0f;
								num63 = ((num61 <= 0) ? OQQOCDQCQD.OCCOCQQCCQ(roadScr.baseScript.activeTerrain, vecPositions[num61], vecPositions[num61 + 1]) : OQQOCDQCQD.OCCOCQQCCQ(roadScr.baseScript.activeTerrain, vecPositions[num61 - 1], vecPositions[num61]));
								int num64 = num61;
								float num65 = num63 + roadScr.soSectionList2[num59].startDistanceGeo;
								float num66 = 0f;
								bool flag22 = false;
								float num68;
								for (int num67 = num64; num67 > 0; num67--)
								{
									num66 = Vector3.Distance(vecPositions[num67], vecPositions[num67 + 1]);
									num68 = num65;
									num65 -= num66;
									if (num65 < 0f)
									{
										num61 = num67;
										vector10 = Vector3.Lerp(vecPositions[num67], vecPositions[num67 - 1], num68 / num66);
										flag22 = true;
										break;
									}
								}
								if (!flag22)
								{
									vector10 = vecPositions[0];
									num61 = 0;
								}
								num63 = OQQOCDQCQD.OCCOCQQCCQ(roadScr.baseScript.activeTerrain, vecPositions[num62 - 1], vecPositions[num62]);
								int num69 = num62;
								num68 = 0f;
								num65 = num63 + roadScr.soSectionList2[num59].endDistanceGeo;
								for (int num70 = num69; num70 < vecPositions.Count - 1; num70++)
								{
									num66 = Vector3.Distance(vecPositions[num70], vecPositions[num70 + 1]);
									num68 = num65;
									num65 -= num66;
									if (num65 < 0f)
									{
										if (num70 < vecPositions.Count - 2)
										{
											num62 = num70;
										}
										vector11 = Vector3.Lerp(vecPositions[num62], vecPositions[num62 + 1], num68 / num66);
										flag22 = true;
										break;
									}
								}
								if (!flag22)
								{
									vector11 = vecPositions[vecPositions.Count - 1];
									num62 = vecPositions.Count - 1;
								}
								if (num61 == 1 && roadScr.startPrefabScript != null)
								{
									num61 = 0;
								}
								if (num62 == vecPositions.Count - 2 && roadScr.endPrefabScript != null)
								{
									num62 = vecPositions.Count - 1;
								}
								if (num61 == 0 && so.objectType == 1 && so.dualSided)
								{
									flag2 = true;
								}
								if (num62 == vecPositions.Count - 1 && so.objectType == 1 && so.dualSided)
								{
									flag3 = true;
								}
								list32.Add(num61);
								list33.Add(num62);
								num65 = Vector3.Distance(vecPositions[num61], list9[num61]);
								Vector3 vector5 = (list9[num61] - list10[num61]).normalized;
								list21[num28].Add(vector10);
								list22[num28].Add(vector10 + vector5 * num65);
								num65 = Vector3.Distance(vecPositions[num61], list10[num61]);
								list23[num28].Add(vector10 + -vector5 * num65);
								list24[num28].Add(vector10);
								if (list17.Count > num61)
								{
									list25[num28].Add(list17[num61]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num71 = num61; num71 <= num62; num71++)
								{
									list21[num28].Add(vecPositions[num71]);
									list22[num28].Add(list9[num71]);
									list23[num28].Add(list10[num71]);
									list24[num28].Add(soSplinePointCenter[num71]);
									if (list17.Count > num61)
									{
										list25[num28].Add(list17[num71]);
									}
									else
									{
										list25[num28].Add(0f);
									}
								}
								num65 = Vector3.Distance(vecPositions[num62], list9[num62]);
								vector5 = (list9[num62] - list10[num62]).normalized;
								list21[num28].Add(vector11);
								list22[num28].Add(vector11 + vector5 * num65);
								num65 = Vector3.Distance(vecPositions[num62], list10[num62]);
								list23[num28].Add(vector11 + -vector5 * num65);
								list24[num28].Add(vector11);
								if (list17.Count > num62 + 1)
								{
									list25[num28].Add(list17[num62 + 1]);
								}
								else if (list25[num28].Count > 0 && list17.Count > num61)
								{
									list25[num28].Add(list25[num28][list25[num28].Count - 1]);
								}
								else
								{
									list25[num28].Add(0f);
								}
							}
						}
						if (so.category == 0)
						{
							flag8 = false;
							num28 = 0;
							int num72 = 0;
							for (int num73 = 0; num73 < roadScr.soSectionList3.Count; num73++)
							{
								if (roadScr.soSectionList3[num73].soid != so.id || (roadScr.baseScript.isInBuildMode && !roadScr.soSectionList3[num73].active))
								{
									continue;
								}
								num38 = (uvsst = 3);
								int num74 = roadScr.soSectionList3[num73].startSplinePoint;
								int num75 = roadScr.soSectionList3[num73].endSplinePoint;
								if (num75 < num74)
								{
									continue;
								}
								flag18 = true;
								if (so.relativeTo != 0 && ((mirrored && so.relativeTo == 1 && roadScr.soSectionList3[num73].roadSide == ERRoadSide.Left) || (mirrored && so.relativeTo == 2 && roadScr.soSectionList3[num73].roadSide == ERRoadSide.Right) || (!mirrored && so.relativeTo == 1 && roadScr.soSectionList3[num73].roadSide == ERRoadSide.Right) || (!mirrored && so.relativeTo == 2 && roadScr.soSectionList3[num73].roadSide == ERRoadSide.Left)))
								{
									continue;
								}
								if ((num72 > 0 || list21[0].Count > 0) && (flag17 || (flag16 && list21[0].Count > 0)))
								{
									list21.Add(new List<Vector3>());
									list22.Add(new List<Vector3>());
									list23.Add(new List<Vector3>());
									list24.Add(new List<Vector3>());
									list25.Add(new List<float>());
									list26.Add(new List<List<Vector2>>());
									for (int num76 = 0; num76 < nodeList.Count; num76++)
									{
										list26[num28 + 1].Add(new List<Vector2>());
									}
									list27.Add(new List<float>());
									list28.Add(new List<float>());
									list29.Add(new List<float>());
									num21 = 0f;
									num22 = 0;
									num28 = list21.Count - 1;
								}
								num72++;
								list37.Add(num73);
								flag17 = true;
								flag16 = false;
								if (num74 <= 0)
								{
									num74 = 1;
								}
								if (num74 >= vecPositions.Count)
								{
									num74 = vecPositions.Count - 1;
								}
								if (num75 >= vecPositions.Count - 1)
								{
									num75 = vecPositions.Count - 2;
								}
								Vector3 vector12 = vecPositions[num74];
								Vector3 vector13 = vecPositions[num75];
								if (roadScr.baseScript.activeTerrain == null)
								{
									roadScr.baseScript.OQQOQQCOOQ(vecPositions[num74]);
								}
								if (roadScr.soSectionList3[num73].startFraction != 0f)
								{
									vector12 = Vector3.Lerp(vecPositions[num74], vecPositions[num74 - 1], roadScr.soSectionList3[num73].startFraction);
								}
								if (roadScr.soSectionList3[num73].endFraction != 0f)
								{
									float t3 = roadScr.soSectionList3[num73].endFraction;
									if (num75 >= vecPositions.Count - 1)
									{
										num75 = vecPositions.Count - 2;
										t3 = 1f;
									}
									vector13 = Vector3.Lerp(vecPositions[num75], vecPositions[num75 + 1], t3);
								}
								float num77 = Vector3.Distance(vecPositions[num74], list9[num74]);
								Vector3 vector5 = (list9[num74] - list10[num74]).normalized;
								list21[num28].Add(vector12);
								list22[num28].Add(vector12 + vector5 * num77);
								num77 = Vector3.Distance(vecPositions[num74], list10[num74]);
								list23[num28].Add(vector12 + -vector5 * num77);
								list24[num28].Add(vector12);
								if (list17.Count > num74)
								{
									list25[num28].Add(list17[num74]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num78 = num74; num78 <= num75; num78++)
								{
									list21[num28].Add(vecPositions[num78]);
									list22[num28].Add(list9[num78]);
									list23[num28].Add(list10[num78]);
									list24[num28].Add(soSplinePointCenter[num78]);
									if (list17.Count > num74)
									{
										list25[num28].Add(list17[num78]);
									}
									else
									{
										list25[num28].Add(0f);
									}
								}
								num77 = Vector3.Distance(vecPositions[num75], list9[num75]);
								vector5 = (list9[num75] - list10[num75]).normalized;
								list21[num28].Add(vector13);
								list22[num28].Add(vector13 + vector5 * num77);
								num77 = Vector3.Distance(vecPositions[num75], list10[num75]);
								list23[num28].Add(vector13 + -vector5 * num77);
								list24[num28].Add(vector13);
								if (list17.Count > num75 + 1)
								{
									list25[num28].Add(list17[num75 + 1]);
								}
								else if (list25[num28].Count > 0 && list17.Count > num74)
								{
									list25[num28].Add(list25[num28][list25[num28].Count - 1]);
								}
								else
								{
									list25[num28].Add(0f);
								}
							}
							flag7 = (flag8 = false);
							num28 = 0;
							num72 = 0;
							for (int num79 = 0; num79 < roadScr.soSectionList4.Count; num79++)
							{
								if (roadScr.soSectionList4[num79].soid != so.id || (roadScr.baseScript.isInBuildMode && !roadScr.soSectionList4[num79].active))
								{
									continue;
								}
								flag18 = true;
								num38 = 3;
								uvsst = 4;
								int num80 = roadScr.soSectionList4[num79].startSplinePoint;
								int num81 = roadScr.soSectionList4[num79].endSplinePoint;
								if (num81 < num80 || (so.relativeTo != 0 && ((mirrored && so.relativeTo == 1 && roadScr.soSectionList4[num79].roadSide == ERRoadSide.Left) || (mirrored && so.relativeTo == 2 && roadScr.soSectionList4[num79].roadSide == ERRoadSide.Right) || (!mirrored && so.relativeTo == 1 && roadScr.soSectionList4[num79].roadSide == ERRoadSide.Right) || (!mirrored && so.relativeTo == 2 && roadScr.soSectionList4[num79].roadSide == ERRoadSide.Left))))
								{
									continue;
								}
								if ((num72 > 0 || list21[0].Count > 0) && (flag17 || (flag16 && list21[0].Count > 0)))
								{
									list21.Add(new List<Vector3>());
									list22.Add(new List<Vector3>());
									list23.Add(new List<Vector3>());
									list24.Add(new List<Vector3>());
									list25.Add(new List<float>());
									list26.Add(new List<List<Vector2>>());
									for (int num82 = 0; num82 < nodeList.Count; num82++)
									{
										list26[num28 + 1].Add(new List<Vector2>());
									}
									list27.Add(new List<float>());
									list28.Add(new List<float>());
									list29.Add(new List<float>());
									num21 = 0f;
									num22 = 0;
									num28 = list21.Count - 1;
								}
								num72++;
								list37.Add(num79);
								flag17 = true;
								flag16 = false;
								if (num80 <= 0)
								{
									num80 = 1;
								}
								if (num80 >= vecPositions.Count)
								{
									num80 = vecPositions.Count - 1;
								}
								if (num81 >= vecPositions.Count - 1)
								{
									num81 = vecPositions.Count - 2;
								}
								Vector3 vector14 = vecPositions[num80];
								Vector3 vector15 = vecPositions[num81];
								if (roadScr.baseScript.activeTerrain == null)
								{
									roadScr.baseScript.OQQOQQCOOQ(vecPositions[num80]);
								}
								if (roadScr.soSectionList4[num79].startFraction != 0f)
								{
									vector14 = Vector3.Lerp(vecPositions[num80], vecPositions[num80 - 1], roadScr.soSectionList4[num79].startFraction);
								}
								if (roadScr.soSectionList4[num79].endFraction != 0f)
								{
									float t4 = roadScr.soSectionList4[num79].endFraction;
									if (num81 >= vecPositions.Count - 1)
									{
										num81 = vecPositions.Count - 2;
										t4 = 1f;
									}
									vector15 = Vector3.Lerp(vecPositions[num81], vecPositions[num81 + 1], t4);
								}
								float num83 = Vector3.Distance(vecPositions[num80], list9[num80]);
								Vector3 vector5 = (list9[num80] - list10[num80]).normalized;
								list21[num28].Add(vector14);
								list22[num28].Add(vector14 + vector5 * num83);
								num83 = Vector3.Distance(vecPositions[num80], list10[num80]);
								list23[num28].Add(vector14 + -vector5 * num83);
								list24[num28].Add(vector14);
								if (list17.Count > num80)
								{
									list25[num28].Add(list17[num80]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num84 = num80; num84 <= num81; num84++)
								{
									list21[num28].Add(vecPositions[num84]);
									list22[num28].Add(list9[num84]);
									list23[num28].Add(list10[num84]);
									list24[num28].Add(soSplinePointCenter[num84]);
									if (list17.Count > num80)
									{
										list25[num28].Add(list17[num84]);
									}
									else
									{
										list25[num28].Add(0f);
									}
								}
								num83 = Vector3.Distance(vecPositions[num81], list9[num81]);
								vector5 = (list9[num81] - list10[num81]).normalized;
								list21[num28].Add(vector15);
								list22[num28].Add(vector15 + vector5 * num83);
								num83 = Vector3.Distance(vecPositions[num81], list10[num81]);
								list23[num28].Add(vector15 + -vector5 * num83);
								list24[num28].Add(vector15);
								if (list17.Count > num80)
								{
									list25[num28].Add(list17[num80]);
								}
								else
								{
									list25[num28].Add(0f);
								}
							}
						}
						if (so.category == 4)
						{
							flag7 = (flag8 = false);
							num28 = 0;
							int num85 = 0;
							for (int num86 = 0; num86 < roadScr.soSectionList5.Count; num86++)
							{
								if (roadScr.soSectionList5[num86].soid != so.id || (roadScr.baseScript.isInBuildMode && !roadScr.soSectionList5[num86].active))
								{
									continue;
								}
								num38 = (uvsst = 5);
								flag19 = true;
								if (so.relativeTo != 0 && ((mirrored && so.relativeTo == 1 && roadScr.soSectionList5[num86].roadSide == ERRoadSide.Left && !so.doubleSidedBendFlag) || (mirrored && so.relativeTo == 2 && roadScr.soSectionList5[num86].roadSide == ERRoadSide.Right && !so.doubleSidedBendFlag) || (!mirrored && so.relativeTo == 1 && roadScr.soSectionList5[num86].roadSide == ERRoadSide.Right && !so.doubleSidedBendFlag) || (!mirrored && so.relativeTo == 2 && roadScr.soSectionList5[num86].roadSide == ERRoadSide.Left && !so.doubleSidedBendFlag)))
								{
									continue;
								}
								if ((num85 > 0 || list21[0].Count > 0) && (flag17 || (flag16 && list21[0].Count > 0)))
								{
									list21.Add(new List<Vector3>());
									list22.Add(new List<Vector3>());
									list23.Add(new List<Vector3>());
									list24.Add(new List<Vector3>());
									list25.Add(new List<float>());
									list26.Add(new List<List<Vector2>>());
									for (int num87 = 0; num87 < nodeList.Count; num87++)
									{
										list26[num28 + 1].Add(new List<Vector2>());
									}
									list27.Add(new List<float>());
									list28.Add(new List<float>());
									list29.Add(new List<float>());
									num21 = 0f;
									num22 = 0;
									num28 = list21.Count - 1;
								}
								list37.Add(num86);
								num85++;
								if (roadScr.soSectionList5[num86].roadSide == ERRoadSide.Left)
								{
									if ((!roadScr.oneWayRoad && roadScr.baseScript.rightHandDriving == 1) || roadScr.oneWayDirection == ERLaneDirection.Left)
									{
										list31.Add(item: true);
									}
									else
									{
										list31.Add(item: false);
									}
								}
								else if (roadScr.soSectionList5[num86].roadSide == ERRoadSide.Left)
								{
									if ((!roadScr.oneWayRoad && roadScr.baseScript.rightHandDriving == 0) || roadScr.oneWayDirection == ERLaneDirection.Left)
									{
										list31.Add(item: true);
									}
									else
									{
										list31.Add(item: false);
									}
								}
								flag17 = true;
								flag16 = false;
								int num88 = roadScr.soSectionList5[num86].startSplinePoint;
								int num89 = roadScr.soSectionList5[num86].endSplinePoint;
								if (num88 <= 0)
								{
									num88 = 1;
								}
								if (num88 >= vecPositions.Count)
								{
									num88 = vecPositions.Count - 1;
								}
								if (num89 >= vecPositions.Count - 1)
								{
									num89 = vecPositions.Count - 2;
								}
								Vector3 vector16 = vecPositions[num88];
								Vector3 vector17 = vecPositions[num89];
								if (roadScr.baseScript.activeTerrain == null)
								{
									roadScr.baseScript.OQQOQQCOOQ(vecPositions[num88]);
								}
								if (roadScr.soSectionList5[num86].startFraction != 0f)
								{
									vector16 = Vector3.Lerp(vecPositions[num88], vecPositions[num88 - 1], roadScr.soSectionList5[num86].startFraction);
								}
								if (roadScr.soSectionList5[num86].endFraction != 0f)
								{
									vector17 = Vector3.Lerp(vecPositions[num89], vecPositions[num89 + 1], roadScr.soSectionList5[num86].endFraction);
								}
								float num90 = Vector3.Distance(vecPositions[num88], list9[num88]);
								Vector3 vector5 = (list9[num88] - list10[num88]).normalized;
								list21[num28].Add(vector16);
								list22[num28].Add(vector16 + vector5 * num90);
								num90 = Vector3.Distance(vecPositions[num88], list10[num88]);
								list23[num28].Add(vector16 + -vector5 * num90);
								list24[num28].Add(vector16);
								if (list17.Count > num88)
								{
									list25[num28].Add(list17[num88]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num91 = num88; num91 <= num89; num91++)
								{
									list21[num28].Add(vecPositions[num91]);
									list22[num28].Add(list9[num91]);
									list23[num28].Add(list10[num91]);
									list24[num28].Add(soSplinePointCenter[num91]);
									if (list17.Count > num88)
									{
										list25[num28].Add(list17[num91]);
									}
									else
									{
										list25[num28].Add(0f);
									}
								}
								num90 = Vector3.Distance(vecPositions[num89], list9[num89]);
								vector5 = (list9[num89] - list10[num89]).normalized;
								list21[num28].Add(vector17);
								list22[num28].Add(vector17 + vector5 * num90);
								num90 = Vector3.Distance(vecPositions[num89], list10[num89]);
								list23[num28].Add(vector17 + -vector5 * num90);
								list24[num28].Add(vector17);
								if (list17.Count > num89 + 1)
								{
									list25[num28].Add(list17[num89 + 1]);
								}
								else if (list25[num28].Count > 0 && list17.Count > num88)
								{
									list25[num28].Add(list25[num28][list25[num28].Count - 1]);
								}
								else
								{
									list25[num28].Add(0f);
								}
							}
						}
						if ((so.category == 2 && so.retainingWall) || isChild)
						{
							flag7 = (flag8 = false);
							num28 = 0;
							int num92 = 0;
							for (int num93 = 0; num93 < roadScr.soSectionList6.Count; num93++)
							{
								if ((roadScr.soSectionList6[num93].soid != so.id && !OCDOODOQDC.IsActiveAsChild(roadScr.baseScript, roadScr.soSectionList6[num93].soid, so.id)) || (roadScr.baseScript.isInBuildMode && !roadScr.soSectionList6[num93].active))
								{
									continue;
								}
								num38 = (uvsst = 6);
								flag19 = true;
								if (so.relativeTo != 0 && ((mirrored && so.relativeTo == 1 && roadScr.soSectionList6[num93].roadSide == ERRoadSide.Left) || (mirrored && so.relativeTo == 2 && roadScr.soSectionList6[num93].roadSide == ERRoadSide.Right) || (!mirrored && so.relativeTo == 1 && roadScr.soSectionList6[num93].roadSide == ERRoadSide.Right) || (!mirrored && so.relativeTo == 2 && roadScr.soSectionList6[num93].roadSide == ERRoadSide.Left)))
								{
									continue;
								}
								if ((num92 > 0 || list21[0].Count > 0) && (flag17 || (flag16 && list21[0].Count > 0)))
								{
									list21.Add(new List<Vector3>());
									list22.Add(new List<Vector3>());
									list23.Add(new List<Vector3>());
									list24.Add(new List<Vector3>());
									list25.Add(new List<float>());
									list26.Add(new List<List<Vector2>>());
									for (int num94 = 0; num94 < nodeList.Count; num94++)
									{
										list26[num28 + 1].Add(new List<Vector2>());
									}
									list27.Add(new List<float>());
									list28.Add(new List<float>());
									list29.Add(new List<float>());
									num21 = 0f;
									num22 = 0;
									num28 = list21.Count - 1;
								}
								num92++;
								list37.Add(num93);
								flag17 = true;
								flag16 = false;
								int num95 = roadScr.soSectionList6[num93].startSplinePoint;
								int num96 = roadScr.soSectionList6[num93].endSplinePoint;
								if (num95 < 0)
								{
									num95 = 0;
								}
								if (num95 >= vecPositions.Count)
								{
									num95 = vecPositions.Count - 1;
								}
								if (num96 >= vecPositions.Count)
								{
									num96 = vecPositions.Count - 1;
								}
								if (num95 == 0)
								{
									flag2 = true;
								}
								if (num96 == vecPositions.Count - 1)
								{
									flag3 = true;
								}
								Vector3 vector18 = vecPositions[num95];
								Vector3 vector19 = vecPositions[num96];
								if (roadScr.baseScript.activeTerrain == null)
								{
									roadScr.baseScript.OQQOQQCOOQ(vecPositions[num95]);
								}
								if (roadScr.soSectionList6[num93].startFraction != 0f)
								{
									vector18 = Vector3.Lerp(vecPositions[num95], vecPositions[num95 - 1], roadScr.soSectionList6[num93].startFraction);
								}
								if (roadScr.soSectionList6[num93].endFraction != 0f)
								{
									float t5 = roadScr.soSectionList6[num93].endFraction;
									if (num96 >= vecPositions.Count - 1)
									{
										num96 = vecPositions.Count - 2;
										t5 = 1f;
									}
									vector19 = Vector3.Lerp(vecPositions[num96], vecPositions[num96 + 1], t5);
								}
								if (isChild && _2vsst != 0f)
								{
									float num97 = 0f;
									float num98 = 0f;
									bool flag23 = false;
									while (!flag23)
									{
										num97 = Vector3.Distance(vector18, vecPositions[num95]);
										if (num98 + num97 > _2vsst)
										{
											vector18 = Vector3.Lerp(vector18, vecPositions[num95], (_2vsst - num98) / num97);
											flag23 = true;
										}
										else
										{
											vector18 = vecPositions[num95];
											num95++;
										}
										if (num95 >= num96)
										{
											flag23 = true;
										}
										num98 += num97;
									}
									num97 = 0f;
									num98 = 0f;
									flag23 = false;
									while (!flag23)
									{
										num97 = Vector3.Distance(vector19, vecPositions[num96]);
										if (num98 + num97 > _2vsst)
										{
											vector19 = Vector3.Lerp(vector19, vecPositions[num96], (_2vsst - num98) / num97);
											flag23 = true;
										}
										else
										{
											vector19 = vecPositions[num96];
											num96--;
										}
										if (num95 >= num96)
										{
											flag23 = true;
										}
										num98 += num97;
									}
								}
								float num99 = Vector3.Distance(vecPositions[num95], list9[num95]);
								Vector3 vector5 = (list9[num95] - list10[num95]).normalized;
								list21[num28].Add(vector18);
								list22[num28].Add(vector18 + vector5 * num99);
								num99 = Vector3.Distance(vecPositions[num95], list10[num95]);
								list23[num28].Add(vector18 + -vector5 * num99);
								list24[num28].Add(vector18);
								if (list17.Count > num95)
								{
									list25[num28].Add(list17[num95]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num100 = num95; num100 <= num96; num100++)
								{
									list21[num28].Add(vecPositions[num100]);
									list22[num28].Add(list9[num100]);
									list23[num28].Add(list10[num100]);
									list24[num28].Add(soSplinePointCenter[num100]);
									if (list17.Count > num95)
									{
										list25[num28].Add(list17[num100]);
									}
									else
									{
										list25[num28].Add(0f);
									}
								}
								num99 = Vector3.Distance(vecPositions[num96], list9[num96]);
								vector5 = (list9[num96] - list10[num96]).normalized;
								list21[num28].Add(vector19);
								list22[num28].Add(vector19 + vector5 * num99);
								num99 = Vector3.Distance(vecPositions[num96], list10[num96]);
								list23[num28].Add(vector19 + -vector5 * num99);
								list24[num28].Add(vector19);
								if (list17.Count > num96 + 1)
								{
									list25[num28].Add(list17[num96 + 1]);
								}
								else if (list25[num28].Count > 0 && list17.Count > num95)
								{
									list25[num28].Add(list25[num28][list25[num28].Count - 1]);
								}
								else
								{
									list25[num28].Add(0f);
								}
							}
							num28 = 0;
							num92 = 0;
							for (int num101 = 0; num101 < roadScr.soSectionList7.Count; num101++)
							{
								if (((roadScr.soSectionList7[num101].soid != so.id || (roadScr.baseScript.isInBuildMode && !roadScr.soSectionList7[num101].active)) && !OCDOODOQDC.IsActiveAsChild(roadScr.baseScript, roadScr.soSectionList7[num101].soid, so.id)) || (roadScr.baseScript.isInBuildMode && !roadScr.soSectionList7[num101].active))
								{
									continue;
								}
								flag19 = true;
								num38 = (uvsst = 7);
								num38 = 6;
								if (so.relativeTo != 0 && ((mirrored && so.relativeTo == 1 && roadScr.soSectionList7[num101].roadSide == ERRoadSide.Left) || (mirrored && so.relativeTo == 2 && roadScr.soSectionList7[num101].roadSide == ERRoadSide.Right) || (!mirrored && so.relativeTo == 1 && roadScr.soSectionList7[num101].roadSide == ERRoadSide.Right) || (!mirrored && so.relativeTo == 2 && roadScr.soSectionList7[num101].roadSide == ERRoadSide.Left)))
								{
									continue;
								}
								if ((num92 > 0 || list21[0].Count > 0) && (flag17 || (flag16 && list21[0].Count > 0)))
								{
									list21.Add(new List<Vector3>());
									list22.Add(new List<Vector3>());
									list23.Add(new List<Vector3>());
									list24.Add(new List<Vector3>());
									list25.Add(new List<float>());
									list26.Add(new List<List<Vector2>>());
									for (int num102 = 0; num102 < nodeList.Count; num102++)
									{
										list26[num28 + 1].Add(new List<Vector2>());
									}
									list27.Add(new List<float>());
									list28.Add(new List<float>());
									list29.Add(new List<float>());
									num21 = 0f;
									num22 = 0;
									num28 = list21.Count - 1;
								}
								num92++;
								list37.Add(num101);
								flag17 = true;
								flag16 = false;
								int num103 = roadScr.soSectionList7[num101].startSplinePoint;
								int num104 = roadScr.soSectionList7[num101].endSplinePoint;
								if (num103 < 0)
								{
									num103 = 0;
								}
								if (num103 >= vecPositions.Count)
								{
									num103 = vecPositions.Count - 1;
								}
								if (num104 >= vecPositions.Count)
								{
									num104 = vecPositions.Count - 1;
								}
								if (num103 == 0)
								{
									flag2 = true;
								}
								if (num104 == vecPositions.Count - 1)
								{
									flag3 = true;
								}
								Vector3 vector20 = vecPositions[num103];
								Vector3 vector21 = vecPositions[num104];
								if (roadScr.baseScript.activeTerrain == null)
								{
									roadScr.baseScript.OQQOQQCOOQ(vecPositions[num103]);
								}
								if (roadScr.soSectionList7[num101].startFraction != 0f)
								{
									vector20 = Vector3.Lerp(vecPositions[num103], vecPositions[num103 - 1], roadScr.soSectionList7[num101].startFraction);
								}
								if (roadScr.soSectionList7[num101].endFraction != 0f)
								{
									float t6 = roadScr.soSectionList7[num101].endFraction;
									if (num104 >= vecPositions.Count - 1)
									{
										num104 = vecPositions.Count - 2;
										t6 = 1f;
									}
									vector21 = Vector3.Lerp(vecPositions[num104], vecPositions[num104 + 1], t6);
								}
								if (isChild && _2vsst != 0f)
								{
									float num105 = 0f;
									float num106 = 0f;
									bool flag24 = false;
									while (!flag24)
									{
										num105 = Vector3.Distance(vector20, vecPositions[num103]);
										if (num106 + num105 > _2vsst)
										{
											vector20 = Vector3.Lerp(vector20, vecPositions[num103], (_2vsst - num106) / num105);
											flag24 = true;
										}
										else
										{
											vector20 = vecPositions[num103];
											num103++;
										}
										if (num103 >= num104)
										{
											flag24 = true;
										}
										num106 += num105;
									}
									num105 = 0f;
									num106 = 0f;
									flag24 = false;
									while (!flag24)
									{
										num105 = Vector3.Distance(vector21, vecPositions[num104]);
										if (num106 + num105 > _2vsst)
										{
											vector21 = Vector3.Lerp(vector21, vecPositions[num104], (_2vsst - num106) / num105);
											flag24 = true;
										}
										else
										{
											vector21 = vecPositions[num104];
											num104--;
										}
										if (num103 >= num104)
										{
											flag24 = true;
										}
										num106 += num105;
									}
								}
								float num107 = Vector3.Distance(vecPositions[num103], list9[num103]);
								Vector3 vector5 = (list9[num103] - list10[num103]).normalized;
								list21[num28].Add(vector20);
								list22[num28].Add(vector20 + vector5 * num107);
								num107 = Vector3.Distance(vecPositions[num103], list10[num103]);
								list23[num28].Add(vector20 + -vector5 * num107);
								list24[num28].Add(vector20);
								if (list17.Count > num103)
								{
									list25[num28].Add(list17[num103]);
								}
								else
								{
									list25[num28].Add(0f);
								}
								for (int num108 = num103; num108 <= num104; num108++)
								{
									list21[num28].Add(vecPositions[num108]);
									list22[num28].Add(list9[num108]);
									list23[num28].Add(list10[num108]);
									list24[num28].Add(soSplinePointCenter[num108]);
									if (list17.Count > num103)
									{
										list25[num28].Add(list17[num108]);
									}
									else
									{
										list25[num28].Add(0f);
									}
								}
								num107 = Vector3.Distance(vecPositions[num104], list9[num104]);
								vector5 = (list9[num104] - list10[num104]).normalized;
								list21[num28].Add(vector21);
								list22[num28].Add(vector21 + vector5 * num107);
								num107 = Vector3.Distance(vecPositions[num104], list10[num104]);
								list23[num28].Add(vector21 + -vector5 * num107);
								list24[num28].Add(vector21);
								if (list17.Count > num104 + 1)
								{
									list25[num28].Add(list17[num104 + 1]);
								}
								else if (list25[num28].Count > 0 && list17.Count > num103)
								{
									list25[num28].Add(list25[num28][list25[num28].Count - 1]);
								}
								else
								{
									list25[num28].Add(0f);
								}
							}
						}
						if (flag18 && flag19)
						{
							for (int num109 = 0; num109 < list21.Count; num109++)
							{
								for (int num110 = num109 + 1; num110 < list21.Count; num110++)
								{
									if (list21[num109].Count <= 1 || list21[num110].Count <= 1)
									{
										continue;
									}
									if (Vector3.Distance(list21[num109][0], list21[num110][list21[num110].Count - 1]) < 5f)
									{
										int num111 = 0;
										int count4 = list21[num109].Count;
										Vector3 pTarget2 = list22[num110][list22[num110].Count - 1];
										Vector3 pSource = list23[num110][list22[num110].Count - 1];
										for (; num111 < count4; num111++)
										{
											if (!OQQOCDQCQD.OOCQODQDQD(pTarget2, pSource, list21[num109][num111]))
											{
												list21[num109].RemoveAt(num111);
												list22[num109].RemoveAt(num111);
												list23[num109].RemoveAt(num111);
												list24[num109].RemoveAt(num111);
												list25[num109].RemoveAt(num111);
											}
										}
										list21[num110].AddRange(list21[num109]);
										list22[num110].AddRange(list22[num109]);
										list23[num110].AddRange(list23[num109]);
										list24[num110].AddRange(list24[num109]);
										list25[num110].AddRange(list25[num109]);
										list21.RemoveAt(num109);
										list22.RemoveAt(num109);
										list23.RemoveAt(num109);
										list24.RemoveAt(num109);
										list25.RemoveAt(num109);
										num109--;
										break;
									}
									if (!(Vector3.Distance(list21[num110][0], list21[num109][list21[num109].Count - 1]) < 5f))
									{
										continue;
									}
									int num112 = list21[num109].Count - 1;
									Vector3 pTarget3 = list22[num110][0];
									Vector3 pSource2 = list23[num110][0];
									for (; num112 >= 0; num112--)
									{
										if (OQQOCDQCQD.OOCQODQDQD(pTarget3, pSource2, list21[num109][num112]))
										{
											list21[num109].RemoveAt(num112);
											list22[num109].RemoveAt(num112);
											list23[num109].RemoveAt(num112);
											list24[num109].RemoveAt(num112);
											list25[num109].RemoveAt(num112);
										}
									}
									list21[num110].InsertRange(0, list21[num109]);
									list22[num110].InsertRange(0, list22[num109]);
									list23[num110].InsertRange(0, list23[num109]);
									list24[num110].InsertRange(0, list24[num109]);
									list25[num110].InsertRange(0, list25[num109]);
									list21.RemoveAt(num109);
									list22.RemoveAt(num109);
									list23.RemoveAt(num109);
									list24.RemoveAt(num109);
									list25.RemoveAt(num109);
									num109--;
									break;
								}
							}
						}
					}
					bool flag25 = false;
					bool flag26 = false;
					bool flag27 = false;
					bool flag28 = false;
					ERSnapSideObjects eRSnapSideObjects = null;
					ERSnapSideObjects eRSnapSideObjects2 = null;
					if (!roadScr.isSideObject && roadScr.startPrefabScript != null && !roadScr.startPrefabScript.isERCrossingExt && flag2 && so.relativeTo != 0 && so.continueOnConnections)
					{
						ERModularRoad road = null;
						int num113 = 0;
						if ((!mirrored && so.relativeTo == 2) || (mirrored && so.relativeTo == 1))
						{
							num113 = 1;
						}
						int side = 1;
						if (num113 == 1)
						{
							side = 0;
						}
						ERSORoadExt eRSORoadExt = null;
						int num114 = roadScr.startPrefabScript.ODCQDODCQQ(roadScr, roadScr.startConnectionSegment, ref road, num113, 0);
						if (num114 != -1)
						{
							road = roadScr.startPrefabScript.crossingElements[num114].connectedRoad;
							int num115 = -1;
							for (int num116 = 0; num116 < road.markersExt[0].soData.Count; num116++)
							{
								if (road.markersExt[0].soData[num116] != null && road.markersExt[0].soData[num116].id == so.id)
								{
									num115 = num116;
								}
							}
							if (num115 != -1)
							{
								bool flag29 = false;
								int num117 = 0;
								if (roadScr.startPrefabScript.crossingElements[num114].connectedMarker == 0 && num113 == 0)
								{
									if ((so.relativeTo == 2 && road.markersExt[0].soData.Count > num115 && road.markersExt[0].soData[num115] != null && road.markersExt[0].soData[num115].active && road.markersExt[0].soData[num115].startOffset == 0f) || road.IsSOAutoGenerated(so, 1, 0))
									{
										flag29 = true;
									}
									else if (so.relativeTo == 1 && road.markersExt[0].soData.Count > num115 && road.markersExt[0].soData[num115] != null && road.markersExt[0].soData[num115].otherSide != null && road.markersExt[0].soData[num115].otherSide.active && road.markersExt[0].soData[num115].otherSide.startOffset == 0f)
									{
										flag29 = true;
									}
								}
								else if (roadScr.startPrefabScript.crossingElements[num114].connectedMarker != 0 && num113 == 0)
								{
									num117 = 1;
									int num118 = road.markersExt.Count - 2;
									if (num118 < 0)
									{
										num118 = 0;
									}
									if ((so.relativeTo == 1 && road.markersExt[num118].soData.Count > num115 && road.markersExt[num118].soData[num115] != null && road.markersExt[num118].soData[num115].active && road.markersExt[num118].soData[num115].endOffset == 0f) || road.IsSOAutoGenerated(so, 0, 1))
									{
										flag29 = true;
									}
									else if (so.relativeTo == 2 && road.markersExt[num118].soData.Count > num115 && road.markersExt[num118].soData[num115] != null && road.markersExt[num118].soData[num115].otherSide != null && road.markersExt[num118].soData[num115].otherSide.active && road.markersExt[num118].soData[num115].otherSide.endOffset == 0f)
									{
										flag29 = true;
									}
								}
								else if (roadScr.startPrefabScript.crossingElements[num114].connectedMarker == 0 && num113 == 1)
								{
									if ((so.relativeTo == 1 && road.markersExt[0].soData.Count > num115 && road.markersExt[0].soData[num115] != null && road.markersExt[0].soData[num115].active && road.markersExt[0].soData[num115].startOffset == 0f) || road.IsSOAutoGenerated(so, 0, 0))
									{
										flag29 = true;
									}
									else if (so.relativeTo == 2 && road.markersExt[0].soData.Count > num115 && road.markersExt[0].soData[num115] != null && road.markersExt[0].soData[num115].otherSide != null && road.markersExt[0].soData[num115].otherSide.active && road.markersExt[0].soData[num115].otherSide.startOffset == 0f)
									{
										flag29 = true;
									}
								}
								else if (roadScr.startPrefabScript.crossingElements[num114].connectedMarker != 0 && num113 == 1)
								{
									num117 = 1;
									int num119 = road.markersExt.Count - 2;
									if (num119 < 0)
									{
										num119 = 0;
									}
									if ((so.relativeTo == 2 && road.markersExt[num119].soData.Count > num115 && road.markersExt[num119].soData[num115] != null && road.markersExt[num119].soData[num115].active && road.markersExt[num119].soData[num115].endOffset == 0f) || road.IsSOAutoGenerated(so, 1, 1))
									{
										flag29 = true;
									}
									else if (so.relativeTo == 1 && road.markersExt[num119].soData.Count > num115 && road.markersExt[num119].soData[num115] != null && road.markersExt[num119].soData[num115].otherSide != null && road.markersExt[num119].soData[num115].otherSide.active && road.markersExt[num119].soData[num115].otherSide.endOffset == 0f)
									{
										flag29 = true;
									}
								}
								if (flag29)
								{
									float num120 = 0f;
									if ((num113 == 0 && !mirrored && so.relativeTo == 1) || (num113 == 1 && !mirrored && so.relativeTo == 2))
									{
										num120 = roadScr.markersExt[0].soData[num3].xPosition;
									}
									else if (roadScr.markersExt[0].soData[num3].otherSide != null)
									{
										num120 = roadScr.markersExt[0].soData[num3].otherSide.xPosition;
									}
									List<Vector3> list38 = null;
									Vector3 zero = Vector3.zero;
									if (num113 == 0)
									{
										QDOODOQQDQODD.SetGlobalRightOCCDOCDDCQ(roadScr.startConnectionSegment, roadScr.startPrefabScript);
										QDOODOQQDQODD.SetGlobalLeftOCCDOCDDCQ(roadScr.startConnectionSegment, roadScr.startPrefabScript);
										QDOODOQQDQODD.SetCornerDirectionRight(roadScr.startConnectionSegment, roadScr.startPrefabScript);
										list38 = new List<Vector3>(roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].rightRoundingPointsGlobal);
										list38.Reverse();
										if (num120 != 0f)
										{
											OCDOODOQDC.OQCQCQOOCO(roadScr.startPrefabScript, roadScr.startConnectionSegment, ref list38, num120, -1f, -1f);
										}
										if (roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].rightAngle > 135f && roadScr.startPrefabScript.OQODDODODC(roadScr.startConnectionSegment, 1))
										{
											flag26 = true;
										}
										zero = roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].centerCornerDirectionRight;
										if (list38.Count > 0)
										{
											Vector3 pCheck = list38[0] + -zero * 5f;
											Vector3 pSource3 = list38[0] + zero * 5f;
											if (OQQOCDQCQD.OOCQODQDQD(list23[0][0], pSource3, pCheck))
											{
												zero *= -1f;
											}
										}
									}
									else
									{
										QDOODOQQDQODD.SetGlobalLeftOCCDOCDDCQ(roadScr.startConnectionSegment, roadScr.startPrefabScript);
										QDOODOQQDQODD.SetGlobalRightOCCDOCDDCQ(roadScr.startConnectionSegment, roadScr.startPrefabScript);
										QDOODOQQDQODD.SetCornerDirectionLeft(roadScr.startConnectionSegment, roadScr.startPrefabScript);
										list38 = new List<Vector3>(roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].leftRoundingPointsGlobal);
										list38.Reverse();
										if (num120 != 0f)
										{
											OCDOODOQDC.OQCQCQOOCO(roadScr.startPrefabScript, roadScr.startConnectionSegment, ref list38, num120, -1f, 1f);
										}
										if (roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].leftAngle > 135f && roadScr.startPrefabScript.OQODDODODC(roadScr.startConnectionSegment, 0))
										{
											flag26 = true;
										}
										zero = roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].centerCornerDirectionLeft;
										if (list38.Count > 0)
										{
											Vector3 pSource4 = list38[0] + -zero * 5f;
											Vector3 pCheck2 = list38[0] + zero * 5f;
											if (!OQQOCDQCQD.OOCQODQDQD(list22[0][0], pSource4, pCheck2))
											{
												zero *= -1f;
											}
										}
									}
									Avsss = zero;
									Vector3 normalized = (list22[0][0] - list23[0][0]).normalized;
									float num121 = Vector3.Distance(list22[0][0], vecPositions[0]);
									if (num121 == 0f)
									{
										num121 = Vector3.Distance(list23[0][0], vecPositions[0]);
										if (num121 == 0f)
										{
											num121 = 5f;
										}
									}
									Vector3 vector22 = list21[0][0];
									normalized *= -1f;
									int num122 = list21.Count - 1;
									for (int num123 = 0; num123 < list38.Count - 1; num123++)
									{
										vecPositions.Add(list38[num123]);
										list21[0].Insert(num123, list38[num123]);
										if (num123 != 0 || !flag26)
										{
											normalized = ((num123 == 0) ? (list38[num123 + 1] - list38[num123]) : (list38[num123 + 1] - list38[num123 - 1]));
											normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
											list22[0].Insert(num123, list38[num123] + -normalized * num121);
											list23[0].Insert(num123, list38[num123] + normalized * num121);
										}
										else
										{
											list22[0].Insert(num123, list38[num123] + -zero * num121);
											list23[0].Insert(num123, list38[num123] + zero * num121);
										}
									}
									flag25 = true;
									if (so.retainingWall)
									{
										if (num113 == 0)
										{
											roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].triangulateRight = false;
										}
										else
										{
											roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].triangulateLeft = false;
										}
										if (!roadScr.baseScript.connectionObjects.Contains(roadScr.startPrefabScript))
										{
											roadScr.baseScript.connectionObjects.Add(roadScr.startPrefabScript);
										}
									}
									eRSnapSideObjects = ERSnapSideObjects.ERGetSnapObject(ERRoadNetwork.snapObjects, soData, roadScr.startPrefabScript, roadScr.startConnectionSegment, side);
									if (eRSnapSideObjects == null)
									{
										eRSnapSideObjects = new ERSnapSideObjects(roadScr.startPrefabScript, roadScr.startConnectionSegment, num114, soData, ERSORoadExt.GetERSORoadExt(road.soDataExt, soData.id), null, null, new List<int>(), new List<int>(), side);
										ERRoadNetwork.snapObjects.Add(eRSnapSideObjects);
										if (num113 == 0 && num117 == 1)
										{
											eRSnapSideObjects.side2 = 1;
										}
										else if (num113 == 1 && num117 == 1)
										{
											eRSnapSideObjects.side2 = 0;
										}
										if (roadScr != road && !roadScr.baseScript.RoadObjectsSoUpdates.Contains(road))
										{
											for (int num124 = 0; num124 < road.soDataExt.Count; num124++)
											{
												if (road.soDataExt[num124].sideObject.id != so.id)
												{
													continue;
												}
												eRSnapSideObjects.road2 = road.gameObject;
												eRSnapSideObjects.el2 = num114;
												eRSnapSideObjects.soData2 = road.soDataExt[num124];
												int num125 = 0;
												if (num117 == 0)
												{
													if (num113 == 0)
													{
														eRSnapSideObjects.ints2 = road.soDataExt[num124].snapIntsStartSide2;
														eRSnapSideObjects.mesh2 = road.soDataExt[num124].snapMeshSide2;
														num125 = 1;
													}
													else
													{
														eRSnapSideObjects.ints2 = road.soDataExt[num124].snapIntsStartSide1;
														eRSnapSideObjects.mesh2 = road.soDataExt[num124].snapMeshSide1;
													}
												}
												else if (num113 == 0)
												{
													eRSnapSideObjects.ints2 = road.soDataExt[num124].snapIntsEndSide1;
													eRSnapSideObjects.mesh2 = road.soDataExt[num124].snapMeshSide1;
												}
												else
												{
													eRSnapSideObjects.ints2 = road.soDataExt[num124].snapIntsEndSide2;
													eRSnapSideObjects.mesh2 = road.soDataExt[num124].snapMeshSide2;
													num125 = 1;
												}
												if (eRSnapSideObjects.ints2 == null || eRSnapSideObjects.ints2.Count == 0 || eRSnapSideObjects.mesh2 == null)
												{
													bool mirrored2 = false;
													if ((num125 == 0 && so.relativeTo == 2) || (num125 == 1 && so.relativeTo == 1))
													{
														mirrored2 = true;
													}
													ERRoadNetwork.soRoadUpdate.Add(new ERSORoadUpdate(road, road.soDataExt[num124], mirrored2));
												}
											}
										}
									}
								}
							}
						}
					}
					if (!roadScr.isSideObject && roadScr.endPrefabScript != null && !roadScr.endPrefabScript.isERCrossingExt && flag3 && so.relativeTo != 0 && so.continueOnConnections)
					{
						ERModularRoad road2 = null;
						int num126 = 0;
						if ((mirrored && so.relativeTo == 1) || (!mirrored && so.relativeTo == 2))
						{
							num126 = 1;
						}
						int side2 = 0;
						if (num126 == 1)
						{
							side2 = 1;
						}
						int num127 = roadScr.endPrefabScript.ODCQDODCQQ(roadScr, roadScr.endConnectionSegment, ref road2, num126, 1);
						if (num127 != -1)
						{
							road2 = roadScr.endPrefabScript.crossingElements[num127].connectedRoad;
							int num128 = -1;
							for (int num129 = 0; num129 < road2.markersExt[0].soData.Count; num129++)
							{
								if (road2.markersExt[0].soData[num129] != null && road2.markersExt[0].soData[num129].id == so.id)
								{
									num128 = num129;
								}
							}
							if (num128 != -1)
							{
								bool flag30 = false;
								int num130 = 0;
								if (roadScr.endPrefabScript.crossingElements[num127].connectedMarker == 0 && num126 == 1)
								{
									if ((so.relativeTo == 1 && road2.markersExt[0].soData.Count > num128 && road2.markersExt[0].soData[num128] != null && road2.markersExt[0].soData[num128].otherSide != null && road2.markersExt[0].soData[num128].otherSide.active && road2.markersExt[0].soData[num128].otherSide.startOffset == 0f) || road2.IsSOAutoGenerated(so, 1, 0))
									{
										flag30 = true;
									}
									else if (so.relativeTo == 2 && road2.markersExt[0].soData.Count > num128 && road2.markersExt[0].soData[num128] != null && road2.markersExt[0].soData[num128].active && road2.markersExt[0].soData[num128].startOffset == 0f)
									{
										flag30 = true;
									}
								}
								else if (roadScr.endPrefabScript.crossingElements[num127].connectedMarker != 0 && num126 == 1)
								{
									int num131 = road2.markersExt.Count - 2;
									if (num131 < 0)
									{
										num131 = 0;
									}
									num130 = 1;
									if ((so.relativeTo == 1 && road2.markersExt[num131].soData.Count > num128 && road2.markersExt[num131].soData[num128] != null && road2.markersExt[num131].soData[num128].active && road2.markersExt[num131].soData[num128].startOffset == 0f) || road2.IsSOAutoGenerated(so, 0, 1))
									{
										flag30 = true;
									}
									else if (so.relativeTo == 2 && road2.markersExt[num131].soData.Count > num128 && road2.markersExt[num131].soData[num128] != null && road2.markersExt[num131].soData[num128].otherSide != null && road2.markersExt[num131].soData[num128].otherSide.active && road2.markersExt[num131].soData[num128].otherSide.startOffset == 0f)
									{
										flag30 = true;
									}
								}
								else if (roadScr.endPrefabScript.crossingElements[num127].connectedMarker == 0 && num126 == 0)
								{
									if ((so.relativeTo == 1 && road2.markersExt[0].soData.Count > num128 && road2.markersExt[0].soData[num128] != null && road2.markersExt[0].soData[num128].active && road2.markersExt[0].soData[num128].startOffset == 0f) || road2.IsSOAutoGenerated(so, 0, 0))
									{
										flag30 = true;
									}
									else if (so.relativeTo == 2 && road2.markersExt[0].soData.Count > num128 && road2.markersExt[0].soData[num128] != null && road2.markersExt[0].soData[num128].otherSide != null && road2.markersExt[0].soData[num128].otherSide.active && road2.markersExt[0].soData[num128].otherSide.startOffset == 0f)
									{
										flag30 = true;
									}
								}
								else if (roadScr.endPrefabScript.crossingElements[num127].connectedMarker != 0 && num126 == 0)
								{
									int num132 = road2.markersExt.Count - 2;
									if (num132 < 0)
									{
										num132 = 0;
									}
									num130 = 1;
									if ((so.relativeTo == 2 && road2.markersExt[num132].soData.Count > num128 && road2.markersExt[num132].soData[num128] != null && road2.markersExt[num132].soData[num128].active && road2.markersExt[num132].soData[num128].startOffset == 0f) || road2.IsSOAutoGenerated(so, 1, 1))
									{
										flag30 = true;
									}
									else if (so.relativeTo == 1 && road2.markersExt[num132].soData.Count > num128 && road2.markersExt[num132].soData[num128] != null && road2.markersExt[num132].soData[num128].otherSide != null && road2.markersExt[num132].soData[num128].otherSide.active && road2.markersExt[num132].soData[num128].otherSide.startOffset == 0f)
									{
										flag30 = true;
									}
								}
								if (flag30)
								{
									float num133 = 0f;
									int index2 = roadScr.markersExt.Count - 1;
									if (roadScr.markersExt[index2].soData != null)
									{
										for (int num134 = 0; num134 < roadScr.markersExt[index2].soData.Count; num134++)
										{
											if (roadScr.markersExt[index2].soData[num134] != null && roadScr.markersExt[index2].soData[num134].id == so.id)
											{
												if ((num126 == 0 && !mirrored && so.relativeTo == 1) || (num126 == 1 && !mirrored && so.relativeTo == 2))
												{
													num133 = roadScr.markersExt[index2].soData[num134].xPosition;
												}
												else if (roadScr.markersExt[index2].soData[num134].otherSide != null)
												{
													num133 = roadScr.markersExt[index2].soData[num134].otherSide.xPosition;
												}
											}
										}
									}
									int index3 = list21.Count - 1;
									Vector3 zero2 = Vector3.zero;
									List<Vector3> list39 = null;
									if (num126 == 0)
									{
										QDOODOQQDQODD.SetGlobalLeftOCCDOCDDCQ(roadScr.endConnectionSegment, roadScr.endPrefabScript);
										QDOODOQQDQODD.SetGlobalRightOCCDOCDDCQ(roadScr.endConnectionSegment, roadScr.endPrefabScript);
										QDOODOQQDQODD.SetCornerDirectionLeft(roadScr.endConnectionSegment, roadScr.endPrefabScript);
										list39 = new List<Vector3>(roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].leftRoundingPointsGlobal);
										if (num133 != 0f)
										{
											OCDOODOQDC.OQCQCQOOCO(roadScr.endPrefabScript, roadScr.endConnectionSegment, ref list39, num133, 1f, -1f);
										}
										if (roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].leftAngle > 135f && roadScr.endPrefabScript.OQODDODODC(roadScr.endConnectionSegment, 0))
										{
											flag28 = true;
										}
										zero2 = roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].centerCornerDirectionLeft;
										if (list39.Count > 0)
										{
											Vector3 pSource5 = list39[list39.Count - 1] + -zero2 * 5f;
											Vector3 pCheck3 = list39[list39.Count - 1] + zero2 * 5f;
											if (OQQOCDQCQD.OOCQODQDQD(list22[index3][list22[index3].Count - 1], pSource5, pCheck3))
											{
												zero2 *= -1f;
											}
										}
									}
									else
									{
										QDOODOQQDQODD.SetGlobalRightOCCDOCDDCQ(roadScr.endConnectionSegment, roadScr.endPrefabScript);
										QDOODOQQDQODD.SetGlobalLeftOCCDOCDDCQ(roadScr.endConnectionSegment, roadScr.endPrefabScript);
										QDOODOQQDQODD.SetCornerDirectionRight(roadScr.endConnectionSegment, roadScr.endPrefabScript);
										list39 = new List<Vector3>(roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].rightRoundingPointsGlobal);
										if (num133 != 0f)
										{
											OCDOODOQDC.OQCQCQOOCO(roadScr.endPrefabScript, roadScr.endConnectionSegment, ref list39, num133, 1f, 1f);
										}
										if (roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].rightAngle > 135f && roadScr.endPrefabScript.OQODDODODC(roadScr.endConnectionSegment, 1))
										{
											flag28 = true;
										}
										zero2 = roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].centerCornerDirectionRight;
										if (list39.Count > 0)
										{
											Vector3 pCheck4 = list39[list39.Count - 1] + -zero2 * 5f;
											Vector3 pSource6 = list39[list39.Count - 1] + zero2 * 5f;
											if (!OQQOCDQCQD.OOCQODQDQD(list23[index3][list23[index3].Count - 1], pSource6, pCheck4))
											{
												zero2 *= -1f;
											}
										}
									}
									_0vsst = zero2;
									Vector3 normalized2 = (list22[index3][list22[index3].Count - 1] - list23[index3][list22[index3].Count - 1]).normalized;
									float num135 = Vector3.Distance(list22[index3][list22[index3].Count - 1], vecPositions[vecPositions.Count - 1]);
									if (num135 == 0f)
									{
										num135 = (num135 = Vector3.Distance(list23[index3][list23[index3].Count - 1], vecPositions[vecPositions.Count - 1]));
										if (num135 == 0f)
										{
											num135 = 5f;
										}
									}
									normalized2 *= -1f;
									int count5 = list39.Count;
									for (int num136 = 1; num136 < count5; num136++)
									{
										Vector3 vector23 = roadScr.endPrefabScript.transform.TransformPoint(list39[num136]);
										vecPositions.Add(list39[num136]);
										list21[index3].Add(list39[num136]);
										if (num136 < count5 - 1 || !flag28)
										{
											normalized2 = ((num136 >= count5 - 1) ? (list39[num136] - list39[num136 - 1]) : (list39[num136 + 1] - list39[num136 - 1]));
											normalized2 = new Vector3(normalized2.z, 0f, 0f - normalized2.x).normalized;
											list22[index3].Add(list39[num136] + -normalized2 * num135);
											list23[index3].Add(list39[num136] + normalized2 * num135);
										}
										else
										{
											list22[index3].Add(list39[num136] + -zero2 * num135);
											list23[index3].Add(list39[num136] + zero2 * num135);
										}
									}
									flag27 = true;
									if (so.retainingWall)
									{
										if (num126 == 0)
										{
											roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].triangulateLeft = false;
										}
										else
										{
											roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].triangulateRight = false;
										}
										if (!roadScr.baseScript.connectionObjects.Contains(roadScr.endPrefabScript))
										{
											roadScr.baseScript.connectionObjects.Add(roadScr.endPrefabScript);
										}
									}
									eRSnapSideObjects2 = ERSnapSideObjects.ERGetSnapObject(ERRoadNetwork.snapObjects, soData, roadScr.endPrefabScript, roadScr.endConnectionSegment, side2);
									if (eRSnapSideObjects2 == null)
									{
										eRSnapSideObjects2 = new ERSnapSideObjects(roadScr.endPrefabScript, roadScr.endConnectionSegment, num127, soData, ERSORoadExt.GetERSORoadExt(road2.soDataExt, soData.id), null, null, new List<int>(), new List<int>(), side2);
										ERRoadNetwork.snapObjects.Add(eRSnapSideObjects2);
										if (num126 == 0 && num130 == 0)
										{
											eRSnapSideObjects2.side2 = 1;
										}
										else if (num126 == 1 && num130 == 0)
										{
											eRSnapSideObjects2.side2 = 0;
										}
										if (!roadScr.baseScript.RoadObjectsSoUpdates.Contains(road2))
										{
											for (int num137 = 0; num137 < road2.soDataExt.Count; num137++)
											{
												if (road2.soDataExt[num137].sideObject.id != so.id)
												{
													continue;
												}
												eRSnapSideObjects2.road2 = road2.gameObject;
												eRSnapSideObjects2.el2 = num127;
												eRSnapSideObjects2.soData2 = road2.soDataExt[num137];
												int num138 = 0;
												if (num130 == 0)
												{
													if (num126 == 0)
													{
														eRSnapSideObjects2.ints2 = road2.soDataExt[num137].snapIntsStartSide1;
														eRSnapSideObjects2.mesh2 = road2.soDataExt[num137].snapMeshSide1;
													}
													else
													{
														eRSnapSideObjects2.ints2 = road2.soDataExt[num137].snapIntsStartSide2;
														eRSnapSideObjects2.mesh2 = road2.soDataExt[num137].snapMeshSide2;
														num138 = 1;
													}
												}
												else if (num126 == 0)
												{
													eRSnapSideObjects2.ints2 = road2.soDataExt[num137].snapIntsEndSide2;
													eRSnapSideObjects2.mesh2 = road2.soDataExt[num137].snapMeshSide2;
													num138 = 1;
												}
												else
												{
													eRSnapSideObjects2.ints2 = road2.soDataExt[num137].snapIntsEndSide1;
													eRSnapSideObjects2.mesh2 = road2.soDataExt[num137].snapMeshSide1;
												}
												if (eRSnapSideObjects2.ints2 == null || eRSnapSideObjects2.mesh2 == null)
												{
													bool mirrored3 = false;
													if ((num138 == 0 && so.relativeTo == 2) || (num138 == 1 && so.relativeTo == 1))
													{
														mirrored3 = true;
													}
													ERRoadNetwork.soRoadUpdate.Add(new ERSORoadUpdate(road2, road2.soDataExt[num137], mirrored3));
												}
											}
										}
									}
								}
							}
						}
					}
					if (so.snapToTerrain)
					{
						for (int num139 = 0; num139 < vecPositions.Count; num139++)
						{
							Vector3 v2 = vecPositions[num139];
							v2.y = OQQOCDQCQD.OQDODCCCCQ(v2, roadScr.baseScript);
							vecPositions[num139] = v2;
						}
					}
					for (int num140 = 0; num140 < roadScr.soDataExt.Count; num140++)
					{
						if (roadScr.soDataExt[num140].id == so.id)
						{
							roadScr.soDataExt[num140].vecPositions = new List<Vector3>(vecPositions);
						}
					}
					bool flag31 = true;
					bool flag32 = true;
					if (roadScr.closedTrack && flag7 && flag8)
					{
						flag31 = false;
						flag32 = false;
					}
					else
					{
						if (flag25 && flag26)
						{
							flag31 = false;
						}
						if (flag27 && flag28)
						{
							flag32 = false;
						}
					}
					if (so.objectType == 0 && so.bridgeObject)
					{
						flag32 = false;
					}
					if (soData.yPosition != 0f)
					{
						for (int num141 = 0; num141 < list21.Count; num141++)
						{
							for (int num142 = 0; num142 < list21[num141].Count; num142++)
							{
								Vector3 v2 = list21[num141][num142];
								v2.y += soData.yPosition;
								list21[num141][num142] = v2;
							}
						}
					}
					List<float> list40 = new List<float>();
					List<List<float>> list41 = new List<List<float>>();
					List<float> list42 = new List<float>();
					float num143 = 0f;
					List<int> list43 = new List<int>();
					if (mirrored && so.objectType == 2)
					{
						for (int num144 = 0; num144 < so.meshObjects.Count; num144++)
						{
							if (so.meshObjects[num144].triangles2.Count == 0)
							{
								so.meshObjects[num144].OQDCDCQOOD();
							}
						}
					}
					for (int num145 = 0; num145 < list21.Count; num145++)
					{
						if (list21[num145].Count == 0)
						{
							list21.RemoveAt(num145);
							list22.RemoveAt(num145);
							list23.RemoveAt(num145);
							soSplinePointCenter.RemoveAt(num145);
							list17.RemoveAt(num145);
							list26.RemoveAt(num145);
							if (list30.Count > num145)
							{
								list30.RemoveAt(num145);
							}
							num145--;
							continue;
						}
						list6.Add(0f);
						list7.Add(0f);
						float num146 = 0f;
						num143 = 0f;
						float num147 = 0f;
						Vector3 position = roadScr.markersExt[0].position;
						Vector3 zero3 = Vector3.zero;
						Vector3 vector24 = new Vector3(-1000000f, 0f, -1000000f);
						list41.Add(new List<float>());
						list41[num145].Add(0f);
						if (so.objectType != 0 || !so.relativeToCenter)
						{
							for (int num148 = 1; num148 < list21[num145].Count; num148++)
							{
								num143 += Vector3.Distance(list21[num145][num148 - 1], list21[num145][num148]);
								list41[num145].Add(num143);
							}
						}
						else
						{
							for (int num149 = 1; num149 < list24[num145].Count; num149++)
							{
								num143 += Vector3.Distance(list24[num145][num149 - 1], list24[num145][num149]);
								list41[num145].Add(num143);
							}
						}
						if (list21[num145].Count < 2)
						{
							list42.Add(0f);
							continue;
						}
						Vector3 normalized3 = (list21[num145][list21[num145].Count - 1] - list21[num145][list21[num145].Count - 2]).normalized;
						if (normalized3 == Vector3.zero)
						{
							normalized3 = (list21[num145][list21[num145].Count - 1] - list21[num145][list21[num145].Count - 3]).normalized;
						}
						zero3 = list21[num145][list21[num145].Count - 1] + 100f * normalized3;
						list21[num145].Add(zero3);
						zero3 = list22[num145][list22[num145].Count - 1] + 100f * normalized3;
						list22[num145].Add(zero3);
						zero3 = list23[num145][list23[num145].Count - 1] + 100f * normalized3;
						list23[num145].Add(zero3);
						zero3 = list24[num145][list24[num145].Count - 1] + 100f * normalized3;
						list24[num145].Add(zero3);
						if (so.objectType != 0 || !so.relativeToCenter)
						{
							list41[num145].Add(num143 + Vector3.Distance(list21[num145][list21[num145].Count - 2], list21[num145][list21[num145].Count - 1]));
						}
						else
						{
							list41[num145].Add(num143 + Vector3.Distance(list24[num145][list24[num145].Count - 2], list24[num145][list24[num145].Count - 1]));
						}
						list42.Add(num143);
					}
					if (go == null)
					{
						return;
					}
					for (int num150 = 0; num150 < so.meshObjects.Count; num150++)
					{
						so.meshObjects[num150].Clear();
					}
					so.instantiatedObjects.Clear();
					so.SetMaxVertices();
					float halfRoadWidth = 0.5f * roadScr.roadWidth;
					bool flag33 = true;
					Vector3 forward = Vector3.zero;
					Vector3 startPos = Vector3.zero;
					float clampUVYPerc = 1f;
					go.GetComponent<ERSideObjectInstance>().startEndPositions.Clear();
					go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Clear();
					bool rotateFlag = false;
					uusst = 0f;
					string text = "";
					if (so.relativeTo > 0)
					{
						text = ((!(so.relativeTo == 1 && mirrored) && (so.relativeTo != 2 || mirrored)) ? " - Left" : " - Right");
					}
					if (list42.Count == 0)
					{
						return;
					}
					for (int num151 = 0; num151 < list21.Count; num151++)
					{
						if (list21[num151].Count <= 1)
						{
							continue;
						}
						if (num151 > 0 && so.objectType > 0 && (!so.combine || num38 != -1))
						{
							CheckVertexLimit(so, 1, force: true);
						}
						bool flag34 = false;
						bool flag35 = false;
						if (num151 == 0 && flag7 && flag8 && roadScr.closedTrack)
						{
							flag34 = true;
						}
						if (num151 == list21.Count - 1 && flag7 && flag8 && roadScr.closedTrack)
						{
							flag35 = true;
						}
						num143 = list42[num151];
						vecPositions = list21[num151];
						list15 = list22[num151];
						list16 = list23[num151];
						soSplinePointCenter = list24[num151];
						list17 = list25[num151];
						nodeList = list26[num151];
						if (list30.Count > num151)
						{
							list43 = list30[num151];
						}
						tvsss = num151;
						if (so.tunnelObject)
						{
							if (soData.autoGenerate && roadScr.soSectionList1.Count > num151)
							{
								Vector3 startPosition = roadScr.soSectionList1[num151].startPosition;
								Vector3 vector25 = roadScr.soSplinePoints[roadScr.soSectionList1[num151].startSplinePoint];
								Vector3 vector26 = roadScr.soSplinePoints[roadScr.soSectionList1[num151].endSplinePoint];
								Vector3 endPosition = roadScr.soSectionList1[num151].endPosition;
								if (so.cutHoles && Terrain.activeTerrain != null)
								{
									OODCDDQOQC.ODDCOQCCCD(roadScr, go.GetComponent<ERSideObjectInstance>().transform, startPosition, vector25, so.x1, so.x2, so.y1, Terrain.activeTerrain.terrainData.heightmapScale, so.scale);
									OODCDDQOQC.ODDCOQCCCD(roadScr, go.GetComponent<ERSideObjectInstance>().transform, endPosition, vector26, so.x1, so.x2, so.y1, Terrain.activeTerrain.terrainData.heightmapScale, so.scale);
								}
								go.GetComponent<ERSideObjectInstance>().startEndPositions.Add(startPosition);
								go.GetComponent<ERSideObjectInstance>().startEndPositions.Add(vector25);
								go.GetComponent<ERSideObjectInstance>().startEndPositions.Add(vector26);
								go.GetComponent<ERSideObjectInstance>().startEndPositions.Add(endPosition);
								go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Add(vecPositions[0]);
								go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Add(vecPositions[1]);
								go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Add(vecPositions[vecPositions.Count - 2]);
								go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Add(vecPositions[vecPositions.Count - 3]);
							}
							else
							{
								if (so.cutHoles && Terrain.activeTerrain != null)
								{
									OODCDDQOQC.ODDCOQCCCD(roadScr, go.GetComponent<ERSideObjectInstance>().transform, vecPositions[0], vecPositions[1], so.x1, so.x2, so.y1, Terrain.activeTerrain.terrainData.heightmapScale, so.scale);
									OODCDDQOQC.ODDCOQCCCD(roadScr, go.GetComponent<ERSideObjectInstance>().transform, vecPositions[vecPositions.Count - 2], vecPositions[vecPositions.Count - 1], so.x1, so.x2, so.y1, Terrain.activeTerrain.terrainData.heightmapScale, so.scale);
								}
								go.GetComponent<ERSideObjectInstance>().startEndPositions.Add(vecPositions[0]);
								go.GetComponent<ERSideObjectInstance>().startEndPositions.Add(vecPositions[1]);
								go.GetComponent<ERSideObjectInstance>().startEndPositions.Add(vecPositions[vecPositions.Count - 2]);
								go.GetComponent<ERSideObjectInstance>().startEndPositions.Add(vecPositions[vecPositions.Count - 1]);
								go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Add(vecPositions[0]);
								go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Add(vecPositions[1]);
								go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Add(vecPositions[vecPositions.Count - 2]);
								go.GetComponent<ERSideObjectInstance>().startEndMeshPositions.Add(vecPositions[vecPositions.Count - 3]);
							}
						}
						list40 = list41[num151];
						float num152 = 0f;
						float num153 = 0f;
						for (int num154 = 0; num154 < so.nodeList.Count - 1; num154++)
						{
							num153 += Vector2.Distance(so.nodeList[num154], so.nodeList[num154 + 1]);
						}
						num152 = 1f / num153;
						if (so.clampUVY && so.objectType == 1)
						{
							if (vecPositions.Count <= 1)
							{
								return;
							}
							float num155 = list40[list40.Count - 2] * so.uvy * num152;
							clampUVYPerc = (Mathf.Round(num155) - (1f - so.clampUVYValue)) / num155;
						}
						if (so.objectType < 2)
						{
							so.middleZDistance = so.m_distance;
							if (so.objectType == 0)
							{
								if (soData.m_distance == 0f)
								{
									soData.m_distance = so.m_distance;
								}
								so.middleZDistance = soData.m_distance;
							}
						}
						if (so.middleZDistance == 0f)
						{
							so.middleZDistance = 1f;
						}
						float num156 = num143;
						if (num151 == 0 && flag31 && so.includeStartSegment && so.startZDistance != 2000f)
						{
							num156 -= (so.startZDistance - so.startOverlapOffset) * so.scale.z;
						}
						else if (num151 != 0 && so.includeStartSegment && so.startZDistance != 2000f && !flag25)
						{
							num156 -= (so.startZDistance - so.startOverlapOffset) * so.scale.z;
						}
						if (num151 == list21.Count - 1 && flag32 && so.includeEndSegment && so.endZDistance != -2000f)
						{
							num156 -= (so.endZDistance - so.endOverlapOffset) * so.scale.z;
						}
						else if (num151 != list21.Count - 1 && so.includeEndSegment && so.endZDistance != -2000f && !flag27)
						{
							num156 -= (so.endZDistance - so.endOverlapOffset) * so.scale.z;
						}
						float num157 = 0.005f;
						if (so.segmentOffset != 0f)
						{
							num157 = so.segmentOffset;
						}
						if (so.objectType == 2 && so.namedChilds)
						{
							num157 = 0.01f;
						}
						bool flag36 = false;
						float num158 = so.middleZDistance * so.scale.z;
						if ((double)num158 < 0.5)
						{
							num157 = so.middleZDistance * so.scale.z * 0.05f;
							flag36 = true;
						}
						if (so.endZDistance > 0f)
						{
							num158 = so.endZDistance * so.scale.z;
						}
						float num159 = 0.1f;
						if (num158 < 1f)
						{
							num159 = num158;
							num158 *= 0.9f;
						}
						else
						{
							num158 = 1f;
						}
						if (so.objectType != 2)
						{
							num158 = 0f;
						}
						float num160 = so.middleZDistance * so.scale.z * 4f;
						if (num160 > 0.1f)
						{
							num160 = 0.1f;
						}
						float num161 = Mathf.Round(num156 / (so.middleZDistance * so.scale.z));
						if (num161 == 0f)
						{
							num161 = 1f;
						}
						float num162 = (num156 + num157 * num161) / (num161 * (so.middleZDistance * so.scale.z));
						if (!so.averageDistance && so.objectType == 0)
						{
							num162 = 1f;
						}
						if (so.objectType == 0 && so.bridgeObject)
						{
							num162 = 1f;
						}
						if (so.objectType == 1 || so.tunnelObject)
						{
							Terrain[] array = UnityEngine.Object.FindObjectsOfType(typeof(Terrain)) as Terrain[];
							Terrain terrain = OQQOQQCOOQ(vecPositions[0]);
							if (terrain != null)
							{
								Vector3 vector27 = (_2usst.min = new Vector3(terrain.transform.position.x, 0f, terrain.transform.position.z));
								vector27.x += terrain.terrainData.size.x;
								vector27.z += terrain.terrainData.size.z;
								_2usst.max = vector27;
								vector27.x = terrain.terrainData.size.x;
								vector27.z = terrain.terrainData.size.z;
								_2usst.size = vector27;
							}
							else if (!yvsst)
							{
								Debug.LogWarning("EasyRoads3Dv3 Warning: No terrain object in scene. Side object '" + so.name + "' requires a terrain object");
								yvsst = true;
							}
						}
						float num163 = 0f;
						float num164 = -1f;
						float num165 = 0f;
						float num166 = 0f;
						int num167 = 1;
						int num168 = 0;
						int num169 = 0;
						bool flag37 = false;
						int currentVecArrayInt = 0;
						int num170 = 0;
						int num171 = 0;
						int num172 = 1;
						int num173 = 0;
						bool skipStartBlend = false;
						bool skipEndBlend = false;
						if (num151 == 0 && !flag31)
						{
							skipStartBlend = true;
						}
						if (num151 == list21.Count - 1 && !flag32)
						{
							skipEndBlend = true;
						}
						if (num151 == list21.Count - 1)
						{
							lastvecPositionsArray = true;
							if (!flag32)
							{
								skipEndBlend = true;
							}
						}
						flag33 = true;
						xssss = 0f;
						yssst = 0f;
						Assss = 0f;
						_0ssst = 0f;
						_1ssss = Vector3.zero;
						_3ssss = 0.25f;
						_4ssst = 0f;
						ttsss = 0f;
						utsst = 0f;
						vtsss = 0f;
						wtsst = Vector3.zero;
						xtsss = Vector3.zero;
						ytsst = 0.25f;
						Atsss = 0f;
						_0tsst = 0f;
						_1tsss = 0f;
						_2tsst = 0f;
						_3tsss = Vector3.zero;
						_4tsst = Vector3.zero;
						tusss = 0.25f;
						vusss = 0f;
						wusst = 0f;
						xusss = 0f;
						yusst = 0f;
						Ausss = Vector3.zero;
						_0usst = Vector3.zero;
						if (so.objectType == 1 && so.deformationObject)
						{
							_3usss = so.easeInOutDistanceTerrainSnap;
							_4usst = num143 - so.easeInOutDistanceTerrainSnap;
							if (so.easeInOutDistanceTerrainSnap > 0.5f * num143)
							{
								_3usss = (_4usst = 0.5f * num143);
							}
						}
						if (soData.clampToMarkers && list43.Count > 0)
						{
							num161 = Mathf.Round(roadScr.markersExt[0].totalDistance / (so.middleZDistance * so.scale.z));
							if (num161 == 0f)
							{
								num161 = 1f;
							}
							num162 = roadScr.markersExt[0].totalDistance / (num161 * so.middleZDistance * so.scale.z);
						}
						List<Vector3> dualSidedEdgeVertices = null;
						if (so.objectType == 1 && so.triangulateDualSided && list32.Count > 0 && list32.Count == list33.Count)
						{
							if (!mirrored)
							{
								soData.mainTriangulateVecs.Add(new List<Vector3>());
								dualSidedEdgeVertices = soData.mainTriangulateVecs[soData.mainTriangulateVecs.Count - 1];
								soData.startSplinePointIndexes.Add(list32[num151]);
								soData.endSplinePointIndexes.Add(list33[num151]);
							}
							else
							{
								soData.mirroredTriangulateVecs.Add(new List<Vector3>());
								dualSidedEdgeVertices = soData.mirroredTriangulateVecs[soData.mirroredTriangulateVecs.Count - 1];
								soData.startSplinePointIndexesMirrored.Add(list32[num151]);
								soData.endSplinePointIndexesMirrored.Add(list33[num151]);
							}
						}
						int num174 = 0;
						float steppedHeight = vecPositions[0].y;
						xvsss = false;
						float num175 = 0f;
						float num176 = roadScr.markersExt[0].totalDistance - 0.1f;
						int lastStep = 0;
						GameObject gameObject = go;
						if (num38 >= 0 && so.objectType == 0)
						{
							gameObject = new GameObject("Section " + num151 + text);
							if (!Application.isPlaying)
							{
								gameObject.transform.parent = go.transform;
							}
						}
						if (so.randomUVx)
						{
							uusst = UnityEngine.Random.value * 0.5f;
						}
						bool shapeDirFlag = false;
						wvsst = true;
						if (num38 > 0 && num151 - num37 >= 0 && !ERMesh.OQQQOQODOO(roadScr, num38, list37[num151 - num37], so, mirrored))
						{
							wvsst = false;
						}
						_1vsss = list21[0][0].y;
						_1vsss = 0f;
						if (num151 == 0 || num151 == list21.Count - 1)
						{
						}
						bool flag38 = false;
						if (!so.includeEndSegment || !flag32)
						{
							flag38 = true;
						}
						if (flag36)
						{
							num143 += 0.5f * so.middleZDistance * num162 * so.scale.z;
						}
						int num177 = 0;
						if (num143 == 0f)
						{
							continue;
						}
						int num178 = 0;
						Vector3 zero4 = Vector3.zero;
						Vector3 zero5 = Vector3.zero;
						int num179 = 0;
						while (num163 + num158 < num143 || (so.objectType == 2 && flag32 && !flag38))
						{
							if (so.objectType == 2 && num163 + num159 >= num143 && flag32)
							{
								flag37 = true;
							}
							else if (so.objectType == 0 && num163 + soData.m_distance * num162 >= num143)
							{
								flag37 = true;
							}
							if (flag37 && so.objectType == 2)
							{
								if (flag36)
								{
									num163 -= so.middleZDistance * num162 * so.scale.z;
								}
								num177++;
								if (num177 >= 2)
								{
									break;
								}
							}
							if (num163 == num164 && num169 > 1)
							{
								return;
							}
							num164 = num163;
							if (num169 > 5 && num163 < num160)
							{
								Debug.LogError("EasyRoads3Dv3 Error: unable to create side object: " + so.name + " error: 5214 - please report");
								return;
							}
							shapeDirFlag = false;
							if (num163 < 0f)
							{
								string message = "EasyRoads3Dv3: " + so.name + " - unable to generate side object, please check the side object settings in the Side Object Manager";
								if (so.objectType == 2)
								{
									message = "EasyRoads3Dv3: " + so.name + " - unable to generate side object, please check the side object settings in the Side Object Manager. Is Read/Write enabled for the Source Prefab in the project settings?";
								}
								Debug.LogError(message);
								return;
							}
							num170++;
							num174++;
							if (soData.clampToMarkers && list43.Count > num173 && (num163 >= num176 || (float)num174 == num161 + 1f))
							{
								currentVecArrayInt = list43[num173];
								num173++;
								num161 = Mathf.Round(roadScr.markersExt[num173].totalDistance / (so.middleZDistance * so.scale.z));
								if (num161 == 0f)
								{
									num161 = 1f;
								}
								num162 = roadScr.markersExt[num173].totalDistance / (num161 * so.middleZDistance * so.scale.z);
								num175 += roadScr.markersExt[num173 - 1].totalDistance;
								num176 += roadScr.markersExt[num173].totalDistance;
								num163 = num175;
								num174 = 1;
								if (roadScr.isSideObject)
								{
									shapeDirFlag = true;
								}
							}
							if (num163 >= utsst)
							{
								ttsss = (utsst = num163);
								float num180 = UnityEngine.Random.Range(soData.minRandomXPositionDistance, soData.maxRandomXPositionDistance);
								if (num180 < 3f * so.middleZDistance)
								{
									num180 = 3f * so.middleZDistance;
								}
								_4ssst = 0.5f * num180;
								utsst += num180;
								vtsss = Mathf.Lerp(ttsss, utsst, 0.5f);
								if (!mirrored)
								{
									wtsst.x = UnityEngine.Random.Range(soData.randomMinXPosition, soData.randomMaxXPosition);
								}
								else
								{
									wtsst.x = UnityEngine.Random.Range(0f - soData.randomMaxXPosition, 0f - soData.randomMinXPosition);
								}
								if (utsst > num143)
								{
									utsst = num143;
									if (utsst - ttsss < 3f * so.middleZDistance)
									{
										wtsst.x = 0f;
									}
								}
								if (vtsss > num143)
								{
									vtsss = num143;
									if (vtsss - ttsss < 2f * so.middleZDistance)
									{
										wtsst.x = 0f;
									}
								}
							}
							if (wtsst.x != 0f)
							{
								if (num163 < vtsss)
								{
									float t7 = (num163 - vtsss) / (vtsss - ttsss);
									xtsss.x = Mathf.Lerp(0f, wtsst.x, Mathf.SmoothStep(0f, 1f, t7));
								}
								else
								{
									float t8 = (num163 - vtsss) / (utsst - vtsss);
									xtsss.x = Mathf.Lerp(wtsst.x, 0f, Mathf.SmoothStep(0f, 1f, t8));
								}
							}
							if (num163 >= _1tsss)
							{
								_0tsst = (_1tsss = num163);
								float num181 = UnityEngine.Random.Range(soData.minRandomYPositionDistance, soData.maxRandomYPositionDistance);
								if (num181 < 3f * so.middleZDistance)
								{
									num181 = 3f * so.middleZDistance;
								}
								Atsss = 0.5f * num181;
								_1tsss += num181;
								_2tsst = Mathf.Lerp(_0tsst, _1tsss, 0.5f);
								_3tsss.x = UnityEngine.Random.Range(soData.randomMinYPosition, soData.randomMaxYPosition);
								if (_1tsss > num143)
								{
									_1tsss = num143;
									if (_1tsss - _0tsst < 3f * so.middleZDistance)
									{
										_3tsss.x = 0f;
									}
								}
								if (_2tsst > num143)
								{
									_2tsst = num143;
									if (_2tsst - _0tsst < 2f * so.middleZDistance)
									{
										_3tsss.x = 0f;
									}
								}
							}
							if (_3tsss.x != 0f)
							{
								if (num163 < _2tsst)
								{
									float t9 = (num163 - _2tsst) / (_2tsst - _0tsst);
									_4tsst.x = Mathf.Lerp(0f, _3tsss.x, Mathf.SmoothStep(0f, 1f, t9));
								}
								else
								{
									float t10 = (num163 - _2tsst) / (_1tsss - _2tsst);
									_4tsst.x = Mathf.Lerp(_3tsss.x, 0f, Mathf.SmoothStep(0f, 1f, t10));
								}
							}
							if (num163 >= Assss)
							{
								yssst = (Assss = num163);
								float num182 = UnityEngine.Random.Range(soData.minRandomRotationDistance, soData.maxRandomRotationDistance);
								if (num182 < 3f * so.middleZDistance)
								{
									num182 = 3f * so.middleZDistance;
								}
								xssss = 0.5f * num182;
								Assss += num182;
								_0ssst = Mathf.Lerp(yssst, Assss, 0.5f);
								if (!mirrored)
								{
									_1ssss.x = UnityEngine.Random.Range(soData.randomMinRotation, soData.randomMaxRotation);
								}
								else
								{
									_1ssss.x = UnityEngine.Random.Range(0f - soData.randomMaxRotation, 0f - soData.randomMinRotation);
								}
								if (Assss > num143)
								{
									Assss = num143;
									if (Assss - yssst < 3f * so.middleZDistance)
									{
										_1ssss.x = 0f;
									}
								}
								if (_0ssst > num143)
								{
									_0ssst = num143;
									if (_0ssst - yssst < 2f * so.middleZDistance)
									{
										_1ssss.x = 0f;
									}
								}
								if (_1ssss.x != 0f && list27[num151].Count > 0 && Assss > list27[num151][0])
								{
									Assss = xusss + so.middleZDistance;
									_0ssst = Mathf.Lerp(yssst, Assss, 0.5f);
									_1ssss.x = 0f;
								}
							}
							if (list27[num151].Count > 0 && num163 > list27[num151][0])
							{
								wusst = (xusss = num163);
								xusss += list28[num151][0];
								yusst = Mathf.Lerp(wusst, xusss, 0.5f);
								Ausss.x = list29[num151][0];
								vusss = 0.5f * list28[num151][0];
								list27[num151].RemoveAt(0);
								list28[num151].RemoveAt(0);
								list29[num151].RemoveAt(0);
							}
							if (_1ssss.x != 0f)
							{
								if (num163 < _0ssst)
								{
									float t11 = (num163 - yssst) / (_0ssst - yssst);
									_2ssst.x = Mathf.Lerp(0f, _1ssss.x, Mathf.SmoothStep(0f, 1f, t11));
								}
								else
								{
									float t12 = (num163 - _0ssst) / (Assss - _0ssst);
									_2ssst.x = Mathf.Lerp(_1ssss.x, 0f, Mathf.SmoothStep(0f, 1f, t12));
								}
							}
							rotateFlag = list31.Count > num151 && list31[num151];
							if (so.objectType == 0)
							{
								float num183 = num163;
								if (so.density != 0f)
								{
									num183 += UnityEngine.Random.value * so.density;
									if (num183 + 0.1f > num143)
									{
										num183 = num143 + 0.01f;
									}
								}
								OOOOCQQDCQ(gameObject, num183, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, -1, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
								if (!(num163 + soData.m_distance * num162 + 1f >= num143) || !roadScr.closedTrack || num151 < list21.Count - 1 || !OOCODQOQOO(roadScr, so, 0, mirrored) || !flag8)
								{
								}
								if (so.startObject != null && num170 == 1 && !flag26 && !so.baseControllerFlag)
								{
									OOOOCQQDCQ(gameObject, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, 0, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
								}
								else if (flag37 && so.endObject != null && flag32 && !flag28 && !so.baseControllerFlag && !so.averageDistance)
								{
									OOOOCQQDCQ(gameObject, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, 2, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
								}
								num163 += soData.m_distance * num162;
								ODOOOCDOCC(num163, list40, ref currentVecArrayInt);
							}
							else if (so.objectType == 1)
							{
								OOCDQODQOD(num163, so.meshObjects[0], 1, roadScr.markersExt, list6, list7, num167, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, debugFlag: false, num169, flag37, num162, so, roadScr, nodeList, clampUVYPerc, num152, soData, mirrored, shapeDirFlag, ref dualSidedEdgeVertices);
								if (so.startObject != null && num170 == 1 && !flag26)
								{
									OOOOCQQDCQ(gameObject, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, 0, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
								}
								else if (so.connectionObject != null && num170 > 1 && !flag37)
								{
									OOOOCQQDCQ(gameObject, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, 1, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
								}
								else if (flag37 && so.endObject != null && flag32 && !flag28)
								{
									OOOOCQQDCQ(gameObject, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, 2, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
								}
								if (so.position == 0)
								{
									int num184 = currentVecArrayInt;
									ODOOOCDOCC(num163, list40, ref currentVecArrayInt);
									if (so.scaleToRoad && !roadScr.isSideObject)
									{
										if (num184 < currentVecArrayInt)
										{
											num171 = 0;
										}
										else
										{
											num171++;
										}
										if (num171 >= 1 && currentVecArrayInt > 0)
										{
											num163 = 0.2f + num143;
										}
										num163 += Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1]);
									}
									else
									{
										num163 += so.middleZDistance * num162 * so.scale.z;
									}
								}
								else
								{
									currentVecArrayInt++;
									num163 = list40[currentVecArrayInt];
								}
								if (num163 + 0.1f > num143 && num163 - 0.25f < num143)
								{
									num163 = num143 - 0.11f;
									flag37 = true;
								}
								if (!flag37 || num151 < list21.Count - 1)
								{
									CheckVertexLimit(so, 0, force: false);
								}
							}
							else
							{
								int num185 = 0;
								int num186 = so.meshObjects.Count - 1;
								bool doLerp = true;
								if (so.middleVariations != 0)
								{
									num178++;
									if (num178 >= so.middleVariations)
									{
										num178 = 0;
									}
									num185 = (num186 = num178);
									doLerp = false;
								}
								for (int num187 = 0; num187 < so.meshObjects.Count; num187++)
								{
									if (so.middleVariations != 0 && so.meshObjects[num187].middleIndex != num185 + 1)
									{
										continue;
									}
									so.meshObjects[num187].vecCount = so.meshObjects[num187].sVecs.Count;
									zero4 = (zero5 = Vector3.zero);
									if (num169 == 0 && so.includeStartSegment && (flag31 || num151 != 0))
									{
										if (so.meshObjects[num187].zValuesStart.Count > 0)
										{
											ODCCQCQCQD(num163, so.meshObjects[num187], 0, roadScr.markersExt, list6, list7, num167, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, debugFlag: false, num169, lastSegment: false, 1f, so, halfRoadWidth, roadScr, flag33, skipStartBlend, skipEndBlend, ref forward, ref startPos, soData, mirrored, ref steppedHeight, ref lastStep, doLerp, ref zero4, ref zero5);
											if (so.boxcollider)
											{
												AddBoxCollider(go, so, so.startZDistance * so.scale.z, num163, vecPositions, list40, currentVecArrayInt, roadScr, soSplinePointCenter, list16, soData, mirrored, zero4, zero5);
											}
										}
										continue;
									}
									if (!flag37 || !so.includeEndSegment || (!flag32 && num151 == list21.Count - 1))
									{
										ODCCQCQCQD(num163, so.meshObjects[num187], 1, roadScr.markersExt, list6, list7, num167, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, debugFlag: false, num169, lastSegment: false, num162, so, halfRoadWidth, roadScr, flag33, skipStartBlend, skipEndBlend, ref forward, ref startPos, soData, mirrored, ref steppedHeight, ref lastStep, doLerp, ref zero4, ref zero5);
										if (so.boxcollider)
										{
											AddBoxCollider(go, so, so.middleZDistance * so.scale.z, num163, vecPositions, list40, currentVecArrayInt, roadScr, soSplinePointCenter, list16, soData, mirrored, zero4, zero5);
										}
										continue;
									}
									flag38 = true;
									if (so.endOverlapOffset > 0f)
									{
										ODDCQOCQCO(num163 - so.endOverlapOffset * so.scale.z, list40, ref currentVecArrayInt);
									}
									if (so.meshObjects[num187].zValuesEnd.Count > 0)
									{
										ODCCQCQCQD(num163, so.meshObjects[num187], 2, roadScr.markersExt, list6, list7, num167, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, debugFlag: true, num169, lastSegment: true, 1f, so, halfRoadWidth, roadScr, flag33, skipStartBlend, skipEndBlend, ref forward, ref startPos, soData, mirrored, ref steppedHeight, ref lastStep, doLerp, ref zero4, ref zero5);
										if (so.boxcollider)
										{
											AddBoxCollider(go, so, so.endZDistance * so.scale.z, num163, vecPositions, list40, currentVecArrayInt, roadScr, soSplinePointCenter, list16, soData, mirrored, zero4, zero5);
										}
									}
								}
								if (so.startObject != null && num170 == 1 && !flag26)
								{
									OOOOCQQDCQ(go, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, 0, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
								}
								else if (so.connectionObject != null && num170 > 1 && num172 == so.connectionRatio)
								{
									OOOOCQQDCQ(go, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, 1, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
								}
								num172++;
								if (num172 > so.connectionRatio)
								{
									num172 = 1;
								}
								bool flag39 = flag37;
								if (num169 == 0 && num163 == 0f && so.includeStartSegment && !flag34)
								{
									num163 = ((so.scaleToRoad && !roadScr.isSideObject) ? (num163 + Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1])) : (num163 + (so.startZDistance * so.scale.z - so.startOverlapOffset * so.scale.z)));
									ODOOOCDOCC(num163, list40, ref currentVecArrayInt);
								}
								else if (!flag37 || !so.includeEndSegment)
								{
									num163 = ((so.scaleToRoad && !roadScr.isSideObject) ? (num163 + Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1])) : (num163 + (so.middleZDistance * num162 * so.scale.z - num157)));
									int num188 = currentVecArrayInt;
									ODOOOCDOCC(num163, list40, ref currentVecArrayInt);
								}
								else
								{
									num163 = ((so.scaleToRoad && !roadScr.isSideObject) ? (num163 + Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1])) : (num163 + (so.endZDistance * so.scale.z + so.endOverlapOffset * so.scale.z)));
								}
								if (num163 + (so.endZDistance * so.scale.z - so.endOverlapOffset * so.scale.z) + num159 >= num143)
								{
									flag37 = true;
								}
								if (so.scaleToRoad && !roadScr.isSideObject && currentVecArrayInt >= vecPositions.Count - 3)
								{
									flag37 = true;
								}
								if (flag37)
								{
									if (so.includeEndSegment)
									{
										CheckVertexLimit(so, 2, force: false);
									}
									else
									{
										CheckVertexLimit(so, 1, force: false);
									}
								}
								else if (flag39)
								{
									if (num151 < list21.Count - 1)
									{
										if (so.includeStartSegment)
										{
											CheckVertexLimit(so, 0, force: false);
										}
										else
										{
											CheckVertexLimit(so, 1, force: false);
										}
									}
								}
								else
								{
									CheckVertexLimit(so, 1, force: false);
								}
							}
							if (list7.Count > num167 && num163 > list7[num167])
							{
								num167++;
							}
							num169++;
							flag33 = false;
						}
						if (so.objectType == 0 && so.averageDistance)
						{
							OOOOCQQDCQ(gameObject, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, -1, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
						}
						if ((so.connectionObject != null || so.endObject != null) && (flag32 || (so.objectType == 0 && so.endObject != null)) && so.objectType != 1 && !flag28 && so.averageDistance)
						{
							xvsss = true;
							OOOOCQQDCQ(gameObject, num163, num162, so, vecPositions, list15, list16, soSplinePointCenter, list17, list40, currentVecArrayInt, num170, roadScr, 2, soData, mirrored, rotateFlag, list37, shapeDirFlag, num151);
						}
						if (num151 >= num37 && so.objectType == 0 && ((so.combine && num38 > 0) || (num38 > 0 && !wvsst)))
						{
							int num189 = 65000;
							if (gameObject.transform.childCount * so.maxVertices <= num189)
							{
								gameObject.isStatic = so.isStatic;
								ERMeshCombineUtility.CombineMesh(gameObject, null, gameObject.transform, roadScr.isSideObject);
								go.GetComponent<ERSideObjectInstance>().batchedObjects.Clear();
								go.GetComponent<ERSideObjectInstance>().batches = false;
							}
							if (!wvsst && (bool)gameObject.GetComponent<MeshRenderer>() && (bool)gameObject.GetComponent<MeshRenderer>().sharedMaterial)
							{
								gameObject.GetComponent<MeshRenderer>().sharedMaterial = roadScr.baseScript.soSectionMaterial;
							}
							ERSideObjectSection eRSideObjectSection = gameObject.AddComponent<ERSideObjectSection>();
							eRSideObjectSection.road = roadScr;
							eRSideObjectSection.sectionIndex = list37[num151 - num37];
							eRSideObjectSection.mirrored = mirrored;
							eRSideObjectSection.sectionListIndex = num38;
							if ((so.relativeTo == 1 && !mirrored) || (so.relativeTo == 2 && mirrored))
							{
								eRSideObjectSection.leftright = 0;
							}
							else
							{
								eRSideObjectSection.leftright = 1;
							}
							eRSideObjectSection.soId = so.id;
						}
						if (so.objectType == 1 && !so.clampUVY)
						{
						}
					}
					if (so.objectType != 0)
					{
						if (!flag32 && !flag27)
						{
							for (int num190 = 0; num190 < so.meshObjects.Count; num190++)
							{
								for (int num191 = 0; num191 < so.meshObjects[num190].middleStartInts.Count; num191++)
								{
									List<Vector3> sVecs = so.meshObjects[num190].sVecs;
									int index4 = so.meshObjects[num190].middleStartInts[num191];
									Vector3 value = (so.meshObjects[num190].sVecs[so.meshObjects[num190].sVecs.Count - so.meshObjects[num190].vecs.Count + so.meshObjects[num190].middleEndInts[num191]] = Vector3.Lerp(so.meshObjects[num190].sVecs[so.meshObjects[num190].middleStartInts[num191]], so.meshObjects[num190].sVecs[so.meshObjects[num190].sVecs.Count - so.meshObjects[num190].vecs.Count + so.meshObjects[num190].middleEndInts[num191]], 0.5f));
									sVecs[index4] = value;
									if (so.smoothMiddle)
									{
										so.meshObjects[num190].normalArray1.Add(so.meshObjects[num190].middleStartInts[num191]);
										so.meshObjects[num190].normalArray2.Add(so.meshObjects[num190].sVecs.Count - so.meshObjects[num190].vecs.Count + so.meshObjects[num190].middleEndInts[num191]);
									}
								}
							}
						}
						if (flag25 && flag26 && eRSnapSideObjects != null)
						{
							List<int> list44 = new List<int>();
							int count6 = so.meshObjects[0].middleStartInts.Count;
							if (so.objectType == 1)
							{
								count6 = so.nodeList.Count;
								for (int num192 = 0; num192 < so.nodeList.Count; num192++)
								{
									if (so.hardEdge[num192])
									{
										count6++;
									}
								}
								for (int num193 = 0; num193 < count6; num193++)
								{
									list44.Add(num193);
								}
							}
							else if (so.objectType == 2)
							{
								for (int num194 = 0; num194 < so.meshObjects[0].middleStartInts.Count; num194++)
								{
									list44.Add(so.meshObjects[0].middleStartInts[num194]);
								}
							}
							eRSnapSideObjects.ERSetIndexes(soData, list44);
						}
						if (flag27 && flag28 && eRSnapSideObjects2 != null)
						{
							List<int> list45 = new List<int>();
							int count7 = so.meshObjects[0].middleEndInts.Count;
							if (so.objectType == 1)
							{
								count7 = so.nodeList.Count;
								for (int num195 = 0; num195 < so.nodeList.Count; num195++)
								{
									if (so.hardEdge[num195])
									{
										count7++;
									}
								}
								int num196 = so.meshObjects[0].sVecs.Count - count7;
								for (int num197 = num196; num197 < so.meshObjects[0].sVecs.Count; num197++)
								{
									list45.Add(num197);
								}
							}
							else if (so.objectType == 2)
							{
								for (int num198 = 0; num198 < so.meshObjects[0].middleEndInts.Count; num198++)
								{
									list45.Add(so.meshObjects[0].sVecs.Count - so.meshObjects[0].vecs.Count + so.meshObjects[0].middleEndInts[num198]);
								}
							}
							eRSnapSideObjects2.ERSetIndexes(soData, list45);
						}
						if (so.objectType == 1 && roadScr.closedTrack && flag7 && flag8 && (so.combine || list21.Count == 1))
						{
							int count8 = so.nodeList.Count;
							int num199 = count8;
							for (int num200 = 0; num200 < num199; num200++)
							{
								if (so.hardEdge[num200])
								{
									count8++;
								}
							}
							int num201 = 0;
							int num202 = 0;
							for (int num203 = 0; num203 < so.nodeList.Count; num203++)
							{
								List<Vector3> sVecs2 = so.meshObjects[0].sVecs;
								int index5 = num203 + num201;
								Vector3 value = (so.meshObjects[0].sVecs[so.meshObjects[0].sVecs.Count - count8 + num203 + num201] = Vector3.Lerp(so.meshObjects[0].sVecs[num203 + num201], so.meshObjects[0].sVecs[so.meshObjects[0].sVecs.Count - count8 + num203 + num201], 0.5f));
								sVecs2[index5] = value;
								so.meshObjects[0].normalArray1.Add(num203 + num201);
								so.meshObjects[0].normalArray2.Add(so.meshObjects[0].sVecs.Count - count8 + num203 + num201);
								if (so.hardEdge[num203] && num203 != num202)
								{
									num202 = num203;
									num203--;
									num201++;
								}
							}
						}
						if (so.objectType == 1 && so.startEndCaps && so.meshObjects[0].sVecs.Count > 0)
						{
							int count9 = so.nodeList.Count;
							int num204 = count9;
							for (int num205 = 0; num205 < count9; num205++)
							{
								if (so.hardEdge[num205])
								{
									num204++;
								}
							}
							int num206 = so.meshObjects[0].sVecs.Count - num204;
							List<Vector3> list46 = new List<Vector3>();
							List<Vector3> list47 = new List<Vector3>();
							List<Vector2> list48 = new List<Vector2>();
							List<Vector2> list49 = new List<Vector2>();
							List<Color> list50 = new List<Color>();
							int num207 = 0;
							int num208 = so.meshObjects[0].sTriangles[0];
							int num209 = 0;
							for (int num210 = 0; num210 < count9; num210++)
							{
								if (so.meshObjects[0].sVecs.Count > num208)
								{
									list46.Add(so.meshObjects[0].sVecs[num208]);
								}
								list49.Add(Vector2.zero);
								list50.Add(Color.white);
								if (so.meshObjects[0].sVecs.Count > num206 + num209)
								{
									list47.Add(so.meshObjects[0].sVecs[num206 + num209]);
								}
								num208++;
								num209++;
								if (so.hardEdge[num210])
								{
									num208++;
									num209++;
								}
							}
							List<int> list51 = new List<int>(so.startCapTris);
							if (mirrored)
							{
								list51 = new List<int>(so.startCapTrisMirrored);
							}
							int count10 = so.meshObjects[0].sVecs.Count;
							for (int num211 = 0; num211 < list51.Count; num211++)
							{
								list51[num211] += count10;
							}
							int num212 = 0;
							List<Vector2> list52 = new List<Vector2>(so.startCapUVs);
							if (mirrored)
							{
								list52.Reverse();
							}
							if (!flag25)
							{
								so.meshObjects[0].sVecs.AddRange(list46);
								so.meshObjects[0].sUv.AddRange(list52);
								so.meshObjects[0].sUv2.AddRange(list49);
								so.meshObjects[0].sTriangles.AddRange(list51);
								so.meshObjects[0].sColors.AddRange(list50);
							}
							else
							{
								list46.Clear();
							}
							if (!flag27)
							{
								count10 = list46.Count;
								for (int num213 = 0; num213 < list51.Count; num213 += 3)
								{
									list51[num213] += count10;
									list51[num213 + 1] += count10;
									list51[num213 + 2] += count10;
									num212 = list51[num213 + 1];
									list51[num213 + 1] = list51[num213 + 2];
									list51[num213 + 2] = num212;
								}
								List<Vector2> list53 = new List<Vector2>(so.endCapUVs);
								if (mirrored)
								{
									list53.Reverse();
								}
								so.meshObjects[0].sVecs.AddRange(list47);
								so.meshObjects[0].sUv.AddRange(list53);
								so.meshObjects[0].sUv2.AddRange(list49);
								so.meshObjects[0].sTriangles.AddRange(list51);
								so.meshObjects[0].sColors.AddRange(list50);
							}
							for (int num214 = 0; num214 < so.meshObjects[0].sVecsGroups.Count; num214++)
							{
								count9 = so.nodeList.Count;
								num206 = so.meshObjects[0].sVecsGroups[num214].Count - num204;
								list46 = new List<Vector3>();
								list47 = new List<Vector3>();
								list48 = new List<Vector2>();
								list49 = new List<Vector2>();
								list50 = new List<Color>();
								num207 = 0;
								num208 = so.meshObjects[0].sTrianglesGroups[num214][0];
								num209 = 0;
								for (int num215 = 0; num215 < count9; num215++)
								{
									if (so.meshObjects[0].sVecsGroups[num214].Count > num208)
									{
										list46.Add(so.meshObjects[0].sVecsGroups[num214][num208]);
									}
									list49.Add(Vector2.zero);
									list50.Add(Color.white);
									if (so.meshObjects[0].sVecsGroups[num214].Count > num206 + num209)
									{
										list47.Add(so.meshObjects[0].sVecsGroups[num214][num206 + num209]);
									}
									num209++;
									num208++;
									if (so.hardEdge[num215])
									{
										num209++;
										num208++;
									}
								}
								list51 = new List<int>(so.startCapTris);
								if (mirrored)
								{
									list51 = new List<int>(so.startCapTrisMirrored);
								}
								count10 = so.meshObjects[0].sVecsGroups[num214].Count;
								if (!flag25)
								{
									so.meshObjects[0].sVecsGroups[num214].AddRange(list46);
									so.meshObjects[0].sUvGroups[num214].AddRange(so.startCapUVs);
									so.meshObjects[0].sUv2Groups[num214].AddRange(list49);
									so.meshObjects[0].sColorsGroups[num214].AddRange(list50);
									for (int num216 = 0; num216 < list51.Count; num216++)
									{
										list51[num216] += count10;
									}
									so.meshObjects[0].sTrianglesGroups[num214].AddRange(list51);
								}
								if (!flag27)
								{
									so.meshObjects[0].sVecsGroups[num214].AddRange(list47);
									so.meshObjects[0].sUvGroups[num214].AddRange(so.endCapUVs);
									so.meshObjects[0].sUv2Groups[num214].AddRange(list49);
									so.meshObjects[0].sColorsGroups[num214].AddRange(list50);
									list51 = new List<int>(so.startCapTris);
									if (mirrored)
									{
										list51 = new List<int>(so.startCapTrisMirrored);
									}
									count10 = num206 + num204 + list46.Count;
									num212 = 0;
									for (int num217 = 0; num217 < list51.Count; num217 += 3)
									{
										list51[num217] += count10;
										list51[num217 + 1] += count10;
										list51[num217 + 2] += count10;
										num212 = list51[num217 + 1];
										list51[num217 + 1] = list51[num217 + 2];
										list51[num217 + 2] = num212;
									}
									so.meshObjects[0].sTrianglesGroups[num214].AddRange(list51);
								}
							}
						}
						go.GetComponent<ERSideObjectInstance>().points = list21[0];
						go.GetComponent<ERSideObjectInstance>().debugVecs = debugvecs;
						go.GetComponent<ERSideObjectInstance>().distances = list41[0];
						so.meshObjects[0].OCOCDCDDOD(roadScr, go, so, roadScr.baseScript, mirrored, num38, list37, num37, list21, list41, soData, eRSnapSideObjects, eRSnapSideObjects2);
						if (so.objectType == 1 && so.triangulateDualSided && mirrored && soData.mainTriangulateVecs.Count > 0 && soData.mainTriangulateVecs[0].Count > 0)
						{
							so.meshObjects[0].TriangulateDoubleSidedShapes(roadScr, go, so, soData);
						}
						if (so.snapVertexColors && so.tunnelObject && so.objectType == 2)
						{
							go.GetComponent<ERSideObjectInstance>().postProcess = true;
						}
					}
					else
					{
						Transform transform = go.transform.Find("container");
						if (so.combine && num38 < 0)
						{
							int num218 = 65000;
							if (so.instantiatedObjects.Count * so.maxVertices > num218)
							{
								List<GameObject> list54 = new List<GameObject>();
								float num219 = Mathf.Ceil(so.instantiatedObjects.Count * so.maxVertices / num218);
								int num220 = 1;
								int num221 = 0;
								GameObject gameObject2 = new GameObject("Batch 1");
								gameObject2.isStatic = so.isStatic;
								list54.Add(gameObject2);
								if (!Application.isPlaying)
								{
									gameObject2.transform.parent = go.transform;
								}
								while (so.instantiatedObjects.Count > 0)
								{
									if ((num221 + 1) * so.maxVertices > num218)
									{
										ERMeshCombineUtility.CombineMesh(gameObject2, null, transform, roadScr.isSideObject);
										num220++;
										num221 = 0;
										gameObject2 = new GameObject("Batch " + num220);
										list54.Add(gameObject2);
										if (!Application.isPlaying)
										{
											gameObject2.transform.parent = go.transform;
										}
									}
									if (!Application.isPlaying)
									{
										so.instantiatedObjects[0].transform.parent = gameObject2.transform;
									}
									num221++;
									so.instantiatedObjects.RemoveAt(0);
								}
								if (num221 > 0)
								{
									gameObject2.isStatic = so.isStatic;
									ERMeshCombineUtility.CombineMesh(gameObject2, null, transform, roadScr.isSideObject);
								}
								go.GetComponent<ERSideObjectInstance>().batchedObjects = new List<GameObject>(list54);
								go.GetComponent<ERSideObjectInstance>().batches = true;
							}
							else
							{
								go.isStatic = so.isStatic;
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
					if (!roadScr.baseScript.debugMode)
					{
					}
				}
				else
				{
					Debug.LogError("Missing side object data: " + go.name + " for road: " + roadScr.gameObject.name);
					if (Application.isEditor && !Application.isPlaying)
					{
						UnityEngine.Object.DestroyImmediate(go);
					}
					else
					{
						UnityEngine.Object.Destroy(go);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Side Object Error: Road Object: " + roadScr.gameObject.name + " - Side Object: " + so.name + " - " + ex.Message);
			}
		}

		public static void AddBoxCollider(GameObject go, SideObject so, float zDist, float curDist, List<Vector3> vecPositions, List<float> vecDistances, int currentVecArrayInt, ERModularRoad roadScr, List<Vector3> vecPositionsCenter, List<Vector3> vecPositionsRight, ERSORoadExt soData, bool mirrored, Vector3 startBoxCollider, Vector3 endBoxCollider)
		{
			Vector3 v2;
			Vector3 zero;
			Vector3 v = (v2 = (zero = Vector3.zero));
			float spPerc = 0f;
			int spIndex = 0;
			if (!so.scaleToRoad || roadScr.isSideObject)
			{
				OCQCCDQCDC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: false, debugFlag: false, ref spPerc, ref spIndex);
				OCQCCDQCDC(curDist + zDist, vecPositions, vecDistances, currentVecArrayInt, ref v2, ref v2, doSecond: false, debugFlag: false, ref spPerc, ref spIndex);
			}
			else
			{
				if (currentVecArrayInt < 0 || currentVecArrayInt >= vecPositions.Count)
				{
					return;
				}
				v = vecPositions[currentVecArrayInt];
				v2 = vecPositions[currentVecArrayInt + 1];
				zDist = Vector3.Distance(v, v2);
			}
			Vector3 ussss = Vector3.zero;
			Vector3 ussss2 = Vector3.zero;
			Vector3 ussss3 = Vector3.zero;
			Vector3 normalized = (vecPositionsRight[currentSplineInt] - vecPositionsCenter[currentSplineInt]).normalized;
			if (wtsst.x != 0f)
			{
				vssss(curDist, ref ussss, ref xtsss, ttsss, vtsss, utsst, _4ssst, wtsst);
				v += normalized * ussss.x;
				vssss(curDist + zDist, ref ussss, ref xtsss, ttsss, vtsss, utsst, _4ssst, wtsst);
				v2 += normalized * ussss.x;
			}
			if (_3tsss.x != 0f)
			{
				vssss(curDist, ref ussss2, ref _4tsst, _0tsst, _2tsst, _1tsss, Atsss, _3tsss);
				v.y += ussss2.x;
				vssss(curDist + zDist, ref ussss2, ref _4tsst, _0tsst, _2tsst, _1tsss, Atsss, _3tsss);
				v2.y += ussss2.x;
			}
			if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
			{
				if (so.snapToTerrain)
				{
					v.y = OQQOCDQCQD.OQDODCCCCQ(v, roadScr.baseScript) + soData.yPosition;
				}
				if (so.snapToTerrain)
				{
					v2.y = OQQOCDQCQD.OQDODCCCCQ(v2, roadScr.baseScript) + soData.yPosition;
				}
			}
			else if (roadScr.snapToTerrain || !roadScr.isSideObject)
			{
				if (so.snapToTerrain)
				{
					v.y = OQQOCDQCQD.OQDODCCCCQ(v, roadScr.baseScript) + soData.yPosition;
				}
				if (so.snapToTerrain)
				{
					v2.y = OQQOCDQCQD.OQDODCCCCQ(v2, roadScr.baseScript) + soData.yPosition;
				}
			}
			zero = (v2 - v).normalized;
			if ((double)so.boxSize.x < 0.01)
			{
				so.boxSize.x = 0.01f;
			}
			GameObject gameObject = new GameObject("BoxCollider");
			gameObject.layer = so.layer;
			gameObject.transform.position = Vector3.Lerp(v, v2, 0.5f);
			gameObject.transform.forward = zero;
			BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
			boxCollider.size = new Vector3(so.boxSize.x * so.scale.x * so.boxColliderScale.x, so.boxSize.y * so.scale.y * so.boxColliderScale.y, zDist * so.boxColliderScale.z);
			boxCollider.center = new Vector3(so.boxOffset.x * so.scale.x, so.boxOffset.y * so.scale.y, 0f);
			if (_1ssss.x != 0f)
			{
				vssss(curDist, ref ussss3, ref _2ssst, yssst, _0ssst, Assss, xssss, _1ssss);
			}
			if (Ausss.x != 0f)
			{
				wssst(curDist, ref ussss3);
			}
			if (so.align == 1 || (sidewaysFlag && so.align != 0))
			{
				OQQOCDQCQD.OCDCCQCDOO(gameObject, v, roadScr, ussss3);
			}
			else if (so.align == 2)
			{
				OQQOCDQCQD.ODODQOCCOQ(gameObject, v2, v, zero, ussss3);
			}
			else if (so.align == 3)
			{
				if (currentSplineInt >= vecPositionsCenter.Count - 1)
				{
					currentSplineInt = vecPositionsCenter.Count - 2;
				}
				OQQOCDQCQD.OQOCQQOCOC(gameObject, vecPositionsCenter[currentSplineInt], roadScr, ussss3, vecPositionsCenter[currentSplineInt + 1], vecPositionsRight[currentSplineInt], 1f);
			}
			else if (ussss3 != Vector3.zero)
			{
				OQQOCDQCQD.ODODQOCCOQ(gameObject, v2, v, zero, ussss3);
			}
			if (mirrored)
			{
				Vector3 center = gameObject.GetComponent<BoxCollider>().center;
				center.x *= -1f;
				gameObject.GetComponent<BoxCollider>().center = center;
			}
			if (!Application.isPlaying)
			{
				gameObject.transform.parent = go.transform;
			}
			else
			{
				soData.runtimeObjects.Add(gameObject);
			}
		}

		public static void CheckVertexLimit(SideObject so, int segment, bool force)
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
			if (!(flag || force))
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

		public static void ODCCQCQCQD(float curDist, ERMesh mobject, int meshSegment, List<ERMarkerExt> markers, List<float> segmentDistances, List<float> segmentAccDistances, int markerIndex, List<Vector3> vecPositions, List<Vector3> vecPositionsLeft, List<Vector3> vecPositionsRight, List<Vector3> vecPositionsCenter, List<float> vecAngles, List<float> vecDistances, int currentVecArrayInt, bool debugFlag, int segmentCount, bool lastSegment, float scaleFactor, SideObject so, float halfRoadWidth, ERModularRoad roadScr, bool newSegment, bool skipStartBlend, bool skipEndBlend, ref Vector3 forward, ref Vector3 startPos, ERSORoadExt soData, bool mirrored, ref float steppedHeight, ref int lastStep, bool doLerp, ref Vector3 startBoxCollider, ref Vector3 endBoxCollider)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Color> list4 = new List<Color>();
			List<Vector3> list5 = new List<Vector3>();
			List<Vector4> list6 = new List<Vector4>();
			List<int> list7 = new List<int>();
			List<Vector3> list8 = new List<Vector3>();
			List<Vector2> list9 = new List<Vector2>();
			List<Vector2> list10 = new List<Vector2>();
			List<Color> list11 = new List<Color>();
			List<Vector3> list12 = new List<Vector3>();
			List<Vector4> collection = new List<Vector4>();
			List<int> tris = new List<int>();
			List<float> list13 = new List<float>();
			List<ZIndexArray> list14 = new List<ZIndexArray>();
			List<Vector3> list15 = new List<Vector3>();
			List<Vector3> list16 = new List<Vector3>();
			int num = 0;
			float spPerc = 0f;
			int spIndex = 0;
			switch (meshSegment)
			{
			case 0:
				list15 = new List<Vector3>(mobject.startVecs);
				list16 = new List<Vector3>(mobject.startNormals);
				list = mobject.sVecs;
				list2 = mobject.sUv;
				list3 = mobject.sUv2;
				list4 = mobject.sColors;
				list5 = mobject.sNormals;
				list6 = mobject.sTangents;
				list7 = mobject.sTriangles;
				list13 = mobject.zValuesStart;
				list14 = mobject.zValueVecIndexesStart;
				list8 = mobject.startVecs;
				list9 = mobject.startUv;
				list10 = mobject.startUv2;
				list11 = mobject.startColors;
				list12 = mobject.startNormals;
				collection = mobject.startTangents;
				tris = (mirrored ? new List<int>(mobject.startTriangles2) : new List<int>(mobject.startTriangles));
				break;
			case 1:
				if (so.stepDown && so.stepUp)
				{
					float tmpDist = curDist + so.middleZDistance * scaleFactor;
					Vector3 v2;
					Vector3 v = (v2 = Vector3.zero);
					OCQCCDQCDC(tmpDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag, ref spPerc, ref spIndex);
					float num2 = v.y - steppedHeight;
					if (num2 > so.stepDistance)
					{
						num = 1;
					}
					else if (num2 < 0f)
					{
						num = 2;
					}
					if (lastStep > 0 || num > 0)
					{
						doLerp = false;
					}
					lastStep = num;
				}
				switch (num)
				{
				case 0:
					list15 = new List<Vector3>(mobject.vecs);
					list16 = new List<Vector3>(mobject.normals);
					list = mobject.sVecs;
					list2 = mobject.sUv;
					list3 = mobject.sUv2;
					list4 = mobject.sColors;
					list5 = mobject.sNormals;
					list6 = mobject.sTangents;
					list7 = mobject.sTriangles;
					list13 = mobject.zValues;
					list14 = mobject.zValueVecIndexes;
					list8 = mobject.vecs;
					list9 = mobject.uv;
					list10 = mobject.uv2;
					list11 = mobject.colors;
					list12 = mobject.normals;
					collection = mobject.tangents;
					tris = (mirrored ? mobject.triangles2 : mobject.triangles);
					break;
				case 1:
					list15 = new List<Vector3>(mobject.suVecs);
					list16 = new List<Vector3>(mobject.suNormals);
					list = mobject.sVecs;
					list2 = mobject.sUv;
					list3 = mobject.sUv2;
					list4 = mobject.sColors;
					list5 = mobject.sNormals;
					list6 = mobject.sTangents;
					list7 = mobject.sTriangles;
					list13 = mobject.zValuesStepUp;
					list14 = mobject.zValueVecIndexesStepUp;
					list8 = mobject.suVecs;
					list9 = mobject.suUv;
					list10 = mobject.suUv2;
					list11 = mobject.suColors;
					list12 = mobject.suNormals;
					collection = mobject.suTangents;
					tris = (mirrored ? mobject.suTriangles2 : mobject.suTriangles);
					break;
				case 2:
					list15 = new List<Vector3>(mobject.sdVecs);
					list16 = new List<Vector3>(mobject.sdNormals);
					list = mobject.sVecs;
					list2 = mobject.sUv;
					list3 = mobject.sUv2;
					list4 = mobject.sColors;
					list5 = mobject.sNormals;
					list6 = mobject.sTangents;
					list7 = mobject.sTriangles;
					list13 = mobject.zValuesStepDown;
					list14 = mobject.zValueVecIndexesStepDown;
					list8 = mobject.sdVecs;
					list9 = mobject.sdUv;
					list10 = mobject.sdUv2;
					list11 = mobject.sdColors;
					list12 = mobject.sdNormals;
					collection = mobject.sdTangents;
					tris = (mirrored ? mobject.sdTriangles2 : mobject.sdTriangles);
					break;
				}
				break;
			case 2:
				list15 = new List<Vector3>(mobject.endVecs);
				list16 = new List<Vector3>(mobject.endNormals);
				list = mobject.sVecs;
				list2 = mobject.sUv;
				list3 = mobject.sUv2;
				list4 = mobject.sColors;
				list5 = mobject.sNormals;
				list6 = mobject.sTangents;
				list7 = mobject.sTriangles;
				list13 = mobject.zValuesEnd;
				list14 = mobject.zValueVecIndexesEnd;
				list8 = mobject.endVecs;
				list9 = mobject.endUv;
				list10 = mobject.endUv2;
				list11 = mobject.endColors;
				list12 = mobject.endNormals;
				collection = mobject.endTangents;
				tris = (mirrored ? new List<int>(mobject.endTriangles2) : new List<int>(mobject.endTriangles));
				curDist -= so.endOverlapOffset;
				break;
			}
			if (so.tunnelObject && so.hasVertexColors && list10.Count < list9.Count)
			{
				list10 = new List<Vector2>(list9);
			}
			try
			{
				float num3 = 0f;
				if (so.scaleToRoad && !roadScr.isSideObject)
				{
					num3 = Vector3.Distance(vecPositions[currentVecArrayInt], vecPositions[currentVecArrayInt + 1]);
					switch (meshSegment)
					{
					case 0:
						scaleFactor = num3 / so.startZDistance;
						break;
					case 1:
						scaleFactor = num3 / so.middleZDistance;
						break;
					case 2:
						scaleFactor = num3 / so.endZDistance;
						break;
					}
					curDist = vecDistances[currentVecArrayInt];
				}
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				Vector3 zero3 = Vector3.zero;
				Vector3 v4;
				Vector3 v3 = (v4 = Vector3.zero);
				bool flag = false;
				bool flag2 = false;
				Vector3 vector = meshSegment switch
				{
					0 => (vecPositions[1] - vecPositions[0]).normalized, 
					2 => (vecPositions[vecPositions.Count - 1] - vecPositions[vecPositions.Count - 2]).normalized, 
					_ => Vector3.zero, 
				};
				Vector2 value = default(Vector2);
				for (int i = 0; i < list13.Count; i++)
				{
					float num4 = curDist + list13[i] * scaleFactor * so.scale.z;
					OCQCCDQCDC(num4, vecPositions, vecDistances, currentVecArrayInt, ref v3, ref v4, doSecond: true, debugFlag, ref spPerc, ref spIndex);
					if (currentSplineInt >= vecAngles.Count)
					{
						currentSplineInt = vecAngles.Count - 1;
					}
					if (currentSplineInt >= vecPositionsRight.Count)
					{
						currentSplineInt = vecPositionsRight.Count - 1;
					}
					Vector3 vector2 = (lastSegment ? forward : (forward = v4 - v3));
					vector2 = new Vector3(vector2.z, 0f, 0f - vector2.x).normalized;
					float yAngleByDir = OQQOCDQCQD.GetYAngleByDir(forward);
					if (useLastFowardFlag && lastvecPositionsArray && currentSplineInt >= vecPositions.Count - 2)
					{
						forward = roadScr.lastForward;
					}
					if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
					{
						if (so.snapToTerrain)
						{
							v3.y = (v4.y = OQQOCDQCQD.OQDODCCCCQ(v3, roadScr.baseScript) + soData.yPosition);
						}
						vector2 = (vecPositionsRight[currentSplineInt] - vecPositionsLeft[currentSplineInt]).normalized;
					}
					else if ((roadScr.snapToTerrain || !roadScr.isSideObject) && so.snapToTerrain)
					{
						v3.y = (v4.y = OQQOCDQCQD.OQDODCCCCQ(v3, roadScr.baseScript) + soData.yPosition);
					}
					startPos = v3;
					Vector3 zero4 = Vector3.zero;
					zero = Vector3.zero;
					zero2 = Vector3.zero;
					zero3 = Vector3.zero;
					if (wtsst.x != 0f)
					{
						ussst(num4, ref zero, ref xtsss, ttsss, vtsss, utsst, _4ssst, wtsst);
						v3 += vector2 * zero.x;
						v4 += vector2 * zero.x;
					}
					if (_3tsss.x != 0f)
					{
						ussst(num4, ref zero2, ref _4tsst, _0tsst, _2tsst, _1tsss, Atsss, _3tsss);
					}
					if (_1ssss.x != 0f)
					{
						vssss(num4, ref zero3, ref _2ssst, yssst, _0ssst, Assss, xssss, _1ssss);
					}
					if (Ausss.x != 0f)
					{
						wssst(num4, ref zero3);
					}
					if (i == 0)
					{
						startBoxCollider = v3;
					}
					if (i == list13.Count - 1)
					{
						endBoxCollider = v3;
					}
					if (so.stepDown && so.stepUp)
					{
						v3.y = steppedHeight;
					}
					for (int j = 0; j < list14[i].index.Count; j++)
					{
						Vector2 vector3 = list8[list14[i].index[j]];
						vector3 = new Vector2(vector3.x * so.scale.x, vector3.y * so.scale.y);
						Vector3 source = list12[list14[i].index[j]];
						if (mirrored)
						{
							source.x *= -1f;
						}
						source = OQQOCDQCQD.OCCDOQQODO(source, yAngleByDir).normalized;
						if (mirrored)
						{
							vector3.x *= -1f;
						}
						Vector3 v5;
						if (!so.adjustToRoadWidth || Mathf.Abs(vector3.x) < so.xOffset)
						{
							v5 = v3 + vector2 * vector3.x;
						}
						else if (vector3.x < 0f)
						{
							vector3.x = vector3.x / so.scale.x + so.xOffset - halfRoadWidth;
							v5 = v3 + vector2 * vector3.x;
						}
						else
						{
							vector3.x = vector3.x / so.scale.x - so.xOffset + halfRoadWidth;
							v5 = v3 + vector2 * vector3.x;
						}
						v5.y += vector3.y;
						if (so.align == 1 || (sidewaysFlag && so.align != 0))
						{
							OQQOCDQCQD.OOCQDCCDQO(ref v5, ref source, v3, forward, vector3, roadScr, zero3);
						}
						else if (so.align == 2)
						{
							OQQOCDQCQD.OQDQDOOOCC(ref v5, ref source, v3, forward, vector3, 0f, zero3);
							source = OQQOCDQCQD.OCDOCCCDCC(source, zero3.x, forward);
						}
						else if (so.align == 3)
						{
							OQQOCDQCQD.OQDQDOOOCC(ref v5, ref source, v3, forward, vector3, vecAngles[currentSplineInt], zero3);
							source = OQQOCDQCQD.OCDOCCCDCC(source, vecAngles[currentSplineInt] + zero3.x, forward);
						}
						else if (zero3.x != 0f)
						{
							OQQOCDQCQD.RandomAlignment(ref v5, ref source, v3, forward, vector3, zero3);
							source = OQQOCDQCQD.OCDOCCCDCC(source, zero3.x, forward);
						}
						if (_3tsss.x != 0f)
						{
							v5.y += zero2.x;
						}
						list15[list14[i].index[j]] = v5;
						list16[list14[i].index[j]] = source;
						if (so.tunnelObject && so.hasVertexColors)
						{
							if (meshSegment == 0 && so.snapVertexColors && mobject.terrainMesh)
							{
								flag2 = true;
								Color color = list11[list14[i].index[j]];
								float r = list11[list14[i].index[j]].r;
								if (color.g > 0f)
								{
									Vector3 vector4 = OQQOCDQCQD.OCOODDDQDO(v5, vector, vector3);
									if (vector4 != v5)
									{
										if ((double)color.g > 0.95)
										{
											vector4 += 0.5f * vector;
										}
										v5 = Vector3.Lerp(v5, vector4, color.g);
										list15[list14[i].index[j]] = v5;
										flag = true;
									}
									else if ((double)color.g > 0.8 && (double)vector3.y > 0.5)
									{
										OCDOODOQDC.OCQCDODDQC(ref tris, list14[i].index[j]);
									}
								}
								if (color.b > 0f)
								{
									Vector3 pos = v5;
									pos.y += 20f;
									float distance = 0f;
									Vector3 b = OQQOCDQCQD.OQOOOCQDDO(pos, Vector3.down, ref distance);
									if (distance < 40f)
									{
										v5 = Vector3.Lerp(v5, b, color.b);
									}
									if (color.b == 1f)
									{
										v5.y -= 0.15f;
									}
									list15[list14[i].index[j]] = v5;
								}
							}
							else if (meshSegment == 2 && so.snapVertexColors && mobject.terrainMesh)
							{
								flag2 = true;
								Color color2 = list11[list14[i].index[j]];
								if (color2.g > 0f)
								{
									Vector3 vector5 = OQQOCDQCQD.OCOODDDQDO(v5, -vector, vector3);
									if (vector5 != v5)
									{
										if ((double)color2.g > 0.95)
										{
											vector5 -= 0.5f * vector;
										}
										v5 = Vector3.Lerp(v5, vector5, color2.g);
										flag = true;
										list15[list14[i].index[j]] = v5;
									}
									else if ((double)color2.g > 0.8 && (double)vector3.y > 0.5)
									{
										OCDOODOQDC.OCQCDODDQC(ref tris, list14[i].index[j]);
									}
								}
								if (color2.b > 0f)
								{
									Vector3 pos2 = v5;
									pos2.y += 20f;
									float distance2 = 0f;
									Vector3 b2 = OQQOCDQCQD.OQOOOCQDDO(pos2, Vector3.down, ref distance2);
									if (distance2 < 40f)
									{
										v5 = Vector3.Lerp(v5, b2, color2.b);
									}
									if (color2.b == 1f)
									{
										v5.y -= 0.15f;
									}
									list15[list14[i].index[j]] = v5;
								}
							}
							value.x = (v5.x - _2usst.min.x) / _2usst.size.x;
							value.y = (v5.z - _2usst.min.z) / _2usst.size.z;
							list10[list14[i].index[j]] = value;
						}
						if (so.tunnelObject && so.randomUVx)
						{
							value = list9[list14[i].index[j]];
							value.x += uusst;
							list9[list14[i].index[j]] = value;
						}
					}
				}
				if (debugFlag)
				{
				}
				list.AddRange(list15);
				list2.AddRange(list9);
				list3.AddRange(list10);
				list4.AddRange(list11);
				list5.AddRange(list16);
				list6.AddRange(collection);
				int count = list.Count;
				int num5 = OQQOCDQCQD.OOQDQCCCQQ(segmentCount, so, newSegment, mobject, lastSegment, skipStartBlend, skipEndBlend);
				if (so.namedChilds)
				{
					if (num5 == 0 && !mobject.snapStartVertices)
					{
						doLerp = false;
					}
					else if (num5 == 1 && !mobject.snapMiddleVertices)
					{
						doLerp = false;
					}
					else if (num5 == 2 && !mobject.snapEndVertices)
					{
						doLerp = false;
					}
				}
				else if (so.segmentOffset != 0f)
				{
					doLerp = false;
				}
				if (num5 == 0 && doLerp)
				{
					if (count - mobject.vecs.Count - mobject.startVecs.Count >= 0)
					{
						if (!so.subMesh)
						{
							for (int k = 0; k < mobject.startEndInts.Count; k++)
							{
								List<Vector3> list17 = list;
								int index = count - mobject.vecs.Count + mobject.middleStartStartInts[k];
								Vector3 value2 = (list[count - mobject.vecs.Count - mobject.startVecs.Count + mobject.startEndInts[k]] = Vector3.Lerp(list[count - mobject.vecs.Count + mobject.middleStartStartInts[k]], list[count - mobject.vecs.Count - mobject.startVecs.Count + mobject.startEndInts[k]], 0.5f));
								list17[index] = value2;
								if (so.smoothStart && !so.namedChilds)
								{
									mobject.normalArray1.Add(count - mobject.vecs.Count + mobject.middleStartStartInts[k]);
									mobject.normalArray2.Add(count - mobject.vecs.Count - mobject.startVecs.Count + mobject.startEndInts[k]);
								}
							}
						}
						else
						{
							for (int l = 0; l < so.meshObjects.Count; l++)
							{
								for (int m = 0; m < so.meshObjects[l].startEndInts.Count; m++)
								{
									List<Vector3> list18 = list;
									int index2 = count - mobject.vecs.Count + so.meshObjects[l].middleStartStartInts[m];
									Vector3 value2 = (list[count - mobject.vecs.Count - mobject.startVecs.Count + so.meshObjects[l].startEndInts[m]] = Vector3.Lerp(list[count - mobject.vecs.Count + so.meshObjects[l].middleStartStartInts[m]], list[count - mobject.vecs.Count - mobject.startVecs.Count + so.meshObjects[l].startEndInts[m]], 0.5f));
									list18[index2] = value2;
									if (so.smoothStart && !so.namedChilds)
									{
										mobject.normalArray1.Add(count - mobject.vecs.Count + so.meshObjects[l].middleStartStartInts[m]);
										mobject.normalArray2.Add(count - mobject.vecs.Count - mobject.startVecs.Count + so.meshObjects[l].startEndInts[m]);
									}
								}
							}
						}
					}
				}
				else if (num5 == 1 && num == 0 && doLerp)
				{
					if (count - 2 * mobject.vecs.Count >= 0)
					{
						if (!so.subMesh)
						{
							for (int n = 0; n < mobject.middleStartInts.Count; n++)
							{
								if (segmentCount == 2)
								{
								}
								List<Vector3> list19 = list;
								int index3 = count - mobject.vecs.Count + mobject.middleStartInts[n];
								Vector3 value2 = (list[count - 2 * mobject.vecs.Count + mobject.middleEndInts[n]] = Vector3.Lerp(list[count - mobject.vecs.Count + mobject.middleStartInts[n]], list[count - 2 * mobject.vecs.Count + mobject.middleEndInts[n]], 0.5f));
								list19[index3] = value2;
								if (so.smoothMiddle && !so.namedChilds)
								{
									mobject.normalArray1.Add(count - mobject.vecs.Count + mobject.middleStartInts[n]);
									mobject.normalArray2.Add(count - 2 * mobject.vecs.Count + mobject.middleEndInts[n]);
								}
							}
						}
						else
						{
							for (int num6 = 0; num6 < so.meshObjects.Count; num6++)
							{
								for (int num7 = 0; num7 < so.meshObjects[num6].middleStartInts.Count; num7++)
								{
									List<Vector3> list20 = list;
									int index4 = count - mobject.vecs.Count + so.meshObjects[num6].middleStartInts[num7];
									Vector3 value2 = (list[count - 2 * mobject.vecs.Count + so.meshObjects[num6].middleEndInts[num7]] = Vector3.Lerp(list[count - mobject.vecs.Count + so.meshObjects[num6].middleStartInts[num7]], list[count - 2 * mobject.vecs.Count + so.meshObjects[num6].middleEndInts[num7]], 0.5f));
									list20[index4] = value2;
									if (so.smoothMiddle && !so.namedChilds)
									{
										mobject.normalArray1.Add(count - mobject.vecs.Count + so.meshObjects[num6].middleStartInts[num7]);
										mobject.normalArray2.Add(count - 2 * mobject.vecs.Count + so.meshObjects[num6].middleEndInts[num7]);
									}
								}
							}
						}
					}
				}
				else if (num5 == 2 && doLerp && count - mobject.endVecs.Count - mobject.vecs.Count >= 0)
				{
					if (!so.subMesh)
					{
						for (int num8 = 0; num8 < mobject.middleEndEndInts.Count; num8++)
						{
							List<Vector3> list21 = list;
							int index5 = count - mobject.endVecs.Count + mobject.endStartInts[num8];
							Vector3 value2 = (list[count - mobject.endVecs.Count - mobject.vecs.Count + mobject.middleEndEndInts[num8]] = Vector3.Lerp(list[count - mobject.endVecs.Count + mobject.endStartInts[num8]], list[count - mobject.endVecs.Count - mobject.vecs.Count + mobject.middleEndEndInts[num8]], 0.5f));
							list21[index5] = value2;
							if (so.smoothEnd && !so.namedChilds)
							{
								mobject.normalArray1.Add(count - mobject.endVecs.Count + mobject.endStartInts[num8]);
								mobject.normalArray2.Add(count - mobject.endVecs.Count - mobject.vecs.Count + mobject.middleEndEndInts[num8]);
							}
						}
					}
					else
					{
						for (int num9 = 0; num9 < so.meshObjects.Count; num9++)
						{
							for (int num10 = 0; num10 < so.meshObjects[num9].middleEndEndInts.Count; num10++)
							{
								List<Vector3> list22 = list;
								int index6 = count - mobject.endVecs.Count + so.meshObjects[num9].endStartInts[num10];
								Vector3 value2 = (list[count - mobject.endVecs.Count - mobject.vecs.Count + so.meshObjects[num9].middleEndEndInts[num10]] = Vector3.Lerp(list[count - mobject.endVecs.Count + so.meshObjects[num9].endStartInts[num10]], list[count - mobject.endVecs.Count - mobject.vecs.Count + so.meshObjects[num9].middleEndEndInts[num10]], 0.5f));
								list22[index6] = value2;
								if (so.smoothEnd && !so.namedChilds)
								{
									mobject.normalArray1.Add(count - mobject.endVecs.Count + so.meshObjects[num9].endStartInts[num10]);
									mobject.normalArray2.Add(count - mobject.endVecs.Count - mobject.vecs.Count + so.meshObjects[num9].middleEndEndInts[num10]);
								}
							}
						}
					}
				}
				if (flag || !flag2)
				{
					for (int num11 = 0; num11 < tris.Count; num11++)
					{
						list7.Add(mobject.vecCount + tris[num11]);
					}
				}
			}
			catch
			{
				Debug.LogError("EasyRoads3Dv3 Error: Road: " + roadScr.name + " - Side Object: " + so.name);
			}
			switch (num)
			{
			case 1:
				steppedHeight += so.stepDistance;
				break;
			case 2:
				steppedHeight -= so.stepDistance;
				break;
			}
		}

		public static void OOCDQODQOD(float curDist, ERMesh mobject, int meshSegment, List<ERMarkerExt> markers, List<float> segmentDistances, List<float> segmentAccDistances, int markerIndex, List<Vector3> vecPositions, List<Vector3> vecPositionsLeft, List<Vector3> vecPositionsRight, List<Vector3> vecPositionsCenter, List<float> vecAngles, List<float> vecDistances, int currentVecArrayInt, bool debugFlag, int segmentCount, bool lastSegment, float scaleFactor, SideObject so, ERModularRoad roadScr, List<List<Vector2>> fullNodeList, float clampUVYPerc, float uvyShapeRatio, ERSORoadExt soData, bool mirrored, bool shapeDirFlag, ref List<Vector3> dualSidedEdgeVertices)
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
			List<Vector3> list19 = new List<Vector3>();
			List<Vector2> list20 = new List<Vector2>();
			List<Vector2> list21 = new List<Vector2>();
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
			Vector2 vector = Vector2.zero;
			Vector2 zero = Vector2.zero;
			Vector3 v2;
			Vector3 n;
			Vector3 v = (v2 = (n = Vector3.zero));
			float spPerc = 0f;
			int spIndex = 0;
			if (so.position == 0)
			{
				OCQCCDQCDC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag, ref spPerc, ref spIndex);
			}
			else
			{
				v = vecPositions[currentVecArrayInt];
				v2 = vecPositions[currentVecArrayInt + 1];
			}
			if (lastSegment)
			{
				v = vecPositions[vecPositions.Count - 2];
				v2 = vecPositions[vecPositions.Count - 1];
			}
			Vector3 vector2;
			Vector3 dir = (vector2 = v2 - v);
			if (shapeDirFlag)
			{
				vector2 = vecPositions[currentVecArrayInt + 1] - vecPositions[currentVecArrayInt - 1];
			}
			vector2 = new Vector3(vector2.z, 0f, 0f - vector2.x).normalized;
			int num = 0;
			if (so.scaleToRoad && !roadScr.isSideObject)
			{
				if (v == vecPositions[currentVecArrayInt])
				{
					vector2 = (vecPositionsRight[currentVecArrayInt] - vecPositionsLeft[currentVecArrayInt]).normalized;
				}
				else
				{
					num = 1;
					vector2 = (vecPositionsRight[currentVecArrayInt + 1] - vecPositionsLeft[currentVecArrayInt + 1]).normalized;
				}
				vector2 = new Vector3(vector2.x, 0f, vector2.z).normalized;
				dir = new Vector3(0f - vector2.z, 0f, vector2.x).normalized;
			}
			if (xtsss.x != 0f)
			{
				v += xtsss.x * vector2;
				v2 += xtsss.x * vector2;
			}
			if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
			{
				if (!so.scaleToRoad)
				{
					vector2 = new Vector3(vector2.x, 0f, vector2.z).normalized;
				}
			}
			else if (roadScr.snapToTerrain)
			{
				roadScr.baseScript.OQCCDQOQOO(ref v);
				v.y += soData.yPosition;
			}
			else if ((roadScr.snapToTerrain || !roadScr.isSideObject) && so.snapToTerrain)
			{
				v.y = (v2.y = OQQOCDQCQD.OQDODCCCCQ(v, roadScr.baseScript) + soData.yPosition);
			}
			if (currentSplineInt >= vecAngles.Count)
			{
				currentSplineInt = vecAngles.Count - 1;
			}
			if (vecPositions.Count <= currentVecArrayInt + 2)
			{
				lastSegment = true;
			}
			bool flag = false;
			if (fullNodeList.Count == 0 || fullNodeList[0].Count == 0 || mirrored)
			{
				flag = true;
			}
			List<float> list22 = new List<float>();
			list22.Add(0f);
			float num2 = 0f;
			float num3 = so.hardEdgePadding;
			List<Vector2> list23;
			List<bool> list24;
			List<float> list25;
			List<float> list26;
			List<Color> list27;
			if (!mirrored)
			{
				list23 = so.nodeList;
				list24 = so.hardEdge;
				list25 = new List<float>(so.uvs);
				list26 = so.snapWeightList;
				list27 = so.colorList;
			}
			else
			{
				list23 = so.nodeListMirrored;
				list24 = ((so.hardEdgeMirrored.Count != 0) ? so.hardEdgeMirrored : so.hardEdge);
				list25 = new List<float>(so.uvsMirrored);
				list26 = so.snapWeightListMirrored;
				list27 = so.colorListMirrored;
				num3 *= -1f;
			}
			if (so.reverseUVs)
			{
				float num4 = 1f;
				float num5 = 0f;
				for (int i = 0; i < list25.Count; i++)
				{
					if (list25[i] < num4)
					{
						num4 = list25[i];
					}
					if (list25[i] > num5)
					{
						num5 = list25[i];
					}
				}
				for (int j = 0; j < list25.Count; j++)
				{
					list25[j] = Mathf.Lerp(num5, num4, (list25[j] - num4) / (num5 - num4));
				}
			}
			bool flag2 = false;
			float t = 0f;
			if (so.deformationObject && (curDist < _3usss || curDist > _4usst))
			{
				flag2 = true;
				t = ((!(curDist < _3usss)) ? Mathf.SmoothStep(0f, 1f, (curDist - _4usst) / _3usss) : Mathf.SmoothStep(1f, 0f, curDist / _3usss));
			}
			bool flag3 = true;
			if (so.triangulateDualSided && ((so.nodeList[0].y > so.nodeList[so.nodeList.Count - 1].y && !mirrored) || (so.nodeList[0].y < so.nodeList[so.nodeList.Count - 1].y && mirrored)))
			{
				flag3 = false;
			}
			int num6 = so.nodeList.Count;
			int num7 = num6;
			int num8 = 0;
			for (int k = 0; k < so.nodeList.Count; k++)
			{
				Vector2 vec = (flag ? list23[k] : ((fullNodeList[k].Count <= currentVecArrayInt) ? fullNodeList[k][fullNodeList[k].Count - 1] : fullNodeList[k][currentVecArrayInt]));
				Vector3 v3 = v + vector2 * vec.x * so.scale.x;
				v3.y += vec.y * so.scale.y;
				if (!so.uv4walls || list27[k].a != 1f || so.category != 2)
				{
					if (so.align == 1 || (sidewaysFlag && so.align != 0))
					{
						OQQOCDQCQD.OOCQDCCDQO(ref v3, ref n, v, dir, vec, roadScr, _2ssst);
					}
					else if (so.align == 2)
					{
						OQQOCDQCQD.OQDQDOOOCC(ref v3, ref n, v, dir, vec, 0f, _2ssst);
					}
					else if (so.align == 3)
					{
						OQQOCDQCQD.OQDQDOOOCC(ref v3, ref n, v, dir, vec, vecAngles[currentSplineInt], _2ssst);
					}
					else if (_2ssst != Vector3.zero)
					{
						OQQOCDQCQD.OQDQDOOOCC(ref v3, ref n, v, dir, vec, 0f, _2ssst);
					}
				}
				list19.Add(v3);
				Vector3 item = v3;
				if (list26[k] > 0f || flag2)
				{
					Vector3 pos = v3;
					roadScr.baseScript.OQCCDQOQOO(ref pos);
					v3.y = Mathf.Lerp(v3.y, pos.y, list26[k]);
					if (flag2)
					{
						v3.y = Mathf.Lerp(v3.y, pos.y, t);
					}
					if (!so.retainingWall && (double)list26[k] > 0.95)
					{
						list8.Add(roadScr.baseScript.OOQDDODCDO(pos));
						if (list24[k])
						{
							list8.Add(list8[list8.Count - 1]);
						}
					}
					else
					{
						list8.Add(Vector3.zero);
						if (list24[k])
						{
							list8.Add(Vector3.zero);
						}
					}
				}
				else
				{
					list8.Add(Vector3.zero);
					if (list24[k])
					{
						list8.Add(Vector3.zero);
					}
				}
				list18.Add(v3);
				if (so.triangulateDualSided && dualSidedEdgeVertices != null && ((k == num7 - 1 && !flag3) || (k == 0 && flag3)))
				{
					dualSidedEdgeVertices.Add(v3);
				}
				list4.Add(list27[k]);
				if (list24[k])
				{
					list18.Add(v3);
					list19.Add(item);
					list4.Add(list27[k]);
					num6++;
					num8++;
				}
				if (k > 0)
				{
					num2 += Vector3.Distance(v3, list18[list18.Count - 2 - num8]);
					list22.Add(num2);
				}
				if (so.clampUVs && !so.terrainUVs)
				{
					vector = new Vector2(list25[k], curDist * so.uvy * clampUVYPerc * uvyShapeRatio / so.scale.z);
					if (lastSegment && so.clampUVY)
					{
						vector.y = Mathf.Ceil(vector.y) - (1f - so.clampUVYValue);
					}
				}
				zero = vector;
				if (so.clampUV4)
				{
					zero = new Vector2(list25[k], curDist * so.uvy * clampUVYPerc * uvyShapeRatio / so.scale.z);
				}
				else
				{
					zero.x = (v3.x - _2usst.min.x) / _2usst.size.x;
					zero.y = (v3.z - _2usst.min.z) / _2usst.size.z;
				}
				if (so.uv4walls)
				{
					vector.y = (v3.y - _1vsss) * so.uvy * clampUVYPerc * uvyShapeRatio / so.scale.x;
					vector.x = curDist * so.uvy * clampUVYPerc * uvyShapeRatio / so.scale.z;
				}
				list21.Add(zero);
				if (list24[k])
				{
					list21.Add(zero);
				}
				if ((so.clampUVs && !so.terrainUVs) || so.uv4walls)
				{
					list20.Add(vector);
					if (list24[k])
					{
						vector.x += num3;
						list20.Add(vector);
					}
				}
				else if (so.terrainUVs)
				{
					list20.Add(zero);
					if (list24[k])
					{
						list20.Add(zero);
					}
				}
			}
			float num9 = 0f;
			if (!so.clampUVs && !so.terrainUVs && !so.uv4walls)
			{
				float num10 = list22[list22.Count - 1];
				float num11 = 0f;
				List<Vector2> list28 = new List<Vector2>();
				if (!mirrored && !so.reverseUVs)
				{
					for (int l = 0; l < num7; l++)
					{
						float num12 = ((list26[l] != 0f && l != 0) ? (num11 + (list22[l] - list22[l - 1]) / so.totalDistance) : list25[l]);
						vector = new Vector2(num12, curDist * so.uvy * clampUVYPerc * uvyShapeRatio / so.scale.z);
						num11 = num12;
						list28.Add(vector);
						if (list24[l])
						{
							list28.Add(vector);
						}
						if (vector.x > num9)
						{
							num9 = vector.x;
						}
					}
				}
				else
				{
					int num13 = num7 - 1;
					for (int num14 = num7 - 1; num14 >= 0; num14--)
					{
						float num12 = ((list26[num14] != 0f && num14 != num13) ? (num11 + (list22[num14 + 1] - list22[num14]) / so.totalDistance) : list25[num14]);
						vector = new Vector2(num12, curDist * so.uvy * clampUVYPerc * uvyShapeRatio / so.scale.z);
						num11 = num12;
						list28.Add(vector);
						if (list24[num14])
						{
							list28.Add(vector);
						}
						if (vector.x > num9)
						{
							num9 = vector.x;
						}
					}
					list28.Reverse();
				}
				list20.AddRange(list28);
			}
			if (debugFlag)
			{
			}
			int count = list.Count;
			int num15 = 0;
			float num16 = 0f;
			if (so.shapeWeightsRelativeX)
			{
				for (int m = 0; m < list23.Count; m++)
				{
					if (list26[m] > 0f)
					{
						if (m < list23.Count - 1 && list23[m + 1].y > list23[m].y)
						{
							vector2 = (list19[m + num15] - list19[m + num15 + 1]).normalized;
							num16 = Vector3.Distance(list18[m + num15], list18[m + num15 + 1]);
							Vector3 v3 = list18[m + num15 + 1] + vector2 * num16;
							list18[m + num15] = v3;
						}
						else if (m > 0 && list23[m - 1].y > list23[m].y)
						{
							vector2 = (list19[m + num15] - list19[m + num15 - 1]).normalized;
							num16 = Vector3.Distance(list18[m + num15 - 1], list18[m + num15]);
							Vector3 v3 = list18[m + num15 - 1] + vector2 * num16;
							list18[m + num15] = v3;
						}
					}
					if (list24[m])
					{
						num15++;
					}
				}
			}
			list.AddRange(list18);
			list2.AddRange(list20);
			list3.AddRange(list21);
			int count2 = so.nodeList.Count;
			num15 = 0;
			if (segmentCount <= 0)
			{
				return;
			}
			for (int num17 = 0; num17 < count2 - 1; num17++)
			{
				if (list24[num17])
				{
					num15++;
				}
				list7.Add(count - num6 + num17 + num15);
				list7.Add(count + num17 + num15);
				list7.Add(count + num17 + 1 + num15);
				list7.Add(count - num6 + num17 + num15);
				list7.Add(count + num17 + 1 + num15);
				list7.Add(count - num6 + num17 + 1 + num15);
			}
		}

		public static void OOOOCQQDCQ(GameObject parentGo, float curDist, float scaleFactor, SideObject so, List<Vector3> vecPositions, List<Vector3> vecPositionsLeft, List<Vector3> vecPositionsRight, List<Vector3> vecPositionsCenter, List<float> vecAngles, List<float> vecDistances, int currentVecArrayInt, int num, ERModularRoad roadScr, int startConnectionEnd, ERSORoadExt soData, bool mirrored, bool rotateFlag, List<int> sectionIndexes, bool shapeDirFlag, int k)
		{
			int count = vecPositions.Count;
			if (count <= 1)
			{
				return;
			}
			float num2 = 1f;
			if (mirrored && so.mirrorType == 0)
			{
				num2 = -1f;
			}
			int num3 = num;
			GameObject gameObject = null;
			GameObject gameObject2 = null;
			string text = "";
			string text2 = "";
			if (so.objectType == 0 && startConnectionEnd == -1)
			{
				if (startConnectionEnd != 2 || so.endObject == null || !so.meshBoundsAlignment)
				{
					gameObject2 = so.sourceObject;
					if (soData.sourceObject != null)
					{
						gameObject2 = soData.sourceObject;
					}
					if (so.childOrder == 0)
					{
						gameObject = UnityEngine.Object.Instantiate(gameObject2);
						text2 = so.sourceObject.name;
					}
					else if (so.childOrder == 1)
					{
						int childCount = gameObject2.transform.childCount;
						if (childCount > 1)
						{
							num--;
							num -= Mathf.RoundToInt(Mathf.Floor(num / childCount) * (float)childCount);
							if (xvsss)
							{
								num++;
								if (num >= childCount)
								{
									num = 0;
								}
							}
							gameObject = UnityEngine.Object.Instantiate(gameObject2.transform.GetChild(num).gameObject);
							text2 = gameObject2.transform.GetChild(num).gameObject.name;
						}
						else
						{
							gameObject = UnityEngine.Object.Instantiate(gameObject2);
							text2 = gameObject2.name;
						}
					}
					else
					{
						int childCount2 = gameObject2.transform.childCount;
						if (childCount2 > 1)
						{
							int index = Mathf.RoundToInt(UnityEngine.Random.Range(0, childCount2));
							gameObject = UnityEngine.Object.Instantiate(gameObject2.transform.GetChild(index).gameObject);
							text2 = gameObject2.transform.GetChild(index).gameObject.name;
						}
						else
						{
							gameObject = UnityEngine.Object.Instantiate(gameObject2);
							text2 = gameObject2.name;
						}
					}
				}
				else
				{
					gameObject = UnityEngine.Object.Instantiate(so.endObject);
					gameObject2 = so.endObject;
					text2 = so.endObject.name;
				}
			}
			else
			{
				text2 = so.name;
				switch (startConnectionEnd)
				{
				case 0:
					if (so.startObject != null)
					{
						gameObject = (gameObject2 = so.startObject);
						text = " Start Object";
					}
					break;
				case 1:
					if (so.connectionObject != null)
					{
						gameObject = (gameObject2 = so.connectionObject);
						text = " Connection Object";
					}
					break;
				case 2:
					if (so.endObject != null)
					{
						gameObject = (gameObject2 = so.endObject);
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
						int childCount3 = gameObject.transform.childCount;
						if (childCount3 > 1)
						{
							num--;
							num -= Mathf.RoundToInt(Mathf.Floor(num / childCount3) * (float)childCount3);
							gameObject = UnityEngine.Object.Instantiate(gameObject.transform.GetChild(num).gameObject);
						}
						else
						{
							gameObject = UnityEngine.Object.Instantiate(gameObject);
						}
					}
					else
					{
						int childCount4 = gameObject.transform.childCount;
						gameObject = ((childCount4 <= 1) ? UnityEngine.Object.Instantiate(gameObject) : UnityEngine.Object.Instantiate(gameObject.transform.GetChild(Mathf.RoundToInt(UnityEngine.Random.Range(0, childCount4))).gameObject));
					}
				}
			}
			if (gameObject == null)
			{
				return;
			}
			ERPrefabInstance eRPrefabInstance = gameObject.AddComponent<ERPrefabInstance>();
			eRPrefabInstance.roadScript = roadScr;
			eRPrefabInstance.so = so;
			eRPrefabInstance.prefab = gameObject2;
			eRPrefabInstance.soData = soData;
			if (so.objectType != 0)
			{
				eRPrefabInstance.child = true;
			}
			if (k >= vvsss && uvsst != -1 && sectionIndexes.Count > tvsss)
			{
				ERSideObjectSection eRSideObjectSection = gameObject.AddComponent<ERSideObjectSection>();
				eRSideObjectSection.road = roadScr;
				eRSideObjectSection.sectionIndex = sectionIndexes[tvsss];
				eRSideObjectSection.mirrored = mirrored;
				eRSideObjectSection.sectionListIndex = uvsst;
				if ((so.relativeTo == 1 && !mirrored) || (so.relativeTo == 2 && mirrored))
				{
					eRSideObjectSection.leftright = 0;
				}
				else
				{
					eRSideObjectSection.leftright = 1;
				}
				eRSideObjectSection.soId = so.id;
			}
			so.instantiatedObjects.Add(gameObject);
			gameObject.name = text2 + text;
			if (!Application.isPlaying)
			{
				gameObject.transform.parent = parentGo.transform;
			}
			else
			{
				soData.runtimeObjects.Add(gameObject);
			}
			if (!roadScr.baseScript.roadUpdateDragFlag)
			{
				gameObject.isStatic = so.isStatic;
			}
			gameObject.layer = so.layer;
			gameObject.tag = so.tag;
			Vector3 v2;
			Vector3 v = (v2 = Vector3.zero);
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			float spPerc = 0f;
			int spIndex = 0;
			Vector3 vector;
			if (!so.meshBoundsAlignment)
			{
				if (so.relativeToCenter || roadScr.isSideObject)
				{
					OCQCCDQCDC(curDist, vecPositionsCenter, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag: false, ref spPerc, ref spIndex);
					if (spIndex <= 0)
					{
						spIndex = 1;
					}
					v = Vector3.Lerp(vecPositions[spIndex - 1], vecPositions[spIndex], spPerc);
					v2 = ((!((double)spPerc < 0.99)) ? Vector3.Lerp(vecPositions[spIndex], vecPositions[spIndex + 1], 0.01f) : Vector3.Lerp(vecPositions[spIndex - 1], vecPositions[spIndex], spPerc + 0.01f));
				}
				else
				{
					OCQCCDQCDC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag: false, ref spPerc, ref spIndex);
				}
				zero2 = (zero = (zero3 = (v2 - v).normalized));
				vector = v;
				if (!roadScr.baseScript.isInBuildMode && !roadScr.isSideObject)
				{
					if (so.snapToTerrain)
					{
						v.y = (v2.y = OQQOCDQCQD.OQDODCCCCQ(v, roadScr.baseScript) + soData.yPosition);
					}
				}
				else if ((roadScr.snapToTerrain || !roadScr.isSideObject) && so.snapToTerrain)
				{
					v.y = (v2.y = OQQOCDQCQD.OQDODCCCCQ(v, roadScr.baseScript) + soData.yPosition);
				}
				zero = (vecPositionsRight[currentVecArrayInt] - vecPositionsLeft[currentVecArrayInt]).normalized;
			}
			else
			{
				Bounds bounds = default(Bounds);
				if (OQQOCDQCQD.ODDOODDCDC(gameObject, ref bounds))
				{
					OCQCCDQCDC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: false, debugFlag: false, ref spPerc, ref spIndex);
					OCQCCDQCDC(curDist + bounds.size.z, vecPositions, vecDistances, currentVecArrayInt, ref v2, ref v2, doSecond: false, debugFlag: false, ref spPerc, ref spIndex);
					zero2 = (zero = (zero3 = (v2 - v).normalized));
					vector = v;
					if ((roadScr.baseScript.isInBuildMode || roadScr.isSideObject) && (roadScr.snapToTerrain || !roadScr.isSideObject) && roadScr.terrainDeformation && so.snapToTerrain)
					{
						v.y = OQQOCDQCQD.OQDODCCCCQ(v, roadScr.baseScript) + soData.yPosition;
						v2.y = OQQOCDQCQD.OQDODCCCCQ(v, roadScr.baseScript) + soData.yPosition;
					}
					zero = (vecPositionsRight[currentVecArrayInt] - vecPositionsLeft[currentVecArrayInt]).normalized;
				}
				else
				{
					OCQCCDQCDC(curDist, vecPositions, vecDistances, currentVecArrayInt, ref v, ref v2, doSecond: true, debugFlag: false, ref spPerc, ref spIndex);
					zero2 = (zero = (zero3 = (v2 - v).normalized));
					vector = v;
					if ((roadScr.baseScript.isInBuildMode || roadScr.isSideObject) && (roadScr.snapToTerrain || !roadScr.isSideObject) && roadScr.terrainDeformation && so.snapToTerrain)
					{
						v.y = (v2.y = OQQOCDQCQD.OQDODCCCCQ(v, roadScr.baseScript) + soData.yPosition);
					}
					zero = (vecPositionsRight[currentVecArrayInt] - vecPositionsLeft[currentVecArrayInt]).normalized;
				}
			}
			if (shapeDirFlag)
			{
				zero = vecPositions[currentVecArrayInt + 1] - vecPositions[currentVecArrayInt - 1];
				zero = new Vector3(zero.z, 0f, 0f - zero.x).normalized;
			}
			if (so.objectType != 0)
			{
				if (xtsss.x != 0f)
				{
					if (zero == Vector3.zero)
					{
						zero = new Vector3(zero2.z, 0f, 0f - zero2.x);
					}
					v += xtsss.x * zero;
					v2 += xtsss.x * zero;
				}
			}
			else if (!so.baseControllerFlag && (soData.randomMinXPosition != 0f || soData.randomMaxXPosition != 0f))
			{
				float num4 = 0f;
				num4 = (mirrored ? Mathf.Lerp(0f - soData.randomMaxXPosition, 0f - soData.randomMinXPosition, UnityEngine.Random.value) : Mathf.Lerp(soData.randomMinXPosition, soData.randomMaxXPosition, UnityEngine.Random.value));
				if (zero == Vector3.zero)
				{
					zero = new Vector3(zero2.z, 0f, 0f - zero2.x);
				}
				v += zero * num4;
				v2 += zero * num4;
			}
			if (so.selectedRotation == 0 && !shapeDirFlag)
			{
				zero = new Vector3(zero3.x, 0f, zero3.z).normalized;
				float num5 = Vector3.Angle(Vector3.forward, zero);
				if (OQQOCDQCQD.OQDDDQOOQO(Vector3.forward, zero, Vector3.up) == -1f)
				{
					num5 = 360f - num5;
				}
				gameObject.transform.eulerAngles = new Vector3(0f, num5 + so.yRotation * num2, 0f);
			}
			else if (so.selectedRotation == 1)
			{
				gameObject.transform.eulerAngles = new Vector3(0f, so.yRotation * num2, 0f);
			}
			else if (so.selectedRotation == 2)
			{
				gameObject.transform.eulerAngles = new Vector3(0f, UnityEngine.Random.value * 360f, 0f);
			}
			else if (shapeDirFlag)
			{
				float num6 = Vector3.Angle(Vector3.forward, zero) - 90f;
				if (OQQOCDQCQD.OQDDDQOOQO(Vector3.forward, zero, Vector3.up) == -1f)
				{
					num6 = 360f - num6;
				}
				gameObject.transform.eulerAngles = new Vector3(0f, num6 + so.yRotation * num2, 0f);
			}
			if (startConnectionEnd == 2 && so.objectType == 1)
			{
				v = vecPositions[vecPositions.Count - 2];
			}
			gameObject.transform.position = v;
			if (so.bridgeObject && OQQOCDQCQD.ODCOODDCOD(gameObject, v, roadScr))
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
				return;
			}
			Vector3 ussss = Vector3.zero;
			if (_1ssss.x != 0f)
			{
				vssss(curDist, ref ussss, ref _2ssst, yssst, _0ssst, Assss, xssss, _1ssss);
			}
			if (Ausss.x != 0f)
			{
				wssst(curDist, ref ussss);
			}
			int num7 = so.align;
			if (so.objectType == 2 && so.connectionObjectRotation == 1)
			{
				num7 = 0;
			}
			if (num7 == 1 || (sidewaysFlag && num7 != 0))
			{
				OQQOCDQCQD.OCDCCQCDOO(gameObject, v, roadScr, ussss);
			}
			else
			{
				switch (num7)
				{
				case 2:
					OQQOCDQCQD.ODODQOCCOQ(gameObject, v2, vector, zero2, ussss);
					break;
				case 3:
				{
					int count2 = vecPositionsCenter.Count;
					int count3 = vecAngles.Count;
					if (!roadScr.isSideObject)
					{
						if (currentSplineInt < count2)
						{
							OQQOCDQCQD.OQOCQQOCOC(gameObject, vecPositionsCenter[currentSplineInt], roadScr, ussss, vecPositionsCenter[currentSplineInt - 1], vecPositionsRight[currentSplineInt], -1f);
						}
						else
						{
							OQQOCDQCQD.OQOCQQOCOC(gameObject, vecPositionsCenter[count2 - 1], roadScr, ussss, vecPositionsCenter[count2 - 1], vecPositionsRight[count2 - 2], -1f);
						}
					}
					else if (currentSplineInt < count2 && currentSplineInt < count3)
					{
						OQQOCDQCQD.OQOCQQOCOC(gameObject, vecPositionsCenter[currentSplineInt], roadScr, new Vector3(0f - vecAngles[currentSplineInt] + ussss.x, ussss.y, ussss.z), vecPositionsCenter[currentSplineInt - 1], vecPositionsRight[currentSplineInt], -1f);
					}
					else
					{
						OQQOCDQCQD.OQOCQQOCOC(gameObject, vecPositionsCenter[count2 - 1], roadScr, new Vector3(0f - vecAngles[count3 - 1] + ussss.x, ussss.y, ussss.z), vecPositionsCenter[count2 - 1], vecPositionsRight[count2 - 2], -1f);
					}
					break;
				}
				default:
					if (so.meshBoundsAlignment)
					{
						float minY = 20000f;
						float maxY = -20000f;
						OQQOCDQCQD.OQDOOCQCCQ(roadScr.baseScript, v2, vector, ref minY, ref maxY);
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
						if (ussss.x != 0f)
						{
							OQQOCDQCQD.InstantiatedRandomRotation(gameObject, Vector3.zero, roadScr, ussss);
						}
						v.y += soData.yPosition;
						gameObject.transform.position = v;
					}
					else if (ussss.x != 0f)
					{
						OQQOCDQCQD.InstantiatedRandomRotation(gameObject, Vector3.zero, roadScr, -ussss);
					}
					break;
				}
			}
			if (_4tsst.x != 0f)
			{
				v = gameObject.transform.position;
				v.y += _4tsst.x;
				gameObject.transform.position = v;
			}
			if (so.minScale != 1f || so.maxScale != 1f)
			{
				float num8 = so.minScale + (so.maxScale - so.minScale) * UnityEngine.Random.value;
				gameObject.transform.localScale = new Vector3(num8, num8, num8);
			}
			if (mirrored)
			{
				if (so.mirrorType == 0)
				{
					gameObject.transform.localScale = new Vector3(0f - gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
				}
				else if (so.mirrorType == 1)
				{
					gameObject.transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
				}
			}
			if (!rotateFlag || so.yRotation == 0f || so.mirrorType == 0)
			{
			}
			if (so.baseControllerFlag)
			{
				gameObject = UnityEngine.Object.Instantiate(gameObject2);
				if (soData.lastEndPosition != Vector3.zero)
				{
					gameObject.transform.position = soData.lastEndPosition;
				}
				else if (so.startObject != null)
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate(so.startObject);
					gameObject3.transform.parent = gameObject.transform.parent;
					gameObject3.transform.position = gameObject.transform.position;
					gameObject3.transform.eulerAngles = gameObject.transform.eulerAngles;
					gameObject3.name = "Start Object";
				}
				if (so.minBaseRotation != 0f || so.maxBaseRotation != 0f)
				{
					v = gameObject.transform.GetChild(so.baseChildIndex).localEulerAngles;
					v.y += UnityEngine.Random.Range(so.minBaseRotation, so.maxBaseRotation);
					gameObject.transform.GetChild(so.baseChildIndex).localEulerAngles = v;
				}
				Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
				soData.lastEndPosition = componentsInChildren[so.baseConnectorIndex].position;
			}
			if (wvsst)
			{
				soData.objects.Add(gameObject);
			}
		}

		public static void OCQCCDQCDC(float tmpDist, List<Vector3> vecPositions, List<float> vecDistances, int currentVecArrayInt, ref Vector3 v, ref Vector3 v1, bool doSecond, bool debugFlag, ref float spPerc, ref int spIndex)
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
				spPerc = num;
				spIndex = i;
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

		public static void ODOOOCDOCC(float curDist, List<float> vecDistances, ref int currentVecArrayInt)
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

		public static void ODDCQOCQCO(float curDist, List<float> vecDistances, ref int currentVecArrayInt)
		{
			if (currentVecArrayInt > 0)
			{
				for (int num = currentVecArrayInt; num > 0; num--)
				{
					if (vecDistances[num] < curDist)
					{
						currentVecArrayInt = num;
						break;
					}
				}
			}
			else
			{
				currentVecArrayInt = 0;
			}
		}

		private static void ussst(float tssss, ref Vector3 ussss, ref Vector3 vssss, float wssss, float xssss, float yssss, float Assss, Vector3 _0ssss)
		{
			if (tssss <= xssss)
			{
				float num = (tssss - wssss) / (xssss - wssss);
				float num2 = num * Assss;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(Assss - num2) < 0.25)
				{
					num = 1f;
				}
				vssss.x = Mathf.Lerp(0f, _0ssss.x, Mathf.SmoothStep(0f, 1f, num));
			}
			else
			{
				float num3 = (tssss - xssss) / (yssss - xssss);
				float num4 = num3 * Assss;
				if ((double)num4 < 0.25)
				{
					num3 = 0f;
				}
				else if ((double)(Assss - num4) < 0.25)
				{
					num3 = 1f;
				}
				vssss.x = Mathf.Lerp(_0ssss.x, 0f, Mathf.SmoothStep(0f, 1f, num3));
			}
			ussss = vssss;
		}

		private static void vssss(float tssss, ref Vector3 ussss, ref Vector3 vssss, float wssss, float xssss, float yssss, float Assss, Vector3 _0ssss)
		{
			if (tssss <= xssss)
			{
				float num = (tssss - wssss) / (xssss - wssss);
				float num2 = num * Assss;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(Assss - num2) < 0.25)
				{
					num = 1f;
				}
				vssss.x = Mathf.Lerp(0f, _0ssss.x, Mathf.SmoothStep(0f, 1f, num));
			}
			else
			{
				float num3 = (tssss - xssss) / (yssss - xssss);
				float num4 = num3 * Assss;
				if ((double)num4 < 0.25)
				{
					num3 = 0f;
				}
				else if ((double)(Assss - num4) < 0.25)
				{
					num3 = 1f;
				}
				vssss.x = Mathf.Lerp(_0ssss.x, 0f, Mathf.SmoothStep(0f, 1f, num3));
			}
			ussss = vssss;
		}

		private static void wssst(float tssss, ref Vector3 ussss)
		{
			if (tssss <= yusst)
			{
				float num = (tssss - wusst) / (yusst - wusst);
				float num2 = num * vusss;
				if ((double)num2 < 0.25)
				{
					num = 0f;
				}
				else if ((double)(vusss - num2) < 0.25)
				{
					num = 1f;
				}
				_0usst.x = Mathf.Lerp(0f, Ausss.x, Mathf.SmoothStep(0f, 1f, num));
				if (ussss == Vector3.zero)
				{
					ussss = _0usst;
				}
				else
				{
					ussss = Vector3.Lerp(ussss, _0usst, num);
				}
			}
			else
			{
				float num3 = (tssss - yusst) / (xusss - yusst);
				float num4 = num3 * vusss;
				if ((double)num4 < 0.25)
				{
					num3 = 0f;
				}
				else if ((double)(vusss - num4) < 0.25)
				{
					num3 = 1f;
				}
				_0usst.x = Mathf.Lerp(Ausss.x, 0f, Mathf.SmoothStep(0f, 1f, num3));
				if (ussss == Vector3.zero)
				{
					ussss = _0usst;
				}
				else
				{
					ussss = Vector3.Lerp(_0usst, ussss, num3);
				}
			}
		}

		public static Terrain OQQOQQCOOQ(Vector3 pos)
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
			if (array.Length == 0)
			{
				return null;
			}
			return array[0];
		}
	}
}
