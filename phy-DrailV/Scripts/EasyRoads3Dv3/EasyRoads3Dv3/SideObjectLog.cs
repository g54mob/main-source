using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class SideObjectLog
	{
		public string version = "2.0.0";

		public string name;

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

		public bool terrainUVs = false;

		public bool reverseUVs = false;

		public float totalDistance = 0f;

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

		public float startOffset = 0.5f;

		public float endOffset = 0.5f;

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

		public float bridgeHeight = 5f;

		public int markerSplineController = 2;

		public float bridgeLength = 20f;

		public float deformationOffset = 20f;

		public float markerIndent = 20f;

		public float markerSurrounding = 10f;

		public bool indentController = false;

		public bool excludeTerrainSplats = false;

		public Vector3 scale = Vector3.one;

		public float indentExt = 0f;

		public int category = 0;

		public void OQODQCOCDD(SideObject so)
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
			if (so.nodeList != null)
			{
				nodeList = new List<Vector2>(so.nodeList);
			}
			if (so.uvs != null)
			{
				uvs = new List<float>(so.uvs);
			}
			if (so.uvDistances != null)
			{
				uvDistances = new List<float>(so.uvDistances);
			}
			clampUVs = so.clampUVs;
			clampUVY = so.clampUVY;
			clampUVYValue = so.clampUVYValue;
			terrainUVs = so.terrainUVs;
			reverseUVs = so.reverseUVs;
			totalDistance = so.totalDistance;
			if (so.snapList != null)
			{
				snapList = new List<bool>(so.snapList);
			}
			if (so.snapWeightList != null)
			{
				snapWeightList = new List<float>(so.snapWeightList);
			}
			if (so.colorList != null)
			{
				colorList = new List<Color>(so.colorList);
			}
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
			adjustToRoadWidth = so.adjustToRoadWidth;
			xOffset = so.xOffset;
			layer = so.layer;
			isStatic = so.isStatic;
			bridgeObject = so.bridgeObject;
			snapToTerrain = so.snapToTerrain;
			deformationObject = so.deformationObject;
			scaleToRoad = so.scaleToRoad;
			splitInBatches = so.splitInBatches;
			targetObject = so.targetObject;
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
			bridgeHeight = so.bridgeHeight;
			markerSplineController = so.markerSplineController;
			bridgeLength = so.bridgeLength;
			deformationOffset = so.deformationOffset;
			markerIndent = so.markerIndent;
			markerSurrounding = so.markerSurrounding;
			indentController = so.indentController;
			excludeTerrainSplats = so.excludeTerrainSplats;
			scale = so.scale;
			indentExt = so.indentExt;
			category = so.category;
		}
	}
}
