using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class ShowIGOWindowEventT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public IGOWindowT WindowId;

		[XmlAttribute]
		public bool Show;

		[XmlAttribute]
		public int Flags;

		[XmlAttribute]
		public string ContentId;

		[XmlElement]
		public List<ulong> TargetId;

		[XmlElement]
		public string String;

		[XmlElement]
		public List<string> Args;

		[XmlElement]
		public List<string> Categories;

		[XmlElement]
		public List<string> MasterTitleIds;

		[XmlElement]
		public List<string> Offers;
	}
}
