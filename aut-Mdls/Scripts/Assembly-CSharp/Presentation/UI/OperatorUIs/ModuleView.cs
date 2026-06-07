using Data.FactoryFloor.Resources;
using Data.Shapes;
using Presentation.Shapes.ShapeRenderer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs
{
	public class ModuleView : MonoBehaviour
	{
		[SerializeField]
		private Image _moduleImage;

		[SerializeField]
		private GameObject _amountLabel;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		private Object _source;

		private ShapeData _shapeData;

		private bool _isRenderingShape;

		public void RenderShape(ShapeResource shape, int amount, Object source)
		{
			StopRenderingShape();
			_source = source;
			_moduleImage.material = ShapeRendererManager.RenderShape(shape.ShapeData, continuous: false, updateCameraRotation: false, source);
			_shapeData = shape.ShapeData;
			_isRenderingShape = true;
			_amountLabel.SetActive(amount > 1);
			_amountText.SetText(amount.ToString());
			base.gameObject.SetActive(value: true);
		}

		public void SetResource(NonShapeResourceDataSO resourceData, int amount)
		{
			_moduleImage.sprite = resourceData.Sprite;
			_amountLabel.SetActive(amount > 1);
			_amountText.SetText(amount.ToString());
			base.gameObject.SetActive(value: true);
		}

		public void StopRenderingShape()
		{
			if (_isRenderingShape)
			{
				ShapeRendererManager.StopRenderShape(_shapeData, _source);
				_shapeData = null;
				_isRenderingShape = false;
			}
		}
	}
}
