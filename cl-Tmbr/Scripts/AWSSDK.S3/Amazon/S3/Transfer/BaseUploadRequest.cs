namespace Amazon.S3.Transfer
{
	public abstract class BaseUploadRequest
	{
		private RequestPayer requestPayer;

		public RequestPayer RequestPayer
		{
			get
			{
				return requestPayer;
			}
			set
			{
				requestPayer = value;
			}
		}
	}
}
