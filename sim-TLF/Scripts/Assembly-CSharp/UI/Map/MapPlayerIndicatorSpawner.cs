using Loxodon.Framework.Binding;
using Player.FSM;
using UnityEngine;
using Zenject;

namespace UI.Map
{
	public class MapPlayerIndicatorSpawner : MonoBehaviour
	{
		[SerializeField]
		private MapIndicatorView _playerIndicator;

		[SerializeField]
		private MapView _map;

		[SerializeField]
		private Sprite _playerIndicatorSprite;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private IPlayerStateMachineParametersManipulator _playerFSM;

		private void Start()
		{
			SpawnPlayerIndicator();
		}

		private void SpawnPlayerIndicator()
		{
			MapIndicatorView mapIndicatorView = _diContainer.InstantiatePrefabForComponent<MapIndicatorView>(_playerIndicator);
			MapIndicatorViewModel dataContext = new MapIndicatorViewModel(_playerIndicatorSprite);
			mapIndicatorView.SetDataContext(dataContext);
			mapIndicatorView.CreateBinding();
			_map.SetMapPoint((_playerFSM as MonoBehaviour).transform.position, mapIndicatorView);
		}
	}
}
