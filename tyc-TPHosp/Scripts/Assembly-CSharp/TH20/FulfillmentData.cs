namespace TH20
{
	[DontSave]
	public class FulfillmentData
	{
		public readonly string EntitlementId;

		public readonly string LastInstruction;

		public readonly string FulfillmentAddress;

		public FulfillmentData(string entitlementID)
		{
			EntitlementId = entitlementID;
			LastInstruction = "FULFILL";
			FulfillmentAddress = "Player";
		}
	}
}
