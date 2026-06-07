using System.Collections.Generic;
using System.Threading.Tasks;
using Logic.Shapes;
using UnityEngine;

namespace Data.Shapes
{
	[CreateAssetMenu(menuName = "Factory/Shapes/ShapesDatabase", fileName = "ShapesDatabase", order = 0)]
	public class ShapesDatabase : ScriptableObject
	{
		[SerializeField]
		private ShapeDataSO[] _defaultShapesData;

		private readonly Dictionary<ShapeHashPair, ShapeData> _shapesData = new Dictionary<ShapeHashPair, ShapeData>();

		public int ShapeCount => _shapesData.Count;

		private void OnEnable()
		{
			_shapesData.Clear();
			ShapeDataSO[] defaultShapesData = _defaultShapesData;
			foreach (ShapeDataSO shapeDataSO in defaultShapesData)
			{
				_shapesData.TryAdd(shapeDataSO.Data.GetShapeHash(), shapeDataSO.Data);
			}
		}

		public ShapeData GetOrCreateShapeData(ShapeDto shapeDto)
		{
			if (shapeDto == null)
			{
				return null;
			}
			if (!TryGetShapeData(shapeDto.Hash, out var shapeData))
			{
				return GetOrCreateShapeData(Shape.Create(shapeDto));
			}
			return shapeData;
		}

		public ShapeData GetOrCreateShapeData(Shape shape)
		{
			if (_shapesData.TryGetValue(shape.GetShapeHash(), out var value))
			{
				return value;
			}
			value = shape.SaveShapeData();
			_shapesData.Add(value.GetShapeHash(), value);
			return value;
		}

		public ShapeDto[] GetShapeDtos()
		{
			ShapeDto[] array = new ShapeDto[_shapesData.Count];
			int num = 0;
			foreach (KeyValuePair<ShapeHashPair, ShapeData> shapesDatum in _shapesData)
			{
				array[num++] = new ShapeDto(shapesDatum.Key, shapesDatum.Value.Voxels, shapesDatum.Value.Bounds);
			}
			return array;
		}

		public async Task<bool> LoadShapesAsync(ShapeDto[] shapes)
		{
			if (shapes == null)
			{
				return false;
			}
			foreach (ShapeDto shapeDto in shapes)
			{
				if (!_shapesData.ContainsKey(shapeDto.Hash))
				{
					Shape shape = Shape.Create(shapeDto, trimBounds: false);
					_shapesData.Add(shapeDto.Hash, shape.SaveShapeData());
				}
			}
			return true;
		}

		public bool TryGetShapeData(ShapeHashPair hash, out ShapeData shapeData)
		{
			return _shapesData.TryGetValue(hash, out shapeData);
		}

		public void AddShapeData(ShapeData shapeData)
		{
			if (!_shapesData.ContainsKey(shapeData.GetShapeHash()))
			{
				_shapesData.Add(shapeData.GetShapeHash(), shapeData);
			}
		}
	}
}
