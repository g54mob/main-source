namespace NSMedieval.Serialization
{
	public class FVSerializationReference
	{
		public readonly string BufferId;

		public readonly long BufferPosition;

		public readonly int RefId;

		public bool IsReferenced;

		public FVSerializationReference(int refId, string id, long position)
		{
			RefId = refId;
			BufferId = id;
			BufferPosition = position;
			IsReferenced = false;
		}
	}
}
