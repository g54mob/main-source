namespace ModApi.Craft.Parts.Modifiers
{
	public interface IPayload
	{
		int ContractNumber { get; set; }

		string PayloadId { get; set; }

		string PayloadTrackingId { get; set; }

		string CraftTrackingId { get; }
	}
}
