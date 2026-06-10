using System.Collections.Generic;
using UnityEngine;

namespace UnityMeshSimplifier
{
	public static class LODGenerator
	{
		public struct StaticRenderer
		{
			public string name;

			public bool isNewMesh;

			public Transform transform;

			public Mesh mesh;

			public Material[] materials;

			public MeshRenderer originalRenderer;
		}

		public struct SkinnedRenderer
		{
			public bool hasBlendShapes;

			public string name;

			public bool isNewMesh;

			public Transform transform;

			public Mesh mesh;

			public Material[] materials;

			public Transform rootBone;

			public Transform[] bones;

			public SkinnedMeshRenderer originalRenderer;
		}

		public const string LODParentGameObjectName = "_UMS_LODs_";

		public const string LODAssetParentPath = "Assets/UMS_LODs/";

		public static LODGroup GenerateLODs(LODGeneratorHelper generatorHelper)
		{
			return null;
		}

		public static LODGroup GenerateLODs(GameObject gameObject, LODLevel[] levels, bool autoCollectRenderers, SimplificationOptions simplificationOptions)
		{
			return null;
		}

		public static LODGroup GenerateLODs(GameObject gameObject, LODLevel[] levels, bool autoCollectRenderers, SimplificationOptions simplificationOptions, string saveAssetsPath)
		{
			return null;
		}

		public static bool DestroyLODs(LODGeneratorHelper generatorHelper)
		{
			return false;
		}

		public static bool DestroyLODs(GameObject gameObject)
		{
			return false;
		}

		public static StaticRenderer[] GetStaticRenderers(MeshRenderer[] renderers)
		{
			return null;
		}

		public static SkinnedRenderer[] GetSkinnedRenderers(SkinnedMeshRenderer[] renderers)
		{
			return null;
		}

		public static StaticRenderer[] CombineStaticMeshes(Transform transform, int levelIndex, MeshRenderer[] renderers, bool autoName = true, string combinedBaseName = "")
		{
			return null;
		}

		public static SkinnedRenderer[] CombineSkinnedMeshes(Transform transform, int levelIndex, SkinnedMeshRenderer[] renderers, ref SkinnedMeshRenderer[] renderersActuallyCombined, bool autoName = true, string combinedBaseName = "")
		{
			return null;
		}

		private static void ParentAndResetTransform(Transform transform, Transform parentTransform)
		{
		}

		private static void ParentAndOffsetTransform(Transform transform, Transform parentTransform, Transform originalTransform)
		{
		}

		private static MeshRenderer CreateLevelRenderer(string name, Transform parentTransform, Transform originalTransform, Mesh mesh, Material[] materials, ref LODLevel level)
		{
			return null;
		}

		private static SkinnedMeshRenderer CreateSkinnedLevelRenderer(string name, Transform parentTransform, Transform originalTransform, Mesh mesh, Material[] materials, Transform rootBone, Transform[] bones, ref LODLevel level)
		{
			return null;
		}

		private static Transform FindBestRootBone(Transform transform, SkinnedMeshRenderer[] skinnedMeshRenderers)
		{
			return null;
		}

		private static Transform FindBestRootBone(Dictionary<Transform, Transform> topLevelParents, SkinnedMeshRenderer[] skinnedMeshRenderers)
		{
			return null;
		}

		private static void SetupLevelRenderer(Renderer renderer, ref LODLevel level)
		{
		}

		private static Renderer[] GetChildRenderersForLOD(GameObject gameObject)
		{
			return null;
		}

		private static void CollectChildRenderersForLOD(Transform transform, List<Renderer> resultRenderers)
		{
		}

		private static Mesh SimplifyMesh(Mesh mesh, float quality, SimplificationOptions options)
		{
			return null;
		}

		private static void DestroyObject(Object obj)
		{
		}

		private static void CreateBackup(GameObject gameObject, Renderer[] originalRenderers)
		{
		}

		private static void RestoreBackup(GameObject gameObject)
		{
		}

		private static void DestroyLODAssets(Transform transform)
		{
		}

		private static void DestroyLODMaterialAsset(Material material)
		{
		}

		private static void DestroyLODAsset(Object asset)
		{
		}

		private static void SaveLODMeshAsset(Object asset, string gameObjectName, string rendererName, int levelIndex, string meshName, string saveAssetsPath)
		{
		}

		private static void SaveAsset(Object asset, string path)
		{
		}

		private static void CreateParentDirectory(string path)
		{
		}

		private static string MakePathSafe(string name)
		{
			return null;
		}

		private static string ValidateSaveAssetsPath(string saveAssetsPath)
		{
			return null;
		}

		private static bool DeleteEmptyDirectory(string path)
		{
			return false;
		}
	}
}
