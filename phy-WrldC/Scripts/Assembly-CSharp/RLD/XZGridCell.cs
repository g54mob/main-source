using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class XZGridCell
	{
		private IXZGrid _parentGrid;

		private int _xIndex;

		private int _zIndex;

		private Vector3 _min;

		private Vector3 _max;

		public IXZGrid ParentGrid => _parentGrid;

		public int XIndex => _xIndex;

		public int ZIndex => _zIndex;

		public Vector3 Min => _min;

		public Vector3 Max => _max;

		public Vector3 Center => (_min + _max) * 0.5f;

		public XZGridCell(int xIndex, int zIndex, Vector3 min, Vector3 max, IXZGrid parentGrid)
		{
			_xIndex = xIndex;
			_zIndex = zIndex;
			_min = min;
			_max = max;
			_parentGrid = parentGrid;
		}

		public static XZGridCell FromPoint(Vector3 point, float cellSizeX, float cellSizeZ, IXZGrid parentGrid)
		{
			Matrix4x4 worldMatrix = parentGrid.WorldMatrix;
			Vector3 vector = worldMatrix.inverse.MultiplyPoint(point);
			int num = Mathf.FloorToInt(vector.x / cellSizeX);
			int num2 = Mathf.FloorToInt(vector.z / cellSizeZ);
			Vector3 vector2 = Vector3.right * num * cellSizeX + Vector3.forward * num2 * cellSizeZ;
			Vector3 point2 = vector2 + Vector3.right * cellSizeX + Vector3.forward * cellSizeZ;
			vector2 = worldMatrix.MultiplyPoint(vector2);
			point2 = worldMatrix.MultiplyPoint(point2);
			return new XZGridCell(num, num2, vector2, point2, parentGrid);
		}

		public List<Vector3> GetCenterAndCorners()
		{
			List<Vector3> obj = new List<Vector3> { Center };
			Vector3 vector = _max - _min;
			obj.Add(_min);
			obj.Add(_min + Vector3.forward * vector.z);
			obj.Add(_max);
			obj.Add(_min + Vector3.right * vector.x);
			return obj;
		}
	}
}
