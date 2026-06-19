using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class AchievementSetT
	{
		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public string GameName;

		[XmlElement]
		public List<AchievementT> Achievement;
	}
}
