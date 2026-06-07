using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_LevelUpGridLayout : MonoBehaviour
	{
		[SerializeField]
		private GridLayoutGroup m_gridLayoutGroup;

		[SerializeField]
		private Vector2 m_oneRowCellSize;

		[SerializeField]
		private Vector2 m_twoRowsCellSize;

		[SerializeField]
		private int m_oneRowCount = 5;

		public int OneRowCount => m_oneRowCount;

		public void SetGrid(int count)
		{
			bool flag = count <= OneRowCount;
			Vector2 cellSize = (flag ? m_oneRowCellSize : m_twoRowsCellSize);
			m_gridLayoutGroup.cellSize = cellSize;
			m_gridLayoutGroup.constraintCount = (flag ? 1 : 2);
		}
	}
}
