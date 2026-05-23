using Data.Variables;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Overlays;
using UnityEngine;

namespace Presentation.UI.ModuleViewer
{
	public class ModuleViewerMaxUIMenu : UIModalDialog
	{
		[SerializeField]
		private GameObject _canvas;

		[SerializeField]
		private GameObject _shapeViewer;

		[SerializeField]
		private ModuleViewer _moduleViewer;

		[SerializeField]
		private BoolVariableRefSO _moduleViewerMaxIsActive;

		private void Awake()
		{
			_shapeViewer.SetActive(value: false);
		}

		public override void ShowModal(AbstractUIModalDialogData menuData)
		{
			_moduleViewerMaxIsActive.SetValue(value: true);
			ModuleViewerMaxUIMenuData moduleViewerMaxUIMenuData = menuData as ModuleViewerMaxUIMenuData;
			_canvas.SetActive(value: true);
			_shapeViewer.SetActive(value: true);
			_moduleViewer.Show(moduleViewerMaxUIMenuData.DataAndIndex, isMaxViewer: true);
		}

		public override void HideModal()
		{
			_moduleViewer.Hide();
			_shapeViewer.SetActive(value: false);
			_canvas.SetActive(value: false);
			_moduleViewerMaxIsActive.SetValue(value: false);
		}

		public void UpdateModule((ModuleViewerData, int) dataAndIndex)
		{
			_moduleViewer.Show(dataAndIndex, isMaxViewer: true);
		}

		public override bool TryCanCancel()
		{
			return true;
		}
	}
}
