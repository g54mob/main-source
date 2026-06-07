using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models
{
	public class ClientResponse : IClientResponseWriter
	{
		private const string XmlResultTagName = "XmlResult";

		private Dictionary<string, string> _data = new Dictionary<string, string>();

		public string Error { get; private set; }

		public bool Succeeded => string.IsNullOrWhiteSpace(Error);

		public bool UseErrorCode { get; private set; }

		public XElement XmlResult { get; private set; }

		public ClientResponse(int version)
		{
			SetValue("Version", version);
		}

		public ClientResponse(string xml, int clientVersion)
		{
			XElement xElement = XDocument.Parse(xml).Element("ClientResponse");
			foreach (XAttribute item in xElement.Attributes())
			{
				SetValue(item.Name.ToString(), item.Value);
			}
			XmlResult = xElement.Element("XmlResult");
			XElement xElement2 = xElement.Element("Error");
			if (xElement2 != null)
			{
				Error = xElement2.Value;
			}
			if ((int.TryParse(GetValue("Version"), out var result) ? result : 0) > clientVersion)
			{
				Error = "This game requires an update.";
			}
		}

		public string GenerateXml()
		{
			XElement xElement = new XElement("ClientResponse", XmlResult);
			foreach (KeyValuePair<string, string> datum in _data)
			{
				xElement.SetAttributeValue(datum.Key, datum.Value);
			}
			if (!string.IsNullOrWhiteSpace(Error))
			{
				xElement.Add(new XElement("Error", Error));
			}
			return xElement.ToString();
		}

		public string GetValue(string key)
		{
			if (HasValue(key))
			{
				return _data[key];
			}
			return null;
		}

		public bool HasValue(string key)
		{
			return _data.ContainsKey(key);
		}

		void IClientResponseWriter.SetError(string error, bool returnErrorCode)
		{
			Error = error;
			UseErrorCode = returnErrorCode;
		}

		void IClientResponseWriter.SetValue(string key, object value)
		{
			SetValue(key, value);
		}

		void IClientResponseWriter.SetXmlResult(XElement result)
		{
			XmlResult = new XElement("XmlResult");
			XmlResult.Add(result);
		}

		private void SetValue(string key, object value)
		{
			_data[key] = value.ToString();
		}
	}
}
