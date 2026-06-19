namespace TH20
{
	public class GenericResponseBase
	{
		public int RequestID { get; set; }

		public GenericResponseBase(int requestID)
		{
			RequestID = requestID;
		}
	}
}
