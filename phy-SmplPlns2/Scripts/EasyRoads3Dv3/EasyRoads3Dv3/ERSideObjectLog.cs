using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERSideObjectLog : MonoBehaviour
	{
		[HideInInspector]
		public List<SideObjectLog> QOQDQOOQDDQOOQ = new List<SideObjectLog>();

		[HideInInspector]
		public List<int> ints = new List<int>();

		[HideInInspector]
		public List<QDQDOOQQDQODD> roadPresets = new List<QDQDOOQQDQODD>();

		[HideInInspector]
		public List<CrossingCornerClass> crossingCornerPresets = new List<CrossingCornerClass>();

		[HideInInspector]
		public List<ERSideWalk> sidewalkPresets = new List<ERSideWalk>();

		[HideInInspector]
		public List<ERTexture> textureData = new List<ERTexture>();

		[HideInInspector]
		public List<string> presetAssets = new List<string>();

		[HideInInspector]
		public int logIndex = 0;

		[HideInInspector]
		public int updateInt = 2;

		[HideInInspector]
		public string resourcesFolder = "Resources";

		public string projectid = "";

		[HideInInspector]
		public DateTime projectDate;

		public bool isHDRP = false;

		public bool isURP = false;

		public void AddRoadPreset(List<SideObject> sceneSideObjects, List<SideObjectLog> projectSideObjects, QDQDOOQQDQODD sourcePreset)
		{
			roadPresets.Add(new QDQDOOQQDQODD(0));
			UpdateRoadPreset(sourcePreset, roadPresets.Count - 1, sceneSideObjects, projectSideObjects, copyShapeData: true);
		}

		public void UpdateRoadPreset(QDQDOOQQDQODD sourcePreset, int element, List<SideObject> sceneSideObjects, List<SideObjectLog> projectSideObjects, bool copyShapeData)
		{
			roadPresets[element].roadTypeName = sourcePreset.roadTypeName;
			roadPresets[element].id = sourcePreset.id;
			roadPresets[element].type = sourcePreset.type;
			roadPresets[element].totalLanes = sourcePreset.totalLanes;
			if (copyShapeData)
			{
				roadPresets[element].roadShapeData = sourcePreset.roadShapeData;
			}
			roadPresets[element].roadShapeDataActive = sourcePreset.roadShapeDataActive;
			roadPresets[element].timestamp = sourcePreset.timestamp;
			roadPresets[element].roadWidth = sourcePreset.roadWidth;
			roadPresets[element].faceDistance = sourcePreset.faceDistance;
			roadPresets[element].angleTreshold = sourcePreset.angleTreshold;
			roadPresets[element].uvTiling = sourcePreset.uvTiling;
			roadPresets[element].planarUVs = sourcePreset.planarUVs;
			roadPresets[element].outerIndent = sourcePreset.outerIndent;
			roadPresets[element].roadShape = new List<Vector2>(sourcePreset.roadShape);
			roadPresets[element].roadShapeExt = new List<Vector2>(sourcePreset.roadShapeExt);
			roadPresets[element].roadShapeExt2 = new List<Vector2>(sourcePreset.roadShapeExt2);
			roadPresets[element].doConnectionTri = new List<bool>(sourcePreset.doConnectionTri);
			roadPresets[element].roadShapeUVs = new List<float>(sourcePreset.roadShapeUVs);
			roadPresets[element].roadShapeUVs2 = new List<float>(sourcePreset.roadShapeUVs2);
			roadPresets[element].roadShapeExtUVs = new List<float>(sourcePreset.roadShapeExtUVs);
			roadPresets[element].roadShapeExtUVs2 = new List<float>(sourcePreset.roadShapeExtUVs2);
			roadPresets[element].hardEdge = new List<bool>(sourcePreset.hardEdge);
			roadPresets[element].roadShapeVecsString = sourcePreset.roadShapeVecsString;
			roadPresets[element].sidewalks = sourcePreset.sidewalks;
			roadPresets[element].sidewalkHeight = sourcePreset.sidewalkHeight;
			roadPresets[element].sidewalkWidth = sourcePreset.sidewalkWidth;
			roadPresets[element].defaultSidewalk = sourcePreset.defaultSidewalk;
			roadPresets[element].sidewalks = sourcePreset.sidewalks;
			roadPresets[element].crosswalks = sourcePreset.crosswalks;
			roadPresets[element].crosswalkIntervals = sourcePreset.crosswalkIntervals;
			roadPresets[element].crosswalksIntersections = sourcePreset.crosswalksIntersections;
			roadPresets[element].crosswalkPrefab = sourcePreset.crosswalkPrefab;
			roadPresets[element].crosswalkHeightOffset = sourcePreset.crosswalkHeightOffset;
			roadPresets[element].subSegments = sourcePreset.subSegments;
			roadPresets[element].roadMaterial = sourcePreset.roadMaterial;
			if (sourcePreset.roadMaterials != null)
			{
				roadPresets[element].roadMaterials = new Material[sourcePreset.roadMaterials.Length];
				Array.Copy(sourcePreset.roadMaterials, roadPresets[element].roadMaterials, sourcePreset.roadMaterials.Length);
			}
			roadPresets[element].roadPhysicsMaterial = sourcePreset.roadPhysicsMaterial;
			if (sourcePreset.roadPhysicsMaterials != null)
			{
				roadPresets[element].roadPhysicsMaterials = new PhysicsMaterial[sourcePreset.roadPhysicsMaterials.Length];
				Array.Copy(sourcePreset.roadPhysicsMaterials, roadPresets[element].roadPhysicsMaterials, sourcePreset.roadPhysicsMaterials.Length);
			}
			roadPresets[element].connectionMaterial = sourcePreset.connectionMaterial;
			roadPresets[element].isSideObject = sourcePreset.isSideObject;
			roadPresets[element].isCustomRoad = sourcePreset.isCustomRoad;
			roadPresets[element].layer = sourcePreset.layer;
			roadPresets[element].isStatic = sourcePreset.isStatic;
			if (!string.IsNullOrEmpty(sourcePreset.tag))
			{
				roadPresets[element].tag = sourcePreset.tag;
			}
			roadPresets[element].castShadow = sourcePreset.castShadow;
			roadPresets[element].splatMapActive = sourcePreset.splatMapActive;
			roadPresets[element].splatIndex = sourcePreset.splatIndex;
			roadPresets[element].expandLevel = sourcePreset.expandLevel;
			roadPresets[element].smoothLevel = sourcePreset.smoothLevel;
			roadPresets[element].splatOpacity = sourcePreset.splatOpacity;
			roadPresets[element].terrainDeformation = sourcePreset.terrainDeformation;
			roadPresets[element].defaultIndent = sourcePreset.defaultIndent;
			roadPresets[element].defaultSurrounding = sourcePreset.defaultSurrounding;
			roadPresets[element].followTerrainContours = sourcePreset.followTerrainContours;
			roadPresets[element].terrainContoursOffset = sourcePreset.terrainContoursOffset;
			roadPresets[element].maxRoadheight = sourcePreset.maxRoadheight;
			roadPresets[element].maxTerrainHeightOffset = sourcePreset.maxTerrainHeightOffset;
			roadPresets[element].minTerrainHeightDistance = sourcePreset.minTerrainHeightDistance;
			roadPresets[element].maxTerrainHeightDistance = sourcePreset.maxTerrainHeightDistance;
			roadPresets[element].randomYPosition = sourcePreset.randomYPosition;
			roadPresets[element].randomMinYPosition = sourcePreset.randomMinYPosition;
			roadPresets[element].randomMaxYPosition = sourcePreset.randomMaxYPosition;
			roadPresets[element].minRandomYPositionDistance = sourcePreset.minRandomYPositionDistance;
			roadPresets[element].maxRandomYPositionDistance = sourcePreset.maxRandomYPositionDistance;
			roadPresets[element].randomMinRotation = sourcePreset.randomMinRotation;
			roadPresets[element].randomMaxRotation = sourcePreset.randomMaxRotation;
			roadPresets[element].minRandomRotationDistance = sourcePreset.minRandomRotationDistance;
			roadPresets[element].maxRandomRotationDistance = sourcePreset.maxRandomRotationDistance;
			roadPresets[element].vegetationStudioMaskLineActive = sourcePreset.vegetationStudioMaskLineActive;
			roadPresets[element].vegetationStudioGrassPerimeter = sourcePreset.vegetationStudioGrassPerimeter;
			roadPresets[element].vegetationStudioPlantPerimeter = sourcePreset.vegetationStudioPlantPerimeter;
			roadPresets[element].vegetationStudioTreePerimeter = sourcePreset.vegetationStudioTreePerimeter;
			roadPresets[element].vegetationStudioObjectPerimeter = sourcePreset.vegetationStudioObjectPerimeter;
			roadPresets[element].vegetationStudioLargeObjectPerimeter = sourcePreset.vegetationStudioLargeObjectPerimeter;
			roadPresets[element].vegetationStudioBiomeMaskActive = sourcePreset.vegetationStudioBiomeMaskActive;
			roadPresets[element].vegetationStudioBiomeMaskDistance = sourcePreset.vegetationStudioBiomeMaskDistance;
			roadPresets[element].vegetationStudioBiomeMaskBlendDistance = sourcePreset.vegetationStudioBiomeMaskBlendDistance;
			roadPresets[element].vegetationStudioBiomeMaskNoiseScale = sourcePreset.vegetationStudioBiomeMaskNoiseScale;
			roadPresets[element].defaultRamp = sourcePreset.defaultRamp;
			roadPresets[element].extrusionType = sourcePreset.extrusionType;
			roadPresets[element].extrusionDistance = sourcePreset.extrusionDistance;
			roadPresets[element].fixedDistance = sourcePreset.fixedDistance;
			roadPresets[element].connectionAngle = sourcePreset.connectionAngle;
			roadPresets[element].connectionRadius = sourcePreset.connectionRadius;
			roadPresets[element].vertexColor = sourcePreset.vertexColor;
			roadPresets[element].isRoadShape = sourcePreset.isRoadShape;
			roadPresets[element].oneWay = sourcePreset.oneWay;
			roadPresets[element].cornerRadiusMainRoad = sourcePreset.cornerRadiusMainRoad;
			roadPresets[element].cornerSementsMainRoad = sourcePreset.cornerSementsMainRoad;
			roadPresets[element].cornerRadiusSecondaryRoad = sourcePreset.cornerRadiusSecondaryRoad;
			roadPresets[element].cornerRadiusSecondaryCurvature = sourcePreset.cornerRadiusSecondaryCurvature;
			roadPresets[element].cornerSementsSecondaryRoad = sourcePreset.cornerSementsSecondaryRoad;
			roadPresets[element].mainRoadsOnly = sourcePreset.mainRoadsOnly;
			for (int i = 0; i < sourcePreset.decalPresets.Count; i++)
			{
				if (!(sourcePreset.decalPresets[i] != null))
				{
					continue;
				}
				bool flag = false;
				for (int j = 0; j < roadPresets[element].decalClassPresets.Count; j++)
				{
					if (roadPresets[element].decalClassPresets[j].id == sourcePreset.decalPresets[i].id)
					{
						ERDecalClass.CopyDecal(sourcePreset.decalPresets[i], roadPresets[element].decalClassPresets[j]);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					ERDecalClass eRDecalClass = new ERDecalClass();
					ERDecalClass.CopyDecal(sourcePreset.decalPresets[i], eRDecalClass);
					roadPresets[element].decalClassPresets.Add(eRDecalClass);
				}
			}
			for (int k = 0; k < roadPresets[element].decalPresets.Count; k++)
			{
				bool flag2 = false;
				for (int l = 0; l < sourcePreset.decalPresets.Count; l++)
				{
					if (roadPresets[element].decalPresets[k] != null && sourcePreset.decalPresets[l] != null && roadPresets[element].decalPresets[k].id == sourcePreset.decalPresets[l].id)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					roadPresets[element].decalPresets.RemoveAt(k);
					k--;
				}
			}
			for (int m = 0; m < roadPresets[element].decalClassPresets.Count; m++)
			{
				for (int n = m + 1; n < roadPresets[element].decalClassPresets.Count; n++)
				{
					if (n < roadPresets[element].decalClassPresets.Count && roadPresets[element].decalClassPresets[m].id == roadPresets[element].decalClassPresets[n].id)
					{
						roadPresets[element].decalClassPresets.RemoveAt(n);
						if (n <= m + 1)
						{
							break;
						}
						n--;
					}
				}
				bool flag3 = false;
				for (int num = 0; num < sourcePreset.decalPresets.Count; num++)
				{
					if (sourcePreset.decalPresets[num] != null && roadPresets[element].decalClassPresets[m].id == sourcePreset.decalPresets[num].id)
					{
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					roadPresets[element].decalClassPresets.RemoveAt(m);
					m--;
				}
			}
			roadPresets[element].decalPresets = new List<ERDecal>(sourcePreset.decalPresets);
			roadPresets[element].trafficPosts = new List<ERTrafficPosts>(sourcePreset.trafficPosts);
			roadPresets[element].soDataLog.Clear();
			for (int num2 = 0; num2 < sceneSideObjects.Count; num2++)
			{
				roadPresets[element].soDataLog.Add(new ERSORoadLog(sceneSideObjects[num2].id));
			}
			bool flag4 = false;
			for (int num3 = 0; num3 < sourcePreset.soDataExt.Count; num3++)
			{
				if (sourcePreset.soDataExt[num3] != null)
				{
					if (!sourcePreset.soDataExt[num3].active)
					{
						continue;
					}
					for (int num4 = 0; num4 < roadPresets[element].soDataLog.Count; num4++)
					{
						if (sourcePreset.soDataExt[num3].sideObject.id == roadPresets[element].soDataLog[num4].id)
						{
							roadPresets[element].soDataLog[num4].active = true;
							break;
						}
					}
				}
				else
				{
					if (!flag4)
					{
						Debug.LogWarning("EasyRoads3Dv3 Warning: empty side object data for source preset: " + sourcePreset.roadTypeName);
					}
					flag4 = true;
				}
			}
		}

		public void AddSidewalkPreset(ERSideWalk sourcePreset)
		{
			sidewalkPresets.Add(ERSideWalk.CreateInstance(sidewalkPresets.Count + 1));
			UpdateSidewalkPreset(sourcePreset, sidewalkPresets.Count - 1);
		}

		public void UpdateSidewalkPreset(ERSideWalk sourcePreset, int element)
		{
			ERSideWalk.CopySidewalk(sourcePreset, sidewalkPresets[element]);
		}

		public void UpdateTextureList(int element, Texture2D _texture, float _roadWidth, float _leftOffset, float _rightOffset, float _leftInnerOffset, float _rightInnerOffset)
		{
			textureData[element].texture = _texture;
			textureData[element].roadWidth = _roadWidth;
			textureData[element].leftOffset = _leftOffset;
			textureData[element].rightOffset = _rightOffset;
			textureData[element].leftInnerOffset = _leftInnerOffset;
			textureData[element].rightInnerOffset = _rightInnerOffset;
		}
	}
}
