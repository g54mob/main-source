using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.BugReport;

namespace Assets.Scripts.Ui.Sharing.Upload.BugReport
{
	public class UploadBugReportViewModel : UploadContentSimpleViewModel
	{
		public bool IncludeSandbox { get; set; } = true;

		public UploadBugReportViewModel()
		{
			base.Title = "Submit Bug Report";
			base.NameLabel = "Bug Title";
			base.DescriptionLabel = "Description / steps to reproduce...";
			base.MinDescriptionLength = 50;
			base.VerifyPlanetarySystemExistsOnServer = true;
		}

		public override WebsiteRequest CreateWebRequest(UploadContentModel model)
		{
			BugReportUpload handler = new BugReportUpload(model, IncludeSandbox);
			return new WebsiteRequest(Game.SimpleRocketsWebsiteUrl, handler);
		}
	}
}
