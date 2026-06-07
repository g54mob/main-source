using System;
using System.Collections.Generic;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	public class PreloadData
	{
		public List<CharacterType> characters { get; set; }

		public List<string> textures { get; set; }

		public List<string> videos { get; set; }

		public List<BgmType> bgm { get; set; }
	}
}
