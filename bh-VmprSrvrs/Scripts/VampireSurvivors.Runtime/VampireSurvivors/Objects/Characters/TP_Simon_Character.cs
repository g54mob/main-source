using System.Collections.Generic;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Simon_Character : TP_Character
	{
		private List<float> _critChancesArray;

		private int _critIndex;

		public override void AfterFullInitialization()
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override float PArmor()
		{
			return 0f;
		}
	}
}
