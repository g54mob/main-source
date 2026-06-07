using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class QDQDOOQQDQODD
	{
		public string roadTypeName = "New Road";

		public double id = -1.0;

		[HideInInspector]
		public double timestamp;

		[HideInInspector]
		public float roadWidth = 6f;

		[HideInInspector]
		public bool advancedWidthSettings = false;

		[HideInInspector]
		public float faceDistance = 2f;

		[HideInInspector]
		public float angleTreshold = 45f;

		[HideInInspector]
		public float uvTiling = 1f;

		[HideInInspector]
		public int uv4Type = 0;

		[HideInInspector]
		public ERRoadWayType type = ERRoadWayType.Primary;

		[HideInInspector]
		public float detailDistance = 50f;

		[HideInInspector]
		public bool planarUVs = false;

		[HideInInspector]
		public float outerIndent = 0.5f;

		[HideInInspector]
		public bool roadShapeDataActive = false;

		[HideInInspector]
		public ERRoadShape roadShapeData;

		[HideInInspector]
		public bool excludeFromTrafficAI = false;

		public float minSpeed = 45f;

		public float maxSpeed = 55f;

		public float speedLimit = 50f;

		public float speedLimitConnections = 50f;

		public List<Vector2> roadShape = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> roadShapeExt = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> roadShapeExt2 = new List<Vector2>();

		[HideInInspector]
		public List<bool> doConnectionTri = new List<bool>();

		[HideInInspector]
		public List<bool> doConnectionTriExt = new List<bool>();

		[HideInInspector]
		public List<float> roadShapeUVs = new List<float>();

		[HideInInspector]
		public List<float> roadShapeExtUVs = new List<float>();

		[HideInInspector]
		public List<float> roadShapeExtUVs2 = new List<float>();

		[HideInInspector]
		public List<float> roadShapeUVs2 = new List<float>();

		[HideInInspector]
		public bool preserveUVs = false;

		[HideInInspector]
		public List<bool> hardEdge = new List<bool>();

		[HideInInspector]
		public string roadShapeVecsString = "";

		[HideInInspector]
		public double defaultSidewalk = 0.0;

		[HideInInspector]
		public bool sidewalks = false;

		[HideInInspector]
		public float sidewalkHeight = 0.2f;

		[HideInInspector]
		public float sidewalkWidth = 2f;

		[HideInInspector]
		public bool crosswalks = false;

		[HideInInspector]
		public float crosswalkIntervals = 100f;

		[HideInInspector]
		public bool crosswalksIntersections = false;

		[HideInInspector]
		public GameObject crosswalkPrefab = null;

		[HideInInspector]
		public float crosswalkHeightOffset = 0.01f;

		[HideInInspector]
		public ERCrossWalkType crosswalkType = ERCrossWalkType.Prefab;

		public ERDecal crosswalkDecal;

		public Material roadMaterial;

		public Material[] roadMaterials;

		public PhysicsMaterial roadPhysicsMaterial;

		[HideInInspector]
		public PhysicsMaterial[] roadPhysicsMaterials;

		public Material connectionMaterial;

		public bool isSideObject = false;

		public bool isCustomRoad = false;

		[HideInInspector]
		public int subSegments = 1;

		[HideInInspector]
		public List<ERSORoad> soData = new List<ERSORoad>();

		[HideInInspector]
		public List<ERSORoadExt> soDataExt = new List<ERSORoadExt>();

		[HideInInspector]
		public List<ERSORoadLog> soDataLog = new List<ERSORoadLog>();

		public int layer = 0;

		public bool isStatic = true;

		public string tag = "Untagged";

		public int renderingLayerMask = 0;

		[HideInInspector]
		public bool splatMapActive = false;

		public int splatIndex = 0;

		public int expandLevel = 0;

		public int smoothLevel = 1;

		public float splatOpacity = 1f;

		public bool followTerrainContours;

		public float terrainContoursOffset = 5f;

		public bool terrainDeformation = true;

		public float defaultIndent = 2f;

		public float defaultSurrounding = 2f;

		[HideInInspector]
		public float maxRoadheight = 0f;

		[HideInInspector]
		public float maxTerrainHeightOffset = 0f;

		[HideInInspector]
		public float minTerrainHeightDistance = 5f;

		[HideInInspector]
		public float maxTerrainHeightDistance = 15f;

		public bool castShadow = false;

		[HideInInspector]
		public bool randomnessFlag = false;

		[HideInInspector]
		public float randomYPosition = 0f;

		[HideInInspector]
		public float randomMinYPosition = -0.02f;

		[HideInInspector]
		public float randomMaxYPosition = 0.02f;

		[HideInInspector]
		public float minRandomYPositionDistance = 15f;

		[HideInInspector]
		public float maxRandomYPositionDistance = 35f;

		[HideInInspector]
		public float randomMinRotation = -1f;

		[HideInInspector]
		public float randomMaxRotation = 1f;

		[HideInInspector]
		public float minRandomRotationDistance = 15f;

		[HideInInspector]
		public float maxRandomRotationDistance = 30f;

		[HideInInspector]
		public bool vegetationStudioMaskLineActive = true;

		[HideInInspector]
		public float vegetationStudioGrassPerimeter = 2f;

		[HideInInspector]
		public float vegetationStudioPlantPerimeter = 3f;

		[HideInInspector]
		public float vegetationStudioTreePerimeter = 4f;

		[HideInInspector]
		public float vegetationStudioObjectPerimeter = 3f;

		[HideInInspector]
		public float vegetationStudioLargeObjectPerimeter = 4f;

		[HideInInspector]
		public bool vegetationStudioBiomeMaskActive = false;

		[HideInInspector]
		public float vegetationStudioBiomeMaskDistance = 0f;

		[HideInInspector]
		public float vegetationStudioBiomeMaskBlendDistance = 0f;

		[HideInInspector]
		public float vegetationStudioBiomeMaskNoiseScale = 0f;

		[HideInInspector]
		public List<ERDecal> decalPresets = new List<ERDecal>();

		[HideInInspector]
		public List<ERDecalClass> decalClassPresets = new List<ERDecalClass>();

		[HideInInspector]
		public double defaultRamp = 0.0;

		[HideInInspector]
		public int extrusionType = 0;

		[HideInInspector]
		public float extrusionDistance = 10f;

		[HideInInspector]
		public float fixedDistance = 5f;

		[HideInInspector]
		public float connectionAngle = 25f;

		[HideInInspector]
		public float connectionRadius = 10f;

		[HideInInspector]
		public bool oneWay = false;

		[HideInInspector]
		public float cornerRadiusMainRoad = 3f;

		[HideInInspector]
		public int cornerSementsMainRoad = 6;

		[HideInInspector]
		public float cornerRadiusSecondaryRoad = 3f;

		[HideInInspector]
		public float cornerRadiusSecondaryCurvature = 0.5f;

		[HideInInspector]
		public int cornerSementsSecondaryRoad = 6;

		[HideInInspector]
		public bool mainRoadsOnly = false;

		[HideInInspector]
		public int isRoadShape = -1;

		[HideInInspector]
		public int controlType = 0;

		[HideInInspector]
		public Color vertexColor = Color.white;

		[HideInInspector]
		public List<ERTrafficPosts> trafficPosts = new List<ERTrafficPosts>();

		[HideInInspector]
		public int activeTrafficPostIndex = -1;

		[HideInInspector]
		public bool showTrafficPosts = false;

		[HideInInspector]
		public bool materialCreator = false;

		[HideInInspector]
		public bool synchRoadWidth = true;

		[HideInInspector]
		public int totalLanes = 2;

		[HideInInspector]
		public float laneWidth = 3.5f;

		[HideInInspector]
		public float shoulderWidthLeft = 1f;

		[HideInInspector]
		public float shoulderWidthRight = 1f;

		[HideInInspector]
		public float leftLineMarkingWidth = 0.15f;

		[HideInInspector]
		public float rightLineMarkingWidth = 0.15f;

		[HideInInspector]
		public Color leftLineMarkingColor = Color.white;

		[HideInInspector]
		public Color rightLineMarkingColor = Color.white;

		[HideInInspector]
		public ERLineMarkingStyle leftLineMarkingStyle = ERLineMarkingStyle.Solid;

		[HideInInspector]
		public ERLineMarkingStyle rightLineMarkingStyle = ERLineMarkingStyle.Solid;

		[HideInInspector]
		public float leftLineMarkingSize = 2f;

		[HideInInspector]
		public float rightLineMarkingSize = 2f;

		[HideInInspector]
		public float leftLineMarkingInterval = 2f;

		[HideInInspector]
		public float rightLineMarkingInterval = 2f;

		[HideInInspector]
		public ERLineMarkingStyle laneMarkingStyle = ERLineMarkingStyle.Broken;

		[HideInInspector]
		public Color LaneMarkingColor = Color.white;

		[HideInInspector]
		public float laneMarkingWidth = 0.15f;

		[HideInInspector]
		public float laneMarkingSize = 2f;

		[HideInInspector]
		public float laneMarkingInterval = 2f;

		[HideInInspector]
		public bool medianIsland = false;

		[HideInInspector]
		public float medianWidth = 0.5f;

		[HideInInspector]
		public ERMedianMarkingStyle medianLineMarkingStyle = ERMedianMarkingStyle.Solid;

		[HideInInspector]
		public float medianLineMarkingWidth = 0.15f;

		[HideInInspector]
		public float medianLineMarkingSize = 2f;

		[HideInInspector]
		public float medianLineMarkingInterval = 2f;

		[HideInInspector]
		public float medianLineMarkingSpace = 0.15f;

		[HideInInspector]
		public Color medianLeftLineMarkingColor = Color.white;

		[HideInInspector]
		public Color medianRightLineMarkingColor = Color.white;

		[HideInInspector]
		public ERRoadMaterialType materialType;

		[HideInInspector]
		public Texture2D baseTexture;

		[HideInInspector]
		public float baseTextureSize = 5f;

		[HideInInspector]
		public Texture2D baseTexture2;

		[HideInInspector]
		public Texture2D normalMap;

		[HideInInspector]
		public Texture2D pbrTexture;

		[HideInInspector]
		public float pbrLaneStrength = 0f;

		[HideInInspector]
		public float pbrCurveStrength = 0f;

		[HideInInspector]
		public Texture2D noiseTexture;

		[HideInInspector]
		public Texture2D noiseTexture2;

		[HideInInspector]
		public Texture2D linesTexture;

		[HideInInspector]
		public float linesTextureSize = 5f;

		[HideInInspector]
		public float linesNormalMapBlend = 0.5f;

		[HideInInspector]
		public float normalMapScale = 1f;

		[HideInInspector]
		public float metallicScale = 1f;

		[HideInInspector]
		public float smoothnessScale = 1f;

		[HideInInspector]
		public float aoScale = 1f;

		[HideInInspector]
		public ERQuality lineMaskQuality = ERQuality.High;

		[HideInInspector]
		public bool dynMapsUpdated = false;

		public void RoadTypeUpgrade()
		{
			type = ERRoadWayType.Primary;
			roadShapeExt2 = new List<Vector2>(roadShape);
			roadShapeExtUVs2 = new List<float>(roadShapeUVs);
			roadShapeData = new ERRoadShape(roadWidth);
			roadShapeData.nodes.Clear();
			for (int i = 0; i < roadShape.Count; i++)
			{
				roadShapeData.nodes.Add(roadShape[i]);
			}
		}

		public int GetTagIndex(string[] tags)
		{
			for (int i = 0; i < tags.Length; i++)
			{
				if (tags[i] == tag)
				{
					return i;
				}
			}
			return 0;
		}

		public static int GetTagIndex(string[] tags, string tag)
		{
			for (int i = 0; i < tags.Length; i++)
			{
				if (tags[i] == tag)
				{
					return i;
				}
			}
			return 0;
		}

		public void ODOQQDCCCQ()
		{
			isRoadShape = 1;
			if (doConnectionTri.Count != roadShape.Count)
			{
				return;
			}
			for (int i = 0; i < roadShape.Count - 1; i++)
			{
				if (roadShape[i].x <= roadShape[i + 1].x)
				{
					if (roadShape[i].x < roadShape[i + 1].x && !doConnectionTri[i])
					{
						isRoadShape = 0;
						break;
					}
					continue;
				}
				isRoadShape = 0;
				break;
			}
		}

		public QDQDOOQQDQODD(int count)
		{
			roadTypeName = "Road Type " + count;
			UpdateTimestamp();
			id = timestamp;
			ERModularBase eRModularBase = UnityEngine.Object.FindObjectOfType<ERModularBase>();
			if (eRModularBase != null)
			{
				cornerRadiusMainRoad = eRModularBase.cornerRadiusMainRoad;
				cornerSementsMainRoad = eRModularBase.cornerSementsMainRoad;
				cornerRadiusSecondaryRoad = eRModularBase.cornerRadiusSecondaryRoad;
				cornerRadiusSecondaryCurvature = eRModularBase.cornerRadiusSecondaryCurvature;
				cornerSementsSecondaryRoad = eRModularBase.cornerSementsSecondaryRoad;
			}
		}

		public void UpdateTimestamp()
		{
			timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			ODOQQDCCCQ();
		}

		public static bool OCQDOCODOC(ERModularBase scr)
		{
			bool result = false;
			for (int i = 0; i < scr.roadTypes.Count; i++)
			{
				for (int j = i + 1; j < scr.roadTypes.Count; j++)
				{
					if (scr.roadTypes[i].id == scr.roadTypes[j].id)
					{
						scr.roadTypes[j].id = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
						result = true;
						string text = "";
						string text2 = scr.roadTypes[j].roadTypeName;
						if (scr.roadTypes[i].roadTypeName == scr.roadTypes[j].roadTypeName)
						{
							text = "and renamed to '" + scr.roadTypes[j].roadTypeName + " [Duplicate]'";
							scr.roadTypes[j].roadTypeName = scr.roadTypes[j].roadTypeName + " [Duplicate]";
						}
						Debug.Log("EasyRoads3Dv3 Warning: Duplicated road type conflict detected between '" + scr.roadTypes[i].roadTypeName + "' and '" + text2 + "'. '" + text2 + "' has been updated " + text + ". Please review the scene if this road type is currently used, otherwise you may want to delete it.");
					}
				}
			}
			return result;
		}

		public static string[] RoadNames(List<QDQDOOQQDQODD> roadTypes)
		{
			List<string> list = new List<string>();
			if (roadTypes.Count > 0)
			{
				list.Add("Select Road Type");
				int num = 1;
				for (int i = 0; i < roadTypes.Count; i++)
				{
					list.Add(num + ". " + roadTypes[i].roadTypeName);
					num++;
				}
			}
			else
			{
				list.Add("No Road Types Available");
			}
			return list.ToArray();
		}

		public static string[] Nodes(ERRoadShape data)
		{
			List<string> list = new List<string>();
			if (data.nodes.Count > 0)
			{
				for (int i = 0; i < data.nodes.Count; i++)
				{
					list.Add("Node " + (i + 1));
				}
			}
			else
			{
				list.Add("No Nodes Available");
			}
			return list.ToArray();
		}

		public static string[] LaneNodes(ERRoadShape data)
		{
			List<string> list = new List<string>();
			if (data.lanes.Count > 0)
			{
				for (int i = 0; i < data.lanes.Count; i++)
				{
					list.Add("Lane " + (i + 1));
				}
			}
			else
			{
				list.Add("No lanes Available");
			}
			return list.ToArray();
		}

		public static GUIContent[] LaneNodesContents(ERRoadShape data)
		{
			List<GUIContent> list = new List<GUIContent>();
			if (data.lanes.Count > 0)
			{
				for (int i = 0; i < data.lanes.Count; i++)
				{
					list.Add(new GUIContent("Lane " + (i + 1), ""));
				}
			}
			else
			{
				list.Add(new GUIContent("No lanes Available", ""));
			}
			return list.ToArray();
		}

		public void OQCOOODCQC()
		{
			roadShapeData.leftLanes = (roadShapeData.rightLanes = 0);
			for (int i = 0; i < roadShapeData.lanes.Count; i++)
			{
				ERLane value = roadShapeData.lanes[i];
				if (roadShapeData.lanes[i].direction == ERLaneDirection.Right)
				{
					value.laneIndex = roadShapeData.rightLanes;
					roadShapeData.rightLanes++;
				}
				else
				{
					value.laneIndex = roadShapeData.leftLanes;
					roadShapeData.leftLanes++;
				}
				roadShapeData.lanes[i] = value;
			}
			for (int j = 0; j < roadShapeData.lanes.Count; j++)
			{
				if (roadShapeData.lanes[j].direction == ERLaneDirection.Right)
				{
					ERLane value2 = roadShapeData.lanes[j];
					value2.laneIndex = roadShapeData.rightLanes - roadShapeData.lanes[j].laneIndex - 1;
					roadShapeData.lanes[j] = value2;
				}
			}
			totalLanes = roadShapeData.lanes.Count;
		}

		public static int SetRoadType(List<QDQDOOQQDQODD> roadTypes, double roadType)
		{
			if (roadTypes.Count > 0)
			{
				for (int i = 0; i < roadTypes.Count; i++)
				{
					if (roadTypes[i].id == roadType)
					{
						return i + 1;
					}
				}
				return 0;
			}
			return 0;
		}

		public void UpdateUVs()
		{
			int outerLaneMarkingLeftIndex = roadShapeData.outerLaneMarkingLeftIndex;
			int outerLaneMarkingRightIndex = roadShapeData.outerLaneMarkingRightIndex;
			bool includeOuterlaneLeftInShape = roadShapeData.includeOuterlaneLeftInShape;
			bool includeOuterlaneRightInShape = roadShapeData.includeOuterlaneRightInShape;
			int num = 0;
			for (int i = 0; i < roadShapeExtUVs2.Count; i++)
			{
				if ((i != outerLaneMarkingLeftIndex || includeOuterlaneLeftInShape) && (i != outerLaneMarkingRightIndex || includeOuterlaneRightInShape))
				{
					if (roadShapeUVs.Count > num)
					{
						roadShapeUVs[num] = roadShapeExtUVs2[i];
					}
					num++;
				}
			}
		}

		public static QDQDOOQQDQODD GetRoadTypeElByID(List<QDQDOOQQDQODD> roadTypes, double id, bool clone = false)
		{
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id == id)
				{
					if (clone)
					{
						QDQDOOQQDQODD qDQDOOQQDQODD = new QDQDOOQQDQODD(roadTypes.Count + 1);
						qDQDOOQQDQODD.OOODDCQQOQ(roadTypes[i], null, null, copyShapeData: true, fromLog: false);
						return qDQDOOQQDQODD;
					}
					return roadTypes[i];
				}
			}
			return null;
		}

		public static int ODQQDQODQD(List<QDQDOOQQDQODD> roadTypes, double id, ref string[] ramps, ref QDQDOOQQDQODD[] rampTypes)
		{
			int result = 0;
			List<string> list = new List<string>();
			List<QDQDOOQQDQODD> list2 = new List<QDQDOOQQDQODD>();
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].type == ERRoadWayType.MotorwayRamp)
				{
					list.Add(list.Count + ". " + roadTypes[i].roadTypeName);
					list2.Add(roadTypes[i]);
					if (roadTypes[i].id == id)
					{
						result = list.Count;
					}
				}
			}
			if (list.Count == 0)
			{
				list.Add("No Motorway Ramps available");
			}
			else
			{
				list.Insert(0, "Select Motorway Ramp");
			}
			ramps = list.ToArray();
			rampTypes = list2.ToArray();
			return result;
		}

		public static int GetRoadTypeByID(List<QDQDOOQQDQODD> roadTypes, double id)
		{
			if (id == 0.0)
			{
				return 0;
			}
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id.ToString().Equals(id.ToString()))
				{
					return i + 1;
				}
			}
			Debug.LogWarning("EasyRoads3Dv3: The road type associated with this connection is not available in this road network");
			return 0;
		}

		public static bool OCOCQDCODO(List<QDQDOOQQDQODD> roadTypes, double id, ref QDQDOOQQDQODD motorwayLink)
		{
			QDQDOOQQDQODD roadTypeElByID = GetRoadTypeElByID(roadTypes, id);
			return false;
		}

		public static string[] OOQOOCQQQQ(List<QDQDOOQQDQODD> roadTypes)
		{
			List<string> list = new List<string>();
			if (roadTypes.Count > 0)
			{
				int num = 1;
				for (int i = 0; i < roadTypes.Count; i++)
				{
					if (roadTypes[i].type == ERRoadWayType.MotorwayRamp)
					{
						list.Add(num + ". " + roadTypes[i].roadTypeName);
						num++;
					}
				}
			}
			else
			{
				list.Add("No Ramp Types Available");
			}
			return list.ToArray();
		}

		public static bool GetTerrainDeformationByID(List<QDQDOOQQDQODD> roadTypes, double id, ref int element)
		{
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id == id)
				{
					element = i;
					return roadTypes[i].terrainDeformation;
				}
			}
			return true;
		}

		public static void UpdateUVTiling(List<QDQDOOQQDQODD> roadTypes, double id, float tiling)
		{
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id == id)
				{
					roadTypes[i].uvTiling = tiling;
					roadTypes[i].UpdateTimestamp();
					break;
				}
			}
		}

		public static void UpdateResolution(List<QDQDOOQQDQODD> roadTypes, double id, ref float resolution, ref float threshold)
		{
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id == id)
				{
					resolution = roadTypes[i].faceDistance;
					threshold = roadTypes[i].angleTreshold;
					break;
				}
			}
		}

		public void OOODDCQQOQ(QDQDOOQQDQODD sourcePreset, List<SideObject> sceneSideObjects, List<SideObjectLog> projectSideObjects, bool copyShapeData, bool fromLog)
		{
			roadTypeName = sourcePreset.roadTypeName;
			id = sourcePreset.id;
			type = sourcePreset.type;
			if (copyShapeData)
			{
				roadShapeData = sourcePreset.roadShapeData;
			}
			roadShapeDataActive = sourcePreset.roadShapeDataActive;
			timestamp = sourcePreset.timestamp;
			roadWidth = sourcePreset.roadWidth;
			totalLanes = sourcePreset.totalLanes;
			faceDistance = sourcePreset.faceDistance;
			angleTreshold = sourcePreset.angleTreshold;
			uvTiling = sourcePreset.uvTiling;
			planarUVs = sourcePreset.planarUVs;
			outerIndent = sourcePreset.outerIndent;
			roadShape = new List<Vector2>(sourcePreset.roadShape);
			roadShapeExt = new List<Vector2>(sourcePreset.roadShapeExt);
			roadShapeExt2 = new List<Vector2>(sourcePreset.roadShapeExt2);
			doConnectionTri = new List<bool>(sourcePreset.doConnectionTri);
			roadShapeUVs = new List<float>(sourcePreset.roadShapeUVs);
			roadShapeUVs2 = new List<float>(sourcePreset.roadShapeUVs2);
			roadShapeExtUVs = new List<float>(sourcePreset.roadShapeExtUVs);
			roadShapeExtUVs2 = new List<float>(sourcePreset.roadShapeExtUVs2);
			hardEdge = new List<bool>(sourcePreset.hardEdge);
			roadShapeVecsString = sourcePreset.roadShapeVecsString;
			sidewalks = sourcePreset.sidewalks;
			sidewalkHeight = sourcePreset.sidewalkHeight;
			sidewalkWidth = sourcePreset.sidewalkWidth;
			defaultSidewalk = sourcePreset.defaultSidewalk;
			sidewalks = sourcePreset.sidewalks;
			crosswalks = sourcePreset.crosswalks;
			crosswalkIntervals = sourcePreset.crosswalkIntervals;
			crosswalksIntersections = sourcePreset.crosswalksIntersections;
			crosswalkPrefab = sourcePreset.crosswalkPrefab;
			crosswalkHeightOffset = sourcePreset.crosswalkHeightOffset;
			crosswalkDecal = sourcePreset.crosswalkDecal;
			crosswalkType = sourcePreset.crosswalkType;
			subSegments = sourcePreset.subSegments;
			roadMaterial = sourcePreset.roadMaterial;
			if (sourcePreset.roadMaterials != null)
			{
				roadMaterials = new Material[sourcePreset.roadMaterials.Length];
				Array.Copy(sourcePreset.roadMaterials, roadMaterials, sourcePreset.roadMaterials.Length);
			}
			roadPhysicsMaterial = sourcePreset.roadPhysicsMaterial;
			if (sourcePreset.roadPhysicsMaterials != null)
			{
				roadPhysicsMaterials = new PhysicsMaterial[sourcePreset.roadPhysicsMaterials.Length];
				Array.Copy(sourcePreset.roadPhysicsMaterials, roadPhysicsMaterials, sourcePreset.roadPhysicsMaterials.Length);
			}
			connectionMaterial = sourcePreset.connectionMaterial;
			isSideObject = sourcePreset.isSideObject;
			isCustomRoad = sourcePreset.isCustomRoad;
			layer = sourcePreset.layer;
			isStatic = sourcePreset.isStatic;
			if (!string.IsNullOrEmpty(sourcePreset.tag))
			{
				tag = sourcePreset.tag;
			}
			renderingLayerMask = sourcePreset.renderingLayerMask;
			castShadow = sourcePreset.castShadow;
			splatMapActive = sourcePreset.splatMapActive;
			splatIndex = sourcePreset.splatIndex;
			expandLevel = sourcePreset.expandLevel;
			smoothLevel = sourcePreset.smoothLevel;
			splatOpacity = sourcePreset.splatOpacity;
			terrainDeformation = sourcePreset.terrainDeformation;
			defaultIndent = sourcePreset.defaultIndent;
			defaultSurrounding = sourcePreset.defaultSurrounding;
			followTerrainContours = sourcePreset.followTerrainContours;
			terrainContoursOffset = sourcePreset.terrainContoursOffset;
			maxRoadheight = sourcePreset.maxRoadheight;
			maxTerrainHeightOffset = sourcePreset.maxTerrainHeightOffset;
			minTerrainHeightDistance = sourcePreset.minTerrainHeightDistance;
			maxTerrainHeightDistance = sourcePreset.maxTerrainHeightDistance;
			randomYPosition = sourcePreset.randomYPosition;
			randomMinYPosition = sourcePreset.randomMinYPosition;
			randomMaxYPosition = sourcePreset.randomMaxYPosition;
			minRandomYPositionDistance = sourcePreset.minRandomYPositionDistance;
			maxRandomYPositionDistance = sourcePreset.maxRandomYPositionDistance;
			randomMinRotation = sourcePreset.randomMinRotation;
			randomMaxRotation = sourcePreset.randomMaxRotation;
			minRandomRotationDistance = sourcePreset.minRandomRotationDistance;
			maxRandomRotationDistance = sourcePreset.maxRandomRotationDistance;
			vegetationStudioMaskLineActive = sourcePreset.vegetationStudioMaskLineActive;
			vegetationStudioGrassPerimeter = sourcePreset.vegetationStudioGrassPerimeter;
			vegetationStudioPlantPerimeter = sourcePreset.vegetationStudioPlantPerimeter;
			vegetationStudioTreePerimeter = sourcePreset.vegetationStudioTreePerimeter;
			vegetationStudioObjectPerimeter = sourcePreset.vegetationStudioObjectPerimeter;
			vegetationStudioLargeObjectPerimeter = sourcePreset.vegetationStudioLargeObjectPerimeter;
			vegetationStudioBiomeMaskActive = sourcePreset.vegetationStudioBiomeMaskActive;
			vegetationStudioBiomeMaskDistance = sourcePreset.vegetationStudioBiomeMaskDistance;
			vegetationStudioBiomeMaskBlendDistance = sourcePreset.vegetationStudioBiomeMaskBlendDistance;
			vegetationStudioBiomeMaskNoiseScale = sourcePreset.vegetationStudioBiomeMaskNoiseScale;
			defaultRamp = sourcePreset.defaultRamp;
			extrusionType = sourcePreset.extrusionType;
			extrusionDistance = sourcePreset.extrusionDistance;
			fixedDistance = sourcePreset.fixedDistance;
			connectionAngle = sourcePreset.connectionAngle;
			connectionRadius = sourcePreset.connectionRadius;
			vertexColor = sourcePreset.vertexColor;
			isRoadShape = sourcePreset.isRoadShape;
			oneWay = sourcePreset.oneWay;
			cornerRadiusMainRoad = sourcePreset.cornerRadiusMainRoad;
			cornerSementsMainRoad = sourcePreset.cornerSementsMainRoad;
			cornerRadiusSecondaryRoad = sourcePreset.cornerRadiusSecondaryRoad;
			cornerRadiusSecondaryCurvature = sourcePreset.cornerRadiusSecondaryCurvature;
			cornerSementsSecondaryRoad = sourcePreset.cornerSementsSecondaryRoad;
			mainRoadsOnly = sourcePreset.mainRoadsOnly;
			minSpeed = sourcePreset.minSpeed;
			maxSpeed = sourcePreset.maxSpeed;
			speedLimit = sourcePreset.speedLimit;
			speedLimitConnections = sourcePreset.speedLimitConnections;
			if (fromLog && sourcePreset.decalClassPresets != null && sourcePreset.decalClassPresets.Count > 0)
			{
				for (int i = 0; i < sourcePreset.decalClassPresets.Count; i++)
				{
					bool flag = false;
					for (int j = 0; j < decalPresets.Count; j++)
					{
						if (decalPresets[j] != null && sourcePreset.decalClassPresets[i] != null && decalPresets[j].id == sourcePreset.decalClassPresets[i].id)
						{
							ERDecal.CopyDecal(sourcePreset.decalClassPresets[i], decalPresets[j]);
							flag = true;
							break;
						}
					}
					if (!flag && sourcePreset.decalClassPresets[i] != null)
					{
						ERDecal eRDecal = ERDecal.CreateInstance(sourcePreset.decalClassPresets[i].decalPrefab, sourcePreset.decalClassPresets[i].baseWidth);
						ERDecal.CopyDecal(sourcePreset.decalClassPresets[i], eRDecal);
						decalPresets.Add(eRDecal);
					}
				}
				for (int k = 0; k < decalPresets.Count; k++)
				{
					bool flag2 = false;
					for (int l = 0; l < sourcePreset.decalClassPresets.Count; l++)
					{
						if (decalPresets[k] != null && sourcePreset.decalClassPresets[l] != null && decalPresets[k].id == sourcePreset.decalClassPresets[l].id)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						decalPresets.RemoveAt(k);
						k--;
					}
				}
			}
			else if (!fromLog && sourcePreset.decalPresets != null && sourcePreset.decalPresets.Count > 0)
			{
				decalPresets = new List<ERDecal>();
				if (sourcePreset.decalPresets != null)
				{
					decalPresets = new List<ERDecal>(sourcePreset.decalPresets);
				}
			}
			trafficPosts = new List<ERTrafficPosts>();
			if (sourcePreset.trafficPosts != null)
			{
				trafficPosts = new List<ERTrafficPosts>(sourcePreset.trafficPosts);
			}
			soDataExt.Clear();
			if (sceneSideObjects != null)
			{
				for (int m = 0; m < sceneSideObjects.Count; m++)
				{
					soDataExt.Add(ERSORoadExt.CreateInstance(sceneSideObjects[m]));
				}
			}
			for (int n = 0; n < sourcePreset.soDataLog.Count; n++)
			{
				if (!sourcePreset.soDataLog[n].active)
				{
					continue;
				}
				for (int num = 0; num < soDataExt.Count; num++)
				{
					if (sourcePreset.soDataLog[n].id == soDataExt[num].sideObject.id)
					{
						soDataExt[num].active = true;
						break;
					}
				}
			}
		}

		public static void OCQCCOOODO(QDQDOOQQDQODD sourcePreset, ERModularRoad road, bool update, int customShapeHandling, bool checkRoadWidth)
		{
			road.subSegments = sourcePreset.subSegments;
			road.rt = new QDQDOOQQDQODD(road.baseScript.roadTypes.Count + 1);
			road.rt.OOODDCQQOQ(sourcePreset, null, null, copyShapeData: true, fromLog: false);
			List<Vector2> list = new List<Vector2>(road.roadShape);
			list.Reverse();
			if ((sourcePreset.roadWidth != road.roadWidth || !OQQOCDQCQD.Vector2ListComparer(list, sourcePreset.roadShape)) && !sourcePreset.isCustomRoad && checkRoadWidth)
			{
				float num = road.roadWidth;
				List<Vector2> list2 = new List<Vector2>(road.roadShape);
				road.roadWidth = sourcePreset.roadWidth;
				ODDOQDDQCQ.GetRoadShape(road.roadWidth, road.subSegments, ref road.roadShape, ref road.roadShapeUVs, ref road.roadShapeUVs2, -1f);
				road.roadShapeMatchCount = road.subSegments + 1;
				if (road.roadShape.Count != sourcePreset.roadShape.Count)
				{
					customShapeHandling = 1;
					road.roadShapeMaterialIntCounts.Clear();
					for (int i = 0; i < road.roadShapeMaterialInts.Count; i++)
					{
						if (road.roadShapeMaterialInts[i] >= road.roadShapeMaterialIntCounts.Count)
						{
							while (road.roadShapeMaterialInts[i] >= road.roadShapeMaterialIntCounts.Count)
							{
								road.roadShapeMaterialIntCounts.Add(0);
							}
						}
						road.roadShapeMaterialIntCounts[road.roadShapeMaterialInts[i]]++;
					}
				}
				road.roadShape = new List<Vector2>(sourcePreset.roadShape);
				road.roadShape.Reverse();
				road.roadShapeUVs = new List<float>(sourcePreset.roadShapeUVs);
				road.roadShapeUVs2 = new List<float>(sourcePreset.roadShapeUVs2);
				int num2 = 1;
				for (int j = 1; j < road.roadShape.Count; j++)
				{
					if ((double)Vector2.Distance(road.roadShape[j - 1], road.roadShape[j]) > 0.01)
					{
						num2++;
					}
				}
				road.roadShapeMatchCount = num2;
				bool flag = false;
				float num3 = road.roadWidth / num;
				for (int k = 0; k < road.markersExt.Count; k++)
				{
					if (!OQQOCDQCQD.Vector2ListComparer(list2, road.markersExt[k].roadShape))
					{
						switch (customShapeHandling)
						{
						case 1:
							road.markersExt[k].roadShape.Clear();
							road.markersExt[k].roadShape = new List<Vector2>(road.roadShape);
							break;
						case 2:
						{
							for (int l = 0; l < road.markersExt[k].roadShape.Count; l++)
							{
								Vector2 value = road.markersExt[k].roadShape[l];
								value.x *= num3;
								road.markersExt[k].roadShape[l] = value;
							}
							break;
						}
						}
					}
					else
					{
						road.markersExt[k].roadShape.Clear();
						road.markersExt[k].roadShape = new List<Vector2>(road.roadShape);
					}
				}
			}
			else if (road.roadShapeMatchCount == 0)
			{
				int num4 = 1;
				for (int m = 1; m < road.roadShape.Count; m++)
				{
					if ((double)Vector2.Distance(road.roadShape[m - 1], road.roadShape[m]) > 0.01)
					{
						num4++;
					}
				}
				road.roadShapeMatchCount = num4;
			}
			if (road.roadShapeUVs.Count == sourcePreset.roadShapeUVs.Count && road.roadShapeUVs2.Count == sourcePreset.roadShapeUVs2.Count)
			{
				road.roadShapeUVs = new List<float>(sourcePreset.roadShapeUVs);
				road.roadShapeUVs2 = new List<float>(sourcePreset.roadShapeUVs2);
				if (road.flipRoadUVs)
				{
					OQOCQDQODD.OQOCODDQDO(ref road.roadShapeUVs, ref road.roadShapeUVs2);
				}
				update = true;
			}
			road.defaultLeftSidewalkid = (road.defaultRightSidewalkid = sourcePreset.defaultSidewalk);
			foreach (ERSideWalkInstance leftSidewalk in road.leftSidewalks)
			{
				foreach (ERSideWalk sidewalk in road.baseScript.sidewalks)
				{
					leftSidewalk.id = road.defaultLeftSidewalkid;
				}
			}
			foreach (ERSideWalkInstance rightSidewalk in road.rightSidewalks)
			{
				foreach (ERSideWalk sidewalk2 in road.baseScript.sidewalks)
				{
					rightSidewalk.id = road.defaultRightSidewalkid;
				}
			}
			if (sourcePreset.sidewalks)
			{
				road.leftSidewalkActive = (road.rightSidewalkActive = sourcePreset.sidewalks);
			}
			if (!road.resolutionFlag)
			{
				road.faceDistance = sourcePreset.faceDistance;
			}
			if (!road.angleThresholdFlag)
			{
				road.angleTreshold = sourcePreset.angleTreshold;
			}
			if (!road.lockUVTiling)
			{
				road.uvTiling = sourcePreset.uvTiling;
			}
			road.planarUVs = sourcePreset.planarUVs;
			road.roadMaterial = sourcePreset.roadMaterial;
			if (sourcePreset.roadMaterials != null)
			{
				road.roadMaterials = new Material[sourcePreset.roadMaterials.Length];
				Array.Copy(sourcePreset.roadMaterials, road.roadMaterials, sourcePreset.roadMaterials.Length);
			}
			road.roadPhysicsMaterial = sourcePreset.roadPhysicsMaterial;
			if (sourcePreset.roadPhysicsMaterials != null)
			{
				road.roadPhysicsMaterials = new PhysicsMaterial[sourcePreset.roadPhysicsMaterials.Length];
				Array.Copy(sourcePreset.roadPhysicsMaterials, road.roadPhysicsMaterials, sourcePreset.roadPhysicsMaterials.Length);
			}
			if (sourcePreset.isSideObject && !road.isSideObject)
			{
				if ((bool)road.gameObject.GetComponent<MeshFilter>())
				{
					UnityEngine.Object.DestroyImmediate(road.gameObject.GetComponent<MeshFilter>());
				}
				if ((bool)road.gameObject.GetComponent<MeshRenderer>())
				{
					UnityEngine.Object.DestroyImmediate(road.gameObject.GetComponent<MeshRenderer>());
				}
				if ((bool)road.gameObject.GetComponent<MeshCollider>())
				{
					UnityEngine.Object.DestroyImmediate(road.gameObject.GetComponent<MeshCollider>());
				}
			}
			road.isSideObject = sourcePreset.isSideObject;
			int num5 = (road.gameObject.layer = sourcePreset.layer);
			road.layer = num5;
			if (!string.IsNullOrEmpty(sourcePreset.tag))
			{
				string text = (road.gameObject.tag = sourcePreset.tag);
				road.tag = text;
			}
			if (ERModularBase.isHDRP || ERModularBase.isURP)
			{
				road.gameObject.GetComponent<MeshRenderer>().renderingLayerMask = OQQOCDQCQD.GetLayerMask(sourcePreset.renderingLayerMask, includeDefault: true);
			}
			bool flag2 = (road.gameObject.isStatic = sourcePreset.isStatic);
			road.isStatic = flag2;
			road.castShadow = sourcePreset.castShadow;
			if (road.castShadow && (bool)road.gameObject.GetComponent<MeshRenderer>())
			{
				road.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else if ((bool)road.gameObject.GetComponent<MeshRenderer>())
			{
				road.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			road.splatMapActive = sourcePreset.splatMapActive;
			road.splatIndex = sourcePreset.splatIndex;
			road.expandLevel = sourcePreset.expandLevel;
			road.smoothLevel = sourcePreset.smoothLevel;
			road.splatOpacity = sourcePreset.splatOpacity;
			road.terrainDeformation = sourcePreset.terrainDeformation;
			bool flag4 = false;
			if (road.followTerrainContours != sourcePreset.followTerrainContours && sourcePreset.followTerrainContours)
			{
				flag4 = true;
			}
			road.followTerrainContours = sourcePreset.followTerrainContours;
			road.terrainContoursOffset = sourcePreset.terrainContoursOffset;
			if (road.indent != sourcePreset.defaultIndent || road.surrounding != sourcePreset.defaultSurrounding || road.vertexColor != sourcePreset.vertexColor)
			{
				for (int n = 0; n < road.markersExt.Count; n++)
				{
					if (road.indent != sourcePreset.defaultIndent && road.baseScript != null)
					{
						if (road.baseScript.terrainMinIndent <= sourcePreset.defaultIndent)
						{
							if (road.indent == road.markersExt[n].leftIndent)
							{
								road.markersExt[n].leftIndent = sourcePreset.defaultIndent;
							}
							if (road.indent == road.markersExt[n].rightIndent)
							{
								road.markersExt[n].rightIndent = sourcePreset.defaultIndent;
							}
						}
						else
						{
							if (road.indent == road.markersExt[n].leftIndent)
							{
								road.markersExt[n].leftIndent = road.baseScript.terrainMinIndent;
							}
							if (road.indent == road.markersExt[n].rightIndent)
							{
								road.markersExt[n].rightIndent = road.baseScript.terrainMinIndent;
							}
						}
					}
					if (road.surrounding != sourcePreset.defaultSurrounding)
					{
						if (road.surrounding == road.markersExt[n].leftSurrounding)
						{
							road.markersExt[n].leftSurrounding = sourcePreset.defaultSurrounding;
						}
						if (road.surrounding == road.markersExt[n].rightSurrounding)
						{
							road.markersExt[n].rightSurrounding = sourcePreset.defaultSurrounding;
						}
					}
					if (road.vertexColor != sourcePreset.vertexColor && road.vertexColor == road.markersExt[n].customColor)
					{
						road.markersExt[n].customColor = sourcePreset.vertexColor;
					}
				}
			}
			road.vertexColor = sourcePreset.vertexColor;
			if (road.baseScript != null)
			{
				if (road.baseScript.terrainMinIndent <= sourcePreset.defaultIndent)
				{
					road.indent = sourcePreset.defaultIndent;
				}
				else
				{
					road.indent = road.baseScript.terrainMinIndent;
				}
			}
			else
			{
				road.indent = sourcePreset.defaultIndent;
			}
			road.surrounding = sourcePreset.defaultSurrounding;
			road.randomYPosition = sourcePreset.randomYPosition;
			road.randomMinYPosition = sourcePreset.randomMinYPosition;
			road.randomMaxYPosition = sourcePreset.randomMaxYPosition;
			road.minRandomYPositionDistance = sourcePreset.minRandomYPositionDistance;
			road.maxRandomYPositionDistance = sourcePreset.maxRandomYPositionDistance;
			road.randomMinRotation = sourcePreset.randomMinRotation;
			road.randomMaxRotation = sourcePreset.randomMaxRotation;
			road.minRandomRotationDistance = sourcePreset.minRandomRotationDistance;
			road.maxRandomRotationDistance = sourcePreset.maxRandomRotationDistance;
			for (int num7 = 0; num7 < road.markersExt.Count; num7++)
			{
				road.markersExt[num7].randomYPosition = sourcePreset.randomYPosition;
				road.markersExt[num7].randomMinYPosition = sourcePreset.randomMinYPosition;
				road.markersExt[num7].randomMaxYPosition = sourcePreset.randomMaxYPosition;
				road.markersExt[num7].minRandomYPositionDistance = sourcePreset.minRandomYPositionDistance;
				road.markersExt[num7].maxRandomYPositionDistance = sourcePreset.maxRandomYPositionDistance;
				road.markersExt[num7].randomMinRotation = sourcePreset.randomMinRotation;
				road.markersExt[num7].randomMaxRotation = sourcePreset.randomMaxRotation;
				road.markersExt[num7].minRandomRotationDistance = sourcePreset.minRandomRotationDistance;
				road.markersExt[num7].maxRandomRotationDistance = sourcePreset.maxRandomRotationDistance;
				if (flag4 && sourcePreset.followTerrainContours)
				{
					if (!road.markersExt[num7].bridgeObject)
					{
						road.markersExt[num7].followTerrainContours = road.followTerrainContours;
						Vector3 pos = road.markersExt[num7].position;
						road.baseScript.OQCCDQOQOO(ref pos);
						road.markersExt[num7].position = pos;
					}
				}
				else if (!sourcePreset.followTerrainContours)
				{
					road.markersExt[num7].followTerrainContours = false;
				}
			}
			road.vegetationStudioMaskLineActive = sourcePreset.vegetationStudioMaskLineActive;
			road.vegetationStudioGrassPerimeter = sourcePreset.vegetationStudioGrassPerimeter;
			road.vegetationStudioPlantPerimeter = sourcePreset.vegetationStudioPlantPerimeter;
			road.vegetationStudioTreePerimeter = sourcePreset.vegetationStudioTreePerimeter;
			road.vegetationStudioObjectPerimeter = sourcePreset.vegetationStudioObjectPerimeter;
			road.vegetationStudioLargeObjectPerimeter = sourcePreset.vegetationStudioLargeObjectPerimeter;
			road.vegetationStudioBiomeMaskActive = sourcePreset.vegetationStudioBiomeMaskActive;
			road.vegetationStudioBiomeMaskDistance = sourcePreset.vegetationStudioBiomeMaskDistance;
			road.vegetationStudioBiomeMaskBlendDistance = sourcePreset.vegetationStudioBiomeMaskBlendDistance;
			road.vegetationStudioBiomeMaskNoiseScale = sourcePreset.vegetationStudioBiomeMaskNoiseScale;
			road.OOOODOCQCQ(road.vegetationStudioMaskLineActive, road.vegetationStudioBiomeMaskActive);
			if (road.baseScript != null && (road.baseScript.vegetationStudio || road.baseScript.vegetationStudioPro))
			{
				if (road.vegetationStudioMaskLineActive)
				{
					float num8 = sourcePreset.roadWidth;
					object[] parameters = new object[6]
					{
						road.gameObject,
						2f * road.vegetationStudioGrassPerimeter,
						2f * road.vegetationStudioPlantPerimeter,
						2f * road.vegetationStudioTreePerimeter,
						2f * road.vegetationStudioObjectPerimeter,
						2f * road.vegetationStudioLargeObjectPerimeter
					};
					road.baseScript.crMethod.Invoke(null, parameters);
				}
				if (road.vegetationStudioBiomeMaskActive)
				{
					float num9 = sourcePreset.roadWidth;
					object[] parameters2 = new object[4] { road.gameObject, road.vegetationStudioBiomeMaskDistance, road.vegetationStudioBiomeMaskBlendDistance, road.vegetationStudioBiomeMaskNoiseScale };
					road.baseScript.crBiomeMethod.Invoke(null, parameters2);
				}
			}
			bool flag5 = false;
			bool flag6 = false;
			foreach (ERDecal decalPreset in sourcePreset.decalPresets)
			{
				if (decalPreset != null)
				{
					if (decalPreset.id == road.startDecalID)
					{
						flag5 = true;
					}
					if (decalPreset.id == road.endDecalID)
					{
						flag6 = true;
					}
					if (flag5 && flag6)
					{
						break;
					}
				}
			}
			if (!flag5)
			{
				road.startDecalID = -1;
				if (road.startDecalPrefab != null)
				{
					if (Application.isEditor && !Application.isPlaying)
					{
						UnityEngine.Object.DestroyImmediate(road.startDecalPrefab);
					}
					else
					{
						UnityEngine.Object.Destroy(road.startDecalPrefab);
					}
				}
			}
			if (!flag6)
			{
				road.endDecalID = -1;
				if (road.endDecalPrefab != null)
				{
					if (Application.isEditor && !Application.isPlaying)
					{
						UnityEngine.Object.DestroyImmediate(road.endDecalPrefab);
					}
					else
					{
						UnityEngine.Object.Destroy(road.endDecalPrefab);
					}
				}
			}
			if (sourcePreset.decalPresets.Count == 0)
			{
				road.startDecalID = -1;
				road.startDecal = null;
				road.startDecalPrefabSource = null;
				road.endDecalID = -1;
				road.endDecal = null;
				road.endDecalPrefabSource = null;
			}
			else
			{
				if (road.startDecalID == -1)
				{
					int minInclusive = 0;
					int count = sourcePreset.decalPresets.Count;
					int index = UnityEngine.Random.Range(minInclusive, count);
					if (sourcePreset.decalPresets[index] != null)
					{
						road.startDecalID = sourcePreset.decalPresets[index].id;
						road.startDecal = sourcePreset.decalPresets[index];
					}
				}
				if (road.endDecalID == -1)
				{
					int minInclusive2 = 0;
					int count2 = sourcePreset.decalPresets.Count;
					int index2 = UnityEngine.Random.Range(minInclusive2, count2);
					if (sourcePreset.decalPresets[index2] != null)
					{
						road.endDecalID = sourcePreset.decalPresets[index2].id;
						road.endDecal = sourcePreset.decalPresets[index2];
					}
				}
			}
			if (!update)
			{
				return;
			}
			int num10 = -1;
			for (int num11 = 0; num11 < road.baseScript.roadTypes.Count; num11++)
			{
				if (road.baseScript.roadTypes[num11] == sourcePreset)
				{
					num10 = num11 + 1;
					break;
				}
			}
			if (num10 != -1)
			{
				AssignSideObjects(road.baseScript, num10, road);
			}
			road.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
		}

		public static void AssignSideObjects(ERModularBase scr, int roadTypeInt, ERModularRoad OOOCDDCQCD)
		{
			if (roadTypeInt - 1 < 0 || roadTypeInt - 1 >= scr.roadTypes.Count)
			{
				return;
			}
			if (scr != null)
			{
				foreach (SideObject item in scr.QOQDQOOQDDQOOQ)
				{
					bool flag = false;
					foreach (ERSORoadExt item2 in scr.roadTypes[roadTypeInt - 1].soDataExt)
					{
						if (item2 != null && item != null && item2.id == item.id)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						scr.roadTypes[roadTypeInt - 1].soDataExt.Add(ERSORoadExt.CreateInstance(item));
					}
				}
			}
			for (int i = 0; i < scr.roadTypes[roadTypeInt - 1].soDataExt.Count; i++)
			{
				if (!(scr.roadTypes[roadTypeInt - 1].soDataExt[i] != null))
				{
					continue;
				}
				bool flag2 = true;
				bool flag3 = false;
				foreach (ERSORoadExt item3 in OOOCDDCQCD.soDataExt)
				{
					if (!(item3 != null) || !(item3.sideObject != null) || !(scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject != null) || item3.sideObject.id != scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject.id)
					{
						continue;
					}
					flag2 = false;
					if (item3.autoGenerate && !scr.roadTypes[roadTypeInt - 1].soDataExt[i].autoGenerate)
					{
						item3.autoGenerate = false;
						item3.markerActive = scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject.markerActive;
						flag3 = true;
					}
					bool flag4 = true;
					if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].active)
					{
						foreach (ERSOMarkerExt soDatum in OOOCDDCQCD.markersExt[0].soData)
						{
							if (soDatum != null && soDatum.sideObject != null && soDatum.sideObject.id == item3.id)
							{
								flag4 = false;
								break;
							}
						}
					}
					if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].active && (!item3.active || flag4 || flag3))
					{
						item3.active = true;
						if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].markerActive || scr.roadTypes[roadTypeInt - 1].soDataExt[i].autoGenerate)
						{
							OCQODDCQDD.OQDCQDCQDD(OOOCDDCQCD, scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject, scr.roadTypes[roadTypeInt - 1].soDataExt[i].markerActive);
						}
					}
					else if (item3.active && scr.roadTypes[roadTypeInt - 1].soDataExt[i].active)
					{
						OOOCDDCQCD.sosCleared = false;
						if (!scr.roadTypes[roadTypeInt - 1].soDataExt[i].autoGenerate)
						{
							int num = 0;
							int num2 = 0;
							foreach (ERMarkerExt item4 in OOOCDDCQCD.markersExt)
							{
								foreach (ERSOMarkerExt soDatum2 in item4.soData)
								{
									if (soDatum2.sideObject.id == scr.roadTypes[roadTypeInt - 1].soDataExt[i].id)
									{
										if (soDatum2.active)
										{
											num++;
										}
										else
										{
											num2++;
										}
									}
								}
							}
							if (num == 0 || num == OOOCDDCQCD.markersExt.Count || num2 == 0 || num2 == OOOCDDCQCD.markersExt.Count)
							{
								foreach (ERMarkerExt item5 in OOOCDDCQCD.markersExt)
								{
									foreach (ERSOMarkerExt soDatum3 in item5.soData)
									{
										if (soDatum3.sideObject.id == scr.roadTypes[roadTypeInt - 1].soDataExt[i].id)
										{
											soDatum3.active = scr.roadTypes[roadTypeInt - 1].soDataExt[i].markerActive;
											if (soDatum3.otherSide != null)
											{
												soDatum3.otherSide.active = soDatum3.active;
											}
										}
									}
								}
							}
						}
					}
					if (!scr.roadTypes[roadTypeInt - 1].soDataExt[i].active)
					{
						break;
					}
					ERSORoadExt.Copy(scr.roadTypes[roadTypeInt - 1].soDataExt[i], item3);
					OCDOODOQDC.OQDCDQDCCQ(item3, scr.roadTypes[roadTypeInt - 1].soDataExt[i]);
					if (!item3.active || scr.roadTypes[roadTypeInt - 1].soDataExt[i].xPosition == scr.roadTypes[roadTypeInt - 1].soDataExt[i].oldXPosition)
					{
						break;
					}
					int num3 = -1;
					for (int j = 0; j < OOOCDDCQCD.markersExt.Count; j++)
					{
						if (num3 == -1)
						{
							for (int k = 0; k < OOOCDDCQCD.markersExt[j].soData.Count; k++)
							{
								if (OOOCDDCQCD.markersExt.Count > 0 && OOOCDDCQCD.markersExt != null && OOOCDDCQCD.markersExt[0] != null && OOOCDDCQCD.markersExt[0].soData != null && OOOCDDCQCD.markersExt[0].soData[k] != null && OOOCDDCQCD.markersExt[0].soData[k].id == item3.id)
								{
									num3 = k;
									break;
								}
							}
						}
						if (num3 >= 0)
						{
							OOOCDDCQCD.markersExt[j].soData[num3].xPosition = item3.xPosition;
							if (OOOCDDCQCD.markersExt[j].soData[num3].otherSide != null)
							{
								OOOCDDCQCD.markersExt[j].soData[num3].otherSide.xPosition = 0f - item3.xPosition;
							}
						}
					}
					break;
				}
				if (!flag2)
				{
					continue;
				}
				OOOCDDCQCD.soDataExt.Add(ERSORoadExt.CreateInstance(scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject));
				if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].active)
				{
					OOOCDDCQCD.soDataExt[OOOCDDCQCD.soDataExt.Count - 1].active = true;
					OOOCDDCQCD.soDataExt[OOOCDDCQCD.soDataExt.Count - 1].autoGenerate = scr.roadTypes[roadTypeInt - 1].soDataExt[i].autoGenerate;
					if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject.markerActive && scr.QOQDQOOQDDQOOQ.Count > 0)
					{
						OCQODDCQDD.OQDCQDCQDD(OOOCDDCQCD, scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject, scr.roadTypes[roadTypeInt - 1].soDataExt[i].markerActive);
					}
				}
				OCDOODOQDC.OQDCDQDCCQ(OOOCDDCQCD.soDataExt[OOOCDDCQCD.soDataExt.Count - 1], scr.roadTypes[roadTypeInt - 1].soDataExt[i]);
			}
			OOOCDDCQCD.sideObjectNames = OCQODDCQDD.OQCCQCDQQO(OOOCDDCQCD);
		}

		public static void HasActiveSideObjects(List<ERSORoadExt> sos1, List<ERSORoadExt> sos2, ref bool flag1, ref bool flag2)
		{
			bool flag3 = false;
			if (sos1 != null)
			{
				foreach (ERSORoadExt item in sos1)
				{
					if (item != null && item.active)
					{
						foreach (ERSORoadExt item2 in sos2)
						{
							if (item.id == item2.id && item2.active)
							{
								flag1 = true;
							}
						}
					}
					else
					{
						foreach (ERSORoadExt item3 in sos2)
						{
							if (item != null && item3 != null && item.id == item3.id && item3.active)
							{
								flag2 = true;
							}
						}
					}
				}
				return;
			}
			foreach (ERSORoadExt item4 in sos2)
			{
				if (item4 != null && item4.active)
				{
					flag2 = true;
				}
			}
		}

		public int OCDCDCODCO(int index, ERLaneDirection direction)
		{
			if (roadShapeData.isset)
			{
				int num = roadShapeData.lanes.Count - 1;
				if (num == -1)
				{
					return -1;
				}
				if (direction == ERLaneDirection.Right)
				{
					if (roadShapeData.lanes[num].laneIndex > 0)
					{
						OQCOOODCQC();
					}
					for (int num2 = num; num2 >= 0; num2--)
					{
						if (roadShapeData.lanes[num2].laneIndex == index)
						{
							return num2;
						}
					}
				}
				else
				{
					for (int i = 0; i <= num; i++)
					{
						if (roadShapeData.lanes[i].laneIndex == index)
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		public static bool ODQOCQCQCD(QDQDOOQQDQODD rt1, QDQDOOQQDQODD rt2)
		{
			if (rt1.roadShapeData.leftLanes != rt1.roadShapeData.leftLanes)
			{
				return false;
			}
			if (rt1.roadShapeData.rightLanes != rt1.roadShapeData.rightLanes)
			{
				return false;
			}
			return true;
		}
	}
}
