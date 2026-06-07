using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class SideObject : ScriptableObject
	{
		public string version = "2.0.0";

		public new string name;

		public double id;

		public double timestamp;

		public int objectType = 0;

		public string gameobjectGUID;

		public string textureGUID;

		public float m_distance = 10f;

		public float uvx = 0.1f;

		public float uvy = 1f;

		public int position = 0;

		public float splinePosition = 0f;

		public int selectedRotation = 0;

		public float randomYAxisMinRotation = 0f;

		public float randomYAxisMaxRotation = 0f;

		public List<Vector2> nodeList = new List<Vector2>();

		public List<float> uvs = new List<float>();

		public List<float> uvDistances = new List<float>();

		public bool clampUVs = true;

		public bool clampUVY = true;

		public float clampUVYValue = 1f;

		public float totalDistance = 0f;

		public bool reverseUVs = false;

		public bool terrainUVs = false;

		public List<bool> snapList = new List<bool>();

		public List<float> snapWeightList = new List<float>();

		public List<Color> colorList = new List<Color>();

		public string gameobjectStartGUID;

		public string gameobjectEndGUID;

		public int align = 1;

		public int alignPoint = 0;

		public bool weld = true;

		public bool combine = true;

		public bool combineInstantiated = true;

		public bool markerActive = true;

		public int uvType = 0;

		public float uv = 1f;

		public bool randomObjects = false;

		public float forwardStartOffset = 0f;

		public float sidewaysOffset = 0f;

		public float density = 0f;

		public string goPath = "";

		public string startPath = "";

		public string endPath = "";

		public string texturePath = "";

		public int terrainTree = 0;

		public float minScale = 1f;

		public float maxScale = 1f;

		public bool childOrderActive = false;

		public int childOrder = 0;

		public bool meshBoundsAlignment = false;

		public float xPosition = 0f;

		public int relativeTo = 0;

		public float yPosition = 0f;

		public float yRotation = 0f;

		public float oldSidwaysDistance = 0f;

		public int sidewaysDistanceUpdate = 0;

		public float uvYRound = 0f;

		public bool adjustUV = true;

		public bool collider = false;

		public bool boxcollider = false;

		public bool tangents = false;

		public GameObject sourceObject;

		public bool flipMesh = false;

		public GameObject startObject;

		public GameObject endObject;

		public GameObject connectionObject;

		public Material material;

		public List<ERMesh> meshObjects = new List<ERMesh>();

		public Vector2 boxSize;

		public Vector2 boxOffset;

		public bool includeStartSegment = false;

		public float startSegmentOffset = 0f;

		public bool includeStartEdgeTris = false;

		public bool includeEndSegment = false;

		public float endSegmentOffset = 0f;

		public bool includeEndEdgeTris = false;

		public bool adjustToRoadWidth = false;

		public float xOffset = 0f;

		public float startOffset = 0f;

		public float endOffset = 0f;

		public float defaultStartOffset = 0f;

		public float defaultEndOffset = 0f;

		public float totalZDistance = 0f;

		public float middleZDistance = 0f;

		public float startZDistance = 0f;

		public float endZDistance = 0f;

		public float minStartZ = 10000f;

		public float maxStartZ = -10000f;

		public float minMiddleZ = 10000f;

		public float maxMiddleZ = -10000f;

		public float minEndZ = 10000f;

		public float maxEndZ = -10000f;

		public bool smoothStart = false;

		public bool smoothMiddle = false;

		public bool smoothEnd = false;

		public GameObject targetObject;

		public bool bridgeObject = false;

		public bool snapToTerrain = false;

		public int layer = 0;

		public bool deformationObject = false;

		public bool isStatic = false;

		public bool castShadows = true;

		public bool scaleToRoad = false;

		public bool splitInBatches = false;

		public List<GameObject> instantiatedObjects = new List<GameObject>();

		public int maxVertices = 0;

		public bool doTestmesh = false;

		public Vector3 testMeshPos = Vector3.zero;

		public Vector3 randomRotation = Vector3.zero;

		public float randomMinRotation = 0f;

		public float randomMaxRotation = 0f;

		public float minRandomRotationDistance = 0f;

		public float maxRandomRotationDistance = 0f;

		public float randomXPosition = 0f;

		public float randomMinXPosition = 0f;

		public float randomMaxXPosition = 0f;

		public float minRandomXPositionDistance = 0f;

		public float maxRandomXPositionDistance = 0f;

		public Vector3 boxColliderScale = new Vector3(1f, 1f, 1f);

		public float randomYPosition = 0f;

		public float randomMinYPosition = 0f;

		public float randomMaxYPosition = 0f;

		public float minRandomYPositionDistance = 0f;

		public float maxRandomYPositionDistance = 0f;

		public bool indentController = false;

		public bool excludeTerrainSplats = false;

		public float bridgeHeight = 5f;

		public int markerSplineController = 2;

		public float bridgeLength = 20f;

		public float deformationOffset = 0f;

		public float markerIndent = 0f;

		public float markerSurrounding = 0f;

		public Vector3 scale = Vector3.one;

		public float indentExt = 0f;

		public int category = 0;

		public void SetSideObject(int count, int scategory)
		{
			id = (timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
			name = "Side Object " + count;
			category = scategory;
		}

		public void UpdateTimeStamp()
		{
			timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}

		public void ODDDODDCQC()
		{
			uvs.Clear();
			float num = 0f;
			for (int i = 0; i < nodeList.Count - 1; i++)
			{
				num += Vector2.Distance(nodeList[i], nodeList[i + 1]);
			}
			float num2 = 0f;
			uvs.Add(0f);
			for (int i = 0; i < nodeList.Count - 1; i++)
			{
				num2 += Vector2.Distance(nodeList[i], nodeList[i + 1]);
				uvs.Add(num2 / num);
			}
		}

		public void SetMaxVertices()
		{
			maxVertices = 0;
			GameObject gameObject = sourceObject;
			if (objectType != 0)
			{
				gameObject = connectionObject;
			}
			if (!(gameObject != null))
			{
				return;
			}
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			if (component != null && component.sharedMesh != null && component.sharedMesh.vertices.Length > maxVertices)
			{
				maxVertices = component.sharedMesh.vertices.Length;
			}
			MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
			foreach (Transform item in gameObject.transform)
			{
				if ((bool)item.GetComponent<MeshFilter>())
				{
					MeshFilter component2 = item.GetComponent<MeshFilter>();
					if (component2.sharedMesh != null && component2.sharedMesh.vertices.Length > maxVertices)
					{
						maxVertices = component2.sharedMesh.vertices.Length;
					}
				}
			}
		}

		public void OODQQCOQDO(bool updateTimeStamp)
		{
			meshObjects.Clear();
			meshObjects.Add(new ERMesh(null, this, 0f, null));
			totalDistance = 0f;
			for (int i = 0; i < nodeList.Count - 1; i++)
			{
				totalDistance += Vector2.Distance(nodeList[i], nodeList[i + 1]);
			}
			uvDistances.Clear();
			uvDistances.Add(0f);
			float num = 0f;
			for (int i = 0; i < nodeList.Count - 1; i++)
			{
				num += Vector2.Distance(nodeList[i], nodeList[i + 1]);
				uvDistances.Add(num / totalDistance);
			}
			if (updateTimeStamp)
			{
				UpdateTimeStamp();
			}
		}

		public void OOCDOQQCQO(Vector3 m_testMeshPos, bool updateTimeStamp)
		{
			if (updateTimeStamp)
			{
				UpdateTimeStamp();
			}
			testMeshPos = m_testMeshPos;
			minStartZ = 10000f;
			maxStartZ = -10000f;
			minMiddleZ = 10000f;
			maxMiddleZ = -10000f;
			minEndZ = 10000f;
			maxEndZ = -10000f;
			if (sourceObject == null && objectType != 1)
			{
				return;
			}
			if (sourceObject != null)
			{
				sourceObject.transform.position = Vector3.zero;
			}
			if (objectType == 1)
			{
				OODQQCOQDO(updateTimeStamp);
				return;
			}
			meshObjects.Clear();
			List<GameObject> list = new List<GameObject>();
			MeshFilter meshFilter = null;
			if ((bool)sourceObject.GetComponent<MeshFilter>())
			{
				if (sourceObject.GetComponent<MeshFilter>().sharedMesh != null)
				{
					list.Add(sourceObject);
				}
				else
				{
					Debug.LogError(string.Concat(sourceObject, ": This object does not have a mesh assigned to the meshfilter!"));
				}
			}
			foreach (Transform item in sourceObject.transform)
			{
				if ((bool)item.GetComponent<MeshFilter>())
				{
					if (item.GetComponent<MeshFilter>().sharedMesh != null)
					{
						list.Add(item.gameObject);
						continue;
					}
					Debug.LogError(string.Concat(sourceObject, "> ", item, ": This object does not have a mesh assigned to the meshfilter!"));
				}
			}
			if (list.Count == 0)
			{
				Debug.LogError(string.Concat(sourceObject, ": This object does not have a meshfilter component!"));
				return;
			}
			Mesh mesh = null;
			float num = 10000f;
			float num2 = -10000f;
			float num3 = 100000f;
			float num4 = -100000f;
			float num5 = 100000f;
			float num6 = -100000f;
			startZDistance = 0f;
			middleZDistance = 0f;
			endZDistance = 0f;
			if (list.Count > 0)
			{
				Bounds bounds = default(Bounds);
				for (int i = 0; i < list.Count; i++)
				{
					bounds.Encapsulate(list[i].GetComponent<MeshFilter>().sharedMesh.bounds);
				}
				num = 100000f;
				num2 = -100000f;
				num3 = 100000f;
				num4 = -100000f;
				num5 = 100000f;
				num6 = -100000f;
				foreach (GameObject item2 in list)
				{
					mesh = item2.GetComponent<MeshFilter>().sharedMesh;
					for (int i = 0; i < mesh.vertices.Length; i++)
					{
						Vector3 vector = item2.transform.TransformPoint(mesh.vertices[i]);
						if (vector.z < num)
						{
							num = vector.z;
						}
						if (vector.z > num2)
						{
							num2 = vector.z;
						}
						if (vector.x < num5)
						{
							num5 = vector.x;
						}
						if (vector.x > num6)
						{
							num6 = vector.x;
						}
						if (vector.y < num3)
						{
							num3 = vector.y;
						}
						if (vector.y > num4)
						{
							num4 = vector.y;
						}
					}
				}
				bounds.min = new Vector3(bounds.min.x, bounds.min.y, num);
				bounds.max = new Vector3(bounds.max.x, bounds.max.y, num2);
				totalZDistance = bounds.max.z - bounds.min.z;
				mesh = null;
				for (int i = 0; i < list.Count; i++)
				{
					meshObjects.Add(new ERMesh(list[i], this, num, sourceObject.transform));
				}
				boxSize = new Vector2(bounds.size.x, bounds.size.y);
				boxSize = new Vector2(num6 - num5, num4 - num3);
				boxOffset = new Vector2(bounds.center.x, bounds.center.y);
			}
			startZDistance = maxStartZ - minStartZ;
			middleZDistance = maxMiddleZ - minMiddleZ;
			endZDistance = maxEndZ - minEndZ;
			if ((startZDistance < 0f && includeStartSegment) || middleZDistance < 0f)
			{
				Debug.LogError("EasyRoads3Dv3: " + name + " Unable to extract mesh data, is the center of the bounding box positioned near (0,0)? Otherwise please contact us");
			}
		}

		public void OQODQCOCDD(SideObject so)
		{
			name = so.name + " [duplicate]";
			id = so.id;
			id = (timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
			objectType = so.objectType;
			gameobjectGUID = so.gameobjectGUID;
			textureGUID = so.textureGUID;
			m_distance = so.m_distance;
			uvx = so.uvx;
			uvy = so.uvy;
			position = so.position;
			splinePosition = so.splinePosition;
			selectedRotation = so.selectedRotation;
			randomYAxisMinRotation = so.randomYAxisMinRotation;
			randomYAxisMaxRotation = so.randomYAxisMaxRotation;
			nodeList = new List<Vector2>(so.nodeList);
			uvs = new List<float>(so.uvs);
			uvDistances = new List<float>(so.uvDistances);
			clampUVs = so.clampUVs;
			clampUVY = so.clampUVY;
			clampUVYValue = so.clampUVYValue;
			terrainUVs = so.terrainUVs;
			totalDistance = so.totalDistance;
			snapList = new List<bool>(so.snapList);
			snapWeightList = new List<float>(so.snapWeightList);
			colorList = new List<Color>(so.colorList);
			gameobjectStartGUID = so.gameobjectStartGUID;
			gameobjectEndGUID = so.gameobjectEndGUID;
			align = so.align;
			alignPoint = so.alignPoint;
			weld = so.weld;
			combine = so.combine;
			combineInstantiated = so.combineInstantiated;
			markerActive = so.markerActive;
			uvType = so.uvType;
			uv = so.uv;
			randomObjects = so.randomObjects;
			forwardStartOffset = so.forwardStartOffset;
			sidewaysOffset = so.sidewaysOffset;
			density = so.density;
			goPath = so.goPath;
			startPath = so.startPath;
			endPath = so.endPath;
			texturePath = so.texturePath;
			terrainTree = so.terrainTree;
			minScale = so.minScale;
			maxScale = so.maxScale;
			childOrderActive = so.childOrderActive;
			childOrder = so.childOrder;
			xPosition = so.xPosition;
			relativeTo = so.relativeTo;
			yPosition = so.yPosition;
			yRotation = so.yRotation;
			oldSidwaysDistance = so.oldSidwaysDistance;
			sidewaysDistanceUpdate = so.sidewaysDistanceUpdate;
			uvYRound = so.uvYRound;
			adjustUV = so.adjustUV;
			collider = so.collider;
			boxcollider = so.boxcollider;
			tangents = so.tangents;
			sourceObject = so.sourceObject;
			flipMesh = so.flipMesh;
			startObject = so.startObject;
			endObject = so.endObject;
			connectionObject = so.connectionObject;
			material = so.material;
			boxSize = so.boxSize;
			boxOffset = so.boxOffset;
			includeStartSegment = so.includeStartSegment;
			startSegmentOffset = so.startSegmentOffset;
			includeStartEdgeTris = so.includeStartEdgeTris;
			includeEndSegment = so.includeEndSegment;
			endSegmentOffset = so.endSegmentOffset;
			includeEndEdgeTris = so.includeEndEdgeTris;
			adjustToRoadWidth = so.adjustToRoadWidth;
			xOffset = so.xOffset;
			startOffset = so.startOffset;
			endOffset = so.endOffset;
			defaultStartOffset = so.defaultStartOffset;
			defaultEndOffset = so.defaultEndOffset;
			totalZDistance = so.totalZDistance;
			middleZDistance = so.middleZDistance;
			startZDistance = so.startZDistance;
			endZDistance = so.endZDistance;
			minStartZ = so.minStartZ;
			maxStartZ = so.maxStartZ;
			minMiddleZ = so.minMiddleZ;
			maxMiddleZ = so.maxMiddleZ;
			minEndZ = so.minEndZ;
			maxEndZ = so.maxEndZ;
			smoothStart = so.smoothStart;
			smoothMiddle = so.smoothMiddle;
			smoothEnd = so.smoothEnd;
			layer = so.layer;
			isStatic = so.isStatic;
			castShadows = so.castShadows;
			bridgeObject = so.bridgeObject;
			snapToTerrain = so.snapToTerrain;
			deformationObject = so.deformationObject;
			scaleToRoad = so.scaleToRoad;
			splitInBatches = so.splitInBatches;
			meshBoundsAlignment = so.meshBoundsAlignment;
			randomRotation = so.randomRotation;
			randomMinRotation = so.randomMinRotation;
			randomMaxRotation = so.randomMaxRotation;
			minRandomRotationDistance = so.minRandomRotationDistance;
			maxRandomRotationDistance = so.maxRandomRotationDistance;
			randomXPosition = so.randomXPosition;
			randomMinXPosition = so.randomMinXPosition;
			randomMaxXPosition = so.randomMaxXPosition;
			minRandomXPositionDistance = so.minRandomXPositionDistance;
			maxRandomXPositionDistance = so.maxRandomXPositionDistance;
			boxColliderScale = so.boxColliderScale;
			randomYPosition = so.randomYPosition;
			randomMinYPosition = so.randomMinYPosition;
			randomMaxYPosition = so.randomMaxYPosition;
			minRandomYPositionDistance = so.minRandomYPositionDistance;
			maxRandomYPositionDistance = so.maxRandomYPositionDistance;
			indentController = so.indentController;
			excludeTerrainSplats = so.excludeTerrainSplats;
			bridgeHeight = so.bridgeHeight;
			markerSplineController = so.markerSplineController;
			bridgeLength = so.bridgeLength;
			deformationOffset = so.deformationOffset;
			markerIndent = so.markerIndent;
			markerSurrounding = so.markerSurrounding;
			scale = so.scale;
			indentExt = so.indentExt;
			targetObject = so.targetObject;
			category = so.category;
			if (so.meshObjects.Count > 0)
			{
				OOCDOQQCQO(Vector3.zero, updateTimeStamp: false);
			}
		}

		public void OQOCCCQDCO(SideObjectLog so)
		{
			name = so.name;
			id = so.id;
			timestamp = so.timestamp;
			objectType = so.objectType;
			gameobjectGUID = so.gameobjectGUID;
			textureGUID = so.textureGUID;
			m_distance = so.m_distance;
			uvx = so.uvx;
			uvy = so.uvy;
			position = so.position;
			splinePosition = so.splinePosition;
			selectedRotation = so.selectedRotation;
			randomYAxisMinRotation = so.randomYAxisMinRotation;
			randomYAxisMaxRotation = so.randomYAxisMaxRotation;
			nodeList = new List<Vector2>(so.nodeList);
			uvs = new List<float>(so.uvs);
			uvDistances = new List<float>(so.uvDistances);
			clampUVs = so.clampUVs;
			clampUVY = so.clampUVY;
			clampUVYValue = so.clampUVYValue;
			terrainUVs = so.terrainUVs;
			totalDistance = so.totalDistance;
			snapList = new List<bool>(so.snapList);
			snapWeightList = new List<float>(so.snapWeightList);
			colorList = new List<Color>(so.colorList);
			gameobjectStartGUID = so.gameobjectStartGUID;
			gameobjectEndGUID = so.gameobjectEndGUID;
			align = so.align;
			alignPoint = so.alignPoint;
			weld = so.weld;
			combine = so.combine;
			combineInstantiated = so.combineInstantiated;
			markerActive = so.markerActive;
			uvType = so.uvType;
			uv = so.uv;
			randomObjects = so.randomObjects;
			forwardStartOffset = so.forwardStartOffset;
			sidewaysOffset = so.sidewaysOffset;
			density = so.density;
			goPath = so.goPath;
			startPath = so.startPath;
			endPath = so.endPath;
			texturePath = so.texturePath;
			terrainTree = so.terrainTree;
			minScale = so.minScale;
			maxScale = so.maxScale;
			childOrderActive = so.childOrderActive;
			childOrder = so.childOrder;
			xPosition = so.xPosition;
			relativeTo = so.relativeTo;
			yPosition = so.yPosition;
			yRotation = so.yRotation;
			oldSidwaysDistance = so.oldSidwaysDistance;
			sidewaysDistanceUpdate = so.sidewaysDistanceUpdate;
			uvYRound = so.uvYRound;
			adjustUV = so.adjustUV;
			collider = so.collider;
			boxcollider = so.boxcollider;
			tangents = so.tangents;
			sourceObject = so.sourceObject;
			flipMesh = so.flipMesh;
			startObject = so.startObject;
			endObject = so.endObject;
			connectionObject = so.connectionObject;
			material = so.material;
			boxSize = so.boxSize;
			boxOffset = so.boxOffset;
			includeStartSegment = so.includeStartSegment;
			startSegmentOffset = so.startSegmentOffset;
			includeStartEdgeTris = so.includeStartEdgeTris;
			includeEndSegment = so.includeEndSegment;
			endSegmentOffset = so.endSegmentOffset;
			includeEndEdgeTris = so.includeEndEdgeTris;
			adjustToRoadWidth = so.adjustToRoadWidth;
			xOffset = so.xOffset;
			startOffset = so.startOffset;
			endOffset = so.endOffset;
			defaultStartOffset = so.defaultStartOffset;
			defaultEndOffset = so.defaultEndOffset;
			totalZDistance = so.totalZDistance;
			middleZDistance = so.middleZDistance;
			startZDistance = so.startZDistance;
			endZDistance = so.endZDistance;
			minStartZ = so.minStartZ;
			maxStartZ = so.maxStartZ;
			minMiddleZ = so.minMiddleZ;
			maxMiddleZ = so.maxMiddleZ;
			minEndZ = so.minEndZ;
			maxEndZ = so.maxEndZ;
			smoothStart = so.smoothStart;
			smoothMiddle = so.smoothMiddle;
			smoothEnd = so.smoothEnd;
			layer = so.layer;
			isStatic = so.isStatic;
			castShadows = so.castShadows;
			bridgeObject = so.bridgeObject;
			snapToTerrain = so.snapToTerrain;
			deformationObject = so.deformationObject;
			scaleToRoad = so.scaleToRoad;
			splitInBatches = so.splitInBatches;
			meshBoundsAlignment = so.meshBoundsAlignment;
			randomRotation = so.randomRotation;
			randomMinRotation = so.randomMinRotation;
			randomMaxRotation = so.randomMaxRotation;
			minRandomRotationDistance = so.minRandomRotationDistance;
			maxRandomRotationDistance = so.maxRandomRotationDistance;
			randomXPosition = so.randomXPosition;
			randomMinXPosition = so.randomMinXPosition;
			randomMaxXPosition = so.randomMaxXPosition;
			minRandomXPositionDistance = so.minRandomXPositionDistance;
			maxRandomXPositionDistance = so.maxRandomXPositionDistance;
			boxColliderScale = so.boxColliderScale;
			randomYPosition = so.randomYPosition;
			randomMinYPosition = so.randomMinYPosition;
			randomMaxYPosition = so.randomMaxYPosition;
			minRandomYPositionDistance = so.minRandomYPositionDistance;
			maxRandomYPositionDistance = so.maxRandomYPositionDistance;
			indentController = so.indentController;
			excludeTerrainSplats = so.excludeTerrainSplats;
			bridgeHeight = so.bridgeHeight;
			markerSplineController = so.markerSplineController;
			bridgeLength = so.bridgeLength;
			deformationOffset = so.deformationOffset;
			markerIndent = so.markerIndent;
			markerSurrounding = so.markerSurrounding;
			scale = so.scale;
			targetObject = so.targetObject;
			category = so.category;
			if (objectType > 0 && (bool)sourceObject)
			{
				if (objectType == 1)
				{
					OODQQCOQDO(updateTimeStamp: false);
				}
				else
				{
					OOCDOQQCQO(Vector3.zero, updateTimeStamp: false);
				}
			}
			if (objectType == 1 && nodeList.Count > 0)
			{
				OODQQCOQDO(updateTimeStamp: false);
			}
		}

		public void Clear()
		{
			for (int i = 0; i < meshObjects.Count; i++)
			{
				meshObjects[i].Clear();
			}
		}
	}
}
