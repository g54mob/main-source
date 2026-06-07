using System;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Presentation.Shapes.ShapeRenderer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs
{
	public class OutputResourceUI : MonoBehaviour
	{
		[SerializeField]
		private Image _resourceImage;

		[SerializeField]
		private TextMeshProUGUI _resourceName;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		private Material _initialMaterial;

		private ShapeData _shapeData;

		private bool _isRenderingShape;

		private void Awake()
		{
			_initialMaterial = _resourceImage.material;
		}

		public void SetResource(ResourceDataSO resourceDataSO, ShapeData shapeData, int amount)
		{
			StopRenderingShape();
			if (resourceDataSO is NonShapeResourceDataSO nonShapeResourceDataSO)
			{
				_resourceImage.sprite = nonShapeResourceDataSO.Sprite;
				_resourceImage.material = _initialMaterial;
				_resourceName.SetText(LocalizationUtility.GetLocalizedText(nonShapeResourceDataSO.NameLocaKey));
			}
			else
			{
				if (!(shapeData != null))
				{
					throw new NotSupportedException("Resource is not configured properly");
				}
				_resourceImage.sprite = null;
				_resourceImage.material = ShapeRendererManager.RenderShape(shapeData, continuous: false, updateCameraRotation: false, this);
				_shapeData = shapeData;
				_isRenderingShape = true;
				_resourceName.SetText(string.Empty);
			}
			_amountText.SetText(amount.ToString());
		}

		private void StopRenderingShape()
		{
			if (_isRenderingShape)
			{
				ShapeRendererManager.StopRenderShape(_shapeData, this);
				_shapeData = null;
				_isRenderingShape = false;
			}
		}
	}
}
