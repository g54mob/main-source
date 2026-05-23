using System.Collections.Generic;
using UnityEngine;

namespace Data.FactoryFloor.Islands
{
	[CreateAssetMenu(menuName = "Factory/Islands/BrushPositions", fileName = "BrushPositions", order = 0)]
	public class BrushPositions : ScriptableObject
	{
		private Dictionary<Vector3Int, int> _brushPositions = new Dictionary<Vector3Int, int>();

		public void SetBrushAtPosition(Vector3Int position, int brushId)
		{
			_brushPositions[position] = brushId;
		}

		public bool IsBrushAtPosition(Vector3Int position, int brushId)
		{
			if (!_brushPositions.TryGetValue(position, out var value))
			{
				return false;
			}
			return value == brushId;
		}

		public bool IsAnyBrushAtPosition(Vector3Int position)
		{
			return _brushPositions.ContainsKey(position);
		}

		public void RemoveBrushAtPosition(Vector3Int position)
		{
			if (_brushPositions.ContainsKey(position))
			{
				_brushPositions.Remove(position);
			}
		}

		public void Clear()
		{
			_brushPositions.Clear();
		}

		public Dictionary<Vector3Int, int> GetBrushPositions()
		{
			return new Dictionary<Vector3Int, int>(_brushPositions);
		}

		public void SetBrushesAtPosition(Dictionary<Vector3Int, int> dataBrushPositions)
		{
			_brushPositions = new Dictionary<Vector3Int, int>(dataBrushPositions);
		}
	}
}
