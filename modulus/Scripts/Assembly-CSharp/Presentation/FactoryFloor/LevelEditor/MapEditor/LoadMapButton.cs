using Logic.Factory.Map;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.MapEditor
{
	public class LoadMapButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private MapLoader _islandLoader;

		private void Start()
		{
			_button.onClick.AddListener(LoadIsland);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(LoadIsland);
		}

		private void LoadIsland()
		{
			_islandLoader.LoadMap();
		}
	}
}
