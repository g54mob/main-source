using System;

namespace Simulator
{
	[Serializable]
	public class SaveClass_GameScore
	{
		public int sales;

		public int trashThrown;

		public SaveClass_GameScore()
		{
			sales = 0;
			trashThrown = 0;
		}
	}
}
