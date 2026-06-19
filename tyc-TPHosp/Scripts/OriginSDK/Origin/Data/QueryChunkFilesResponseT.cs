using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryChunkFilesResponseT
	{
		[XmlElement]
		public List<string> Files;
	}
}
