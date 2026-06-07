using System.Collections.Generic;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.SaveUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.Menus
{
	public class SaveMenu : GamecontrolMenu
	{
		[SerializeField]
		private SavePanelUI _savePanelUIPrefab;

		[SerializeField]
		private Transform _savePanelsParent;

		[SerializeField]
		private Toggle _devMapsToggle;

		[SerializeField]
		private SaveFileUtils _saveFileUtilsSO;

		[SerializeField]
		private string _factoryScene;

		[SerializeField]
		private ScrollRect _scrollRect;

		private bool _isDevEnvironment;

		private readonly List<SavePanelUI> _savePanels = new List<SavePanelUI>();

		private string _savePath
		{
			get
			{
				if (!_isDevEnvironment || !_devMapsToggle.isOn)
				{
					return SaveSystem.GetFullSavePathForFileName("Levels");
				}
				return SaveSystem.GetFullStreamingAssetPathForFileName("Levels");
			}
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.ShowMenu(menuData);
			_isDevEnvironment = false;
			_devMapsToggle.gameObject.SetActive(value: false);
			_devMapsToggle.isOn = false;
			if (Application.isEditor || Debug.isDebugBuild)
			{
				_isDevEnvironment = true;
				_devMapsToggle.gameObject.SetActive(value: true);
			}
			_devMapsToggle.onValueChanged.AddListener(OnToggle);
			DestroyOldLoadPanels();
			SpawnLoadPanels();
			_scrollRect.verticalNormalizedPosition = 1f;
		}

		public override void HideMenu()
		{
			base.HideMenu();
			_devMapsToggle.onValueChanged.RemoveListener(OnToggle);
		}

		private void OnToggle(bool devMaps)
		{
			DestroyOldLoadPanels();
			SpawnLoadPanels();
		}

		private void DestroyOldLoadPanels()
		{
			for (int num = _savePanelsParent.transform.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(_savePanelsParent.transform.GetChild(num).gameObject);
			}
			_savePanels.Clear();
		}

		private void SpawnLoadPanels()
		{
			foreach (SaveFile item in _saveFileUtilsSO.GetSaveFilesInDirectory(_savePath))
			{
				SavePanelUI savePanelUI = Object.Instantiate(_savePanelUIPrefab, _savePanelsParent);
				_savePanels.Add(savePanelUI);
				if (item.Info != null)
				{
					savePanelUI.SetExistingSavePanel(item.Name, item.Path, item.Info, this);
				}
				else
				{
					savePanelUI.SetExistingSavePanel(item.Name, item.Path, this);
				}
			}
			SavePanelUI savePanelUI2 = Object.Instantiate(_savePanelUIPrefab, _savePanelsParent);
			_savePanels.Add(savePanelUI2);
			savePanelUI2.SetNewSavePanel(_devMapsToggle.isOn && _isDevEnvironment);
		}

		public void RefreshPanels()
		{
			DestroyOldLoadPanels();
			SpawnLoadPanels();
		}

		public bool IsFactoryScene()
		{
			if (SceneManager.GetActiveScene().name == _factoryScene)
			{
				return true;
			}
			return false;
		}
	}
}
