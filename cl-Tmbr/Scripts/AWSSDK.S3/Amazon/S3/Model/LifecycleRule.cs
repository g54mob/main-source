using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class LifecycleRule
	{
		private LifecycleRuleAbortIncompleteMultipartUpload abortIncompleteMultipartUpload;

		private LifecycleRuleExpiration expiration;

		private string id;

		private LifecycleRuleNoncurrentVersionExpiration noncurrentVersionExpiration;

		private List<LifecycleRuleNoncurrentVersionTransition> noncurrentVersionTransitions = (AWSConfigs.InitializeCollections ? new List<LifecycleRuleNoncurrentVersionTransition>() : null);

		private LifecycleRuleStatus status = LifecycleRuleStatus.Disabled;

		private List<LifecycleTransition> transitions = (AWSConfigs.InitializeCollections ? new List<LifecycleTransition>() : null);

		private LifecycleFilter filter;

		public LifecycleRuleAbortIncompleteMultipartUpload AbortIncompleteMultipartUpload
		{
			get
			{
				return abortIncompleteMultipartUpload;
			}
			set
			{
				abortIncompleteMultipartUpload = value;
			}
		}

		public LifecycleRuleExpiration Expiration
		{
			get
			{
				return expiration;
			}
			set
			{
				expiration = value;
			}
		}

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

		public LifecycleRuleNoncurrentVersionExpiration NoncurrentVersionExpiration
		{
			get
			{
				return noncurrentVersionExpiration;
			}
			set
			{
				noncurrentVersionExpiration = value;
			}
		}

		public LifecycleFilter Filter
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

		public LifecycleRuleStatus Status
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

		public List<LifecycleRuleNoncurrentVersionTransition> NoncurrentVersionTransitions
		{
			get
			{
				return noncurrentVersionTransitions;
			}
			set
			{
				noncurrentVersionTransitions = value;
			}
		}

		public List<LifecycleTransition> Transitions
		{
			get
			{
				return transitions;
			}
			set
			{
				transitions = value;
			}
		}

		internal bool IsSetAbortIncompleteMultipartUpload()
		{
			return abortIncompleteMultipartUpload != null;
		}

		internal bool IsSetExpiration()
		{
			return expiration != null;
		}

		internal bool IsSetId()
		{
			return id != null;
		}

		internal bool IsSetNoncurrentVersionExpiration()
		{
			return noncurrentVersionExpiration != null;
		}

		internal bool IsSetFilter()
		{
			return filter != null;
		}

		internal bool IsSetStatus()
		{
			return status != null;
		}

		internal bool IsSetNoncurrentVersionTransitions()
		{
			if (noncurrentVersionTransitions != null)
			{
				if (noncurrentVersionTransitions.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetTransitions()
		{
			if (transitions != null)
			{
				if (transitions.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}
	}
}
