using ManagementScripts;

namespace UIScripts
{
	public class EscapePanel : UIPanel
	{
		public override void OpenPanel()
		{
			if (!base.isActiveAndEnabled)
			{
				base.OpenPanel();
				SetRestrictions(val: true);
			}
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			SetRestrictions(val: false);
		}

		public void SetRestrictions(bool val)
		{
			TimeController.Instance?.TogglePauseGame("EscapePanel", !val);
			UserControl.AllowControl = !val;
			UserControl.SetKeyboardBlockFromSource("EscapePanel", val);
		}
	}
}
