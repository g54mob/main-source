#define ENABLE_DEBUG_ERRORS
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Presentation.Shapes.ShapeRenderer;
using Presentation.UI.Buttons;
using Presentation.UI.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.Sorter
{
	public class SorterUI : FactoryPanelUIMenu
	{
		private enum ESorterStatus
		{
			NoInput = 0,
			NotConfigured = 1,
			Filtering = 2
		}

		[Header("Sorter UI")]
		[SerializeField]
		private Button _assignButton;

		[SerializeField]
		private Button _skipButton;

		[SerializeField]
		private Button _resetButton;

		[SerializeField]
		private GameObject _resetButtonContainer;

		[SerializeField]
		private ButtonEnabler _assignButtonEnabler;

		[SerializeField]
		private ButtonEnabler _skipButtonEnabler;

		[SerializeField]
		private CanvasGroup _connectionGraphic;

		[SerializeField]
		private TextMeshProUGUI _statusText;

		[Header("Resource")]
		[SerializeField]
		private Image _resourceImage;

		[SerializeField]
		private ResourceInfoPanelContent _resourceInfoPanel;

		[Header("References")]
		[SerializeField]
		private ResourceDatabaseSO _resourceDatabaseSO;

		[SerializeField]
		private ShapesDatabase _shapesDatabaseSO;

		private SorterBehavior _behaviour;

		private Material _resourceImageInitialMaterial;

		private Sprite _resourceImageInitialSprite;

		private ShapeData _lastRenderedShapeData;

		private string _currentStatusLocaKey;

		protected override void HandleOnAwake()
		{
			_resourceImageInitialMaterial = _resourceImage.material;
			_resourceImageInitialSprite = _resourceImage.sprite;
		}

		protected override void SetTexts()
		{
			base.SetTexts();
			SetStatusText();
		}

		private void SetSorterStatus(ESorterStatus value)
		{
			switch (value)
			{
			case ESorterStatus.NoInput:
				_currentStatusLocaKey = LocalizationUtility.GetLocalizedText("Sorter.StatusNoInput");
				_resourceImage.gameObject.SetActive(value: false);
				_statusText.gameObject.SetActive(value: true);
				SetStatusText();
				break;
			case ESorterStatus.NotConfigured:
				_resourceImage.gameObject.SetActive(value: true);
				_statusText.gameObject.SetActive(value: false);
				break;
			case ESorterStatus.Filtering:
				_currentStatusLocaKey = LocalizationUtility.GetLocalizedText("Sorter.StatusFiltering");
				_resourceImage.gameObject.SetActive(value: true);
				_statusText.gameObject.SetActive(value: true);
				SetStatusText();
				break;
			}
		}

		private void SetStatusText()
		{
			_statusText.SetText(_currentStatusLocaKey);
		}

		private void OnShapePassed(Resource resource, int index)
		{
			OnResourceChanged();
		}

		private void OnShapePassed(int index)
		{
			OnResourceChanged();
		}

		private void OnResourceAdded(Resource resource)
		{
			OnResourceChanged();
		}

		private void UpdateButtons()
		{
			_assignButton.gameObject.SetActive(!_behaviour.IsFilterSet);
			_skipButton.gameObject.SetActive(!_behaviour.IsFilterSet);
			_resetButtonContainer.SetActive(_behaviour.IsFilterSet);
			_connectionGraphic.gameObject.SetActive(!_behaviour.IsFilterSet);
		}

		private void AssignButtonPressed()
		{
			_behaviour.AssignCurrentResource();
			HideMenu();
		}

		private void SkipButtonPressed()
		{
			_skipButtonEnabler.Interactable = false;
			_behaviour.SkipCurrentResource();
		}

		private void ResetButtonPressed()
		{
			_behaviour.ResetCurrentResource();
			UpdateButtons();
			OnResourceChanged();
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as SorterBehavior;
			_assignButton.onClick.AddListener(AssignButtonPressed);
			_skipButton.onClick.AddListener(SkipButtonPressed);
			_resetButton.onClick.AddListener(ResetButtonPressed);
			_behaviour.OnResourceAdded.RegisterMainThread(OnResourceAdded);
			_behaviour.OnOutputResource.RegisterMainThread(OnShapePassed);
			_behaviour.OnSkippedResource.RegisterMainThread(OnShapePassed);
			UpdateButtons();
			if (_behaviour.IsFilterSet)
			{
				SetResourceImageToFilter();
			}
			else
			{
				OnResourceChanged();
			}
		}

		public override void HideMenu()
		{
			if (_lastRenderedShapeData != null)
			{
				ShapeRendererManager.StopRenderShape(_lastRenderedShapeData, this);
				_lastRenderedShapeData = null;
			}
			_assignButton.onClick.RemoveListener(AssignButtonPressed);
			_skipButton.onClick.RemoveListener(SkipButtonPressed);
			_resetButton.onClick.RemoveListener(ResetButtonPressed);
			_behaviour.OnResourceAdded.UnRegisterMainThread(OnResourceAdded);
			_behaviour.OnOutputResource.UnRegisterMainThread(OnShapePassed);
			_behaviour.OnSkippedResource.UnRegisterMainThread(OnShapePassed);
			base.HideMenu();
		}

		private void OnResourceChanged()
		{
			if (!_behaviour.IsFilterSet)
			{
				bool hasResource = _behaviour.HasResource;
				_assignButtonEnabler.Interactable = hasResource;
				_skipButtonEnabler.Interactable = hasResource && !_behaviour.IsTryingToSkip;
				_resourceInfoPanel.enabled = false;
				if (_lastRenderedShapeData != null)
				{
					ShapeRendererManager.StopRenderShape(_lastRenderedShapeData, this);
					_lastRenderedShapeData = null;
				}
				if (!hasResource)
				{
					_resourceImage.material = _resourceImageInitialMaterial;
					_resourceImage.sprite = _resourceImageInitialSprite;
					SetSorterStatus(ESorterStatus.NoInput);
				}
				else if (_behaviour.CurrentResource.Data is NonShapeResourceDataSO nonShapeResourceDataSO)
				{
					_resourceImage.material = _resourceImageInitialMaterial;
					_resourceImage.sprite = nonShapeResourceDataSO.Sprite;
					_resourceInfoPanel.UpdateContent(nonShapeResourceDataSO);
					_resourceInfoPanel.enabled = true;
					SetSorterStatus(ESorterStatus.NotConfigured);
				}
				else if (_behaviour.CurrentResource is ShapeResource shapeResource)
				{
					_resourceImage.material = ShapeRendererManager.RenderShape(shapeResource, continuous: false, updateCameraRotation: false, this);
					_resourceImage.sprite = null;
					_lastRenderedShapeData = shapeResource.ShapeData;
					SetSorterStatus(ESorterStatus.NotConfigured);
				}
			}
		}

		private void SetResourceImageToFilter()
		{
			if (_behaviour.IsFilterSet)
			{
				if (_behaviour.FilterHash.IsValid)
				{
					if (_shapesDatabaseSO.TryGetShapeData(_behaviour.FilterHash, out var shapeData))
					{
						_resourceImage.material = ShapeRendererManager.RenderShape(shapeData, continuous: false, updateCameraRotation: false, this);
						_resourceImage.sprite = null;
						_resourceInfoPanel.enabled = false;
						_lastRenderedShapeData = shapeData;
						SetSorterStatus(ESorterStatus.Filtering);
						return;
					}
					this.LogError(string.Format("Sorter filter is set to hash \"{0}\" but resource was not found in the {1}", _behaviour.FilterHash, "ShapesDatabase"), "SetResourceImageToFilter", 224);
				}
				else
				{
					if (_resourceDatabaseSO.GetResourceDataFromID(_behaviour.Filter.ResourceID) is NonShapeResourceDataSO nonShapeResourceDataSO)
					{
						_resourceImage.material = _resourceImageInitialMaterial;
						_resourceImage.sprite = nonShapeResourceDataSO.Sprite;
						_resourceInfoPanel.UpdateContent(nonShapeResourceDataSO);
						_resourceInfoPanel.enabled = true;
						SetSorterStatus(ESorterStatus.Filtering);
						return;
					}
					this.LogError(string.Format("Sorter filter is set to id {0} but resource was not found in the {1}", _behaviour.Filter.ResourceID, "ResourceDatabaseSO"), "SetResourceImageToFilter", 238);
				}
			}
			_resourceImage.material = _resourceImageInitialMaterial;
			_resourceImage.sprite = _resourceImageInitialSprite;
			_resourceInfoPanel.enabled = false;
			SetSorterStatus(ESorterStatus.NotConfigured);
		}
	}
}
