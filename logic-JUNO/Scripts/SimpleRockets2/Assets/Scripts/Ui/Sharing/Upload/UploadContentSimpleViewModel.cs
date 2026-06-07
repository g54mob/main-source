using System.Collections;
using Assets.Scripts.Sharing;

namespace Assets.Scripts.Ui.Sharing.Upload
{
	public abstract class UploadContentSimpleViewModel : UploadContentViewModel
	{
		public abstract WebsiteRequest CreateWebRequest(UploadContentModel model);

		public override IEnumerator Upload(UploadContentModel model, UploadProgressedDelegate onUploadProgressed, UploadCompletedDelegate onUploadCompleted)
		{
			WebsiteRequest request = CreateWebRequest(model);
			yield return SendWebRequest(request, delegate(WebsiteRequest x)
			{
				onUploadProgressed(x.Progress);
			}, delegate(WebsiteRequest x)
			{
				onUploadCompleted(new UploadContentResult(x));
			}, delegate
			{
				onUploadCompleted(new UploadContentResult(UploadContentResultType.Canceled, null));
			});
		}
	}
}
