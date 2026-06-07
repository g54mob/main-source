using System;
using System.Collections.Generic;
using System.Text;
using AYellowpaper.SerializedCollections;
using Data.Buildings;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Quests.SubQuestEvents;
using Events.Generic;
using Logic.Factory;
using Presentation.UI;
using Presentation.UI.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BuildingsBar : AbstractOperatorBar
	{
		[Serializable]
		private struct BuildingButtonHighlightEvents
		{
			public StartHighlightingUIBuildingButtonSubQuestEventSO StartHighlightEvent;

			public StopHighlightingUIButtonSubQuestEventSO StopHighlightEvent;
		}

		[Header("Databases")]
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private BuildingFamilyDatabase _buildingFamilyDatabase;

		[Header("Prefabs")]
		[SerializeField]
		private CategoryLayoutView _categoryLayoutViewPrefab;

		[SerializeField]
		private PlaceBuildingButton _placeBuildingBtnPrefab;

		[SerializeField]
		private ModuleButton _moduleButtonPrefab;

		[Header("Layout")]
		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private RectTransform _categoryLayoutContainer;

		[Header("Layout BuildingDetail")]
		[SerializeField]
		private RectTransform _detailRow;

		[SerializeField]
		private RectTransform _moduleGridContent;

		[SerializeField]
		private Image _buildingPreview;

		[SerializeField]
		private Button _buildingPreviewButton;

		[SerializeField]
		private GameObject _buildingPreviewLockedView;

		[SerializeField]
		private RectTransform _outputInfo;

		[SerializeField]
		private RectTransform _overclockOutputInfo;

		[SerializeField]
		private BuildingObjectData _overclockStationData;

		[SerializeField]
		private GameObject _inputInfo;

		[SerializeField]
		private Transform _inputResourcesParent;

		[SerializeField]
		private ResourceUI _resourceUIPrefab;

		[SerializeField]
		private Image _outputImage;

		[SerializeField]
		private TextMeshProUGUI _outputNameText;

		[SerializeField]
		private TextMeshProUGUI _outputAmountText;

		[SerializeField]
		private Transform _outputAmountContainer;

		[SerializeField]
		[LocaKey]
		private string _perMinLocaKey;

		[SerializeField]
		private GameObject _constructionProductionButtonsPanel;

		[SerializeField]
		private ButtonEnabler _constructionButtonEnabler;

		[SerializeField]
		private ButtonEnabler _productionButtonEnabler;

		[SerializeField]
		private Color _constructionAmountColor;

		[SerializeField]
		private Color _productionAmountColor;

		[Header("Stats")]
		[SerializeField]
		private TextMeshProUGUI _statsFloorAmountText;

		[Header("Events")]
		[SerializeField]
		private IntEvent _placeBuildingButtonPressedEvent;

		[SerializeField]
		private SerializedDictionary<BuildingObjectData, BuildingButtonHighlightEvents> _buttonHighlightEvents;

		private readonly Dictionary<int, BuildingFamily> _buildingFamilies = new Dictionary<int, BuildingFamily>();

		private int _currentFamilyId;

		private int _currentBuildingId;

		private BuildingFamilyData _currentFamilyData;

		private Color _familyColor;

		private readonly Dictionary<int, Sprite> _buildingPreviews = new Dictionary<int, Sprite>();

		private readonly Dictionary<int, List<(ModuleButton, int)>> _moduleButtons = new Dictionary<int, List<(ModuleButton, int)>>();

		private readonly List<ResourceUI> _resourceUIs = new List<ResourceUI>();

		private AspectRatioFitter _previewAspectRatioFitter;

		private string _currentTitleKey;

		private bool ModuleRequirementIsConstruction = true;

		private BuildingObjectData _currentBuildingObjectData;

		protected override void InitalizeInternal()
		{
			_currentFamilyData = _buildingFamilyDatabase.GetBuildingFamilyDataWithId(_currentFamilyId);
			_previewAspectRatioFitter = _buildingPreview.GetComponent<AspectRatioFitter>();
			_detailRow.gameObject.SetActive(value: false);
			LoadAvailableBuildings();
		}

		private void Awake()
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageChanged;
			_buildingPreviewButton.onClick.AddListener(BuildingPreviewButtonPressed);
			_constructionButtonEnabler.Button.onClick.AddListener(ToggleModuleRequirementAmount);
			_productionButtonEnabler.Button.onClick.AddListener(ToggleModuleRequirementAmount);
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageChanged;
			_buildingPreviewButton.onClick.RemoveListener(BuildingPreviewButtonPressed);
			_constructionButtonEnabler.Button.onClick.RemoveListener(ToggleModuleRequirementAmount);
			_productionButtonEnabler.Button.onClick.RemoveListener(ToggleModuleRequirementAmount);
		}

		public override void Show()
		{
			base.gameObject.SetActive(value: true);
			_currentFamilyId = BuildingFamily;
			_currentFamilyData = _buildingFamilyDatabase.GetBuildingFamilyDataWithId(_currentFamilyId);
			_familyColor = _currentFamilyData.Color;
			if (_buildingFamilies.ContainsKey(_currentFamilyId))
			{
				ShowCategoriesInFamilyWithID(_currentFamilyId);
			}
			UpdateTitle(_buildingFamilyDatabase.BuildingFamilies[_currentFamilyId].NameLocalizationId);
		}

		public override void Hide()
		{
			_detailRow.gameObject.SetActive(value: false);
			HideCategoriesInFamilyWithID(_currentFamilyId);
			base.gameObject.SetActive(value: false);
		}

		private void OnDisable()
		{
			HideDetails();
		}

		private void LoadAvailableBuildings()
		{
			foreach (BuildingObjectData buildingData in _factoryObjectDatabase.BuildingsObjectData.BuildingDatas)
			{
				if (!(buildingData == null) && !buildingData.UIData.HideFromBuildBar)
				{
					Sprite sprite = Sprite.Create(buildingData.MeshRenderIcon, new Rect(0f, 0f, buildingData.MeshRenderIcon.width, buildingData.MeshRenderIcon.height), new Vector2(0.5f, 0.5f));
					_buildingPreviews.Add(buildingData.ID, sprite);
					if (!_buildingFamilies.ContainsKey(buildingData.FamilyID))
					{
						_buildingFamilies.Add(buildingData.FamilyID, new BuildingFamily());
					}
					BuildingFamily buildingFamily = _buildingFamilies[buildingData.FamilyID];
					CategoryLayoutView categoryLayoutView;
					if (!buildingFamily.CategoryLayouts.ContainsKey(buildingData.CategoryType))
					{
						categoryLayoutView = UnityEngine.Object.Instantiate(_categoryLayoutViewPrefab, _categoryLayoutContainer);
						buildingFamily.CategoryLayouts[buildingData.CategoryType] = new CategoryLayout
						{
							Layout = categoryLayoutView
						};
						BuildingCategoryData buildingCategoryDataWithId = _buildingFamilyDatabase.GetBuildingCategoryDataWithId(buildingData.CategoryType);
						categoryLayoutView.Setup(buildingCategoryDataWithId.Icon[(buildingCategoryDataWithId.Type == BuildingCategoryType.Paints && buildingData.FamilyID + 1 < buildingCategoryDataWithId.Icon.Length) ? (buildingData.FamilyID + 1) : buildingData.FamilyID]);
						categoryLayoutView.gameObject.SetActive(value: false);
					}
					else
					{
						categoryLayoutView = buildingFamily.CategoryLayouts[buildingData.CategoryType].Layout;
					}
					PlaceBuildingButton placeBuildingButton = UnityEngine.Object.Instantiate(_placeBuildingBtnPrefab, categoryLayoutView.transform);
					buildingFamily.CategoryLayouts[buildingData.CategoryType].BuildingButtons.Add(placeBuildingButton);
					placeBuildingButton.Setup(buildingData, sprite);
					if (placeBuildingButton.TryGetComponent<BuildingButtonQuestHighlighter>(out var component) && _buttonHighlightEvents.ContainsKey(buildingData))
					{
						component.SetEvents(_buttonHighlightEvents[buildingData].StartHighlightEvent, _buttonHighlightEvents[buildingData].StopHighlightEvent, buildingData);
					}
					categoryLayoutView.RearrangeIcon();
					LoadModules(buildingData);
				}
			}
		}

		private void LoadModules(BuildingObjectData buildingObjectData)
		{
			int num = 0;
			foreach (DioramaEditorSave.DioramaShapeCollection value in buildingObjectData.DioramaSave.DioramaShapesDictionary.Values)
			{
				ModuleButton moduleButton = UnityEngine.Object.Instantiate(_moduleButtonPrefab, _moduleGridContent);
				moduleButton.SetModuleIcon(value.ShapeData.Data.GridIcon, buildingObjectData.GetModuleViewerData, num);
				moduleButton.gameObject.SetActive(value: false);
				if (!_moduleButtons.ContainsKey(buildingObjectData.ID))
				{
					_moduleButtons.Add(buildingObjectData.ID, new List<(ModuleButton, int)>());
				}
				_moduleButtons[buildingObjectData.ID].Add((moduleButton, value.Shapes.Count));
				num++;
			}
		}

		private void ShowCategoriesInFamilyWithID(int familyId)
		{
			if (_buildingFamilies[familyId].CategoryLayouts.Count == 0)
			{
				return;
			}
			foreach (CategoryLayout value in _buildingFamilies[familyId].CategoryLayouts.Values)
			{
				value.Layout.gameObject.SetActive(value: true);
				for (int i = 0; i < value.BuildingButtons.Count; i++)
				{
					value.BuildingButtons[i].Hovered += OnPlaceButtonHovered;
					value.BuildingButtons[i].Selected += OnPlaceButtonSelected;
				}
			}
		}

		private void HideCategoriesInFamilyWithID(int familyId)
		{
			foreach (CategoryLayout value in _buildingFamilies[familyId].CategoryLayouts.Values)
			{
				value.Layout.gameObject.SetActive(value: false);
				for (int i = 0; i < value.BuildingButtons.Count; i++)
				{
					value.BuildingButtons[i].Hovered -= OnPlaceButtonHovered;
					value.BuildingButtons[i].Selected -= OnPlaceButtonSelected;
				}
			}
		}

		private void OnPlaceButtonHovered(FancyToolBarButton placeBuildingButton)
		{
			ShowDetails(placeBuildingButton as PlaceBuildingButton);
		}

		private void OnPlaceButtonSelected(FancyToolBarButton placeBuildingButton)
		{
			HideDetails();
		}

		private void ShowDetails(PlaceBuildingButton placeBuildingButton)
		{
			RemoveModuleButtons(_currentBuildingId);
			_currentBuildingId = placeBuildingButton.ID;
			_currentBuildingObjectData = _factoryObjectDatabase.BuildingsObjectData.GetBuildingDataWithId(_currentBuildingId);
			UpdateTitle(_currentBuildingObjectData.NameLocKey);
			UpdateInputInfo(_currentBuildingObjectData);
			UpdateOutputInfo(_currentBuildingObjectData);
			UpdateStats(_currentBuildingObjectData);
			_buildingPreview.sprite = _buildingPreviews[_currentBuildingId];
			float aspectRatio = _buildingPreview.sprite.rect.width / _buildingPreview.sprite.rect.height;
			_previewAspectRatioFitter.aspectRatio = aspectRatio;
			for (int i = 0; i < _moduleButtons[_currentBuildingId].Count; i++)
			{
				_moduleButtons[_currentBuildingId][i].Item1.gameObject.SetActive(value: true);
			}
			_detailRow.gameObject.SetActive(value: true);
			_buildingPreviewButton.interactable = !placeBuildingButton.IsLocked;
			_buildingPreviewLockedView.SetActive(placeBuildingButton.IsLocked);
			SetModuleRequirementAmount(isConstruction: true);
		}

		private void SetModuleRequirementAmount(bool isConstruction)
		{
			ModuleRequirementIsConstruction = isConstruction;
			_constructionButtonEnabler.Interactable = !isConstruction;
			_productionButtonEnabler.Interactable = isConstruction;
			if (!(_currentBuildingObjectData == null))
			{
				for (int i = 0; i < _moduleButtons[_currentBuildingId].Count; i++)
				{
					int amount = Mathf.RoundToInt((float)_moduleButtons[_currentBuildingId][i].Item2 * (isConstruction ? 1f : _currentBuildingObjectData.ProducingCostMultiplier));
					_moduleButtons[_currentBuildingId][i].Item1.SetAmount(amount);
					_moduleButtons[_currentBuildingId][i].Item1.SetAmountColor(isConstruction ? _constructionAmountColor : _productionAmountColor);
				}
			}
		}

		private void ToggleModuleRequirementAmount()
		{
			SetModuleRequirementAmount(!ModuleRequirementIsConstruction);
		}

		public void HideDetails()
		{
			_detailRow.gameObject.SetActive(value: false);
		}

		private void RemoveModuleButtons(int buildingId)
		{
			if (_moduleButtons.ContainsKey(buildingId))
			{
				for (int i = 0; i < _moduleButtons[buildingId].Count; i++)
				{
					_moduleButtons[buildingId][i].Item1.gameObject.SetActive(value: false);
				}
			}
		}

		private void UpdateStats(BuildingObjectData buildingObjectData)
		{
			_statsFloorAmountText.SetText((buildingObjectData.Upgrades.Count + 1).ToString());
		}

		private void OnLanguageChanged()
		{
			if (!string.IsNullOrEmpty(_currentTitleKey))
			{
				UpdateTitle(_currentTitleKey);
			}
		}

		private void UpdateTitle(string localizationKey)
		{
			_currentTitleKey = localizationKey;
			_titleText.SetText(LocalizationUtility.GetLocalizedText(localizationKey));
		}

		private void UpdateInputInfo(BuildingObjectData buildingObjectData)
		{
			if (buildingObjectData.GetFactoryObjectBehaviour<BuildingBehaviour>() is MonumentBuildingBehaviour)
			{
				UpdateInputInfoMonuments(buildingObjectData);
				return;
			}
			_inputInfo.SetActive(buildingObjectData.AdditionalInputs.Count > 0);
			for (int i = 0; i < _resourceUIs.Count; i++)
			{
				_resourceUIs[i].gameObject.SetActive(value: false);
			}
			for (int j = 0; j < buildingObjectData.AdditionalInputs.Count; j++)
			{
				NonShapeResourceDataSO nonShapeResourceDataSO = buildingObjectData.AdditionalInputs[j].ResourceData as NonShapeResourceDataSO;
				ResourceUI resourceUI;
				if (j >= _resourceUIs.Count)
				{
					resourceUI = UnityEngine.Object.Instantiate(_resourceUIPrefab, _inputResourcesParent);
					_resourceUIs.Add(resourceUI);
				}
				else
				{
					resourceUI = _resourceUIs[j];
				}
				resourceUI.SetResource(nonShapeResourceDataSO, $"x{buildingObjectData.AdditionalInputs[j].Value}");
				if (nonShapeResourceDataSO is PaintResourceDataSO)
				{
					resourceUI.SetColor((nonShapeResourceDataSO as PaintResourceDataSO).Color);
				}
				else
				{
					resourceUI.SetColor(_buildingFamilyDatabase.GetFamilyColorById(nonShapeResourceDataSO.FamilyID));
				}
				_resourceUIs[j].gameObject.SetActive(value: true);
			}
		}

		private void UpdateInputInfoMonuments(BuildingObjectData buildingObjectData)
		{
			_inputInfo.SetActive(value: true);
			for (int i = 0; i < _resourceUIs.Count; i++)
			{
				_resourceUIs[i].gameObject.SetActive(value: false);
			}
			ResourceUI resourceUI;
			if (_resourceUIs.Count == 0)
			{
				resourceUI = UnityEngine.Object.Instantiate(_resourceUIPrefab, _inputResourcesParent);
				_resourceUIs.Add(resourceUI);
			}
			else
			{
				resourceUI = _resourceUIs[0];
			}
			MonumentBuildingBehaviour factoryObjectBehaviour = buildingObjectData.GetFactoryObjectBehaviour<MonumentBuildingBehaviour>();
			int num = Mathf.RoundToInt((float)FactoryUpdater.Instance.GetUnscaledStepsPerSecond() / (float)factoryObjectBehaviour.UpdateFrequencyForReducingDatashards * 60f);
			resourceUI.SetResource(factoryObjectBehaviour.DataShardToCharge, string.Format(LocalizationUtility.GetLocalizedText(_perMinLocaKey), num));
			resourceUI.SetColor(_buildingFamilyDatabase.GetFamilyColorById(factoryObjectBehaviour.DataShardToCharge.FamilyID));
			resourceUI.gameObject.SetActive(value: true);
		}

		private void UpdateOverclockOutput(BuildingObjectData buildingObjectData)
		{
			bool flag = buildingObjectData == _overclockStationData;
			_outputInfo.gameObject.SetActive(!flag);
			_overclockOutputInfo.gameObject.SetActive(flag);
		}

		private void UpdateOutputInfo(BuildingObjectData buildingObjectData)
		{
			if (buildingObjectData.GetFactoryObjectBehaviour<BuildingBehaviour>() is MonumentBuildingBehaviour)
			{
				UpdateOutputInfoMonuments(buildingObjectData);
				return;
			}
			if (buildingObjectData.ResourceOutputs.Count > 0)
			{
				_outputAmountContainer.gameObject.SetActive(value: true);
				_constructionProductionButtonsPanel.SetActive(value: true);
				NonShapeResourceDataSO nonShapeResourceDataSO = buildingObjectData.ResourceOutputs[0].ResourceData as NonShapeResourceDataSO;
				_outputNameText.SetText(LocalizationUtility.GetLocalizedText(nonShapeResourceDataSO.NameLocaKey));
				_outputImage.sprite = nonShapeResourceDataSO.Sprite;
				PaintResourceDataSO paintResourceDataSO = buildingObjectData.ResourceOutputs[0].ResourceData as PaintResourceDataSO;
				if (paintResourceDataSO != null)
				{
					Color color = paintResourceDataSO.Color;
					color.a = 1f;
					_outputNameText.color = color;
				}
				else
				{
					_outputNameText.color = _familyColor;
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("x{0} ( ", buildingObjectData.ResourceOutputs[0].Value);
				for (int i = 0; i < buildingObjectData.Upgrades.Count; i++)
				{
					if ((i != 0 || buildingObjectData.Upgrades[i].ResourceCounts[0].Value != buildingObjectData.ResourceOutputs[0].Value) && (i <= 0 || buildingObjectData.Upgrades[i].ResourceCounts[0].Value != buildingObjectData.Upgrades[i - 1].ResourceCounts[0].Value))
					{
						stringBuilder.AppendFormat("<style=\"Green\">x{0}</style>", buildingObjectData.Upgrades[i].ResourceCounts[0].Value);
						if (i < buildingObjectData.Upgrades.Count - 1)
						{
							stringBuilder.Append(", ");
						}
					}
				}
				stringBuilder.Append(" )");
				_outputAmountText.SetText(stringBuilder.ToString());
			}
			UpdateOverclockOutput(buildingObjectData);
		}

		private void UpdateOutputInfoMonuments(BuildingObjectData buildingObjectData)
		{
			_outputAmountContainer.gameObject.SetActive(value: false);
			_constructionProductionButtonsPanel.SetActive(value: false);
			MonumentBuildingBehaviour factoryObjectBehaviour = buildingObjectData.GetFactoryObjectBehaviour<MonumentBuildingBehaviour>();
			_outputNameText.SetText(LocalizationUtility.GetLocalizedText(factoryObjectBehaviour.ChargeTextLocaKey));
			_outputNameText.color = factoryObjectBehaviour.ChargeColor;
			_outputImage.sprite = factoryObjectBehaviour.ChargeIcon;
		}

		private void BuildingPreviewButtonPressed()
		{
			_placeBuildingButtonPressedEvent.Fire(_currentBuildingId);
			HideDetails();
		}
	}
}
