using System;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Serialization
{
	[Serializable]
	public class SerializedPart
	{
		public string Name { get; set; }

		public CharacterPartType PartType { get; set; }

		public string PartVersion { get; set; }

		public SerializedPart()
		{
		}

		public SerializedPart(string name, CharacterPartType partType, string partVersion)
		{
		}
	}
}
