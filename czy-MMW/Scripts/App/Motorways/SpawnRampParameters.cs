using System;
using FixMath;

namespace Motorways
{
	[Serializable]
	public class SpawnRampParameters
	{
		public int startDay = 35;

		public Fix64 dailyIncrement = (Fix64)0.022;
	}
}
