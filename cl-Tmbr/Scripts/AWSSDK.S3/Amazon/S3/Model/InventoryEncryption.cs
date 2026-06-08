namespace Amazon.S3.Model
{
	public class InventoryEncryption
	{
		private SSES3 sSES3;

		private SSEKMS sSEKms;

		public SSES3 SSES3
		{
			get
			{
				return sSES3;
			}
			set
			{
				sSES3 = value;
			}
		}

		public SSEKMS SSEKMS
		{
			get
			{
				return sSEKms;
			}
			set
			{
				sSEKms = value;
			}
		}

		internal bool IsSetSSES3()
		{
			return sSES3 != null;
		}

		internal bool IsSetSSEKMS()
		{
			return sSEKms != null;
		}
	}
}
