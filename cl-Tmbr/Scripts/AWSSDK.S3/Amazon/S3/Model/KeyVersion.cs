using System;

namespace Amazon.S3.Model
{
	public class KeyVersion
	{
		private string key;

		private string versionId;

		private string eTag;

		private DateTime? lastModifiedTime;

		private long? size;

		public string Key
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}

		public string VersionId
		{
			get
			{
				return versionId;
			}
			set
			{
				versionId = value;
			}
		}

		public string ETag
		{
			get
			{
				return eTag;
			}
			set
			{
				eTag = value;
			}
		}

		public long? Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
			}
		}

		public DateTime? LastModifiedTime
		{
			get
			{
				return lastModifiedTime;
			}
			set
			{
				lastModifiedTime = value;
			}
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetVersionId()
		{
			return versionId != null;
		}

		internal bool IsSetETag()
		{
			return !string.IsNullOrEmpty(eTag);
		}

		internal bool IsSetSize()
		{
			return size.HasValue;
		}

		internal bool IsSetLastModifiedTime()
		{
			return lastModifiedTime.HasValue;
		}
	}
}
