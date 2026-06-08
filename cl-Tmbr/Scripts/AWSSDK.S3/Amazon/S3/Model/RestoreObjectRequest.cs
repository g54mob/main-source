using System.Xml;
using Amazon.Runtime;
using Amazon.S3.Model.Internal.MarshallTransformations;

namespace Amazon.S3.Model
{
	public class RestoreObjectRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private int? days;

		private string expectedBucketOwner;

		private string description;

		private string key;

		private GlacierJobTier tier;

		private GlacierJobTier retrievalTier;

		private RestoreRequestType type;

		private SelectParameters selectParameters;

		private OutputLocation outputLocation;

		private RequestPayer requestPayer;

		private string versionId;

		public string BucketName
		{
			get
			{
				return bucketName;
			}
			set
			{
				bucketName = value;
			}
		}

		public ChecksumAlgorithm ChecksumAlgorithm
		{
			get
			{
				return _checksumAlgorithm;
			}
			set
			{
				_checksumAlgorithm = value;
			}
		}

		public int? Days
		{
			get
			{
				return days;
			}
			set
			{
				days = value;
			}
		}

		public string ExpectedBucketOwner
		{
			get
			{
				return expectedBucketOwner;
			}
			set
			{
				expectedBucketOwner = value;
			}
		}

		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
			}
		}

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

		public GlacierJobTier Tier
		{
			get
			{
				return tier;
			}
			set
			{
				tier = value;
			}
		}

		public GlacierJobTier RetrievalTier
		{
			get
			{
				return retrievalTier;
			}
			set
			{
				retrievalTier = value;
			}
		}

		public RestoreRequestType RestoreRequestType
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}

		public SelectParameters SelectParameters
		{
			get
			{
				return selectParameters;
			}
			set
			{
				selectParameters = value;
			}
		}

		public OutputLocation OutputLocation
		{
			get
			{
				return outputLocation;
			}
			set
			{
				outputLocation = value;
			}
		}

		public RequestPayer RequestPayer
		{
			get
			{
				return requestPayer;
			}
			set
			{
				requestPayer = value;
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

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetDays()
		{
			return days.HasValue;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetDescription()
		{
			return description != null;
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetTier()
		{
			return tier != null;
		}

		internal bool IsSetRetrievalTier()
		{
			return retrievalTier != null;
		}

		internal bool IsSetType()
		{
			return type != null;
		}

		internal bool IsSetSelectParameters()
		{
			return selectParameters != null;
		}

		internal bool IsSetOutputLocation()
		{
			return outputLocation != null;
		}

		internal void Marshall(string propertyName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(propertyName, "http://s3.amazonaws.com/doc/2006-03-01/");
			if (IsSetRetrievalTier())
			{
				xmlWriter.WriteElementString("Tier", S3Transforms.ToXmlStringValue(RetrievalTier));
			}
			if (IsSetTier())
			{
				xmlWriter.WriteStartElement("GlacierJobParameters");
				xmlWriter.WriteElementString("Tier", S3Transforms.ToXmlStringValue(Tier));
				xmlWriter.WriteEndElement();
			}
			if (IsSetDays())
			{
				xmlWriter.WriteElementString("Days", S3Transforms.ToXmlStringValue(Days.Value));
			}
			if (IsSetType())
			{
				xmlWriter.WriteElementString("Type", S3Transforms.ToXmlStringValue(RestoreRequestType.Value));
			}
			if (IsSetDescription())
			{
				xmlWriter.WriteElementString("Description", S3Transforms.ToXmlStringValue(Description));
			}
			if (IsSetSelectParameters())
			{
				SelectParameters.Marshall("SelectParameters", xmlWriter);
			}
			if (IsSetOutputLocation())
			{
				OutputLocation.Marshall("OutputLocation", xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}

		internal bool IsSetRequestPayer()
		{
			return requestPayer != null;
		}

		internal bool IsSetVersionId()
		{
			return versionId != null;
		}
	}
}
