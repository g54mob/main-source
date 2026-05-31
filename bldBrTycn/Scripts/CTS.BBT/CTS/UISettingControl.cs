using System;

namespace CTS
{
	public class UISettingControl : UISetting
	{
		public static event Action Reset;

		public override void ResetSetting()
		{
			UISettingControl.Reset?.Invoke();
		}

		protected override string GetName()
		{
			return "";
		}
	}
}
