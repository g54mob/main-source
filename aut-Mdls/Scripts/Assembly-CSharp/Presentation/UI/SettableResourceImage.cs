using Data.FactoryFloor.Resources;
using Data.Shapes;
using Presentation.Shapes.ShapeRenderer;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class SettableResourceImage : MonoBehaviour
	{
		[SerializeField]
		private ResourceInfoPanelContent _resourceInfoPanelContent;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private Sprite _unknownSprite;

		private bool _renderingShape;

		private ShapeData _shapeData;

		private Material _material;

		public void SetResourceData(NonShapeResourceDataSO resourceDataSO)
		{
			StopRenderingShape();
			_shapeData = null;
			_image.sprite = resourceDataSO.Sprite;
			_image.material = null;
			if (_resourceInfoPanelContent != null)
			{
				_resourceInfoPanelContent.enabled = true;
				_resourceInfoPanelContent.UpdateContent(resourceDataSO);
			}
		}

		public void SetShapeData(ShapeData shapeData)
		{
			if (_resourceInfoPanelContent != null)
			{
				_resourceInfoPanelContent.enabled = true;
				_resourceInfoPanelContent.UpdateContent(shapeData);
			}
			if (!_renderingShape || !(shapeData == _shapeData))
			{
				StopRenderingShape();
				_shapeData = shapeData;
				if (shapeData.GridIcon == null)
				{
					_material = ShapeRendererManager.RenderShape(shapeData, continuous: false, updateCameraRotation: false, this);
					_image.material = _material;
					_image.sprite = null;
					_renderingShape = true;
				}
				else
				{
					_image.material = null;
					_image.sprite = Sprite.Create(shapeData.GridIcon, new Rect(0f, 0f, shapeData.GridIcon.width, shapeData.GridIcon.height), new Vector2(0.5f, 0.5f));
				}
			}
		}

		public void Reset()
		{
			StopRenderingShape();
			if (_resourceInfoPanelContent != null)
			{
				_resourceInfoPanelContent.enabled = false;
			}
			_image.sprite = _unknownSprite;
			_image.material = null;
			_shapeData = null;
		}

		private void StopRenderingShape()
		{
			if (_renderingShape && !(_shapeData == null))
			{
				ShapeRendererManager.StopRenderShape(_shapeData, this);
			}
		}
	}
}
