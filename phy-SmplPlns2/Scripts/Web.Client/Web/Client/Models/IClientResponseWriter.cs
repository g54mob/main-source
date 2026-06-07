using System.Xml.Linq;

namespace Web.Client.Models
{
	public interface IClientResponseWriter
	{
		void SetError(string error, bool returnErrorCode = false);

		void SetValue(string key, object value);

		void SetXmlResult(XElement result);
	}
}
