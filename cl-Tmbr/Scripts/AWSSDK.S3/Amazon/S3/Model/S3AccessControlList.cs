using System.Collections.Generic;
using System.Xml;

namespace Amazon.S3.Model
{
	public class S3AccessControlList
	{
		private List<S3Grant> grantList = (AWSConfigs.InitializeCollections ? new List<S3Grant>() : null);

		public Owner Owner { get; set; }

		public List<S3Grant> Grants
		{
			get
			{
				return grantList;
			}
			set
			{
				grantList = value;
			}
		}

		public void AddGrant(S3Grantee grantee, S3Permission permission)
		{
			S3Grant item = new S3Grant
			{
				Grantee = grantee,
				Permission = permission
			};
			if (Grants == null)
			{
				Grants = new List<S3Grant>();
			}
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

		internal bool IsSetOwner()
		{
			return Owner != null;
		}

		internal bool IsSetGrants()
		{
			if (grantList != null)
			{
				if (grantList.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal void Marshall(string memberName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(memberName);
			if (grantList != null)
			{
				foreach (S3Grant grant in grantList)
				{
					grant?.Marshall("Grant", xmlWriter);
				}
			}
			xmlWriter.WriteEndElement();
		}
	}
}
