using System;
using System.Collections.Generic;
using System.Linq;
using Data.Buildings;
using Data.Shapes;
using Events.UI.ModuleViewer;
using Logic.Shapes;
using Presentation.Locators;
using Presentation.UI.ButtonHelpers;
using Presentation.UI.LayoutElements.ColorPicker;
using Presentation.UI.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.ModuleViewer
{
	public class ModuleViewer : MonoBehaviour
	{
		[Header("General")]
		[SerializeField]
		private Camera _moduleViewerCamera;

		[SerializeField]
		private ModuleViewerLocator _moduleViewerLocator;

		[Header("Building Info")]
		[SerializeField]
		private Image _buildingPreview;

		[SerializeField]
		private TextMeshProUGUI _buildingNameText;

		[Header("Modules List")]
		[SerializeField]
		private Transform _buildingModules;

		[SerializeField]
		private ModuleButtonInViewer _moduleButtonPrefab;

		[Header("Center module")]
		[SerializeField]
		private ShapeViewer _shapeViewer;

		[Header("Pinning module")]
		[SerializeField]
		private Button _pinAllButton;

		[SerializeField]
		private TextMeshProUGUI _pinAllButtonText;

		[SerializeField]
		private Button _pinModuleButton;

		[SerializeField]
		private ButtonContentSwitcher _pinModuleButtonContentSwitcher;

		[SerializeField]
		private PinModuleUIEvent _pinModuleUIEvent;

		[SerializeField]
		private PinnedModulesViewLocator _locator;

		[Header("Stats")]
		[SerializeField]
		private TextMeshProUGUI _statsVolumeText;

		[SerializeField]
		private TextMeshProUGUI _statsSizeText;

		[Header("Audio")]
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[Header("Color")]
		[SerializeField]
		private RectTransform _colorParent;

		[SerializeField]
		private ColorToggle _colorToggleButtonPrefab;

		[SerializeField]
		private ColorToggle _allToggleButtonPrefab;

		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		private readonly List<ModuleButtonInViewer> _spawnedModuleButtons = new List<ModuleButtonInViewer>();

		private bool _pinAllToggleFlag;

		private BuildingObjectData _currentBuilding;

		private ModuleViewerData _currentModuleViewerData;

		private int _currentShapeIndex;

		private ShapeData _currentShape;

		private string _statsVolumeString;

		private string _statsSizeString;

		private bool _isMaxViewer;

		private List<ColorToggle> _spawnedToggleButtons = new List<ColorToggle>();

		private List<Color> _selectedColors = new List<Color>();

		private ColorToggle _allToggle;

		private RectTransform _colorToggleEmptySpace;

		private int _colorAmount;

		public BuildingObjectData LastShownBuilding => _currentBuilding;

		public ModuleViewerData LastShownModuleViewerData => _currentModuleViewerData;

		public int LastShownShapeIndex => _currentShapeIndex;

		public ShapeData LastShownShapeData => _currentShape;

		private void Awake()
		{
			_moduleViewerLocator.Set(this);
			_moduleViewerCamera.gameObject.SetActive(value: false);
			_pinModuleButton.onClick.AddListener(PinModule);
			_pinAllButton.onClick.AddListener(PinAll);
			LocalizationUtility.OnLanguageUpdate += UpdateLocalization;
			UpdateStatsStrings();
		}

		private void UpdateStatsStrings()
		{
			_statsVolumeString = LocalizationUtility.GetLocalizedText("ModuleViewer.StatsVolumeTitle") + "<br>" + LocalizationUtility.GetLocalizedText("ModuleViewer.StatsVolume");
			_statsSizeString = LocalizationUtility.GetLocalizedText("ModuleViewer.StatsSizeTitle") + "<br>" + LocalizationUtility.GetLocalizedText("ModuleViewer.StatsSize");
		}

		private void OnDestroy()
		{
			_pinModuleButton.onClick.RemoveListener(PinModule);
			_pinAllButton.onClick.RemoveListener(PinAll);
			LocalizationUtility.OnLanguageUpdate -= UpdateLocalization;
			DestroyColorButtons();
		}

		private void PinModule()
		{
			_pinModuleUIEvent.Fire((_currentModuleViewerData, _currentShapeIndex));
			UpdatePinButton(_currentModuleViewerData, _currentShape);
			_spawnedModuleButtons[_currentShapeIndex].IsPinned = _locator.PinnedModulesBarView.IsModulePinned(_currentModuleViewerData, _currentShape);
			CheckPinAllToggle();
		}

		private void CheckPinAllToggle()
		{
			bool flag = true;
			for (int i = 0; i < _spawnedModuleButtons.Count; i++)
			{
				if (_spawnedModuleButtons[i].gameObject.activeSelf && !_spawnedModuleButtons[i].IsPinned)
				{
					flag = false;
				}
			}
			if (flag)
			{
				_pinAllToggleFlag = true;
			}
			else
			{
				_pinAllToggleFlag = false;
			}
			UpdatePinAllButton();
		}

		private void PinAll()
		{
			_pinAllToggleFlag = !_pinAllToggleFlag;
			int num = 0;
			foreach (ModuleViewerData.ShapeDataAndAmount module in _currentModuleViewerData.Modules)
			{
				bool flag = _locator.PinnedModulesBarView.IsModulePinned(_currentModuleViewerData, module.Shape.Data);
				if ((!flag && _pinAllToggleFlag) || (!_pinAllToggleFlag && flag))
				{
					_pinModuleUIEvent.Fire((_currentModuleViewerData, num));
					_spawnedModuleButtons[num].IsPinned = _locator.PinnedModulesBarView.IsModulePinned(_currentModuleViewerData, module.Shape.Data);
				}
				num++;
			}
			UpdatePinButton(_currentModuleViewerData, _currentShape);
			UpdatePinAllButton();
		}

		private void UpdatePinAllButton()
		{
			_pinAllButtonText.SetText(LocalizationUtility.GetLocalizedText(_pinAllToggleFlag ? "ModuleViewer.UnpinAllButton" : "ModuleViewer.PinAllButton"));
		}

		public void Show((ModuleViewerData, int) dataAndIndex, bool isMaxViewer = false)
		{
			_isMaxViewer = isMaxViewer;
			bool num = dataAndIndex.Item1 == _currentModuleViewerData;
			bool flag = dataAndIndex.Item2 == _currentShapeIndex;
			ResetCurrentButtons();
			_moduleViewerCamera.gameObject.SetActive(value: true);
			UpdateCurrentModuleViewerDataFields(dataAndIndex);
			if (!num)
			{
				BuildModuleViewerData(_currentModuleViewerData);
				BuildModuleList(_currentModuleViewerData);
			}
			else if (!flag)
			{
				UpdateModuleList(_currentModuleViewerData);
			}
			ShowCenterModule(_currentShape);
			SetShapeStats(_currentShape);
			UpdatePinButton(_currentModuleViewerData, _currentShape);
			_audioManagerLocator.AudioManager.PlayOpenUI();
			CheckPinAllToggle();
			ShowColorButtons(_currentShape);
		}

		private void ShowColorButtons(ShapeData currentShape)
		{
			DestroyColorButtons();
			Dictionary<Color, HashSet<Voxel>> dictionary = new Dictionary<Color, HashSet<Voxel>>();
			Voxel[] voxels = currentShape.Voxels;
			for (int i = 0; i < voxels.Length; i++)
			{
				Voxel item = voxels[i];
				if (!(item.Color == Color.clear) && item.IsOccupied)
				{
					if (dictionary.ContainsKey(item.Color))
					{
						dictionary[item.Color].Add(item);
						continue;
					}
					dictionary[item.Color] = new HashSet<Voxel> { item };
				}
			}
			_colorAmount = dictionary.Count;
			if (_colorAmount <= 1)
			{
				_colorParent.gameObject.SetActive(value: false);
				return;
			}
			_colorParent.gameObject.SetActive(value: true);
			_allToggle = UnityEngine.Object.Instantiate(_allToggleButtonPrefab, _colorParent);
			ColorToggle allToggle = _allToggle;
			allToggle.OnColorChanged = (Action<ColorToggle, Color>)Delegate.Combine(allToggle.OnColorChanged, new Action<ColorToggle, Color>(HandleAllButtonClicked));
			foreach (KeyValuePair<Color, HashSet<Voxel>> item2 in dictionary)
			{
				ColorToggle colorToggle = UnityEngine.Object.Instantiate(_colorToggleButtonPrefab, _colorParent);
				colorToggle.IsSelected = true;
				colorToggle.SetColor(item2.Key);
				_selectedColors.Add(item2.Key);
				colorToggle.OnColorChanged = (Action<ColorToggle, Color>)Delegate.Combine(colorToggle.OnColorChanged, new Action<ColorToggle, Color>(HandleColorButtonPressed));
				_spawnedToggleButtons.Add(colorToggle);
			}
			_allToggle.SetDisabled(_selectedColors.Count >= _colorAmount);
			UpdateShapeWithColors();
		}

		private void HandleAllButtonClicked(ColorToggle button, Color arg2)
		{
			bool flag = false;
			foreach (ColorToggle spawnedToggleButton in _spawnedToggleButtons)
			{
				if (!spawnedToggleButton.IsSelected)
				{
					spawnedToggleButton.ButtonPressed();
					flag = true;
				}
			}
			if (flag)
			{
				UpdateShapeWithColors(animateRotation: false);
			}
		}

		private void HandleColorButtonPressed(ColorToggle button, Color color)
		{
			if (button.IsSelected && !_selectedColors.Contains(color))
			{
				_selectedColors.Add(color);
			}
			else if (!button.IsSelected && _selectedColors.Contains(color))
			{
				_selectedColors.Remove(color);
			}
			_allToggle.SetDisabled(_selectedColors.Count >= _colorAmount);
			UpdateShapeWithColors(animateRotation: false);
		}

		private void UpdateShapeWithColors(bool animateRotation = true)
		{
			Shape shape = Shape.Create(_currentShape);
			shape = shape.RemoveColors(_selectedColors);
			ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(shape);
			ShowCenterModule(orCreateShapeData, animateRotation);
		}

		private void SetShapeStats(ShapeData data)
		{
			_statsVolumeText.SetText(string.Format(_statsVolumeString, data.OccupiedVoxels.Count().ToString()));
			_statsSizeText.SetText(string.Format(_statsSizeString, data.Bounds.x.ToString(), data.Bounds.y.ToString(), data.Bounds.z.ToString()));
		}

		private void ResetCurrentButtons()
		{
			if (_currentShapeIndex < _spawnedModuleButtons.Count)
			{
				_spawnedModuleButtons[_currentShapeIndex].IsActive = false;
			}
		}

		public void Hide()
		{
			_audioManagerLocator.AudioManager.PlayCloseUI();
			_moduleViewerCamera.gameObject.SetActive(value: false);
			HideCenterModule();
			DestroyColorButtons();
		}

		private void DestroyColorButtons()
		{
			if (_colorToggleEmptySpace != null)
			{
				UnityEngine.Object.Destroy(_colorToggleEmptySpace.gameObject);
			}
			if (_allToggle != null)
			{
				ColorToggle allToggle = _allToggle;
				allToggle.OnColorChanged = (Action<ColorToggle, Color>)Delegate.Remove(allToggle.OnColorChanged, new Action<ColorToggle, Color>(HandleAllButtonClicked));
				UnityEngine.Object.Destroy(_allToggle.gameObject);
			}
			foreach (ColorToggle spawnedToggleButton in _spawnedToggleButtons)
			{
				spawnedToggleButton.OnColorChanged = (Action<ColorToggle, Color>)Delegate.Remove(spawnedToggleButton.OnColorChanged, new Action<ColorToggle, Color>(HandleColorButtonPressed));
				UnityEngine.Object.Destroy(spawnedToggleButton.gameObject);
			}
			_selectedColors.Clear();
			_spawnedToggleButtons.Clear();
		}

		private void UpdateCurrentModuleViewerDataFields((ModuleViewerData, int) dataAndIndex)
		{
			_currentModuleViewerData = dataAndIndex.Item1;
			_currentShapeIndex = dataAndIndex.Item2;
			_currentShape = dataAndIndex.Item1.Modules.ElementAt(dataAndIndex.Item2).Shape.Data;
		}

		private void UpdatePinButton(ModuleViewerData moduleViewerData, ShapeData shape)
		{
			bool flag = _locator.PinnedModulesBarView.IsModulePinned(moduleViewerData, shape);
			_pinModuleButtonContentSwitcher.SetContentByIndex(flag ? 1 : 0);
		}

		private void ShowCenterModule(ShapeData data, bool animateRotation = true)
		{
			_shapeViewer.ShowShape(data, animateRotation);
		}

		private void HideCenterModule()
		{
			_shapeViewer.Hide();
		}

		private void BuildModuleViewerData(ModuleViewerData moduleViewerData)
		{
			_buildingPreview.sprite = moduleViewerData.PreviewSprite;
			SetModuleViewerDataName();
		}

		private void UpdateLocalization()
		{
			SetModuleViewerDataName();
			UpdateStatsStrings();
			if (_currentShape != null)
			{
				SetShapeStats(_currentShape);
			}
		}

		private void SetModuleViewerDataName()
		{
			if (_currentModuleViewerData != null)
			{
				_buildingNameText.SetText(LocalizationUtility.GetLocalizedText(_currentModuleViewerData.TitleLocKey));
			}
		}

		private void BuildModuleList(ModuleViewerData moduleViewerData)
		{
			for (int i = 0; i < _spawnedModuleButtons.Count; i++)
			{
				_spawnedModuleButtons[i].IsActive = false;
				_spawnedModuleButtons[i].gameObject.SetActive(value: false);
			}
			int num = 0;
			foreach (ModuleViewerData.ShapeDataAndAmount module in moduleViewerData.Modules)
			{
				ModuleButtonInViewer moduleButtonInViewer;
				if (num >= _spawnedModuleButtons.Count)
				{
					moduleButtonInViewer = UnityEngine.Object.Instantiate(_moduleButtonPrefab, _buildingModules);
					_spawnedModuleButtons.Add(moduleButtonInViewer);
				}
				else
				{
					moduleButtonInViewer = _spawnedModuleButtons[num];
				}
				moduleButtonInViewer.IsInMaxViewer = _isMaxViewer;
				moduleButtonInViewer.SetModuleIcon(module.Shape.Data.GridIcon, moduleViewerData, num);
				moduleButtonInViewer.SetAmount(module.Amount);
				moduleButtonInViewer.IsPinned = _locator.PinnedModulesBarView.IsModulePinned(_currentModuleViewerData, module.Shape.Data);
				moduleButtonInViewer.gameObject.SetActive(value: true);
				num++;
			}
			_spawnedModuleButtons[_currentShapeIndex].IsActive = true;
		}

		private void UpdateModuleList(ModuleViewerData moduleViewerData)
		{
			int num = 0;
			foreach (ModuleViewerData.ShapeDataAndAmount module in moduleViewerData.Modules)
			{
				_spawnedModuleButtons[num].IsPinned = _locator.PinnedModulesBarView.IsModulePinned(_currentModuleViewerData, module.Shape.Data);
				num++;
			}
			_spawnedModuleButtons[_currentShapeIndex].IsActive = true;
		}
	}
}
