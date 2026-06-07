using UnityEngine;

namespace Brewery.Bar.Rules
{
	[CreateAssetMenu(fileName = "OutsideHeaterBarRule", menuName = "Brewery/Bar Rules/Outside Heater Rule")]
	public class OutsideHeaterBarRule : BarRuleBase
	{
		[Header("Time Settings")]
		[Tooltip("Hour when day starts (heater not needed). Default: 6 (6am)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int dayStartHour;

		[Tooltip("Hour when night starts (heater needed). Default: 22 (10pm)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int nightStartHour;

		private static readonly string[] ColdOutsideKeys;

		private const string FailCold = "COLD";

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
