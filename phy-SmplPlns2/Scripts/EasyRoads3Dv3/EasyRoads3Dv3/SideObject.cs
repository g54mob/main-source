using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class SideObject : ScriptableObject
	{
		public string version = "2.0.0";

		public new string name;

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

		public float totalDistance = 0f;

		public bool reverseUVs = false;

		public bool terrainUVs = false;

		public List<bool> snapList = new List<bool>();

		public List<float> snapWeightList = new List<float>();

		public List<Color> colorList = new List<Color>();

		public string gameobjectStartGUID;

		public string gameobjectEndGUID;

		public int align = 0;

		public int alignPoint = 0;

		public bool weld = true;

		public bool combine = false;

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

		public float startOffset = 0f;

		public float endOffset = 0f;

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

		public bool isStatic = true;

		public bool castShadows = true;

		public bool scaleToRoad = false;

		public bool splitInBatches = false;

		public List<GameObject> instantiatedObjects = new List<GameObject>();

		public int maxVertices = 0;

		public bool doTestmesh = false;

		public Vector3 testMeshPos = Vector3.zero;

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

		public bool indentController = false;

		public bool excludeTerrainSplats = false;

		public float x1 = 0f;

		public float x2 = 0f;

		public float xf1 = 0f;

		public float xf2 = 0f;

		public float xf1Total = 0f;

		public float xf2Total = 0f;

		public float y1 = 0f;

		public float bridgeHeight = 5f;

		public int markerSplineController = 2;

		public float bridgeLength = 20f;

		public float deformationOffset = 0f;

		public float markerIndent = 0f;

		public float markerSurrounding = 0f;

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

		public bool strictRules = false;

		public bool snapIndents = false;

		public float snapIndentWidth = 1f;

		public bool cutHoles = true;

		public float innerStartOffset = 0f;

		public float innerEndOffset = 0f;

		public bool ignoredForRetainingWalls = false;

		public float heightMaxThreshold = 100f;

		public float heightMaxStartThreshold = 1f;

		public float heightMaxEndThreshold = 1f;

		public float xThresholdDistance = 5f;

		public float angleThreshold = 10f;

		public bool doubleSidedBendFlag = false;

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

		public bool recalculateNormals = false;

		public bool baseControllerFlag = false;

		public Vector3 connectorEndOffset;

		public float minBaseRotation = 0f;

		public float maxBaseRotation = 0f;

		public int baseChildIndex = -1;

		public int baseConnectorIndex = -1;

		public bool continueOnConnections = false;

		public bool ignoreOffsetsOnConnections = false;

		public int middleVariations = 0;

		public bool triangulateDualSided = false;

		public Material dualSidedMaterial;

		public float dualSidedMaterialTiling = 1f;

		public void OODQQCODOO()
		{
			buildOtherSideObjectChilds.Clear();
			for (int i = 0; i < buildOtherSideObjects.Count; i++)
			{
				buildOtherSideObjectChilds.Add(new SideObjectChild(buildOtherSideObjects[i], 0f));
			}
			buildOtherSideObjects.Clear();
		}

		public float ODDDCDDOCQ(double id)
		{
			for (int i = 0; i < buildOtherSideObjectChilds.Count; i++)
			{
				if (buildOtherSideObjectChilds[i].soid == id)
				{
					return buildOtherSideObjectChilds[i].offset;
				}
			}
			return 0f;
		}

		public void SetSideObject(int count, int scategory)
		{
			id = (timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
			name = "Side Object " + count;
			category = scategory;
		}

		public void UpdateTimeStamp()
		{
			timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}

		public void OQCQODQQQQ()
		{
			uvs.Clear();
			float num = 0f;
			for (int i = 0; i < nodeList.Count - 1; i++)
			{
				num += Vector2.Distance(nodeList[i], nodeList[i + 1]);
			}
			float num2 = 0f;
			uvs.Add(0f);
			for (int j = 0; j < nodeList.Count - 1; j++)
			{
				num2 += Vector2.Distance(nodeList[j], nodeList[j + 1]);
				uvs.Add(num2 / num);
			}
			OCDDQQDCCD();
		}

		public void OCDDQQDCCD()
		{
			nodeListMirrored = new List<Vector2>(nodeList);
			nodeListMirrored.Reverse();
			for (int i = 0; i < nodeListMirrored.Count; i++)
			{
				Vector2 value = nodeListMirrored[i];
				value.x *= -1f;
				nodeListMirrored[i] = value;
			}
			uvsMirrored.Clear();
			hardEdgeMirrored = new List<bool>();
			for (int num = nodeListMirrored.Count - 1; num >= 0; num--)
			{
				uvsMirrored.Add(uvs[num]);
				if (hardEdge[num] && hardEdgePadding > 0f)
				{
					uvsMirrored[uvsMirrored.Count - 1] += hardEdgePadding;
				}
				hardEdgeMirrored.Add(hardEdge[num]);
			}
			snapWeightListMirrored = new List<float>(snapWeightList);
			snapWeightListMirrored.Reverse();
			colorListMirrored = new List<Color>(colorList);
			colorListMirrored.Reverse();
		}

		public void SetMaxVertices()
		{
			maxVertices = 0;
			GameObject gameObject = sourceObject;
			if (objectType != 0)
			{
				gameObject = connectionObject;
			}
			if (!(gameObject != null))
			{
				return;
			}
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			if (component != null && component.sharedMesh != null && component.sharedMesh.vertices.Length > maxVertices)
			{
				maxVertices = component.sharedMesh.vertices.Length;
			}
			MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
			foreach (Transform item in gameObject.transform)
			{
				if ((bool)item.GetComponent<MeshFilter>())
				{
					MeshFilter component2 = item.GetComponent<MeshFilter>();
					if (component2.sharedMesh != null && component2.sharedMesh.vertices.Length > maxVertices)
					{
						maxVertices = component2.sharedMesh.vertices.Length;
					}
				}
			}
		}

		public static bool OQCOQDDQCQ(List<ERSOSection> sections, SideObject so)
		{
			for (int i = 0; i < sections.Count; i++)
			{
				if (sections[i].so.buildOtherSideObjectChilds.Count == 0 && sections[i].so.buildOtherSideObjects.Count != 0)
				{
					sections[i].so.OODQQCODOO();
				}
				if (!sections[i].active || !(sections[i].so != null) || sections[i].so.buildOtherSideObjectChilds.Count <= 0)
				{
					continue;
				}
				for (int j = 0; j < sections[i].so.buildOtherSideObjectChilds.Count; j++)
				{
					if (sections[i].so.buildOtherSideObjectChilds[j].soid == so.id)
					{
						return true;
					}
				}
			}
			return false;
		}

		public void OQDQOOOCQO(bool updateTimeStamp)
		{
			meshObjects.Clear();
			subMesh = false;
			meshObjects.Add(new ERMesh(null, this, 0f, null, Vector3.one, null, null));
			totalDistance = 0f;
			for (int i = 0; i < nodeList.Count - 1; i++)
			{
				totalDistance += Vector2.Distance(nodeList[i], nodeList[i + 1]);
			}
			uvDistances.Clear();
			uvDistances.Add(0f);
			float num = 0f;
			for (int j = 0; j < nodeList.Count - 1; j++)
			{
				num += Vector2.Distance(nodeList[j], nodeList[j + 1]);
				uvDistances.Add(num / totalDistance);
			}
			if (updateTimeStamp)
			{
				UpdateTimeStamp();
			}
		}

		public void OOCCQCQDQD()
		{
			x1 = (x2 = (xf1 = (xf2 = (xf1Total = (xf2Total = (y1 = 0f))))));
			bool flag = true;
			foreach (ERMesh meshObject in meshObjects)
			{
				if (!meshObject.terrainMesh)
				{
					flag = false;
				}
			}
			foreach (ERMesh meshObject2 in meshObjects)
			{
				foreach (Vector3 vec in meshObject2.vecs)
				{
					if ((double)vec.y > 0.25)
					{
						if (vec.x < x1)
						{
							x1 = vec.x;
						}
						else if (vec.x > x2)
						{
							x2 = vec.x;
						}
						if (vec.y > y1)
						{
							y1 = vec.y;
						}
					}
				}
			}
			foreach (ERMesh meshObject3 in meshObjects)
			{
				foreach (Vector3 startVec in meshObject3.startVecs)
				{
					if (flag || !meshObject3.terrainMesh)
					{
						if (startVec.x < xf1)
						{
							xf1 = startVec.x;
						}
						else if (startVec.x > xf2)
						{
							xf2 = startVec.x;
						}
					}
					if (startVec.x < xf1Total)
					{
						xf1Total = startVec.x;
					}
					else if (startVec.x > xf2Total)
					{
						xf2Total = startVec.x;
					}
				}
			}
			y1 += 0.05f;
		}

		public string OCCQOQDOOD(Vector3 m_testMeshPos, bool updateTimeStamp)
		{
			if (updateTimeStamp)
			{
				UpdateTimeStamp();
			}
			string result = "";
			testMeshPos = m_testMeshPos;
			minStartZ = 10000f;
			maxStartZ = -10000f;
			minMiddleZ = 10000f;
			maxMiddleZ = -10000f;
			minEndZ = 10000f;
			maxEndZ = -10000f;
			startOverlapOffset = 0f;
			endOverlapOffset = 0f;
			hasVertexColors = (startSection = (endSection = (namedChilds = false)));
			if (sourceObject == null && objectType != 1)
			{
				return result;
			}
			if (sourceObject != null)
			{
				sourceObject.transform.position = Vector3.zero;
			}
			if (objectType == 1)
			{
				OQDQOOOCQO(updateTimeStamp);
				return result;
			}
			meshObjects.Clear();
			subMesh = false;
			List<GameObject> list = new List<GameObject>();
			MeshFilter meshFilter = null;
			if ((bool)sourceObject.GetComponent<MeshFilter>())
			{
				if (sourceObject.GetComponent<MeshFilter>().sharedMesh != null)
				{
					list.Add(sourceObject);
				}
				else
				{
					Debug.LogError(sourceObject?.ToString() + ": This object does not have a mesh assigned to the meshfilter!");
				}
			}
			bool flag = false;
			foreach (Transform item in sourceObject.transform)
			{
				if (!item.GetComponent<MeshFilter>())
				{
					continue;
				}
				if (item.GetComponent<MeshFilter>().sharedMesh != null)
				{
					string text = item.name;
					if (text.IndexOf("_start") >= 0 || text.IndexOf("_middle") >= 0 || text.IndexOf("_end") >= 0)
					{
						flag = true;
						includeStartSegment = (includeEndSegment = false);
					}
					list.Add(item.gameObject);
				}
				else
				{
					result = sourceObject?.ToString() + "> " + item?.ToString() + ": This object does not have a mesh assigned to the meshfilter!";
					Debug.LogError(sourceObject?.ToString() + "> " + item?.ToString() + ": This object does not have a mesh assigned to the meshfilter!");
				}
			}
			if (list.Count == 0)
			{
				Debug.LogError(sourceObject?.ToString() + ": This object does not have a meshfilter component!");
				return sourceObject?.ToString() + ": This object does not have a meshfilter component!";
			}
			Mesh mesh = null;
			float num = 10000f;
			float num2 = -10000f;
			float num3 = 100000f;
			float num4 = -100000f;
			float num5 = 100000f;
			float num6 = -100000f;
			startZDistance = 0f;
			middleZDistance = 0f;
			endZDistance = 0f;
			bool rotate = false;
			float num7 = 10000f;
			float num8 = 10000f;
			float num9 = 10000f;
			startBoundsZ = (endBoundsZ = 0f);
			if (list.Count > 0)
			{
				Bounds bounds = default(Bounds);
				for (int i = 0; i < list.Count; i++)
				{
					bounds.Encapsulate(list[i].GetComponent<MeshFilter>().sharedMesh.bounds);
					if (!flag)
					{
						continue;
					}
					float z = list[i].GetComponent<MeshFilter>().sharedMesh.bounds.min.z;
					Vector3 min = list[i].GetComponent<MeshFilter>().sharedMesh.bounds.min;
					z = list[i].transform.TransformPoint(min).z;
					if (list[i].name.IndexOf("_start") >= 0)
					{
						num7 = z;
						float z2 = list[i].GetComponent<MeshFilter>().sharedMesh.bounds.size.z;
						Vector3 size = list[i].GetComponent<MeshFilter>().sharedMesh.bounds.size;
						z2 = list[i].transform.TransformPoint(size).z;
						if (z2 > startBoundsZ)
						{
							startBoundsZ = z2;
						}
					}
					else if (list[i].name.IndexOf("_middle") >= 0)
					{
						num8 = z;
					}
					else if (list[i].name.IndexOf("_end") >= 0)
					{
						num9 = z;
						float z3 = list[i].GetComponent<MeshFilter>().sharedMesh.bounds.size.z;
						Vector3 size2 = list[i].GetComponent<MeshFilter>().sharedMesh.bounds.size;
						z3 = list[i].transform.TransformPoint(size2).z;
						if (z3 > endBoundsZ)
						{
							endBoundsZ = z3;
						}
					}
				}
				if (flag)
				{
					if (num7 != 10000f && num8 != 10000f && num7 > num8)
					{
						rotate = true;
					}
					else if (num9 != 10000f && num8 != 10000f && num9 < num8)
					{
						rotate = true;
					}
					namedChilds = true;
				}
				num = 100000f;
				num2 = -100000f;
				num3 = 100000f;
				num4 = -100000f;
				num5 = 100000f;
				num6 = -100000f;
				num7 = 1000f;
				float num10 = 10000f;
				float num11 = 10000f;
				float num12 = 10000f;
				foreach (GameObject item2 in list)
				{
					mesh = item2.GetComponent<MeshFilter>().sharedMesh;
					float z4 = item2.transform.TransformPoint(mesh.vertices[0]).z;
					for (int j = 0; j < mesh.vertices.Length; j++)
					{
						Vector3 vector = item2.transform.TransformPoint(mesh.vertices[j]);
						if (vector.z < num)
						{
							num = vector.z;
						}
						if (vector.z > num2)
						{
							num2 = vector.z;
						}
						if (vector.x < num5)
						{
							num5 = vector.x;
						}
						if (vector.x > num6)
						{
							num6 = vector.x;
						}
						if (vector.y < num3)
						{
							num3 = vector.y;
						}
						if (vector.y > num4)
						{
							num4 = vector.y;
						}
						if (vector.z < z4)
						{
							z4 = vector.z;
						}
						if (item2.name.Contains("_start") && num < num7)
						{
							num7 = num;
						}
					}
					if (mesh.colors.Length != 0)
					{
						hasVertexColors = true;
					}
					if (item2.name.Contains("_start") && z4 < num10)
					{
						num10 = z4;
					}
					else if (item2.name.Contains("_middle") && z4 < num11)
					{
						num11 = z4;
					}
					if (item2.name.Contains("_end") && z4 < num12)
					{
						num12 = z4;
					}
				}
				if (flag)
				{
					num7 = num10;
				}
				bounds.min = new Vector3(bounds.min.x, bounds.min.y, num);
				bounds.max = new Vector3(bounds.max.x, bounds.max.y, num2);
				totalZDistance = bounds.max.z - bounds.min.z;
				mesh = null;
				Mesh mesh2 = null;
				middleVariations = 0;
				for (int k = 0; k < list.Count; k++)
				{
					mesh = null;
					Material[] array = null;
					if ((bool)list[k].GetComponent<MeshFilter>())
					{
						mesh = list[k].GetComponent<MeshFilter>().sharedMesh;
					}
					if ((bool)list[k].GetComponent<MeshRenderer>())
					{
						array = list[k].GetComponent<MeshRenderer>().sharedMaterials;
					}
					if (!(mesh != null))
					{
						continue;
					}
					if (mesh.subMeshCount > 1)
					{
						subMesh = true;
					}
					mesh2 = UnityEngine.Object.Instantiate(mesh);
					for (int l = 0; l < mesh.subMeshCount; l++)
					{
						mesh2.triangles = mesh.GetTriangles(l);
						meshObjects.Add(new ERMesh(list[k], this, num, sourceObject.transform, Vector3.one, mesh2, array[l], num7, endBoundsZ, rotate));
						meshObjects[meshObjects.Count - 1].name = list[k].name;
						if (list[k].name.Contains("_terrain"))
						{
							meshObjects[meshObjects.Count - 1].terrainMesh = true;
						}
						meshObjects[meshObjects.Count - 1].castShadows = castShadows;
						if (list[k].name.Contains("_castShadowsOff"))
						{
							meshObjects[meshObjects.Count - 1].castShadows = false;
						}
						if (list[k].name.Contains("_end"))
						{
						}
						if (!list[k].name.Contains("_middle"))
						{
							continue;
						}
						string[] array2 = list[k].name.Split(new char[1] { '_' });
						string[] array3 = array2;
						foreach (string text2 in array3)
						{
							if (!text2.Contains("middle"))
							{
								continue;
							}
							string text3 = text2.Replace("middle", "");
							if (!(text3 != ""))
							{
								continue;
							}
							int result2 = -1;
							if (int.TryParse(text3, out result2))
							{
								if (result2 > middleVariations)
								{
									middleVariations = result2;
								}
								meshObjects[meshObjects.Count - 1].middleIndex = result2;
							}
						}
					}
				}
				UnityEngine.Object.DestroyImmediate(mesh2);
				if (meshObjects.Count == 0)
				{
					Debug.LogError("EasyRoads3Dv3: " + name + " Unable to extract mesh data, the source mesh does not have valid mesh data");
				}
				boxSize = new Vector2(bounds.size.x, bounds.size.y);
				boxSize = new Vector2(num6 - num5, num4 - num3);
				boxOffset = new Vector2(bounds.center.x, bounds.center.y);
			}
			startZDistance = maxStartZ - minStartZ;
			middleZDistance = maxMiddleZ - minMiddleZ;
			endZDistance = maxEndZ - minEndZ;
			if (includeStartSegment && namedChilds)
			{
				startOverlapOffset = maxStartZ - minMiddleZ;
			}
			if (includeEndSegment && namedChilds)
			{
				endOverlapOffset = maxMiddleZ - minEndZ;
			}
			int num13 = meshObjects.Count - 1;
			int num14 = 0;
			bool flag2 = false;
			for (int num15 = num13; num15 >= 0; num15--)
			{
				num14 = -1;
				if (meshObjects[num15].startVecs.Count != 0)
				{
					num14 = 0;
				}
				else if (meshObjects[num15].vecs.Count != 0)
				{
					num14 = 1;
				}
				else if (meshObjects[num15].endVecs.Count != 0)
				{
					num14 = 2;
				}
				else if (meshObjects[num15].suVecs.Count != 0)
				{
					num14 = 3;
				}
				else if (meshObjects[num15].sdVecs.Count != 0)
				{
					num14 = 4;
				}
				for (int n = 0; n < num15; n++)
				{
					if (meshObjects[num15].materials.Count > 0 && meshObjects[num15].materials[0] == meshObjects[n].materials[0] && ussst(meshObjects[n], meshObjects[num15], num14))
					{
						meshObjects.RemoveAt(num15);
						flag2 = true;
						break;
					}
				}
			}
			if (flag2)
			{
				for (int num16 = 0; num16 < meshObjects.Count; num16++)
				{
					meshObjects[num16].OQDCDCQOOD();
				}
				if (subMesh)
				{
					for (int num17 = 0; num17 < meshObjects.Count; num17++)
					{
						for (int num18 = num17 + 1; num18 < meshObjects.Count; num18++)
						{
							if (meshObjects[num17].startVecs.Count != meshObjects[num18].startVecs.Count || meshObjects[num17].vecs.Count != meshObjects[num18].vecs.Count || meshObjects[num17].endVecs.Count != meshObjects[num18].endVecs.Count)
							{
								subMesh = false;
								break;
							}
						}
					}
				}
			}
			if (flag)
			{
				float num19 = 0f;
				float num20 = 0f;
				for (int num21 = 0; num21 < meshObjects.Count; num21++)
				{
					meshObjects[num21].snapStartVertices = false;
					meshObjects[num21].snapMiddleVertices = false;
					meshObjects[num21].snapEndVertices = false;
					ODCCQQODQC(meshObjects[num21].vecs, meshObjects[num21].startVecs, meshObjects[num21].zValues, meshObjects[num21].zValuesStart, meshObjects[num21].zValueVecIndexes, meshObjects[num21].zValueVecIndexesStart, meshObjects[num21], 0f, middleZDistance, ref meshObjects[num21].middleStartStartInts, ref meshObjects[num21].startEndInts, 0, ref meshObjects[num21].snapStartVertices, 0f, startOverlapOffset);
					ODCCQQODQC(meshObjects[num21].vecs, meshObjects[num21].vecs, meshObjects[num21].zValues, meshObjects[num21].zValues, meshObjects[num21].zValueVecIndexes, meshObjects[num21].zValueVecIndexes, meshObjects[num21], 0f, middleZDistance, ref meshObjects[num21].middleStartInts, ref meshObjects[num21].middleEndInts, 1, ref meshObjects[num21].snapMiddleVertices, 0f, 0f);
					if (!stepDown || !stepUp)
					{
						continue;
					}
					for (int num22 = 0; num22 < meshObjects[num21].vecs.Count; num22++)
					{
						if (meshObjects[num21].vecs[num22].y > num20)
						{
							num20 = meshObjects[num21].vecs[num22].y;
						}
					}
					for (int num23 = 0; num23 < meshObjects[num21].suVecs.Count; num23++)
					{
						if (meshObjects[num21].suVecs[num23].y > num19)
						{
							num19 = meshObjects[num21].suVecs[num23].y;
						}
					}
					for (int num24 = 0; num24 < meshObjects[num21].sdVecs.Count; num24++)
					{
						if (meshObjects[num21].sdVecs[num24].y > num19)
						{
							num19 = meshObjects[num21].sdVecs[num24].y;
						}
					}
				}
				if (stepDown && stepUp)
				{
					stepDistance = num19 - num20;
				}
			}
			startDirZOffset = 1000f;
			endDirZOffset = 0f;
			for (int num25 = 0; num25 < meshObjects.Count; num25++)
			{
			}
			if ((startZDistance < 0f && includeStartSegment) || middleZDistance < 0f)
			{
				Debug.LogError("EasyRoads3Dv3: " + name + " Unable to extract mesh data, is the center of the bounding box positioned near (0,0)? Otherwise please contact us with details ideally including the source prefab so we can test it.");
			}
			if (middleZDistance == 0f)
			{
				result = "The extracted mesh does not have depth and is therefore unsuitable for the Procedural Side Object Type.";
			}
			else if (includeStartSegment && minStartZ > minMiddleZ)
			{
				result = "The Start section of the extracted mesh is inside the middle section, this will no work well. The Start and Middle section can overlap but the Start section should start before the Middle section.";
			}
			else if (includeEndSegment && maxEndZ < maxMiddleZ)
			{
				result = "The End section of the extracted mesh is inside the middle section, this will not work well. The End and Middle section can overlap but the End section should end behind the Middle section.";
			}
			OOCCQCQDQD();
			return result;
		}

		private void ODCCQQODQC(List<Vector3> vecs1, List<Vector3> vecs2, List<float> zValues1, List<float> zValues2, List<ZIndexArray> zValueVecIndexes1, List<ZIndexArray> zValueVecIndexes2, ERMesh meshObject, float startDistance, float endDistance, ref List<int> startArray, ref List<int> endArray, int section, ref bool snapVertices, float startOffset, float endOffset)
		{
			float num = 10000f;
			float num2 = -10000f;
			int num3 = -1;
			int num4 = -1;
			float num5 = 0f;
			float num6 = 0f;
			int num7 = 0;
			int num8 = 0;
			for (int i = 0; i < zValues1.Count; i++)
			{
				if (zValues1[i] < num)
				{
					num3 = i;
					num = zValues1[i];
				}
			}
			for (int j = 0; j < zValues2.Count; j++)
			{
				if (zValues2[j] > num2)
				{
					num4 = j;
					num2 = zValues2[j];
				}
			}
			if (num3 == -1 || num4 == -1)
			{
				return;
			}
			float num9 = 0.1f;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int k = 0; k < zValues1.Count; k++)
			{
				if (Mathf.Abs(zValues1[k] - startOffset - num) < num9)
				{
					list.AddRange(zValueVecIndexes1[k].index);
				}
			}
			for (int l = 0; l < zValues2.Count; l++)
			{
				if (Mathf.Abs(zValues2[l] + endOffset - num2) < num9)
				{
					list2.AddRange(zValueVecIndexes2[l].index);
				}
			}
			if (list.Count != list2.Count)
			{
				return;
			}
			startArray.Clear();
			meshObject.middleEndInts.Clear();
			num9 = 0.005f;
			float num10 = 0f;
			int item = 0;
			int index = 0;
			for (int m = 0; m < list.Count; m++)
			{
				bool flag = false;
				Vector2 a = new Vector2(vecs1[list[m]].x, vecs1[list[m]].y);
				num = 10000f;
				for (int n = 0; n < list2.Count; n++)
				{
					Vector2 b = new Vector2(vecs2[list2[n]].x, vecs2[list2[n]].y);
					num10 = Vector2.Distance(a, b);
					if (num10 < num)
					{
						item = list2[n];
						index = n;
						num = num10;
					}
				}
				if (num < num9)
				{
					startArray.Add(list[m]);
					endArray.Add(item);
					flag = true;
					list2.RemoveAt(index);
				}
			}
			if (startArray.Count == endArray.Count)
			{
				snapVertices = true;
			}
		}

		private float ODCDOCDOQQ(List<GameObject> goObjects, bool rotate180)
		{
			float num = 10000f;
			for (int i = 0; i < goObjects.Count; i++)
			{
				if (goObjects[i].name.IndexOf("_start") < 0)
				{
					continue;
				}
				Mesh sharedMesh = goObjects[i].GetComponent<MeshFilter>().sharedMesh;
				for (int j = 0; j < sharedMesh.vertices.Length; j++)
				{
					Vector3 point = sharedMesh.vertices[j];
					if (rotate180)
					{
						point = OQQOCDQCQD.OOQOCODQOO(point, Vector3.zero, Quaternion.Euler(0f, 180f, 0f));
					}
					if (point.z < num)
					{
						num = point.z;
					}
				}
			}
			return num;
		}

		private bool ussst(ERMesh tssss, ERMesh ussss, int vssss)
		{
			switch (vssss)
			{
			case 0:
				if (tssss.lodIndex == ussss.lodIndex && tssss.startVecs.Count == 0 && (tssss.vecs.Count != 0 || tssss.endVecs.Count != 0 || tssss.suVecs.Count != 0 || tssss.sdVecs.Count != 0))
				{
					tssss.startVecs = ussss.startVecs;
					tssss.startUv = ussss.startUv;
					tssss.startUv2 = ussss.startUv2;
					tssss.startColors = ussss.startColors;
					tssss.startNormals = ussss.startNormals;
					tssss.startTangents = ussss.startTangents;
					tssss.startTriangles = ussss.startTriangles;
					tssss.zValueVecIndexesStart = ussss.zValueVecIndexesStart;
					tssss.zValuesStart = ussss.zValuesStart;
					return true;
				}
				break;
			case 1:
				if (tssss.lodIndex == ussss.lodIndex && tssss.vecs.Count == 0 && (tssss.startVecs.Count != 0 || tssss.endVecs.Count != 0 || tssss.suVecs.Count != 0 || tssss.sdVecs.Count != 0))
				{
					tssss.vecs = ussss.vecs;
					tssss.uv = ussss.uv;
					tssss.uv2 = ussss.uv2;
					tssss.colors = ussss.colors;
					tssss.normals = ussss.normals;
					tssss.tangents = ussss.tangents;
					tssss.triangles = ussss.triangles;
					tssss.zValueVecIndexes = ussss.zValueVecIndexes;
					tssss.zValues = ussss.zValues;
					return true;
				}
				break;
			case 2:
				if (tssss.lodIndex == ussss.lodIndex && tssss.endVecs.Count == 0 && (tssss.startVecs.Count != 0 || tssss.vecs.Count != 0 || tssss.suVecs.Count != 0 || tssss.sdVecs.Count != 0))
				{
					tssss.endVecs = ussss.endVecs;
					tssss.endUv = ussss.endUv;
					tssss.endUv2 = ussss.endUv2;
					tssss.endColors = ussss.endColors;
					tssss.endNormals = ussss.endNormals;
					tssss.endTangents = ussss.endTangents;
					tssss.endTriangles = ussss.endTriangles;
					tssss.zValueVecIndexesEnd = ussss.zValueVecIndexesEnd;
					tssss.zValuesEnd = ussss.zValuesEnd;
					return true;
				}
				break;
			case 3:
				if (tssss.lodIndex == ussss.lodIndex && tssss.suVecs.Count == 0 && (tssss.startVecs.Count != 0 || tssss.vecs.Count != 0 || tssss.endVecs.Count != 0 || tssss.sdVecs.Count != 0))
				{
					tssss.suVecs = ussss.suVecs;
					tssss.suUv = ussss.suUv;
					tssss.suUv2 = ussss.suUv2;
					tssss.suColors = ussss.suColors;
					tssss.suNormals = ussss.suNormals;
					tssss.suTangents = ussss.suTangents;
					tssss.suTriangles = ussss.suTriangles;
					tssss.zValueVecIndexesStepUp = ussss.zValueVecIndexesStepUp;
					tssss.zValuesStepUp = ussss.zValuesStepUp;
					return true;
				}
				break;
			case 4:
				if (tssss.lodIndex == ussss.lodIndex && tssss.sdVecs.Count == 0 && (tssss.startVecs.Count != 0 || tssss.vecs.Count != 0 || tssss.endVecs.Count != 0 || tssss.suVecs.Count != 0))
				{
					tssss.sdVecs = ussss.sdVecs;
					tssss.sdUv = ussss.sdUv;
					tssss.sdUv2 = ussss.sdUv2;
					tssss.sdColors = ussss.sdColors;
					tssss.sdNormals = ussss.sdNormals;
					tssss.sdTangents = ussss.sdTangents;
					tssss.sdTriangles = ussss.sdTriangles;
					tssss.zValueVecIndexesStepDown = ussss.zValueVecIndexesStepDown;
					tssss.zValuesStepDown = ussss.zValuesStepDown;
					return true;
				}
				break;
			}
			return false;
		}

		public void ODCCOOCCCO(SideObject so)
		{
			name = so.name + " [duplicate]";
			id = so.id;
			id = (timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
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
			nodeList = new List<Vector2>(so.nodeList);
			uvs = new List<float>(so.uvs);
			uvDistances = new List<float>(so.uvDistances);
			clampUVs = so.clampUVs;
			clampUVY = so.clampUVY;
			clampUVYValue = so.clampUVYValue;
			terrainUVs = so.terrainUVs;
			totalDistance = so.totalDistance;
			snapList = new List<bool>(so.snapList);
			snapWeightList = new List<float>(so.snapWeightList);
			colorList = new List<Color>(so.colorList);
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
			adjustToRoadWidth = so.adjustToRoadWidth;
			xOffset = so.xOffset;
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
			layer = so.layer;
			isStatic = so.isStatic;
			castShadows = so.castShadows;
			bridgeObject = so.bridgeObject;
			tunnelObject = so.tunnelObject;
			snapToTerrain = so.snapToTerrain;
			deformationObject = so.deformationObject;
			scaleToRoad = so.scaleToRoad;
			splitInBatches = so.splitInBatches;
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
			indentController = so.indentController;
			excludeTerrainSplats = so.excludeTerrainSplats;
			bridgeHeight = so.bridgeHeight;
			markerSplineController = so.markerSplineController;
			bridgeLength = so.bridgeLength;
			deformationOffset = so.deformationOffset;
			markerIndent = so.markerIndent;
			markerSurrounding = so.markerSurrounding;
			scale = so.scale;
			indentExt = so.indentExt;
			targetObject = so.targetObject;
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
			baseControllerFlag = so.baseControllerFlag;
			connectorEndOffset = so.connectorEndOffset;
			minBaseRotation = so.minBaseRotation;
			maxBaseRotation = so.maxBaseRotation;
			baseChildIndex = so.baseChildIndex;
			baseConnectorIndex = so.baseConnectorIndex;
			continueOnConnections = so.continueOnConnections;
			ignoreOffsetsOnConnections = so.ignoreOffsetsOnConnections;
			x1 = so.x1;
			x2 = so.x2;
			xf1 = so.xf1;
			xf2 = so.xf2;
			xf1Total = so.xf1Total;
			xf2Total = so.xf2Total;
			y1 = so.y1;
			triangulateDualSided = so.triangulateDualSided;
			dualSidedMaterial = so.dualSidedMaterial;
			dualSidedMaterialTiling = so.dualSidedMaterialTiling;
			if (so.meshObjects.Count > 0)
			{
				OCCQOQDOOD(Vector3.zero, updateTimeStamp: false);
			}
		}

		public void OOODDCQQOQ(SideObjectLog so)
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
			nodeList = new List<Vector2>(so.nodeList);
			uvs = new List<float>(so.uvs);
			uvDistances = new List<float>(so.uvDistances);
			clampUVs = so.clampUVs;
			clampUVY = so.clampUVY;
			clampUVYValue = so.clampUVYValue;
			terrainUVs = so.terrainUVs;
			totalDistance = so.totalDistance;
			snapList = new List<bool>(so.snapList);
			snapWeightList = new List<float>(so.snapWeightList);
			colorList = new List<Color>(so.colorList);
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
			adjustToRoadWidth = so.adjustToRoadWidth;
			xOffset = so.xOffset;
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
			layer = so.layer;
			isStatic = so.isStatic;
			castShadows = so.castShadows;
			bridgeObject = so.bridgeObject;
			tunnelObject = so.tunnelObject;
			snapToTerrain = so.snapToTerrain;
			deformationObject = so.deformationObject;
			scaleToRoad = so.scaleToRoad;
			splitInBatches = so.splitInBatches;
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
			indentController = so.indentController;
			excludeTerrainSplats = so.excludeTerrainSplats;
			bridgeHeight = so.bridgeHeight;
			markerSplineController = so.markerSplineController;
			bridgeLength = so.bridgeLength;
			deformationOffset = so.deformationOffset;
			markerIndent = so.markerIndent;
			markerSurrounding = so.markerSurrounding;
			scale = so.scale;
			targetObject = so.targetObject;
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
			baseControllerFlag = so.baseControllerFlag;
			connectorEndOffset = so.connectorEndOffset;
			minBaseRotation = so.minBaseRotation;
			maxBaseRotation = so.maxBaseRotation;
			baseChildIndex = so.baseChildIndex;
			baseConnectorIndex = so.baseConnectorIndex;
			continueOnConnections = so.continueOnConnections;
			x1 = so.x1;
			x2 = so.x2;
			xf1 = so.xf1;
			xf2 = so.xf2;
			xf1Total = so.xf1Total;
			xf2Total = so.xf2Total;
			y1 = so.y1;
			triangulateDualSided = so.triangulateDualSided;
			dualSidedMaterial = so.dualSidedMaterial;
			dualSidedMaterialTiling = so.dualSidedMaterialTiling;
			if (objectType > 0 && (bool)sourceObject)
			{
				if (objectType == 1)
				{
					OQDQOOOCQO(updateTimeStamp: false);
				}
				else
				{
					OCCQOQDOOD(Vector3.zero, updateTimeStamp: false);
				}
			}
			if (objectType == 1 && nodeList.Count > 0)
			{
				OQDQOOOCQO(updateTimeStamp: false);
			}
		}

		public void Clear()
		{
			for (int i = 0; i < meshObjects.Count; i++)
			{
				meshObjects[i].Clear();
			}
		}
	}
}
