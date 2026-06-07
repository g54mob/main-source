namespace BestHTTP.Core
{
	public enum RequestEvents
	{
		Upgraded = 0,
		DownloadProgress = 1,
		UploadProgress = 2,
		StreamingData = 3,
		StateChange = 4,
		Resend = 5,
		Headers = 6
	}
}
