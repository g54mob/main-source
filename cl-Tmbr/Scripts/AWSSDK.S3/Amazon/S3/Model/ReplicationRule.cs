namespace Amazon.S3.Model
{
	public class ReplicationRule
	{
		private string id;

		private int? priority;

		private ReplicationRuleFilter filter;

		private ReplicationRuleStatus status;

		private ReplicationDestination destination;

		private SourceSelectionCriteria sourceSelectionCriteria;

		private ExistingObjectReplication existingObjectReplication;

		private DeleteMarkerReplication deleteMarkerReplication;

		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public int Priority
		{
			get
			{
				return priority.GetValueOrDefault();
			}
			set
			{
				priority = value;
			}
		}

		public ReplicationRuleFilter Filter
		{
			get
			{
				return filter;
			}
			set
			{
				filter = value;
			}
		}

		public ReplicationRuleStatus Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}
		}

		public ReplicationDestination Destination
		{
			get
			{
				return destination;
			}
			set
			{
				destination = value;
			}
		}

		public SourceSelectionCriteria SourceSelectionCriteria
		{
			get
			{
				return sourceSelectionCriteria;
			}
			set
			{
				sourceSelectionCriteria = value;
			}
		}

		public ExistingObjectReplication ExistingObjectReplication
		{
			get
			{
				return existingObjectReplication;
			}
			set
			{
				existingObjectReplication = value;
			}
		}

		public DeleteMarkerReplication DeleteMarkerReplication
		{
			get
			{
				return deleteMarkerReplication;
			}
			set
			{
				deleteMarkerReplication = value;
			}
		}

		internal bool IsSetId()
		{
			return !string.IsNullOrEmpty(id);
		}

		internal bool IsSetPriority()
		{
			return priority.HasValue;
		}

		internal bool IsSetFilter()
		{
			return filter != null;
		}

		internal bool IsSetStatus()
		{
			return status != null;
		}

		internal bool IsSetDestination()
		{
			return destination != null;
		}

		internal bool IsSetSourceSelectionCriteria()
		{
			return sourceSelectionCriteria != null;
		}

		internal bool IsSetExistingObjectReplication()
		{
			return existingObjectReplication != null;
		}

		internal bool IsSetDeleteMarkerReplication()
		{
			return deleteMarkerReplication != null;
		}
	}
}
