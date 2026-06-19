namespace TH20.ExtContent
{
	public class GameItemSandboxSave : GameItemBase
	{
		public const string cPreviewIconFileName = "PreviewIcon.png";

		public void SetData(string sandboxSaveDisplayName)
		{
			base.DisplayName = sandboxSaveDisplayName;
			OnDataUpdated();
		}

		public override bool ValidateReadyForPublish(bool bSilent = false)
		{
			return true;
		}
	}
}
