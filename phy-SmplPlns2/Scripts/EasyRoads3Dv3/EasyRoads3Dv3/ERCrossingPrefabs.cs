using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERCrossingPrefabs : MonoBehaviour
	{
		[Serializable]
		private sealed class ussst
		{
			public static readonly ussst _003C_003E9 = new ussst();

			public static Comparison<ERConnectionSibling> _003C_003E9__127_0;

			public static Comparison<ERConnectionSibling> _003C_003E9__144_0;

			public static Comparison<ERConnectionSibling> _003C_003E9__151_0;

			internal int _003CUpdateSurfacesTriangulation_003Eb__127_0(ERConnectionSibling x, ERConnectionSibling y)
			{
				return x.angle.CompareTo(y.angle);
			}

			internal int _003CSetSidewalkState_003Eb__144_0(ERConnectionSibling x, ERConnectionSibling y)
			{
				return x.angle.CompareTo(y.angle);
			}

			internal int _003COOOOQOOCQO_003Eb__151_0(ERConnectionSibling x, ERConnectionSibling y)
			{
				return x.angle.CompareTo(y.angle);
			}
		}

		[HideInInspector]
		public List<QDOODOQQDQODD> crossingElements = new List<QDOODOQQDQODD>();

		[HideInInspector]
		public List<QDOQDSQOOQDDD> sidewalkControlElements = new List<QDOQDSQOOQDDD>();

		[HideInInspector]
		public List<ERConnectionSibling> siblings = new List<ERConnectionSibling>();

		[HideInInspector]
		public List<ERConnectionSibling> orderedSiblings = new List<ERConnectionSibling>();

		[HideInInspector]
		public List<ERConnectionSibling> priorityRoads = new List<ERConnectionSibling>();

		[HideInInspector]
		public float turnSWAroundCornerThreshold = 5f;

		[HideInInspector]
		public Vector3[] meshVecs = new Vector3[0];

		[HideInInspector]
		public Vector3[] fullMeshVecs = new Vector3[0];

		[HideInInspector]
		public Vector3[] tmpMeshVecs = new Vector3[0];

		[HideInInspector]
		public Vector3[] tmpFullMeshVecs = new Vector3[0];

		[HideInInspector]
		public Vector3[] tCrossingTmpFullMeshVecs = new Vector3[0];

		[HideInInspector]
		public int[] outerVecInts = new int[0];

		[HideInInspector]
		public List<Vector3> surfaceVecs = new List<Vector3>();

		[HideInInspector]
		public List<int> surfaceVecType = new List<int>();

		[HideInInspector]
		public List<int> surfaceConnectionInt = new List<int>();

		[HideInInspector]
		public List<ERBlendVecs> tCrossingBlendData = new List<ERBlendVecs>();

		[HideInInspector]
		public List<ERChildObject> childObjects = new List<ERChildObject>();

		[HideInInspector]
		public List<Vector3> indentVecs = new List<Vector3>();

		[HideInInspector]
		public GameObject sourcePrefab;

		public int prefabId = 0;

		[HideInInspector]
		public string guid = "";

		[HideInInspector]
		public List<int> prioritySegments = new List<int>();

		[HideInInspector]
		public float minNodeDistance = 3f;

		[HideInInspector]
		public int nodeWithinRange = -1;

		[HideInInspector]
		public GameObject sourceObject;

		[HideInInspector]
		public bool meshInstance = false;

		[HideInInspector]
		public int selectedConnection = -1;

		[HideInInspector]
		public string[] QDOOOQOOQQQQD = new string[0];

		public bool deformTerrain = true;

		public bool isRoundabout = false;

		public bool isERCrossing = false;

		public bool isERCrossingExt = false;

		public bool isYConnector = false;

		public bool isIConnector = false;

		public bool isFlexConnector = false;

		[HideInInspector]
		public int priorityRoadCount = 0;

		public bool isSnapConnector = false;

		public bool isExitRoadConnector = false;

		[HideInInspector]
		public Vector3 prefabCenterDummy;

		[HideInInspector]
		public float snapRadius = 3f;

		[HideInInspector]
		public ERRoundabouts roundaboutScript;

		[HideInInspector]
		public ERCrossings crossingsScript;

		[HideInInspector]
		public ERIConnector iConnectorScript;

		public bool isTerrainEdgeConnector = false;

		public bool isCustomPrefab = false;

		[HideInInspector]
		public int customPrefabVersion = 0;

		[HideInInspector]
		public bool recalculateNormals = false;

		[HideInInspector]
		public bool planarUVs = false;

		[HideInInspector]
		public float planarTiling = 1f;

		[HideInInspector]
		public int lastVecRoadIndex = 0;

		[HideInInspector]
		public bool isSceneObject = true;

		[HideInInspector]
		public GameObject surfaceObject;

		[HideInInspector]
		public Vector3[] surfaceMeshVecs = null;

		[HideInInspector]
		public Vector3[] tmpSurfaceMeshVecs = null;

		[HideInInspector]
		public Vector3[] tmpSurfaceVecsTCrossings = new Vector3[0];

		[HideInInspector]
		public int[] surfaceInts;

		[HideInInspector]
		public Vector3 leftBottomCorner;

		[HideInInspector]
		public Vector3 leftTopCorner;

		[HideInInspector]
		public Vector3 rightBottomCorner;

		[HideInInspector]
		public Vector3 rightTopCorner;

		[HideInInspector]
		public bool tCrossing = false;

		[HideInInspector]
		public bool tStraightBending = true;

		[HideInInspector]
		public int tCrossingLeftRight = 1;

		[HideInInspector]
		public float tMainRoadWidth = 0f;

		[HideInInspector]
		public float tConnectionRoadWidth = 0f;

		[HideInInspector]
		public float bottomLeftSidewalkWidth = 0f;

		[HideInInspector]
		public float bottomLeftSidewalkOuterOffset = 0f;

		[HideInInspector]
		public float bottomLeftSidewalkCurbDepth = 0f;

		[HideInInspector]
		public float bottomRightSidewalkWidth = 0f;

		[HideInInspector]
		public float bottomRightSidewalkOuterOffset = 0f;

		[HideInInspector]
		public float bottomRightSidewalkCurbDepth = 0f;

		[HideInInspector]
		public float topLeftSidewalkWidth = 0f;

		[HideInInspector]
		public float topLeftSidewalkOuterOffset = 0f;

		[HideInInspector]
		public float topLeftSidewalkCurbDepth = 0f;

		[HideInInspector]
		public float topRightSidewalkWidth = 0f;

		[HideInInspector]
		public float topRightSidewalkOuterOffset = 0f;

		[HideInInspector]
		public float topRightSidewalkCurbDepth = 0f;

		[HideInInspector]
		public bool v32Sidewalks = true;

		[HideInInspector]
		public ERConnection connObject;

		[HideInInspector]
		public Vector3 testVec;

		[HideInInspector]
		public List<int> surfaceSurroundingInts = new List<int>();

		[HideInInspector]
		public int rotationPriorityElement = -1;

		[HideInInspector]
		public Vector3 cornerPos;

		[HideInInspector]
		public Vector3 mainCorner;

		[HideInInspector]
		public Vector3 connectedCorner;

		[HideInInspector]
		public Vector3 mainVecOuter;

		[HideInInspector]
		public Vector3 connectionVecOuter;

		[HideInInspector]
		public Vector3 indentTopVec;

		[HideInInspector]
		public Vector3 indentRightVec;

		[HideInInspector]
		public Vector3 mainIndent;

		[HideInInspector]
		public Vector3 connectionIndent;

		[HideInInspector]
		public int selectedRotationConnection = 0;

		[HideInInspector]
		public Vector3 bottomVec;

		[HideInInspector]
		public Vector3 rightVec;

		[HideInInspector]
		public Vector3 bottomIndent;

		[HideInInspector]
		public Vector3 rightIndent;

		[HideInInspector]
		public float sAngle = 90f;

		[HideInInspector]
		public ERModularBase baseScript;

		[HideInInspector]
		public bool QDQDQOOQQDQOQQ = false;

		[HideInInspector]
		public Vector3 tp1;

		[HideInInspector]
		public Vector3 tp2;

		[HideInInspector]
		public bool doTerrainDeformation = true;

		[HideInInspector]
		public bool includeOuterVertices = true;

		public bool averageNormals = true;

		[HideInInspector]
		public float surroundingDistance = 0f;

		[HideInInspector]
		public Mesh surfaceMesh = null;

		[HideInInspector]
		public List<Vector3> debugVecs1 = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> debugVecs2 = new List<Vector3>();

		[HideInInspector]
		public bool lightmapAdjusted = false;

		[HideInInspector]
		public bool isFlexUpdating = false;

		[HideInInspector]
		public Vector3 oldPosition;

		[HideInInspector]
		public Vector3 oldRotation;

		[HideInInspector]
		public bool lockScale = true;

		[HideInInspector]
		public float extraIndentMargin = 0f;

		[HideInInspector]
		public float indent = 0f;

		[HideInInspector]
		public float surrounding = 0f;

		[HideInInspector]
		public bool customTriangulation = false;

		[HideInInspector]
		public bool roundingPointsSet = false;

		[HideInInspector]
		public bool signPostsSet = false;

		[HideInInspector]
		public bool displayLaneData = true;

		public void OCODCDCDQQ()
		{
			if (base.gameObject.GetComponent<MeshFilter>() != null && base.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				Vector3[] vertices = base.gameObject.GetComponent<MeshFilter>().sharedMesh.vertices;
				meshVecs = new Vector3[vertices.Length];
				Array.Copy(vertices, meshVecs, 0);
				meshVecs = vertices;
			}
		}

		public void OCODOODQQQ(Vector3 v1, Vector3 v2, int connectionElement, ERModularRoad road)
		{
			ODOCOODDOD(connectionElement);
			Vector3 normalized = (v1 - v2).normalized;
			Vector3 normalized2 = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
			Vector3 vector = v2 + normalized2;
			float num = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f;
			num -= crossingElements[connectionElement].centerPointAngle;
			Vector3 eulerAngles = base.transform.eulerAngles;
			if (OOCQODQDQD(base.transform.position, v1, v2))
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
			ODOQCOOOCC(ignorePriority: true, road);
		}

		public void ODOCOODDOD(int el)
		{
			Vector3 normalized = (crossingElements[el].controlPointV3 - crossingElements[el].centerPoint).normalized;
			crossingElements[el].centerPointAngle = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f;
		}

		public void ODDDCQQOOQ(int elInt, float distance)
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
					if ((bool)base.transform.parent && (bool)base.transform.parent.parent)
					{
						baseScript = base.transform.parent.parent.GetComponent<ERModularBase>();
					}
					if (baseScript == null)
					{
						baseScript = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
						if (baseScript == null)
						{
							return;
						}
					}
				}
				baseScript.OCQDOOQQDC(this);
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
				tmpFullMeshVecs = OCQDCOOCOO.OQOQDOCOCQ(this, elInt, controlPoints, distance, defaultDistance, fullMeshVecs, ref tCrossingTmpFullMeshVecs, multiplyFactor, angle, curveStrength);
				if (crossingsScript == null)
				{
					crossingsScript = base.gameObject.GetComponent<ERCrossings>();
				}
				tmpFullMeshVecs = OOCOCCQDOD.OCDCDOQCOC(crossingsScript, tmpFullMeshVecs);
				tmpFullMeshVecs = ERSideWalkVecs.SnapSidewalkCornersVecs(crossingsScript, tmpFullMeshVecs);
				mesh.vertices = tmpFullMeshVecs;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mesh.normals = ERSideWalkVecs.OQQDDCOQDD(crossingsScript, mesh.normals);
				mesh.RecalculateTangents();
				qDOODOQQDQODD.tmpCenterPoint = Vector3.Lerp(tmpFullMeshVecs[qDOODOQQDQODD.fullConnectionVecInts[0]], tmpFullMeshVecs[qDOODOQQDQODD.fullConnectionVecInts[qDOODOQQDQODD.fullConnectionVecInts.Count - 1]], qDOODOQQDQODD.centerPointPercentage);
				qDOODOQQDQODD.tmpCenterPoint.y = 0f;
				if (tmpSurfaceMeshVecs == null)
				{
					tmpSurfaceMeshVecs = new Vector3[surfaceMeshVecs.Length];
					Array.Copy(surfaceMeshVecs, tmpSurfaceMeshVecs, surfaceMeshVecs.Length);
					tmpSurfaceVecsTCrossings = new Vector3[surfaceMeshVecs.Length];
					Array.Copy(surfaceMeshVecs, tmpSurfaceVecsTCrossings, surfaceMeshVecs.Length);
				}
				tmpSurfaceMeshVecs = OCQDCOOCOO.OOOCDQDQDD(this, elInt, controlPoints, distance, defaultDistance, surfaceMeshVecs, ref tmpSurfaceVecsTCrossings, multiplyFactor, angle, curveStrength);
				OCOCODQQDC.OQCODOOQOO(this, elInt);
				OCOCODQQDC.OQOOOCDQQD(this);
				if (crossingElements[2].connectedRoad != null && crossingElements[elInt].connectedRoad != crossingElements[2].connectedRoad)
				{
					crossingElements[2].connectedRoad.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
				if (crossingElements[3].connectedRoad != null && crossingElements[elInt].connectedRoad != crossingElements[3].connectedRoad)
				{
					crossingElements[3].connectedRoad.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
			}
		}

		public void OQOCCQOQOQ(List<int> affectedVecs, List<Vector2> tmpVecs)
		{
			Vector3[] array = (Vector3[])meshVecs.Clone();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].x = tmpVecs[i].x;
				array[i].z = tmpVecs[i].y;
			}
			base.gameObject.GetComponent<MeshFilter>().sharedMesh.vertices = array;
		}

		public void ODOQCOOOCC(bool ignorePriority, ERModularRoad road)
		{
			if (baseScript == null)
			{
				if ((bool)base.transform.parent && (bool)base.transform.parent.parent)
				{
					baseScript = base.transform.parent.parent.GetComponent<ERModularBase>();
				}
				if (baseScript == null)
				{
					baseScript = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
					if (baseScript == null)
					{
						return;
					}
				}
			}
			if (isCustomPrefab)
			{
				ODCQOCQODQ(forceFlag: false);
			}
			else if (baseScript.surfaceChangeFlag)
			{
				UpdateSurfacesTriangulation();
			}
			if (tmpSurfaceMeshVecs == null)
			{
				if (surfaceMeshVecs == null)
				{
					surfaceMeshVecs = new Vector3[0];
				}
				Debug.Log(surfaceMeshVecs.Length);
				tmpSurfaceMeshVecs = new Vector3[surfaceMeshVecs.Length];
				Array.Copy(surfaceMeshVecs, tmpSurfaceMeshVecs, surfaceMeshVecs.Length);
			}
			else if (tmpSurfaceMeshVecs.Length == 0)
			{
				tmpSurfaceMeshVecs = new Vector3[surfaceMeshVecs.Length];
				Array.Copy(surfaceMeshVecs, tmpSurfaceMeshVecs, surfaceMeshVecs.Length);
			}
			OCOCODQQDC.OQOOOCDQQD(this);
			CheckPlanarUVs();
			if (baseScript.aiTraffic && !isFlexConnector && !isCustomPrefab && crossingsScript != null)
			{
				if (siblings.Count == 0)
				{
					PopulateSiblingsList();
				}
				bool hasLaneControlData = false;
				for (int i = 0; i < siblings.Count; i++)
				{
					if (siblings[i] == null)
					{
						return;
					}
					if (siblings[i].laneData == null)
					{
						siblings[i].laneData = ERLaneData.CreateInstance();
					}
					ERLaneData laneData = siblings[i].laneData;
					if (laneData.connectors.Count > 0)
					{
						hasLaneControlData = true;
					}
					siblings[i].dir = -crossingElements[i].centerPoint.normalized;
					if (siblings[i].rightRoundingPoints.Count == 0)
					{
						siblings[i].rightRoundingPoints.Add(crossingElements[i].rightRoadpoint);
					}
					else
					{
						siblings[i].rightRoundingPoints[0] = crossingElements[i].rightRoadpoint;
					}
					if (siblings[i].leftRoundingPoints.Count == 0)
					{
						siblings[i].leftRoundingPoints.Add(crossingElements[i].leftRoadpoint);
					}
					else
					{
						siblings[i].leftRoundingPoints[0] = crossingElements[i].leftRoadpoint;
					}
				}
				if (crossingsScript == null)
				{
					crossingsScript = base.gameObject.GetComponent<ERCrossings>();
				}
				QDDDQODDQDQDQDD.OOQOOODDOC(crossingsScript, null);
				QDDDQODDQDQDQDD.OCQDDQCOCC(hasLaneControlData);
			}
			Vector3 position = base.transform.position;
			Vector3 eulerAngles = base.transform.eulerAngles;
			List<ERModularRoad> list = new List<ERModularRoad>();
			for (int j = 0; j < crossingElements.Count; j++)
			{
				if (!(crossingElements[j].connectedRoad != null) || !(!crossingElements[j].rotationPriority || ignorePriority))
				{
					continue;
				}
				ERModularRoad component = crossingElements[j].connectedRoad.GetComponent<ERModularRoad>();
				bool flag = false;
				if (crossingElements[j].connectedMarker == 0)
				{
					if (component.startConnectionSegment == j && component.startPrefabScript == this)
					{
						flag = true;
					}
				}
				else if (component.endConnectionSegment == j && component.endPrefabScript == this)
				{
					flag = true;
				}
				if (!flag)
				{
					continue;
				}
				Vector3 position2 = base.transform.TransformPoint(crossingElements[j].centerPoint);
				if (!isIConnector)
				{
					if (component.markersExt.Count <= crossingElements[j].connectedMarker || crossingElements[j].connectedMarker < 0)
					{
						crossingElements[j].connectedRoad = null;
						return;
					}
					component.markersExt[crossingElements[j].connectedMarker].position = position2;
				}
				int num = crossingElements[j].roadShapeVecs.Count + crossingElements[j].sidewalkLeftVecs.Count + crossingElements[j].sidewalkRightVecs.Count;
				if (crossingElements[j].roadType == crossingElements[j].connectedRoad.roadType || crossingElements[j].connectedRoad.roadType == 0.0)
				{
					bool flag2 = false;
					if (!isIConnector && !isCustomPrefab && crossingElements[j].roadShapeVecsString != crossingElements[j].connectedRoad.roadShapeString)
					{
						flag2 = true;
					}
					if (!isIConnector && isCustomPrefab && crossingElements[j].roadShapeMatchCount != crossingElements[j].connectedRoad.roadShapeMatchCount)
					{
						flag2 = true;
					}
					if (flag2)
					{
						crossingElements[j].connectedRoad.nodeWithinRange = crossingElements[j].connectedMarker;
						if (crossingElements[j].connectedMarker == 0)
						{
							crossingElements[j].connectedRoad.OODCDQQQDD(this, j, reverse: true, uvReverse: true, UpdateResolutionFlag: false);
							OQQCQDQDCC.OOQQCCCCOO(baseScript, this, j, crossingElements[j].connectedRoad, 0);
						}
						else
						{
							crossingElements[j].connectedRoad.OODCDQQQDD(this, j, reverse: false, uvReverse: false, UpdateResolutionFlag: false);
							OQQCQDQDCC.OOQQCCCCOO(baseScript, this, j, crossingElements[j].connectedRoad, 1);
						}
					}
				}
				bool flag3 = false;
				if (isFlexConnector && siblings.Count > j && !siblings[j].hasChanged && oldPosition == position && oldRotation == eulerAngles)
				{
					flag3 = true;
				}
				if (OCQDDCDOOD(list, component) && !flag3)
				{
					list.Add(component);
				}
			}
			oldPosition = position;
			oldRotation = eulerAngles;
			for (int k = 0; k < list.Count; k++)
			{
				if (road != list[k])
				{
					list[k].ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
			}
			ERCrossingPrefabs[] componentsInChildren = base.gameObject.GetComponentsInChildren<ERCrossingPrefabs>();
			ERCrossingPrefabs[] array = componentsInChildren;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array)
			{
				if (eRCrossingPrefabs != this && eRCrossingPrefabs.transform != base.transform)
				{
					eRCrossingPrefabs.ODOQCOOOCC(ignorePriority: true, null);
				}
			}
		}

		public void UpdateSurfacesTriangulation()
		{
			if (isFlexConnector)
			{
				if (deformTerrain)
				{
					List<ERConnectionSibling> list = new List<ERConnectionSibling>(siblings);
					list.Sort((ERConnectionSibling x, ERConnectionSibling y) => x.angle.CompareTo(y.angle));
					OCDDOODQDQ.UpdateYCrossingSurfaces(this, tmpMeshVecs, list, ref surfaceMeshVecs);
				}
				else if (surfaceObject != null)
				{
					UnityEngine.Object.DestroyImmediate(surfaceObject);
				}
			}
			else if (isRoundabout)
			{
				OCDDOODQDQ.ODDDOQCCCD(this, tmpMeshVecs, ref surfaceMeshVecs);
			}
			else if (isCustomPrefab)
			{
				OODDOCOCOC.OCOOOQCCCQ(this, baseScript, doTerrainDeformation);
				ODCQOCQODQ(forceFlag: false);
			}
			else if (!isERCrossingExt)
			{
				OCOCODQQDC.OCDDDCQOQQ(this, tmpMeshVecs, ref surfaceMeshVecs);
			}
		}

		public void ODDDOQCCCD()
		{
			ODCQOCQODQ(forceFlag: false);
			CheckPlanarUVs();
			if (isERCrossing && !isRoundabout && !isFlexConnector && !isCustomPrefab)
			{
				OCOCODQQDC.OCDDDCQOQQ(this, tmpMeshVecs, ref surfaceMeshVecs);
			}
			else if (isRoundabout)
			{
				OCDDOODQDQ.ODDDOQCCCD(this, tmpMeshVecs, ref surfaceMeshVecs);
			}
		}

		public void ODCQOCQODQ(bool forceFlag)
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
			if (doTerrainDeformation || !doTerrainDeformation)
			{
				if ((isCustomPrefab && surroundingDistance != baseScript.minSurrounding) || (isCustomPrefab && surfaceMesh == null) || forceFlag || baseScript.surfaceChangeFlag)
				{
					if (crossingElements.Count > 0)
					{
						OODDOCOCOC.OCOOOQCCCQ(this, baseScript, doTerrainDeformation);
					}
					else
					{
						OODDOCOCOC.OCOOOQCCCQ(this, baseScript, doTerrainDeformation);
						doTerrainDeformation = false;
						Debug.Log("EasyRoads3Dv3 Alert: this prefab does not have connections, terrain deformation is not supported yet for this type of prefabs");
					}
					surroundingDistance = baseScript.minSurrounding;
					surfaceMesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
					OCOCODQQDC.OQOOOCDQQD(this);
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
					uv[i] = new Vector2(vector.x, vector.z) * planarTiling;
				}
				sharedMesh.uv = uv;
			}
		}

		public static bool OCQDDCDOOD(List<ERModularRoad> affectedObjects, ERModularRoad roadScr)
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

		public void ODCQOOCOQQ(bool flag)
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

		public void OQOCQDCCQC(int el)
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

		public void OCQQOODQOQ()
		{
			if (crossingsScript == null)
			{
				crossingsScript = base.gameObject.GetComponent<ERCrossings>();
				if (crossingsScript == null)
				{
					return;
				}
			}
			for (int i = 0; i < siblings.Count; i++)
			{
				QDOODOQQDQODD qDOODOQQDQODD = crossingElements[i];
				List<Vector3> list = new List<Vector3>();
				if (!(qDOODOQQDQODD.connectedRoad != null))
				{
					continue;
				}
				if (qDOODOQQDQODD.connectedRoad.startPrefabScript == this && qDOODOQQDQODD.connectedRoad.startConnectionSegment == i)
				{
					for (int j = 0; j < 3; j++)
					{
						if (qDOODOQQDQODD.connectedRoad.markersExt.Count > j)
						{
							list.Add(qDOODOQQDQODD.connectedRoad.markersExt[j].position);
						}
						else
						{
							list.Add(qDOODOQQDQODD.connectedRoad.markersExt[1].position);
						}
					}
				}
				else if (qDOODOQQDQODD.connectedRoad.endPrefabScript == this && qDOODOQQDQODD.connectedRoad.endConnectionSegment == i)
				{
					for (int num = qDOODOQQDQODD.connectedRoad.markersExt.Count - 1; num >= 0; num--)
					{
						list.Add(qDOODOQQDQODD.connectedRoad.markersExt[num].position);
					}
					if (list.Count == 2)
					{
						list.Add(qDOODOQQDQODD.connectedRoad.markersExt[0].position);
					}
				}
				crossingsScript.OCDCOCDODQ(i, list[0], list[1], list[2], update: false);
				siblings[i].angle = 360f - QDDDQODDQDQDQDD.OCCQDDQQCD(siblings[i].angleControlPoint, Vector3.forward, Vector3.up);
			}
		}

		public void OCQOOCQDOQ(int el, int startend)
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
					base.gameObject.GetComponent<ERIConnector>().ODDDQDQOOD(null);
				}
			}
			else if (crossingElements[0].connectedRoad == null)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
			}
			else
			{
				base.gameObject.GetComponent<ERIConnector>().ODDDQDQOOD(null);
			}
		}

		public void PopulateSiblingsList()
		{
			for (int i = 0; i < crossingElements.Count; i++)
			{
				siblings.Add(ERConnectionSibling.CreateInstance(null, 0f, crossingElements[i].centerPoint, null, null));
				if (crossingElements[i].connectedRoad != null)
				{
					siblings[i].road = crossingElements[i].connectedRoad;
				}
				siblings[i].roadTypeIndex = QDQDOOQQDQODD.GetRoadTypeByID(baseScript.roadTypes, crossingElements[i].roadType);
				siblings[i].roadType = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, crossingElements[i].roadType);
			}
			QDDDQODDQDQDQDD.OOQOOODDOC(crossingsScript, null);
		}

		public void InitFlexConnector(bool updateRoadTypes)
		{
			for (int i = 0; i < crossingElements.Count; i++)
			{
				int num = 0;
				int num2 = 0;
				if (!(crossingElements[i].connectedRoad != null))
				{
					continue;
				}
				if (crossingElements[i].connectedRoad.startPrefabScript == this)
				{
					crossingElements[i].connectedRoad.markersExt[0].roadShape = new List<Vector2>(crossingElements[i].connectedRoad.roadShape);
					if (crossingElements[i].connectedRoad.endPrefabScript == this && crossingElements[i].connectedRoad.endConnectionSegment == i)
					{
						if (tCrossing && i == 3)
						{
							crossingElements[i].connectedRoad.endConnectionSegment--;
						}
						continue;
					}
					crossingElements[i].connectedRoad.startConnectionSegment = i;
					if (tCrossing && i == 3)
					{
						crossingElements[i].connectedRoad.startConnectionSegment--;
					}
				}
				else if (crossingElements[i].connectedRoad.endPrefabScript == this)
				{
					crossingElements[i].connectedRoad.markersExt[crossingElements[i].connectedRoad.markersExt.Count - 1].roadShape = new List<Vector2>(crossingElements[i].connectedRoad.roadShape);
					crossingElements[i].connectedRoad.endConnectionSegment = i;
					if (tCrossing && i == 3)
					{
						crossingElements[i].connectedRoad.endConnectionSegment--;
					}
				}
			}
			siblings.Clear();
			bool flag = tCrossing;
			bool flag2 = false;
			int num3 = 0;
			for (int j = 0; j < crossingElements.Count; j++)
			{
				if (crossingElements[j].connectedRoad != null)
				{
					flag2 = true;
					num3++;
				}
			}
			if (num3 <= 8)
			{
				for (int k = 0; k < crossingElements.Count; k++)
				{
					if (tCrossing)
					{
						if (tCrossingLeftRight == 1 && k == 2)
						{
							if (crossingElements[3].connectedRoad != null)
							{
							}
							crossingElements.RemoveAt(k);
							tCrossing = false;
							k--;
							continue;
						}
						if (tCrossingLeftRight == 0 && k == 3)
						{
							crossingElements.RemoveAt(k);
							tCrossing = false;
							continue;
						}
					}
					siblings.Add(ERConnectionSibling.CreateInstance(null, 0f, crossingElements[k].centerPoint, null, null));
					if (!updateRoadTypes || crossingElements[k].connectedRoad == null)
					{
						siblings[k].roadTypeIndex = QDQDOOQQDQODD.GetRoadTypeByID(baseScript.roadTypes, crossingElements[k].roadType);
						siblings[k].roadType = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, crossingElements[k].roadType, clone: true);
					}
					else
					{
						siblings[k].roadTypeIndex = QDQDOOQQDQODD.GetRoadTypeByID(baseScript.roadTypes, crossingElements[k].connectedRoad.roadType);
						siblings[k].roadType = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, crossingElements[k].connectedRoad.roadType, clone: true);
					}
					if (siblings[k].roadType.cornerSementsMainRoad != 0)
					{
						siblings[k].defaultSegments = (siblings[k].cornerSegments = (siblings[k].defaultCornerSegments = siblings[k].roadType.cornerSementsMainRoad));
						siblings[k].radius = (siblings[k].defaultRadius = siblings[k].roadType.cornerRadiusMainRoad);
						siblings[k].leftCornerAngle = (siblings[k].rightCornerAngle = (siblings[k].defaultLeftCornerAngle = (siblings[k].defaultRightCornerAngle = siblings[k].roadType.cornerRadiusSecondaryCurvature)));
					}
					if (crossingElements[k].connectedRoad != null)
					{
						siblings[k].road = crossingElements[k].connectedRoad;
						if (siblings[k].road.startPrefabScript == this)
						{
							ActivateSidewalks(k, 0);
						}
						else
						{
							ActivateSidewalks(k, 1);
						}
					}
				}
				if (!flag && sidewalkControlElements.Count > 0)
				{
					if (sidewalkControlElements[0].renderFlag)
					{
						int index = 0;
						ERSideWalk eRSideWalk = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index].sidewalkWidth1, sidewalkControlElements[index].curbHeight, sidewalkControlElements[index].curbDepth, sidewalkControlElements[index].beveledCurb, sidewalkControlElements[index].beveledHeight, sidewalkControlElements[index].beveledDepth, sidewalkControlElements[index].outerCurb, sidewalkControlElements[index].sidewalkUVs, sidewalkControlElements[index].sidewalkMaterial);
						siblings[0].rightSidewalkActive = true;
						siblings[0].rightSidewalkid = eRSideWalk.id;
						siblings[0].rightSidewalk = eRSideWalk;
						if (siblings[0].roadType.crosswalksIntersections && eRSideWalk.crosswalkPavement)
						{
							siblings[0].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[0].rightConnectionHandle)
						{
							if (siblings[0].road.startPrefabScript == this)
							{
								siblings[0].road.leftSidewalkActive = true;
								siblings[0].road.defaultLeftSidewalkid = eRSideWalk.id;
							}
							else
							{
								siblings[0].road.rightSidewalkActive = true;
								siblings[0].road.defaultRightSidewalkid = eRSideWalk.id;
							}
						}
						siblings[3].leftSidewalkActive = true;
						siblings[3].leftSidewalkid = eRSideWalk.id;
						siblings[3].leftSidewalk = eRSideWalk;
						if (siblings[3].roadType.crosswalksIntersections && eRSideWalk.crosswalkPavement)
						{
							siblings[3].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[0].leftConnectionHandle && siblings[3].road != null)
						{
							if (siblings[3].road.startPrefabScript == this)
							{
								siblings[3].road.rightSidewalkActive = true;
								siblings[3].road.defaultRightSidewalkid = eRSideWalk.id;
							}
							else
							{
								siblings[3].road.leftSidewalkActive = true;
								siblings[3].road.defaultLeftSidewalkid = eRSideWalk.id;
							}
						}
					}
					if (sidewalkControlElements[1].renderFlag)
					{
						int index2 = 1;
						ERSideWalk eRSideWalk2 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index2].sidewalkWidth1, sidewalkControlElements[index2].curbHeight, sidewalkControlElements[index2].curbDepth, sidewalkControlElements[index2].beveledCurb, sidewalkControlElements[index2].beveledHeight, sidewalkControlElements[index2].beveledDepth, sidewalkControlElements[index2].outerCurb, sidewalkControlElements[index2].sidewalkUVs, sidewalkControlElements[index2].sidewalkMaterial);
						siblings[0].leftSidewalkActive = true;
						siblings[0].leftSidewalkid = eRSideWalk2.id;
						siblings[0].leftSidewalk = eRSideWalk2;
						if (siblings[0].roadType.crosswalksIntersections && eRSideWalk2.crosswalkPavement)
						{
							siblings[0].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[1].leftConnectionHandle)
						{
							if (siblings[0].road.startPrefabScript == this)
							{
								siblings[0].road.rightSidewalkActive = true;
								siblings[0].road.defaultRightSidewalkid = eRSideWalk2.id;
							}
							else
							{
								siblings[0].road.leftSidewalkActive = true;
								siblings[0].road.defaultLeftSidewalkid = eRSideWalk2.id;
							}
						}
						siblings[2].rightSidewalkActive = true;
						siblings[2].rightSidewalkid = eRSideWalk2.id;
						siblings[2].rightSidewalk = eRSideWalk2;
						if (siblings[2].roadType.crosswalksIntersections && eRSideWalk2.crosswalkPavement)
						{
							siblings[2].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[1].rightConnectionHandle && siblings[2].road != null)
						{
							if (siblings[2].road.startPrefabScript == this)
							{
								siblings[2].road.leftSidewalkActive = true;
								siblings[2].road.defaultLeftSidewalkid = eRSideWalk2.id;
							}
							else
							{
								siblings[2].road.rightSidewalkActive = true;
								siblings[2].road.defaultRightSidewalkid = eRSideWalk2.id;
							}
						}
					}
					if (sidewalkControlElements[2].renderFlag)
					{
						int index3 = 2;
						ERSideWalk eRSideWalk3 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index3].sidewalkWidth1, sidewalkControlElements[index3].curbHeight, sidewalkControlElements[index3].curbDepth, sidewalkControlElements[index3].beveledCurb, sidewalkControlElements[index3].beveledHeight, sidewalkControlElements[index3].beveledDepth, sidewalkControlElements[index3].outerCurb, sidewalkControlElements[index3].sidewalkUVs, sidewalkControlElements[index3].sidewalkMaterial);
						siblings[1].rightSidewalkActive = true;
						siblings[1].rightSidewalkid = eRSideWalk3.id;
						siblings[1].rightSidewalk = eRSideWalk3;
						if (siblings[1].roadType.crosswalksIntersections && eRSideWalk3.crosswalkPavement)
						{
							siblings[1].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[2].rightConnectionHandle)
						{
							if (siblings[1].road.startPrefabScript == this)
							{
								siblings[1].road.leftSidewalkActive = true;
								siblings[1].road.defaultLeftSidewalkid = eRSideWalk3.id;
							}
							else
							{
								siblings[1].road.rightSidewalkActive = true;
								siblings[1].road.defaultRightSidewalkid = eRSideWalk3.id;
							}
						}
						siblings[2].leftSidewalkActive = true;
						siblings[2].leftSidewalkid = eRSideWalk3.id;
						siblings[2].leftSidewalk = eRSideWalk3;
						if (siblings[2].roadType.crosswalksIntersections && eRSideWalk3.crosswalkPavement)
						{
							siblings[2].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[2].leftConnectionHandle && siblings[2].road != null)
						{
							if (siblings[2].road.startPrefabScript == this)
							{
								siblings[2].road.rightSidewalkActive = true;
								siblings[2].road.defaultRightSidewalkid = eRSideWalk3.id;
							}
							else
							{
								siblings[2].road.leftSidewalkActive = true;
								siblings[2].road.defaultLeftSidewalkid = eRSideWalk3.id;
							}
						}
					}
					if (sidewalkControlElements[3].renderFlag)
					{
						int index4 = 3;
						ERSideWalk eRSideWalk4 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index4].sidewalkWidth1, sidewalkControlElements[index4].curbHeight, sidewalkControlElements[index4].curbDepth, sidewalkControlElements[index4].beveledCurb, sidewalkControlElements[index4].beveledHeight, sidewalkControlElements[index4].beveledDepth, sidewalkControlElements[index4].outerCurb, sidewalkControlElements[index4].sidewalkUVs, sidewalkControlElements[index4].sidewalkMaterial);
						siblings[1].leftSidewalkActive = true;
						siblings[1].leftSidewalkid = eRSideWalk4.id;
						siblings[1].leftSidewalk = eRSideWalk4;
						if (siblings[1].roadType.crosswalksIntersections && eRSideWalk4.crosswalkPavement)
						{
							siblings[1].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[3].leftConnectionHandle)
						{
							if (siblings[1].road.startPrefabScript == this)
							{
								siblings[1].road.rightSidewalkActive = true;
								siblings[1].road.defaultRightSidewalkid = eRSideWalk4.id;
							}
							else
							{
								siblings[1].road.leftSidewalkActive = true;
								siblings[1].road.defaultLeftSidewalkid = eRSideWalk4.id;
							}
						}
						siblings[3].rightSidewalkActive = true;
						siblings[3].rightSidewalkid = eRSideWalk4.id;
						siblings[3].rightSidewalk = eRSideWalk4;
						if (siblings[3].roadType.crosswalksIntersections && eRSideWalk4.crosswalkPavement)
						{
							siblings[3].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[3].rightConnectionHandle && siblings[3].road != null)
						{
							if (siblings[3].road.startPrefabScript == this)
							{
								siblings[3].road.leftSidewalkActive = true;
								siblings[3].road.defaultLeftSidewalkid = eRSideWalk4.id;
							}
							else
							{
								siblings[3].road.rightSidewalkActive = true;
								siblings[3].road.defaultRightSidewalkid = eRSideWalk4.id;
							}
						}
					}
				}
				else if (tCrossingLeftRight == 1 && sidewalkControlElements.Count > 0)
				{
					if (sidewalkControlElements[0].renderFlag)
					{
						int index5 = 0;
						ERSideWalk eRSideWalk5 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index5].sidewalkWidth1, sidewalkControlElements[index5].curbHeight, sidewalkControlElements[index5].curbDepth, sidewalkControlElements[index5].beveledCurb, sidewalkControlElements[index5].beveledHeight, sidewalkControlElements[index5].beveledDepth, sidewalkControlElements[index5].outerCurb, sidewalkControlElements[index5].sidewalkUVs, sidewalkControlElements[index5].sidewalkMaterial);
						siblings[0].rightSidewalkActive = true;
						siblings[0].rightSidewalkid = eRSideWalk5.id;
						siblings[0].rightSidewalk = eRSideWalk5;
						if (siblings[0].roadType.crosswalksIntersections && eRSideWalk5.crosswalkPavement)
						{
							siblings[0].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[0].rightConnectionHandle)
						{
							if (siblings[0].road.startPrefabScript == this)
							{
								siblings[0].road.leftSidewalkActive = true;
								siblings[0].road.defaultLeftSidewalkid = eRSideWalk5.id;
							}
							else
							{
								siblings[0].road.rightSidewalkActive = true;
								siblings[0].road.defaultRightSidewalkid = eRSideWalk5.id;
							}
						}
						siblings[2].leftSidewalkActive = true;
						siblings[2].leftSidewalkid = eRSideWalk5.id;
						siblings[2].leftSidewalk = eRSideWalk5;
						if (siblings[2].roadType.crosswalksIntersections && eRSideWalk5.crosswalkPavement)
						{
							siblings[2].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[0].leftConnectionHandle && siblings[2].road != null)
						{
							if (siblings[2].road.startPrefabScript == this)
							{
								siblings[2].road.rightSidewalkActive = true;
								siblings[2].road.defaultRightSidewalkid = eRSideWalk5.id;
							}
							else
							{
								siblings[2].road.leftSidewalkActive = true;
								siblings[2].road.defaultLeftSidewalkid = eRSideWalk5.id;
							}
						}
					}
					if (sidewalkControlElements[1].renderFlag)
					{
						int index6 = 1;
						ERSideWalk eRSideWalk6 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index6].sidewalkWidth1, sidewalkControlElements[index6].curbHeight, sidewalkControlElements[index6].curbDepth, sidewalkControlElements[index6].beveledCurb, sidewalkControlElements[index6].beveledHeight, sidewalkControlElements[index6].beveledDepth, sidewalkControlElements[index6].outerCurb, sidewalkControlElements[index6].sidewalkUVs, sidewalkControlElements[index6].sidewalkMaterial);
						siblings[0].leftSidewalkActive = true;
						siblings[0].leftSidewalkid = eRSideWalk6.id;
						siblings[0].leftSidewalk = eRSideWalk6;
						if (siblings[0].roadType.crosswalksIntersections && eRSideWalk6.crosswalkPavement)
						{
							siblings[0].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[1].leftConnectionHandle && siblings[0].road != null)
						{
							if (siblings[0].road.startPrefabScript == this)
							{
								siblings[0].road.rightSidewalkActive = true;
								siblings[0].road.defaultRightSidewalkid = eRSideWalk6.id;
							}
							else
							{
								siblings[0].road.leftSidewalkActive = true;
								siblings[0].road.defaultLeftSidewalkid = eRSideWalk6.id;
							}
						}
						siblings[1].rightSidewalkActive = true;
						siblings[1].rightSidewalkid = eRSideWalk6.id;
						siblings[1].rightSidewalk = eRSideWalk6;
						if (siblings[1].roadType.crosswalksIntersections && eRSideWalk6.crosswalkPavement)
						{
							siblings[1].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[1].rightConnectionHandle && siblings[1].road != null)
						{
							if (siblings[1].road.startPrefabScript == this)
							{
								siblings[1].road.leftSidewalkActive = true;
								siblings[1].road.defaultLeftSidewalkid = eRSideWalk6.id;
							}
							else
							{
								siblings[1].road.rightSidewalkActive = true;
								siblings[1].road.defaultRightSidewalkid = eRSideWalk6.id;
							}
						}
					}
					if (sidewalkControlElements[3].renderFlag)
					{
						int index7 = 3;
						ERSideWalk eRSideWalk7 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index7].sidewalkWidth1, sidewalkControlElements[index7].curbHeight, sidewalkControlElements[index7].curbDepth, sidewalkControlElements[index7].beveledCurb, sidewalkControlElements[index7].beveledHeight, sidewalkControlElements[index7].beveledDepth, sidewalkControlElements[index7].outerCurb, sidewalkControlElements[index7].sidewalkUVs, sidewalkControlElements[index7].sidewalkMaterial);
						siblings[1].leftSidewalkActive = true;
						siblings[1].leftSidewalkid = eRSideWalk7.id;
						siblings[1].leftSidewalk = eRSideWalk7;
						if (siblings[1].roadType.crosswalksIntersections && eRSideWalk7.crosswalkPavement)
						{
							siblings[1].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[3].leftConnectionHandle)
						{
							if (siblings[1].road.startPrefabScript == this)
							{
								siblings[1].road.rightSidewalkActive = true;
								siblings[1].road.defaultRightSidewalkid = eRSideWalk7.id;
							}
							else
							{
								siblings[1].road.leftSidewalkActive = true;
								siblings[1].road.defaultLeftSidewalkid = eRSideWalk7.id;
							}
						}
						siblings[2].rightSidewalkActive = true;
						siblings[2].rightSidewalkid = eRSideWalk7.id;
						siblings[2].rightSidewalk = eRSideWalk7;
						if (siblings[2].roadType.crosswalksIntersections && eRSideWalk7.crosswalkPavement)
						{
							siblings[2].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[3].rightConnectionHandle && siblings[2].road != null)
						{
							if (siblings[2].road.startPrefabScript == this)
							{
								siblings[2].road.leftSidewalkActive = true;
								siblings[2].road.defaultLeftSidewalkid = eRSideWalk7.id;
							}
							else
							{
								siblings[2].road.rightSidewalkActive = true;
								siblings[2].road.defaultRightSidewalkid = eRSideWalk7.id;
							}
						}
					}
				}
				else if (sidewalkControlElements.Count > 0)
				{
					if (sidewalkControlElements[0].renderFlag)
					{
						int index8 = 0;
						ERSideWalk eRSideWalk8 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index8].sidewalkWidth1, sidewalkControlElements[index8].curbHeight, sidewalkControlElements[index8].curbDepth, sidewalkControlElements[index8].beveledCurb, sidewalkControlElements[index8].beveledHeight, sidewalkControlElements[index8].beveledDepth, sidewalkControlElements[index8].outerCurb, sidewalkControlElements[index8].sidewalkUVs, sidewalkControlElements[index8].sidewalkMaterial);
						siblings[0].rightSidewalkActive = true;
						siblings[0].rightSidewalkid = eRSideWalk8.id;
						siblings[0].rightSidewalk = eRSideWalk8;
						if (siblings[0].roadType.crosswalksIntersections && eRSideWalk8.crosswalkPavement)
						{
							siblings[0].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[0].rightConnectionHandle)
						{
							if (siblings[0].road.startPrefabScript == this)
							{
								siblings[0].road.leftSidewalkActive = true;
								siblings[0].road.defaultLeftSidewalkid = eRSideWalk8.id;
							}
							else
							{
								siblings[0].road.rightSidewalkActive = true;
								siblings[0].road.defaultRightSidewalkid = eRSideWalk8.id;
							}
						}
						siblings[1].leftSidewalkActive = true;
						siblings[1].leftSidewalkid = eRSideWalk8.id;
						siblings[1].leftSidewalk = eRSideWalk8;
						if (siblings[1].roadType.crosswalksIntersections && eRSideWalk8.crosswalkPavement)
						{
							siblings[1].leftCrosswalkActive = true;
						}
						if ((sidewalkControlElements[0].leftConnectionHandle && !sidewalkControlElements[0].rightConnectionHandle) || (!sidewalkControlElements[0].leftConnectionHandle && !sidewalkControlElements[0].rightConnectionHandle) || (!sidewalkControlElements[0].leftConnectionHandle && sidewalkControlElements[0].rightConnectionHandle))
						{
							if (siblings[1].road.startPrefabScript == this)
							{
								siblings[1].road.rightSidewalkActive = true;
								siblings[1].road.defaultRightSidewalkid = eRSideWalk8.id;
							}
							else
							{
								siblings[1].road.leftSidewalkActive = true;
								siblings[1].road.defaultLeftSidewalkid = eRSideWalk8.id;
							}
						}
					}
					if (sidewalkControlElements[1].renderFlag)
					{
						int index9 = 1;
						ERSideWalk eRSideWalk9 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index9].sidewalkWidth1, sidewalkControlElements[index9].curbHeight, sidewalkControlElements[index9].curbDepth, sidewalkControlElements[index9].beveledCurb, sidewalkControlElements[index9].beveledHeight, sidewalkControlElements[index9].beveledDepth, sidewalkControlElements[index9].outerCurb, sidewalkControlElements[index9].sidewalkUVs, sidewalkControlElements[index9].sidewalkMaterial);
						siblings[0].leftSidewalkActive = true;
						siblings[0].leftSidewalkid = eRSideWalk9.id;
						siblings[0].leftSidewalk = eRSideWalk9;
						if (siblings[0].roadType.crosswalksIntersections && eRSideWalk9.crosswalkPavement)
						{
							siblings[0].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[1].leftConnectionHandle)
						{
							if (siblings[0].road.startPrefabScript == this)
							{
								siblings[0].road.rightSidewalkActive = true;
								siblings[0].road.defaultRightSidewalkid = eRSideWalk9.id;
							}
							else
							{
								siblings[0].road.leftSidewalkActive = true;
								siblings[0].road.defaultLeftSidewalkid = eRSideWalk9.id;
							}
						}
						siblings[2].rightSidewalkActive = true;
						siblings[2].rightSidewalkid = eRSideWalk9.id;
						siblings[2].rightSidewalk = eRSideWalk9;
						if (siblings[2].roadType.crosswalksIntersections && eRSideWalk9.crosswalkPavement)
						{
							siblings[2].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[1].rightConnectionHandle && siblings[2].road != null)
						{
							if (siblings[2].road.startPrefabScript == this)
							{
								siblings[2].road.leftSidewalkActive = true;
								siblings[2].road.defaultLeftSidewalkid = eRSideWalk9.id;
							}
							else
							{
								siblings[2].road.rightSidewalkActive = true;
								siblings[2].road.defaultRightSidewalkid = eRSideWalk9.id;
							}
						}
					}
					if (sidewalkControlElements[2].renderFlag)
					{
						int index10 = 2;
						ERSideWalk eRSideWalk10 = ERSideWalk.Upgrade(baseScript.sidewalks, sidewalkControlElements[index10].sidewalkWidth1, sidewalkControlElements[index10].curbHeight, sidewalkControlElements[index10].curbDepth, sidewalkControlElements[index10].beveledCurb, sidewalkControlElements[index10].beveledHeight, sidewalkControlElements[index10].beveledDepth, sidewalkControlElements[index10].outerCurb, sidewalkControlElements[index10].sidewalkUVs, sidewalkControlElements[index10].sidewalkMaterial);
						siblings[1].rightSidewalkActive = true;
						siblings[1].rightSidewalkid = eRSideWalk10.id;
						siblings[1].rightSidewalk = eRSideWalk10;
						if (siblings[1].roadType.crosswalksIntersections && eRSideWalk10.crosswalkPavement)
						{
							siblings[1].rightCrosswalkActive = true;
						}
						if (sidewalkControlElements[2].rightConnectionHandle)
						{
							if (siblings[1].road.startPrefabScript == this)
							{
								siblings[1].road.leftSidewalkActive = true;
								siblings[1].road.defaultLeftSidewalkid = eRSideWalk10.id;
							}
							else
							{
								siblings[1].road.rightSidewalkActive = true;
								siblings[1].road.defaultRightSidewalkid = eRSideWalk10.id;
							}
						}
						siblings[2].leftSidewalkActive = true;
						siblings[2].leftSidewalkid = eRSideWalk10.id;
						siblings[2].leftSidewalk = eRSideWalk10;
						if (siblings[2].roadType.crosswalksIntersections && eRSideWalk10.crosswalkPavement)
						{
							siblings[2].leftCrosswalkActive = true;
						}
						if (sidewalkControlElements[2].leftConnectionHandle && siblings[2].road != null)
						{
							if (siblings[2].road.startPrefabScript == this)
							{
								siblings[2].road.rightSidewalkActive = true;
								siblings[2].road.defaultRightSidewalkid = eRSideWalk10.id;
							}
							else
							{
								siblings[2].road.leftSidewalkActive = true;
								siblings[2].road.defaultLeftSidewalkid = eRSideWalk10.id;
							}
						}
					}
				}
			}
			OCQQOODQOQ();
			crossingsScript.OCOQDOOOQC(null);
		}

		public void ActivateSidewalks(int siblingIndex, int startend)
		{
			if (startend == 0)
			{
				siblings[siblingIndex].leftSidewalkActive = siblings[siblingIndex].road.rightSidewalkActive;
				siblings[siblingIndex].leftSidewalkIndex = siblings[siblingIndex].road.defaultRightSidewalk;
				siblings[siblingIndex].leftSidewalkid = siblings[siblingIndex].road.defaultRightSidewalkid;
				if (siblings[siblingIndex].leftSidewalkActive && siblings[siblingIndex].roadType.crosswalksIntersections)
				{
					siblings[siblingIndex].leftCrosswalkActive = true;
				}
				siblings[siblingIndex].rightSidewalkActive = siblings[siblingIndex].road.leftSidewalkActive;
				siblings[siblingIndex].rightSidewalkIndex = siblings[siblingIndex].road.defaultLeftSidewalk;
				siblings[siblingIndex].rightSidewalkid = siblings[siblingIndex].road.defaultLeftSidewalkid;
				if (siblings[siblingIndex].rightSidewalkActive && siblings[siblingIndex].roadType.crosswalksIntersections)
				{
					siblings[siblingIndex].rightCrosswalkActive = true;
				}
			}
			else
			{
				siblings[siblingIndex].leftSidewalkActive = siblings[siblingIndex].road.leftSidewalkActive;
				siblings[siblingIndex].leftSidewalkIndex = siblings[siblingIndex].road.defaultLeftSidewalk;
				siblings[siblingIndex].leftSidewalkid = siblings[siblingIndex].road.defaultLeftSidewalkid;
				if (siblings[siblingIndex].leftSidewalkActive && siblings[siblingIndex].roadType.crosswalksIntersections)
				{
					siblings[siblingIndex].leftCrosswalkActive = true;
				}
				siblings[siblingIndex].rightSidewalkActive = siblings[siblingIndex].road.rightSidewalkActive;
				siblings[siblingIndex].rightSidewalkIndex = siblings[siblingIndex].road.defaultRightSidewalk;
				siblings[siblingIndex].rightSidewalkid = siblings[siblingIndex].road.defaultRightSidewalkid;
				if (siblings[siblingIndex].rightSidewalkActive && siblings[siblingIndex].roadType.crosswalksIntersections)
				{
					siblings[siblingIndex].rightCrosswalkActive = true;
				}
			}
		}

		public void ODDCDCDODO()
		{
		}

		public void OQQCDDOQOQ(ERModularRoad road, int startend)
		{
			Vector3 position;
			Vector3 position2;
			Vector3 p;
			if (startend == 0)
			{
				position = road.markersExt[0].position;
				position2 = road.markersExt[1].position;
				p = ((road.markersExt.Count <= 2) ? position2 : road.markersExt[2].position);
			}
			else
			{
				position = road.markersExt[road.markersExt.Count - 1].position;
				position2 = road.markersExt[road.markersExt.Count - 2].position;
				p = ((road.markersExt.Count <= 2) ? position2 : road.markersExt[road.markersExt.Count - 3].position);
			}
			Vector3 vector = base.transform.InverseTransformPoint(position2);
			vector.y = 0f;
			vector = base.transform.position;
			Vector3 angleControlPoint = ERConnectionSibling.GetAngleControlPoint(vector, position, position2, p);
			angleControlPoint = base.transform.InverseTransformPoint(angleControlPoint);
			float oDOCCQCQDO = 360f - QDDDQODDQDQDQDD.OCCQDDQQCD(angleControlPoint, Vector3.forward, Vector3.up);
			AttachRoadToFlexConnector(baseScript, road, oDOCCQCQDO, angleControlPoint, startend);
			road.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
			baseScript.UpdateSideObjectsInScene();
		}

		public void AttachRoadToFlexConnector(ERModularBase scr, ERModularRoad road, float ODOCCQCQDO, Vector3 OQDOODDOOQ, int startend)
		{
			siblings.Add(ERConnectionSibling.CreateInstance(scr.OOOCDDCQCD, ODOCCQCQDO, OQDOODDOOQ, null, siblings));
			int connectedMarker = 0;
			switch (startend)
			{
			case -1:
				if (scr.OODOOQQDQD == 0)
				{
					scr.OOOCDDCQCD.startPrefabScript = this;
					scr.OOOCDDCQCD.startConnectionSegment = siblings.Count - 1;
				}
				else
				{
					scr.OOOCDDCQCD.endPrefabScript = this;
					scr.OOOCDDCQCD.endConnectionSegment = siblings.Count - 1;
					connectedMarker = scr.OOOCDDCQCD.markersExt.Count - 1;
				}
				break;
			case 0:
				road.startPrefabScript = this;
				road.startConnectionSegment = siblings.Count - 1;
				break;
			default:
				road.endPrefabScript = this;
				road.endConnectionSegment = siblings.Count - 1;
				connectedMarker = road.markersExt.Count - 1;
				break;
			}
			if (crossingElements.Count < siblings.Count)
			{
				crossingElements.Add(new QDOODOQQDQODD());
				crossingElements[crossingElements.Count - 1].roadShapeMatchCount = road.roadShape.Count;
			}
			crossingElements[siblings.Count - 1].connectedRoad = road;
			crossingElements[siblings.Count - 1].connectedMarker = connectedMarker;
			siblings[siblings.Count - 1].hasChanged = true;
			for (int i = 0; i < siblings.Count - 1; i++)
			{
				if (siblings[i].roadTypeID == road.roadType)
				{
					siblings[siblings.Count - 1].primarySection = siblings[i].primarySection;
					break;
				}
			}
		}

		public void SetSidewalkState(ERModularRoad road)
		{
			if (road.rt == null || road.rt.defaultSidewalk == 0.0)
			{
				return;
			}
			road.defaultLeftSidewalkid = (road.defaultRightSidewalkid = road.rt.defaultSidewalk);
			int num = 0;
			for (int i = 0; i < baseScript.sidewalks.Count; i++)
			{
				if (baseScript.sidewalks[i].id == road.rt.defaultSidewalk)
				{
					road.defaultLeftSidewalk = (road.defaultRightSidewalk = i);
				}
			}
			List<ERConnectionSibling> list = new List<ERConnectionSibling>(siblings);
			list.Sort((ERConnectionSibling x, ERConnectionSibling y) => x.angle.CompareTo(y.angle));
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				if (list[num2].road == road)
				{
					ERConnectionSibling eRConnectionSibling = ((num2 != 0) ? list[num2 - 1] : list[list.Count - 1]);
					list[num2].rightSidewalkActive = (road.leftSidewalkActive = eRConnectionSibling.leftSidewalkActive);
					Debug.Log("index " + num2 + " right sw active " + eRConnectionSibling.leftSidewalkActive);
					eRConnectionSibling = ((num2 != list.Count - 1) ? list[num2 + 1] : list[0]);
					list[num2].leftSidewalkActive = (road.rightSidewalkActive = eRConnectionSibling.rightSidewalkActive);
					Debug.Log("index " + num2 + " left sw active " + eRConnectionSibling.rightSidewalkActive);
					break;
				}
			}
		}

		public void ODCOQDOQCQ(int index)
		{
			for (int i = 0; i < crossingElements.Count; i++)
			{
				if (siblings[i].laneData == null)
				{
					continue;
				}
				ERLaneData laneData = siblings[i].laneData;
				for (int j = 0; j < laneData.connectors.Count; j++)
				{
					if (laneData.connectors[j].endConnectionIndex == index)
					{
						laneData.connectors.RemoveAt(j);
						j--;
					}
					else if (laneData.connectors[j].endConnectionIndex > index)
					{
						laneData.connectors[j].endConnectionIndex--;
					}
				}
			}
			for (int k = 0; k < crossingElements.Count; k++)
			{
				if (crossingElements[k].connectedRoad != null)
				{
					if (crossingElements[k].connectedRoad.startPrefabScript == this)
					{
					}
					if (crossingElements[k].connectedRoad.endPrefabScript == this)
					{
					}
					crossingElements[k].connectedRoad.startSegmentIntAdjusted = false;
					crossingElements[k].connectedRoad.endSegmentIntAdjusted = false;
				}
			}
			for (int l = index; l < crossingElements.Count; l++)
			{
				if (crossingElements[l].connectedRoad != null)
				{
					if (crossingElements[l].connectedRoad.startPrefabScript == this && crossingElements[l].connectedRoad.startConnectionSegment >= l && !crossingElements[l].connectedRoad.startSegmentIntAdjusted)
					{
						crossingElements[l].connectedRoad.startConnectionSegment--;
						crossingElements[l].connectedRoad.startSegmentIntAdjusted = true;
					}
					if (crossingElements[l].connectedRoad.endPrefabScript == this && crossingElements[l].connectedRoad.endConnectionSegment >= l && !crossingElements[l].connectedRoad.endSegmentIntAdjusted)
					{
						crossingElements[l].connectedRoad.endConnectionSegment--;
						crossingElements[l].connectedRoad.endSegmentIntAdjusted = true;
					}
				}
			}
		}

		public static void OODODQCCDC(ERCrossings cScr, ERModularBase scr, bool mergeRoadObjects = true)
		{
			if (cScr.prefabScript.crossingElements.Count > 2)
			{
				scr.UpdateQueue();
				cScr.OCOQDOOOQC(null);
				return;
			}
			ERModularRoad connectedRoad = cScr.prefabScript.crossingElements[0].connectedRoad;
			int connectedMarker = cScr.prefabScript.crossingElements[0].connectedMarker;
			ERModularRoad eRModularRoad = null;
			int num = 0;
			if (cScr.prefabScript.crossingElements.Count == 2)
			{
				eRModularRoad = cScr.prefabScript.crossingElements[1].connectedRoad;
				num = cScr.prefabScript.crossingElements[1].connectedMarker;
			}
			UnityEngine.Object.DestroyImmediate(cScr.prefabScript.gameObject);
			if (mergeRoadObjects && connectedRoad != null && eRModularRoad != null && connectedRoad.roadType == eRModularRoad.roadType)
			{
				ERModularRoad oOOCDDCQCD = scr.OOOCDDCQCD;
				int oODOOQQDQD = scr.OODOOQQDQD;
				Vector3 position = Vector3.Lerp(connectedRoad.markersExt[connectedMarker].position, eRModularRoad.markersExt[num].position, 0.5f);
				connectedRoad.markersExt[connectedMarker].position = position;
				eRModularRoad.markersExt.RemoveAt(num);
				if (num > 0)
				{
					num--;
				}
				if (connectedRoad.road == null)
				{
					connectedRoad.road = new ERRoad(connectedRoad);
				}
				if (eRModularRoad.road == null)
				{
					eRModularRoad.road = new ERRoad(eRModularRoad);
				}
				ERRoadNetwork eRRoadNetwork = new ERRoadNetwork();
				eRRoadNetwork.ConnectRoads(connectedRoad.road, eRModularRoad.road);
			}
		}

		public int ODCQDODCQQ(ERModularRoad road1, int index, ref ERModularRoad road2, int side, int startend)
		{
			if ((side == 1 && startend == 0) || (side == 0 && startend == 1))
			{
				if (crossingsScript != null && !isFlexConnector)
				{
					switch (index)
					{
					case 0:
						if (!tCrossing)
						{
							if (crossingElements[2].connectedRoad != null)
							{
								return 2;
							}
						}
						else if (tCrossingLeftRight == 1)
						{
							if (crossingElements[1].connectedRoad != null)
							{
								return 1;
							}
						}
						else if (crossingElements[2].connectedRoad != null)
						{
							return 2;
						}
						break;
					case 2:
						if (crossingElements[1].connectedRoad != null)
						{
							return 1;
						}
						break;
					case 1:
						if (!tCrossing)
						{
							if (crossingElements[3].connectedRoad != null)
							{
								return 3;
							}
						}
						else if (tCrossingLeftRight == 0)
						{
							if (crossingElements[0].connectedRoad != null)
							{
								return 0;
							}
						}
						else if (crossingElements[3].connectedRoad != null)
						{
							return 3;
						}
						break;
					case 3:
						if (crossingElements[0].connectedRoad != null)
						{
							return 0;
						}
						break;
					}
				}
				else
				{
					if (isFlexConnector)
					{
						float angle = siblings[index].angle;
						float num = 361f;
						int num2 = -1;
						float num3 = 361f;
						int num4 = -1;
						for (int i = 0; i < siblings.Count; i++)
						{
							if (siblings[i].angle > angle && siblings[i].angle < num)
							{
								num2 = i;
								num = siblings[i].angle;
							}
							if (siblings[i].angle < num3 && i != index)
							{
								num4 = i;
								num3 = siblings[i].angle;
							}
						}
						if (num2 == -1)
						{
							num2 = num4;
						}
						return num2;
					}
					if (isCustomPrefab || isRoundabout)
					{
						int num5 = index + 1;
						if (num5 >= crossingElements.Count)
						{
							num5 = 0;
						}
						if (crossingElements[num5].connectedRoad != null)
						{
							return num5;
						}
					}
				}
			}
			else if (crossingsScript != null && !isFlexConnector)
			{
				switch (index)
				{
				case 0:
					if (!tCrossing)
					{
						if (crossingElements[3].connectedRoad != null)
						{
							return 3;
						}
					}
					else if (tCrossingLeftRight == 0)
					{
						if (crossingElements[1].connectedRoad != null)
						{
							return 1;
						}
					}
					else if (crossingElements[3].connectedRoad != null)
					{
						return 3;
					}
					break;
				case 2:
					if (crossingElements[0].connectedRoad != null)
					{
						return 0;
					}
					break;
				case 1:
					if (!tCrossing)
					{
						if (crossingElements[2].connectedRoad != null)
						{
							return 2;
						}
					}
					else if (tCrossingLeftRight == 1)
					{
						if (crossingElements[0].connectedRoad != null)
						{
							return 0;
						}
					}
					else if (crossingElements[2].connectedRoad != null)
					{
						return 2;
					}
					break;
				case 3:
					if (crossingElements[1].connectedRoad != null)
					{
						return 1;
					}
					break;
				}
			}
			else
			{
				if (isFlexConnector)
				{
					float angle2 = siblings[index].angle;
					float num6 = -1f;
					int num7 = -1;
					float num8 = -1f;
					int num9 = -1;
					for (int j = 0; j < siblings.Count; j++)
					{
						if (siblings[j].angle < angle2 && siblings[j].angle > num6)
						{
							num7 = j;
							num6 = siblings[j].angle;
						}
						if (siblings[j].angle > num8 && j != index)
						{
							num9 = j;
							num8 = siblings[j].angle;
						}
					}
					if (num7 == -1)
					{
						num7 = num9;
					}
					return num7;
				}
				if (isCustomPrefab || isRoundabout)
				{
					int num10 = index - 1;
					if (num10 < 0)
					{
						num10 = crossingElements.Count - 1;
					}
					if (crossingElements[num10].connectedRoad != null)
					{
						return num10;
					}
				}
			}
			return -1;
		}

		public bool OQODDODODC(int index, int side)
		{
			int num = 0;
			if (side == 1)
			{
				if (crossingElements[index].rightRoundingPoints.Count == 0)
				{
					return false;
				}
				if (crossingsScript != null && !isFlexConnector)
				{
					switch (index)
					{
					case 0:
						num = (tCrossing ? ((tCrossingLeftRight == 1) ? 1 : 3) : 3);
						break;
					case 2:
						num = 0;
						break;
					case 1:
						num = (tCrossing ? ((tCrossingLeftRight == 0) ? 1 : 0) : 2);
						break;
					case 3:
						num = 1;
						break;
					}
				}
				else if (isFlexConnector)
				{
					int num2 = siblings[index].orderedIndex - 1;
					if (num2 <= -1)
					{
						num2 = siblings.Count - 1;
					}
					for (int i = 0; i < siblings.Count; i++)
					{
						if (siblings[i].orderedIndex == num2)
						{
							num = i;
						}
					}
				}
				else if (isCustomPrefab || isRoundabout)
				{
					num = index - 1;
					if (num < 0)
					{
						num = crossingElements.Count - 1;
					}
				}
				if (crossingElements[num].leftRoundingPoints.Count > 0)
				{
					if (crossingElements[num].leftRoundingPoints[crossingElements[num].leftRoundingPoints.Count - 1] == crossingElements[index].rightRoundingPoints[crossingElements[index].rightRoundingPoints.Count - 1])
					{
						return true;
					}
					return false;
				}
			}
			else
			{
				if (crossingElements[index].leftRoundingPoints.Count == 0)
				{
					return false;
				}
				if (crossingsScript != null && !isFlexConnector)
				{
					switch (index)
					{
					case 0:
						num = (tCrossing ? ((tCrossingLeftRight == 0) ? 1 : 2) : 2);
						break;
					case 2:
						num = 1;
						break;
					case 1:
						num = (tCrossing ? ((tCrossingLeftRight != 1) ? 3 : 0) : 3);
						break;
					case 3:
						num = 0;
						break;
					}
				}
				else if (isFlexConnector)
				{
					int num3 = siblings[index].orderedIndex + 1;
					if (num3 >= siblings.Count)
					{
						num3 = 0;
					}
					for (int j = 0; j < siblings.Count; j++)
					{
						if (siblings[j].orderedIndex == num3)
						{
							num = j;
						}
					}
				}
				else if (isCustomPrefab || isRoundabout)
				{
					num = index + 1;
					if (num >= crossingElements.Count)
					{
						num = 0;
					}
				}
				if (crossingElements[num].rightRoundingPoints.Count > 0)
				{
					if (crossingElements[num].rightRoundingPoints[crossingElements[num].rightRoundingPoints.Count - 1] == crossingElements[index].leftRoundingPoints[crossingElements[index].leftRoundingPoints.Count - 1])
					{
						return true;
					}
					return false;
				}
			}
			return false;
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

		public static void OQCDCQDQDC()
		{
			ERCrossingPrefabs[] array = UnityEngine.Object.FindObjectsOfType<ERCrossingPrefabs>();
			ERCrossingPrefabs[] array2 = array;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				if (eRCrossingPrefabs.surfaceObject != null)
				{
					if (eRCrossingPrefabs.gameObject.GetComponent<ERCrossings>() != null && eRCrossingPrefabs.surfaceObject != null)
					{
						OCOCODQQDC.OCDDDCQOQQ(eRCrossingPrefabs, eRCrossingPrefabs.tmpMeshVecs, ref eRCrossingPrefabs.surfaceMeshVecs);
					}
				}
				else if (eRCrossingPrefabs.gameObject.GetComponent<ERRoundabouts>() != null && eRCrossingPrefabs.surfaceObject != null)
				{
					OCDDOODQDQ.ODDDOQCCCD(eRCrossingPrefabs, eRCrossingPrefabs.tmpMeshVecs, ref eRCrossingPrefabs.surfaceMeshVecs);
				}
				else if (eRCrossingPrefabs.isCustomPrefab && eRCrossingPrefabs.doTerrainDeformation && eRCrossingPrefabs.surfaceObject != null && eRCrossingPrefabs.crossingElements.Count > 0)
				{
					OODDOCOCOC.OCOOOQCCCQ(eRCrossingPrefabs, eRCrossingPrefabs.baseScript, eRCrossingPrefabs.doTerrainDeformation);
				}
			}
		}

		public void OOOOQOOCQO()
		{
			List<ERConnectionSibling> list = new List<ERConnectionSibling>(siblings);
			list.Sort((ERConnectionSibling x, ERConnectionSibling y) => x.angle.CompareTo(y.angle));
			bool flag = false;
			for (int num = 0; num < list.Count; num++)
			{
				if (list[num].roadType != null)
				{
					flag = false;
					if (list[num].buildPriority == 0)
					{
						flag = true;
					}
					ERConnectionSibling eRConnectionSibling = null;
					eRConnectionSibling = ((num >= list.Count - 1) ? list[0] : list[num + 1]);
					if ((list[num].leftSidewalkActive && list[num].leftSidewalkid != 0.0) || (eRConnectionSibling.rightSidewalkActive && eRConnectionSibling.rightSidewalkid != 0.0))
					{
						if (list[num].leftSidewalk == null)
						{
							list[num].leftSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, list[num].leftSidewalkid);
						}
						if (list[num].leftSidewalk == null)
						{
							list[num].leftSidewalkid = 0.0;
						}
						if (list[num].leftSidewalkGO == null && list[num].leftSidewalk != null)
						{
							list[num].leftSidewalkGO = ODDDOCCQCO(num, " [Left]", list[num].leftSidewalk.material);
						}
						if (!list[num].rightSidewalkActive && list[num].leftSidewalkGO != null)
						{
							UnityEngine.Object.DestroyImmediate(list[num].leftSidewalkGO);
						}
						if (num < list.Count - 1)
						{
							ERSideWalkVecs.OQQCDQCODD(baseScript, this, list[num], list[num + 1], num, num + 1, flag, turnSWAroundCornerThreshold);
						}
						else
						{
							ERSideWalkVecs.OQQCDQCODD(baseScript, this, list[num], list[0], num, 0, flag, turnSWAroundCornerThreshold);
						}
					}
					else if (list[num].leftSidewalkGO != null)
					{
						UnityEngine.Object.DestroyImmediate(list[num].leftSidewalkGO);
					}
				}
				if ((list[num].leftSidewalkActive && list[num].leftCrosswalkActive) || (list[num].rightSidewalkActive && list[num].rightCrosswalkActive))
				{
					ERSideWalkVecs.OCQDCQDOOO(base.transform, list[num]);
				}
			}
			for (int num2 = 0; num2 < priorityRoads.Count; num2++)
			{
				if (priorityRoads[num2].mainConnectionDecalVecs.Count > 0)
				{
					if (priorityRoads[num2].mainRoadConnectionEdgeDecal != 0)
					{
						QDDDQODDQDQDQDD.OCQODDCDQC(base.transform, priorityRoads[num2], num2);
					}
					else if (priorityRoads[num2].mainConnectionDecal != null)
					{
						UnityEngine.Object.DestroyImmediate(priorityRoads[num2].mainConnectionDecal);
					}
				}
				else if (priorityRoads[num2].mainConnectionDecal != null)
				{
					UnityEngine.Object.DestroyImmediate(priorityRoads[num2].mainConnectionDecal);
				}
			}
			priorityRoads.Clear();
		}

		public static void SidewalkActiveState(ERModularRoad road, bool active, double id, int side)
		{
			if (road.startPrefabScript != null && road.startPrefabScript.isFlexConnector && road.startPrefabScript.siblings.Count > road.startConnectionSegment)
			{
				if (side == 0)
				{
					road.startPrefabScript.siblings[road.startConnectionSegment].rightSidewalkActive = active;
					if (active)
					{
						road.startPrefabScript.siblings[road.startConnectionSegment].rightSidewalkid = id;
					}
					if (!active && road.startPrefabScript.siblings[road.startConnectionSegment].rightSidewalkGO != null)
					{
						UnityEngine.Object.DestroyImmediate(road.startPrefabScript.siblings[road.startConnectionSegment].rightSidewalkGO);
					}
					if (road.startPrefabScript.crossingsScript != null)
					{
						road.startPrefabScript.crossingsScript.OCOQDOOOQC(road.rt, doSetFlexVars: false);
					}
				}
				else
				{
					road.startPrefabScript.siblings[road.startConnectionSegment].leftSidewalkActive = active;
					if (active)
					{
						road.startPrefabScript.siblings[road.startConnectionSegment].leftSidewalkid = id;
					}
					if (!active && road.startPrefabScript.siblings[road.startConnectionSegment].leftSidewalkGO != null)
					{
						UnityEngine.Object.DestroyImmediate(road.startPrefabScript.siblings[road.startConnectionSegment].leftSidewalkGO);
					}
					if (road.startPrefabScript.crossingsScript != null)
					{
						road.startPrefabScript.crossingsScript.OCOQDOOOQC(road.rt, doSetFlexVars: false);
					}
				}
			}
			if (!(road.endPrefabScript != null) || !road.endPrefabScript.isFlexConnector)
			{
				return;
			}
			if (side == 0)
			{
				road.endPrefabScript.siblings[road.endConnectionSegment].leftSidewalkActive = active;
				if (active)
				{
					road.endPrefabScript.siblings[road.endConnectionSegment].leftSidewalkid = id;
				}
				if (!active && road.endPrefabScript.siblings[road.endConnectionSegment].leftSidewalkGO != null)
				{
					UnityEngine.Object.DestroyImmediate(road.endPrefabScript.siblings[road.endConnectionSegment].leftSidewalkGO);
				}
				if (road.endPrefabScript.crossingsScript != null)
				{
					road.endPrefabScript.crossingsScript.OCOQDOOOQC(road.rt, doSetFlexVars: false);
				}
			}
			else
			{
				road.endPrefabScript.siblings[road.endConnectionSegment].rightSidewalkActive = active;
				if (active)
				{
					road.endPrefabScript.siblings[road.endConnectionSegment].rightSidewalkid = id;
				}
				if (!active && road.endPrefabScript.siblings[road.endConnectionSegment].rightSidewalkGO != null)
				{
					UnityEngine.Object.DestroyImmediate(road.endPrefabScript.siblings[road.endConnectionSegment].rightSidewalkGO);
				}
				if (road.endPrefabScript.crossingsScript != null)
				{
					road.endPrefabScript.crossingsScript.OCOQDOOOQC(road.rt, doSetFlexVars: false);
				}
			}
		}

		public GameObject ODDDOCCQCO(int index, string side, Material mat)
		{
			GameObject gameObject = null;
			Transform transform = base.transform.Find("sidewalk_" + side + "_" + index);
			if (transform == null)
			{
				gameObject = new GameObject("sidewalk_" + side + "_" + index);
				gameObject.transform.position = base.transform.position;
				gameObject.transform.rotation = base.transform.rotation;
				gameObject.transform.parent = base.transform;
				gameObject.isStatic = true;
				gameObject.AddComponent<MeshRenderer>().sharedMaterial = mat;
				gameObject.AddComponent<MeshFilter>().sharedMesh = new Mesh();
				gameObject.AddComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				gameObject = transform.gameObject;
			}
			return gameObject;
		}

		public static string SetFlexConnectorName(ERModularBase scr)
		{
			if (scr == null)
			{
				scr = UnityEngine.Object.FindObjectOfType<ERModularBase>();
				if (scr == null)
				{
					return "Flex Connector";
				}
			}
			ERCrossingPrefabs[] componentsInChildren = scr.GetComponentsInChildren<ERCrossingPrefabs>();
			int num = 0;
			ERCrossingPrefabs[] array = componentsInChildren;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array)
			{
				if (eRCrossingPrefabs.isFlexConnector)
				{
					num++;
				}
			}
			num++;
			return "Flex Connector " + $"{num:D5}";
		}

		public void ODCQCCQOCQ(int index, string side, Material mat)
		{
			GameObject gameObject = GameObject.Find("sidewalk_" + side + "_" + index);
			if (gameObject != null)
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
		}

		public static bool OOCQODQDQD(Vector3 pTarget, Vector3 pSource, Vector3 pCheck)
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
