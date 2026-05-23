using Logic.Factory.Islands;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class LoadIslandButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private IslandLoader _islandLoader;

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
			_islandLoader.LoadIsland();
		}
	}
}
