using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetObjectLegalHoldResponse : AmazonWebServiceResponse
	{
		private ObjectLockLegalHold _legalHold;

		public ObjectLockLegalHold LegalHold
		{
			get
			{
				return _legalHold;
			}
			set
			{
				_legalHold = value;
			}
		}

		internal bool IsSetLegalHold()
		{
			return _legalHold != null;
		}
	}
}
