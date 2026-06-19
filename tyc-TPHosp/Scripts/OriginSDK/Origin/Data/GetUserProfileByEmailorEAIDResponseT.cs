using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetUserProfileByEmailorEAIDResponseT
	{
		[XmlAttribute]
		public string Return;

		[XmlElement]
		public List<UserT> User;
	}
}
