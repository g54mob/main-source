using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Events.UI.Overlays;
using Presentation.Shapes.ShapeRenderer;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class StorageDepotUI : FactoryPanelUIMenu
	{
		[Header("Storage Depot Refs")]
		[SerializeField]
		private Button _resetButton;

		[SerializeField]
		private TextMeshProUGUI _description;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		[SerializeField]
		private TextMeshProUGUI _totalText;

		[SerializeField]
		private Image _resourceImage;

		[SerializeField]
		private ResourceInfoPanelContent _resourceInfoPanel;

		[SerializeField]
		private GameObject _panelHasStorage;

		[SerializeField]
		private GameObject _panelHasNoStorage;

		[SerializeField]
		private Material _resourceIconMaterial;

		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		private StorageDepotBehaviour _behaviour;

		private Resource _currentlyShownResource;

		private bool _isRenderingShape;

		private ShapeResource _renderShape;

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as StorageDepotBehaviour;
			_behaviour.OnStoredAmountChanged.RegisterMainThread(HandleAmountChanged);
			UpdateDescription();
			_resetButton.onClick.RemoveListener(OnResetButtonClicked);
			_resetButton.onClick.AddListener(OnResetButtonClicked);
		}

		private void HandleAmountChanged(ulong newAmount)
		{
			UpdateDescription();
		}

		private void UpdateDescription()
		{
			ulong storedAmount = _behaviour.StoredAmount;
			ulong maxStorage = _behaviour.MaxStorage;
			_amountText.gameObject.SetActive(_behaviour.StoredResource != null);
			_totalText.gameObject.SetActive(_behaviour.StoredResource != null);
			_amountText.SetText($"{storedAmount}");
			_totalText.SetText($"/{maxStorage}");
			_panelHasStorage.gameObject.SetActive(storedAmount != 0 && _behaviour.StoredResource != null);
			_panelHasNoStorage.gameObject.SetActive(storedAmount == 0 || _behaviour.StoredResource == null);
			UpdateIcon();
		}

		private void UpdateIcon()
		{
			if (_currentlyShownResource != _behaviour.StoredResource)
			{
				if (_behaviour.StoredResource == null)
				{
					_resourceImage.material = _resourceIconMaterial;
					_resourceImage.sprite = null;
					_resourceInfoPanel.enabled = false;
				}
				else if (_behaviour.StoredResource.Data is NonShapeResourceDataSO nonShapeResourceDataSO)
				{
					_resourceImage.material = _resourceIconMaterial;
					_resourceImage.sprite = nonShapeResourceDataSO.Sprite;
					_resourceInfoPanel.enabled = true;
					_resourceInfoPanel.UpdateContent(nonShapeResourceDataSO);
				}
				else if (_behaviour.StoredResource is ShapeResource shapeResource)
				{
					StopRenderingShape();
					_resourceImage.material = ShapeRendererManager.RenderShape(shapeResource.ShapeData, continuous: true, updateCameraRotation: false, this);
					_renderShape = shapeResource;
					_isRenderingShape = true;
					_resourceImage.sprite = null;
					_resourceInfoPanel.enabled = false;
				}
				_currentlyShownResource = _behaviour.StoredResource;
			}
		}

		private void StopRenderingShape()
		{
			if (_isRenderingShape)
			{
				ShapeRendererManager.StopRenderShape(_renderShape.ShapeData, this);
				_isRenderingShape = false;
			}
		}

		private void OnResetButtonClicked()
		{
			ModalDialogDto modalDialogDto = new ModalDialogDto(new ModalDialogContent("StorageDepot.DiscardWarning"), Sizes.Xs, HandleReset, showCancelButton: true);
			modalDialogDto.OverrideSuccessButtonTextKey = "ModalGeneric.YesButton";
			modalDialogDto.OverrideCancelButtonTextKey = "ModalGeneric.NoButton";
			_showModalDialogEvent.Fire(new UIModaldialogData(modalDialogDto));
		}

		private void HandleReset()
		{
			_behaviour.ResetStorage();
			_currentlyShownResource = null;
			StopRenderingShape();
		}

		public override void HideMenu()
		{
			_resetButton.onClick.RemoveListener(OnResetButtonClicked);
			_behaviour.OnStoredAmountChanged.UnRegisterMainThread(HandleAmountChanged);
			_currentlyShownResource = null;
			StopRenderingShape();
			base.HideMenu();
		}
	}
}
