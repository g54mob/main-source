using System.Text;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using MyBox;
using UI.Map.MapIndicators;
using UnityEngine;
using WorldEnvironment.Islands;
using Zenject;

namespace UI.Map
{
	public class MapSegmentView : UIView
	{
		[SerializeField]
		private RectGrid _rectGrid;

		[SerializeField]
		private MapIndicatorView _indicatorPrefab;

		[ReadOnly(new string[] { })]
		[SerializeField]
		private int _currentX;

		[ReadOnly(new string[] { })]
		[SerializeField]
		private int _currentY;

		[SerializeField]
		[TextArea(20, 40)]
		private string _output;

		[SerializeField]
		private Sprite _mainIslandSprite;

		[SerializeField]
		private Sprite _defaultIslandSprite;

		[Inject]
		private WorldGridManager _worldGridManager;

		[Inject]
		private DiContainer _diContainer;

		public void CreateBinidng(WorldGridManager worldGridManager = null)
		{
			if (worldGridManager != null)
			{
				Debug.LogError("World Grid Manager is not binded! Bind it Before injecting... Setting default or existing one... Not For Publishing");
				_worldGridManager = worldGridManager;
			}
			BindingSet<MapSegmentView, MapSegmentViewModel> bindingSet = this.CreateBindingSet<MapSegmentView, MapSegmentViewModel>();
			bindingSet.Bind(this).For((MapSegmentView v) => v._currentX).To((MapSegmentViewModel vm) => vm.X)
				.OneWay();
			bindingSet.Bind(this).For((MapSegmentView v) => v._currentY).To((MapSegmentViewModel vm) => vm.Y)
				.OneWay();
			bindingSet.Build();
			RectTransform rectTransform = base.transform as RectTransform;
			rectTransform.anchoredPosition = new Vector2(rectTransform.rect.width * (float)_currentX, rectTransform.rect.height * (float)_currentY);
			UpdateMapState();
		}

		private void UpdateMapState()
		{
			foreach (Transform item in _rectGrid.transform)
			{
				Object.Destroy(item.gameObject);
			}
			IslandWorldGrid gridAt = _worldGridManager.GetGridAt(_currentX, _currentY);
			_output = $"Grid ({_currentX}, {_currentY}):\n" + ToGridString(gridAt.IslandGrid);
			int length = gridAt.IslandGrid.GetLength(0);
			int length2 = gridAt.IslandGrid.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					int cellValue = gridAt.IslandGrid[i, j];
					int y = length - 1 - i;
					Vector2 rectPosAt = _rectGrid.GetRectPosAt(j, y);
					SpawnIsland(rectPosAt, cellValue);
				}
			}
		}

		private void SpawnMainIsland(Vector2 localPos, Sprite sprite)
		{
			MapIndicatorView mapIndicatorView = Object.Instantiate(_indicatorPrefab, _rectGrid.transform);
			(mapIndicatorView.transform as RectTransform).localPosition = new Vector3(localPos.x, localPos.y, 0f);
			MainIslandMapIndicatorViewModel dataContext = _diContainer.Instantiate<MainIslandMapIndicatorViewModel>(new object[1] { sprite });
			mapIndicatorView.SetDataContext(dataContext);
			mapIndicatorView.CreateBinding();
		}

		private void SpawnIslandWithSprite(Vector2 localPos, Sprite sprite)
		{
			MapIndicatorView mapIndicatorView = Object.Instantiate(_indicatorPrefab, _rectGrid.transform);
			(mapIndicatorView.transform as RectTransform).localPosition = new Vector3(localPos.x, localPos.y, 0f);
			MapIndicatorViewModel dataContext = new MapIndicatorViewModel(sprite);
			mapIndicatorView.SetDataContext(dataContext);
			mapIndicatorView.CreateBinding();
		}

		private void SpawnIsland(Vector2 localPos, int cellValue)
		{
			switch (cellValue)
			{
			case 1:
				SpawnMainIsland(localPos, _mainIslandSprite);
				break;
			case 2:
			case 3:
				SpawnIslandWithSprite(localPos, _defaultIslandSprite);
				break;
			}
		}

		private string ToGridString(int[,] grid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					stringBuilder.Append(grid[i, j] + " ");
				}
				stringBuilder.AppendLine();
			}
			return stringBuilder.ToString();
		}
	}
}
