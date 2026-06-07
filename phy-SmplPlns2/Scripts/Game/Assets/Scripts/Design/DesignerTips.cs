using Assets.Scripts.Design.UI;

namespace Assets.Scripts.Design
{
	public static class DesignerTips
	{
		private static string[] _desktopTips = new string[6] { "You can clone parts by clicking and dragging them with the right mouse button.", "You can hold down control while rotating or panning the view to prevent accidentally dragging a part.", "Several parts have properties that can be set by clicking the button with the wrench icon.", "Left click on a part in the part list to show detailed information about it.", "You can clone parts by clicking and dragging them with the right mouse button.", "You can press CTRL+Z to undo and CTRL+Y to redo." };

		private static string[] _mobileTips = new string[1] { string.Empty };

		public static void ShowDesignerTip(DesignerUIScript designerUI)
		{
			int num = Game.Instance.Settings.App.UserPrefs.GetInt("NumDesignerTipsShown");
			Game.Instance.Settings.App.UserPrefs.SetInt("NumDesignerTipsShown", num + 1);
			Game.Instance.Settings.App.Save();
			if (num < 21)
			{
				string empty = string.Empty;
				empty = ((!Game.Instance.Device.IsDesktopBuild) ? GetTipMessage(_mobileTips, num) : GetTipMessage(_desktopTips, num));
				if (!string.IsNullOrEmpty(empty))
				{
					designerUI.ShowMessage("Tip: " + empty);
				}
			}
		}

		private static string GetTipMessage(string[] tips, int tipIndex)
		{
			int num = tipIndex % tips.Length;
			return tips[num];
		}
	}
}
