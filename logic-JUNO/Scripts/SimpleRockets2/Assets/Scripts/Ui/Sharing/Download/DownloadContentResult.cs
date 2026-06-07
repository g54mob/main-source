using Assets.Scripts.Sharing;

namespace Assets.Scripts.Ui.Sharing.Download
{
	public class DownloadContentResult
	{
		public string Message { get; }

		public DownloadContentResultType Result { get; }

		public WebsiteRequest WebRequest { get; }

		public DownloadContentResult(DownloadContentResultType result, string message)
		{
			Result = result;
			Message = message;
		}

		public DownloadContentResult(WebsiteRequest request)
		{
			WebRequest = request;
			if (!request.Success)
			{
				if (request.Response == null)
				{
					Result = DownloadContentResultType.CommunicationFailure;
					Message = "Failed to download. Please verify your Internet connection and try again.";
				}
				else
				{
					Result = DownloadContentResultType.ServerFailure;
					Message = request.Response.Error;
				}
			}
			else
			{
				Result = DownloadContentResultType.Success;
				Message = string.Empty;
			}
		}
	}
}
