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

		public XElement XmlResult { get; private set; }

		public ClientResponse()
		{
		}

		public ClientResponse(string xml)
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

		void IClientResponseWriter.SetError(string error)
		{
			Error = error;
		}

		void IClientResponseWriter.SetValue(string key, string value)
		{
			SetValue(key, value);
		}

		void IClientResponseWriter.SetXmlResult(XElement result)
		{
			XmlResult = new XElement("XmlResult");
			XmlResult.Add(result);
		}

		private void SetValue(string key, string value)
		{
			_data[key] = value;
		}
	}
}
