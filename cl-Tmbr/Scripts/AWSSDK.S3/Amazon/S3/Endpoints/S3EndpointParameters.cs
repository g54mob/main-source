using Amazon.Runtime.Endpoints;

namespace Amazon.S3.Endpoints
{
	public class S3EndpointParameters : EndpointParameters
	{
		public string Bucket
		{
			get
			{
				return (string)base["Bucket"];
			}
			set
			{
				base["Bucket"] = value;
			}
		}

		public string Region
		{
			get
			{
				return (string)base["Region"];
			}
			set
			{
				base["Region"] = value;
			}
		}

		public bool? UseFIPS
		{
			get
			{
				return (bool?)base["UseFIPS"];
			}
			set
			{
				base["UseFIPS"] = value;
			}
		}

		public bool? UseDualStack
		{
			get
			{
				return (bool?)base["UseDualStack"];
			}
			set
			{
				base["UseDualStack"] = value;
			}
		}

		public string Endpoint
		{
			get
			{
				return (string)base["Endpoint"];
			}
			set
			{
				base["Endpoint"] = value;
			}
		}

		public bool? ForcePathStyle
		{
			get
			{
				return (bool?)base["ForcePathStyle"];
			}
			set
			{
				base["ForcePathStyle"] = value;
			}
		}

		public bool? Accelerate
		{
			get
			{
				return (bool?)base["Accelerate"];
			}
			set
			{
				base["Accelerate"] = value;
			}
		}

		public bool? UseGlobalEndpoint
		{
			get
			{
				return (bool?)base["UseGlobalEndpoint"];
			}
			set
			{
				base["UseGlobalEndpoint"] = value;
			}
		}

		public bool? UseObjectLambdaEndpoint
		{
			get
			{
				return (bool?)base["UseObjectLambdaEndpoint"];
			}
			set
			{
				base["UseObjectLambdaEndpoint"] = value;
			}
		}

		public string Key
		{
			get
			{
				return (string)base["Key"];
			}
			set
			{
				base["Key"] = value;
			}
		}

		public string Prefix
		{
			get
			{
				return (string)base["Prefix"];
			}
			set
			{
				base["Prefix"] = value;
			}
		}

		public string CopySource
		{
			get
			{
				return (string)base["CopySource"];
			}
			set
			{
				base["CopySource"] = value;
			}
		}

		public bool? DisableAccessPoints
		{
			get
			{
				return (bool?)base["DisableAccessPoints"];
			}
			set
			{
				base["DisableAccessPoints"] = value;
			}
		}

		public bool? DisableMultiRegionAccessPoints
		{
			get
			{
				return (bool?)base["DisableMultiRegionAccessPoints"];
			}
			set
			{
				base["DisableMultiRegionAccessPoints"] = value;
			}
		}

		public bool? UseArnRegion
		{
			get
			{
				return (bool?)base["UseArnRegion"];
			}
			set
			{
				base["UseArnRegion"] = value;
			}
		}

		public bool? UseS3ExpressControlEndpoint
		{
			get
			{
				return (bool?)base["UseS3ExpressControlEndpoint"];
			}
			set
			{
				base["UseS3ExpressControlEndpoint"] = value;
			}
		}

		public bool? DisableS3ExpressSessionAuth
		{
			get
			{
				return (bool?)base["DisableS3ExpressSessionAuth"];
			}
			set
			{
				base["DisableS3ExpressSessionAuth"] = value;
			}
		}

		public S3EndpointParameters()
		{
			UseFIPS = false;
			UseDualStack = false;
			ForcePathStyle = false;
			Accelerate = false;
			UseGlobalEndpoint = false;
			DisableMultiRegionAccessPoints = false;
		}
	}
}
