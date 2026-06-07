using System;

namespace VampireSurvivors.Data.Props
{
	[Serializable]
	public class PropData
	{
		public string textureName { get; set; }

		public string frameName { get; set; }

		public int destroyedAmount { get; set; }

		public float maxHp { get; set; }

		public string destructibleType { get; set; }
	}
}
