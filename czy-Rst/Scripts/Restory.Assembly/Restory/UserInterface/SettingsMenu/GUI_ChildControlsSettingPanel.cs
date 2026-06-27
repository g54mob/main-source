using UnityEngine.Events;

namespace Restory.UserInterface.SettingsMenu
{
	public abstract class GUI_ChildControlsSettingPanel : GUI_BaseSettingPanel
	{
		public UnityEvent<GUI_BaseSettingPanel> OnBack = new UnityEvent<GUI_BaseSettingPanel>();

		public void Back()
		{
			OnBack.Invoke(this);
		}
	}
}
