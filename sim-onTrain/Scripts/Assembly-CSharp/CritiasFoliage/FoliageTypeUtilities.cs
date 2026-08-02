using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace CritiasFoliage
{
	public class FoliageTypeUtilities
	{
		public static void BuildDataPartialEditTime(FoliagePainter painter, FoliageType type)
		{
			GameObject prefab = type.m_Prefab;
			type.Type = type.Type;
			if (type.m_RuntimeData == null)
			{
				type.m_RuntimeData = new FoliageTypeRuntimeData();
			}
			FoliageTypeRuntimeData runtimeData = type.m_RuntimeData;
			List<Material> list = new List<Material>();
			if (type.IsSpeedTreeType && runtimeData.m_SpeedTreeData == null)
			{
				runtimeData.m_SpeedTreeData = new FoliageTypeSpeedTreeData();
			}
			if (type.IsGrassType)
			{
				if (runtimeData.m_LODDataGrass == null)
				{
					runtimeData.m_LODDataGrass = new FoliageTypeLODGrass();
				}
				runtimeData.m_LODDataGrass.m_Mesh = prefab.GetComponentInChildren<MeshFilter>().sharedMesh;
				runtimeData.m_LODDataGrass.m_Material = prefab.GetComponentInChildren<MeshRenderer>().sharedMaterial;
				list.Add(runtimeData.m_LODDataGrass.m_Material);
			}
			else
			{
				LODGroup component = prefab.GetComponent<LODGroup>();
				if (component == null)
				{
					if (runtimeData.m_LODDataTree == null || runtimeData.m_LODDataTree.Length == 0)
					{
						runtimeData.m_LODDataTree = new FoliageTypeLODTree[1];
					}
					runtimeData.m_LODDataTree[0] = new FoliageTypeLODTree();
					runtimeData.m_LODDataTree[0].m_Mesh = prefab.GetComponentInChildren<MeshFilter>().sharedMesh;
					runtimeData.m_LODDataTree[0].m_Materials = prefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
					runtimeData.m_LODDataTree[0].m_EndDistance = type.m_RenderInfo.m_MaxDistance;
					list.AddRange(runtimeData.m_LODDataTree[0].m_Materials);
				}
				else
				{
					List<FoliageTypeLODTree> list2 = new List<FoliageTypeLODTree>(component.lodCount);
					LOD[] lODs = component.GetLODs();
					for (int i = 0; i < component.lodCount; i++)
					{
						if (lODs[i].renderers[0].gameObject.GetComponent<BillboardRenderer>() != null)
						{
							FoliageTypeSpeedTreeData speedTreeData = runtimeData.m_SpeedTreeData;
							FoliageWindTreeUtilities.ExtractBillboardData(lODs[i].renderers[0].gameObject.GetComponent<BillboardRenderer>(), speedTreeData);
							continue;
						}
						FoliageTypeLODTree foliageTypeLODTree = new FoliageTypeLODTree();
						MeshRenderer component2 = lODs[i].renderers[0].gameObject.GetComponent<MeshRenderer>();
						MeshFilter component3 = lODs[i].renderers[0].gameObject.GetComponent<MeshFilter>();
						foliageTypeLODTree.m_Mesh = component3.sharedMesh;
						foliageTypeLODTree.m_Materials = component2.sharedMaterials;
						list.AddRange(component2.sharedMaterials);
						list2.Add(foliageTypeLODTree);
					}
					runtimeData.m_LODDataTree = list2.ToArray();
					UpdateDistancesLOD(runtimeData.m_LODDataTree, lODs, type.m_RenderInfo.m_MaxDistance, type.m_RenderInfo.m_LODTransition, type.IsSpeedTreeType);
				}
			}
			if (list.Count > 0)
			{
				if (type.IsSpeedTreeType)
				{
					if (type.m_RenderInfo.m_Hue == new Color(0f, 0f, 0f, 0f))
					{
						type.m_RenderInfo.m_Hue = list[0].GetColor("_HueVariation");
					}
					if (type.m_RenderInfo.m_Color == new Color(0f, 0f, 0f, 0f))
					{
						type.m_RenderInfo.m_Color = list[0].GetColor("_Color");
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (!list[j].enableInstancing)
					{
						list[j].enableInstancing = true;
					}
				}
			}
			if (type.Type == EFoliageType.SPEEDTREE_GRASS)
			{
				Shader shaderGrass = painter.GetShaderGrass();
				FoliageTypeLODGrass lODDataGrass = type.m_RuntimeData.m_LODDataGrass;
				lODDataGrass.m_Material = new Material(lODDataGrass.m_Material);
				lODDataGrass.m_Material.shader = shaderGrass;
				lODDataGrass.m_Material.enableInstancing = true;
			}
			else if (type.Type == EFoliageType.SPEEDTREE_TREE || type.Type == EFoliageType.SPEEDTREE_TREE_BILLBOARD)
			{
				Shader shaderTreeMaster = painter.GetShaderTreeMaster();
				FoliageTypeLODTree[] lODDataTree = type.m_RuntimeData.m_LODDataTree;
				foreach (FoliageTypeLODTree foliageTypeLODTree2 in lODDataTree)
				{
					Material[] materials = foliageTypeLODTree2.m_Materials;
					for (int l = 0; l < materials.Length; l++)
					{
						materials[l] = new Material(materials[l]);
						materials[l].shader = shaderTreeMaster;
						materials[l].enableInstancing = true;
					}
					foliageTypeLODTree2.m_Materials = materials;
				}
			}
			if (type.IsGrassType)
			{
				if (type.m_EnableBend)
				{
					type.m_RuntimeData.m_LODDataGrass.m_Material.EnableKeyword("CRITIAS_DISTANCE_BEND");
				}
				else
				{
					type.m_RuntimeData.m_LODDataGrass.m_Material.DisableKeyword("CRITIAS_DISTANCE_BEND");
				}
			}
		}

		public static void BuildDataRuntime(FoliagePainter painter, FoliageType type, Transform attachmentPoint)
		{
			type.m_RuntimeData.m_TypeMPB = new MaterialPropertyBlock();
			if (type.IsSpeedTreeType)
			{
				FoliageTypeSpeedTreeData speedTreeData = type.m_RuntimeData.m_SpeedTreeData;
				LOD[] lODs = type.m_Prefab.GetComponent<LODGroup>().GetLODs();
				for (int num = lODs.Length - 1; num >= 0; num--)
				{
					if (!(lODs[num].renderers[0].GetComponent<BillboardRenderer>() != null))
					{
						speedTreeData.m_SpeedTreeWindObject = Object.Instantiate(lODs[num].renderers[0].gameObject, attachmentPoint);
						break;
					}
				}
				speedTreeData.m_SpeedTreeWindObjectMesh = speedTreeData.m_SpeedTreeWindObject.GetComponentInChildren<MeshRenderer>();
				Shader shaderNull = painter.GetShaderNull();
				Material[] materials = speedTreeData.m_SpeedTreeWindObjectMesh.materials;
				for (int i = 0; i < materials.Length; i++)
				{
					materials[i].shader = shaderNull;
				}
				speedTreeData.m_SpeedTreeWindObject.AddComponent<FoliageWindTreeWind>();
				speedTreeData.m_SpeedTreeWindObjectMesh.shadowCastingMode = ShadowCastingMode.Off;
				speedTreeData.m_SpeedTreeWindObject.transform.SetParent(attachmentPoint, worldPositionStays: false);
				speedTreeData.m_SpeedTreeWindObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				MeshFilter componentInChildren = speedTreeData.m_SpeedTreeWindObject.GetComponentInChildren<MeshFilter>();
				Bounds bounds = componentInChildren.mesh.bounds;
				bounds.Expand(4.5f);
				componentInChildren.mesh.bounds = bounds;
				speedTreeData.m_SpeedTreeWindObject.GetComponentInChildren<MeshFilter>().mesh = componentInChildren.mesh;
			}
			type.IsRuntimeInitialized = true;
		}

		public static void UpdateDistancesLOD(FoliageTypeLODTree[] treeLods, LOD[] groupLods, float maxDistance, float lodDistance, bool isSpeedTree)
		{
			if (groupLods != null && groupLods.Length != 0)
			{
				for (int i = 0; i < treeLods.Length; i++)
				{
					if (!isSpeedTree || !(groupLods[i].renderers[0].GetComponent<BillboardRenderer>() != null))
					{
						FoliageTypeLODTree foliageTypeLODTree = treeLods[i];
						LOD lOD = groupLods[i];
						if (i == treeLods.Length - 1)
						{
							foliageTypeLODTree.m_EndDistance = maxDistance;
						}
						else
						{
							foliageTypeLODTree.m_EndDistance = (1f - lOD.screenRelativeTransitionHeight) * maxDistance / 3f;
						}
					}
				}
			}
			else
			{
				treeLods[0].m_EndDistance = maxDistance;
			}
		}
	}
}
