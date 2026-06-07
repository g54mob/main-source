using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Synty.SidekickCharacters.Database;
using Synty.SidekickCharacters.Database.DTO;
using Synty.SidekickCharacters.Enums;
using UnityEngine;

namespace Synty.SidekickCharacters.API
{
	public class SidekickRuntime
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CPopulateToolData_003Ed__119 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public SidekickRuntime runtime;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const string _BLEND_GENDER_NAME = "masculineFeminine";

		private const string _BLEND_MUSCLE_NAME = "defaultBuff";

		private const string _BLEND_SHAPE_HEAVY_NAME = "defaultHeavy";

		private const string _BLEND_SHAPE_SKINNY_NAME = "defaultSkinny";

		private const string _TEXTURE_COLOR_NAME = "ColorMap.png";

		private const string _TEXTURE_METALLIC_NAME = "MetallicMap.png";

		private const string _TEXTURE_SMOOTHNESS_NAME = "SmoothnessMap.png";

		private const string _TEXTURE_REFLECTION_NAME = "ReflectionMap.png";

		private const string _TEXTURE_EMISSION_NAME = "EmissionMap.png";

		private const string _TEXTURE_OPACITY_NAME = "OpacityMap.png";

		private const string _TEXTURE_PREFIX = "T_";

		private static readonly int _COLOR_MAP;

		private static readonly int _METALLIC_MAP;

		private static readonly int _SMOOTHNESS_MAP;

		private static readonly int _REFLECTION_MAP;

		private static readonly int _EMISSION_MAP;

		private static readonly int _OPACITY_MAP;

		private DatabaseManager _dbManager;

		private GameObject _baseModel;

		private Material _currentMaterial;

		private RuntimeAnimatorController _currentAnimationController;

		private List<Vector2> _currentUVList;

		private Dictionary<ColorPartType, List<Vector2>> _currentUVDictionary;

		private Dictionary<string, Vector3> _blendShapeRigMovement;

		private Dictionary<string, Quaternion> _blendShapeRigRotation;

		private Dictionary<CharacterPartType, Dictionary<string, string>> _partLibrary;

		private Dictionary<CharacterPartType, List<SidekickPart>> _allPartsLibrary;

		private Dictionary<string, List<string>> _partOutfitMap;

		private Dictionary<string, bool> _partOutfitToggleMap;

		private Dictionary<string, Dictionary<SidekickSpecies, Dictionary<CharacterPartType, List<string>>>> _filterPartDictionary;

		private Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> _mappedPartDictionary;

		private Dictionary<CharacterPartType, List<string>> _mappedPartList;

		private Dictionary<SidekickSpecies, Dictionary<CharacterPartType, List<string>>> _mappedBasePartDictionary;

		private Dictionary<string, SidekickSpecies> _speciesDictionary;

		private Dictionary<string, List<SidekickPartPreset>> _mappedPresetFilterDictionary;

		private Dictionary<SidekickSpecies, List<SidekickPartPreset>> _mappedBasePresetDictionary;

		private int _partCount;

		private SidekickSpecies _currentSpecies;

		private static Dictionary<CharacterPartType, List<SidekickPart>> s_cachedAllPartsLibrary;

		private static Dictionary<CharacterPartType, List<string>> s_cachedMappedPartList;

		private static Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> s_cachedMappedPartDictionary;

		private static Dictionary<SidekickSpecies, Dictionary<CharacterPartType, List<string>>> s_cachedMappedBasePartDictionary;

		private static Dictionary<string, SidekickSpecies> s_cachedSpeciesDictionary;

		private static int s_cachedPartCount;

		private static bool s_partLibraryCached;

		private static Dictionary<string, List<SidekickPartPreset>> s_cachedMappedPresetFilterDictionary;

		private static Dictionary<SidekickSpecies, List<SidekickPartPreset>> s_cachedMappedBasePresetDictionary;

		private static bool s_presetLibraryCached;

		private float _bodyTypeBlendValue;

		private float _bodySizeSkinnyBlendValue;

		private float _bodySizeHeavyBlendValue;

		private float _musclesBlendValue;

		public DatabaseManager DBManager
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameObject BaseModel
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material CurrentMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RuntimeAnimatorController CurrentAnimationController
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<Vector2> CurrentUVList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<ColorPartType, List<Vector2>> CurrentUVDictionary
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<CharacterPartType, Dictionary<string, string>> PartLibrary
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int PartCount
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public Dictionary<string, List<string>> PartOutfitMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<string, bool> PartOutfitToggleMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float BodyTypeBlendValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float BodySizeSkinnyBlendValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float BodySizeHeavyBlendValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MusclesBlendValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public SidekickSpecies CurrentSpecies
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<string, Dictionary<SidekickSpecies, Dictionary<CharacterPartType, List<string>>>> FilterPartDictionary
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> MappedPartDictionary
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public Dictionary<SidekickSpecies, Dictionary<CharacterPartType, List<string>>> MappedBasePartDictionary
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public Dictionary<CharacterPartType, List<string>> MappedPartList
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public Dictionary<CharacterPartType, List<SidekickPart>> AllPartsLibrary
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public Dictionary<string, List<SidekickPartPreset>> MappedPresetFilterDictionary
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public Dictionary<SidekickSpecies, List<SidekickPartPreset>> MappedBasePresetDictionary
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public SidekickRuntime(GameObject model, Material material, RuntimeAnimatorController animationController = null, DatabaseManager dbManager = null)
		{
		}

		[AsyncStateMachine(typeof(_003CPopulateToolData_003Ed__119))]
		public static Task PopulateToolData(SidekickRuntime runtime)
		{
			return null;
		}

		public GameObject CreateCharacter(string modelName, List<SkinnedMeshRenderer> toCombine, bool combineMesh, bool processBoneMovement, GameObject existingModel = null)
		{
			return null;
		}

		public GameObject CreateModelFromParts(List<SkinnedMeshRenderer> parts, string outputModelName, GameObject existingModel = null)
		{
			return null;
		}

		public void PopulateUVDictionary(List<SkinnedMeshRenderer> usedParts)
		{
		}

		public void UpdateBlendShapes(GameObject model)
		{
		}

		public Dictionary<CharacterPartType, Dictionary<string, string>> PopulatePartLibrary()
		{
			return null;
		}

		public Task PopulatePresetLibrary()
		{
			return null;
		}

		public Task LoadPartLibrary()
		{
			return null;
		}

		public string GetOutfitNameFromPartName(string partName)
		{
			return null;
		}

		public CharacterPartType ExtractPartType(string partName)
		{
			return default(CharacterPartType);
		}

		public string ExtractPartTypeString(string partName)
		{
			return null;
		}

		public void ProcessRigMovementOnBlendShapeChange(Dictionary<CharacterPartType, Dictionary<BlendShapeType, SidekickBlendShapeRigMovement>> offsetLibrary)
		{
		}

		public void ProcessBoneMovement(GameObject model)
		{
		}

		public void UpdateColor(ColorType colorType, SidekickColorRow colorRow)
		{
		}

		public void UpdateTexture(Texture2D texture, Color newColor, int u, int v)
		{
		}
	}
}
