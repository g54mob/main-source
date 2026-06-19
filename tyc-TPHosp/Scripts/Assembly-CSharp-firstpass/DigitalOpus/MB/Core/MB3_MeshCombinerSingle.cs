using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public class MB3_MeshCombinerSingle : MB3_MeshCombiner
	{
		[Serializable]
		public class SerializableIntArray
		{
			public int[] data;

			public SerializableIntArray()
			{
			}

			public SerializableIntArray(int len)
			{
				data = new int[len];
			}
		}

		[Serializable]
		public class MB_DynamicGameObject : IComparable<MB_DynamicGameObject>
		{
			public int instanceID;

			public string name;

			public int vertIdx;

			public int blendShapeIdx;

			public int numVerts;

			public int numBlendShapes;

			public int[] indexesOfBonesUsed = new int[0];

			public int lightmapIndex = -1;

			public Vector4 lightmapTilingOffset = new Vector4(1f, 1f, 0f, 0f);

			public Vector3 meshSize = Vector3.one;

			public bool show = true;

			public bool invertTriangles;

			public int[] submeshTriIdxs;

			public int[] submeshNumTris;

			public int[] targetSubmeshIdxs;

			public Rect[] uvRects;

			public Rect[] encapsulatingRect;

			public Rect[] sourceMaterialTiling;

			public Rect[] obUVRects;

			public bool _beingDeleted;

			public int _triangleIdxAdjustment;

			[NonSerialized]
			public SerializableIntArray[] _tmpSubmeshTris;

			[NonSerialized]
			public Transform[] _tmpCachedBones;

			[NonSerialized]
			public Matrix4x4[] _tmpCachedBindposes;

			[NonSerialized]
			public BoneWeight[] _tmpCachedBoneWeights;

			[NonSerialized]
			public int[] _tmpIndexesOfSourceBonesUsed;

			public int CompareTo(MB_DynamicGameObject b)
			{
				return vertIdx - b.vertIdx;
			}
		}

		public class MeshChannels
		{
			public Vector3[] vertices;

			public Vector3[] normals;

			public Vector4[] tangents;

			public Vector2[] uv0raw;

			public Vector2[] uv0modified;

			public Vector2[] uv2;

			public Vector2[] uv3;

			public Vector2[] uv4;

			public Color[] colors;

			public BoneWeight[] boneWeights;

			public Matrix4x4[] bindPoses;

			public int[] triangles;

			public MBBlendShape[] blendShapes;
		}

		[Serializable]
		public class MBBlendShapeFrame
		{
			public float frameWeight;

			public Vector3[] vertices;

			public Vector3[] normals;

			public Vector3[] tangents;
		}

		[Serializable]
		public class MBBlendShape
		{
			public int gameObjectID;

			public string name;

			public int indexInSource;

			public MBBlendShapeFrame[] frames;
		}

		public class MeshChannelsCache
		{
			private MB3_MeshCombinerSingle mc;

			protected Dictionary<int, MeshChannels> meshID2MeshChannels = new Dictionary<int, MeshChannels>();

			private Vector2 _HALF_UV = new Vector2(0.5f, 0.5f);

			public MeshChannelsCache(MB3_MeshCombinerSingle mcs)
			{
				mc = mcs;
			}

			internal Vector3[] GetVertices(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.vertices == null)
				{
					value.vertices = m.vertices;
				}
				return value.vertices;
			}

			internal Vector3[] GetNormals(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.normals == null)
				{
					value.normals = _getMeshNormals(m);
				}
				return value.normals;
			}

			internal Vector4[] GetTangents(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.tangents == null)
				{
					value.tangents = _getMeshTangents(m);
				}
				return value.tangents;
			}

			internal Vector2[] GetUv0Raw(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.uv0raw == null)
				{
					value.uv0raw = _getMeshUVs(m);
				}
				return value.uv0raw;
			}

			internal Vector2[] GetUv0Modified(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.uv0modified == null)
				{
					value.uv0modified = null;
				}
				return value.uv0modified;
			}

			internal Vector2[] GetUv2(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.uv2 == null)
				{
					value.uv2 = _getMeshUV2s(m);
				}
				return value.uv2;
			}

			internal Vector2[] GetUv3(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.uv3 == null)
				{
					value.uv3 = MBVersion.GetMeshUV3orUV4(m, get3: true, mc.LOG_LEVEL);
				}
				return value.uv3;
			}

			internal Vector2[] GetUv4(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.uv4 == null)
				{
					value.uv4 = MBVersion.GetMeshUV3orUV4(m, get3: false, mc.LOG_LEVEL);
				}
				return value.uv4;
			}

			internal Color[] GetColors(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.colors == null)
				{
					value.colors = _getMeshColors(m);
				}
				return value.colors;
			}

			internal Matrix4x4[] GetBindposes(Renderer r)
			{
				Mesh mesh = MB_Utility.GetMesh(r.gameObject);
				if (!meshID2MeshChannels.TryGetValue(mesh.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(mesh.GetInstanceID(), value);
				}
				if (value.bindPoses == null)
				{
					value.bindPoses = _getBindPoses(r);
				}
				return value.bindPoses;
			}

			internal BoneWeight[] GetBoneWeights(Renderer r, int numVertsInMeshBeingAdded)
			{
				Mesh mesh = MB_Utility.GetMesh(r.gameObject);
				if (!meshID2MeshChannels.TryGetValue(mesh.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(mesh.GetInstanceID(), value);
				}
				if (value.boneWeights == null)
				{
					value.boneWeights = _getBoneWeights(r, numVertsInMeshBeingAdded);
				}
				return value.boneWeights;
			}

			internal int[] GetTriangles(Mesh m)
			{
				if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
				{
					value = new MeshChannels();
					meshID2MeshChannels.Add(m.GetInstanceID(), value);
				}
				if (value.triangles == null)
				{
					value.triangles = m.triangles;
				}
				return value.triangles;
			}

			internal MBBlendShape[] GetBlendShapes(Mesh m, int gameObjectID)
			{
				if (MBVersion.GetMajorVersion() > 5 || (MBVersion.GetMajorVersion() == 5 && MBVersion.GetMinorVersion() >= 3))
				{
					if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
					{
						value = new MeshChannels();
						meshID2MeshChannels.Add(m.GetInstanceID(), value);
					}
					if (value.blendShapes == null)
					{
						MBBlendShape[] array = new MBBlendShape[m.blendShapeCount];
						int vertexCount = m.vertexCount;
						for (int i = 0; i < array.Length; i++)
						{
							MBBlendShape mBBlendShape = (array[i] = new MBBlendShape());
							mBBlendShape.frames = new MBBlendShapeFrame[MBVersion.GetBlendShapeFrameCount(m, i)];
							mBBlendShape.name = m.GetBlendShapeName(i);
							mBBlendShape.indexInSource = i;
							mBBlendShape.gameObjectID = gameObjectID;
							for (int j = 0; j < mBBlendShape.frames.Length; j++)
							{
								MBBlendShapeFrame mBBlendShapeFrame = (mBBlendShape.frames[j] = new MBBlendShapeFrame());
								mBBlendShapeFrame.frameWeight = MBVersion.GetBlendShapeFrameWeight(m, i, j);
								mBBlendShapeFrame.vertices = new Vector3[vertexCount];
								mBBlendShapeFrame.normals = new Vector3[vertexCount];
								mBBlendShapeFrame.tangents = new Vector3[vertexCount];
								MBVersion.GetBlendShapeFrameVertices(m, i, j, mBBlendShapeFrame.vertices, mBBlendShapeFrame.normals, mBBlendShapeFrame.tangents);
							}
						}
						value.blendShapes = array;
						return value.blendShapes;
					}
					MBBlendShape[] array2 = new MBBlendShape[value.blendShapes.Length];
					for (int k = 0; k < array2.Length; k++)
					{
						array2[k] = new MBBlendShape();
						array2[k].name = value.blendShapes[k].name;
						array2[k].indexInSource = value.blendShapes[k].indexInSource;
						array2[k].frames = value.blendShapes[k].frames;
						array2[k].gameObjectID = gameObjectID;
					}
					return array2;
				}
				return new MBBlendShape[0];
			}

			private Color[] _getMeshColors(Mesh m)
			{
				Color[] array = m.colors;
				if (array.Length == 0)
				{
					if (mc.LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no colors. Generating");
					}
					if (mc.LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have colors. Generating an array of white colors");
					}
					array = new Color[m.vertexCount];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = Color.white;
					}
				}
				return array;
			}

			private Vector3[] _getMeshNormals(Mesh m)
			{
				Vector3[] normals = m.normals;
				if (normals.Length == 0)
				{
					if (mc.LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no normals. Generating");
					}
					if (mc.LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have normals. Generating normals.");
					}
					Mesh mesh = UnityEngine.Object.Instantiate(m);
					mesh.RecalculateNormals();
					normals = mesh.normals;
					MB_Utility.Destroy(mesh);
				}
				return normals;
			}

			private Vector4[] _getMeshTangents(Mesh m)
			{
				Vector4[] array = m.tangents;
				if (array.Length == 0)
				{
					if (mc.LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no tangents. Generating");
					}
					if (mc.LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have tangents. Generating tangents.");
					}
					Vector3[] vertices = m.vertices;
					Vector2[] uv0Raw = GetUv0Raw(m);
					Vector3[] normals = _getMeshNormals(m);
					array = new Vector4[m.vertexCount];
					for (int i = 0; i < m.subMeshCount; i++)
					{
						int[] triangles = m.GetTriangles(i);
						_generateTangents(triangles, vertices, uv0Raw, normals, array);
					}
				}
				return array;
			}

			private Vector2[] _getMeshUVs(Mesh m)
			{
				Vector2[] array = m.uv;
				if (array.Length == 0)
				{
					if (mc.LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no uvs. Generating");
					}
					if (mc.LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have uvs. Generating uvs.");
					}
					array = new Vector2[m.vertexCount];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = _HALF_UV;
					}
				}
				return array;
			}

			private Vector2[] _getMeshUV2s(Mesh m)
			{
				Vector2[] array = m.uv2;
				if (array.Length == 0)
				{
					if (mc.LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no uv2s. Generating");
					}
					if (mc.LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have uv2s. Generating uv2s.");
					}
					if (mc._lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged_to_separate_rects)
					{
						UnityEngine.Debug.LogError("Mesh " + m?.ToString() + " did not have a UV2 channel. Nothing to copy when trying to copy UV2 to separate rects. The combined mesh will not lightmap properly. Try using generate new uv2 layout.");
					}
					array = new Vector2[m.vertexCount];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = _HALF_UV;
					}
				}
				return array;
			}

			public static Matrix4x4[] _getBindPoses(Renderer r)
			{
				if (r is SkinnedMeshRenderer)
				{
					return ((SkinnedMeshRenderer)r).sharedMesh.bindposes;
				}
				if (r is MeshRenderer)
				{
					Matrix4x4 identity = Matrix4x4.identity;
					return new Matrix4x4[1] { identity };
				}
				UnityEngine.Debug.LogError("Could not _getBindPoses. Object does not have a renderer");
				return null;
			}

			public static BoneWeight[] _getBoneWeights(Renderer r, int numVertsInMeshBeingAdded)
			{
				if (r is SkinnedMeshRenderer)
				{
					return ((SkinnedMeshRenderer)r).sharedMesh.boneWeights;
				}
				if (r is MeshRenderer)
				{
					BoneWeight boneWeight = default(BoneWeight);
					int num = (boneWeight.boneIndex3 = 0);
					int num3 = (boneWeight.boneIndex2 = num);
					int boneIndex = (boneWeight.boneIndex1 = num3);
					boneWeight.boneIndex0 = boneIndex;
					boneWeight.weight0 = 1f;
					float num6 = (boneWeight.weight3 = 0f);
					float weight = (boneWeight.weight2 = num6);
					boneWeight.weight1 = weight;
					BoneWeight[] array = new BoneWeight[numVertsInMeshBeingAdded];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = boneWeight;
					}
					return array;
				}
				UnityEngine.Debug.LogError("Could not _getBoneWeights. Object does not have a renderer");
				return null;
			}

			private void _generateTangents(int[] triangles, Vector3[] verts, Vector2[] uvs, Vector3[] normals, Vector4[] outTangents)
			{
				int num = triangles.Length;
				int num2 = verts.Length;
				Vector3[] array = new Vector3[num2];
				Vector3[] array2 = new Vector3[num2];
				for (int i = 0; i < num; i += 3)
				{
					int num3 = triangles[i];
					int num4 = triangles[i + 1];
					int num5 = triangles[i + 2];
					Vector3 vector = verts[num3];
					Vector3 vector2 = verts[num4];
					Vector3 vector3 = verts[num5];
					Vector2 vector4 = uvs[num3];
					Vector2 vector5 = uvs[num4];
					Vector2 vector6 = uvs[num5];
					float num6 = vector2.x - vector.x;
					float num7 = vector3.x - vector.x;
					float num8 = vector2.y - vector.y;
					float num9 = vector3.y - vector.y;
					float num10 = vector2.z - vector.z;
					float num11 = vector3.z - vector.z;
					float num12 = vector5.x - vector4.x;
					float num13 = vector6.x - vector4.x;
					float num14 = vector5.y - vector4.y;
					float num15 = vector6.y - vector4.y;
					float num16 = num12 * num15 - num13 * num14;
					if (num16 == 0f)
					{
						UnityEngine.Debug.LogError("Could not compute tangents. All UVs need to form a valid triangles in UV space. If any UV triangles are collapsed, tangents cannot be generated.");
						return;
					}
					float num17 = 1f / num16;
					Vector3 vector7 = new Vector3((num15 * num6 - num14 * num7) * num17, (num15 * num8 - num14 * num9) * num17, (num15 * num10 - num14 * num11) * num17);
					Vector3 vector8 = new Vector3((num12 * num7 - num13 * num6) * num17, (num12 * num9 - num13 * num8) * num17, (num12 * num11 - num13 * num10) * num17);
					array[num3] += vector7;
					array[num4] += vector7;
					array[num5] += vector7;
					array2[num3] += vector8;
					array2[num4] += vector8;
					array2[num5] += vector8;
				}
				for (int j = 0; j < num2; j++)
				{
					Vector3 vector9 = normals[j];
					Vector3 vector10 = array[j];
					Vector3 normalized = (vector10 - vector9 * Vector3.Dot(vector9, vector10)).normalized;
					outTangents[j] = new Vector4(normalized.x, normalized.y, normalized.z);
					outTangents[j].w = ((Vector3.Dot(Vector3.Cross(vector9, vector10), array2[j]) < 0f) ? (-1f) : 1f);
				}
			}
		}

		public struct BoneAndBindpose
		{
			public Transform bone;

			public Matrix4x4 bindPose;

			public BoneAndBindpose(Transform t, Matrix4x4 bp)
			{
				bone = t;
				bindPose = bp;
			}

			public override bool Equals(object obj)
			{
				if (obj is BoneAndBindpose && bone == ((BoneAndBindpose)obj).bone && bindPose == ((BoneAndBindpose)obj).bindPose)
				{
					return true;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (bone.GetInstanceID() % int.MaxValue) ^ (int)bindPose[0, 0];
			}
		}

		[SerializeField]
		protected List<GameObject> objectsInCombinedMesh = new List<GameObject>();

		[SerializeField]
		private int lightmapIndex = -1;

		[SerializeField]
		private List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh = new List<MB_DynamicGameObject>();

		private Dictionary<int, MB_DynamicGameObject> _instance2combined_map = new Dictionary<int, MB_DynamicGameObject>();

		[SerializeField]
		private Vector3[] verts = new Vector3[0];

		[SerializeField]
		private Vector3[] normals = new Vector3[0];

		[SerializeField]
		private Vector4[] tangents = new Vector4[0];

		[SerializeField]
		private Vector2[] uvs = new Vector2[0];

		[SerializeField]
		private Vector2[] uv2s = new Vector2[0];

		[SerializeField]
		private Vector2[] uv3s = new Vector2[0];

		[SerializeField]
		private Vector2[] uv4s = new Vector2[0];

		[SerializeField]
		private Color[] colors = new Color[0];

		[SerializeField]
		private Matrix4x4[] bindPoses = new Matrix4x4[0];

		[SerializeField]
		private Transform[] bones = new Transform[0];

		[SerializeField]
		internal MBBlendShape[] blendShapes = new MBBlendShape[0];

		[SerializeField]
		internal MBBlendShape[] blendShapesInCombined = new MBBlendShape[0];

		[SerializeField]
		private SerializableIntArray[] submeshTris = new SerializableIntArray[0];

		[SerializeField]
		private Mesh _mesh;

		private BoneWeight[] boneWeights = new BoneWeight[0];

		private GameObject[] empty = new GameObject[0];

		private int[] emptyIDs = new int[0];

		public override MB2_TextureBakeResults textureBakeResults
		{
			set
			{
				if (mbDynamicObjectsInCombinedMesh.Count > 0 && _textureBakeResults != value && _textureBakeResults != null && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("If Texture Bake Result is changed then objects currently in combined mesh may be invalid.");
				}
				_textureBakeResults = value;
			}
		}

		public override MB_RenderType renderType
		{
			set
			{
				if (value == MB_RenderType.skinnedMeshRenderer && _renderType == MB_RenderType.meshRenderer && boneWeights.Length != verts.Length)
				{
					UnityEngine.Debug.LogError("Can't set the render type to SkinnedMeshRenderer without clearing the mesh first. Try deleteing the CombinedMesh scene object.");
				}
				_renderType = value;
			}
		}

		public override GameObject resultSceneObject
		{
			set
			{
				if (_resultSceneObject != value)
				{
					_targetRenderer = null;
					if (_mesh != null && _LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Result Scene Object was changed when this mesh baker component had a reference to a mesh. If mesh is being used by another object make sure to reset the mesh to none before baking to avoid overwriting the other mesh.");
					}
				}
				_resultSceneObject = value;
			}
		}

		private MB_DynamicGameObject instance2Combined_MapGet(int gameObjectID)
		{
			return _instance2combined_map[gameObjectID];
		}

		private void instance2Combined_MapAdd(int gameObjectID, MB_DynamicGameObject dgo)
		{
			_instance2combined_map.Add(gameObjectID, dgo);
		}

		private void instance2Combined_MapRemove(int gameObjectID)
		{
			_instance2combined_map.Remove(gameObjectID);
		}

		private bool instance2Combined_MapTryGetValue(int gameObjectID, out MB_DynamicGameObject dgo)
		{
			return _instance2combined_map.TryGetValue(gameObjectID, out dgo);
		}

		private int instance2Combined_MapCount()
		{
			return _instance2combined_map.Count;
		}

		private void instance2Combined_MapClear()
		{
			_instance2combined_map.Clear();
		}

		private bool instance2Combined_MapContainsKey(int gameObjectID)
		{
			return _instance2combined_map.ContainsKey(gameObjectID);
		}

		public override int GetNumObjectsInCombined()
		{
			return mbDynamicObjectsInCombinedMesh.Count;
		}

		public override List<GameObject> GetObjectsInCombined()
		{
			List<GameObject> list = new List<GameObject>();
			list.AddRange(objectsInCombinedMesh);
			return list;
		}

		public Mesh GetMesh()
		{
			if (_mesh == null)
			{
				_mesh = new Mesh();
			}
			return _mesh;
		}

		public void SetMesh(Mesh m)
		{
			_mesh = m;
		}

		public Transform[] GetBones()
		{
			return bones;
		}

		public override int GetLightmapIndex()
		{
			if (lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout || lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
			{
				return lightmapIndex;
			}
			return -1;
		}

		public override int GetNumVerticesFor(GameObject go)
		{
			return GetNumVerticesFor(go.GetInstanceID());
		}

		public override int GetNumVerticesFor(int instanceID)
		{
			if (instance2Combined_MapTryGetValue(instanceID, out var dgo))
			{
				return dgo.numVerts;
			}
			return -1;
		}

		public override Dictionary<MBBlendShapeKey, MBBlendShapeValue> BuildSourceBlendShapeToCombinedIndexMap()
		{
			Dictionary<MBBlendShapeKey, MBBlendShapeValue> dictionary = new Dictionary<MBBlendShapeKey, MBBlendShapeValue>();
			for (int i = 0; i < blendShapesInCombined.Length; i++)
			{
				MBBlendShapeValue mBBlendShapeValue = new MBBlendShapeValue();
				mBBlendShapeValue.combinedMeshGameObject = _targetRenderer.gameObject;
				mBBlendShapeValue.blendShapeIndex = i;
				dictionary.Add(new MBBlendShapeKey(blendShapesInCombined[i].gameObjectID, blendShapesInCombined[i].indexInSource), mBBlendShapeValue);
			}
			return dictionary;
		}

		private void _initialize(int numResultMats)
		{
			if (mbDynamicObjectsInCombinedMesh.Count == 0)
			{
				lightmapIndex = -1;
			}
			if (_mesh == null)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("_initialize Creating new Mesh");
				}
				_mesh = GetMesh();
			}
			if (instance2Combined_MapCount() != mbDynamicObjectsInCombinedMesh.Count)
			{
				instance2Combined_MapClear();
				for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
				{
					if (mbDynamicObjectsInCombinedMesh[i] != null)
					{
						instance2Combined_MapAdd(mbDynamicObjectsInCombinedMesh[i].instanceID, mbDynamicObjectsInCombinedMesh[i]);
					}
				}
				boneWeights = _mesh.boneWeights;
			}
			if (objectsInCombinedMesh.Count == 0 && submeshTris.Length != numResultMats)
			{
				submeshTris = new SerializableIntArray[numResultMats];
				for (int j = 0; j < submeshTris.Length; j++)
				{
					submeshTris[j] = new SerializableIntArray(0);
				}
			}
			if (mbDynamicObjectsInCombinedMesh.Count > 0 && mbDynamicObjectsInCombinedMesh[0].indexesOfBonesUsed.Length == 0 && renderType == MB_RenderType.skinnedMeshRenderer && boneWeights.Length != 0)
			{
				for (int k = 0; k < mbDynamicObjectsInCombinedMesh.Count; k++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[k];
					HashSet<int> hashSet = new HashSet<int>();
					for (int l = mB_DynamicGameObject.vertIdx; l < mB_DynamicGameObject.vertIdx + mB_DynamicGameObject.numVerts; l++)
					{
						if (boneWeights[l].weight0 > 0f)
						{
							hashSet.Add(boneWeights[l].boneIndex0);
						}
						if (boneWeights[l].weight1 > 0f)
						{
							hashSet.Add(boneWeights[l].boneIndex1);
						}
						if (boneWeights[l].weight2 > 0f)
						{
							hashSet.Add(boneWeights[l].boneIndex2);
						}
						if (boneWeights[l].weight3 > 0f)
						{
							hashSet.Add(boneWeights[l].boneIndex3);
						}
					}
					mB_DynamicGameObject.indexesOfBonesUsed = new int[hashSet.Count];
					hashSet.CopyTo(mB_DynamicGameObject.indexesOfBonesUsed);
				}
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("Baker used old systems that duplicated bones. Upgrading to new system by building indexesOfBonesUsed");
				}
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log($"_initialize numObjsInCombined={mbDynamicObjectsInCombinedMesh.Count}");
			}
		}

		private bool _collectMaterialTriangles(Mesh m, MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map)
		{
			int num = m.subMeshCount;
			if (sharedMaterials.Length < num)
			{
				num = sharedMaterials.Length;
			}
			dgo._tmpSubmeshTris = new SerializableIntArray[num];
			dgo.targetSubmeshIdxs = new int[num];
			for (int i = 0; i < num; i++)
			{
				if (_textureBakeResults.doMultiMaterial)
				{
					if (!sourceMats2submeshIdx_map.Contains(sharedMaterials[i]))
					{
						UnityEngine.Debug.LogError("Object " + dgo.name + " has a material that was not found in the result materials maping. " + sharedMaterials[i]);
						return false;
					}
					dgo.targetSubmeshIdxs[i] = (int)sourceMats2submeshIdx_map[sharedMaterials[i]];
				}
				else
				{
					dgo.targetSubmeshIdxs[i] = 0;
				}
				dgo._tmpSubmeshTris[i] = new SerializableIntArray();
				dgo._tmpSubmeshTris[i].data = m.GetTriangles(i);
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Collecting triangles for: " + dgo.name + " submesh:" + i + " maps to submesh:" + dgo.targetSubmeshIdxs[i] + " added:" + dgo._tmpSubmeshTris[i].data.Length, LOG_LEVEL);
				}
			}
			return true;
		}

		private bool _collectOutOfBoundsUVRects2(Mesh m, MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResults, MeshChannelsCache meshChannelCache)
		{
			if (_textureBakeResults == null)
			{
				UnityEngine.Debug.LogError("Need to bake textures into combined material");
				return false;
			}
			if (meshAnalysisResults.TryGetValue(m.GetInstanceID(), out var value))
			{
				dgo.obUVRects = new Rect[sharedMaterials.Length];
				for (int i = 0; i < dgo.obUVRects.Length; i++)
				{
					dgo.obUVRects[i] = value[i].uvRect;
				}
			}
			else
			{
				int subMeshCount = m.subMeshCount;
				int num = subMeshCount;
				if (sharedMaterials.Length < subMeshCount)
				{
					num = sharedMaterials.Length;
				}
				dgo.obUVRects = new Rect[num];
				value = new MB_Utility.MeshAnalysisResult[subMeshCount];
				for (int j = 0; j < subMeshCount; j++)
				{
					int num2 = dgo.targetSubmeshIdxs[j];
					if (_textureBakeResults.resultMaterials[num2].considerMeshUVs)
					{
						MB_Utility.hasOutOfBoundsUVs(meshChannelCache.GetUv0Raw(m), m, ref value[j], j);
						Rect uvRect = value[j].uvRect;
						if (j < num)
						{
							dgo.obUVRects[j] = uvRect;
						}
					}
				}
				meshAnalysisResults.Add(m.GetInstanceID(), value);
			}
			return true;
		}

		private bool _validateTextureBakeResults()
		{
			if (_textureBakeResults == null)
			{
				UnityEngine.Debug.LogError("Texture Bake Results is null. Can't combine meshes.");
				return false;
			}
			if (_textureBakeResults.materialsAndUVRects == null || _textureBakeResults.materialsAndUVRects.Length == 0)
			{
				UnityEngine.Debug.LogError("Texture Bake Results has no materials in material to sourceUVRect map. Try baking materials. Can't combine meshes.");
				return false;
			}
			if (_textureBakeResults.resultMaterials == null || _textureBakeResults.resultMaterials.Length == 0)
			{
				UnityEngine.Debug.LogError("Texture Bake Results has no result materials. Try baking materials. Can't combine meshes.");
				return false;
			}
			return true;
		}

		private bool _validateMeshFlags()
		{
			if (mbDynamicObjectsInCombinedMesh.Count > 0 && ((!_doNorm && doNorm) || (!_doTan && doTan) || (!_doCol && doCol) || (!_doUV && doUV) || (!_doUV3 && doUV3) || (!_doUV4 && doUV4)))
			{
				UnityEngine.Debug.LogError("The channels have changed. There are already objects in the combined mesh that were added with a different set of channels.");
				return false;
			}
			_doNorm = doNorm;
			_doTan = doTan;
			_doCol = doCol;
			_doUV = doUV;
			_doUV3 = doUV3;
			_doUV4 = doUV4;
			return true;
		}

		private bool _showHide(GameObject[] goToShow, GameObject[] goToHide)
		{
			if (goToShow == null)
			{
				goToShow = empty;
			}
			if (goToHide == null)
			{
				goToHide = empty;
			}
			int numResultMats = _textureBakeResults.resultMaterials.Length;
			_initialize(numResultMats);
			for (int i = 0; i < goToHide.Length; i++)
			{
				if (!instance2Combined_MapContainsKey(goToHide[i].GetInstanceID()))
				{
					if (LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Trying to hide an object " + goToHide[i]?.ToString() + " that is not in combined mesh. Did you initially bake with 'clear buffers after bake' enabled?");
					}
					return false;
				}
			}
			for (int j = 0; j < goToShow.Length; j++)
			{
				if (!instance2Combined_MapContainsKey(goToShow[j].GetInstanceID()))
				{
					if (LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Trying to show an object " + goToShow[j]?.ToString() + " that is not in combined mesh. Did you initially bake with 'clear buffers after bake' enabled?");
					}
					return false;
				}
			}
			for (int k = 0; k < goToHide.Length; k++)
			{
				_instance2combined_map[goToHide[k].GetInstanceID()].show = false;
			}
			for (int l = 0; l < goToShow.Length; l++)
			{
				_instance2combined_map[goToShow[l].GetInstanceID()].show = true;
			}
			return true;
		}

		private bool _addToCombined(GameObject[] goToAdd, int[] goToDelete, bool disableRendererInSource)
		{
			Stopwatch stopwatch = null;
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				stopwatch = new Stopwatch();
				stopwatch.Start();
			}
			if (!_validateTextureBakeResults())
			{
				return false;
			}
			if (!_validateMeshFlags())
			{
				return false;
			}
			if (!ValidateTargRendererAndMeshAndResultSceneObj())
			{
				return false;
			}
			if (outputOption != MB2_OutputOptions.bakeMeshAssetsInPlace && renderType == MB_RenderType.skinnedMeshRenderer && (_targetRenderer == null || !(_targetRenderer is SkinnedMeshRenderer)))
			{
				UnityEngine.Debug.LogError("Target renderer must be set and must be a SkinnedMeshRenderer");
				return false;
			}
			if (_doBlendShapes && renderType != MB_RenderType.skinnedMeshRenderer)
			{
				UnityEngine.Debug.LogError("If doBlendShapes is set then RenderType must be skinnedMeshRenderer.");
				return false;
			}
			GameObject[] _goToAdd;
			if (goToAdd == null)
			{
				_goToAdd = empty;
			}
			else
			{
				_goToAdd = (GameObject[])goToAdd.Clone();
			}
			int[] array = ((goToDelete != null) ? ((int[])goToDelete.Clone()) : emptyIDs);
			if (_mesh == null)
			{
				DestroyMesh();
			}
			MB2_TextureBakeResults.Material2AtlasRectangleMapper material2AtlasRectangleMapper = new MB2_TextureBakeResults.Material2AtlasRectangleMapper(textureBakeResults);
			int num = _textureBakeResults.resultMaterials.Length;
			_initialize(num);
			if (submeshTris.Length != num)
			{
				UnityEngine.Debug.LogError("The number of submeshes " + submeshTris.Length + " in the combined mesh was not equal to the number of result materials " + num + " in the Texture Bake Result");
				return false;
			}
			if (_mesh.vertexCount > 0 && _instance2combined_map.Count == 0)
			{
				UnityEngine.Debug.LogWarning("There were vertices in the combined mesh but nothing in the MeshBaker buffers. If you are trying to bake in the editor and modify at runtime, make sure 'Clear Buffers After Bake' is unchecked.");
			}
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("==== Calling _addToCombined objs adding:" + _goToAdd.Length + " objs deleting:" + array.Length + " fixOutOfBounds:" + textureBakeResults.DoAnyResultMatsUseConsiderMeshUVs() + " doMultiMaterial:" + textureBakeResults.doMultiMaterial + " disableRenderersInSource:" + disableRendererInSource, LOG_LEVEL);
			}
			if (_textureBakeResults.resultMaterials == null || _textureBakeResults.resultMaterials.Length == 0)
			{
				UnityEngine.Debug.LogError("No resultMaterials in this TextureBakeResults. Try baking textures.");
				return false;
			}
			OrderedDictionary orderedDictionary = BuildSourceMatsToSubmeshIdxMap(num);
			if (orderedDictionary == null)
			{
				return false;
			}
			int num2 = 0;
			int[] array2 = new int[num];
			int num3 = 0;
			List<MB_DynamicGameObject>[] array3 = null;
			HashSet<int> hashSet = new HashSet<int>();
			HashSet<BoneAndBindpose> hashSet2 = new HashSet<BoneAndBindpose>();
			if (renderType == MB_RenderType.skinnedMeshRenderer && array.Length != 0)
			{
				array3 = _buildBoneIdx2dgoMap();
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (instance2Combined_MapTryGetValue(array[i], out var dgo))
				{
					num2 += dgo.numVerts;
					num3 += dgo.numBlendShapes;
					if (renderType == MB_RenderType.skinnedMeshRenderer)
					{
						for (int j = 0; j < dgo.indexesOfBonesUsed.Length; j++)
						{
							if (array3[dgo.indexesOfBonesUsed[j]].Contains(dgo))
							{
								array3[dgo.indexesOfBonesUsed[j]].Remove(dgo);
								if (array3[dgo.indexesOfBonesUsed[j]].Count == 0)
								{
									hashSet.Add(dgo.indexesOfBonesUsed[j]);
								}
							}
						}
					}
					for (int k = 0; k < dgo.submeshNumTris.Length; k++)
					{
						array2[k] += dgo.submeshNumTris[k];
					}
				}
				else if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Trying to delete an object that is not in combined mesh");
				}
			}
			List<MB_DynamicGameObject> list = new List<MB_DynamicGameObject>();
			Dictionary<int, MB_Utility.MeshAnalysisResult[]> dictionary = new Dictionary<int, MB_Utility.MeshAnalysisResult[]>();
			MeshChannelsCache meshChannelsCache = new MeshChannelsCache(this);
			int num4 = 0;
			int[] array4 = new int[num];
			int num5 = 0;
			Dictionary<Transform, int> dictionary2 = new Dictionary<Transform, int>();
			for (int l = 0; l < bones.Length; l++)
			{
				dictionary2.Add(bones[l], l);
			}
			int m;
			for (m = 0; m < _goToAdd.Length; m++)
			{
				if (!instance2Combined_MapContainsKey(_goToAdd[m].GetInstanceID()) || Array.FindIndex(array, (int o) => o == _goToAdd[m].GetInstanceID()) != -1)
				{
					MB_DynamicGameObject mB_DynamicGameObject = new MB_DynamicGameObject();
					GameObject gameObject = _goToAdd[m];
					Material[] gOMaterials = MB_Utility.GetGOMaterials(gameObject);
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						UnityEngine.Debug.Log($"Getting {gOMaterials.Length} shared materials for {gameObject}");
					}
					if (gOMaterials == null)
					{
						UnityEngine.Debug.LogError("Object " + gameObject.name + " does not have a Renderer");
						_goToAdd[m] = null;
						return false;
					}
					Mesh mesh = MB_Utility.GetMesh(gameObject);
					if (mesh == null)
					{
						UnityEngine.Debug.LogError("Object " + gameObject.name + " MeshFilter or SkinedMeshRenderer had no mesh");
						_goToAdd[m] = null;
						return false;
					}
					if (MBVersion.IsRunningAndMeshNotReadWriteable(mesh))
					{
						UnityEngine.Debug.LogError("Object " + gameObject.name + " Mesh Importer has read/write flag set to 'false'. This needs to be set to 'true' in order to read data from this mesh.");
						_goToAdd[m] = null;
						return false;
					}
					MB_TextureTilingTreatment[] array5 = new MB_TextureTilingTreatment[gOMaterials.Length];
					Rect[] array6 = new Rect[gOMaterials.Length];
					Rect[] array7 = new Rect[gOMaterials.Length];
					Rect[] array8 = new Rect[gOMaterials.Length];
					string errorMsg = "";
					for (int num6 = 0; num6 < gOMaterials.Length; num6++)
					{
						object obj = orderedDictionary[gOMaterials[num6]];
						if (obj == null)
						{
							UnityEngine.Debug.LogError("Source object " + gameObject.name + " used a material " + gOMaterials[num6]?.ToString() + " that was not in the baked materials.");
							return false;
						}
						int idxInResultMats = (int)obj;
						if (!material2AtlasRectangleMapper.TryMapMaterialToUVRect(gOMaterials[num6], mesh, num6, idxInResultMats, meshChannelsCache, dictionary, out array5[num6], out array6[num6], out array7[num6], out array8[num6], ref errorMsg, LOG_LEVEL))
						{
							UnityEngine.Debug.LogError(errorMsg);
							_goToAdd[m] = null;
							return false;
						}
					}
					if (!(_goToAdd[m] != null))
					{
						continue;
					}
					list.Add(mB_DynamicGameObject);
					mB_DynamicGameObject.name = $"{_goToAdd[m].ToString()} {_goToAdd[m].GetInstanceID()}";
					mB_DynamicGameObject.instanceID = _goToAdd[m].GetInstanceID();
					mB_DynamicGameObject.uvRects = array6;
					mB_DynamicGameObject.encapsulatingRect = array7;
					mB_DynamicGameObject.sourceMaterialTiling = array8;
					mB_DynamicGameObject.numVerts = mesh.vertexCount;
					if (_doBlendShapes)
					{
						mB_DynamicGameObject.numBlendShapes = mesh.blendShapeCount;
					}
					Renderer renderer = MB_Utility.GetRenderer(gameObject);
					if (renderType == MB_RenderType.skinnedMeshRenderer)
					{
						_CollectBonesToAddForDGO(mB_DynamicGameObject, dictionary2, hashSet, hashSet2, renderer, meshChannelsCache);
					}
					if (lightmapIndex == -1)
					{
						lightmapIndex = renderer.lightmapIndex;
					}
					if (lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
					{
						if (lightmapIndex != renderer.lightmapIndex && LOG_LEVEL >= MB2_LogLevel.warn)
						{
							UnityEngine.Debug.LogWarning("Object " + gameObject.name + " has a different lightmap index. Lightmapping will not work.");
						}
						if (!MBVersion.GetActive(gameObject) && LOG_LEVEL >= MB2_LogLevel.warn)
						{
							UnityEngine.Debug.LogWarning("Object " + gameObject.name + " is inactive. Can only get lightmap index of active objects.");
						}
						if (renderer.lightmapIndex == -1 && LOG_LEVEL >= MB2_LogLevel.warn)
						{
							UnityEngine.Debug.LogWarning("Object " + gameObject.name + " does not have an index to a lightmap.");
						}
					}
					mB_DynamicGameObject.lightmapIndex = renderer.lightmapIndex;
					mB_DynamicGameObject.lightmapTilingOffset = MBVersion.GetLightmapTilingOffset(renderer);
					if (!_collectMaterialTriangles(mesh, mB_DynamicGameObject, gOMaterials, orderedDictionary))
					{
						return false;
					}
					mB_DynamicGameObject.meshSize = renderer.bounds.size;
					mB_DynamicGameObject.submeshNumTris = new int[num];
					mB_DynamicGameObject.submeshTriIdxs = new int[num];
					if (textureBakeResults.DoAnyResultMatsUseConsiderMeshUVs() && !_collectOutOfBoundsUVRects2(mesh, mB_DynamicGameObject, gOMaterials, orderedDictionary, dictionary, meshChannelsCache))
					{
						return false;
					}
					num4 += mB_DynamicGameObject.numVerts;
					num5 += mB_DynamicGameObject.numBlendShapes;
					for (int num7 = 0; num7 < mB_DynamicGameObject._tmpSubmeshTris.Length; num7++)
					{
						array4[mB_DynamicGameObject.targetSubmeshIdxs[num7]] += mB_DynamicGameObject._tmpSubmeshTris[num7].data.Length;
					}
					mB_DynamicGameObject.invertTriangles = IsMirrored(gameObject.transform.localToWorldMatrix);
				}
				else
				{
					if (LOG_LEVEL >= MB2_LogLevel.warn)
					{
						UnityEngine.Debug.LogWarning("Object " + _goToAdd[m].name + " has already been added");
					}
					_goToAdd[m] = null;
				}
			}
			for (int num8 = 0; num8 < _goToAdd.Length; num8++)
			{
				if (_goToAdd[num8] != null && disableRendererInSource)
				{
					MB_Utility.DisableRendererInSource(_goToAdd[num8]);
					if (LOG_LEVEL == MB2_LogLevel.trace)
					{
						UnityEngine.Debug.Log("Disabling renderer on " + _goToAdd[num8].name + " id=" + _goToAdd[num8].GetInstanceID());
					}
				}
			}
			int num9 = verts.Length + num4 - num2;
			int num10 = bindPoses.Length + hashSet2.Count - hashSet.Count;
			int[] array9 = new int[num];
			int num11 = blendShapes.Length + num5 - num3;
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Verts adding:" + num4 + " deleting:" + num2 + " submeshes:" + array9.Length + " bones:" + num10 + " blendShapes:" + num11);
			}
			for (int num12 = 0; num12 < array9.Length; num12++)
			{
				array9[num12] = submeshTris[num12].data.Length + array4[num12] - array2[num12];
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("    submesh :" + num12 + " already contains:" + submeshTris[num12].data.Length + " tris to be Added:" + array4[num12] + " tris to be Deleted:" + array2[num12]);
				}
			}
			if (num9 >= MBVersion.MaxMeshVertexCount())
			{
				UnityEngine.Debug.LogError("Cannot add objects. Resulting mesh will have more than " + MBVersion.MaxMeshVertexCount() + " vertices. Try using a Multi-MeshBaker component. This will split the combined mesh into several meshes. You don't have to re-configure the MB2_TextureBaker. Just remove the MB2_MeshBaker component and add a MB2_MultiMeshBaker component.");
				return false;
			}
			Vector3[] destinationArray = null;
			Vector4[] destinationArray2 = null;
			Vector2[] destinationArray3 = null;
			Vector2[] destinationArray4 = null;
			Vector2[] destinationArray5 = null;
			Vector2[] destinationArray6 = null;
			Color[] destinationArray7 = null;
			MBBlendShape[] array10 = null;
			Vector3[] destinationArray8 = new Vector3[num9];
			if (_doNorm)
			{
				destinationArray = new Vector3[num9];
			}
			if (_doTan)
			{
				destinationArray2 = new Vector4[num9];
			}
			if (_doUV)
			{
				destinationArray3 = new Vector2[num9];
			}
			if (_doUV3)
			{
				destinationArray5 = new Vector2[num9];
			}
			if (_doUV4)
			{
				destinationArray6 = new Vector2[num9];
			}
			if (doUV2())
			{
				destinationArray4 = new Vector2[num9];
			}
			if (_doCol)
			{
				destinationArray7 = new Color[num9];
			}
			if (_doBlendShapes)
			{
				array10 = new MBBlendShape[num11];
			}
			BoneWeight[] array11 = new BoneWeight[num9];
			Matrix4x4[] array12 = new Matrix4x4[num10];
			Transform[] array13 = new Transform[num10];
			SerializableIntArray[] array14 = new SerializableIntArray[num];
			for (int num13 = 0; num13 < array14.Length; num13++)
			{
				array14[num13] = new SerializableIntArray(array9[num13]);
			}
			for (int num14 = 0; num14 < array.Length; num14++)
			{
				MB_DynamicGameObject dgo2 = null;
				if (instance2Combined_MapTryGetValue(array[num14], out dgo2))
				{
					dgo2._beingDeleted = true;
				}
			}
			mbDynamicObjectsInCombinedMesh.Sort();
			int num15 = 0;
			int num16 = 0;
			int[] array15 = new int[num];
			int num17 = 0;
			for (int num18 = 0; num18 < mbDynamicObjectsInCombinedMesh.Count; num18++)
			{
				MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[num18];
				if (!mB_DynamicGameObject2._beingDeleted)
				{
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Copying obj in combined arrays idx:" + num18, LOG_LEVEL);
					}
					Array.Copy(verts, mB_DynamicGameObject2.vertIdx, destinationArray8, num15, mB_DynamicGameObject2.numVerts);
					if (_doNorm)
					{
						Array.Copy(normals, mB_DynamicGameObject2.vertIdx, destinationArray, num15, mB_DynamicGameObject2.numVerts);
					}
					if (_doTan)
					{
						Array.Copy(tangents, mB_DynamicGameObject2.vertIdx, destinationArray2, num15, mB_DynamicGameObject2.numVerts);
					}
					if (_doUV)
					{
						Array.Copy(uvs, mB_DynamicGameObject2.vertIdx, destinationArray3, num15, mB_DynamicGameObject2.numVerts);
					}
					if (_doUV3)
					{
						Array.Copy(uv3s, mB_DynamicGameObject2.vertIdx, destinationArray5, num15, mB_DynamicGameObject2.numVerts);
					}
					if (_doUV4)
					{
						Array.Copy(uv4s, mB_DynamicGameObject2.vertIdx, destinationArray6, num15, mB_DynamicGameObject2.numVerts);
					}
					if (doUV2())
					{
						Array.Copy(uv2s, mB_DynamicGameObject2.vertIdx, destinationArray4, num15, mB_DynamicGameObject2.numVerts);
					}
					if (_doCol)
					{
						Array.Copy(colors, mB_DynamicGameObject2.vertIdx, destinationArray7, num15, mB_DynamicGameObject2.numVerts);
					}
					if (_doBlendShapes)
					{
						Array.Copy(blendShapes, mB_DynamicGameObject2.blendShapeIdx, array10, num16, mB_DynamicGameObject2.numBlendShapes);
					}
					if (renderType == MB_RenderType.skinnedMeshRenderer)
					{
						Array.Copy(boneWeights, mB_DynamicGameObject2.vertIdx, array11, num15, mB_DynamicGameObject2.numVerts);
					}
					for (int num19 = 0; num19 < num; num19++)
					{
						int[] data = submeshTris[num19].data;
						int num20 = mB_DynamicGameObject2.submeshTriIdxs[num19];
						int num21 = mB_DynamicGameObject2.submeshNumTris[num19];
						if (LOG_LEVEL >= MB2_LogLevel.debug)
						{
							MB2_Log.LogDebug("    Adjusting submesh triangles submesh:" + num19 + " startIdx:" + num20 + " num:" + num21 + " nsubmeshTris:" + array14.Length + " targSubmeshTidx:" + array15.Length, LOG_LEVEL);
						}
						for (int num22 = num20; num22 < num20 + num21; num22++)
						{
							data[num22] -= num17;
						}
						Array.Copy(data, num20, array14[num19].data, array15[num19], num21);
					}
					mB_DynamicGameObject2.vertIdx = num15;
					mB_DynamicGameObject2.blendShapeIdx = num16;
					for (int num23 = 0; num23 < array15.Length; num23++)
					{
						mB_DynamicGameObject2.submeshTriIdxs[num23] = array15[num23];
						array15[num23] += mB_DynamicGameObject2.submeshNumTris[num23];
					}
					num16 += mB_DynamicGameObject2.numBlendShapes;
					num15 += mB_DynamicGameObject2.numVerts;
				}
				else
				{
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Not copying obj: " + num18, LOG_LEVEL);
					}
					num17 += mB_DynamicGameObject2.numVerts;
				}
			}
			if (renderType == MB_RenderType.skinnedMeshRenderer)
			{
				_CopyBonesWeAreKeepingToNewBonesArrayAndAdjustBWIndexes(hashSet, hashSet2, array13, array12, array11, num2);
			}
			for (int num24 = mbDynamicObjectsInCombinedMesh.Count - 1; num24 >= 0; num24--)
			{
				if (mbDynamicObjectsInCombinedMesh[num24]._beingDeleted)
				{
					instance2Combined_MapRemove(mbDynamicObjectsInCombinedMesh[num24].instanceID);
					objectsInCombinedMesh.RemoveAt(num24);
					mbDynamicObjectsInCombinedMesh.RemoveAt(num24);
				}
			}
			verts = destinationArray8;
			if (_doNorm)
			{
				normals = destinationArray;
			}
			if (_doTan)
			{
				tangents = destinationArray2;
			}
			if (_doUV)
			{
				uvs = destinationArray3;
			}
			if (_doUV3)
			{
				uv3s = destinationArray5;
			}
			if (_doUV4)
			{
				uv4s = destinationArray6;
			}
			if (doUV2())
			{
				uv2s = destinationArray4;
			}
			if (_doCol)
			{
				colors = destinationArray7;
			}
			if (_doBlendShapes)
			{
				blendShapes = array10;
			}
			if (renderType == MB_RenderType.skinnedMeshRenderer)
			{
				boneWeights = array11;
			}
			int num25 = bones.Length - hashSet.Count;
			bindPoses = array12;
			bones = array13;
			submeshTris = array14;
			int num26 = 0;
			foreach (BoneAndBindpose item in hashSet2)
			{
				array13[num25 + num26] = item.bone;
				array12[num25 + num26] = item.bindPose;
				num26++;
			}
			for (int num27 = 0; num27 < list.Count; num27++)
			{
				MB_DynamicGameObject mB_DynamicGameObject3 = list[num27];
				GameObject gameObject2 = _goToAdd[num27];
				int num28 = num15;
				int index = num16;
				Mesh mesh2 = MB_Utility.GetMesh(gameObject2);
				Matrix4x4 localToWorldMatrix = gameObject2.transform.localToWorldMatrix;
				Matrix4x4 matrix4x = localToWorldMatrix;
				float num29 = (matrix4x[2, 3] = 0f);
				float value = (matrix4x[1, 3] = num29);
				matrix4x[0, 3] = value;
				destinationArray8 = meshChannelsCache.GetVertices(mesh2);
				Vector3[] array16 = null;
				Vector4[] array17 = null;
				if (_doNorm)
				{
					array16 = meshChannelsCache.GetNormals(mesh2);
				}
				if (_doTan)
				{
					array17 = meshChannelsCache.GetTangents(mesh2);
				}
				if (renderType != MB_RenderType.skinnedMeshRenderer)
				{
					for (int num32 = 0; num32 < destinationArray8.Length; num32++)
					{
						int num33 = num28 + num32;
						verts[num28 + num32] = localToWorldMatrix.MultiplyPoint3x4(destinationArray8[num32]);
						if (_doNorm)
						{
							normals[num33] = matrix4x.MultiplyPoint3x4(array16[num32]);
							normals[num33] = normals[num33].normalized;
						}
						if (_doTan)
						{
							float w = array17[num32].w;
							Vector3 vector = matrix4x.MultiplyPoint3x4(array17[num32]);
							vector.Normalize();
							tangents[num33] = vector;
							tangents[num33].w = w;
						}
					}
				}
				else
				{
					if (_doNorm)
					{
						array16.CopyTo(normals, num28);
					}
					if (_doTan)
					{
						array17.CopyTo(tangents, num28);
					}
					destinationArray8.CopyTo(verts, num28);
				}
				int subMeshCount = mesh2.subMeshCount;
				if (mB_DynamicGameObject3.uvRects.Length < subMeshCount)
				{
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Mesh " + mB_DynamicGameObject3.name + " has more submeshes than materials");
					}
					subMeshCount = mB_DynamicGameObject3.uvRects.Length;
				}
				else if (mB_DynamicGameObject3.uvRects.Length > subMeshCount && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + mB_DynamicGameObject3.name + " has fewer submeshes than materials");
				}
				if (_doUV)
				{
					_copyAndAdjustUVsFromMesh(mB_DynamicGameObject3, mesh2, num28, meshChannelsCache);
				}
				if (doUV2())
				{
					_copyAndAdjustUV2FromMesh(mB_DynamicGameObject3, mesh2, num28, meshChannelsCache);
				}
				if (_doUV3)
				{
					destinationArray5 = meshChannelsCache.GetUv3(mesh2);
					destinationArray5.CopyTo(uv3s, num28);
				}
				if (_doUV4)
				{
					destinationArray6 = meshChannelsCache.GetUv4(mesh2);
					destinationArray6.CopyTo(uv4s, num28);
				}
				if (_doCol)
				{
					destinationArray7 = meshChannelsCache.GetColors(mesh2);
					destinationArray7.CopyTo(colors, num28);
				}
				if (_doBlendShapes)
				{
					array10 = meshChannelsCache.GetBlendShapes(mesh2, mB_DynamicGameObject3.instanceID);
					array10.CopyTo(blendShapes, index);
				}
				if (renderType == MB_RenderType.skinnedMeshRenderer)
				{
					Renderer renderer2 = MB_Utility.GetRenderer(gameObject2);
					_AddBonesToNewBonesArrayAndAdjustBWIndexes(mB_DynamicGameObject3, renderer2, num28, array13, array11, meshChannelsCache);
				}
				for (int num34 = 0; num34 < array15.Length; num34++)
				{
					mB_DynamicGameObject3.submeshTriIdxs[num34] = array15[num34];
				}
				for (int num35 = 0; num35 < mB_DynamicGameObject3._tmpSubmeshTris.Length; num35++)
				{
					int[] data2 = mB_DynamicGameObject3._tmpSubmeshTris[num35].data;
					for (int num36 = 0; num36 < data2.Length; num36++)
					{
						data2[num36] += num28;
					}
					if (mB_DynamicGameObject3.invertTriangles)
					{
						for (int num37 = 0; num37 < data2.Length; num37 += 3)
						{
							int num38 = data2[num37];
							data2[num37] = data2[num37 + 1];
							data2[num37 + 1] = num38;
						}
					}
					int num39 = mB_DynamicGameObject3.targetSubmeshIdxs[num35];
					data2.CopyTo(submeshTris[num39].data, array15[num39]);
					mB_DynamicGameObject3.submeshNumTris[num39] += data2.Length;
					array15[num39] += data2.Length;
				}
				mB_DynamicGameObject3.vertIdx = num15;
				mB_DynamicGameObject3.blendShapeIdx = num16;
				instance2Combined_MapAdd(gameObject2.GetInstanceID(), mB_DynamicGameObject3);
				objectsInCombinedMesh.Add(gameObject2);
				mbDynamicObjectsInCombinedMesh.Add(mB_DynamicGameObject3);
				num15 += destinationArray8.Length;
				if (_doBlendShapes)
				{
					num16 += array10.Length;
				}
				for (int num40 = 0; num40 < mB_DynamicGameObject3._tmpSubmeshTris.Length; num40++)
				{
					mB_DynamicGameObject3._tmpSubmeshTris[num40] = null;
				}
				mB_DynamicGameObject3._tmpSubmeshTris = null;
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Added to combined:" + mB_DynamicGameObject3.name + " verts:" + destinationArray8.Length + " bindPoses:" + array12.Length, LOG_LEVEL);
				}
			}
			if (lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged_to_separate_rects)
			{
				_copyUV2unchangedToSeparateRects();
			}
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("===== _addToCombined completed. Verts in buffer: " + verts.Length + " time(ms): " + stopwatch.ElapsedMilliseconds, LOG_LEVEL);
			}
			return true;
		}

		private void _copyAndAdjustUVsFromMesh(MB_DynamicGameObject dgo, Mesh mesh, int vertsIdx, MeshChannelsCache meshChannelsCache)
		{
			Vector2[] uv0Raw = meshChannelsCache.GetUv0Raw(mesh);
			int[] array = new int[uv0Raw.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			bool flag = false;
			for (int j = 0; j < dgo.targetSubmeshIdxs.Length; j++)
			{
				int[] array2 = ((dgo._tmpSubmeshTris == null) ? mesh.GetTriangles(j) : dgo._tmpSubmeshTris[j].data);
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log($"Build UV transform for mesh {dgo.name} submesh {j} encapsulatingRect {dgo.encapsulatingRect[j]}");
				}
				Rect rect = MB3_TextureCombinerMerging.BuildTransformMeshUV2AtlasRect(textureBakeResults.resultMaterials[dgo.targetSubmeshIdxs[j]].considerMeshUVs, dgo.uvRects[j], (dgo.obUVRects == null) ? new Rect(0f, 0f, 1f, 1f) : dgo.obUVRects[j], dgo.sourceMaterialTiling[j], dgo.encapsulatingRect[j]);
				foreach (int num in array2)
				{
					if (array[num] == -1)
					{
						array[num] = j;
						Vector2 vector = uv0Raw[num];
						vector.x = rect.x + vector.x * rect.width;
						vector.y = rect.y + vector.y * rect.height;
						uvs[vertsIdx + num] = vector;
					}
					if (array[num] != j)
					{
						flag = true;
					}
				}
			}
			if (flag && LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning(dgo.name + "has submeshes which share verticies. Adjusted uvs may not map correctly in combined atlas.");
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log($"_copyAndAdjustUVsFromMesh copied {uv0Raw.Length} verts");
			}
		}

		private void _copyAndAdjustUV2FromMesh(MB_DynamicGameObject dgo, Mesh mesh, int vertsIdx, MeshChannelsCache meshChannelsCache)
		{
			Vector2[] uv = meshChannelsCache.GetUv2(mesh);
			if (lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
			{
				Vector4 lightmapTilingOffset = dgo.lightmapTilingOffset;
				Vector2 vector = new Vector2(lightmapTilingOffset.x, lightmapTilingOffset.y);
				Vector2 vector2 = new Vector2(lightmapTilingOffset.z, lightmapTilingOffset.w);
				Vector2 vector3 = default(Vector2);
				for (int i = 0; i < uv.Length; i++)
				{
					vector3.x = vector.x * uv[i].x;
					vector3.y = vector.y * uv[i].y;
					uv2s[vertsIdx + i] = vector2 + vector3;
				}
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log("_copyAndAdjustUV2FromMesh copied and modify for preserve current lightmapping " + uv.Length);
				}
			}
			else
			{
				uv.CopyTo(uv2s, vertsIdx);
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log("_copyAndAdjustUV2FromMesh copied without modifying " + uv.Length);
				}
			}
		}

		public override void UpdateSkinnedMeshApproximateBounds()
		{
			UpdateSkinnedMeshApproximateBoundsFromBounds();
		}

		public override void UpdateSkinnedMeshApproximateBoundsFromBones()
		{
			if (outputOption == MB2_OutputOptions.bakeMeshAssetsInPlace)
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Can't UpdateSkinnedMeshApproximateBounds when output type is bakeMeshAssetsInPlace");
				}
			}
			else if (bones.Length == 0)
			{
				if (verts.Length != 0 && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("No bones in SkinnedMeshRenderer. Could not UpdateSkinnedMeshApproximateBounds.");
				}
			}
			else if (_targetRenderer == null)
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Target Renderer is not set. No point in calling UpdateSkinnedMeshApproximateBounds.");
				}
			}
			else if (!_targetRenderer.GetType().Equals(typeof(SkinnedMeshRenderer)))
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Target Renderer is not a SkinnedMeshRenderer. No point in calling UpdateSkinnedMeshApproximateBounds.");
				}
			}
			else
			{
				MB3_MeshCombiner.UpdateSkinnedMeshApproximateBoundsFromBonesStatic(bones, (SkinnedMeshRenderer)targetRenderer);
			}
		}

		public override void UpdateSkinnedMeshApproximateBoundsFromBounds()
		{
			if (outputOption == MB2_OutputOptions.bakeMeshAssetsInPlace)
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Can't UpdateSkinnedMeshApproximateBoundsFromBounds when output type is bakeMeshAssetsInPlace");
				}
			}
			else if (verts.Length == 0 || mbDynamicObjectsInCombinedMesh.Count == 0)
			{
				if (verts.Length != 0 && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Nothing in SkinnedMeshRenderer. Could not UpdateSkinnedMeshApproximateBoundsFromBounds.");
				}
			}
			else if (_targetRenderer == null)
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Target Renderer is not set. No point in calling UpdateSkinnedMeshApproximateBoundsFromBounds.");
				}
			}
			else if (!_targetRenderer.GetType().Equals(typeof(SkinnedMeshRenderer)))
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Target Renderer is not a SkinnedMeshRenderer. No point in calling UpdateSkinnedMeshApproximateBoundsFromBounds.");
				}
			}
			else
			{
				MB3_MeshCombiner.UpdateSkinnedMeshApproximateBoundsFromBoundsStatic(objectsInCombinedMesh, (SkinnedMeshRenderer)targetRenderer);
			}
		}

		private int _getNumBones(Renderer r)
		{
			if (renderType == MB_RenderType.skinnedMeshRenderer)
			{
				if (r is SkinnedMeshRenderer)
				{
					return ((SkinnedMeshRenderer)r).bones.Length;
				}
				if (r is MeshRenderer)
				{
					return 1;
				}
				UnityEngine.Debug.LogError("Could not _getNumBones. Object does not have a renderer");
				return 0;
			}
			return 0;
		}

		private Transform[] _getBones(Renderer r)
		{
			return MBVersion.GetBones(r);
		}

		public override void Apply(GenerateUV2Delegate uv2GenerationMethod)
		{
			bool flag = false;
			if (renderType == MB_RenderType.skinnedMeshRenderer)
			{
				flag = true;
			}
			Apply(triangles: true, vertices: true, _doNorm, _doTan, _doUV, doUV2(), _doUV3, _doUV4, doCol, flag, doBlendShapes, uv2GenerationMethod);
		}

		public virtual void ApplyShowHide()
		{
			if (_validationLevel >= MB2_ValidationLevel.quick && !ValidateTargRendererAndMeshAndResultSceneObj())
			{
				return;
			}
			if (_mesh != null)
			{
				if (renderType == MB_RenderType.meshRenderer)
				{
					MBVersion.MeshClear(_mesh, t: true);
					_mesh.vertices = verts;
				}
				SerializableIntArray[] submeshTrisWithShowHideApplied = GetSubmeshTrisWithShowHideApplied();
				if (textureBakeResults.doMultiMaterial)
				{
					int num = (_mesh.subMeshCount = _numNonZeroLengthSubmeshTris(submeshTrisWithShowHideApplied));
					int numNonZeroLengthSubmeshTris = num;
					int num3 = 0;
					for (int i = 0; i < submeshTrisWithShowHideApplied.Length; i++)
					{
						if (submeshTrisWithShowHideApplied[i].data.Length != 0)
						{
							_mesh.SetTriangles(submeshTrisWithShowHideApplied[i].data, num3);
							num3++;
						}
					}
					_updateMaterialsOnTargetRenderer(submeshTrisWithShowHideApplied, numNonZeroLengthSubmeshTris);
				}
				else
				{
					_mesh.triangles = submeshTrisWithShowHideApplied[0].data;
				}
				if (renderType == MB_RenderType.skinnedMeshRenderer)
				{
					if (verts.Length == 0)
					{
						targetRenderer.enabled = false;
					}
					else
					{
						targetRenderer.enabled = true;
					}
					bool updateWhenOffscreen = ((SkinnedMeshRenderer)targetRenderer).updateWhenOffscreen;
					((SkinnedMeshRenderer)targetRenderer).updateWhenOffscreen = true;
					((SkinnedMeshRenderer)targetRenderer).updateWhenOffscreen = updateWhenOffscreen;
				}
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log("ApplyShowHide");
				}
			}
			else
			{
				UnityEngine.Debug.LogError("Need to add objects to this meshbaker before calling ApplyShowHide");
			}
		}

		public override void Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapesFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
		{
			Stopwatch stopwatch = null;
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				stopwatch = new Stopwatch();
				stopwatch.Start();
			}
			if (_validationLevel >= MB2_ValidationLevel.quick && !ValidateTargRendererAndMeshAndResultSceneObj())
			{
				return;
			}
			if (_mesh != null)
			{
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log($"Apply called tri={triangles} vert={vertices} norm={normals} tan={tangents} uv={uvs} col={colors} uv3={uv3} uv4={uv4} uv2={uv2} bone={bones} blendShape{blendShapes} meshID={_mesh.GetInstanceID()}");
				}
				if (triangles || _mesh.vertexCount != verts.Length)
				{
					bool justClearTriangles = triangles && !vertices && !normals && !tangents && !uvs && !colors && !uv3 && !uv4 && !uv2 && !bones;
					MBVersion.SetMeshIndexFormatAndClearMesh(_mesh, verts.Length, vertices, justClearTriangles);
				}
				if (vertices)
				{
					Vector3[] array = verts;
					if (verts.Length != 0)
					{
						if (_recenterVertsToBoundsCenter && _renderType == MB_RenderType.meshRenderer)
						{
							array = new Vector3[verts.Length];
							Vector3 vector = verts[0];
							Vector3 vector2 = verts[0];
							for (int i = 1; i < verts.Length; i++)
							{
								Vector3 vector3 = verts[i];
								if (vector.x < vector3.x)
								{
									vector.x = vector3.x;
								}
								if (vector.y < vector3.y)
								{
									vector.y = vector3.y;
								}
								if (vector.z < vector3.z)
								{
									vector.z = vector3.z;
								}
								if (vector2.x > vector3.x)
								{
									vector2.x = vector3.x;
								}
								if (vector2.y > vector3.y)
								{
									vector2.y = vector3.y;
								}
								if (vector2.z > vector3.z)
								{
									vector2.z = vector3.z;
								}
							}
							Vector3 vector4 = (vector + vector2) / 2f;
							for (int j = 0; j < verts.Length; j++)
							{
								array[j] = verts[j] - vector4;
							}
							targetRenderer.transform.position = vector4;
						}
						else
						{
							targetRenderer.transform.position = Vector3.zero;
						}
					}
					_mesh.vertices = array;
				}
				if (triangles && (bool)_textureBakeResults)
				{
					if (_textureBakeResults == null)
					{
						UnityEngine.Debug.LogError("Texture Bake Result was not set.");
					}
					else
					{
						SerializableIntArray[] submeshTrisWithShowHideApplied = GetSubmeshTrisWithShowHideApplied();
						int num = (_mesh.subMeshCount = _numNonZeroLengthSubmeshTris(submeshTrisWithShowHideApplied));
						int numNonZeroLengthSubmeshTris = num;
						int num3 = 0;
						for (int k = 0; k < submeshTrisWithShowHideApplied.Length; k++)
						{
							if (submeshTrisWithShowHideApplied[k].data.Length != 0)
							{
								_mesh.SetTriangles(submeshTrisWithShowHideApplied[k].data, num3);
								num3++;
							}
						}
						_updateMaterialsOnTargetRenderer(submeshTrisWithShowHideApplied, numNonZeroLengthSubmeshTris);
					}
				}
				if (normals)
				{
					if (_doNorm)
					{
						_mesh.normals = this.normals;
					}
					else
					{
						UnityEngine.Debug.LogError("normal flag was set in Apply but MeshBaker didn't generate normals");
					}
				}
				if (tangents)
				{
					if (_doTan)
					{
						_mesh.tangents = this.tangents;
					}
					else
					{
						UnityEngine.Debug.LogError("tangent flag was set in Apply but MeshBaker didn't generate tangents");
					}
				}
				if (uvs)
				{
					if (_doUV)
					{
						_mesh.uv = this.uvs;
					}
					else
					{
						UnityEngine.Debug.LogError("uv flag was set in Apply but MeshBaker didn't generate uvs");
					}
				}
				if (colors)
				{
					if (_doCol)
					{
						_mesh.colors = this.colors;
					}
					else
					{
						UnityEngine.Debug.LogError("color flag was set in Apply but MeshBaker didn't generate colors");
					}
				}
				if (uv3)
				{
					if (_doUV3)
					{
						MBVersion.MeshAssignUV3(_mesh, uv3s);
					}
					else
					{
						UnityEngine.Debug.LogError("uv3 flag was set in Apply but MeshBaker didn't generate uv3s");
					}
				}
				if (uv4)
				{
					if (_doUV4)
					{
						MBVersion.MeshAssignUV4(_mesh, uv4s);
					}
					else
					{
						UnityEngine.Debug.LogError("uv4 flag was set in Apply but MeshBaker didn't generate uv4s");
					}
				}
				if (uv2)
				{
					if (doUV2())
					{
						_mesh.uv2 = uv2s;
					}
					else
					{
						UnityEngine.Debug.LogError("uv2 flag was set in Apply but lightmapping option was set to " + lightmapOption);
					}
				}
				bool flag = false;
				if (renderType != MB_RenderType.skinnedMeshRenderer && lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout)
				{
					if (uv2GenerationMethod != null)
					{
						uv2GenerationMethod(_mesh, uv2UnwrappingParamsHardAngle, uv2UnwrappingParamsPackMargin);
						if (LOG_LEVEL >= MB2_LogLevel.trace)
						{
							UnityEngine.Debug.Log("generating new UV2 layout for the combined mesh ");
						}
					}
					else
					{
						UnityEngine.Debug.LogError("No GenerateUV2Delegate method was supplied. UV2 cannot be generated.");
					}
					flag = true;
				}
				else if (renderType == MB_RenderType.skinnedMeshRenderer && lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("UV2 cannot be generated for SkinnedMeshRenderer objects.");
				}
				if (renderType != MB_RenderType.skinnedMeshRenderer && lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout && !flag)
				{
					UnityEngine.Debug.LogError("Failed to generate new UV2 layout. Only works in editor.");
				}
				if (renderType == MB_RenderType.skinnedMeshRenderer)
				{
					if (verts.Length == 0)
					{
						targetRenderer.enabled = false;
					}
					else
					{
						targetRenderer.enabled = true;
					}
					bool updateWhenOffscreen = ((SkinnedMeshRenderer)targetRenderer).updateWhenOffscreen;
					((SkinnedMeshRenderer)targetRenderer).updateWhenOffscreen = true;
					((SkinnedMeshRenderer)targetRenderer).updateWhenOffscreen = updateWhenOffscreen;
				}
				if (bones)
				{
					_mesh.bindposes = bindPoses;
					_mesh.boneWeights = boneWeights;
				}
				if (blendShapesFlag && (MBVersion.GetMajorVersion() > 5 || (MBVersion.GetMajorVersion() == 5 && MBVersion.GetMinorVersion() >= 3)))
				{
					if (blendShapesInCombined.Length != blendShapes.Length)
					{
						blendShapesInCombined = new MBBlendShape[blendShapes.Length];
					}
					Vector3[] array2 = new Vector3[verts.Length];
					Vector3[] array3 = new Vector3[verts.Length];
					Vector3[] array4 = new Vector3[verts.Length];
					MBVersion.ClearBlendShapes(_mesh);
					for (int l = 0; l < blendShapes.Length; l++)
					{
						MB_DynamicGameObject mB_DynamicGameObject = instance2Combined_MapGet(blendShapes[l].gameObjectID);
						if (mB_DynamicGameObject != null)
						{
							for (int m = 0; m < blendShapes[l].frames.Length; m++)
							{
								MBBlendShapeFrame mBBlendShapeFrame = blendShapes[l].frames[m];
								int vertIdx = mB_DynamicGameObject.vertIdx;
								Array.Copy(mBBlendShapeFrame.vertices, 0, array2, vertIdx, blendShapes[l].frames[m].vertices.Length);
								Array.Copy(mBBlendShapeFrame.normals, 0, array3, vertIdx, blendShapes[l].frames[m].normals.Length);
								Array.Copy(mBBlendShapeFrame.tangents, 0, array4, vertIdx, blendShapes[l].frames[m].tangents.Length);
								MBVersion.AddBlendShapeFrame(_mesh, blendShapes[l].name + blendShapes[l].gameObjectID, mBBlendShapeFrame.frameWeight, array2, array3, array4);
								_ZeroArray(array2, vertIdx, blendShapes[l].frames[m].vertices.Length);
								_ZeroArray(array3, vertIdx, blendShapes[l].frames[m].normals.Length);
								_ZeroArray(array4, vertIdx, blendShapes[l].frames[m].tangents.Length);
							}
						}
						else
						{
							UnityEngine.Debug.LogError("InstanceID in blend shape that was not in instance2combinedMap");
						}
						blendShapesInCombined[l] = blendShapes[l];
					}
					((SkinnedMeshRenderer)_targetRenderer).sharedMesh = null;
					((SkinnedMeshRenderer)_targetRenderer).sharedMesh = _mesh;
				}
				if (triangles || vertices)
				{
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						UnityEngine.Debug.Log("recalculating bounds on mesh.");
					}
					_mesh.RecalculateBounds();
				}
				if (_optimizeAfterBake && !Application.isPlaying)
				{
					MBVersion.OptimizeMesh(_mesh);
				}
			}
			else
			{
				UnityEngine.Debug.LogError("Need to add objects to this meshbaker before calling Apply or ApplyAll");
			}
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Apply Complete time: " + stopwatch.ElapsedMilliseconds + " vertices: " + _mesh.vertexCount);
			}
		}

		private int _numNonZeroLengthSubmeshTris(SerializableIntArray[] subTris)
		{
			int num = 0;
			for (int i = 0; i < subTris.Length; i++)
			{
				if (subTris[i].data.Length != 0)
				{
					num++;
				}
			}
			return num;
		}

		private void _updateMaterialsOnTargetRenderer(SerializableIntArray[] subTris, int numNonZeroLengthSubmeshTris)
		{
			if (subTris.Length != textureBakeResults.resultMaterials.Length)
			{
				UnityEngine.Debug.LogError("Mismatch between number of submeshes and number of result materials");
			}
			Material[] array = new Material[numNonZeroLengthSubmeshTris];
			int num = 0;
			for (int i = 0; i < subTris.Length; i++)
			{
				if (subTris[i].data.Length != 0)
				{
					array[num] = _textureBakeResults.resultMaterials[i].combinedMaterial;
					num++;
				}
			}
			targetRenderer.materials = array;
		}

		public SerializableIntArray[] GetSubmeshTrisWithShowHideApplied()
		{
			bool flag = false;
			for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				if (!mbDynamicObjectsInCombinedMesh[i].show)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				int[] array = new int[submeshTris.Length];
				SerializableIntArray[] array2 = new SerializableIntArray[submeshTris.Length];
				for (int j = 0; j < mbDynamicObjectsInCombinedMesh.Count; j++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[j];
					if (mB_DynamicGameObject.show)
					{
						for (int k = 0; k < mB_DynamicGameObject.submeshNumTris.Length; k++)
						{
							array[k] += mB_DynamicGameObject.submeshNumTris[k];
						}
					}
				}
				for (int l = 0; l < array2.Length; l++)
				{
					array2[l] = new SerializableIntArray(array[l]);
				}
				int[] array3 = new int[array2.Length];
				for (int m = 0; m < mbDynamicObjectsInCombinedMesh.Count; m++)
				{
					MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[m];
					if (!mB_DynamicGameObject2.show)
					{
						continue;
					}
					for (int n = 0; n < submeshTris.Length; n++)
					{
						int[] data = submeshTris[n].data;
						int num = mB_DynamicGameObject2.submeshTriIdxs[n];
						int num2 = num + mB_DynamicGameObject2.submeshNumTris[n];
						for (int num3 = num; num3 < num2; num3++)
						{
							array2[n].data[array3[n]] = data[num3];
							array3[n]++;
						}
					}
				}
				return array2;
			}
			return submeshTris;
		}

		public override bool UpdateGameObjects(GameObject[] gos, bool recalcBounds = true, bool updateVertices = true, bool updateNormals = true, bool updateTangents = true, bool updateUV = false, bool updateUV2 = false, bool updateUV3 = false, bool updateUV4 = false, bool updateColors = false, bool updateSkinningInfo = false)
		{
			return _updateGameObjects(gos, recalcBounds, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateColors, updateSkinningInfo);
		}

		private bool _updateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateColors, bool updateSkinningInfo)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("UpdateGameObjects called on " + gos.Length + " objects.");
			}
			int numResultMats = 1;
			if (textureBakeResults.doMultiMaterial)
			{
				numResultMats = textureBakeResults.resultMaterials.Length;
			}
			_initialize(numResultMats);
			if (_mesh.vertexCount > 0 && _instance2combined_map.Count == 0)
			{
				UnityEngine.Debug.LogWarning("There were vertices in the combined mesh but nothing in the MeshBaker buffers. If you are trying to bake in the editor and modify at runtime, make sure 'Clear Buffers After Bake' is unchecked.");
			}
			bool flag = true;
			MeshChannelsCache meshChannelCache = new MeshChannelsCache(this);
			MB2_TextureBakeResults.Material2AtlasRectangleMapper mat2rect_map = null;
			OrderedDictionary orderedDictionary = null;
			Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResultsCache = null;
			if (updateUV)
			{
				orderedDictionary = BuildSourceMatsToSubmeshIdxMap(numResultMats);
				if (orderedDictionary == null)
				{
					return false;
				}
				mat2rect_map = new MB2_TextureBakeResults.Material2AtlasRectangleMapper(textureBakeResults);
				meshAnalysisResultsCache = new Dictionary<int, MB_Utility.MeshAnalysisResult[]>();
			}
			for (int i = 0; i < gos.Length; i++)
			{
				flag = flag && _updateGameObject(gos[i], updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateColors, updateSkinningInfo, meshChannelCache, meshAnalysisResultsCache, orderedDictionary, mat2rect_map);
			}
			if (recalcBounds)
			{
				_mesh.RecalculateBounds();
			}
			return flag;
		}

		private bool _updateGameObject(GameObject go, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateColors, bool updateSkinningInfo, MeshChannelsCache meshChannelCache, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResultsCache, OrderedDictionary sourceMats2submeshIdx_map, MB2_TextureBakeResults.Material2AtlasRectangleMapper mat2rect_map)
		{
			MB_DynamicGameObject dgo = null;
			if (!instance2Combined_MapTryGetValue(go.GetInstanceID(), out dgo))
			{
				UnityEngine.Debug.LogError("Object " + go.name + " has not been added");
				return false;
			}
			Mesh mesh = MB_Utility.GetMesh(go);
			if (dgo.numVerts != mesh.vertexCount)
			{
				UnityEngine.Debug.LogError("Object " + go.name + " source mesh has been modified since being added. To update it must have the same number of verts");
				return false;
			}
			if (_doUV && updateUV)
			{
				Material[] gOMaterials = MB_Utility.GetGOMaterials(go);
				MB_TextureTilingTreatment[] array = new MB_TextureTilingTreatment[gOMaterials.Length];
				Rect[] array2 = new Rect[gOMaterials.Length];
				Rect[] array3 = new Rect[gOMaterials.Length];
				Rect[] array4 = new Rect[gOMaterials.Length];
				string errorMsg = "";
				int num = Mathf.Min(mesh.subMeshCount, gOMaterials.Length);
				if (num != dgo.targetSubmeshIdxs.Length)
				{
					UnityEngine.Debug.LogError($"Error updating object {go.name} in the combined mesh. The object has a different number of materials/submeshes than it did when previously baked. Try using AddDelete instead of Update.");
					return false;
				}
				for (int i = 0; i < num; i++)
				{
					object obj = sourceMats2submeshIdx_map[gOMaterials[i]];
					if (obj == null)
					{
						UnityEngine.Debug.LogError("Source object " + go.name + " used a material " + gOMaterials[i]?.ToString() + " that was not in the baked materials.");
						return false;
					}
					int num2 = (int)obj;
					if (num2 != dgo.targetSubmeshIdxs[i])
					{
						UnityEngine.Debug.LogError($"Update failed for object {go.name}. Material {gOMaterials[i]} is mapped to a different submesh in the combined mesh than the previous material. This is not supported. Try using AddDelete.");
						return false;
					}
					if (!mat2rect_map.TryMapMaterialToUVRect(gOMaterials[i], mesh, i, num2, meshChannelCache, meshAnalysisResultsCache, out array[i], out array2[i], out array3[i], out array4[i], ref errorMsg, LOG_LEVEL))
					{
						UnityEngine.Debug.LogError(errorMsg);
						return false;
					}
				}
				dgo.uvRects = array2;
				dgo.encapsulatingRect = array3;
				dgo.sourceMaterialTiling = array4;
				_copyAndAdjustUVsFromMesh(dgo, mesh, dgo.vertIdx, meshChannelCache);
			}
			if (doUV2() && updateUV2)
			{
				_copyAndAdjustUV2FromMesh(dgo, mesh, dgo.vertIdx, meshChannelCache);
			}
			if (renderType == MB_RenderType.skinnedMeshRenderer && updateSkinningInfo)
			{
				Renderer renderer = MB_Utility.GetRenderer(go);
				BoneWeight[] array5 = meshChannelCache.GetBoneWeights(renderer, dgo.numVerts);
				Transform[] array6 = _getBones(renderer);
				int num3 = dgo.vertIdx;
				bool flag = false;
				for (int j = 0; j < array5.Length; j++)
				{
					if (array6[array5[j].boneIndex0] != bones[boneWeights[num3].boneIndex0])
					{
						flag = true;
						break;
					}
					boneWeights[num3].weight0 = array5[j].weight0;
					boneWeights[num3].weight1 = array5[j].weight1;
					boneWeights[num3].weight2 = array5[j].weight2;
					boneWeights[num3].weight3 = array5[j].weight3;
					num3++;
				}
				if (flag)
				{
					UnityEngine.Debug.LogError("Detected that some of the boneweights reference different bones than when initial added. Boneweights must reference the same bones " + dgo.name);
				}
			}
			Matrix4x4 localToWorldMatrix = go.transform.localToWorldMatrix;
			if (updateVertices)
			{
				Vector3[] vertices = meshChannelCache.GetVertices(mesh);
				for (int k = 0; k < vertices.Length; k++)
				{
					verts[dgo.vertIdx + k] = localToWorldMatrix.MultiplyPoint3x4(vertices[k]);
				}
			}
			float num4 = (localToWorldMatrix[2, 3] = 0f);
			float value = (localToWorldMatrix[1, 3] = num4);
			localToWorldMatrix[0, 3] = value;
			if (_doNorm && updateNormals)
			{
				Vector3[] array7 = meshChannelCache.GetNormals(mesh);
				for (int l = 0; l < array7.Length; l++)
				{
					int num7 = dgo.vertIdx + l;
					normals[num7] = localToWorldMatrix.MultiplyPoint3x4(array7[l]);
					normals[num7] = normals[num7].normalized;
				}
			}
			if (_doTan && updateTangents)
			{
				Vector4[] array8 = meshChannelCache.GetTangents(mesh);
				for (int m = 0; m < array8.Length; m++)
				{
					int num8 = dgo.vertIdx + m;
					float w = array8[m].w;
					Vector3 vector = localToWorldMatrix.MultiplyPoint3x4(array8[m]);
					vector.Normalize();
					tangents[num8] = vector;
					tangents[num8].w = w;
				}
			}
			if (_doCol && updateColors)
			{
				Color[] array9 = meshChannelCache.GetColors(mesh);
				for (int n = 0; n < array9.Length; n++)
				{
					colors[dgo.vertIdx + n] = array9[n];
				}
			}
			if (_doUV3 && updateUV3)
			{
				Vector2[] uv = meshChannelCache.GetUv3(mesh);
				for (int num9 = 0; num9 < uv.Length; num9++)
				{
					uv3s[dgo.vertIdx + num9] = uv[num9];
				}
			}
			if (_doUV4 && updateUV4)
			{
				Vector2[] uv2 = meshChannelCache.GetUv4(mesh);
				for (int num10 = 0; num10 < uv2.Length; num10++)
				{
					uv4s[dgo.vertIdx + num10] = uv2[num10];
				}
			}
			return true;
		}

		public bool ShowHideGameObjects(GameObject[] toShow, GameObject[] toHide)
		{
			if (textureBakeResults == null)
			{
				UnityEngine.Debug.LogError("TextureBakeResults must be set.");
				return false;
			}
			return _showHide(toShow, toHide);
		}

		public override bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource = true)
		{
			int[] array = null;
			if (deleteGOs != null)
			{
				array = new int[deleteGOs.Length];
				for (int i = 0; i < deleteGOs.Length; i++)
				{
					if (deleteGOs[i] == null)
					{
						UnityEngine.Debug.LogError("The " + i + "th object on the list of objects to delete is 'Null'");
					}
					else
					{
						array[i] = deleteGOs[i].GetInstanceID();
					}
				}
			}
			return AddDeleteGameObjectsByID(gos, array, disableRendererInSource);
		}

		public override bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource)
		{
			if (validationLevel > MB2_ValidationLevel.none)
			{
				if (gos != null)
				{
					for (int i = 0; i < gos.Length; i++)
					{
						if (gos[i] == null)
						{
							UnityEngine.Debug.LogError("The " + i + "th object on the list of objects to combine is 'None'. Use Command-Delete on Mac OS X; Delete or Shift-Delete on Windows to remove this one element.");
							return false;
						}
						if (validationLevel < MB2_ValidationLevel.robust)
						{
							continue;
						}
						for (int j = i + 1; j < gos.Length; j++)
						{
							if (gos[i] == gos[j])
							{
								UnityEngine.Debug.LogError("GameObject " + gos[i]?.ToString() + " appears twice in list of game objects to add");
								return false;
							}
						}
					}
				}
				if (deleteGOinstanceIDs != null && validationLevel >= MB2_ValidationLevel.robust)
				{
					for (int k = 0; k < deleteGOinstanceIDs.Length; k++)
					{
						for (int l = k + 1; l < deleteGOinstanceIDs.Length; l++)
						{
							if (deleteGOinstanceIDs[k] == deleteGOinstanceIDs[l])
							{
								UnityEngine.Debug.LogError("GameObject " + deleteGOinstanceIDs[k] + "appears twice in list of game objects to delete");
								return false;
							}
						}
					}
				}
			}
			if (_usingTemporaryTextureBakeResult && gos != null && gos.Length != 0)
			{
				MB_Utility.Destroy(_textureBakeResults);
				_textureBakeResults = null;
				_usingTemporaryTextureBakeResult = false;
			}
			if (_textureBakeResults == null && gos != null && gos.Length != 0 && gos[0] != null && !_CreateTemporaryTextrueBakeResult(gos, GetMaterialsOnTargetRenderer()))
			{
				return false;
			}
			BuildSceneMeshObject(gos);
			if (!_addToCombined(gos, deleteGOinstanceIDs, disableRendererInSource))
			{
				UnityEngine.Debug.LogError("Failed to add/delete objects to combined mesh");
				return false;
			}
			if (targetRenderer != null)
			{
				if (renderType == MB_RenderType.skinnedMeshRenderer)
				{
					SkinnedMeshRenderer obj = (SkinnedMeshRenderer)targetRenderer;
					obj.sharedMesh = _mesh;
					obj.bones = bones;
					UpdateSkinnedMeshApproximateBoundsFromBounds();
				}
				targetRenderer.lightmapIndex = GetLightmapIndex();
			}
			return true;
		}

		public override bool CombinedMeshContains(GameObject go)
		{
			return objectsInCombinedMesh.Contains(go);
		}

		public override void ClearBuffers()
		{
			verts = new Vector3[0];
			normals = new Vector3[0];
			tangents = new Vector4[0];
			uvs = new Vector2[0];
			uv2s = new Vector2[0];
			uv3s = new Vector2[0];
			uv4s = new Vector2[0];
			colors = new Color[0];
			bones = new Transform[0];
			bindPoses = new Matrix4x4[0];
			boneWeights = new BoneWeight[0];
			submeshTris = new SerializableIntArray[0];
			blendShapes = new MBBlendShape[0];
			if (blendShapesInCombined == null)
			{
				blendShapesInCombined = new MBBlendShape[0];
			}
			else
			{
				for (int i = 0; i < blendShapesInCombined.Length; i++)
				{
					blendShapesInCombined[i].frames = new MBBlendShapeFrame[0];
				}
			}
			mbDynamicObjectsInCombinedMesh.Clear();
			objectsInCombinedMesh.Clear();
			instance2Combined_MapClear();
			if (_usingTemporaryTextureBakeResult)
			{
				MB_Utility.Destroy(_textureBakeResults);
				_textureBakeResults = null;
				_usingTemporaryTextureBakeResult = false;
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				MB2_Log.LogDebug("ClearBuffers called");
			}
		}

		public override void ClearMesh()
		{
			if (_mesh != null)
			{
				MBVersion.MeshClear(_mesh, t: false);
			}
			else
			{
				_mesh = new Mesh();
			}
			ClearBuffers();
		}

		public override void DestroyMesh()
		{
			if (_mesh != null)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Destroying Mesh");
				}
				MB_Utility.Destroy(_mesh);
			}
			_mesh = new Mesh();
			ClearBuffers();
		}

		public override void DestroyMeshEditor(MB2_EditorMethodsInterface editorMethods)
		{
			if (_mesh != null)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Destroying Mesh");
				}
				editorMethods.Destroy(_mesh);
			}
			_mesh = new Mesh();
			ClearBuffers();
		}

		public bool ValidateTargRendererAndMeshAndResultSceneObj()
		{
			if (_resultSceneObject == null)
			{
				if (_LOG_LEVEL >= MB2_LogLevel.error)
				{
					UnityEngine.Debug.LogError("Result Scene Object was not set.");
				}
				return false;
			}
			if (_targetRenderer == null)
			{
				if (_LOG_LEVEL >= MB2_LogLevel.error)
				{
					UnityEngine.Debug.LogError("Target Renderer was not set.");
				}
				return false;
			}
			if (_targetRenderer.transform.parent != _resultSceneObject.transform)
			{
				if (_LOG_LEVEL >= MB2_LogLevel.error)
				{
					UnityEngine.Debug.LogError("Target Renderer game object is not a child of Result Scene Object was not set.");
				}
				return false;
			}
			if (_renderType == MB_RenderType.skinnedMeshRenderer && !(_targetRenderer is SkinnedMeshRenderer))
			{
				if (_LOG_LEVEL >= MB2_LogLevel.error)
				{
					UnityEngine.Debug.LogError("Render Type is skinned mesh renderer but Target Renderer is not.");
				}
				return false;
			}
			if (_renderType == MB_RenderType.meshRenderer)
			{
				if (!(_targetRenderer is MeshRenderer))
				{
					if (_LOG_LEVEL >= MB2_LogLevel.error)
					{
						UnityEngine.Debug.LogError("Render Type is mesh renderer but Target Renderer is not.");
					}
					return false;
				}
				MeshFilter component = _targetRenderer.GetComponent<MeshFilter>();
				if (_mesh != component.sharedMesh)
				{
					if (_LOG_LEVEL >= MB2_LogLevel.error)
					{
						UnityEngine.Debug.LogError("Target renderer mesh is not equal to mesh.");
					}
					return false;
				}
			}
			return true;
		}

		private OrderedDictionary BuildSourceMatsToSubmeshIdxMap(int numResultMats)
		{
			OrderedDictionary orderedDictionary = new OrderedDictionary();
			for (int i = 0; i < numResultMats; i++)
			{
				MB_MultiMaterial mB_MultiMaterial = _textureBakeResults.resultMaterials[i];
				for (int j = 0; j < mB_MultiMaterial.sourceMaterials.Count; j++)
				{
					if (mB_MultiMaterial.sourceMaterials[j] == null)
					{
						UnityEngine.Debug.LogError("Found null material in source materials for combined mesh materials " + i);
						return null;
					}
					if (!orderedDictionary.Contains(mB_MultiMaterial.sourceMaterials[j]))
					{
						orderedDictionary.Add(mB_MultiMaterial.sourceMaterials[j], i);
					}
				}
			}
			return orderedDictionary;
		}

		internal static Renderer BuildSceneHierarchPreBake(MB3_MeshCombinerSingle mom, GameObject root, Mesh m, bool createNewChild = false, GameObject[] objsToBeAdded = null)
		{
			if (mom._LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("Building Scene Hierarchy createNewChild=" + createNewChild);
			}
			MeshFilter meshFilter = null;
			MeshRenderer meshRenderer = null;
			SkinnedMeshRenderer skinnedMeshRenderer = null;
			Transform transform = null;
			if (root == null)
			{
				UnityEngine.Debug.LogError("root was null.");
				return null;
			}
			if (mom.textureBakeResults == null)
			{
				UnityEngine.Debug.LogError("textureBakeResults must be set.");
				return null;
			}
			if (root.GetComponent<Renderer>() != null)
			{
				UnityEngine.Debug.LogError("root game object cannot have a renderer component");
				return null;
			}
			if (!createNewChild)
			{
				if (mom.targetRenderer != null && mom.targetRenderer.transform.parent == root.transform)
				{
					transform = mom.targetRenderer.transform;
				}
				else
				{
					Renderer[] componentsInChildren = root.GetComponentsInChildren<Renderer>();
					if (componentsInChildren.Length == 1)
					{
						if (componentsInChildren[0].transform.parent != root.transform)
						{
							UnityEngine.Debug.LogError("Target Renderer is not an immediate child of Result Scene Object. Try using a game object with no children as the Result Scene Object..");
						}
						transform = componentsInChildren[0].transform;
					}
				}
			}
			if (transform != null && transform.parent != root.transform)
			{
				transform = null;
			}
			GameObject gameObject;
			if (transform == null)
			{
				gameObject = new GameObject(mom.name + "-mesh");
				gameObject.transform.parent = root.transform;
				transform = gameObject.transform;
			}
			transform.parent = root.transform;
			gameObject = transform.gameObject;
			if (mom.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				if (component != null)
				{
					MB_Utility.Destroy(component);
				}
				MeshFilter component2 = gameObject.GetComponent<MeshFilter>();
				if (component2 != null)
				{
					MB_Utility.Destroy(component2);
				}
				skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
				if (skinnedMeshRenderer == null)
				{
					skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
				}
			}
			else
			{
				SkinnedMeshRenderer component3 = gameObject.GetComponent<SkinnedMeshRenderer>();
				if (component3 != null)
				{
					MB_Utility.Destroy(component3);
				}
				meshFilter = gameObject.GetComponent<MeshFilter>();
				if (meshFilter == null)
				{
					meshFilter = gameObject.AddComponent<MeshFilter>();
				}
				meshRenderer = gameObject.GetComponent<MeshRenderer>();
				if (meshRenderer == null)
				{
					meshRenderer = gameObject.AddComponent<MeshRenderer>();
				}
			}
			if (mom.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				skinnedMeshRenderer.bones = mom.GetBones();
				bool updateWhenOffscreen = skinnedMeshRenderer.updateWhenOffscreen;
				skinnedMeshRenderer.updateWhenOffscreen = true;
				skinnedMeshRenderer.updateWhenOffscreen = updateWhenOffscreen;
			}
			_ConfigureSceneHierarch(mom, root, meshRenderer, meshFilter, skinnedMeshRenderer, m, objsToBeAdded);
			if (mom.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				return skinnedMeshRenderer;
			}
			return meshRenderer;
		}

		public static void BuildPrefabHierarchy(MB3_MeshCombinerSingle mom, GameObject instantiatedPrefabRoot, Mesh m, bool createNewChild = false, GameObject[] objsToBeAdded = null)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = null;
			MeshRenderer meshRenderer = null;
			MeshFilter meshFilter = null;
			GameObject gameObject = new GameObject(mom.name + "-mesh");
			gameObject.transform.parent = instantiatedPrefabRoot.transform;
			Transform transform = gameObject.transform;
			transform.parent = instantiatedPrefabRoot.transform;
			gameObject = transform.gameObject;
			if (mom.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				if (component != null)
				{
					MB_Utility.Destroy(component);
				}
				MeshFilter component2 = gameObject.GetComponent<MeshFilter>();
				if (component2 != null)
				{
					MB_Utility.Destroy(component2);
				}
				skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
				if (skinnedMeshRenderer == null)
				{
					skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
				}
			}
			else
			{
				SkinnedMeshRenderer component3 = gameObject.GetComponent<SkinnedMeshRenderer>();
				if (component3 != null)
				{
					MB_Utility.Destroy(component3);
				}
				meshFilter = gameObject.GetComponent<MeshFilter>();
				if (meshFilter == null)
				{
					meshFilter = gameObject.AddComponent<MeshFilter>();
				}
				meshRenderer = gameObject.GetComponent<MeshRenderer>();
				if (meshRenderer == null)
				{
					meshRenderer = gameObject.AddComponent<MeshRenderer>();
				}
			}
			if (mom.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				skinnedMeshRenderer.bones = mom.GetBones();
				bool updateWhenOffscreen = skinnedMeshRenderer.updateWhenOffscreen;
				skinnedMeshRenderer.updateWhenOffscreen = true;
				skinnedMeshRenderer.updateWhenOffscreen = updateWhenOffscreen;
				skinnedMeshRenderer.sharedMesh = m;
			}
			_ConfigureSceneHierarch(mom, instantiatedPrefabRoot, meshRenderer, meshFilter, skinnedMeshRenderer, m, objsToBeAdded);
			if (mom.targetRenderer != null)
			{
				Material[] array = new Material[mom.targetRenderer.sharedMaterials.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = mom.targetRenderer.sharedMaterials[i];
				}
				if (mom.renderType == MB_RenderType.skinnedMeshRenderer)
				{
					skinnedMeshRenderer.sharedMaterial = null;
					skinnedMeshRenderer.sharedMaterials = array;
				}
				else
				{
					meshRenderer.sharedMaterial = null;
					meshRenderer.sharedMaterials = array;
				}
			}
		}

		private static void _ConfigureSceneHierarch(MB3_MeshCombinerSingle mom, GameObject root, MeshRenderer mr, MeshFilter mf, SkinnedMeshRenderer smr, Mesh m, GameObject[] objsToBeAdded = null)
		{
			GameObject gameObject;
			if (mom.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				gameObject = smr.gameObject;
				smr.lightmapIndex = mom.GetLightmapIndex();
			}
			else
			{
				gameObject = mr.gameObject;
				mf.sharedMesh = m;
				mr.lightmapIndex = mom.GetLightmapIndex();
			}
			if (mom.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping || mom.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout)
			{
				gameObject.isStatic = true;
			}
			if (objsToBeAdded == null || objsToBeAdded.Length == 0 || !(objsToBeAdded[0] != null))
			{
				return;
			}
			bool flag = true;
			bool flag2 = true;
			string tag = objsToBeAdded[0].tag;
			int layer = objsToBeAdded[0].layer;
			for (int i = 0; i < objsToBeAdded.Length; i++)
			{
				if (objsToBeAdded[i] != null)
				{
					if (!objsToBeAdded[i].tag.Equals(tag))
					{
						flag = false;
					}
					if (objsToBeAdded[i].layer != layer)
					{
						flag2 = false;
					}
				}
			}
			if (flag)
			{
				root.tag = tag;
				gameObject.tag = tag;
			}
			if (flag2)
			{
				root.layer = layer;
				gameObject.layer = layer;
			}
		}

		public void BuildSceneMeshObject(GameObject[] gos = null, bool createNewChild = false)
		{
			if (_resultSceneObject == null)
			{
				_resultSceneObject = new GameObject("CombinedMesh-" + base.name);
			}
			_targetRenderer = BuildSceneHierarchPreBake(this, _resultSceneObject, GetMesh(), createNewChild, gos);
		}

		private bool IsMirrored(Matrix4x4 tm)
		{
			Vector3 lhs = tm.GetRow(0);
			Vector3 rhs = tm.GetRow(1);
			Vector3 rhs2 = tm.GetRow(2);
			lhs.Normalize();
			rhs.Normalize();
			rhs2.Normalize();
			if (!(Vector3.Dot(Vector3.Cross(lhs, rhs), rhs2) >= 0f))
			{
				return true;
			}
			return false;
		}

		public override void CheckIntegrity()
		{
			if (!MB_Utility.DO_INTEGRITY_CHECKS)
			{
				return;
			}
			if (renderType == MB_RenderType.skinnedMeshRenderer)
			{
				for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[i];
					HashSet<int> hashSet = new HashSet<int>();
					HashSet<int> hashSet2 = new HashSet<int>();
					for (int j = mB_DynamicGameObject.vertIdx; j < mB_DynamicGameObject.vertIdx + mB_DynamicGameObject.numVerts; j++)
					{
						hashSet.Add(boneWeights[j].boneIndex0);
						hashSet.Add(boneWeights[j].boneIndex1);
						hashSet.Add(boneWeights[j].boneIndex2);
						hashSet.Add(boneWeights[j].boneIndex3);
					}
					for (int k = 0; k < mB_DynamicGameObject.indexesOfBonesUsed.Length; k++)
					{
						hashSet2.Add(mB_DynamicGameObject.indexesOfBonesUsed[k]);
					}
					hashSet2.ExceptWith(hashSet);
					if (hashSet2.Count > 0)
					{
						UnityEngine.Debug.LogError("The bone indexes were not the same. " + hashSet.Count + " " + hashSet2.Count);
					}
					for (int l = 0; l < mB_DynamicGameObject.indexesOfBonesUsed.Length; l++)
					{
						if (l < 0 || l > bones.Length)
						{
							UnityEngine.Debug.LogError("Bone index was out of bounds.");
						}
					}
					if (renderType == MB_RenderType.skinnedMeshRenderer && mB_DynamicGameObject.indexesOfBonesUsed.Length < 1)
					{
						UnityEngine.Debug.Log("DGO had no bones");
					}
				}
			}
			if (doBlendShapes && renderType != MB_RenderType.skinnedMeshRenderer)
			{
				UnityEngine.Debug.LogError("Blend shapes can only be used with skinned meshes.");
			}
		}

		private void _ZeroArray(Vector3[] arr, int idx, int length)
		{
			int num = idx + length;
			for (int i = idx; i < num; i++)
			{
				arr[i] = Vector3.zero;
			}
		}

		private List<MB_DynamicGameObject>[] _buildBoneIdx2dgoMap()
		{
			List<MB_DynamicGameObject>[] array = new List<MB_DynamicGameObject>[bones.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new List<MB_DynamicGameObject>();
			}
			for (int j = 0; j < mbDynamicObjectsInCombinedMesh.Count; j++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[j];
				for (int k = 0; k < mB_DynamicGameObject.indexesOfBonesUsed.Length; k++)
				{
					array[mB_DynamicGameObject.indexesOfBonesUsed[k]].Add(mB_DynamicGameObject);
				}
			}
			return array;
		}

		private void _CollectBonesToAddForDGO(MB_DynamicGameObject dgo, Dictionary<Transform, int> bone2idx, HashSet<int> boneIdxsToDelete, HashSet<BoneAndBindpose> bonesToAdd, Renderer r, MeshChannelsCache meshChannelCache)
		{
			Matrix4x4[] array = (dgo._tmpCachedBindposes = meshChannelCache.GetBindposes(r));
			BoneWeight[] array2 = (dgo._tmpCachedBoneWeights = meshChannelCache.GetBoneWeights(r, dgo.numVerts));
			Transform[] array3 = (dgo._tmpCachedBones = _getBones(r));
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < array2.Length; i++)
			{
				hashSet.Add(array2[i].boneIndex0);
				hashSet.Add(array2[i].boneIndex1);
				hashSet.Add(array2[i].boneIndex2);
				hashSet.Add(array2[i].boneIndex3);
			}
			int[] array4 = new int[hashSet.Count];
			hashSet.CopyTo(array4);
			for (int j = 0; j < array4.Length; j++)
			{
				bool flag = false;
				int num = array4[j];
				if (bone2idx.TryGetValue(array3[num], out var value) && array3[num] == bones[value] && !boneIdxsToDelete.Contains(value) && array[num] == bindPoses[value])
				{
					flag = true;
				}
				if (!flag)
				{
					BoneAndBindpose item = new BoneAndBindpose(array3[num], array[num]);
					if (!bonesToAdd.Contains(item))
					{
						bonesToAdd.Add(item);
					}
				}
			}
			dgo._tmpIndexesOfSourceBonesUsed = array4;
		}

		private void _CopyBonesWeAreKeepingToNewBonesArrayAndAdjustBWIndexes(HashSet<int> boneIdxsToDeleteHS, HashSet<BoneAndBindpose> bonesToAdd, Transform[] nbones, Matrix4x4[] nbindPoses, BoneWeight[] nboneWeights, int totalDeleteVerts)
		{
			if (boneIdxsToDeleteHS.Count > 0)
			{
				int[] array = new int[boneIdxsToDeleteHS.Count];
				boneIdxsToDeleteHS.CopyTo(array);
				Array.Sort(array);
				int[] array2 = new int[bones.Length];
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < bones.Length; i++)
				{
					if (num2 < array.Length && array[num2] == i)
					{
						num2++;
						array2[i] = -1;
						continue;
					}
					array2[i] = num;
					nbones[num] = bones[i];
					nbindPoses[num] = bindPoses[i];
					num++;
				}
				int num3 = boneWeights.Length - totalDeleteVerts;
				for (int j = 0; j < num3; j++)
				{
					nboneWeights[j].boneIndex0 = array2[nboneWeights[j].boneIndex0];
					nboneWeights[j].boneIndex1 = array2[nboneWeights[j].boneIndex1];
					nboneWeights[j].boneIndex2 = array2[nboneWeights[j].boneIndex2];
					nboneWeights[j].boneIndex3 = array2[nboneWeights[j].boneIndex3];
				}
				for (int k = 0; k < mbDynamicObjectsInCombinedMesh.Count; k++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[k];
					for (int l = 0; l < mB_DynamicGameObject.indexesOfBonesUsed.Length; l++)
					{
						mB_DynamicGameObject.indexesOfBonesUsed[l] = array2[mB_DynamicGameObject.indexesOfBonesUsed[l]];
					}
				}
			}
			else
			{
				Array.Copy(bones, nbones, bones.Length);
				Array.Copy(bindPoses, nbindPoses, bindPoses.Length);
			}
		}

		private void _AddBonesToNewBonesArrayAndAdjustBWIndexes(MB_DynamicGameObject dgo, Renderer r, int vertsIdx, Transform[] nbones, BoneWeight[] nboneWeights, MeshChannelsCache meshChannelCache)
		{
			Transform[] tmpCachedBones = dgo._tmpCachedBones;
			Matrix4x4[] tmpCachedBindposes = dgo._tmpCachedBindposes;
			BoneWeight[] tmpCachedBoneWeights = dgo._tmpCachedBoneWeights;
			int[] array = new int[tmpCachedBones.Length];
			for (int i = 0; i < dgo._tmpIndexesOfSourceBonesUsed.Length; i++)
			{
				int num = dgo._tmpIndexesOfSourceBonesUsed[i];
				for (int j = 0; j < nbones.Length; j++)
				{
					if (tmpCachedBones[num] == nbones[j] && tmpCachedBindposes[num] == bindPoses[j])
					{
						array[num] = j;
						break;
					}
				}
			}
			for (int k = 0; k < tmpCachedBoneWeights.Length; k++)
			{
				int num2 = vertsIdx + k;
				nboneWeights[num2].boneIndex0 = array[tmpCachedBoneWeights[k].boneIndex0];
				nboneWeights[num2].boneIndex1 = array[tmpCachedBoneWeights[k].boneIndex1];
				nboneWeights[num2].boneIndex2 = array[tmpCachedBoneWeights[k].boneIndex2];
				nboneWeights[num2].boneIndex3 = array[tmpCachedBoneWeights[k].boneIndex3];
				nboneWeights[num2].weight0 = tmpCachedBoneWeights[k].weight0;
				nboneWeights[num2].weight1 = tmpCachedBoneWeights[k].weight1;
				nboneWeights[num2].weight2 = tmpCachedBoneWeights[k].weight2;
				nboneWeights[num2].weight3 = tmpCachedBoneWeights[k].weight3;
			}
			for (int l = 0; l < dgo._tmpIndexesOfSourceBonesUsed.Length; l++)
			{
				dgo._tmpIndexesOfSourceBonesUsed[l] = array[dgo._tmpIndexesOfSourceBonesUsed[l]];
			}
			dgo.indexesOfBonesUsed = dgo._tmpIndexesOfSourceBonesUsed;
			dgo._tmpIndexesOfSourceBonesUsed = null;
			dgo._tmpCachedBones = null;
			dgo._tmpCachedBindposes = null;
			dgo._tmpCachedBoneWeights = null;
		}

		private void _copyUV2unchangedToSeparateRects()
		{
			int padding = 16;
			List<Vector2> list = new List<Vector2>();
			float num = 1E+11f;
			float num2 = 0f;
			for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				float magnitude = mbDynamicObjectsInCombinedMesh[i].meshSize.magnitude;
				if (magnitude > num2)
				{
					num2 = magnitude;
				}
				if (magnitude < num)
				{
					num = magnitude;
				}
			}
			float num3 = 1000f;
			float num4 = 10f;
			float num5 = 0f;
			float num6 = 1f;
			if (num2 - num > num3 - num4)
			{
				num6 = (num3 - num4) / (num2 - num);
				num5 = num4 - num * num6;
			}
			else
			{
				num6 = num3 / num2;
			}
			for (int j = 0; j < mbDynamicObjectsInCombinedMesh.Count; j++)
			{
				float magnitude2 = mbDynamicObjectsInCombinedMesh[j].meshSize.magnitude;
				magnitude2 = magnitude2 * num6 + num5;
				Vector2 item = Vector2.one * magnitude2;
				list.Add(item);
			}
			AtlasPackingResult[] rects = new MB2_TexturePackerRegular
			{
				atlasMustBePowerOfTwo = false
			}.GetRects(list, 8192, 8192, padding);
			for (int k = 0; k < mbDynamicObjectsInCombinedMesh.Count; k++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[k];
				float x;
				float num7 = (x = uv2s[mB_DynamicGameObject.vertIdx].x);
				float y;
				float num8 = (y = uv2s[mB_DynamicGameObject.vertIdx].y);
				int num9 = mB_DynamicGameObject.vertIdx + mB_DynamicGameObject.numVerts;
				for (int l = mB_DynamicGameObject.vertIdx; l < num9; l++)
				{
					if (uv2s[l].x < num7)
					{
						num7 = uv2s[l].x;
					}
					if (uv2s[l].x > x)
					{
						x = uv2s[l].x;
					}
					if (uv2s[l].y < num8)
					{
						num8 = uv2s[l].y;
					}
					if (uv2s[l].y > y)
					{
						y = uv2s[l].y;
					}
				}
				Rect rect = rects[0].rects[k];
				for (int m = mB_DynamicGameObject.vertIdx; m < num9; m++)
				{
					float num10 = x - num7;
					float num11 = y - num8;
					if (num10 == 0f)
					{
						num10 = 1f;
					}
					if (num11 == 0f)
					{
						num11 = 1f;
					}
					uv2s[m].x = (uv2s[m].x - num7) / num10 * rect.width + rect.x;
					uv2s[m].y = (uv2s[m].y - num8) / num11 * rect.height + rect.y;
				}
			}
		}

		public override List<Material> GetMaterialsOnTargetRenderer()
		{
			List<Material> list = new List<Material>();
			if (_targetRenderer != null)
			{
				list.AddRange(_targetRenderer.sharedMaterials);
			}
			return list;
		}
	}
}
