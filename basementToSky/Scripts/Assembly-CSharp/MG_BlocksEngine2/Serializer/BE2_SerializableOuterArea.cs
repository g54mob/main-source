using System;
using System.Collections.Generic;

namespace MG_BlocksEngine2.Serializer
{
	[Serializable]
	public class BE2_SerializableOuterArea
	{
		public List<BE2_SerializableBlock> childBlocks;

		public BE2_SerializableOuterArea()
		{
			childBlocks = new List<BE2_SerializableBlock>();
		}
	}
}
