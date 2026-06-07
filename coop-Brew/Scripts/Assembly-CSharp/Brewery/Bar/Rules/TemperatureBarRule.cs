using UnityEngine;

namespace Brewery.Bar.Rules
{
	[CreateAssetMenu(fileName = "TemperatureBarRule", menuName = "Brewery/Bar Rules/Temperature Rule (Inside)")]
	public class TemperatureBarRule : BarRuleBase
	{
		[Header("Time Settings")]
		[Tooltip("Hour when day starts (need cooling). Default: 6 (6am)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int dayStartHour;

		[Tooltip("Hour when night starts (need heating). Default: 22 (10pm)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int nightStartHour;

		private static readonly string[] TooHotKeys;

		private static readonly string[] TooColdKeys;

		private static readonly string[] WrongModeKeys;

		private const string FailTooHot = "TOO_HOT";

		private const string FailTooCold = "TOO_COLD";

		private const string FailWrongMode = "WRONG_MODE";

		public override RuleStatus Evaluate(BarRuleContext context)
		{
			return default(RuleStatus);
		}

		public override string GetComplaintMessage(RuleStatus status)
		{
			return null;
		}

		public override string GetStatusMessage(RuleStatus status)
		{
			return null;
		}

		private bool IsDaytimeInternal(BarRuleContext context)
		{
			return false;
		}
	}
}
