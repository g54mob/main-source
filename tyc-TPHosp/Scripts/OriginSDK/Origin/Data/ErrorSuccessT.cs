using System.Xml.Serialization;

namespace Origin.Data
{
	public class ErrorSuccessT
	{
		[XmlAttribute]
		public int Code;

		[XmlAttribute]
		public string Description;
	}
}
