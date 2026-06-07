using DV.Common;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class MainMenuBugReportDataProvider : BugReportDataProvider
	{
		private ISaveGame LastPlayedSave => SingletonBehaviour<UserManager>.Instance.CurrentUser?.CurrentSession?.LatestSave;

		public override bool CheckScreenshot()
		{
			return LastPlayedSave?.Thumbnail;
		}

		public override Texture GetScreenshotForPreview()
		{
			return LastPlayedSave?.Thumbnail;
		}

		public override (Texture texture, bool isTemporary) GetScreenshotForPacking()
		{
			return (texture: LastPlayedSave?.Thumbnail, isTemporary: false);
		}

		public override bool ShouldFlipScreenshotPreview()
		{
			return true;
		}

		public override bool ShouldFlipScreenshotWhenSaving()
		{
			return false;
		}
	}
}
