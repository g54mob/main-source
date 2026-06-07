using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Presentation.Shapes.ShapeRenderer;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class FreightHubSlotWidgetSimple : MonoBehaviour
	{
		[SerializeField]
		private Image _resourceImage;

		private Material _resourceIconMaterial;

		private Sprite _resourceIconSprite;

		private Resource _currentlyShownResource;

		private bool _isRenderingShape;

		private ShapeResource _renderShape;

		protected int _slotIndex;

		protected virtual void Awake()
		{
			_resourceIconMaterial = _resourceImage.material;
			_resourceIconSprite = _resourceImage.sprite;
		}

		public void Setup(int slotIndex)
		{
			_slotIndex = slotIndex;
		}

		public void UpdateDisplay(FreightHubBehaviour.FreightHubSlot freightHubSlot)
		{
			UpdateIcon(freightHubSlot);
		}

		public void ClearDisplay()
		{
			_currentlyShownResource = null;
			ResetIcon();
			StopRenderingShape();
		}

		private void UpdateIcon(FreightHubBehaviour.FreightHubSlot freightHubSlot)
		{
			if (_currentlyShownResource != freightHubSlot.Resource)
			{
				StopRenderingShape();
				if (!freightHubSlot.HasResource)
				{
					ResetIcon();
				}
				else if (freightHubSlot.Resource.Data is NonShapeResourceDataSO nonShapeResourceDataSO)
				{
					_resourceImage.material = _resourceIconMaterial;
					_resourceImage.sprite = nonShapeResourceDataSO.Sprite;
					SetResourceCanHaveInfoPanel(value: true, nonShapeResourceDataSO);
				}
				else if (freightHubSlot.Resource is ShapeResource shapeResource)
				{
					_resourceImage.material = ShapeRendererManager.RenderShape(shapeResource.ShapeData, continuous: false, updateCameraRotation: false, this);
					_renderShape = shapeResource;
					_isRenderingShape = true;
					_resourceImage.sprite = null;
					SetResourceCanHaveInfoPanel(value: false);
				}
				_currentlyShownResource = freightHubSlot.Resource;
			}
		}

		protected virtual void SetResourceCanHaveInfoPanel(bool value, NonShapeResourceDataSO resourceData = null)
		{
		}

		private void StopRenderingShape()
		{
			if (_isRenderingShape)
			{
				_isRenderingShape = false;
				ShapeRendererManager.StopRenderShape(_renderShape.ShapeData, this);
				_currentlyShownResource = null;
			}
		}

		private void ResetIcon()
		{
			_resourceImage.material = _resourceIconMaterial;
			_resourceImage.sprite = _resourceIconSprite;
			SetResourceCanHaveInfoPanel(value: false);
		}
	}
}
