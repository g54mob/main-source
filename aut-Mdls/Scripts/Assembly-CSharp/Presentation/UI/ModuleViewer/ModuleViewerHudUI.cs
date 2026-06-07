using Events.UI.Overlays;
using Presentation.Locators;
using Presentation.UI.Menus.HudPanelTabGroups;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.ModuleViewer
{
	public class ModuleViewerHudUI : TabGroupPanel
	{
		[SerializeField]
		private ModuleViewer _moduleViewer;

		[SerializeField]
		private Button _openModuleViewerMaxButton;

		[SerializeField]
		private ModuleViewerMaxLocator _maxLocator;

		[SerializeField]
		private ShowModalDialogEvent _showUIModalDialogEvent;

		private (ModuleViewerData, int) _dataAndIndex;

		private void Awake()
		{
			base.gameObject.SetActive(value: false);
			_openModuleViewerMaxButton.onClick.AddListener(OpenModuleViewerMax);
		}

		private void OnDestroy()
		{
			_openModuleViewerMaxButton.onClick.RemoveListener(OpenModuleViewerMax);
		}

		public override void ShowPanel()
		{
			base.ShowPanel();
			_moduleViewer.Show(_dataAndIndex);
		}

		public override void ShowPanel(AbstractHudPanelData panelData)
		{
			if (panelData is ModuleViewerHudPanelData)
			{
				ModuleViewerHudPanelData moduleViewerHudPanelData = panelData as ModuleViewerHudPanelData;
				_dataAndIndex = (moduleViewerHudPanelData.ModuleViewerData, moduleViewerHudPanelData.Index);
				base.gameObject.SetActive(value: true);
				_moduleViewer.Show(_dataAndIndex);
			}
		}

		public override void HidePanel()
		{
			_moduleViewer.Hide();
			base.gameObject.SetActive(value: false);
		}

		private void OpenModuleViewerMax()
		{
			_showUIModalDialogEvent.Fire(new ModuleViewerMaxUIMenuData(_maxLocator.Value, _dataAndIndex));
		}
	}
}
