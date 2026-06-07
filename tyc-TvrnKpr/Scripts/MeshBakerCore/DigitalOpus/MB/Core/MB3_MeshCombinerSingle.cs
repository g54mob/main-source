using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public class MB3_MeshCombinerSingle : MB3_MeshCombiner
	{
		internal class MB_MeshCombinerSingle_BlendShapeProcessor
		{
			private MB3_MeshCombinerSingle combiner;

			private MBBlendShape[] nblendShapes;

			private bool _disposed;

			protected void Dispose(bool disposing)
			{
			}

			public void Dispose()
			{
			}

			public MB_MeshCombinerSingle_BlendShapeProcessor(MB3_MeshCombinerSingle cm)
			{
			}

			public static MBBlendShape[] GetBlendShapes(Mesh m, GameObject gameObject, Dictionary<int, MeshChannels> meshID2MeshChannels)
			{
				return null;
			}

			internal void ApplyBlendShapeFramesToMeshAndBuildMap(int newVertCount)
			{
			}

			public void AllocateBlendShapeArrayIfNecessary(int nBlendShapeSize)
			{
			}

			public void AssignNewBlendShapesToCombinerIfNecessary()
			{
			}

			public void CopyBlendShapesInCurrentMeshIfNecessary(ref int targBlendShapeIdx, MB_DynamicGameObject dgo)
			{
			}

			public void CopyBlendShapesForNewMeshIfNecessary(ref int targBlendShapeIdx, MB_DynamicGameObject dgo, Mesh mesh, IMeshChannelsCacheTaggingInterface meshChannelCache)
			{
			}

			private static string _ConvertBlendShapeNameToOutputName(string bs)
			{
				return null;
			}

			internal void ApplyBlendShapeFramesToMeshAndBuildMap_MergeBlendShapesWithTheSameName(int newVertCount)
			{
			}

			private static void _BuildSrcShape2CombinedMap(MB3_MeshCombinerSingle combiner, SerializableSourceBlendShape2Combined map, MBBlendShape[] bs)
			{
			}

			private static void _ZeroArray(Vector3[] arr, int idx, int length)
			{
			}
		}

		public class MB_MeshCombinerSingle_BoneProcessor : MB_IMeshCombinerSingle_BoneProcessor, IDisposable
		{
			private MB3_MeshCombinerSingle combiner;

			private List<MB_DynamicGameObject>[] boneIdx2dgoMap;

			private HashSet<int> boneIdxsToDelete;

			private HashSet<BoneAndBindpose> bonesToAdd;

			private Dictionary<BoneAndBindpose, int> boneAndBindPose2idx;

			private Transform[] oldBonesPreviousBake;

			private Matrix4x4[] oldBindPosesPreviousBake;

			private Transform[] nbones;

			private Matrix4x4[] nbindPoses;

			private BoneWeight[] nboneWeights;

			private BoneWeight[] boneWeights;

			private int _newBonesStartAtIdx;

			private bool _disposed;

			private bool _didSetup;

			protected void Dispose(bool disposing)
			{
			}

			public void Dispose()
			{
			}

			public int GetNewBonesSize()
			{
				return 0;
			}

			public MB_MeshCombinerSingle_BoneProcessor(MB3_MeshCombinerSingle cm)
			{
			}

			public HashSet<BoneAndBindpose> GetBonesToAdd()
			{
				return null;
			}

			public int GetNumBonesToDelete()
			{
				return 0;
			}

			public void BuildBoneIdx2DGOMapIfNecessary(int[] _goToDelete)
			{
			}

			public void RemoveBonesForDgosWeAreDeleting(MB_DynamicGameObject dgo)
			{
			}

			public void AllocateAndSetupSMRDataStructures(List<MB_DynamicGameObject> toAddDGOs, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, int newVertSize, IVertexAndTriangleProcessor vertexAndTriangleProcessor)
			{
			}

			public void UpdateGameObjects_ReadBoneWeightInfoFromCombinedMesh()
			{
			}

			public int GetNewBonesLength()
			{
				return 0;
			}

			internal void _CollectSkinningDataForDGOsInCombinedMesh(List<MB_DynamicGameObject> objsToAdd)
			{
			}

			public bool CollectBonesToAddForDGO(MB_DynamicGameObject dgo, Renderer r, bool noExtraBonesForMeshRenderers)
			{
				return false;
			}

			private List<MB_DynamicGameObject>[] _buildBoneIdx2dgoMap()
			{
				return null;
			}

			public void CopyBonesWeAreKeepingToNewBonesArrayAndAdjustBWIndexes(int totalDeleteVerts)
			{
			}

			public void InsertNewBonesIntoBonesArray()
			{
			}

			public void AddBonesToNewBonesArrayAndAdjustBWIndexes1(MB_DynamicGameObject dgo, int vertsIdx)
			{
			}

			public void UpdateGameObjects_UpdateBWIndexes(MB_DynamicGameObject dgo)
			{
			}

			public void CopyVertsNormsTansToBuffers(MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, NativeSlice<Vector3> nnorms, NativeSlice<Vector4> ntangs, NativeSlice<Vector3> nverts, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents, NativeSlice<Vector3> verts)
			{
			}

			public void CopyVertsNormsTansToBuffers(MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, Vector3[] nnorms, Vector4[] ntangs, Vector3[] nverts, Vector3[] normals, Vector4[] tangents, Vector3[] verts)
			{
			}

			public void DisposeOfTemporarySMRData()
			{
			}

			public void CopyBoneWeightsFromMeshForDGOsInCombined(MB_DynamicGameObject dgo, int targVidx)
			{
			}

			public void ApplySMRdataToMeshToBuffer()
			{
			}

			public void ApplySMRdataToMesh(MB3_MeshCombinerSingle combiner, Mesh mesh)
			{
			}

			public bool GetCachedSMRMeshData(MB_DynamicGameObject dgo)
			{
				return false;
			}

			public bool DB_CheckIntegrity()
			{
				return false;
			}
		}

		public class MB_MeshCombinerSingle_BoneProcessorNewAPI : MB_IMeshCombinerSingle_BoneProcessor, IDisposable
		{
			private MB2_LogLevel LOG_LEVEL;

			private bool _initialized;

			private bool _disposed;

			private MB3_MeshCombinerSingle combiner;

			private HashSet<BoneAndBindpose> bonesToAddAndInCombined;

			private List<BoneAndBindpose> masterList;

			private Matrix4x4[] nBindPoses;

			private Transform[] nbones;

			private int boneWeightSize;

			private int targBoneWeightIdx;

			private Dictionary<MB_DynamicGameObject, int> dgo2firstIdxInBoneWeightsArray;

			private NativeArray<byte> bonesPerVertex_nvarr;

			private NativeArray<BoneWeight1> boneWeight1s_nvarr;

			public MB_MeshCombinerSingle_BoneProcessorNewAPI(MB3_MeshCombinerSingle cm)
			{
			}

			public int GetNewBonesSize()
			{
				return 0;
			}

			public void BuildBoneIdx2DGOMapIfNecessary(int[] _goToDelete)
			{
			}

			public void RemoveBonesForDgosWeAreDeleting(MB_DynamicGameObject dgo)
			{
			}

			public bool GetCachedSMRMeshData(MB_DynamicGameObject dgo)
			{
				return false;
			}

			public void AllocateAndSetupSMRDataStructures(List<MB_DynamicGameObject> dgosToAdd, List<MB_DynamicGameObject> dgosInCombinedMesh, int newVertSize, IVertexAndTriangleProcessor vertexAndTriangleProcessor)
			{
			}

			public void UpdateGameObjects_ReadBoneWeightInfoFromCombinedMesh()
			{
			}

			public void CopyBoneWeightsFromMeshForDGOsInCombined(MB_DynamicGameObject dgo, int targVidx)
			{
			}

			public void AddBonesToNewBonesArrayAndAdjustBWIndexes1(MB_DynamicGameObject dgo, int firstVertexIdxForThisDGO)
			{
			}

			public void CopyBonesWeAreKeepingToNewBonesArrayAndAdjustBWIndexes(int totalDeleteVerts)
			{
			}

			public void CopyVertsNormsTansToBuffers(MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, Vector3[] nnorms, Vector4[] ntangs, Vector3[] nverts, Vector3[] normals, Vector4[] tangents, Vector3[] verts)
			{
			}

			public void CopyVertsNormsTansToBuffers(MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, NativeSlice<Vector3> nnorms, NativeSlice<Vector4> ntangs, NativeSlice<Vector3> nverts, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents, NativeSlice<Vector3> verts)
			{
			}

			public void InsertNewBonesIntoBonesArray()
			{
			}

			public void ApplySMRdataToMeshToBuffer()
			{
			}

			public void ApplySMRdataToMesh(MB3_MeshCombinerSingle combiner, Mesh mesh)
			{
			}

			public void UpdateGameObjects_UpdateBWIndexes(MB_DynamicGameObject dgo)
			{
			}

			protected void Dispose(bool disposing)
			{
			}

			public void Dispose()
			{
			}

			public void DisposeOfTemporarySMRData()
			{
			}

			internal void _AllocateNewArraysForCombinedMesh(int newVertSize, IVertexAndTriangleProcessor vertexAndTriangleProcessor)
			{
			}

			private bool _CollectBonesToAddForDGO_Pass2(MB_DynamicGameObject dgo, bool noExtraBonesForMeshRenderers)
			{
				return false;
			}

			private int _BuildMasterBonesArray(List<MB_DynamicGameObject> dgosToAdd, List<MB_DynamicGameObject> dgosInCombinedMesh)
			{
				return 0;
			}

			internal void _CollectSkinningDataForDGOsInCombinedMesh(List<MB_DynamicGameObject> dgosAdding, List<MB_DynamicGameObject> dgosInCombinedMesh, MeshChannelsCache_NativeArray meshChannelsCache)
			{
			}

			public bool DB_CheckIntegrity()
			{
				return false;
			}
		}

		public enum MeshCreationConditions
		{
			NoMesh = 0,
			CreatedInEditor = 1,
			CreatedAtRuntime = 2,
			AssignedByUser = 3
		}

		[Serializable]
		public struct BufferDataFromPreviousBake
		{
			public int numVertsBaked;

			public Vector3 meshVerticesShift;

			public bool meshVerticiesWereShifted;
		}

		[Serializable]
		public class SerializableIntArray
		{
			[SerializeField]
			public int[] data;

			public SerializableIntArray()
			{
			}

			public SerializableIntArray(int len)
			{
			}
		}

		public struct BoneWeightDataForMesh
		{
			private bool _disposed;

			public bool initialized;

			public bool weMustDispose;

			public NativeArray<byte> bonesPerVertex;

			public NativeArray<BoneWeight1> boneWeights;

			public bool[] UsedBoneIdxsInSrcMesh;

			public int numUsedbones;

			internal void Dispose()
			{
			}

			private void Dispose(bool disposing)
			{
			}
		}

		[Serializable]
		public class MB_DynamicGameObject : IComparable<MB_DynamicGameObject>
		{
			public int instanceID;

			public GameObject gameObject;

			public string name;

			public int vertIdx;

			public int blendShapeIdx;

			public int numVerts;

			public int numBlendShapes;

			public int numBoneWeights;

			public bool isSkinnedMeshWithBones;

			public int[] indexesOfBonesUsed;

			public int lightmapIndex;

			public Vector4 lightmapTilingOffset;

			public Vector3 meshSize;

			public bool show;

			public bool invertTriangles;

			public int[] submeshTriIdxs;

			public int[] submeshNumTris;

			public int[] targetSubmeshIdxs;

			public Rect[] uvRects;

			public Rect[] encapsulatingRect;

			public Rect[] sourceMaterialTiling;

			public Rect[] obUVRects;

			public int[] textureArraySliceIdx;

			public Material[] sourceSharedMaterials;

			[NonSerialized]
			internal bool _initialized;

			[NonSerialized]
			internal bool _beingDeleted;

			[NonSerialized]
			internal Mesh _mesh;

			[NonSerialized]
			internal Renderer _renderer;

			[NonSerialized]
			internal SerializableIntArray[] _tmpSubmeshTris;

			[NonSerialized]
			internal Transform[] _tmpSMR_CachedBones;

			[NonSerialized]
			internal List<Matrix4x4> _tmpSMR_CachedBindposes;

			[NonSerialized]
			internal BoneAndBindpose[] _tmpSMR_CachedBoneAndBindPose;

			[NonSerialized]
			internal int[] _tmpSMR_srcMeshBoneIdx2masterListBoneIdx;

			[NonSerialized]
			internal BoneWeight[] _tmpSMR_CachedBoneWeights;

			[NonSerialized]
			internal BoneWeightDataForMesh _tmpSMR_CachedBoneWeightData;

			public bool Initialize(bool beingDeleted)
			{
				return false;
			}

			public bool InitializeNew(bool beingDeleted, GameObject go)
			{
				return false;
			}

			public void UnInitialize()
			{
			}

			public int CompareTo(MB_DynamicGameObject b)
			{
				return 0;
			}
		}

		public class MeshChannels : IDisposable
		{
			private bool _disposed;

			public Vector3[] vertices;

			public Vector3[] normals;

			public Vector4[] tangents;

			public Vector2[] uv0raw;

			public Vector2[] uv0modified;

			public Vector2[] uv2raw;

			public Vector2[] uv2modified;

			public Vector2[] uv3;

			public Vector2[] uv4;

			public Vector2[] uv5;

			public Vector2[] uv6;

			public Vector2[] uv7;

			public Vector2[] uv8;

			public Color[] colors;

			public BoneWeight[] boneWeights;

			public List<Matrix4x4> bindPoses;

			public int[] triangles;

			public MBBlendShape[] blendShapes;

			public void Dispose()
			{
			}

			public bool IsDisposed()
			{
				return false;
			}

			protected virtual void Dispose(bool disposing)
			{
			}
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
			public GameObject gameObject;

			public string name;

			public int indexInSource;

			public MBBlendShapeFrame[] frames;
		}

		public struct BoneAndBindpose
		{
			public Transform bone;

			public Matrix4x4 bindPose;

			public BoneAndBindpose(Transform t, Matrix4x4 bp)
			{
				bone = null;
				bindPose = default(Matrix4x4);
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		public interface IMeshChannelsCacheTaggingInterface
		{
			void Dispose();

			bool HasCollectedMeshData();

			void CollectChannelDataForAllMeshesInList(List<MB_DynamicGameObject> toUpdateDGOs, List<MB_DynamicGameObject> toAddDGOs, MB_MeshVertexChannelFlags newChannels, MB_RenderType renderType, bool doBlendShapes);

			MBBlendShape[] GetBlendShapes(Mesh mesh, int instanceID, GameObject gameObject);

			bool hasOutOfBoundsUVs(Mesh m, ref MB_Utility.MeshAnalysisResult mar, int submeshIdx);
		}

		public class MeshChannelsCache : IDisposable, IMeshChannelsCacheTaggingInterface
		{
			private MB2_LogLevel LOG_LEVEL;

			private MB2_LightmapOptions lightmapOption;

			protected Dictionary<int, MeshChannels> meshID2MeshChannels;

			private bool _collectedMeshData;

			private bool _disposed;

			private Vector2 _HALF_UV;

			public MeshChannelsCache(MB2_LogLevel ll, MB2_LightmapOptions lo)
			{
			}

			public void Dispose()
			{
			}

			protected virtual void Dispose(bool disposing)
			{
			}

			public bool HasCollectedMeshData()
			{
				return false;
			}

			public bool hasOutOfBoundsUVs(Mesh m, ref MB_Utility.MeshAnalysisResult mar, int submeshIdx)
			{
				return false;
			}

			internal Vector3[] GetVertices(Mesh m)
			{
				return null;
			}

			internal Vector3[] GetNormals(Mesh m)
			{
				return null;
			}

			internal Vector4[] GetTangents(Mesh m)
			{
				return null;
			}

			internal Vector2[] GetUv0Raw(Mesh m)
			{
				return null;
			}

			internal Vector2[] GetUv0Modified(Mesh m)
			{
				return null;
			}

			internal Vector2[] GetUv2Modified(Mesh m)
			{
				return null;
			}

			internal Vector2[] GetUVChannel(int channel, Mesh m)
			{
				return null;
			}

			internal Color[] GetColors(Mesh m)
			{
				return null;
			}

			public void CollectChannelDataForAllMeshesInList(List<MB_DynamicGameObject> toUpdateDGOs, List<MB_DynamicGameObject> toAddDGOs, MB_MeshVertexChannelFlags newChannels, MB_RenderType renderType, bool doBlendShapes)
			{
			}

			internal List<Matrix4x4> GetBindposes(Renderer r, out bool isSkinnedMeshWithBones)
			{
				isSkinnedMeshWithBones = default(bool);
				return null;
			}

			internal BoneWeight[] GetBoneWeights(Renderer r, int numVertsInMeshBeingAdded, bool isSkinnedMeshWithBones)
			{
				return null;
			}

			public MBBlendShape[] GetBlendShapes(Mesh m, int gameObjectID, GameObject gameObject)
			{
				return null;
			}

			private Color[] _getMeshColors(Mesh m)
			{
				return null;
			}

			private Vector3[] _getMeshNormals(Mesh m)
			{
				return null;
			}

			private Vector4[] _getMeshTangents(Mesh m)
			{
				return null;
			}

			private Vector2[] _getMeshUVs(Mesh m)
			{
				return null;
			}

			private Vector2[] _getMeshUV2s(Mesh m, ref Vector2[] uv2modified)
			{
				return null;
			}

			private static void _getBindPoses(Renderer r, List<Matrix4x4> poses, out bool isSkinnedMeshWithBones)
			{
				isSkinnedMeshWithBones = default(bool);
			}

			private static BoneWeight[] _getBoneWeights(Renderer r, int numVertsInMeshBeingAdded, bool isSkinnedMeshWithBones)
			{
				return null;
			}

			private void _generateTangents(int[] triangles, Vector3[] verts, Vector2[] uvs, Vector3[] normals, Vector4[] outTangents)
			{
			}
		}

		public interface IVertexAndTriangleProcessor : IDisposable
		{
			MB_MeshVertexChannelFlags channels { get; }

			bool IsInitialized();

			bool IsDisposed();

			void Init(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int vertexCount, int[] newSubmeshTrisSize, int uvChannelWithExtraParameter, IMeshChannelsCacheTaggingInterface meshChannelsCache, bool loadDataFromCombinedMesh, MB2_LogLevel logLevel);

			void InitShowHide(MB3_MeshCombinerSingle combiner);

			void InitFromMeshCombiner(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int uvChannelWithExtraParameter);

			int GetVertexCount();

			int GetSubmeshCount();

			void TransferOwnershipOfSerializableBuffersToCombiner(MB3_MeshCombinerSingle c, MB_MeshVertexChannelFlags channelsToTransfer, BufferDataFromPreviousBake serializableBufferData);

			void CopyArraysFromPreviousBakeBuffersToNewBuffers(MB_DynamicGameObject dgo, ref IVertexAndTriangleProcessor iOldBuffers, int destStartVertIdx, int triangleIdxAdjustment, int[] targSubmeshTidx, MB2_LogLevel LOG_LEVEL);

			void CopyFromDGOMeshToBuffers(MB_DynamicGameObject dgo, int destStartVertsIdx, MB_MeshVertexChannelFlags channelsToUpdate, bool updateTris, bool updateBWdata, MB_IMeshBakerSettings settings, MB_IMeshCombinerSingle_BoneProcessor boneProcessor, int[] targSubmeshTidx, MB2_TextureBakeResults textureBakeResults, UVAdjuster_Atlas uvAdjuster, MB2_LogLevel LOG_LEVEL, IMeshChannelsCacheTaggingInterface meshChannelCache);

			void AssignBuffersToMesh(Mesh mesh, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, MB_MeshVertexChannelFlags channelsToWriteToMesh, bool doWriteTrisToMesh, IAssignToMeshCustomizer assignToMeshCustomizer, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, out BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes);

			void AssignTriangleDataForSubmeshes(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes);

			void AssignTriangleDataForSubmeshes_ShowHide(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes);

			void CopyUV2unchangedToSeparateRects(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, float uv2UnwrappingParamsPackMargin);

			int[] GetTriangleSizes();
		}

		public class MB_MeshCombinerSingle_SubCombiner
		{
			public static void instance2Combined_MapAdd(ref Dictionary<GameObject, MB_DynamicGameObject> _instance2combined_map, GameObject gameObjectID, MB_DynamicGameObject dgo)
			{
			}

			public static void instance2Combined_MapRemove(ref Dictionary<GameObject, MB_DynamicGameObject> _instance2combined_map, GameObject gameObjectID)
			{
			}

			internal static bool _ShowHideGameObjects(MB3_MeshCombinerSingle c)
			{
				return false;
			}

			internal static bool _AddToCombined(MB3_MeshCombinerSingle c, MB_MeshVertexChannelFlags newChannels, int totalAddVerts, int totalDeleteVerts, int numResultMats, int totalAddBlendShapes, int totalDeleteBlendShapes, int[] totalAddSubmeshTris, int[] totalDeleteSubmeshTris, int[] _goToDelete, List<MB_DynamicGameObject> toAddDGOs, GameObject[] _goToAdd, UVAdjuster_Atlas uvAdjuster, ref IVertexAndTriangleProcessor oldMeshData, Stopwatch sw)
			{
				return false;
			}

			public static bool _UpdateGameObjects(MB3_MeshCombinerSingle combiner, List<MB_DynamicGameObject> dgosToUpdate, MB_MeshVertexChannelFlags newChannels, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo, UVAdjuster_Atlas uVAdjuster, MB2_LogLevel LOG_LEVEL)
			{
				return false;
			}

			public static bool Apply(MB3_MeshCombinerSingle combiner, GenerateUV2Delegate uv2GenerationMethod)
			{
				return false;
			}

			public static bool Apply(MB3_MeshCombinerSingle combiner, bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapesFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
			{
				return false;
			}

			internal static bool Apply(MB3_MeshCombinerSingle combiner, bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool uv5, bool uv6, bool uv7, bool uv8, bool colors, bool bones = false, bool blendShapesFlag = false, bool suppressClearMesh = false, GenerateUV2Delegate uv2GenerationMethod = null)
			{
				return false;
			}

			public static bool ApplyShowHide(MB3_MeshCombinerSingle combiner)
			{
				return false;
			}
		}

		public class UVAdjuster_Atlas
		{
			private MB2_TextureBakeResults textureBakeResults;

			private MB2_LogLevel LOG_LEVEL;

			private int[] numTimesMatAppearsInAtlas;

			private MB_MaterialAndUVRect[] matsAndSrcUVRect;

			private bool compareNamesWhenComparingMaterials;

			public UVAdjuster_Atlas(MB2_TextureBakeResults tbr, MB2_LogLevel ll)
			{
			}

			public bool MapSharedMaterialsToAtlasRects(Material[] sharedMaterials, bool checkTargetSubmeshIdxsFromPreviousBake, Mesh m, IMeshChannelsCacheTaggingInterface meshChannelsCache, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResultsCache, OrderedDictionary sourceMats2submeshIdx_map, GameObject go, MB_DynamicGameObject dgoOut)
			{
				return false;
			}

			public bool IsSameMaterialInTextureBakeResult(Material a, Material b)
			{
				return false;
			}

			public bool TryMapMaterialToUVRect(Material mat, Mesh m, int submeshIdx, int idxInResultMats, IMeshChannelsCacheTaggingInterface meshChannelCache, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisCache, out MB_TextureTilingTreatment tilingTreatment, out Rect rectInAtlas, out Rect encapsulatingRectOut, out Rect sourceMaterialTilingOut, out int sliceIdx, ref string errorMsg, MB2_LogLevel logLevel)
			{
				tilingTreatment = default(MB_TextureTilingTreatment);
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				sliceIdx = default(int);
				return false;
			}
		}

		public struct VertexAndTriangleProcessor : IVertexAndTriangleProcessor, IDisposable
		{
			private bool _disposed;

			private bool _isInitialized;

			internal MB2_LogLevel LOG_LEVEL;

			private Vector3[] verticies;

			private Vector3[] normals;

			private Vector4[] tangents;

			private Color[] colors;

			private Vector2[] uv0s;

			private float[] uvsSliceIdx;

			private Vector2[] uv2s;

			private Vector2[] uv3s;

			private Vector2[] uv4s;

			private Vector2[] uv5s;

			private Vector2[] uv6s;

			private Vector2[] uv7s;

			private Vector2[] uv8s;

			private SerializableIntArray[] submeshTris;

			public MB_MeshVertexChannelFlags channels { get; private set; }

			public void Dispose()
			{
			}

			public bool IsInitialized()
			{
				return false;
			}

			public bool IsDisposed()
			{
				return false;
			}

			public void Init(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int vertexCount, int[] newSubmeshTrisSize, int uvChannelWithExtraParameter, IMeshChannelsCacheTaggingInterface meshChannelsCache, bool loadDataFromCombinedMesh, MB2_LogLevel logLevel)
			{
			}

			public void InitShowHide(MB3_MeshCombinerSingle combiner)
			{
			}

			public void InitFromMeshCombiner(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int uvChannelWithExtraParameter)
			{
			}

			public int GetVertexCount()
			{
				return 0;
			}

			public int GetSubmeshCount()
			{
				return 0;
			}

			public void TransferOwnershipOfSerializableBuffersToCombiner(MB3_MeshCombinerSingle c, MB_MeshVertexChannelFlags channelsToTransfer, BufferDataFromPreviousBake serializableBufferData)
			{
			}

			public void CopyArraysFromPreviousBakeBuffersToNewBuffers(MB_DynamicGameObject dgo, ref IVertexAndTriangleProcessor iOldBuffers, int destStartVertIdx, int triangleIdxAdjustment, int[] targSubmeshTidx, MB2_LogLevel LOG_LEVEL)
			{
			}

			public void CopyFromDGOMeshToBuffers(MB_DynamicGameObject dgo, int destStartVertsIdx, MB_MeshVertexChannelFlags channelsToUpdate, bool updateTris, bool updateBWdata, MB_IMeshBakerSettings settings, MB_IMeshCombinerSingle_BoneProcessor boneProcessor, int[] targSubmeshTidx, MB2_TextureBakeResults textureBakeResults, UVAdjuster_Atlas uvAdjuster, MB2_LogLevel LOG_LEVEL, IMeshChannelsCacheTaggingInterface meshChannelCacheParam)
			{
			}

			public void AssignBuffersToMesh(Mesh mesh, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, MB_MeshVertexChannelFlags channelsToWriteToMesh, bool doWriteTrisToMesh, IAssignToMeshCustomizer assignToMeshCustomizer, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, out BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
			{
				serializableBufferData = default(BufferDataFromPreviousBake);
				submeshTrisToUse = null;
				numNonZeroLengthSubmeshes = default(int);
			}

			public void AssignTriangleDataForSubmeshes(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
			{
				submeshTrisToUse = null;
				numNonZeroLengthSubmeshes = default(int);
			}

			public void AssignTriangleDataForSubmeshes_ShowHide(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
			{
				submeshTrisToUse = null;
				numNonZeroLengthSubmeshes = default(int);
			}

			private void AdjustVertsToWriteAccordingToPivotPositionIfNecessary(MB_MeshPivotLocation pivotLocationType, MB_RenderType renderType, bool clearBuffersAfterBake, Vector3 pivotLocation_wld, out BufferDataFromPreviousBake serializableBufferData, out Vector3[] verts2Write)
			{
				serializableBufferData = default(BufferDataFromPreviousBake);
				verts2Write = null;
			}

			private static int _NumNonZeroLengthSubmeshTris(SerializableIntArray[] subTris, out int numIndexes)
			{
				numIndexes = default(int);
				return 0;
			}

			private void _copyAndAdjustUVsFromMesh(MB2_TextureBakeResults tbr, MB_DynamicGameObject dgo, Mesh mesh, int uvChannel, int vertsIdx, Vector2[] uvsOut, float[] uvsSliceIdx, MeshChannelsCache meshChannelsCache, MB2_LogLevel LOG_LEVEL, MB2_TextureBakeResults textureBakeResults)
			{
			}

			private void _CopyAndAdjustUV2FromMesh(MB_IMeshBakerSettings settings, MeshChannelsCache meshChannelsCache, MB_DynamicGameObject dgo, int vertsIdx, MB2_LogLevel LOG_LEVEL)
			{
			}

			public void CopyUV2unchangedToSeparateRects(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, float uv2UnwrappingParamsPackMargin)
			{
			}

			private SerializableIntArray[] GetSubmeshTrisWithShowHideApplied(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh)
			{
				return null;
			}

			public int[] GetTriangleSizes()
			{
				return null;
			}

			private void _LocalToWorld(Transform t, bool doNorm, bool doTan, int destStartVertsIdx, Vector3[] dgoMeshVerts, Vector3[] dgoMeshNorms, Vector4[] dgoMeshTans, Vector3[] verticies, Vector3[] normals, Vector4[] tangents)
			{
			}

			private static void _LocalToWorldMatrix_TRS(ref Matrix4x4 wld_X_local, bool doNorm, bool doTan, int destStartVertsIdx, Vector3[] dgoMeshVerts, Vector3[] dgoMeshNorms, Vector4[] dgoMeshTans, Vector3[] verticies, Vector3[] normals, Vector4[] tangents)
			{
			}

			private static void _LocalToWorld_TR(Quaternion wld_Rot_local, Vector3 position_wld, bool doNorm, bool doTan, int destStartVertsIdx, Vector3[] dgoMeshVerts_local, Vector3[] dgoMeshNorms_local, Vector4[] dgoMeshTans_local, Vector3[] verticies, Vector3[] normals, Vector4[] tangents)
			{
			}

			private static void _LocalToWorld_TRS(Quaternion wld_Rot_local, Vector3 position_wld, Vector3 scale, bool doNorm, bool doTan, int destStartVertsIdx, Vector3[] dgoMeshVerts_local, Vector3[] dgoMeshNorms_local, Vector4[] dgoMeshTans_local, Vector3[] verticies, Vector3[] normals, Vector4[] tangents)
			{
			}
		}

		public class MeshChannelsCache_NativeArray : IDisposable, IMeshChannelsCacheTaggingInterface
		{
			private MB2_LogLevel LOG_LEVEL;

			private MB2_LightmapOptions lightmapOption;

			protected Dictionary<int, MeshChannelsNativeArray> meshID2MeshChannels;

			private bool _collectedMeshData;

			private bool _disposed;

			private Vector2 _HALF_UV;

			public MeshChannelsCache_NativeArray(MB2_LogLevel ll, MB2_LightmapOptions lo)
			{
			}

			public void Dispose()
			{
			}

			protected virtual void Dispose(bool disposing)
			{
			}

			public bool HasCollectedMeshData()
			{
				return false;
			}

			public bool hasOutOfBoundsUVs(Mesh m, ref MB_Utility.MeshAnalysisResult mar, int submeshIdx)
			{
				return false;
			}

			internal NativeArray<Vector3> GetVerticiesAsNativeArray(Mesh m)
			{
				return default(NativeArray<Vector3>);
			}

			internal NativeArray<Vector3> GetNormalsAsNativeArray(Mesh m)
			{
				return default(NativeArray<Vector3>);
			}

			internal NativeArray<Vector4> GetTangentsAsNativeArray(Mesh m)
			{
				return default(NativeArray<Vector4>);
			}

			internal NativeArray<Vector2> GetUv0RawAsNativeArray(Mesh m)
			{
				return default(NativeArray<Vector2>);
			}

			internal NativeArray<Vector2> GetUv0ModifiedAsNativeArray(Mesh m)
			{
				return default(NativeArray<Vector2>);
			}

			internal NativeArray<Vector2> GetUv2ModifiedAsNativeArray(Mesh m)
			{
				return default(NativeArray<Vector2>);
			}

			internal NativeArray<Vector2> GetUVChannelAsNativeArray(int channel, Mesh m)
			{
				return default(NativeArray<Vector2>);
			}

			internal NativeArray<Color> GetColorsAsNativeArray(Mesh m)
			{
				return default(NativeArray<Color>);
			}

			public void CollectChannelDataForAllMeshesInList(List<MB_DynamicGameObject> toUpdateDGOs, List<MB_DynamicGameObject> toAddDGOs, MB_MeshVertexChannelFlags newChannels, MB_RenderType renderType, bool doBlendShapes)
			{
			}

			internal List<Matrix4x4> GetBindposes(Renderer r, out bool isSkinnedMeshWithBones)
			{
				isSkinnedMeshWithBones = default(bool);
				return null;
			}

			internal BoneWeightDataForMesh GetBoneWeightData(Renderer r, int numbones, bool isSkinnedMeshWithBones)
			{
				return default(BoneWeightDataForMesh);
			}

			public MBBlendShape[] GetBlendShapes(Mesh m, int gameObjectID, GameObject gameObject)
			{
				return null;
			}

			private Color[] _getMeshColors(Mesh m)
			{
				return null;
			}

			private Vector3[] _getMeshNormals(Mesh m)
			{
				return null;
			}

			private Vector4[] _getMeshTangents(Mesh m)
			{
				return null;
			}

			private Vector2[] _getMeshUVs(Mesh m)
			{
				return null;
			}

			private Vector2[] _getMeshUV2s(Mesh m, ref NativeArray<Vector2> uv2modified)
			{
				return null;
			}

			private static void _getBindPoses(Renderer r, List<Matrix4x4> poses, out bool isSkinnedMeshWithBones)
			{
				isSkinnedMeshWithBones = default(bool);
			}

			private static void _getBoneWeightData(ref BoneWeightDataForMesh bwd, Renderer r, int numBones, bool isSkinnedMeshWithBones)
			{
			}

			internal NativeArray<Vector2> GetUv0Raw(Mesh m)
			{
				return default(NativeArray<Vector2>);
			}

			private static BoneWeight[] _getBoneWeights(Renderer r, int numVertsInMeshBeingAdded, bool isSkinnedMeshWithBones)
			{
				return null;
			}

			private void _generateTangents(int[] triangles, Vector3[] verts, NativeArray<Vector2> uvs, Vector3[] normals, Vector4[] outTangents)
			{
			}
		}

		public class MeshChannelsNativeArray : IDisposable
		{
			private bool _disposed;

			public NativeArray<Vector3> vertcies_NativeArray;

			public NativeArray<Vector3> normals_NativeArray;

			public NativeArray<Vector4> tangents_NativeArray;

			public NativeArray<Color> colors_NativeArray;

			public NativeArray<Vector2> uv0raw_NativeArray;

			public NativeArray<Vector2> uv0modified_NativeArray;

			public NativeArray<Vector2> uv2raw_NativeArray;

			public NativeArray<Vector2> uv2modified_NativeArray;

			public NativeArray<Vector2> uv3_NativeArray;

			public NativeArray<Vector2> uv4_NativeArray;

			public NativeArray<Vector2> uv5_NativeArray;

			public NativeArray<Vector2> uv6_NativeArray;

			public NativeArray<Vector2> uv7_NativeArray;

			public NativeArray<Vector2> uv8_NativeArray;

			public List<Matrix4x4> bindPoses;

			public BoneWeightDataForMesh boneWeightData;

			public MBBlendShape[] blendShapes;

			public void Dispose()
			{
			}

			public bool IsDisposed()
			{
				return false;
			}

			protected virtual void Dispose(bool disposing)
			{
			}
		}

		public struct MB_MeshCombinerSingle_MeshNativeArrayHelper
		{
			public struct SIZER_4
			{
				public unsafe fixed byte data[4];
			}

			public struct SIZER_8
			{
				public unsafe fixed byte data[8];
			}

			public struct SIZER_12
			{
				public unsafe fixed byte data[12];
			}

			public struct SIZER_16
			{
				public unsafe fixed byte data[16];
			}

			public struct SIZER_20
			{
				public unsafe fixed byte data[20];
			}

			public struct SIZER_24
			{
				public unsafe fixed byte data[24];
			}

			public struct SIZER_28
			{
				public unsafe fixed byte data[28];
			}

			public struct SIZER_32
			{
				public unsafe fixed byte data[32];
			}

			public struct SIZER_36
			{
				public unsafe fixed byte data[36];
			}

			public struct SIZER_40
			{
				public unsafe fixed byte data[40];
			}

			public struct SIZER_44
			{
				public unsafe fixed byte data[44];
			}

			public struct SIZER_48
			{
				public unsafe fixed byte data[48];
			}

			public struct SIZER_52
			{
				public unsafe fixed byte data[52];
			}

			public struct SIZER_56
			{
				public unsafe fixed byte data[56];
			}

			public struct SIZER_60
			{
				public unsafe fixed byte data[60];
			}

			public struct SIZER_64
			{
				public unsafe fixed byte data[64];
			}

			public struct SIZER_68
			{
				public unsafe fixed byte data[68];
			}

			public struct SIZER_72
			{
				public unsafe fixed byte data[72];
			}

			public struct SIZER_76
			{
				public unsafe fixed byte data[72];
			}

			public struct SIZER_80
			{
				public unsafe fixed byte data[80];
			}

			public struct SIZER_84
			{
				public unsafe fixed byte data[84];
			}

			public struct SIZER_88
			{
				public unsafe fixed byte data[88];
			}

			public struct SIZER_92
			{
				public unsafe fixed byte data[92];
			}

			public struct SIZER_96
			{
				public unsafe fixed byte data[96];
			}

			public struct SIZER_100
			{
				public unsafe fixed byte data[100];
			}

			public struct SIZER_104
			{
				public unsafe fixed byte data[104];
			}

			public struct SIZER_108
			{
				public unsafe fixed byte data[108];
			}

			public struct SIZER_112
			{
				public unsafe fixed byte data[112];
			}

			public struct SIZER_116
			{
				public unsafe fixed byte data[116];
			}

			public struct SIZER_120
			{
				public unsafe fixed byte data[120];
			}

			public struct SIZER_124
			{
				public unsafe fixed byte data[124];
			}

			public struct SIZER_128
			{
				public unsafe fixed byte data[128];
			}

			public struct SIZER_132
			{
				public unsafe fixed byte data[132];
			}

			public struct SIZER_136
			{
				public unsafe fixed byte data[136];
			}

			public struct SIZER_140
			{
				public unsafe fixed byte data[140];
			}

			public struct SIZER_144
			{
				public unsafe fixed byte data[144];
			}

			public struct SIZER_148
			{
				public unsafe fixed byte data[148];
			}

			public struct SIZER_152
			{
				public unsafe fixed byte data[152];
			}

			private static Type[] _TypeForStride;

			public Mesh.MeshDataArray dataArray;

			public Mesh.MeshData data;

			public int vertexCount;

			[Preserve]
			public void _ENSURE_IL2CPP_CREATES_NECESSARY_CODE(ref Mesh.MeshData m)
			{
			}

			public static int CalcStride(MB_MeshVertexChannelFlags channels, int uvChannelWithExtraParameter, out int strideVertexBuffer, out int strideUVbuffer)
			{
				strideVertexBuffer = default(int);
				strideUVbuffer = default(int);
				return 0;
			}

			public static void Init(MB_MeshVertexChannelFlags channels, VertexAttributeDescriptor[] vertexAttributes, ref VertexAndTriangleProcessorNativeArray nativeSlices, int vertexCount, int[] submeshCount, int uvChannelWithExtraParameter)
			{
			}

			public static void AllocateWriteableMeshData(ref VertexAndTriangleProcessorNativeArray nativeSlices, VertexAttributeDescriptor[] channels, int vertexCount, int numBuffers)
			{
			}

			public static void SetupNativeSlices(ref VertexAndTriangleProcessorNativeArray nativeSlices, int strideVertexData, int strideUVdata, int uvChannelWithExtraParameter)
			{
			}

			public static void NativeSliceCopyFrom(object toHereSlice, Type toHereSizerType, object fromHereSlice, Type fromHereSizerType)
			{
			}

			public static void NativeSliceCopy<T>(NativeSlice<T> srcArray, int srcStartIdx, NativeSlice<T> destArray, int destStartIdx, int length) where T : struct
			{
			}

			public static void NativeSliceCopyTo<T>(NativeSlice<T> srcArray, NativeSlice<T> destArray, int destStartIdx) where T : struct
			{
			}
		}

		public struct VertexAndTriangleProcessorNativeArray : IVertexAndTriangleProcessor, IDisposable
		{
			private bool _disposed;

			private bool _isInitialized;

			internal MB2_LogLevel LOG_LEVEL;

			internal VertexAttributeDescriptor[] vertexAttributes;

			internal bool dataArrayAllocated;

			internal Mesh.MeshDataArray dataArray;

			internal Mesh.MeshData data;

			internal int vertexCount;

			internal NativeArray<Vector3> verticiesModified;

			internal NativeSlice<Vector3> verticies;

			internal NativeSlice<Vector3> normals;

			internal NativeSlice<Vector4> tangents;

			internal NativeSlice<Color> colors;

			internal NativeSlice<Vector2> uv0s;

			internal NativeSlice<Vector2> uv2s;

			internal NativeSlice<Vector2> uv3s;

			internal NativeSlice<Vector2> uv4s;

			internal NativeSlice<Vector2> uv5s;

			internal NativeSlice<Vector2> uv6s;

			internal NativeSlice<Vector2> uv7s;

			internal NativeSlice<Vector2> uv8s;

			internal NativeSlice<float> uvsSliceIdx;

			internal NativeSlice<Vector3> uvsWithExtraIndex;

			private SerializableIntArray[] submeshTris;

			internal NativeArray<ushort> triangleBuffer;

			internal int bufferStride_0;

			internal int bufferStride_1;

			internal int bufferStride_2;

			internal Type rawSliceSizerType_0;

			internal Type rawSliceSizerType_1;

			internal object rawSliceVertexStream_0;

			internal object rawSliceVertexStream_1;

			public MB_MeshVertexChannelFlags channels { get; private set; }

			public void Dispose()
			{
			}

			public bool IsInitialized()
			{
				return false;
			}

			public bool IsDisposed()
			{
				return false;
			}

			public void Init(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int vertexCount, int[] newSubmeshTrisSize, int uvChannelWithExtraParameter, IMeshChannelsCacheTaggingInterface meshChannelsCache, bool loadDataFromCombinedMesh, MB2_LogLevel logLevel)
			{
			}

			public void InitShowHide(MB3_MeshCombinerSingle combiner)
			{
			}

			public void InitFromMeshCombiner(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int uvChannelWithExtraParameter)
			{
			}

			public void ApplyDataBufferToMesh(Mesh m)
			{
			}

			public int GetVertexCount()
			{
				return 0;
			}

			public int GetSubmeshCount()
			{
				return 0;
			}

			public void TransferOwnershipOfSerializableBuffersToCombiner(MB3_MeshCombinerSingle c, MB_MeshVertexChannelFlags channelsToTransfer, BufferDataFromPreviousBake serializableBufferData)
			{
			}

			public void CopyArraysFromPreviousBakeBuffersToNewBuffers(MB_DynamicGameObject dgo, ref IVertexAndTriangleProcessor iOldBuffers, int destStartVertIdx, int triangleIdxAdjustment, int[] targSubmeshTidx, MB2_LogLevel LOG_LEVEL)
			{
			}

			public void CopyFromDGOMeshToBuffers(MB_DynamicGameObject dgo, int destStartVertsIdx, MB_MeshVertexChannelFlags channelsToUpdate, bool updateTris, bool updateBWdata, MB_IMeshBakerSettings settings, MB_IMeshCombinerSingle_BoneProcessor boneProcessor, int[] targSubmeshTidx, MB2_TextureBakeResults textureBakeResults, UVAdjuster_Atlas uvAdjuster, MB2_LogLevel LOG_LEVEL, IMeshChannelsCacheTaggingInterface meshChannelCacheParam)
			{
			}

			public void AssignBuffersToMesh(Mesh mesh, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, MB_MeshVertexChannelFlags channelsToWriteToMesh, bool doWriteTrisToMesh, IAssignToMeshCustomizer assignToMeshCustomizer, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, out BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
			{
				serializableBufferData = default(BufferDataFromPreviousBake);
				submeshTrisToUse = null;
				numNonZeroLengthSubmeshes = default(int);
			}

			public void AssignTriangleDataForSubmeshes(Mesh mmesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
			{
				submeshTrisToUse = null;
				numNonZeroLengthSubmeshes = default(int);
			}

			public void AssignTriangleDataForSubmeshes_ShowHide(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
			{
				submeshTrisToUse = null;
				numNonZeroLengthSubmeshes = default(int);
			}

			private void AdjustVertsToWriteAccordingToPivotPositionIfNecessary(MB_MeshPivotLocation pivotLocationType, MB_RenderType renderType, bool clearBuffersAfterBake, Vector3 pivotLocation_wld, out BufferDataFromPreviousBake serializableBufferData)
			{
				serializableBufferData = default(BufferDataFromPreviousBake);
			}

			private static int _NumNonZeroLengthSubmeshTris(SerializableIntArray[] subTris, out int numIndexes)
			{
				numIndexes = default(int);
				return 0;
			}

			private void _copyAndAdjustUVsFromMesh(MB2_TextureBakeResults tbr, MB_DynamicGameObject dgo, Mesh mesh, int uvChannel, int vertsIdx, NativeSlice<Vector2> uvsOut, NativeSlice<float> uvsSliceIdx, MeshChannelsCache_NativeArray meshChannelsCache, MB2_LogLevel LOG_LEVEL, MB2_TextureBakeResults textureBakeResults)
			{
			}

			private void _CopyAndAdjustUV2FromMesh(MB_IMeshBakerSettings settings, MeshChannelsCache_NativeArray meshChannelsCache, MB_DynamicGameObject dgo, int vertsIdx, MB2_LogLevel LOG_LEVEL)
			{
			}

			public void CopyUV2unchangedToSeparateRects(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, float uv2UnwrappingParamsPackMargin)
			{
			}

			private SerializableIntArray[] GetSubmeshTrisWithShowHideApplied(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh)
			{
				return null;
			}

			public int[] GetTriangleSizes()
			{
				return null;
			}

			private void _LocalToWorld(Transform t, bool doNorm, bool doTan, int destStartVertsIdx, NativeArray<Vector3> dgoMeshVerts, NativeArray<Vector3> dgoMeshNorms, NativeArray<Vector4> dgoMeshTans, NativeSlice<Vector3> verticies, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents)
			{
			}

			private static void _LocalToWorldMatrix_TRS(ref Matrix4x4 wld_X_local, bool doNorm, bool doTan, int destStartVertsIdx, NativeSlice<Vector3> dgoMeshVerts, NativeSlice<Vector3> dgoMeshNorms, NativeSlice<Vector4> dgoMeshTans, NativeSlice<Vector3> verticies, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents)
			{
			}

			private static void _LocalToWorld_TR(Quaternion wld_Rot_local, Vector3 position_wld, bool doNorm, bool doTan, int destStartVertsIdx, NativeSlice<Vector3> dgoMeshVerts_local, NativeSlice<Vector3> dgoMeshNorms_local, NativeSlice<Vector4> dgoMeshTans_local, NativeSlice<Vector3> verticies, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents)
			{
			}

			private static void _LocalToWorld_TRS(Quaternion wld_Rot_local, Vector3 position_wld, Vector3 scale, bool doNorm, bool doTan, int destStartVertsIdx, NativeSlice<Vector3> dgoMeshVerts_local, NativeSlice<Vector3> dgoMeshNorms_local, NativeSlice<Vector4> dgoMeshTans_local, NativeSlice<Vector3> verticies, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents)
			{
			}
		}

		public Stopwatch db_showHideGameObjects;

		public Stopwatch db_addDeleteGameObjects;

		public Stopwatch db_addDeleteGameObjects_CollectMeshData;

		public Stopwatch db_addDeleteGameObjects_CollectMeshData_a;

		public Stopwatch db_addDeleteGameObjects_CollectMeshData_b;

		public Stopwatch db_addDeleteGameObjects_CollectMeshData_c;

		public Stopwatch db_addDeleteGameObjects_InitFromMeshCombiner;

		public Stopwatch db_addDeleteGameObjects_Init;

		public Stopwatch db_addDeleteGameObjects_CopyArraysFromPreviousBakeBuffersToNewBuffers;

		public Stopwatch db_addDeleteGameObjects_CopyFromDGOMeshToBuffers;

		public Stopwatch db_apply;

		public Stopwatch db_applyShowHide;

		public Stopwatch db_updateGameObjects;

		[SerializeField]
		protected List<GameObject> objectsInCombinedMesh;

		[SerializeField]
		private int lightmapIndex;

		[SerializeField]
		public List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh;

		private Dictionary<GameObject, MB_DynamicGameObject> _instance2combined_map;

		[SerializeField]
		private MB_MeshVertexChannelFlags channelsLastBake;

		[SerializeField]
		private Vector3[] verts;

		[SerializeField]
		private Vector3[] normals;

		[SerializeField]
		private Vector4[] tangents;

		[SerializeField]
		private Vector2[] uvs;

		[SerializeField]
		private float[] uvsSliceIdx;

		[SerializeField]
		private Vector2[] uv2s;

		[SerializeField]
		private Vector2[] uv3s;

		[SerializeField]
		private Vector2[] uv4s;

		[SerializeField]
		private Vector2[] uv5s;

		[SerializeField]
		private Vector2[] uv6s;

		[SerializeField]
		private Vector2[] uv7s;

		[SerializeField]
		private Vector2[] uv8s;

		[SerializeField]
		private Color[] colors;

		[SerializeField]
		private SerializableIntArray[] submeshTris;

		[SerializeField]
		private Matrix4x4[] bindPoses;

		[SerializeField]
		private Transform[] bones;

		[SerializeField]
		internal MBBlendShape[] blendShapes;

		[SerializeField]
		internal BufferDataFromPreviousBake bufferDataFromPrevious;

		[SerializeField]
		private MeshCreationConditions _meshBirth;

		[SerializeField]
		private Mesh _mesh;

		internal IVertexAndTriangleProcessor _vertexAndTriProcessor;

		protected MB_IMeshCombinerSingle_BoneProcessor _boneProcessor;

		internal MB_MeshCombinerSingle_BlendShapeProcessor _blendShapeProcessor;

		protected IMeshChannelsCacheTaggingInterface _meshChannelsCache;

		private GameObject[] empty;

		private int[] emptyIDs;

		public override MB2_TextureBakeResults textureBakeResults
		{
			set
			{
			}
		}

		public override MB_RenderType renderType
		{
			set
			{
			}
		}

		public override GameObject resultSceneObject
		{
			set
			{
			}
		}

		public void StartProfile()
		{
		}

		public void PrintProfileInfo()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public int GetVertexCount()
		{
			return 0;
		}

		private MB_DynamicGameObject instance2Combined_MapGet(GameObject gameObjectID)
		{
			return null;
		}

		private void instance2Combined_MapAdd(GameObject gameObjectID, MB_DynamicGameObject dgo)
		{
		}

		private void instance2Combined_MapRemove(GameObject gameObjectID)
		{
		}

		private bool instance2Combined_MapTryGetValue(GameObject gameObjectID, out MB_DynamicGameObject dgo)
		{
			dgo = null;
			return false;
		}

		private int instance2Combined_MapCount()
		{
			return 0;
		}

		private void instance2Combined_MapClear()
		{
		}

		private bool instance2Combined_MapContainsKey(GameObject gameObjectID)
		{
			return false;
		}

		public bool InstanceID2DGO(int instanceID, out MB_DynamicGameObject dgoGameObject)
		{
			dgoGameObject = null;
			return false;
		}

		public override int GetNumObjectsInCombined()
		{
			return 0;
		}

		public override List<GameObject> GetObjectsInCombined()
		{
			return null;
		}

		public Mesh GetMesh()
		{
			return null;
		}

		public MeshCreationConditions SetMesh(Mesh m)
		{
			return default(MeshCreationConditions);
		}

		public Transform[] GetBones()
		{
			return null;
		}

		public override int GetLightmapIndex()
		{
			return 0;
		}

		private bool _Initialize(int numResultMats)
		{
			return false;
		}

		private bool _collectMaterialTriangles(Mesh m, MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map)
		{
			return false;
		}

		private bool _collectOutOfBoundsUVRects2(Mesh m, MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResults)
		{
			return false;
		}

		private bool _validateTextureBakeResults()
		{
			return false;
		}

		internal bool _ShowHide(GameObject[] goToShow, GameObject[] goToHide)
		{
			return false;
		}

		internal bool _AddToCombined(GameObject[] goToAdd, int[] goToDelete, bool disableRendererInSource)
		{
			return false;
		}

		internal bool __AddToCombined(GameObject[] _goToAdd, int[] _goToDelete, bool disableRendererInSource, int numResultMats, OrderedDictionary sourceMats2submeshIdx_map, ref IVertexAndTriangleProcessor oldMeshData, MB_MeshVertexChannelFlags newChannels, Stopwatch sw)
		{
			return false;
		}

		private Transform[] _getBones(Renderer r, bool isSkinnedMeshWithBones)
		{
			return null;
		}

		public override bool Apply(GenerateUV2Delegate uv2GenerationMethod)
		{
			return false;
		}

		public virtual void ApplyShowHide()
		{
		}

		public override bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapesFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
		{
			return false;
		}

		public override bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool uv5, bool uv6, bool uv7, bool uv8, bool colors, bool bones = false, bool blendShapesFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
		{
			return false;
		}

		public override bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateColors, bool updateSkinningInfo)
		{
			return false;
		}

		public override bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo)
		{
			return false;
		}

		internal bool _UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo)
		{
			return false;
		}

		private bool __UpdateGameObjects(GameObject[] gos, bool recalcBounds, MB_MeshVertexChannelFlags newChannels, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResultsCache, OrderedDictionary sourceMats2submeshIdx_map, UVAdjuster_Atlas uVAdjuster)
		{
			return false;
		}

		public bool ShowHideGameObjects(GameObject[] toShow, GameObject[] toHide)
		{
			return false;
		}

		public override bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource = true)
		{
			return false;
		}

		public override bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource)
		{
			return false;
		}

		public override bool CombinedMeshContains(GameObject go)
		{
			return false;
		}

		public override void ClearBuffers()
		{
		}

		private Mesh _NewMesh()
		{
			return null;
		}

		public override void ClearMesh()
		{
		}

		public override void ClearMesh(MB2_EditorMethodsInterface editorMethods)
		{
		}

		internal override void _DisposeRuntimeCreated()
		{
		}

		public override void DestroyMesh()
		{
		}

		public override void DestroyMeshEditor(MB2_EditorMethodsInterface editorMethods)
		{
		}

		public bool ValidateTargRendererAndMeshAndResultSceneObj()
		{
			return false;
		}

		private OrderedDictionary BuildSourceMatsToSubmeshIdxMap(int numResultMats)
		{
			return null;
		}

		internal Renderer BuildSceneHierarchPreBake(MB3_MeshCombinerSingle mom, GameObject root, Mesh m, bool createNewChild = false, GameObject[] objsToBeAdded = null)
		{
			return null;
		}

		private static void _ConfigureSceneHierarch(MB3_MeshCombinerSingle mom, GameObject root, MeshRenderer mr, MeshFilter mf, SkinnedMeshRenderer smr, Mesh m, GameObject[] objsToBeAdded = null)
		{
		}

		private void _SetLightmapIndexIfPreserveLightmapping(Renderer tr)
		{
		}

		public void BuildSceneMeshObject(GameObject[] gos = null, bool createNewChild = false)
		{
		}

		private bool IsMirrored(Matrix4x4 tm)
		{
			return false;
		}

		public override void CheckIntegrity()
		{
		}

		public override List<Material> GetMaterialsOnTargetRenderer()
		{
			return null;
		}

		private bool _UseNativeArrayAPIorNot()
		{
			return false;
		}

		public MB_IMeshCombinerSingle_BoneProcessor Create_BoneProcessor(bool doNativeArrays)
		{
			return null;
		}

		public static IVertexAndTriangleProcessor Create_VertexAndTriangleProcessor(bool doNativeArrays)
		{
			return null;
		}

		public static IMeshChannelsCacheTaggingInterface Create_MeshChannelsCache(bool doNativeArrays, MB2_LogLevel LOG_LEVEL, MB2_LightmapOptions lightmapOption)
		{
			return null;
		}

		public override void UpdateSkinnedMeshApproximateBounds()
		{
		}

		public override void UpdateSkinnedMeshApproximateBoundsFromBones()
		{
		}

		public override void UpdateSkinnedMeshApproximateBoundsFromBounds()
		{
		}

		private static void _UpdateMaterialsOnTargetRenderer(MB2_TextureBakeResults textureBakeResults, Renderer targetRenderer, SerializableIntArray[] subTris, int numNonZeroLengthSubmeshTris)
		{
		}
	}
}
