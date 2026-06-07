using System;
using System.Collections.Generic;

namespace Synty.SidekickCharacters.Serialization
{
	[Serializable]
	public class SerializedCharacter
	{
		public string Name { get; set; }

		public int Species { get; set; }

		public List<SerializedPart> Parts { get; set; }

		public SerializedColorSet ColorSet { get; set; }

		public List<SerializedColorRow> ColorRows { get; set; }

		public SerializedBlendShapeValues BlendShapes { get; set; }
	}
}
