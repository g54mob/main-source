using System;
using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class EventType : ConstantClass
	{
		public static readonly EventType ObjectCreatedAll = new EventType("s3:ObjectCreated:*");

		public static readonly EventType ObjectCreatedPut = new EventType("s3:ObjectCreated:Put");

		public static readonly EventType ObjectCreatedPost = new EventType("s3:ObjectCreated:Post");

		public static readonly EventType ObjectCreatedCopy = new EventType("s3:ObjectCreated:Copy");

		public static readonly EventType ObjectCreatedCompleteMultipartUpload = new EventType("s3:ObjectCreated:CompleteMultipartUpload");

		public static readonly EventType ObjectRemovedAll = new EventType("s3:ObjectRemoved:*");

		public static readonly EventType ObjectRemovedDelete = new EventType("s3:ObjectRemoved:Delete");

		public static readonly EventType ObjectRemovedDeleteMarkerCreated = new EventType("s3:ObjectRemoved:DeleteMarkerCreated");

		public static readonly EventType ReducedRedundancyLostObject = new EventType("s3:ReducedRedundancyLostObject");

		public static readonly EventType ObjectRestoreAll = new EventType("s3:ObjectRestore:*");

		public static readonly EventType ObjectRestorePost = new EventType("s3:ObjectRestore:Post");

		public static readonly EventType ObjectRestoreCompleted = new EventType("s3:ObjectRestore:Completed");

		public static readonly EventType ReplicationAll = new EventType("s3:Replication:*");

		public static readonly EventType ReplicationOperationFailedReplication = new EventType("s3:Replication:OperationFailedReplication");

		public static readonly EventType ReplicationOperationNotTracked = new EventType("s3:Replication:OperationNotTracked");

		public static readonly EventType ReplicationOperationMissedThreshold = new EventType("s3:Replication:OperationMissedThreshold");

		public static readonly EventType ReplicationOperationReplicatedAfterThreshold = new EventType("s3:Replication:OperationReplicatedAfterThreshold");

		public static readonly EventType S3IntelligentTiering = new EventType("s3:IntelligentTiering");

		public static readonly EventType S3LifecycleExpirationAll = new EventType("s3:LifecycleExpiration:*");

		public static readonly EventType S3LifecycleExpirationDelete = new EventType("s3:LifecycleExpiration:Delete");

		public static readonly EventType S3LifecycleExpirationDeleteMarkerCreated = new EventType("s3:LifecycleExpiration:DeleteMarkerCreated");

		public static readonly EventType S3LifecycleTransition = new EventType("s3:LifecycleTransition");

		public static readonly EventType S3ObjectAclPut = new EventType("s3:ObjectAcl:Put");

		public static readonly EventType S3ObjectRestoreDelete = new EventType("s3:ObjectRestore:Delete");

		public static readonly EventType S3ObjectTaggingAll = new EventType("s3:ObjectTagging:*");

		public static readonly EventType S3ObjectTaggingDelete = new EventType("s3:ObjectTagging:Delete");

		public static readonly EventType S3ObjectTaggingPut = new EventType("s3:ObjectTagging:Put");

		public EventType(string value)
			: base(value)
		{
		}

		public static EventType FindValue(string value)
		{
			return ConstantClass.FindValue<EventType>(value);
		}

		public static implicit operator EventType(string value)
		{
			return FindValue(value);
		}

		public override bool Equals(ConstantClass obj)
		{
			if (obj == null)
			{
				return false;
			}
			return Equals(obj.Value);
		}

		protected override bool Equals(string value)
		{
			if (value == null)
			{
				return false;
			}
			string text = base.Value;
			if (!text.StartsWith("s3:", StringComparison.OrdinalIgnoreCase))
			{
				text = "s3:" + text;
			}
			if (!value.StartsWith("s3:", StringComparison.OrdinalIgnoreCase))
			{
				value = "s3:" + value;
			}
			return StringComparer.OrdinalIgnoreCase.Equals(text, value);
		}
	}
}
