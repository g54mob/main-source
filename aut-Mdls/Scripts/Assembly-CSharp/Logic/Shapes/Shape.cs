#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Shapes;
using UnityEngine;
using UnityEngine.Pool;
using Utils;

namespace Logic.Shapes
{
	public class Shape
	{
		public enum Direction
		{
			Left = 0,
			Up = 1,
			Down = 2,
			Right = 3,
			Forward = 4,
			Backward = 5
		}

		public enum CutDirection
		{
			Horizontal = 0,
			Vertical = 1
		}

		public enum RotateDirection
		{
			Right = 0,
			Left = 1,
			Forward = 2,
			Backward = 3,
			RollRight = 4,
			RollLeft = 5
		}

		private const int MAX_SHAPE_SIZE = 18;

		public const float VOXEL_SIZE = 0.1f;

		public const float HALF_VOXEL_SIZE = 0.05f;

		private ShapeData _shapeData;

		private Voxel[,,] _voxels;

		private List<Voxel> _occupiedVoxels = new List<Voxel>();

		private Vector3Int _bounds;

		private Hash128 _voxelHash;

		private Hash128 _colorHash;

		private ShapeHashPair _cachedHash;

		private bool _hashDirty = true;

		private Vector3 _position;

		private bool _trimBounds = true;

		public bool TrimBounds
		{
			get
			{
				return _trimBounds;
			}
			set
			{
				_trimBounds = value;
			}
		}

		public ShapeData ShapeData => _shapeData;

		public Vector3 Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}

		public Voxel[,,] Voxels => _voxels;

		public List<Voxel> OccupiedVoxels => _occupiedVoxels;

		private Shape()
		{
		}

		private Shape(Vector3 position)
		{
			_position = position;
		}

		public static Shape Create(ShapeData shapeData, Vector3 position = default(Vector3))
		{
			Shape shape = new Shape();
			shape.LoadShapeData(shapeData);
			shape._position = position;
			return shape;
		}

		public static Shape Create(ShapeDto shapeDto, bool trimBounds = true)
		{
			Vector3Int bounds = shapeDto.Bounds;
			Voxel[,,] array = new Voxel[bounds.x, bounds.y, bounds.z];
			for (int i = 0; i < shapeDto.Voxels.Length; i++)
			{
				Vector3Int vector3Int = to3D(i, bounds);
				array[vector3Int.x, vector3Int.y, vector3Int.z] = shapeDto.GetVoxel(vector3Int.x, vector3Int.y, vector3Int.z);
			}
			Shape shape = new Shape();
			shape.TrimBounds = trimBounds;
			shape.SetVoxels(array);
			return shape;
		}

		public static Shape CreateCube(Vector3 position, int size, Color color)
		{
			Voxel[,,] array = new Voxel[size, size, size];
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					for (int k = 0; k < size; k++)
					{
						array[i, j, k] = new Voxel
						{
							Position = new Vector3Int(i, j, k),
							IsOccupied = true,
							Color = color
						};
					}
				}
			}
			Shape shape = new Shape();
			shape._position = position;
			shape._bounds = new Vector3Int(size, size, size);
			shape.SetVoxels(array);
			return shape;
		}

		public static Shape CreateCube(Vector3 position, Vector3Int size, Color color)
		{
			Voxel[,,] array = new Voxel[size.x, size.y, size.z];
			for (int i = 0; i < size.x; i++)
			{
				for (int j = 0; j < size.y; j++)
				{
					for (int k = 0; k < size.z; k++)
					{
						array[i, j, k] = new Voxel
						{
							Position = new Vector3Int(i, j, k),
							IsOccupied = true,
							Color = color
						};
					}
				}
			}
			Shape shape = new Shape();
			shape._position = position;
			shape._bounds = new Vector3Int(size.x, size.y, size.z);
			shape.SetVoxels(array);
			return shape;
		}

		public static Shape CreateEmptyShape(Vector3 position = default(Vector3), Vector3Int size = default(Vector3Int), Color color = default(Color), bool trimBounds = true)
		{
			Voxel[,,] array = new Voxel[size.x, size.y, size.z];
			for (int i = 0; i < size.x; i++)
			{
				for (int j = 0; j < size.y; j++)
				{
					for (int k = 0; k < size.z; k++)
					{
						array[i, j, k] = new Voxel
						{
							Position = new Vector3Int(i, j, k),
							IsOccupied = false,
							Color = color
						};
					}
				}
			}
			Shape shape = new Shape();
			shape.TrimBounds = trimBounds;
			shape._position = position;
			shape._bounds = new Vector3Int(size.x, size.y, size.z);
			shape.SetVoxels(array, calculateHash: true, calculateBounds: false);
			return shape;
		}

		public Vector3Int GetBounds()
		{
			return _bounds;
		}

		public void SetBounds(Vector3Int bounds)
		{
			_bounds = bounds;
		}

		public void SetVoxels(Voxel[,,] voxels, bool calculateHash = true, bool calculateBounds = true)
		{
			_voxels = voxels;
			if (calculateBounds)
			{
				CalculateBounds(calculateHash);
			}
		}

		public void CopyData(Shape other)
		{
			_voxels = (Voxel[,,])other._voxels.Clone();
			_occupiedVoxels = new List<Voxel>(other._occupiedVoxels);
			_bounds = other._bounds;
			_voxelHash = other._voxelHash;
			_colorHash = other._colorHash;
			_position = other._position;
			_hashDirty = true;
		}

		public Voxel GetVoxel(int x, int y, int z)
		{
			return _voxels[x, y, z];
		}

		public Voxel GetVoxel(Vector3Int voxelPos)
		{
			return _voxels[voxelPos.x, voxelPos.y, voxelPos.z];
		}

		public bool TryGetVoxel(Vector3Int voxelPos, out Voxel voxel)
		{
			if (voxelPos.x < 0 || voxelPos.y < 0 || voxelPos.z < 0)
			{
				voxel = default(Voxel);
				return false;
			}
			if (voxelPos.x >= _bounds.x || voxelPos.y >= _bounds.y || voxelPos.z >= _bounds.z)
			{
				voxel = default(Voxel);
				return false;
			}
			voxel = GetVoxel(voxelPos);
			return true;
		}

		public void SetOccupiedVoxels(List<Voxel> occupiedVoxels)
		{
			_occupiedVoxels = occupiedVoxels;
		}

		public Vector3Int GetVoxelOffsetToShape(Shape shape)
		{
			Vector3 vector = _position - new Vector3((float)_bounds.x / 2f * 0.1f, 0f, (float)_bounds.z / 2f * 0.1f) + new Vector3(1f, 0f, 1f) * 0.05f;
			Vector3 vector2 = shape._position - new Vector3((float)shape._bounds.x / 2f * 0.1f, 0f, (float)shape._bounds.z / 2f * 0.1f) + new Vector3(1f, 0f, 1f) * 0.05f - vector;
			vector2 /= 0.1f;
			return new Vector3Int(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y), Mathf.RoundToInt(vector2.z));
		}

		public Vector3 VoxelPosToWorldPos(Vector3Int voxelPos)
		{
			return _position - new Vector3((float)_bounds.x / 2f * 0.1f, 0f, (float)_bounds.z / 2f * 0.1f) + new Vector3(1f, 1f, 1f) * 0.05f + new Vector3((float)voxelPos.x * 0.1f, (float)voxelPos.y * 0.1f, (float)voxelPos.z * 0.1f);
		}

		public Vector3 VoxelPosToWorldPos(Voxel voxel)
		{
			return _position - new Vector3((float)_bounds.x / 2f * 0.1f, 0f, (float)_bounds.z / 2f * 0.1f) + new Vector3(1f, 1f, 1f) * 0.05f + new Vector3((float)voxel.Position.x * 0.1f, (float)voxel.Position.y * 0.1f, (float)voxel.Position.z * 0.1f);
		}

		public Vector3Int WorldPosToVoxelPos(Vector3 worldPos)
		{
			Vector3 vector = _position - new Vector3((float)_bounds.x / 2f * 0.1f, 0f, (float)_bounds.z / 2f * 0.1f) + new Vector3(1f, 1f, 1f) * 0.05f;
			Vector3 vector2 = worldPos - vector;
			return new Vector3Int(Mathf.RoundToInt(vector2.x / 0.1f), Mathf.RoundToInt(vector2.y / 0.1f), Mathf.RoundToInt(vector2.z / 0.1f));
		}

		public bool IsWorldPosWithinBounds(Vector3 worldPos, out Voxel voxel)
		{
			Vector3 vector = _position - new Vector3((float)_bounds.x / 2f * 0.1f, 0f, (float)_bounds.z / 2f * 0.1f) + new Vector3(1f, 1f, 1f) * 0.05f;
			Vector3 vector2 = worldPos - vector;
			Vector3Int voxelPos = new Vector3Int(Mathf.RoundToInt(vector2.x / 0.1f), Mathf.RoundToInt(vector2.y / 0.1f), Mathf.RoundToInt(vector2.z / 0.1f));
			if (IsVoxelPosWithinBounds(voxelPos, out voxel))
			{
				return true;
			}
			return false;
		}

		public bool IsVoxelPosWithinBounds(Vector3Int voxelPos, out Voxel voxel)
		{
			voxel = _voxels[0, 0, 0];
			if (voxelPos.x >= _bounds.x || voxelPos.x < 0 || voxelPos.y >= _bounds.y || voxelPos.y < 0 || voxelPos.z >= _bounds.z || voxelPos.z < 0)
			{
				return false;
			}
			voxel = _voxels[voxelPos.x, voxelPos.y, voxelPos.z];
			return true;
		}

		public Shape Duplicate()
		{
			Shape shape = new Shape();
			shape.CopyData(this);
			return shape;
		}

		public bool CompareBounds(Shape other)
		{
			return _bounds == other._bounds;
		}

		public bool CompareVoxels(Shape other)
		{
			return _voxelHash == other._voxelHash;
		}

		public bool CompareColors(Shape other)
		{
			return _colorHash == other._colorHash;
		}

		public Hash128 GetVoxelHash()
		{
			return _voxelHash;
		}

		public Hash128 GetColorHash()
		{
			return _colorHash;
		}

		public ShapeHashPair GetShapeHash()
		{
			if (!_cachedHash.VoxelHash.isValid || !_cachedHash.ColorHash.isValid || _hashDirty)
			{
				_cachedHash = new ShapeHashPair
				{
					VoxelHash = _voxelHash,
					ColorHash = _colorHash
				};
				_hashDirty = false;
			}
			return _cachedHash;
		}

		public bool BruteForceCompareVoxels(Shape other, out bool sameColors)
		{
			sameColors = true;
			bool flag = true;
			for (int i = 0; i < _bounds.x; i++)
			{
				for (int j = 0; j < _bounds.y; j++)
				{
					for (int k = 0; k < _bounds.z; k++)
					{
						if (!flag && !sameColors)
						{
							return false;
						}
						if (_voxels[i, j, k].IsOccupied != other._voxels[i, j, k].IsOccupied)
						{
							flag = false;
						}
						if (_voxels[i, j, k].Color != other._voxels[i, j, k].Color)
						{
							sameColors = false;
						}
					}
				}
			}
			return flag;
		}

		public (Shape, Shape) Cut(CutDirection direction, int pos)
		{
			Shape shape = new Shape();
			Shape shape2 = new Shape();
			Voxel[,,] array;
			Voxel[,,] array2;
			switch (direction)
			{
			case CutDirection.Horizontal:
			{
				array = new Voxel[_bounds.x, pos, _bounds.z];
				array2 = new Voxel[_bounds.x, _bounds.y - pos, _bounds.z];
				for (int l = 0; l < _bounds.x; l++)
				{
					for (int m = 0; m < _bounds.y; m++)
					{
						for (int n = 0; n < _bounds.z; n++)
						{
							if (m >= pos)
							{
								array2[l, m - pos, n] = _voxels[l, m, n];
							}
							else
							{
								array[l, m, n] = _voxels[l, m, n];
							}
						}
					}
				}
				shape2._position += new Vector3(0f, 0.1f * (float)pos, 0f);
				break;
			}
			case CutDirection.Vertical:
			{
				array = new Voxel[pos, _bounds.y, _bounds.z];
				array2 = new Voxel[_bounds.x - pos, _bounds.y, _bounds.z];
				for (int i = 0; i < _bounds.x; i++)
				{
					for (int j = 0; j < _bounds.y; j++)
					{
						for (int k = 0; k < _bounds.z; k++)
						{
							if (i >= pos)
							{
								array2[i - pos, j, k] = _voxels[i, j, k];
							}
							else
							{
								array[i, j, k] = _voxels[i, j, k];
							}
						}
					}
				}
				float num = (float)_bounds.x / 4f;
				float num2 = ((pos % 2 == 0) ? 0.05f : 0.025f);
				shape._position += new Vector3(0.1f * (0f - num) + num2, 0f, 0f);
				shape2._position += new Vector3(0.1f * (float)pos - 0.1f * num - num2, 0f, 0f);
				break;
			}
			default:
				array = new Voxel[0, 0, 0];
				array2 = new Voxel[0, 0, 0];
				break;
			}
			shape.SetVoxels(array);
			shape2.SetVoxels(array2);
			return (shape, shape2);
		}

		public Shape[] CutInterval(int interval)
		{
			int num = _bounds.x / interval;
			num += ((_bounds.x % interval != 0) ? 1 : 0);
			if (num < 1)
			{
				num = 1;
			}
			Voxel[][,,] array = new Voxel[num][,,];
			for (int i = 0; i < num; i++)
			{
				if (i == num - 1)
				{
					array[i] = new Voxel[(_bounds.x % interval == 0) ? interval : (_bounds.x % interval), _bounds.y, _bounds.z];
				}
				else
				{
					array[i] = new Voxel[interval, _bounds.y, _bounds.z];
				}
			}
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < _bounds.x; j++)
			{
				for (int k = 0; k < _bounds.y; k++)
				{
					for (int l = 0; l < _bounds.z; l++)
					{
						array[num2][j - num2 * interval, k, l] = _voxels[j, k, l];
					}
				}
				num3++;
				if (num3 == interval)
				{
					num2++;
					num3 = 0;
				}
			}
			List<Shape> list = new List<Shape>();
			for (int m = 0; m < array.Length; m++)
			{
				Shape shape = new Shape();
				shape.SetVoxels(array[m]);
				if (!shape.IsShapeEmpty())
				{
					list.Add(shape);
				}
			}
			return list.ToArray();
		}

		public Shape[] CutInterval(IReadOnlyList<int> cuts)
		{
			if (cuts == null)
			{
				return new Shape[1] { this };
			}
			List<Voxel[,,]> list = new List<Voxel[,,]>();
			int num = 1;
			int num2 = _bounds.x / -2 + 1;
			for (int i = num2; i < _bounds.x + num2; i++)
			{
				if (!cuts.Contains(i))
				{
					num++;
					continue;
				}
				list.Add(new Voxel[num, _bounds.y, _bounds.z]);
				num = 1;
			}
			list.Add(new Voxel[num, _bounds.y, _bounds.z]);
			int num3 = 0;
			int num4 = num2;
			for (int j = num2; j < _bounds.x + num2; j++)
			{
				int num5 = j - num4;
				if (num5 == list[num3].GetLength(0))
				{
					num3++;
					num4 = j;
					num5 = j - num4;
				}
				for (int k = 0; k < _bounds.y; k++)
				{
					for (int l = 0; l < _bounds.z; l++)
					{
						list[num3][num5, k, l] = _voxels[j - num2, k, l];
					}
				}
			}
			List<Shape> list2 = new List<Shape>();
			for (int m = 0; m < list.Count; m++)
			{
				Shape shape = new Shape();
				shape.SetVoxels(list[m]);
				if (!shape.IsShapeEmpty())
				{
					list2.Add(shape);
				}
			}
			return list2.ToArray();
		}

		public void Rotate(RotateDirection rotDir)
		{
			Voxel[,,] array;
			switch (rotDir)
			{
			case RotateDirection.Right:
			case RotateDirection.Left:
			{
				array = new Voxel[_bounds.z, _bounds.y, _bounds.x];
				for (int l = 0; l < _bounds.x; l++)
				{
					for (int m = 0; m < _bounds.y; m++)
					{
						for (int n = 0; n < _bounds.z; n++)
						{
							Vector3Int vector3Int2 = ((rotDir == RotateDirection.Right) ? new Vector3Int(n, m, l * -1 + (_bounds.x - 1)) : new Vector3Int(n * -1 + (_bounds.z - 1), m, l));
							array[vector3Int2.x, vector3Int2.y, vector3Int2.z] = _voxels[l, m, n];
						}
					}
				}
				break;
			}
			case RotateDirection.Forward:
			case RotateDirection.Backward:
			{
				array = new Voxel[_bounds.x, _bounds.z, _bounds.y];
				for (int num = 0; num < _bounds.x; num++)
				{
					for (int num2 = 0; num2 < _bounds.y; num2++)
					{
						for (int num3 = 0; num3 < _bounds.z; num3++)
						{
							Vector3Int vector3Int3 = ((rotDir == RotateDirection.Backward) ? new Vector3Int(num, num3, num2 * -1 + (_bounds.y - 1)) : new Vector3Int(num, num3 * -1 + (_bounds.z - 1), num2));
							array[vector3Int3.x, vector3Int3.y, vector3Int3.z] = _voxels[num, num2, num3];
						}
					}
				}
				break;
			}
			default:
			{
				array = new Voxel[_bounds.y, _bounds.x, _bounds.z];
				for (int i = 0; i < _bounds.x; i++)
				{
					for (int j = 0; j < _bounds.y; j++)
					{
						for (int k = 0; k < _bounds.z; k++)
						{
							Vector3Int vector3Int = ((rotDir == RotateDirection.RollRight) ? new Vector3Int(j, i * -1 + (_bounds.x - 1), k) : new Vector3Int(j * -1 + (_bounds.y - 1), i, k));
							array[vector3Int.x, vector3Int.y, vector3Int.z] = _voxels[i, j, k];
						}
					}
				}
				break;
			}
			}
			SetVoxels(array);
		}

		public void Rotate(Vector3Int newRotation)
		{
			while (newRotation.y > 0)
			{
				if (newRotation.y > 180)
				{
					Rotate(RotateDirection.Left);
					newRotation.y -= 270;
				}
				if (newRotation.y > 0 && newRotation.y <= 180)
				{
					Rotate(RotateDirection.Right);
					newRotation.y -= 90;
				}
			}
			while (newRotation.z > 0)
			{
				if (newRotation.z > 180)
				{
					Rotate(RotateDirection.RollRight);
					newRotation.z -= 270;
				}
				if (newRotation.z > 0 && newRotation.z <= 180)
				{
					Rotate(RotateDirection.RollLeft);
					newRotation.z -= 90;
				}
			}
			while (newRotation.x > 0)
			{
				if (newRotation.x > 180)
				{
					Rotate(RotateDirection.Forward);
					newRotation.x -= 270;
				}
				if (newRotation.x > 0 && newRotation.x <= 180)
				{
					Rotate(RotateDirection.Backward);
					newRotation.x -= 90;
				}
			}
		}

		public Shape Combine(Shape shape, bool calculateHash = true, bool calculateBounds = true, bool trimBounds = true)
		{
			Vector3Int voxelOffsetToShape = GetVoxelOffsetToShape(shape);
			Vector3Int vector3Int = new Vector3Int((voxelOffsetToShape.x >= 0) ? Mathf.Max(voxelOffsetToShape.x + shape._bounds.x, _bounds.x) : Mathf.Max(Mathf.Abs(voxelOffsetToShape.x) + _bounds.x, shape._bounds.x), (voxelOffsetToShape.y >= 0) ? Mathf.Max(voxelOffsetToShape.y + shape._bounds.y, _bounds.y) : Mathf.Max(Mathf.Abs(voxelOffsetToShape.y) + _bounds.y, shape._bounds.y), (voxelOffsetToShape.z >= 0) ? Mathf.Max(voxelOffsetToShape.z + shape._bounds.z, _bounds.z) : Mathf.Max(Mathf.Abs(voxelOffsetToShape.z) + _bounds.z, shape._bounds.z));
			if (vector3Int.x > 18 || vector3Int.y > 18 || vector3Int.z > 18)
			{
				this.LogError(string.Format("Tried to combine shapes into a shape that exceeds the maximum size (Attempted Size: {0}x{1}x{2}, Max Size: {3}x{3}x{3})", vector3Int.x, vector3Int.y, vector3Int.z, 18), "Combine", 815);
				return null;
			}
			Voxel[,,] array = new Voxel[vector3Int.x, vector3Int.y, vector3Int.z];
			for (int i = 0; i < _bounds.x; i++)
			{
				for (int j = 0; j < _bounds.y; j++)
				{
					for (int k = 0; k < _bounds.z; k++)
					{
						int num = ((voxelOffsetToShape.x < 0) ? (i - voxelOffsetToShape.x) : i);
						int num2 = ((voxelOffsetToShape.y < 0) ? (j - voxelOffsetToShape.y) : j);
						int num3 = ((voxelOffsetToShape.z < 0) ? (k - voxelOffsetToShape.z) : k);
						array[num, num2, num3] = _voxels[i, j, k];
					}
				}
			}
			for (int l = 0; l < shape._bounds.x; l++)
			{
				for (int m = 0; m < shape._bounds.y; m++)
				{
					for (int n = 0; n < shape._bounds.z; n++)
					{
						int num4 = ((voxelOffsetToShape.x > 0) ? (l + voxelOffsetToShape.x) : l);
						int num5 = ((voxelOffsetToShape.y > 0) ? (m + voxelOffsetToShape.y) : m);
						int num6 = ((voxelOffsetToShape.z > 0) ? (n + voxelOffsetToShape.z) : n);
						if (shape._voxels[l, m, n].IsOccupied)
						{
							array[num4, num5, num6] = shape._voxels[l, m, n];
						}
					}
				}
			}
			Shape shape2 = new Shape(_position);
			shape2.TrimBounds = trimBounds;
			shape2.SetVoxels(array, calculateHash, calculateBounds);
			return shape2;
		}

		public Vector3Int GetCombinedShapeBounds(List<Shape> shapes)
		{
			Vector3 vector = VoxelPosToWorldPos(_voxels[0, 0, 0]);
			Vector3 vector2 = VoxelPosToWorldPos(_voxels[_bounds.x - 1, _bounds.y - 1, _bounds.z - 1]);
			for (int i = 0; i < shapes.Count; i++)
			{
				vector = Vector3.Min(vector, shapes[i].VoxelPosToWorldPos(shapes[i]._voxels[0, 0, 0]));
				vector2 = Vector3.Max(vector2, shapes[i].VoxelPosToWorldPos(shapes[i]._voxels[shapes[i]._bounds.x - 1, shapes[i]._bounds.y - 1, shapes[i]._bounds.z - 1]));
			}
			Vector3Int vector3Int = WorldPosToVoxelPos(vector);
			Vector3Int vector3Int2 = WorldPosToVoxelPos(vector2);
			return new Vector3Int(Mathf.Abs(vector3Int2.x - vector3Int.x) + 1, Mathf.Abs(vector3Int2.y - vector3Int.y) + 1, Mathf.Abs(vector3Int2.z - vector3Int.z) + 1);
		}

		public Shape Combine(List<Shape> shapes)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			for (int i = 0; i < shapes.Count; i++)
			{
				if (shapes[i] != null)
				{
					Vector3Int voxelOffsetToShape = GetVoxelOffsetToShape(shapes[i]);
					list.Add(voxelOffsetToShape);
				}
			}
			Vector3 vector = VoxelPosToWorldPos(_voxels[0, 0, 0]);
			Vector3 vector2 = VoxelPosToWorldPos(_voxels[_bounds.x - 1, _bounds.y - 1, _bounds.z - 1]);
			for (int j = 0; j < shapes.Count; j++)
			{
				vector = Vector3.Min(vector, shapes[j].VoxelPosToWorldPos(shapes[j]._voxels[0, 0, 0]));
				vector2 = Vector3.Max(vector2, shapes[j].VoxelPosToWorldPos(shapes[j]._voxels[shapes[j]._bounds.x - 1, shapes[j]._bounds.y - 1, shapes[j]._bounds.z - 1]));
			}
			Vector3Int vector3Int = WorldPosToVoxelPos(vector);
			Vector3Int vector3Int2 = WorldPosToVoxelPos(vector2);
			Vector3Int vector3Int3 = new Vector3Int(Mathf.Abs(vector3Int2.x - vector3Int.x) + 1, Mathf.Abs(vector3Int2.y - vector3Int.y) + 1, Mathf.Abs(vector3Int2.z - vector3Int.z) + 1);
			Vector3Int vector3Int4 = vector3Int;
			if (vector3Int3.x > 18 || vector3Int3.y > 18 || vector3Int3.z > 18)
			{
				this.LogError(string.Format("Tried to combine shapes into a shape that exceeds the maximum size (Attempted Size: {0}x{1}x{2}, Max Size: {3}x{3}x{3})", vector3Int3.x, vector3Int3.y, vector3Int3.z, 18), "Combine", 922);
				return null;
			}
			Shape shape = new Shape(_position);
			Voxel[,,] array = new Voxel[vector3Int3.x, vector3Int3.y, vector3Int3.z];
			for (int k = 0; k < _bounds.x; k++)
			{
				for (int l = 0; l < _bounds.y; l++)
				{
					for (int m = 0; m < _bounds.z; m++)
					{
						int num = ((vector3Int4.x < 0) ? (k - vector3Int4.x) : k);
						int num2 = ((vector3Int4.y < 0) ? (l - vector3Int4.y) : l);
						int num3 = ((vector3Int4.z < 0) ? (m - vector3Int4.z) : m);
						array[num, num2, num3] = _voxels[k, l, m];
					}
				}
			}
			for (int n = 0; n < shapes.Count; n++)
			{
				for (int num4 = 0; num4 < shapes[n]._bounds.x; num4++)
				{
					for (int num5 = 0; num5 < shapes[n]._bounds.y; num5++)
					{
						for (int num6 = 0; num6 < shapes[n]._bounds.z; num6++)
						{
							int num7 = ((list[n].x - vector3Int4.x > 0) ? (num4 + list[n].x - vector3Int4.x) : num4);
							int num8 = ((list[n].y - vector3Int4.y > 0) ? (num5 + list[n].y - vector3Int4.y) : num5);
							int num9 = ((list[n].z - vector3Int4.z > 0) ? (num6 + list[n].z - vector3Int4.z) : num6);
							if (shapes[n]._voxels[num4, num5, num6].IsOccupied)
							{
								array[num7, num8, num9] = shapes[n]._voxels[num4, num5, num6];
							}
						}
					}
				}
			}
			shape.SetVoxels(array);
			return shape;
		}

		public (Shape, Shape) Stamp(Vector3Int minPos, Vector3Int maxPos, bool calculateHash = true, bool calculateBounds = true, bool forceRecalculateOccupiedVoxels = false, bool trimBounds = true)
		{
			minPos = new Vector3Int(Mathf.Max(minPos.x, 0), Mathf.Max(minPos.y, 0), Mathf.Max(minPos.z, 0));
			maxPos = new Vector3Int(Mathf.Min(maxPos.x, _bounds.x - 1), Mathf.Min(maxPos.y, _bounds.y - 1), Mathf.Min(maxPos.z, _bounds.z - 1));
			Voxel[,,] array = new Voxel[_bounds.x, _bounds.y, _bounds.z];
			Voxel[,,] array2 = new Voxel[_bounds.x, _bounds.y, _bounds.z];
			List<Voxel> list = new List<Voxel>();
			List<Voxel> list2 = new List<Voxel>();
			for (int i = 0; i < _bounds.x; i++)
			{
				for (int j = 0; j < _bounds.y; j++)
				{
					for (int k = 0; k < _bounds.z; k++)
					{
						if (i >= minPos.x && i <= maxPos.x && j >= minPos.y && j <= maxPos.y && k >= minPos.z && k <= maxPos.z)
						{
							Voxel voxel = _voxels[i, j, k];
							if (voxel.IsOccupied)
							{
								list.Add(voxel);
							}
							array[i, j, k] = voxel;
						}
						else
						{
							Voxel item = _voxels[i, j, k];
							if (item.IsOccupied)
							{
								list2.Add(item);
							}
							array2[i, j, k] = _voxels[i, j, k];
						}
					}
				}
			}
			Shape shape = new Shape(_position);
			Shape shape2 = new Shape(_position);
			shape.TrimBounds = trimBounds;
			shape2.TrimBounds = trimBounds;
			if (forceRecalculateOccupiedVoxels)
			{
				shape.SetOccupiedVoxels(list);
				shape2.SetOccupiedVoxels(list2);
			}
			if (!calculateBounds)
			{
				shape._bounds = _bounds;
				shape2._bounds = _bounds;
			}
			shape.SetVoxels(array, calculateHash, calculateBounds);
			shape2.SetVoxels(array2, calculateHash, calculateBounds);
			return (shape, shape2);
		}

		public Shape RemoveColors(List<Color> removedColors)
		{
			Voxel[,,] array = new Voxel[_bounds.x, _bounds.y, _bounds.z];
			List<Voxel> list = new List<Voxel>();
			for (int i = 0; i < _bounds.x; i++)
			{
				for (int j = 0; j < _bounds.y; j++)
				{
					for (int k = 0; k < _bounds.z; k++)
					{
						Voxel voxel = _voxels[i, j, k];
						if (voxel.IsOccupied && removedColors.Contains(voxel.Color))
						{
							list.Add(voxel);
							array[i, j, k] = voxel;
						}
					}
				}
			}
			Shape shape = new Shape(_position);
			shape.TrimBounds = false;
			shape.SetOccupiedVoxels(list);
			shape.SetVoxels(array);
			return shape;
		}

		public Shape Subtract(Shape subtractor, bool calculateHash = true, bool calculateBounds = true, bool trimBounds = true)
		{
			Voxel[,,] array = (Voxel[,,])_voxels.Clone();
			Voxel[,,] voxels = subtractor.Voxels;
			int upperBound = voxels.GetUpperBound(0);
			int upperBound2 = voxels.GetUpperBound(1);
			int upperBound3 = voxels.GetUpperBound(2);
			for (int i = voxels.GetLowerBound(0); i <= upperBound; i++)
			{
				for (int j = voxels.GetLowerBound(1); j <= upperBound2; j++)
				{
					for (int k = voxels.GetLowerBound(2); k <= upperBound3; k++)
					{
						Voxel voxel = voxels[i, j, k];
						if (!voxel.IsOccupied)
						{
							continue;
						}
						int length = array.GetLength(0);
						Vector3Int position = voxel.Position;
						if (length <= position.x)
						{
							continue;
						}
						int length2 = array.GetLength(1);
						position = voxel.Position;
						if (length2 > position.y)
						{
							int length3 = array.GetLength(2);
							position = voxel.Position;
							if (length3 > position.z)
							{
								position = voxel.Position;
								int x = position.x;
								position = voxel.Position;
								int y = position.y;
								position = voxel.Position;
								array[x, y, position.z].IsOccupied = false;
							}
						}
					}
				}
			}
			Shape shape = new Shape(_position);
			shape.TrimBounds = trimBounds;
			shape.SetVoxels(array, calculateHash, calculateBounds);
			return shape;
		}

		public void ChangeColor(Color color)
		{
			for (int i = 0; i < _occupiedVoxels.Count; i++)
			{
				Voxel voxel = new Voxel
				{
					IsOccupied = true,
					Color = color,
					Position = _occupiedVoxels[i].Position
				};
				_occupiedVoxels[i] = voxel;
				_voxels[_occupiedVoxels[i].Position.x, _occupiedVoxels[i].Position.y, _occupiedVoxels[i].Position.z] = voxel;
			}
			CalculateBounds();
		}

		public bool IsOverlappingWithShape(Shape shape, out Voxel[] overlappingVoxels)
		{
			Vector3Int voxelOffsetToShape = GetVoxelOffsetToShape(shape);
			if (Mathf.Abs(voxelOffsetToShape.x) > _bounds.x + shape._bounds.x || Mathf.Abs(voxelOffsetToShape.z) > _bounds.z + shape._bounds.z || Mathf.Abs(voxelOffsetToShape.y) > _bounds.y + shape._bounds.y)
			{
				overlappingVoxels = new Voxel[0];
				return false;
			}
			bool result = false;
			List<Voxel> list = CollectionPool<List<Voxel>, Voxel>.Get();
			for (int i = 0; i < _bounds.x; i++)
			{
				for (int j = 0; j < _bounds.y; j++)
				{
					for (int k = 0; k < _bounds.z; k++)
					{
						if (shape.IsVoxelPosWithinBounds(new Vector3Int(i - voxelOffsetToShape.x, j - voxelOffsetToShape.y, k - voxelOffsetToShape.z), out var voxel) && _voxels[i, j, k].IsOccupied && voxel.IsOccupied)
						{
							result = true;
							list.Add(_voxels[i, j, k]);
						}
					}
				}
			}
			overlappingVoxels = list.ToArray();
			CollectionPool<List<Voxel>, Voxel>.Release(list);
			return result;
		}

		public void SetVoxel(Vector3Int voxelPos, bool isOccupied, Color color)
		{
			_voxels[voxelPos.x, voxelPos.y, voxelPos.z].IsOccupied = isOccupied;
			_voxels[voxelPos.x, voxelPos.y, voxelPos.z].Color = color;
		}

		public void Regenerate(bool recalculateBounds = true)
		{
			if (recalculateBounds)
			{
				CalculateBounds();
			}
		}

		public void Expand(int expandAmount)
		{
			_bounds = new Vector3Int(_bounds.x + expandAmount * 2, _bounds.y + expandAmount * 2, _bounds.z + expandAmount * 2);
			Voxel[,,] array = new Voxel[_bounds.x, _bounds.y, _bounds.z];
			for (int i = 0; i < _voxels.GetLength(0); i++)
			{
				for (int j = 0; j < _voxels.GetLength(1); j++)
				{
					for (int k = 0; k < _voxels.GetLength(2); k++)
					{
						array[i + 1, j + 1, k + 1] = _voxels[i, j, k];
						array[i + 1, j + 1, k + 1].Position = new Vector3Int(i + 1, j + 1, k + 1);
					}
				}
			}
			array[0, 0, 0] = new Voxel
			{
				Position = new Vector3Int(0, 0, 0),
				IsOccupied = true,
				Color = Color.white
			};
			array[_bounds.x - 1, _bounds.y - 1, _bounds.z - 1] = new Voxel
			{
				Position = new Vector3Int(_bounds.x - 1, _bounds.y - 1, _bounds.z - 1),
				IsOccupied = true,
				Color = Color.white
			};
			SetVoxels(array);
			CalculateBounds();
			SetVoxel(new Vector3Int(0, 0, 0), isOccupied: false, Color.white);
			SetVoxel(new Vector3Int(_bounds.x - 1, _bounds.y - 1, _bounds.z - 1), isOccupied: false, Color.white);
			_occupiedVoxels.RemoveAt(0);
			_occupiedVoxels.RemoveAt(_occupiedVoxels.Count - 1);
		}

		public int GetVoxelsInLineCount(Vector3Int pos, RectTransform.Axis axis)
		{
			int num = 0;
			switch (axis)
			{
			case RectTransform.Axis.Horizontal:
			{
				for (int j = 0; j < _voxels.GetLength(0); j++)
				{
					if (_voxels[j, pos.y, 0].IsOccupied)
					{
						num++;
					}
				}
				return num;
			}
			case RectTransform.Axis.Vertical:
			{
				for (int i = 0; i < _voxels.GetLength(1); i++)
				{
					if (_voxels[pos.x, i, 0].IsOccupied)
					{
						num++;
					}
				}
				return num;
			}
			default:
				return 0;
			}
		}

		public bool IsShapeEmpty()
		{
			return _occupiedVoxels.Count <= 0;
		}

		public Vector3Int GetLowestValidVoxelPos(Vector3Int pos)
		{
			Voxel[,,] voxels = Voxels;
			Vector3Int bounds = GetBounds();
			Vector3Int result = new Vector3Int(Math.Clamp(pos.x, 0, bounds.x), Math.Clamp(pos.y, 0, bounds.y), Math.Clamp(pos.z, 0, bounds.z));
			int y = bounds.y;
			int y2 = result.y;
			for (int num = result.y; num >= 0; num--)
			{
				if (num < y && voxels[result.x, num, result.z].IsOccupied)
				{
					y2 = num;
				}
			}
			result.y = y2;
			return result;
		}

		private void CalculateBounds(bool calculateHash = true)
		{
			if (calculateHash)
			{
				_voxelHash = default(Hash128);
				_colorHash = default(Hash128);
				_hashDirty = true;
			}
			int num = 0;
			Vector3Int vector3Int = new Vector3Int(18, 18, 18);
			Vector3Int vector3Int2 = new Vector3Int(-1, -1, -1);
			for (int i = 0; i < _voxels.GetLength(0); i++)
			{
				for (int j = 0; j < _voxels.GetLength(1); j++)
				{
					for (int k = 0; k < _voxels.GetLength(2); k++)
					{
						if (_voxels[i, j, k].IsOccupied || !TrimBounds)
						{
							num++;
							vector3Int.x = Mathf.Min(vector3Int.x, i);
							vector3Int.y = Mathf.Min(vector3Int.y, j);
							vector3Int.z = Mathf.Min(vector3Int.z, k);
							vector3Int2.x = Mathf.Max(vector3Int2.x, i);
							vector3Int2.y = Mathf.Max(vector3Int2.y, j);
							vector3Int2.z = Mathf.Max(vector3Int2.z, k);
						}
					}
				}
			}
			_occupiedVoxels.Clear();
			_occupiedVoxels.Capacity = num;
			_bounds = new Vector3Int(vector3Int2.x - vector3Int.x + 1, vector3Int2.y - vector3Int.y + 1, vector3Int2.z - vector3Int.z + 1);
			_bounds = Vector3Int.Max(_bounds, Vector3Int.zero);
			Voxel[,,] array = new Voxel[_bounds.x, _bounds.y, _bounds.z];
			if (calculateHash)
			{
				_voxelHash.Append(_bounds.GetHashCode());
			}
			for (int l = 0; l < _bounds.x; l++)
			{
				for (int m = 0; m < _bounds.y; m++)
				{
					for (int n = 0; n < _bounds.z; n++)
					{
						Vector3Int vector3Int3 = new Vector3Int(vector3Int.x + l, vector3Int.y + m, vector3Int.z + n);
						array[l, m, n] = _voxels[vector3Int3.x, vector3Int3.y, vector3Int3.z];
						array[l, m, n].Position = new Vector3Int(l, m, n);
						if (array[l, m, n].IsOccupied)
						{
							_occupiedVoxels.Add(array[l, m, n]);
						}
						if (calculateHash)
						{
							_voxelHash.Append(array[l, m, n].IsOccupied ? 1 : 0);
							_colorHash.Append(array[l, m, n].IsOccupied ? array[l, m, n].Color.GetHashCode() : 0);
						}
					}
				}
			}
			_voxels = array;
		}

		public bool IsLastVoxelInLine(Voxel voxel, Direction dir)
		{
			Vector3Int vector3Int = Vector3Int.one;
			switch (dir)
			{
			case Direction.Left:
				vector3Int = new Vector3Int(-1, 0, 0);
				break;
			case Direction.Up:
				vector3Int = new Vector3Int(0, 1, 0);
				break;
			case Direction.Down:
				vector3Int = new Vector3Int(0, -1, 0);
				break;
			case Direction.Right:
				vector3Int = new Vector3Int(1, 0, 0);
				break;
			case Direction.Forward:
				vector3Int = new Vector3Int(0, 0, 1);
				break;
			case Direction.Backward:
				vector3Int = new Vector3Int(0, 0, -1);
				break;
			}
			Voxel voxel2;
			for (Vector3Int voxelPos = voxel.Position + vector3Int; IsVoxelPosWithinBounds(voxelPos, out voxel2); voxelPos += vector3Int)
			{
				if (voxel2.IsOccupied)
				{
					return false;
				}
			}
			return true;
		}

		public override string ToString()
		{
			string text = $"Shape {_voxels.GetLength(0)},{_voxels.GetLength(1)},{_voxels.GetLength(2)} pos {_position} \n";
			for (int i = 0; i < _voxels.GetLength(1); i++)
			{
				for (int num = _voxels.GetLength(2) - 1; num >= 0; num--)
				{
					string text2 = string.Empty;
					for (int j = 0; j < _voxels.GetLength(0); j++)
					{
						text2 += (_voxels[j, i, num].IsOccupied ? "⬜" : "⬛");
					}
					text = text + text2 + "\n";
				}
				text += "----\n";
			}
			return text;
		}

		public int to1D(int x, int y, int z, Vector3Int bounds)
		{
			return z * bounds.x * bounds.y + y * bounds.x + x;
		}

		public static Vector3Int to3D(int idx, Vector3Int bounds)
		{
			int num = idx / (bounds.x * bounds.y);
			idx -= num * bounds.x * bounds.y;
			int y = idx / bounds.x;
			return new Vector3Int(idx % bounds.x, y, num);
		}

		public ShapeData SaveShapeData()
		{
			ShapeData shapeData = new ShapeData
			{
				Bounds = _bounds,
				VoxelHash = _voxelHash,
				ColorHash = _colorHash,
				OccupiedVoxels = new List<Voxel>(_occupiedVoxels),
				Voxels = new Voxel[_bounds.x * _bounds.y * _bounds.z]
			};
			for (int i = 0; i < _bounds.x; i++)
			{
				for (int j = 0; j < _bounds.y; j++)
				{
					for (int k = 0; k < _bounds.z; k++)
					{
						int num = to1D(i, j, k, _bounds);
						shapeData.Voxels[num] = _voxels[i, j, k];
					}
				}
			}
			shapeData.RotationIndependantHash = default(RotationIndependentHash);
			List<ShapeHashPair> list = CollectionPool<List<ShapeHashPair>, ShapeHashPair>.Get();
			int num2 = 0;
			for (int l = 0; l < 4; l++)
			{
				for (int m = 0; m < 4; m++)
				{
					Rotate((num2 % 2 != 0) ? RotateDirection.RollRight : RotateDirection.Right);
					list.Add(new ShapeHashPair
					{
						VoxelHash = _voxelHash,
						ColorHash = _colorHash
					});
				}
				Rotate(RotateDirection.Forward);
				num2++;
			}
			Rotate(RotateDirection.RollLeft);
			for (int n = 0; n < 4; n++)
			{
				Rotate(RotateDirection.Forward);
				list.Add(new ShapeHashPair
				{
					VoxelHash = _voxelHash,
					ColorHash = _colorHash
				});
			}
			Rotate(RotateDirection.RollRight);
			Rotate(RotateDirection.RollRight);
			for (int num3 = 0; num3 < 4; num3++)
			{
				Rotate(RotateDirection.Forward);
				list.Add(new ShapeHashPair
				{
					VoxelHash = _voxelHash,
					ColorHash = _colorHash
				});
			}
			Rotate(RotateDirection.RollLeft);
			list.Sort();
			shapeData.RotationIndependantHash.Rotations = list.Distinct().ToArray();
			CollectionPool<List<ShapeHashPair>, ShapeHashPair>.Release(list);
			return shapeData;
		}

		public bool RotateToDesiredShapeRotation(ShapeData desiredRotationShapeData)
		{
			if (_voxelHash == desiredRotationShapeData.VoxelHash)
			{
				return true;
			}
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					Rotate((num % 2 != 0) ? RotateDirection.RollRight : RotateDirection.Right);
					if (_voxelHash == desiredRotationShapeData.VoxelHash)
					{
						return true;
					}
				}
				Rotate(RotateDirection.Forward);
				num++;
			}
			Rotate(RotateDirection.RollLeft);
			for (int k = 0; k < 4; k++)
			{
				Rotate(RotateDirection.Forward);
				if (_voxelHash == desiredRotationShapeData.VoxelHash)
				{
					return true;
				}
			}
			Rotate(RotateDirection.RollRight);
			Rotate(RotateDirection.RollRight);
			for (int l = 0; l < 4; l++)
			{
				Rotate(RotateDirection.Forward);
				if (_voxelHash == desiredRotationShapeData.VoxelHash)
				{
					return true;
				}
			}
			return false;
		}

		public void LoadShapeData(ShapeData data)
		{
			_shapeData = data;
			_bounds = data.Bounds;
			_voxelHash = data.VoxelHash;
			_colorHash = data.ColorHash;
			_hashDirty = true;
			_occupiedVoxels = new List<Voxel>(data.OccupiedVoxels);
			_voxels = new Voxel[_bounds.x, _bounds.y, _bounds.z];
			for (int i = 0; i < data.Voxels.Length; i++)
			{
				Vector3Int vector3Int = to3D(i, _bounds);
				_voxels[vector3Int.x, vector3Int.y, vector3Int.z] = data.Voxels[i];
			}
		}
	}
}
