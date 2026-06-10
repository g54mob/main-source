using System.Collections.Generic;
using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public class ObjectBuilder
	{
		public class ProgressInfo
		{
			public int materialsLoaded;

			public int objectsLoaded;

			public int groupsLoaded;

			public int numGroups;
		}

		private class BuildStatus
		{
			public bool newObject;

			public int objCount;

			public int subObjCount;

			public int idxCount;

			public int grpIdx;

			public int numGroups;

			public int grpFaceIdx;

			public int meshPartIdx;

			public int totFaceIdxCount;

			public GameObject currObjGameObject;

			internal GameObject subObjParent;
		}

		public ImportOptions buildOptions;

		private BuildStatus buildStatus;

		private DataSet currDataSet;

		private GameObject currParentObj;

		private Dictionary<string, Material> currMaterials;

		private List<MaterialData> materialData;

		private static int MAX_VERTICES_LIMIT_FOR_A_MESH;

		private static int MAX_INDICES_LIMIT_FOR_A_MESH;

		private static int MAX_VERT_COUNT;

		public Dictionary<string, Material> ImportedMaterials => null;

		public int NumImportedMaterials => 0;

		public void InitBuildMaterials(List<MaterialData> materialData, bool hasColors)
		{
		}

		public bool BuildMaterials(ProgressInfo info)
		{
			return false;
		}

		public void StartBuildObjectAsync(DataSet dataSet, GameObject parentObj, Dictionary<string, Material> materials = null)
		{
		}

		public bool BuildObjectAsync(ref ProgressInfo info)
		{
			return false;
		}

		public static void Solve(Mesh origMesh)
		{
		}

		public static void BuildMeshCollider(GameObject targetObject, bool convex = false, bool isTrigger = false, bool inflateMesh = false, float skinWidth = 0.01f)
		{
		}

		protected bool BuildNextObject(GameObject parentObj, Dictionary<string, Material> mats)
		{
			return false;
		}

		private GameObject ImportSubObject(GameObject parentObj, DataSet.ObjectData objData, Dictionary<string, Material> mats)
		{
			return null;
		}

		private Material BuildMaterial(MaterialData md)
		{
			return null;
		}

		private bool Using32bitIndices()
		{
			return false;
		}
	}
}
