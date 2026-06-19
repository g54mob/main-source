using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryAchievementsT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong PersonaId;

		[XmlAttribute]
		public bool All;

		[XmlElement]
		public List<string> GameId;
	}
}
