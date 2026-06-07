using Data.FactoryFloor;
using Logic.Factory;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class IslandEditorToolLayerButtons : MonoBehaviour
	{
		[SerializeField]
		private Button _factoryLayerButton;

		[SerializeField]
		private GameObject _factoryLayerClicked;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		[Space]
		[SerializeField]
		private Button _terrianLayerButton;

		[SerializeField]
		private GameObject _terrianLayerClicked;

		[SerializeField]
		private FactoryLayer _terrianLayer;

		[Space]
		[SerializeField]
		private CurrentFactoryLayer _currentFactoryLayer;

		[SerializeField]
		private CurrentGameMode _currentGameMode;

		[SerializeField]
		private CampaignModeSO _campaignModeSO;

		[SerializeField]
		private EditorModeSO _editorModeSO;

		private void Start()
		{
			_currentFactoryLayer.CurrentEditingFactoryLayerChanged += OnIslandEditorLayerChanged;
			_factoryLayerButton.onClick.AddListener(SwitchToFactory);
			_terrianLayerButton.onClick.AddListener(SwitchToTerrian);
			OnIslandEditorLayerChanged(_currentFactoryLayer.Value);
		}

		private void OnDestroy()
		{
			_currentFactoryLayer.CurrentEditingFactoryLayerChanged -= OnIslandEditorLayerChanged;
			_factoryLayerButton.onClick.RemoveListener(SwitchToFactory);
			_terrianLayerButton.onClick.RemoveListener(SwitchToTerrian);
		}

		private void OnIslandEditorLayerChanged(FactoryLayer layer)
		{
			if (layer == _terrianLayer)
			{
				_factoryLayerClicked.SetActive(value: false);
				_terrianLayerClicked.SetActive(value: true);
			}
			else if (layer == _factoryLayer)
			{
				_factoryLayerClicked.SetActive(value: true);
				_terrianLayerClicked.SetActive(value: false);
			}
		}

		private void SwitchToTerrian()
		{
			_toolSystemLocator.ToolSystem.SelectDefaultTool();
			_currentGameMode.SwitchTo(_editorModeSO);
		}

		private void SwitchToFactory()
		{
			_toolSystemLocator.ToolSystem.SelectDefaultTool();
			_currentGameMode.SwitchTo(_campaignModeSO);
		}
	}
}
