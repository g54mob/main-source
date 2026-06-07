using System.IO;
using Data.Variables;
using Logic.Factory.Islands;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class SaveIslandButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private IslandSaver _islandSaver;

		[SerializeField]
		private StreamingAssetsPathVariableSO _currentIslandWorkingPath;

		private void Start()
		{
			_button.interactable = false;
			_text.SetText(string.Empty);
			_button.onClick.AddListener(SaveIsland);
			_currentIslandWorkingPath.ValueChanged += OnCurrentIslandChanged;
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(SaveIsland);
			_currentIslandWorkingPath.ValueChanged -= OnCurrentIslandChanged;
		}

		private void OnCurrentIslandChanged(string path)
		{
			_button.interactable = path != _currentIslandWorkingPath.DefaultValue;
			_text.SetText(Path.GetFileNameWithoutExtension(path));
		}

		private void SaveIsland()
		{
			_islandSaver.SaveCurrentIsland();
		}
	}
}
