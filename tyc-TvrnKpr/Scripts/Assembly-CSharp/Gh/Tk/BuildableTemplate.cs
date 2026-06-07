using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using LitJson;
using Unity.Mathematics;
using UnityEngine;

namespace Gh.Tk
{
	public class BuildableTemplate : IPersistable, ICustomSaveState
	{
		[JsonIgnore]
		private EntityObject _entityObject;

		[JsonIgnore]
		private DataStore _entityObjectData;

		private List<string> _allEntityObjectPrefabIdsInUse;

		public const string BASE_DESIGN_PIECE_PREFIX = "EntityDecoration_";

		[JsonIgnore]
		private BuildableTemplate _parentData;

		[JsonIgnore]
		public List<BuildableTemplate> Variants;

		[JsonIgnore]
		private BuildableTemplate _currentVariant;

		[JsonIgnore]
		private List<Style> _styles;

		public const string OfficialName = "Greenheart Games";

		private static List<BuildableTemplate> _customTemplates;

		private static List<BuildableTemplate> _officialTemplates;

		private static List<BuildableTemplate> _allTemplates;

		public static string TemplatesSubCategory;

		public static List<string> DecorationSubCategories;

		private const string _zipEntryName = "propTemplates.json";

		public const string CustomDecoPropKey = "CustomDecoProp";

		public const string CustomWallDecoPropKey = "CustomWallDecoProp";

		public const string GROUP_KEY_PREFIX = "Group ";

		public string PropType { get; set; }

		public string UniqueKey { get; set; }

		[JsonIgnore]
		public string UniqueKeySansGroup => null;

		public string TemplateOf { get; set; }

		public bool IsCustomTemplate { get; set; }

		public List<string> DisabledMeshGroups { get; set; }

		public Quaternion CustomUIRotation { get; set; }

		[JsonIgnore]
		public bool HasBrokenPieces => false;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool HideFromPlayer { get; set; }

		[JsonIgnore]
		public EntityObject EntityObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int NumberOfDesignPieces { get; private set; }

		public string AuthorId { get; set; }

		public string AuthorGreenbackUserHash { get; set; }

		public string AuthorName { get; set; }

		public string SourceShareCode { get; set; }

		public bool IsDecoration { get; set; }

		public bool AutoGenerateObstruction { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public float Stars { get; set; }

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string[] Categories { get; set; }

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string[] SubCategories { get; set; }

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int BuildLimit { get; set; }

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int BuildCost { get; set; }

		[JsonIgnore]
		public int EffectiveBuildCost { get; private set; }

		[JsonIgnore]
		public int DiscountPercentage { get; private set; }

		[JsonIgnore]
		public string DiscountReasonKey { get; private set; }

		public bool ShowAsVariant { get; set; }

		[JsonIgnore]
		public bool IsVariantGroup { get; set; }

		[JsonIgnore]
		public BuildableTemplate CurrentSelectedVariant
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public string CurrentStyle { get; set; }

		[JsonIgnore]
		public string[] StyleSetIds { get; set; }

		[JsonIgnore]
		public List<Style> Styles
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public static IEnumerable<BuildableTemplate> PropTemplates => null;

		public static IEnumerable<BuildableTemplate> CustomTemplates => null;

		public static IEnumerable<BuildableTemplate> OfficialTemplates => null;

		public event EventHandler CurrentSelectedVariantChanged
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

		public event EventHandler SwatchesChanged
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

		public static event EventHandler<EventArgs<BuildableTemplate>> TemplateRemoved
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

		public static event EventHandler<EventArgs<BuildableTemplate>> TemplateAdded
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

		public static event EventHandler<EventArgs<string>> ShareTemplateHappened
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

		public static event EventHandler SaveAsTemplateHappened
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

		public static event EventHandler<EventArgs<string>> ImportShareCodeHappened
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

		public bool IsTemplateOfCustomDecoPropBase()
		{
			return false;
		}

		public void RecalculateDesignPieceCount()
		{
		}

		public List<string> GetDecorPrefabsInUseByThisTemplate()
		{
			return null;
		}

		public bool IsUnlocked()
		{
			return false;
		}

		public string GetNonVariantKey()
		{
			return null;
		}

		public bool IsBaseDesignPiece()
		{
			return false;
		}

		public bool CanAfford()
		{
			return false;
		}

		public string GetAuthorNameWithInheritance()
		{
			return null;
		}

		public bool IsGreenheartTemplate()
		{
			return false;
		}

		private BuildableTemplate GetInheritedDataSource(bool ignoreSelectedVariant = false)
		{
			return null;
		}

		public string GetNameWithInheritance()
		{
			return null;
		}

		public string GetNameKeyWithInheritance()
		{
			return null;
		}

		public string GetDescriptionWithInheritance()
		{
			return null;
		}

		public string GetDescriptionKeyWithInheritance()
		{
			return null;
		}

		public float GetStarsWithInheritance()
		{
			return 0f;
		}

		public string[] GetCategoriesWithInheritance()
		{
			return null;
		}

		public string[] GetSubCategoriesWithInheritance()
		{
			return null;
		}

		public int GetBuildLimitWithInhertiance()
		{
			return 0;
		}

		public int CalculateCurrentPropCount()
		{
			return 0;
		}

		public int GetBuildCostWithInheritance()
		{
			return 0;
		}

		public int GetBuildCostForStyleSetting(string styleId)
		{
			return 0;
		}

		public void UpdateEffectiveBuildCost()
		{
		}

		private (int, string) GetDiscountPercentageInfo()
		{
			return default((int, string));
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}

		public BuildableTemplate GetVariantGroupParent()
		{
			return null;
		}

		internal void ChangeVariantParent(BuildableTemplate baseTemplate)
		{
		}

		internal void UngroupFromVariant()
		{
		}

		public void RemoveVariant(BuildableTemplate removeTemplate)
		{
		}

		internal BuildableTemplate GetNextVariant(int direction)
		{
			return null;
		}

		public string GetEffectiveCurrentStyle()
		{
			return null;
		}

		public Style GetStyle(string id)
		{
			return null;
		}

		public bool IsOfficialTemplate()
		{
			return false;
		}

		public bool CanPlayerEdit()
		{
			return false;
		}

		public bool IsMadeByCurrentPlayer()
		{
			return false;
		}

		public string GetDesignPiecesIconTooltipKey()
		{
			return null;
		}

		public static void LoadAllTemplates()
		{
		}

		private static void RefreshDecorationSubCategories()
		{
		}

		public static void CheckForDemoTemplates()
		{
		}

		private static string GetSteamCloudLocation(string appId)
		{
			return null;
		}

		public static int ImportCustomTemplatesFromFile(string filePath)
		{
			return 0;
		}

		public static void OnCustomTemplatesImported(IEnumerable<BuildableTemplate> newTemplates)
		{
		}

		public static void OnPlayerAuthorNameChanged(string authorId, string newName)
		{
		}

		public static void LoadOfficialTemplates()
		{
		}

		public static string GetCustomTemplatesFilePath()
		{
			return null;
		}

		public static void LoadCustomTemplates()
		{
		}

		public static List<BuildableTemplate> LoadTemplatesFromJson(string json)
		{
			return null;
		}

		private static BuildableTemplate LoadFromJsonData(JsonData data)
		{
			return null;
		}

		internal static void SaveCustomTemplates()
		{
		}

		public static void AddCustomTemplates(IEnumerable<BuildableTemplate> templates, bool allowOverride = false)
		{
		}

		public static void AddCustomTemplate(BuildableTemplate template)
		{
		}

		public static void UploadAndGetShareCode((BuildableTemplate template, string sharedImagePath)[] templates, Action<string> success, Action<string> error)
		{
		}

		public static void RaiseSaveAsTemplateHappendEvent()
		{
		}

		internal static void SaveAsNewTemplate(GameObjectX gox)
		{
		}

		internal static BuildableTemplate CreateNewTemplate(GameObjectX gox)
		{
			return null;
		}

		public static BuildableTemplate[] ImportTemplate(string code, Stream zipStream)
		{
			return null;
		}

		public static BuildableTemplate SaveEntityObjectsAsNewTemplate(EntityObject mainObj, EntityObject[] entityObjects, string templateName = null, Quaternion? displayRotationOverride = null)
		{
			return null;
		}

		public static BuildableTemplate CreateTemplateFromEntityObjects(EntityObject mainObj, EntityObject[] entityObjects, string templateName = null, Quaternion? displayRotationOverride = null)
		{
			return null;
		}

		private static float3 GetCenter(IEnumerable<EntityObject> entityObjects)
		{
			return default(float3);
		}

		public static void DeleteTemplate(BuildableTemplate data)
		{
		}

		internal void SaveChanges()
		{
		}

		public static void CreateNewGroupParent(BuildableTemplate baseTemplate, BuildableTemplate variant)
		{
		}

		public static bool IsValidDecorationTemplateParent(BuildableTemplate candidate, BuildableTemplate variantTemplate)
		{
			return false;
		}

		public static bool IsValidPropDecorationTemplateParent(BuildableTemplate candidate, BuildableTemplate variantTemplate)
		{
			return false;
		}

		public static void ValidateUnlockedBuildableTemplates()
		{
		}

		private string ToDebugString()
		{
			return null;
		}
	}
}
