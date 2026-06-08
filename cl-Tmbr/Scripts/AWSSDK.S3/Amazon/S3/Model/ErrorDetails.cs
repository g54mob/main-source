namespace Amazon.S3.Model
{
	public class ErrorDetails
	{
		private string errorCode;

		private string errorMessage;

		public string ErrorCode
		{
			get
			{
				return errorCode;
			}
			set
			{
				errorCode = value;
			}
		}

		public string ErrorMessage
		{
			get
			{
				return errorMessage;
			}
			set
			{
				errorMessage = value;
			}
		}
	}
}
