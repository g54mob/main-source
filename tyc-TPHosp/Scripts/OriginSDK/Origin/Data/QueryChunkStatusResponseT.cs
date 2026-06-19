using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryChunkStatusResponseT
	{
		[XmlElement]
		public List<ChunkStatusT> ChunkStatus;
	}
}
