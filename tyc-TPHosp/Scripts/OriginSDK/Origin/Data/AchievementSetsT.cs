using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class AchievementSetsT
	{
		[XmlElement]
		public List<AchievementSetT> AchievementSet;
	}
}
