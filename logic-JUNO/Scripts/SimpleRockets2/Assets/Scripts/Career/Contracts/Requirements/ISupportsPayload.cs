namespace Assets.Scripts.Career.Contracts.Requirements
{
	public interface ISupportsPayload
	{
		int NumPayloadParts { get; }

		string PayloadId { get; }

		bool RequiresPayload { get; }

		bool IsTrackingPayload(string payloadTrackingId);
	}
}
