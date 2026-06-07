using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERCrossingPrefabs : MonoBehaviour
	{
		public List<QDOODOQQDQODD> crossingElements = new List<QDOODOQQDQODD>();

		public List<QDOQDSQOOQDDD> sidewalkControlElements = new List<QDOQDSQOOQDDD>();

		public Vector3[] meshVecs = new Vector3[0];

		public Vector3[] fullMeshVecs = new Vector3[0];

		public Vector3[] tmpMeshVecs = new Vector3[0];

		public Vector3[] tmpFullMeshVecs = new Vector3[0];

		public Vector3[] tCrossingTmpFullMeshVecs = new Vector3[0];

		public int[] outerVecInts = new int[0];

		public List<Vector3> surfaceVecs = new List<Vector3>();

		public List<int> surfaceVecType = new List<int>();

		public List<int> surfaceConnectionInt = new List<int>();

		public List<ERBlendVecs> tCrossingBlendData = new List<ERBlendVecs>();

		public List<Vector3> indentVecs = new List<Vector3>();

		public GameObject sourcePrefab;

		public int prefabId = 0;

		public List<int> prioritySegments = new List<int>();

		public float minNodeDistance = 3f;

		public int nodeWithinRange = -1;

		public GameObject sourceObject;

		public bool meshInstance = false;

		public int selectedConnection = -1;

		public string[] QDOOOQOOQQQQD = new string[0];

		public bool deformTerrain = true;

		public bool isRoundabout = false;

		public bool isERCrossing = false;

		public bool isIConnector = false;

		public ERRoundabouts roundaboutScript;

		public ERCrossings crossingsScript;

		public ERIConnector iConnectorScript;

		public bool isCustomPrefab = false;

		public int customPrefabVersion = 0;

		public bool recalculateNormals = false;

		public bool planarUVs = false;

		public float planarTiling = 1f;

		public int lastVecRoadIndex = 0;

		public bool isSceneObject = true;

		public GameObject surfaceObject;

		public Vector3[] surfaceMeshVecs = null;

		public Vector3[] tmpSurfaceMeshVecs = null;

		public Vector3[] tmpSurfaceVecsTCrossings = new Vector3[0];

		public int[] surfaceInts;

		public Vector3 leftBottomCorner;

		public Vector3 leftTopCorner;

		public Vector3 rightBottomCorner;

		public Vector3 rightTopCorner;

		public bool tCrossing = false;

		public bool tStraightBending = true;

		public int tCrossingLeftRight = 1;

		public float tMainRoadWidth = 0f;

		public float tConnectionRoadWidth = 0f;

		public float bottomLeftSidewalkWidth = 0f;

		public float bottomLeftSidewalkOuterOffset = 0f;

		public float bottomLeftSidewalkCurbDepth = 0f;

		public float bottomRightSidewalkWidth = 0f;

		public float bottomRightSidewalkOuterOffset = 0f;

		public float bottomRightSidewalkCurbDepth = 0f;

		public float topLeftSidewalkWidth = 0f;

		public float topLeftSidewalkOuterOffset = 0f;

		public float topLeftSidewalkCurbDepth = 0f;

		public float topRightSidewalkWidth = 0f;

		public float topRightSidewalkOuterOffset = 0f;

		public float topRightSidewalkCurbDepth = 0f;

		public ERConnection connObject;

		public Vector3 testVec;

		public List<int> surfaceSurroundingInts = new List<int>();

		public int rotationPriorityElement = -1;

		public Vector3 cornerPos;

		public Vector3 mainCorner;

		public Vector3 connectedCorner;

		public Vector3 mainVecOuter;

		public Vector3 connectionVecOuter;

		public Vector3 indentTopVec;

		public Vector3 indentRightVec;

		public Vector3 mainIndent;

		public Vector3 connectionIndent;

		public int selectedRotationConnection = 0;

		public Vector3 bottomVec;

		public Vector3 rightVec;

		public Vector3 bottomIndent;

		public Vector3 rightIndent;

		public float sAngle = 90f;

		public ERModularBase baseScript;

		public bool QDQDQOOQQDQOQQ = false;

		public Vector3 tp1;

		public Vector3 tp2;

		public bool doTerrainDeformation = true;

		public bool includeOuterVertices = true;

		public float surroundingDistance = 0f;

		public Mesh surfaceMesh = null;

		public List<Vector3> debugVecs1 = new List<Vector3>();

		public List<Vector3> debugVecs2 = new List<Vector3>();

		public bool lightmapAdjusted = false;

		public bool lockScale = true;

		public float extraIndentMargin = 0f;

		public float indent = 0f;

		public float surrounding = 0f;

		public void OODDCDQQDO()
		{
			Vector3[] vertices = base.gameObject.GetComponent<MeshFilter>().sharedMesh.vertices;
			meshVecs = new Vector3[vertices.Length];
			Array.Copy(vertices, meshVecs, 0);
			meshVecs = vertices;
		}

		public void ODOOOQODQC(Vector3 v1, Vector3 v2, int connectionElement, ERModularRoad road)
		{
			OOQDOOOCOD(connectionElement);
			Vector3 normalized = (v1 - v2).normalized;
			Vector3 normalized2 = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
			Vector3 vector = v2 + normalized2;
			float num = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f;
			num -= crossingElements[connectionElement].centerPointAngle;
			Vector3 eulerAngles = base.transform.eulerAngles;
			if (OOOOCDQQOC(base.transform.position, v1, v2))
			{
				eulerAngles.y += num;
			}
			else
			{
				eulerAngles.y -= num;
			}
			base.transform.eulerAngles = new Vector3(0f, num, 0f);
			Vector3 vector2 = v1 + new Vector3(normalized.z, 0f, 0f - normalized.x) * 2f;
			Vector3 lhs = v1 - vector2;
			Vector3 rhs = v2 - vector2;
			Vector3 vector3 = -Vector3.Cross(lhs, rhs).normalized;
			Vector3 forward = base.transform.forward;
			Vector3 forward2 = forward - Vector3.Dot(forward, vector3) * vector3;
			base.transform.rotation = Quaternion.LookRotation(forward2, vector3);
			Vector3 vector4 = base.transform.TransformPoint(crossingElements[connectionElement].centerPoint);
			base.transform.position += v1 - vector4;
			OCOOQCCDQO(ignorePriority: true, road);
		}

		public void OOQDOOOCOD(int el)
		{
			Vector3 normalized = (crossingElements[el].controlPointV3 - crossingElements[el].centerPoint).normalized;
			crossingElements[el].centerPointAngle = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f;
		}

		public void ODDQOCQDDO(int elInt, float distance)
		{
		}

		public void DeformTCossingConnection(int elInt, float distance, float defaultDistance, List<Vector3> controlPoints, float multiplyFactor, float angle, Vector3 cpCenterPoint, float curveStrength)
		{
			if (!tCrossing)
			{
				return;
			}
			controlPoints.Reverse();
			if (fullMeshVecs.Length == 0)
			{
				if (baseScript == null)
				{
					if ((bool)base.transform.parent.parent)
					{
						baseScript = base.transform.parent.parent.GetComponent<ERModularBase>();
					}
					if (baseScript == null)
					{
						return;
					}
				}
				baseScript.ODDQOOQODD(this);
			}
			if (crossingElements[elInt].rotationPriority)
			{
				return;
			}
			if (tCrossingTmpFullMeshVecs.Length == 0)
			{
				tCrossingTmpFullMeshVecs = new Vector3[fullMeshVecs.Length];
				Array.Copy(fullMeshVecs, tCrossingTmpFullMeshVecs, fullMeshVecs.Length);
				tmpSurfaceVecsTCrossings = new Vector3[surfaceMeshVecs.Length];
				Array.Copy(surfaceMeshVecs, tmpSurfaceVecsTCrossings, surfaceMeshVecs.Length);
			}
			QDOODOQQDQODD qDOODOQQDQODD = crossingElements[elInt];
			if (qDOODOQQDQODD.connectionVecInts.Count != 0)
			{
				Vector3 normalized = (meshVecs[qDOODOQQDQODD.connectionVecInts[0]] - meshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.connectionVecInts.Count - 1]]).normalized;
				Mesh mesh = null;
				if (!meshInstance)
				{
					mesh = UnityEngine.Object.Instantiate(base.gameObject.GetComponent<MeshFilter>().sharedMesh);
					base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
					base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
					meshInstance = true;
				}
				else
				{
					mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
				}
				tmpFullMeshVecs = mesh.vertices;
				tmpFullMeshVecs = OQDDODCOQQ.OCCDOOCDOC(this, elInt, controlPoints, distance, defaultDistance, fullMeshVecs, ref tCrossingTmpFullMeshVecs, multiplyFactor, angle, curveStrength);
				if (crossingsScript == null)
				{
					crossingsScript = base.gameObject.GetComponent<ERCrossings>();
				}
				tmpFullMeshVecs = OOQCCQOCDO.OQOQCDODCO(crossingsScript, tmpFullMeshVecs);
				tmpFullMeshVecs = ERSideWalkVecs.SnapSidewalkCornersVecs(crossingsScript, tmpFullMeshVecs);
				mesh.vertices = tmpFullMeshVecs;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mesh.normals = ERSideWalkVecs.OODOCDCQDC(crossingsScript, mesh.normals);
				if (baseScript.tangentsInEditMode)
				{
					OCQQDQQCQQ.OOCCQOQQQC(mesh);
				}
				qDOODOQQDQODD.tmpCenterPoint = Vector3.Lerp(tmpFullMeshVecs[qDOODOQQDQODD.fullConnectionVecInts[0]], tmpFullMeshVecs[qDOODOQQDQODD.fullConnectionVecInts[qDOODOQQDQODD.fullConnectionVecInts.Count - 1]], qDOODOQQDQODD.centerPointPercentage);
				qDOODOQQDQODD.tmpCenterPoint.y = 0f;
				if (tmpSurfaceMeshVecs == null)
				{
					tmpSurfaceMeshVecs = new Vector3[surfaceMeshVecs.Length];
					Array.Copy(surfaceMeshVecs, tmpSurfaceMeshVecs, surfaceMeshVecs.Length);
					tmpSurfaceVecsTCrossings = new Vector3[surfaceMeshVecs.Length];
					Array.Copy(surfaceMeshVecs, tmpSurfaceVecsTCrossings, surfaceMeshVecs.Length);
				}
				tmpSurfaceMeshVecs = OQDDODCOQQ.OODCQDOCQQ(this, elInt, controlPoints, distance, defaultDistance, surfaceMeshVecs, ref tmpSurfaceVecsTCrossings, multiplyFactor, angle, curveStrength);
				OCDCCCQDCC.OCQQOQCCDC(this, elInt);
				OCDCCCQDCC.ODQQOODCDQ(this);
				if (crossingElements[2].connectedRoad != null && crossingElements[elInt].connectedRoad != crossingElements[2].connectedRoad)
				{
					crossingElements[2].connectedRoad.OCCCCCCDCC(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
				if (crossingElements[3].connectedRoad != null && crossingElements[elInt].connectedRoad != crossingElements[3].connectedRoad)
				{
					crossingElements[3].connectedRoad.OCCCCCCDCC(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
			}
		}

		public void OODQDDQCQO(List<int> affectedVecs, List<Vector2> tmpVecs)
		{
			Vector3[] array = (Vector3[])meshVecs.Clone();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].x = tmpVecs[i].x;
				array[i].z = tmpVecs[i].y;
			}
			base.gameObject.GetComponent<MeshFilter>().sharedMesh.vertices = array;
		}

		public void OCOOQCCDQO(bool ignorePriority, ERModularRoad road)
		{
			OCCQOOCCCQ(forceFlag: false);
			if (tmpSurfaceMeshVecs == null)
			{
				tmpSurfaceMeshVecs = new Vector3[surfaceMeshVecs.Length];
				Array.Copy(surfaceMeshVecs, tmpSurfaceMeshVecs, surfaceMeshVecs.Length);
			}
			else if (tmpSurfaceMeshVecs.Length == 0)
			{
				tmpSurfaceMeshVecs = new Vector3[surfaceMeshVecs.Length];
				Array.Copy(surfaceMeshVecs, tmpSurfaceMeshVecs, surfaceMeshVecs.Length);
			}
			OCDCCCQDCC.ODQQOODCDQ(this);
			CheckPlanarUVs();
			List<ERModularRoad> list = new List<ERModularRoad>();
			for (int i = 0; i < crossingElements.Count; i++)
			{
				if (!(crossingElements[i].connectedRoad != null) || (crossingElements[i].rotationPriority && !ignorePriority))
				{
					continue;
				}
				ERModularRoad component = crossingElements[i].connectedRoad.GetComponent<ERModularRoad>();
				bool flag = false;
				if (crossingElements[i].connectedMarker == 0)
				{
					if (component.startConnectionSegment == i && component.startPrefabScript == this)
					{
						flag = true;
					}
				}
				else if (component.endConnectionSegment == i && component.endPrefabScript == this)
				{
					flag = true;
				}
				if (!flag)
				{
					continue;
				}
				Vector3 position = base.transform.TransformPoint(crossingElements[i].centerPoint);
				if (component.markersExt.Count <= crossingElements[i].connectedMarker)
				{
					return;
				}
				component.markersExt[crossingElements[i].connectedMarker].position = position;
				int num = crossingElements[i].roadShapeVecs.Count + crossingElements[i].sidewalkLeftVecs.Count + crossingElements[i].sidewalkRightVecs.Count;
				if (crossingElements[i].roadType == crossingElements[i].connectedRoad.roadType || crossingElements[i].connectedRoad.roadType == 0.0)
				{
					bool flag2 = false;
					if (!isIConnector && !isCustomPrefab && crossingElements[i].roadShapeVecsString != crossingElements[i].connectedRoad.roadShapeString)
					{
						flag2 = true;
					}
					if (!isIConnector && isCustomPrefab && crossingElements[i].roadShapeMatchCount != crossingElements[i].connectedRoad.roadShapeMatchCount)
					{
						flag2 = true;
					}
					if (flag2)
					{
						crossingElements[i].connectedRoad.nodeWithinRange = crossingElements[i].connectedMarker;
						if (crossingElements[i].connectedMarker == 0)
						{
							crossingElements[i].connectedRoad.OQCCCCQCCO(this, i, reverse: true, uvReverse: true);
							OCOCOOQQCD.OQCDOQOCDC(baseScript, this, i, crossingElements[i].connectedRoad, 0);
						}
						else
						{
							crossingElements[i].connectedRoad.OQCCCCQCCO(this, i, reverse: false, uvReverse: false);
							OCOCOOQQCD.OQCDOQOCDC(baseScript, this, i, crossingElements[i].connectedRoad, 1);
						}
					}
				}
				if (ODQCOCCQCQ(list, component))
				{
					list.Add(component);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (road != list[i])
				{
					list[i].OCCCCCCDCC(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
			}
			ERCrossingPrefabs[] componentsInChildren = base.gameObject.GetComponentsInChildren<ERCrossingPrefabs>();
			ERCrossingPrefabs[] array = componentsInChildren;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array)
			{
				if (eRCrossingPrefabs != this)
				{
					eRCrossingPrefabs.OCOOQCCDQO(ignorePriority: true, null);
				}
			}
		}

		public void OCODQQCQQO()
		{
			OCCQOOCCCQ(forceFlag: false);
			CheckPlanarUVs();
			if (!isRoundabout)
			{
				OCDCCCQDCC.ODOODDQDOD(this, tmpMeshVecs, ref surfaceMeshVecs);
			}
			else
			{
				OQOQODQOCO.OCODQQCQQO(this, tmpMeshVecs, ref surfaceMeshVecs);
			}
		}

		public void OCCQOOCCCQ(bool forceFlag)
		{
			if (baseScript == null)
			{
				if ((bool)base.transform.parent && (bool)base.transform.parent.parent)
				{
					baseScript = base.transform.parent.parent.GetComponent<ERModularBase>();
				}
				if (baseScript == null)
				{
					return;
				}
			}
			if (doTerrainDeformation)
			{
				if ((isCustomPrefab && surroundingDistance != baseScript.minSurrounding) || (isCustomPrefab && surfaceMesh == null) || forceFlag)
				{
					if (crossingElements.Count > 0)
					{
						OCCQCCQOQD.OCQDQCQDOQ(this, baseScript);
					}
					else
					{
						OCCQCCQOQD.OCQDQCQDOQ(this, baseScript);
						doTerrainDeformation = false;
						Debug.Log("EasyRoads3Dv3 Alert: this prefab does not have connections, terrain deformation is not supported yet for this type of prefabs");
					}
					surroundingDistance = baseScript.minSurrounding;
					surfaceMesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
					OCDCCCQDCC.ODQQOODCDQ(this);
				}
			}
			else if ((bool)base.transform.Find("surface"))
			{
				UnityEngine.Object.DestroyImmediate(base.transform.Find("surface").gameObject);
			}
		}

		public void CheckPlanarUVs()
		{
			if (planarUVs && (bool)base.gameObject.GetComponent<MeshFilter>() && (bool)base.gameObject.GetComponent<MeshFilter>().sharedMesh)
			{
				Mesh sharedMesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
				Vector2[] uv = sharedMesh.uv;
				for (int i = 0; i <= lastVecRoadIndex; i++)
				{
					Vector3 vector = base.transform.TransformPoint(sharedMesh.vertices[i]);
					ref Vector2 reference = ref uv[i];
					reference = new Vector2(vector.x, vector.z) * planarTiling;
				}
				sharedMesh.uv = uv;
			}
		}

		public static bool ODQCOCCQCQ(List<ERModularRoad> affectedObjects, ERModularRoad roadScr)
		{
			for (int i = 0; i < affectedObjects.Count; i++)
			{
				if (affectedObjects[i] == roadScr)
				{
					return false;
				}
			}
			return true;
		}

		public void OCQQQCDODC(bool flag)
		{
			for (int i = 0; i < sidewalkControlElements.Count; i++)
			{
				sidewalkControlElements[i].renderFlag = flag;
				sidewalkControlElements[i].leftConnectionHandle = flag;
				crossingElements[sidewalkControlElements[i].crossingElementLeftIndex].includeLeftSidewalk = flag;
				sidewalkControlElements[i].rightConnectionHandle = flag;
				crossingElements[sidewalkControlElements[i].crossingElementRightIndex].includeRightSidewalk = flag;
			}
		}

		public void OCDQQDODQC(int el)
		{
			for (int i = 0; i < crossingElements.Count; i++)
			{
				if (i != el)
				{
					crossingElements[i].rotationPriority = false;
				}
			}
		}

		public bool HasConnections()
		{
			for (int i = 0; i < crossingElements.Count; i++)
			{
				if (crossingElements[i].connectedRoad != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasConnectionsFull()
		{
			for (int i = 0; i < crossingElements.Count; i++)
			{
				if (!(crossingElements[i].connectedRoad != null))
				{
					continue;
				}
				if (crossingElements[i].connectedRoad.startPrefabScript == this)
				{
					if (crossingElements[i].connectedRoad.endPrefabScript != null && crossingElements[i].connectedRoad.endPrefabScript.isCustomPrefab)
					{
						return true;
					}
				}
				else if (crossingElements[i].connectedRoad.startPrefabScript != null && crossingElements[i].connectedRoad.startPrefabScript.isCustomPrefab)
				{
					return true;
				}
			}
			return false;
		}

		public void OODCQOQOQO(int el, int startend)
		{
			if (startend == 0)
			{
				crossingElements[el].connectedRoad.startPrefabScript = null;
				crossingElements[el].connectedRoad.startConnectionSegment = 0;
			}
			else
			{
				crossingElements[el].connectedRoad.endPrefabScript = null;
				crossingElements[el].connectedRoad.endConnectionSegment = 0;
			}
			crossingElements[el].connectedRoad = null;
			crossingElements[el].connectedMarker = -1;
			if (el == 0)
			{
				if (crossingElements[1].connectedRoad == null)
				{
					UnityEngine.Object.DestroyImmediate(base.gameObject);
				}
				else
				{
					base.gameObject.GetComponent<ERIConnector>().OCCCCCCDCC(null);
				}
			}
			else if (crossingElements[0].connectedRoad == null)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
			}
			else
			{
				base.gameObject.GetComponent<ERIConnector>().OCCCCCCDCC(null);
			}
		}

		public void SetElementInfo(int index, int sourceIndex)
		{
			int num = 0;
			if (isIConnector)
			{
				sourceIndex = ((index == 0) ? 1 : 0);
			}
			crossingElements[index].roadType = crossingElements[sourceIndex].roadType;
			crossingElements[index].roadMaterials = new Material[crossingElements[sourceIndex].roadMaterials.Length];
			Array.Copy(crossingElements[sourceIndex].roadMaterials, crossingElements[index].roadMaterials, crossingElements[sourceIndex].roadMaterials.Length);
		}

		public static void OOQOQOCOQO()
		{
			ERCrossingPrefabs[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERCrossingPrefabs)) as ERCrossingPrefabs[];
			ERCrossingPrefabs[] array2 = array;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				if (eRCrossingPrefabs.surfaceObject != null)
				{
					if (eRCrossingPrefabs.gameObject.GetComponent<ERCrossings>() != null && eRCrossingPrefabs.surfaceObject != null)
					{
						OCDCCCQDCC.ODOODDQDOD(eRCrossingPrefabs, eRCrossingPrefabs.tmpMeshVecs, ref eRCrossingPrefabs.surfaceMeshVecs);
					}
				}
				else if (eRCrossingPrefabs.gameObject.GetComponent<ERRoundabouts>() != null && eRCrossingPrefabs.surfaceObject != null)
				{
					OQOQODQOCO.OCODQQCQQO(eRCrossingPrefabs, eRCrossingPrefabs.tmpMeshVecs, ref eRCrossingPrefabs.surfaceMeshVecs);
				}
				else if (eRCrossingPrefabs.isCustomPrefab && eRCrossingPrefabs.doTerrainDeformation && eRCrossingPrefabs.surfaceObject != null && eRCrossingPrefabs.crossingElements.Count > 0)
				{
					OCCQCCQOQD.OCQDQCQDOQ(eRCrossingPrefabs, eRCrossingPrefabs.baseScript);
				}
			}
		}

		public static bool OOOOCDQQOC(Vector3 pTarget, Vector3 pSource, Vector3 pCheck)
		{
			Vector3 normalized = (pTarget - pSource).normalized;
			Vector3 normalized2 = (pCheck - pSource).normalized;
			if (Vector3.Cross(normalized, normalized2).y < 0f)
			{
				return false;
			}
			return true;
		}
	}
}
