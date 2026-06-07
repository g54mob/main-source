using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class QDQDOOQQDQODD
	{
		public string roadTypeName = "New Road";

		public double id;

		public double timestamp;

		public float roadWidth = 6f;

		public float faceDistance = 2f;

		public float angleTreshold = 45f;

		public float uvTiling = 1f;

		public int uv4Type = 0;

		public float detailDistance = 50f;

		public bool planarUVs = false;

		public float outerIndent = 0.5f;

		public bool roadShapeDataActive = false;

		public ERRoadShape roadShapeData;

		public List<Vector2> roadShape = new List<Vector2>();

		public List<Vector2> roadShapeExt = new List<Vector2>();

		public List<bool> doConnectionTri = new List<bool>();

		public List<float> roadShapeUVs = new List<float>();

		public List<float> roadShapeExtUVs = new List<float>();

		public List<float> roadShapeUVs2 = new List<float>();

		public List<bool> hardEdge = new List<bool>();

		public string roadShapeVecsString = "";

		public double defaultSidewalk = 0.0;

		public bool sidewalks = false;

		public float sidewalkHeight = 0.2f;

		public float sidewalkWidth = 2f;

		public Material roadMaterial;

		public Material[] roadMaterials;

		public Material roadPhysicsMaterial;

		public Material[] roadPhysicsMaterials;

		public Material connectionMaterial;

		public bool isSideObject = false;

		public bool isCustomRoad = false;

		public int subSegments = 1;

		public List<ERSORoad> soData = new List<ERSORoad>();

		public List<ERSORoadExt> soDataExt = new List<ERSORoadExt>();

		public List<ERSORoadLog> soDataLog = new List<ERSORoadLog>();

		public int layer = 0;

		public string tag = "";

		public bool splatMapActive = false;

		public int splatIndex = 0;

		public int expandLevel = 0;

		public int smoothLevel = 1;

		public float splatOpacity = 1f;

		public bool terrainDeformation = true;

		public bool castShadow = false;

		public bool randomnessFlag = false;

		public float randomYPosition = 0f;

		public float randomMinYPosition = -0.02f;

		public float randomMaxYPosition = 0.02f;

		public float minRandomYPositionDistance = 15f;

		public float maxRandomYPositionDistance = 35f;

		public float randomMinRotation = -1f;

		public float randomMaxRotation = 1f;

		public float minRandomRotationDistance = 15f;

		public float maxRandomRotationDistance = 30f;

		public float vegetationStudioGrassPerimeter = 2f;

		public float vegetationStudioPlantPerimeter = 3f;

		public float vegetationStudioTreePerimeter = 4f;

		public float vegetationStudioObjectPerimeter = 3f;

		public float vegetationStudioLargeObjectPerimeter = 4f;

		public List<ERDecal> decalPresets = new List<ERDecal>();

		public List<ERDecalClass> decalClassPresets = new List<ERDecalClass>();

		public QDQDOOQQDQODD(int count)
		{
			roadTypeName = "Road Type " + count;
			UpdateTimestamp();
			id = timestamp;
		}

		public void UpdateTimestamp()
		{
			timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
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
					list.Add(num + ".  " + roadTypes[i].roadTypeName);
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

		public static QDQDOOQQDQODD GetRoadTypeElByID(List<QDQDOOQQDQODD> roadTypes, double id)
		{
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id == id)
				{
					return roadTypes[i];
				}
			}
			return null;
		}

		public static int GetRoadTypeByID(List<QDQDOOQQDQODD> roadTypes, double id)
		{
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id == id)
				{
					return i + 1;
				}
			}
			return 0;
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

		public void OQOCCCQDCO(QDQDOOQQDQODD sourcePreset, List<SideObject> sceneSideObjects, List<SideObjectLog> projectSideObjects)
		{
			roadTypeName = sourcePreset.roadTypeName;
			id = sourcePreset.id;
			timestamp = sourcePreset.timestamp;
			roadWidth = sourcePreset.roadWidth;
			faceDistance = sourcePreset.faceDistance;
			angleTreshold = sourcePreset.angleTreshold;
			uvTiling = sourcePreset.uvTiling;
			planarUVs = sourcePreset.planarUVs;
			outerIndent = sourcePreset.outerIndent;
			roadShape = new List<Vector2>(sourcePreset.roadShape);
			doConnectionTri = new List<bool>(sourcePreset.doConnectionTri);
			roadShapeUVs = new List<float>(sourcePreset.roadShapeUVs);
			roadShapeUVs2 = new List<float>(sourcePreset.roadShapeUVs2);
			hardEdge = new List<bool>(sourcePreset.hardEdge);
			roadShapeVecsString = sourcePreset.roadShapeVecsString;
			sidewalks = sourcePreset.sidewalks;
			sidewalkHeight = sourcePreset.sidewalkHeight;
			sidewalkWidth = sourcePreset.sidewalkWidth;
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
				roadPhysicsMaterials = new Material[sourcePreset.roadPhysicsMaterials.Length];
				Array.Copy(sourcePreset.roadPhysicsMaterials, roadPhysicsMaterials, sourcePreset.roadPhysicsMaterials.Length);
			}
			connectionMaterial = sourcePreset.connectionMaterial;
			isSideObject = sourcePreset.isSideObject;
			layer = sourcePreset.layer;
			castShadow = sourcePreset.castShadow;
			splatMapActive = sourcePreset.splatMapActive;
			splatIndex = sourcePreset.splatIndex;
			expandLevel = sourcePreset.expandLevel;
			smoothLevel = sourcePreset.smoothLevel;
			splatOpacity = sourcePreset.splatOpacity;
			terrainDeformation = sourcePreset.terrainDeformation;
			randomYPosition = sourcePreset.randomYPosition;
			randomMinYPosition = sourcePreset.randomMinYPosition;
			randomMaxYPosition = sourcePreset.randomMaxYPosition;
			minRandomYPositionDistance = sourcePreset.minRandomYPositionDistance;
			maxRandomYPositionDistance = sourcePreset.maxRandomYPositionDistance;
			randomMinRotation = sourcePreset.randomMinRotation;
			randomMaxRotation = sourcePreset.randomMaxRotation;
			minRandomRotationDistance = sourcePreset.minRandomRotationDistance;
			maxRandomRotationDistance = sourcePreset.maxRandomRotationDistance;
			for (int i = 0; i < sourcePreset.decalClassPresets.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < decalPresets.Count; j++)
				{
					if (decalPresets[j].id == sourcePreset.decalClassPresets[i].id)
					{
						ERDecal.CopyDecal(sourcePreset.decalClassPresets[i], decalPresets[j]);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					ERDecal eRDecal = ERDecal.CreateInstance(sourcePreset.decalClassPresets[i].decalPrefab, sourcePreset.decalClassPresets[i].baseWidth);
					ERDecal.CopyDecal(sourcePreset.decalClassPresets[i], eRDecal);
					decalPresets.Add(eRDecal);
				}
			}
			for (int j = 0; j < decalPresets.Count; j++)
			{
				bool flag2 = false;
				for (int i = 0; i < sourcePreset.decalClassPresets.Count; i++)
				{
					if (decalPresets[j].id == sourcePreset.decalClassPresets[i].id)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					decalPresets.RemoveAt(j);
					j--;
				}
			}
			soDataExt.Clear();
			for (int i = 0; i < sceneSideObjects.Count; i++)
			{
				soDataExt.Add(ERSORoadExt.CreateInstance(sceneSideObjects[i]));
			}
			for (int k = 0; k < sourcePreset.soDataLog.Count; k++)
			{
				if (!sourcePreset.soDataLog[k].active)
				{
					continue;
				}
				for (int i = 0; i < soDataExt.Count; i++)
				{
					if (sourcePreset.soDataLog[k].id == soDataExt[i].sideObject.id)
					{
						soDataExt[i].active = true;
						break;
					}
				}
			}
		}

		public static void ODCQOCQDOO(QDQDOOQQDQODD sourcePreset, ERModularRoad road, bool update)
		{
			road.subSegments = sourcePreset.subSegments;
			if (sourcePreset.roadWidth != road.roadWidth && !sourcePreset.isCustomRoad)
			{
				road.roadWidth = sourcePreset.roadWidth;
				OCQQDQQCQQ.GetRoadShape(road.roadWidth, road.subSegments, ref road.roadShape, ref road.roadShapeUVs, ref road.roadShapeUVs2, -1f);
				road.roadShapeMatchCount = road.subSegments + 1;
				int num = 1;
				for (int i = 1; i < road.roadShape.Count; i++)
				{
					if ((double)Vector2.Distance(road.roadShape[i - 1], road.roadShape[i]) > 0.01)
					{
						num++;
					}
				}
				road.roadShapeMatchCount = num;
				for (int i = 0; i < road.markersExt.Count; i++)
				{
					road.markersExt[i].roadShape.Clear();
					road.markersExt[i].roadShape = new List<Vector2>(road.roadShape);
				}
			}
			else if (road.roadShapeMatchCount == 0)
			{
				int num = 1;
				for (int i = 1; i < road.roadShape.Count; i++)
				{
					if ((double)Vector2.Distance(road.roadShape[i - 1], road.roadShape[i]) > 0.01)
					{
						num++;
					}
				}
				road.roadShapeMatchCount = num;
			}
			road.faceDistance = sourcePreset.faceDistance;
			road.angleTreshold = sourcePreset.angleTreshold;
			road.uvTiling = sourcePreset.uvTiling;
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
				road.roadPhysicsMaterials = new Material[sourcePreset.roadPhysicsMaterials.Length];
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
			road.layer = sourcePreset.layer;
			road.castShadow = sourcePreset.castShadow;
			road.splatMapActive = sourcePreset.splatMapActive;
			road.splatIndex = sourcePreset.splatIndex;
			road.expandLevel = sourcePreset.expandLevel;
			road.smoothLevel = sourcePreset.smoothLevel;
			road.splatOpacity = sourcePreset.splatOpacity;
			road.terrainDeformation = sourcePreset.terrainDeformation;
			road.randomYPosition = sourcePreset.randomYPosition;
			road.randomMinYPosition = sourcePreset.randomMinYPosition;
			road.randomMaxYPosition = sourcePreset.randomMaxYPosition;
			road.minRandomYPositionDistance = sourcePreset.minRandomYPositionDistance;
			road.maxRandomYPositionDistance = sourcePreset.maxRandomYPositionDistance;
			road.randomMinRotation = sourcePreset.randomMinRotation;
			road.randomMaxRotation = sourcePreset.randomMaxRotation;
			road.minRandomRotationDistance = sourcePreset.minRandomRotationDistance;
			road.maxRandomRotationDistance = sourcePreset.maxRandomRotationDistance;
			for (int i = 0; i < road.markersExt.Count; i++)
			{
				road.markersExt[i].randomYPosition = sourcePreset.randomYPosition;
				road.markersExt[i].randomMinYPosition = sourcePreset.randomMinYPosition;
				road.markersExt[i].randomMaxYPosition = sourcePreset.randomMaxYPosition;
				road.markersExt[i].minRandomYPositionDistance = sourcePreset.minRandomYPositionDistance;
				road.markersExt[i].maxRandomYPositionDistance = sourcePreset.maxRandomYPositionDistance;
				road.markersExt[i].randomMinRotation = sourcePreset.randomMinRotation;
				road.markersExt[i].randomMaxRotation = sourcePreset.randomMaxRotation;
				road.markersExt[i].minRandomRotationDistance = sourcePreset.minRandomRotationDistance;
				road.markersExt[i].maxRandomRotationDistance = sourcePreset.maxRandomRotationDistance;
			}
			road.vegetationStudioGrassPerimeter = sourcePreset.vegetationStudioGrassPerimeter;
			road.vegetationStudioPlantPerimeter = sourcePreset.vegetationStudioPlantPerimeter;
			road.vegetationStudioTreePerimeter = sourcePreset.vegetationStudioTreePerimeter;
			road.vegetationStudioObjectPerimeter = sourcePreset.vegetationStudioObjectPerimeter;
			road.vegetationStudioLargeObjectPerimeter = sourcePreset.vegetationStudioLargeObjectPerimeter;
			if (road.baseScript.vegetationStudio)
			{
				float num2 = sourcePreset.roadWidth;
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
			bool flag = false;
			bool flag2 = false;
			foreach (ERDecal decalPreset in sourcePreset.decalPresets)
			{
				if (decalPreset.id == road.startDecalID)
				{
					flag = true;
				}
				if (decalPreset.id == road.endDecalID)
				{
					flag2 = true;
				}
				if (flag && flag2)
				{
					break;
				}
			}
			if (!flag)
			{
				road.startDecalID = -1;
				if (road.startDecalPrefab != null)
				{
					UnityEngine.Object.DestroyImmediate(road.startDecalPrefab);
				}
			}
			if (!flag2)
			{
				road.endDecalID = -1;
				if (road.endDecalPrefab != null)
				{
					UnityEngine.Object.DestroyImmediate(road.endDecalPrefab);
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
					int min = 0;
					int count = sourcePreset.decalPresets.Count;
					int index = UnityEngine.Random.Range(min, count);
					road.startDecalID = sourcePreset.decalPresets[index].id;
					road.startDecal = sourcePreset.decalPresets[index];
				}
				if (road.endDecalID == -1)
				{
					int min = 0;
					int count = sourcePreset.decalPresets.Count;
					int index = UnityEngine.Random.Range(min, count);
					road.endDecalID = sourcePreset.decalPresets[index].id;
					road.endDecal = sourcePreset.decalPresets[index];
				}
			}
			if (!update)
			{
				return;
			}
			road.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			int num3 = -1;
			for (int i = 0; i < road.baseScript.roadTypes.Count; i++)
			{
				if (road.baseScript.roadTypes[i] == sourcePreset)
				{
					num3 = i + 1;
					break;
				}
			}
			if (num3 != -1)
			{
				AssignSideObjects(road.baseScript, num3, road);
			}
		}

		public static void AssignSideObjects(ERModularBase scr, int roadTypeInt, ERModularRoad OCCCQDQOCQ)
		{
			for (int i = 0; i < scr.roadTypes[roadTypeInt - 1].soDataExt.Count; i++)
			{
				if (!(scr.roadTypes[roadTypeInt - 1].soDataExt[i] != null))
				{
					continue;
				}
				bool flag = true;
				foreach (ERSORoadExt item in OCCCQDQOCQ.soDataExt)
				{
					if (!(item.sideObject == scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject))
					{
						continue;
					}
					flag = false;
					if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].active && !item.active)
					{
						item.active = true;
						if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject.markerActive)
						{
							OCQQCCQCCO.OQOOQQCOQO(OCCCQDQOCQ, scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject);
						}
					}
					else if (item.active)
					{
						OCCCQDQOCQ.sosCleared = false;
					}
					break;
				}
				if (!flag)
				{
					continue;
				}
				OCCCQDQOCQ.soDataExt.Add(ERSORoadExt.CreateInstance(scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject));
				if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].active)
				{
					OCCCQDQOCQ.soDataExt[OCCCQDQOCQ.soDataExt.Count - 1].active = true;
					if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject.markerActive && scr.QOQDQOOQDDQOOQ.Count > 0)
					{
						OCQQCCQCCO.OQOOQQCOQO(OCCCQDQOCQ, scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject);
					}
				}
				OQQOOODQDQ.CopySoData(OCCCQDQOCQ.soDataExt[OCCCQDQOCQ.soDataExt.Count - 1], scr.roadTypes[roadTypeInt - 1].soDataExt[i]);
			}
			OCCCQDQOCQ.sideObjectNames = OCQQCCQCCO.OODQOODCOD(OCCCQDQOCQ);
		}

		public static void HasActiveSideObjects(List<ERSORoadExt> sos1, List<ERSORoadExt> sos2, ref bool flag1, ref bool flag2)
		{
			bool flag3 = false;
			if (sos1 != null)
			{
				foreach (ERSORoadExt item in sos1)
				{
					if (item.active)
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
							if (item.id == item3.id && item3.active)
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
				if (item4.active)
				{
					flag2 = true;
				}
			}
		}
	}
}
