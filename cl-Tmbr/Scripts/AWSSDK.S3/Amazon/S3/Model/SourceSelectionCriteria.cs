namespace Amazon.S3.Model
{
	public class SourceSelectionCriteria
	{
		private SseKmsEncryptedObjects sseKmsEncryptedObjects;

		private ReplicaModifications replicaModifications;

		public SseKmsEncryptedObjects SseKmsEncryptedObjects
		{
			get
			{
				return sseKmsEncryptedObjects;
			}
			set
			{
				sseKmsEncryptedObjects = value;
			}
		}

		public ReplicaModifications ReplicaModifications
		{
			get
			{
				return replicaModifications;
			}
			set
			{
				replicaModifications = value;
			}
		}

		internal bool IsSetSseKmsEncryptedObjects()
		{
			return sseKmsEncryptedObjects != null;
		}

		internal bool IsSetReplicaModifications()
		{
			return replicaModifications != null;
		}
	}
}
