using UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Apps
{
	public class SecurityApp : MultiToolApp
	{
		[SerializeField]
		private UIToggle allowCamera;

		[SerializeField]
		private UIToggle allowWifi;

		[SerializeField]
		private UIImage cameraBorder;

		[SerializeField]
		private UIImage wifiBorder;

		public override void Init()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		public void OnToggleChange(GadgetPermissions.Category module, Toggle toggle)
		{
		}

		public void SetFirstTimeOpenNoPermission()
		{
		}

		public void OpenFirstTimeSecurityModal()
		{
		}

		public void SetCurrentGadgetPermission()
		{
		}

		public void SetCameraEnabled(bool permissions)
		{
		}

		public void SetCameraDisabled()
		{
		}

		public void SetWifiEnabled(bool permissions)
		{
		}

		public void SetWifiDisabled()
		{
		}

		public override void OnSolderModule(Module module)
		{
		}

		public override void OnUnsolderModule(Module module)
		{
		}
	}
}
