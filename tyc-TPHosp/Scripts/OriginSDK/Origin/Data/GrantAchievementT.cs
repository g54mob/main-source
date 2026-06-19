using System.Xml.Serialization;

namespace Origin.Data
{
	public class GrantAchievementT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong PersonaId;

		[XmlAttribute]
		public string AchievementId;

		[XmlAttribute]
		public string AchievementCode;

		[XmlAttribute]
		public int Progress;
	}
}
