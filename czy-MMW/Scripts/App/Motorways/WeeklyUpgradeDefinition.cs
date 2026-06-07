using System;
using System.Collections.Generic;
using FixMath;
using UnityEngine;

namespace Motorways
{
	[Serializable]
	public class WeeklyUpgradeDefinition
	{
		public UpgradePackageDefinition package;

		public Fix64 baseWeight = Fix64.One;

		[Tooltip("How much this should increase in weight each week it isn't offered.")]
		public Fix64 weightIncreaseWhenNotOffered;

		[Tooltip("The maximum number of packages that can be taken by the player. 0 is infinite")]
		public int maxPackageCount;

		[Tooltip("The first week this package can appear (inclusive)")]
		public int startingWeek;

		[Tooltip("The last week that this package can appear (inclusive)")]
		public int lastWeek;

		[Tooltip("The number of upgrades that the player must have taken by the provided week")]
		public List<ExpectedUpgradeTimeline> expectedUpgradeTimeline;

		[Tooltip("The type of upgrade to check that the player has remaining to change weights based on.")]
		public UpgradeType relativeUpgradeType;

		[Tooltip("Weight change (y-axis) against remaining upgrades (x-axis).")]
		public AnimationCurve relativeUpgradeMultiplierCurve;

		public WeeklyUpgradeDefinition NewCopy()
		{
			return new WeeklyUpgradeDefinition
			{
				package = new UpgradePackageDefinition
				{
					type = package.type,
					amount = package.amount,
					additionalConcrete = package.additionalConcrete
				},
				baseWeight = baseWeight,
				weightIncreaseWhenNotOffered = weightIncreaseWhenNotOffered,
				maxPackageCount = maxPackageCount,
				startingWeek = startingWeek,
				lastWeek = lastWeek,
				expectedUpgradeTimeline = expectedUpgradeTimeline,
				relativeUpgradeType = relativeUpgradeType,
				relativeUpgradeMultiplierCurve = relativeUpgradeMultiplierCurve
			};
		}
	}
}
