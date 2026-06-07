using Data.FactoryFloor.Islands;
using Logic.Factory.Islands;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class SaveIslandAsButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private IslandSaver _islandSaver;

		[SerializeField]
		private CurrentEditingIsland _currentEditingIsland;

		private void Start()
		{
			OnCurrentEditingIslandChanged();
			_button.onClick.AddListener(SaveIsland);
			_currentEditingIsland.ValueChanged += OnCurrentEditingIslandChanged;
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(SaveIsland);
			_currentEditingIsland.ValueChanged -= OnCurrentEditingIslandChanged;
		}

		private void SaveIsland()
		{
			_islandSaver.SaveCurrentIslandAsNew();
		}

		private void OnCurrentEditingIslandChanged()
		{
			_button.interactable = !_currentEditingIsland.Empty;
		}
	}
}
