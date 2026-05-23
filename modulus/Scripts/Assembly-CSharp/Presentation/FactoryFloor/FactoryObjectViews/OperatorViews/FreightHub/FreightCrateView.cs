using Data.FactoryFloor.Resources;
using Presentation.Shapes.ShapeRenderer;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.FreightHub
{
	public class FreightCrateView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _spriteRenderer1;

		[SerializeField]
		private SpriteRenderer _spriteRenderer2;

		[SerializeField]
		private Material _defaultSpriteRenderingMaterial;

		[SerializeField]
		private Sprite _defaultSlotSprite;

		private Material _material;

		private bool _isRenderingShape;

		private ShapeResource _renderShape;

		public void SetResource(Resource resource)
		{
			StopRenderingShape();
			if (resource.Data is NonShapeResourceDataSO nonShapeResourceDataSO)
			{
				_spriteRenderer1.sprite = nonShapeResourceDataSO.Sprite;
				_spriteRenderer2.sprite = nonShapeResourceDataSO.Sprite;
				_spriteRenderer1.material = _defaultSpriteRenderingMaterial;
				_spriteRenderer2.material = _defaultSpriteRenderingMaterial;
			}
			else if (resource is ShapeResource shapeResource)
			{
				_renderShape = shapeResource;
				_material = ShapeRendererManager.RenderShape(shapeResource.ShapeData, continuous: false, updateCameraRotation: false, this);
				_isRenderingShape = true;
				_spriteRenderer1.sprite = _defaultSlotSprite;
				_spriteRenderer1.material = _material;
				_spriteRenderer2.sprite = _defaultSlotSprite;
				_spriteRenderer2.material = _material;
			}
			else
			{
				_spriteRenderer1.sprite = null;
				_spriteRenderer2.sprite = null;
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
	}
}
