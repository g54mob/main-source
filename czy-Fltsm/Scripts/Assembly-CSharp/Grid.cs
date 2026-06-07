using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[Serializable]
public class Grid : GraphBase
{
	public delegate GridNode InstantiateGridNode(Grid grid, Vector2 rootPosition);

	[Header("Grid")]
	[Header("Debug")]
	[Tooltip("Debug this graph?")]
	[SerializeField]
	private bool _isDebug;

	[SerializeField]
	[Tooltip("Debug radius used for scenes that do not have a GameManager")]
	private int _debugRadius;

	[SerializeField]
	[Tooltip("Should the gizmos for blocked nodes be drawn?")]
	private bool _displayBlockedNodes;

	[SerializeField]
	[Tooltip("Should the gizmos for the clearance values of the nodes be drawn?")]
	private bool _displayClearance;

	private static byte[] _upperClearances = new byte[9];

	private static byte[] _lowerClearances = new byte[9];

	private static int _instanceCount = 0;

	private GridNode[,] _grid;

	private int _size;

	private int _maxIndex;

	private Vector3 _offset;

	private int _instanceId;

	public bool WasDisposed { get; private set; }

	public Grid()
	{
		_instanceId = _instanceCount++;
	}

	public override void Initialize()
	{
		Vector2 vector = (_isDebug ? Vector2.zero : GameManager.WorldManager.WorldCenter.Vector2TopDown());
		float num = (_isDebug ? ((float)_debugRadius) : GameManager.WorldManager.InteractableRadius);
		_size = Mathf.CeilToInt(num + num);
		_size = _size / 4 * 4 + 20;
		_ = _size;
		_maxIndex = _size - 1;
		_offset = new Vector3(vector.x, 0f, vector.y);
		_offset.x += _size / 2;
		_offset.z = 0f - _offset.z + (float)(_size / 2);
		Vector2 vector2 = -_offset.Vector2TopDown();
		_grid = new GridNode[_size, _size];
		for (int i = 0; i < _size; i++)
		{
			for (int j = 0; j < _size; j++)
			{
				_grid[j, i] = GridNode.Get(this, new Vector2(vector2.x + (float)j, vector2.y + (float)i));
			}
		}
		base.MaximumSize = Mathf.CeilToInt(Mathf.Pow(4f, MaximumDepth));
		base.TerrainType = Navigator.ReturnTerrainTypeFromGraphType(GraphType);
	}

	public void Dispose()
	{
		Debug.Log("Disposing Grid with instance ID: " + _instanceId);
		_grid = null;
		WasDisposed = true;
	}

	public void UpdateBlockedNodes(Polygon polygon, Rect bounds, List<GridNode> blockedNodes)
	{
		bounds.center += _offset.Vector2TopDown();
		int num = ReturnSafeIndex(Mathf.FloorToInt(bounds.xMin));
		int num2 = ReturnSafeIndex(Mathf.FloorToInt(bounds.yMin));
		int num3 = ReturnSafeIndex(Mathf.CeilToInt(bounds.xMax));
		int num4 = ReturnSafeIndex(Mathf.CeilToInt(bounds.yMax));
		blockedNodes.Clear();
		for (int i = num2; i < num4; i++)
		{
			for (int j = num; j < num3; j++)
			{
				GridNode gridNode = _grid[j, i];
				if (gridNode.ReturnIsPolygonOverlapping(polygon))
				{
					gridNode.IncreaseObstacleCount();
					blockedNodes.Add(gridNode);
				}
			}
		}
	}

	public void ResetClearance(GridNode clearanceCenter, int distance)
	{
		if (_grid == null)
		{
			return;
		}
		int num = Mathf.RoundToInt(clearanceCenter.Center.x + _offset.x);
		int num2 = Mathf.RoundToInt(clearanceCenter.Center.y + _offset.z);
		int num3 = ReturnSafeIndex(num - distance);
		int num4 = ReturnSafeIndex(num2 - distance);
		int num5 = ReturnSafeIndex(num + distance + 1);
		int num6 = ReturnSafeIndex(num2 + distance + 1);
		for (int i = num4; i < num6; i++)
		{
			for (int j = num3; j < num5; j++)
			{
				_grid[j, i].ResetClearance();
			}
		}
	}

	public void SetClearance(GridNode clearanceCenter, int distance)
	{
		if (clearanceCenter != null)
		{
			int centerIndexX = Mathf.RoundToInt(clearanceCenter.Center.x + _offset.x);
			int centerIndexY = Mathf.RoundToInt(clearanceCenter.Center.y + _offset.z);
			for (int i = 1; i <= distance; i++)
			{
				SetClearanceAtDistance(centerIndexX, centerIndexY, i);
			}
			int num = distance;
			while (-1 < num)
			{
				SetClearanceAtDistance(centerIndexX, centerIndexY, num);
				num--;
			}
		}
	}

	private void SetClearanceAtDistance(int centerIndexX, int centerIndexY, int distance)
	{
		int num = ReturnSafeIndex(centerIndexX - distance);
		int num2 = ReturnSafeIndex(centerIndexY - distance);
		int num3 = ReturnSafeIndex(centerIndexX + distance + 1);
		int num4 = ReturnSafeIndex(centerIndexY + distance + 1);
		int num5 = num3 - 1;
		int num6 = num4 - 1;
		int num7 = 0;
		for (int i = num; i < num3; i++)
		{
			SetClearance(_grid[i, num2], i, num2, num7, _lowerClearances, leftToRight: true);
			SetClearance(_grid[i, num6], i, num6, num7, _upperClearances, leftToRight: true);
			num7++;
		}
		num7 = 0;
		for (int j = num2; j < num4; j++)
		{
			SetClearance(_grid[num, j], num, j, num7, _lowerClearances, leftToRight: false);
			SetClearance(_grid[num5, j], num5, j, num7, _upperClearances, leftToRight: false);
			num7++;
		}
	}

	private void SetClearance(GridNode node, int nodeX, int nodeY, int index, byte[] clearances, bool leftToRight)
	{
		int num = ((!leftToRight) ? PopulateClearancesBottomToTop(node, nodeX, nodeY, index, clearances) : PopulateClearancesLeftToRight(node, nodeX, nodeY, index, clearances));
		byte b;
		if (node.IsBlocked)
		{
			b = 0;
		}
		else
		{
			b = byte.MaxValue;
			for (int i = 0; i < 9; i++)
			{
				byte b2 = clearances[i];
				if (b2 < b)
				{
					b = b2;
				}
			}
			if (b < byte.MaxValue)
			{
				b++;
			}
		}
		node.SetClearance(b);
		clearances[num] = b;
	}

	private int PopulateClearancesLeftToRight(GridNode node, int nodeX, int nodeY, int index, byte[] clearances)
	{
		int num = nodeX + 1;
		int num2 = nodeY + 1;
		int num3 = nodeY - 1;
		bool flag = num2 < _size;
		bool flag2 = -1 < num3;
		int num5;
		if (index == 0)
		{
			int num4 = nodeX - 1;
			if (-1 < num4)
			{
				clearances[0] = (flag2 ? _grid[num4, num3].Clearance : byte.MaxValue);
				clearances[1] = _grid[num4, nodeY].Clearance;
				clearances[2] = (flag ? _grid[num4, num2].Clearance : byte.MaxValue);
			}
			else
			{
				byte b;
				clearances[2] = (b = byte.MaxValue);
				clearances[0] = (clearances[1] = b);
			}
			clearances[3] = (flag2 ? _grid[nodeX, num3].Clearance : byte.MaxValue);
			clearances[4] = (byte)((!node.IsBlocked) ? byte.MaxValue : 0);
			clearances[5] = (flag ? _grid[nodeX, num2].Clearance : byte.MaxValue);
			num5 = 6;
		}
		else
		{
			num5 = (index - 1) % 3 * 3;
		}
		if (num < _size)
		{
			clearances[num5] = (flag2 ? _grid[num, num3].Clearance : byte.MaxValue);
			clearances[num5 + 1] = _grid[num, nodeY].Clearance;
			clearances[num5 + 2] = (flag ? _grid[num, num2].Clearance : byte.MaxValue);
		}
		else
		{
			int num6 = num5;
			int num7 = num5 + 1;
			byte b;
			clearances[num5 + 2] = (b = byte.MaxValue);
			clearances[num6] = (clearances[num7] = b);
		}
		if (num5 == 0)
		{
			return 7;
		}
		return num5 - 2;
	}

	private int PopulateClearancesBottomToTop(GridNode node, int nodeX, int nodeY, int index, byte[] clearances)
	{
		int num = nodeX + 1;
		int num2 = nodeX - 1;
		int num3 = nodeY + 1;
		bool flag = -1 < num2;
		bool flag2 = num < _size;
		int num5;
		if (index == 0)
		{
			int num4 = nodeY - 1;
			if (-1 < num4)
			{
				clearances[0] = (flag ? _grid[num2, num4].Clearance : byte.MaxValue);
				clearances[1] = _grid[nodeX, num4].Clearance;
				clearances[2] = (flag2 ? _grid[num, num4].Clearance : byte.MaxValue);
			}
			else
			{
				byte b;
				clearances[2] = (b = byte.MaxValue);
				clearances[0] = (clearances[1] = b);
			}
			clearances[3] = (flag ? _grid[num2, nodeY].Clearance : byte.MaxValue);
			clearances[4] = (byte)((!node.IsBlocked) ? byte.MaxValue : 0);
			clearances[5] = (flag2 ? _grid[num, nodeY].Clearance : byte.MaxValue);
			num5 = 6;
		}
		else
		{
			num5 = (index - 1) % 3 * 3;
		}
		if (num < _size)
		{
			clearances[num5] = (flag ? _grid[num2, num3].Clearance : byte.MaxValue);
			clearances[num5 + 1] = _grid[nodeX, num3].Clearance;
			clearances[num5 + 2] = (flag2 ? _grid[num, num3].Clearance : byte.MaxValue);
		}
		else
		{
			int num6 = num5;
			int num7 = num5 + 1;
			byte b;
			clearances[num5 + 2] = (b = byte.MaxValue);
			clearances[num6] = (clearances[num7] = b);
		}
		if (num5 == 0)
		{
			return 7;
		}
		return num5 - 2;
	}

	public void PopulateNeighbors(PathfindingNode node, List<PathfindingNode> neighbors)
	{
		Vector2 rootPosition2D = node.RootPosition2D;
		int num = Mathf.RoundToInt(rootPosition2D.x + _offset.x);
		int num2 = Mathf.RoundToInt(rootPosition2D.y + _offset.z);
		int num3 = num - 1;
		int num4 = num + 1;
		int num5 = num2 - 1;
		int num6 = num2 + 1;
		bool num7 = 0 < num;
		bool flag = num < _maxIndex;
		bool flag2 = 0 < num2;
		bool flag3 = num2 < _maxIndex;
		if (num7)
		{
			if (flag2)
			{
				neighbors.Add(_grid[num3, num5]);
			}
			neighbors.Add(_grid[num3, num2]);
			if (flag3)
			{
				neighbors.Add(_grid[num3, num6]);
			}
		}
		if (flag2)
		{
			neighbors.Add(_grid[num, num5]);
		}
		if (node.Graph != this)
		{
			neighbors.Add(_grid[num, num2]);
		}
		if (flag3)
		{
			neighbors.Add(_grid[num, num6]);
		}
		if (flag)
		{
			if (flag2)
			{
				neighbors.Add(_grid[num4, num5]);
			}
			neighbors.Add(_grid[num4, num2]);
			if (flag3)
			{
				neighbors.Add(_grid[num4, num6]);
			}
		}
	}

	public void PopulateNeighborhood(float x, float y, int range, List<GridNode> neighborhood)
	{
		int num = Mathf.RoundToInt(x + _offset.x);
		int num2 = Mathf.RoundToInt(y + _offset.z);
		int num3 = num - range;
		int num4 = num2 - range;
		int num5 = num + range + 1;
		int num6 = num2 + range + 1;
		int num7 = 3 + (range - 1) * 2;
		int num8 = num7 * num7;
		if (neighborhood.Capacity < num8)
		{
			neighborhood.Capacity = num8;
		}
		for (int i = num4; i < num6; i++)
		{
			for (int j = num3; j < num5; j++)
			{
				if (ReturnNode(j, i) != null)
				{
					neighborhood.Add(ReturnNode(j, i));
				}
			}
		}
	}

	public override PathfindingNode ReturnNode(Target target, Navigator navigator = null, int deepestLevel = 0, bool onlyUnblocked = true, bool hasLineOfSight = true)
	{
		if (TypesMatch(target.TargetGraphType))
		{
			Vector3 position = target.transform.position;
			return ReturnNode(position.x, position.z, onlyUnblocked);
		}
		return null;
	}

	public override PathfindingNode ReturnNode(Vector3 position)
	{
		return ReturnNode(position.x, position.z);
	}

	public GridNode ReturnNode(Vector2 point)
	{
		return ReturnNode(point.x, point.y);
	}

	private GridNode ReturnNode(float posX, float posY, bool onlyUnblocked = false)
	{
		int num = Mathf.RoundToInt(posX + _offset.x);
		int num2 = Mathf.RoundToInt(posY + _offset.z);
		if (-1 >= num || num >= _size || -1 >= num2 || num2 >= _size)
		{
			return null;
		}
		GridNode gridNode = _grid[num, num2];
		if (onlyUnblocked && gridNode != null && gridNode.IsBlocked)
		{
			return ReturnClosestUnblockedNode(num, num2);
		}
		return gridNode;
	}

	private GridNode ReturnClosestUnblockedNode(int indexX, int indexY)
	{
		int num = ((0 <= indexX) ? indexX : 0);
		int num2 = ((0 <= indexY) ? (indexY - 1) : 0);
		int num3 = ((indexX + 1 >= _size) ? (_size - 1) : (indexX + 1));
		int num4 = ((indexY + 1 >= _size) ? (_size - 1) : (indexY + 1));
		int num5 = 0;
		while (num > -1 && num3 < _size && num2 > -1 && num4 < _size)
		{
			for (num5 = num2 + 1; num5 <= num4 && num5 < _size; num5++)
			{
				if (num < 0)
				{
					break;
				}
				if (!_grid[num, num5].IsBlocked)
				{
					return _grid[num, num5];
				}
			}
			num--;
			for (num5 = num + 2; num5 <= num3 && num5 < _size; num5++)
			{
				if (num4 >= _size)
				{
					break;
				}
				if (!_grid[num5, num4].IsBlocked)
				{
					return _grid[num5, num4];
				}
			}
			num4++;
			num5 = num4 - 2;
			while (num5 >= num2 && num5 >= 0 && num3 < _size)
			{
				if (!_grid[num3, num5].IsBlocked)
				{
					return _grid[num3, num5];
				}
				num5--;
			}
			num3++;
			num5 = num3 - 2;
			while (num5 > num && num5 >= 0 && num2 >= 0)
			{
				if (!_grid[num5, num2].IsBlocked)
				{
					return _grid[num5, num2];
				}
				num5--;
			}
			num2--;
		}
		return null;
	}

	private GridNode ReturnNode(int indexX, int indexY)
	{
		if (-1 < indexX && indexX < _size && -1 < indexY && indexY < _size)
		{
			return _grid[indexX, indexY];
		}
		return null;
	}

	public PathfindingNode[] ReturnNeighborhood(float x, float y, int range)
	{
		int num = Mathf.RoundToInt(x + _offset.x);
		int num2 = Mathf.RoundToInt(y + _offset.z);
		int num3 = num - range;
		int num4 = num2 - range;
		int num5 = num + range + 1;
		int num6 = num2 + range + 1;
		int num7 = 0;
		int num8 = 3 + (range - 1) * 2;
		if (ReturnNode(num, num2) == null)
		{
			return null;
		}
		PathfindingNode[] array = new PathfindingNode[num8 * num8];
		for (int i = num4; i < num6; i++)
		{
			for (int j = num3; j < num5; j++)
			{
				array[num7++] = ReturnNode(j, i);
			}
		}
		return array;
	}

	private int ReturnSafeIndex(int index)
	{
		return Mathf.Min(_maxIndex, Mathf.Max(0, index));
	}

	public override void Draw()
	{
		for (int i = 0; i < _size; i++)
		{
			for (int j = 0; j < _size; j++)
			{
				GridNode gridNode = _grid[j, i];
				if (_displayBlockedNodes && gridNode.IsBlocked)
				{
					Gizmos.color = Color.red;
					gridNode.DrawGizmo();
				}
				if (_displayClearance && gridNode.Clearance < byte.MaxValue)
				{
					Gizmos.color = new Color(0f, (float)(int)gridNode.Clearance * 0.125f, 0.25f);
					gridNode.DrawGizmo();
				}
				if (!_displayBlockedNodes && !_displayClearance)
				{
					Gizmos.color = Color.magenta;
					gridNode.DrawGizmo();
				}
			}
		}
	}
}
