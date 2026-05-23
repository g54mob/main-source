#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using Data.Objectives;
using Data.Objectives.Validators;
using Data.Statistics;
using Events;
using Events.FactoryFloor;
using Presentation.Locators;
using Presentation.UI.Menus.FullscreenPage;
using TMPro;
using UnityEngine;
using Utils;

namespace Presentation.UI.Objectives
{
	public class DeliveryTargetsUI : FullPage
	{
		[Header("Dependencies")]
		[SerializeField]
		private DeliveryTargetSO _deliveryTargetSO;

		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDeliveredEvent;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[Header("UI References")]
		[SerializeField]
		private Transform _categoriesParent;

		[SerializeField]
		private TargetItemView _targetViewPrefab;

		[SerializeField]
		private DeliveryCategoryView _categoryPrefab;

		[SerializeField]
		private BotCatogoryUILibrary _botCategoryUI;

		[SerializeField]
		private SerializedDictionary<ResourceDataSO, TotalTargetsUIRefs> _totalTargetsRefs = new SerializedDictionary<ResourceDataSO, TotalTargetsUIRefs>();

		[SerializeField]
		private TextMeshProUGUI _xpGainText;

		[SerializeField]
		private List<ResourceDataSO> _acceptedResourceTypes = new List<ResourceDataSO>();

		[SerializeField]
		private Color _totalIconHiddenColor;

		[Header("Audio")]
		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private readonly Dictionary<ObjectiveTargetItem, TargetItemView> _objectiveTargetViews = new Dictionary<ObjectiveTargetItem, TargetItemView>();

		private readonly List<DeliveryCategoryView> _categoryViews = new List<DeliveryCategoryView>();

		private bool _isInitiated;

		private void Awake()
		{
			_finishedLoadingSaveEvent.Register(ResetUI);
		}

		public override void Initialize()
		{
			InstantiateDeliveryTargetViews();
		}

		private void OnDestroy()
		{
			_finishedLoadingSaveEvent.UnRegister(ResetUI);
		}

		private void ResetUI()
		{
			_isInitiated = false;
		}

		public override void ShowPage()
		{
			base.gameObject.SetActive(value: true);
			_resourceDeliveredEvent.RegisterMainThread(HandleResourceDelivered);
			UpdateViews(!_isInitiated);
			UpdateTotals();
		}

		public override void HidePage()
		{
			_resourceDeliveredEvent.UnRegisterMainThread(HandleResourceDelivered);
			base.gameObject.SetActive(value: false);
		}

		private void InstantiateDeliveryTargetViews()
		{
			for (int i = 0; i < _deliveryTargetSO.Categories.Count; i++)
			{
				ObjectiveTargetCategorySO objectiveTargetCategorySO = _deliveryTargetSO.Categories[i];
				DeliveryCategoryView deliveryCategoryView = Object.Instantiate(_categoryPrefab, _categoriesParent);
				_categoryViews.Add(deliveryCategoryView);
				deliveryCategoryView.Build(objectiveTargetCategorySO.Resource.ResourceData, _botCategoryUI.CategoryUIs[objectiveTargetCategorySO].color);
				for (int j = 0; j < objectiveTargetCategorySO.Items.Count; j++)
				{
					InstantiateTargetView(objectiveTargetCategorySO.Items[j], deliveryCategoryView, j, objectiveTargetCategorySO, i);
				}
			}
			_isInitiated = true;
		}

		private void InstantiateTargetView(ObjectiveTargetItem item, DeliveryCategoryView categoryView, int tier, ObjectiveTargetCategorySO category, int categoryIndex)
		{
			TargetItemView targetItemView = Object.Instantiate(_targetViewPrefab, categoryView.Targets);
			targetItemView.Build(item, tier, category, _botCategoryUI.CategoryUIs[category].color, category.Resource.ResourceData.NameLocaKey);
			_objectiveTargetViews[item] = targetItemView;
		}

		private void HandleResourceDelivered(Resource resource)
		{
			if (_acceptedResourceTypes.Contains(resource.Data))
			{
				UpdateViews();
				UpdateTotals(resource);
			}
		}

		private void UpdateTotals(Resource resource = null)
		{
			_xpGainText.SetText(_statisticsSO.GetXPEarnedStatistic(XPEarnedSource.DeliveryTargets).ToString());
			if (resource == null)
			{
				for (int i = 0; i < _acceptedResourceTypes.Count; i++)
				{
					uint deliveredStatistic = _statisticsSO.GetDeliveredStatistic(_acceptedResourceTypes[i].ID);
					_totalTargetsRefs[_acceptedResourceTypes[i]].Text.SetText(deliveredStatistic.ToString());
					_totalTargetsRefs[_acceptedResourceTypes[i]].IconImage.color = ((deliveredStatistic != 0) ? Color.white : _totalIconHiddenColor);
				}
			}
			else
			{
				uint deliveredStatistic2 = _statisticsSO.GetDeliveredStatistic(resource.Data.ID);
				_totalTargetsRefs[resource.Data].Text.SetText(deliveredStatistic2.ToString());
				_totalTargetsRefs[resource.Data].IconImage.color = ((deliveredStatistic2 != 0) ? Color.white : _totalIconHiddenColor);
			}
		}

		private void UpdateViews(bool reset = false)
		{
			if (_isInitiated || reset)
			{
				for (int i = 0; i < _deliveryTargetSO.Categories.Count; i++)
				{
					UpdateCategoryView(_deliveryTargetSO.Categories[i], i, reset);
				}
			}
		}

		private void UpdateCategoryView(ObjectiveTargetCategorySO category, int index, bool reset = false)
		{
			ObjectivesValidatorContext.CurrentCategory = category;
			bool flag = category.Validators.TrueForAll((AbstractObjectiveValidator v) => v.IsValid());
			_categoryViews[index].UpdateView(flag);
			if (flag || reset)
			{
				UpdateObjectiveItems(category);
				_categoryViews[index].UpdateValues(category.DisplayDeliveredTotal, category.DisplayRequiredInTier, category.CurrentTier);
			}
		}

		private void UpdateObjectiveItems(ObjectiveTargetCategorySO category)
		{
			for (int i = 0; i < category.Items.Count; i++)
			{
				ObjectiveTargetItem objectiveTargetItem = category.Items[i];
				if (objectiveTargetItem.Active)
				{
					if (!_objectiveTargetViews.TryGetValue(objectiveTargetItem, out var value))
					{
						this.LogError(string.Format("{0} not found for item at index {1} in category {2}. Cannot update UI.", "TargetItemView", i, category.name), "UpdateObjectiveItems", 208);
					}
					else if (i < category.CurrentTier)
					{
						value.SetViewClaimed();
					}
					else if (i == category.CurrentTier)
					{
						value.SetViewCurrent(objectiveTargetItem, category.DisplayDeliveredInTier);
					}
					else
					{
						value.SetViewDefault();
					}
				}
			}
		}
	}
}
