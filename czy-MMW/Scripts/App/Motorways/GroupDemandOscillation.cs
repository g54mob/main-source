using System;
using FixMath;
using UnityEngine.Serialization;

namespace Motorways
{
	[Serializable]
	public class GroupDemandOscillation
	{
		public int index;

		[FormerlySerializedAs("minimumDemand")]
		public Fix64 baseDemand = Fix64Consts.OneHalf;

		[FormerlySerializedAs("maximumDemand")]
		public Fix64 burstDemand = Fix64Consts.Two;

		public int eccentricity;

		public int periodInDays = 7;

		public Fix64 GetDemandAtDay(Fix64 timeInDays)
		{
			timeInDays %= (Fix64)periodInDays;
			return baseDemand + Fix64.Pow(Fix64.Abs(Fix64.Sin(timeInDays * Fix64.Pi / (Fix64)periodInDays)), (Fix64)(2 + eccentricity)) * (burstDemand - baseDemand);
		}
	}
}
