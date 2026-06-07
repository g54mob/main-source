using Logic.Factory.Islands;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Islands
{
	public class IslandBuilderUI : MonoBehaviour
	{
		[SerializeField]
		private IslandCreator _islandCreator;

		[SerializeField]
		private Button _createSmallIsland;

		[SerializeField]
		private Button _createMediumIsland;

		[SerializeField]
		private Button _createBigIsland;

		[SerializeField]
		private Vector2Int _smallIslandSize = new Vector2Int(28, 28);

		[SerializeField]
		private Vector2Int _mediumIslandSize = new Vector2Int(50, 50);

		[SerializeField]
		private Vector2Int _bigIslandSize = new Vector2Int(72, 72);

		private void Awake()
		{
			_createSmallIsland.onClick.AddListener(CreateSmallIsland);
			_createMediumIsland.onClick.AddListener(CreateMediumIsland);
			_createBigIsland.onClick.AddListener(CreateBigIsland);
		}

		private void OnDestroy()
		{
			_createSmallIsland.onClick.RemoveListener(CreateSmallIsland);
			_createMediumIsland.onClick.RemoveListener(CreateMediumIsland);
			_createBigIsland.onClick.RemoveListener(CreateBigIsland);
		}

		private void CreateSmallIsland()
		{
			_islandCreator.CreateNewIsland(_smallIslandSize);
		}

		private void CreateMediumIsland()
		{
			_islandCreator.CreateNewIsland(_mediumIslandSize);
		}

		private void CreateBigIsland()
		{
			_islandCreator.CreateNewIsland(_bigIslandSize);
		}
	}
}
