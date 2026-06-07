using Assets.Scripts.Sharing;

namespace Assets.Scripts.Ui.Sharing.Upload
{
	public class UploadContentResult
	{
		public string Message { get; }

		public UploadContentResultType Result { get; }

		public WebsiteRequest WebRequest { get; }

		public UploadContentResult(UploadContentResultType result, string message)
		{
			Result = result;
			Message = message;
		}

		public UploadContentResult(WebsiteRequest request)
		{
			WebRequest = request;
			if (!request.Success)
			{
				if (request.Response == null)
				{
					Result = UploadContentResultType.CommunicationFailure;
					Message = "Failed to upload. Please verify your Internet connection and try again.";
				}
				else
				{
					Result = ((request.Response.GetValue("ForceLogOff") == "true") ? UploadContentResultType.ServerFailureForceLogOff : UploadContentResultType.ServerFailure);
					Message = request.Response.Error;
				}
			}
			else
			{
				Result = UploadContentResultType.Success;
				Message = Game.SimpleRocketsWebsiteUrl + request.Response.GetValue("Url");
			}
		}
	}
}
