using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERRoadType
	{
		public double id;

		public string roadTypeName = "New Road";

		public List<Vector2> roadShape = new List<Vector2>();

		public List<Vector2> roadShapeExt = new List<Vector2>();

		public List<bool> doConnectionTri = new List<bool>();

		public List<float> roadShapeUVs = new List<float>();

		public List<float> roadShapeExtUVs = new List<float>();

		public List<float> roadShapeUVs2 = new List<float>();

		public List<bool> hardEdge = new List<bool>();

		public float roadWidth = 6f;

		public float faceDistance = 2f;

		public float angleTreshold = 45f;

		public bool sidewalks = false;

		public float sidewalkHeight = 0.2f;

		public float sidewalkWidth = 2f;

		public Material roadMaterial;

		public PhysicsMaterial roadPhysicsMaterial;

		public Material connectionMaterial;

		public bool isSideObject = false;

		public List<ERSORoad> soData = new List<ERSORoad>();

		public List<ERSORoadExt> soDataExt = new List<ERSORoadExt>();

		public List<ERSORoadLog> soDataLog = new List<ERSORoadLog>();

		public int layer = 0;

		public string tag = "";

		public bool hasMeshCollider = true;

		public bool terrainDeformation = true;

		public Color vertexColor;

		private ERRoadShape ussst;

		public ERRoadType()
		{
			id = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}

		public void Update()
		{
			ERModularBase eRModularBase = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			if (eRModularBase == null)
			{
				Debug.Log("No Road Network object was found");
				return;
			}
			bool flag = false;
			foreach (QDQDOOQQDQODD roadType in eRModularBase.roadTypes)
			{
				if (roadType != null && roadType.id == id)
				{
					roadType.roadTypeName = roadTypeName;
					roadType.faceDistance = faceDistance;
					roadType.angleTreshold = angleTreshold;
					roadType.roadWidth = roadWidth;
					roadType.roadMaterial = roadMaterial;
					roadType.roadMaterials = new Material[1];
					roadType.roadMaterials[0] = roadMaterial;
					roadType.roadPhysicsMaterial = roadPhysicsMaterial;
					roadType.isSideObject = isSideObject;
					roadType.layer = layer;
					roadType.tag = tag;
					if (!string.IsNullOrEmpty(tag))
					{
						roadType.tag = tag;
					}
					roadType.terrainDeformation = terrainDeformation;
					roadType.vertexColor = vertexColor;
					roadType.UpdateTimestamp();
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				eRModularBase.roadTypes.Add(new QDQDOOQQDQODD(eRModularBase.roadTypes.Count + 1));
				OCQODDCQDD.OCODCOOQOC(eRModularBase.QOQDQOOQDDQOOQ, ref eRModularBase.roadTypes[eRModularBase.roadTypes.Count - 1].soDataExt);
				QDQDOOQQDQODD qDQDOOQQDQODD = eRModularBase.roadTypes[eRModularBase.roadTypes.Count - 1];
				qDQDOOQQDQODD.roadTypeName = roadTypeName;
				qDQDOOQQDQODD.roadWidth = roadWidth;
				qDQDOOQQDQODD.faceDistance = faceDistance;
				qDQDOOQQDQODD.angleTreshold = angleTreshold;
				qDQDOOQQDQODD.roadMaterial = roadMaterial;
				qDQDOOQQDQODD.roadMaterials = new Material[1];
				qDQDOOQQDQODD.roadMaterials[0] = roadMaterial;
				qDQDOOQQDQODD.roadPhysicsMaterial = roadPhysicsMaterial;
				qDQDOOQQDQODD.isSideObject = isSideObject;
				qDQDOOQQDQODD.layer = layer;
				qDQDOOQQDQODD.tag = tag;
				if (!string.IsNullOrEmpty(tag))
				{
					qDQDOOQQDQODD.tag = tag;
				}
				qDQDOOQQDQODD.terrainDeformation = terrainDeformation;
				qDQDOOQQDQODD.UpdateTimestamp();
			}
		}

		public static QDQDOOQQDQODD GetRoadType(ERRoadType t, ERModularBase baseScript)
		{
			foreach (QDQDOOQQDQODD roadType in baseScript.roadTypes)
			{
				if (roadType != null && roadType.id == t.id)
				{
					return roadType;
				}
			}
			return null;
		}
	}
}
