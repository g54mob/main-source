using Restory.Data.InteractiveObjects;
using Restory.UI.Presenters;
using Restory.UI.Presenters.PC.Apps;
using UnityEngine;

namespace Restory.Data.PC
{
	[CreateAssetMenu(menuName = "Restory/PC/PcApps", fileName = "Name - PcApp")]
	public class PcAppInfo : InteractiveObjectInfo
	{
		[SerializeField]
		private PcAppCategoryInfo category;

		[SerializeField]
		private int version = 1;

		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private string shopDescriptionLocalizationKey;

		[SerializeField]
		private Sprite desktopIcon;

		[SerializeField]
		private string installDescriptionLocalizationKey;

		[SerializeField]
		private GUI_PcAppBase pcAppPrefab;

		[SerializeField]
		private GUI_PcAppToolbarButton toolbarButtonPrefab;

		[SerializeField]
		private PcAppGuiLifecycleMode guiLifecycleMode;

		public PcAppCategoryInfo Category => category;

		public int Version => version;

		public string NameLocalizationKey => nameLocalizationKey;

		public string ShopDescriptionLocalizationKey => shopDescriptionLocalizationKey;

		public string InstallDescriptionLocalizationKey => installDescriptionLocalizationKey;

		public GUI_PcAppBase PcAppPrefab => pcAppPrefab;

		public GUI_PcAppToolbarButton ToolbarButtonPrefab => toolbarButtonPrefab;

		public Sprite DesktopIcon => desktopIcon;

		public PcAppGuiLifecycleMode GuiLifecycleMode => guiLifecycleMode;
	}
}
