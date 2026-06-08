using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class S3BucketLoggingConfig
	{
		private List<S3Grant> targetGrants = (AWSConfigs.InitializeCollections ? new List<S3Grant>() : null);

		private TargetObjectKeyFormat _targetObjectKeyFormat;

		public string TargetBucketName { get; set; }

		public List<S3Grant> Grants
		{
			get
			{
				return targetGrants;
			}
			set
			{
				targetGrants = value;
			}
		}

		public TargetObjectKeyFormat TargetObjectKeyFormat
		{
			get
			{
				return _targetObjectKeyFormat;
			}
			set
			{
				_targetObjectKeyFormat = value;
			}
		}

		public string TargetPrefix { get; set; }

		internal bool IsSetTargetBucket()
		{
			return TargetBucketName != null;
		}

		internal bool IsSetGrants()
		{
			if (targetGrants != null)
			{
				if (targetGrants.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetTargetObjectKeyFormat()
		{
			return _targetObjectKeyFormat != null;
		}

		internal bool IsSetTargetPrefix()
		{
			return TargetPrefix != null;
		}

		public void AddGrant(S3Grantee grantee, S3Permission permission)
		{
			if (Grants == null)
			{
				Grants = new List<S3Grant>();
			}
			S3Grant item = new S3Grant
			{
				Grantee = grantee,
				Permission = permission
			};
			Grants.Add(item);
		}

		public void RemoveGrant(S3Grantee grantee, S3Permission permission)
		{
			if (Grants == null)
			{
				return;
			}
			foreach (S3Grant grant in Grants)
			{
				if (grant.Grantee.Equals(grantee) && grant.Permission == permission)
				{
					Grants.Remove(grant);
					break;
				}
			}
		}

		public void RemoveGrant(S3Grantee grantee)
		{
			if (Grants == null)
			{
				return;
			}
			List<S3Grant> list = new List<S3Grant>();
			foreach (S3Grant grant in Grants)
			{
				if (grant.Grantee.Equals(grantee))
				{
					list.Add(grant);
				}
			}
			foreach (S3Grant item in list)
			{
				Grants.Remove(item);
			}
		}
	}
}
