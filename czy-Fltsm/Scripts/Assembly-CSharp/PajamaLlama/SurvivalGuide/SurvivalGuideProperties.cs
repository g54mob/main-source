using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.JSON;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	[CreateAssetMenu(menuName = "Flotsam/Survival Guide/Properties")]
	public class SurvivalGuideProperties : ScriptableObject
	{
		[SerializeField]
		private WidgetContainerLayoutStyle[] _widgetContainerLayoutStyles = new WidgetContainerLayoutStyle[0];

		[SerializeField]
		private BaseWidget[] _widgets = new BaseWidget[0];

		[SerializeField]
		private string _guidePath = "";

		[SerializeField]
		private string _categoriesPath = "";

		[SerializeField]
		private GameObject _categoryParentPrefab;

		[SerializeField]
		private CategoryPageIndex _categoryIndexPrefab;

		[SerializeField]
		private GameObject _pageParentPrefab;

		[Header("Generated Pages")]
		[SerializeField]
		private Sprite _sizeSprite;

		[SerializeField]
		private Sprite _weightSprite;

		[SerializeField]
		private Sprite _beautySprite;

		[SerializeField]
		private Sprite _storageSprite;

		[SerializeField]
		private Sprite _liquidStorageSprite;

		[SerializeField]
		private Sprite _energyStorageSprite;

		[SerializeField]
		private Sprite _researchSprite;

		[SerializeField]
		private Sprite _houseSprite;

		[SerializeField]
		private Sprite _birdhouseSprite;

		[SerializeField]
		private Sprite _energyConsumptionSprite;

		[SerializeField]
		private Sprite _energyProductionSprite;

		[SerializeField]
		private Sprite _timeSprite;

		[SerializeField]
		private Sprite _drifterProducerSprite;

		[SerializeField]
		private Sprite _pollutionSprite;

		[SerializeField]
		private Sprite _affinitySprite;

		[SerializeField]
		private Color _affinitySpriteColor = Color.white;

		[SerializeField]
		private float _affinitySpriteSize = 40f;

		[SerializeField]
		private Sprite _resourceBackgroundSprite;

		[SerializeField]
		private Color _resourceBackgroundSpriteColor = Color.white;

		[SerializeField]
		private Sprite _itemTypeBackgroundSprite;

		[Space]
		[SerializeField]
		private LocalizedString _infoString = null;

		[SerializeField]
		private LocalizedString _capacityString = null;

		[SerializeField]
		private LocalizedString _drifterString = null;

		[SerializeField]
		private LocalizedString _birdString = null;

		[SerializeField]
		private LocalizedString _storageString = null;

		[SerializeField]
		private LocalizedString _mixedStorageString = null;

		[SerializeField]
		private LocalizedString _liquidStorageString = null;

		[SerializeField]
		private LocalizedString _energyStorageString = null;

		[SerializeField]
		private LocalizedString _producedInString = null;

		[SerializeField]
		private LocalizedString _usedInString = null;

		[SerializeField]
		private LocalizedString _researchCostString = null;

		[SerializeField]
		private LocalizedString _technologyString = null;

		[SerializeField]
		private LocalizedString _researchKnowledgeRequirementString = null;

		[SerializeField]
		private LocalizedString _researchExpertiseRequirementString = null;

		[SerializeField]
		private LocalizedString _researchBackgroundRequirementString = null;

		[SerializeField]
		private LocalizedString _buildingCostString = null;

		[SerializeField]
		private LocalizedString _needsDrifterProducerString = null;

		[SerializeField]
		private LocalizedString _drifterProducerAttributeString = null;

		[SerializeField]
		private LocalizedString _constructionTimeString = null;

		[SerializeField]
		private LocalizedString _recipeTimeString = null;

		[SerializeField]
		private LocalizedString _minutesString = null;

		[SerializeField]
		private LocalizedString _secondsString = null;

		[SerializeField]
		private LocalizedString _upgradesToString = null;

		[SerializeField]
		private LocalizedString _upgradesFromString = null;

		[SerializeField]
		private LocalizedString _productionString = null;

		[SerializeField]
		private LocalizedString _productionCostString = null;

		[SerializeField]
		private LocalizedString _energyOutputString = null;

		[SerializeField]
		private LocalizedString _energyPerSecondString = null;

		[SerializeField]
		private LocalizedString _resourceBurnTimeString = null;

		[SerializeField]
		private LocalizedString _preFloodString = null;

		[SerializeField]
		private LocalizedString _postFloodString = null;

		[SerializeField]
		private LocalizedString _attributesString = null;

		[SerializeField]
		private LocalizedString _tutorialString = null;

		[SerializeField]
		private LocalizedString _categoryString = null;

		[SerializeField]
		private LocalizedString _dimensionsString = null;

		[SerializeField]
		private LocalizedString _weightString = null;

		[SerializeField]
		private LocalizedString _beautyString = null;

		[SerializeField]
		private LocalizedString _itemTypeString = null;

		[SerializeField]
		private LocalizedString _foodQualityString = null;

		[SerializeField]
		private LocalizedString _foodPollutionString = null;

		[Space]
		[SerializeField]
		private Color _backgroundPositiveModifierColor = Color.green;

		[SerializeField]
		private Color _backgroundNegativeModifierColor = Color.red;

		[SerializeField]
		private Color _backgroundNeutralModifierColor = Color.black;

		[Header("Settings")]
		[SerializeField]
		private BuildableSettings _buildableSettings;

		[SerializeField]
		private ItemSettings _itemSettings;

		[SerializeField]
		private AgentProperties _agentProperties;

		[SerializeField]
		private GameplaySettings _gameplaySettings;

		[SerializeField]
		private DrifterAttributes _drifterAttributes;

		public WidgetContainerLayoutStyle[] WidgetContainerLayoutStyles => _widgetContainerLayoutStyles;

		public BaseWidget[] Widgets => _widgets;

		public string GuidePath => _guidePath;

		public string CategoriesPath => _categoriesPath;

		public GameObject CategoryParentPrefab => _categoryParentPrefab;

		public CategoryPageIndex CategoryIndexPrefab => _categoryIndexPrefab;

		public GameObject PageParentPrefab => _pageParentPrefab;

		public Sprite SizeSprite => _sizeSprite;

		public Sprite WeightSprite => _weightSprite;

		public Sprite BeautySprite => _beautySprite;

		public Sprite StorageSprite => _storageSprite;

		public Sprite LiquidStorageSprite => _liquidStorageSprite;

		public Sprite EnergyStorageSprite => _energyStorageSprite;

		public Sprite ResearchSprite => _researchSprite;

		public Sprite HouseSprite => _houseSprite;

		public Sprite BirdhouseSprite => _birdhouseSprite;

		public Sprite EnergyConsumptionSprite => _energyConsumptionSprite;

		public Sprite EnergyProductionSprite => _energyProductionSprite;

		public Sprite TimeSprite => _timeSprite;

		public Sprite DrifterProducerSprite => _drifterProducerSprite;

		public Sprite PollutionSprite => _pollutionSprite;

		public Sprite AffinitySprite => _affinitySprite;

		public Color AffinitySpriteColor => _affinitySpriteColor;

		public float AffinitySpriteSize => _affinitySpriteSize;

		public Sprite ResourceBackgroundSprite => _resourceBackgroundSprite;

		public Color ResourceBackgroundSpriteColor => _resourceBackgroundSpriteColor;

		public Sprite ItemTypeBackgroundSprite => _itemTypeBackgroundSprite;

		public LocalizedString InfoString => _infoString;

		public LocalizedString CapacityString => _capacityString;

		public LocalizedString DrifterString => _drifterString;

		public LocalizedString BirdString => _birdString;

		public LocalizedString StorageString => _storageString;

		public LocalizedString MixedStorageString => _mixedStorageString;

		public LocalizedString LiquidStorageString => _liquidStorageString;

		public LocalizedString EnergyStorageString => _energyStorageString;

		public LocalizedString ProducedInString => _producedInString;

		public LocalizedString UsedInString => _usedInString;

		public LocalizedString ResearchCostString => _researchCostString;

		public LocalizedString TechnologyString => _technologyString;

		public LocalizedString ResearchKnowledgeRequirementString => _researchKnowledgeRequirementString;

		public LocalizedString ResearchExpertiseRequirementString => _researchExpertiseRequirementString;

		public LocalizedString ResearchBackgroundRequirementString => _researchBackgroundRequirementString;

		public LocalizedString BuildingCostString => _buildingCostString;

		public LocalizedString NeedsDrifterProducerString => _needsDrifterProducerString;

		public LocalizedString DrifterProducerAttributeString => _drifterProducerAttributeString;

		public LocalizedString ConstructionTimeString => _constructionTimeString;

		public LocalizedString RecipeTimeString => _recipeTimeString;

		public LocalizedString MinutesString => _minutesString;

		public LocalizedString SecondsString => _secondsString;

		public LocalizedString UpgradesToString => _upgradesToString;

		public LocalizedString UpgradesFromString => _upgradesFromString;

		public LocalizedString ProductionString => _productionString;

		public LocalizedString ProductionCostString => _productionCostString;

		public LocalizedString EnergyOutputString => _energyOutputString;

		public LocalizedString EnergyPerSecondString => _energyPerSecondString;

		public LocalizedString ResourceBurnTimeString => _resourceBurnTimeString;

		public LocalizedString PreFloodString => _preFloodString;

		public LocalizedString PostFloodString => _postFloodString;

		public LocalizedString AttributesString => _attributesString;

		public LocalizedString TutorialString => _tutorialString;

		public LocalizedString CategoryString => _categoryString;

		public LocalizedString DimensionsString => _dimensionsString;

		public LocalizedString WeightString => _weightString;

		public LocalizedString BeautyString => _beautyString;

		public LocalizedString ItemTypeString => _itemTypeString;

		public LocalizedString FoodQualityString => _foodQualityString;

		public LocalizedString FoodPollutionString => _foodPollutionString;

		public Color BackgroundPositiveModifierColor => _backgroundPositiveModifierColor;

		public Color BackgroundNegativeModifierColor => _backgroundNegativeModifierColor;

		public Color BackgroundNeutralModifierColor => _backgroundNeutralModifierColor;

		public BuildableSettings BuildableSettings => _buildableSettings;

		public ItemSettings ItemSettings => _itemSettings;

		public AgentProperties AgentProperties => _agentProperties;

		public GameplaySettings GameplaySettings => _gameplaySettings;

		public DrifterAttributes DrifterAttributes => _drifterAttributes;

		internal List<CategoryPage> CreateSurvivalGuide()
		{
			List<CategoryPage> list = CreateCategories(Application.streamingAssetsPath + CategoriesPath);
			GeneratePages(list);
			foreach (CategoryPage item in list)
			{
				item.SortPages();
			}
			return list;
		}

		private List<CategoryPage> CreateCategories(string path)
		{
			List<CategoryPage> list = new List<CategoryPage>();
			if (JSONExtensions.TryReadJSON(path, out SurvivalGuideCategories output))
			{
				output.CreateCategoryPages(list);
			}
			return list;
		}

		private List<Page> GeneratePages(List<CategoryPage> survivalGuide)
		{
			List<Page> list = new List<Page>();
			if (TryReturnCategory(survivalGuide, "buildings", out var category))
			{
				list.AddRange(BuildablePage.Generate(BuildableSettings.Buildables, category));
			}
			if (TryReturnCategory(survivalGuide, "resources", out category))
			{
				list.AddRange(ResourcePage.Generate(ItemSettings.ItemProperties, BuildableSettings.Buildables, category));
			}
			if (TryReturnCategory(survivalGuide, "backgrounds", out category))
			{
				list.AddRange(DrifterBackgroundPage.Generate(AgentProperties.PastBackgrounds, category));
				list.AddRange(DrifterBackgroundPage.Generate(AgentProperties.PresentBackgrounds, category));
				list.AddRange(DrifterBackgroundPage.Generate(AgentProperties.SpecializedBackgrounds, category));
			}
			if (TryReturnCategory(survivalGuide, "attributes", out category))
			{
				list.AddRange(DrifterAttributePage.Generate(DrifterAttributes, category));
			}
			if (TryReturnCategory(survivalGuide, "diseases", out category))
			{
				list.AddRange(DrifterDiseasePage.Generate(AgentProperties.VitalProperties.Diseases, category));
			}
			return list;
		}

		private bool TryReturnCategory(List<CategoryPage> categories, string id, out CategoryPage category)
		{
			foreach (CategoryPage category2 in categories)
			{
				if (category2.Equals(id))
				{
					category = category2;
					return true;
				}
			}
			category = null;
			return false;
		}

		internal bool TryReturnWidgetContainerStyle(string id, out WidgetContainerLayoutStyle style)
		{
			WidgetContainerLayoutStyle[] widgetContainerLayoutStyles = WidgetContainerLayoutStyles;
			foreach (WidgetContainerLayoutStyle widgetContainerLayoutStyle in widgetContainerLayoutStyles)
			{
				if (widgetContainerLayoutStyle.Equals(id))
				{
					style = widgetContainerLayoutStyle;
					return true;
				}
			}
			style = null;
			return false;
		}

		internal bool TryReturnStyle(string id, out BaseWidget widget)
		{
			BaseWidget[] widgets = Widgets;
			foreach (BaseWidget baseWidget in widgets)
			{
				if (baseWidget.Equals(id))
				{
					widget = baseWidget;
					return true;
				}
			}
			widget = null;
			return false;
		}
	}
}
