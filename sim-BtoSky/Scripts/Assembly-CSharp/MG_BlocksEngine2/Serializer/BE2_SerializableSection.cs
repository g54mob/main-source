using System;
using System.Collections.Generic;

namespace MG_BlocksEngine2.Serializer
{
	[Serializable]
	public class BE2_SerializableSection
	{
		public List<BE2_SerializableBlock> childBlocks;

		public List<BE2_SerializableInput> inputs;

		public BE2_SerializableSection()
		{
			childBlocks = new List<BE2_SerializableBlock>();
			inputs = new List<BE2_SerializableInput>();
		}
	}
}
