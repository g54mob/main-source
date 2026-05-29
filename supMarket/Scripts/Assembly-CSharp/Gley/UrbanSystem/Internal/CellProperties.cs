using System;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class CellProperties
	{
		[SerializeField]
		private Vector3 _center;

		[SerializeField]
		private int _row;

		[SerializeField]
		private int _column;

		public Vector3 Center => default(Vector3);

		public int Row => 0;

		public int Column => 0;

		public CellProperties(int column, int row, Vector3 center)
		{
		}
	}
}
