using Brewery.Skills;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public class SkillTreeUIController : BaseBreweryUIController
	{
		private const string TemplatePath = "UI/SkillTreeUI";

		private const string StylesheetPath = "UI/SkillTreeUI";

		private VisualElement skillTreeRoot;

		private Label skillPointsText;

		private Label playerLevelText;

		private Button brewingTab;

		private Button tradingTab;

		private Button barTab;

		private Button housingTab;

		private VisualElement brewingContent;

		private VisualElement tradingContent;

		private VisualElement barContent;

		private VisualElement housingContent;

		private VisualElement cornGrindingNode;

		private VisualElement grapeStompingNode;

		private VisualElement beerBarrelOutputNode;

		private VisualElement wineBarrelOutputNode;

		private VisualElement spiritsBarrelOutputNode;

		private VisualElement beerBarrelFermentationNode;

		private VisualElement wineBarrelAgingNode;

		private VisualElement beerEnzymePackNode;

		private VisualElement beerRiceHullsNode;

		private VisualElement beerDefoamerNode;

		private VisualElement beerYeastNutrientNode;

		private VisualElement wineRiceHullsNode;

		private VisualElement wineDefoamerNode;

		private VisualElement wineYeastNutrientNode;

		private VisualElement spiritsEnzymePackNode;

		private VisualElement spiritsRiceHullsNode;

		private VisualElement spiritsYeastNutrientNode;

		private VisualElement barrelBobNode;

		private VisualElement supplySamNode;

		private VisualElement supplySteveNode;

		private VisualElement marthaBrewerNode;

		private VisualElement drSketchyNode;

		private VisualElement farmerJackNode;

		private VisualElement tomMaltNode;

		private VisualElement oldPeteNode;

		private VisualElement henryHerbsNode;

		private VisualElement sweetSallyNode;

		private VisualElement traderTimNode;

		private VisualElement ritaTraderNode;

		private VisualElement viperVicNode;

		private VisualElement cartelCarlosNode;

		private VisualElement corporateEliteNode;

		private VisualElement workingClassNode;

		private VisualElement priestsNode;

		private VisualElement bikersNode;

		private VisualElement partySceneNode;

		private VisualElement beerBaseValueNode;

		private VisualElement wineBaseValueNode;

		private VisualElement spiritsBaseValueNode;

		private VisualElement cascadeHopsNode;

		private VisualElement chiliPeppersNode;

		private VisualElement citrusZestNode;

		private VisualElement cocainePowderNode;

		private VisualElement coffeeBeansNode;

		private VisualElement exoticFlowersNode;

		private VisualElement holyWaterNode;

		private VisualElement honeyNode;

		private VisualElement methCrystalsNode;

		private VisualElement oakBarrelChipsNode;

		private VisualElement sharkTestosteroneNode;

		private VisualElement snakeVenomNode;

		private VisualElement vanillaPodsNode;

		private VisualElement viagraDustNode;

		private VisualElement weedExtractNode;

		private VisualElement detailsIconContainer;

		private Label detailsName;

		private Label detailsCategory;

		private Label detailsLevel;

		private VisualElement detailsProgressFill;

		private Label detailsDescription;

		private VisualElement benefitsList;

		private Label costText;

		private Button upgradeButton;

		private VisualElement tradingEmptyDetails;

		private VisualElement tradingDetailsPanel;

		private VisualElement tradingDetailsIconContainer;

		private Label tradingDetailsName;

		private Label tradingDetailsCategory;

		private Label tradingDetailsLevel;

		private VisualElement tradingDetailsProgressFill;

		private Label tradingDetailsDescription;

		private Label tradingDiscountPercent;

		private VisualElement tradingBenefitsList;

		private VisualElement discountedItemsGrid;

		private Label tradingCostText;

		private Button tradingUpgradeButton;

		private VisualElement barEmptyDetails;

		private VisualElement barDetailsPanel;

		private VisualElement barDetailsIconContainer;

		private Label barDetailsName;

		private Label barDetailsCategory;

		private Label barDetailsLevel;

		private VisualElement barDetailsProgressFill;

		private Label barDetailsDescription;

		private Label barBonusPercent;

		private VisualElement barBenefitsList;

		private Label barCostText;

		private Button barUpgradeButton;

		private VisualElement constructionMaterialBonusNode;

		private VisualElement buildEfficiencyNode;

		private VisualElement housingEmptyDetails;

		private VisualElement housingDetailsPanel;

		private VisualElement housingDetailsIconContainer;

		private Label housingDetailsName;

		private Label housingDetailsCategory;

		private Label housingDetailsLevel;

		private VisualElement housingDetailsProgressFill;

		private Label housingDetailsDescription;

		private VisualElement housingBenefitsList;

		private Label housingCostText;

		private Button housingUpgradeButton;

		private InputReader inputReader;

		private PlayerSkillData localPlayerSkills;

		private string currentTab;

		private SkillType? selectedSkill;

		public static SkillTreeUIController Instance { get; private set; }

		protected override void RegisterSingleton()
		{
		}

		protected override VisualElement GetContainer()
		{
			return null;
		}

		protected override void OnUIHiding()
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void BuildUI()
		{
		}

		private void SetupSkillNodeClick(VisualElement node, SkillType skill)
		{
		}

		private void ApplyIconWithBadge(VisualElement iconContainer, SkillType skill, int badgeSize = 48)
		{
		}

		private void ApplySkillIcon(VisualElement node, SkillType skill)
		{
		}

		private void FindLocalPlayerSkills()
		{
		}

		private void OnPlayerSkillDataRegistered()
		{
		}

		private void SubscribeToSkillChanges()
		{
		}

		private void UnsubscribeFromSkills()
		{
		}

		private void OnSkillLevelChanged(SkillType skill, int newLevel)
		{
		}

		private void RefreshUI()
		{
		}

		private void RefreshHeader()
		{
		}

		private void RefreshAllSkillNodes()
		{
		}

		private void RefreshSkillNode(SkillType skill)
		{
		}

		private VisualElement GetNodeForSkill(SkillType skill)
		{
			return null;
		}

		private string GetSkillCategory(SkillType skill)
		{
			return null;
		}

		private void SelectSkill(SkillType skill)
		{
		}

		private void UpdateDetailsPanel(SkillType skill)
		{
		}

		private void UpdateTradingDetailsPanel(SkillType skill, int level, int maxLevel, bool isMaxed)
		{
		}

		private void UpdateBarDetailsPanel(SkillType skill, int level, int maxLevel, bool isMaxed)
		{
		}

		private void UpdateHousingDetailsPanel(SkillType skill, int level, int maxLevel, bool isMaxed)
		{
		}

		private VisualElement CreateDiscountedItemElement(DiscountedItemInfo itemInfo)
		{
			return null;
		}

		private string GetBenefitTextForSkill(SkillType skill, int level, int maxLevel)
		{
			return null;
		}

		private bool IsDurationSkill(SkillType skill)
		{
			return false;
		}

		private bool IsMinigameTimeBonusSkill(SkillType skill)
		{
			return false;
		}

		private bool IsBarrelOutputSkill(SkillType skill)
		{
			return false;
		}

		private bool IsBoosterSkill(SkillType skill)
		{
			return false;
		}

		private bool IsTradingDiscountSkill(SkillType skill)
		{
			return false;
		}

		private bool IsFactionSellBonusSkill(SkillType skill)
		{
			return false;
		}

		private bool IsBaseValueSkill(SkillType skill)
		{
			return false;
		}

		private bool IsCatalystBonusSkill(SkillType skill)
		{
			return false;
		}

		private bool IsBarTabSkill(SkillType skill)
		{
			return false;
		}

		private bool IsHousingSkill(SkillType skill)
		{
			return false;
		}

		private bool IsBarrelTimerSkill(SkillType skill)
		{
			return false;
		}

		private void OnUpgradeClicked()
		{
		}

		private void SelectTab(string tabKey)
		{
		}

		protected override void HandleCustomKeys(KeyDownEvent evt)
		{
		}

		private void FindInputReader()
		{
		}

		private void OnLocalInputReaderReady(InputReader reader)
		{
		}

		private void BindToInputReader(InputReader reader)
		{
		}

		private void UnsubscribeFromInput()
		{
		}

		private void HandleSkillTreeToggle()
		{
		}

		public void ToggleUI()
		{
		}

		public void ShowUI()
		{
		}
	}
}
