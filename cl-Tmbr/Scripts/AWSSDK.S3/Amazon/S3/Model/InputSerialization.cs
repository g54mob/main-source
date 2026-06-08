using System.Xml;
using Amazon.S3.Model.Internal.MarshallTransformations;

namespace Amazon.S3.Model
{
	public class InputSerialization
	{
		public CSVInput CSV { get; set; }

		public CompressionType CompressionType { get; set; } = CompressionType.None;

		public JSONInput JSON { get; set; }

		public ParquetInput Parquet { get; set; }

		internal bool IsSetCSV()
		{
			return CSV != null;
		}

		internal bool IsSetCompressionType()
		{
			return CompressionType != null;
		}

		internal bool IsSetJSON()
		{
			return JSON != null;
		}

		internal bool IsSetParquet()
		{
			return Parquet != null;
		}

		internal void Marshall(string memberName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(memberName);
			if (IsSetCompressionType())
			{
				xmlWriter.WriteElementString("CompressionType", S3Transforms.ToXmlStringValue(CompressionType.Value));
			}
			if (IsSetCSV())
			{
				CSV.Marshall("CSV", xmlWriter);
			}
			if (IsSetJSON())
			{
				JSON.Marshall("JSON", xmlWriter);
			}
			if (IsSetParquet())
			{
				Parquet.Marshall("Parquet", xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}
	}
}
