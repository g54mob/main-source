using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERIConnector : MonoBehaviour
	{
		public float roadWidth1 = 6f;

		public float leftIndentInner1 = 0.1f;

		public float leftIndent1 = 0.1f;

		public float leftUVXInner1 = 0.1f;

		public float leftUVX1 = 0.1f;

		public float rightUVX1 = 0.1f;

		public float rightUVXInner1 = 0.1f;

		public float rightIndentInner1 = 0.1f;

		public float rightIndent1 = 0.1f;

		public float cornerRadius1 = 1f;

		public int cornerSegments1 = 5;

		public float angle1 = 0f;

		public float prevAngle1 = 0f;

		public Material road1Material;

		public Material road1MaterialActive;

		public int roadType1;

		public double roadType1ID;

		public QDQDOOQQDQODD roadType1Object = null;

		public ERTexture road1ERTexture;

		private float vssss = 0.1f;

		private float wssst = 0f;

		private float xssss = 0.05f;

		private float yssst = 0f;

		public float road1Stretch = 1f;

		public int road1StretchType = 0;

		public float road1XOffset = 0f;

		public float xOffsetForRoad1 = 0f;

		public int subdivide1 = 0;

		public float roadWidth2 = 6f;

		public float leftIndentInner2 = 0.1f;

		public float leftIndent2 = 0.1f;

		public float leftUVXInner2 = 0.1f;

		public float leftUVX2 = 0.1f;

		public float rightUVX2 = 0.1f;

		public float rightUVXInner2 = 0.1f;

		public float rightIndentInner2 = 0.1f;

		public float rightIndent2 = 0.1f;

		public float cornerRadius2 = 1f;

		public int cornerSegments2 = 5;

		public float angle2 = 120f;

		public float prevAngle2 = 0f;

		public Material road2Material;

		public Material road2MaterialActive;

		public int roadType2;

		public double roadType2ID;

		public QDQDOOQQDQODD roadType2Object = null;

		public ERTexture road2ERTexture;

		private float Assss = 0.1f;

		private float _0ssst = 0f;

		private float _1ssss = 0.05f;

		private float _2ssst = 0f;

		public float road2Stretch = 1f;

		public int road2StretchType = 0;

		public float road2XOffset = 0f;

		public float xOffsetForRoad2 = 0f;

		public int subdivide2 = 0;

		public float shapeTransitionAlignment = 0f;

		public int transitionAlignmentIndex = 0;

		public bool laneChangeConnector = false;

		public float resolution = 1f;

		public int crossingStructure = 0;

		public bool blend = false;

		public int textureType = 0;

		public int roadStructureType = -1;

		public string[] crossingStructureStrings = new string[4] { "3 Connections", "1 and 2 form road", "1 and 3 form road", "2 and 3 form road" };

		public bool clampUVs = false;

		public float attachAngle = 1f;

		public List<QDQDOOQQDQODD> roadTypesDynamic = new List<QDQDOOQQDQODD>();

		public List<Vector3> splinePoints1 = new List<Vector3>();

		public List<Vector3> splinePoints2 = new List<Vector3>();

		public List<Vector3> roadSplinePoints1 = new List<Vector3>();

		public List<Vector3> roadSplinePoints2 = new List<Vector3>();

		public List<int> roadShapeMaterialInts1 = new List<int>();

		public List<int> roadShapeMaterialInts2 = new List<int>();

		public List<Vector3> leftRoundingPoints1 = new List<Vector3>();

		public List<Vector3> centerPoints1 = new List<Vector3>();

		public List<Vector3> rightRoundingPoints1 = new List<Vector3>();

		public List<Vector3> leftPointsIndents1 = new List<Vector3>();

		public List<Vector3> rightPointsIndents1 = new List<Vector3>();

		public List<Vector3> middlePoints1 = new List<Vector3>();

		public List<Vector3> leftPoints13 = new List<Vector3>();

		public List<Vector3> rightPoints12 = new List<Vector3>();

		public List<Vector2> leftRoundingPointsUV1 = new List<Vector2>();

		private List<Vector2> _3ssss = new List<Vector2>();

		public List<Vector2> rightRoundingPointsUV1 = new List<Vector2>();

		public List<Vector2> leftPointsIndentsUV1 = new List<Vector2>();

		public List<Vector2> rightPointsIndentsUV1 = new List<Vector2>();

		public List<Vector3> leftRoundingPoints2 = new List<Vector3>();

		public List<Vector3> centerPoints2 = new List<Vector3>();

		public List<Vector3> rightRoundingPoints2 = new List<Vector3>();

		public List<Vector3> leftPointsIndents2 = new List<Vector3>();

		public List<Vector3> rightPointsIndents2 = new List<Vector3>();

		public List<Vector3> middlePoints2 = new List<Vector3>();

		public List<Vector3> rightPoints23 = new List<Vector3>();

		public List<Vector2> leftRoundingPointsUV2 = new List<Vector2>();

		private List<Vector2> _4ssst = new List<Vector2>();

		public List<Vector2> rightRoundingPointsUV2 = new List<Vector2>();

		public List<Vector2> leftPointsIndentsUV2 = new List<Vector2>();

		public List<Vector2> rightPointsIndentsUV2 = new List<Vector2>();

		public List<Vector3> priorityConnectionPoints = new List<Vector3>();

		public List<Vector2> priorityConnectionPointsUV = new List<Vector2>();

		public float minAngle12 = 45f;

		public float minAngle13 = 45f;

		public float minAngle23 = 45f;

		public Vector2 cpUV1;

		public Vector2 cpUV2;

		public Vector2 cpUV3;

		public List<Vector3> ll1 = new List<Vector3>();

		public List<Vector3> ll2 = new List<Vector3>();

		public List<Vector3> ll3 = new List<Vector3>();

		public List<Vector3> ll4 = new List<Vector3>();

		public Vector3 l1Start;

		public Vector3 l1End;

		public Vector3 l2Start;

		public Vector3 l2End;

		public Vector3 l3Start;

		public Vector3 l3End;

		public Vector3 r1Start;

		public Vector3 r1End;

		public Vector3 r2Start;

		public Vector3 r2End;

		public Vector3 r3Start;

		public Vector3 r3End;

		public Vector3 ip12;

		public Vector3 ip23;

		public Vector3 ip13;

		public Vector3 ip13Left;

		public Vector3 ip12right;

		public Vector3 ip23right;

		public Vector3 cp1Left;

		public Vector3 cp1Right;

		public Vector3 cp2Left;

		public Vector3 cp2Right;

		public Vector3 cp3Left;

		public Vector3 cp3Right;

		public bool lock1 = false;

		public bool lock2 = false;

		public bool lock3 = false;

		private float ttsss = 0f;

		private float utsst = 0f;

		public ERModularRoad road1 = null;

		public ERModularRoad road2 = null;

		public List<Vector2> roadShape1 = new List<Vector2>();

		public List<Vector2> roadShape2 = new List<Vector2>();

		public List<float> roadShapeUVs1 = new List<float>();

		public List<float> roadShapeUVs2 = new List<float>();

		public List<Material> roadMaterials1 = new List<Material>();

		public List<Material> roadMaterials2 = new List<Material>();

		public List<Vector3> leftPoints = new List<Vector3>();

		public List<Vector3> rightPoints = new List<Vector3>();

		public float connectorLength1 = 0f;

		public float connectorLength2 = 0f;

		public float blendDistance = 0f;

		public int blendSection = 1;

		public bool triangleStrip = false;

		public float triangleStripDistance = 1f;

		public float triangleStripUVStart = 0f;

		public float triangleStripUVEnd = 1f;

		public Material triangleStripMaterial;

		public Material blendMaterial;

		public Material transitionMaterial;

		public bool transitionSwap = false;

		public int proceduralMaterialIndex = 0;

		public bool presetSwapped = false;

		public float t1 = 0f;

		public float t2 = 0f;

		public GameObject go1;

		public GameObject go2;

		public GameObject go3;

		public GameObject go4;

		public ERCrossingPrefabs prefabScript;

		public List<Vector3> surfaceVecs = new List<Vector3>();

		public Vector3 testPoint;

		public GameObject surfaceMesh;

		public ERModularBase baseScript;

		public Vector3 centerDir;

		public Vector3 cp1 = Vector3.zero;

		public Vector3 cp2 = Vector3.zero;

		public Vector3 cp3 = Vector3.zero;

		public Vector3 cp4 = Vector3.zero;

		public Vector3 tv = Vector3.zero;

		public List<Vector3> tvecs = new List<Vector3>();

		public void SetCurveType(ERModularRoad road, ERIConnectorCurveType curveType)
		{
			if (road1 == road)
			{
				if (curveType == ERIConnectorCurveType.Lineair)
				{
					road1StretchType = 0;
				}
				else if (ERIConnectorCurveType.Exponential == curveType)
				{
					road1StretchType = 1;
				}
				else if (ERIConnectorCurveType.Smooth == curveType)
				{
					road1StretchType = 2;
				}
			}
			else if (curveType == ERIConnectorCurveType.Lineair)
			{
				road2StretchType = 0;
			}
			else if (ERIConnectorCurveType.Exponential == curveType)
			{
				road2StretchType = 1;
			}
			else if (ERIConnectorCurveType.Smooth == curveType)
			{
				road2StretchType = 2;
			}
		}

		public ERIConnectorCurveType GetCurveType(ERRoad road)
		{
			if (road != null && road.roadScript != null)
			{
				if (road.roadScript == road1)
				{
					if (road1StretchType == 0)
					{
						return ERIConnectorCurveType.Lineair;
					}
					if (road1StretchType == 1)
					{
						return ERIConnectorCurveType.Exponential;
					}
					if (road1StretchType == 2)
					{
						return ERIConnectorCurveType.Smooth;
					}
				}
				else
				{
					if (road2StretchType == 0)
					{
						return ERIConnectorCurveType.Lineair;
					}
					if (road2StretchType == 1)
					{
						return ERIConnectorCurveType.Exponential;
					}
					if (road2StretchType == 2)
					{
						return ERIConnectorCurveType.Smooth;
					}
				}
			}
			else if (roadWidth1 < roadWidth2)
			{
				if (road1StretchType == 0)
				{
					return ERIConnectorCurveType.Lineair;
				}
				if (road1StretchType == 1)
				{
					return ERIConnectorCurveType.Exponential;
				}
				if (road1StretchType == 2)
				{
					return ERIConnectorCurveType.Smooth;
				}
			}
			else
			{
				if (road2StretchType == 0)
				{
					return ERIConnectorCurveType.Lineair;
				}
				if (road2StretchType == 1)
				{
					return ERIConnectorCurveType.Exponential;
				}
				if (road2StretchType == 2)
				{
					return ERIConnectorCurveType.Smooth;
				}
			}
			return ERIConnectorCurveType.Lineair;
		}

		public void UpdateERTexture(int road)
		{
			switch (road)
			{
			case 1:
				OCODQDOQDO(road1ERTexture, ref roadWidth1, ref leftIndent1, ref rightIndent1, ref leftUVX1, ref rightUVX1, ref leftIndentInner1, ref rightIndentInner1, ref yssst, cornerRadius1);
				break;
			case 2:
				OCODQDOQDO(road2ERTexture, ref roadWidth2, ref leftIndent2, ref rightIndent2, ref leftUVX2, ref rightUVX2, ref leftIndentInner2, ref rightIndentInner2, ref _2ssst, cornerRadius2);
				break;
			}
		}

		public void ODDDQDQOOD(ERModularRoad sourceRoad)
		{
			if (baseScript == null)
			{
				baseScript = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			}
			if (roadTypesDynamic.Count == 0)
			{
				roadTypesDynamic.Clear();
				foreach (QDQDOOQQDQODD roadType in baseScript.roadTypes)
				{
					if (roadType.roadShape.Count == 2)
					{
						roadTypesDynamic.Add(roadType);
					}
				}
			}
			Clear();
			cp1 = Vector3.zero;
			cp2 = Vector3.zero;
			cp3 = Vector3.zero;
			cp4 = Vector3.zero;
			float indentLeftStart = 0f;
			float indentLeftEnd = 0f;
			float surroundingLeftStart = 0f;
			float surroundingLeftEnd = 0f;
			float indentRightStart = 0f;
			float indentRightEnd = 0f;
			float surroundingRightStart = 0f;
			float surroundingRightEnd = 0f;
			bool flag = false;
			bool flag2 = false;
			int startEnd = 0;
			int startEnd2 = 0;
			float uvRatio = 5f;
			float uvRatio2 = 5f;
			float num = 0f;
			float num2 = 0f;
			if (prefabScript == null)
			{
				prefabScript = base.gameObject.GetComponent<ERCrossingPrefabs>();
				prefabScript.iConnectorScript = this;
			}
			road1 = null;
			road2 = null;
			Vector3 position = base.transform.position;
			Vector3 position2 = base.transform.position;
			if (prefabScript.crossingElements[0].connectedRoad != null)
			{
				ERModularRoad eRModularRoad = (road1 = prefabScript.crossingElements[0].connectedRoad);
				roadShape1 = new List<Vector2>(eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker].roadShape);
				roadShapeUVs1 = new List<float>(eRModularRoad.roadShapeUVs);
				uvRatio = 5f * road1.uvTiling;
				roadType1Object = road1.rt;
				bool flag3 = false;
				if (roadType1 == 0)
				{
					flag3 = true;
				}
				else if (roadType1 - 1 >= baseScript.roadTypes.Count || road1.roadType != baseScript.roadTypes[roadType1 - 1].id)
				{
					flag3 = true;
				}
				if (flag3)
				{
					roadType1 = 0;
					for (int i = 0; i < baseScript.roadTypes.Count; i++)
					{
						if (baseScript.roadTypes[i].id == road1.roadType)
						{
							roadType1 = i + 1;
							roadType1ID = road1.roadType;
							break;
						}
					}
				}
				float num3 = 1000f;
				float num4 = -1000f;
				for (int j = 0; j < roadShape1.Count; j++)
				{
					if (num3 > roadShape1[j].x)
					{
						num3 = roadShape1[j].x;
					}
					if (num4 < roadShape1[j].x)
					{
						num4 = roadShape1[j].x;
					}
				}
				roadWidth1 = num4 - num3;
				if (prefabScript.crossingElements[0].connectedMarker == 0)
				{
					cp3 = (cp4 = eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker + 1].position);
					if (eRModularRoad.markersExt.Count > prefabScript.crossingElements[0].connectedMarker + 2)
					{
						cp4 = eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker + 2].position;
					}
					ERMarkerExt eRMarkerExt = eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker];
					indentLeftStart = (indentLeftEnd = eRMarkerExt.rightIndent);
					indentRightStart = (indentRightEnd = eRMarkerExt.leftIndent);
					surroundingLeftStart = (surroundingLeftEnd = eRMarkerExt.rightSurrounding);
					surroundingRightStart = (surroundingRightEnd = eRMarkerExt.leftSurrounding);
					for (int k = 0; k < roadShape1.Count; k++)
					{
						Vector2 value = roadShape1[k];
						value.x *= -1f;
						roadShape1[k] = value;
					}
					flag = true;
				}
				else
				{
					cp3 = (cp4 = eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker - 1].position);
					if (prefabScript.crossingElements[0].connectedMarker - 2 >= 0)
					{
						cp4 = eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker - 2].position;
					}
					ERMarkerExt eRMarkerExt2 = eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker];
					indentLeftStart = (indentLeftEnd = eRMarkerExt2.leftIndent);
					indentRightStart = (indentRightEnd = eRMarkerExt2.rightIndent);
					surroundingLeftStart = (surroundingLeftEnd = eRMarkerExt2.leftSurrounding);
					surroundingRightStart = (surroundingRightEnd = eRMarkerExt2.rightSurrounding);
					startEnd = 1;
				}
				road1Material = eRModularRoad.roadMaterial;
				roadMaterials1 = new List<Material>(eRModularRoad.roadMaterials);
				if (roadMaterials1.Count == 0)
				{
					roadMaterials1.Add(eRModularRoad.roadMaterial);
				}
				if (road1MaterialActive == null)
				{
					road1MaterialActive = road1Material;
				}
				road1MaterialActive = road1Material;
				roadShapeMaterialInts1 = new List<int>(eRModularRoad.roadShapeMaterialInts);
			}
			else
			{
				connectorLength1 = 0f;
				roadType1Object = null;
				if (roadType1 > 0)
				{
					roadShape1 = new List<Vector2>(baseScript.roadTypes[roadType1 - 1].roadShape);
					roadShapeUVs1 = new List<float>(baseScript.roadTypes[roadType1 - 1].roadShapeUVs);
					roadMaterials1 = new List<Material>(baseScript.roadTypes[roadType1 - 1].roadMaterials);
					if (roadMaterials1.Count == 0)
					{
						roadMaterials1.Add(baseScript.roadTypes[roadType1 - 1].roadMaterial);
					}
				}
				else
				{
					connectorLength1 = 0f;
				}
				road1MaterialActive = road1Material;
				roadShapeMaterialInts1.Add(0);
				roadShapeMaterialInts1.Add(0);
			}
			if (prefabScript.crossingElements[1].connectedRoad != null)
			{
				ERModularRoad eRModularRoad2 = (road2 = prefabScript.crossingElements[1].connectedRoad);
				roadType2Object = road2.rt;
				roadShape2 = new List<Vector2>(eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker].roadShape);
				roadShapeUVs2 = new List<float>(eRModularRoad2.roadShapeUVs);
				uvRatio2 = 5f * road2.uvTiling;
				bool flag4 = false;
				if (roadType2 == 0)
				{
					flag4 = true;
				}
				else if (roadType2 - 1 >= baseScript.roadTypes.Count || road2.roadType != baseScript.roadTypes[roadType2 - 1].id)
				{
					flag4 = true;
				}
				if (flag4)
				{
					roadType2 = 0;
					for (int l = 0; l < baseScript.roadTypes.Count; l++)
					{
						if (baseScript.roadTypes[l].id == road2.roadType)
						{
							roadType2 = l + 1;
							roadType2ID = road2.roadType;
							break;
						}
					}
				}
				float num5 = 1000f;
				float num6 = -1000f;
				for (int m = 0; m < roadShape2.Count; m++)
				{
					if (num5 > roadShape2[m].x)
					{
						num5 = roadShape2[m].x;
					}
					if (num6 < roadShape2[m].x)
					{
						num6 = roadShape2[m].x;
					}
				}
				roadWidth2 = num6 - num5;
				if (prefabScript.crossingElements[1].connectedMarker == 0)
				{
					cp1 = (cp2 = eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker + 1].position);
					ERMarkerExt eRMarkerExt3 = eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker + 1];
					if (eRModularRoad2.markersExt.Count > prefabScript.crossingElements[1].connectedMarker + 2)
					{
						cp2 = eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker + 2].position;
						eRMarkerExt3 = eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker + 2];
					}
					roadShape2.Reverse();
					roadShapeUVs2.Reverse();
				}
				else
				{
					cp1 = (cp2 = eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker - 1].position);
					ERMarkerExt eRMarkerExt4 = eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker - 1];
					if (prefabScript.crossingElements[1].connectedMarker - 2 >= 0)
					{
						cp2 = eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker - 2].position;
						eRMarkerExt4 = eRModularRoad2.markersExt[prefabScript.crossingElements[1].connectedMarker - 2];
					}
					flag2 = true;
					startEnd2 = 1;
				}
				road2Material = eRModularRoad2.roadMaterial;
				roadMaterials2 = new List<Material>(eRModularRoad2.roadMaterials);
				if (roadMaterials2.Count == 0)
				{
					roadMaterials2.Add(eRModularRoad2.roadMaterial);
				}
				road2Material = roadMaterials2[0];
				roadShapeMaterialInts2 = new List<int>(eRModularRoad2.roadShapeMaterialInts);
				if (road2MaterialActive == null)
				{
					road2MaterialActive = road2Material;
				}
				road2MaterialActive = road2Material;
			}
			else
			{
				connectorLength2 = 0f;
				roadType2Object = null;
				if (roadType2 > 0)
				{
					roadShape2 = new List<Vector2>(baseScript.roadTypes[roadType2 - 1].roadShape);
					roadShapeUVs2 = new List<float>(baseScript.roadTypes[roadType2 - 1].roadShapeUVs);
					roadMaterials2 = new List<Material>(baseScript.roadTypes[roadType2 - 1].roadMaterials);
					if (roadMaterials2.Count == 0)
					{
						roadMaterials2.Add(baseScript.roadTypes[roadType2 - 1].roadMaterial);
					}
				}
				else
				{
					connectorLength2 = 0f;
				}
				if (road2MaterialActive == null)
				{
					road2MaterialActive = road2Material;
				}
				road2MaterialActive = road2Material;
				roadShapeMaterialInts2.Add(0);
				roadShapeMaterialInts2.Add(0);
				cp1 = base.transform.position;
			}
			if (road1 == null || road2 == null)
			{
				connectorLength1 = 0f;
				connectorLength2 = 0f;
				blend = false;
				textureType = 0;
			}
			if (roadMaterials1.Count > 0)
			{
				if (road1MaterialActive != roadMaterials1[0])
				{
					roadMaterials1.Clear();
					roadMaterials1.Add(road1MaterialActive);
				}
			}
			else
			{
				roadMaterials1.Clear();
				roadMaterials1.Add(road1MaterialActive);
			}
			if (roadMaterials2.Count > 0)
			{
				if (road2MaterialActive != roadMaterials2[0])
				{
					roadMaterials2.Clear();
					roadMaterials2.Add(road2MaterialActive);
				}
			}
			else
			{
				roadMaterials2.Clear();
				roadMaterials2.Add(road2MaterialActive);
			}
			if (cp2 == Vector3.zero)
			{
				cp2 = base.transform.position;
			}
			centerDir = Vector3.zero;
			if (road1 == null && roadType1 == 0)
			{
				roadType1 = roadType2;
				roadType1ID = roadType2ID;
			}
			if (road2 == null && roadType2 == 0)
			{
				roadType2 = roadType1;
				roadType2ID = roadType1ID;
			}
			if (connectorLength1 > 0f)
			{
				Vector3 vector = cp1;
				if (roadWidth2 > roadWidth1 && road1XOffset != 0f)
				{
					num = (roadWidth1 - roadWidth2) * 0.5f * road1XOffset;
					Vector3 vector2 = vector - cp3;
					vector2 = new Vector3(vector2.z, 0f, 0f - vector2.x).normalized;
					position -= vector2 * num;
					vector -= vector2 * num;
					num = (road1Stretch * roadWidth1 - roadWidth1) * 0.5f;
				}
				else if (roadWidth1 > roadWidth2 && road2XOffset != 0f)
				{
					num2 = (roadWidth1 - roadWidth2) * 0.5f * road2XOffset;
					Vector3 vector3 = vector - cp3;
					vector3 = new Vector3(vector3.z, 0f, 0f - vector3.x).normalized;
					vector -= vector3 * num2;
					num = ((road1Stretch == 1f) ? 0f : ((0f - (road1Stretch * roadWidth1 - roadWidth1)) * 0.5f));
				}
				if (road1XOffset >= 0f)
				{
					num *= -1f;
				}
				splinePoints1 = OCCQQDQODQ(vector, position, cp3, cp4, 0.5f, resolution, connectorLength1, ref t1);
			}
			else
			{
				Vector3 vector4 = (tv = ERModularRoad.OQQCQOQOOD(cp1, base.transform.position, cp3, cp4, 0.05f, 0.5f));
				centerDir = (base.transform.position - vector4).normalized;
				splinePoints1.Add(base.transform.position);
				t1 = 0f;
			}
			if (cp3 == Vector3.zero)
			{
				cp3 = base.transform.position;
			}
			if (cp1 != Vector3.zero && cp1 != base.transform.position)
			{
				if (connectorLength2 > 0f)
				{
					if (roadWidth1 > roadWidth2 && road2XOffset != 0f)
					{
						num2 = (roadWidth1 - roadWidth2) * 0.5f * road2XOffset;
						Vector3 vector5 = cp3 - cp1;
						vector5 = new Vector3(vector5.z, 0f, 0f - vector5.x).normalized;
						position2 -= vector5 * num2;
						cp3 -= vector5 * num2;
						num2 = (road2Stretch * roadWidth2 - roadWidth2) * 0.5f;
						Debug.Log("the below will create the curve on the other end, but x values should shift by half the road width");
					}
					else if (roadWidth2 > roadWidth1 && road1XOffset != 0f)
					{
						num2 = (roadWidth1 - roadWidth2) * 0.5f * road2XOffset;
						Vector3 vector6 = cp3 - cp1;
						vector6 = new Vector3(vector6.z, 0f, 0f - vector6.x).normalized;
						cp3 -= vector6 * num;
						num2 = ((road2Stretch == 1f) ? 0f : ((0f - (road2Stretch * roadWidth2 - roadWidth2)) * 0.5f));
					}
					if (road2XOffset < 0f)
					{
						num2 *= -1f;
					}
					splinePoints2 = OCCQQDQODQ(cp3, position2, cp1, cp2, 0.5f, resolution, connectorLength2, ref t2);
				}
				else
				{
					splinePoints2.Add(base.transform.position);
					t2 = 0f;
				}
			}
			if (splinePoints1.Count == 0 || splinePoints2.Count == 0)
			{
				if (splinePoints1.Count > 1)
				{
					centerDir = (splinePoints1[0] - splinePoints1[1]).normalized;
				}
				else if (centerDir == Vector3.zero)
				{
					Vector3 vector7 = ERModularRoad.OQQCQOQOOD(cp3, base.transform.position, cp1, cp2, 0.01f, 0.5f);
					centerDir = (base.transform.position - vector7).normalized;
				}
			}
			if (cp1 != Vector3.zero && cp3 != Vector3.zero)
			{
				centerDir = (cp1 - cp3).normalized;
			}
			splinePoints1.Reverse();
			splinePoints2.Reverse();
			if (blendDistance > 0f)
			{
				if (blendDistance > resolution)
				{
					if (blendSection == 0)
					{
						OQQOQQDDQC(ref splinePoints1, 0.5f * blendDistance);
						OQQOQQDDQC(ref splinePoints2, 0.5f * blendDistance);
					}
					else if (blendSection == 1)
					{
						OQQOQQDDQC(ref splinePoints1, blendDistance);
					}
					else if (blendSection == 2)
					{
						OQQOQQDDQC(ref splinePoints2, blendDistance);
					}
				}
				else
				{
					OQQOQQDDQC(ref splinePoints1, blendDistance);
					if (!((double)(blendDistance / resolution) > 0.9))
					{
					}
				}
			}
			List<Vector3> vecs = new List<Vector3>();
			List<Vector2> uvs = new List<Vector2>();
			List<Vector2> list = new List<Vector2>();
			List<Vector3> vecs2 = new List<Vector3>();
			List<Vector2> uvs2 = new List<Vector2>();
			List<Vector2> list2 = new List<Vector2>();
			List<Color> colors = new List<Color>();
			List<Vector2> list3 = new List<Vector2>();
			List<Vector2> list4 = new List<Vector2>();
			List<int> list5 = new List<int>();
			List<float> list6 = new List<float>();
			List<float> list7 = new List<float>();
			List<int> list8 = new List<int>();
			List<bool> list9 = new List<bool>();
			List<bool> list10 = new List<bool>();
			int num7 = 1;
			int index = 0;
			int index2 = 1;
			list3.Add(roadShape1[0]);
			list6.Add(roadShapeUVs1[0]);
			list5.Add(roadShapeMaterialInts1[0]);
			list9.Add(item: true);
			if (roadShape1.Count > 2)
			{
				num7 = 2;
				index = 1;
				index2 = 2;
				list3.Add(roadShape1[1]);
				list6.Add(roadShapeUVs1[1]);
				list5.Add(roadShapeMaterialInts1[1]);
				list9.Add(item: true);
			}
			for (int n = num7; n < num7 + subdivide1; n++)
			{
				list3.Add(Vector2.Lerp(roadShape1[index], roadShape1[index2], (float)(n - num7 + 1) / ((float)subdivide1 + 1f)));
				list6.Add(Mathf.Lerp(roadShapeUVs1[index], roadShapeUVs1[index2], (float)(n - num7 + 1) / ((float)subdivide1 + 1f)));
				list5.Add(roadShapeMaterialInts1[index]);
				list9.Add(item: false);
			}
			if (roadShape1.Count > 2)
			{
				list3.Add(roadShape1[2]);
				list6.Add(roadShapeUVs1[2]);
				if (roadShapeMaterialInts1.Count > 2)
				{
					list5.Add(roadShapeMaterialInts1[2]);
				}
				list9.Add(item: true);
				if (roadShape1.Count > 3)
				{
					list3.Add(roadShape1[3]);
					list6.Add(roadShapeUVs1[3]);
					if (roadShapeMaterialInts1.Count > 3)
					{
						list5.Add(roadShapeMaterialInts1[3]);
					}
					list9.Add(item: true);
				}
			}
			else
			{
				list3.Add(roadShape1[1]);
				list6.Add(roadShapeUVs1[1]);
				list5.Add(roadShapeMaterialInts1[1]);
				list9.Add(item: true);
			}
			if (roadShape1.Count >= 3)
			{
				list3.Clear();
				list6.Clear();
				list5.Clear();
				list9.Clear();
				for (int num8 = 0; num8 < roadShape1.Count; num8++)
				{
					list3.Add(roadShape1[num8]);
					list6.Add(roadShapeUVs1[num8]);
					if (roadShapeMaterialInts1.Count > num8)
					{
						list5.Add(roadShapeMaterialInts1[num8]);
					}
					list9.Add(item: true);
				}
			}
			if (splinePoints2.Count > 0)
			{
				num7 = 1;
				index = 0;
				index2 = 1;
				list4.Add(roadShape2[0]);
				list7.Add(roadShapeUVs2[0]);
				list8.Add(roadShapeMaterialInts2[0]);
				list10.Add(item: true);
				if (roadShape2.Count > 2)
				{
					num7 = 2;
					index = 1;
					index2 = 2;
					list4.Add(roadShape2[1]);
					list7.Add(roadShapeUVs2[1]);
					list8.Add(roadShapeMaterialInts2[1]);
					list10.Add(item: true);
				}
				if (subdivide2 > 0)
				{
					for (int num9 = num7; num9 < num7 + subdivide2; num9++)
					{
						list4.Add(Vector2.Lerp(roadShape2[index], roadShape2[index2], (float)(num9 - num7 + 1) / ((float)subdivide2 + 1f)));
						list7.Add(Mathf.Lerp(roadShapeUVs2[index], roadShapeUVs2[index2], (float)(num9 - num7 + 1) / ((float)subdivide2 + 1f)));
						list8.Add(roadShapeMaterialInts2[index]);
						list10.Add(item: false);
					}
				}
				if (roadShape2.Count > 2)
				{
					list4.Add(roadShape2[2]);
					list7.Add(roadShapeUVs2[2]);
					list8.Add(roadShapeMaterialInts2[2]);
					list10.Add(item: true);
					if (roadShape2.Count > 3)
					{
						list4.Add(roadShape2[3]);
						list7.Add(roadShapeUVs2[3]);
						list8.Add(roadShapeMaterialInts2[3]);
						list10.Add(item: true);
					}
				}
				else
				{
					list4.Add(roadShape2[1]);
					list7.Add(roadShapeUVs2[1]);
					list8.Add(roadShapeMaterialInts2[1]);
					list10.Add(item: true);
				}
				if (roadShape2.Count >= 3)
				{
					list4.Clear();
					list7.Clear();
					list8.Clear();
					list10.Clear();
					for (int num10 = 0; num10 < roadShape2.Count; num10++)
					{
						list4.Add(roadShape2[num10]);
						list7.Add(roadShapeUVs2[num10]);
						list8.Add(roadShapeMaterialInts2[num10]);
						list10.Add(item: true);
					}
				}
			}
			List<List<int>> tris = new List<List<int>>();
			for (int num11 = 0; num11 < roadMaterials1.Count; num11++)
			{
				tris.Add(new List<int>());
			}
			List<List<int>> tris2 = new List<List<int>>();
			for (int num12 = 0; num12 < roadMaterials2.Count; num12++)
			{
				tris2.Add(new List<int>());
			}
			int num13 = 0;
			float num14 = 0f;
			float num15 = 0f;
			float num16 = 0f;
			List<Vector3> list11 = new List<Vector3>();
			List<Vector3> list12 = new List<Vector3>();
			OCQDCQOQDD(splinePoints1, splinePoints2, ref vecs, ref uvs, ref tris, list3, list6, list5, uvRatio, road1Stretch, road1StretchType, ref list11, ref list12, flag, centerDir, 0, startEnd, ref centerPoints1, ref leftRoundingPoints1, ref rightRoundingPoints1, num, ref roadSplinePoints1);
			leftPoints.AddRange(list12);
			rightPoints.AddRange(list11);
			list11.Clear();
			list12.Clear();
			if (splinePoints2.Count > 0)
			{
				OCQDCQOQDD(splinePoints2, splinePoints1, ref vecs2, ref uvs2, ref tris2, list4, list7, list8, uvRatio2, road2Stretch, road2StretchType, ref list11, ref list12, !flag2, -centerDir, 1, startEnd2, ref centerPoints2, ref leftRoundingPoints2, ref rightRoundingPoints2, num2, ref roadSplinePoints2);
			}
			list11.Reverse();
			list12.Reverse();
			leftPoints.AddRange(list11);
			rightPoints.AddRange(list12);
			int count = vecs.Count;
			int road2Start = count;
			list2.AddRange(uvs2);
			if (blendDistance >= 0f && road1 != null && road2 != null && textureType == 1)
			{
				uvs2.Clear();
				uvs2 = ODDCCODQDO(uvs[uvs.Count - 1].y, splinePoints2, list7, uvRatio, flag, list6[0]);
				if (splinePoints2.Count > 0)
				{
					list = ODDCCODQDO(uvs2[uvs2.Count - 1].y, splinePoints1, list6, uvRatio2, flag2, list7[0]);
				}
				ODDCQCQQCC(ref colors, splinePoints1, splinePoints2, list3, list4);
			}
			else if (textureType != 2)
			{
			}
			vecs.AddRange(vecs2);
			if (connectorLength1 == 0f || blendSection == 1)
			{
				uvs.AddRange(list2);
			}
			else
			{
				uvs.AddRange(uvs2);
			}
			list.AddRange(list2);
			if (connectorLength1 == 0f)
			{
				roadMaterials1 = roadMaterials2;
			}
			for (int num17 = 0; num17 < tris2.Count; num17++)
			{
				if (tris2[num17].Count <= 0)
				{
					continue;
				}
				int num18 = -1;
				for (int num19 = 0; num19 < tris.Count; num19++)
				{
					if (roadMaterials2[num17] == roadMaterials1[num19] || roadMaterials2[num17] == null)
					{
						num18 = num19;
						break;
					}
					if (num18 == -1)
					{
						tris.Add(new List<int>());
						num18 = tris.Count - 1;
						roadMaterials1.Add(roadMaterials2[num17]);
					}
				}
				for (int num20 = 0; num20 < tris2[num17].Count; num20++)
				{
					tris[num18].Add(tris2[num17][num20] + count);
				}
			}
			if (textureType == 1 && blendMaterial != null)
			{
				for (int num21 = 0; num21 < roadMaterials1.Count; num21++)
				{
					if (blendSection == 0)
					{
						if (roadMaterials1[num21] == road1Material || roadMaterials1[num21] == road2Material)
						{
							roadMaterials1[num21] = blendMaterial;
						}
					}
					else if (blendSection == 1 && roadMaterials1[num21] == road1Material)
					{
						roadMaterials1[num21] = blendMaterial;
					}
					else if (blendSection == 2 && roadMaterials1[num21] == road2Material)
					{
						roadMaterials1[num21] = blendMaterial;
					}
				}
			}
			else if (textureType == 2 && transitionMaterial != null)
			{
				for (int num22 = 0; num22 < roadMaterials1.Count; num22++)
				{
					roadMaterials1[num22] = transitionMaterial;
				}
			}
			bool hasMesh = true;
			if (splinePoints1.Count <= 1 && splinePoints2.Count <= 1)
			{
				if ((bool)base.gameObject.GetComponent<MeshRenderer>())
				{
					UnityEngine.Object.DestroyImmediate(base.gameObject.GetComponent<MeshRenderer>());
				}
				if ((bool)base.gameObject.GetComponent<MeshFilter>())
				{
					UnityEngine.Object.DestroyImmediate(base.gameObject.GetComponent<MeshFilter>());
				}
				if ((bool)base.gameObject.GetComponent<MeshCollider>())
				{
					UnityEngine.Object.DestroyImmediate(base.gameObject.GetComponent<MeshCollider>());
				}
				hasMesh = false;
			}
			else
			{
				Mesh mesh = OCOCDCDDOD();
				base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = roadMaterials1.ToArray();
				mesh.vertices = vecs.ToArray();
				mesh.uv = uvs.ToArray();
				if (list.Count > 0 && textureType == 1)
				{
					mesh.uv4 = list.ToArray();
				}
				if (colors.Count > 0)
				{
					mesh.colors = colors.ToArray();
				}
				mesh.tangents = new Vector4[vecs.Count];
				mesh.subMeshCount = tris.Count;
				for (int num23 = 0; num23 < tris.Count; num23++)
				{
					mesh.SetTriangles(tris[num23].ToArray(), num23);
				}
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mesh.RecalculateTangents();
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			OOOQQQQCDC(leftPoints, rightPoints, ref surfaceMesh, base.transform, ref surfaceVecs, indentLeftStart, indentLeftEnd, surroundingLeftStart, surroundingLeftEnd, indentRightStart, indentRightEnd, surroundingRightStart, surroundingRightEnd, baseScript, hasMesh);
			if (connectorLength2 == 0f)
			{
				flag2 = false;
			}
			GetIConnectionData(vecs, list9, list10, flag, flag2, road2Start);
			if (sourceRoad != null)
			{
				if (sourceRoad == road1 && road2 != null)
				{
					road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
				else if (sourceRoad == road2 && road1 != null)
				{
					road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
			}
			if (prefabScript.baseScript == null)
			{
				if (prefabScript.transform.parent.parent.GetComponent<ERModularBase>() != null)
				{
					prefabScript.baseScript = prefabScript.transform.parent.parent.GetComponent<ERModularBase>();
				}
				else if (prefabScript.transform.parent.parent.parent != null && prefabScript.transform.parent.parent.parent.GetComponent<ERModularBase>() != null)
				{
					prefabScript.baseScript = prefabScript.transform.parent.parent.parent.GetComponent<ERModularBase>();
				}
			}
			if (prefabScript.baseScript == null || !prefabScript.baseScript.aiTraffic || roadType1Object == null || roadType2Object == null)
			{
				return;
			}
			prefabScript.siblings.Clear();
			if (prefabScript.siblings.Count != 2)
			{
				prefabScript.siblings.Clear();
				prefabScript.siblings.Add(ERConnectionSibling.CreateInstance(null, 0f, prefabScript.crossingElements[0].centerPoint, null, null));
				prefabScript.siblings.Add(ERConnectionSibling.CreateInstance(null, 0f, prefabScript.crossingElements[1].centerPoint, null, null));
			}
			prefabScript.siblings[0].roadType = (prefabScript.siblings[0].roadTypeAI = roadType1Object);
			prefabScript.siblings[0].forward = (prefabScript.crossingElements[0].centerPoint = (prefabScript.crossingElements[0].controlPointV3 - prefabScript.crossingElements[0].tmpCenterPoint).normalized);
			prefabScript.siblings[1].roadType = (prefabScript.siblings[1].roadTypeAI = roadType2Object);
			prefabScript.siblings[1].forward = (prefabScript.crossingElements[0].centerPoint = (prefabScript.crossingElements[0].controlPointV3 - prefabScript.crossingElements[0].tmpCenterPoint).normalized);
			prefabScript.crossingElements[0].leftRoundingPoints.Clear();
			prefabScript.crossingElements[0].leftRoundingPointsGlobal.Clear();
			prefabScript.crossingElements[0].rightRoundingPoints.Clear();
			prefabScript.crossingElements[0].rightRoundingPointsGlobal.Clear();
			if (prefabScript.crossingElements[0].connectedMarker == 0)
			{
				prefabScript.crossingElements[0].leftRoundingPoints.Add(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[0].rightIntFull]);
				prefabScript.crossingElements[0].leftRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[0].rightIntFull]));
				prefabScript.crossingElements[0].rightRoundingPoints.Add(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[0].leftIntFull]);
				prefabScript.crossingElements[0].rightRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[0].leftIntFull]));
			}
			else
			{
				prefabScript.crossingElements[0].leftRoundingPoints.Add(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[0].leftIntFull]);
				prefabScript.crossingElements[0].leftRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[0].leftIntFull]));
				prefabScript.crossingElements[0].rightRoundingPoints.Add(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[0].rightIntFull]);
				prefabScript.crossingElements[0].rightRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[0].rightIntFull]));
			}
			prefabScript.crossingElements[1].leftRoundingPoints.Clear();
			prefabScript.crossingElements[1].leftRoundingPointsGlobal.Clear();
			prefabScript.crossingElements[1].rightRoundingPoints.Clear();
			prefabScript.crossingElements[1].rightRoundingPointsGlobal.Clear();
			if (prefabScript.crossingElements[1].connectedMarker == 0)
			{
				prefabScript.crossingElements[1].leftRoundingPoints.Add(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[1].rightIntFull]);
				prefabScript.crossingElements[1].leftRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[1].rightIntFull]));
				prefabScript.crossingElements[1].rightRoundingPoints.Add(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[1].leftIntFull]);
				prefabScript.crossingElements[1].rightRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[1].leftIntFull]));
			}
			else
			{
				prefabScript.crossingElements[1].leftRoundingPoints.Add(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[1].leftIntFull]);
				prefabScript.crossingElements[1].leftRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[1].leftIntFull]));
				prefabScript.crossingElements[1].rightRoundingPoints.Add(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[1].rightIntFull]);
				prefabScript.crossingElements[1].rightRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.tmpFullMeshVecs[prefabScript.crossingElements[1].rightIntFull]));
			}
			if ((roadType1Object.roadShapeData.lanes != null && roadType1Object.roadShapeData.lanes.Count == 0) || (roadType2Object.roadShapeData.lanes != null && roadType2Object.roadShapeData.lanes.Count == 0))
			{
				return;
			}
			bool flag5 = false;
			if (roadType1Object.roadShapeData.leftLanes == -1)
			{
				roadType1Object.OQCOOODCQC();
			}
			if (roadType2Object.roadShapeData.leftLanes == -1)
			{
				roadType2Object.OQCOOODCQC();
			}
			if (roadType1Object.roadShapeData.leftLanes == roadType2Object.roadShapeData.leftLanes && roadType1Object.roadShapeData.rightLanes == roadType2Object.roadShapeData.rightLanes)
			{
				flag5 = true;
			}
			for (int num24 = 0; num24 < prefabScript.siblings.Count; num24++)
			{
				if (prefabScript.siblings[num24].laneData == null)
				{
					prefabScript.siblings[num24].laneData = ERLaneData.CreateInstance();
				}
				prefabScript.siblings[num24].laneData.connectors.Clear();
				int num25 = prefabScript.siblings[num24].roadType.roadShapeData.rightLanes;
				int num26 = -1;
				for (int num27 = 0; num27 < prefabScript.siblings[num24].roadType.roadShapeData.lanes.Count; num27++)
				{
					if (baseScript.rightHandDriving == 1)
					{
						if (prefabScript.siblings[num24].roadType.roadShapeData.lanes[num27].direction != ERLaneDirection.Right)
						{
							continue;
						}
						num25--;
						for (int num28 = 0; num28 < prefabScript.siblings.Count; num28++)
						{
							int leftLanes = prefabScript.siblings[num28].roadType.roadShapeData.leftLanes;
							if (num28 == num24)
							{
								continue;
							}
							if (prefabScript.siblings[num28].roadType.roadShapeData.leftLanes == -1)
							{
								prefabScript.siblings[num28].roadType.OQCOOODCQC();
							}
							for (int num29 = 0; num29 < prefabScript.siblings[num28].roadType.roadShapeData.leftLanes; num29++)
							{
								if (!flag5 || num25 == num29)
								{
									bool stop = false;
									ERLaneConnector ussss = ERLaneConnector.CreateInstance();
									ussss.startConnectionIndex = num24;
									ussss.startLaneIndex = num27;
									ussss.endConnectionIndex = num28;
									ussss.endLaneIndex = num29;
									ussss.stop = false;
									ussss.stop = stop;
									ussst(prefabScript, ref ussss, num24, num28, prefabScript.siblings[num24].roadTypeAI.roadShapeData.lanes[num27].TurnOptions, prefabScript.siblings[num24].forward, prefabScript.siblings[num28].forward);
									if (ussss != null)
									{
										ussss.minSpeed = roadType1Object.minSpeed;
										ussss.maxSpeed = roadType1Object.maxSpeed;
										ussss.speedLimit = roadType1Object.speedLimit;
										prefabScript.siblings[num24].laneData.connectors.Add(ussss);
									}
								}
							}
							if (prefabScript.siblings[num24].roadType.roadShapeData.leftLanes == -1)
							{
								prefabScript.siblings[num24].roadType.OQCOOODCQC();
							}
						}
					}
					else
					{
						if (prefabScript.siblings[num24].roadType.roadShapeData.lanes[num27].direction != ERLaneDirection.Left)
						{
							continue;
						}
						num26++;
						for (int num30 = 0; num30 < prefabScript.siblings.Count; num30++)
						{
							int rightLanes = prefabScript.siblings[num30].roadType.roadShapeData.rightLanes;
							if (num30 == num24)
							{
								continue;
							}
							if (prefabScript.siblings[num30].roadType.roadShapeData.rightLanes == -1)
							{
								prefabScript.siblings[num30].roadType.OQCOOODCQC();
							}
							for (int num31 = 0; num31 < prefabScript.siblings[num30].roadType.roadShapeData.rightLanes; num31++)
							{
								int num32 = prefabScript.siblings[num30].roadType.roadShapeData.rightLanes - num31 - 1;
								int endLaneIndex = prefabScript.siblings[num30].roadType.roadShapeData.leftLanes + num31;
								if (!flag5 || num26 == num32)
								{
									bool stop2 = false;
									ERLaneConnector ussss2 = ERLaneConnector.CreateInstance();
									ussss2.startConnectionIndex = num24;
									ussss2.startLaneIndex = num27;
									ussss2.endConnectionIndex = num30;
									ussss2.endLaneIndex = endLaneIndex;
									ussss2.stop = stop2;
									ussst(prefabScript, ref ussss2, num24, num30, prefabScript.siblings[num24].roadTypeAI.roadShapeData.lanes[num27].TurnOptions, prefabScript.siblings[num24].forward, prefabScript.siblings[num30].forward);
									if (ussss2 != null)
									{
										ussss2.minSpeed = roadType1Object.minSpeed;
										ussss2.maxSpeed = roadType1Object.maxSpeed;
										ussss2.speedLimit = roadType1Object.speedLimit;
										prefabScript.siblings[num24].laneData.connectors.Add(ussss2);
									}
								}
							}
							if (prefabScript.siblings[num24].roadType.roadShapeData.leftLanes == -1)
							{
								prefabScript.siblings[num24].roadType.OQCOOODCQC();
							}
						}
					}
				}
			}
		}

		private void ussst(ERCrossingPrefabs tssss, ref ERLaneConnector ussss, int vssss, int wssss, ERLaneDirectionOptions xssss, Vector3 yssss, Vector3 Assss)
		{
			float num = 0f;
			float num2 = 0f;
			bool flag = true;
			int num3 = 1;
			if (tssss.baseScript.rightHandDriving == 0)
			{
				num3 = 0;
			}
			num = tssss.siblings[vssss].roadTypeAI.roadShapeData.lanes[ussss.startLaneIndex].position;
			if ((vssss == num3 && tssss.crossingElements[vssss].connectedMarker == 0) || (vssss == num3 && tssss.crossingElements[vssss].connectedMarker != 0))
			{
				num *= -1f;
				flag = false;
			}
			num2 = tssss.siblings[wssss].roadTypeAI.roadShapeData.lanes[ussss.endLaneIndex].position;
			if (num < 0f)
			{
				ussss.connectorStartLocal = Vector3.Lerp(tssss.crossingElements[vssss].centerPoint, tssss.crossingElements[vssss].leftRoundingPoints[0], 0f - num);
			}
			else
			{
				ussss.connectorStartLocal = Vector3.Lerp(tssss.crossingElements[vssss].centerPoint, tssss.crossingElements[vssss].rightRoundingPoints[0], num);
			}
			num2 = ((tssss.crossingElements[ussss.endConnectionIndex].connectedMarker != 0) ? tssss.siblings[wssss].roadTypeAI.roadShapeData.lanes[ussss.endLaneIndex].position : tssss.siblings[wssss].roadTypeAI.roadShapeData.lanes[tssss.siblings[wssss].roadTypeAI.roadShapeData.lanes.Count - 1 - ussss.endLaneIndex].position);
			if (num2 < 0f)
			{
				ussss.connectorEndLocal = Vector3.Lerp(tssss.crossingElements[ussss.endConnectionIndex].centerPoint, tssss.crossingElements[ussss.endConnectionIndex].leftRoundingPoints[0], 0f - num);
			}
			else
			{
				ussss.connectorEndLocal = Vector3.Lerp(tssss.crossingElements[ussss.endConnectionIndex].centerPoint, tssss.crossingElements[ussss.endConnectionIndex].rightRoundingPoints[0], num);
			}
			ussss.connectorStart = tssss.transform.TransformPoint(ussss.connectorStartLocal);
			ussss.connectorEnd = tssss.transform.TransformPoint(ussss.connectorEndLocal);
			ussss.mainConnection = true;
			ussss.laneDirection = ERDirectionType.Straight;
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector3> list3 = new List<Vector3>();
			if ((num < 0f && num2 >= 0f) || (num >= 0f && num2 < 0f))
			{
				num = Mathf.Abs(num);
				num2 = Mathf.Abs(num2);
			}
			if (connectorLength1 != 0f || connectorLength2 != 0f)
			{
				Vector3 value = Vector3.zero;
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				Vector3 zero3 = Vector3.zero;
				if (prefabScript.crossingElements[vssss].connectedMarker == 0)
				{
					if (tssss.baseScript.rightHandDriving == 0)
					{
						int num4 = prefabScript.crossingElements[vssss].connectedRoad.rt.totalLanes - 1 - ussss.startLaneIndex;
						if (num4 < prefabScript.crossingElements[vssss].connectedRoad.laneData.Count && prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points.Length > 1)
						{
							value = prefabScript.crossingElements[vssss].connectedRoad.laneData[num4].points[prefabScript.crossingElements[vssss].connectedRoad.laneData[num4].points.Length - 1];
							zero = prefabScript.crossingElements[vssss].connectedRoad.laneData[num4].points[prefabScript.crossingElements[vssss].connectedRoad.laneData[num4].points.Length - 2];
						}
					}
					else
					{
						value = prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points[0];
						zero = prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points[1];
					}
				}
				else if (tssss.baseScript.rightHandDriving == 0)
				{
					if (ussss.startLaneIndex < prefabScript.crossingElements[vssss].connectedRoad.laneData.Count && prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points.Length > 1)
					{
						value = prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points[prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points.Length - 1];
						zero = prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points[prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points.Length - 2];
					}
				}
				else
				{
					int num5 = prefabScript.crossingElements[vssss].connectedRoad.rt.totalLanes - 1 - ussss.startLaneIndex;
					if (num5 < prefabScript.crossingElements[vssss].connectedRoad.laneData.Count && prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points.Length > 1)
					{
						value = prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points[prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points.Length - 1];
						zero = prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points[prefabScript.crossingElements[vssss].connectedRoad.laneData[ussss.startLaneIndex].points.Length - 2];
					}
				}
				if (prefabScript.crossingElements[wssss].connectedMarker == 0)
				{
					if (tssss.baseScript.rightHandDriving == 0)
					{
						int num6 = prefabScript.crossingElements[wssss].connectedRoad.rt.totalLanes - 1 - ussss.endLaneIndex;
						if (num6 < prefabScript.crossingElements[wssss].connectedRoad.laneData.Count && prefabScript.crossingElements[wssss].connectedRoad.laneData[num6].points.Length > 1)
						{
							zero2 = prefabScript.crossingElements[wssss].connectedRoad.laneData[num6].points[0];
							zero3 = prefabScript.crossingElements[wssss].connectedRoad.laneData[num6].points[1];
						}
					}
					else
					{
						int num7 = prefabScript.crossingElements[vssss].connectedRoad.rt.totalLanes - 1 - ussss.endLaneIndex;
						zero2 = prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points[prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points.Length - 1];
						zero3 = prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points[prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points.Length - 2];
					}
				}
				else if (tssss.baseScript.rightHandDriving == 0)
				{
					if (ussss.endLaneIndex < prefabScript.crossingElements[wssss].connectedRoad.laneData.Count && prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points.Length > 1)
					{
						zero2 = prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points[0];
						zero3 = prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points[1];
					}
				}
				else if (ussss.endLaneIndex < prefabScript.crossingElements[wssss].connectedRoad.laneData.Count && prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points.Length > 1)
				{
					zero2 = prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points[0];
					zero3 = prefabScript.crossingElements[wssss].connectedRoad.laneData[ussss.endLaneIndex].points[1];
				}
				float num8 = 0f;
				float num9 = 0f;
				if (connectorLength1 > 0f && connectorLength2 > 0f && road1Stretch != 1f && road2Stretch != 1f)
				{
					num8 = connectorLength1 / (connectorLength1 + connectorLength2);
				}
				if (connectorLength1 != 0f)
				{
					float num10 = num;
					float num11 = num2;
					if (num8 != 0f)
					{
						if (vssss == 0)
						{
							num11 = Mathf.Lerp(num, num2, num8);
							num9 = num11;
						}
						else
						{
							num10 = Mathf.Lerp(num, num2, num8);
							num9 = num10;
						}
					}
					if (num10 < 0f)
					{
						num10 *= -1f;
					}
					if (num11 < 0f)
					{
						num11 *= -1f;
					}
					if (vssss == 1)
					{
						float num12 = num10;
						num10 = num11;
						num11 = num12;
					}
					float num13 = 0f;
					float num14 = splinePoints1.Count - 1;
					for (int i = 0; (float)i <= num14; i++)
					{
						num13 = Mathf.Lerp(num10, num11, (float)i * 1f / num14);
						Vector3 item = ((!flag) ? Vector3.Lerp(centerPoints1[i], leftRoundingPoints1[i], num13) : Vector3.Lerp(centerPoints1[i], rightRoundingPoints1[i], num13));
						list.Add(item);
					}
					if (list.Count < 4)
					{
					}
				}
				if (vssss == 1)
				{
					list.Reverse();
				}
				if (connectorLength2 != 0f)
				{
					float num15 = num;
					float num16 = num2;
					if (num8 != 0f)
					{
						num15 = num;
						if (vssss == 0)
						{
							num15 = num9;
						}
						else
						{
							num16 = num9;
						}
					}
					if (num15 < 0f)
					{
						num15 *= -1f;
					}
					if (num16 < 0f)
					{
						num16 *= -1f;
					}
					if (vssss == 0)
					{
						float num17 = num15;
						num15 = num16;
						num16 = num17;
					}
					float num18 = 0f;
					float num19 = splinePoints2.Count - 1;
					for (int j = 0; (float)j <= num19; j++)
					{
						num18 = Mathf.Lerp(num15, num16, (float)j * 1f / num19);
						if (num18 < 0f)
						{
							num18 *= -1f;
						}
						Vector3 item2 = ((!flag) ? Vector3.Lerp(centerPoints2[j], rightRoundingPoints2[j], num18) : Vector3.Lerp(centerPoints2[j], leftRoundingPoints2[j], num18));
						list2.Add(item2);
					}
					if (list2.Count >= 4)
					{
					}
					if (vssss == 0)
					{
						list2.Reverse();
						if (list.Count > 0)
						{
							list2.RemoveAt(0);
						}
						list.AddRange(list2);
					}
					else
					{
						if (list.Count > 0)
						{
							list.RemoveAt(0);
						}
						list.InsertRange(0, list2);
					}
				}
				list[0] = value;
			}
			for (int k = 0; k < list.Count; k++)
			{
				list3.Add(list[k]);
			}
			ussss.points = list3.ToArray();
		}

		public void GetIConnectionData(List<Vector3> vecs1, List<bool> conInts1, List<bool> conInts2, bool reversed1, bool reversed2, int road2Start)
		{
			if (base.gameObject.GetComponent<ERCrossingPrefabs>() == null)
			{
				base.gameObject.AddComponent<ERCrossingPrefabs>();
			}
			if (prefabScript == null)
			{
				prefabScript = base.gameObject.GetComponent<ERCrossingPrefabs>();
			}
			if (prefabScript.crossingElements.Count < 4)
			{
				for (int i = prefabScript.crossingElements.Count; i < 4; i++)
				{
					prefabScript.crossingElements.Add(new QDOODOQQDQODD());
				}
			}
			prefabScript.meshVecs = vecs1.ToArray();
			prefabScript.tmpMeshVecs = new Vector3[prefabScript.meshVecs.Length];
			Array.Copy(prefabScript.meshVecs, prefabScript.tmpMeshVecs, prefabScript.meshVecs.Length);
			prefabScript.tmpFullMeshVecs = new Vector3[prefabScript.meshVecs.Length];
			Array.Copy(prefabScript.meshVecs, prefabScript.tmpFullMeshVecs, prefabScript.meshVecs.Length);
			prefabScript.fullMeshVecs = new Vector3[prefabScript.meshVecs.Length];
			Array.Copy(prefabScript.meshVecs, prefabScript.fullMeshVecs, prefabScript.meshVecs.Length);
			prefabScript.surfaceMeshVecs = (prefabScript.tmpSurfaceMeshVecs = surfaceVecs.ToArray());
			prefabScript.crossingElements[0].centerPoint = (prefabScript.crossingElements[0].tmpCenterPoint = splinePoints1[0]);
			prefabScript.crossingElements[0].controlPointV3 = Vector3.zero;
			prefabScript.crossingElements[0].alignmentHandleVec = Vector3.zero;
			if (splinePoints2.Count > 0)
			{
				prefabScript.crossingElements[1].centerPoint = (prefabScript.crossingElements[1].tmpCenterPoint = splinePoints2[0]);
			}
			else
			{
				prefabScript.crossingElements[1].centerPoint = (prefabScript.crossingElements[1].tmpCenterPoint = Vector3.zero);
			}
			prefabScript.crossingElements[1].controlPointV3 = Vector3.zero;
			prefabScript.crossingElements[1].alignmentHandleVec = Vector3.zero;
			prefabScript.surfaceInts = new int[16];
			prefabScript.surfaceInts[0] = 1;
			prefabScript.surfaceInts[1] = 0;
			prefabScript.surfaceInts[2] = 2;
			prefabScript.surfaceInts[3] = 3;
			prefabScript.surfaceInts[4] = surfaceVecs.Count - 2;
			prefabScript.surfaceInts[5] = surfaceVecs.Count - 1;
			prefabScript.surfaceInts[6] = surfaceVecs.Count - 3;
			prefabScript.surfaceInts[7] = surfaceVecs.Count - 4;
			prefabScript.surfaceVecs = new List<Vector3>(surfaceVecs);
			prefabScript.crossingElements[0].connectionVecInts.Clear();
			prefabScript.crossingElements[0].fullConnectionVecInts.Clear();
			prefabScript.crossingElements[1].connectionVecInts.Clear();
			prefabScript.crossingElements[2].fullConnectionVecInts.Clear();
			List<int> list = new List<int>();
			for (int j = 0; j < conInts1.Count; j++)
			{
				if (conInts1[j])
				{
					list.Add(j);
				}
			}
			if (reversed1)
			{
				list.Reverse();
			}
			prefabScript.crossingElements[0].connectionVecInts = new List<int>(list);
			prefabScript.crossingElements[0].fullConnectionVecInts = new List<int>(list);
			int mostLeftInt = 0;
			int mostRightInt = list.Count - 1;
			GetLeftRightInts(roadShape1, ref mostLeftInt, ref mostRightInt);
			prefabScript.crossingElements[0].leftInt = mostLeftInt;
			prefabScript.crossingElements[0].leftIntFull = mostLeftInt;
			prefabScript.crossingElements[0].rightInt = mostRightInt;
			prefabScript.crossingElements[0].rightIntFull = mostRightInt;
			prefabScript.crossingElements[0].leftSurroundingV3 = surfaceVecs[0];
			prefabScript.crossingElements[0].rightSurroundingV3 = surfaceVecs[3];
			prefabScript.crossingElements[0].leftIndentV3 = surfaceVecs[1];
			prefabScript.crossingElements[0].rightIndentV3 = surfaceVecs[2];
			prefabScript.crossingElements[0].centerPoint = (prefabScript.crossingElements[0].tmpCenterPoint = base.transform.InverseTransformPoint(splinePoints1[0]));
			if (prefabScript.crossingElements[0].centerPoint == Vector3.zero)
			{
				prefabScript.crossingElements[0].centerPoint = (prefabScript.crossingElements[0].tmpCenterPoint = -centerDir * 3f);
			}
			if (prefabScript.crossingElements[0].connectedRoad != null && prefabScript.crossingElements[0].connectedMarker < prefabScript.crossingElements[0].connectedRoad.markersExt.Count)
			{
				if (splinePoints1[0] != base.transform.position)
				{
					prefabScript.crossingElements[0].connectedRoad.markersExt[prefabScript.crossingElements[0].connectedMarker].position = splinePoints1[0];
				}
				else
				{
					prefabScript.crossingElements[0].connectedRoad.markersExt[prefabScript.crossingElements[0].connectedMarker].position = splinePoints1[0] + -centerDir * 3f;
				}
			}
			prefabScript.crossingElements[1].leftSurroundingV3 = prefabScript.crossingElements[0].rightSurroundingV3;
			prefabScript.crossingElements[1].rightSurroundingV3 = prefabScript.crossingElements[0].leftSurroundingV3;
			prefabScript.crossingElements[1].leftIndentV3 = prefabScript.crossingElements[0].rightIndentV3;
			prefabScript.crossingElements[1].rightIndentV3 = prefabScript.crossingElements[0].leftIndentV3;
			if (splinePoints2.Count > 0)
			{
				list.Clear();
				for (int k = 0; k < conInts2.Count; k++)
				{
					if (conInts2[k])
					{
						list.Add(road2Start + k);
					}
				}
				if (reversed2)
				{
					list.Reverse();
				}
				prefabScript.crossingElements[1].connectionVecInts = new List<int>(list);
				prefabScript.crossingElements[1].fullConnectionVecInts = new List<int>(list);
				mostLeftInt = 0;
				mostRightInt = list.Count - 1;
				GetLeftRightInts(roadShape2, ref mostLeftInt, ref mostRightInt);
				prefabScript.crossingElements[1].leftInt = mostLeftInt;
				prefabScript.crossingElements[1].leftIntFull = mostLeftInt;
				prefabScript.crossingElements[1].rightInt = mostRightInt;
				prefabScript.crossingElements[1].rightIntFull = mostRightInt;
				if (splinePoints2.Count == 1)
				{
					float num = Vector3.Distance(surfaceVecs[surfaceVecs.Count - 1], surfaceVecs[0]);
					float num2 = Vector3.Distance(surfaceVecs[surfaceVecs.Count - 1], surfaceVecs[3]);
					if (connectorLength1 == 0f && num2 < num)
					{
						prefabScript.crossingElements[1].leftSurroundingV3 = surfaceVecs[surfaceVecs.Count - 1];
						prefabScript.crossingElements[1].rightSurroundingV3 = surfaceVecs[surfaceVecs.Count - 4];
						prefabScript.crossingElements[1].leftIndentV3 = surfaceVecs[surfaceVecs.Count - 2];
						prefabScript.crossingElements[1].rightIndentV3 = surfaceVecs[surfaceVecs.Count - 3];
					}
					else
					{
						prefabScript.crossingElements[1].leftSurroundingV3 = surfaceVecs[surfaceVecs.Count - 4];
						prefabScript.crossingElements[1].rightSurroundingV3 = surfaceVecs[surfaceVecs.Count - 1];
						prefabScript.crossingElements[1].leftIndentV3 = surfaceVecs[surfaceVecs.Count - 3];
						prefabScript.crossingElements[1].rightIndentV3 = surfaceVecs[surfaceVecs.Count - 2];
					}
				}
				else
				{
					prefabScript.crossingElements[1].leftSurroundingV3 = surfaceVecs[surfaceVecs.Count - 1];
					prefabScript.crossingElements[1].rightSurroundingV3 = surfaceVecs[surfaceVecs.Count - 4];
					prefabScript.crossingElements[1].leftIndentV3 = surfaceVecs[surfaceVecs.Count - 2];
					prefabScript.crossingElements[1].rightIndentV3 = surfaceVecs[surfaceVecs.Count - 3];
					prefabScript.crossingElements[1].connectionVecInts.Reverse();
					prefabScript.crossingElements[1].fullConnectionVecInts.Reverse();
				}
				prefabScript.crossingElements[1].centerPoint = (prefabScript.crossingElements[1].tmpCenterPoint = base.transform.InverseTransformPoint(splinePoints2[0]));
			}
			else
			{
				prefabScript.crossingElements[1].centerPoint = (prefabScript.crossingElements[1].tmpCenterPoint = centerDir * 3f);
			}
			if (prefabScript.crossingElements[1].connectedRoad != null && prefabScript.crossingElements[1].connectedMarker < prefabScript.crossingElements[1].connectedRoad.markersExt.Count)
			{
				if (splinePoints2[0] != base.transform.position)
				{
					prefabScript.crossingElements[1].connectedRoad.markersExt[prefabScript.crossingElements[1].connectedMarker].position = splinePoints2[0];
				}
				else
				{
					prefabScript.crossingElements[1].connectedRoad.markersExt[prefabScript.crossingElements[1].connectedMarker].position = splinePoints2[0] + centerDir * 3f;
				}
			}
		}

		public void GetLeftRightInts(List<Vector2> roadShape, ref int mostLeftInt, ref int mostRightInt)
		{
			float num = 100000f;
			float num2 = -100000f;
			for (int i = 0; i < roadShape.Count; i++)
			{
				if (roadShape[i].x < num)
				{
					mostRightInt = i;
					num = roadShape[i].x;
				}
				if (roadShape[i].x > num2)
				{
					mostLeftInt = i;
					num2 = roadShape[i].x;
				}
			}
			if (mostLeftInt > mostRightInt)
			{
				int num3 = mostLeftInt;
				mostLeftInt = mostRightInt;
				mostRightInt = num3;
			}
		}

		public void OCQDCQOQDD(List<Vector3> splinePoints, List<Vector3> splinePointsOther, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> tris, List<Vector2> roadShape, List<float> roadShapeUVs, List<int> roadShapeMaterialInts, float uvRatio, float stretchRatio, float stretchType, ref List<Vector3> leftPoints, ref List<Vector3> rightPoints, bool reversed, Vector3 cDir, int firstSecond, int startEnd, ref List<Vector3> centerPoints, ref List<Vector3> leftRoundingPoints, ref List<Vector3> rightRoundingPoints, float roadOffsetValue, ref List<Vector3> roadSplinePoints)
		{
			roadSplinePoints.Clear();
			float num = 100f;
			int num2 = 0;
			float num3 = -100f;
			int num4 = 0;
			for (int i = 0; i < roadShape.Count; i++)
			{
				if (roadShape[i].x < num)
				{
					num = roadShape[i].x;
					num2 = i;
				}
				if (roadShape[i].x > num3)
				{
					num3 = roadShape[i].x;
					num4 = i;
				}
			}
			int count = roadShape.Count;
			int num5 = 0;
			int num6 = 0;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			for (int j = 1; j < splinePoints.Count; j++)
			{
				num10 += Vector3.Distance(splinePoints[j - 1], splinePoints[j]);
			}
			float num11 = num10;
			float num12 = 1f;
			if (splinePointsOther.Count > 1)
			{
				for (int k = 1; k < splinePointsOther.Count; k++)
				{
					num11 += Vector3.Distance(splinePointsOther[k - 1], splinePointsOther[k]);
				}
				num12 = num11 / num10;
				num12 *= (float)splinePoints.Count * 1f / ((float)splinePointsOther.Count * 1f);
			}
			if (reversed)
			{
				uvRatio *= -1f;
			}
			List<float> list = new List<float>(roadShapeUVs);
			if (reversed)
			{
				list.Reverse();
			}
			float a = 0f;
			float b = 1f;
			if (textureType == 2)
			{
				if (connectorLength1 == 0f || connectorLength2 == 0f)
				{
					if (transitionSwap)
					{
						a = 1f;
						b = 0f;
					}
				}
				else
				{
					float num13 = connectorLength1 + connectorLength2;
					float num14 = connectorLength1 / num13;
					float num15 = connectorLength2 / num13;
					if (firstSecond == 0)
					{
						b = num14;
						if (transitionSwap)
						{
							a = 1f;
							b = 1f - num14;
						}
					}
					else
					{
						a = 1f;
						b = 1f - num15;
						if (transitionSwap)
						{
							a = 0f;
							b = num15;
						}
					}
				}
			}
			float num16 = roadWidth1;
			if (roadWidth2 > num16)
			{
				num16 = roadWidth2;
			}
			num16 *= 0.5f;
			float num17 = 0f;
			Vector3 vector;
			if (splinePoints.Count > 1)
			{
				for (int l = 0; l < splinePoints.Count; l++)
				{
					if (l > 0)
					{
						num9 = Vector3.Distance(splinePoints[l - 1], splinePoints[l]);
						num7 += num9;
					}
					num8 = num7 / uvRatio;
					vector = ((l == 0) ? (splinePoints[l + 1] - splinePoints[l]).normalized : ((l != splinePoints.Count - 1) ? (splinePoints[l + 1] - splinePoints[l - 1]).normalized : ((splinePointsOther.Count != 0) ? cDir : (splinePoints[l] - splinePoints[l - 1]).normalized)));
					Vector3 vector2 = splinePoints[l];
					if (l == splinePoints.Count - 1 && textureType == 2)
					{
						vector2 += vector * 0.0025f;
					}
					vector = new Vector3(0f - vector.z, 0f, vector.x).normalized;
					if (firstSecond != 1 || startEnd == 0)
					{
					}
					centerPoints.Add(splinePoints[l]);
					float num18 = num7 / num11;
					if (stretchType == 1f)
					{
						num18 *= num18;
					}
					else if (stretchType == 2f)
					{
						num18 = Mathf.SmoothStep(0f, 1f, num18);
					}
					if (stretchType != 1f && num12 != 1f)
					{
						num18 *= num12;
					}
					num17 = roadOffsetValue * num18;
					Vector3 zero = Vector3.zero;
					Vector3 zero2 = Vector3.zero;
					for (int m = 0; m < roadShape.Count; m++)
					{
						float num19 = Mathf.Lerp(roadShape[m].x, roadShape[m].x * stretchRatio, num18);
						num19 -= num17;
						Vector3 vector3 = vector2 + vector * num19;
						vector3.y += roadShape[m].y;
						vecs.Add(base.transform.InverseTransformPoint(vector3));
						if (m == num2)
						{
							rightRoundingPoints.Add(vector3);
							zero = vector3;
						}
						else if (m == num4)
						{
							leftRoundingPoints.Add(vector3);
							zero2 = vector3;
						}
						if (textureType != 2)
						{
							uvs.Add(new Vector2(list[m], num8));
						}
						else
						{
							uvs.Add(new Vector2(list[m], Mathf.Lerp(a, b, num7 / num10)));
						}
						if (m == 0)
						{
							num19 = Mathf.Lerp(num, num * stretchRatio, num18);
							leftPoints.Add(base.transform.InverseTransformPoint(splinePoints[l] + vector * num19));
							num19 = Mathf.Lerp(num3, num3 * stretchRatio, num18);
							rightPoints.Add(base.transform.InverseTransformPoint(splinePoints[l] + vector * num19));
						}
						bool flag = true;
						num6 = roadShapeMaterialInts[m];
						if (m < roadShapeMaterialInts.Count - 2 && num6 != roadShapeMaterialInts[m + 1])
						{
							flag = false;
						}
						if (m == roadShape.Count - 1 || l == splinePoints.Count - 1)
						{
							flag = false;
						}
						if (flag)
						{
							if (!reversed)
							{
								tris[num6].Add(l * count + m + num5);
								tris[num6].Add((l + 1) * count + m + 1 + num5);
								tris[num6].Add(l * count + m + 1 + num5);
								tris[num6].Add((l + 1) * count + m + num5);
								tris[num6].Add((l + 1) * count + m + 1 + num5);
								tris[num6].Add(l * count + m + num5);
							}
							else
							{
								tris[num6].Add(l * count + m + num5);
								tris[num6].Add(l * count + m + 1 + num5);
								tris[num6].Add((l + 1) * count + m + 1 + num5);
								tris[num6].Add((l + 1) * count + m + num5);
								tris[num6].Add(l * count + m + num5);
								tris[num6].Add((l + 1) * count + m + 1 + num5);
							}
						}
					}
					if (transitionAlignmentIndex == 0)
					{
						roadSplinePoints.Add(splinePoints[l]);
					}
					else if (transitionAlignmentIndex == 1)
					{
						vector = (splinePoints[l] - leftRoundingPoints[l]).normalized;
						roadSplinePoints.Add(leftRoundingPoints[l] + vector * num16);
					}
					else
					{
						vector = (splinePoints[l] - rightRoundingPoints[l]).normalized;
						roadSplinePoints.Add(rightRoundingPoints[l] + vector * num16);
					}
				}
				return;
			}
			vector = new Vector3(0f - centerDir.z, 0f, centerDir.x).normalized;
			if (firstSecond == 1 && startEnd == 1)
			{
				vector *= -1f;
			}
			for (int n = 0; n < roadShape.Count; n++)
			{
				Vector3 vector3 = splinePoints[0] + vector * roadShape[n].x;
				vector3.y += roadShape[n].y;
				vecs.Add(base.transform.InverseTransformPoint(vector3));
				uvs.Add(Vector2.zero);
				if (n == 0)
				{
					leftPoints.Add(base.transform.InverseTransformPoint(splinePoints[0] + vector * num));
					rightPoints.Add(base.transform.InverseTransformPoint(splinePoints[0] + vector * num3));
				}
			}
		}

		public List<Vector2> ODDCCODQDO(float startY, List<Vector3> splinePoints, List<float> roadShapeUVs, float uvRatio, bool reversed, float sourceUV)
		{
			float num = 0f;
			float num2 = 0f;
			List<Vector2> list = new List<Vector2>();
			List<Vector2> list2 = new List<Vector2>();
			splinePoints.Reverse();
			if (reversed)
			{
				uvRatio *= -1f;
			}
			List<float> list3 = new List<float>(roadShapeUVs);
			if (((double)sourceUV < 0.5 && (double)list3[0] > 0.5) || ((double)sourceUV > 0.5 && (double)list3[0] < 0.5))
			{
				list3.Reverse();
			}
			for (int i = 0; i < splinePoints.Count; i++)
			{
				if (i > 0)
				{
					num += Vector3.Distance(splinePoints[i - 1], splinePoints[i]);
				}
				num2 = num / uvRatio;
				list2.Clear();
				for (int j = 0; j < list3.Count; j++)
				{
					list2.Add(new Vector2(1f - list3[j], startY + num2));
				}
				list.InsertRange(0, list2);
			}
			splinePoints.Reverse();
			return list;
		}

		public void ODDCQCQQCC(ref List<Color> colors, List<Vector3> splinePoints1, List<Vector3> splinePoints2, List<Vector2> roadShape1, List<Vector2> roadShape2)
		{
			Vector3 position = base.transform.position;
			float num = blendDistance * 0.5f;
			Color white = Color.white;
			float a = 0.5f;
			if (blendSection == 1)
			{
				a = 1f;
			}
			else if (blendSection == 2)
			{
				a = 0f;
			}
			for (int i = 0; i < splinePoints1.Count; i++)
			{
				float num2 = Vector3.Distance(splinePoints1[i], position);
				if (num2 > num)
				{
					white.a = 0f;
				}
				else
				{
					white.a = Mathf.Lerp(a, 0f, num2 / num);
				}
				for (int j = 0; j < roadShape1.Count; j++)
				{
					colors.Add(white);
				}
			}
			a = 0.5f;
			if (blendSection == 1)
			{
				a = 1f;
			}
			else if (blendSection == 2)
			{
				a = 0f;
			}
			for (int k = 0; k < splinePoints2.Count; k++)
			{
				float num3 = Vector3.Distance(splinePoints2[k], position);
				if (num3 > num)
				{
					white.a = 1f;
				}
				else
				{
					white.a = Mathf.Lerp(a, 1f, num3 / num);
				}
				for (int l = 0; l < roadShape2.Count; l++)
				{
					colors.Add(white);
				}
			}
		}

		public void OQCCOQOQOO(ref List<Vector3> targetArray, List<Vector3> otherArray)
		{
			List<Vector3> list = new List<Vector3>(otherArray);
			list.Reverse();
			list.RemoveAt(0);
			targetArray.AddRange(list);
		}

		public void SetUVS(List<Vector3> leftRoundingPoints, List<Vector3> leftPointsIndents, List<Vector3> centerPoints, List<Vector3> rightPointsIndents, List<Vector3> rightRoundingPoints, ref List<Vector2> leftRoundingPointsUV, ref List<Vector2> leftPointsIndentsUV, ref List<Vector2> centerPointsUV, ref List<Vector2> rightPointsIndentsUV, ref List<Vector2> rightRoundingPointsUV, ref Vector2 cp, float leftIndentUVX, float rightIndentUVX)
		{
			centerPointsUV.Clear();
			leftRoundingPointsUV.Clear();
			leftPointsIndentsUV.Clear();
			rightRoundingPointsUV.Clear();
			rightPointsIndentsUV.Clear();
			float num = 0.2f;
			float num2 = 0f;
			centerPointsUV.Add(new Vector2(0.5f, 0f));
			for (int i = 1; i < centerPoints.Count; i++)
			{
				num2 += Vector3.Distance(centerPoints[i - 1], centerPoints[i]);
				centerPointsUV.Add(new Vector2(0.5f, num2 * num));
			}
			num2 += Vector3.Distance(centerPoints[centerPoints.Count - 1], Vector3.zero);
			cp = new Vector2(0.5f, num2 * num);
			num2 = 0f;
			leftRoundingPointsUV.Add(new Vector2(0f, 0f));
			leftPointsIndentsUV.Add(new Vector2(leftIndentUVX, 0f));
			for (int j = 1; j < leftRoundingPoints.Count; j++)
			{
				num2 += Vector3.Distance(leftRoundingPoints[j - 1], leftRoundingPoints[j]);
				leftRoundingPointsUV.Add(new Vector2(0f, num2 * num));
				leftPointsIndentsUV.Add(new Vector2(leftIndentUVX, num2 * num));
			}
			num2 = 0f;
			rightRoundingPointsUV.Add(new Vector2(1f, 0f));
			rightPointsIndentsUV.Add(new Vector2(rightIndentUVX, 0f));
			for (int k = 1; k < rightRoundingPoints.Count; k++)
			{
				num2 += Vector3.Distance(rightRoundingPoints[k - 1], rightRoundingPoints[k]);
				rightRoundingPointsUV.Add(new Vector2(1f, num2 * num));
				rightPointsIndentsUV.Add(new Vector2(rightIndentUVX, num2 * num));
			}
		}

		public Mesh OCOCDCDDOD()
		{
			Mesh mesh = null;
			if (!base.gameObject.GetComponent<MeshRenderer>())
			{
				base.gameObject.AddComponent<MeshRenderer>();
				base.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			if (!base.gameObject.GetComponent<MeshFilter>())
			{
				base.gameObject.AddComponent<MeshFilter>();
			}
			if (!base.gameObject.GetComponent<MeshCollider>())
			{
				base.gameObject.AddComponent<MeshCollider>();
			}
			if (base.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
				base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Vector2> list4 = new List<Vector2>();
			List<int> list5 = new List<int>();
			List<Vector3> list6 = new List<Vector3>();
			List<Vector2> list7 = new List<Vector2>();
			List<Vector2> list8 = new List<Vector2>();
			List<Vector2> list9 = new List<Vector2>();
			List<int> list10 = new List<int>();
			List<Color> list11 = new List<Color>();
			List<Color> list12 = new List<Color>();
			bool flag = false;
			int num = 0;
			mesh.Clear();
			return mesh;
		}

		private void OQQQDQDCCQ(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, ref List<int> trisTmp, ref List<Vector3> vecsTmp, ref List<Vector2> uvsTmp, ref List<Vector2> uvsTmp1, ref List<Vector2> uvsTmp2, ref List<Color> colorsTmp, bool skipMiddles, bool weldVecs)
		{
			int count = vecs.Count;
			bool[] array = new bool[trisTmp.Count];
			int num = -1;
			for (int i = 0; i < vecsTmp.Count; i++)
			{
				vecs.Add(vecsTmp[i]);
				uvs.Add(uvsTmp[i]);
				num = vecs.Count - 1;
				for (int j = 0; j < trisTmp.Count; j++)
				{
					if (trisTmp[j] == i && !array[j])
					{
						trisTmp[j] = num;
						array[j] = true;
					}
				}
			}
			tris.AddRange(trisTmp);
			trisTmp.Clear();
			vecsTmp.Clear();
			uvsTmp.Clear();
			uvsTmp1.Clear();
			uvsTmp2.Clear();
			colorsTmp.Clear();
		}

		private void OOQOOQOCOC(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, ref List<int> trisTmp, ref List<Vector3> vecsTmp, ref List<Vector2> uvsTmp, ref List<Vector2> uvsTmp1, ref List<Vector2> uvsTmp2, ref List<Color> colorsTmp, bool skipMiddles, bool weldVecs)
		{
			bool[] array = new bool[trisTmp.Count];
			int num = -1;
			for (int i = 0; i < vecsTmp.Count; i++)
			{
				num = -1;
				if ((!skipMiddles || vecsTmp[i].x != 0f) && weldVecs)
				{
					for (int j = 0; j < vecs.Count; j++)
					{
						if (vecsTmp[i] == vecs[j])
						{
							num = j;
							break;
						}
					}
				}
				if (num == -1 || !weldVecs)
				{
					vecs.Add(vecsTmp[i]);
					uvs.Add(uvsTmp[i]);
					num = vecs.Count - 1;
				}
				for (int k = 0; k < trisTmp.Count; k++)
				{
					if (trisTmp[k] == i && !array[k])
					{
						trisTmp[k] = num;
						array[k] = true;
					}
				}
			}
			tris.AddRange(trisTmp);
			trisTmp.Clear();
			vecsTmp.Clear();
			uvsTmp.Clear();
			uvsTmp1.Clear();
			uvsTmp2.Clear();
			colorsTmp.Clear();
		}

		private List<int> Triangulate(List<Vector3> vecs, List<Vector3> edges)
		{
			List<Vector2> list = new List<Vector2>();
			List<PointER> list2 = new List<PointER>();
			for (int i = 0; i < vecs.Count; i++)
			{
				Vector3 vector = vecs[i];
				list2.Add(new PointER(vector.x, vector.z, 0f));
			}
			for (int j = 0; j < edges.Count; j++)
			{
				Vector3 vector = vecs[j];
				list.Add(new Vector2(vector.x, vector.z));
			}
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<TriangleER> list5 = delaunayER.Triangulate(list2);
			for (int k = 0; k < list5.Count; k++)
			{
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex1.x, list5[k].Vertex1.z, list5[k].Vertex1.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex3.x, list5[k].Vertex3.z, list5[k].Vertex3.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex2.x, list5[k].Vertex2.z, list5[k].Vertex2.y), vecs));
			}
			for (int l = 0; l < list3.Count; l += 3)
			{
				if (list.Count == 0)
				{
					list4.Add(list3[l]);
					list4.Add(list3[l + 1]);
					list4.Add(list3[l + 2]);
					continue;
				}
				Vector3 vector2 = (vecs[list3[l]] + vecs[list3[l + 1]] + vecs[list3[l + 2]]) / 3f;
				if (OQOQOOCDCC.OCDCDOCQCQ(list.Count, list, vector2.x, vector2.z))
				{
					list4.Add(list3[l]);
					list4.Add(list3[l + 1]);
					list4.Add(list3[l + 2]);
				}
			}
			return list4;
		}

		public List<Vector3> OCCQQDQODQ(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float tension, float res, float distance, ref float tValue)
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0.01f;
			float num2 = 0f;
			Vector3 a = p2;
			bool flag = false;
			bool flag2 = false;
			for (float num3 = 0f; num3 < 1f; num3 += num)
			{
				Vector3 vector = ERModularRoad.OQQCQOQOOD(p1, p2, p3, p4, num3, tension);
				if (flag && num2 + Vector3.Distance(a, vector) > distance)
				{
					flag2 = true;
				}
				if (Vector3.Distance(a, vector) > res || num3 == 0f || flag2)
				{
					list.Add(vector);
					num2 += Vector3.Distance(a, vector);
					a = vector;
					tValue = num3;
					if (num2 + res > distance)
					{
						flag = true;
					}
					if (flag2)
					{
						break;
					}
				}
			}
			float num4 = num2 / (float)(list.Count - 1);
			for (int i = 1; i < list.Count - 1; i++)
			{
				Vector3 normalized = (list[i] - list[i - 1]).normalized;
				list[i] = list[i - 1] + normalized * num4;
			}
			return list;
		}

		public void OQQOQQDDQC(ref List<Vector3> splinePoints, float distance)
		{
			float num = 0f;
			float num2 = 0f;
			for (int num3 = splinePoints.Count - 1; num3 > 0; num3--)
			{
				num2 = Vector3.Distance(splinePoints[num3], splinePoints[num3 - 1]);
				if (num + num2 > distance)
				{
					if (num + num2 != distance)
					{
						Vector3 normalized = (splinePoints[num3 - 1] - splinePoints[num3]).normalized;
						splinePoints.Insert(num3, splinePoints[num3] + normalized * (distance - num));
					}
					break;
				}
				num += num2;
			}
		}

		public void Clear()
		{
			tvecs.Clear();
			splinePoints1.Clear();
			splinePoints2.Clear();
			surfaceVecs.Clear();
			roadShapeMaterialInts1.Clear();
			roadShapeMaterialInts2.Clear();
			leftRoundingPoints1.Clear();
			centerPoints1.Clear();
			rightRoundingPoints1.Clear();
			leftPointsIndents1.Clear();
			rightPointsIndents1.Clear();
			middlePoints1.Clear();
			leftRoundingPointsUV1.Clear();
			_3ssss.Clear();
			rightRoundingPointsUV1.Clear();
			leftPointsIndentsUV1.Clear();
			rightPointsIndentsUV1.Clear();
			leftRoundingPoints2.Clear();
			centerPoints2.Clear();
			rightRoundingPoints2.Clear();
			leftPointsIndents2.Clear();
			rightPointsIndents2.Clear();
			middlePoints2.Clear();
			leftRoundingPointsUV2.Clear();
			_4ssst.Clear();
			rightRoundingPointsUV2.Clear();
			leftPointsIndentsUV2.Clear();
			rightPointsIndentsUV2.Clear();
			leftPoints.Clear();
			rightPoints.Clear();
			priorityConnectionPoints.Clear();
			priorityConnectionPointsUV.Clear();
			rightPoints12.Clear();
			ll1.Clear();
			ll2.Clear();
			ll3.Clear();
			ll4.Clear();
			cp1Left = Vector3.zero;
			cp1Right = Vector3.zero;
			cp2Left = Vector3.zero;
			cp2Right = Vector3.zero;
			ttsss = 0f;
			utsst = 0f;
		}

		public void OQCCDCCCOD()
		{
			if (road1ERTexture != null)
			{
				vssss = road1ERTexture.roadWidth * road1ERTexture.leftOffset;
				wssst = road1ERTexture.leftOffset;
				xssss = road1ERTexture.roadWidth * road1ERTexture.leftInnerOffset;
				yssst = road1ERTexture.leftInnerOffset;
				Debug.Log(road1ERTexture.leftOffset + " " + vssss + " " + wssst + " " + xssss + " " + yssst);
			}
			else
			{
				vssss = 0.25f;
				wssst = 0.25f / cornerRadius1;
				xssss = 0.1f;
				yssst = 0.1f / cornerRadius1;
			}
		}

		public void OCODQDOQDO(ERTexture roadERTexture, ref float roadWidth, ref float leftIndent, ref float rightIndent, ref float leftUVX, ref float rightUVX, ref float leftIndentInner, ref float rightIndentInner, ref float roadOuterUVXInner, float cornerRadius)
		{
			if (roadERTexture != null)
			{
				roadWidth = roadERTexture.roadWidth;
				leftIndent = roadERTexture.roadWidth * roadERTexture.leftOffset;
				leftUVX = roadERTexture.leftOffset;
				leftIndentInner = roadERTexture.roadWidth * roadERTexture.leftInnerOffset;
				roadOuterUVXInner = roadERTexture.leftInnerOffset;
				rightIndent = roadERTexture.roadWidth * roadERTexture.rightOffset;
				rightIndentInner = roadERTexture.roadWidth * roadERTexture.rightInnerOffset;
				rightUVX = 1f - roadERTexture.rightOffset;
			}
			else
			{
				leftIndent = 0.25f;
				leftUVX = 0.25f / cornerRadius;
				leftIndentInner = 0.1f;
				roadOuterUVXInner = 0.1f / cornerRadius;
				rightIndent = 0.25f;
				rightIndentInner = 0.1f;
				rightUVX = 0.25f / cornerRadius;
			}
		}

		public static void OOOQQQQCDC(List<Vector3> leftPoints, List<Vector3> rightPoints, ref GameObject surfaceMesh, Transform tr, ref List<Vector3> surfaceVecs, float indentLeftStart, float indentLeftEnd, float surroundingLeftStart, float surroundingLeftEnd, float indentRightStart, float indentRightEnd, float surroundingRightStart, float surroundingRightEnd, ERModularBase baseScript, bool hasMesh)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
			if (leftPoints.Count > 2)
			{
				float num = 0f;
				float num2 = 0f;
				for (int i = 0; i < leftPoints.Count - 1; i++)
				{
					num += Vector3.Distance(leftPoints[i], leftPoints[i + 1]);
				}
				int num3 = 4;
				for (int j = 0; j < leftPoints.Count; j++)
				{
					if (j > 0)
					{
						num2 += Vector3.Distance(leftPoints[j], leftPoints[j - 1]);
					}
					float t = num2 / num;
					t = Mathf.SmoothStep(0f, 1f, t);
					float num4 = Mathf.Lerp(indentLeftStart, indentLeftEnd, t);
					float num5 = Mathf.Lerp(surroundingLeftStart, surroundingLeftEnd, t);
					Vector3 normalized = (leftPoints[j] - rightPoints[j]).normalized;
					Vector3 pos = tr.TransformPoint(leftPoints[j] + normalized * (num4 + num5));
					baseScript.OQCCDQOQOO(ref pos);
					list.Add(tr.InverseTransformPoint(pos));
					list2.Add(new Vector2(0f, 0f));
					pos = leftPoints[j] + normalized * num4;
					list.Add(pos);
					pos.y -= 0.02f;
					list2.Add(new Vector2(0f, 1f));
					num4 = Mathf.Lerp(indentRightStart, indentRightEnd, t);
					num5 = Mathf.Lerp(surroundingRightStart, surroundingRightEnd, t);
					pos = rightPoints[j] + -normalized * num4;
					pos.y -= 0.02f;
					list.Add(pos);
					list2.Add(new Vector2(0f, 1f));
					pos = tr.TransformPoint(rightPoints[j] + -normalized * (num4 + num5));
					baseScript.OQCCDQOQOO(ref pos);
					list.Add(tr.InverseTransformPoint(pos));
					list2.Add(new Vector2(0f, 0f));
					if (j < leftPoints.Count - 1)
					{
						for (int k = 0; k < num3 - 1; k++)
						{
							list3.Add(j * num3 + k);
							list3.Add((j + 1) * num3 + k + 1);
							list3.Add(j * num3 + k + 1);
							list3.Add((j + 1) * num3 + k);
							list3.Add((j + 1) * num3 + k + 1);
							list3.Add(j * num3 + k);
						}
					}
				}
			}
			else
			{
				float num4 = indentLeftStart;
				float num5 = surroundingLeftStart;
				Vector3 normalized = (leftPoints[0] - rightPoints[0]).normalized;
				Vector3 pos = tr.TransformPoint(leftPoints[0] + normalized * (num4 + num5));
				baseScript.OQCCDQOQOO(ref pos);
				list.Add(tr.InverseTransformPoint(pos));
				list2.Add(new Vector2(0f, 0f));
				pos = leftPoints[0] + normalized * num4;
				list.Add(pos);
				pos.y -= 0.02f;
				list2.Add(new Vector2(0f, 0f));
				num4 = indentRightStart;
				num5 = surroundingRightStart;
				pos = rightPoints[0] + -normalized * num4;
				pos.y -= 0.02f;
				list.Add(pos);
				list2.Add(new Vector2(0f, 0f));
				pos = tr.TransformPoint(rightPoints[0] + -normalized * (num4 + num5));
				baseScript.OQCCDQOQOO(ref pos);
				list.Add(tr.InverseTransformPoint(pos));
				list2.Add(new Vector2(0f, 0f));
				num4 = indentLeftEnd;
				num5 = surroundingLeftEnd;
				normalized = (leftPoints[0] - rightPoints[0]).normalized;
				pos = tr.TransformPoint(leftPoints[0] + normalized * (num4 + num5));
				baseScript.OQCCDQOQOO(ref pos);
				list.Add(tr.InverseTransformPoint(pos));
				list2.Add(new Vector2(0f, 0f));
				pos = leftPoints[0] + normalized * num4;
				list.Add(pos);
				pos.y -= 0.02f;
				list2.Add(new Vector2(0f, 0f));
				num4 = indentRightEnd;
				num5 = surroundingRightEnd;
				pos = rightPoints[0] + -normalized * num4;
				pos.y -= 0.02f;
				list.Add(pos);
				list2.Add(new Vector2(0f, 0f));
				pos = tr.TransformPoint(rightPoints[0] + -normalized * (num4 + num5));
				baseScript.OQCCDQOQOO(ref pos);
				list.Add(tr.InverseTransformPoint(pos));
				list2.Add(new Vector2(0f, 0f));
			}
			surfaceVecs = list;
			if (!hasMesh)
			{
				if (surfaceMesh != null)
				{
					UnityEngine.Object.DestroyImmediate(surfaceMesh);
				}
				else if ((bool)tr.Find("surface"))
				{
					surfaceMesh = tr.Find("surface").gameObject;
					if (surfaceMesh != null)
					{
						UnityEngine.Object.DestroyImmediate(surfaceMesh);
					}
				}
				return;
			}
			Mesh mesh = null;
			if (surfaceMesh == null)
			{
				surfaceMesh = new GameObject("surface");
				surfaceMesh.hideFlags = HideFlags.HideInHierarchy;
				surfaceMesh.AddComponent<MeshFilter>();
				surfaceMesh.AddComponent<MeshRenderer>();
				surfaceMesh.AddComponent<MeshCollider>();
				surfaceMesh.AddComponent<ERSurfaceScript>();
				ERModularBase eRModularBase = UnityEngine.Object.FindObjectOfType<ERModularBase>();
				if (eRModularBase != null)
				{
					surfaceMesh.GetComponent<MeshRenderer>().material = eRModularBase.surfaceMaterial;
				}
				surfaceMesh.transform.parent = tr;
				surfaceMesh.GetComponent<MeshRenderer>().enabled = !baseScript.hideSurfaces;
				surfaceMesh.GetComponent<MeshCollider>().enabled = !baseScript.hideSurfaces;
				surfaceMesh.layer = baseScript.sLayer;
			}
			if (!surfaceMesh.GetComponent<MeshRenderer>())
			{
				surfaceMesh.AddComponent<MeshRenderer>();
			}
			if (!surfaceMesh.GetComponent<MeshFilter>())
			{
				surfaceMesh.AddComponent<MeshFilter>();
			}
			if (!surfaceMesh.GetComponent<MeshCollider>())
			{
				surfaceMesh.AddComponent<MeshCollider>();
			}
			if (surfaceMesh.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = surfaceMesh.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				surfaceMesh.GetComponent<MeshFilter>().sharedMesh = mesh;
				surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			surfaceMesh.transform.position = tr.position;
			mesh.Clear();
			mesh.vertices = list.ToArray();
			mesh.uv = list2.ToArray();
			mesh.triangles = list3.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = null;
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			if (baseScript.hideSurfaces)
			{
				surfaceMesh.GetComponent<MeshCollider>().enabled = false;
				surfaceMesh.SetActive(value: false);
				surfaceMesh.SetActive(value: true);
			}
		}
	}
}
