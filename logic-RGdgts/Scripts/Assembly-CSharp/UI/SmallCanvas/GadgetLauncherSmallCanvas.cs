using RetroLauncher;
using UI.Elements;
using UnityEngine;

namespace UI.SmallCanvas
{
	public class GadgetLauncherSmallCanvas : MonoBehaviour
	{
		protected UIMultitoolManager uiManager;

		protected MultiTool multitool;

		public UIToggle onLauncherToggle;

		public UIToggle autostartToggle;

		public UIToggle alwaysOnTopToggle;

		public UIButton confirmButton;

		public UIButton closeButton;

		private SerializedGadgetMetaData currentMetadata;

		private GadgetConfiguration launcherConfiguration;

		private GadgetSmallCanvas gadgetSmallCanvas;

		public void Init()
		{
		}

		public void SetFromMetadata(SerializedGadgetMetaData metadata)
		{
		}

		public void SetGadgetSmallReference(GadgetSmallCanvas smallCanvas)
		{
		}

		public void Close()
		{
		}

		public void Clear()
		{
		}

		public void OpenConfirmModal()
		{
		}

		public void OnConfirm(bool confirm)
		{
		}

		private void OnAlwaysOnTopChange(bool onTop)
		{
		}

		private void OnAutostartChange(bool autostart)
		{
		}

		public void OnOnLauncherChange(bool active)
		{
		}
	}
}
