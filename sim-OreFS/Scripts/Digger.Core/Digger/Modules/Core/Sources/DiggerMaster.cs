using System.IO;
using Digger.Modules.Core.Sources.Generators;
using UnityEngine;

namespace Digger.Modules.Core.Sources
{
	[AddComponentMenu("Digger/Digger Master")]
	public class DiggerMaster : ADiggerMonoBehaviour
	{
		public const string ParentFolder = "DiggerData";

		public const string ScenesBaseFolder = "Scenes";

		[SerializeField]
		private int chunkSize = 33;

		[SerializeField]
		private string sceneDataFolder;

		[SerializeField]
		private float screenRelativeTransitionHeightLod0 = 0.1f;

		[SerializeField]
		private float screenRelativeTransitionHeightLod1 = 0.05f;

		[SerializeField]
		private int colliderLodIndex;

		[SerializeField]
		private bool createLODs;

		[SerializeField]
		private bool showUnderlyingObjects;

		[SerializeField]
		private int resolutionMult = 1;

		[SerializeField]
		private float voxelHeight = 1f;

		[SerializeField]
		private bool autoVoxelHeight;

		[SerializeField]
		private int layer;

		[SerializeField]
		private string chunksTag = "Untagged";

		[SerializeField]
		private bool enableOcclusionCulling = true;

		[SerializeField]
		private bool enableContributeGI = true;

		[SerializeField]
		private bool forceMicroSplatMaterialAssetUpdate;

		[SerializeField]
		private bool autoSaveMeshesAsAssets = true;

		[SerializeField]
		private bool autoRemoveFloatingVoxels;

		[SerializeField]
		private int maxFloatingVoxelGroupSizeToRemove = 30;

		[SerializeField]
		private ScriptableObject voxelGenerator;

		public int SizeOfMesh => chunkSize - 1;

		public int SizeVox => chunkSize + 1;

		private static string ParentPath
		{
			get
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
				if (directoryInfo.Exists && directoryInfo.Parent != null && directoryInfo.Parent.Exists)
				{
					Directory.SetCurrentDirectory(directoryInfo.Parent.FullName);
				}
				return Path.Combine("Assets", "DiggerData");
			}
		}

		private static string ScenesBasePath => Path.Combine(ParentPath, "Scenes");

		public string SceneDataPath => Path.Combine(ScenesBasePath, sceneDataFolder);

		public string SceneDataFolder
		{
			get
			{
				return sceneDataFolder;
			}
			set
			{
				sceneDataFolder = value;
			}
		}

		public float ScreenRelativeTransitionHeightLod0
		{
			get
			{
				return screenRelativeTransitionHeightLod0;
			}
			set
			{
				screenRelativeTransitionHeightLod0 = value;
			}
		}

		public float ScreenRelativeTransitionHeightLod1
		{
			get
			{
				return screenRelativeTransitionHeightLod1;
			}
			set
			{
				screenRelativeTransitionHeightLod1 = value;
			}
		}

		public int ColliderLodIndex
		{
			get
			{
				return colliderLodIndex;
			}
			set
			{
				colliderLodIndex = value;
			}
		}

		public int ResolutionMult
		{
			get
			{
				return resolutionMult;
			}
			set
			{
				resolutionMult = value;
			}
		}

		public int ChunkSize
		{
			get
			{
				return chunkSize;
			}
			set
			{
				chunkSize = value;
			}
		}

		public bool CreateLODs
		{
			get
			{
				return createLODs;
			}
			set
			{
				createLODs = value;
			}
		}

		public bool ShowUnderlyingObjects
		{
			get
			{
				return showUnderlyingObjects;
			}
			set
			{
				showUnderlyingObjects = value;
			}
		}

		public int Layer
		{
			get
			{
				return layer;
			}
			set
			{
				layer = value;
			}
		}

		public string ChunksTag
		{
			get
			{
				return chunksTag;
			}
			set
			{
				chunksTag = value ?? "Untagged";
			}
		}

		public bool EnableOcclusionCulling
		{
			get
			{
				return enableOcclusionCulling;
			}
			set
			{
				enableOcclusionCulling = value;
			}
		}

		public bool EnableContributeGI
		{
			get
			{
				return enableContributeGI;
			}
			set
			{
				enableContributeGI = value;
			}
		}

		public float VoxelHeight
		{
			get
			{
				return voxelHeight;
			}
			set
			{
				voxelHeight = value;
			}
		}

		public bool AutoVoxelHeight
		{
			get
			{
				return autoVoxelHeight;
			}
			set
			{
				autoVoxelHeight = value;
			}
		}

		public bool ForceMicroSplatMaterialAssetUpdate
		{
			get
			{
				return forceMicroSplatMaterialAssetUpdate;
			}
			set
			{
				forceMicroSplatMaterialAssetUpdate = value;
			}
		}

		public bool AutoSaveMeshesAsAssets
		{
			get
			{
				return autoSaveMeshesAsAssets;
			}
			set
			{
				autoSaveMeshesAsAssets = value;
			}
		}

		public bool AutoRemoveFloatingVoxels
		{
			get
			{
				return autoRemoveFloatingVoxels;
			}
			set
			{
				autoRemoveFloatingVoxels = value;
			}
		}

		public int MaxFloatingVoxelGroupSizeToRemove
		{
			get
			{
				return maxFloatingVoxelGroupSizeToRemove;
			}
			set
			{
				maxFloatingVoxelGroupSizeToRemove = value;
			}
		}

		public IVoxelGenerator VoxelGenerator
		{
			get
			{
				if ((voxelGenerator == null || !(voxelGenerator is IVoxelGenerator)) && voxelGenerator == null)
				{
					voxelGenerator = ScriptableObject.CreateInstance<SimpleVoxelGenerator>();
				}
				return voxelGenerator as IVoxelGenerator;
			}
			set
			{
				voxelGenerator = value as ScriptableObject;
			}
		}

		public void CreateDirs()
		{
		}
	}
}
