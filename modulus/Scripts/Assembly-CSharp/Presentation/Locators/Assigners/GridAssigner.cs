using UnityEngine;

namespace Presentation.Locators.Assigners
{
	public class GridAssigner : MonoBehaviour
	{
		[SerializeField]
		private Grid _grid;

		[SerializeField]
		private GridLocator _gridLocator;

		private void Awake()
		{
			_gridLocator.SetGrid(_grid);
		}
	}
}
