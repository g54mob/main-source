#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using UnityEngine;
using Utils;

namespace Presentation.Shapes.ShapeRenderer
{
	public class ShapeRendererManager : MonoBehaviour
	{
		[SerializeField]
		private ShapeRenderer _shapeRendererRef;

		[SerializeField]
		private int _rendererPoolCount = 5;

		private static readonly List<ShapeRenderer> _renderersPool = new List<ShapeRenderer>();

		private void Awake()
		{
			_renderersPool.Clear();
			for (int i = 0; i < _rendererPoolCount; i++)
			{
				AddShapeRender();
			}
		}

		public static ShapeHashPair GetShapeHash(ShapeData shapeData)
		{
			return shapeData.GetShapeHash();
		}

		public static Material RenderShape(ShapeData shapeData, bool continuous, bool updateCameraRotation, Object source)
		{
			ShapeHashPair shapeHash = shapeData.GetShapeHash();
			foreach (ShapeRenderer item in _renderersPool)
			{
				if (item.CompareShapeHash(shapeHash))
				{
					return item.AddSource(source);
				}
			}
			ShapeRenderer shapeRenderer = null;
			foreach (ShapeRenderer item2 in _renderersPool)
			{
				if (!item2.IsRendering && !item2.InUse)
				{
					shapeRenderer = item2;
					break;
				}
			}
			if (shapeRenderer == null)
			{
				typeof(ShapeRendererManager).LogWarning("Shape Renderer Pool has been incremented. Consider increasing the _rendererPoolCount.", "RenderShape", 53);
				return null;
			}
			return shapeRenderer.StartRender(shapeData, continuous, updateCameraRotation, source);
		}

		public static Material RenderShape(ShapeResource shape, bool continuous, bool updateCameraRotation, Object source)
		{
			return RenderShape(shape.ShapeData, continuous, updateCameraRotation, source);
		}

		private void AddShapeRender()
		{
			Vector3 position = new Vector3(2000f, 2000f, 2000f);
			for (int i = 0; i < _renderersPool.Count; i++)
			{
				position += Vector3.one * 500f;
			}
			ShapeRenderer shapeRenderer = Object.Instantiate(_shapeRendererRef, position, Quaternion.identity);
			shapeRenderer.transform.SetParent(base.transform);
			shapeRenderer.Setup();
			_renderersPool.Add(shapeRenderer);
		}

		public static void StopRenderShape(ShapeData shapeData, Object source)
		{
			ShapeHashPair shapeHash = shapeData.GetShapeHash();
			foreach (ShapeRenderer item in _renderersPool)
			{
				if (item.CompareShapeHash(shapeHash))
				{
					item.StopRender(source);
					break;
				}
			}
		}

		public static void StopRenderShape(ShapeResource shape, Object source)
		{
			StopRenderShape(shape.ShapeData, source);
		}
	}
}
