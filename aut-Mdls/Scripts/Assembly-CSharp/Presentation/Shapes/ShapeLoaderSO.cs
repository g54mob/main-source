using System;
using Data.Shapes;
using Logic.Shapes;
using UnityEngine;

namespace Presentation.Shapes
{
	[ExecuteAlways]
	public class ShapeLoaderSO : ShapeLoader
	{
		private ShapeDataSO _shapeDataSO;

		public ShapeDataSO ShapeDataSO => _shapeDataSO;

		public static ShapeLoader CreateFromShapeData(ShapeDataSO shapeData, Material material, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), bool createCollider = false)
		{
			GameObject obj = new GameObject("ShapeLoader");
			obj.transform.SetPositionAndRotation(position, rotation);
			ShapeLoaderSO shapeLoaderSO = obj.AddComponent<ShapeLoaderSO>();
			shapeLoaderSO.EditorFindShapeMeshLibrary();
			shapeLoaderSO.InitMeshRendererAndFilter(material);
			shapeLoaderSO.LoadShapeDataSO(shapeData);
			if (createCollider)
			{
				shapeLoaderSO.CreateCollider();
			}
			return shapeLoaderSO;
		}

		public void LoadShapeDataSO(ShapeDataSO shapeDataSO)
		{
			EditorFindShapeMeshLibrary();
			_shapeDataSO = shapeDataSO;
			base.LoadShapeData(shapeDataSO.Data);
		}

		public override void LoadShape(Shape shape)
		{
			EditorFindShapeMeshLibrary();
			base.LoadShape(shape);
		}

		public override void LoadShapeData(ShapeData shapeData)
		{
			throw new NotSupportedException("Use LoadShapeDataSO or LoadShape(Shape, ShapeDataSO) instead");
		}

		public void SetShapeDataSO(ShapeDataSO shapeDataSO)
		{
			_shapeDataSO = shapeDataSO;
			SetShapeData(shapeDataSO.Data);
		}

		private void EditorFindShapeMeshLibrary()
		{
		}
	}
}
