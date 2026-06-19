using JSAM;
using Loxodon.Framework.Binding;
using UnityEngine;
using Zenject;

namespace UI.Map
{
	public class MapWaveIndicatorSpawner : MonoBehaviour
	{
		[SerializeField]
		private MapIndicatorView _waveIndicator;

		[SerializeField]
		private MapView _map;

		[SerializeField]
		private Sprite _waveSprite;

		[Inject]
		private DiContainer _diContainer;

		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				SpawnWave();
			}
		}

		private void SpawnWave()
		{
			AudioManager.PlaySound(UILibrarySounds.UIMapWave);
			MapIndicatorView mapIndicatorView = _diContainer.InstantiatePrefabForComponent<MapIndicatorView>(_waveIndicator);
			MapIndicatorViewModel dataContext = new MapIndicatorViewModel(_waveSprite);
			mapIndicatorView.SetDataContext(dataContext);
			mapIndicatorView.CreateBinding();
			_map.SetMapPointAtMousePosition(mapIndicatorView);
		}
	}
}
