using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Amazon.S3.Model
{
	public class Stats
	{
		public long BytesScanned { get; set; }

		public long BytesProcessed { get; set; }

		public long BytesReturned { get; set; }

		internal static Stats Unmarshall(byte[] payload)
		{
			XElement xElement = XElement.Parse(Encoding.UTF8.GetString(payload, 0, payload.Length));
			if (xElement.Name != "Stats")
			{
				throw new InvalidOperationException("Top element name expected to be \"Stats\"");
			}
			long bytesScanned = long.Parse(xElement.Descendants("BytesScanned").First().Value, CultureInfo.InvariantCulture);
			long bytesProcessed = long.Parse(xElement.Descendants("BytesProcessed").First().Value, CultureInfo.InvariantCulture);
			long bytesReturned = long.Parse(xElement.Descendants("BytesReturned").First().Value, CultureInfo.InvariantCulture);
			return new Stats
			{
				BytesScanned = bytesScanned,
				BytesProcessed = bytesProcessed,
				BytesReturned = bytesReturned
			};
		}
	}
}
