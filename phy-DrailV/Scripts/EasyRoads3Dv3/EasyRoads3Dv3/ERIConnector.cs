using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
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

		public ERTexture road1ERTexture;

		private float ᙃ = 0.1f;

		private float ᙄ = 0f;

		private float ᙅ = 0.05f;

		private float _4AAAA = 0f;

		public float road1Stretch = 1f;

		public int road1StretchType = 0;

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

		public ERTexture road2ERTexture;

		private float _5AAA1 = 0.1f;

		private float _6AAAA = 0f;

		private float _7AAA1 = 0.05f;

		private float _8AAAA = 0f;

		public float road2Stretch = 1f;

		public int road2StretchType = 0;

		public int subdivide2 = 0;

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

		private List<Vector2> _9AAA1 = new List<Vector2>();

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

		private List<Vector2> BAAAA = new List<Vector2>();

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

		private float CAAA1 = 0f;

		private float _00AAA = 0f;

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

		public void UpdateERTexture(int road)
		{
			switch (road)
			{
			case 1:
				OQQDOCDQOQ(road1ERTexture, ref roadWidth1, ref leftIndent1, ref rightIndent1, ref leftUVX1, ref rightUVX1, ref leftIndentInner1, ref rightIndentInner1, ref _4AAAA, cornerRadius1);
				break;
			case 2:
				OQQDOCDQOQ(road2ERTexture, ref roadWidth2, ref leftIndent2, ref rightIndent2, ref leftUVX2, ref rightUVX2, ref leftIndentInner2, ref rightIndentInner2, ref _8AAAA, cornerRadius2);
				break;
			}
		}

		public void OCCCCCCDCC(ERModularRoad sourceRoad)
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
			if (prefabScript == null)
			{
				prefabScript = base.gameObject.GetComponent<ERCrossingPrefabs>();
				prefabScript.iConnectorScript = this;
			}
			road1 = null;
			road2 = null;
			if (prefabScript.crossingElements[0].connectedRoad != null)
			{
				ERModularRoad eRModularRoad = (road1 = prefabScript.crossingElements[0].connectedRoad);
				roadShape1 = new List<Vector2>(eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker].roadShape);
				roadShapeUVs1 = new List<float>(eRModularRoad.roadShapeUVs);
				uvRatio = 5f * road1.uvTiling;
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
					for (int i = 0; i < roadShape1.Count; i++)
					{
						Vector2 value = roadShape1[i];
						value.x *= -1f;
						roadShape1[i] = value;
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
					ERMarkerExt eRMarkerExt = eRModularRoad.markersExt[prefabScript.crossingElements[0].connectedMarker];
					indentLeftStart = (indentLeftEnd = eRMarkerExt.leftIndent);
					indentRightStart = (indentRightEnd = eRMarkerExt.rightIndent);
					surroundingLeftStart = (surroundingLeftEnd = eRMarkerExt.leftSurrounding);
					surroundingRightStart = (surroundingRightEnd = eRMarkerExt.rightSurrounding);
					startEnd = 1;
				}
				bool flag3 = false;
				if (roadType1 == 0)
				{
					flag3 = true;
				}
				else if (road1.roadType != baseScript.roadTypes[roadType1 - 1].id)
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
				float num = 1000f;
				float num2 = -1000f;
				for (int i = 0; i < roadShape1.Count; i++)
				{
					if (num > roadShape1[i].x)
					{
						num = roadShape1[i].x;
					}
					if (num2 < roadShape1[i].x)
					{
						num2 = roadShape1[i].x;
					}
				}
				roadWidth1 = num2 - num;
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
				ERModularRoad eRModularRoad = (road2 = prefabScript.crossingElements[1].connectedRoad);
				roadShape2 = new List<Vector2>(eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker].roadShape);
				roadShapeUVs2 = new List<float>(eRModularRoad.roadShapeUVs);
				uvRatio2 = 5f * road2.uvTiling;
				if (prefabScript.crossingElements[1].connectedMarker == 0)
				{
					cp1 = (cp2 = eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker + 1].position);
					ERMarkerExt eRMarkerExt = eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker + 1];
					if (eRModularRoad.markersExt.Count > prefabScript.crossingElements[1].connectedMarker + 2)
					{
						cp2 = eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker + 2].position;
						eRMarkerExt = eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker + 2];
					}
					roadShape2.Reverse();
					roadShapeUVs2.Reverse();
				}
				else
				{
					cp1 = (cp2 = eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker - 1].position);
					ERMarkerExt eRMarkerExt = eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker - 1];
					if (prefabScript.crossingElements[1].connectedMarker - 2 >= 0)
					{
						cp2 = eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker - 2].position;
						eRMarkerExt = eRModularRoad.markersExt[prefabScript.crossingElements[1].connectedMarker - 2];
					}
					flag2 = true;
					startEnd2 = 1;
				}
				bool flag3 = false;
				if (roadType2 == 0)
				{
					flag3 = true;
				}
				else if (road2.roadType != baseScript.roadTypes[roadType2 - 1].id)
				{
					flag3 = true;
				}
				if (flag3)
				{
					roadType2 = 0;
					for (int i = 0; i < baseScript.roadTypes.Count; i++)
					{
						if (baseScript.roadTypes[i].id == road2.roadType)
						{
							roadType2 = i + 1;
							roadType2ID = road2.roadType;
							break;
						}
					}
				}
				float num = 1000f;
				float num2 = -1000f;
				for (int i = 0; i < roadShape2.Count; i++)
				{
					if (num > roadShape2[i].x)
					{
						num = roadShape2[i].x;
					}
					if (num2 < roadShape2[i].x)
					{
						num2 = roadShape2[i].x;
					}
				}
				roadWidth2 = num2 - num;
				road2Material = eRModularRoad.roadMaterial;
				roadMaterials2 = new List<Material>(eRModularRoad.roadMaterials);
				if (roadMaterials2.Count == 0)
				{
					roadMaterials2.Add(eRModularRoad.roadMaterial);
				}
				road2Material = roadMaterials2[0];
				roadShapeMaterialInts2 = new List<int>(eRModularRoad.roadShapeMaterialInts);
				if (road2MaterialActive == null)
				{
					road2MaterialActive = road2Material;
				}
				road2MaterialActive = road2Material;
			}
			else
			{
				connectorLength2 = 0f;
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
				splinePoints1 = OQQOQCQQQD(cp1, base.transform.position, cp3, cp4, 0.5f, resolution, connectorLength1, ref t1);
			}
			else
			{
				Vector3 vector = (tv = ERModularRoad.OQODDDCOQD(cp1, base.transform.position, cp3, cp4, 0.05f, 0.5f));
				centerDir = (base.transform.position - vector).normalized;
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
					splinePoints2 = OQQOQCQQQD(cp3, base.transform.position, cp1, cp2, 0.5f, resolution, connectorLength2, ref t2);
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
					Vector3 vector = ERModularRoad.OQODDDCOQD(cp3, base.transform.position, cp1, cp2, 0.01f, 0.5f);
					centerDir = (base.transform.position - vector).normalized;
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
						OOQCODQCDD(ref splinePoints1, 0.5f * blendDistance);
						OOQCODQCDD(ref splinePoints2, 0.5f * blendDistance);
					}
					else if (blendSection == 1)
					{
						OOQCODQCDD(ref splinePoints1, blendDistance);
					}
					else if (blendSection == 2)
					{
						OOQCODQCDD(ref splinePoints2, blendDistance);
					}
				}
				else
				{
					OOQCODQCDD(ref splinePoints1, blendDistance);
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
			int num3 = 1;
			int index = 0;
			int index2 = 1;
			list3.Add(roadShape1[0]);
			list6.Add(roadShapeUVs1[0]);
			list5.Add(roadShapeMaterialInts1[0]);
			list9.Add(item: true);
			if (roadShape1.Count > 2)
			{
				num3 = 2;
				index = 1;
				index2 = 2;
				list3.Add(roadShape1[1]);
				list6.Add(roadShapeUVs1[1]);
				list5.Add(roadShapeMaterialInts1[1]);
				list9.Add(item: true);
			}
			for (int i = num3; i < num3 + subdivide1; i++)
			{
				list3.Add(Vector2.Lerp(roadShape1[index], roadShape1[index2], (float)(i - num3 + 1) / ((float)subdivide1 + 1f)));
				list6.Add(Mathf.Lerp(roadShapeUVs1[index], roadShapeUVs1[index2], (float)(i - num3 + 1) / ((float)subdivide1 + 1f)));
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
				for (int i = 0; i < roadShape1.Count; i++)
				{
					list3.Add(roadShape1[i]);
					list6.Add(roadShapeUVs1[i]);
					if (roadShapeMaterialInts1.Count > i)
					{
						list5.Add(roadShapeMaterialInts1[i]);
					}
					list9.Add(item: true);
				}
			}
			if (splinePoints2.Count > 0)
			{
				num3 = 1;
				index = 0;
				index2 = 1;
				list4.Add(roadShape2[0]);
				list7.Add(roadShapeUVs2[0]);
				list8.Add(roadShapeMaterialInts2[0]);
				list10.Add(item: true);
				if (roadShape2.Count > 2)
				{
					num3 = 2;
					index = 1;
					index2 = 2;
					list4.Add(roadShape2[1]);
					list7.Add(roadShapeUVs2[1]);
					list8.Add(roadShapeMaterialInts2[1]);
					list10.Add(item: true);
				}
				if (subdivide2 > 0)
				{
					for (int i = num3; i < num3 + subdivide2; i++)
					{
						list4.Add(Vector2.Lerp(roadShape2[index], roadShape2[index2], (float)(i - num3 + 1) / ((float)subdivide2 + 1f)));
						list7.Add(Mathf.Lerp(roadShapeUVs2[index], roadShapeUVs2[index2], (float)(i - num3 + 1) / ((float)subdivide2 + 1f)));
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
					for (int i = 0; i < roadShape2.Count; i++)
					{
						list4.Add(roadShape2[i]);
						list7.Add(roadShapeUVs2[i]);
						list8.Add(roadShapeMaterialInts2[i]);
						list10.Add(item: true);
					}
				}
			}
			List<List<int>> tris = new List<List<int>>();
			for (int i = 0; i < roadMaterials1.Count; i++)
			{
				tris.Add(new List<int>());
			}
			List<List<int>> tris2 = new List<List<int>>();
			for (int i = 0; i < roadMaterials2.Count; i++)
			{
				tris2.Add(new List<int>());
			}
			int num4 = 0;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			List<Vector3> list11 = new List<Vector3>();
			List<Vector3> list12 = new List<Vector3>();
			OCODQDOQCC(splinePoints1, splinePoints2, ref vecs, ref uvs, ref tris, list3, list6, list5, uvRatio, road1Stretch, road1StretchType, ref list11, ref list12, flag, centerDir, 0, startEnd);
			leftPoints.AddRange(list12);
			rightPoints.AddRange(list11);
			list11.Clear();
			list12.Clear();
			if (splinePoints2.Count > 0)
			{
				OCODQDOQCC(splinePoints2, splinePoints1, ref vecs2, ref uvs2, ref tris2, list4, list7, list8, uvRatio2, road2Stretch, road2StretchType, ref list11, ref list12, !flag2, -centerDir, 1, startEnd2);
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
				uvs2 = ODCCOQCCQO(uvs[uvs.Count - 1].y, splinePoints2, list7, uvRatio, flag, list6[0]);
				if (splinePoints2.Count > 0)
				{
					list = ODCCOQCCQO(uvs2[uvs2.Count - 1].y, splinePoints1, list6, uvRatio2, flag2, list7[0]);
				}
				OODDCCDCQQ(ref colors, splinePoints1, splinePoints2, list3, list4);
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
			for (int i = 0; i < tris2.Count; i++)
			{
				if (tris2[i].Count <= 0)
				{
					continue;
				}
				int num8 = -1;
				for (int j = 0; j < tris.Count; j++)
				{
					if (roadMaterials2[i] == roadMaterials1[j] || roadMaterials2[i] == null)
					{
						num8 = j;
						break;
					}
					if (num8 == -1)
					{
						tris.Add(new List<int>());
						num8 = tris.Count - 1;
						roadMaterials1.Add(roadMaterials2[i]);
					}
				}
				for (int j = 0; j < tris2[i].Count; j++)
				{
					tris[num8].Add(tris2[i][j] + count);
				}
			}
			if (textureType == 1 && blendMaterial != null)
			{
				for (int i = 0; i < roadMaterials1.Count; i++)
				{
					if (blendSection == 0)
					{
						if (roadMaterials1[i] == road1Material || roadMaterials1[i] == road2Material)
						{
							roadMaterials1[i] = blendMaterial;
						}
					}
					else if (blendSection == 1 && roadMaterials1[i] == road1Material)
					{
						roadMaterials1[i] = blendMaterial;
					}
					else if (blendSection == 2 && roadMaterials1[i] == road2Material)
					{
						roadMaterials1[i] = blendMaterial;
					}
				}
			}
			else if (textureType == 2 && transitionMaterial != null)
			{
				for (int i = 0; i < roadMaterials1.Count; i++)
				{
					roadMaterials1[i] = transitionMaterial;
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
				Mesh mesh = OODOQQQCDD();
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
				for (int i = 0; i < tris.Count; i++)
				{
					mesh.SetTriangles(tris[i].ToArray(), i);
				}
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				OCQQDQQCQQ.OOCCQOQQQC(mesh);
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			OOQDODCCQQ(leftPoints, rightPoints, ref surfaceMesh, base.transform, ref surfaceVecs, indentLeftStart, indentLeftEnd, surroundingLeftStart, surroundingLeftEnd, indentRightStart, indentRightEnd, surroundingRightStart, surroundingRightEnd, baseScript, hasMesh);
			if (connectorLength2 == 0f)
			{
				flag2 = false;
			}
			GetIConnectionData(vecs, list9, list10, flag, flag2, road2Start);
			if (sourceRoad != null)
			{
				if (sourceRoad == road1 && road2 != null)
				{
					road2.OCCCCCCDCC(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
				else if (sourceRoad == road2 && road1 != null)
				{
					road1.OCCCCCCDCC(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
			}
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
			for (int i = 0; i < conInts1.Count; i++)
			{
				if (conInts1[i])
				{
					list.Add(i);
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
				for (int i = 0; i < conInts2.Count; i++)
				{
					if (conInts2[i])
					{
						list.Add(road2Start + i);
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

		public void OCODQDOQCC(List<Vector3> splinePoints, List<Vector3> splinePointsOther, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<List<int>> tris, List<Vector2> roadShape, List<float> roadShapeUVs, List<int> roadShapeMaterialInts, float uvRatio, float stretchRatio, float stretchType, ref List<Vector3> leftPoints, ref List<Vector3> rightPoints, bool reversed, Vector3 cDir, int firstSecond, int startEnd)
		{
			float num = 100f;
			float num2 = -100f;
			for (int i = 0; i < roadShape.Count; i++)
			{
				if (roadShape[i].x < num)
				{
					num = roadShape[i].x;
				}
				if (roadShape[i].x > num2)
				{
					num2 = roadShape[i].x;
				}
			}
			int count = roadShape.Count;
			int num3 = 0;
			int num4 = 0;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			for (int j = 1; j < splinePoints.Count; j++)
			{
				num8 += Vector3.Distance(splinePoints[j - 1], splinePoints[j]);
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
					float num9 = connectorLength1 + connectorLength2;
					float num10 = connectorLength1 / num9;
					float num11 = connectorLength2 / num9;
					if (firstSecond == 0)
					{
						b = num10;
						if (transitionSwap)
						{
							a = 1f;
							b = 1f - num10;
						}
					}
					else
					{
						a = 1f;
						b = 1f - num11;
						if (transitionSwap)
						{
							a = 0f;
							b = num11;
						}
					}
				}
			}
			Vector3 vector;
			if (splinePoints.Count > 1)
			{
				for (int j = 0; j < splinePoints.Count; j++)
				{
					if (j > 0)
					{
						num7 = Vector3.Distance(splinePoints[j - 1], splinePoints[j]);
						num5 += num7;
					}
					num6 = num5 / uvRatio;
					vector = ((j == 0) ? (splinePoints[j + 1] - splinePoints[j]).normalized : ((j != splinePoints.Count - 1) ? (splinePoints[j + 1] - splinePoints[j - 1]).normalized : ((splinePointsOther.Count != 0) ? cDir : (splinePoints[j] - splinePoints[j - 1]).normalized)));
					Vector3 vector2 = splinePoints[j];
					if (j == splinePoints.Count - 1 && textureType == 2)
					{
						vector2 += vector * 0.0025f;
					}
					vector = new Vector3(0f - vector.z, 0f, vector.x).normalized;
					if (firstSecond != 1 || startEnd == 0)
					{
					}
					for (int i = 0; i < roadShape.Count; i++)
					{
						float num12 = num5 / num8;
						if (stretchType == 1f)
						{
							num12 *= num12;
						}
						else if (stretchType == 2f)
						{
							num12 = Mathf.SmoothStep(0f, 1f, num12);
						}
						float num13 = Mathf.Lerp(roadShape[i].x, roadShape[i].x * stretchRatio, num12);
						Vector3 position = vector2 + vector * num13;
						position.y += roadShape[i].y;
						vecs.Add(base.transform.InverseTransformPoint(position));
						if (textureType != 2)
						{
							uvs.Add(new Vector2(list[i], num6));
						}
						else
						{
							uvs.Add(new Vector2(list[i], Mathf.Lerp(a, b, num5 / num8)));
						}
						if (i == 0)
						{
							num13 = Mathf.Lerp(num, num * stretchRatio, num12);
							leftPoints.Add(base.transform.InverseTransformPoint(splinePoints[j] + vector * num13));
							num13 = Mathf.Lerp(num2, num2 * stretchRatio, num12);
							rightPoints.Add(base.transform.InverseTransformPoint(splinePoints[j] + vector * num13));
						}
						bool flag = true;
						num4 = roadShapeMaterialInts[i];
						if (i < roadShapeMaterialInts.Count - 2 && num4 != roadShapeMaterialInts[i + 1])
						{
							flag = false;
						}
						if (i == roadShape.Count - 1 || j == splinePoints.Count - 1)
						{
							flag = false;
						}
						if (flag)
						{
							if (!reversed)
							{
								tris[num4].Add(j * count + i + num3);
								tris[num4].Add((j + 1) * count + i + 1 + num3);
								tris[num4].Add(j * count + i + 1 + num3);
								tris[num4].Add((j + 1) * count + i + num3);
								tris[num4].Add((j + 1) * count + i + 1 + num3);
								tris[num4].Add(j * count + i + num3);
							}
							else
							{
								tris[num4].Add(j * count + i + num3);
								tris[num4].Add(j * count + i + 1 + num3);
								tris[num4].Add((j + 1) * count + i + 1 + num3);
								tris[num4].Add((j + 1) * count + i + num3);
								tris[num4].Add(j * count + i + num3);
								tris[num4].Add((j + 1) * count + i + 1 + num3);
							}
						}
					}
				}
				return;
			}
			vector = new Vector3(0f - centerDir.z, 0f, centerDir.x).normalized;
			if (firstSecond == 1 && startEnd == 1)
			{
				vector *= -1f;
			}
			for (int i = 0; i < roadShape.Count; i++)
			{
				Vector3 position = splinePoints[0] + vector * roadShape[i].x;
				position.y += roadShape[i].y;
				vecs.Add(base.transform.InverseTransformPoint(position));
				uvs.Add(Vector2.zero);
				if (i == 0)
				{
					leftPoints.Add(base.transform.InverseTransformPoint(splinePoints[0] + vector * num));
					rightPoints.Add(base.transform.InverseTransformPoint(splinePoints[0] + vector * num2));
				}
			}
		}

		public List<Vector2> ODCCOQCCQO(float startY, List<Vector3> splinePoints, List<float> roadShapeUVs, float uvRatio, bool reversed, float sourceUV)
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

		public void OODDCCDCQQ(ref List<Color> colors, List<Vector3> splinePoints1, List<Vector3> splinePoints2, List<Vector2> roadShape1, List<Vector2> roadShape2)
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
			for (int i = 0; i < splinePoints2.Count; i++)
			{
				float num2 = Vector3.Distance(splinePoints2[i], position);
				if (num2 > num)
				{
					white.a = 1f;
				}
				else
				{
					white.a = Mathf.Lerp(a, 1f, num2 / num);
				}
				for (int j = 0; j < roadShape2.Count; j++)
				{
					colors.Add(white);
				}
			}
		}

		public void MergeOuterArray(ref List<Vector3> targetArray, List<Vector3> otherArray)
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
			for (int i = 1; i < leftRoundingPoints.Count; i++)
			{
				num2 += Vector3.Distance(leftRoundingPoints[i - 1], leftRoundingPoints[i]);
				leftRoundingPointsUV.Add(new Vector2(0f, num2 * num));
				leftPointsIndentsUV.Add(new Vector2(leftIndentUVX, num2 * num));
			}
			num2 = 0f;
			rightRoundingPointsUV.Add(new Vector2(1f, 0f));
			rightPointsIndentsUV.Add(new Vector2(rightIndentUVX, 0f));
			for (int i = 1; i < rightRoundingPoints.Count; i++)
			{
				num2 += Vector3.Distance(rightRoundingPoints[i - 1], rightRoundingPoints[i]);
				rightRoundingPointsUV.Add(new Vector2(1f, num2 * num));
				rightPointsIndentsUV.Add(new Vector2(rightIndentUVX, num2 * num));
			}
		}

		public Mesh OODOQQQCDD()
		{
			Mesh mesh = null;
			if (!base.gameObject.GetComponent<MeshRenderer>())
			{
				base.gameObject.AddComponent<MeshRenderer>();
				base.gameObject.GetComponent<MeshRenderer>().castShadows = false;
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

		private void ODOOQODCOD(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, ref List<int> trisTmp, ref List<Vector3> vecsTmp, ref List<Vector2> uvsTmp, ref List<Vector2> uvsTmp1, ref List<Vector2> uvsTmp2, ref List<Color> colorsTmp, bool skipMiddles, bool weldVecs)
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

		private void ODCDOOQDDO(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, ref List<int> trisTmp, ref List<Vector3> vecsTmp, ref List<Vector2> uvsTmp, ref List<Vector2> uvsTmp1, ref List<Vector2> uvsTmp2, ref List<Color> colorsTmp, bool skipMiddles, bool weldVecs)
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

		private List<int> Triangulate(List<Vector3> vecs, List<Vector3> edges)
		{
			List<Vector2> list = new List<Vector2>();
			List<PointER> list2 = new List<PointER>();
			for (int i = 0; i < vecs.Count; i++)
			{
				Vector3 vector = vecs[i];
				list2.Add(new PointER(vector.x, vector.z, 0f));
			}
			for (int i = 0; i < edges.Count; i++)
			{
				Vector3 vector = vecs[i];
				list.Add(new Vector2(vector.x, vector.z));
			}
			List<TriangleER> list3 = delaunayER.Triangulate(list2);
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			for (int i = 0; i < list3.Count; i++)
			{
				list4.Add(delaunayER.FindVertice(new Vector3(list3[i].Vertex1.x, list3[i].Vertex1.z, list3[i].Vertex1.y), vecs));
				list4.Add(delaunayER.FindVertice(new Vector3(list3[i].Vertex3.x, list3[i].Vertex3.z, list3[i].Vertex3.y), vecs));
				list4.Add(delaunayER.FindVertice(new Vector3(list3[i].Vertex2.x, list3[i].Vertex2.z, list3[i].Vertex2.y), vecs));
			}
			for (int i = 0; i < list4.Count; i += 3)
			{
				if (list.Count == 0)
				{
					list5.Add(list4[i]);
					list5.Add(list4[i + 1]);
					list5.Add(list4[i + 2]);
					continue;
				}
				Vector3 vector2 = (vecs[list4[i]] + vecs[list4[i + 1]] + vecs[list4[i + 2]]) / 3f;
				if (OOCDOQCOCD.OCCOQDODDD(list.Count, list, vector2.x, vector2.z))
				{
					list5.Add(list4[i]);
					list5.Add(list4[i + 1]);
					list5.Add(list4[i + 2]);
				}
			}
			return list5;
		}

		public List<Vector3> OQQOQCQQQD(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float tension, float res, float distance, ref float tValue)
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0.01f;
			float num2 = 0f;
			Vector3 a = p2;
			bool flag = false;
			bool flag2 = false;
			for (float num3 = 0f; num3 < 1f; num3 += num)
			{
				Vector3 vector = ERModularRoad.OQODDDCOQD(p1, p2, p3, p4, num3, tension);
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

		public void OOQCODQCDD(ref List<Vector3> splinePoints, float distance)
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
			_9AAA1.Clear();
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
			BAAAA.Clear();
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
			CAAA1 = 0f;
			_00AAA = 0f;
		}

		public void OCQODODQOO()
		{
			if (road1ERTexture != null)
			{
				ᙃ = road1ERTexture.roadWidth * road1ERTexture.leftOffset;
				ᙄ = road1ERTexture.leftOffset;
				ᙅ = road1ERTexture.roadWidth * road1ERTexture.leftInnerOffset;
				_4AAAA = road1ERTexture.leftInnerOffset;
				Debug.Log(road1ERTexture.leftOffset + " " + ᙃ + " " + ᙄ + " " + ᙅ + " " + _4AAAA);
			}
			else
			{
				ᙃ = 0.25f;
				ᙄ = 0.25f / cornerRadius1;
				ᙅ = 0.1f;
				_4AAAA = 0.1f / cornerRadius1;
			}
		}

		public void OQQDOCDQOQ(ERTexture roadERTexture, ref float roadWidth, ref float leftIndent, ref float rightIndent, ref float leftUVX, ref float rightUVX, ref float leftIndentInner, ref float rightIndentInner, ref float roadOuterUVXInner, float cornerRadius)
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

		public static void OOQDODCCQQ(List<Vector3> leftPoints, List<Vector3> rightPoints, ref GameObject surfaceMesh, Transform tr, ref List<Vector3> surfaceVecs, float indentLeftStart, float indentLeftEnd, float surroundingLeftStart, float surroundingLeftEnd, float indentRightStart, float indentRightEnd, float surroundingRightStart, float surroundingRightEnd, ERModularBase baseScript, bool hasMesh)
		{
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			if (leftPoints.Count > 2)
			{
				float num = 0f;
				float num2 = 0f;
				for (int i = 0; i < leftPoints.Count - 1; i++)
				{
					num += Vector3.Distance(leftPoints[i], leftPoints[i + 1]);
				}
				int num3 = 4;
				for (int i = 0; i < leftPoints.Count; i++)
				{
					if (i > 0)
					{
						num2 += Vector3.Distance(leftPoints[i], leftPoints[i - 1]);
					}
					float t = num2 / num;
					t = Mathf.SmoothStep(0f, 1f, t);
					float num4 = Mathf.Lerp(indentLeftStart, indentLeftEnd, t);
					float num5 = Mathf.Lerp(surroundingLeftStart, surroundingLeftEnd, t);
					Vector3 normalized = (leftPoints[i] - rightPoints[i]).normalized;
					Vector3 pos = tr.TransformPoint(leftPoints[i] + normalized * (num4 + num5));
					baseScript.OCCDCQCOQC(ref pos);
					list.Add(tr.InverseTransformPoint(pos));
					pos = leftPoints[i] + normalized * num4;
					list.Add(pos);
					pos.y -= 0.02f;
					num4 = Mathf.Lerp(indentRightStart, indentRightEnd, t);
					num5 = Mathf.Lerp(surroundingRightStart, surroundingRightEnd, t);
					pos = rightPoints[i] + -normalized * num4;
					pos.y -= 0.02f;
					list.Add(pos);
					pos = tr.TransformPoint(rightPoints[i] + -normalized * (num4 + num5));
					baseScript.OCCDCQCOQC(ref pos);
					list.Add(tr.InverseTransformPoint(pos));
					if (i < leftPoints.Count - 1)
					{
						for (int j = 0; j < num3 - 1; j++)
						{
							list2.Add(i * num3 + j);
							list2.Add((i + 1) * num3 + j + 1);
							list2.Add(i * num3 + j + 1);
							list2.Add((i + 1) * num3 + j);
							list2.Add((i + 1) * num3 + j + 1);
							list2.Add(i * num3 + j);
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
				baseScript.OCCDCQCOQC(ref pos);
				list.Add(tr.InverseTransformPoint(pos));
				pos = leftPoints[0] + normalized * num4;
				list.Add(pos);
				pos.y -= 0.02f;
				num4 = indentRightStart;
				num5 = surroundingRightStart;
				pos = rightPoints[0] + -normalized * num4;
				pos.y -= 0.02f;
				list.Add(pos);
				pos = tr.TransformPoint(rightPoints[0] + -normalized * (num4 + num5));
				baseScript.OCCDCQCOQC(ref pos);
				list.Add(tr.InverseTransformPoint(pos));
				num4 = indentLeftEnd;
				num5 = surroundingLeftEnd;
				normalized = (leftPoints[0] - rightPoints[0]).normalized;
				pos = tr.TransformPoint(leftPoints[0] + normalized * (num4 + num5));
				baseScript.OCCDCQCOQC(ref pos);
				list.Add(tr.InverseTransformPoint(pos));
				pos = leftPoints[0] + normalized * num4;
				list.Add(pos);
				pos.y -= 0.02f;
				num4 = indentRightEnd;
				num5 = surroundingRightEnd;
				pos = rightPoints[0] + -normalized * num4;
				pos.y -= 0.02f;
				list.Add(pos);
				pos = tr.TransformPoint(rightPoints[0] + -normalized * (num4 + num5));
				baseScript.OCCDCQCOQC(ref pos);
				list.Add(tr.InverseTransformPoint(pos));
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
				surfaceMesh.GetComponent<MeshRenderer>().material = Resources.Load("Materials/surfaceMaterial") as Material;
				surfaceMesh.transform.parent = tr;
				surfaceMesh.GetComponent<MeshRenderer>().enabled = !baseScript.hideSurfaces;
				surfaceMesh.GetComponent<MeshCollider>().enabled = !baseScript.hideSurfaces;
				surfaceMesh.layer = 31;
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
			mesh.uv = new Vector2[list.Count];
			mesh.triangles = list2.ToArray();
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
