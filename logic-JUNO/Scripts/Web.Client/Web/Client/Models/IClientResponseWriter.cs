using System.Xml.Linq;

namespace Web.Client.Models
{
	public interface IClientResponseWriter
	{
		void SetError(string error);

		void SetValue(string key, string value);

		void SetXmlResult(XElement result);
	}
}
