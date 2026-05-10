using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class GridData : MonoBehaviour
	{
		[SerializeField]
		private int _gridCellSize;

		[SerializeField]
		private Vector3 _gridCorner;

		[SerializeField]
		private RowData[] _grid;

		public RowData[] Grid => null;

		public Vector3 GridCorner => default(Vector3);

		public int GridCellSize => 0;

		public void SetGridData(RowData[] grid, Vector3 gridCorner, int gridCellSize)
		{
		}

		public bool IsValid(out string error)
		{
			error = null;
			return false;
		}
	}
}
