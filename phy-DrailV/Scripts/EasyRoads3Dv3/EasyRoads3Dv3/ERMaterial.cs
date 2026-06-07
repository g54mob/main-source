using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERMaterial : ScriptableObject
	{
		public int id = 0;

		public new string name;

		public double roadType1ID;

		public double roadType2ID;

		public double roadType3ID;

		public Material road1Material;

		public Material road2Material;

		public Material road3Material;

		public float connectorLength1 = 0f;

		public float connectorLength2 = 0f;

		public float connectorLength3 = 0f;

		public float road1Stretch = 1f;

		public float road2Stretch = 1f;

		public float road3Stretch = 1f;

		public int road1StretchType = 0;

		public int road2StretchType = 0;

		public int road3StretchType = 0;

		public int subdivide1 = 0;

		public int subdivide2 = 0;

		public int subdivide3 = 0;

		public float resolution = 1f;

		public bool blend = false;

		public float blendDistance = 1f;

		public int blendSection = 0;

		public bool triangleStrip = false;

		public float triangleStripDistance = 1f;

		public float triangleStripUVStart = 0f;

		public float triangleStripUVEnd = 1f;

		public Material triangleStripMaterial;

		public void Init(ERModularBase scr)
		{
			int min = 1;
			int max = 999999999;
			id = UnityEngine.Random.Range(min, max);
			name = "Material " + (scr.materials.Count + 1);
		}

		public static ERMaterial CreateInstance(ERModularBase scr)
		{
			ERMaterial eRMaterial = ScriptableObject.CreateInstance<ERMaterial>();
			eRMaterial.Init(scr);
			return eRMaterial;
		}

		public static string[] OCODCDQCCO(ERModularBase scr)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < scr.materials.Count; i++)
			{
				list.Add(i + ". " + scr.materials[i].name);
			}
			_ = list.Count;
			bool flag = 0 == 0;
			return list.ToArray();
		}

		public static ERMaterial OOCOCOOOOC(ERModularBase scr, ERIConnector prefab, ref int targetRoad, ref int index)
		{
			ERMaterial result = null;
			for (int i = 0; i < scr.materials.Count; i++)
			{
				if ((prefab.roadType1ID == scr.materials[i].roadType1ID && prefab.roadType2ID == scr.materials[i].roadType2ID) || (prefab.roadType1ID == scr.materials[i].roadType2ID && prefab.roadType2ID == scr.materials[i].roadType1ID))
				{
					if (prefab.roadType1ID == scr.materials[i].roadType1ID)
					{
						targetRoad = 0;
					}
					else
					{
						targetRoad = 1;
					}
					result = scr.materials[i];
					index = i;
				}
			}
			return result;
		}

		public static Material OCDOCCCOQQ(ERModularBase scr, ERIConnector prefab)
		{
			ERMaterial eRMaterial = CreateInstance(scr);
			eRMaterial.roadType1ID = prefab.roadType1ID;
			eRMaterial.roadType2ID = prefab.roadType2ID;
			eRMaterial.road1Material = prefab.road1Material;
			eRMaterial.road2Material = prefab.road2Material;
			eRMaterial.connectorLength1 = prefab.connectorLength1;
			eRMaterial.connectorLength2 = prefab.connectorLength2;
			eRMaterial.road1Stretch = prefab.road1Stretch;
			eRMaterial.road2Stretch = prefab.road2Stretch;
			eRMaterial.road1StretchType = prefab.road1StretchType;
			eRMaterial.road2StretchType = prefab.road2StretchType;
			eRMaterial.subdivide1 = prefab.subdivide1;
			eRMaterial.subdivide2 = prefab.subdivide2;
			eRMaterial.resolution = prefab.resolution;
			eRMaterial.blend = prefab.blend;
			eRMaterial.blendDistance = prefab.blendDistance;
			eRMaterial.blendSection = prefab.blendSection;
			eRMaterial.triangleStrip = prefab.triangleStrip;
			eRMaterial.triangleStripDistance = prefab.triangleStripDistance;
			eRMaterial.triangleStripUVStart = prefab.triangleStripUVStart;
			eRMaterial.triangleStripUVEnd = prefab.triangleStripUVEnd;
			eRMaterial.triangleStripMaterial = prefab.triangleStripMaterial;
			eRMaterial.triangleStripMaterial = new Material(Shader.Find("EasyRoads3Dv3/Road Blend"));
			eRMaterial.triangleStripMaterial.name = eRMaterial.name;
			eRMaterial.triangleStripMaterial.shader = Shader.Find("EasyRoads3Dv3/Road Blend");
			if (prefab.road1Material.HasProperty("_MainTex"))
			{
				eRMaterial.triangleStripMaterial.SetTexture("_MainTex", prefab.road1Material.GetTexture("_MainTex"));
			}
			if (prefab.road1Material.HasProperty("_BumpMap"))
			{
				eRMaterial.triangleStripMaterial.SetTexture("_BumpMap", prefab.road1Material.GetTexture("_BumpMap"));
			}
			if (prefab.road2Material.HasProperty("_MainTex"))
			{
				eRMaterial.triangleStripMaterial.SetTexture("_MainTex2", prefab.road2Material.GetTexture("_MainTex"));
			}
			if (prefab.road2Material.HasProperty("_BumpMap"))
			{
				eRMaterial.triangleStripMaterial.SetTexture("_BumpMap2", prefab.road2Material.GetTexture("_BumpMap"));
			}
			if (prefab.road1Material.HasProperty("_MetallicRoad"))
			{
				eRMaterial.triangleStripMaterial.SetFloat("_MetallicRoad", prefab.road1Material.GetFloat("_MetallicRoad"));
			}
			if (prefab.road1Material.HasProperty("_SmoothnessRoad"))
			{
				eRMaterial.triangleStripMaterial.SetFloat("_SmoothnessRoad", prefab.road1Material.GetFloat("_SmoothnessRoad"));
			}
			if (prefab.road1Material.HasProperty("_Color"))
			{
				eRMaterial.triangleStripMaterial.SetColor("_Color", prefab.road1Material.GetColor("_Color"));
			}
			if (prefab.road2Material.HasProperty("_Color"))
			{
				eRMaterial.triangleStripMaterial.SetColor("_Color2", prefab.road2Material.GetColor("_Color"));
			}
			scr.materials.Add(eRMaterial);
			return eRMaterial.triangleStripMaterial;
		}
	}
}
