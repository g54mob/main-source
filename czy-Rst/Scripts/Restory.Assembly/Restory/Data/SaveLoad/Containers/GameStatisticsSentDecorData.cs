using System;
using Restory.Data.Decors;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class GameStatisticsSentDecorData
	{
		public DecorInfo Info;

		public int MoneyReceived;

		public int DayIndex;
	}
}
