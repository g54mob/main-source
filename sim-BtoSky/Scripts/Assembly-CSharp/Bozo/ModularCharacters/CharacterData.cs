using System;
using System.Collections.Generic;

namespace Bozo.ModularCharacters
{
	[Serializable]
	public class CharacterData
	{
		public string characterName;

		public List<string> bodyIDs;

		public List<float> bodyShapes;

		public List<string> faceIDs;

		public List<float> faceShapes;

		public List<string> bodyModsKeys;

		public List<BodyModData> bodyMods;

		public List<OutfitData> outfitDatas;

		public OutfitData bodyData;

		public float stance;
	}
}
