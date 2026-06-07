using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.Sandbox;

namespace Assets.Scripts.Ui.Sharing.Upload.Sandbox
{
	public class UploadSandboxViewModel : UploadContentSimpleViewModel
	{
		public UploadSandboxViewModel()
		{
			base.Title = "Upload Sandbox";
			base.NameLabel = "Sandbox Name";
			base.DescriptionLabel = "Sandbox Description";
			base.VerifyPlanetarySystemExistsOnServer = true;
		}

		public override WebsiteRequest CreateWebRequest(UploadContentModel model)
		{
			SandboxUpload handler = new SandboxUpload(model);
			return new WebsiteRequest(Game.SimpleRocketsWebsiteUrl, handler);
		}
	}
}
