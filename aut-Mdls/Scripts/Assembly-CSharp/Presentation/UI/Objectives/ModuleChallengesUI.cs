#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Objectives.Validators;
using Events.FactoryFloor;
using Presentation.UI.Menus.FullscreenPage;
using TMPro;
using UnityEngine;
using Utils;

namespace Presentation.UI.Objectives
{
	public class ModuleChallengesUI : FullPage
	{
		[Header("Dependencies")]
		[SerializeField]
		private ModuleChallengeSO _moduleChallengeSO;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDeliveredEvent;

		[Header("UI References")]
		[SerializeField]
		private ModuleChallengeSetView _moduleChallengesCategoryPrefab;

		[SerializeField]
		private Transform _moduleChallengesCategoryParent;

		[SerializeField]
		private List<TextMeshProUGUI> _deliverAmountsTexts;

		[Header("Stats")]
		[SerializeField]
		private TextMeshProUGUI _statsText;

		[SerializeField]
		private TextMeshProUGUI _statsValueText;

		private readonly Dictionary<ObjectiveTargetItem, ChallengeItemView> _challengeViews = new Dictionary<ObjectiveTargetItem, ChallengeItemView>();

		private readonly Dictionary<ModuleChallengeSet, ModuleChallengeSetView> _moduleChallengeSetViews = new Dictionary<ModuleChallengeSet, ModuleChallengeSetView>();

		private readonly List<ModuleChallengeCategoryView> _categoryViews = new List<ModuleChallengeCategoryView>();

		private bool _isInitiated;

		private int _totalMetalToEarn;

		private int _totalSilverToEarn;

		private int _totalGoldToEarn;

		private int _totalEarnedMetal;

		private int _totalEarnedSilver;

		private int _totalEarnedGold;

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= SetTexts;
		}

		public override void Initialize()
		{
			LocalizationUtility.OnLanguageUpdate += SetTexts;
			SetTotalTiers();
			SetTexts();
			InstantiateModuleChallengesViews();
		}

		private void SetTotalTiers()
		{
			_totalMetalToEarn = 0;
			_totalSilverToEarn = 0;
			_totalGoldToEarn = 0;
			foreach (ModuleChallengeSet set in _moduleChallengeSO.Sets)
			{
				_ = set;
				_totalMetalToEarn += 3;
				_totalSilverToEarn += 3;
				_totalGoldToEarn += 3;
			}
		}

		private void SetTexts()
		{
			_statsText.SetText(LocalizationUtility.GetLocalizedText("ModuleChallenges.StatsTotal") + "\n" + LocalizationUtility.GetLocalizedText("ModuleChallenges.StatsMetalTiers") + "\n" + LocalizationUtility.GetLocalizedText("ModuleChallenges.StatsSilverTiers") + "\n" + LocalizationUtility.GetLocalizedText("ModuleChallenges.StatsGoldTiers"));
		}

		public override void ShowPage()
		{
			base.gameObject.SetActive(value: true);
			_resourceDeliveredEvent.RegisterMainThread(HandleResourceDelivered);
			UpdateViews();
			UpdateStats();
		}

		public override void HidePage()
		{
			_resourceDeliveredEvent.UnRegisterMainThread(HandleResourceDelivered);
			base.gameObject.SetActive(value: false);
		}

		private void InstantiateModuleChallengesViews()
		{
			for (int i = 0; i < _deliverAmountsTexts.Count; i++)
			{
				_deliverAmountsTexts[i].SetText(_moduleChallengeSO.Sets[0].Categories[0].Items[i].Amount.ToString());
			}
			for (int j = 0; j < _moduleChallengeSO.Sets.Count; j++)
			{
				ModuleChallengeSet moduleChallengeSet = _moduleChallengeSO.Sets[j];
				ModuleChallengeSetView moduleChallengeSetView = Object.Instantiate(_moduleChallengesCategoryPrefab, _moduleChallengesCategoryParent);
				moduleChallengeSetView.Build(moduleChallengeSet);
				if (moduleChallengeSet.Categories.Count != 3)
				{
					this.DevException(string.Format("{0} at index {1} contains {2} objectives, but exactly 3 are expected. Please ensure the data is correctly configured :).", "ModuleChallengeSet", j, moduleChallengeSet.Categories.Count), "InstantiateModuleChallengesViews", 107);
					continue;
				}
				_moduleChallengeSetViews[moduleChallengeSet] = moduleChallengeSetView;
				for (int k = 0; k < moduleChallengeSet.Categories.Count; k++)
				{
					ObjectiveTargetCategorySO objectiveTargetCategorySO = moduleChallengeSet.Categories[k];
					if (objectiveTargetCategorySO == null)
					{
						this.DevException(string.Format("{0} at index {1} in ModuleChallengeSet {2} is null.", "ObjectiveTargetCategorySO", k, j), "InstantiateModuleChallengesViews", 118);
						continue;
					}
					ModuleChallengeCategoryView moduleChallengeCategoryView = moduleChallengeSetView.CategoryViews[k];
					_categoryViews.Add(moduleChallengeCategoryView);
					moduleChallengeCategoryView.Build(objectiveTargetCategorySO, k);
					for (int l = 0; l < objectiveTargetCategorySO.Items.Count; l++)
					{
						ObjectiveTargetItem objectiveTargetItem = objectiveTargetCategorySO.Items[l];
						moduleChallengeCategoryView.ItemViews[l].Build(objectiveTargetItem, l);
						_challengeViews[objectiveTargetItem] = moduleChallengeCategoryView.ItemViews[l];
					}
				}
			}
			_isInitiated = true;
		}

		private void HandleResourceDelivered(Resource resource)
		{
			if (resource is ShapeResource)
			{
				UpdateViews();
				UpdateStats();
			}
		}

		private void UpdateViews()
		{
			if (!_isInitiated)
			{
				return;
			}
			_totalEarnedMetal = 0;
			_totalEarnedSilver = 0;
			_totalEarnedGold = 0;
			foreach (ModuleChallengeSet set in _moduleChallengeSO.Sets)
			{
				_totalEarnedMetal += set.GetTotalCompletedMetalTiers();
				_totalEarnedSilver += set.GetTotalCompletedSilverTiers();
				_totalEarnedGold += set.GetTotalCompletedGoldTiers();
				_moduleChallengeSetViews[set].UpdateValues(set);
				for (int i = 0; i < set.Categories.Count; i++)
				{
					UpdateCategoryView(set, i);
				}
			}
		}

		private void UpdateCategoryView(ModuleChallengeSet challengeSet, int categoryIndex)
		{
			ModuleChallengeSetView moduleChallengeSetView = _moduleChallengeSetViews[challengeSet];
			ObjectiveTargetCategorySO objectiveTargetCategorySO = (ObjectivesValidatorContext.CurrentCategory = challengeSet.Categories[categoryIndex]);
			bool flag = objectiveTargetCategorySO.Validators.TrueForAll((AbstractObjectiveValidator v) => v.IsValid()) && objectiveTargetCategorySO.Items.TrueForAll((ObjectiveTargetItem item) => item.Active);
			if (objectiveTargetCategorySO.Resource.HasShapeData)
			{
				moduleChallengeSetView.CategoryViews[categoryIndex].UpdateView(flag);
				UpdateObjectiveItems(objectiveTargetCategorySO, flag);
				if (flag)
				{
					moduleChallengeSetView.CategoryViews[categoryIndex].UpdateValues();
				}
			}
		}

		private void UpdateObjectiveItems(ObjectiveTargetCategorySO category, bool isCategoryValid)
		{
			for (int i = 0; i < category.Items.Count; i++)
			{
				ObjectiveTargetItem objectiveTargetItem = category.Items[i];
				if (!_challengeViews.TryGetValue(objectiveTargetItem, out var value))
				{
					this.LogError(string.Format("{0} not found for item at index {1} in category {2}. Cannot update UI.", "ChallengeItemView", i, category.name), "UpdateObjectiveItems", 207);
				}
				else if (isCategoryValid && i < category.CurrentTier)
				{
					value.SetViewClaimed(objectiveTargetItem);
				}
				else if (isCategoryValid && i == category.CurrentTier)
				{
					value.SetViewCurrent(objectiveTargetItem, category.DisplayDeliveredInTier);
				}
				else
				{
					value.SetViewDefault();
				}
			}
		}

		private void UpdateStats()
		{
			_statsValueText.SetText($"{_moduleChallengeSO.GetTotalDeliveredModuleChallenges()}\n" + $"{_totalEarnedMetal}<style=Light><size=28> / {_totalMetalToEarn}</size></style>\n" + $"{_totalEarnedSilver}<style=Light><size=28> /{_totalSilverToEarn}</size></style>\n" + $"{_totalEarnedGold}<style=Light><size=28> /{_totalGoldToEarn}</size></style>");
		}
	}
}
