using Logic.Factory.Map;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.MapEditor
{
	public class SaveMapButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private MapSaver _islandSaver;

		private void Start()
		{
			_button.onClick.AddListener(SaveIsland);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(SaveIsland);
		}

		private void SaveIsland()
		{
			_islandSaver.SaveCurrentMap();
		}
	}
}
