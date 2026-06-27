using System;
using UnityEngine;

namespace Restory.Data.PC
{
	[Serializable]
	public class HackingTimelineSettings
	{
		[Header("Timeline")]
		[SerializeField]
		[Range(0f, 50f)]
		[Tooltip("No events in the first N% of hack progress.")]
		private int emptyStartZonePercentage = 20;

		[SerializeField]
		[Range(0f, 50f)]
		[Tooltip("No events in the last N% of hack progress.")]
		private int emptyEndZonePercentage = 20;

		[SerializeField]
		[Range(0f, 50f)]
		[Tooltip("Minimum gap between consecutive events.")]
		private int minEventGapPercentage = 15;

		[SerializeField]
		[Range(0f, 20f)]
		[Tooltip("If progress falls this far below a passed event, that event be active again.")]
		private int eventComebackThresholdPercentage = 5;

		[SerializeField]
		[Range(0f, 3f)]
		[Tooltip("Minimum number of random events per hack.")]
		private int minEventCount = 1;

		[SerializeField]
		[Range(0f, 6f)]
		[Tooltip("Maximum number of random events per hack.")]
		private int maxEventCount = 3;

		[Space(10f)]
		[Header("Delay")]
		[SerializeField]
		[Range(0f, 2f)]
		[Tooltip("Min duration of delay popup.")]
		private float minHackingDelayInSeconds = 1f;

		[SerializeField]
		[Range(0f, 4f)]
		[Tooltip("Max duration of delay popup.")]
		private float maxHackingDelayInSeconds = 2f;

		[Space(10f)]
		[Header("Impacts")]
		[SerializeField]
		[Range(0f, 100f)]
		[Tooltip("Hack progress added for successful Break delay passing.")]
		private int breakBonusPercentage = 10;

		[SerializeField]
		[Range(0f, 100f)]
		[Tooltip("Hack progress added for successful Alert delay passing.")]
		private int alertBonusPercentage = 10;

		[SerializeField]
		[Range(0f, 100f)]
		[Tooltip("Hack progress added for correct Decision.")]
		private int decisionBonusPercentage = 10;

		[SerializeField]
		[Range(0f, 100f)]
		[Tooltip("Hack progress removed for typing during Break delay.")]
		private int breakPenaltyPercentage = 10;

		[SerializeField]
		[Range(0f, 100f)]
		[Tooltip("Hack progress removed for typing during Alert delay.")]
		private int alertPenaltyPercentage = 10;

		[SerializeField]
		[Range(0f, 100f)]
		[Tooltip("Hack progress removed for wrong Decision.")]
		private int decisionPenaltyPercentage = 100;

		public int EmptyStartZonePercentage => emptyStartZonePercentage;

		public int EmptyEndZonePercentage => emptyEndZonePercentage;

		public int MinEventGapPercentage => minEventGapPercentage;

		public int EventComebackThresholdPercentage => eventComebackThresholdPercentage;

		public int MinEventCount => minEventCount;

		public int MaxEventCount => maxEventCount;

		public float MinHackingDelayInSeconds => minHackingDelayInSeconds;

		public float MaxHackingDelayInSeconds => maxHackingDelayInSeconds;

		public int BreakBonusPercentage => breakBonusPercentage;

		public int AlertBonusPercentage => alertBonusPercentage;

		public int DecisionBonusPercentage => decisionBonusPercentage;

		public int BreakPenaltyPercentage => breakPenaltyPercentage;

		public int AlertPenaltyPercentage => alertPenaltyPercentage;

		public int DecisionPenaltyPercentage => decisionPenaltyPercentage;
	}
}
