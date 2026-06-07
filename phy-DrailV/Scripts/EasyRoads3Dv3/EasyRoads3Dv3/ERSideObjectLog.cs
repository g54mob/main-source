using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERSideObjectLog : MonoBehaviour
	{
		public List<SideObjectLog> QOQDQOOQDDQOOQ = new List<SideObjectLog>();

		public List<int> ints = new List<int>();

		public List<QDQDOOQQDQODD> roadPresets = new List<QDQDOOQQDQODD>();

		public List<CrossingCornerClass> crossingCornerPresets = new List<CrossingCornerClass>();

		public List<ERSideWalk> sidewalkPresets = new List<ERSideWalk>();

		public List<ERTexture> textureData = new List<ERTexture>();

		public int updateInt = 2;

		public void AddRoadPreset(List<SideObject> sceneSideObjects, List<SideObjectLog> projectSideObjects, QDQDOOQQDQODD sourcePreset)
		{
			roadPresets.Add(new QDQDOOQQDQODD(0));
			UpdateRoadPreset(sourcePreset, roadPresets.Count - 1, sceneSideObjects, projectSideObjects);
		}

		public void UpdateRoadPreset(QDQDOOQQDQODD sourcePreset, int element, List<SideObject> sceneSideObjects, List<SideObjectLog> projectSideObjects)
		{
			roadPresets[element].roadTypeName = sourcePreset.roadTypeName;
			roadPresets[element].id = sourcePreset.id;
			roadPresets[element].timestamp = sourcePreset.timestamp;
			roadPresets[element].roadWidth = sourcePreset.roadWidth;
			roadPresets[element].faceDistance = sourcePreset.faceDistance;
			roadPresets[element].angleTreshold = sourcePreset.angleTreshold;
			roadPresets[element].uvTiling = sourcePreset.uvTiling;
			roadPresets[element].planarUVs = sourcePreset.planarUVs;
			roadPresets[element].outerIndent = sourcePreset.outerIndent;
			roadPresets[element].roadShape = new List<Vector2>(sourcePreset.roadShape);
			roadPresets[element].doConnectionTri = new List<bool>(sourcePreset.doConnectionTri);
			roadPresets[element].roadShapeUVs = new List<float>(sourcePreset.roadShapeUVs);
			roadPresets[element].roadShapeUVs2 = new List<float>(sourcePreset.roadShapeUVs2);
			roadPresets[element].hardEdge = new List<bool>(sourcePreset.hardEdge);
			roadPresets[element].roadShapeVecsString = sourcePreset.roadShapeVecsString;
			roadPresets[element].sidewalks = sourcePreset.sidewalks;
			roadPresets[element].sidewalkHeight = sourcePreset.sidewalkHeight;
			roadPresets[element].sidewalkWidth = sourcePreset.sidewalkWidth;
			roadPresets[element].subSegments = sourcePreset.subSegments;
			roadPresets[element].roadMaterial = sourcePreset.roadMaterial;
			if (sourcePreset.roadMaterials != null)
			{
				roadPresets[element].roadMaterials = new Material[sourcePreset.roadMaterials.Length];
				Array.Copy(sourcePreset.roadMaterials, roadPresets[element].roadMaterials, sourcePreset.roadMaterials.Length);
			}
			roadPresets[element].roadPhysicsMaterial = sourcePreset.roadMaterial;
			if (sourcePreset.roadPhysicsMaterials != null)
			{
				roadPresets[element].roadPhysicsMaterials = new Material[sourcePreset.roadPhysicsMaterials.Length];
				Array.Copy(sourcePreset.roadPhysicsMaterials, roadPresets[element].roadPhysicsMaterials, sourcePreset.roadPhysicsMaterials.Length);
			}
			roadPresets[element].connectionMaterial = sourcePreset.connectionMaterial;
			roadPresets[element].isSideObject = sourcePreset.isSideObject;
			roadPresets[element].layer = sourcePreset.layer;
			roadPresets[element].castShadow = sourcePreset.castShadow;
			roadPresets[element].splatMapActive = sourcePreset.splatMapActive;
			roadPresets[element].splatIndex = sourcePreset.splatIndex;
			roadPresets[element].expandLevel = sourcePreset.expandLevel;
			roadPresets[element].smoothLevel = sourcePreset.smoothLevel;
			roadPresets[element].splatOpacity = sourcePreset.splatOpacity;
			roadPresets[element].terrainDeformation = sourcePreset.terrainDeformation;
			roadPresets[element].randomYPosition = sourcePreset.randomYPosition;
			roadPresets[element].randomMinYPosition = sourcePreset.randomMinYPosition;
			roadPresets[element].randomMaxYPosition = sourcePreset.randomMaxYPosition;
			roadPresets[element].minRandomYPositionDistance = sourcePreset.minRandomYPositionDistance;
			roadPresets[element].maxRandomYPositionDistance = sourcePreset.maxRandomYPositionDistance;
			roadPresets[element].randomMinRotation = sourcePreset.randomMinRotation;
			roadPresets[element].randomMaxRotation = sourcePreset.randomMaxRotation;
			roadPresets[element].minRandomRotationDistance = sourcePreset.minRandomRotationDistance;
			roadPresets[element].maxRandomRotationDistance = sourcePreset.maxRandomRotationDistance;
			for (int i = 0; i < sourcePreset.decalPresets.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < roadPresets[element].decalPresets.Count; j++)
				{
					if (roadPresets[element].decalPresets[j].id == sourcePreset.decalPresets[i].id)
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
			for (int j = 0; j < roadPresets[element].decalPresets.Count; j++)
			{
				bool flag = false;
				for (int i = 0; i < sourcePreset.decalPresets.Count; i++)
				{
					if (roadPresets[element].decalPresets[j].id == sourcePreset.decalPresets[i].id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					roadPresets[element].decalPresets.RemoveAt(j);
					j--;
				}
			}
			roadPresets[element].soDataLog.Clear();
			for (int i = 0; i < sceneSideObjects.Count; i++)
			{
				roadPresets[element].soDataLog.Add(new ERSORoadLog(sceneSideObjects[i].id));
			}
			bool flag2 = false;
			for (int k = 0; k < sourcePreset.soDataExt.Count; k++)
			{
				if (sourcePreset.soDataExt[k] != null)
				{
					if (!sourcePreset.soDataExt[k].active)
					{
						continue;
					}
					for (int i = 0; i < roadPresets[element].soDataLog.Count; i++)
					{
						if (sourcePreset.soDataExt[k].sideObject.id == roadPresets[element].soDataLog[i].id)
						{
							roadPresets[element].soDataLog[i].active = true;
							break;
						}
					}
				}
				else
				{
					if (!flag2)
					{
						Debug.LogWarning("EasyRoads3Dv3 Warning: empty side object data for source preset: " + sourcePreset.roadTypeName);
					}
					flag2 = true;
				}
			}
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
