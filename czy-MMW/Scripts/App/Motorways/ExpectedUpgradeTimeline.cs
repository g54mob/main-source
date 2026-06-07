using System;
using FixMath;
using UnityEngine;

namespace Motorways
{
	[Serializable]
	public class ExpectedUpgradeTimeline
	{
		public int week;

		[Tooltip("How many of this upgrade do we expect to have by this week?")]
		public int expectedUpgradeCount;

		[Tooltip("How much extra weight do we put on the package if they haven't had this many of this upgrade by now?")]
		public Fix64 bonusWeightIfNotMet;
	}
}
