using System.Xml;

namespace Amazon.S3.Model
{
	public class OutputSerialization
	{
		public CSVOutput CSV { get; set; }

		public JSONOutput JSON { get; set; }

		internal bool IsSetCSV()
		{
			return CSV != null;
		}

		internal bool IsSetJSON()
		{
			return JSON != null;
		}

		internal void Marshall(string propertyName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(propertyName);
			if (IsSetCSV())
			{
				CSV.Marshall("CSV", xmlWriter);
			}
			if (IsSetJSON())
			{
				JSON.Marshall("JSON", xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}
	}
}
