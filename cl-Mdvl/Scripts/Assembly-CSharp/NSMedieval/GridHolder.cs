using UnityEngine;

namespace NSMedieval
{
	[CreateAssetMenu(fileName = "New Test Grid", menuName = "Test/Grid")]
	public class GridHolder : ScriptableObject
	{
		public Wrapper<Elements>[] grid;

		public const int Size = 5;

		private void Awake()
		{
			if (grid == null)
			{
				ResetGrid();
			}
		}

		public void ResetGrid()
		{
			grid = new Wrapper<Elements>[5];
			for (int i = 0; i < 5; i++)
			{
				grid[i] = new Wrapper<Elements>();
				grid[i].values = new Elements[5];
			}
		}
	}
}
