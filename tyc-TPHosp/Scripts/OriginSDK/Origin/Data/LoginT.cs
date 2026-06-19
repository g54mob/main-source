using System.Xml.Serialization;

namespace Origin.Data
{
	public class LoginT
	{
		[XmlAttribute]
		public bool IsLoggedIn;

		[XmlAttribute]
		public int UserIndex;

		[XmlAttribute]
		public LoginReasonCodeT LoginReasonCode;
	}
}
