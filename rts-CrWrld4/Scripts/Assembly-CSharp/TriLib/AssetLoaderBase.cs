using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TriLib
{
	public class AssetLoaderBase : IDisposable
	{
		protected const string AssimpFilenameMagicString = "$$$___magic___$$$";

		public NodeData RootNodeData;

		public MaterialData[] MaterialData;

		public MeshData[] MeshData;

		public AnimationData[] AnimationData;

		public CameraData[] CameraData;

		public AssimpMetadata[] Metadata;

		public Dictionary<string, string> NodesPath;

		public Dictionary<string, Material> LoadedMaterials;

		public Dictionary<string, Texture2D> LoadedTextures;

		public Dictionary<SkinnedMeshRenderer, IList<string>> LoadedBoneNames;

		public Dictionary<string, MeshData> MeshDataConnections;

		public Dictionary<string, EmbeddedTextureData> EmbeddedTextures;

		public static ConcurrentList<FileLoadData> FilesLoadData;

		public static Material StandardBaseMaterial;

		public static Material StandardSpecularMaterial;

		public static Material StandardBaseAlphaMaterial;

		public static Material StandardSpecularAlphaMaterial;

		public static Material StandardBaseCutoutMaterial;

		public static Material StandardBaseFadeMaterial;

		public static Material StandardSpecularCutoutMaterial;

		public static Material StandardSpecularFadeMaterial;

		public static Material StandardRoughnessMaterial;

		public static Material StandardRoughnessCutoutMaterial;

		public static Material StandardRoughnessFadeMaterial;

		public static Material StandardRoughnessAlphaMaterial;

		public static Texture2D NotFoundTexture;

		public uint NodeId;

		public bool HasBoneInfo;

		public bool HasBlendShapes;

		protected IntPtr Scene;

		protected bool HasOnMeshCreated => false;

		protected bool HasOnMaterialCreated => false;

		protected bool HasOnTextureLoaded => false;

		public bool HasOnAvatarCreated => false;

		protected bool HasOnAnimationClipCreated => false;

		protected bool HasOnObjectLoaded => false;

		protected bool HasOnMetadataProcessed => false;

		protected bool HasOnBlendShapeKeyCreated => false;

		[Obsolete]
		public event EmbeddedTextureLoadCallback EmbeddedTextureLoad
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event MeshCreatedHandle OnMeshCreated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event MaterialCreatedHandle OnMaterialCreated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event TextureLoadHandle OnTextureLoaded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event AvatarCreatedHandle OnAvatarCreated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event AnimationClipCreatedHandle OnAnimationClipCreated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event ObjectLoadedHandle OnObjectLoaded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event MetadataProcessedHandle OnMetadataProcessed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event BlendShapeKeyCreatedHandle OnBlendShapeKeyCreated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected void TriggerOnMeshCreated(uint meshIndex, Mesh mesh)
		{
		}

		protected void TriggerOnMaterialCreated(uint materialIndex, bool isOverriden, Material material)
		{
		}

		protected void TriggerOnTextureLoaded(string sourcePath, Material material, string propertyName, Texture2D texture)
		{
		}

		public void TriggerOnAvatarCreated(Avatar avatar, Animator animator)
		{
		}

		protected void TriggerOnAnimationClipCreated(uint animationClipIndex, AnimationClip animationClip)
		{
		}

		protected void TriggerOnObjectLoaded(GameObject loadedGameObject)
		{
		}

		protected void TriggerOnMetadataProcessed(AssimpMetadataType metadataType, uint metadataIndex, string metadataKey, object metadataValue)
		{
		}

		protected void TriggerOnBlendShapeKeyCreated(Mesh mesh, string name, Vector3[] vertices, Vector3[] normals, Vector4[] tangents, Vector4[] biTangents)
		{
		}

		public static bool IsExtensionSupported(string extension)
		{
			return false;
		}

		public static string GetSupportedFileExtensions()
		{
			return null;
		}

		static AssetLoaderBase()
		{
		}

		private static void LoadAllStandardMaterials()
		{
		}

		private static bool LoadStandardMaterials()
		{
			return false;
		}

		private static bool LoadNotFoundTexture()
		{
			return false;
		}

		protected void InternalLoadFromMemory(byte[] fileBytes, string filename, string basePath, AssetLoaderOptions options = null, bool usesWrapperGameObject = false, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, LoadTextureDataCallback loadTextureDataCallback = null, AssimpInterop.ProgressCallback progressCallback = null, FileLoadData customFileLoadData = null)
		{
		}

		protected void InternalLoadFromMemoryAndZip(byte[] data, string assetExtension, string basePath, AssetLoaderOptions options = null, bool usesWrapperGameObject = false, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, LoadTextureDataCallback loadTextureDataCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
		}

		protected void InternalLoadFromFile(string filename, string basePath, AssetLoaderOptions options = null, bool usesWrapperGameObject = false, AssimpInterop.ProgressCallback progressCallback = null)
		{
		}

		protected GameObject BuildGameObject(AssetLoaderOptions options, string basePath = null, GameObject wrapperGameObject = null)
		{
			return null;
		}

		protected virtual void SetupSkinnedMeshRendererTransforms(GameObject gameObject)
		{
		}

		private static void LoadContextOptions(GameObject gameObject, AssetLoaderOptions options)
		{
		}

		protected virtual void ProcessMetadata(AssimpMetadata metadata)
		{
		}

		protected virtual void SetupAnimations(GameObject gameObject, AssetLoaderOptions options)
		{
		}

		protected virtual GameObject TransformNodeData(NodeData nodeData, AssetLoaderOptions options, GameObject existingGameObject = null)
		{
			return null;
		}

		private int CountChild(Transform transform)
		{
			return 0;
		}

		protected virtual void CreateMeshComponents(GameObject gameObject, AssetLoaderOptions options, Mesh mesh, bool hasBoneInfo, Material[] combinedMaterials, IList<string> boneNames = null, Material singleMaterial = null, MeshData meshData = null, string connectionKey = null)
		{
		}

		protected virtual void TransformCameraData(GameObject gameObject, CameraData cameraData, AssetLoaderOptions options)
		{
		}

		private static AnimationCurve FixCurve(float animationLength, AnimationCurve curve)
		{
			return null;
		}

		protected virtual void TransformAnimationData(AnimationData animationData, AssetLoaderOptions options, GameObject gameObject, bool useWrapperGameObject = false)
		{
		}

		protected virtual void TransformMeshData(MeshData meshData, AssetLoaderOptions options)
		{
		}

		protected virtual void TransformMaterialData(MaterialData materialData, AssetLoaderOptions options, string basePath = null)
		{
		}

		protected virtual Material LoadMaterial(string name, AssetLoaderOptions options, bool hasAlpha, bool hasSpecular)
		{
			return null;
		}

		protected virtual Texture2D LoadTextureFromFile(string path, string name, AssetLoaderOptions options, EmbeddedTextureData embeddedTextureData, TextureWrapMode textureWrapMode, ref bool hasAlphaChannel, bool isNormalMap, bool checkAlphaChannel = false)
		{
			return null;
		}

		private static uint GetDefaultPostProcessSteps()
		{
			return 0u;
		}

		private static IntPtr BuildPropertyStore(AssetLoaderOptions options)
		{
			return (IntPtr)0;
		}

		private static IntPtr ImportFileFromMemory(byte[] fileBytes, string fileHint, AssetLoaderOptions options, AssimpInterop.DataCallback dataCallback, AssimpInterop.ExistsCallback existsCallback, int fileId, AssimpInterop.ProgressCallback progressCallback)
		{
			return (IntPtr)0;
		}

		private static IntPtr ImportFile(string filename, AssetLoaderOptions options, AssimpInterop.ProgressCallback progressCallback)
		{
			return (IntPtr)0;
		}

		private void LoadInternal(string basePath, AssetLoaderOptions options, bool usesWrapperGameObject = false, LoadTextureDataCallback loadTextureDataCallback = null)
		{
		}

		private void BuildObjects(AssetLoaderOptions options, bool usesWrapperGameObject = false)
		{
		}

		private NodeData BuildObject(NodeData parentNodeData, IntPtr node, AssetLoaderOptions options, bool usesWrapperGameObject = false)
		{
			return null;
		}

		private AssimpMetadata[] BuildMetadata(IntPtr node)
		{
			return null;
		}

		private void BuildMeshes()
		{
		}

		private void BuildCameras()
		{
		}

		private void BuildMaterials(string basePath, AssetLoaderOptions options, LoadTextureDataCallback loadTextureDataCallback = null)
		{
		}

		private EmbeddedTextureData LoadTextureData(string path, string basePath)
		{
			return null;
		}

		private EmbeddedTextureData LoadEmbeddedTextureData(IntPtr texture, string textureName)
		{
			return null;
		}

		private void BuildBones()
		{
		}

		private void BuildAnimations(AssetLoaderOptions options)
		{
		}

		protected virtual string FixNodeName(string name, uint nodeId)
		{
			return null;
		}

		protected virtual string FixName(string name, uint id)
		{
			return null;
		}

		protected virtual string FixName(string name)
		{
			return null;
		}

		private static IntPtr DefaultDataCallback(string resourceFilename, int resourceId, ref int fileSize)
		{
			return (IntPtr)0;
		}

		private static bool DefaultExistsCallback(string resourceFilename, int resourceId)
		{
			return false;
		}

		protected void ReleaseImport()
		{
		}

		public void Dispose()
		{
		}
	}
}
