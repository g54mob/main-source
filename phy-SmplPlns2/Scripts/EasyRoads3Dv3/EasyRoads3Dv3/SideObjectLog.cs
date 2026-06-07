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

		public float xPosition2 = 0f;

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

		public PhysicsMaterial physicMaterial;

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

		public float segmentOffset = 0f;

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

		public bool tunnelObject = false;

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

		public Texture2D densityMap;

		public float densitySize = 50f;

		public float densitySize2 = 50f;

		public float densityStrength = 0.5f;

		public float densityStrength2 = 0.5f;

		public float terrainNormal = 0f;

		public float terrainNormal2 = 1f;

		public List<ERChildsSO> childObjects = new List<ERChildsSO>();

		public bool autoGenerate = false;

		public float heightThreshold = 10f;

		public float autogenerateStartOffset = 0f;

		public float autogenerateEndOffset = 0f;

		public bool snapIndents = false;

		public float snapIndentWidth = 0f;

		public bool cutHoles = true;

		public float innerStartOffset = 0f;

		public float innerEndOffset = 0f;

		public bool ignoredForRetainingWalls = false;

		public float heightMaxThreshold = 100f;

		public float heightMaxStartThreshold = 1f;

		public float heightMaxEndThreshold = 1f;

		public float xThresholdDistance = 5f;

		public float angleThreshold = 10f;

		public int connectionRatio = 1;

		public bool retainingWall = false;

		public int surroundingControl = 0;

		public int indentControl = 0;

		public List<Vector2> nodeListMirrored = new List<Vector2>();

		public List<float> uvsMirrored = new List<float>();

		public List<float> snapWeightListMirrored = new List<float>();

		public List<Color> colorListMirrored = new List<Color>();

		public bool uv4walls = false;

		public bool hasVertexColors = false;

		public float deformationOffsetForward = 0f;

		public float deformationOffsetSideways = 0f;

		public int connectionObjectRotation = 0;

		public bool subMesh = false;

		public bool acceptBarriers = true;

		public bool activeOnBridges = true;

		public bool dualSided = false;

		public int mirrorType = 0;

		public bool snapVertexColors = false;

		public float minSnapRange = 0f;

		public float maxSnapRange = 0f;

		public bool clampUV4 = false;

		public float geoStartOffset = 0f;

		public float geoEndOffset = 0f;

		public bool strictRules = false;

		public float startOverlapOffset = 0f;

		public float endOverlapOffset = 0f;

		public int lodLevels = 0;

		public List<bool> hardEdge = new List<bool>();

		public List<bool> hardEdgeMirrored = new List<bool>();

		public float hardEdgePadding = 0f;

		public bool startEndCaps = false;

		public List<Vector2> endCapUVs = new List<Vector2>();

		public List<Vector2> startCapUVs = new List<Vector2>();

		public List<int> startCapTris = new List<int>();

		public List<int> startCapTrisMirrored = new List<int>();

		public Vector2 startCapUVOffset = new Vector2(0.5f, 0.5f);

		public Vector2 endCapUVOffset = new Vector2(0.5f, 0.5f);

		public float startCapUVScale = 1f;

		public float endCapUVScale = 1f;

		public float startCapUVRotation = 0f;

		public float endCapUVRotation = 0f;

		public bool namedChilds = false;

		public bool startSection = false;

		public bool endSection = false;

		public bool stepDown = false;

		public bool stepUp = false;

		public float stepDistance = 0f;

		public float startDirZOffset = 0f;

		public float endDirZOffset = 0f;

		public bool buildOtherSideObject1 = false;

		public double defaultOtherSoId1 = 0.0;

		public bool buildOtherSideObject2 = false;

		public double defaultOtherSoId2 = 0.0;

		public List<double> buildOtherSideObjects = new List<double>();

		public bool averageDistance = true;

		public bool randomUVx = false;

		public bool isUsedAsChild = false;

		public bool relativeToCenter = false;

		public bool shapeWeightsRelativeX = false;

		public float easeInOutDistanceTerrainSnap = 0f;

		public float startBoundsZ = 0f;

		public float endBoundsZ = 0f;

		public List<SideObjectChild> buildOtherSideObjectChilds = new List<SideObjectChild>();

		public float minSectionLength = 50f;

		public float maxSlope = 45f;

		public string tag = "Untagged";

		public int selectedTag = 0;

		public bool doubleSidedBendFlag = false;

		public bool recalculateNormals = false;

		public float x1 = 0f;

		public float x2 = 0f;

		public float xf1 = 0f;

		public float xf2 = 0f;

		public float xf1Total = 0f;

		public float xf2Total = 0f;

		public float y1 = 0f;

		public bool baseControllerFlag = false;

		public Vector3 connectorEndOffset;

		public float minBaseRotation = 0f;

		public float maxBaseRotation = 0f;

		public int baseChildIndex = -1;

		public int baseConnectorIndex = -1;

		public bool continueOnConnections = true;

		public bool ignoreOffsetsOnConnections = false;

		public bool triangulateDualSided = false;

		public Material dualSidedMaterial;

		public float dualSidedMaterialTiling = 1f;

		public void ODCCOOCCCO(SideObject so)
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
			uv4walls = so.uv4walls;
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
			xPosition2 = so.xPosition2;
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
			physicMaterial = so.physicMaterial;
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
			segmentOffset = so.segmentOffset;
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
			tunnelObject = so.tunnelObject;
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
			densityMap = so.densityMap;
			densitySize = so.densitySize;
			densitySize2 = so.densitySize2;
			densityStrength = so.densityStrength;
			densityStrength2 = so.densityStrength2;
			terrainNormal = so.terrainNormal;
			terrainNormal2 = so.terrainNormal2;
			childObjects = new List<ERChildsSO>(so.childObjects);
			autoGenerate = so.autoGenerate;
			heightThreshold = so.heightThreshold;
			autogenerateStartOffset = so.autogenerateStartOffset;
			autogenerateEndOffset = so.autogenerateEndOffset;
			snapIndents = so.snapIndents;
			snapIndentWidth = so.snapIndentWidth;
			cutHoles = so.cutHoles;
			innerStartOffset = so.innerStartOffset;
			innerEndOffset = so.innerEndOffset;
			ignoredForRetainingWalls = so.ignoredForRetainingWalls;
			heightMaxThreshold = so.heightMaxThreshold;
			heightMaxStartThreshold = so.heightMaxStartThreshold;
			heightMaxEndThreshold = so.heightMaxEndThreshold;
			xThresholdDistance = so.xThresholdDistance;
			angleThreshold = so.angleThreshold;
			connectionRatio = so.connectionRatio;
			retainingWall = so.retainingWall;
			surroundingControl = so.surroundingControl;
			indentControl = so.indentControl;
			nodeListMirrored = new List<Vector2>(so.nodeListMirrored);
			uvsMirrored = new List<float>(so.uvsMirrored);
			snapWeightListMirrored = new List<float>(so.snapWeightListMirrored);
			colorListMirrored = so.colorListMirrored;
			hasVertexColors = so.hasVertexColors;
			deformationOffsetForward = so.deformationOffsetForward;
			deformationOffsetSideways = so.deformationOffsetSideways;
			connectionObjectRotation = so.connectionObjectRotation;
			subMesh = so.subMesh;
			acceptBarriers = so.acceptBarriers;
			activeOnBridges = so.activeOnBridges;
			dualSided = so.dualSided;
			triangulateDualSided = so.triangulateDualSided;
			dualSidedMaterial = so.dualSidedMaterial;
			dualSidedMaterialTiling = so.dualSidedMaterialTiling;
			mirrorType = so.mirrorType;
			snapVertexColors = so.snapVertexColors;
			minSnapRange = so.minSnapRange;
			maxSnapRange = so.maxSnapRange;
			clampUV4 = so.clampUV4;
			geoStartOffset = so.geoStartOffset;
			geoEndOffset = so.geoEndOffset;
			startOverlapOffset = so.startOverlapOffset;
			endOverlapOffset = so.endOverlapOffset;
			lodLevels = so.lodLevels;
			hardEdge = new List<bool>(so.hardEdge);
			hardEdgeMirrored = new List<bool>(so.hardEdgeMirrored);
			hardEdgePadding = so.hardEdgePadding;
			startEndCaps = so.startEndCaps;
			endCapUVs = new List<Vector2>(so.endCapUVs);
			startCapUVs = new List<Vector2>(so.startCapUVs);
			startCapTris = new List<int>(so.startCapTris);
			startCapTrisMirrored = new List<int>(so.startCapTrisMirrored);
			startCapUVOffset = so.startCapUVOffset;
			endCapUVOffset = so.endCapUVOffset;
			startCapUVScale = so.startCapUVScale;
			endCapUVScale = so.endCapUVScale;
			startCapUVRotation = so.startCapUVRotation;
			endCapUVRotation = so.endCapUVRotation;
			namedChilds = so.namedChilds;
			startSection = so.startSection;
			endSection = so.endSection;
			stepDown = so.stepDown;
			stepUp = so.stepUp;
			stepDistance = so.stepDistance;
			startDirZOffset = so.startDirZOffset;
			endDirZOffset = so.endDirZOffset;
			buildOtherSideObject1 = so.buildOtherSideObject1;
			defaultOtherSoId1 = so.defaultOtherSoId1;
			buildOtherSideObject2 = so.buildOtherSideObject2;
			defaultOtherSoId2 = so.defaultOtherSoId2;
			buildOtherSideObjects = new List<double>(so.buildOtherSideObjects);
			averageDistance = so.averageDistance;
			randomUVx = so.randomUVx;
			isUsedAsChild = so.isUsedAsChild;
			relativeToCenter = so.relativeToCenter;
			shapeWeightsRelativeX = so.shapeWeightsRelativeX;
			easeInOutDistanceTerrainSnap = so.easeInOutDistanceTerrainSnap;
			startBoundsZ = so.startBoundsZ;
			endBoundsZ = so.endBoundsZ;
			buildOtherSideObjectChilds = new List<SideObjectChild>(so.buildOtherSideObjectChilds);
			minSectionLength = so.minSectionLength;
			maxSlope = so.maxSlope;
			tag = so.tag;
			selectedTag = so.selectedTag;
			doubleSidedBendFlag = so.doubleSidedBendFlag;
			recalculateNormals = so.recalculateNormals;
			strictRules = so.strictRules;
			uv4walls = so.uv4walls;
			x1 = so.x1;
			x2 = so.x2;
			xf1 = so.xf1;
			xf2 = so.xf2;
			xf1Total = so.xf1Total;
			xf2Total = so.xf2Total;
			y1 = so.y1;
			baseControllerFlag = so.baseControllerFlag;
			connectorEndOffset = so.connectorEndOffset;
			minBaseRotation = so.minBaseRotation;
			maxBaseRotation = so.maxBaseRotation;
			baseChildIndex = so.baseChildIndex;
			baseConnectorIndex = so.baseConnectorIndex;
			continueOnConnections = so.continueOnConnections;
			ignoreOffsetsOnConnections = so.ignoreOffsetsOnConnections;
		}
	}
}
