using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Date;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class CertStatus
	{
		public const int Unrevoked = 11;

		public const int Undetermined = 12;

		private int status;

		private DateTimeObject revocationDate;

		public DateTimeObject RevocationDate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Status
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
	}
}
