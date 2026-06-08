using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class CORSRule
	{
		private string id;

		private List<string> allowedMethods = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private List<string> allowedOrigins = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private List<string> exposeHeaders = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private List<string> allowedHeaders = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private int? maxAgeSeconds;

		public List<string> AllowedMethods
		{
			get
			{
				return allowedMethods;
			}
			set
			{
				allowedMethods = value;
			}
		}

		public List<string> AllowedOrigins
		{
			get
			{
				return allowedOrigins;
			}
			set
			{
				allowedOrigins = value;
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

		public List<string> ExposeHeaders
		{
			get
			{
				return exposeHeaders;
			}
			set
			{
				exposeHeaders = value;
			}
		}

		public int? MaxAgeSeconds
		{
			get
			{
				return maxAgeSeconds;
			}
			set
			{
				maxAgeSeconds = value;
			}
		}

		public List<string> AllowedHeaders
		{
			get
			{
				return allowedHeaders;
			}
			set
			{
				allowedHeaders = value;
			}
		}

		internal bool IsSetAllowedMethods()
		{
			if (allowedMethods != null)
			{
				if (allowedMethods.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetAllowedOrigins()
		{
			if (allowedOrigins != null)
			{
				if (allowedOrigins.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetId()
		{
			return id != null;
		}

		internal bool IsSetExposeHeaders()
		{
			if (exposeHeaders != null)
			{
				if (exposeHeaders.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetMaxAgeSeconds()
		{
			return maxAgeSeconds.HasValue;
		}

		internal bool IsSetAllowedHeaders()
		{
			if (allowedHeaders != null)
			{
				if (allowedHeaders.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}
	}
}
