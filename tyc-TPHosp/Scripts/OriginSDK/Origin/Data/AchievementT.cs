using System.Xml.Serialization;

namespace Origin.Data
{
	public class AchievementT
	{
		[XmlAttribute]
		public string Id;

		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public int Progress;

		[XmlAttribute]
		public int Total;

		[XmlAttribute]
		public int Count;

		[XmlAttribute]
		public string Description;

		[XmlAttribute]
		public string HowTo;

		[XmlAttribute]
		public string ImageId;

		[XmlAttribute]
		public string GrantDate;

		[XmlAttribute]
		public string Expiration;
	}
}
