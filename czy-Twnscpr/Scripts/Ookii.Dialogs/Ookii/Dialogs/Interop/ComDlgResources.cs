namespace Ookii.Dialogs.Interop
{
	internal static class ComDlgResources
	{
		public enum ComDlgResourceId
		{
			OpenButton = 370,
			Open = 384,
			FileNotFound = 391,
			CreatePrompt = 402,
			ReadOnly = 427,
			ConfirmSaveAs = 435
		}

		private static Win32Resources _resources;

		public static string LoadString(ComDlgResourceId id)
		{
			return null;
		}

		public static string FormatString(ComDlgResourceId id, params string[] args)
		{
			return null;
		}
	}
}
